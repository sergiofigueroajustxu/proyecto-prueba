Imports Capa_Entidad
Imports Capa_Negocio

Imports System.IO


Public Class Libro_Mayor

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
        Dim lista As New List(Of Entidad_Libro_Mayor)
        Dim obj As New Negocio_Partida
        lista = obj.Mostrarlibromayor(TExtBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        DataGridView1.DataSource = lista
        TextBox6.Text = Year(Now())

    End Sub


    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
    End Sub



    Private Sub Libro_Ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargargridview()
    End Sub


    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Dim lista As New List(Of Entidad_Libro_Mayor)
        Dim obj As New Negocio_Partida
        lista = obj.Mostrarlibromayor(TExtBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TExtBox1.TextChanged
        Dim lista As New List(Of Entidad_Libro_Mayor)
        Dim obj As New Negocio_Partida
        lista = obj.Mostrarlibromayor(TExtBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim lista As New List(Of Entidad_Libro_Mayor)
        Dim obj As New Negocio_Partida
        lista = obj.Mostrarlibromayor(TExtBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim lista As New List(Of Entidad_Libro_Mayor)
        Dim obj As New Negocio_Partida
        lista = obj.Mostrarlibromayor(TExtBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        Dim path As String
        If path1.SelectedPath.ToString.Length > 0 Then
            path = path1.SelectedPath.ToString + "\libro_mayor.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Libro_Mayor)
            Dim obj As New Negocio_Partida
            lista = obj.Mostrarlibromayor(TExtBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged, DataGridView1.CellContentClick
        Dim fila As Integer
        'Dim totaltexto As String
        'totaltexto = Format(DataGridView1(1, fila).Value.ToString,"#,##0.00")
        fila = DataGridView1.CurrentCell.RowIndex
        'Factura.TextBox6.Text = DataGridView1(16, fila).Value.ToString

        'DETALLE DEL DOCUMENTO
        Partida.ListView1.Clear()
        With Partida.ListView1
            .View = View.Details
            .Columns.Add("Fecha", 50)
            .Columns.Add("Partida", 50)
            .Columns.Add("Tipo", 50)
            .Columns.Add("Concepto", 200)
            .Columns.Add("Cuenta", 50)
            .Columns.Add("Nombre", 100)
            .Columns.Add("C.C.", 50, HorizontalAlignment.Right)
            .Columns.Add("Debe", 70, HorizontalAlignment.Right)
            .Columns.Add("Haber", 70, HorizontalAlignment.Right)
        End With

        Dim Entidad_detalle As New Entidad_Libro_Diario
        Dim Negocio_detalle As New Negocio_Partida
        Dim lista As New List(Of Entidad_Libro_Diario)

        lista = Negocio_detalle.Mostrarlibrodiario("", "", "", "", "", "")
        For i = 0 To lista.Count - 1
            Dim oreg As New ListViewItem(i.ToString)
            With oreg
                .SubItems.Add(lista.Item(i).Fecha)
                .SubItems.Add(lista.Item(i).tipo)
                .SubItems.Add(lista.Item(i).Partida)
                .SubItems.Add(lista.Item(i).concepto)
                .SubItems.Add(Format(lista.Item(i).idsucursal, "#,###,##0.00"))
                .SubItems.Add(Format(lista.Item(i).debe, "#,###,##0.00"))
                .SubItems.Add(Format(lista.Item(i).haber, "#,###,##0.00"))
                'partida.ListView1.Items.Add(oreg) 'Agregamos todo esto al listview
            End With
        Next

        'Partida.Show()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        Dim lista As New List(Of Entidad_Libro_Diario)
        Dim obj As New Negocio_Partida
        lista = obj.Mostrarlibrodiario(TExtBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        TExtBox1.Text = ""
    End Sub

    Private Sub TextBox6_ValueChanged(sender As Object, e As EventArgs) Handles TextBox6.ValueChanged

    End Sub
End Class