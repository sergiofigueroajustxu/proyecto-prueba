Public Class Entidad_Cobros
    Private _idcobros As Integer
    Public Property idcobros() As Integer
        Get
            Return _idcobros
        End Get
        Set(ByVal value As Integer)
            _idcobros = value
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

    Private _monto As Double
    Public Property monto() As Double
        Get
            Return _monto
        End Get
        Set(ByVal value As Double)
            _monto = value
        End Set
    End Property

    Private _fecha As String
    Public Property fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property

    Private _idbanco_caja As Integer
    Public Property idbanco_caja() As Integer
        Get
            Return _idbanco_caja
        End Get
        Set(ByVal value As Integer)
            _idbanco_caja = value
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
    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    Private _idautorizacion As String
    Public Property idautorizacion() As String
        Get
            Return _idautorizacion
        End Get
        Set(ByVal value As String)
            _idautorizacion = value
        End Set
    End Property

    Private _chkconciliado As Integer
    Public Property chkconciliado() As Integer
        Get
            Return _chkconciliado
        End Get
        Set(ByVal value As Integer)
            _chkconciliado = value
        End Set
    End Property


End Class
