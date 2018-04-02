Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class Mantenimiento_Bancos

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        modificar_bancos()

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
    Private Sub cargarnomenclatura()
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Negocio_Nomenclatura
        lista = obj.MostrarNomenclatura("")
        ComboBox3.DataSource = lista
        ComboBox3.DisplayMember = "nombre"
        ComboBox3.ValueMember = "cuenta"
        ComboBox3.SelectedIndex = -1
    End Sub
    Private Sub modificar_bancos()
        Dim Entidad As New Entidad_Bancos
        Dim Negocio As New Negocio_Bancos
        With Entidad
            .nombre = TextBox2.Text
            .descripcion = TextBox3.Text
            .idbanco = Label3.Text
            .cuenta_contable = ComboBox3.SelectedValue
        End With

        Negocio.Modificar_bancos(Entidad)
    End Sub
    'Nuevo Banco'
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            limpiar()
            Habilitar_deshabilitar(False)
        ElseIf Button1.Text = "Guardar" Then
            Button1.Text = "Nuevo"
            Habilitar_deshabilitar(True)
            agregar_bancos()
            cargargridview()
        End If
    End Sub

    Private Sub agregar_bancos()
        Dim Entidad As New Entidad_Bancos
        Dim Negocio As New Negocio_Bancos
        With Entidad
            .nombre = TextBox2.Text
            .descripcion = TextBox3.Text
            .cuenta_contable = ComboBox3.SelectedValue
        End With

        Negocio.Nueva_Bancos(Entidad)
    End Sub

    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_Bancos)
        Dim obj As New Negocio_Bancos
        Dim filtro As String
        filtro = TextBox1.Text
        lista = obj.Mostrarbancos(filtro)
        DataGridView1.DataSource = lista
    End Sub

    Private Sub limpiar()
        Label3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        NumericUpDown1.Value = 0.0
        NumericUpDown2.Value = 0.0
        ComboBox3.SelectedIndex = -1
    End Sub

    Private Sub Habilitar_deshabilitar(ByVal bol As Boolean)
        DataGridView1.Enabled = bol
        Button2.Enabled = bol
        Button3.Enabled = bol
        TextBox1.Enabled = bol
    End Sub

    

    Private Sub Mantenimiento_Bancos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Me.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(214, Byte), Integer))
        DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        cargarnomenclatura()
        cargargridview()
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        Label3.Text = Me.DataGridView1(0, fila).Value.ToString()
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        TextBox3.Text = Me.DataGridView1(2, fila).Value.ToString()
        ComboBox3.SelectedValue = Me.DataGridView1(3, fila).Value
        'buscarencombo(ComboBox3, Me.DataGridView1(3, fila).Value.ToString())
    End Sub
    Private Sub buscarencombo(ByVal combo As ComboBox, ByVal cad As String)
        Dim i As Integer
        Dim bol = False
        While i <= combo.Items.Count - 1 And bol = False
            combo.SelectedIndex = i
            If combo.SelectedValue.ToString = cad Then
                combo.SelectedIndex = i
                bol = True
            End If
            i += 1
        End While


    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        eliminar_bancos()
        cargargridview()
    End Sub
    Private Sub eliminar_bancos()
        Dim Entidad As New Entidad_Bancos
        Dim Negocio As New Negocio_Bancos
        With Entidad
            .nombre = TextBox2.Text
            .descripcion = TextBox3.Text
            .idbanco = Label3.Text
        End With

        Negocio.Eliminar_bancos(Entidad)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_Bancos)
        Dim obj As New Negocio_Bancos
        lista = obj.Mostrarbancos(Me.TextBox1.Text)
        DataGridView1.DataSource = lista

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim path1 As FolderBrowserDialog
        path1 = New FolderBrowserDialog
        path1.ShowDialog()

        If path1.SelectedPath.ToString.Length > 0 Then
            Dim path As String
            path = path1.SelectedPath.ToString + "\bancos.XML"

            'My.Computer.FileSystem.WriteAllText(path, xml2, True)


            Dim lista As New List(Of Entidad_Bancos)

            Dim obj As New Negocio_Bancos
            lista = obj.Mostrarbancos(TextBox1.Text)

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

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class