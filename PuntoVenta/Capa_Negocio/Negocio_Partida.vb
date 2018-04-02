Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Partida
    Public Function Mostrarpartida(ByVal filtro As String) As List(Of Entidad_Partida)
        Dim lista As New List(Of Entidad_Partida)
        Dim obj As New Dato_Partida
        lista = obj.Mostrarpartida(filtro)
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Partida(ByVal registros As Entidad_Partida)
        Dim Datos As New Dato_Partida
        Datos.Nueva_Partida(registros)
    End Sub

    'Para modificar una

    Public Sub Modificar_Partida(ByVal registros As Entidad_Partida)
        Dim Datos As New Dato_Partida
        Datos.Modificar_Partida(registros)
    End Sub

    'Para Eliminar'
    Public Sub Eliminar_Partida(ByVal registros As Entidad_Partida)
        Dim Datos As New Dato_Partida
        Datos.Eliminar_Partida(registros)
    End Sub

    Public Function verifica(ByVal filtro As String) As Integer
        Dim lista As New List(Of Entidad_Partida)
        Dim conteo As Integer = 0
        Dim obj As New Dato_Partida
        lista = obj.verifica(filtro)
        conteo = lista.Count
        Return conteo
    End Function
    Public Function Mostrarlibrodiario(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String, filtro5 As String, filtro6 As String) As List(Of Entidad_Libro_Diario)
        Dim lista As New List(Of Entidad_Libro_Diario)
        Dim obj As New Dato_Partida
        lista = obj.Libro_Diario(filtro1, filtro2, filtro3, filtro4, filtro5, filtro6)
        Return lista
    End Function

    Public Function Mostrarlibromayor(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String, filtro5 As String, filtro6 As String) As List(Of Entidad_Libro_Mayor)
        Dim lista As New List(Of Entidad_Libro_Mayor)
        Dim obj As New Dato_Partida
        lista = obj.Libro_Mayor(filtro1, filtro2, filtro3, filtro4, filtro5, filtro6)
        Return lista
    End Function
    Public Function Mostrarlibrobalancesaldos(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String) As List(Of Entidad_Libro_Balance_Saldos)
        Dim lista As New List(Of Entidad_Libro_Balance_Saldos)
        Dim obj As New Dato_Partida
        lista = obj.Libro_Balance_Saldos(filtro1, filtro2, filtro3, filtro4)
        Return lista
    End Function



End Class
