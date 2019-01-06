Imports Access
Namespace Comunes.Comun



    Public Class FabricaWS
        Inherits Fabrica

        Public Shared vcNombreTablaAdministracionArchivos As String = "CTL_AdministracionArchivosWS"

        Public Shared Function ObtenAdministracionArchivos(ByVal prmAdmin As Comunes.Comun.WS.ClsAdministracionArchivosWS) As DataTable


            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable
            Dim vSql As String = ""
            Dim vSqlFiltro As String = ""

            If prmAdmin Is Nothing Then
                Return Nothing
            End If

            DAO.RegresaEsquemaDeDatos("SELECT * FROM CTL_AdministracionArchivosWS (NOLOCK) WHERE 1=0", dt)

            vSql = "SELECT ADM.* FROM CTL_AdministracionArchivosWS ADM (NOLOCK)" & vbCr

            If Not prmAdmin.NombreArchivo = "" Then
                vSqlFiltro &= " ADM.cNombreArchivo = '" & prmAdmin.NombreArchivo & "'"
            End If

            If vSqlFiltro.Trim <> "" Then
                vSqlFiltro = " Where " & vSqlFiltro
            End If

            vSql &= vSqlFiltro

            DAO.RegresaConsultaSQL(vSql, dt)

            If Not dt Is Nothing Then
                Return dt
            End If

            Return Nothing
        End Function


    End Class
End Namespace