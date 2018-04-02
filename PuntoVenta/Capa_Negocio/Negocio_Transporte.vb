Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Transporte
    Public Function Mostrartransporte(ByVal filtro As String) As List(Of Entidad_Transporte)
        Dim lista As New List(Of Entidad_Transporte)
        Dim obj As New Dato_Transporte
        lista = obj.MostrarTransporte(filtro)
        Return lista
    End Function

    Public Sub Nueva_Transporte(ByVal registros As Entidad_Transporte)
        Dim Datos As New Dato_Transporte
        Datos.Nueva_Transporte(registros)
    End Sub

    Public Sub Modificar_Transporte(ByVal registros As Entidad_Transporte)
        Dim Datos As New Dato_Transporte
        Datos.Modificar_Transporte(registros)
    End Sub

    Public Sub Eliminar_Transporte(ByVal registros As Entidad_Transporte)
        Dim Datos As New Dato_Transporte
        Datos.Eliminar_Transporte(registros)
    End Sub


End Class
