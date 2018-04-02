Public Class Entidad_Compra_Detalles
    Private _idcompra As Integer
    Public Property idcompra() As Integer
        Get
            Return _idcompra
        End Get
        Set(ByVal value As Integer)
            _idcompra = value
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

    Private _importe As Double
    Public Property importe() As Double
        Get
            Return _importe
        End Get
        Set(ByVal value As Double)
            _importe = value
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
    Private _lote As String
    Public Property lote() As String
        Get
            Return _lote
        End Get
        Set(ByVal value As String)
            _lote = value
        End Set
    End Property
    Private _vence As String
    Public Property vence() As String
        Get
            Return _vence
        End Get
        Set(ByVal value As String)
            _vence = value
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
