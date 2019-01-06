
Namespace Comunes.Catalogos
    Public Class ClsProducto
        Inherits Comunes.Comun.ClsBaseComun2

        Private atrnRFCEmisor As Integer
        Private atrPrecio As Double
        Private atrTasaIVA As Double

        Public Property Precio()
            Get
                Return atrPrecio
            End Get
            Set(ByVal value)
                atrPrecio = value
            End Set
        End Property

        Public Property TasaIVA()
            Get
                Return atrTasaIVA
            End Get
            Set(ByVal value)
                atrTasaIVA = value
            End Set
        End Property

        Public Property RFCEmisor() As Integer
            Get
                Return atrnRFCEmisor
            End Get
            Set(ByVal value As Integer)
                atrnRFCEmisor = value
            End Set
        End Property

        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            DAO.FolioAdministradoAgregar("FAC_CONCEPTOS", "Folio administrado para la tabla FAC_CONCEPTOS")
            Return "FAC_CONCEPTOS"
        End Function

        Public Sub New(ByVal prmfolio As Integer)
            MyBase.New(prmfolio)
            MyBase.atrCampoFolio = "nConcepto"
        End Sub

        Public Sub New()
            MyBase.New(0)
            MyBase.atrCampoFolio = "nConcepto"
        End Sub

        Public Overrides Function Guardar() As Boolean
            Return EscribanoCatalogos.Guardar(Me)
        End Function

        Public Overrides Function getRow() As Comun.ClsBaseComun2.ObtenerRowEventHandler
            Return AddressOf FabricaCatalogos.ObtenProducto
        End Function
    End Class
End Namespace


