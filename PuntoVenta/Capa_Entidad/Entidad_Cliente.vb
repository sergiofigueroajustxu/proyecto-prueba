Public Class Entidad_Cliente
    Private _idcliente As Integer
    Public Property idcliente() As String
        Get
            Return _idcliente
        End Get
        Set(ByVal value As String)
            _idcliente = value
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
    Private _apellidos As String
    Public Property apellidos() As String
        Get
            Return _apellidos
        End Get
        Set(ByVal value As String)
            _apellidos = value
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
    Private _nit As String
    Public Property nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Private _nomyap As String
    Public ReadOnly Property nomyap() As String
        Get
            Return _nombre & " " & _apellidos
        End Get
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

    Private _idruta As Integer
    Public Property idruta() As Integer
        Get
            Return _idruta
        End Get
        Set(ByVal value As Integer)
            _idruta = value
        End Set
    End Property


End Class
