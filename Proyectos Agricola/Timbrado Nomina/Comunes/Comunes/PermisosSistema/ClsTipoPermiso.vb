Namespace Comunes.Catalogos
    Public Class ClsTipoPermiso
        Inherits Comunes.Comun.ClsBaseComun2

        Private atrSqlCatalogo As String
        Private atrCampoFiltrado As String
        Private atrCampoDescripcion As String

        Public Property SqlCatalogo() As String
            Get
                Return atrSqlCatalogo
            End Get
            Set(ByVal value As String)
                atrSqlCatalogo = value
            End Set
        End Property

        Public Property CampoFiltrado() As String
            Get
                Return atrCampoFiltrado
            End Get
            Set(ByVal value As String)
                atrCampoFiltrado = value
            End Set
        End Property

        Public Property CampoDescripcion() As String
            Get
                Return atrCampoDescripcion
            End Get
            Set(ByVal value As String)
                atrCampoDescripcion = value
            End Set
        End Property

        Public Sub New()
            MyBase.New(0)
            MyBase.atrCampoFolio = "nTipoPermiso"
        End Sub


        Public Sub New(ByVal prmfolio As Integer)
            MyBase.New(prmfolio)
            MyBase.atrCampoFolio = "nTipoPermiso"
        End Sub

        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            DAO.FolioAdministradoAgregar("CTL_TIPOSPERMISOS", "Folio administrado para la tabla ADSUM_TiposPermisosSistema")
            Return "CTL_TIPOSPERMISOS"
        End Function

        Public Overrides Function getRow() As Comunes.Comun.ClsBaseComun2.ObtenerRowEventHandler
            Return AddressOf Comunes.Comun.ConfiguracionPermisos.FabricaPermisos.ObtenTipoPermiso
        End Function

        Public Overrides Function Guardar() As Boolean
            Return Catalogos.EscribanoCatalogos.Guardar(Me)
        End Function

        Public Function ObtenUsuarios() As DataTable

            Return Comunes.Comun.ConfiguracionPermisos.FabricaPermisos.ObtenPermisosParaUsuarios(Me)
        End Function
        Public Function ObtenUsuariosConPermisosAsignados() As DataTable
            Dim vDt As DataTable = Comunes.Comun.ConfiguracionPermisos.FabricaPermisos.ObtenPermisosParaUsuarios(Me)
            If vDt Is Nothing Then Return Nothing
            Return ObtenUsuariosConPermisosAsignados(vDt)
        End Function
        Public Function ObtenUsuariosConPermisosAsignados(ByRef prmUsuariosPermisos As DataTable) As DataTable
            If prmUsuariosPermisos Is Nothing Then Return Nothing
            Dim vDtSoloPermisos As New DataTable
            Comunes.Comun.ClsTools.copiaRows(prmUsuariosPermisos.Select("cPermiso IS NOT NULL"), vDtSoloPermisos, prmUsuariosPermisos.Columns)
            Return vDtSoloPermisos
        End Function
        Public Function ObtenUsuariosSinPermisosAsignados() As DataTable
            Dim vDt As DataTable = Comunes.Comun.ConfiguracionPermisos.FabricaPermisos.ObtenPermisosParaUsuarios(Me)
            If vDt Is Nothing Then Return Nothing
            Return ObtenUsuariosSinPermisosAsignados(vDt)
        End Function
        Public Function ObtenUsuariosSinPermisosAsignados(ByRef prmUsuariosPermisos As DataTable) As DataTable
            If prmUsuariosPermisos Is Nothing Then Return Nothing
            Dim vDtSinPermisos As New DataTable
            Comunes.Comun.ClsTools.copiaRows(prmUsuariosPermisos.Select("cPermiso IS NULL"), vDtSinPermisos, prmUsuariosPermisos.Columns)
            Return vDtSinPermisos
        End Function

        Public Function ObtenListaValoresPermisos() As DataTable

        End Function
    End Class
End Namespace


