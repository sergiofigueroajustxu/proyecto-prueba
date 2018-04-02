﻿Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Pagos
    Public Sub Nuevo_Pagos(ByVal registros As Entidad_Pagos)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_insertarpagos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idcliente", registros.idcliente)
                    .AddWithValue("@monto", registros.monto)
                    .AddWithValue("@fecha", registros.fecha)
                    .AddWithValue("@idbanco_caja", registros.idbanco_caja)
                    .AddWithValue("@correlativo", registros.correlativo)
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@idautorizacion", registros.idautorizacion)
                    .AddWithValue("@chkconciliado", registros.chkconciliado)
                End With
                cmd.ExecuteNonQuery()
                MsgBox("Se guardo el registro")
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
    Public Function MostrarPagos(ByVal filtro As String) As List(Of Entidad_Pagos)
        Dim lista As New List(Of Entidad_Pagos)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarPagos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Pagos
                reg.fecha = dr.GetValue(0).ToString
                reg.idpagos = dr.GetValue(1).ToString
                reg.idcliente = dr.GetValue(2).ToString
                reg.monto = dr.GetValue(3).ToString
                reg.nombre = dr.GetValue(4).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

End Class
