Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Compra_detalle
    Public Sub Nueva_CompraDetalle(ByVal registros As Entidad_Compra_Detalles)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_registrarcompradetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idproducto", registros.idproducto)
                .AddWithValue("@importe", registros.importe)
                .AddWithValue("@cantidad", registros.cantidad)
                .AddWithValue("@cancelado", registros.cancelado)
                .AddWithValue("@montopagado", registros.montopagado)
                .AddWithValue("@lote", registros.lote)
                .AddWithValue("@vence", registros.vence)
                .AddWithValue("@codigo_barra", registros.codigo_barra)
                .AddWithValue("@idcompra", registros.idcompra)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub


    'Metodo que muestra cuando debe un determinado cliente se utiliza en el formulario pagos'
    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_Compra_Detalles)
        Dim lista As New List(Of Entidad_Compra_Detalles)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_listardeuda2", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idcliente", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Compra_Detalles
                reg.idcompra = dr.GetValue(0).ToString
                reg.idproducto = dr.GetValue(1).ToString()
                reg.importe = dr.GetValue(2).ToString() 'aqui importe representa importe - montopagado'
                reg.nombreproducto = dr.GetValue(3).ToString()
                reg.correlativo = dr.GetValue(4).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    Public Sub Actualiza_deudas(ByVal registros As Entidad_Compra_Detalles)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_actualicompradetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idcompra", registros.idcompra)
                .AddWithValue("@idproducto", registros.idproducto)
                .AddWithValue("@cancelado", registros.cancelado)
                .AddWithValue("@montopagado", registros.montopagado)


            End With
            cmd.ExecuteNonQuery()
        End Using
    End Sub



End Class
