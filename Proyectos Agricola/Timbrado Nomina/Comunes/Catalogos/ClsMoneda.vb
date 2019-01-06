Namespace Comunes.Catalogos
    Public Class ClsMoneda
        Inherits Comunes.Comun.ClsBaseComun2


        Private atrSigno As String
        Private atrMonedaBase As Boolean
        Private atrCveMoneda As String
        Private atrNombre As String
        Private atrNomenclatura As String
        Private atrAbreviaXml As String


        Public Property Signo() As String
            Get
                Return atrSigno
            End Get
            Set(ByVal value As String)
                atrSigno = value
            End Set
        End Property

        ' <summary>
        ' Obtiene el precio de compra para la moneda actual con la moneda base a la fecha
        ' </summary>
        Public ReadOnly Property PrecioCompraActual() As Decimal
            Get
                Return FabricaCatalogos.ObtenPrecioDeCompraActual(Me.Folio)
            End Get
        End Property

        Public Property MonedaBase() As Boolean
            Get
                Return atrMonedaBase
            End Get
            Set(ByVal value As Boolean)
                atrMonedaBase = value
            End Set
        End Property

        Public Property CveMoneda() As String
            Get
                Return atrCveMoneda
            End Get
            Set(ByVal value As String)
                atrCveMoneda = value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return atrNombre
            End Get
            Set(ByVal value As String)
                atrNombre = value
            End Set
        End Property

        Public Property Nomenclatura() As String
            Get
                Return atrNomenclatura
            End Get
            Set(ByVal value As String)
                atrNomenclatura = value
            End Set
        End Property

        Public Property AbreviaXml() As String
            Get
                Return atrAbreviaXml
            End Get
            Set(ByVal value As String)
                atrAbreviaXml = value
            End Set
        End Property


        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Return "CTL_MONEDAS"
        End Function

        Public Sub New(ByVal prmfolio As Integer)
            MyBase.New(prmfolio)
            MyBase.atrCampoFolio = "nMoneda"
        End Sub

        Public Sub New()
            MyBase.New(0)
            MyBase.atrCampoFolio = "nMoneda"
        End Sub

        Public Overrides Function Guardar() As Boolean
            Return EscribanoCatalogos.Guardar(Me)
        End Function

        Public Overrides Function getRow() As Comun.ClsBaseComun2.ObtenerRowEventHandler
            Return AddressOf FabricaCatalogos.ObtenMoneda
        End Function
    End Class
End Namespace

