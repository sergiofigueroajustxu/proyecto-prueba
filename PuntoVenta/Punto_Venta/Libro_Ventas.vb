Imports Capa_Entidad
Imports Capa_Negocio

Imports System.IO


Public Class Libro_Ventas

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
        Dim lista As New List(Of Entidad_Libro_Venta)
        Dim obj As New Negocio_Venta
        lista = obj.Mostrarlibroventa(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, textbox5.Text)
        DataGridView1.DataSource = lista
        textbox5.Text = Year(Now())
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
        Dim lista As New List(Of Entidad_Libro_Venta)
        Dim obj As New Negocio_Venta
        lista = obj.Mostrarlibroventa(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, textbox5.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Libro_Venta)
        Dim obj As New Negocio_Venta
        lista = obj.Mostrarlibroventa(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, textbox5.Text)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim lista As New List(Of Entidad_Libro_Venta)
        Dim obj As New Negocio_Venta
        lista = obj.Mostrarlibroventa(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, textbox5.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim lista As New List(Of Entidad_Libro_Venta)
        Dim obj As New Negocio_Venta
        lista = obj.Mostrarlibroventa(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, textbox5.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        If path1.SelectedPath.ToString.Length > 0 Then
            Dim path As String
            path = path1.SelectedPath.ToString + "\libro_ventas.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Libro_Venta)
            Dim obj As New Negocio_Venta
            lista = obj.Mostrarlibroventa(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, textbox5.Text)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.EventArgs) Handles DataGridView1.SelectionChanged, DataGridView1.CellContentClick
        Dim fila As Integer
        'Dim totaltexto As String
        'totaltexto = Format(DataGridView1(11, fila).Value.ToString,"#,##0.00")
        fila = DataGridView1.CurrentCell.RowIndex
        Factura.TextBox6.Text = DataGridView1(16, fila).Value.ToString
        Factura.TextBox2.Text = DataGridView1(1, fila).Value.ToString
        Factura.TextBox5.Text = DataGridView1(2, fila).Value.ToString
        Factura.DateTimePicker1.Value = DataGridView1(3, fila).Value
        Factura.TextBox1.Text = DataGridView1(4, fila).Value.ToString
        Factura.TextBox7.Text = DataGridView1(5, fila).Value.ToString
        Factura.TextBox4.Text = DataGridView1(14, fila).Value.ToString
        Factura.Label4.Text = FormatNumber(DataGridView1(11, fila).Value.ToString, 2)
        Factura.TextBox3.Text = DataGridView1(15, fila).Value.ToString
        Factura.TextBox8.Text = DataGridView1(17, fila).Value.ToString
        Factura.DateTimePicker3.Value = DataGridView1(3, fila).Value

        'DETALLE DEL DOCUMENTO
        Factura.ListView1.Clear()
        With Factura.ListView1
            .View = View.Details
            .Columns.Add("Id", 0)
            .Columns.Add("Producto", 260)
            .Columns.Add("Precio", 70, HorizontalAlignment.Right)
            .Columns.Add("Cantidad", 70, HorizontalAlignment.Right)
            .Columns.Add("Valor", 100, HorizontalAlignment.Right)
            .Columns.Add("Codigo", 0)
        End With

        Dim Entidad_detalle As New Entidad_ventadetalle
        Dim Negocio_detalle As New Negocio_Venta_Detalle
        Dim lista As New List(Of Entidad_ventadetalle)
        Dim idfactura As String
        idfactura = DataGridView1(2, fila).Value.ToString

        lista = Negocio_detalle.mostrar_ventadetalle(idfactura)
        Dim itemfactura As String
        For i = 0 To lista.Count - 1
            itemfactura = idfactura & CStr(i)
            Dim oreg As New ListViewItem(lista.Item(i).idproducto)
            With oreg
                .SubItems.Add(lista.Item(i).nombreproducto)
                .SubItems.Add(Format(lista.Item(i).precio, "#,###,##0.00"))
                .SubItems.Add(Format(lista.Item(i).cantidad, "#,###,##0.00"))
                .SubItems.Add(Format(lista.Item(i).valor, "#,###,##0.00"))
                .SubItems.Add(lista.Item(i).codigo_barra)
                Factura.ListView1.Items.Add(oreg) 'Agregamos todo esto al listview
            End With
        Next

        Factura.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles textbox5.TextChanged
        TextBox2.Text = ""
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Mes_ValueChanged(sender As Object, e As EventArgs) Handles Mes.ValueChanged
        TextBox2.Text = Mes.Value.ToString
    End Sub
End Class