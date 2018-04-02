Public Class Detalle_Compra

  
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If TextBox1.Text = "" Then
            'MessageBox.Show("Debe de ingresar una cantidad")
            'Exit Sub
        End If
        If TextBox1.Text = "0" Then
            'MessageBox.Show("Deberia ingresar una cantidad mayor a 0")
            'Exit Sub
        End If
        If Not IsNumeric(TextBox1.Text = "0") Then
            MessageBox.Show("La Cantidad no es Valida")
            Exit Sub
        End If



        Dim oreg As New ListViewItem(PictureBox1.Name) 'codigo del producto'

        With oreg
            .SubItems.Add(Label6.Text) 'nombre'
            .SubItems.Add(NumericUpDown2.Value)  'Cantidad'
            .SubItems.Add(NumericUpDown1.Value) 'importe'
            .SubItems.Add(TextBox3.Text) 'lote
            .SubItems.Add(DateTimePicker1.Text) 'fecha vence
            .SubItems.Add(TextBox4.Text) 'codgo barra
            Compra.ListView1.Items.Add(oreg) 'Agregamos todo esto al listview'
        End With
        Compra.Label4.Text = CStr(CDbl(Compra.Label4.Text) + CDbl(NumericUpDown1.Value))
        ' Compra.verificarcheckboxes()
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Dispose()
        Me.Close()
    End Sub


    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        NumericUpDown1.Value = NumericUpDown2.Value * CDbl(TextBox2.Text)
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class