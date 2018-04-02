Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Compras
    Public Function Nueva_Compra(ByVal registros As Entidad_Compras) As Integer
        Dim idcompramax As Integer
        idcompramax = 0
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("agregarcompra", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idtipocomprobante", registros.idtipocomprobante)
                    .AddWithValue("@idfactura", registros.idfactura)
                    .AddWithValue("@idproveedor", registros.idproveedor)
                    .AddWithValue("@importe_total", registros.importetotal)
                    .AddWithValue("@retencion", registros.retencion)
                    .AddWithValue("@fecha", registros.fecha)
                    .AddWithValue("@sucursal", registros.sucursal)
                    .AddWithValue("@contenedor", registros.contenedor)
                    .AddWithValue("@fecha_vence", registros.fecha_vence)
                End With
                Dim returnParameter As SqlParameter = cmd.Parameters.Add("@idcompra", SqlDbType.Int)
                returnParameter.Direction = ParameterDirection.ReturnValue
                cmd.ExecuteNonQuery()
                idcompramax = returnParameter.Value
                If idcompramax > 0 Then
                    MsgBox("Se guardo el registro ID: " + idcompramax.ToString)
                Else
                    MsgBox("Registro duplicado")
                End If
            Catch ex As Exception
                MsgBox("No se guardo el registro")
                idcompramax = 0
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
        Return idcompramax
    End Function


    Public Function Mostrarlibrocompra(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String, filtro5 As String) As List(Of Entidad_Libro_Compra)
        Dim lista As New List(Of Entidad_Libro_Compra)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarlibrocompra", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idfactura", filtro1)
            cmd.Parameters.AddWithValue("@mes", filtro2)
            cmd.Parameters.AddWithValue("@nit", filtro3)
            cmd.Parameters.AddWithValue("@sucursal", filtro4)
            cmd.Parameters.AddWithValue("@anio", filtro5)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Libro_Compra
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
                reg.contenedor = dr.GetValue(12).ToString
                reg.idcompra = dr.GetValue(13).ToString
                If (IsDate(dr.GetValue(14))) Then
                    reg.Fecha_Vence = dr.GetValue(14).ToString
                Else
                    reg.Fecha_Vence = dr.GetValue(1).ToString
                End If
                reg.cuenta_bien = dr.GetValue(15).ToString
                reg.cuenta_servicio = dr.GetValue(16).ToString
                reg.Exenta = dr.GetValue(17).ToString
                reg.idp = dr.GetValue(18).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    Public Sub Eliminar_Compra(ByVal registros As Entidad_Compras)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Try
                Dim cmd As New SqlCommand("p_eliminacompra", cnn)
                cmd.CommandType = CommandType.StoredProcedure

                With cmd.Parameters
                    .AddWithValue("@idcompra", registros.idcompra)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Fallo la operacion")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub


    Public Sub Nueva_Compra_Completa(ByVal registros As Entidad_Compras)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_agregarcompragasto", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idtipocomprobante", registros.idtipocomprobante)
                    .AddWithValue("@idfactura", registros.idfactura)
                    .AddWithValue("@nit", registros.nit)
                    .AddWithValue("@importe_total", registros.importetotal)
                    .AddWithValue("@fecha", registros.fecha)
                    .AddWithValue("@compra_bien", registros.compra_bien)
                    .AddWithValue("@iva_bien", registros.iva_bien)
                    .AddWithValue("@servicio", registros.servicio)
                    .AddWithValue("@iva_servicio", registros.iva_servicio)
                    .AddWithValue("@cuenta_bien", registros.cuenta_bien)
                    .AddWithValue("@cuenta_servicio", registros.cuenta_servicio)
                    .AddWithValue("@sucursal", registros.sucursal)
                    .AddWithValue("@exento", registros.exento)
                    .AddWithValue("@idp", registros.idp)
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

    Public Sub Modificar_Compra_Completa(ByVal registros As Entidad_Compras)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarcompragasto", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim cuenta_bien As String = ""
            Dim cuenta_servicio As String = ""
            If Not IsNothing(registros.cuenta_bien) Then cuenta_bien = registros.cuenta_bien
            If Not IsNothing(registros.cuenta_servicio) Then cuenta_servicio = registros.cuenta_servicio
            Try
                With cmd.Parameters
                    .AddWithValue("@idtipocomprobante", registros.idtipocomprobante)
                    .AddWithValue("@idfactura", registros.idfactura)
                    .AddWithValue("@nit", registros.nit)
                    .AddWithValue("@importe_total", registros.importetotal)
                    .AddWithValue("@fecha", registros.fecha)
                    .AddWithValue("@compra_bien", registros.compra_bien)
                    .AddWithValue("@iva_bien", registros.iva_bien)
                    .AddWithValue("@servicio", registros.servicio)
                    .AddWithValue("@iva_servicio", registros.iva_servicio)
                    .AddWithValue("@cuenta_bien", cuenta_bien)
                    .AddWithValue("@cuenta_servicio", cuenta_servicio)
                    .AddWithValue("@sucursal", registros.sucursal)
                    .AddWithValue("@exento", registros.exento)
                    .AddWithValue("@idp", registros.idp)
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


    Public Function listardeuda(ByVal id As Integer) As List(Of Entidad_Compras)
        Dim lista As New List(Of Entidad_Compras)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_listardeudafacturacompra", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idproveedor", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Compras
                reg.idcompra = dr.GetValue(0).ToString
                reg.idfactura = dr.GetValue(1).ToString()
                reg.fecha = dr.GetValue(2).ToString()
                reg.importetotal = dr.GetValue(3).ToString()
                reg.fecha_vence = dr.GetValue(4).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
End Class
