Namespace Comunes.Comun
    Public Class ClsFiltrosGlobal
        Inherits ClsContenedor

        Private atrReporte As ClsReportes

        Public Sub New(ByVal prmreporte As ClsReportes)
            MyBase.New()
            atrReporte = prmreporte
            MyBase.NombreTabla = FabricaReportes.vfiltrosglobal
            MyBase.ObtenerTabla = AddressOf ObtenTabla
        End Sub

        Private Function ObtenTabla() As DataTable
            Return FabricaReportes.ObtenFiltrosGlobal(atrReporte.Folio)
        End Function

    End Class
End Namespace

