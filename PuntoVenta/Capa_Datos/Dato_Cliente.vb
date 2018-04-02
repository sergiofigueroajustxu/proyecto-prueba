Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Cliente
    'funcion para mostrar el nombre y apellido del cliente
    Public Function Mostrarcliente() As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_cliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Cliente
                reg.idcliente = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.nit = dr.GetValue(2).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    'funcion para mostrar el nombre y apellido del proveedor
    Public Function Mostrarproveedor() As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_proveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Cliente
                reg.idcliente = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.nit = dr.GetValue(2).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    'funcion para mostrar datos de un cliente
    Public Function MostrarDatosCliente(ByVal id As Integer) As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrardatoscliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idCliente", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Cliente
                reg.idcliente = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.nit = dr.GetValue(2).ToString()
                reg.telefono = dr.GetValue(5).ToString()
                reg.direccion = dr.GetValue(4).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'funcion para mostrar el nombre y apellido del cliente
    Public Function Mostrartodocliente() As List(Of Entidad_Cliente)
        Dim lista As New List(Of Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrartodocliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Cliente
                reg.idcliente = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.apellidos = dr.GetValue(2).ToString()
                reg.telefono = dr.GetValue(3).ToString()
                reg.nit = dr.GetValue(4).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function


    Public Function buscacliente(ByVal nombre As String) As List(Of Entidad_Cliente)

        Dim lista As New List(Of Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Try
                Dim cmd As New SqlCommand("p_buscacliente", cnn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@nombre", nombre)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                While dr.Read
                    Dim reg As New Entidad_Cliente
                    reg.idcliente = dr.GetValue(0).ToString()
                    reg.nombre = dr.GetValue(1).ToString()
                    reg.apellidos = dr.GetValue(2).ToString()
                    reg.telefono = dr.GetValue(3).ToString()
                    lista.Add(reg)
                End While
                dr.Close()
            Catch ex As Exception
            End Try
        End Using

        Return lista

    End Function

    'para agregar un nuevo cliente'
    Public Function Nuevo_cliente(ByVal registros As Entidad_Cliente) As Integer
        Dim respuesta = 315
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevocliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@apellido", registros.apellidos)
                    .AddWithValue("@telefono", registros.telefono)
                    .AddWithValue("@nit", registros.nit)
                    .AddWithValue("@direccion", registros.direccion)
                End With
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                dr.Read()
                respuesta = (dr.GetValue(0).ToString)
                dr.Close()
                'cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
        End Using
        Return respuesta
    End Function

    'para modificar un cliente'
    Public Sub modificar_cliente(ByVal registros As Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarcliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@apellido", registros.apellidos)
                    .AddWithValue("@telefono", registros.telefono)
                    .AddWithValue("@idcliente", registros.idcliente)

                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()

        End Using
    End Sub
    'Para Eliminar un Proveedor'

    Public Sub eliminar_cliente(ByVal registros As Entidad_Cliente)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminacliente", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idcliente", registros.idcliente)

                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
End Class
