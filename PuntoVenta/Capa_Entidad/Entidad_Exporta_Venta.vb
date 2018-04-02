Public Class Entidad_Exporta_Venta


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
    Private _idempleado As Integer
    Public Property Idempleado() As Integer
        Get
            Return _idempleado
        End Get
        Set(ByVal value As Integer)
            _idempleado = value
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
    Private _idruta As Integer
    Public Property idruta() As Integer
        Get
            Return _idruta
        End Get
        Set(ByVal value As Integer)
            _idruta = value
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
    Private _direccion As String
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
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
    Private _nombreEmpleado As String
    Public Property nombreEmpleado() As String
        Get
            Return _nombreEmpleado
        End Get
        Set(ByVal value As String)
            _nombreEmpleado = value
        End Set
    End Property
    Private _idproducto As Integer
    Public Property idproducto() As Integer
        Get
            Return _idproducto
        End Get
        Set(ByVal value As Integer)
            _idproducto = value
        End Set
    End Property

    Private _precio As Double
    Public Property precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _importe As Double
    Public Property importe() As Double
        Get
            Return _importe
        End Get
        Set(ByVal value As Double)
            _importe = value
        End Set
    End Property

    Private _monto_pagado As Double
    Public Property monto_pagado() As Double
        Get
            Return _monto_pagado
        End Get
        Set(ByVal value As Double)
            _monto_pagado = value
        End Set
    End Property

    Private _cod_producto As String
    Public Property cod_producto() As String
        Get
            Return _cod_producto
        End Get
        Set(ByVal value As String)
            _cod_producto = value
        End Set
    End Property

    Private _cantidad_d As Double
    Public Property cantidad_d() As Double
        Get
            Return _cantidad_d
        End Get
        Set(ByVal value As Double)
            _cantidad_d = value
        End Set
    End Property

    Private _valor As Double
    Public Property valor() As Double
        Get
            Return _valor
        End Get
        Set(ByVal value As Double)
            _valor = value
        End Set
    End Property

    Private _iva As Double
    Public Property iva() As Double
        Get
            Return _iva
        End Get
        Set(ByVal value As Double)
            _iva = value
        End Set
    End Property

    Private _idp_detalle As Double
    Public Property idp_detalle() As Double
        Get
            Return _idp_detalle
        End Get
        Set(ByVal value As Double)
            _idp_detalle = value
        End Set
    End Property

    Private _otros As Double
    Public Property otros() As Double
        Get
            Return _otros
        End Get
        Set(ByVal value As Double)
            _otros = value
        End Set
    End Property

    Private _cancelado As Integer
    Public Property cancelado() As Integer
        Get
            Return _cancelado
        End Get
        Set(ByVal value As Integer)
            _cancelado = value
        End Set
    End Property

    Private _codigo_barra As String
    Public Property codigo_barra() As String
        Get
            Return _codigo_barra
        End Get
        Set(ByVal value As String)
            _codigo_barra = value
        End Set
    End Property
End Class
