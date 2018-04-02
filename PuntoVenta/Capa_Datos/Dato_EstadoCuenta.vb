Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_EstadoCuenta
    Public Function MostrarEstadoCuenta(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String) As List(Of Entidad_EstadoCuenta)
        Dim lista As New List(Of Entidad_EstadoCuenta)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarestadocuenta", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idcliente", filtro1)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_EstadoCuenta
                reg.Fecha = dr.GetValue(0).ToString()
                reg.Id = dr.GetValue(1).ToString()
                reg.IdProducto = dr.GetValue(2).ToString()
                reg.montopagado = dr.GetValue(3)
                reg.Nombre = dr.GetValue(4).ToString()
reg.Correlativo = dr.GetValue(5).ToString()
             reg.idCliente = dr.GetValue(6).ToString()
reg.Cliente = dr.GetValue(7).ToString()
                reg.venta = dr.GetValue(8)
                reg.compra = dr.GetValue(9)
                reg.montocobrado = dr.GetValue(10)

                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

End Class
