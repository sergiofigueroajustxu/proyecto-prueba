Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Sucursal
    Public Function Mostrarsucursal(ByVal filtro As String) As List(Of Entidad_Sucursal)
        Dim lista As New List(Of Entidad_Sucursal)
        Dim obj As New Dato_Sucursal
        lista = obj.Mostrarsucursal(filtro)
        Return lista
    End Function

    'Para Agregar una Nueva Sucursal'
    Public Sub Nueva_Sucursal(ByVal registros As Entidad_Sucursal)
        Dim Datos As New Dato_Sucursal
        Datos.Nueva_Sucursal(registros)
    End Sub

    'Para modificar una sucursal

    Public Sub Modificar_sucursal(ByVal registros As Entidad_Sucursal)
        Dim Datos As New Dato_Sucursal
        Datos.Modificar_Sucursal(registros)
    End Sub

    'Para Eliminar una Sucursal'
    Public Sub Eliminar_sucursal(ByVal registros As Entidad_Sucursal)
        Dim Datos As New Dato_Sucursal
        Datos.Eliminar_Sucursal(registros)
    End Sub
End Class
