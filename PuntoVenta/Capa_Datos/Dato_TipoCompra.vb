Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_TipoCompra
    Public Function MostrarTipoCompra(ByVal filtro As String) As List(Of Entidad_Tipo_compra)
        Dim lista As New List(Of Entidad_Tipo_compra)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrartipocompra", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Tipo_compra
                reg.idtipocompra = dr.GetValue(0).ToString()
                reg.descripcion = dr.GetValue(1).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function


End Class
