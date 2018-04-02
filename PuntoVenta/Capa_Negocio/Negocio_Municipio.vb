Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Municipio
    Public Function Mostrarmunicipio(ByVal filtro As String) As List(Of Entidad_Municipio)
        Dim lista As New List(Of Entidad_Municipio)
        Dim obj As New Dato_Municipio
        lista = obj.Mostrarmunicipio(filtro)
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Municipio(ByVal registros As Entidad_Municipio)
        Dim Datos As New Dato_Municipio
        Datos.Nueva_Municipio(registros)
    End Sub

    'Para modificar 

    Public Sub Modificar_Municipio(ByVal registros As Entidad_Municipio)
        Dim Datos As New Dato_Municipio
        Datos.Modificar_Municipio(registros)
    End Sub

    'Para Eliminar una 
    Public Sub Eliminar_Municipio(ByVal registros As Entidad_Municipio)
        Dim Datos As New Dato_Municipio
        Datos.Eliminar_Municipio(registros)
    End Sub

End Class
