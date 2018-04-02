Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Venta
    Public Function Nueva_Venta(ByVal registros As Entidad_Venta)
        Dim idventamax As Integer
        idventamax = 0
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_venta", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idcliente", registros.idcliente)
                    .AddWithValue("@idempleado", registros.idempleado)
                    .AddWithValue("@idtipoventa", registros.idtipoventa)
                    .AddWithValue("@fecha", registros.fecha)
                    .AddWithValue("@idfactura", registros.idfactura)
                    .AddWithValue("@sucursal", registros.sucursal)
                    .AddWithValue("@tot_documento", registros.tot_documento)
                    .AddWithValue("@tot_bien", registros.tot_bien)
                    .AddWithValue("@iva_bien", registros.iva_bien)
                    .AddWithValue("@vence", registros.fecha_vence)
                    .AddWithValue("@nombre_cliente", registros.nombre_cliente)
                End With
                cmd.ExecuteNonQuery()
                Dim returnParameter As SqlParameter = cmd.Parameters.Add("@idventamax", SqlDbType.Int)
                returnParameter.Direction = ParameterDirection.ReturnValue
                cmd.ExecuteNonQuery()
                idventamax = returnParameter.Value
                If idventamax > 0 Then
                    MsgBox("Se guardo el registro ID: " + idventamax.ToString)
                Else
                    MsgBox("Problema al grabar el registro " + idventamax.ToString)
                End If
            Catch ex As Exception
                MsgBox("No se guardo el registro")
                idventamax = 0
            End Try
        End Using
        Return idventamax
    End Function
    Public Function verificafactura(ByVal idfactura As String) As Integer
        Dim valor As Integer
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_verifica_venta", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idfactura", idfactura)
            cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
            cmd.ExecuteNonQuery()
            valor = CType(cmd.Parameters.Item("@RETURN_VALUE").Value, Integer)
        End Using
        Return valor
    End Function

    Public Function Mostrarlibroventa(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String, filtro5 As String) As List(Of Entidad_Libro_Venta)
        Dim lista As New List(Of Entidad_Libro_Venta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarlibroventa", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idfactura", filtro1)
            cmd.Parameters.AddWithValue("@mes", filtro2)
            cmd.Parameters.AddWithValue("@nit", filtro3)
            cmd.Parameters.AddWithValue("@sucursal", filtro4)
            cmd.Parameters.AddWithValue("@anio", filtro5)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Libro_Venta
                reg.Factura = dr.GetValue(0).ToString
                reg.Fecha = dr.GetValue(1).ToString
                reg.NIT = dr.GetValue(2).ToString
                reg.Nombre = dr.GetValue(3).ToString
                reg.Bien = dr.GetValue(4).ToString
                reg.Servicio = dr.GetValue(5).ToString
                reg.Exenta = dr.GetValue(6).ToString
                reg.IVA_Bien = dr.GetValue(7).ToString
                reg.IVA_Servicio = dr.GetValue(8).ToString
                reg.Total = dr.GetValue(9).ToString
                reg.Sucursal = dr.GetValue(10).ToString
                reg.Descripcion = dr.GetValue(11).ToString
                reg.Idempleado = dr.GetValue(12).ToString
                reg.idruta = dr.GetValue(13)
                reg.idcliente = dr.GetValue(14).ToString
                reg.direccion = dr.GetValue(15).ToString
                reg.nombreSucursal = dr.GetValue(16).ToString
                reg.nombreEmpleado = dr.GetValue(17).ToString
                reg.Fecha_Vence = dr.GetValue(18).ToString

                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function



    Public Sub Eliminar_Venta(ByVal registros As Entidad_Venta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminaventa", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idventa", registros.idventa)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Fallo la operacion")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub


    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_Venta)
        Dim lista As New List(Of Entidad_Venta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_listardeudafacturaventa", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idcliente", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Venta
                reg.idventa = dr.GetValue(0).ToString
                reg.idfactura = dr.GetValue(1).ToString()
                reg.fecha = dr.GetValue(2).ToString()
                reg.tot_documento = dr.GetValue(3).ToString()
                reg.fecha_vence = dr.GetValue(4).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    Public Function exporta_venta(ByVal filtro1 As String, filtro2 As String) As List(Of Entidad_Exporta_Venta)
        Dim lista As New List(Of Entidad_Exporta_Venta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_exporta_ventas", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@mes", filtro1)
            cmd.Parameters.AddWithValue("@anio", filtro2)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Exporta_Venta

                reg.Factura = dr.GetValue(0).ToString
                reg.idcliente = dr.GetValue(1).ToString
                reg.Idempleado = dr.GetValue(2).ToString
                reg.Fecha = dr.GetValue(3).ToString
                reg.idtipoventa = dr.GetValue(4).ToString
                'reg.idtipocomprobante = dr.GetValue(5).ToString
                reg.Total = dr.GetValue(6).ToString
                'reg.retencion = dr.GetValue(7).ToString
                reg.Fecha_Vence = dr.GetValue(8).ToString
                'reg.tipodocumento = dr.GetValue(9).ToString
                'reg.correlativo = dr.GetValue(10).ToString
                reg.NIT = dr.GetValue(11).ToString
                reg.Nombre = dr.GetValue(12).ToString
                reg.direccion = dr.GetValue(13).ToString
                reg.Sucursal = dr.GetValue(14).ToString
                reg.Exenta = dr.GetValue(15).ToString

                reg.Bien = dr.GetValue(16).ToString
                reg.Servicio = dr.GetValue(17).ToString
                reg.Total = dr.GetValue(18).ToString
                reg.IVA_Bien = dr.GetValue(19).ToString
                reg.IVA_Servicio = dr.GetValue(20).ToString
                'reg.idp = dr.GetValue(21).ToString
                'reg.otr  = dr.GetValue(22).ToString
                'reg.cod_empleado = dr.GetValue(23).ToString
                'reg.bloqueado = dr.GetValue(24).ToString
                reg.idproducto = dr.GetValue(25).ToString
                reg.precio = dr.GetValue(26).ToString
                reg.cantidad = dr.GetValue(27).ToString
                reg.importe = dr.GetValue(28).ToString
                reg.monto_pagado = dr.GetValue(29).ToString
                reg.cod_producto = dr.GetValue(30).ToString
                reg.cantidad_d = dr.GetValue(31).ToString
                reg.valor = dr.GetValue(32).ToString
                reg.iva = dr.GetValue(33).ToString
                reg.idp_detalle = dr.GetValue(34).ToString
                reg.otros = dr.GetValue(35).ToString
                reg.cancelado = dr.GetValue(36).ToString
                reg.codigo_barra = dr.GetValue(37).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

End Class
