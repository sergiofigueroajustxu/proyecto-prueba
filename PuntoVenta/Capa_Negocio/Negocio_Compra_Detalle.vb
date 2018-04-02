Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Compra_Detalle
    Public Sub Nueva_Compra_Detalle(ByVal registros As Entidad_Compra_Detalles)
        Dim Datos As New Dato_Compra_detalle
        Datos.Nueva_CompraDetalle(registros)
    End Sub

    'para listar lo que debe un cliente determinado
    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_Compra_Detalles)
        Dim lista As New List(Of Entidad_Compra_Detalles)
        Dim obj As New Dato_Compra_detalle
        lista = obj.listardeuda(id)
        Return lista
    End Function
    'Para actualizar a los clientes que deben'
    Public Sub Actualiza_deudas(ByVal registros As Entidad_Compra_Detalles)
        Dim Datos As New Dato_Compra_detalle
        Datos.Actualiza_deudas(registros)
    End Sub


End Class
