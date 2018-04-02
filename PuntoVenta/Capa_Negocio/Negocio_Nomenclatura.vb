Imports Capa_Datos
Imports Capa_Entidad
Public Class Negocio_Nomenclatura
    Public Function MostrarNomenclatura(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Dato_Nomenclatura
        lista = obj.Mostrarnomenclatura(filtro)
        Return lista
    End Function
    Public Function MostrarNomenclaturaCuenta(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Dato_Nomenclatura
        lista = obj.MostrarNomenclaturaCuenta(filtro)
        Return lista
    End Function
    Public Function MostrarNomenclaturaGastos(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Dato_Nomenclatura
        lista = obj.MostrarNomenclaturaGastos(filtro)
        Return lista
    End Function
    Public Function MostrarNomenclaturaServicios(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Dato_Nomenclatura
        lista = obj.MostrarNomenclaturaServicios(filtro)
        Return lista
    End Function
    Public Function MostrarNomenclaturaIngresos(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Dato_Nomenclatura
        lista = obj.MostrarNomenclaturaIngresos(filtro)
        Return lista
    End Function
    Public Function MostrarNomenclaturaEgresos(ByVal filtro As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Dato_Nomenclatura
        lista = obj.MostrarNomenclaturaEgresos(filtro)
        Return lista
    End Function
    Public Function MostrarNomenclaturaSaldos(ByVal filtro As String, fecha As String, anio As String) As List(Of Entidad_Nomenclatura)
        Dim lista As New List(Of Entidad_Nomenclatura)
        Dim obj As New Dato_Nomenclatura
        lista = obj.MostrarNomenclaturaSaldos(filtro, fecha, anio)
        Return lista
    End Function
    'Para Agregar una Nueva
    Public Sub Nueva_Nomenclatura(ByVal registros As Entidad_Nomenclatura)
        Dim Datos As New Dato_Nomenclatura
        Datos.Nueva_Nomenclatura(registros)
    End Sub

    'Para modificar 

    Public Sub Modificar_Nomenclatura(ByVal registros As Entidad_Nomenclatura)
        Dim Datos As New Dato_Nomenclatura
        Datos.Modificar_Nomenclatura(registros)
    End Sub

    'Para Eliminar
    Public Sub Eliminar_Nomenclatura(ByVal registros As Entidad_Nomenclatura)
        Dim Datos As New Dato_Nomenclatura
        Datos.Eliminar_Nomenclatura(registros)
    End Sub
End Class
