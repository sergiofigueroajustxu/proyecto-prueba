Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class Mantenimiento_Nomenclatura

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar_Nomenclatura()
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

    Private Sub modificar_Nomenclatura()
        Dim Entidad As New Entidad_Nomenclatura
        Dim Negocio As New Negocio_Nomenclatura
        With Entidad
            .cuenta = TextBox1.Text
            .nombre = TextBox2.Text
            .en_polizas = CInt(TextBox4.Text)
            .padre = TextBox3.Text
            .flujo_efectivo = TextBox5.Text
            .es_gasto_bien = CInt(TextBox7.Text)
            .es_gasto_servicio = CInt(TextBox8.Text)

        End With

        Negocio.Modificar_Nomenclatura(Entidad)
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
            agregar_nomenclatura()
            cargargridview()
        End If
    End Sub

    Private Sub agregar_nomenclatura()
        Dim Entidad As New Entidad_Nomenclatura
        Dim Negocio As New Negocio_Nomenclatura
        With Entidad
            .cuenta = TextBox1.Text
            '.nivel = textbox2.text
            .nombre = TextBox2.Text
            .en_polizas = CInt(TextBox4.Text)
            .padre = TextBox3.Text
            .flujo_efectivo = TextBox5.Text
            .es_gasto_bien = CInt(TextBox7.Text)
            .es_gasto_servicio = CInt(TextBox8.Text)

        End With

        Negocio.Nueva_Nomenclatura(Entidad)
    End Sub

    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Negocio_Nomenclatura
        Dim filtro As String
        filtro = TextBox11.Text
        lista = obj.Mostrarnomenclatura(filtro)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub limpiar()
        TextBox8.Text = "0"
        TextBox7.Text = "0"

        TextBox4.Text = "0"
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox1.Text = ""
        TextBox11.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        Button2.Enabled = bol
        Button3.Enabled = bol
        TextBox11.Enabled = bol
    End Sub



    Private Sub Mantenimiento_Nomenclatura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))

        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargargridview()
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        TextBox1.Text = Me.DataGridView1(0, fila).Value.ToString()
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        TextBox3.Text = Me.DataGridView1(2, fila).Value.ToString()
        TextBox4.Text = Me.DataGridView1(3, fila).Value.ToString()
        TextBox5.Text = Me.DataGridView1(4, fila).Value.ToString()
        TextBox7.Text = Me.DataGridView1(5, fila).Value.ToString()
        TextBox8.Text = Me.DataGridView1(6, fila).Value.ToString()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        eliminar_Nomenclatura()
        cargargridview()
    End Sub
    Private Sub eliminar_Nomenclatura()
        Dim Entidad As New Entidad_Nomenclatura
        Dim Negocio As New Negocio_Nomenclatura
        With Entidad
            .cuenta = TextBox1.Text
            .nivel = TextBox2.Text
            .nombre = TextBox3.Text
        End With

        Negocio.Eliminar_Nomenclatura(Entidad)

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Negocio_Nomenclatura
        lista = obj.Mostrarnomenclatura(Me.TextBox11.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then TextBox4.Text = 1 Else TextBox4.Text = 0
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If TextBox4.Text = "1" Then CheckBox1.Checked = True Else CheckBox1.Checked = False
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text = "1" Then CheckBox2.Checked = True Else CheckBox2.Checked = False
    End Sub
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text = "1" Then CheckBox3.Checked = True Else CheckBox3.Checked = False
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim lista2 As New List(Of Entidad_Nomenclatura)
        Dim obj2 As New Negocio_Nomenclatura
        Dim filtro As String
        filtro = TextBox3.Text
        lista2 = obj2.MostrarNomenclaturaCuenta(filtro)
        If lista2.Count > 0 Then
            TextBox6.Text = lista2.Item(0).nombre
        Else
            TextBox6.Text = ""
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then TextBox7.Text = 1 Else TextBox7.Text = 0
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then TextBox8.Text = 1 Else TextBox8.Text = 0
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        Dim path As String
        If path1.SelectedPath.ToString.Length > 0 Then
            path = path1.SelectedPath.ToString + "\nomenclatura.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Nomenclatura)
            Dim obj As New Negocio_Nomenclatura

            lista = obj.MostrarNomenclatura(TextBox1.Text)
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