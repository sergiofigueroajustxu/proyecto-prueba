Public Class Entidad_Partida_Detalle
    Private _numero_partida As String
    Public Property numero_partida() As String
        Get
            Return _numero_partida
        End Get
        Set(ByVal value As String)
            _numero_partida = value
        End Set
    End Property

    Private _idsucursal As String
    Public Property idsucursal() As String
        Get
            Return _idsucursal
        End Get
        Set(ByVal value As String)
            _idsucursal = value
        End Set
    End Property

    Private _item As Integer
    Public Property item() As Integer
        Get
            Return _item
        End Get
        Set(ByVal value As Integer)
            _item = value
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

    Private _debe As Double
    Public Property debe() As Double
        Get
            Return _debe
        End Get
        Set(ByVal value As Double)
            _debe = value
        End Set
    End Property

    Private _haber As Double
    Public Property haber() As Double
        Get
            Return _haber
        End Get
        Set(ByVal value As Double)
            _haber = value
        End Set
    End Property

End Class
