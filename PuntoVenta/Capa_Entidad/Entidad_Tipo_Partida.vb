Public Class Entidad_Tipo_Partida
    Private _idtipo_partida As String
    Public Property idtipopartida() As String
        Get
            Return _idtipo_partida
        End Get
        Set(ByVal value As String)
            _idtipo_partida = value
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



End Class
