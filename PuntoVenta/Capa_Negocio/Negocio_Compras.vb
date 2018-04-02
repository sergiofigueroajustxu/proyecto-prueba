Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Compras
    Public Function Nueva_Compra(ByVal registros As Entidad_Compras) As Integer
        Dim Datos As New Dato_Compras
        Return Datos.Nueva_Compra(registros)
    End Function


    Public Function Mostrarlibrocompra(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String, filtro5 As String) As List(Of Entidad_Libro_Compra)
        Dim lista As New List(Of Entidad_Libro_Compra)
        Dim obj As New Dato_Compras
        lista = obj.Mostrarlibrocompra(filtro1, filtro2, filtro3, filtro4, filtro5)
        Return lista
    End Function

    Public Sub Eliminar_Compra(ByVal registros As Entidad_Compras)
        Dim Datos As New Dato_Compras
        Datos.Eliminar_Compra(registros)
    End Sub

    Public Sub Nueva_Compra_Completa(ByVal registros As Entidad_Compras)
        Dim Datos As New Dato_Compras
        Datos.Nueva_Compra_Completa(registros)
    End Sub

    Public Sub Modificar_Compra_Completa(ByVal registros As Entidad_Compras)
        Dim Datos As New Dato_Compras
        Datos.Modificar_Compra_Completa(registros)
    End Sub

    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_Compras)
        Dim lista As New List(Of Entidad_Compras)
        Dim obj As New Dato_Compras
        lista = obj.listardeuda(id)
        Return lista
    End Function
End Class
