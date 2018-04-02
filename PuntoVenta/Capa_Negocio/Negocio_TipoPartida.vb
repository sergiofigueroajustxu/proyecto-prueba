Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_TipoPartida
    Public Function Mostrartipopartida(ByVal filtro As String) As List(Of Entidad_Tipo_Partida)
        Dim lista As New List(Of Entidad_Tipo_Partida)
        Dim obj As New Dato_TipoPartida
        lista = obj.Mostrartipopartida(filtro)
        Return lista
    End Function


End Class
