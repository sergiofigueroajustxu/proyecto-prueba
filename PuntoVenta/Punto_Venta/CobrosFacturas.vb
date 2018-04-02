﻿Imports Capa_Entidad
Imports Capa_Negocio
Public Class CobrosFacturas

    Private Sub Cobros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarcombo(ComboBox1)
        cargarcombo3(ComboBox3)
        TextBox1.Text = Mid(Me.fecha_formatoansi, 1, 10)
        DataGridView1.AutoGenerateColumns = False
        DataGridView2.AutoGenerateColumns = False
    End Sub

    Private Sub cargarcombo(ByVal combo As ComboBox)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Negocio_Cliente
        lista = obj.Mostrarcliente
        combo.DataSource = lista
        combo.DisplayMember = "nombre"
        combo.ValueMember = "idcliente"
        combo.SelectedIndex = -1

    End Sub

    'Para Cargar el Gridview'
    Public Sub cargargridview(ByVal id As Integer)
        Dim lista As New List(Of Entidad_ventadetalle)
        Dim obj As New Negocio_Venta_Detalle
        lista = obj.listardeuda(id)
        DataGridView1.DataSource = lista
        Dim lista2 As New List(Of Entidad_Venta)
        Dim obj2 As New Negocio_Venta
        lista2 = obj2.listardeuda(id)
        DataGridView2.DataSource = lista2
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.SelectedIndex >= 0 Then
            Label3.Text = ComboBox1.SelectedValue.ToString

            If IsNumeric(ComboBox1.SelectedValue.ToString) Then
                cargargridview(CInt(ComboBox1.SelectedValue.ToString))
                Label5.Text = Format(sumarimporte(DataGridView1), "##,##0.00")
                NumericUpDown1.Maximum = sumarimporte(DataGridView1)
            End If

        Else
            Label3.Text = ""
        End If

    End Sub

    Private Sub cargarcombo3(ByVal combo As ComboBox)
        Dim lista As New List(Of Entidad_Bancos)
        Dim obj As New Negocio_Bancos
        lista = obj.Mostrarbancos("")
        combo.DataSource = lista
        combo.DisplayMember = "nombre"
        combo.ValueMember = "idbanco"
        combo.SelectedIndex = -1
    End Sub
    Private Function sumarimporte(ByVal grid As DataGridView)
        Dim importe As Double
        For i = 0 To grid.RowCount - 1
            importe = importe + CDbl(grid(4, i).Value.ToString())
        Next
        Return importe
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Busca_Clientes.Show()
        Busca_Clientes.Text = "Pagos"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim importetotal As Double
        Dim importe As Double = 0
        Dim cancelado As Integer = 0
        Dim i As Integer = 0

        importetotal = CDbl(NumericUpDown1.Value)
        If importetotal <= 0 Then
            MessageBox.Show("Debe de ingresar un valor mayor a 0")
            Exit Sub
        End If

        Dim Entidad_detalle As New Entidad_ventadetalle
        Dim Negocio_detalle As New Negocio_Venta_Detalle

        Dim Entidad_Cobro As New Entidad_Cobros
        Dim Negocio_Cobro As New Negocio_Cobros

        Dim idbanco_caja As Integer = 1
        Dim correlativo As String = Mid(Me.fecha_formatoansi, 10)
        Dim nombre As String = "COBRO EN EFECTIVO"
        Dim idautorizacion As String = ""
        Dim chkconciliado As Integer = 0

        With Entidad_Cobro
            .idcliente = Label3.Text
            .monto = importetotal
            ' .fecha = Me.fecha_formatoansi
            .fecha = Format(DateTimePicker1.Value, "yyyyMMdd")
            .idbanco_caja = ComboBox3.SelectedValue
            .correlativo = TextBox1.Text
            .nombre = TextBox3.Text
            .idautorizacion = TextBox2.Text
            .chkconciliado = chkconciliado
        End With

        Negocio_Cobro.Nuevo_Cobro(Entidad_Cobro)

        While importetotal > 0
            importe = CDbl(Me.DataGridView1(4, i).Value)
            importetotal = importetotal - importe
            If importetotal >= 0 Then
                cancelado = 1
            Else
                importe = importetotal + importe
                cancelado = 0
            End If

            With Entidad_detalle
                .idventa = Me.DataGridView1(0, i).Value
                .idproducto = Me.DataGridView1(1, i).Value
                .montopagado = importe
                .cancelado = cancelado
            End With
            'Actualizamos la lista de los proveedores'
            Negocio_detalle.Actualiza_deudas(Entidad_detalle)
            i += 1
        End While

       

        MessageBox.Show("Pago registrado correctamente")
        ComboBox1.SelectedIndex = -1
        limpiar()
    End Sub

    Private Sub limpiar()
        NumericUpDown1.Value = 0.0
        Label5.Text = ""
        Label3.Text = ""
        DateTimePicker1.Value = Now
        ComboBox3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.Text = Mid(Me.fecha_formatoansi, 1, 10)
        cargargridview(-1)
    End Sub

    Private Function fecha_formatoansi() As String
        Dim cadena As String = ""
        cadena = Now.Year
        If (Now.Month) < 10 Then
            cadena = cadena + "0" + CStr(Now.Month)
        Else
            cadena = cadena + CStr(Now.Month)
        End If

        If Now.Day < 10 Then
            cadena = cadena + "0" + CStr(Now.Day)
        Else
            cadena = cadena + CStr(Now.Day)
        End If
        Return cadena

    End Function

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class