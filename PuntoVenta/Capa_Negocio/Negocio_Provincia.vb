Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Departamento
    Public Function Mostrardepartamento(ByVal filtro As String) As List(Of Entidad_Departamento)
        Dim lista As New List(Of Entidad_Departamento)
        Dim obj As New Dato_Departamento
        lista = obj.Mostrardepartamento(filtro)
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Departamento(ByVal registros As Entidad_Departamento)
        Dim Datos As New Dato_Departamento
        Datos.Nueva_Departamento(registros)
    End Sub

    'Para modificar 

    Public Sub Modificar_departamento(ByVal registros As Entidad_Departamento)
        Dim Datos As New Dato_Departamento
        Datos.Modificar_Departamento(registros)
    End Sub

    'Para Eliminar una 
    Public Sub Eliminar_Departamento(ByVal registros As Entidad_Departamento)
        Dim Datos As New Dato_Departamento
        Datos.Eliminar_Departamento(registros)
    End Sub

End Class
