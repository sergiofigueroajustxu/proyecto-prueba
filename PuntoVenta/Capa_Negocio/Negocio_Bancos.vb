Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Bancos
    Public Function Mostrarbancos(ByVal filtro As String) As List(Of Entidad_Bancos)
        Dim lista As New List(Of Entidad_Bancos)
        Dim obj As New Dato_Bancos
        lista = obj.Mostrarbancos(filtro)
        Return lista
    End Function

    'Para Agregar una Nuevo Bancos'
    Public Sub Nueva_Bancos(ByVal registros As Entidad_Bancos)
        Dim Datos As New Dato_Bancos
        Datos.Nueva_Bancos(registros)
    End Sub

    'Para modificar una bancos

    Public Sub Modificar_bancos(ByVal registros As Entidad_Bancos)
        Dim Datos As New Dato_Bancos
        Datos.Modificar_Bancos(registros)
    End Sub

    'Para Eliminar una Bancos'
    Public Sub Eliminar_Bancos(ByVal registros As Entidad_Bancos)
        Dim Datos As New Dato_Bancos
        Datos.Eliminar_Bancos(registros)
    End Sub
End Class
