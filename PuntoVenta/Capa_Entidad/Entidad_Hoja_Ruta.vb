Public Class Entidad_Hoja_Ruta


    Private _fecha As Date
    Public Property Fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Private _idruta As Integer
    Public Property Ruta() As Integer
        Get
            Return _idruta
        End Get
        Set(ByVal value As Integer)
            _idruta = value

        End Set
    End Property

    Private _idtipoventa As Integer
    Public Property TipoVenta() As Integer
        Get
            Return _idtipoventa
        End Get
        Set(ByVal value As Integer)
            _idtipoventa = value
        End Set
    End Property


    Private _idfactura As String
    Public Property Factura() As String
        Get
            Return _idfactura
        End Get
        Set(ByVal value As String)
            _idfactura = value
        End Set
    End Property


    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
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

    Private _importe As Double
    Public Property Importe() As Double
        Get
            Return _importe
        End Get
        Set(ByVal value As Double)
            _importe = value
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

    Private _producto As String
    Public Property Producto() As String
        Get
            Return _producto
        End Get
        Set(ByVal value As String)
            _producto = value
        End Set
    End Property


    Private _cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property
    Private _nombreSucursal As String


End Class
