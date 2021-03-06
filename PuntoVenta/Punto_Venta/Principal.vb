﻿Imports Capa_Negocio
Imports Capa_Entidad
Imports System.IO
Imports System.Text

Public Class Principal
    Dim negocio As New Negocio_Producto
    Dim entidad As New List(Of Entidad_Producto)
    Dim contar As Integer = 0
    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarimagenespicturebox()
        'iniciamos label'

        entidad = negocio.productos_pa_comprar
    End Sub
    'Cargar imagenes para los picturebox'
    Private Sub cargarimagenespicturebox()
        If File.Exists("c:\temp\imagenes\logo.png") Then
            PictureBox11.Load("c:\temp\imagenes\logo.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\cobros.png") Then
            PictureBox1.Load("c:\temp\imagenes\diseño\cobros.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\ventas.png") Then
            PictureBox8.Load("c:\temp\imagenes\diseño\ventas.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\compras.png") Then
            PictureBox5.Load("c:\temp\imagenes\diseño\compras.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\libroventas.png") Then
            PictureBox2.Load("c:\temp\imagenes\diseño\libroventas.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\librocompras.png") Then
            PictureBox4.Load("c:\temp\imagenes\diseño\librocompras.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\pagos.png") Then
            PictureBox6.Load("c:\temp\imagenes\diseño\pagos.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\mantenimiento.png") Then
            PictureBox7.Load("c:\temp\imagenes\diseño\mantenimiento.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\ctacorriente.png") Then
            PictureBox3.Load("c:\temp\imagenes\diseño\ctacorriente.png")
        End If

        If File.Exists("c:\temp\imagenes\diseño\financiero.png") Then
            PictureBox13.Load("c:\temp\imagenes\diseño\financiero.png")
        End If

        If File.Exists("c:\temp\imagenes\diseño\fin.png") Then
            PictureBox10.Load("c:\temp\imagenes\diseño\fin.png")
        End If

        If File.Exists("c:\temp\imagenes\diseño\retiros.png") Then
            PictureBox12.Load("c:\temp\imagenes\diseño\retiros.png")
        End If

        If File.Exists("c:\temp\imagenes\diseño\sincroniza.png") Then
            PictureBox14.Load("c:\temp\imagenes\diseño\sincroniza.png")
        End If
        If File.Exists("c:\temp\imagenes\diseño\depositos.png") Then
            PictureBox9.Load("c:\temp\imagenes\diseño\depositos.png")
        End If
    End Sub

    'Cuando entra en el control'
    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox2, Label1)
    End Sub

    'Cuando sale del control'
    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        cambiarcolor(88, 89, 185, PictureBox2, Label1)
    End Sub

    'Cuando entra en el control'

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        cambiarcolor(88, 89, 185, PictureBox1, Label9)
    End Sub

    'Cuando deja el control'
    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        'cambiarcolor(140, 191, 38, PictureBox1, Label9)
        PictureBox1.BackColor = Color.DarkGoldenrod
        Label9.BackColor = Color.DarkGoldenrod
    End Sub

    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        cambiarcolor(88, 89, 185, PictureBox4, Label5)
    End Sub

    'Cuando deja el control'
    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        cambiarcolor(27, 161, 226, PictureBox4, Label5)
    End Sub

    Private Sub PictureBox12_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseEnter
        cambiarcolor(88, 89, 185, PictureBox12, Label31)
    End Sub
    Private Sub PictureBox12_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseLeave
        cambiarcolor(190, 50, 150, PictureBox12, Label31)
    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        CobrosFacturas.Show()
    End Sub



    'Funcion para cambiar de color'
    Private Sub cambiarcolor(ByVal red As Integer, ByVal green As Integer, ByVal blue As Integer, ByVal pict As PictureBox, ByVal etiqueta As Label)
        pict.BackColor = Color.FromArgb(CType(CType(red, Byte), Integer), CType(CType(green, Byte), Integer), CType(CType(blue, Byte), Integer))
        etiqueta.BackColor = Color.FromArgb(CType(CType(red, Byte), Integer), CType(CType(green, Byte), Integer), CType(CType(blue, Byte), Integer))
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Compra.Show()
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox5, Label2)
    End Sub


    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        cambiarcolor(3, 72, 131, PictureBox5, Label2)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        PagosFacturas.Show()
    End Sub

    Private Sub PictureBox8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox8, Label8)
    End Sub

    Private Sub PictureBox8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseLeave
        cambiarcolor(50, 140, 0, PictureBox8, Label8)
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        Venta.Show()
    End Sub

    Private Sub PictureBox7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseEnter
        '    cambiarcolor(27, 161, 226, PictureBox7, Label7)
        '    Label14.BackColor = Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        '    Label16.BackColor = Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        '    Label15.BackColor = Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
    End Sub

    Private Sub PictureBox7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseLeave
        'cambiarcolor(110, 21, 95, PictureBox7, Label7)
        'Label14.BackColor = Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(95, Byte), Integer))
        'Label15.BackColor = Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(95, Byte), Integer))
        'Label16.BackColor = Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(95, Byte), Integer))
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        Mantenimiento_Productos.Show()
    End Sub

    Private Sub Label14_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseEnter
        Label14.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label14_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseLeave
        Label14.ForeColor = Color.White
    End Sub

    Private Sub Label15_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseEnter
        Label15.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label15_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseLeave
        Label15.ForeColor = Color.White
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        Mantenimiento_Categoria.Show()
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        Mantenimiento_Proveedores.Show()
    End Sub

    Private Sub Label16_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseEnter
        Label16.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseLeave
        Label16.ForeColor = Color.White
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cobros.Show()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Pagos.Show()
    End Sub



    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        Venta.Show()
    End Sub

    Private Sub Label8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox8, Label8)
    End Sub


    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        cambiarcolor(0, 171, 169, PictureBox8, Label8)
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Compra.Show()
    End Sub

    Private Sub Label2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox5, Label2)
    End Sub


    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        cambiarcolor(3, 72, 131, PictureBox5, Label2)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        If contar <> entidad.Count Then
            If File.Exists("c:\temp\imagenes\productos\" + entidad(contar).foto) Then
                PictureBox9.Load("c:\temp\imagenes\productos\" + entidad(contar).foto)
            End If
            Label10.Text = entidad(contar).nombre & vbCrLf & "STOCK = " & entidad(contar).stock
        Else
            contar = 0
            Exit Sub
        End If

        contar += 1
    End Sub

    Private Sub PictureBox6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox6, Label6)
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.BackColor = Color.Brown
        Label6.BackColor = Color.Brown
    End Sub


    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Pagos.Show()
    End Sub

    Private Sub Label6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox6, Label6)
    End Sub

    Private Sub Label6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseLeave
        PictureBox6.BackColor = Color.Brown
        Label6.BackColor = Color.Brown
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        CobrosFacturas.Show()
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox2, Label1)
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        cambiarcolor(88, 89, 185, PictureBox2, Label1)
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        Me.Close()
    End Sub

    Private Sub PictureBox10_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox10, Label11)
    End Sub

    Private Sub PictureBox100_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseLeave
        PictureBox10.BackColor = Color.BlueViolet
        Label11.BackColor = Color.BlueViolet
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Me.Close()
    End Sub

    Private Sub Label11_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseEnter
        cambiarcolor(27, 161, 226, PictureBox10, Label11)
    End Sub

    Private Sub Label11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseLeave
        PictureBox10.BackColor = Color.BlueViolet
        Label11.BackColor = Color.BlueViolet
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Cobros.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Mantenimiento_Sucursal.Show()
    End Sub

    Private Sub Label20_MouseEnter(sender As Object, e As EventArgs) Handles Label20.MouseEnter
        Label20.ForeColor = Color.DarkOrange
    End Sub



    Private Sub Label20_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label20.MouseLeave
        Label20.ForeColor = Color.White
    End Sub

    Private Sub Label30_MouseEnter(sender As Object, e As EventArgs) Handles Label30.MouseEnter
        Label30.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label30_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label30.MouseLeave
        Label30.ForeColor = Color.White
    End Sub


    Private Sub Label33_MouseEnter(sender As Object, e As EventArgs) Handles Label33.MouseEnter
        Label33.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label33_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label33.MouseLeave
        Label33.ForeColor = Color.White
    End Sub

    Private Sub PictureBox9_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox9.MouseEnter
        'PictureBox9.BackColor = Color.BlueViolet
        'Label26.BackColor = Color.BlueViolet
        'PictureBox15.Visible = True
        'PictureBox16.Visible = True
    End Sub
    Private Sub PictureBox9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseLeave
        'PictureBox9.BackColor = Color.DarkSalmon
        'Label26.BackColor = Color.DarkSalmon
        'PictureBox15.Visible = False
        'PictureBox16.Visible = False
    End Sub

    Private Sub Label12_MouseEnter(sender As Object, e As EventArgs) Handles Label12.MouseEnter
        Label12.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label12_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label12.MouseLeave
        Label12.ForeColor = Color.White
    End Sub
    Private Sub Label13_MouseEnter(sender As Object, e As EventArgs) Handles Label13.MouseEnter
        Label13.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label13_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.MouseLeave
        Label13.ForeColor = Color.White
    End Sub


    Private Sub Label17_MouseEnter(sender As Object, e As EventArgs) Handles Label17.MouseEnter
        Label17.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label17_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label17.MouseLeave
        Label17.ForeColor = Color.White
    End Sub
    Private Sub Label18_MouseEnter(sender As Object, e As EventArgs) Handles Label18.MouseEnter
        Label18.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label18_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label18.MouseLeave
        Label18.ForeColor = Color.White
    End Sub

    Private Sub Label26_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label26.MouseLeave
        Label26.ForeColor = Color.White
    End Sub
    Private Sub Label26_MouseEnter(sender As Object, e As EventArgs) Handles Label26.MouseEnter
        Label26.ForeColor = Color.DarkOrange
    End Sub



    Private Sub Label27_MouseEnter(sender As Object, e As EventArgs) Handles Label27.MouseEnter
        Label27.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label27_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label27.MouseLeave
        Label27.ForeColor = Color.White
    End Sub

    Private Sub Label4_MouseEnter(sender As Object, e As EventArgs) Handles Label4.MouseEnter
        Label4.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.White
    End Sub


    Private Sub Label21_MouseEnter(sender As Object, e As EventArgs) Handles Label21.MouseEnter
        Label21.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label21_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label21.MouseLeave
        Label21.ForeColor = Color.White
    End Sub

    Private Sub Label22_MouseEnter(sender As Object, e As EventArgs) Handles Label22.MouseEnter
        Label22.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label22_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label22.MouseLeave
        Label22.ForeColor = Color.White
    End Sub


    Private Sub Label23_MouseEnter(sender As Object, e As EventArgs) Handles Label23.MouseEnter
        Label23.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label23_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label23.MouseLeave
        Label23.ForeColor = Color.White
    End Sub


    Private Sub Label24_MouseEnter(sender As Object, e As EventArgs) Handles Label24.MouseEnter
        Label24.ForeColor = Color.DarkOrange
    End Sub

    Private Sub Label24_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label24.MouseLeave
        Label24.ForeColor = Color.White
    End Sub


    Private Sub Label25_MouseEnter(sender As Object, e As EventArgs) Handles Label25.MouseEnter
        Label25.ForeColor = Color.DarkOrange
    End Sub
    Private Sub Label25_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label25.MouseLeave
        Label25.ForeColor = Color.White
    End Sub
    Private Sub Label35_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label35.MouseLeave
        Label35.ForeColor = Color.White
    End Sub
    Private Sub Label35_MouseEnter(sender As Object, e As EventArgs) Handles Label35.MouseEnter
        Label35.ForeColor = Color.DarkOrange
    End Sub
    Private Sub Label36_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label36.MouseLeave
        Label36.ForeColor = Color.White
    End Sub
    Private Sub Label36_MouseEnter(sender As Object, e As EventArgs) Handles Label36.MouseEnter
        Label36.ForeColor = Color.DarkOrange
    End Sub



    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        gasto.show()
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click
        Libro_Mayor.Show()
    End Sub

    Private Sub Label33_Click(sender As Object, e As EventArgs) Handles Label33.Click

    End Sub

    Private Sub Label9_Click_1(sender As Object, e As EventArgs) Handles Label9.Click
        Cobros.Show()
    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click
        Mantenimiento_Bancos.Show()
    End Sub



    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        kardex.Show()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Inventario.Show()
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        EstadoCuenta.Show()
    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click
        MovimientoBanco.Show()
    End Sub
    Private Sub Label34_MouseEnter(sender As Object, e As EventArgs) Handles Label34.MouseEnter
        Label34.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label34_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label34.MouseLeave
        Label34.ForeColor = Color.White
    End Sub

    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Mantenimiento_Nomenclatura.Show()
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        Partida.Show()
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        Libro_Diario.Show()
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click
        Libro_Balance_Saldos.Show()
    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click
        Nomenclatura_Saldos.Show()
        'ReporteInventario.Show()
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click


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
        path1 = "c:\temp\impresiones\factura FACTURA.txt"
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
                        lineadato = lineatexto



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
        'textoFormato = Format(numero, "#,##0.00")
        textoFormato = StrDup(15 - numero.Length, " ") & numero
        Return textoFormato
    End Function

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click

        MovimientoBancoIngreso.Show()
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        MovimientoBancoEgreso.Show()
    End Sub

    Private Sub Label35_Click(sender As Object, e As EventArgs) Handles Label35.Click
        hoja_ruta.show()
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.Click
        Libro_Ventas.Show()
    End Sub



    Private Sub Label36_Click(sender As Object, e As EventArgs) Handles Label36.Click
        Libro_Compras.Show()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        PagosFacturas.Show()
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click

    End Sub

    Private Sub Label41_Click(sender As Object, e As EventArgs) Handles Label41.Click

    End Sub
    Private Sub Label41_MouseEnter(sender As Object, e As EventArgs) Handles Label41.MouseEnter
        Label41.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label41_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label41.MouseLeave
        Label41.ForeColor = Color.White
    End Sub
    Private Sub Label40_MouseEnter(sender As Object, e As EventArgs) Handles Label40.MouseEnter
        Label40.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label40_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label40.MouseLeave
        Label40.ForeColor = Color.White
    End Sub
    Private Sub Label42_MouseEnter(sender As Object, e As EventArgs) Handles Label42.MouseEnter
        Label42.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label42_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label42.MouseLeave
        Label42.ForeColor = Color.White
    End Sub
    Private Sub Label43_MouseEnter(sender As Object, e As EventArgs) Handles Label43.MouseEnter
        Label43.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label43_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label43.MouseLeave
        Label43.ForeColor = Color.White
    End Sub
    Private Sub Label44_MouseEnter(sender As Object, e As EventArgs) Handles Label44.MouseEnter
        Label44.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label44_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label44.MouseLeave
        Label44.ForeColor = Color.White
    End Sub
    Private Sub Label45_MouseEnter(sender As Object, e As EventArgs) Handles Label45.MouseEnter
        Label45.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label45_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label45.MouseLeave
        Label45.ForeColor = Color.White
    End Sub
    Private Sub Label46_MouseEnter(sender As Object, e As EventArgs) Handles Label46.MouseEnter
        Label46.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label46_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label46.MouseLeave
        Label46.ForeColor = Color.White
    End Sub
    Private Sub Label47_MouseEnter(sender As Object, e As EventArgs) Handles Label47.MouseEnter
        Label47.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label47_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label47.MouseLeave
        Label47.ForeColor = Color.White
    End Sub
    Private Sub Label48_MouseEnter(sender As Object, e As EventArgs) Handles Label48.MouseEnter
        Label48.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label48_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label48.MouseLeave
        Label48.ForeColor = Color.White
    End Sub

    Private Sub Label49_MouseEnter(sender As Object, e As EventArgs) Handles Label49.MouseEnter
        Label49.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label49_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label49.MouseLeave
        Label49.ForeColor = Color.White
    End Sub

    Private Sub Label50_MouseEnter(sender As Object, e As EventArgs) Handles Label50.MouseEnter
        Label50.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label50_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label50.MouseLeave
        Label50.ForeColor = Color.White
    End Sub
    Private Sub Label51_MouseEnter(sender As Object, e As EventArgs) Handles Label51.MouseEnter
        Label51.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label51_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label51.MouseLeave
        Label51.ForeColor = Color.White
    End Sub
    Private Sub Label52_MouseEnter(sender As Object, e As EventArgs) Handles Label52.MouseEnter
        Label52.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label52_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label52.MouseLeave
        Label52.ForeColor = Color.White
    End Sub
    Private Sub Label53_MouseEnter(sender As Object, e As EventArgs) Handles Label53.MouseEnter
        Label53.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label53_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label53.MouseLeave
        Label53.ForeColor = Color.White
    End Sub

    Private Sub Label54_MouseEnter(sender As Object, e As EventArgs) Handles Label54.MouseEnter
        Label54.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label54_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label54.MouseLeave
        Label54.ForeColor = Color.White
    End Sub
    Private Sub Label55_MouseEnter(sender As Object, e As EventArgs) Handles Label55.MouseEnter
        Label55.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label55_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label55.MouseLeave
        Label55.ForeColor = Color.White
    End Sub

    Private Sub Label56_MouseEnter(sender As Object, e As EventArgs) Handles Label56.MouseEnter
        Label56.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label56_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label56.MouseLeave
        Label56.ForeColor = Color.White
    End Sub

    Private Sub Label57_MouseEnter(sender As Object, e As EventArgs) Handles Label57.MouseEnter
        Label57.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label57_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label57.MouseLeave
        Label57.ForeColor = Color.White
    End Sub

    Private Sub Label58_MouseEnter(sender As Object, e As EventArgs) Handles Label58.MouseEnter
        Label58.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label58_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label58.MouseLeave
        Label58.ForeColor = Color.White
    End Sub

    Private Sub Label59_MouseEnter(sender As Object, e As EventArgs) Handles Label59.MouseEnter
        Label59.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label59_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label59.MouseLeave
        Label59.ForeColor = Color.White
    End Sub

    Private Sub Label60_MouseEnter(sender As Object, e As EventArgs) Handles Label60.MouseEnter
        Label60.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label60_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label60.MouseLeave
        Label60.ForeColor = Color.White
    End Sub

    Private Sub Label61_MouseEnter(sender As Object, e As EventArgs) Handles Label61.MouseEnter
        Label61.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label61_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label61.MouseLeave
        Label61.ForeColor = Color.White
    End Sub

    Private Sub Label62_MouseEnter(sender As Object, e As EventArgs) Handles Label62.MouseEnter
        Label62.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label62_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label62.MouseLeave
        Label62.ForeColor = Color.White
    End Sub

    Private Sub Label63_MouseEnter(sender As Object, e As EventArgs) Handles Label63.MouseEnter
        Label63.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label63_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label63.MouseLeave
        Label63.ForeColor = Color.White
    End Sub

    Private Sub Label64_MouseEnter(sender As Object, e As EventArgs) Handles Label64.MouseEnter
        Label64.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label64_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label64.MouseLeave
        Label64.ForeColor = Color.White
    End Sub

    Private Sub Label65_MouseEnter(sender As Object, e As EventArgs) Handles Label65.MouseEnter
        Label65.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label65_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label65.MouseLeave
        Label65.ForeColor = Color.White
    End Sub

    Private Sub Label66_MouseEnter(sender As Object, e As EventArgs) Handles Label66.MouseEnter
        Label66.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label66_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label66.MouseLeave
        Label66.ForeColor = Color.White
    End Sub

    Private Sub Label67_MouseEnter(sender As Object, e As EventArgs) Handles Label67.MouseEnter
        Label67.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label67_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label67.MouseLeave
        Label67.ForeColor = Color.White
    End Sub
    Private Sub Label68_MouseEnter(sender As Object, e As EventArgs) Handles Label68.MouseEnter
        Label68.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label68_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label68.MouseLeave
        Label68.ForeColor = Color.White
    End Sub
    Private Sub Label69_MouseEnter(sender As Object, e As EventArgs) Handles Label69.MouseEnter
        Label69.ForeColor = Color.DarkRed
    End Sub

    Private Sub Label69_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label69.MouseLeave
        Label69.ForeColor = Color.White
    End Sub

    Private Sub Label59_Click(sender As Object, e As EventArgs) Handles Label59.Click
        Mantenimiento_Provincia.Show()
    End Sub

    Private Sub Label61_Click(sender As Object, e As EventArgs) Handles Label61.Click
        Mantenimiento_Ruta.Show()
    End Sub

    Private Sub Label68_Click(sender As Object, e As EventArgs) Handles Label68.Click

    End Sub

    Private Sub Label69_Click(sender As Object, e As EventArgs) Handles Label69.Click
        Mantenimiento_Municipio.Show()
    End Sub

    Private Sub Label58_Click(sender As Object, e As EventArgs) Handles Label58.Click
        Mantenimiento_Transporte.Show()
    End Sub

    Private Sub Label60_Click(sender As Object, e As EventArgs) Handles Label60.Click
        Control_Transporte.Show()
    End Sub

    Private Sub Label45_Click(sender As Object, e As EventArgs) Handles Label45.Click

    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click

    End Sub

    Private Sub Label44_Click(sender As Object, e As EventArgs) Handles Label44.Click

    End Sub

    Private Sub Label42_Click(sender As Object, e As EventArgs) Handles Label42.Click

    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs) Handles Label40.Click

    End Sub
End Class