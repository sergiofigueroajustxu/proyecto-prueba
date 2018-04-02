Public Class Entidad_Compras
    Private _idcompra As Integer
    Public Property idcompra() As String
        Get
            Return _idcompra
        End Get
        Set(ByVal value As String)
            _idcompra = value
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

    Private _idtipocomprobante As Integer
    Public Property idtipocomprobante() As Integer
        Get
            Return _idtipocomprobante
        End Get
        Set(ByVal value As Integer)
            _idtipocomprobante = value
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

    Private _idproveedor As Integer
    Public Property idproveedor() As Integer
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As Integer)
            _idproveedor = value
        End Set
    End Property

    Private _importetotal As Double
    Public Property importetotal() As Double
        Get
            Return _importetotal
        End Get
        Set(ByVal value As Double)
            _importetotal = value
        End Set
    End Property

    Private _retencion As Double
    Public Property retencion() As Double
        Get
            Return _retencion
        End Get
        Set(ByVal value As Double)
            _retencion = value
        End Set
    End Property

    Private _contenedor As String
    Public Property contenedor() As String
        Get
            Return _contenedor
        End Get
        Set(ByVal value As String)
            _contenedor = value
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

    Private _nit As String
    Public Property nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property

    Private _cuenta_bien As String
    Public Property cuenta_bien() As String
        Get
            Return _cuenta_bien
        End Get
        Set(ByVal value As String)
            _cuenta_bien = value
        End Set
    End Property
    Private _cuenta_servicio As String
    Public Property cuenta_servicio() As String
        Get
            Return _cuenta_servicio
        End Get
        Set(ByVal value As String)
            _cuenta_servicio = value
        End Set
    End Property
    Private _compra_bien As Double
    Public Property compra_bien() As Double
        Get
            Return _compra_bien
        End Get
        Set(ByVal value As Double)
            _compra_bien = value
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
    Private _servicio As Double
    Public Property servicio() As Double
        Get
            Return _servicio
        End Get
        Set(ByVal value As Double)
            _servicio = value
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

    Private _exento As Double
    Public Property exento() As Double
        Get
            Return _exento
        End Get
        Set(ByVal value As Double)
            _exento = value
        End Set
    End Property
    Private _idp As Double
    Public Property idp() As Double
        Get
            Return _idp
        End Get
        Set(ByVal value As Double)
            _idp = value
        End Set
    End Property
End Class
