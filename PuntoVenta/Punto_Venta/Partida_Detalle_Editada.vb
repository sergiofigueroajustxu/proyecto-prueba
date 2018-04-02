Imports Capa_Entidad
Imports Capa_Negocio

Public Class Partida_Detalle_Editada
    Private Sub Partida_Detalle_Editada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarcombosucursal()
    End Sub
    Private Sub cargarcombosucursal()
        Dim lista As New List(Of Entidad_Sucursal)
        Dim obj As New Negocio_Sucursal
        lista = obj.Mostrarsucursal("")
        idsucursal.DataSource = lista
        idsucursal.DisplayMember = "nombre"
        idsucursal.ValueMember = "idsucursal"
        idsucursal.SelectedIndex = -1
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If (debe.Value + haber.Value) = 0 Then
            MessageBox.Show("La Cantidad no es Valida")
            Exit Sub
        End If
        If IsNothing(Me.idsucursal.SelectedValue) Then
            MessageBox.Show("Debe Elegir Centro de Costo")
            Exit Sub
        End If
        Dim oreg As New ListViewItem(Me.Cuenta.Text)  'Codigo de cuenta
        With oreg
            .SubItems.Add(Me.Nombre_Cuenta.Text)
            .SubItems.Add(Me.idsucursal.SelectedValue.ToString)
            .SubItems.Add(Me.debe.Value.ToString)
            .SubItems.Add(Me.haber.Value.ToString)
            PartidaEditada.ListView1.Items.Add(oreg) 'Agregamos todo esto al listview'
        End With
        PartidaEditada.totDebe.Value = PartidaEditada.totDebe.Value + debe.Value
        PartidaEditada.totHaber.Value = PartidaEditada.totHaber.Value + haber.Value

        Me.Close()
    End Sub
End Class