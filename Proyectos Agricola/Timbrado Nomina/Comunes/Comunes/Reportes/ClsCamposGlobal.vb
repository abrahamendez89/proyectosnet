Namespace Comunes.Comun
    Public Class ClsCamposGlobal
        Inherits ClsContenedor

        Private atrReporte As ClsReportes

        Public Sub New(ByVal prmreporte As ClsReportes)
            MyBase.New()
            atrReporte = prmreporte
            MyBase.NombreTabla = FabricaReportes.vtablaglobal
            MyBase.ObtenerTabla = AddressOf ObtenTabla
        End Sub

        Private Function ObtenTabla() As DataTable
            Return FabricaReportes.ObtenCamposGlobal(atrReporte.Folio)
        End Function

    End Class
End Namespace
