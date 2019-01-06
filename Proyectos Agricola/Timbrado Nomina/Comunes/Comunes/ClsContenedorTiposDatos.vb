
Public Class ClsContenedorTiposDatos
    Inherits Comunes.Comun.ClsContenedor

#Region "Declaraciones"
    Dim atrLlave As String
#End Region

    Public Property Llave() As String
        Get
            Return atrLlave
        End Get
        Set(ByVal value As String)
            atrLlave = value
        End Set
    End Property


    Public Sub New(ByVal prmfolio As Integer)
        MyBase.New(prmfolio)  
        MyBase.NombreTabla = Comunes.Catalogos.FabricaCatalogos.vNombreTablaTiposDatos
        MyBase.ObtenerObjeto = AddressOf Comunes.Catalogos.FabricaCatalogos.ObtenTiposDatos
        MyBase.ObtenerRow = AddressOf Comunes.Catalogos.FabricaCatalogos.ObtenTiposDatos
        MyBase.ObtenerTabla = AddressOf ObtenTabla
    End Sub

    Public Sub Refresh()
        Me.Inicializar()
    End Sub

    Public Sub New()
        MyBase.New()
        MyBase.NombreTabla = Comunes.Catalogos.FabricaCatalogos.vNombreTablaTiposDatos
        MyBase.ObtenerObjeto = AddressOf Comunes.Catalogos.FabricaCatalogos.ObtenTiposDatos
        MyBase.ObtenerRow = AddressOf Comunes.Catalogos.FabricaCatalogos.ObtenTiposDatos
        MyBase.ObtenerTabla = AddressOf ObtenTabla
    End Sub

    Public Function ObtenTabla() As DataTable
        Return Comunes.Catalogos.FabricaCatalogos.ObtenerTiposDatos(atrLlave)
    End Function

End Class
