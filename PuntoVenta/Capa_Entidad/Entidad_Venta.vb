Public Class Entidad_Venta
    Private _idventa As Integer
    Public Property idventa() As Integer
        Get
            Return _idventa
        End Get
        Set(ByVal value As Integer)
            _idventa = value
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

    Private _idempleado As Integer
    Public Property idempleado() As Integer
        Get
            Return _idempleado
        End Get
        Set(ByVal value As Integer)
            _idempleado = value
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
    Private _fecha_vence As String
    Public Property fecha_vence() As String
        Get
            Return _fecha_vence
        End Get
        Set(ByVal value As String)
            _fecha_vence = value
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
    Private _idfactura As String
    Public Property idfactura() As String
        Get
            Return _idfactura
        End Get
        Set(ByVal value As String)
            _idfactura = value
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

    Private _tot_bien As Double
    Public Property tot_bien() As Double
        Get
            Return _tot_bien
        End Get
        Set(ByVal value As Double)
            _tot_bien = value
        End Set
    End Property

    Private _tot_servicio As Double
    Public Property tot_servicio() As Double
        Get
            Return _tot_servicio
        End Get
        Set(ByVal value As Double)
            _tot_servicio = value
        End Set
    End Property

    Private _tot_exenta As Double
    Public Property tot_exenta() As Double
        Get
            Return _tot_exenta
        End Get
        Set(ByVal value As Double)
            _tot_exenta = value
        End Set
    End Property

    Private _iva_bien As Double
    Public Property iva_bien() As Double
        Get
            Return _iva_bien
        End Get
        Set(ByVal value As Double)
            _iva_bien = value
        End Set
    End Property

    Private _iva_servicio As Double
    Public Property iva_servicio() As Double
        Get
            Return _iva_servicio
        End Get
        Set(ByVal value As Double)
            _iva_servicio = value
        End Set
    End Property

    Private _tot_documento As Double
    Public Property tot_documento() As Double
        Get
            Return _tot_documento
        End Get
        Set(ByVal value As Double)
            _tot_documento = value
        End Set
    End Property
    Private _nombre_cliente As String
    Public Property nombre_cliente() As String
        Get
            Return _nombre_cliente
        End Get
        Set(ByVal value As String)
            _nombre_cliente = value
        End Set
    End Property
End Class
