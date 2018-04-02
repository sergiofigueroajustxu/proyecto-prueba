Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class Mantenimiento_Proveedores


    Private Sub Mantenimiento_Proveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.ForeColor = Color.Black
        personalizargridview(Me.DataGridView1)
        DataGridView1.AutoGenerateColumns = False
        cargarcomboruta()
        cargarcombomunicipio()
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
            .DefaultCellStyle.SelectionBackColor = Color.LightGray
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .AllowUserToResizeRows = False
        End With
    End Sub

    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Proveedor)
        Dim obj As New Negocio_Proveedor
        lista = obj.Mostrartodosproveedor
        DataGridView1.DataSource = lista
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        Label3.Text = Me.DataGridView1(0, fila).Value.ToString()
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        TextBox3.Text = Me.DataGridView1(3, fila).Value.ToString()
        TextBox4.Text = Me.DataGridView1(4, fila).Value.ToString()
        TextBox5.Text = Me.DataGridView1(5, fila).Value.ToString()
        TextBox6.Text = Me.DataGridView1(6, fila).Value.ToString()
        TextBox7.Text = Me.DataGridView1(2, fila).Value.ToString()
        TextBox8.Text = Me.DataGridView1(7, fila).Value.ToString()
        TextBox9.Text = Me.DataGridView1(8, fila).Value.ToString()
        NumericUpDown10.Value = Me.DataGridView1(9, fila).Value.ToString()
        NumericUpDown11.Value = Me.DataGridView1(10, fila).Value.ToString()
        NumericUpDown12.Value = Me.DataGridView1(11, fila).Value.ToString()
        NumericUpDown13.Value = Me.DataGridView1(12, fila).Value.ToString()
        CheckBox1.Checked = IIf(Me.DataGridView1(13, fila).Value = "S", True, False)
        ComboBox1.SelectedValue = Me.DataGridView1(14, fila).Value
        If Not IsDBNull(Me.DataGridView1(15, fila).Value) And Not IsNothing(Me.DataGridView1(15, fila).Value) Then
            ComboBox2.SelectedValue = Me.DataGridView1(15, fila).Value
        Else
            ComboBox2.SelectedItem = -1
        End If
    End Sub

    Private Sub nuevo_proveedor()
        'Agregar proveedor
        Dim Entidad As New Entidad_Proveedor
        Dim Negocio As New Negocio_Proveedor

        With Entidad
            .nombre = TextBox2.Text
            .Ruc = TextBox3.Text
            .representante = TextBox4.Text
            .direccion = TextBox5.Text
            .telefono = TextBox6.Text
            .apellidos = TextBox7.Text
            .celular = TextBox9.Text
            .correo = TextBox8.Text
            .limite_proveedor = NumericUpDown10.Value
            .limite_dias_proveedor = NumericUpDown11.Value
            .pago_pendiente = NumericUpDown12.Value
            .cobro_pendiente = NumericUpDown13.Value
            .es_proveedor = IIf(CheckBox1.Checked, "S", "N")
            .idruta = ComboBox1.SelectedValue
            .codigo_municipio = ComboBox2.SelectedValue
        End With
        'llamamos a agregar Proveedor'
        Negocio.Nuevo_Proveedor(Entidad)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            limpiar()
            deshabilitar()
        ElseIf Button1.Text = "Guardar" Then
            If IsNothing(ComboBox1.SelectedValue) Then
                MsgBox("Falta asignar Ruta")
                Return
            End If
            If IsNothing(ComboBox2.SelectedValue) Then
                MsgBox("Falta asignar Municipio")
                Return
            End If

            Button1.Text = "Nuevo"
            habilitar()
            nuevo_proveedor()
            cargargridview()
        End If

    End Sub

    Private Sub limpiar()
        Label3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox9.Text = ""
        TextBox8.Text = ""
        CheckBox1.Checked = False
        NumericUpDown13.Value = 0
        NumericUpDown10.Value = 0
        NumericUpDown11.Value = 0
        NumericUpDown12.Value = 0
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub deshabilitar()
        Button2.Enabled = False
        Button3.Enabled = False
        DataGridView1.Enabled = False
        TextBox1.Enabled = False
    End Sub

    Private Sub habilitar()
        Button2.Enabled = True
        Button3.Enabled = True
        DataGridView1.Enabled = True
        TextBox1.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If IsNothing(ComboBox1.SelectedValue) Or IsNothing(ComboBox2.SelectedValue) Then
            MsgBox("Falta seleccionar ruta o municipio.")
        Else
            modificar_proveedor()
            cargargridview()
        End If
    End Sub

    Private Sub modificar_proveedor()
        'modificar proveedor
        Dim Entidad As New Entidad_Proveedor
        Dim Negocio As New Negocio_Proveedor

        With Entidad
            .idproveedor = Label3.Text
            .nombre = TextBox2.Text
            .Ruc = TextBox3.Text
            .representante = TextBox4.Text
            .direccion = TextBox5.Text
            .telefono = TextBox6.Text
            .apellidos = TextBox7.Text
            .correo = TextBox8.Text
            .celular = TextBox9.Text
            .limite_proveedor = NumericUpDown10.Value
            .limite_dias_proveedor = NumericUpDown11.Value
            .pago_pendiente = NumericUpDown13.Value
            .cobro_pendiente = NumericUpDown12.Value
            .es_proveedor = IIf(CheckBox1.Checked, "S", "N")
            .idruta = ComboBox1.SelectedValue
            .codigo_municipio = ComboBox2.SelectedValue
        End With
        'llamamos a agregar Proveedor'
        Negocio.Modificar_Proveedor(Entidad)
    End Sub
    Private Sub Eliminar_proveedor()
        'eliminar proveedor
        Dim Entidad As New Entidad_Proveedor
        Dim Negocio As New Negocio_Proveedor

        With Entidad
            .idproveedor = Label3.Text
            .nombre = TextBox2.Text
            .Ruc = TextBox3.Text
            .representante = TextBox4.Text
            .direccion = TextBox5.Text
            .telefono = TextBox6.Text
            .apellidos = TextBox7.Text
            .correo = TextBox8.Text
            .celular = TextBox9.Text
            .limite_proveedor = NumericUpDown10.Value
            .limite_dias_proveedor = NumericUpDown11.Value
            .pago_pendiente = NumericUpDown13.Value
            .cobro_pendiente = NumericUpDown12.Value
            .es_proveedor = IIf(CheckBox1.Checked, "S", "N")
            .idruta = ComboBox1.SelectedValue
            .codigo_municipio = ComboBox2.SelectedValue
        End With
        'llamamos a eliminar Proveedor'
        Negocio.Eliminar_Proveedor(Entidad)
    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Proveedor)
        Dim obj As New Negocio_Proveedor
        lista = obj.MostrarProveedor(TextBox1.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        eliminar_proveedor()
        cargargridview()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cargarcomboruta()
        Dim lista As New List(Of Entidad_Ruta)
        Dim obj As New Negocio_Ruta
        lista = obj.Mostrarruta("")
        ComboBox1.DataSource = lista
        ComboBox1.DisplayMember = "nombre"
        ComboBox1.ValueMember = "idruta"
        ComboBox1.SelectedIndex = -1
    End Sub
    Private Sub cargarcombomunicipio()
        Dim lista As New List(Of Entidad_Municipio)
        Dim obj As New Negocio_Municipio
        lista = obj.Mostrarmunicipio("")
        ComboBox2.DataSource = lista
        ComboBox2.DisplayMember = "nombre_municipio"
        ComboBox2.ValueMember = "codigo_municipio"
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        Dim path As String
        If path1.SelectedPath.ToString.Length > 0 Then
            path = path1.SelectedPath.ToString + "\proveedor.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Proveedor)
            Dim obj As New Negocio_Proveedor

            lista = obj.MostrarProveedor(TextBox1.Text)
            'DataGridView1.DataSource = lista
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

