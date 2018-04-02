Public Class Entidad_Transporte
    Private _idtransporte As Integer
    Public Property idtransporte() As Integer
        Get
            Return _idtransporte
        End Get
        Set(ByVal value As Integer)
            _idtransporte = value
        End Set
    End Property
    Private _numero_placa As String
    Public Property numero_placa() As String
        Get
            Return _numero_placa
        End Get
        Set(ByVal value As String)
            _numero_placa = value
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

    Private _telefono As String
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _direccion As String
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _codigo_empleado As String
    Public Property codigo_empleado() As String
        Get
            Return _codigo_empleado
        End Get
        Set(ByVal value As String)
            _codigo_empleado = value
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
    Private _km_vehiculo As Double
    Public Property km_vehiculo() As Double
        Get
            Return _km_vehiculo
        End Get
        Set(ByVal value As Double)
            _km_vehiculo = value
        End Set
    End Property
    Private _valor_km As Double
    Public Property valor_km() As Double
        Get
            Return _valor_km
        End Get
        Set(ByVal value As Double)
            _valor_km = value
        End Set
    End Property
    Private _fecha_inicio As Date
    Public Property fecha_inicio() As Date
        Get
            Return _fecha_inicio
        End Get
        Set(ByVal value As Date)
            _fecha_inicio = value
        End Set
    End Property
End Class
