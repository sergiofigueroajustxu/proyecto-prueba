Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_MovimientoBanco
    Public Function Mostrarmovimientobanco(ByVal idbanco As Integer, ByVal filtro As String, ByVal IE As String) As List(Of Entidad_MovimientoBanco)
        Dim lista As New List(Of Entidad_MovimientoBanco)
        Dim obj As New Dato_MovimientoBancos
        lista = obj.MostrarMovimientoBanco(idbanco, filtro, IE)
        Return lista
    End Function

    'Para Agregar una Nuevo Movimiento Bancos'
    Public Sub Nueva_MovimientoBanco(ByVal registros As Entidad_MovimientoBanco)
        Dim Datos As New Dato_MovimientoBancos
        Datos.Agregar_MovimientoBanco(registros)
    End Sub
    Public Sub Agrega_Partida_MovimientoBanco(ByVal registros As Entidad_MovimientoBanco)
        Dim Datos As New Dato_MovimientoBancos
        Datos.Agregar_Partida_MovimientoBanco(registros)
    End Sub
    'Para modificar un movimiento banco
    Public Sub Anula_Partida_MovimientoBanco(ByVal registros As Entidad_MovimientoBanco)
        Dim Datos As New Dato_MovimientoBancos
        Datos.Anula_Partida_MovimientoBanco(registros)
    End Sub
    Public Sub Modificar_MovimientoBanco(ByVal registros As Entidad_MovimientoBanco)
        Dim Datos As New Dato_MovimientoBancos
        Datos.Modificar_MovimientoBanco(registros)
    End Sub

End Class
