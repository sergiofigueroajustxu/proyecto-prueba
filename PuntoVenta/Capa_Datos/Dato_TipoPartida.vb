Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_TipoPartida
    Public Function MostrarTipoPartida(ByVal filtro As String) As List(Of Entidad_Tipo_Partida)
        Dim lista As New List(Of Entidad_Tipo_Partida)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrartipopartida", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Tipo_Partida
                reg.idtipopartida = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function


End Class
