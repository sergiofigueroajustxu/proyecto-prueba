Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Control_Transporte
    Public Function MostrarControlTransporte(ByVal filtro As String) As List(Of Entidad_Control_Transporte)
        Dim lista As New List(Of Entidad_Control_Transporte)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarcontroltransporte", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Control_Transporte
                reg.idcontroltransporte = dr.GetValue(0).ToString()
                reg.numero_placa = dr.GetValue(1).ToString()
                reg.fecha_solicita = dr.GetValue(2).ToString()
                reg.fecha_carga = dr.GetValue(3).ToString()
                reg.fecha_entregara = dr.GetValue(4).ToString()
                reg.fecha_entrega = dr.GetValue(5).ToString()
                reg.numero_despacho = dr.GetValue(6).ToString()
                reg.idfactura = dr.GetValue(7).ToString()
                reg.km_recorrido = dr.GetValue(8).ToString()
                reg.valor_transporte = dr.GetValue(9).ToString()
                reg.idruta = dr.GetValue(10).ToString()
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    Public Sub Nueva_Control_Transporte(ByVal reg As Entidad_Control_Transporte)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevacontroltransporte", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numero_placa", reg.numero_placa)
                .AddWithValue("@fecha_solicita", reg.fecha_solicita)
                .AddWithValue("@fecha_carga", reg.fecha_carga)
                .AddWithValue("@fecha_entregara", reg.fecha_entregara)
                .AddWithValue("@fecha_entrega", reg.fecha_entrega)
                .AddWithValue("@numero_despacho", reg.numero_despacho)
                .AddWithValue("@idfactura", reg.idfactura)
                .AddWithValue("@km_recorrido", reg.km_recorrido)
                .AddWithValue("@valor_transporte", reg.valor_transporte)
                .AddWithValue("@idruta", reg.idruta)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una 

    Public Sub Modificar_Control_Transporte(ByVal reg As Entidad_Control_Transporte)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarcontroltransporte", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idcontroltransporte", reg.idcontroltransporte)
                .AddWithValue("@numero_placa", reg.numero_placa)
                .AddWithValue("@fecha_solicita", reg.fecha_solicita)
                .AddWithValue("@fecha_carga", reg.fecha_carga)
                .AddWithValue("@fecha_entregara", reg.fecha_entregara)
                .AddWithValue("@fecha_entrega", reg.fecha_entrega)
                .AddWithValue("@numero_despacho", reg.numero_despacho)
                .AddWithValue("@idfactura", reg.idfactura)
                .AddWithValue("@km_recorrido", reg.km_recorrido)
                .AddWithValue("@valor_transporte", reg.valor_transporte)
                .AddWithValue("@idruta", reg.idruta)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar una Categoria'

    Public Sub Eliminar_Control_Transporte(ByVal registros As Entidad_Control_Transporte)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminarcontroltransporte", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@idcontroltransporte", registros.idcontroltransporte)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub


End Class
