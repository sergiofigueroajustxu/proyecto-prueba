Public Class Entidad_Control_Transporte
    Private _idcontroltransporte As Integer
    Public Property idcontroltransporte() As Integer
        Get
            Return _idcontroltransporte
        End Get
        Set(ByVal value As Integer)
            _idcontroltransporte = value
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

    Private _fecha_solicita As Date
    Public Property fecha_solicita() As Date
        Get
            Return _fecha_solicita
        End Get
        Set(ByVal value As Date)
            _fecha_solicita = value
        End Set
    End Property

    Private _fecha_carga As Date
    Public Property fecha_carga() As Date
        Get
            Return _fecha_carga
        End Get
        Set(ByVal value As Date)
            _fecha_carga = value
        End Set
    End Property
    Private _fecha_entregara As Date
    Public Property fecha_entregara() As Date
        Get
            Return _fecha_entregara
        End Get
        Set(ByVal value As Date)
            _fecha_entregara = value
        End Set
    End Property
    Private _fecha_entrega As Date
    Public Property fecha_entrega() As Date
        Get
            Return _fecha_entrega
        End Get
        Set(ByVal value As Date)
            _fecha_entrega = value
        End Set
    End Property

    Private _numero_despacho As String
    Public Property numero_despacho() As String
        Get
            Return _numero_despacho
        End Get
        Set(ByVal value As String)
            _numero_despacho = value
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


    Private _km_recorrido As Double
    Public Property km_recorrido() As Double
        Get
            Return _km_recorrido
        End Get
        Set(ByVal value As Double)
            _km_recorrido = value
        End Set
    End Property
    Private _valor_transporte As Double
    Public Property valor_transporte() As Double
        Get
            Return _valor_transporte
        End Get
        Set(ByVal value As Double)
            _valor_transporte = value
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
