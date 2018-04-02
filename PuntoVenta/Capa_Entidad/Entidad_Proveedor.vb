Public Class Entidad_Proveedor
    Private _idproveedor As Integer
    Public Property idproveedor() As Integer
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As Integer)
            _idproveedor = value
        End Set
    End Property

    Private _apellidos As String
    Public Property apellidos() As String
        Get
            Return _apellidos
        End Get
        Set(ByVal value As String)
            _apellidos = value
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
    Private _es_proveedor As String
    Public Property es_proveedor() As String
        Get
            Return _es_proveedor
        End Get
        Set(ByVal value As String)
            _es_proveedor = value
        End Set
    End Property

    Private _Ruc As String
    Public Property Ruc() As String
        Get
            Return _Ruc
        End Get
        Set(ByVal value As String)
            _Ruc = value
        End Set
    End Property

    Private _representante As String
    Public Property representante() As String
        Get
            Return _representante
        End Get
        Set(ByVal value As String)
            _representante = value
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

    Private _telefono As String
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _correo As String
    Public Property correo() As String
        Get
            Return _correo
        End Get
        Set(ByVal value As String)
            _correo = value
        End Set
    End Property

    Private _celular As String
    Public Property celular() As String
        Get
            Return _celular
        End Get
        Set(ByVal value As String)
            _celular = value
        End Set
    End Property

    Private _limite_proveedor As Decimal
    Public Property limite_proveedor() As Decimal
        Get
            Return _limite_proveedor
        End Get
        Set(ByVal value As Decimal)
            _limite_proveedor = value
        End Set
    End Property
    Private _limite_dias_proveedor As Decimal
    Public Property limite_dias_proveedor() As Decimal
        Get
            Return _limite_dias_proveedor
        End Get
        Set(ByVal value As Decimal)
            _limite_dias_proveedor = value
        End Set
    End Property
    Private _pago_pendiente As Decimal
    Public Property pago_pendiente() As Decimal
        Get
            Return _pago_pendiente
        End Get
        Set(ByVal value As Decimal)
            _pago_pendiente = value
        End Set
    End Property
    Private _cobro_pendiente As Decimal
    Public Property cobro_pendiente() As Decimal
        Get
            Return _cobro_pendiente
        End Get
        Set(ByVal value As Decimal)
            _cobro_pendiente = value
        End Set
    End Property

    Private _idruta As Integer
    Public Property idruta() As Integer
        Get
            Return _idruta
        End Get
        Set(ByVal value As Integer)
            _idruta = value
        End Set
    End Property
    Private _codigo_municipio As String
    Public Property codigo_municipio() As String
        Get
            Return _codigo_municipio
        End Get
        Set(ByVal value As String)
            _codigo_municipio = value
        End Set
    End Property
End Class
