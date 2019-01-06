Namespace Comunes.Comun
    Public Class ClsOrdenacion
        Inherits ClsBaseComun

        Private atrCampo As ClsCampos
        Private atrOrden As Integer


        Public Property Campo() As ClsCampos
            Get
                Return atrCampo
            End Get
            Set(ByVal value As ClsCampos)
                atrCampo = value
            End Set
        End Property


        Public Property Orden() As Integer
            Get
                Return atrOrden
            End Get
            Set(ByVal value As Integer)
                atrOrden = value
            End Set
        End Property


        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Return ""
        End Function

        Public Overrides Function getRow() As ClsBaseComun.ObtenerRowEventHandler
            Return Nothing
        End Function
    End Class
End Namespace
