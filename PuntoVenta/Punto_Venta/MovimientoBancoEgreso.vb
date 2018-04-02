Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO
Public Class MovimientoBancoEgreso
    Dim abre As New OpenFileDialog
    Private Sub Mantenimiento_MovimientoBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridView1.AutoGenerateColumns = False
        personalizargridview(Me.DataGridView1)
        personalizargridview(Me.DataGridView2)
        personalizargridview(Me.DataGridView3)
        cargarcombo()
        cargarnomenclatura()
        cargarcombosucursal()
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
            .DefaultCellStyle.SelectionBackColor = Color.Gray
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .AllowUserToResizeRows = False
        End With
    End Sub

    'Para Cargar el Gridview'
    Private Sub cargargridview()
        Dim lista As New List(Of Entidad_MovimientoBanco)
        Dim obj As New Negocio_MovimientoBanco
        lista = obj.Mostrarmovimientobanco(ComboBox1.SelectedIndex, TextBox1.Text, "E")
        DataGridView1.DataSource = lista
    End Sub

    'Para Cargar Al Combobox'
    Private Sub cargarcombo()
        Dim lista As New List(Of Entidad_Bancos)
        Dim obj As New Negocio_Bancos
        lista = obj.Mostrarbancos("")
        ComboBox1.DataSource = lista
        ComboBox1.DisplayMember = "descripcion"
        ComboBox1.ValueMember = "idbanco"
        ComboBox1.SelectedIndex = -1
    End Sub
    Private Sub cargarcombosucursal()
        Dim lista As New List(Of Entidad_Sucursal)
        Dim obj As New Negocio_Sucursal
        lista = obj.Mostrarsucursal("")
        ComboBox2.DataSource = lista
        ComboBox2.DisplayMember = "nombre"
        ComboBox2.ValueMember = "idsucursal"
        ComboBox2.SelectedIndex = -1
    End Sub
    Private Sub cargarnomenclatura()
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Negocio_Nomenclatura
        lista = obj.MostrarNomenclaturaEgresos("")
        ComboBox3.DataSource = lista
        ComboBox3.DisplayMember = "nombre"
        ComboBox3.ValueMember = "cuenta"
        ComboBox3.SelectedIndex = -1
    End Sub
    'Para Buscar Correlativo'
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim lista As New List(Of Entidad_MovimientoBanco)
        Dim obj As New Negocio_MovimientoBanco
        lista = obj.Mostrarmovimientobanco(ComboBox1.SelectedIndex, TextBox1.Text, "E")
        DataGridView1.DataSource = lista
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        Dim fila As Integer
        fila = DataGridView1.CurrentCell.RowIndex
        TextBox3.Text = Me.DataGridView1(0, fila).Value.ToString()
        buscarencombo(ComboBox1, Me.DataGridView1(2, fila).Value.ToString())
        TextBox2.Text = Me.DataGridView1(1, fila).Value.ToString()
        NumericUpDown4.Value = Me.DataGridView1(4, fila).Value.ToString()
        NumericUpDown3.Value = Me.DataGridView1(5, fila).Value.ToString()
        buscarencombo(ComboBox3, Me.DataGridView1(7, fila).Value.ToString())
        buscarencombo(ComboBox2, Me.DataGridView1(8, fila).Value.ToString())
        cargargridviewcorrelativo(TextBox3.Text)

    End Sub

    Private Sub cargargridviewcorrelativo(ByVal correlativo As String)
        Dim lista As New List(Of Entidad_Cobros)
        Dim obj As New Negocio_Cobros
        lista = obj.mostrarcobros(correlativo)
        DataGridView2.DataSource = lista

        Dim listapago As New List(Of Entidad_Pagos)
        Dim objpago As New Negocio_Pagos
        listapago = objpago.MostrarPagos(correlativo)
        DataGridView3.DataSource = listapago

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "Nuevo" Then
            Button1.Text = "Guardar"
            Button4.Text = "Cancelar"
            habilitar_deshabitar(False)
            limpiarcajas()

        ElseIf Button1.Text = "Guardar" Then
            If ComboBox1.SelectedIndex < 0 Then
                MessageBox.Show("Debe de seleccionar un Banco")
                ComboBox1.Focus()
                Exit Sub
            End If
            If TextBox3.Text = "" Then
                MessageBox.Show("Debe asignar un codigo")
                TextBox3.Focus()
                Exit Sub
            End If
            Button4.Text = "Anular"
            Button1.Text = "Nuevo"
            nuevo_movimientobanco()
            habilitar_deshabitar(True)
            cargargridview()
        End If
    End Sub

    'Metodo para agregar un nuevo producto'
    Private Sub nuevo_movimientobanco()
        'Agregar producto
        Dim Entidad As New Entidad_MovimientoBanco
        Dim Negocio As New Negocio_MovimientoBanco

        With Entidad
            .correlativo = TextBox3.Text
            .idbanco = ComboBox1.SelectedValue
            .fecha = DateTimePicker1.Value.ToString
            .nombre = TextBox2.Text
            .valor_deposito = NumericUpDown4.Value
            .valor_retiro = NumericUpDown3.Value
            .cuenta_contable = ComboBox3.SelectedValue
            .agencia = ComboBox2.SelectedValue
        End With
        'llamamos a agregar producto'
        Negocio.Nueva_MovimientoBanco(Entidad)
    End Sub

    Private Sub habilitar_deshabitar(ByVal bol As Boolean)
        Button2.Enabled = bol
        DataGridView1.Enabled = bol
        Button3.Enabled = bol
        TextBox1.Enabled = bol


    End Sub



    Private Sub limpiarcajas()
        'Button4.Text = "Anular"
        TextBox2.Text = ""
        ComboBox1.Text = ""
        TextBox1.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        NumericUpDown3.Value = 0
        NumericUpDown4.Value = 0
        TextBox3.Text = ""

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

    Private Sub modificar()
        Dim Entidad As New Entidad_MovimientoBanco
        Dim Negocio As New Negocio_MovimientoBanco

        With Entidad
            .correlativo = TextBox3.Text
            .idbanco = ComboBox1.SelectedValue
            .nombre = TextBox2.Text
            .valor_deposito = NumericUpDown4.Value
            .valor_retiro = NumericUpDown3.Value
            .cuenta_contable = ComboBox3.SelectedValue
            .agencia = ComboBox2.SelectedValue
        End With
        'llamamos a agregar producto'
        Negocio.Modificar_MovimientoBanco(Entidad)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.SelectedIndex < 0 Then
            MessageBox.Show("Debe de seleccionar un banco")
            ComboBox1.Focus()
            Exit Sub
        End If
        If TextBox3.Text = "" Then
            MessageBox.Show("Debe asignar un correlativo")
            TextBox3.Focus()
            Exit Sub
        End If

        modificar()
        cargargridview()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim Entidad As New Entidad_MovimientoBanco
        Dim Negocio As New Negocio_MovimientoBanco

        With Entidad
            .correlativo = TextBox3.Text
            .idbanco = ComboBox1.SelectedValue
            .fecha = DateTimePicker1.Value.ToString
            .nombre = TextBox2.Text
            .valor_deposito = NumericUpDown4.Value
            .valor_retiro = NumericUpDown3.Value
            .cuenta_contable = ComboBox3.SelectedValue
            .agencia = ComboBox2.SelectedValue
        End With

        Negocio.Agrega_Partida_MovimientoBanco(Entidad)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If Button4.Text = "Cancelar" Then
            habilitar_deshabitar(True)
            limpiarcajas()
            Button4.Text = "Anular"
        Else

            Dim Entidad As New Entidad_MovimientoBanco
            Dim Negocio As New Negocio_MovimientoBanco

            With Entidad
                .correlativo = TextBox3.Text
                .idbanco = ComboBox1.SelectedValue
                .fecha = DateTimePicker1.Value.ToString
                .nombre = TextBox2.Text
                .valor_deposito = NumericUpDown4.Value
                .valor_retiro = NumericUpDown3.Value
                .cuenta_contable = ComboBox3.SelectedValue
                .agencia = ComboBox2.SelectedValue
            End With

            Negocio.Anula_Partida_MovimientoBanco(Entidad)
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub
End Class