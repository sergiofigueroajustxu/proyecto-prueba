Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class Mantenimiento_Sucursal

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar_sucursal()
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

    Private Sub modificar_Sucursal()
        Dim Entidad As New Entidad_Sucursal
        Dim Negocio As New Negocio_Sucursal
        With Entidad
            .nombre = TextBox2.Text
            .direccion = TextBox3.Text
            .idsucursal = TextBox4.Text
            .telefono = TextBox5.Text
        End With

        Negocio.Modificar_sucursal(Entidad)
    End Sub
    'Nueva Sucursal'
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            limpiar()
            Habilitar_deshabilitar(False)
        ElseIf Button1.Text = "Guardar" Then
            Button1.Text = "Nuevo"
            Habilitar_deshabilitar(True)
            agregar_sucursal()
            cargargridview()
        End If
    End Sub

    Private Sub agregar_sucursal()
        Dim Entidad As New Entidad_Sucursal
        Dim Negocio As New Negocio_Sucursal
        With Entidad
            .nombre = TextBox2.Text
            .direccion = TextBox3.Text
        End With

        Negocio.Nueva_sucursal(Entidad)
    End Sub

    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Sucursal)
        Dim obj As New Negocio_Sucursal
        Dim filtro As String
        filtro = TextBox1.Text
        lista = obj.Mostrarsucursal(filtro)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub limpiar()

        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        Button2.Enabled = bol

        TextBox1.Enabled = bol
    End Sub

    

    Private Sub Mantenimiento_Sucursal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargargridview()
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        TextBox4.Text = Me.DataGridView1(0, fila).Value.ToString()
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        TextBox3.Text = Me.DataGridView1(2, fila).Value.ToString()
        TextBox5.Text = Me.DataGridView1(3, fila).Value.ToString()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        eliminar_sucursal()
        cargargridview()
    End Sub
    Private Sub eliminar_sucursal()
        Dim Entidad As New Entidad_Sucursal
        Dim Negocio As New Negocio_Sucursal
        With Entidad
            .nombre = TextBox2.Text
            .direccion = TextBox3.Text
            .idsucursal = TextBox4.Text
        End With

        Negocio.Eliminar_sucursal(Entidad)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Sucursal)
        Dim obj As New Negocio_Sucursal
        lista = obj.Mostrarsucursal(Me.TextBox1.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        Dim path As String
        If path1.SelectedPath.ToString.Length > 0 Then
            path = path1.SelectedPath.ToString + "\sucursal.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Sucursal)
            Dim obj As New Negocio_Sucursal

            lista = obj.Mostrarsucursal(TextBox1.Text)
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