Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_TipoVenta
    Public Function Mostrartipoventa(ByVal filtro As String) As List(Of Entidad_Tipo_venta)
        Dim lista As New List(Of Entidad_Tipo_venta)
        Dim obj As New Dato_TipoVenta
        lista = obj.Mostrartipoventa(filtro)
        Return lista
    End Function


End Class
