Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_TipoVenta
    Public Function MostrarTipoVenta(ByVal filtro As String) As List(Of Entidad_Tipo_venta)
        Dim lista As New List(Of Entidad_Tipo_venta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrartipoventa", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Tipo_venta
                reg.idtipoventa = dr.GetValue(0).ToString()
                reg.descripcion = dr.GetValue(1).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function


End Class
