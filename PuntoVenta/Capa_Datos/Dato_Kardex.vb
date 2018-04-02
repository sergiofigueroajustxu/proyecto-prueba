Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Kardex
    Public Function MostrarKardex(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String) As List(Of Entidad_Kardex)
        Dim lista As New List(Of Entidad_Kardex)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            'Dim cmd As New SqlCommand("p_mostrarkardex", cnn)
            Dim cmd As New SqlCommand("p_kardex_saldo", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim idproducto As Integer
            If filtro1.Length = 0 Then idproducto = -1 Else idproducto = CInt(filtro1)
            cmd.Parameters.AddWithValue("@idproducto", idproducto)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Kardex
                reg.fecha = dr.GetValue(0).ToString
                reg.idfactura = dr.GetValue(1).ToString
                reg.idproducto = dr.GetValue(2).ToString
                reg.nombre = dr.GetValue(3).ToString
                reg.ingreso = dr.GetValue(4).ToString
                reg.egreso = dr.GetValue(5).ToString
                reg.saldo = dr.GetValue(6).ToString
                reg.costo = dr.GetValue(8).ToString
                reg.precio = dr.GetValue(9).ToString
                reg.idcliente = dr.GetValue(10).ToString
                reg.idempleado = dr.GetValue(11).ToString
                reg.idproveedor = dr.GetValue(12).ToString
                reg.idtipoventa = dr.GetValue(13).ToString
                reg.sucursal = dr.GetValue(14).ToString
                reg.compra = dr.GetValue(15).ToString
                reg.venta = dr.GetValue(16).ToString

                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

End Class
