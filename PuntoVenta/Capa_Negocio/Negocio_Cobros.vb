Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Cobros
    'Para registrar un pago'
    Public Sub Nuevo_Cobro(ByVal registros As Entidad_Cobros)
        Dim Datos As New Dato_Cobros
        Datos.Nuevo_Cobros(registros)

    End Sub
    Public Function MostrarCobros(ByVal filtro As String) As List(Of Entidad_Cobros)
        Dim lista As New List(Of Entidad_Cobros)
        Dim obj As New Dato_Cobros
        lista = obj.MostrarCobros(filtro)
        Return lista
    End Function

End Class
