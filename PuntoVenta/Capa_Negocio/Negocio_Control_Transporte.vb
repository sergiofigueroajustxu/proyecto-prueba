Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Control_Transporte
    Public Function MostrarControltransporte(ByVal filtro As String) As List(Of Entidad_Control_Transporte)
        Dim lista As New List(Of Entidad_Control_Transporte)
        Dim obj As New Dato_Control_Transporte
        lista = obj.MostrarControlTransporte(filtro)
        Return lista
    End Function

    Public Sub Nueva_Control_Transporte(ByVal registros As Entidad_Control_Transporte)
        Dim Datos As New Dato_Control_Transporte
        Datos.Nueva_Control_Transporte(registros)
    End Sub

    Public Sub Modificar_Control_Transporte(ByVal registros As Entidad_Control_Transporte)
        Dim Datos As New Dato_Control_Transporte
        Datos.Modificar_Control_Transporte(registros)
    End Sub

    Public Sub Eliminar_Control_Transporte(ByVal registros As Entidad_Control_Transporte)
        Dim Datos As New Dato_Control_Transporte
        Datos.Eliminar_Control_Transporte(registros)
    End Sub

End Class
