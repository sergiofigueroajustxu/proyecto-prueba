Public Class Entidad_Libro_Compra


    Private _idfactura As String
    Public Property Factura() As String
        Get
            Return _idfactura
        End Get
        Set(ByVal value As String)
            _idfactura = value
        End Set
    End Property

    Private _fecha As Date
    Public Property Fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property
    Private _fecha_vence As Date
    Public Property Fecha_Vence() As Date
        Get
            Return _fecha_vence
        End Get
        Set(ByVal value As Date)
            _fecha_vence = value
        End Set
    End Property
    Private _nit As String
    Public Property NIT() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _tot_bien As Double
    Public Property Bien() As Double
        Get
            Return _tot_bien
        End Get
        Set(ByVal value As Double)
            _tot_bien = value
        End Set
    End Property

    Private _tot_servicio As Double
    Public Property Servicio() As Double
        Get
            Return _tot_servicio
        End Get
        Set(ByVal value As Double)
            _tot_servicio = value
        End Set
    End Property

    Private _tot_exenta As Double
    Public Property Exenta() As Double
        Get
            Return _tot_exenta
        End Get
        Set(ByVal value As Double)
            _tot_exenta = value
        End Set
    End Property

    Private _iva_bien As Double
    Public Property IVA_Bien() As Double
        Get
            Return _iva_bien
        End Get
        Set(ByVal value As Double)
            _iva_bien = value
        End Set
    End Property

    Private _iva_servicio As Double
    Public Property IVA_Servicio() As Double
        Get
            Return _iva_servicio
        End Get
        Set(ByVal value As Double)
            _iva_servicio = value
        End Set
    End Property

    Private _tot_documento As Double
    Public Property Total() As Double
        Get
            Return _tot_documento
        End Get
        Set(ByVal value As Double)
            _tot_documento = value
        End Set
    End Property

    Private _sucursal As String
    Public Property Sucursal() As String
        Get
            Return _sucursal
        End Get
        Set(ByVal value As String)
            _sucursal = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
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

    Private _idcompra As Integer
    Public Property idcompra() As Integer
        Get
            Return _idcompra
        End Get
        Set(ByVal value As Integer)
            _idcompra = value
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

