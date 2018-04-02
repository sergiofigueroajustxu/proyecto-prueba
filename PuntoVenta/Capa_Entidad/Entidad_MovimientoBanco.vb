Public Class Entidad_MovimientoBanco
    Private _correlativo As String
    Public Property correlativo() As String
        Get
            Return _correlativo
        End Get
        Set(ByVal value As String)
            _correlativo = value
        End Set
    End Property

    Private _idbanco As Integer
    Public Property idbanco() As Integer
        Get
            Return _idbanco
        End Get
        Set(ByVal value As Integer)
            _idbanco = value
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


    Private _fecha As Date
    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property


    Private _valor_deposito As Double
    Public Property valor_deposito() As Double
        Get
            Return _valor_deposito
        End Get
        Set(ByVal value As Double)
            _valor_deposito = value
        End Set
    End Property

    Private _valor_retiro As Double
    Public Property valor_retiro() As Double
        Get
            Return _valor_retiro
        End Get
        Set(ByVal value As Double)
            _valor_retiro = value
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

    Private _cuenta_contable As String
    Public Property cuenta_contable() As String
        Get
            Return _cuenta_contable
        End Get
        Set(ByVal value As String)
            _cuenta_contable = value
        End Set
    End Property
    Private _agencia As String
    Public Property agencia() As String
        Get
            Return _agencia
        End Get
        Set(ByVal value As String)
            _agencia = value
        End Set
    End Property
End Class
