Imports Capa_Entidad
Imports Capa_Datos



Public Class Negocio_Empleado
    'Para El login
    Public Function Validar(ByVal registros As Entidad_Empleado) As Integer
        Dim valor As Integer
        Dim obj As New Dato_Empleado
        valor = obj.Validar(registros)
        Return valor
    End Function

    'Para obtener el idempleado
    Public Function obtener_idempleado(ByVal usuario As String) As List(Of Entidad_Empleado)
        Dim lista As New List(Of Entidad_Empleado)
        Dim obj As New Dato_Empleado
        lista = obj.obtener_idempleado(usuario)
        Return lista
    End Function


    'Para Eliminar una Empleado'
    Public Sub Eliminar_empleado(ByVal registros As Entidad_Empleado)
        Dim Datos As New Dato_Empleado
        Datos.Eliminar_Empleado(registros)
    End Sub

    Public Function MostrarEmpleado(ByVal filtro As String) As List(Of Entidad_Empleado)
        Dim lista As New List(Of Entidad_Empleado)
        Dim obj As New Dato_Empleado
        lista = obj.Mostrar_Empleado(filtro)
        Return lista
    End Function

End Class
