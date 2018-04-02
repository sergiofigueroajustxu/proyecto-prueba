Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Bancos
    Public Function Mostrarbancos(ByVal filtro As String) As List(Of Entidad_Bancos)
        Dim lista As New List(Of Entidad_Bancos)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarbancos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Bancos
                reg.idbanco = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.descripcion = dr.GetValue(2).ToString()
                reg.cuenta_contable = dr.GetValue(3).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva Banco'
    Public Sub Nueva_Bancos(ByVal registros As Entidad_Bancos)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevabancos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@descripcion", registros.descripcion)
                    .AddWithValue("@cuenta_contable", registros.cuenta_contable)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una Bancos'

    Public Sub Modificar_Bancos(ByVal registros As Entidad_Bancos)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarbancos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@descripcion", registros.descripcion)
                    .AddWithValue("@idbanco", registros.idbanco)
                    .AddWithValue("@cuenta_contable", registros.cuenta_contable)

                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar una Bancos'

    Public Sub Eliminar_Bancos(ByVal registros As Entidad_Bancos)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminabancos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idbanco", registros.idbanco)

                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("Fallo la operacion")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
End Class
