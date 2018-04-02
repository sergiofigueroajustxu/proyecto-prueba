Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO


Public Class Gasto

    Private Sub Libro_Compras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargarcombosucursal()
        cargarnomenclaturabien()
        cargarnomenclaturaservicio()
        cargarcombotipocompra()
        cargarcombo()
        cargargridview()
        TextBox7.Text = Year(Now())
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        eliminar_compra()
        cargargridview()
    End Sub

    Private Sub personalizargridview(ByVal grid As DataGridView)
        With grid
            .BackgroundColor = Color.White
            .EnableHeadersVisualStyles = False 'desactivar el estilo visual'
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .RowHeadersVisible = False
            .DefaultCellStyle.SelectionBackColor = Color.DarkGray
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .AllowUserToResizeRows = False
        End With
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
    Private Sub cargarcombo()
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.Mostrarproveedor
        ComboBox1.DataSource = lista
        ComboBox1.DisplayMember = "nombre"
        ComboBox1.ValueMember = "idcliente"
        ComboBox1.SelectedIndex = -1
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
    Private Sub cargarnomenclaturabien()
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Negocio_Nomenclatura
        lista = obj.MostrarNomenclaturaGastos("")
        ComboBox2.DataSource = lista
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "cuenta"
        ComboBox2.SelectedIndex = -1
    End Sub
    Private Sub cargarnomenclaturaservicio()
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Negocio_Nomenclatura
        lista = obj.MostrarNomenclaturaServicios("")
        ComboBox4.DataSource = lista
        ComboBox4.DisplayMember = "nombre"
        ComboBox4.ValueMember = "cuenta"
        ComboBox4.SelectedIndex = -1
    End Sub


    Private Sub eliminar_compra()
        Dim Entidad As New Entidad_Compras
        Dim Negocio As New Negocio_Compras
        If TextBox41.Text.Length > 0 Then
            With Entidad
                .idcompra = TextBox41.Text
            End With

            Negocio.Eliminar_Compra(Entidad)
        End If
    End Sub


    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Libro_Compra)
        Dim obj As New Negocio_Compras
        lista = obj.Mostrarlibrocompra(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub limpiar()
        TextBox1.Text = ""
        'TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox41.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox10.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        NumericUpDown1.Value = 0
        NumericUpDown2.Value = 0
        NumericUpDown3.Value = 0
        NumericUpDown4.Value = 0
        NumericUpDown5.Value = 0
        NumericUpDown6.Value = 0
        NumericUpDown7.Value = 0

    End Sub

    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        Button1.Enabled = bol
        Button3.Enabled = bol

    End Sub




    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        TextBox41.Text = Me.DataGridView1(12, fila).Value.ToString
        ComboBox3.SelectedValue = CInt(Me.DataGridView1(0, fila).Value) 'sucursal
        ComboBox5.Text = Me.DataGridView1(1, fila).Value 'Tipo documento
        TextBox6.Text = Me.DataGridView1(2, fila).Value.ToString 'correlativo
        DateTimePicker1.Value = Me.DataGridView1(3, fila).Value.ToString 'fecha
        TextBox10.Text = Me.DataGridView1(4, fila).Value.ToString 'nit
        ComboBox1.Text = Me.DataGridView1(5, fila).Value 'nombre del cliente

        NumericUpDown4.Value = Me.DataGridView1(8, fila).Value.ToString ' exento
        NumericUpDown3.Value = Me.DataGridView1(15, fila).Value.ToString ' idp
        NumericUpDown1.Value = Me.DataGridView1(6, fila).Value.ToString ' compra bien
        NumericUpDown5.Value = Me.DataGridView1(9, fila).Value.ToString ' servicio
        If Not IsNothing(Me.DataGridView1(13, fila).Value) Then ComboBox2.SelectedValue = Me.DataGridView1(13, fila).Value 'cuenta contable bien
        NumericUpDown2.Value = Me.DataGridView1(7, fila).Value.ToString ' iva bien
        NumericUpDown6.Value = Me.DataGridView1(10, fila).Value.ToString ' iva servicio
        NumericUpDown7.Value = Me.DataGridView1(11, fila).Value.ToString
        If Not IsNothing(Me.DataGridView1(14, fila).Value) Then ComboBox4.SelectedValue = Me.DataGridView1(14, fila).Value 'cuenta contable servicio

    End Sub






    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.Validated
        If TextBox10.TextLength >= 0 Then
            ComboBox1.Text = obtiene_nombre_cliente(TextBox10.Text)
        Else
            ComboBox1.Text = ""
        End If
        If ComboBox1.Text.Length < 1 Then

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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar ")
            ComboBox1.Focus()
            Exit Sub
        End If
        If ComboBox2.SelectedValue = 0 And NumericUpDown1.Value <> 0 Then
            MessageBox.Show("Debe seleccionar Cuenta Contable")
            ComboBox2.Focus()
            Exit Sub
        End If

        If ComboBox4.SelectedValue = 0 And NumericUpDown2.Value <> 0 Then
            MessageBox.Show("Debe seleccionar Cuenta Contable")
            ComboBox4.Focus()
            Exit Sub
        End If
        If ComboBox5.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar ")
            ComboBox5.Focus()
            Exit Sub
        End If


        If TextBox10.Text = "" Then
            MessageBox.Show("Debe seleccionar un proveedor")
            TextBox10.Focus()
            Exit Sub
        End If
        If ComboBox3.SelectedValue = 0 Then
            MessageBox.Show("Debe seleccionar sucursal")
            ComboBox3.Focus()
            Exit Sub
        End If

        If TextBox6.Text = "" Then
            MessageBox.Show("Debe ingresar correlativo de documento")
            TextBox6.Focus()
            Exit Sub
        End If
        'Agregar Compra
        Dim Entidad As New Entidad_Compras
        Dim Negocio As New Negocio_Compras
        Dim tipocompra As Integer
        tipocompra = ComboBox5.SelectedValue

        Dim cancelado As Integer
        Dim montopagado As Double
        cancelado = 1
        If tipocompra = 3 Then 'credito
            cancelado = 0
            montopagado = 0
        End If

        With Entidad
            .fecha = Me.convertirfecha_ansi(Me.DateTimePicker1, Me.DateTimePicker1)
            .idtipocomprobante = tipocompra
            .idfactura = TextBox6.Text
            .nit = TextBox10.Text
            .importetotal = NumericUpDown7.Value
            .contenedor = ""
            .sucursal = ComboBox3.SelectedValue
            .retencion = 0
            .compra_bien = NumericUpDown1.Value
            .servicio = NumericUpDown2.Value
            .iva_bien = NumericUpDown5.Value
            .iva_servicio = NumericUpDown6.Value
            .cuenta_bien = ComboBox2.SelectedValue
            .cuenta_servicio = ComboBox4.SelectedValue
            .exento = NumericUpDown4.Value
            .idp = NumericUpDown3.Value
        End With
        Negocio.Modificar_Compra_completa(Entidad)
        cargargridview()
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



    Private Sub grabar()

        If ComboBox1.SelectedValue = -1 Then
            MessageBox.Show("Debe seleccionar ")
            ComboBox1.Focus()
            Exit Sub
        End If
        If ComboBox2.SelectedValue = -1 And NumericUpDown1.Value <> 0 Then
            MessageBox.Show("Debe seleccionar Cuenta Contable")
            ComboBox2.Focus()
            Exit Sub
        End If
        If ComboBox3.SelectedValue = -1 Then
            MessageBox.Show("Debe seleccionar ")
            ComboBox3.Focus()
            Exit Sub
        End If
        If ComboBox4.SelectedValue = -1 And NumericUpDown2.Value <> 0 Then
            MessageBox.Show("Debe seleccionar Cuenta Contable")
            ComboBox4.Focus()
            Exit Sub
        End If
        If ComboBox5.SelectedValue = -1 Then
            MessageBox.Show("Debe seleccionar ")
            ComboBox5.Focus()
            Exit Sub
        End If

        If TextBox6.Text = "" Then
            MessageBox.Show("Debe ingresar correlativo de documento")
            TextBox6.Focus()
            Exit Sub
        End If
        'Agregar Compra
        Dim Entidad As New Entidad_Compras
        Dim Negocio As New Negocio_Compras
        Dim tipocompra As Integer
        tipocompra = ComboBox5.SelectedValue

        Dim cancelado As Integer
        Dim montopagado As Double
        cancelado = 1
        If tipocompra = 3 Then 'credito
            cancelado = 0
            montopagado = 0
        End If
        Dim cuenta_bien As String = ""
        Dim cuenta_servicio As String = ""

        If Not IsNothing(ComboBox2.SelectedValue) Then cuenta_bien = ComboBox2.SelectedValue
        If Not IsNothing(ComboBox4.SelectedValue) Then cuenta_servicio = ComboBox4.SelectedValue

        With Entidad
            .fecha = Me.convertirfecha_ansi(Me.DateTimePicker1, Me.DateTimePicker1)
            .idtipocomprobante = tipocompra
            .idfactura = TextBox6.Text
            .nit = TextBox10.Text
            .importetotal = NumericUpDown7.Value
            .contenedor = ""
            .sucursal = ComboBox3.SelectedValue
            .retencion = 0
            .compra_bien = NumericUpDown1.Value
            .servicio = NumericUpDown2.Value
            .iva_bien = NumericUpDown5.Value
            .iva_servicio = NumericUpDown6.Value
            .cuenta_bien = cuenta_bien
            .cuenta_servicio = cuenta_servicio
            .exento = NumericUpDown4.Value
            .idp = NumericUpDown3.Value
        End With
        Negocio.Nueva_Compra_Completa(Entidad)
        cargargridview()
        Habilitar_deshabilitar(True)
        Button4.Text = "Nuevo"

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim lista As New List(Of Entidad_Libro_Compra)
        Dim obj As New Negocio_Compras
        lista = obj.Mostrarlibrocompra(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "Nuevo" Then
            Button4.Text = "Guardar"
            limpiar()
            Habilitar_deshabilitar(False)
        ElseIf Button4.Text = "Guardar" Then


            grabar()

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim lista As New List(Of Entidad_Libro_Compra)
        Dim obj As New Negocio_Compras
        lista = obj.Mostrarlibrocompra(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim lista As New List(Of Entidad_Libro_Compra)
        Dim obj As New Negocio_Compras
        lista = obj.Mostrarlibrocompra(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Libro_Compra)
        Dim obj As New Negocio_Compras
        lista = obj.Mostrarlibrocompra(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim lista As New List(Of Entidad_Libro_Compra)
        Dim obj As New Negocio_Compras
        lista = obj.Mostrarlibrocompra(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If IsNumeric(ComboBox1.SelectedValue) Then TextBox10.Text = obtiene_nit_cliente(CInt(ComboBox1.SelectedValue))

    End Sub
    Private Function obtiene_nit_cliente(ByVal itemList As Integer) As String
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Habilitar_deshabilitar(True)
        Button4.Text = "Nuevo"
        limpiar()
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        eliminar_compra()
        cargargridview()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged, NumericUpDown2.ValueChanged, NumericUpDown3.ValueChanged, NumericUpDown4.ValueChanged, NumericUpDown5.ValueChanged, NumericUpDown6.ValueChanged
        NumericUpDown7.Value = NumericUpDown1.Value + NumericUpDown2.Value + NumericUpDown3.Value + NumericUpDown4.Value + NumericUpDown5.Value + NumericUpDown6.Value
    End Sub

    Private Sub TextBox41_TextChanged(sender As Object, e As EventArgs) Handles TextBox41.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        TextBox2.Text = ""
    End Sub
End Class