Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Proveedor

    Public Function Mostrartodosproveedor() As List(Of Entidad_Proveedor)
        Dim lista As New List(Of Entidad_Proveedor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrartodoproveedores", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Proveedor
                reg.idproveedor = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.Ruc = dr.GetValue(2).ToString()
                reg.representante = dr.GetValue(3).ToString()
                reg.direccion = dr.GetValue(4).ToString()
                reg.telefono = dr.GetValue(5).ToString()
                reg.apellidos = dr.GetValue(6).ToString()
                reg.correo = dr.GetValue(7).ToString()
                reg.celular = dr.GetValue(8).ToString()
                reg.limite_proveedor = System.Convert.ToDecimal(dr.GetValue(9))
                reg.limite_dias_proveedor = System.Convert.ToInt16(dr.GetValue(10))
                reg.pago_pendiente = System.Convert.ToDecimal(dr.GetValue(11))
                reg.cobro_pendiente = System.Convert.ToDecimal(dr.GetValue(12))
                reg.es_proveedor = dr.GetValue(13).ToString
                reg.idruta = dr.GetValue(14)
                If Not IsDBNull(dr.GetValue(15)) And Not IsNothing(dr.GetValue(15)) Then
                    reg.codigo_municipio = dr.GetValue(15)
                Else
                    reg.codigo_municipio = ""
                End If
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    Public Function MostrarProveedor(ByVal filtro As String) As List(Of Entidad_Proveedor)
        Dim lista As New List(Of Entidad_Proveedor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarfiltroproveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Proveedor
                reg.idproveedor = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.Ruc = dr.GetValue(2).ToString()
                reg.representante = dr.GetValue(3).ToString()
                reg.direccion = dr.GetValue(4).ToString()
                reg.telefono = dr.GetValue(5).ToString()
                reg.apellidos = dr.GetValue(6).ToString()
                reg.correo = dr.GetValue(7).ToString()
                reg.celular = dr.GetValue(8).ToString()
                reg.limite_proveedor = System.Convert.ToDecimal(dr.GetValue(9))
                reg.limite_dias_proveedor = System.Convert.ToInt16(dr.GetValue(10))
                reg.pago_pendiente = System.Convert.ToDecimal(dr.GetValue(11))
                reg.cobro_pendiente = System.Convert.ToDecimal(dr.GetValue(12))
                reg.es_proveedor = dr.GetValue(13).ToString
                reg.idruta = dr.GetValue(14)
                If Not IsDBNull(dr.GetValue(15)) And Not IsNothing(dr.GetValue(15)) Then
                    reg.codigo_municipio = dr.GetValue(15)
                Else
                    reg.codigo_municipio = ""
                End If
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'para agregar un nuevo proveedor'
    Public Sub Nuevo_Proveedor(ByVal registros As Entidad_Proveedor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevoproveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@ruc", registros.Ruc)
                .AddWithValue("@representante", registros.representante)
                .AddWithValue("@direccion", registros.direccion)
                .AddWithValue("@telefono", registros.telefono)
                .AddWithValue("@apellidos", registros.apellidos)
                .AddWithValue("@correo", registros.correo)
                .AddWithValue("@celular", registros.celular)
                .AddWithValue("@limite_proveedor", registros.limite_proveedor)
                .AddWithValue("@limite_dias_proveedor", registros.limite_dias_proveedor)
                .AddWithValue("@pago_pendiente", registros.pago_pendiente)
                .AddWithValue("@cobro_pendiente", registros.cobro_pendiente)
                .AddWithValue("@es_proveedor", registros.es_proveedor)
                .AddWithValue("@idruta", registros.idruta)
                .AddWithValue("@codigo_municipio", registros.codigo_municipio)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'para modificar un nuevo proveedor'
    Public Sub Modificar_Proveedor(ByVal registros As Entidad_Proveedor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarproveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idproveedor", registros.idproveedor)
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@apellidos", registros.apellidos)
                .AddWithValue("@ruc", registros.Ruc)
                .AddWithValue("@representante", registros.representante)
                .AddWithValue("@direccion", registros.direccion)
                .AddWithValue("@telefono", registros.telefono)
                .AddWithValue("@correo", registros.correo)
                .AddWithValue("@celular", registros.celular)
                .AddWithValue("@limite_proveedor", registros.limite_proveedor)
                .AddWithValue("@limite_dias_proveedor", registros.limite_dias_proveedor)
                .AddWithValue("@pago_pendiente", registros.pago_pendiente)
                .AddWithValue("@cobro_pendiente", registros.cobro_pendiente)
                .AddWithValue("@es_proveedor", registros.es_proveedor)
                .AddWithValue("@idruta", registros.idruta)
                .AddWithValue("@codigo_municipio", registros.codigo_municipio)
            End With
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    'Para Eliminar un Proveedor'

    Public Sub Eliminar_Proveedor(ByVal registros As Entidad_Proveedor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminaproveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idproveedor", registros.idproveedor)

            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
End Class
