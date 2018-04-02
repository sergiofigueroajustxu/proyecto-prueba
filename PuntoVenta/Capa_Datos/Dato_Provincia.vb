Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Departamento
    Public Function Mostrardepartamento(ByVal filtro As String) As List(Of Entidad_Departamento)
        Dim lista As New List(Of Entidad_Departamento)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrardepartamento", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Departamento
                reg.iddepartamento = dr.GetValue(0).ToString()
                reg.codigo_departamento = dr.GetValue(1).ToString()
                reg.nombre_departamento = dr.GetValue(2).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Departamento(ByVal registros As Entidad_Departamento)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevadepartamento", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre_departamento", registros.nombre_departamento)
                .AddWithValue("@codigo_departamento", registros.codigo_departamento)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una 

    Public Sub Modificar_Departamento(ByVal registros As Entidad_Departamento)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificardepartamento", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre_departamento", registros.nombre_departamento)
                .AddWithValue("@codigo_departamento", registros.codigo_departamento)
                .AddWithValue("@iddepartamento", registros.iddepartamento)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    Public Sub Eliminar_Departamento(ByVal registros As Entidad_Departamento)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminardepartamento", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@iddepartamento", registros.iddepartamento)

            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

End Class
