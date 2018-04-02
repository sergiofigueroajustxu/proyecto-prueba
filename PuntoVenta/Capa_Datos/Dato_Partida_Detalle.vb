Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Partida_Detalle
    Public Function MostrarPartidaDetalle(ByVal filtro As String) As List(Of Entidad_Partida_Detalle)
        Dim lista As New List(Of Entidad_Partida_Detalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarPartidaDetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Partida_Detalle
                reg.numero_partida = dr.GetValue(0).ToString
                reg.idsucursal = dr.GetValue(1).ToString
                reg.cuenta_contable = dr.GetValue(2).ToString
                reg.debe = dr.GetValue(3).ToString
                reg.haber = dr.GetValue(4).ToString
                reg.item = dr.GetValue(5).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Partida_Detalle(ByVal registros As Entidad_Partida_Detalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevaPartidaDetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numero_partida", registros.numero_partida)
                .AddWithValue("@idsucursal", registros.idsucursal)
                .AddWithValue("@cuenta_contable", registros.cuenta_contable)
                .AddWithValue("@debe", registros.debe)
                .AddWithValue("@haber", registros.haber)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una 

    Public Sub Modificar_Partida_Detalle(ByVal registros As Entidad_Partida_Detalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarPartidaDetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numero_partida", registros.numero_partida)
                .AddWithValue("@idsucursal", registros.idsucursal)
                .AddWithValue("@cuenta_contable", registros.cuenta_contable)
                .AddWithValue("@debe", registros.debe)
                .AddWithValue("@haber", registros.haber)
                .AddWithValue("@item", registros.item)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar 

    Public Sub Eliminar_Partida_Detalle(ByVal registros As Entidad_Partida_Detalle)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminaPartidaDetalle", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@numero_partida", registros.numero_partida)
                .AddWithValue("@idsucural", registros.idsucursal)
                .AddWithValue("@cuenta_contable", registros.cuenta_contable)
                .AddWithValue("@item", registros.item)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

End Class
