Imports Access
Public Class ClsSencilla

    Public Delegate Sub onActivaClasificador(ByVal prmObj As Object)
    Public ActivaClasificador As onActivaClasificador

    Public Delegate Sub onDesActivaClasificador(ByVal prmObj As Object)
    Public DesActivaClasificador As onDesActivaClasificador

    Public atrdecimal As Boolean = False
    Public atrEntero As Boolean = False
    Private atrCodigoIncorrecto As Boolean = False

    Private atrRowFiltro As DataRow
    Private atrFiltrosGlobalReporte As DataTable
    Private atrDTPermisos As DataTable

    Public Property RowFiltro() As DataRow
        Get
            Return atrRowFiltro
        End Get
        Set(ByVal value As DataRow)
            atrRowFiltro = value
        End Set
    End Property
    Public Property FiltrosGlobal() As DataTable
        Get
            Return atrFiltrosGlobalReporte
        End Get
        Set(ByVal value As DataTable)
            atrFiltrosGlobalReporte = value
        End Set
    End Property
    Public Property DTPermisos() As DataTable
        Get
            Return atrDTPermisos
        End Get
        Set(ByVal value As DataTable)
            atrDTPermisos = value
        End Set
    End Property


    Public Property UsaClasificador() As Boolean
        Get
            Return CheckBox2.Visible
        End Get
        Set(ByVal value As Boolean)
            CheckBox2.Visible = value
        End Set
    End Property

    Public Property Clasificador() As Boolean
        Get
            Return CheckBox2.Checked
        End Get
        Set(ByVal value As Boolean)
            CheckBox2.Checked = value
        End Set
    End Property

    Public Property ExcluirVisible() As Boolean
        Get
            Return CheckBox1.Visible
        End Get
        Set(ByVal value As Boolean)
            CheckBox1.Visible = value
        End Set
    End Property

    Public Property Excluir() As Boolean
        Get
            Return CheckBox1.Checked
        End Get
        Set(ByVal value As Boolean)

            CheckBox1.Checked = value
        End Set
    End Property

    Public Property ClasificadorNombre() As String
        Get
            Return CheckBox2.Tag
        End Get
        Set(ByVal value As String)
            CheckBox2.Tag = value
        End Set
    End Property

    Public Property Value() As String
        Get
            Return AccTextBoxAdvanced1.Text
        End Get
        Set(ByVal value As String)
            AccTextBoxAdvanced1.Text = value
        End Set
    End Property

    Public Property Metacatalogo() As String
        Get
            If Not AccTextBoxAdvanced1.CatalogoBase Is Nothing Then
                Return AccTextBoxAdvanced1.CatalogoBase.NombreMetaCatalogo
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            AccTextBoxAdvanced1.CatalogoBase = New Catalogo(New MetaCatalogo(value))
            AccTextBoxAdvanced1.ControlDestinoDescripcion = Label2
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal value As String)
            Label1.Text = value
        End Set
    End Property

    Public Property CodigoIncorrecto() As Boolean
        Get
            Return atrCodigoIncorrecto
        End Get
        Set(ByVal value As Boolean)
            atrCodigoIncorrecto = value
        End Set
    End Property

    Public WriteOnly Property ControlDestino() As Boolean
        Set(ByVal value As Boolean)
            Label2.Visible = value
        End Set
    End Property

    Private Sub ClsSencilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            AccTextBoxAdvanced1.Text = ""
            AccTextBoxAdvanced1.Enabled = False
            ActivaClasificador(Me)
        Else
            AccTextBoxAdvanced1.Enabled = True
            DesActivaClasificador(Me)
        End If
    End Sub

    Public Function ValidayObtenDescripcion() As Boolean
        AccTextBoxAdvanced1.ValidayObtenDescripcion()
        Return AccTextBoxAdvanced1.ValorValido
    End Function

    Private Sub AccTextBoxAdvanced1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AccTextBoxAdvanced1.KeyPress
        If AccTextBoxAdvanced1.CatalogoBase Is Nothing And atrdecimal Then
            Comunes.Comun.ClsTools.ValidaCajaNumerosDecimales(sender, e)
        ElseIf AccTextBoxAdvanced1.CatalogoBase Is Nothing And atrEntero Then
            Comunes.Comun.ClsTools.ValidaCajaNumerica(sender, e)
        End If
    End Sub

    Public Sub ConfiguraFiltrosPermisos(ByRef prmRow As DataRow, ByRef prmDTPermisos As DataTable, ByVal prmValidating As Boolean, ByVal prmSugerirDefault As Boolean)
        'Desarrolló: Lic. Jesus Fernando Zamora Angulo
        'Configura los filtros extendidos para metacatálogos que dependan de permisos generales
        If Comunes.Comun.Permisos.ClsManejadorPermisos.ConfiguraFiltrosPermisosReporteador(AccTextBoxAdvanced1, prmRow, prmDTPermisos, prmValidating, prmSugerirDefault) Then
            LanzaValidating()
        End If
    End Sub


    Public Sub LanzaValidating()
        Me.ClsSencilla_Validating(Me, New System.ComponentModel.CancelEventArgs)
    End Sub

    Private Sub ClsSencilla_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        If CType(sender, ClsSencilla).Metacatalogo = "" Then Return
        If Not CType(sender, ClsSencilla).ValidayObtenDescripcion AndAlso CType(sender, ClsSencilla).Value <> "" And CType(sender, ClsSencilla).Label2.Text.Trim = "" Then
            System.Windows.Forms.MessageBox.Show(Comunes.Comun.ClsTools.GlobalSistemaCodigoNoExiste, Comunes.Comun.ClsTools.GlobalSistemaCaption, Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
            CType(sender, ClsSencilla).Value = ""
            CType(sender, ClsSencilla).CodigoIncorrecto = True
            e.Cancel = True
            Exit Sub
        End If

        If CType(sender, ClsSencilla).RowFiltro Is Nothing Then Exit Sub



        If Comunes.Comun.ClsTools.IfNull(CType(sender, ClsSencilla).RowFiltro("bEsPermiso"), False) Then
            'Es permiso principal, obtenemos todos `los catàlogos a los que tiene que filtrar
            For Each dr As DataRow In atrFiltrosGlobalReporte.Select("nTipoPermiso = " & CType(sender, ClsSencilla).RowFiltro("nTipoPermiso") & " AND bFiltrarPermiso = True")
                If dr("obj") Is DBNull.Value Then Continue For
                Select Case dr("cTipoSeleccion")
                    Case "Sencillo"
                        CType(dr("obj"), ClsSencilla).ConfiguraFiltrosPermisos(dr, atrDTPermisos, True, False)
                    Case "Multiple"
                        CType(dr("obj"), ClsMultiple).ConfiguraFiltrosPermisos(dr, atrDTPermisos, True, False)
                End Select
            Next
        End If
    End Sub

    Public Sub ValidaElementoSecundarioPermisos()
        If Me.AccTextBoxAdvanced1.Text.Trim = "" OrElse Me.AccTextBoxAdvanced1.CatalogoBase Is Nothing Then Exit Sub

        Dim DAO As DataAccessCls = DataAccessCls.DevuelveInstancia
        Dim vcWHERE As String = " WHERE 1 = 1"
        Dim vcSQL As String = "SELECT 1 FROM " & Me.AccTextBoxAdvanced1.CatalogoBase.MetaCatalogoBase.SqlVistaCatalogo & " (NOLOCK) " & vbCr
        If Not Me.AccTextBoxAdvanced1.CatalogoBase.FiltroExtendido Is Nothing AndAlso Not Me.AccTextBoxAdvanced1.CatalogoBase.FiltroExtendido = "" Then
            vcWHERE &= " AND " & Me.AccTextBoxAdvanced1.CatalogoBase.FiltroExtendido.Trim & vbCr
        End If
        vcWHERE &= " AND " & Me.AccTextBoxAdvanced1.CatalogoBase.MetaCatalogoBase.CampoPrimario & " = " & Me.AccTextBoxAdvanced1.Text.Trim
        vcSQL &= vcWHERE

        If Not DAO.ExistenDatosEnConsultaSQL(vcSQL) Then
            Me.AccTextBoxAdvanced1.Text = ""
        End If

    End Sub
End Class
