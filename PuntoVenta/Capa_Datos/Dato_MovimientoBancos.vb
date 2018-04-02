Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data

Public Class Dato_MovimientoBancos

    Public Function MostrarMovimientoBanco(ByVal idbanco As Integer, correlativo As String, IE As String) As List(Of Entidad_MovimientoBanco)
        Dim lista As New List(Of Entidad_MovimientoBanco)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_movimientobanco", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idbanco", idbanco)
            cmd.Parameters.AddWithValue("@correlativo", correlativo)
            cmd.Parameters.AddWithValue("@IE", IE)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_MovimientoBanco
                reg.correlativo = dr.GetValue(0).ToString
                reg.idbanco = dr.GetValue(1).ToString
                reg.fecha = dr.GetValue(2).ToString
                reg.nombre = dr.GetValue(3).ToString
                reg.valor_deposito = dr.GetValue(4).ToString
                reg.valor_retiro = dr.GetValue(5).ToString
                reg.chkconciliado = dr.GetValue(6).ToString
                reg.cuenta_contable = dr.GetValue(7).ToString
                reg.agencia = dr.GetValue(8).ToString
                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function


    'Metodo para Actualizar Saldo en Banco '
    Public Sub Actualiza_SaldoBanco(ByVal registros As Entidad_MovimientoBanco)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("actualizasaldobanco", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idbanco", registros.idbanco)
                .AddWithValue("@valor_deposito", registros.valor_deposito)
                .AddWithValue("@valor_retiro", registros.valor_retiro)
            End With
            cmd.ExecuteNonQuery()
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub



    'Agregar Nuevo 
    Public Sub Agregar_MovimientoBanco(ByVal registros As Entidad_MovimientoBanco)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevomovimientobanco", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@correlativo", registros.correlativo)
                    .AddWithValue("@idbanco", registros.idbanco)
                    .AddWithValue("@fecha", convertirfecha_ansi_text(registros.fecha))
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@valor_deposito", registros.valor_deposito)
                    .AddWithValue("@valor_retiro", registros.valor_retiro)
                    .AddWithValue("@chkconciliado", registros.chkconciliado)
                    .AddWithValue("@cuenta_contable", registros.cuenta_contable)
                    .AddWithValue("@sucursal", registros.agencia)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub

    Public Sub Agregar_Partida_MovimientoBanco(ByVal registros As Entidad_MovimientoBanco)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_AgregarPartidaIngresoMovimientoBanco", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@correlativo", registros.correlativo)
                .AddWithValue("@idbanco", registros.idbanco)
                .AddWithValue("@fecha", convertirfecha_ansi_text(registros.fecha))
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@valor_deposito", registros.valor_deposito)
                .AddWithValue("@valor_retiro", registros.valor_retiro)
                .AddWithValue("@chkconciliado", registros.chkconciliado)
                .AddWithValue("@cuenta_contable", registros.cuenta_contable)
                .AddWithValue("@sucursal", registros.agencia)
            End With
            cmd.ExecuteNonQuery()
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub
    'Para modificar un producto'
    Public Sub modificar_movimientobanco(ByVal registros As Entidad_MovimientoBanco)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarmovimientobanco", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@correlativo", registros.correlativo)
                .AddWithValue("@idbanco", registros.idbanco)
                .AddWithValue("@fecha", convertirfecha_ansi_text(registros.fecha))
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@valor_deposito", registros.valor_deposito)
                .AddWithValue("@valor_retiro", registros.valor_retiro)
                .AddWithValue("@chkconciliado", registros.chkconciliado)
                .AddWithValue("@cuenta_contable", registros.cuenta_contable)
                .AddWithValue("@sucursal", registros.agencia)
            End With
            cmd.ExecuteNonQuery()
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub
    Public Sub Anula_Partida_MovimientoBanco(ByVal registros As Entidad_MovimientoBanco)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_AnulaPartidaIngresoMovimientoBanco", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@correlativo", registros.correlativo)
                .AddWithValue("@idbanco", registros.idbanco)
                .AddWithValue("@fecha", convertirfecha_ansi_text(registros.fecha))
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@valor_deposito", registros.valor_deposito)
                .AddWithValue("@valor_retiro", registros.valor_retiro)
                .AddWithValue("@chkconciliado", registros.chkconciliado)
                .AddWithValue("@cuenta_contable", registros.cuenta_contable)
                .AddWithValue("@sucursal", registros.agencia)
            End With
            cmd.ExecuteNonQuery()
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub

    Private Function convertirfecha_ansi_text(ByVal fecha As String) As String
        Dim cadena As String = ""
        cadena = Mid(fecha, 7, 4) & Mid(fecha, 4, 2) & Mid(fecha, 1, 2)
        Return cadena
    End Function

End Class
