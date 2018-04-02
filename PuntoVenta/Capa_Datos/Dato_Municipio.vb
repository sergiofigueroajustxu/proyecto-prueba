Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Municipio
    Public Function Mostrarmunicipio(ByVal filtro As String) As List(Of Entidad_Municipio)
        Dim lista As New List(Of Entidad_Municipio)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarmunicipio", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Municipio
                reg.idmunicipio = dr.GetValue(0).ToString()
                reg.codigo_municipio = dr.GetValue(1).ToString()
                reg.nombre_municipio = dr.GetValue(2).ToString()
                reg.padre_municipio = dr.GetValue(3).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Municipio(ByVal registros As Entidad_Municipio)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevamunicipio", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre_municipio", registros.nombre_municipio)
                .AddWithValue("@codigo_municipio", registros.codigo_municipio)
                .AddWithValue("@padre_municipio", registros.padre_municipio)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una 

    Public Sub Modificar_Municipio(ByVal registros As Entidad_Municipio)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarmunicipio", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre_municipio", registros.nombre_municipio)
                .AddWithValue("@codigo_municipio", registros.codigo_municipio)
                .AddWithValue("@padre_municipio", registros.padre_municipio)
                .AddWithValue("@idmunicipio", registros.idmunicipio)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar una Categoria'

    Public Sub Eliminar_Municipio(ByVal registros As Entidad_Municipio)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminarmunicipio", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idmunicipio", registros.idmunicipio)

            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

End Class
