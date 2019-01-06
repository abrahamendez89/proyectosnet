Imports Sistema.Comunes
Imports Sistema.Comunes.Comun
Imports Sistema.Comunes.Comun.ClsTools
Imports Access

Namespace Comunes.Comun.ConfiguracionPermisos
    Public Class FabricaPermisos
        Inherits Comunes.Comun.Fabrica


        Public Shared Function ObtenPermisosSistema(ByVal prmTipoPermiso As Integer, ByVal prmUsuario As String) As ConfiguracionPermisos.ClsPermisoSistema
            If prmUsuario.Trim = "" Then Return Nothing
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vDt As New DataTable
            Dim vcSQL As String = "SELECT PS.* FROM CTL_PermisosSistema PS (NOLOCK) " & vbCr
            vcSQL &= " WHERE PS.nTipoPermiso = " & prmTipoPermiso & " AND cUsuario = '" & prmUsuario.Trim & "'"
            DAO.RegresaConsultaSQL(vcSQL, vDt)
            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then Return Nothing
            Return ObtenPermisosSistema(vDt.Rows(0), prmUsuario.Trim)
        End Function
        Public Shared Function ObtenPErmisosSistema(ByVal prmRow As DataRow, ByVal prmUsuario As String) As ConfiguracionPermisos.ClsPermisoSistema
            Dim vObjTipoPermiso As Catalogos.ClsTipoPermiso = ObtenTipoPermiso(prmRow("nTipoPermiso"))
            If vObjTipoPermiso Is Nothing Then Return Nothing
            Dim ret As New ConfiguracionPermisos.ClsPermisoSistema(vObjTipoPermiso, prmUsuario.Trim, prmRow("cPermiso"), prmRow("bBloquearATX"), IfNull(prmRow("cValorDefault"), ""))
            Return ret
        End Function



        Public Shared Function ObtenTipoPermiso(ByVal prmTipoPermiso As Integer) As Catalogos.ClsTipoPermiso
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vDt As New DataTable
            Dim vcSQL As String = " SELECT * FROM CTL_TiposPermisosSistema (NOlOCK) WHERE nTipoPermiso = " & prmTipoPermiso
            DAO.RegresaConsultaSQL(vcSQL, vDt)
            If vDt Is Nothing OrElse vDt.Rows.Count = 0 Then Return Nothing
            Return ObtenTipoPermiso(vDt.Rows(0))
        End Function


        Public Shared Function ObtenTipoPermiso(ByVal prmrow As DataRow) As Catalogos.ClsTipoPermiso
            If prmrow Is Nothing Then
                Return Nothing
            End If
            Dim ret As New Catalogos.ClsTipoPermiso(prmrow("nTipoPermiso"))
            ret.Descripcion = prmrow("cDescripcion")
            ret.Activo = prmrow("bActivo")
            ret.SqlCatalogo = prmrow("cSqlCatalogo")
            ret.CampoFiltrado = prmrow("cCampoPrimario")
            ret.CampoDescripcion = prmrow("cCampoDescripcionPrimario")
            ret.CargaDatosRegistro(prmrow)

            Return ret

        End Function

        Public Shared Function ObtenTipoPermiso(ByRef prmrow As DataRow, ByVal prmobj As Catalogos.ClsTipoPermiso) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If
            If prmobj Is Nothing Then
                Return Nothing
            End If
            prmrow("nTipoPermiso") = prmobj.Folio
            prmrow("cDescripcion") = prmobj.Descripcion
            prmrow("cSqlCatalogo") = prmobj.SqlCatalogo
            prmrow("cCampoPrimario") = prmobj.CampoFiltrado
            prmrow("cCampoDescripcionPrimario") = prmobj.CampoDescripcion
            prmrow("bActivo") = prmobj.Activo

            prmobj.LLenaDatosRegistroComun(prmrow)


            Return prmrow

        End Function


        Public Shared Function ObtenPermisosParaUsuarios(ByVal prmTipoPermiso As Catalogos.ClsTipoPermiso) As DataTable
            If prmTipoPermiso Is Nothing Then Return Nothing
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vcSql As String = "SP_COMUN_ObtenPermisosUsuarios"
            Dim vParam(0) As Object
            Dim vDs As New DataSet
            vParam(0) = prmTipoPermiso.Folio
            If Not DAO.RegresaConsultaSQL(vcSql, vDs, vParam) Then Return Nothing
            If vDs Is Nothing OrElse vDs.Tables.Count = 0 Then Return Nothing
            Return vDs.Tables(0)
        End Function

        ' ''Public Shared Function ObtenListaValoresPermisos(ByVal prmTipoPermiso As Catalogos.ClsTipoPermiso) As DataTable
        ' ''    If prmTipoPermiso Is Nothing Then Return Nothing
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim vDt As New DataTable
        ' ''    Dim vcCamposSelect As String = prmTipoPermiso.CampoFiltrado.Trim & " as nFolio," & prmTipoPermiso.CampoDescripcion.Trim & " as cDescripcion"
        ' ''    Dim vcCamposGroupBy As String = prmTipoPermiso.CampoFiltrado.Trim & "," & prmTipoPermiso.CampoDescripcion.Trim
        ' ''    Dim vcSQL As String = " SELECT {0} FROM {1} (NOLOCK) " & vbCr
        ' ''    vcSQL &= " GROUP BY {2} "
        ' ''    vcSQL = String.Format(vcSQL, vcCamposSelect, prmTipoPermiso.SqlCatalogo, vcCamposGroupBy)
        ' ''    If Not DAO.RegresaConsultaSQL(vcSQL, vDt) Then Return Nothing
        ' ''    If vDt Is Nothing Then Return Nothing
        ' ''    Return vDt
        ' ''End Function

        ' ''Public Shared Function ObtenValor(ByVal prmFolio As Integer, ByVal prmDescripcion As String) As ClsValor
        ' ''    Dim vObjValor As New ClsValor(prmFolio, prmDescripcion)
        ' ''    Return vObjValor
        ' ''End Function

        ' ''Public Shared Function InicializaPermisosUsuarios(ByVal prmTipoPermiso As Catalogos.ClsTipoPermiso) As Boolean
        ' ''    If prmTipoPermiso Is Nothing Then Return False
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    If Not DAO.TieneTransaccionAbierta Then
        ' ''        ClsTools.MuestraMensajeSistFact("Este método requiere una transacción abierta ...", Windows.Forms.MessageBoxIcon.Error)
        ' ''        Return False
        ' ''    End If
        ' ''    Dim vcSQL As String = "DELETE FROM CTL_PermisosSistema WHERE nTipoPermiso = " & prmTipoPermiso.Folio
        ' ''    Return DAO.EjecutaComandoSQL(vcSQL)
        ' ''End Function

        ' ''Public Shared Function ObtenTablaEsquemaDatosPermisosUsuarios() As DataTable
        ' ''    Dim vDt As New DataTable
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    DAO.RegresaConsultaSQL("SELECT * FROM CTL_PermisosSistema (NOLOCK) WHERE 1 = 0", vDt)
        ' ''    vDt.TableName = "CTL_PermisosSistema"
        ' ''    Return vDt
        ' ''End Function

    End Class
End Namespace