Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO

Public Class Compra
    Private txt() As PictureBox
    Private lbl() As Label
    Dim panel As New PanelExtended
    Dim pag As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Pagos.Show()
        Pagos.ComboBox1.Text = ComboBox1.Text

    End Sub

    Private Sub Compra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.Coral
        panel.AutoScroll = True
        panel.Location = New System.Drawing.Point(600, 85)
        panel.Name = "Panel1"
        panel.Size = New System.Drawing.Size(540, 580)
        'Se agrega al formulario'
        Me.Controls.Add(panel)

        'Dim num As Integer
        'num = contarproducto()
        mostrarproducto()

        With ListView1
            .View = View.Details
            .Columns.Add("ID", 50)
            .Columns.Add("Producto", 230)
            .Columns.Add("Cantidad", 70, HorizontalAlignment.Right)
            .Columns.Add("Valor", 100, HorizontalAlignment.Right)
            .Columns.Add("Lote", 100)
            .Columns.Add("Vence", 100)
            .Columns.Add("Cod B", 100)

        End With


        If File.Exists("c:\temp\imagenes\logo.png") Then 'Comprobamos que el archivo existe'
            PictureBox1.Load("c:\temp\imagenes\logo.png")
        End If


        cargarcombosucursal()
        cargarcombo(ComboBox1)
        cargarcombocategoria()
        cargarcombotipocompra()
    End Sub
    Private Sub cargarcombosucursal()
        Dim lista As New List(Of Entidad_Sucursal)
        Dim obj As New Negocio_Sucursal
        lista = obj.Mostrarsucursal("")
        ComboBox3.DataSource = lista
        ComboBox3.DisplayMember = "nombre"
        ComboBox3.ValueMember = "idsucursal"
        ComboBox3.SelectedIndex = -1
    End Sub
    Private Sub cargarcombotipocompra()
        Dim lista As New List(Of Entidad_Tipo_compra)
        Dim obj As New Negocio_TipoCompra
        lista = obj.Mostrartipocompra("")
        ComboBox5.DataSource = lista
        ComboBox5.DisplayMember = "descripcion"
        ComboBox5.ValueMember = "idtipocompra"
        ComboBox5.SelectedIndex = -1
    End Sub


    Private Sub cargarcombo(ByVal combo As ComboBox)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.Mostrarproveedor
        combo.DataSource = lista
        combo.DisplayMember = "nombre"
        combo.ValueMember = "idcliente"

        combo.SelectedIndex = -1
    End Sub

    Private Sub cargarcombocategoria()
        Dim lista As New List(Of Entidad_Categoria)
        Dim obj As New Negocio_Categoria
        lista = obj.Mostrarcategoria("")
        ComboBox2.DataSource = lista
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "idcategoria"
        ComboBox2.SelectedIndex = -1
    End Sub
    'para buscar un producto'
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim cuenta As Integer
        Dim obj As New Negocio_Producto
        Dim listaProductos As New List(Of Entidad_Producto)
        If CheckBox1.Checked And ComboBox2.SelectedIndex >= 0 Then
            If IsNumeric(ComboBox2.SelectedValue) And IsNumeric(ComboBox1.SelectedValue) Then
                listaProductos = obj.buscarnomcatproveedor(Me.TextBox2.Text, ComboBox2.SelectedValue, ComboBox1.SelectedValue)
                'cuenta = obj.contarproductospornomycat(Me.TextBox2.Text, ComboBox2.SelectedValue)
                cuenta = listaProductos.Count
                'NumericUpDown2.Maximum = Math.Round(cuenta / 12, 0) - 1
                dibuja(cuenta, listaProductos)
            ElseIf IsNumeric(ComboBox2.SelectedValue) Then
                listaProductos = obj.buscarnomcat(Me.TextBox2.Text, ComboBox2.SelectedValue)
                cuenta = listaProductos.Count
                dibuja(cuenta, listaProductos)

            End If


        Else
            listaProductos = obj.buscarnomcatproveedor(Me.TextBox2.Text, -1, ComboBox1.SelectedValue)
            'listaProductos = obj.buscartodoproducto(Me.TextBox2.Text)
            'cuenta = contarproductoporfiltro(TextBox2.Text)
            cuenta = listaProductos.Count
            'NumericUpDown2.Maximum = Math.Round(cuenta / 12, 0) - 1
            dibuja(cuenta, listaProductos)
        End If


    End Sub

    Private Sub btnvender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvender.Click

        If Label5.Text = "" Then
            MessageBox.Show("Debe seleccionar un proveedor")
            ComboBox1.Focus()
            Exit Sub
        End If
        If ComboBox3.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar un sucursal")
            ComboBox1.Focus()
            Exit Sub
        End If

        If TextBox5.Text = "" Then
            MessageBox.Show("Debe ingresar correlativo de documento")
            ComboBox1.Focus()
            Exit Sub
        End If

        If ListView1.Items.Count <= 0 Then
            MessageBox.Show("Debe seleccionar por lo menos un producto")
            Exit Sub
        End If

        'para recuperar el id del empleado
        Dim lista2 As New List(Of Entidad_Empleado)
        Dim obj2 As New Negocio_Empleado
        lista2 = obj2.obtener_idempleado(Mid(Principal.Text, 11, Principal.Text.Length))

        'para saber el tipodecompra'
        Dim tipocompra As Integer
        tipocompra = ComboBox5.SelectedValue

        Dim cancelado As Integer
        Dim montopagado As Double


        cancelado = 1
        If tipocompra = 3 Then 'credito
            cancelado = 0
            montopagado = 0
        End If


        'Agregar Compra
        Dim Entidad As New Entidad_Compras
        Dim Negocio As New Negocio_Compras


        With Entidad
            .fecha = Me.convertirfecha_ansi(Me.DateTimePicker1, Me.DateTimePicker2)
            .idtipocomprobante = tipocompra
            .idfactura = TextBox5.Text
            .idproveedor = TextBox4.Text
            .importetotal = CDbl(Label4.Text)
            .sucursal = ComboBox3.SelectedValue
            .contenedor = TextBox6.Text
            .retencion = 0
            .fecha_vence = Me.convertirfecha_ansi(Me.DateTimePicker3, Me.DateTimePicker3)


        End With
        'Agregamos una nueva compra'
        Dim idcompramax As Integer
        idcompramax = Negocio.Nueva_Compra(Entidad)

        If idcompramax > 0 Then
            'Para Agregar Compra_Detalle'
            Dim Entidad_detalle As New Entidad_Compra_Detalles
            Dim Negocio_detalle As New Negocio_Compra_Detalle

            For i = 0 To ListView1.Items.Count - 1
                'Para Obtener el id del producto
                'Dim lista3 As New List(Of Entidad_Producto)
                'Dim obj3 As New Negocio_Producto
                'lista3 = obj3.obtener_idproducto(ListView1.Items(i).SubItems(0).Text)

                Dim importe As Double = CDbl(ListView1.Items(i).SubItems(3).Text)
                Dim cantidad As Integer = CInt(ListView1.Items(i).SubItems(2).Text)
                importe = importe - importe / (CDbl(Label4.Text) + CDbl(NumericUpDown1.Value)) * CDbl(NumericUpDown1.Value)

                With Entidad_detalle
                    .idcompra = idcompramax
                    .idproducto = ListView1.Items(i).SubItems(0).Text
                    .importe = importe
                    .cantidad = cantidad
                    .cancelado = cancelado
                    '.montopagado = IIf(cancelado = 1, CDbl(ListView1.Items(i).SubItems(3).Text), 0)
                    .montopagado = IIf(cancelado = 1, importe, 0)
                    .lote = ListView1.Items(i).SubItems(4).Text
                    .vence = convertirfecha_ansi_text(ListView1.Items(i).SubItems(5).Text)
                    .codigo_barra = ListView1.Items(i).SubItems(6).Text
                End With
                'Agregamos la compra Detalle'
                Negocio_detalle.Nueva_Compra_Detalle(Entidad_detalle)



                'Para Actualizar el Stock'
                Dim Entidad_productos As New Entidad_Producto
                Dim Negocio_productos As New Negocio_Producto

                Dim listaProductos As New List(Of Entidad_Producto)
                'Buscamos el precio y el stock'
                listaProductos = Negocio_productos.preciostock(ListView1.Items(i).SubItems(3).Text)
                Dim iva As Double
                With Entidad_productos
                    .stock = ListView1.Items(i).SubItems(2).Text
                    .idproducto = ListView1.Items(i).SubItems(0).Text
                    iva = .iva_unidad
                End With
                Dim preciocompra As Double

                preciocompra = CDbl(ListView1.Items(i).SubItems(3).Text) / (1 + iva)

                Negocio_productos.Actualiza_Stockcompras(Entidad_productos, preciocompra, tipocompra)
            Next
        End If
        'MessageBox.Show("Compra Exitosa")
        limpiar()
    End Sub

    Private Function convertirfecha_ansi(ByVal picker As DateTimePicker, ByVal picker2 As DateTimePicker) As String
        Dim cadena As String = ""
        cadena = CStr(picker.Value.Year)
        If (picker.Value.Month) < 10 Then
            cadena = cadena + "0" + CStr(picker.Value.Month)
        Else
            cadena = cadena + CStr(picker.Value.Month)
        End If

        If picker.Value.Day < 10 Then
            cadena = cadena + "0" + CStr(picker.Value.Day)
        Else
            cadena = cadena + CStr(picker.Value.Day)
        End If

        If picker2.Value.Hour < 10 Then
            cadena = cadena + " 0" + CStr(picker2.Value.Hour) + ":"
        Else
            cadena = cadena + " " + CStr(picker2.Value.Hour) + ":"
        End If

        If picker2.Value.Minute < 10 Then
            cadena = cadena + "0" + CStr(picker2.Value.Minute) + ":"
        Else
            cadena = cadena + CStr(picker2.Value.Minute) + ":"
        End If

        If picker2.Value.Second < 10 Then
            cadena = cadena + "0" + CStr(picker2.Value.Second)
        Else
            cadena = cadena + CStr(picker2.Value.Second)
        End If
        Return cadena
    End Function

    Private Function convertirfecha_ansi_text(ByVal fecha As String) As String
        Dim cadena As String = ""
        cadena = Mid(fecha, 7, 4) & Mid(fecha, 4, 2) & Mid(fecha, 1, 2)
        Return cadena
    End Function



    'Procedimiento para que se muestren todos los productos en Picturebox'
    Private Sub mostrarproducto()
        Dim lista As New List(Of Entidad_Producto)
        Dim obj As New Negocio_Producto
        lista = obj.Mostrartodosproducto("")
        Dim fin As Integer
        fin = lista.Count
        'NumericUpDown2.Maximum = Math.Round(fin / 12, 0) - 1

        dibuja(fin, lista)
    End Sub

    'metodo para dibujar picturebox en tiempo de ejecucion'
    Private Sub dibuja(ByVal fin As Integer, ByVal lista As List(Of Entidad_Producto))
        If fin > 24 Then
            NumericUpDown2.Maximum = Math.Round(fin / 12, 0) - 1
        Else
            NumericUpDown2.Maximum = 1
        End If
        panel.Controls.Clear() 'Eliminamos todos los controles que esten en panel'
        Dim i As Integer
        Dim j As Integer = 0
        Dim p As Integer = 0
        Dim fin2 As Integer = 0
        Dim contador As Integer = 0
        ReDim txt(fin)
        ReDim lbl(fin)
        Dim constante As Integer = 160 'variable que determina el espaciado entre los picturebox'
        Dim constantex As Integer = 130
        'While fin2 < fin
        '       If (fin - fin2) > 12 Then p = 12 Else p = fin - fin2
        '        For i = 1 + fin2 To p + fin2
        Dim pagina = 0
        If fin > 12 * pag Then
            p = 12
            pagina = pag - 1
        Else
            p = fin
        End If
        'For i = 1 To fin
        For i = 1 + (pagina * 12) To p + (pagina * 12)

            txt(i) = New PictureBox 'instanciamos los picturebox'
            lbl(i) = New Label 'iniciamos el label'

            'Picturebox'
            Me.txt(i).Size = New System.Drawing.Size(130, 110)
            Me.txt(i).Name = lista.Item(i - 1).idproducto
            Me.txt(i).SizeMode = PictureBoxSizeMode.StretchImage

            If File.Exists("c:\temp\imagenes\productos\" + lista.Item(i - 1).foto) Then 'Comprobamos que el archivo existe'
                Me.txt(i).Load("c:\temp\imagenes\productos\" + lista.Item(i - 1).foto)
            End If

            contador = contador + 1
            If contador <= 4 Then
                txt(i).Location = New System.Drawing.Point((contador * constantex) - constantex, j * constante) 'para la ubicacion'

            Else
                j = j + 1
                txt(i).Location = New System.Drawing.Point(0, j * constante)
                contador = 1
            End If

            panel.Controls.Add(txt(i))

            lbl(i).Location = New System.Drawing.Point(txt(i).Location.X, txt(i).Location.Y + 110)
            Me.txt(i).Text = lista.Item(i - 1).nombre
            Me.lbl(i).Text = lista.Item(i - 1).nombre
            Me.lbl(i).ForeColor = Color.White
            Me.lbl(i).BackColor = Color.DarkSlateBlue
            Me.lbl(i).Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl(i).Size = New System.Drawing.Size(130, 50)
            Me.lbl(i).TextAlign = ContentAlignment.TopCenter
            panel.Controls.Add(lbl(i))

            AddHandler txt(i).Click, AddressOf All_filter_click
        Next

        fin2 = fin2 + p
        'End While
    End Sub

    'Asignar un manejador de evento al control creado'
    Private Sub All_filter_click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim picture As PictureBox
        picture = CType(sender, PictureBox)
        Dim obj As New Negocio_Producto
        Dim listaProductos As New List(Of Entidad_Producto)
        listaProductos = obj.preciostock(picture.Name) 'Se Busca el precio y el stock' 



        If File.Exists(picture.ImageLocation) Then
            Detalle_Compra.PictureBox1.Load(picture.ImageLocation) 'copiamos la imagen de un picturebox a otro'
        End If
        Detalle_Compra.PictureBox1.Name = picture.Name
        Detalle_Compra.Label6.Text = picture.Text
        Detalle_Compra.TextBox2.Text = listaProductos.Item(0).costo_promedio
        Detalle_Compra.Show() 'Abrimos el formulario detalle producto '



    End Sub

    'Funcion que cuenta la cantidad  de productos'
    Private Function contarproducto() As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductos
        Return valor
    End Function

    'Devuelve la cantidad de productos segun el nombre '
    Private Function contarproductoporfiltro(ByVal nombre As String) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductosporfiltro(nombre)
        Return valor
    End Function

    'Devuelve la cantidad de productos segun su categoria '
    Private Function contarproductoporcategoria(ByVal id As Integer, idproveedor As Integer) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        valor = obj.contarproductosporcategoria(id, idproveedor)
        Return valor
    End Function


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


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex >= 0 Then
            Label5.Text = ComboBox1.SelectedValue.ToString

            If IsNumeric(Label5.Text) Then
                TextBox1.Text = obtiene_nit_cliente(CInt(Label5.Text))
                TextBox3.Text = obtiene_direccion_cliente(CInt(Label5.Text))
                verifica(ComboBox1, ComboBox2)
                CheckBox1.Checked = True
            Else
                TextBox1.Text = ""
                TextBox3.Text = ""
                CheckBox1.Checked = False
            End If

            'combo.DataSource = lista
            'combo.DisplayMember = "nombre"
            'combo.ValueMember = "idcliente"

        Else
            Label5.Text = ""
            TextBox5.Text = ""
        End If
        TextBox4.Text = Label5.Text
        TextBox2.Text = ""
    End Sub

    Public Function obtiene_nit_cliente(ByVal itemList As Integer) As String
        Dim obj As New Negocio_Cliente
        Dim lista As New List(Of Entidad_Cliente)
        Dim var_retorno As String
        lista = obj.MostrarDatosCliente(itemList)
        var_retorno = lista.Item(0).nit.ToString
        Return var_retorno
    End Function

    Public Function obtiene_direccion_cliente(ByVal itemList As Integer) As String
        Dim obj As New Negocio_Cliente
        Dim lista As New List(Of Entidad_Cliente)
        Dim var_retorno As String
        lista = obj.MostrarDatosCliente(itemList)
        var_retorno = lista.Item(0).direccion.ToString
        Return var_retorno
    End Function
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.Validated
        If TextBox1.TextLength >= 0 Then
            ComboBox1.Text = obtiene_nombre_cliente(TextBox1.Text)
        Else
            ComboBox1.Text = ""
        End If
        If ComboBox1.Text.Length < 1 Then
            TextBox3.Text = "Ciudad"
            Button2.ForeColor = Color.Red
            ComboBox1.Focus()
        End If

    End Sub
    Private Function obtiene_nombre_cliente(ByVal nit As String) As String
        Dim obj As New Negocio_Cliente
        Dim lista As New List(Of Entidad_Cliente)
        Dim var_retorno As String
        lista = obj.buscanitcliente(nit)
        If lista.Count > 0 Then
            var_retorno = lista.Item(0).nomyap.ToString
        Else
            var_retorno = ""
        End If

        Return var_retorno
    End Function

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If IsNumeric(ComboBox2.SelectedValue) Then
            verifica(ComboBox1, ComboBox2)
        End If
    End Sub

    Private Sub verifica(ByVal combo As ComboBox, combo2 As ComboBox)
        If combo.SelectedIndex >= 0 Then
            Dim valor2 = 0
            If IsNumeric(combo2.SelectedValue) Then
                valor2 = combo2.SelectedValue
            Else
                valor2 = 0
            End If
            If IsNumeric(combo.SelectedValue) Then
                    Dim cuenta As Integer
                    Dim obj As New Negocio_Producto
                    Dim listaProductos As New List(Of Entidad_Producto)
                listaProductos = obj.Mostrarproducto(valor2, combo.SelectedValue)
                'cuenta = contarproductoporcategoria(valor2, combo.SelectedValue)
                cuenta = listaProductos.Count
                dibuja(cuenta, listaProductos)
            Else

            End If
        Else
            MsgBox("Se debe asignar Proveedor")

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            verifica(ComboBox1, ComboBox2)
        Else
            'Dim num As Integer
            'num = contarproducto()
            mostrarproducto()
        End If

    End Sub

    Private Sub limpiar()
        ComboBox1.SelectedIndex = -1
        ComboBox1.Text = ""
        rbtcontado.Checked = True
        Me.ListView1.Items.Clear()
        Label4.Text = "0.00"
        Label5.Text = ""
        TextBox1.Text = ""
        ComboBox2.SelectedIndex = -1
        CheckBox1.Checked = False
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Date.Now.ToLocalTime
        NumericUpDown1.Value = 0
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Mantenimiento_Proveedores.Show()
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.Click

        If ListView1.SelectedItems.Count > 0 Then
            Dim respuesta As Integer
            Dim txtcount As Integer = ListView1.SelectedIndices(0) 'Gets the index of the first selected index
            respuesta = MsgBox("Confirma que elimina el item:" & ListView1.Items(txtcount).SubItems(1).Text & "  " & ListView1.Items(txtcount).SubItems(3).Text & "  unidades", vbYesNo, "Elimnina Item")
            If respuesta = MsgBoxResult.Yes Then
                Dim cantidad As Double, precio As Double, iva As Double
                iva = 0.12
                cantidad = CDbl(ListView1.Items(txtcount).SubItems(2).Text)
                precio = CDbl(ListView1.Items(txtcount).SubItems(3).Text)
                Label4.Text = FormatNumber(CDbl(Label4.Text) - (precio), 2) 'Multiplicamos el precio por la cantidad'
                Label13.Text = FormatNumber(CDbl(Label13.Text) - (precio) * iva / (1 + iva), 2)
                ListView1.Items(txtcount).Remove()
            End If

        End If

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.Validated
        Dim subtotal As Double
        For i = 0 To ListView1.Items.Count - 1
            subtotal += CDbl(ListView1.Items(i).SubItems(3).Text)
        Next

        Label4.Text = CStr(subtotal)
        Label4.Text = FormatNumber(CDbl(Label4.Text) - NumericUpDown1.Value, 2)
    End Sub

    Private Sub ListView1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Form__KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(Keys.Tab, True)
        End If

    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        pag = NumericUpDown2.Value
        TextBox2.Text = ""
        CheckBox1.Checked = False
        mostrarproducto()
        CheckBox1.Checked = True

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub
End Class