Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Sucursal
    Public Function Mostrarsucursal(ByVal filtro As String) As List(Of Entidad_Sucursal)
        Dim lista As New List(Of Entidad_Sucursal)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarsucursal", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Sucursal
                reg.idsucursal = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.direccion = dr.GetValue(2).ToString()
                reg.telefono = dr.GetValue(3).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva Sucursal'
    Public Sub Nueva_Sucursal(ByVal registros As Entidad_Sucursal)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevasucursal", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idsucursal", registros.idsucursal)
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@direccion", registros.direccion)
                .AddWithValue("@telefono", registros.telefono)
                .AddWithValue("@nit", "")
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una Sucursal'

    Public Sub Modificar_Sucursal(ByVal registros As Entidad_Sucursal)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarsucursal", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@direccion", registros.direccion)
                .AddWithValue("@idsucursal", registros.idsucursal)
                .AddWithValue("@telefono", registros.telefono)
                .AddWithValue("@nit", "")

            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar una Sucursal'

    Public Sub Eliminar_Sucursal(ByVal registros As Entidad_Sucursal)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminarsucursal", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idsucursal", registros.idsucursal)
                .AddWithValue("@resp", 3)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
End Class
