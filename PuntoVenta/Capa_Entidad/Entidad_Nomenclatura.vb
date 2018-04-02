Public Class Entidad_Nomenclatura
    Private _cuenta As String
    Public Property cuenta() As String
        Get
            Return _cuenta
        End Get
        Set(ByVal value As String)
            _cuenta = value
        End Set
    End Property
    Private _nivel As Integer
    Public Property nivel() As Integer
        Get
            Return _nivel
        End Get
        Set(ByVal value As Integer)
            _nivel = value
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

    Private _padre As String
    Public Property padre() As String
        Get
            Return _padre
        End Get
        Set(ByVal value As String)
            _padre = value
        End Set
    End Property


    Private _flujo_efectivo As String
    Public Property flujo_efectivo() As String
        Get
            Return _flujo_efectivo
        End Get
        Set(ByVal value As String)
            _flujo_efectivo = value
        End Set
    End Property

    Private _en_polizas As Integer
    Public Property en_polizas() As Integer
        Get
            Return _en_polizas
        End Get
        Set(ByVal value As Integer)
            _en_polizas = value
        End Set
    End Property

    Private _es_gasto_bien As Integer
    Public Property es_gasto_bien() As Integer
        Get
            Return _es_gasto_bien
        End Get
        Set(ByVal value As Integer)
            _es_gasto_bien = value
        End Set
    End Property

    Private _es_gasto_servicio As Integer
    Public Property es_gasto_servicio() As Integer
        Get
            Return _es_gasto_servicio
        End Get
        Set(ByVal value As Integer)
            _es_gasto_servicio = value
        End Set
    End Property
    Private _saldo_anterior As Double
    Public Property saldo_anterior() As Integer
        Get
            Return _saldo_anterior
        End Get
        Set(ByVal value As Integer)
            _saldo_anterior = value
        End Set
    End Property
    Private _saldo_actual As Double
    Public Property saldo_actual() As Integer
        Get
            Return _saldo_actual
        End Get
        Set(ByVal value As Integer)
            _saldo_actual = value
        End Set
    End Property
End Class
