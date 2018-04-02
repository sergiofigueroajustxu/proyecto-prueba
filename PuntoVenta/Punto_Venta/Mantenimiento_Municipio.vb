Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class Mantenimiento_Municipio

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar_municipio()
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

    Private Sub modificar_municipio()
        Dim Entidad As New Entidad_Municipio
        Dim Negocio As New Negocio_Municipio
        With Entidad
            .codigo_municipio = TextBox2.Text
            .nombre_municipio = TextBox3.Text
            .idmunicipio = Label3.Text
            .padre_municipio = ComboBox1.SelectedValue
        End With

        Negocio.Modificar_Municipio(Entidad)
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
            agregar_municipio()
            cargargridview()
        End If
    End Sub

    Private Sub agregar_municipio()
        Dim Entidad As New Entidad_Municipio
        Dim Negocio As New Negocio_Municipio
        With Entidad
            .codigo_municipio = TextBox2.Text
            .nombre_municipio = TextBox3.Text
            .padre_municipio = ComboBox1.SelectedValue
        End With

        Negocio.Nueva_Municipio(Entidad)
    End Sub

    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Municipio)
        Dim obj As New Negocio_Municipio
        Dim filtro As String
        filtro = TextBox1.Text
        lista = obj.Mostrarmunicipio(filtro)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub limpiar()
        Label3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.SelectedValue = -1
    End Sub

    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        Button2.Enabled = bol
        Button3.Enabled = bol
        TextBox1.Enabled = bol
    End Sub



    Private Sub Mantenimiento_Municipio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarcombo()
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargargridview()
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        If fila >= 0 Then
            Label3.Text = Me.DataGridView1(0, fila).Value.ToString
            TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString
            TextBox3.Text = Me.DataGridView1(2, fila).Value.ToString

            ComboBox1.SelectedValue = DataGridView1(3, fila).Value
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        eliminar_municipio()
        cargargridview()
    End Sub
    Private Sub eliminar_municipio()
        Dim Entidad As New Entidad_Municipio
        Dim Negocio As New Negocio_Municipio
        With Entidad
            .codigo_municipio = TextBox2.Text
            .nombre_municipio = TextBox3.Text
            .idmunicipio = Label3.Text
            .padre_municipio = ComboBox1.SelectedValue
        End With

        Negocio.Eliminar_Municipio(Entidad)

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Municipio)
        Dim obj As New Negocio_Municipio
        lista = obj.Mostrarmunicipio(Me.TextBox1.Text)
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
            path = path1.SelectedPath.ToString + "\municipio.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Municipio)
            Dim obj As New Negocio_Municipio

            lista = obj.Mostrarmunicipio(TextBox1.Text)
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
    Private Sub cargarcombo()
        Dim lista As New List(Of Entidad_Departamento)
        Dim obj As New Negocio_Departamento
        lista = obj.Mostrardepartamento("")
        ComboBox1.DataSource = lista
        ComboBox1.DisplayMember = "nombre_departamento"
        ComboBox1.ValueMember = "codigo_departamento"
        ComboBox1.SelectedIndex = -1


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class