Public Class Entidad_Departamento
    Private _iddepartamento As Integer
    Public Property iddepartamento() As Integer
        Get
            Return _iddepartamento
        End Get
        Set(ByVal value As Integer)
            _iddepartamento = value
        End Set
    End Property

    Private _nombre_departamento As String
    Public Property nombre_departamento() As String
        Get
            Return _nombre_departamento
        End Get
        Set(ByVal value As String)
            _nombre_departamento = value
        End Set
    End Property

    Private _codigo_departamento As String
    Public Property codigo_departamento() As String
        Get
            Return _codigo_departamento
        End Get
        Set(ByVal value As String)
            _codigo_departamento = value
        End Set
    End Property


End Class
