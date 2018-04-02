Public Class Entidad_Libro_Diario

    Private _fecha As Date
    Public Property Fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Private _partida As String
    Public Property Partida() As String
        Get
            Return _partida
        End Get
        Set(ByVal value As String)
            _partida = value
        End Set
    End Property


    Private _tipo As String
    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _concepto As String
    Public Property concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
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

    Private _nombre_cuenta As String
    Public Property nombre_cuenta() As String
        Get
            Return _nombre_cuenta
        End Get
        Set(ByVal value As String)
            _nombre_cuenta = value
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

    Private _nombreSucursal As String
    Public Property nombreSucursal() As String
        Get
            Return _nombreSucursal
        End Get
        Set(ByVal value As String)
            _nombreSucursal = value
        End Set
    End Property

End Class
