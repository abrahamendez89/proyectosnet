Namespace Comunes.Catalogos
    Public Class ClsContieneParidades
        Inherits Comun.ClsContenedor

        Public Moneda As Integer
        Public FechaInicio As Date
        Public FechaFin As Date

        Public Sub New(ByVal prmMoneda As Integer, ByVal prmFechaInicio As Date, ByVal prmFechaFin As Date)
            MyBase.New(FabricaCatalogos.vNombreTablaParidades)
            Moneda = prmMoneda
            FechaInicio = prmFechaInicio
            FechaFin = prmFechaFin
            'MyBase.ObtenerObjeto = AddressOf FabricaCatalogos.ObtenParida
            'MyBase.ObtenerRow = AddressOf FabricaCatalogos.ObtenParidad
            'MyBase.ObtenerTabla = AddressOf ObtenTabla
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Shadows Function Guardar() As Boolean
            Return MyBase.Guardar(True)
        End Function

        Public Function ObtenTabla() As DataTable
            Return FabricaCatalogos.ObtenContenedorParidades(Moneda, FechaInicio, FechaFin)
        End Function

    End Class
End Namespace

