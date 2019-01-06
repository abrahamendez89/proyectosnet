Namespace Comunes.Comun.ConfiguracionPermisos
    Public Class ClsValor

        Private atrFolio As Integer
        Private atrDescripcion As String

        Public Sub New(ByVal prmFolio As Integer, ByVal prmDescripcion As String)
            atrFolio = prmFolio
            atrDescripcion = prmDescripcion
        End Sub

        Public Property Folio() As Integer
            Get
                Return atrFolio
            End Get
            Set(ByVal value As Integer)
                atrFolio = value
            End Set
        End Property

        Public Property Descripcion() As String
            Get
                Return atrDescripcion
            End Get
            Set(ByVal value As String)
                atrDescripcion = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Descripcion.Trim
            'Return MyBase.ToString()
        End Function
    End Class
End Namespace
