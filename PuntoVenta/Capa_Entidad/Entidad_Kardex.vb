Public Class Entidad_Kardex

    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Private _idfactura As String
    Public Property idfactura() As String
        Get
            Return _idfactura
        End Get
        Set(ByVal value As String)
            _idfactura = value
        End Set
    End Property

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

    Private _costo As Double
    Public Property costo() As Double
        Get
            Return _costo
        End Get
        Set(ByVal value As Double)
            _costo = value
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

    Private _compra As Double
    Public Property compra() As Double
        Get
            Return _compra
        End Get
        Set(ByVal value As Double)
            _compra = value
        End Set
    End Property
    Private _venta As Double
    Public Property venta() As Double
        Get
            Return _venta
        End Get
        Set(ByVal value As Double)
            _venta = value
        End Set
    End Property


    Private _idcliente As String
    Public Property idcliente() As String
        Get
            Return _idcliente
        End Get
        Set(ByVal value As String)
            _idcliente = value
        End Set
    End Property

    Private _idempleado As String
    Public Property idempleado() As String
        Get
            Return _idempleado
        End Get
        Set(ByVal value As String)
            _idempleado = value
        End Set
    End Property

    Private _idtipoventa As String
    Public Property idtipoventa() As String
        Get
            Return _idtipoventa
        End Get
        Set(ByVal value As String)
            _idtipoventa = value
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
    Private _idproveedor As String
    Public Property idproveedor() As String
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As String)
            _idproveedor = value
        End Set
    End Property

End Class
