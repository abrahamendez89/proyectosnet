Imports Access
Namespace Comunes.Comun
    Public Class FabricaReportes
        Inherits Fabrica

        Public Shared vtablaglobal As String = "ADSUM_ReporteExpressColumnas"
        Public Shared vfiltrosglobal As String = "ADSUM_ReportesExpressFiltros"
        Public Enum Forma
            FormaGrid = 1
            FormaResultado = 2
        End Enum

        Enum eTablasReporte
            '--------------------------------------------------
            'Este valor del enum está destinado para referirse a la configuración completa de un Batch (selección, agrupador, etc)
            ConfiguraciónCompletaBatch = -1
            '--------------------------------------------------
            CamposSeleccionBatch = 0
            CamposAgrupacionBatch = 1
            CamposOrdenacionBatch = 2
            CamposTotalesBatch = 3
            CamposTodosReporte = 4
            CamposFiltrosBatch = 5
        End Enum


        Public Shared Function ObtenReporteGuardados(ByVal prmReporte As Integer) As ArrayList
            'Regresa una colección de Reportes Guardados
            'Obtiene reporte a partir del folio del mismo
            Dim DtReporte As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vlsql As String = ""
            Dim vRes As New ArrayList

            vlsql = "SELECT * FROM ADSUM_ReporteExpressGuarda(NOLOCK)" & vbCr
            vlsql &= "WHERE bActivo=1 and nReporte=" & prmReporte.ToString.Trim

            DAO.RegresaConsultaSQL(vlsql, DtReporte)

            If DtReporte.Rows.Count = 0 Then
                Return Nothing
            End If

            For Each vRowReporteGuardado As DataRow In DtReporte.Rows
                vRes.Add(ObtenReporteGuardado(vRowReporteGuardado))
            Next

            Return vRes
        End Function


        Public Shared Function FGValidaColumnasDataSourceConReporteGuardado(ByRef PrmDataSource As System.Data.DataColumnCollection, ByRef prmReporte As Integer, ByVal PrmTablaValidar As Integer) As Boolean
            'Elaboró:     César Octavio Niebla Manjarrez 
            'Fecha:       14-Julio-2009
            'Que Hace:    Regresa un valor indicando si el origen de datos (DataSource) 
            '             contempla todas las columnas referenciadas en los reportes guardados(Batch's) 
            '             de un folio de reporte determinado
            'Parámetros:  PrmDataSource = Son las columnas que genera el origen de dato
            '             PrmnReporte = Folio del reporte con respecto al cual se validarán las columnas del PrmDataSource
            '             PrmTablaValidar = Se refiere al tipo eTablasReporte
            '------------------------------------------------------------------------------
            'Objeto mediante el cual se obtiene el reporte con sus batch's correspondiente:

            Dim objContieneReportesGuardados As New ArrayList
            Dim ColumnaOrigen As String
            Dim columnaStore As String


            objContieneReportesGuardados = ObtenReporteGuardados(prmReporte)

            If objContieneReportesGuardados Is Nothing Then
                'El reporte no tiene batchs guardados
                Return True
            End If

            Dim vbExiste As Boolean = False
            Dim vColumna As Integer = 0
            'Realizamos la validación  de las columnas de cada uno de los batch's (reportes guardados)
            If Not PrmTablaValidar = eTablasReporte.ConfiguraciónCompletaBatch Then
                '1.-Ciclo para recorrer cada uno de los Batch activos del reporte
                For Each ObjReporteGuardado As ClsReporteGuarda In objContieneReportesGuardados.ToArray
                    vColumna += 1
                    '2.-Ciclo para recorrer cada una de las columnas del batch en cuestión
                    If ObjReporteGuardado.aDataset.Tables(PrmTablaValidar).Rows.Count = 0 Then Return True
                    For Each vRow As DataRow In ObjReporteGuardado.aDataset.Tables(PrmTablaValidar).Rows
                        vbExiste = False
                        For vnCol As Integer = 0 To PrmDataSource.Count - 1
                            ColumnaOrigen = PrmDataSource.Item(vnCol).Caption.Trim.ToUpper
                            columnaStore = vRow.Item(0).ToString.Trim.ToUpper
                            If PrmDataSource.Item(vnCol).Caption.Trim.ToUpper = vRow.Item(0).ToString.Trim.ToUpper Then
                                'Si existe columna
                                vbExiste = True
                                Exit For
                            End If
                        Next

                        If Not vbExiste Then
                            Exit For
                        End If
                    Next
                    If Not vbExiste Then
                        Exit For
                    End If
                Next
            End If

            Return vbExiste
        End Function

        Public Shared Function ObtenReportesBorrados(ByVal prmReporte As Integer) As DataTable
            Dim dt As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = "Select * from ADSUM_ReporteExpressGuarda(NOLOCK) where bactivo=0 and nreporte=" & prmReporte
            DAO.RegresaEsquemaDeDatos("Select * from ADSUM_ReporteExpressGuarda(NOLOCK) where 1=0", dt)
            DAO.RegresaConsultaSQL(vsql, dt)

            Return dt

        End Function

        Public Shared Function ObtenFiltrosGlobal(ByVal prmnumero As Integer) As DataTable
            Dim dt As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = "Select * from ADSUM_ReportesExpressFiltros(NOLOCK) where nreporte=" & prmnumero
            DAO.RegresaEsquemaDeDatos("Select * from ADSUM_ReportesExpressFiltros(NOLOCK) where 1=0", dt)
            DAO.RegresaConsultaSQL(vsql, dt)

            Return dt
        End Function

        Public Shared Function ObtenCamposGlobal(ByVal prmnumero As Integer) As DataTable
            Dim dt As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = "Select * from ADSUM_ReporteExpressColumnas(NOLOCK) where nreporte=" & prmnumero
            DAO.RegresaEsquemaDeDatos("Select * from ADSUM_ReporteExpressColumnas(NOLOCK) where 1=0", dt)
            DAO.RegresaConsultaSQL(vsql, dt)

            Return dt

        End Function

        Public Shared Function ObtenReportes(ByVal prmnumero As Integer) As ClsReportes
            Dim dt As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = "Select * from ADSUM_ReportesExpress(NOLOCK) where nreporte=" & prmnumero

            DAO.RegresaConsultaSQL(vsql, dt)

            If dt.Rows.Count > 0 Then
                Return ObtenReportes(dt.Rows(0))
            Else
                Return Nothing
            End If

        End Function

        Public Shared Function ObtenReportes(ByVal prmReporte As String) As ClsReportes
            Dim dt As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = "Select * from ADSUM_ReportesExpress(NOLOCK) where creporte='" & prmReporte & "' "

            DAO.RegresaConsultaSQL(vsql, dt)

            If dt.Rows.Count > 0 Then
                Return ObtenReportes(dt.Rows(0))
            Else
                Return Nothing
            End If
        End Function

        Public Shared Function ObtenReportes(ByVal prmrow As DataRow) As ClsReportes
            If prmrow Is Nothing Then
                Return Nothing
            End If

            Dim prmobj As New ClsReportes(prmrow("nReporte"))

            prmobj.Descripcion = prmrow("cReporte")
            prmobj.Query = prmrow("cSqlSelect")
            prmobj.Store = prmrow("cStore")
            If Not prmrow("cSqlfrom") Is DBNull.Value Then
                prmobj._From = prmrow("cSqlfrom")
            End If
            If Not prmrow("cSqlWhere") Is DBNull.Value Then
                prmobj.Where = prmrow("cSqlWhere")
            End If
            If Not prmrow("cSqlGroup") Is DBNull.Value Then
                prmobj.Group = prmrow("cSqlGroup")
            End If
            If Not prmrow("cSqlOrder") Is DBNull.Value Then
                prmobj.Order = prmrow("cSqlOrder")
            End If
            If Not prmrow("cSqlHaving") Is DBNull.Value Then
                prmobj.Having = prmrow("cSqlHaving")
            End If
            prmobj.ModificaColumnas = prmrow("bModificaColumna")
            prmobj.ModificaAgrupacion = prmrow("bModificaAgrupacion")
            prmobj.ModificaOrdenacion = prmrow("bModificaOrdenacion")
            prmobj.ModificaTotales = prmrow("bModificaTotales")
            prmobj.OmitirAlias = prmrow("bOmitirAlias")
            prmobj.CalculaAcumulado = prmrow("bCalculaAcumulado")
            If prmrow("cClasificador") Is DBNull.Value Then
                prmobj.Clasificadores = ""
            Else
                prmobj.Clasificadores = prmrow("cClasificador")
            End If

            '   prmobj.CampoRelativo = prmrow("cCampoRelativo")
            ' prmobj.CampoAcumulado = prmrow("cCampoAcumulado")
            prmobj.Activo = prmrow("bActivo")
            Return prmobj
        End Function

        Public Shared Function ObtenCampoCalculado(ByVal prmreporte As Integer, ByVal prmCampo As String) As DataTable
            Dim vsql As String = "Select * from ADSUM_ReporteExpressCalculados(nolock)"
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable

            vsql &= " where nreporte=" & prmreporte & " and ccampo='" & prmCampo & "'"

            DAO.RegresaConsultaSQL(vsql, dt)

            Return dt
        End Function

        Public Shared Function ObtenCampoCalculado(ByVal prmreporte As Integer) As DataTable
            Dim vsql As String = "Select ccampo from ADSUM_ReporteExpressCalculados(nolock)"
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable

            vsql &= " where nreporte=" & prmreporte & " group by ccampo"

            DAO.RegresaConsultaSQL(vsql, dt)

            Return dt
        End Function

        Public Shared Function ObtenCampoFormula(ByVal prmreporte As Integer) As DataTable
            Dim vsql As String = "Select * from ADSUM_ReporteExpressCalculados(nolock)"
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim dt As New DataTable

            vsql &= " where nreporte=" & prmreporte

            DAO.RegresaConsultaSQL(vsql, dt)

            Return dt
        End Function

        Public Shared Function BorraCampoCalculado(ByVal prmreporte As Integer, ByVal prmcampo As String)
            Dim vsql As String = "delete ADSUM_ReporteExpressCalculados where nreporte=" & prmreporte & " and ccampo ='" & prmcampo & "'"
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

            DAO.EjecutaComandoSQL(vsql)
        End Function

        Public Shared Function BorraCampoCalculado(ByVal prmreporte As Integer)
            Dim vsql As String = "delete ADSUM_ReporteExpressCalculados where nreporte=" & prmreporte
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            DAO.EjecutaComandoSQL(vsql)
        End Function

        Public Shared Function ObtenReportes(ByRef prmrow As DataRow, ByVal prmObj As ClsReportes) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If
            If prmObj Is Nothing Then
                Return Nothing
            End If

            prmrow("nReporte") = prmObj.Folio
            prmrow("cReporte") = prmObj.Descripcion
            prmrow("cStore") = prmObj.Store
            prmrow("cSqlSelect") = prmObj.Query
            prmrow("cSqlFrom") = prmObj._From
            prmrow("cSqlWhere") = prmObj.Where
            prmrow("cSqlGroup") = prmObj.Group
            prmrow("cSqlOrder") = prmObj.Order
            prmrow("cSqlHaving") = prmObj.Having
            prmrow("bModificaColumna") = prmObj.ModificaColumnas
            prmrow("bModificaAgrupacion") = prmObj.ModificaAgrupacion
            prmrow("bModificaOrdenacion") = prmObj.ModificaOrdenacion
            prmrow("bModificaTotales") = prmObj.ModificaTotales
            prmrow("bOmitirAlias") = prmObj.OmitirAlias
            prmrow("bActivo") = prmObj.Activo
            prmrow("bCalculaAcumulado") = prmObj.CalculaAcumulado
            prmrow("cCampoRelativo") = prmObj.CampoRelativo
            prmrow("cCampoAcumulado") = prmObj.CampoAcumulado
            prmrow("cClasificador") = prmObj.Clasificadores
            Return prmrow
        End Function

        Public Shared Function ObtenReporteGuardado(ByVal prmNombreGuardado As Integer) As DataTable
            Dim dt As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = "SELECT * FROM ADSUM_ReporteExpressGuarda (NOLOCK)"
            vsql &= "where bactivo=1 and nreporte= " & prmNombreGuardado & " and ( (bpublico=1) or (bpublico=0 and cusuario='" & DAO.GetLoginUsuario & "'))"

            DAO.RegresaConsultaSQL(vsql, dt)

            Return dt

        End Function

        Public Shared Function ObtenReporteGuardado(ByVal prmNombreGuardado As Integer, ByVal prmTabla As DataTable)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = "SELECT * FROM ADSUM_ReporteExpressGuarda (NOLOCK)"
            vsql &= "where bactivo=1 and nreporte= " & prmNombreGuardado & " and ( (bpublico=1) or (bpublico=0 and cusuario='" & DAO.GetLoginUsuario & "'))"

            DAO.RegresaConsultaSQL(vsql, prmTabla)
        End Function

        Public Shared Function ObtenReporteGuardado(ByVal prmNombreGuardado As String) As ClsReporteGuarda

        End Function

        Public Shared Function ObtenReporteGuardado() As DataTable
            Dim dt As New DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vsql As String = "SELECT *,cast(0 as bit) as seleccion FROM ADSUM_ReporteExpressGuarda (NOLOCK)"
            vsql &= "where ( (bpublico=1) or (bpublico=0 and cusuario='" & DAO.GetLoginUsuario & "')) and bactivo=1"

            DAO.RegresaConsultaSQL(vsql, dt)

            Return dt
        End Function



        Public Shared Function ObtenReporteGuardado(ByRef prmrow As DataRow, ByVal prmobj As ClsReporteGuarda) As DataRow
            If prmrow Is Nothing Then
                Return Nothing
            End If
            If prmobj Is Nothing Then
                Return Nothing
            End If

            prmrow("nReporteGuarda") = prmobj.Folio
            prmrow("nReporte") = prmobj.Reporte.Folio
            prmrow("cNombreReporte") = prmobj.Descripcion
            prmrow("cTitutoReporte") = prmobj.TituloReporte
            Dim c As New IO.StringWriter
            prmobj.aDataset.WriteXml(c, XmlWriteMode.WriteSchema)
            prmrow("cConfiguracion") = c.ToString
            prmrow("ccamporelativo") = prmobj.CampoRelativo
            prmrow("cUsuario") = prmobj.Usuario
            prmrow("dFecha") = prmobj.Fecha
            prmrow("bPublico") = prmobj.Publico
            prmrow("bActivo") = prmobj.Activo
            prmrow("bEliminaRegistros") = prmobj.EliminaRegistros


            Return prmrow
        End Function

        Public Shared Function ObtenReporteGuardado(ByVal prmrow As DataRow) As ClsReporteGuarda
            If prmrow Is Nothing Then
                Return Nothing
            End If

            Dim prmobj As New ClsReporteGuarda()
            prmobj.Folio = prmrow("nReporteGuarda")
            prmobj.Reporte = FabricaReportes.ObtenReportes(prmrow("nReporte"))
            prmobj.Descripcion = prmrow("cNombreReporte")
            prmobj.TituloReporte = prmrow("cTitutoReporte")
            Dim c As New IO.StringReader(prmrow("cconfiguracion"))
            prmobj.aDataset.ReadXml(c, XmlReadMode.Auto)
            If Not prmrow("ccamporelativo") Is DBNull.Value Then
                prmobj.CampoRelativo = prmrow("ccamporelativo")
            End If
            prmobj.Usuario = prmrow("cUsuario")
            prmobj.Fecha = prmrow("dFecha")
            prmobj.Publico = prmrow("bPublico")
            prmobj.EliminaRegistros = prmrow("bEliminaRegistros")

            Return prmobj
        End Function

        Public Shared Function getCadenaConeccion() As String
            Dim cadena As String
            Dim DAO As DataAccessCls = DAO.DevuelveInstancia
            cadena = "Data Source=" & DAO.GetNombreServidor & ";Initial Catalog=" & DAO.GetNombreBaseDeDatos & ";User ID=sa" & ";Password=" & "Adsum12"
            Return cadena
        End Function

        ' ''Public Shared Function ObtenFiltrosStoreProcedure(ByVal prmStore As String) As SqlClient.SqlParameterCollection

        ' ''    Dim objConecction As SqlClient.SqlConnection
        ' ''    Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        ' ''    Dim sc As SqlClient.SqlCommand
        ' ''    Dim sd As SqlClient.SqlDataAdapter
        ' ''    Dim sq As SqlClient.SqlCommandBuilder
        ' ''    Dim dt As New DataTable

        ' ''    Return DAO.RegresaParametrosStoreProcedure(prmStore)

        ' ''    objConecction = New SqlClient.SqlConnection(getCadenaConeccion())
        ' ''    objConecction.Open()
        ' ''    sc = New SqlClient.SqlCommand(prmStore, objConecction)
        ' ''    sc.CommandType = CommandType.StoredProcedure
        ' ''    If Not objConecction.State = ConnectionState.Open Then
        ' ''        objConecction.Open()
        ' ''    End If

        ' ''    'SqlCommandBuilder.DeriveParameters(salesCMD)
        ' ''    'nwindConn.Close()

        ' ''    'sd = New SqlClient.SqlDataAdapter()
        ' ''    'sc = New SqlClient.SqlCommand(prmStore, objConecction)
        ' ''    'sc.CommandType = CommandType.StoredProcedure

        ' ''    'sd = New SqlClient.SqlDataAdapter(sc)

        ' ''    'sq = New SqlClient.SqlCommandBuilder(sd)

        ' ''    'SqlClient.SqlCommandBuilder.DeriveParameters()


        ' ''    Try
        ' ''        sq.DeriveParameters(sc)
        ' ''    Catch ex As Exception
        ' ''        System.Windows.Forms.MessageBox.Show(ex.ToString, Comunes.Comun.ClsTools.GlobalSistemaCaption, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
        ' ''    Finally
        ' ''        objConecction.Close()
        ' ''    End Try

        ' ''    Return sc.Parameters

        ' ''    'Dim sc As SqlClient.SqlCommand
        ' ''    'Dim sd As SqlClient.SqlDataAdapter
        ' ''    'Dim sq As SqlClient.SqlCommandBuilder
        ' ''    'Dim dt As New DataTable
        ' ''    'Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia

        ' ''    'DAO.LlenaTablaDeDatos("Select 'Coneccion'", sd, dt)

        ' ''    'sc = New SqlClient.SqlCommand(prmStore, sd.SelectCommand.Connection)
        ' ''    'sc.CommandType = CommandType.StoredProcedure

        ' ''    'sd = New SqlClient.SqlDataAdapter(sc)


        ' ''    'sq = New SqlClient.SqlCommandBuilder(sd)

        ' ''    'Try
        ' ''    '    sq.DeriveParameters(sc)
        ' ''    'Catch ex As Exception
        ' ''    '    System.Windows.Forms.MessageBox.Show(ex.ToString, Comunes.Comun.ClsTools.GlobalSistemaCaption, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Exclamation)
        ' ''    'Finally
        ' ''    '    objConecction.Close()
        ' ''    'End Try

        ' ''    'Return sc.Parameters

        ' ''End Function

        Public Shared Function ObtenBatchReporte(ByVal prmReporte As Integer, ByVal dt As DataTable)
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String
            'vSQL = "Select nReporteGuarda, nReporte, cConfiguracion From Adsum_ReporteExpressGuarda (Nolock) " & vbCr
            vSQL = "Select * From Adsum_ReporteExpressGuarda (Nolock) " & vbCr
            vSQL &= "Where nReporte=13 and bActivo=1 "
            DAO.RegresaConsultaSQL(vSQL, dt)
        End Function

        Public Shared Function ObtenFolioFormato(ByVal prmValor As String) As Integer
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String = ""
            Dim dtTipos As New DataTable
            Dim nFormato As Object

            vSQL = "Select F.nFormato  From Adsum_tiposDatos T(Nolock)" & vbCr
            vSQL &= "Inner join Adsum_ReportesFormatosColumnas F (Nolock) On F.nFormato=T.nValor" & vbCr
            vSQL &= "where cLlave='REP_TIPODATOS' and cValor='" & prmValor.Trim & "'"
            nFormato = DAO.RegresaDatoSQL(vSQL)

            Return nFormato

        End Function

        Public Shared Function obtenFormatoTipoDato(ByVal prmValor As String) As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String = ""
            Dim dtTipos As New DataTable
            Dim cFormato As Object

            vSQL = "Select F.cFormato From Adsum_tiposDatos T(Nolock)" & vbCr
            vSQL &= "Inner join Adsum_ReportesFormatosColumnas F (Nolock) On F.nFormato=T.nValor" & vbCr
            vSQL &= "where cLlave='REP_TIPODATOS' and T.cValor='" & prmValor.Trim & "'"
            cFormato = DAO.RegresaDatoSQL(vSQL)

            Return cFormato
        End Function

        Public Shared Function ObtenCampoFormateado(ByVal prmvalor As String) As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String = ""
            Dim dtTipos As New DataTable
            Dim cFormato As Object

            vSQL = "Select T.cValor From Adsum_tiposDatos T(Nolock)" & vbCr
            vSQL &= "Inner join Adsum_ReportesFormatosColumnas F (Nolock) On F.nFormato=T.nValor" & vbCr
            vSQL &= "where cLlave='REP_TIPODATOS' and F.cFormato='" & prmvalor.Trim & "'"
            cFormato = DAO.RegresaDatoSQL(vSQL)

            Return cFormato
        End Function

        Public Shared Function ObtenCampoFormateado(ByVal prmvalor As Integer) As String
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String = ""
            Dim dtTipos As New DataTable
            Dim cFormato As Object

            vSQL = "Select T.cValor From Adsum_tiposDatos T(Nolock)" & vbCr
            vSQL &= "Inner join Adsum_ReportesFormatosColumnas F (Nolock) On F.nFormato=T.nValor" & vbCr
            vSQL &= "where cLlave='REP_TIPODATOS' and F.nFormato=" & prmvalor
            cFormato = DAO.RegresaDatoSQL(vSQL)

            Return cFormato
        End Function


        Public Shared Function ObtenCamposCalculados(ByVal prmReporte As String) As DataTable
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String = ""
            Dim dt As New DataTable

            vSQL = "SELECT * FROM ADSUM_ReporteExpressCalculados (NOLOCK)" & vbCr
            vSQL &= "Where nReporte=" & prmReporte
            DAO.RegresaConsultaSQL(vSQL, dt)

            Return dt
        End Function

        Public Shared Function EliminaCampoCalculado(ByVal prmReporte As Integer, ByVal prmCampoCalculado As String) As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQL As String
            Dim bExito As Boolean

            vSQL = "Delete ADSUM_ReporteExpressCalculados Where nReporte=" & prmReporte & " and cCampo='" & prmCampoCalculado.Trim & "'"

            bExito = DAO.EjecutaComandoSQL(vSQL)
            Return bExito
        End Function


        Public Sub New()

        End Sub

    End Class
End Namespace
