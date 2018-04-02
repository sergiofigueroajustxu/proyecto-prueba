Public Class Entidad_Lote
    Private _idproducto As Integer
    Public Property idproducto() As Integer
        Get
            Return _idproducto
        End Get
        Set(ByVal value As Integer)
            _idproducto = value
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

    Private _saldo_lote As Integer
    Public Property saldo_lote() As Integer
        Get
            Return _saldo_lote
        End Get
        Set(ByVal value As Integer)
            _saldo_lote = value
        End Set
    End Property



End Class
