Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Imports System.Text

Public Class Venta
    Private txt() As PictureBox
    Private lbl() As Label
    Dim panel As New PanelExtended
    Dim pag As Integer = 1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Cobros.Show()
        Cobros.ComboBox1.Text = ComboBox1.Text

    End Sub

    Private Sub Venta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        panel.AutoScroll = True
            panel.Location = New System.Drawing.Point(600, 85)
            panel.Name = "Panel1"
            panel.Size = New System.Drawing.Size(540, 580)

            Me.Controls.Add(panel)


            mostrarproducto()

            With ListView1
                .View = View.Details
            .Columns.Add("ID", 0)
            .Columns.Add("Producto", 260)
            .Columns.Add("Precio", 70, HorizontalAlignment.Right)
                .Columns.Add("Cantidad", 70, HorizontalAlignment.Right)
                .Columns.Add("Valor", 100, HorizontalAlignment.Right)
            .Columns.Add("Cod Barra", 0)
        End With


            If File.Exists("c:\temp\imagenes\logo.png") Then 'Comprobamos que el archivo existe'
                PictureBox1.Load("c:\temp\imagenes\logo.png")
            End If


            cargarcombosucursal()
        cargarcombo(ComboBox1)
        cargarcombo4(ComboBox4)
        cargarcombocategoria()
        cargarcombotipoventa()
        cargarcomboempleado()


    End Sub

    Private Sub cargarcombo4(ByVal combo As ComboBox)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.Mostrarproveedor
        combo.DataSource = lista
        combo.DisplayMember = "nombre"
        combo.ValueMember = "idcliente"

        combo.SelectedIndex = -1
    End Sub

    Private Sub cargarcombo(ByVal combo As ComboBox)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.Mostrarcliente
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

    Private Sub cargarcombosucursal()
        Dim lista As New List(Of Entidad_Sucursal)
        Dim obj As New Negocio_Sucursal
        lista = obj.Mostrarsucursal("")
        ComboBox3.DataSource = lista
        ComboBox3.DisplayMember = "nombre"
        ComboBox3.ValueMember = "idsucursal"
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub cargarcombotipoventa()
        Dim lista As New List(Of Entidad_Tipo_venta)
        Dim obj As New Negocio_TipoVenta
        lista = obj.Mostrartipoventa("")
        ComboBox5.DataSource = lista
        ComboBox5.DisplayMember = "descripcion"
        ComboBox5.ValueMember = "idtipoventa"
        ComboBox5.SelectedIndex = -1
    End Sub
    Private Sub cargarcomboempleado()
        Dim lista As New List(Of Entidad_Empleado)
        Dim obj As New Negocio_Empleado
        lista = obj.MostrarEmpleado("")
        ComboBox6.DataSource = lista
        ComboBox6.DisplayMember = "nombres_apellidos"
        ComboBox6.ValueMember = "idempleado"
        ComboBox6.SelectedIndex = -1
    End Sub

    'para buscar un producto'
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim cuenta As Integer
        Dim obj As New Negocio_Producto
        Dim listaProductos As New List(Of Entidad_Producto)
        If CheckBox1.Checked And ComboBox2.SelectedIndex >= 0 Then
            If IsNumeric(ComboBox2.SelectedValue) Then
                listaProductos = obj.buscarnomcat(Me.TextBox2.Text, ComboBox2.SelectedValue)
                ' cuenta = obj.contarproductospornomycat(Me.TextBox2.Text, ComboBox2.SelectedValue)
                cuenta = listaProductos.Count
                dibuja(cuenta, listaProductos)
            End If
           
        Else

            listaProductos = obj.buscartodoproducto(Me.TextBox2.Text)
            cuenta = listaProductos.Count
            'cuenta = contarproductoporfiltro(TextBox2.Text)
            dibuja(cuenta, listaProductos)
        End If


    End Sub

    Private Sub btnvender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvender.Click
        Dim IVA As Decimal
        IVA = 0.12

        If Label5.Text = "" Then
            MessageBox.Show("Debe seleccionar un cliente")
            ComboBox1.Focus()
            Exit Sub
        End If

        If ListView1.Items.Count <= 0 Then
            MessageBox.Show("Debe seleccionar por lo menos un producto")
            Exit Sub
        End If

        If ComboBox3.SelectedValue = Nothing Then
            MessageBox.Show("Debe asignar sucursal")
            ComboBox3.Focus()
            Exit Sub
        End If

        If TextBox5.Text = "" Then
            MessageBox.Show("Debe ingresar correlativo")
            TextBox5.Focus()
            Exit Sub
        End If
        If ComboBox6.Text = "" Then
            MessageBox.Show("Debe asignar empleado")
            ComboBox6.Focus()
            Exit Sub
        End If
        'para recuperar el id del empleado
        '     Dim lista2 As New List(Of Entidad_Empleado)
        '     Dim obj2 As New Negocio_Empleado
        '    lista2 = obj2.obtener_idempleado(Mid(Principal.Text, 11, Principal.Text.Length))

        Dim cancelado As Integer

        ' falta una funcion que verifique que el tipo de documento es credito
        If ComboBox5.SelectedValue = 4 Then
            cancelado = 0
        Else
            cancelado = 1
        End If


        'Agregar Venta
        Dim Entidad As New Entidad_Venta
        Dim Negocio As New Negocio_Venta
        Dim conteo As Integer
        Dim tipoventa As Integer

        tipoventa = ComboBox5.SelectedValue
        conteo = Negocio.verifica(TextBox5.Text)
        If conteo > 0 Then
            MsgBox("Documento duplicado")
            Exit Sub
        End If

        With Entidad
            .idcliente = Label5.Text 'Agregamos idcliente'
            .idempleado = ComboBox6.SelectedValue
            '   .idempleado = lista2.Item(0).idempleado 'Agregamos idempleado'
            .idtipoventa = tipoventa
            '.idtipoventa = ComboBox5.SelectedValue
            .fecha = Me.convertirfecha_ansi(Me.DateTimePicker1, Me.DateTimePicker2)
            .idfactura = TextBox5.Text
            .sucursal = ComboBox3.SelectedValue.ToString
            '.tot_bien = FormatNumber(CDbl(Label4.Text) / (1 + IVA), 2)
            .iva_bien = CDbl(Label10.Text)
            .tot_servicio = 0
            .tot_bien = FormatNumber(CDbl(Label4.Text) - CDbl(Label10.Text), 2)
            .iva_servicio = 0
            .tot_documento = Label4.Text
            .fecha_vence = Me.convertirfecha_ansi(Me.DateTimePicker3, Me.DateTimePicker3)
            '.sucursal = sucursales.Item(0).idsucursal
            .nombre_cliente = ComboBox1.Text
        End With

        'llamamos a agregar venta'
        Dim idventamax As Integer
        idventamax = Negocio.Nueva_Venta(Entidad)


        'Para Agregar Venta_Detalle'
        Dim Entidad_detalle As New Entidad_ventadetalle
        Dim Negocio_detalle As New Negocio_Venta_Detalle

        For i = 0 To ListView1.Items.Count - 1
            'Para Obtener el id del producto
            'Dim lista3 As New List(Of Entidad_Producto)
            'Dim obj3 As New Negocio_Producto
            'lista3 = obj3.obtener_idproducto(ListView1.Items(i).SubItems(0).Text)


            With Entidad_detalle
                .idproducto = ListView1.Items(i).SubItems(0).Text
                .precio = ListView1.Items(i).SubItems(2).Text
                .cantidad = ListView1.Items(i).SubItems(3).Text
                .cancelado = cancelado
                .codigo_barra = ListView1.Items(i).SubItems(5).Text
                .idventa = idventamax
            End With
            'Agregamos la venta Detalle'
            Negocio_detalle.Nueva_VentaDetalle(Entidad_detalle)

            'Para Actualizar el Stock'
            Dim Entidad_productos As New Entidad_Producto
            Dim Negocio_productos As New Negocio_Producto

            Dim listaProductos As New List(Of Entidad_Producto)
            'Buscamos el precio y el stock'
            listaProductos = Negocio_productos.preciostock(ListView1.Items(i).SubItems(0).Text)

            With Entidad_productos
                '.stock = CType(listaProductos.Item(0).stock, Integer) - CType(ListView1.Items(i).SubItems(3).Text, Integer)
                .stock = CType(ListView1.Items(i).SubItems(3).Text, Integer)
                .idproducto = ListView1.Items(i).SubItems(0).Text
            End With

            Negocio_productos.Actualiza_Stock(Entidad_productos, tipoventa)

        Next
        'MessageBox.Show("Transacion Finalizada")
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



    'Procedimiento para que se muestren todos los productos en Picturebox'
    Private Sub mostrarproducto()   '(ByVal fin As Integer)
        Dim lista As New List(Of Entidad_Producto)
        Dim obj As New Negocio_Producto
        lista = obj.Mostrartodosproducto("")
        Dim fin As Integer
        fin = lista.Count
        If (Math.Round(fin / 12, 0) - 1) > 0 Then
            NumericUpDown1.Maximum = Math.Round(fin / 12, 0) - 1
        Else
            NumericUpDown1.Maximum = fin
        End If

        If fin > 0 Then
            dibuja(fin, lista)
        Else

        End If
    End Sub

    'metodo para dibujar picturebox en tiempo de ejecucion'
    Private Sub dibuja(ByVal fin As Integer, ByVal lista As List(Of Entidad_Producto))

        panel.Controls.Clear() 'Eliminamos todos los controles que esten en panel'
        Dim i As Integer
        Dim j As Integer = 0
        Dim p As Integer = 0
        Dim contador As Integer = 0
        ReDim txt(fin)
        ReDim lbl(fin)
        Dim constante As Integer = 160 'variable que determina el espaciado entre los picturebox'
        Dim constantex As Integer = 130
        Dim pagina = 0
        If fin > (12 * pag) Then
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
            Else
                Me.txt(i).Load("c:\temp\imagenes\productos\nd.jpg")
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
            Me.lbl(i).Text = lista.Item(i - 1).nombre + "  Q." + FormatNumber(lista.Item(i - 1).precio_bien, 2)
            Me.lbl(i).ForeColor = Color.White
            Me.lbl(i).BackColor = Color.DarkSlateBlue
            Me.lbl(i).Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl(i).Size = New System.Drawing.Size(130, 50)
            Me.lbl(i).TextAlign = ContentAlignment.TopCenter
            panel.Controls.Add(lbl(i))

            AddHandler txt(i).Click, AddressOf All_filter_click
        Next

    End Sub

    'Asignar un manejador de evento al control creado'
    Private Sub All_filter_click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim picture As PictureBox
        picture = CType(sender, PictureBox)
        traslada_datos_captura_detalle_producto(picture.Name)


    End Sub

    Sub traslada_datos_captura_detalle_producto(ByVal idproducto As Integer)

        Dim obj As New Negocio_Producto
        Dim listaProductos As New List(Of Entidad_Producto)
        listaProductos = obj.preciostock(idproducto) 'Se Busca el precio y el stock' 
        Dim precio_credito As Decimal

        precio_credito = FormatNumber((listaProductos.Item(0).precio_bien) * 1.1, 4)
        Detalle_Producto.Label2.Text = listaProductos.Item(0).stock
        Detalle_Producto.Label7.Text = listaProductos.Item(0).precio_bien
        Detalle_Producto.Label9.Text = precio_credito
        Detalle_Producto.Label11.Text = listaProductos.Item(0).precio_minimo
        Detalle_Producto.Label3.Text = listaProductos.Item(0).precio
        Detalle_Producto.Label13.Text = listaProductos.Item(0).iva_unidad

        If File.Exists("c:\temp\imagenes\productos\" + listaProductos.Item(0).foto) Then
            Detalle_Producto.PictureBox1.Load("c:\temp\imagenes\productos\" + listaProductos.Item(0).foto)
        End If

        Detalle_Producto.PictureBox1.Name = idproducto
        Detalle_Producto.Label6.Text = listaProductos.Item(0).nombre
        If Len(TextBox6.Text) = 0 Then
            Detalle_Producto.TextBox2.Text = listaProductos.Item(0).codigo_barra
        Else
            Detalle_Producto.TextBox2.Text = TextBox6.Text
        End If
        Detalle_Producto.Show() 'Abrimos el formulario detalle producto '

    End Sub



    Private Function borrar_contarproducto() As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        'valor = obj.contarproductos
        Return valor
    End Function


    Private Function borrar_contarproductoporfiltro(ByVal nombre As String) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        'valor = obj.contarproductosporfiltro(nombre)
        Return valor
    End Function


    Private Function borrar_contarproductoporcategoria(ByVal id As Integer, idproveedor As Integer) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Producto
        'valor = obj.contarproductosporcategoria(id, idproveedor)
        Return valor
    End Function


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
            Else
                TextBox1.Text = ""
                TextBox3.Text = ""
            End If
        Else
            Label5.Text = ""
        End If
        TextBox4.Text = Label5.Text
    End Sub

    Public Function obtiene_nit_cliente(ByVal itemList As Integer) As String
        Dim obj As New Negocio_Cliente
        Dim lista As New List(Of Entidad_Cliente)
        Dim var_retorno As String
        lista = obj.MostrarDatosCliente(itemList)

        If lista.Count > 0 Then
            var_retorno = lista.Item(0).nit.ToString
        Else
            var_retorno = ""
        End If
        Return var_retorno
    End Function
    Public Function obtiene_direccion_cliente(ByVal itemList As Integer) As String
        Dim obj As New Negocio_Cliente
        Dim lista As New List(Of Entidad_Cliente)
        Dim var_retorno As String
        lista = obj.MostrarDatosCliente(itemList)
        If lista.Count > 0 Then
            var_retorno = lista.Item(0).direccion.ToString
        Else
            var_retorno = ""
        End If
        Return var_retorno
    End Function

    Public Function obtiene_nombres_cliente(ByVal itemList As Integer) As String
        Dim obj As New Negocio_Cliente
        Dim lista As New List(Of Entidad_Cliente)
        Dim var_retorno As String
        lista = obj.MostrarDatosCliente(itemList)
        If lista.Count > 0 Then
            var_retorno = lista.Item(0).nombre.ToString
        Else
            var_retorno = ""
        End If
        Return var_retorno
    End Function
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
        verifica(ComboBox2, ComboBox4)
    End Sub

    Private Sub verifica(ByVal combo As ComboBox, combo2 As ComboBox)

        If CheckBox1.Checked And combo.SelectedIndex >= 0 And CheckBox2.Checked And combo2.SelectedIndex >= 0 Then
            Dim cuenta As Integer
            Dim obj As New Negocio_Producto
            Dim listaProductos As New List(Of Entidad_Producto)
            listaProductos = obj.Mostrarproducto(combo.SelectedValue, combo2.SelectedValue)

            cuenta = listaProductos.Count
            dibuja(cuenta, listaProductos)

        Else
            If CheckBox1.Checked And combo.SelectedIndex >= 0 Then
                If IsNumeric(combo.SelectedValue) Then
                    Dim cuenta As Integer
                    Dim obj As New Negocio_Producto
                    Dim listaProductos As New List(Of Entidad_Producto)
                    listaProductos = obj.Mostrarproducto(combo.SelectedValue, 0)
                    cuenta = listaProductos.Count

                    dibuja(cuenta, listaProductos)
                End If
            End If

            If CheckBox2.Checked And combo2.SelectedIndex >= 0 Then
                If IsNumeric(combo2.SelectedValue) Then
                    Dim cuenta As Integer
                    Dim obj As New Negocio_Producto
                    Dim listaProductos As New List(Of Entidad_Producto)
                    listaProductos = obj.Mostrarproducto(0, combo2.SelectedValue)
                    cuenta = listaProductos.Count

                    dibuja(cuenta, listaProductos)
                End If
            End If


        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            verifica(ComboBox2, ComboBox4)
        Else
            CheckBox2.Checked = False

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
        ComboBox2.SelectedIndex = -1
        CheckBox1.Checked = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        Label10.Text = "0.00"
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Date.Now.ToLocalTime
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.ForeColor = Color.Red Then

            Dim Entidad As New Entidad_Cliente
            Dim Negocio As New Negocio_Cliente

            With Entidad
                .nombre = ComboBox1.Text
                .apellidos = ""
                .telefono = ""
                .nit = TextBox1.Text
                .direccion = TextBox3.Text
            End With
            TextBox4.Text = Negocio.Nuevo_cliente(Entidad)

        End If
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub TextBox4_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox4.Validated
        If TextBox4.TextLength >= 0 Then
            ComboBox1.Text = obtiene_nombre_cliente(TextBox4.Text)
        Else
            ComboBox1.Text = ""
        End If
        Button2.ForeColor = Color.Black
        If ComboBox1.Text.Length < 1 Then
            TextBox3.Text = "Ciudad"
            Button2.ForeColor = Color.Red
            ComboBox1.Focus()
        End If

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.Validated
        Dim cuenta As Integer
        Dim obj As New Negocio_Producto
        Dim listaProductos As New List(Of Entidad_Producto)
        listaProductos = obj.buscartodoproducto(Me.TextBox6.Text)
        cuenta = listaProductos.Count
        ' cuenta = contarproductoporfiltro(TextBox6.Text)
        dibuja(cuenta, listaProductos)


    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        If CheckBox2.Checked Then
            verifica(ComboBox2, ComboBox4)
        Else
            CheckBox1.Checked = False
            'Dim num As Integer
            'num = contarproducto()
            mostrarproducto() ' (num)
        End If

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        verifica(ComboBox2, ComboBox4)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.Validated
        If TextBox1.TextLength >= 0 Then
            ComboBox1.Text = obtiene_nombre_cliente(TextBox1.Text)
        Else
            ComboBox1.Text = ""
        End If
        Button2.ForeColor = Color.Black
        If ComboBox1.Text.Length < 1 Then
            TextBox3.Text = "Ciudad"
            Button2.ForeColor = Color.Red
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.Validated
        If IsNumeric(TextBox4.Text) Then
            Label5.Text = TextBox4.Text
            ComboBox1.Text = obtiene_nombres_cliente(CInt(Label5.Text))
            TextBox1.Text = obtiene_nit_cliente(CInt(Label5.Text))
            TextBox3.Text = obtiene_direccion_cliente(CInt(Label5.Text))
        Else
            TextBox1.Text = ""
            TextBox3.Text = ""
            ComboBox1.Text = ""
        End If
        Button2.ForeColor = Color.Black
    End Sub

    '    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim respuesta As Integer
            Dim txtcount As Integer = ListView1.SelectedIndices(0) 'Gets the index of the first selected index
            respuesta = MsgBox("Confirma que modifica el item:" & ListView1.Items(txtcount).SubItems(1).Text & "  " & ListView1.Items(txtcount).SubItems(3).Text & "  unidades", vbYesNo, "Elimnina Item")
            If respuesta = MsgBoxResult.Yes Then
                Dim cantidad As Double, precio As Double, iva As Double, idproducto As Integer
                idproducto = ListView1.Items(txtcount).SubItems(0).Text
                iva = 0.12
                precio = CDbl(ListView1.Items(txtcount).SubItems(2).Text)
                cantidad = CDbl(ListView1.Items(txtcount).SubItems(3).Text)
                Label4.Text = FormatNumber(CDbl(Label4.Text) - (cantidad * precio), 2) 'Multiplicamos el precio por la cantidad'
                Label10.Text = FormatNumber(CDbl(Label10.Text) - (cantidad * precio) * iva / (1 + iva), 2)
                ListView1.Items(txtcount).Remove()
                traslada_datos_captura_detalle_producto(idproducto)
            End If

        End If

    End Sub
    Private Sub TextBox6__KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(ChrW(Keys.Tab), True)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
    End Sub

    Private Sub TextBox6_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub


    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        pag = NumericUpDown1.Value
        TextBox2.Text = ""
        TextBox6.Text = ""
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        mostrarproducto()
        CheckBox1.Checked = True
        CheckBox2.Checked = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        imprimir()
    End Sub
    Private Sub imprimir()

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
        path1 = "c:\temp\impresiones\factura " + ComboBox5.Text + ".txt"
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
                        If lineatexto = "<NOMBRE>" Then lineadato = Mid(ComboBox1.Text, 1, 100)
                        If lineatexto = "<DIRECCION>" Then lineadato = Mid(TextBox3.Text, 1, 100)
                        If lineatexto = "<TIPO DOCUMENTO>" Then lineadato = ComboBox5.Text
                        If lineatexto = "<SUCURSAL>" Then lineadato = ComboBox3.Text
                        If lineatexto = "<CORRELATIVO>" Then lineadato = TextBox5.Text
                        If lineatexto = "<FECHA>" Then lineadato = DateTimePicker1.Value.ToString
                        If lineatexto = "<TOTAL>" Then lineadato = formatoNumero(Label4.Text)
                        If lineatexto = "<DIASCREDITO>" Then lineadato = CStr((DateTimePicker3.Value - DateTimePicker1.Value).Days)
                        If lineatexto = "<VENCIMIENTO>" Then lineadato = DateTimePicker3.Value.ToString
                        If lineatexto = "<TOTALLETRAS>" Then lineadato = convertirLetras(Label4.Text)
                        If lineatexto = "<VENDEDOR>" Then lineadato = ComboBox6.Text

                        Dim conteoLineas As Integer
                        conteoLineas = ListView1.Items.Count

                        If conteoLineas > 0 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_01>" : lineadato = Mid(ListView1.Items(0).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_01>" : lineadato = Mid(ListView1.Items(0).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_01>" : lineadato = formatoNumero(ListView1.Items(0).SubItems(3).Text)
                                Case "<PRECIO_01>" : lineadato = formatoNumero(ListView1.Items(0).SubItems(2).Text)
                                Case "<IMPORTE_01>" : lineadato = formatoNumero(ListView1.Items(0).SubItems(4).Text)
                            End Select
                        End If

                        If conteoLineas > 1 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_02>" : lineadato = Mid(ListView1.Items(1).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_02>" : lineadato = Mid(ListView1.Items(1).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_02>" : lineadato = formatoNumero(ListView1.Items(1).SubItems(3).Text)
                                Case "<PRECIO_02>" : lineadato = formatoNumero(ListView1.Items(1).SubItems(2).Text)
                                Case "<IMPORTE_02>" : lineadato = formatoNumero(ListView1.Items(1).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 2 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_03>" : lineadato = Mid(ListView1.Items(2).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_03>" : lineadato = Mid(ListView1.Items(2).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_03>" : lineadato = formatoNumero(ListView1.Items(2).SubItems(3).Text)
                                Case "<PRECIO_03>" : lineadato = formatoNumero(ListView1.Items(2).SubItems(2).Text)
                                Case "<IMPORTE_03>" : lineadato = formatoNumero(ListView1.Items(2).SubItems(4).Text)
                            End Select
                        End If

                        If conteoLineas > 3 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_04>" : lineadato = Mid(ListView1.Items(3).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_04>" : lineadato = Mid(ListView1.Items(3).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_04>" : lineadato = formatoNumero(ListView1.Items(3).SubItems(3).Text)
                                Case "<PRECIO_04>" : lineadato = formatoNumero(ListView1.Items(3).SubItems(2).Text)
                                Case "<IMPORTE_04>" : lineadato = formatoNumero(ListView1.Items(3).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 4 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_05>" : lineadato = Mid(ListView1.Items(4).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_05>" : lineadato = Mid(ListView1.Items(4).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_05>" : lineadato = formatoNumero(ListView1.Items(4).SubItems(3).Text)
                                Case "<PRECIO_05>" : lineadato = formatoNumero(ListView1.Items(4).SubItems(2).Text)
                                Case "<IMPORTE_05>" : lineadato = formatoNumero(ListView1.Items(4).SubItems(4).Text)
                            End Select
                        End If

                        If conteoLineas > 5 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_06>" : lineadato = Mid(ListView1.Items(5).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_06>" : lineadato = Mid(ListView1.Items(5).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_06>" : lineadato = formatoNumero(ListView1.Items(5).SubItems(3).Text)
                                Case "<PRECIO_06>" : lineadato = formatoNumero(ListView1.Items(5).SubItems(2).Text)
                                Case "<IMPORTE_06>" : lineadato = formatoNumero(ListView1.Items(5).SubItems(4).Text)
                            End Select
                        End If

                        If conteoLineas > 6 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_07>" : lineadato = Mid(ListView1.Items(6).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_07>" : lineadato = Mid(ListView1.Items(6).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_07>" : lineadato = formatoNumero(ListView1.Items(6).SubItems(3).Text)
                                Case "<PRECIO_07>" : lineadato = formatoNumero(ListView1.Items(6).SubItems(2).Text)
                                Case "<IMPORTE_07>" : lineadato = formatoNumero(ListView1.Items(6).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 7 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_08>" : lineadato = Mid(ListView1.Items(7).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_08>" : lineadato = Mid(ListView1.Items(7).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_08>" : lineadato = formatoNumero(ListView1.Items(7).SubItems(3).Text)
                                Case "<PRECIO_08>" : lineadato = formatoNumero(ListView1.Items(7).SubItems(2).Text)
                                Case "<IMPORTE_08>" : lineadato = formatoNumero(ListView1.Items(7).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 8 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_09>" : lineadato = Mid(ListView1.Items(8).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_09>" : lineadato = Mid(ListView1.Items(8).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_09>" : lineadato = formatoNumero(ListView1.Items(8).SubItems(3).Text)
                                Case "<PRECIO_09>" : lineadato = formatoNumero(ListView1.Items(8).SubItems(2).Text)
                                Case "<IMPORTE_09>" : lineadato = formatoNumero(ListView1.Items(8).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 9 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_10>" : lineadato = Mid(ListView1.Items(9).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_10>" : lineadato = Mid(ListView1.Items(9).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_10>" : lineadato = formatoNumero(ListView1.Items(9).SubItems(3).Text)
                                Case "<PRECIO_10>" : lineadato = formatoNumero(ListView1.Items(9).SubItems(2).Text)
                                Case "<IMPORTE_10>" : lineadato = formatoNumero(ListView1.Items(9).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 10 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_11>" : lineadato = Mid(ListView1.Items(10).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_11>" : lineadato = Mid(ListView1.Items(10).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_11>" : lineadato = formatoNumero(ListView1.Items(10).SubItems(3).Text)
                                Case "<PRECIO_11>" : lineadato = formatoNumero(ListView1.Items(10).SubItems(2).Text)
                                Case "<IMPORTE_11>" : lineadato = formatoNumero(ListView1.Items(10).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 11 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_12>" : lineadato = Mid(ListView1.Items(11).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_12>" : lineadato = Mid(ListView1.Items(11).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_12>" : lineadato = formatoNumero(ListView1.Items(11).SubItems(3).Text)
                                Case "<PRECIO_12>" : lineadato = formatoNumero(ListView1.Items(11).SubItems(2).Text)
                                Case "<IMPORTE_12>" : lineadato = formatoNumero(ListView1.Items(11).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 12 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_13>" : lineadato = Mid(ListView1.Items(12).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_13>" : lineadato = Mid(ListView1.Items(12).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_13>" : lineadato = formatoNumero(ListView1.Items(12).SubItems(3).Text)
                                Case "<PRECIO_13>" : lineadato = formatoNumero(ListView1.Items(12).SubItems(2).Text)
                                Case "<IMPORTE_13>" : lineadato = formatoNumero(ListView1.Items(12).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 13 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_14>" : lineadato = Mid(ListView1.Items(13).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_14>" : lineadato = Mid(ListView1.Items(13).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_14>" : lineadato = formatoNumero(ListView1.Items(13).SubItems(3).Text)
                                Case "<PRECIO_14>" : lineadato = formatoNumero(ListView1.Items(13).SubItems(2).Text)
                                Case "<IMPORTE_14>" : lineadato = formatoNumero(ListView1.Items(13).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 14 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_15>" : lineadato = Mid(ListView1.Items(14).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_15>" : lineadato = Mid(ListView1.Items(14).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_15>" : lineadato = formatoNumero(ListView1.Items(14).SubItems(3).Text)
                                Case "<PRECIO_15>" : lineadato = formatoNumero(ListView1.Items(14).SubItems(2).Text)
                                Case "<IMPORTE_15>" : lineadato = formatoNumero(ListView1.Items(14).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 15 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_16>" : lineadato = Mid(ListView1.Items(15).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_16>" : lineadato = Mid(ListView1.Items(15).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_16>" : lineadato = formatoNumero(ListView1.Items(15).SubItems(3).Text)
                                Case "<PRECIO_16>" : lineadato = formatoNumero(ListView1.Items(15).SubItems(2).Text)
                                Case "<IMPORTE_16>" : lineadato = formatoNumero(ListView1.Items(15).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 16 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_17>" : lineadato = Mid(ListView1.Items(16).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_17>" : lineadato = Mid(ListView1.Items(16).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_17>" : lineadato = formatoNumero(ListView1.Items(16).SubItems(3).Text)
                                Case "<PRECIO_17>" : lineadato = formatoNumero(ListView1.Items(16).SubItems(2).Text)
                                Case "<IMPORTE_17>" : lineadato = formatoNumero(ListView1.Items(16).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 17 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_18>" : lineadato = Mid(ListView1.Items(17).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_18>" : lineadato = Mid(ListView1.Items(17).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_18>" : lineadato = formatoNumero(ListView1.Items(17).SubItems(3).Text)
                                Case "<PRECIO_18>" : lineadato = formatoNumero(ListView1.Items(17).SubItems(2).Text)
                                Case "<IMPORTE_18>" : lineadato = formatoNumero(ListView1.Items(17).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 18 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_19>" : lineadato = Mid(ListView1.Items(18).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_19>" : lineadato = Mid(ListView1.Items(18).SubItems(1).Text, 1, 30)
                                Case "<CANTIDAD_19>" : lineadato = formatoNumero(ListView1.Items(18).SubItems(3).Text)
                                Case "<PRECIO_19>" : lineadato = formatoNumero(ListView1.Items(18).SubItems(2).Text)
                                Case "<IMPORTE_19>" : lineadato = formatoNumero(ListView1.Items(18).SubItems(4).Text)
                            End Select
                        End If
                        If conteoLineas > 19 Then
                            Select Case lineatexto
                                Case "<PRODUCTO_20>" : lineadato = Mid(ListView1.Items(19).SubItems(5).Text, 1, 15)
                                Case "<NPRODUCTO_20>" : lineadato = Mid(ListView1.Items(19).SubItems(1).Text, 1, 30)
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
        'textoFormato = Format(numero, "#,##0.00")
        textoFormato = StrDup(15 - numero.Length, " ") & numero
        Return textoFormato
    End Function

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
        If decimales = "00" Then decimales_texto = "QUETZALES EXACTOS." Else decimales_texto = " CON " + decimales + "/100 QUETZALES"
        Return CENTENASMILTEXTO + DECENASMILTEXTO + DECENASMIL_Y + UNIDADESMILTEXTO + CENTENASTEXTO + DECENASTEXTO + DECENAS_Y + UNIDADESTEXTO + decimales_texto
    End Function

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        Dim path As String
        If path1.SelectedPath.ToString.Length > 0 Then
            path = path1.SelectedPath.ToString + "\exporta_venta.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Exporta_Venta)
            Dim obj As New Negocio_Venta
            Dim mes As String, anio As String
            mes = InputBox("MES:")
            anio = InputBox("AÑO:")
            lista = obj.exporta_venta(mes, anio)
            Dim lista2 As New Xml.Serialization.XmlSerializer(lista.GetType)

            Dim archivo As TextWriter
            archivo = New StringWriter()


            lista2.Serialize(archivo, lista)
            Dim archivoTexto As String
            archivoTexto = archivo.ToString

            ' correccion caracteres especiales en xml
            archivoTexto = Replace(archivoTexto, "utf-16", "utf-8")
            archivoTexto = Replace(archivoTexto, "á", "a")
            archivoTexto = Replace(archivoTexto, "é", "e")
            archivoTexto = Replace(archivoTexto, "í", "i")
            archivoTexto = Replace(archivoTexto, "ó", "o")
            archivoTexto = Replace(archivoTexto, "ú", "u")
            archivoTexto = Replace(archivoTexto, "ñ", "n")
            archivoTexto = Replace(archivoTexto, "Ñ", "N")

            My.Computer.FileSystem.WriteAllText(path, archivoTexto, False)

        End If

    End Sub
End Class