Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Pagos
    'Para registrar un pago'
    Public Sub Nuevo_Pago(ByVal registros As Entidad_Pagos)
        Dim Datos As New Dato_Pagos
        Datos.Nuevo_Pagos(registros)
    End Sub
    Public Function MostrarPagos(ByVal filtro As String) As List(Of Entidad_Pagos)
        Dim lista As New List(Of Entidad_Pagos)
        Dim obj As New Dato_Pagos
        lista = obj.MostrarPagos(filtro)
        Return lista
    End Function

End Class
