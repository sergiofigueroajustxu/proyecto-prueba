﻿Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Venta_Detalle
    Public Sub Nueva_VentaDetalle(ByVal registros As Entidad_ventadetalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_regitrarventadetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idproducto", registros.idproducto)
                .AddWithValue("@precio", registros.precio)
                .AddWithValue("@cantidad", registros.cantidad)
                .AddWithValue("@cancelado", registros.cancelado)
                .AddWithValue("@codigo_barra", registros.codigo_barra)
                .AddWithValue("@idventa", registros.idventa)
            End With
            cmd.ExecuteNonQuery()
        End Using
    End Sub
    'Metodo que muestra cuando debe un determinado cliente se utiliza en el formulario pagos'
    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_ventadetalle)
        Dim lista As New List(Of Entidad_ventadetalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_listardeuda1", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idcliente", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_ventadetalle
                reg.idventa = dr.GetValue(0).ToString
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

    Public Sub Actualiza_deudas(ByVal registros As Entidad_ventadetalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_actualiventadetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idventa", registros.idventa)
                .AddWithValue("@idproducto", registros.idproducto)
                .AddWithValue("@cancelado", registros.cancelado)
                .AddWithValue("@montopagado", registros.montopagado)


            End With
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Public Function mostrar_detalleventa(ByVal id As String) As List(Of Entidad_ventadetalle)
        Dim lista As New List(Of Entidad_ventadetalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_detalleventa", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idfactura", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_ventadetalle
                reg.idventa = dr.GetValue(0).ToString
                reg.idproducto = dr.GetValue(1).ToString
                reg.nombreproducto = dr.GetValue(2).ToString
                reg.correlativo = dr.GetValue(3).ToString
                reg.precio = dr.GetValue(4).ToString
                reg.cantidad = dr.GetValue(5).ToString
                reg.codigo_barra = dr.GetValue(6).ToString
                reg.importe = dr.GetValue(7).ToString
                reg.valor = dr.GetValue(8).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
End Class
