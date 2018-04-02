Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_EstadoCuenta

    Public Function MostrarEstadoCuenta(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String) As List(Of Entidad_EstadoCuenta)
        Dim lista As New List(Of Entidad_EstadoCuenta)
        Dim obj As New Dato_EstadoCuenta
        lista = obj.MostrarEstadoCuenta(filtro1, filtro2, filtro3, filtro4)
        Return lista
    End Function

End Class
