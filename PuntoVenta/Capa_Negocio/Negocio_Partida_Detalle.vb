Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Partida_Detalle
    Public Function MostrarpartidaDetalle(ByVal filtro As String) As List(Of Entidad_Partida_Detalle)
        Dim lista As New List(Of Entidad_Partida_Detalle)
        Dim obj As New Dato_Partida_Detalle
        lista = obj.MostrarPartidaDetalle(filtro)
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Partida_Detalle(ByVal registros As Entidad_Partida_Detalle)
        Dim Datos As New Dato_Partida_Detalle
        Datos.Nueva_Partida_Detalle(registros)
    End Sub

    'Para modificar una

    Public Sub Modificar_Partida_Detalle(ByVal registros As Entidad_Partida_Detalle)
        Dim Datos As New Dato_Partida_Detalle
        Datos.Modificar_Partida_Detalle(registros)
    End Sub

    'Para Eliminar'
    Public Sub Eliminar_Partida_Detalle(ByVal registros As Entidad_Partida_Detalle)
        Dim Datos As New Dato_Partida_Detalle
        Datos.Eliminar_Partida_Detalle(registros)
    End Sub

End Class
