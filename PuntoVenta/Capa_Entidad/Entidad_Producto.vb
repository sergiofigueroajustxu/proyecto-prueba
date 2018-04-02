Public Class Entidad_Producto
    Private _idproducto As Integer
    Public Property idproducto() As Integer
        Get
            Return _idproducto
        End Get
        Set(ByVal value As Integer)
            _idproducto = value
        End Set
    End Property

    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _idcategoria As Integer
    Public Property idcategoria() As Integer
        Get
            Return _idcategoria
        End Get
        Set(ByVal value As Integer)
            _idcategoria = value
        End Set
    End Property


    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property


    Private _stock As Integer
    Public Property stock() As Integer
        Get
            Return _stock
        End Get
        Set(ByVal value As Integer)
            _stock = value
        End Set
    End Property

    Private _foto As String
    Public Property foto() As String
        Get
            Return _foto
        End Get
        Set(ByVal value As String)
            _foto = value
        End Set
    End Property

    Private _idproveedor As Integer
    Public Property idproveedor() As Integer
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As Integer)
            _idproveedor = value
        End Set
    End Property

    Private _precio_bien As Double
    Public Property precio_bien() As Double
        Get
            Return _precio_bien
        End Get
        Set(ByVal value As Double)
            _precio_bien = value
        End Set
    End Property

    Private _costo_promedio As Double
    Public Property costo_promedio() As Double
        Get
            Return _costo_promedio
        End Get
        Set(ByVal value As Double)
            _costo_promedio = value
        End Set
    End Property

    Private _precio_minimo As Double
    Public Property precio_minimo() As Double
        Get
            Return _precio_minimo
        End Get
        Set(ByVal value As Double)
            _precio_minimo = value
        End Set
    End Property

    Private _iva_unidad As Double
    Public Property iva_unidad() As Double
        Get
            Return _iva_unidad
        End Get
        Set(ByVal value As Double)
            _iva_unidad = value
        End Set
    End Property

    Private _idp_unidad As Double
    Public Property idp_unidad() As Double
        Get
            Return _idp_unidad
        End Get
        Set(ByVal value As Double)
            _idp_unidad = value
        End Set
    End Property

    Private _otros_imp As Double
    Public Property otros_imp() As Double
        Get
            Return _otros_imp
        End Get
        Set(ByVal value As Double)
            _otros_imp = value
        End Set
    End Property

    Private _saldo_minimo As Double
    Public Property saldo_minimo() As Double
        Get
            Return _saldo_minimo
        End Get
        Set(ByVal value As Double)
            _saldo_minimo = value
        End Set
    End Property

    Private _codigo_barra As String
    Public Property codigo_barra() As String
        Get
            Return _codigo_barra
        End Get
        Set(ByVal value As String)
            _codigo_barra = value
        End Set
    End Property

    Private _cuenta_inventario As String
    Public Property cuenta_inventario() As String
        Get
            Return _cuenta_inventario
        End Get
        Set(ByVal value As String)
            _cuenta_inventario = value
        End Set
    End Property
End Class
