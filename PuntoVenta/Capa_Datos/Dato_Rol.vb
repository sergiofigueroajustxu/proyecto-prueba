Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Cargo
    Public Function Mostrarruta(ByVal filtro As String) As List(Of Entidad_Ruta)
        Dim lista As New List(Of Entidad_Ruta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarruta", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Ruta
                reg.idruta = dr.GetValue(0).ToString()
                reg.nombre = dr.GetValue(1).ToString()
                reg.descripcion = dr.GetValue(2).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Ruta(ByVal registros As Entidad_Ruta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevaruta", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@descripcion", registros.descripcion)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una 

    Public Sub Modificar_Ruta(ByVal registros As Entidad_Ruta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarruta", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@descripcion", registros.descripcion)
                .AddWithValue("@idruta", registros.idruta)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar una Categoria'

    Public Sub Eliminar_Ruta(ByVal registros As Entidad_Ruta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminaruta", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idruta", registros.idruta)

            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    Public Function MostrarHojaRuta(ByVal filtro1 As String, filtro2 As String, filtro3 As String) As List(Of Entidad_Hoja_Ruta)
        Dim lista As New List(Of Entidad_Hoja_Ruta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_hojaruta", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@fecha", filtro1)
            cmd.Parameters.AddWithValue("@idruta", filtro2)
            cmd.Parameters.AddWithValue("@idtipoventa", filtro3)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Hoja_Ruta
                reg.Fecha = dr.GetValue(0).ToString
                reg.Ruta = dr.GetValue(1).ToString
                reg.Nombre = dr.GetValue(2).ToString
                reg.Direccion = dr.GetValue(3).ToString
                reg.TipoVenta = dr.GetValue(4).ToString
                reg.Factura = dr.GetValue(5).ToString
                ' reg.codigo_barra = dr.GetValue(6).ToString
                reg.Producto = dr.GetValue(7).ToString
                reg.Cantidad = dr.GetValue(8).ToString
                reg.Importe = dr.GetValue(9).ToString
                reg.Sucursal = dr.GetValue(10).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
End Class
