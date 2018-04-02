Imports System.Data.SqlClient
Imports Capa_Entidad
Imports System.Data

Public Class Dato_Producto
    Public Function Mostrarproducto(ByVal idcategoria As Integer, idproveedor As Integer) As List(Of Entidad_Producto)
        Dim lista As New List(Of Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_producto", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idcategoria", idcategoria)
            cmd.Parameters.AddWithValue("@idproveedor", idproveedor)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Producto
                reg.idproducto = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.idcategoria = dr.GetValue(2).ToString
                reg.precio = dr.GetValue(3).ToString
                reg.stock = dr.GetValue(4).ToString
                reg.foto = dr.GetValue(5).ToString
                reg.idproveedor = dr.GetValue(6).ToString
                reg.costo_promedio = dr.GetValue(7).ToString
                reg.precio_minimo = dr.GetValue(8).ToString
                reg.iva_unidad = dr.GetValue(9).ToString
                reg.idp_unidad = dr.GetValue(10).ToString
                reg.otros_imp = dr.GetValue(11).ToString
                reg.saldo_minimo = dr.GetValue(12).ToString
                reg.codigo_barra = dr.GetValue(13).ToString
                reg.precio_bien = dr.GetValue(7).ToString
                reg.cuenta_inventario = dr.GetValue(8).ToString
                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function

    Public Function preciostock(ByVal id As Integer) As List(Of Entidad_Producto)
        Dim lista As New List(Of Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_preciostock", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idproducto", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Producto
                reg.precio = dr.GetValue(0).ToString
                reg.stock = dr.GetValue(1).ToString
                reg.precio_bien = dr.GetValue(2).ToString
                reg.costo_promedio = dr.GetValue(3).ToString
                reg.precio_minimo = dr.GetValue(4).ToString
                reg.iva_unidad = dr.GetValue(5).ToString
                reg.idp_unidad = dr.GetValue(6).ToString
                reg.otros_imp = dr.GetValue(7).ToString
                reg.nombre = dr.GetValue(8).ToString
                reg.foto = dr.GetValue(9).ToString
                reg.codigo_barra = dr.GetValue(10).ToString
                reg.cuenta_inventario = dr.GetValue(11).ToString
                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function

    'Metodo para Actualizar Stock en las ventas '
    Public Sub Actualiza_Stock(ByVal registros As Entidad_Producto, tipoventa As Integer)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("actualizastock", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@stock", registros.stock)
                    .AddWithValue("@idproducto", registros.idproducto)
                    .AddWithValue("@tipoventa", tipoventa)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub

    'Metodo que actualiza el stock en las compras'
    Public Sub Actualiza_StockCompras(ByVal registros As Entidad_Producto, preciocompra As Double, tipocompra As Integer)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_actualizastockcompra", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@stock", registros.stock)
                    .AddWithValue("@idproducto", registros.idproducto)
                    .AddWithValue("@preciocompra", preciocompra)
                    .AddWithValue("@tipocompra", tipocompra)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub


    'Mostrar todos los productos'

    Public Function Mostrartodosproductos(ByVal filtro As String) As List(Of Entidad_Producto)

        Dim lista As New List(Of Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_mostrartodoproductos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombreproveedor", filtro)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Producto
                reg.idproducto = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.idcategoria = dr.GetValue(2).ToString()
                reg.precio = dr.GetValue(3).ToString()
                reg.stock = dr.GetValue(4).ToString()
                reg.foto = dr.GetValue(5).ToString()
                reg.idproveedor = dr.GetValue(6).ToString
                reg.costo_promedio = dr.GetValue(7).ToString()
                reg.precio_minimo = dr.GetValue(8).ToString()
                reg.iva_unidad = dr.GetValue(9).ToString()
                reg.idp_unidad = dr.GetValue(10).ToString()
                reg.otros_imp = dr.GetValue(11).ToString()
                reg.saldo_minimo = dr.GetValue(12).ToString()
                reg.codigo_barra = dr.GetValue(13).ToString()
                reg.cuenta_inventario = dr.GetValue(14).ToString
                reg.precio_bien = dr.GetValue(7).ToString()
                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function

    'Metodo para mostrar productos que tengan stock menor a 3'

    Public Function productos_pa_comprar() As List(Of Entidad_Producto)
        Dim lista As New List(Of Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("productos_pa_comprar", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Producto
                reg.nombre = dr.GetValue(0).ToString()
                reg.stock = IIf(dr.GetValue(1).ToString() = "", 0, dr.GetValue(1).ToString)
                reg.foto = dr.GetValue(2).ToString()
                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function

    'Metodo para buscartodoproducto sin importar la categoria'

    Public Function buscartodoproducto(ByVal nombre As String) As List(Of Entidad_Producto)
        Dim lista As New List(Of Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_buscartodoproducto", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombre", nombre)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Producto
                reg.idproducto = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.idcategoria = dr.GetValue(2).ToString()
                reg.precio = dr.GetValue(3).ToString()
                reg.stock = dr.GetValue(4).ToString()
                reg.foto = dr.GetValue(5).ToString()
                reg.idproveedor = dr.GetValue(6).ToString
                reg.costo_promedio = dr.GetValue(7).ToString()
                reg.precio_minimo = dr.GetValue(8).ToString()
                reg.iva_unidad = dr.GetValue(9).ToString()
                reg.idp_unidad = dr.GetValue(10).ToString()
                reg.otros_imp = dr.GetValue(11).ToString()
                reg.saldo_minimo = dr.GetValue(12).ToString()
                reg.codigo_barra = dr.GetValue(13).ToString()
                reg.cuenta_inventario = dr.GetValue(14).ToString
                reg.precio_bien = dr.GetValue(7).ToString()

                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function

    Public Function buscartodoproductoproveedor(ByVal idproveedor As String) As List(Of Entidad_Producto)
        Dim lista As New List(Of Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_buscartodoproductoproveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idproveedor", idproveedor)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Producto
                reg.idproducto = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.idcategoria = dr.GetValue(2).ToString()
                reg.precio = dr.GetValue(3).ToString()
                reg.stock = dr.GetValue(4).ToString()
                reg.foto = dr.GetValue(5).ToString()
                reg.idproveedor = dr.GetValue(6).ToString
                reg.costo_promedio = dr.GetValue(7).ToString()
                reg.precio_minimo = dr.GetValue(8).ToString()
                reg.iva_unidad = dr.GetValue(9).ToString()
                reg.idp_unidad = dr.GetValue(10).ToString()
                reg.otros_imp = dr.GetValue(11).ToString()
                reg.saldo_minimo = dr.GetValue(12).ToString()
                reg.codigo_barra = dr.GetValue(13).ToString()
                reg.precio_bien = dr.GetValue(7).ToString()
                reg.cuenta_inventario = dr.GetValue(14).ToString

                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function


    Public Function buscarnomycat(ByVal nombre As String, ByVal id As Integer) As List(Of Entidad_Producto)
        Dim lista As New List(Of Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_buscarnomycat", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@idcategoria", id)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Producto
                reg.idproducto = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.idcategoria = dr.GetValue(2).ToString()
                reg.precio = dr.GetValue(3).ToString()
                reg.stock = dr.GetValue(4).ToString()
                reg.foto = dr.GetValue(5).ToString()
                reg.idproveedor = dr.GetValue(6).ToString
                reg.costo_promedio = dr.GetValue(7).ToString()
                reg.precio_minimo = dr.GetValue(8).ToString()
                reg.iva_unidad = dr.GetValue(9).ToString()
                reg.idp_unidad = dr.GetValue(10).ToString()
                reg.otros_imp = dr.GetValue(11).ToString()
                reg.saldo_minimo = dr.GetValue(12).ToString()
                reg.codigo_barra = dr.GetValue(13).ToString()
                reg.cuenta_inventario = dr.GetValue(14).ToString
                reg.precio_bien = dr.GetValue(7).ToString()
                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function
    Public Function buscarnomycatproveedor(ByVal nombre As String, ByVal id As Integer, ByVal idPrv As Integer) As List(Of Entidad_Producto)
        Dim lista As New List(Of Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_buscarnomycatproveedor", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@idcategoria", id)
            cmd.Parameters.AddWithValue("@idproveedor", idPrv)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Dim reg As New Entidad_Producto
                reg.idproducto = dr.GetValue(0).ToString
                reg.nombre = dr.GetValue(1).ToString()
                reg.idcategoria = dr.GetValue(2).ToString()
                reg.precio = dr.GetValue(3).ToString()
                reg.stock = dr.GetValue(4).ToString()
                reg.foto = dr.GetValue(5).ToString()
                reg.idproveedor = dr.GetValue(6).ToString
                reg.costo_promedio = dr.GetValue(7).ToString()
                reg.precio_minimo = dr.GetValue(8).ToString()
                reg.iva_unidad = dr.GetValue(9).ToString()
                reg.idp_unidad = dr.GetValue(10).ToString()
                reg.otros_imp = dr.GetValue(11).ToString()
                reg.saldo_minimo = dr.GetValue(12).ToString()
                reg.codigo_barra = dr.GetValue(13).ToString()
                reg.cuenta_inventario = dr.GetValue(14).ToString
                reg.precio_bien = dr.GetValue(7).ToString()
                lista.Add(reg)
            End While
            dr.Close()
            cnn.Dispose()
            cnn.Close()
        End Using
        Return lista
    End Function

    'Agregar Nuevo Producto'
    Public Sub Agregar_Producto(ByVal registros As Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_nuevoproducto", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@idcategoria", registros.idcategoria)
                    .AddWithValue("@precio", registros.precio)
                    .AddWithValue("@stock", registros.stock)
                    .AddWithValue("@idproveedor", registros.idproveedor)
                    .AddWithValue("@foto", registros.foto)
                    .AddWithValue("@costo_promedio", registros.costo_promedio)
                    .AddWithValue("@precio_minimo", registros.precio_minimo)
                    .AddWithValue("@iva_unidad", registros.iva_unidad)
                    .AddWithValue("@idp_unidad", registros.idp_unidad)
                    .AddWithValue("@otros_imp", registros.otros_imp)
                    .AddWithValue("@saldo_minimo", registros.saldo_minimo)
                    .AddWithValue("@codigo_barra", registros.codigo_barra)
                    .AddWithValue("@cuenta_inventario", registros.cuenta_inventario)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub

    'Para modificar un producto'
    Public Sub modificar_producto(ByVal registros As Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_modificarproducto", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("idproducto", registros.idproducto)
                    .AddWithValue("@nombre", registros.nombre)
                    .AddWithValue("@idcategoria", registros.idcategoria)
                    .AddWithValue("@precio", registros.precio)
                    .AddWithValue("@stock", registros.stock)
                    .AddWithValue("@idproveedor", registros.idproveedor)
                    .AddWithValue("@foto", registros.foto)
                    .AddWithValue("@costo_promedio", registros.costo_promedio)
                    .AddWithValue("@precio_minimo", registros.precio_minimo)
                    .AddWithValue("@iva_unidad", registros.iva_unidad)
                    .AddWithValue("@idp_unidad", registros.idp_unidad)
                    .AddWithValue("@otros_imp", registros.otros_imp)
                    .AddWithValue("@saldo_minimo", registros.saldo_minimo)
                    .AddWithValue("@codigo_barra", registros.codigo_barra)
                    .AddWithValue("@cuenta_inventario", registros.cuenta_inventario)
                End With
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("No se guardo el registro")
            End Try
            cnn.Dispose()
            cnn.Close()
        End Using
    End Sub


    'Para saber cuantos productos es que hay'

    Public Function contarproductos() As Integer
        Dim logeo As Integer
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("maxproductos", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
            cmd.ExecuteNonQuery()
            logeo = CType(cmd.Parameters.Item("@RETURN_VALUE").Value, Integer)
            cnn.Dispose()
            cnn.Close()
        End Using

        Return logeo

    End Function

    Public Function contarproductosporfiltro(ByVal nombre As String) As Integer
        Dim logeo As Integer
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_contarproductosporfiltro", cnn)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
            cmd.ExecuteNonQuery()
            logeo = CType(cmd.Parameters.Item("@RETURN_VALUE").Value, Integer)
            cnn.Dispose()
            cnn.Close()
        End Using
        Return logeo
    End Function


    Public Function contarproductosporcategoria(ByVal id As Integer, idproveedor As Integer) As Integer
        Dim logeo As Integer
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_contarproductosporcategoria", cnn)
            cmd.Parameters.AddWithValue("@idcategoria", id)
            cmd.Parameters.AddWithValue("@idproveedor", idproveedor)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
            cmd.ExecuteNonQuery()
            logeo = CType(cmd.Parameters.Item("@RETURN_VALUE").Value, Integer)
            cnn.Dispose()
            cnn.Close()
        End Using
        Return logeo
    End Function

    'cuenta los productos que hay en cierta categoria segun su nombre'
    Public Function contarproductospornombreycategoria(ByVal nombre As String, ByVal id As Integer) As Integer
        Dim logeo As Integer
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()
            Dim cmd As New SqlCommand("p_contarnomycate", cnn)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@idcategoria", id)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
            cmd.ExecuteNonQuery()
            logeo = CType(cmd.Parameters.Item("@RETURN_VALUE").Value, Integer)
            cnn.Dispose()
            cnn.Close()
        End Using
        Return logeo
    End Function
    'Para Eliminar un Productor'

    Public Sub Eliminar_Producto(ByVal registros As Entidad_Producto)
        Using cnn As New SqlConnection(My.Settings.cnn)
            cnn.Open()

            Dim cmd As New SqlCommand("p_eliminaproducto", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            Try
                With cmd.Parameters
                    .AddWithValue("@idproducto", registros.idproducto)

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
