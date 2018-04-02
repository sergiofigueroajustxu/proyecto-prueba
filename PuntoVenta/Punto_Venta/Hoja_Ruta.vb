Imports Capa_Entidad
Imports Capa_Negocio

Imports System.IO


Public Class Hoja_Ruta

    Private Sub Hoja_Ruta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
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
    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Hoja_Ruta)
        Dim obj As New Negocio_Ruta
        lista = obj.MostrarHojaRuta(TextBox1.Text, TextBox2.Text, TextBox3.Text)
        DataGridView1.DataSource = lista
    End Sub


    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
    End Sub




    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Hoja_Ruta)
        Dim obj As New Negocio_Ruta
        lista = obj.MostrarHojaRuta(TextBox1.Text, TextBox2.Text, TextBox3.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim lista As New List(Of Entidad_Hoja_Ruta)
        Dim obj As New Negocio_Ruta
        lista = obj.MostrarHojaRuta(TextBox1.Text, TextBox2.Text, TextBox3.Text)
        DataGridView1.DataSource = lista

    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim lista As New List(Of Entidad_Hoja_Ruta)
        Dim obj As New Negocio_Ruta
        lista = obj.MostrarHojaRuta(TextBox1.Text, TextBox2.Text, TextBox3.Text)
        DataGridView1.DataSource = lista

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        If path1.SelectedPath.ToString.Length > 0 Then
            Dim path As String
            path = path1.SelectedPath.ToString + "\hoja_rutas.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Hoja_Ruta)
            Dim obj As New Negocio_Ruta
            lista = obj.MostrarHojaRuta(TextBox1.Text, TextBox2.Text, TextBox3.Text)
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

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox1.Text = convertirfecha_ansi(DateTimePicker1, DateTimePicker1)
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


End Class