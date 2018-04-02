Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Transporte
    Public Function MostrarTransporte(ByVal filtro As String) As List(Of Entidad_Transporte)
        Dim lista As New List(Of Entidad_Transporte)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrartransporte", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Transporte
                reg.idtransporte = dr.GetValue(0).ToString()
                reg.numero_placa = dr.GetValue(1).ToString()
                reg.nombre = dr.GetValue(2).ToString()
                reg.telefono = dr.GetValue(3).ToString()
                reg.direccion = dr.GetValue(4).ToString()
                reg.km_vehiculo = dr.GetValue(5).ToString()
                reg.valor_km = dr.GetValue(6).ToString()
                reg.fecha_inicio = dr.GetValue(7).ToString()
                reg.codigo_empleado = dr.GetValue(8).ToString()
                reg.cuenta_contable = dr.GetValue(9).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Transporte(ByVal registros As Entidad_Transporte)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevatransporte", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numero_placa", registros.numero_placa)
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@telefono", registros.telefono)
                .AddWithValue("@direccion", registros.direccion)
                .AddWithValue("@km_vehiculo", registros.km_vehiculo)
                .AddWithValue("@valor_km", registros.valor_km)
                .AddWithValue("@fecha_inicio", registros.fecha_inicio)
                If Not IsNothing(registros.codigo_empleado) Then
                    .AddWithValue("@codigo_empleado", registros.codigo_empleado)
                Else
                    .AddWithValue("@codigo_empleado", 0)
                End If
                .AddWithValue("@cuenta_contable", registros.cuenta_contable)

            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una 

    Public Sub Modificar_Transporte(ByVal registros As Entidad_Transporte)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificartransporte", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idtransporte", registros.idtransporte)
                .AddWithValue("@numero_placa", registros.numero_placa)
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@telefono", registros.telefono)
                .AddWithValue("@direccion", registros.direccion)
                .AddWithValue("@km_vehiculo", registros.km_vehiculo)
                .AddWithValue("@valor_km", registros.valor_km)
                .AddWithValue("@fecha_inicio", registros.fecha_inicio)
                If Not IsNothing(registros.codigo_empleado) Then
                    .AddWithValue("@codigo_empleado", registros.codigo_empleado)
                Else
                    .AddWithValue("@codigo_empleado", 0)
                End If
                .AddWithValue("@cuenta_contable", registros.cuenta_contable)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar una Categoria'

    Public Sub Eliminar_Transporte(ByVal registros As Entidad_Transporte)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminarTransporte", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idtransporte", registros.idtransporte)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

End Class
