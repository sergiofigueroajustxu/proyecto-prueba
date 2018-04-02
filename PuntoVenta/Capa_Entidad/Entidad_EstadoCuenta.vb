Public Class Entidad_EstadoCuenta

    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
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


    Private _saldo As Double
    Public Property saldo() As Double
        Get
            Return _saldo
        End Get
        Set(ByVal value As Double)
            _saldo = value
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


    Private _correlativo As String
    Public Property correlativo() As String
        Get
            Return _correlativo
        End Get
        Set(ByVal value As String)
            _correlativo = value
        End Set
    End Property

    Private _idcliente As Integer
    Public Property idcliente() As Integer
        Get
            Return _idcliente
        End Get
        Set(ByVal value As Integer)
            _idcliente = value
        End Set
    End Property

    Private _cliente As String
    Public Property cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
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

    Private _compra As Double
    Public Property compra() As Double
        Get
            Return _compra
        End Get
        Set(ByVal value As Double)
            _compra = value
        End Set
    End Property



    Private _montopagado As Double
    Public Property montopagado() As Double
        Get
            Return _montopagado
        End Get
        Set(ByVal value As Double)
            _montopagado = value
        End Set
    End Property

    Private _montocobrado As Double
    Public Property montocobrado() As Double
        Get
            Return _montocobrado
        End Get
        Set(ByVal value As Double)
            _montocobrado = value
        End Set
    End Property




    Private _idtipoventa As Integer
    Public Property idtipoventa() As Integer
        Get
            Return _idtipoventa
        End Get
        Set(ByVal value As Integer)
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


End Class
