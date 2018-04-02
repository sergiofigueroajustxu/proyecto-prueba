Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Imports System.Text

Public Class Factura
    Private prtSettings As Object
    Private tipopapel As String = "Legal"
    Private horizontal As Boolean = False

    Private Sub Venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'With ListView1
        '.View = View.Details
        '.Columns.Add("Id", 0)
        '.Columns.Add("Producto", 260)
        '.Columns.Add("Precio", 70)
        '.Columns.Add("Cantidad", 70)
        '.Columns.Add("Valor", 100)
        '.Columns.Add("Codigo", 0)
        'End With

        If File.Exists("c:\temp\imagenes\logo.png") Then 'Comprobamos que el archivo existe'
            PictureBox1.Load("c:\temp\imagenes\logo.png")
        End If
    End Sub

    'funcion para colorear el listview'
    Public Sub colorearListView(ByRef list As ListView)
        Dim i As Integer

        For i = 0 To list.Items.Count - 1
            If i = Int(i / 2) * 2 Then
                list.Items.Item(i).BackColor = Color.Red
            Else
                list.Items.Item(i).BackColor = Color.Yellow
            End If
        Next
        list.FullRowSelect = True
    End Sub

    Private Sub TextBox6__KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(ChrW(Keys.Tab), True)
        End If

    End Sub

    Private Sub btnvender_Click(sender As Object, e As EventArgs) Handles btnvender.Click

        Dim printDoc = New System.Drawing.Printing.PrintDocument
        AddHandler printDoc.PrintPage, AddressOf print_PrintPage

        Dim lineaactual = 0

        '        'If esPreview Then
        Dim prtPrev As New PrintPreviewDialog
        'prtPrev.Enabled = True


        prtPrev.Document = printDoc
        prtPrev.Text = "Previsualizar documento"
        prtPrev.ShowDialog()
        ''Else
        ''   prtDoc.Print()
        ''End If

    End Sub

    Private Sub print_PrintPage(ByVal sender As Object,
                            ByVal e As Printing.PrintPageEventArgs)


        e.PageSettings.Margins.Left = 0
        e.PageSettings.Margins.Top = 0
        e.PageSettings.Margins.Right = 0
        e.PageSettings.Margins.Bottom = 0


        Dim prFont As New Font("Courier New", 8, FontStyle.Regular, GraphicsUnit.Point)
        Dim xPos As Single = e.MarginBounds.Left
        Dim yPos As Single = prFont.GetHeight(e.Graphics)

        Dim lineatexto As String
        Dim px, py As Integer
        Dim linea, lineadato As String
        Dim posicionentexto As String


        Dim indice As Integer = 0
        Dim path1, path2 As String
        path1 = "c:\temp\impresiones\factura " + TextBox2.Text + ".txt"
        path2 = "c:\temp\impresiones\Datosfactura.txt"

        Using fs As FileStream = File.Create(path2)
            lineatexto = ""
            posicionentexto = ""
            'lee posiciones y genera datos
            If File.Exists(path1) Then
                Using sr As StreamReader = File.OpenText(path1)
                    Do While sr.Peek() >= 0
                        linea = sr.ReadLine()
                        indice = indice + 1
                        posicionentexto = Mid(linea, 1, 10)
                        lineatexto = Trim(Mid(linea, 11))
                        lineadato = "" ' lineatexto


                        If Mid(lineatexto, 1, 1) <> "<" Then lineadato = lineatexto
                        If lineatexto = "<NIT>" Then lineadato = TextBox1.Text
                        If lineatexto = "<NOMBRE>" Then lineadato = Mid(TextBox7.Text, 1, 100)
                        If lineatexto = "<DIRECCION>" Then lineadato = Mid(TextBox3.Text, 1, 100)
                        If lineatexto = "<TIPO DOCUMENTO>" Then lineadato = TextBox2.Text
                        If lineatexto = "<SUCURSAL>" Then lineadato = TextBox6.Text
                        If lineatexto = "<CORRELATIVO>" Then lineadato = TextBox5.Text
                        If lineatexto = "<VENDEDOR>" Then lineadato = TextBox8.Text
                        If lineatexto = "<FECHA>" Then lineadato = DateTimePicker1.Value.ToString
                        If lineatexto = "<TOTAL>" Then lineadato = formatoNumero(Label4.Text)
                        If lineatexto = "<DIASCREDITO>" Then lineadato = CStr((DateTimePicker3.Value - DateTimePicker1.Value).Days)
                        If lineatexto = "<VENCIMIENTO>" Then lineadato = DateTimePicker3.Value.ToString
                        If lineatexto = "<TOTALLETRAS>" Then lineadato = convertirLetras(Label4.Text)

                        Dim conteoLineas As Integer
                        conteoLineas = ListView1.Items.Count

                        If conteoLineas > 0 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_01>" : lineadato = Mid(ListView1.Items(0).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_01>" : lineadato = Mid(ListView1.Items(0).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_01>" : lineadato = formatoNumero(ListView1.Items(0).SubItems(3).Text)
                                Case "<PRECIO_01>" : lineadato = formatoNumero(ListView1.Items(0).SubItems(2).Text)
                                Case "<IMPORTE_01>" : lineadato = formatoNumero(ListView1.Items(0).SubItems(4).Text)
                            End Select
                        End If

                        If conteoLineas > 1 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_02>" : lineadato = Mid(ListView1.Items(1).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_02>" : lineadato = Mid(ListView1.Items(1).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_02>" : lineadato = formatoNumero(ListView1.Items(1).SubItems(3).Text)
                                Case "<PRECIO_02>" : lineadato = formatoNumero(ListView1.Items(1).SubItems(2).Text)
                                Case "<IMPORTE_02>" : lineadato = formatoNumero(ListView1.Items(1).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 2 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_03>" : lineadato = Mid(ListView1.Items(2).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_03>" : lineadato = Mid(ListView1.Items(2).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_03>" : lineadato = formatoNumero(ListView1.Items(2).SubItems(3).Text)
                                Case "<PRECIO_03>" : lineadato = formatoNumero(ListView1.Items(2).SubItems(2).Text)
                                Case "<IMPORTE_03>" : lineadato = formatoNumero(ListView1.Items(2).SubItems(4).Text)
                            End Select
                        End If

                        If conteoLineas > 3 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_04>" : lineadato = Mid(ListView1.Items(3).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_04>" : lineadato = Mid(ListView1.Items(3).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_04>" : lineadato = formatoNumero(ListView1.Items(3).SubItems(3).Text)
                                Case "<PRECIO_04>" : lineadato = formatoNumero(ListView1.Items(3).SubItems(2).Text)
                                Case "<IMPORTE_04>" : lineadato = formatoNumero(ListView1.Items(3).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 4 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_05>" : lineadato = Mid(ListView1.Items(4).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_05>" : lineadato = Mid(ListView1.Items(4).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_05>" : lineadato = formatoNumero(ListView1.Items(4).SubItems(3).Text)
                                Case "<PRECIO_05>" : lineadato = formatoNumero(ListView1.Items(4).SubItems(2).Text)
                                Case "<IMPORTE_05>" : lineadato = formatoNumero(ListView1.Items(4).SubItems(4).Text)
                            End Select
                        End If

                        If conteoLineas > 5 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_06>" : lineadato = Mid(ListView1.Items(5).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_06>" : lineadato = Mid(ListView1.Items(5).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_06>" : lineadato = formatoNumero(ListView1.Items(5).SubItems(3).Text)
                                Case "<PRECIO_06>" : lineadato = formatoNumero(ListView1.Items(5).SubItems(2).Text)
                                Case "<IMPORTE_06>" : lineadato = formatoNumero(ListView1.Items(5).SubItems(4).Text)
                            End Select
                        End If

                        If conteoLineas > 6 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_07>" : lineadato = Mid(ListView1.Items(6).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_07>" : lineadato = Mid(ListView1.Items(6).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_07>" : lineadato = formatoNumero(ListView1.Items(6).SubItems(3).Text)
                                Case "<PRECIO_07>" : lineadato = formatoNumero(ListView1.Items(6).SubItems(2).Text)
                                Case "<IMPORTE_07>" : lineadato = formatoNumero(ListView1.Items(6).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 7 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_08>" : lineadato = Mid(ListView1.Items(7).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_08>" : lineadato = Mid(ListView1.Items(7).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_08>" : lineadato = formatoNumero(ListView1.Items(7).SubItems(3).Text)
                                Case "<PRECIO_08>" : lineadato = formatoNumero(ListView1.Items(7).SubItems(2).Text)
                                Case "<IMPORTE_08>" : lineadato = formatoNumero(ListView1.Items(7).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 8 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_09>" : lineadato = Mid(ListView1.Items(8).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_09>" : lineadato = Mid(ListView1.Items(8).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_09>" : lineadato = formatoNumero(ListView1.Items(8).SubItems(3).Text)
                                Case "<PRECIO_09>" : lineadato = formatoNumero(ListView1.Items(8).SubItems(2).Text)
                                Case "<IMPORTE_09>" : lineadato = formatoNumero(ListView1.Items(8).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 9 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_10>" : lineadato = Mid(ListView1.Items(9).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_10>" : lineadato = Mid(ListView1.Items(9).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_10>" : lineadato = formatoNumero(ListView1.Items(9).SubItems(3).Text)
                                Case "<PRECIO_10>" : lineadato = formatoNumero(ListView1.Items(9).SubItems(2).Text)
                                Case "<IMPORTE_10>" : lineadato = formatoNumero(ListView1.Items(9).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 10 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_11>" : lineadato = Mid(ListView1.Items(10).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_11>" : lineadato = Mid(ListView1.Items(10).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_11>" : lineadato = formatoNumero(ListView1.Items(10).SubItems(3).Text)
                                Case "<PRECIO_11>" : lineadato = formatoNumero(ListView1.Items(10).SubItems(2).Text)
                                Case "<IMPORTE_11>" : lineadato = formatoNumero(ListView1.Items(10).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 11 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_12>" : lineadato = Mid(ListView1.Items(11).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_12>" : lineadato = Mid(ListView1.Items(11).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_12>" : lineadato = formatoNumero(ListView1.Items(11).SubItems(3).Text)
                                Case "<PRECIO_12>" : lineadato = formatoNumero(ListView1.Items(11).SubItems(2).Text)
                                Case "<IMPORTE_12>" : lineadato = formatoNumero(ListView1.Items(11).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 12 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_13>" : lineadato = Mid(ListView1.Items(12).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_13>" : lineadato = Mid(ListView1.Items(12).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_13>" : lineadato = formatoNumero(ListView1.Items(12).SubItems(3).Text)
                                Case "<PRECIO_13>" : lineadato = formatoNumero(ListView1.Items(12).SubItems(2).Text)
                                Case "<IMPORTE_13>" : lineadato = formatoNumero(ListView1.Items(12).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 13 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_14>" : lineadato = Mid(ListView1.Items(13).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_14>" : lineadato = Mid(ListView1.Items(13).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_14>" : lineadato = formatoNumero(ListView1.Items(13).SubItems(3).Text)
                                Case "<PRECIO_14>" : lineadato = formatoNumero(ListView1.Items(13).SubItems(2).Text)
                                Case "<IMPORTE_14>" : lineadato = formatoNumero(ListView1.Items(13).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 14 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_15>" : lineadato = Mid(ListView1.Items(14).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_15>" : lineadato = Mid(ListView1.Items(14).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_15>" : lineadato = formatoNumero(ListView1.Items(14).SubItems(3).Text)
                                Case "<PRECIO_15>" : lineadato = formatoNumero(ListView1.Items(14).SubItems(2).Text)
                                Case "<IMPORTE_15>" : lineadato = formatoNumero(ListView1.Items(14).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 15 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_16>" : lineadato = Mid(ListView1.Items(15).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_16>" : lineadato = Mid(ListView1.Items(15).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_16>" : lineadato = formatoNumero(ListView1.Items(15).SubItems(3).Text)
                                Case "<PRECIO_16>" : lineadato = formatoNumero(ListView1.Items(15).SubItems(2).Text)
                                Case "<IMPORTE_16>" : lineadato = formatoNumero(ListView1.Items(15).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 16 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_17>" : lineadato = Mid(ListView1.Items(16).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_17>" : lineadato = Mid(ListView1.Items(16).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_17>" : lineadato = formatoNumero(ListView1.Items(16).SubItems(3).Text)
                                Case "<PRECIO_17>" : lineadato = formatoNumero(ListView1.Items(16).SubItems(2).Text)
                                Case "<IMPORTE_17>" : lineadato = formatoNumero(ListView1.Items(16).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 17 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_18>" : lineadato = Mid(ListView1.Items(17).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_18>" : lineadato = Mid(ListView1.Items(17).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_18>" : lineadato = formatoNumero(ListView1.Items(17).SubItems(3).Text)
                                Case "<PRECIO_18>" : lineadato = formatoNumero(ListView1.Items(17).SubItems(2).Text)
                                Case "<IMPORTE_18>" : lineadato = formatoNumero(ListView1.Items(17).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 18 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_19>" : lineadato = Mid(ListView1.Items(18).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_19>" : lineadato = Mid(ListView1.Items(18).SubItems(1).Text, 1, 50)
                                Case "<CANTIDAD_19>" : lineadato = formatoNumero(ListView1.Items(18).SubItems(3).Text)
                                Case "<PRECIO_19>" : lineadato = formatoNumero(ListView1.Items(18).SubItems(2).Text)
                                Case "<IMPORTE_19>" : lineadato = formatoNumero(ListView1.Items(18).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 19 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_20>" : lineadato = Mid(ListView1.Items(19).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_20>" : lineadato = Mid(ListView1.Items(19).SubItems(1).Text, 1, 40)
                                Case "<CANTIDAD_20>" : lineadato = formatoNumero(ListView1.Items(19).SubItems(3).Text)
                                Case "<PRECIO_20>" : lineadato = formatoNumero(ListView1.Items(19).SubItems(2).Text)
                                Case "<IMPORTE_20>" : lineadato = formatoNumero(ListView1.Items(19).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 20 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_21>" : lineadato = Mid(ListView1.Items(20).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_21>" : lineadato = Mid(ListView1.Items(20).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_21>" : lineadato = formatoNumero(ListView1.Items(20).SubItems(3).Text)
                                Case "<PRECIO_21>" : lineadato = formatoNumero(ListView1.Items(20).SubItems(2).Text)
                                Case "<IMPORTE_21>" : lineadato = formatoNumero(ListView1.Items(20).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 21 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_22>" : lineadato = Mid(ListView1.Items(21).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_22>" : lineadato = Mid(ListView1.Items(21).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_22>" : lineadato = formatoNumero(ListView1.Items(21).SubItems(3).Text)
                                Case "<PRECIO_22>" : lineadato = formatoNumero(ListView1.Items(21).SubItems(2).Text)
                                Case "<IMPORTE_22>" : lineadato = formatoNumero(ListView1.Items(21).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 22 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_23>" : lineadato = Mid(ListView1.Items(22).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_23>" : lineadato = Mid(ListView1.Items(22).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_23>" : lineadato = formatoNumero(ListView1.Items(22).SubItems(3).Text)
                                Case "<PRECIO_23>" : lineadato = formatoNumero(ListView1.Items(22).SubItems(2).Text)
                                Case "<IMPORTE_23>" : lineadato = formatoNumero(ListView1.Items(22).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 23 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_24>" : lineadato = Mid(ListView1.Items(23).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_24>" : lineadato = Mid(ListView1.Items(23).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_24>" : lineadato = formatoNumero(ListView1.Items(23).SubItems(3).Text)
                                Case "<PRECIO_24>" : lineadato = formatoNumero(ListView1.Items(23).SubItems(2).Text)
                                Case "<IMPORTE_24>" : lineadato = formatoNumero(ListView1.Items(23).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 24 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_25>" : lineadato = Mid(ListView1.Items(24).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_25>" : lineadato = Mid(ListView1.Items(24).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_25>" : lineadato = formatoNumero(ListView1.Items(24).SubItems(3).Text)
                                Case "<PRECIO_25>" : lineadato = formatoNumero(ListView1.Items(24).SubItems(2).Text)
                                Case "<IMPORTE_25>" : lineadato = formatoNumero(ListView1.Items(24).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 25 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_26>" : lineadato = Mid(ListView1.Items(25).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_26>" : lineadato = Mid(ListView1.Items(25).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_26>" : lineadato = formatoNumero(ListView1.Items(25).SubItems(3).Text)
                                Case "<PRECIO_26>" : lineadato = formatoNumero(ListView1.Items(25).SubItems(2).Text)
                                Case "<IMPORTE_26>" : lineadato = formatoNumero(ListView1.Items(25).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 26 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_27>" : lineadato = Mid(ListView1.Items(26).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_27>" : lineadato = Mid(ListView1.Items(26).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_27>" : lineadato = formatoNumero(ListView1.Items(26).SubItems(3).Text)
                                Case "<PRECIO_27>" : lineadato = formatoNumero(ListView1.Items(26).SubItems(2).Text)
                                Case "<IMPORTE_27>" : lineadato = formatoNumero(ListView1.Items(26).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 27 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_28>" : lineadato = Mid(ListView1.Items(27).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_28>" : lineadato = Mid(ListView1.Items(27).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_28>" : lineadato = formatoNumero(ListView1.Items(27).SubItems(3).Text)
                                Case "<PRECIO_28>" : lineadato = formatoNumero(ListView1.Items(27).SubItems(2).Text)
                                Case "<IMPORTE_28>" : lineadato = formatoNumero(ListView1.Items(27).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 28 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_29>" : lineadato = Mid(ListView1.Items(28).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_29>" : lineadato = Mid(ListView1.Items(28).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_29>" : lineadato = formatoNumero(ListView1.Items(28).SubItems(3).Text)
                                Case "<PRECIO_29>" : lineadato = formatoNumero(ListView1.Items(28).SubItems(2).Text)
                                Case "<IMPORTE_29>" : lineadato = formatoNumero(ListView1.Items(28).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 29 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_30>" : lineadato = Mid(ListView1.Items(29).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_30>" : lineadato = Mid(ListView1.Items(29).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_30>" : lineadato = formatoNumero(ListView1.Items(29).SubItems(3).Text)
                                Case "<PRECIO_30>" : lineadato = formatoNumero(ListView1.Items(29).SubItems(2).Text)
                                Case "<IMPORTE_30>" : lineadato = formatoNumero(ListView1.Items(29).SubItems(4).Text)
                            End Select
                        End If

                        ' idproducto = ListView1.Items(i).SubItems(0).Text
                        ' codigo_barra = ListView1.Items(i).SubItems(5).Text



                        lineatexto = posicionentexto & lineadato & Chr(13)

                        Dim info As Byte() = New UTF8Encoding(True).GetBytes(lineatexto)
                        fs.Write(info, 0, info.Length)

                    Loop
                End Using
            End If
        End Using


        Using sr As StreamReader = File.OpenText(path2)
            Do While sr.Peek() >= 0
                linea = sr.ReadLine()
                px = CInt(Mid(linea, 1, 4))
                py = CInt(Mid(linea, 6, 4))
                lineatexto = Mid(linea, 11)
                'px = px + 100 - lineatexto.Length
                e.Graphics.DrawString(lineatexto, prFont, Brushes.Black, px, py)
            Loop
        End Using


        e.HasMorePages = False

    End Sub

    Function formatoNumero(ByVal numero As String)
        Dim textoFormato As String
        textoFormato = StrDup(15 - numero.Length, " ") & numero
        Return textoFormato
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Entidad As New Entidad_Venta
        Dim Negocio As New Negocio_Venta
        If TextBox5.Text.Length > 0 Then
            With Entidad
                .idventa = TextBox5.Text
            End With
            Negocio.Eliminar_Venta(Entidad)
            Dim texto2 As String
            texto2 = Libro_Ventas.TextBox2.Text
            Libro_Ventas.TextBox2.Text = ""
            Libro_Ventas.TextBox2.Text = texto2
        End If

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub
    Function convertirLetras(ByVal numero As String)
        Dim textoFormato As String
        Dim decimales As String
        Dim enteros As String
        Dim CENTENAS As String
        Dim DECENAS As String
        Dim UNIDADES As String
        Dim CENTENASMIL As String
        Dim DECENASMIL As String
        Dim UNIDADESMIL As String
        Dim CENTENASTEXTO As String
        Dim DECENASTEXTO As String
        Dim UNIDADESTEXTO As String
        Dim CENTENASMILTEXTO As String
        Dim DECENASMILTEXTO As String
        Dim UNIDADESMILTEXTO As String
        Dim DECENAS_Y As String
        Dim DECENASMIL_Y As String

        textoFormato = FormatNumber(numero, 2)
        decimales = Mid(textoFormato, textoFormato.Length - 1, 2)
        enteros = Mid(textoFormato, 1, textoFormato.Length - 3)
        If enteros.Length > 6 Then CENTENASMIL = Mid(enteros, enteros.Length - 6, 1) Else CENTENASMIL = "0"
        If enteros.Length > 5 Then DECENASMIL = Mid(enteros, enteros.Length - 5, 1) Else DECENASMIL = "0"
        If enteros.Length > 4 Then UNIDADESMIL = Mid(enteros, enteros.Length - 4, 1) Else UNIDADESMIL = "0"

        If enteros.Length > 2 Then CENTENAS = Mid(enteros, enteros.Length - 2, 1) Else CENTENAS = "0"
        If enteros.Length > 1 Then DECENAS = Mid(enteros, enteros.Length - 1, 1) Else DECENAS = "0"
        UNIDADES = Mid(enteros, enteros.Length, 1)
        Select Case CENTENAS
            Case "1"
                CENTENASTEXTO = "CIEN(TO) "

            Case "2"
                CENTENASTEXTO = "DOSCIENTOS "
            Case "3"
                CENTENASTEXTO = "TRESCIENTOS "
            Case "4"
                CENTENASTEXTO = "CUATROCIENTOS "
            Case "5"
                CENTENASTEXTO = "QUINIENTOS "
            Case "6"
                CENTENASTEXTO = "SEISCIENTOS "
            Case "7"
                CENTENASTEXTO = "SETECIENTOS "
            Case "8"
                CENTENASTEXTO = "OCHOCIENTOS "
            Case "9"
                CENTENASTEXTO = "NOVECIENTOS "
            Case Else
                CENTENASTEXTO = " "
        End Select
        Select Case DECENAS
            Case "1"
                DECENASTEXTO = "DIEZ "
            Case "2"
                DECENASTEXTO = "VEINTE "
            Case "3"
                DECENASTEXTO = "TREINTA "
            Case "4"
                DECENASTEXTO = "CUARENTA "
            Case "5"
                DECENASTEXTO = "CINCUENTA "
            Case "6"
                DECENASTEXTO = "SESENTA "
            Case "7"
                DECENASTEXTO = "SETENTA "
            Case "8"
                DECENASTEXTO = "OCHENTA "
            Case "9"
                DECENASTEXTO = "NOVENTA "
            Case Else
                DECENASTEXTO = " "
        End Select
        Select Case UNIDADES
            Case "1"
                If DECENAS = "1" Then
                    DECENASTEXTO = "ONCE "
                    UNIDADESTEXTO = ""
                Else
                    UNIDADESTEXTO = "UN(O) "
                End If
            Case "2"
                If DECENAS = "1" Then
                    DECENASTEXTO = "DOCE "
                    UNIDADESTEXTO = ""
                Else
                    UNIDADESTEXTO = "DOS "
                End If
            Case "3"
                If DECENAS = "1" Then
                    DECENASTEXTO = "TRECE "
                    UNIDADESTEXTO = ""
                Else
                    UNIDADESTEXTO = "TRES "
                End If
            Case "4"
                If DECENAS = "1" Then
                    DECENASTEXTO = "CATORCE "
                    UNIDADESTEXTO = ""
                Else
                    UNIDADESTEXTO = "CUATRO "
                End If
            Case "5"
                If DECENAS = "1" Then
                    DECENASTEXTO = "QUINCE "
                    UNIDADESTEXTO = ""
                Else
                    UNIDADESTEXTO = "CINCO "
                End If
            Case "6"
                If DECENAS = "1" Then
                    DECENASTEXTO = "DIECISEIS "
                    UNIDADESTEXTO = ""
                Else
                    UNIDADESTEXTO = "SEIS "
                End If
            Case "7"
                If DECENAS = "1" Then
                    DECENASTEXTO = "DIECISIETE "
                    UNIDADESTEXTO = ""
                Else
                    UNIDADESTEXTO = "SIETE "
                End If
            Case "8"
                UNIDADESTEXTO = "OCHO "
            Case "9"
                UNIDADESTEXTO = "NUEVE "
            Case Else
                UNIDADESTEXTO = " "
        End Select
        Select Case CENTENASMIL
            Case "1"
                CENTENASMILTEXTO = "CIEN(TO) "

            Case "2"
                CENTENASMILTEXTO = "DOSCIENTOS "
            Case "3"
                CENTENASMILTEXTO = "TRESCIENTOS "
            Case "4"
                CENTENASMILTEXTO = "CUATROCIENTOS "
            Case "5"
                CENTENASMILTEXTO = "QUINIENTOS "
            Case "6"
                CENTENASMILTEXTO = "SEISCIENTOS "
            Case "7"
                CENTENASMILTEXTO = "SETECIENTOS "
            Case "8"
                CENTENASMILTEXTO = "OCHOCIENTOS "
            Case "9"
                CENTENASMILTEXTO = "NOVECIENTOS "
            Case Else
                CENTENASMILTEXTO = " "
        End Select
        Select Case DECENASMIL
            Case "1"
                DECENASMILTEXTO = "DIEZ "
            Case "2"
                DECENASMILTEXTO = "VEINTE "
            Case "3"
                DECENASMILTEXTO = "TREINTA "
            Case "4"
                DECENASMILTEXTO = "CUARENTA "
            Case "5"
                DECENASMILTEXTO = "CINCUENTA "
            Case "6"
                DECENASMILTEXTO = "SESENTA "
            Case "7"
                DECENASMILTEXTO = "SETENTA "
            Case "8"
                DECENASMILTEXTO = "OCHENTA "
            Case "9"
                DECENASMILTEXTO = "NOVENTA "
            Case Else
                DECENASMILTEXTO = " "
        End Select
        Select Case UNIDADESMIL
            Case "1"
                If DECENASMIL = "1" Then
                    DECENASMILTEXTO = "ONCE MIL "
                    UNIDADESMILTEXTO = ""
                Else
                    UNIDADESMILTEXTO = "UN MIL "
                End If
            Case "2"
                If DECENASMIL = "1" Then
                    DECENASMILTEXTO = "DOCE MIL "
                    UNIDADESMILTEXTO = ""
                Else
                    UNIDADESMILTEXTO = "DOS MIL "
                End If
            Case "3"
                If DECENASMIL = "1" Then
                    DECENASMILTEXTO = "TRECE MIL "
                    UNIDADESMILTEXTO = ""
                Else
                    UNIDADESMILTEXTO = "TRES MIL "
                End If
            Case "4"
                If DECENASMIL = "1" Then
                    DECENASMILTEXTO = "CATORCE MIL "
                    UNIDADESMILTEXTO = ""
                Else
                    UNIDADESMILTEXTO = "CUATRO MIL "
                End If
            Case "5"
                If DECENASMIL = "1" Then
                    DECENASMILTEXTO = "QUINCE MIL "
                    UNIDADESMILTEXTO = ""
                Else
                    UNIDADESMILTEXTO = "CINCO MIL "
                End If
            Case "6"
                UNIDADESMILTEXTO = " SEIS MIL "
            Case "7"
                UNIDADESMILTEXTO = " SIETE MIL "
            Case "8"
                UNIDADESMILTEXTO = " OCHO MIL "
            Case "9"
                UNIDADESMILTEXTO = " NUEVE MIL "
            Case Else
                UNIDADESMILTEXTO = " "
                If enteros.Length > 4 Then UNIDADESMILTEXTO = "MIL "
        End Select

        If Len(DECENASTEXTO) > 1 And Len(UNIDADESTEXTO) > 1 Then DECENAS_Y = " Y " Else DECENAS_Y = ""
        If Len(DECENASMILTEXTO) > 1 And Len(UNIDADESMILTEXTO) > 1 Then DECENASMIL_Y = " Y " Else DECENASMIL_Y = ""
        Dim decimales_texto As String
        If decimales = "00" Then decimales_texto = "QUETZALES EXACTOS" Else decimales_texto = " CON " + decimales + "/100 QUETZALES"
        Return CENTENASMILTEXTO + DECENASMILTEXTO + DECENASMIL_Y + UNIDADESMILTEXTO + CENTENASTEXTO + DECENASTEXTO + DECENAS_Y + UNIDADESTEXTO + decimales_texto
    End Function
End Class