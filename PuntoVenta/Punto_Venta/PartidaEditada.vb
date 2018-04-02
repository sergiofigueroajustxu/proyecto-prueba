Imports Capa_Entidad
Imports Capa_Negocio
Imports System.IO

Public Class PartidaEditada
    Private txt() As PictureBox
    Private lbl() As Label
    Dim panel As New PanelExtended


    Private Sub PartidaEditada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        panel.AutoScroll = True
        panel.Location = New System.Drawing.Point(600, 85)
        panel.Name = "Panel1"
        panel.Size = New System.Drawing.Size(540, 580)
        'Se agrega al formulario'
        Me.Controls.Add(panel)

        mostrarCuentas()


        If File.Exists("c:\temp\imagenes\logo.png") Then 'Comprobamos que el archivo existe'
            PictureBox1.Load("c:\temp\imagenes\logo.png")
        End If

        cargarcombotipo()
    End Sub


    Private Sub cargarcombotipo()
        Dim lista As New List(Of Entidad_Tipo_partida)
        Dim obj As New Negocio_TipoPartida
        lista = obj.Mostrartipopartida("")
        ComboBox5.DataSource = lista
        ComboBox5.DisplayMember = "nombre"
        ComboBox5.ValueMember = "idtipopartida"
        ComboBox5.SelectedIndex = -1
    End Sub

    'para buscar un producto'
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim contador As Integer
        Dim obj As New Negocio_Nomenclatura
        Dim listaCuentas As New List(Of Entidad_Nomenclatura)
        listaCuentas = obj.MostrarNomenclaturaCuenta(Me.TextBox2.Text)
        contador = listaCuentas.Count   'contarproductoporfiltro(TextBox2.Text)
        dibuja(contador, listaCuentas)


    End Sub

    Private Sub btnvender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvender.Click

        If ListView1.Items.Count <= 1 Then
            MessageBox.Show("Debe seleccionar Cuentas Contables")
            ' Exit Sub
        End If

        If TextBox5.Text = "" Then
            MessageBox.Show("Debe ingresar correlativo")
            TextBox5.Focus()
            Exit Sub
        End If


        Dim Entidad As New Entidad_Partida
        Dim Negocio As New Negocio_Partida
        Dim conteo As Integer
        Dim tipopoliza As String

        tipopoliza = ComboBox5.SelectedValue
        conteo = Negocio.verifica(TextBox5.Text)
        If conteo = 0 Then
            MsgBox("No se encontro partida a modificar")
            Exit Sub
        End If

        With Entidad
            .numero_partida = TextBox5.Text
            .tipo = tipopoliza
            .fecha = Me.convertirfecha_ansi(Me.DateTimePicker1, Me.DateTimePicker2)
            .concepto = TextBox1.Text
        End With

        Negocio.Modificar_Partida(Entidad)

        If 1 = 1 Then
            ''Para Agregar Detalle'
            Dim Entidad_detalle As New Entidad_Partida_Detalle
            Dim Negocio_detalle As New Negocio_Partida_Detalle
            For i = 0 To ListView1.Items.Count - 1
                With Entidad_detalle
                    .cuenta_contable = ListView1.Items(i).SubItems(0).Text
                    .idsucursal = ListView1.Items(i).SubItems(2).Text
                    .debe = ListView1.Items(i).SubItems(3).Text
                    .haber = ListView1.Items(i).SubItems(4).Text
                    .numero_partida = TextBox5.Text
                End With

                Negocio_detalle.Nueva_Partida_Detalle(Entidad_detalle)
            Next
        End If
        MessageBox.Show("Transacion Finalizada")
        limpiar()
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
            'cadena = cadena + " 0" + CStr(picker2.Value.Hour) + ":"
        Else
            'cadena = cadena + " " + CStr(picker2.Value.Hour) + ":"
        End If

        If picker2.Value.Minute < 10 Then
            'cadena = cadena + "0" + CStr(picker2.Value.Minute) + ":"
        Else
            'cadena = cadena + CStr(picker2.Value.Minute) + ":"
        End If

        If picker2.Value.Second < 10 Then
            'cadena = cadena + "0" + CStr(picker2.Value.Second)
        Else
            'cadena = cadena + CStr(picker2.Value.Second)
        End If
        Return cadena
    End Function



    'Procedimiento para que se muestren todos los productos en Picturebox'
    Private Sub mostrarCuentas()
        Dim fin As Integer
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Negocio_Nomenclatura
        lista = obj.MostrarNomenclaturaCuenta("")
        fin = lista.Count
        dibuja(fin, lista)
    End Sub

    'metodo para dibujar picturebox en tiempo de ejecucion'
    Private Sub dibuja(ByVal fin As Integer, ByVal lista As List(Of Entidad_Nomenclatura))

        panel.Controls.Clear() 'Eliminamos todos los controles que esten en panel'
        Dim i As Integer
        Dim j As Integer = 0
        Dim p As Integer = 0
        Dim contador As Integer = 0
        ReDim txt(fin)
        ReDim lbl(fin)
        Dim constante As Integer = 40 'variable que determina el espaciado entre los picturebox'
        Dim constantex As Integer = 130
        Dim CuentaContable As String
        'If fin > 12 Then p = 12 Else p = fin
        For i = 1 To fin
            'For i = 1 To p
            txt(i) = New PictureBox 'instanciamos los picturebox'
            lbl(i) = New Label 'iniciamos el label

            'Picturebox'
            Me.txt(i).Size = New System.Drawing.Size(1, 3)
            Me.txt(i).Name = lista.Item(i - 1).cuenta '& "  " & lista.Item(i - 1).nombre
            Me.txt(i).SizeMode = PictureBoxSizeMode.StretchImage


            contador = contador + 1
            If contador <= 1 Then
                txt(i).Location = New System.Drawing.Point((contador * constantex) - constantex, j * constante) 'para la ubicacion'

            Else
                j = j + 1
                txt(i).Location = New System.Drawing.Point(0, j * constante)
                contador = 1
            End If

            panel.Controls.Add(txt(i))
            CuentaContable = Mid(lista.Item(i - 1).cuenta & Space(15), 1, 15)
            lbl(i).Location = New System.Drawing.Point(txt(i).Location.X, txt(i).Location.Y + 5)
            Me.txt(i).Text = lista.Item(i - 1).nombre
            Me.lbl(i).Text = CuentaContable & " " & lista.Item(i - 1).nombre
            Me.lbl(i).ForeColor = Color.White
            If lista.Item(i - 1).en_polizas = 1 Then Me.lbl(i).BackColor = Color.SlateBlue Else Me.lbl(i).BackColor = Color.SteelBlue
            Me.lbl(i).Font = New System.Drawing.Font("Courier New", 8.5, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbl(i).Size = New System.Drawing.Size(500, 30)
            Me.lbl(i).TextAlign = ContentAlignment.MiddleLeft
            panel.Controls.Add(lbl(i))

            AddHandler lbl(i).Click, AddressOf All_filter_click
        Next

    End Sub

    'Asignar un manejador de evento al control creado'
    Private Sub All_filter_click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim etiqueta As Label
        etiqueta = CType(sender, Label)
        traslada_datos_captura_detalle_partida(etiqueta.Text, 0, 0)


    End Sub

    Sub traslada_datos_captura_detalle_partida(ByVal idcuenta As String, debe As Double, haber As Double)

        Dim obj As New Negocio_Nomenclatura
        Dim listaCuentas As New List(Of Entidad_Nomenclatura)
        listaCuentas = obj.MostrarNomenclaturaCuenta(idcuenta)
        If listaCuentas.Count > 0 Then
            Partida_Detalle_Editada.Cuenta.Text = listaCuentas.Item(0).cuenta
            Partida_Detalle_Editada.Nombre_Cuenta.Text = listaCuentas.Item(0).nombre
            Partida_Detalle_Editada.debe.Value = debe
            Partida_Detalle_Editada.haber.Value = haber
            Partida_Detalle_Editada.Show()
        End If
    End Sub




    'funcion para colorear el listview'
    Public Sub colorearListView(ByRef list As ListView)
        Dim i As Integer

        For i = 0 To list.Items.Count - 1

            If i = Int(i / 2) * 2 Then

                list.Items.Item(i).BackColor = Color.Red

            Else

                list.Items.Item(i).BackColor = Color.Yellow
            End If

        Next

        list.FullRowSelect = True
    End Sub


    Private Sub limpiar()
        Me.ListView1.Items.Clear()
        Label5.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox5.Text = ""
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Date.Now.ToLocalTime
        totDebe.Value = 0
        totHaber.Value = 0
    End Sub



    '    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim respuesta As Integer
            Dim txtcount As Integer = ListView1.SelectedIndices(0) 'Gets the index of the first selected index
            respuesta = MsgBox("Confirma que modifica el item:" & ListView1.Items(txtcount).SubItems(1).Text & "  " & ListView1.Items(txtcount).SubItems(3).Text & "  ", vbYesNo, "Elimnina Item")
            If respuesta = MsgBoxResult.Yes Then
                Dim debe As Double, haber As Double, idcuenta As String
                idcuenta = ListView1.Items(txtcount).SubItems(0).Text
                debe = CDbl(ListView1.Items(txtcount).SubItems(3).Text)
                haber = CDbl(ListView1.Items(txtcount).SubItems(4).Text)
                totDebe.Value = totDebe.Value - debe
                totHaber.Value = totHaber.Value - haber
                ListView1.Items(txtcount).Remove()
                traslada_datos_captura_detalle_partida(idcuenta, debe, haber)
            End If

        End If

    End Sub
    Private Sub TextBox6__KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            My.Computer.Keyboard.SendKeys(ChrW(Keys.Tab), True)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
    End Sub

    Private Sub ListView1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged

    End Sub
End Class