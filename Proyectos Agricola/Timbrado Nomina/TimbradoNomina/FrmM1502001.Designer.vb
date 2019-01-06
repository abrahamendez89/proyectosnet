<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmM1502001
    Inherits Sistema.AccessForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmM1502001))
        Me.DSFacturaElectronica = New System.Data.DataSet()
        Me.DtArchivos = New System.Data.DataTable()
        Me.DataColumn9 = New System.Data.DataColumn()
        Me.DataColumn10 = New System.Data.DataColumn()
        Me.DataColumn11 = New System.Data.DataColumn()
        Me.DataColumn12 = New System.Data.DataColumn()
        Me.DataColumn13 = New System.Data.DataColumn()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CboTipoPago = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GrdFacturaElectronica = New DevExpress.XtraGrid.GridControl()
        Me.GrvFactElectronica = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColClave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EditClaveSucursal = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ColEmpleado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColFactura = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColResultado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeleccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ChkFacturar = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.EditSubtotalGrid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditIVAGrid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditImpNoAcredGrid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditClaveGastoGrid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditClaveImpuestoGrid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditRetencionIVAGrid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditRetencionISRGrid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditPorcentajeIVA = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.EditnCantidad = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.CboUnidad = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.dgv_datos = New System.Windows.Forms.DataGridView()
        Me.CLAVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TRABAJADOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RESULTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnTimbrar = New System.Windows.Forms.Button()
        Me.CboTemporada = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtSemana = New Sistema.AccTextBoxAdvanced()
        Me.TxtFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.TxtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.OptAdmin = New System.Windows.Forms.RadioButton()
        Me.OptCampo = New System.Windows.Forms.RadioButton()
        Me.OptEmpaque = New System.Windows.Forms.RadioButton()
        Me.TxtFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnConsultar = New System.Windows.Forms.Button()
        Me.OptAdmImuris = New System.Windows.Forms.RadioButton()
        Me.cmb_Nomina = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmb_tipoTimbre = New System.Windows.Forms.ComboBox()
        Me.btn_rfc = New System.Windows.Forms.Button()
        Me.btn_numDiasCorregir = New System.Windows.Forms.Button()
        Me.btn_cancelarTimbre = New System.Windows.Forms.Button()
        Me.pb_progreso = New System.Windows.Forms.ProgressBar()
        Me.btn_EnviarPDF = New System.Windows.Forms.Button()
        Me.btn_marcarTodos = New System.Windows.Forms.Button()
        Me.btn_DesmarcarTodos = New System.Windows.Forms.Button()
        Me.btn_recuperarAcuses = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_timbresRestantes = New System.Windows.Forms.TextBox()
        CType(Me.DSFacturaElectronica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GrdFacturaElectronica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrvFactElectronica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditClaveSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkFacturar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditSubtotalGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditIVAGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditImpNoAcredGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditClaveGastoGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditClaveImpuestoGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditRetencionIVAGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditRetencionISRGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditPorcentajeIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditnCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DSFacturaElectronica
        '
        Me.DSFacturaElectronica.DataSetName = "NewDataSet"
        Me.DSFacturaElectronica.Tables.AddRange(New System.Data.DataTable() {Me.DtArchivos})
        '
        'DtArchivos
        '
        Me.DtArchivos.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn9, Me.DataColumn10, Me.DataColumn11, Me.DataColumn12, Me.DataColumn13, Me.DataColumn1})
        Me.DtArchivos.TableName = "DtArchivos"
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "cCveEmpl"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "cNombre"
        '
        'DataColumn11
        '
        Me.DataColumn11.Caption = "nFactura"
        Me.DataColumn11.ColumnName = "nFactura"
        Me.DataColumn11.DataType = GetType(Integer)
        '
        'DataColumn12
        '
        Me.DataColumn12.ColumnName = "cExitoError"
        '
        'DataColumn13
        '
        Me.DataColumn13.ColumnName = "bSeleccion"
        Me.DataColumn13.DataType = GetType(Boolean)
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "nFolio"
        Me.DataColumn1.ReadOnly = True
        '
        'CboTipoPago
        '
        Me.CboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoPago.FormattingEnabled = True
        Me.CboTipoPago.Location = New System.Drawing.Point(502, 151)
        Me.CboTipoPago.Name = "CboTipoPago"
        Me.CboTipoPago.Size = New System.Drawing.Size(300, 22)
        Me.CboTipoPago.TabIndex = 11
        Me.CboTipoPago.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.GrdFacturaElectronica)
        Me.GroupBox3.Controls.Add(Me.CboTipoPago)
        Me.GroupBox3.Controls.Add(Me.dgv_datos)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 100)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1175, 273)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Trabajadores"
        '
        'GrdFacturaElectronica
        '
        Me.GrdFacturaElectronica.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrdFacturaElectronica.DataMember = "DtArchivos"
        Me.GrdFacturaElectronica.DataSource = Me.DSFacturaElectronica
        '
        '
        '
        Me.GrdFacturaElectronica.EmbeddedNavigator.Name = ""
        Me.GrdFacturaElectronica.Location = New System.Drawing.Point(17, 21)
        Me.GrdFacturaElectronica.MainView = Me.GrvFactElectronica
        Me.GrdFacturaElectronica.Name = "GrdFacturaElectronica"
        Me.GrdFacturaElectronica.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.EditSubtotalGrid, Me.EditIVAGrid, Me.EditImpNoAcredGrid, Me.EditClaveGastoGrid, Me.EditClaveImpuestoGrid, Me.EditRetencionIVAGrid, Me.EditRetencionISRGrid, Me.EditPorcentajeIVA, Me.EditClaveSucursal, Me.EditnCantidad, Me.CboUnidad, Me.ChkFacturar})
        Me.GrdFacturaElectronica.Size = New System.Drawing.Size(1144, 234)
        Me.GrdFacturaElectronica.TabIndex = 14
        Me.GrdFacturaElectronica.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GrvFactElectronica})
        '
        'GrvFactElectronica
        '
        Me.GrvFactElectronica.ColumnPanelRowHeight = 50
        Me.GrvFactElectronica.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColClave, Me.ColEmpleado, Me.ColFactura, Me.ColResultado, Me.ColSeleccion})
        Me.GrvFactElectronica.GridControl = Me.GrdFacturaElectronica
        Me.GrvFactElectronica.Name = "GrvFactElectronica"
        Me.GrvFactElectronica.OptionsPrint.AutoWidth = False
        Me.GrvFactElectronica.OptionsView.ColumnAutoWidth = False
        '
        'ColClave
        '
        Me.ColClave.AppearanceHeader.Options.UseTextOptions = True
        Me.ColClave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColClave.Caption = "Clave"
        Me.ColClave.ColumnEdit = Me.EditClaveSucursal
        Me.ColClave.DisplayFormat.FormatString = "000"
        Me.ColClave.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ColClave.FieldName = "cCveEmpl"
        Me.ColClave.Name = "ColClave"
        Me.ColClave.OptionsColumn.AllowEdit = False
        Me.ColClave.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColClave.OptionsColumn.ReadOnly = True
        Me.ColClave.Visible = True
        Me.ColClave.VisibleIndex = 0
        Me.ColClave.Width = 64
        '
        'EditClaveSucursal
        '
        Me.EditClaveSucursal.AutoHeight = False
        Me.EditClaveSucursal.MaxLength = 3
        Me.EditClaveSucursal.Name = "EditClaveSucursal"
        '
        'ColEmpleado
        '
        Me.ColEmpleado.AppearanceHeader.Options.UseTextOptions = True
        Me.ColEmpleado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColEmpleado.Caption = "Empleado"
        Me.ColEmpleado.FieldName = "cNombre"
        Me.ColEmpleado.Name = "ColEmpleado"
        Me.ColEmpleado.OptionsColumn.AllowEdit = False
        Me.ColEmpleado.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColEmpleado.OptionsColumn.ReadOnly = True
        Me.ColEmpleado.Visible = True
        Me.ColEmpleado.VisibleIndex = 1
        Me.ColEmpleado.Width = 338
        '
        'ColFactura
        '
        Me.ColFactura.AppearanceCell.Options.UseTextOptions = True
        Me.ColFactura.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColFactura.AppearanceHeader.Options.UseTextOptions = True
        Me.ColFactura.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColFactura.Caption = "Factura"
        Me.ColFactura.FieldName = "nFactura"
        Me.ColFactura.Name = "ColFactura"
        Me.ColFactura.OptionsColumn.AllowEdit = False
        Me.ColFactura.OptionsColumn.ReadOnly = True
        Me.ColFactura.Width = 152
        '
        'ColResultado
        '
        Me.ColResultado.AppearanceHeader.Options.UseTextOptions = True
        Me.ColResultado.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColResultado.Caption = "Resultado"
        Me.ColResultado.DisplayFormat.FormatString = "{0:c2}"
        Me.ColResultado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColResultado.FieldName = "cExitoError"
        Me.ColResultado.Name = "ColResultado"
        Me.ColResultado.OptionsColumn.AllowEdit = False
        Me.ColResultado.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColResultado.OptionsColumn.ReadOnly = True
        Me.ColResultado.Visible = True
        Me.ColResultado.VisibleIndex = 2
        Me.ColResultado.Width = 461
        '
        'ColSeleccion
        '
        Me.ColSeleccion.Caption = "Sel."
        Me.ColSeleccion.ColumnEdit = Me.ChkFacturar
        Me.ColSeleccion.FieldName = "bSeleccion"
        Me.ColSeleccion.Name = "ColSeleccion"
        Me.ColSeleccion.Visible = True
        Me.ColSeleccion.VisibleIndex = 3
        Me.ColSeleccion.Width = 40
        '
        'ChkFacturar
        '
        Me.ChkFacturar.AutoHeight = False
        Me.ChkFacturar.Name = "ChkFacturar"
        '
        'EditSubtotalGrid
        '
        Me.EditSubtotalGrid.AutoHeight = False
        Me.EditSubtotalGrid.MaxLength = 12
        Me.EditSubtotalGrid.Name = "EditSubtotalGrid"
        '
        'EditIVAGrid
        '
        Me.EditIVAGrid.AutoHeight = False
        Me.EditIVAGrid.MaxLength = 12
        Me.EditIVAGrid.Name = "EditIVAGrid"
        '
        'EditImpNoAcredGrid
        '
        Me.EditImpNoAcredGrid.AutoHeight = False
        Me.EditImpNoAcredGrid.MaxLength = 12
        Me.EditImpNoAcredGrid.Name = "EditImpNoAcredGrid"
        '
        'EditClaveGastoGrid
        '
        Me.EditClaveGastoGrid.AutoHeight = False
        Me.EditClaveGastoGrid.MaxLength = 3
        Me.EditClaveGastoGrid.Name = "EditClaveGastoGrid"
        '
        'EditClaveImpuestoGrid
        '
        Me.EditClaveImpuestoGrid.AutoHeight = False
        Me.EditClaveImpuestoGrid.MaxLength = 3
        Me.EditClaveImpuestoGrid.Name = "EditClaveImpuestoGrid"
        '
        'EditRetencionIVAGrid
        '
        Me.EditRetencionIVAGrid.AutoHeight = False
        Me.EditRetencionIVAGrid.MaxLength = 12
        Me.EditRetencionIVAGrid.Name = "EditRetencionIVAGrid"
        '
        'EditRetencionISRGrid
        '
        Me.EditRetencionISRGrid.AutoHeight = False
        Me.EditRetencionISRGrid.MaxLength = 12
        Me.EditRetencionISRGrid.Name = "EditRetencionISRGrid"
        '
        'EditPorcentajeIVA
        '
        Me.EditPorcentajeIVA.AutoHeight = False
        Me.EditPorcentajeIVA.MaxLength = 6
        Me.EditPorcentajeIVA.Name = "EditPorcentajeIVA"
        '
        'EditnCantidad
        '
        Me.EditnCantidad.AutoHeight = False
        Me.EditnCantidad.Mask.EditMask = "#####0.0000;"
        Me.EditnCantidad.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.EditnCantidad.Name = "EditnCantidad"
        '
        'CboUnidad
        '
        Me.CboUnidad.AutoHeight = False
        Me.CboUnidad.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CboUnidad.Name = "CboUnidad"
        Me.CboUnidad.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'dgv_datos
        '
        Me.dgv_datos.AllowUserToAddRows = False
        Me.dgv_datos.AllowUserToDeleteRows = False
        Me.dgv_datos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CLAVE, Me.TRABAJADOR, Me.RESULTADO})
        Me.dgv_datos.Location = New System.Drawing.Point(17, 22)
        Me.dgv_datos.Name = "dgv_datos"
        Me.dgv_datos.ReadOnly = True
        Me.dgv_datos.Size = New System.Drawing.Size(1142, 232)
        Me.dgv_datos.TabIndex = 15
        Me.dgv_datos.Visible = False
        '
        'CLAVE
        '
        Me.CLAVE.HeaderText = "CLAVE"
        Me.CLAVE.Name = "CLAVE"
        Me.CLAVE.ReadOnly = True
        Me.CLAVE.Width = 150
        '
        'TRABAJADOR
        '
        Me.TRABAJADOR.HeaderText = "TRABAJADOR"
        Me.TRABAJADOR.Name = "TRABAJADOR"
        Me.TRABAJADOR.ReadOnly = True
        Me.TRABAJADOR.Width = 350
        '
        'RESULTADO
        '
        Me.RESULTADO.HeaderText = "RESULTADO"
        Me.RESULTADO.Name = "RESULTADO"
        Me.RESULTADO.ReadOnly = True
        Me.RESULTADO.Width = 150
        '
        'BtnTimbrar
        '
        Me.BtnTimbrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTimbrar.Location = New System.Drawing.Point(1042, 407)
        Me.BtnTimbrar.Name = "BtnTimbrar"
        Me.BtnTimbrar.Size = New System.Drawing.Size(137, 34)
        Me.BtnTimbrar.TabIndex = 48
        Me.BtnTimbrar.Text = "Timbrar"
        Me.BtnTimbrar.UseVisualStyleBackColor = True
        '
        'CboTemporada
        '
        Me.CboTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTemporada.FormattingEnabled = True
        Me.CboTemporada.Location = New System.Drawing.Point(111, 6)
        Me.CboTemporada.Name = "CboTemporada"
        Me.CboTemporada.Size = New System.Drawing.Size(300, 22)
        Me.CboTemporada.TabIndex = 49
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label12.Location = New System.Drawing.Point(30, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 14)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Temporada"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(50, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 14)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Semana"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtSemana
        '
        Me.TxtSemana.BlancoEsValorInvalido = True
        Me.TxtSemana.CadenaDescripcionNoValida = "Codigo no existe"
        Me.TxtSemana.CaracterValorNuevo = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TxtSemana.CatalogoBase = Nothing
        Me.TxtSemana.CatalogoPrincipal = False
        Me.TxtSemana.ColorDesactivado = System.Drawing.Color.Empty
        Me.TxtSemana.ControlDestinoDescripcion = Nothing
        Me.TxtSemana.DescripcionElementoInvalido = "Codigo no existe"
        Me.TxtSemana.EnPantalla = False
        Me.TxtSemana.FiltroExtendido = ""
        Me.TxtSemana.LanzarMensajeError = False
        Me.TxtSemana.Location = New System.Drawing.Point(111, 34)
        Me.TxtSemana.Multiple = False
        Me.TxtSemana.Name = "TxtSemana"
        Me.TxtSemana.PermiteAvanceElementoInvalido = True
        Me.TxtSemana.PermiteAyudaRapida = True
        Me.TxtSemana.PermiteSoloCapturarAlfanumericos = True
        Me.TxtSemana.Size = New System.Drawing.Size(35, 22)
        Me.TxtSemana.TabIndex = 51
        Me.TxtSemana.Tag = "Serie"
        Me.TxtSemana.TeclaAyuda = System.Windows.Forms.Keys.F1
        Me.TxtSemana.TituloMensaje = "Agricola la Primavera"
        Me.TxtSemana.ValorValido = False
        '
        'TxtFechaIni
        '
        Me.TxtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechaIni.Location = New System.Drawing.Point(152, 34)
        Me.TxtFechaIni.Name = "TxtFechaIni"
        Me.TxtFechaIni.Size = New System.Drawing.Size(92, 22)
        Me.TxtFechaIni.TabIndex = 53
        '
        'TxtFechaFin
        '
        Me.TxtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechaFin.Location = New System.Drawing.Point(250, 34)
        Me.TxtFechaFin.Name = "TxtFechaFin"
        Me.TxtFechaFin.Size = New System.Drawing.Size(92, 22)
        Me.TxtFechaFin.TabIndex = 54
        '
        'OptAdmin
        '
        Me.OptAdmin.AutoSize = True
        Me.OptAdmin.Location = New System.Drawing.Point(539, 7)
        Me.OptAdmin.Name = "OptAdmin"
        Me.OptAdmin.Size = New System.Drawing.Size(108, 18)
        Me.OptAdmin.TabIndex = 55
        Me.OptAdmin.TabStop = True
        Me.OptAdmin.Text = "Natura Culiacán"
        Me.OptAdmin.UseVisualStyleBackColor = True
        '
        'OptCampo
        '
        Me.OptCampo.AutoSize = True
        Me.OptCampo.Location = New System.Drawing.Point(653, 7)
        Me.OptCampo.Name = "OptCampo"
        Me.OptCampo.Size = New System.Drawing.Size(97, 18)
        Me.OptCampo.TabIndex = 56
        Me.OptCampo.TabStop = True
        Me.OptCampo.Text = "Natura Imuris"
        Me.OptCampo.UseVisualStyleBackColor = True
        '
        'OptEmpaque
        '
        Me.OptEmpaque.AutoSize = True
        Me.OptEmpaque.Location = New System.Drawing.Point(756, 7)
        Me.OptEmpaque.Name = "OptEmpaque"
        Me.OptEmpaque.Size = New System.Drawing.Size(148, 18)
        Me.OptEmpaque.TabIndex = 57
        Me.OptEmpaque.TabStop = True
        Me.OptEmpaque.Text = "Administrativo Culiacán"
        Me.OptEmpaque.UseVisualStyleBackColor = True
        '
        'TxtFechaPago
        '
        Me.TxtFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TxtFechaPago.Location = New System.Drawing.Point(457, 38)
        Me.TxtFechaPago.Name = "TxtFechaPago"
        Me.TxtFechaPago.Size = New System.Drawing.Size(92, 22)
        Me.TxtFechaPago.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(355, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 14)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Fecha de Pago"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Location = New System.Drawing.Point(1058, 32)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(121, 34)
        Me.BtnConsultar.TabIndex = 60
        Me.BtnConsultar.Text = "Consultar"
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'OptAdmImuris
        '
        Me.OptAdmImuris.AutoSize = True
        Me.OptAdmImuris.Location = New System.Drawing.Point(910, 7)
        Me.OptAdmImuris.Name = "OptAdmImuris"
        Me.OptAdmImuris.Size = New System.Drawing.Size(142, 18)
        Me.OptAdmImuris.TabIndex = 61
        Me.OptAdmImuris.TabStop = True
        Me.OptAdmImuris.Text = "Administrativos Imuris"
        Me.OptAdmImuris.UseVisualStyleBackColor = True
        '
        'cmb_Nomina
        '
        Me.cmb_Nomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Nomina.FormattingEnabled = True
        Me.cmb_Nomina.Location = New System.Drawing.Point(617, 37)
        Me.cmb_Nomina.Name = "cmb_Nomina"
        Me.cmb_Nomina.Size = New System.Drawing.Size(162, 22)
        Me.cmb_Nomina.TabIndex = 62
        Me.cmb_Nomina.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(555, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Nómina:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(785, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 14)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Tipo de timbre:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label3.Visible = False
        '
        'cmb_tipoTimbre
        '
        Me.cmb_tipoTimbre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipoTimbre.FormattingEnabled = True
        Me.cmb_tipoTimbre.Location = New System.Drawing.Point(891, 38)
        Me.cmb_tipoTimbre.Name = "cmb_tipoTimbre"
        Me.cmb_tipoTimbre.Size = New System.Drawing.Size(161, 22)
        Me.cmb_tipoTimbre.TabIndex = 64
        Me.cmb_tipoTimbre.Visible = False
        '
        'btn_rfc
        '
        Me.btn_rfc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_rfc.Location = New System.Drawing.Point(409, 407)
        Me.btn_rfc.Name = "btn_rfc"
        Me.btn_rfc.Size = New System.Drawing.Size(163, 34)
        Me.btn_rfc.TabIndex = 66
        Me.btn_rfc.Text = "Actualizar RFC y CURP"
        Me.btn_rfc.UseVisualStyleBackColor = True
        '
        'btn_numDiasCorregir
        '
        Me.btn_numDiasCorregir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_numDiasCorregir.Location = New System.Drawing.Point(578, 407)
        Me.btn_numDiasCorregir.Name = "btn_numDiasCorregir"
        Me.btn_numDiasCorregir.Size = New System.Drawing.Size(163, 34)
        Me.btn_numDiasCorregir.TabIndex = 68
        Me.btn_numDiasCorregir.Text = "Corregir Problema NumDias"
        Me.btn_numDiasCorregir.UseVisualStyleBackColor = True
        '
        'btn_cancelarTimbre
        '
        Me.btn_cancelarTimbre.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_cancelarTimbre.Location = New System.Drawing.Point(33, 407)
        Me.btn_cancelarTimbre.Name = "btn_cancelarTimbre"
        Me.btn_cancelarTimbre.Size = New System.Drawing.Size(163, 34)
        Me.btn_cancelarTimbre.TabIndex = 69
        Me.btn_cancelarTimbre.Text = "Cancelar Timbres"
        Me.btn_cancelarTimbre.UseVisualStyleBackColor = True
        '
        'pb_progreso
        '
        Me.pb_progreso.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_progreso.Location = New System.Drawing.Point(33, 379)
        Me.pb_progreso.Name = "pb_progreso"
        Me.pb_progreso.Size = New System.Drawing.Size(1146, 13)
        Me.pb_progreso.TabIndex = 70
        '
        'btn_EnviarPDF
        '
        Me.btn_EnviarPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_EnviarPDF.Location = New System.Drawing.Point(899, 407)
        Me.btn_EnviarPDF.Name = "btn_EnviarPDF"
        Me.btn_EnviarPDF.Size = New System.Drawing.Size(137, 34)
        Me.btn_EnviarPDF.TabIndex = 71
        Me.btn_EnviarPDF.Text = "Enviar a PDF"
        Me.btn_EnviarPDF.UseVisualStyleBackColor = True
        '
        'btn_marcarTodos
        '
        Me.btn_marcarTodos.Location = New System.Drawing.Point(33, 71)
        Me.btn_marcarTodos.Name = "btn_marcarTodos"
        Me.btn_marcarTodos.Size = New System.Drawing.Size(142, 23)
        Me.btn_marcarTodos.TabIndex = 72
        Me.btn_marcarTodos.Text = "Marcar Todos"
        Me.btn_marcarTodos.UseVisualStyleBackColor = True
        '
        'btn_DesmarcarTodos
        '
        Me.btn_DesmarcarTodos.Location = New System.Drawing.Point(181, 71)
        Me.btn_DesmarcarTodos.Name = "btn_DesmarcarTodos"
        Me.btn_DesmarcarTodos.Size = New System.Drawing.Size(142, 23)
        Me.btn_DesmarcarTodos.TabIndex = 73
        Me.btn_DesmarcarTodos.Text = "Desmarcar Todos"
        Me.btn_DesmarcarTodos.UseVisualStyleBackColor = True
        '
        'btn_recuperarAcuses
        '
        Me.btn_recuperarAcuses.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_recuperarAcuses.Location = New System.Drawing.Point(946, 72)
        Me.btn_recuperarAcuses.Name = "btn_recuperarAcuses"
        Me.btn_recuperarAcuses.Size = New System.Drawing.Size(233, 23)
        Me.btn_recuperarAcuses.TabIndex = 74
        Me.btn_recuperarAcuses.Text = "Recuperar Acuses faltantes"
        Me.btn_recuperarAcuses.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(634, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 14)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Timbres restantes:"
        '
        'txt_timbresRestantes
        '
        Me.txt_timbresRestantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_timbresRestantes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_timbresRestantes.Location = New System.Drawing.Point(749, 73)
        Me.txt_timbresRestantes.Name = "txt_timbresRestantes"
        Me.txt_timbresRestantes.ReadOnly = True
        Me.txt_timbresRestantes.Size = New System.Drawing.Size(100, 23)
        Me.txt_timbresRestantes.TabIndex = 76
        Me.txt_timbresRestantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmM1502001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 471)
        Me.Controls.Add(Me.txt_timbresRestantes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_recuperarAcuses)
        Me.Controls.Add(Me.btn_DesmarcarTodos)
        Me.Controls.Add(Me.btn_marcarTodos)
        Me.Controls.Add(Me.btn_EnviarPDF)
        Me.Controls.Add(Me.pb_progreso)
        Me.Controls.Add(Me.btn_cancelarTimbre)
        Me.Controls.Add(Me.btn_numDiasCorregir)
        Me.Controls.Add(Me.btn_rfc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_Nomina)
        Me.Controls.Add(Me.cmb_tipoTimbre)
        Me.Controls.Add(Me.OptAdmImuris)
        Me.Controls.Add(Me.BtnConsultar)
        Me.Controls.Add(Me.TxtFechaPago)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OptEmpaque)
        Me.Controls.Add(Me.OptCampo)
        Me.Controls.Add(Me.OptAdmin)
        Me.Controls.Add(Me.TxtFechaFin)
        Me.Controls.Add(Me.TxtFechaIni)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtSemana)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.CboTemporada)
        Me.Controls.Add(Me.BtnTimbrar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmM1502001"
        Me.ReferenciaRapidaVisible = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ""
        Me.Controls.SetChildIndex(Me.lblToolTip, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.BtnTimbrar, 0)
        Me.Controls.SetChildIndex(Me.CboTemporada, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.TxtSemana, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtFechaIni, 0)
        Me.Controls.SetChildIndex(Me.TxtFechaFin, 0)
        Me.Controls.SetChildIndex(Me.OptAdmin, 0)
        Me.Controls.SetChildIndex(Me.OptCampo, 0)
        Me.Controls.SetChildIndex(Me.OptEmpaque, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtFechaPago, 0)
        Me.Controls.SetChildIndex(Me.BtnConsultar, 0)
        Me.Controls.SetChildIndex(Me.OptAdmImuris, 0)
        Me.Controls.SetChildIndex(Me.cmb_tipoTimbre, 0)
        Me.Controls.SetChildIndex(Me.cmb_Nomina, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btn_rfc, 0)
        Me.Controls.SetChildIndex(Me.btn_numDiasCorregir, 0)
        Me.Controls.SetChildIndex(Me.btn_cancelarTimbre, 0)
        Me.Controls.SetChildIndex(Me.pb_progreso, 0)
        Me.Controls.SetChildIndex(Me.btn_EnviarPDF, 0)
        Me.Controls.SetChildIndex(Me.btn_marcarTodos, 0)
        Me.Controls.SetChildIndex(Me.btn_DesmarcarTodos, 0)
        Me.Controls.SetChildIndex(Me.btn_recuperarAcuses, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txt_timbresRestantes, 0)
        CType(Me.DSFacturaElectronica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GrdFacturaElectronica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrvFactElectronica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditClaveSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkFacturar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditSubtotalGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditIVAGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditImpNoAcredGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditClaveGastoGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditClaveImpuestoGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditRetencionIVAGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditRetencionISRGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditPorcentajeIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditnCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MxGrdFacturaElectronica As DriverXtraGrid
    Friend WithEvents DSFacturaElectronica As System.Data.DataSet


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CboTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents DtArchivos As System.Data.DataTable
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents DataColumn11 As System.Data.DataColumn
    Friend WithEvents DataColumn12 As System.Data.DataColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataColumn13 As System.Data.DataColumn
    Friend WithEvents BtnTimbrar As System.Windows.Forms.Button
    Friend WithEvents MxGrdArchivos As DriverXtraGrid
    Friend WithEvents CboTemporada As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtSemana As Sistema.AccTextBoxAdvanced
    Friend WithEvents TxtFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents OptAdmin As System.Windows.Forms.RadioButton
    Friend WithEvents OptCampo As System.Windows.Forms.RadioButton
    Friend WithEvents OptEmpaque As System.Windows.Forms.RadioButton
    Friend WithEvents TxtFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnConsultar As System.Windows.Forms.Button
    Friend WithEvents OptAdmImuris As System.Windows.Forms.RadioButton
    Private WithEvents GrdFacturaElectronica As DevExpress.XtraGrid.GridControl
    Private WithEvents GrvFactElectronica As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents ColClave As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents EditClaveSucursal As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents ColEmpleado As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents ColFactura As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents CboUnidad As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Private WithEvents EditnCantidad As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents ColResultado As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents EditSubtotalGrid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents EditIVAGrid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents EditImpNoAcredGrid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents EditClaveImpuestoGrid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents EditClaveGastoGrid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents EditRetencionIVAGrid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents EditRetencionISRGrid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents EditPorcentajeIVA As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Private WithEvents ColSeleccion As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents ChkFacturar As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents cmb_Nomina As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipoTimbre As System.Windows.Forms.ComboBox
    Friend WithEvents btn_rfc As System.Windows.Forms.Button
    Friend WithEvents dgv_datos As System.Windows.Forms.DataGridView
    Friend WithEvents CLAVE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TRABAJADOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RESULTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_numDiasCorregir As System.Windows.Forms.Button
    Friend WithEvents btn_cancelarTimbre As System.Windows.Forms.Button
    Friend WithEvents pb_progreso As System.Windows.Forms.ProgressBar
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents btn_EnviarPDF As System.Windows.Forms.Button
    Friend WithEvents btn_marcarTodos As System.Windows.Forms.Button
    Friend WithEvents btn_DesmarcarTodos As System.Windows.Forms.Button
    Friend WithEvents btn_recuperarAcuses As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_timbresRestantes As System.Windows.Forms.TextBox
End Class
