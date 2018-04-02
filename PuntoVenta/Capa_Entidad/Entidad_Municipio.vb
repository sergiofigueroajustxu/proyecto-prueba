Public Class Entidad_Municipio
    Private _idmunicipio As Integer
    Public Property idmunicipio() As Integer
        Get
            Return _idmunicipio
        End Get
        Set(ByVal value As Integer)
            _idmunicipio = value
        End Set
    End Property

    Private _nombre_municipio As String
    Public Property nombre_municipio() As String
        Get
            Return _nombre_municipio
        End Get
        Set(ByVal value As String)
            _nombre_municipio = value
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
    Private _padre_municipio As String
    Public Property padre_municipio() As String
        Get
            Return _padre_municipio
        End Get
        Set(ByVal value As String)
            _padre_municipio = value
        End Set
    End Property


End Class
