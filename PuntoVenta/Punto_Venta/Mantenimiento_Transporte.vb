Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class Mantenimiento_Transporte

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar_transporte()
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

    Private Sub modificar_transporte()
        Dim Entidad As New Entidad_Transporte
        Dim Negocio As New Negocio_Transporte
        With Entidad
            .fecha_inicio = fecha_inicio.Text
            .idtransporte = idtransporte.Text
            .km_vehiculo = km_vehiculo.Value
            .numero_placa = numero_placa.Text
            .nombre = nombre.Text
            .codigo_empleado = codigo_empleado.SelectedValue
            .cuenta_contable = cuenta_contable.SelectedValue
            .direccion = direccion.Text
            .telefono = telefono.Text
            .valor_km = valor_km.Value
        End With

        Negocio.Modificar_Transporte(Entidad)
    End Sub
    'Nueva Categoria'
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            limpiar()
            Habilitar_deshabilitar(False)
        ElseIf Button1.Text = "Guardar" Then
            Button1.Text = "Nuevo"
            Habilitar_deshabilitar(True)
            agregar_transporte()
            cargargridview()
        End If
    End Sub

    Private Sub agregar_transporte()
        Dim Entidad As New Entidad_Transporte
        Dim Negocio As New Negocio_Transporte
        With Entidad
            .fecha_inicio = fecha_inicio.Text
            .km_vehiculo = km_vehiculo.Value
            .numero_placa = numero_placa.Text
            .nombre = nombre.Text
            .codigo_empleado = codigo_empleado.SelectedValue
            .cuenta_contable = cuenta_contable.SelectedValue
            .direccion = direccion.Text
            .telefono = telefono.Text
            .valor_km = valor_km.Value
        End With

        Negocio.Nueva_Transporte(Entidad)
    End Sub

    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Transporte)
        Dim obj As New Negocio_Transporte
        Dim filtro As String
        filtro = TextBox1.Text
        lista = obj.Mostrartransporte(filtro)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub limpiar()
        idtransporte.Text = ""
        numero_placa.Text = ""
        nombre.Text = ""
        fecha_inicio.Text = ""
        idtransporte.Text = ""
        km_vehiculo.Value = 0
        numero_placa.Text = ""
        nombre.Text = ""
        codigo_empleado.Text = ""
        cuenta_contable.Text = ""
        direccion.Text = ""
        telefono.Text = ""
        valor_km.Value = 0

    End Sub

    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        Button2.Enabled = bol
        Button3.Enabled = bol
        TextBox1.Enabled = bol
    End Sub



    Private Sub Mantenimiento_Transporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarnomenclatura()
        cargarempleados()
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargargridview()
    End Sub
    Private Sub cargarnomenclatura()
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Negocio_Nomenclatura
        lista = obj.MostrarNomenclatura("")
        cuenta_contable.DataSource = lista
        cuenta_contable.DisplayMember = "nombre"
        cuenta_contable.ValueMember = "cuenta"
        cuenta_contable.SelectedIndex = -1
    End Sub
    Private Sub cargarempleados()
        Dim lista As New List(Of Entidad_Empleado)
        Dim obj As New Negocio_Empleado
        lista = obj.MostrarEmpleado("")
        codigo_empleado.DataSource = lista
        codigo_empleado.DisplayMember = "nombres_apellidos"
        codigo_empleado.ValueMember = "idempleado"
        codigo_empleado.SelectedIndex = -1
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        If fila >= 0 Then
            idtransporte.Text = Me.DataGridView1(0, fila).Value.ToString()
            numero_placa.Text = Me.DataGridView1(1, fila).Value.ToString()
            nombre.Text = Me.DataGridView1(2, fila).Value.ToString()
            telefono.Text = Me.DataGridView1(3, fila).Value.ToString()
            direccion.Text = Me.DataGridView1(4, fila).Value.ToString()
            km_vehiculo.Text = Me.DataGridView1(5, fila).Value.ToString()
            valor_km.Text = Me.DataGridView1(6, fila).Value.ToString()
            fecha_inicio.Text = Me.DataGridView1(7, fila).Value.ToString()
            codigo_empleado.SelectedValue = Me.DataGridView1(8, fila).Value
            cuenta_contable.SelectedValue = Me.DataGridView1(9, fila).Value
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        eliminar_transporte()
        cargargridview()
    End Sub
    Private Sub eliminar_transporte()
        Dim Entidad As New Entidad_Transporte
        Dim Negocio As New Negocio_Transporte
        With Entidad
            .idtransporte = idtransporte.Text
        End With

        Negocio.Eliminar_Transporte(Entidad)

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Transporte)
        Dim obj As New Negocio_Transporte
        lista = obj.Mostrartransporte(Me.TextBox1.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        Dim path As String
        If path1.SelectedPath.ToString.Length > 0 Then
            path = path1.SelectedPath.ToString + "\transporte.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Transporte)
            Dim obj As New Negocio_Transporte

            lista = obj.Mostrartransporte(TextBox1.Text)
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

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class