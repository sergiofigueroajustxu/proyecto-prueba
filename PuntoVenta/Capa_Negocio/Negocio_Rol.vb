Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Rol
    Public Function Mostrarruta(ByVal filtro As String) As List(Of Entidad_Ruta)
        Dim lista As New List(Of Entidad_Ruta)
        Dim obj As New Dato_Ruta
        lista = obj.Mostrarruta(filtro)
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_ruta(ByVal registros As Entidad_Ruta)
        Dim Datos As New Dato_Ruta
        Datos.Nueva_Ruta(registros)
    End Sub

    'Para modificar 

    Public Sub Modificar_ruta(ByVal registros As Entidad_Ruta)
        Dim Datos As New Dato_Ruta
        Datos.Modificar_Ruta(registros)
    End Sub

    'Para Eliminar una 
    Public Sub Eliminar_ruta(ByVal registros As Entidad_Ruta)
        Dim Datos As New Dato_Ruta
        Datos.Eliminar_Ruta(registros)
    End Sub

    Public Function MostrarHojaRuta(ByVal filtro1 As String, filtro2 As String, filtro3 As String) As List(Of Entidad_Hoja_Ruta)
        Dim lista As New List(Of Entidad_Hoja_Ruta)
        Dim obj As New Dato_Ruta
        lista = obj.MostrarHojaRuta(filtro1, filtro2, filtro3)
        Return lista
    End Function
End Class
