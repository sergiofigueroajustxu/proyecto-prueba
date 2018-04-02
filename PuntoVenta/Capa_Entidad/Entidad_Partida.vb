Public Class Entidad_Partida
    Private _numero_partida As String
    Public Property numero_partida() As String
        Get
            Return _numero_partida
        End Get
        Set(ByVal value As String)
            _numero_partida = value
        End Set
    End Property

    Private _tipo As String
    Public Property tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
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


    Private _concepto As String
    Public Property concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property





End Class
