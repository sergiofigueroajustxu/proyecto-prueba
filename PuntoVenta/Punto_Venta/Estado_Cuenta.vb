Imports Capa_Entidad
Imports Capa_Negocio

Imports System.IO


Public Class EstadoCuenta


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


    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_EstadoCuenta)
        Dim obj As New Negocio_EstadoCuenta
        lista = obj.MostrarEstadoCuenta(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub limpiar()
        TextBox41.Text = ""
    End Sub

    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        Button2.Enabled = bol
        TextBox41.Enabled = bol
    End Sub



    Private Sub EstadoCuenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargargridview()
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        TextBox41.Text = Me.DataGridView1(0, fila).Value.ToString()
    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim lista As New List(Of Entidad_EstadoCuenta)
        Dim obj As New Negocio_EstadoCuenta
        lista = obj.MostrarEstadoCuenta(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_EstadoCuenta)
        Dim obj As New Negocio_EstadoCuenta
        lista = obj.MostrarEstadoCuenta(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim lista As New List(Of Entidad_EstadoCuenta)
        Dim obj As New Negocio_EstadoCuenta
        lista = obj.MostrarEstadoCuenta(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim lista As New List(Of Entidad_EstadoCuenta)
        Dim obj As New Negocio_EstadoCuenta
        lista = obj.MostrarEstadoCuenta(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()
        If path1.SelectedPath.ToString.Length > 0 Then
            Dim path As String
            path = path1.SelectedPath.ToString + "\estadocuenta.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_EstadoCuenta)
            Dim obj As New Negocio_EstadoCuenta
            lista = obj.MostrarEstadoCuenta(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
            DataGridView1.DataSource = lista
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class