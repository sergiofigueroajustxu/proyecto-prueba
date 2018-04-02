Public Class Entidad_Tipo_compra
    Private _idtipo_compra As Integer
    Public Property idtipocompra() As Integer
        Get
            Return _idtipo_compra
        End Get
        Set(ByVal value As Integer)
            _idtipo_compra = value
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

End Class
