Public Class Entidad_Bancos
    Private _idbanco As Integer
    Public Property idbanco() As Integer
        Get
            Return _idbanco
        End Get
        Set(ByVal value As Integer)
            _idbanco = value
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

    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Private _cuenta_contable As String
    Public Property cuenta_contable() As String
        Get
            Return _cuenta_contable
        End Get
        Set(ByVal value As String)
            _cuenta_contable = value
        End Set
    End Property
End Class
