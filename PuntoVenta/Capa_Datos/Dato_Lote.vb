Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Lote
    Public Function MostrarLote(ByVal filtro As String) As List(Of Entidad_Lote)
        Dim lista As New List(Of Entidad_Lote)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarLote", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Lote
                reg.idproducto = dr.GetValue(0).ToString()
                reg.lote = dr.GetValue(1).ToString()
                reg.vence = dr.GetValue(2).ToString()
                reg.codigo_barra = dr.GetValue(3).ToString()
                reg.saldo_lote = dr.GetValue(4).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    Public Sub Modificar_Lote(ByVal registros As Entidad_Lote)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarLote", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idproducto", registros.idproducto)
                    .AddWithValue("@idlote", registros.lote)
                    .AddWithValue("@codigo_barra", registros.codigo_barra)
                    .AddWithValue("@fecha_vence", registros.vence)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

End Class
