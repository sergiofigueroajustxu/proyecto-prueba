Imports Capa_Entidad
Imports Capa_Negocio
Public Class Login

    'Metodo para ver si existe el usuario y contraseña'
    Private Function Validar(ByVal registros As Entidad_Empleado) As Integer
        Dim valor As Integer
        Dim obj As New Negocio_Empleado
        valor = obj.Validar(registros)
        Return valor
    End Function

    Private Sub logearse()
        Dim autorizado As Integer
        Dim registros As New Entidad_Empleado
        With registros
            .usuario = txtusuario.Text
            .contraseña = txtcontraseña.Text
            '.nombres_apellidos 
            '.id_rol
        End With
        autorizado = Validar(registros)

        If autorizado > 0 Then
            Select Case autorizado
                Case 1
                    Principal.Show()
                    Principal.Text = "Usuario : " + registros.usuario
                Case 2
                    PrincipalContador.Show()
                    PrincipalContador.Text = "Usuario : " + registros.usuario
                Case 3
                    Venta.Show()
            End Select
            Me.Close()
        Else
            MessageBox.Show("usuario o contraseña incorrecta")
        End If
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        logearse()
    End Sub


    Private Sub txtcontraseña_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            logearse()
        End If
    End Sub

    Private Sub txtusuario_TextChanged(sender As Object, e As EventArgs) Handles txtusuario.TextChanged

    End Sub

    Private Sub txtcontraseña_TextChanged(sender As Object, e As EventArgs) Handles txtcontraseña.TextChanged

    End Sub
End Class
