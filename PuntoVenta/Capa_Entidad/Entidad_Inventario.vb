Public Class Entidad_Inventario


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

    Private _ingreso As Double
    Public Property ingreso() As Double
        Get
            Return _ingreso
        End Get
        Set(ByVal value As Double)
            _ingreso = value
        End Set
    End Property

    Private _egreso As Double
    Public Property egreso() As Double
        Get
            Return _egreso
        End Get
        Set(ByVal value As Double)
            _egreso = value
        End Set
    End Property
    Private _saldo As Double
    Public Property saldo() As Double
        Get
            Return _saldo
        End Get
        Set(ByVal value As Double)
            _saldo = value
        End Set
    End Property

    Private _sucursal As String
    Public Property sucursal() As String
        Get
            Return _sucursal
        End Get
        Set(ByVal value As String)
            _sucursal = value
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
    Private _costo_promedio As Double
    Public Property costo_promedio() As Double
        Get
            Return _costo_promedio
        End Get
        Set(ByVal value As Double)
            _costo_promedio = value
        End Set
    End Property
    Private _categoria As String
    Public Property categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
        End Set
    End Property
    Private _proveedor As String
    Public Property proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
End Class
