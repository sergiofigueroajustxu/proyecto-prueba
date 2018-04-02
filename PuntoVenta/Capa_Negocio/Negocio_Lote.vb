Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Lote
    Public Function Mostrarlote(ByVal filtro As String) As List(Of Entidad_Lote)
        Dim lista As New List(Of Entidad_Lote)
        Dim obj As New Dato_Lote
        lista = obj.Mostrarlote(filtro)
        Return lista
    End Function

    Public Sub Modificar_Lote(ByVal registros As Entidad_Lote)
        Dim Datos As New Dato_Lote
        Datos.Modificar_Lote(registros)
    End Sub

End Class
