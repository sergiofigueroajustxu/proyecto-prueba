Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Cliente
    ' para mostrar cliente
    Public Function Mostrarcliente() As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Dato_Cliente
        lista = obj.Mostrarcliente
        Return lista
    End Function
    ' para mostrar cliente
    Public Function Mostrarproveedor() As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Dato_Cliente
        lista = obj.Mostrarproveedor
        Return lista
    End Function
    ' para mostrar datos de cliente cliente
    Public Function MostrarDatosCliente(id) As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Dato_Cliente
        lista = obj.MostrarDatosCliente(id)
        Return lista
    End Function
    ' para mostrar cliente
    Public Function Mostrartodocliente() As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Dato_Cliente
        lista = obj.Mostrartodocliente
        Return lista
    End Function

    'para buscar cliente
    Public Function buscacliente(ByVal nombre As String) As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Dato_Cliente
        lista = obj.buscacliente(nombre)
        Return lista
    End Function
    'para buscar cliente por medio del nit
    Public Function buscanitcliente(ByVal nit As String) As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Dim obj As New Dato_Cliente
        lista = obj.buscacliente(nit)
        Return lista
    End Function
    'Para agregar un cliente'
    Public Function Nuevo_cliente(ByVal registros As Entidad_Cliente) As Integer
        Dim Datos As New Dato_Cliente
        Return Datos.Nuevo_cliente(registros)
    End Function

    'Para modificar un cliente'
    Public Sub modificar_cliente(ByVal registros As Entidad_Cliente)
        Dim Datos As New Dato_Cliente
        Datos.modificar_cliente(registros)
    End Sub

    'Para Eliminar un Cliente'
    Public Sub Eliminar_cliente(ByVal registros As Entidad_Cliente)
        Dim Datos As New Dato_Cliente
        Datos.eliminar_cliente(registros)
    End Sub
End Class
