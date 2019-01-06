Imports Access
Namespace Comunes.Comun
    Public Class ClsReporteGuarda
        Inherits ClsBaseComun

        Private atrReporte As ClsReportes
        Private atrDataset As New DataSet
        Private atrTituloReporte As String
        Private atrColumnas As System.Windows.Forms.ListView
        Private atrFiltros As DataTable
        Private atrClasificadores As DataTable
        Private atrAgrupacion As System.Windows.Forms.ListView
        Private atrOrdenacion As System.Windows.Forms.ListView
        Private atrTotales As System.Windows.Forms.ListView
        Private atrColorFondo As System.Windows.Forms.ListView
        Private atrColorLetra As System.Windows.Forms.ListView
        Private atrCampoRelativo As String
        Private atrUsuario As String
        Private atrFecha As DateTime
        Private atrPublico As Boolean
        Private atrEliminaRegistros As Boolean


        Public Function RenombraReporte() As Boolean
            Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
            Dim vSQLText As String = ""
            vSQLText = "UPDATE ADSUM_ReporteExpressGuarda SET bPublico=" & IIf(Me.Publico, 1, 0) & ", cNombreReporte = '" & Me.Descripcion & "'" & vbCr
            vSQLText &= " WHERE nReporte = " & Me.Reporte.Folio & " AND nReporteGuarda = " & Me.Folio
            Return DAO.EjecutaComandoSQL(vSQLText)
        End Function

        Public Function Reactivar() As Boolean
            Return EscribanoReportes.ReactivarReporte(Me)
        End Function

        Public Property CampoRelativo() As String
            Get
                Return atrCampoRelativo
            End Get
            Set(ByVal value As String)
                atrCampoRelativo = value
            End Set
        End Property

        Public Property Columnas() As System.Windows.Forms.ListView
            Get
                Return atrColumnas
            End Get
            Set(ByVal value As System.Windows.Forms.ListView)
                atrColumnas = value
            End Set
        End Property

        Public Property Filtros() As DataTable
            Get
                Return atrFiltros
            End Get
            Set(ByVal value As DataTable)
                atrFiltros = value
            End Set
        End Property

        Public Property Clasificadores() As DataTable
            Get
                Return atrClasificadores
            End Get
            Set(ByVal value As DataTable)
                atrClasificadores = value
            End Set
        End Property

        Public Property Agrupacion() As System.Windows.Forms.ListView
            Get
                Return atrAgrupacion
            End Get
            Set(ByVal value As System.Windows.Forms.ListView)
                atrAgrupacion = value
            End Set
        End Property

        Public Property Ordenacion() As System.Windows.Forms.ListView
            Get
                Return atrOrdenacion
            End Get
            Set(ByVal value As System.Windows.Forms.ListView)
                atrOrdenacion = value
            End Set
        End Property

        Public Property Totales() As System.Windows.Forms.ListView
            Get
                Return atrTotales
            End Get
            Set(ByVal value As System.Windows.Forms.ListView)
                atrTotales = value
            End Set
        End Property

        Public Property ColorFondo() As System.Windows.Forms.ListView
            Get
                Return atrColorFondo
            End Get
            Set(ByVal value As System.Windows.Forms.ListView)
                atrColorFondo = value
            End Set
        End Property

        Public Property ColorLetra() As System.Windows.Forms.ListView
            Get
                Return atrColorLetra
            End Get
            Set(ByVal value As System.Windows.Forms.ListView)
                atrColorLetra = value
            End Set
        End Property

        Public Property Reporte() As ClsReportes
            Get
                Return atrReporte
            End Get
            Set(ByVal value As ClsReportes)
                atrReporte = value
            End Set
        End Property

        Public Property aDataset() As DataSet
            Get
                Return atrDataset
            End Get
            Set(ByVal value As DataSet)
                atrDataset = value
            End Set
        End Property

        Public Property TituloReporte() As String
            Get
                Return atrTituloReporte
            End Get
            Set(ByVal value As String)
                atrTituloReporte = value
            End Set
        End Property

        Public Property Usuario() As String
            Get
                Return atrUsuario
            End Get
            Set(ByVal value As String)
                atrUsuario = value
            End Set
        End Property

        Public Property Fecha() As DateTime
            Get
                Return atrFecha
            End Get
            Set(ByVal value As DateTime)
                atrFecha = value
            End Set
        End Property

        Public Property Publico() As Boolean
            Get
                Return atrPublico
            End Get
            Set(ByVal value As Boolean)
                atrPublico = value
            End Set
        End Property

        Public Property EliminaRegistros() As Boolean
            Get
                Return atrEliminaRegistros
            End Get
            Set(ByVal value As Boolean)
                atrEliminaRegistros = value
            End Set
        End Property

        Public Overrides Function FormatoFolio() As String
            Return ""
        End Function

        Public Overrides Function getNombreFolioAdministrado() As String
            DAO.FolioAdministradoAgregar("Adsum_ReporteExpressGuarda", "Adsum_ReporteExpressGuarda")
            Return "Adsum_ReporteExpressGuarda"
        End Function

        Public Overrides Function getRow() As ClsBaseComun.ObtenerRowEventHandler
            Return AddressOf FabricaReportes.ObtenReporteGuardado
        End Function

        Public Overrides Function Guardar() As Boolean
            If Activo Then
                Dim dtRepo As New DataTable
                dtRepo.Columns.Add("Columnas", GetType(DataTable))
                dtRepo.Columns.Add("Agrupacion", GetType(DataTable))
                dtRepo.Columns.Add("Ordenacion", GetType(DataTable))
                dtRepo.Columns.Add("Totales", GetType(DataTable))

                dtRepo.Rows.Add(dtRepo.NewRow)
                dtRepo.Rows(0)("Columnas") = New DataTable
                dtRepo.Rows(0)("Agrupacion") = New DataTable
                dtRepo.Rows(0)("Ordenacion") = New DataTable
                dtRepo.Rows(0)("Totales") = New DataTable

                dtRepo.Rows(0)("Columnas").Columns.Add("cCampo", GetType(String))
                'Se agrego para el guardado de los colores en los batch
                dtRepo.Rows(0)("Columnas").Columns.Add("nColorFondo", GetType(Integer))
                dtRepo.Rows(0)("Columnas").Columns.Add("nColorLetra", GetType(Integer))
                dtRepo.Rows(0)("Agrupacion").Columns.Add("cCampo", GetType(String))
                dtRepo.Rows(0)("Ordenacion").Columns.Add("cCampo", GetType(String))
                dtRepo.Rows(0)("Totales").Columns.Add("cCampo", GetType(String))

                If atrReporte.ModificaColumnas Then
                    For Each vitem As System.Windows.Forms.ListViewItem In atrColumnas.Items
                        Dim dr As DataRow = dtRepo.Rows(0)("Columnas").NewRow
                        dr("ccampo") = vitem.Name.Trim
                        dr("nColorFondo") = vitem.BackColor.ToArgb
                        dr("nColorLetra") = vitem.ForeColor.ToArgb
                        dtRepo.Rows(0)("Columnas").rows.add(dr)
                    Next
                End If
                If atrReporte.ModificaAgrupacion Then
                    For Each vitem As System.Windows.Forms.ListViewItem In atrAgrupacion.Items
                        Dim dr As DataRow = dtRepo.Rows(0)("Agrupacion").NewRow
                        dr("ccampo") = vitem.Name.Trim
                        dtRepo.Rows(0)("Agrupacion").rows.add(dr)
                    Next
                End If
                If atrReporte.ModificaOrdenacion Then
                    For Each vitem As System.Windows.Forms.ListViewItem In atrOrdenacion.Items
                        Dim dr As DataRow = dtRepo.Rows(0)("Ordenacion").NewRow
                        dr("ccampo") = vitem.Name.Trim
                        dtRepo.Rows(0)("Ordenacion").rows.add(dr)
                    Next
                End If
                If atrReporte.ModificaTotales Then
                    For Each vitem As System.Windows.Forms.ListViewItem In atrTotales.Items
                        Dim dr As DataRow = dtRepo.Rows(0)("Totales").NewRow
                        dr("ccampo") = vitem.Name.Trim
                        dtRepo.Rows(0)("Totales").rows.add(dr)
                    Next
                End If
                Dim tempfiltros As New DataTable
                'Comunes.Comun.ClsTools.copiaRows(atrFiltros.Select(""), tempfiltros, atrFiltros.Columns)
                'tempfiltros.Columns.Add("cCampo", GetType(String))
                tempfiltros.Columns.Add("Alias", GetType(String))
                tempfiltros.Columns.Add("Valor", GetType(String))
                tempfiltros.Columns.Add("Valor2", GetType(String))
                tempfiltros.Columns.Add("Excluir", GetType(Boolean))
                tempfiltros.Columns.Add("bClasificador", GetType(String))
                tempfiltros.Columns.Add("cNombreClasificador", GetType(String))
                tempfiltros.Columns.Add("cClasificadores", GetType(String))

                For Each vRow As DataRow In atrFiltros.Rows
                    Dim vr As DataRow = tempfiltros.NewRow
                    vr("Alias") = vRow("cAlias")
                    vr("cNombreClasificador") = vRow("cNombreClasificador")
                    If vRow("cTipoSeleccion") <> "Rango" Then
                        vr("Valor") = vRow("Obj").Value
                    Else
                        vr("Valor") = vRow("Obj").Value1
                        vr("Valor2") = vRow("Obj").Value2
                    End If
                    If vRow("cTipoSeleccion") <> "Boleano" And vRow("cTipoSeleccion") <> "Fecha" Then
                        vr("Excluir") = vRow("obj").Excluir
                        vr("bClasificador") = vRow("obj").Clasificador
                    Else
                        vr("Excluir") = False
                        vr("bClasificador") = False
                    End If
                    tempfiltros.Rows.Add(vr)
                Next
                'tempfiltros.Columns.Remove("Obj")
                Dim dtcampos As New DataTable
                Dim dtClasificadores As New DataTable
                ClsTools.copiaRows(atrReporte.CamposGlobal.ArregloDataTable.Select, dtcampos, atrReporte.CamposGlobal.ArregloDataTable.Columns)
                If Not atrClasificadores Is Nothing Then
                    ClsTools.copiaRows(atrClasificadores.Select, dtClasificadores, atrClasificadores.Columns)
                End If
                atrDataset.Tables.Clear()
                atrDataset.Tables.Add(dtRepo.Rows(0)("Columnas"))
                atrDataset.Tables.Add(dtRepo.Rows(0)("Agrupacion"))
                atrDataset.Tables.Add(dtRepo.Rows(0)("Ordenacion"))
                atrDataset.Tables.Add(dtRepo.Rows(0)("Totales"))
                atrDataset.Tables.Add(dtcampos)
                atrDataset.Tables.Add(tempfiltros)
                atrDataset.Tables.Add(dtClasificadores)
            End If
            Return EscribanoReportes.Guardar(Me)
        End Function
    End Class
End Namespace

