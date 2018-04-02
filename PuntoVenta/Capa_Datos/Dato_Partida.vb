Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Partida
    Public Function MostrarPartida(ByVal filtro As String) As List(Of Entidad_Partida)
        Dim lista As New List(Of Entidad_Partida)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarPartida", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Partida
                reg.numero_partida = dr.GetValue(0).ToString
                reg.tipo = dr.GetValue(1).ToString
                reg.fecha = dr.GetValue(2).ToString
                reg.concepto = dr.GetValue(3).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    'Para Agregar una Nueva 
    Public Sub Nueva_Partida(ByVal registros As Entidad_Partida)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevaPartida", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@numero_partida", registros.numero_partida)
                    .AddWithValue("@tipo", registros.tipo)
                    .AddWithValue("@fecha", registros.fecha)
                    .AddWithValue("@concepto", registros.concepto)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using

    End Sub

    'Para Modificar una 

    Public Sub Modificar_Partida(ByVal registros As Entidad_Partida)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarPartida", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@numero_partida", registros.numero_partida)
                    .AddWithValue("@tipo", registros.tipo)
                    .AddWithValue("@fecha", registros.fecha)
                    .AddWithValue("@concepto", registros.concepto)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar 

    Public Sub Eliminar_Partida(ByVal registros As Entidad_Partida)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminaPartida", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@numero_partida", registros.numero_partida)

                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    Public Function verifica(ByVal filtro As String) As List(Of Entidad_Partida)
        Dim lista As New List(Of Entidad_Partida)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarPartida", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Partida
                reg.numero_partida = dr.GetValue(0).ToString
                reg.tipo = dr.GetValue(1).ToString
                reg.fecha = dr.GetValue(2).ToString
                reg.concepto = dr.GetValue(3).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function


    Public Function Libro_Diario(ByVal filtro As String, filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String, filtro6 As String) As List(Of Entidad_Libro_Diario)
        Dim lista As New List(Of Entidad_Libro_Diario)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_Libro_Diario", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@fecha", filtro)
            cmd.Parameters.AddWithValue("@partida", filtro1)
            cmd.Parameters.AddWithValue("@tipo", filtro2)
            cmd.Parameters.AddWithValue("@cuenta", filtro3)
            cmd.Parameters.AddWithValue("@sucursal", filtro4)
            cmd.Parameters.AddWithValue("@anio", filtro6)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Libro_Diario
                reg.Partida = dr.GetValue(0).ToString
                reg.Fecha = dr.GetValue(1).ToString
                reg.tipo = dr.GetValue(2).ToString
                reg.concepto = dr.GetValue(3).ToString
                reg.cuenta_contable = dr.GetValue(4).ToString
                reg.nombre_cuenta = dr.GetValue(5).ToString
                reg.idsucursal = dr.GetValue(6).ToString
                reg.nombreSucursal = dr.GetValue(7).ToString
                reg.debe = dr.GetValue(8).ToString
                reg.haber = dr.GetValue(9).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    Public Function Libro_Mayor(ByVal filtro As String, filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String, filtro6 As String) As List(Of Entidad_Libro_Mayor)
        Dim lista As New List(Of Entidad_Libro_Mayor)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_Libro_Mayor", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@fecha", filtro)
            cmd.Parameters.AddWithValue("@cuenta", filtro1)
            cmd.Parameters.AddWithValue("@sucursal", filtro2)
            cmd.Parameters.AddWithValue("@anio", filtro6)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Libro_Mayor
                reg.cuenta_contable = dr.GetValue(0).ToString
                reg.nombre_cuenta = dr.GetValue(1).ToString
                reg.idsucursal = dr.GetValue(2).ToString
                reg.nombreSucursal = dr.GetValue(3).ToString
                reg.Partida = dr.GetValue(4).ToString
                reg.Fecha = dr.GetValue(5).ToString
                reg.tipo = dr.GetValue(6).ToString
                reg.concepto = dr.GetValue(7).ToString
                reg.debe = Format(dr.GetValue(8), "#.00")
                reg.haber = Format(dr.GetValue(9), "#.00")
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    Public Function Libro_Balance_Saldos(ByVal filtro1 As String, filtro2 As String, filtro3 As String, filtro4 As String) As List(Of Entidad_Libro_Balance_Saldos)
        Dim lista As New List(Of Entidad_Libro_Balance_Saldos)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_Libro_Balance_Saldos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@fecha", filtro3)
            cmd.Parameters.AddWithValue("@cuenta", filtro1)
            cmd.Parameters.AddWithValue("@sucursal", filtro2)
            cmd.Parameters.AddWithValue("@anio", filtro4)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Libro_Balance_Saldos
                reg.cuenta_contable = dr.GetValue(0).ToString
                reg.nombre_cuenta = dr.GetValue(1).ToString
                reg.idsucursal = dr.GetValue(2).ToString
                reg.nombreSucursal = dr.GetValue(3).ToString
                If IsDBNull(dr.GetValue(4)) Then
                    reg.anterior = Format(0, "#.00")
                Else
                    reg.anterior = Format(dr.GetValue(4), "#.00")
                End If
                If IsDBNull(dr.GetValue(5)) Then
                    reg.debe = Format(0, "#.00")
                Else
                    reg.debe = Format(dr.GetValue(5), "#.00")
                End If
                If IsDBNull(dr.GetValue(6)) Then
                    reg.haber = Format(0, "#.00")
                Else
                    reg.haber = Format(dr.GetValue(6), "#.00")
                End If
                If IsDBNull(dr.GetValue(7)) Then
                    reg.actual = Format(0, "#.00")
                Else
                    reg.actual = Format(dr.GetValue(7), "#.00")
                End If
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

End Class
