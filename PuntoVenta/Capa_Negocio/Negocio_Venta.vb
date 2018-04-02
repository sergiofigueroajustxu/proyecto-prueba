Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Venta
    Public Function Nueva_Venta(ByVal registros As Entidad_Venta)
        Dim Datos As New Dato_Venta
        Return Datos.Nueva_Venta(registros)
    End Function

    Public Function verifica(ByVal idfactura As String) As Integer
        Dim valor As Integer
        Dim obj As New Dato_Venta
        valor = obj.verificafactura(idfactura)
        Return valor
    End Function

    Public Function Mostrarlibroventa(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String, filtro5 As String) As List(Of Entidad_Libro_Venta)
        Dim lista As New List(Of Entidad_Libro_Venta)
        Dim obj As New Dato_Venta
        lista = obj.Mostrarlibroventa(filtro1, filtro2, filtro3, filtro4, filtro5)
        Return lista
    End Function

    Public Sub Eliminar_Venta(ByVal registros As Entidad_Venta)
        Dim Datos As New Dato_Venta
        Datos.Eliminar_Venta(registros)
    End Sub

    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_Venta)
        Dim lista As New List(Of Entidad_Venta)
        Dim obj As New Dato_Venta
        lista = obj.listardeuda(id)
        Return lista
    End Function
    Public Function exporta_venta(ByVal filtro1 As String, filtro2 As String) As List(Of Entidad_Exporta_Venta)
        Dim lista As New List(Of Entidad_Exporta_Venta)
        Dim obj As New Dato_Venta
        lista = obj.exporta_venta(filtro1, filtro2)
        Return lista
    End Function
End Class
