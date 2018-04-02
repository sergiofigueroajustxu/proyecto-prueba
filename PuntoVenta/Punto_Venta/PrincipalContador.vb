Imports Capa_Negocio
Imports Capa_Entidad
Imports System.IO
Imports System.Text

Public Class PrincipalContador
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
        Mantenimiento_Ruta.Show()
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
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        Dim path As String
        If path1.SelectedPath.ToString.Length > 0 Then
            path = path1.SelectedPath.ToString + "\exporta_venta.xml"
            Dim archivolee As New DataSet
            If File.Exists(path) Then
                archivolee.ReadXml(path)
                Dim archivoTexto2 As String
                archivoTexto2 = My.Computer.FileSystem.ReadAllText(path)
                If archivoTexto2.Length > 1 Then

                    Dim table As DataTable
                    Dim row As DataRow
                    'Dim column As DataColumn
                    'Agregar Venta
                    Dim Entidad As New Entidad_Venta
                    Dim Negocio As New Negocio_Venta
                    Dim conteo As Integer
                    Dim Entidad_detalle As New Entidad_ventadetalle
                    Dim Negocio_Detalle As New Negocio_Venta_Detalle
                    Dim Entidad_productos As New Entidad_Producto
                    Dim Negocio_productos As New Negocio_Producto

                    For Each table In archivolee.Tables
                        MsgBox("Table Name: " & table.TableName)
                        'Dim columns As DataColumnCollection = table.Columns
                        Dim nuevo As String
                        nuevo = ""
                        Dim idventamax As Integer
                        idventamax = 0
                        For Each row In table.Rows
                            Dim itemfactura As Integer
                            Dim idfactura As String
                            itemfactura = table.Columns.IndexOf("Factura")
                            idfactura = row(itemfactura).ToString
                            conteo = Negocio.verifica(idfactura)
                            If conteo > 0 Then
                                If nuevo <> idfactura Then
                                    idventamax = 0
                                    'MsgBox("Documento duplicado")
                                End If
                            Else
                                nuevo = idfactura
                                With Entidad
                                    .idcliente = row(table.Columns.IndexOf("idcliente"))
                                    .idempleado = row(table.Columns.IndexOf("Idempleado"))
                                    .idtipoventa = row(table.Columns.IndexOf("idtipoventa"))
                                    .fecha = row(table.Columns.IndexOf("Fecha"))
                                    .idfactura = row(table.Columns.IndexOf("Factura"))
                                    .sucursal = row(table.Columns.IndexOf("Sucursal"))
                                    .iva_bien = CDbl(row(table.Columns.IndexOf("IVA_Bien")))
                                    .tot_servicio = CDbl(row(table.Columns.IndexOf("Servicio")))
                                    .tot_bien = CDbl(row(table.Columns.IndexOf("Bien")))
                                    .iva_servicio = CDbl(row(table.Columns.IndexOf("IVA_Servicio")))
                                    .tot_documento = CDbl(row(table.Columns.IndexOf("Total")))
                                    .fecha_vence = row(table.Columns.IndexOf("Fecha_Vence"))
                                End With
                                idventamax = Negocio.Nueva_Venta(Entidad)
                            End If
                            If idventamax > 0 Then
                                ' rutina para grabar detalle
                                With Entidad_detalle
                                    .idventa = idventamax
                                    .idproducto = row(table.Columns.IndexOf("idproducto"))
                                    .precio = row(table.Columns.IndexOf("precio"))
                                    .cantidad = row(table.Columns.IndexOf("cantidad"))
                                    .cancelado = row(table.Columns.IndexOf("cancelado"))
                                    .codigo_barra = row(table.Columns.IndexOf("codigo_barra"))
                                End With
                                Negocio_Detalle.Nueva_VentaDetalle(Entidad_detalle)
                                'Para Actualizar el Stock'
                                Dim listaProductos As New List(Of Entidad_Producto)
                                'Buscamos el precio y el stock'
                                listaProductos = Negocio_productos.preciostock(row(table.Columns.IndexOf("idproducto")))
                                With Entidad_productos
                                    .stock = CType(listaProductos.Item(0).stock, Integer) - CType(row(table.Columns.IndexOf("cantidad")), Integer)
                                    .idproducto = row(table.Columns.IndexOf("idproducto"))
                                End With
                                Negocio_productos.Actualiza_Stock(Entidad_productos, row(table.Columns.IndexOf("idtipoventa")))
                            End If
                        Next row
                    Next table
                    MsgBox("Proceso finalizado")
                Else
                    MsgBox("No existen datos")
                End If
            Else
                MsgBox("No existen datos")
            End If

        End If
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

    Private Sub Label41_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label59_Click(sender As Object, e As EventArgs) 
        Mantenimiento_Sucursal.Show()
    End Sub

    Private Sub Label61_Click(sender As Object, e As EventArgs) 
        Mantenimiento_Ruta.Show()
    End Sub

    Private Sub Label68_Click(sender As Object, e As EventArgs) 

    End Sub
End Class