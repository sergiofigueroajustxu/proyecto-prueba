Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Inventario
    Public Function MostrarInventario(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String) As List(Of Entidad_Inventario)
        Dim lista As New List(Of Entidad_Inventario)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarinventario", cnn)
            Dim idsucursal As Integer
            If filtro1.Length = 0 Then idsucursal = 0 Else idsucursal = CInt(filtro1)
            cmd.Parameters.AddWithValue("@idsucursal", idsucursal)

            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Inventario
                reg.idProducto = dr.GetValue(0).ToString()
                reg.Nombre = dr.GetValue(1).ToString()
                reg.Ingreso = dr.GetValue(2).ToString()
                reg.egreso = dr.GetValue(3).ToString()
                reg.saldo = dr.GetValue(4).ToString()
                reg.sucursal = dr.GetValue(5).ToString()
                reg.precio = dr.GetValue(6).ToString()
                reg.costo_promedio = dr.GetValue(7).ToString()
                reg.categoria = dr.GetValue(8).ToString()
                reg.proveedor = dr.GetValue(9).ToString()

                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

End Class
