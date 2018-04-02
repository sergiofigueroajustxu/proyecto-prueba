Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data
Public Class Dato_Nomenclatura
    Public Function MostrarNomenclatura(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarNomenclatura", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Nomenclatura
                reg.cuenta = dr.GetValue(0).ToString
                reg.nivel = dr.GetValue(1).ToString
                reg.nombre = dr.GetValue(2).ToString
                reg.en_polizas = dr.GetValue(3).ToString
                reg.padre = dr.GetValue(4).ToString
                reg.flujo_efectivo = dr.GetValue(5).ToString
                reg.es_gasto_bien = dr.GetValue(6).ToString
                reg.es_gasto_servicio = dr.GetValue(7).ToString

                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    Public Function MostrarNomenclaturaCuenta(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarNomenclaturaCuenta", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Nomenclatura
                reg.cuenta = dr.GetValue(0).ToString
                reg.nivel = dr.GetValue(1).ToString
                reg.nombre = dr.GetValue(2).ToString
                reg.en_polizas = dr.GetValue(3).ToString
                reg.padre = dr.GetValue(4).ToString
                reg.flujo_efectivo = dr.GetValue(5).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    Public Function MostrarNomenclaturaGastos(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarNomenclaturaGastos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Nomenclatura
                reg.cuenta = dr.GetValue(0).ToString
                reg.nivel = dr.GetValue(1).ToString
                reg.nombre = dr.GetValue(2).ToString
                reg.en_polizas = dr.GetValue(3).ToString
                reg.padre = dr.GetValue(4).ToString
                reg.flujo_efectivo = dr.GetValue(5).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    Public Function MostrarNomenclaturaServicios(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarNomenclaturaServicios", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Nomenclatura
                reg.cuenta = dr.GetValue(0).ToString
                reg.nivel = dr.GetValue(1).ToString
                reg.nombre = dr.GetValue(2).ToString
                reg.en_polizas = dr.GetValue(3).ToString
                reg.padre = dr.GetValue(4).ToString
                reg.flujo_efectivo = dr.GetValue(5).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    Public Function MostrarNomenclaturaIngresos(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarNomenclaturaIngresos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Nomenclatura
                reg.cuenta = dr.GetValue(0).ToString
                reg.nivel = dr.GetValue(1).ToString
                reg.nombre = dr.GetValue(2).ToString
                reg.en_polizas = dr.GetValue(3).ToString
                reg.padre = dr.GetValue(4).ToString
                reg.flujo_efectivo = dr.GetValue(5).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function
    Public Function MostrarNomenclaturaEgresos(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarNomenclaturaEgresos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Nomenclatura
                reg.cuenta = dr.GetValue(0).ToString
                reg.nivel = dr.GetValue(1).ToString
                reg.nombre = dr.GetValue(2).ToString
                reg.en_polizas = dr.GetValue(3).ToString
                reg.padre = dr.GetValue(4).ToString
                reg.flujo_efectivo = dr.GetValue(5).ToString
                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function

    Public Function MostrarNomenclaturaSaldos(ByVal filtro As String, fecha As String, anio As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrarNomenclaturaSaldos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@filtro", filtro)
            cmd.Parameters.AddWithValue("@fecha", fecha)
            cmd.Parameters.AddWithValue("@anio", anio)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read

                Dim reg As New Entidad_Nomenclatura
                reg.cuenta = dr.GetValue(0).ToString
                reg.nivel = dr.GetValue(1).ToString
                reg.nombre = dr.GetValue(2).ToString
                reg.en_polizas = dr.GetValue(3).ToString
                reg.padre = dr.GetValue(4).ToString
                reg.flujo_efectivo = dr.GetValue(5).ToString
                reg.es_gasto_bien = dr.GetValue(6).ToString
                reg.es_gasto_servicio = dr.GetValue(7).ToString
                reg.saldo_anterior = dr.GetValue(8).ToString
                reg.saldo_actual = dr.GetValue(9).ToString

                lista.Add(reg)
            End While
            dr.Close()
        End Using
        Return lista
    End Function


    'Para Agregar una Nueva 
    Public Sub Nueva_Nomenclatura(ByVal registros As Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevaNomenclatura", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@cuenta", registros.cuenta)
                    .AddWithValue("@nivel", registros.nivel)
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@en_polizas", registros.en_polizas)
                    .AddWithValue("@padre", registros.padre)
                    .AddWithValue("@flujo_efectivo", registros.flujo_efectivo)
                    .AddWithValue("@es_gasto_bien", registros.es_gasto_bien)
                    .AddWithValue("@es_gasto_servicio", registros.es_gasto_servicio)
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

    Public Sub Modificar_Nomenclatura(ByVal registros As Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarNomenclatura", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@cuenta", registros.cuenta)
                .AddWithValue("@nivel", registros.nivel)
                .AddWithValue("@nombre", registros.nombre)
                .AddWithValue("@en_polizas", registros.en_polizas)
                .AddWithValue("@padre", registros.padre)
                .AddWithValue("@flujo_efectivo", registros.flujo_efectivo)
                .AddWithValue("@es_gasto_bien", registros.es_gasto_bien)
                .AddWithValue("@es_gasto_servicio", registros.es_gasto_servicio)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub

    'Para Eliminar 

    Public Sub Eliminar_Nomenclatura(ByVal registros As Entidad_Nomenclatura)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminaNomenclatura", cnn)
            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .AddWithValue("@cuenta", registros.cuenta)
            End With
            cmd.ExecuteNonQuery()
            cnn.Close()
            cnn.Dispose()
        End Using
    End Sub
End Class
