Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Empleado

    'Para el Login'

    Public Function Validar(ByVal registro As Entidad_Empleado) As Integer
        Dim valor As Integer
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_validar", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@usuario", registro.usuario)
            cmd.Parameters.AddWithValue("@clave", registro.contraseña)
            cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue

            cmd.ExecuteNonQuery()
            valor = CType(cmd.Parameters.Item("@RETURN_VALUE").Value, Integer)
            'If valor >= 0 Then
            'logeo = True
            'Else
            'logeo = False
            'End If
            cnn.Close()
            cnn.Dispose()
        End Using
        'Return logeo
        Return valor
    End Function

    'Obtenemos el id del empleado'
    Public Function obtener_idempleado(ByVal usuario As String) As List(Of Entidad_Empleado)

        Dim lista As New List(Of Entidad_Empleado)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Try
                Dim cmd As New SqlCommand("p_idempleado", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@usuario", usuario)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim reg As New Entidad_Empleado
                    reg.idempleado = dr.GetValue(0).ToString()
                    lista.Add(reg)
                End While
                dr.Close()

            Catch ex As Exception
            End Try
        End Using

        Return lista

    End Function


    'Para Eliminar un Proveedor'
    Public Sub Eliminar_Empleado(ByVal registros As Entidad_Empleado)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminarempleado", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idempleado", registros.idempleado)
                .AddWithValue("@resp", 3)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    Public Function Mostrar_Empleado(ByVal filtro As String) As List(Of Entidad_Empleado)
        Dim lista As New List(Of Entidad_Empleado)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarempleado", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Empleado
                reg.idempleado = dr.GetValue(0).ToString()
                reg.nombres_apellidos = dr.GetValue(1).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

End Class
