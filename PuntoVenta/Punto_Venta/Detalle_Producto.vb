Public Class Detalle_Producto

    Private Sub Detalle_Producto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ControlBox = False 'con esto desapareces los botones maximizar minimizat y cerrar'
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "Añadir")
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Cancelar")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Debe de ingresar una cantidad")
            Exit Sub
        End If
        If TextBox1.Text = "0" Then
            MessageBox.Show("Ingreso una cantidad dierente a 0")
            ' Exit Sub
        End If
        If Not IsNumeric(TextBox1.Text) Then
            MessageBox.Show("La Cantidad no es Valida")
            Exit Sub
        End If

        Dim posicion As Integer 'variable que contendra la posicion en la que se repite el listview'
        Dim stock As Integer
        posicion = recorrerlistview(Venta.ListView1)
        ' si es igual a -1 significa que no se repite
        If posicion = -1 Then
            stock = CType(Me.Label2.Text, Integer)
            If stock >= CType(Me.TextBox1.Text, Integer) Then
            Else
                MessageBox.Show("No tienes stock suficiente")

            End If

            Dim oreg As New ListViewItem(PictureBox1.Name)
            With oreg
                .SubItems.Add(Label6.Text)
                .SubItems.Add(FormatNumber(Label3.Text, 2))
                .SubItems.Add(FormatNumber(TextBox1.Text, 2))
                .SubItems.Add(FormatNumber((Label3.Text) * (TextBox1.Text), 2))
                .SubItems.Add(TextBox2.Text)
                .SubItems.Add(TextBox3.Text)
                Venta.ListView1.Items.Add(oreg)
            End With

            Venta.Label4.Text = FormatNumber(CDbl(Venta.Label4.Text) + (CDbl(Label3.Text) * CDbl(TextBox1.Text)), 2)
            Venta.Label10.Text = FormatNumber(CDbl(Venta.Label10.Text) + (CDbl(Label3.Text) * CDbl(Label13.Text) * CDbl(TextBox1.Text) / (1 + CDbl(Label13.Text))), 2)
            Venta.TextBox2.Text = ""
            Venta.TextBox6.Text = ""
            Me.Close()

            Else
            stock = CType(Me.Label2.Text, Integer)
            If stock >= (CType(Me.TextBox1.Text, Integer) + CType(Venta.ListView1.Items(posicion).SubItems(2).Text, Integer)) Then
                Venta.ListView1.Items(posicion).SubItems(2).Text = CType(CType(Venta.ListView1.Items(posicion).SubItems(2).Text, Double) + CType(TextBox1.Text, Double), String)
                Venta.Label4.Text = FormatNumber(CDbl(Venta.Label4.Text) + (CDbl(Label3.Text) * CDbl(TextBox1.Text)), 2)
                Venta.Label10.Text = FormatNumber(CDbl(Venta.Label10.Text) + (CDbl(Label3.Text) * CDbl(Label13.Text) * CDbl(TextBox1.Text) / (1 + CDbl(Label13.Text))), 2)
                Venta.TextBox2.Text = ""
                Venta.TextBox6.Text = ""
                Me.Close()
            Else
                MessageBox.Show("No tienes stock suficiente")
                ' opera con saldo negativo
                Venta.ListView1.Items(posicion).SubItems(2).Text = CType(CType(Venta.ListView1.Items(posicion).SubItems(2).Text, Double) + CType(TextBox1.Text, Double), String)
                Venta.Label4.Text = FormatNumber(CDbl(Venta.Label4.Text) + (CDbl(Label3.Text) * CDbl(TextBox1.Text)), 2)
                Venta.Label10.Text = FormatNumber(CDbl(Venta.Label10.Text) + (CDbl(Label3.Text) * CDbl(Label13.Text) * CDbl(TextBox1.Text) / (1 + CDbl(Label13.Text))), 2)
                Venta.TextBox2.Text = ""
                Venta.TextBox6.Text = ""
                Me.Close()
            End If

        End If




    End Sub

    'Funcion que recorre el listview para ver si es que se repite algun producto y retorna la posicion en la que se encuentra'
    Private Function recorrerlistview(ByVal listview1 As ListView) As Integer

        Dim nombre As String
        Dim posicion As Integer = -1


        For i = 0 To listview1.Items.Count - 1
            nombre = listview1.Items(i).SubItems(0).Text
            If posicion = -1 Then
                If Label6.Text = nombre Then
                    posicion = i
                Else
                    posicion = -1
                End If
            End If
        Next
        Return posicion
    End Function

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Label3.Text = Label7.Text
        TextBox1.Text = "1"
        TextBox1.Minimum = "0"
    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Label3.Text = Label9.Text
        '    TextBox1.Text = "12"
        TextBox1.Minimum = "0"
    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        Label3.Text = Label11.Text
        '     TextBox1.Text = "100"
        TextBox1.Minimum = "0"
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.Validated
        If TextBox2.Text = "1234567890" Then
            '    TextBox3.Visible = True
        Else
            '    TextBox3.Visible = False
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Label3.Text = TextBox3.Text
    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_ValueChanged(sender As Object, e As EventArgs) Handles TextBox1.ValueChanged
        TextBox4.Text = FormatNumber(TextBox1.Value * CDbl(Label3.Text), 2)
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class