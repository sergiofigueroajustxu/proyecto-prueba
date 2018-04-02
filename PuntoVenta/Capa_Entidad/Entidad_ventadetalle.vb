Public Class Entidad_ventadetalle
    Private _idventa As Integer
    Public Property idventa() As Integer
        Get
            Return _idventa
        End Get
        Set(ByVal value As Integer)
            _idventa = value
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

    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
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
    Private _precio_servicio As Double
    Public Property precio_servicio() As Double
        Get
            Return _precio_servicio
        End Get
        Set(ByVal value As Double)
            _precio_servicio = value
        End Set
    End Property
    Private _precio_exento As Double
    Public Property precio_exento() As Double
        Get
            Return _precio_exento
        End Get
        Set(ByVal value As Double)
            _precio_exento = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _cancelado As Integer
    Public Property cancelado() As Integer
        Get
            Return _cancelado
        End Get
        Set(ByVal value As Integer)
            _cancelado = value
        End Set
    End Property
    Private _valor As Double
    Public Property valor() As Double
        Get
            Return _valor
        End Get
        Set(ByVal value As Double)
            _valor = value
        End Set
    End Property


    Private _importe As Double
    Public Property importe() As Double
        Get
            Return _importe
        End Get
        Set(ByVal value As Double)
            _importe = value
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

    Private _nombreproducto As String
    Public Property nombreproducto() As String
        Get
            Return _nombreproducto
        End Get
        Set(ByVal value As String)
            _nombreproducto = value
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

    Private _codigo_barra As String
    Public Property codigo_barra() As String
        Get
            Return _codigo_barra
        End Get
        Set(ByVal value As String)
            _codigo_barra = value
        End Set
    End Property


End Class
