Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_TipoCompra
    Public Function Mostrartipocompra(ByVal filtro As String) As List(Of Entidad_Tipo_compra)
        Dim lista As New List(Of Entidad_Tipo_compra)
        Dim obj As New Dato_TipoCompra
        lista = obj.Mostrartipocompra(filtro)
        Return lista
    End Function


End Class
