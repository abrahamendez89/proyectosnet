<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdjuntarXMLAPolizas
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
        Me.cmb_temporadas = New System.Windows.Forms.ComboBox()
        Me.btn_consultar_semana = New System.Windows.Forms.Button()
        Me.cmb_nomina = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_semana = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_empresasPolizas = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmb_tipoPolizas = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_Ejercicio = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_mes = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chb_sinXML = New System.Windows.Forms.CheckBox()
        Me.chb_conXML = New System.Windows.Forms.CheckBox()
        Me.btn_quitarPoliza = New System.Windows.Forms.Button()
        Me.cmb_polizasSeleccionadas = New System.Windows.Forms.ComboBox()
        Me.btn_agregarPoliza = New System.Windows.Forms.Button()
        Me.dgv_polizas = New System.Windows.Forms.DataGridView()
        Me.btn_consultar_polizas = New System.Windows.Forms.Button()
        Me.dgv_nomina = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_totalPoliza = New System.Windows.Forms.TextBox()
        Me.txt_totalXML = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btn_AsignarPolizaSemana = New System.Windows.Forms.Button()
        Me.tc_tabs = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chb_aguinaldos = New System.Windows.Forms.CheckBox()
        Me.chb_vacaciones = New System.Windows.Forms.CheckBox()
        Me.chb_liquidaciones = New System.Windows.Forms.CheckBox()
        Me.chb_sueldos = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmb_empresasNomina = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txt_UUIDXML = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_FechaEMISION = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btn_QuitarXMLCombo = New System.Windows.Forms.Button()
        Me.txt_descReceptor = New System.Windows.Forms.TextBox()
        Me.cmb_xmlAgregados = New System.Windows.Forms.ComboBox()
        Me.btn_agregarXMLCombo = New System.Windows.Forms.Button()
        Me.txt_descEmisor = New System.Windows.Forms.TextBox()
        Me.txt_RFCReceptorXML = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_RFCEmisorXML = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_folioXML = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_ImporteXML = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.wb = New System.Windows.Forms.WebBrowser()
        Me.btn_buscarXML = New System.Windows.Forms.Button()
        Me.txt_rutaArchivoXML = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btn_quitarPolizaFAC_XML = New System.Windows.Forms.Button()
        Me.cmb_polizasFAC_XML = New System.Windows.Forms.ComboBox()
        Me.btn_agregarPolizaFAC_XML = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dgv_polizasCargosFAC_XML = New System.Windows.Forms.DataGridView()
        Me.btn_consultarPolizasFAC_XML = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmb_mesFAC_XML = New System.Windows.Forms.ComboBox()
        Me.cmb_empresasPolizasFAC_XML = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmb_EjercicioFAC_XML = New System.Windows.Forms.ComboBox()
        Me.cmb_tipoPolizasFAC_XML = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_polizas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_nomina, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc_tabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgv_polizasCargosFAC_XML, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblToolTip
        '
        Me.lblToolTip.Size = New System.Drawing.Size(19, 25)
        '
        'cmb_temporadas
        '
        Me.cmb_temporadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_temporadas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_temporadas.FormattingEnabled = True
        Me.cmb_temporadas.Location = New System.Drawing.Point(96, 65)
        Me.cmb_temporadas.Name = "cmb_temporadas"
        Me.cmb_temporadas.Size = New System.Drawing.Size(139, 24)
        Me.cmb_temporadas.TabIndex = 23
        '
        'btn_consultar_semana
        '
        Me.btn_consultar_semana.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultar_semana.Location = New System.Drawing.Point(299, 92)
        Me.btn_consultar_semana.Name = "btn_consultar_semana"
        Me.btn_consultar_semana.Size = New System.Drawing.Size(114, 27)
        Me.btn_consultar_semana.TabIndex = 22
        Me.btn_consultar_semana.Text = "Consultar"
        Me.btn_consultar_semana.UseVisualStyleBackColor = True
        '
        'cmb_nomina
        '
        Me.cmb_nomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_nomina.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_nomina.FormattingEnabled = True
        Me.cmb_nomina.Items.AddRange(New Object() {"Natura Culiacán", "Natura Imuris", "Tecnica Culiacán", "Tecnica Imuris"})
        Me.cmb_nomina.Location = New System.Drawing.Point(96, 36)
        Me.cmb_nomina.Name = "cmb_nomina"
        Me.cmb_nomina.Size = New System.Drawing.Size(317, 24)
        Me.cmb_nomina.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Nómina:"
        '
        'txt_semana
        '
        Me.txt_semana.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_semana.Location = New System.Drawing.Point(319, 64)
        Me.txt_semana.Name = "txt_semana"
        Me.txt_semana.Size = New System.Drawing.Size(94, 23)
        Me.txt_semana.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(243, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Semana:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Temporada:"
        '
        'cmb_empresasPolizas
        '
        Me.cmb_empresasPolizas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresasPolizas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_empresasPolizas.FormattingEnabled = True
        Me.cmb_empresasPolizas.Location = New System.Drawing.Point(86, 21)
        Me.cmb_empresasPolizas.Name = "cmb_empresasPolizas"
        Me.cmb_empresasPolizas.Size = New System.Drawing.Size(536, 24)
        Me.cmb_empresasPolizas.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Empresa:"
        '
        'cmb_tipoPolizas
        '
        Me.cmb_tipoPolizas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipoPolizas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipoPolizas.FormattingEnabled = True
        Me.cmb_tipoPolizas.Location = New System.Drawing.Point(86, 50)
        Me.cmb_tipoPolizas.Name = "cmb_tipoPolizas"
        Me.cmb_tipoPolizas.Size = New System.Drawing.Size(536, 24)
        Me.cmb_tipoPolizas.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Tipo póliza:"
        '
        'cmb_Ejercicio
        '
        Me.cmb_Ejercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Ejercicio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Ejercicio.FormattingEnabled = True
        Me.cmb_Ejercicio.Location = New System.Drawing.Point(86, 78)
        Me.cmb_Ejercicio.Name = "cmb_Ejercicio"
        Me.cmb_Ejercicio.Size = New System.Drawing.Size(153, 24)
        Me.cmb_Ejercicio.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Ejercicio:"
        '
        'cmb_mes
        '
        Me.cmb_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_mes.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_mes.FormattingEnabled = True
        Me.cmb_mes.Location = New System.Drawing.Point(482, 78)
        Me.cmb_mes.Name = "cmb_mes"
        Me.cmb_mes.Size = New System.Drawing.Size(140, 24)
        Me.cmb_mes.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(440, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 16)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Mes:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox1.Controls.Add(Me.chb_sinXML)
        Me.GroupBox1.Controls.Add(Me.chb_conXML)
        Me.GroupBox1.Controls.Add(Me.btn_quitarPoliza)
        Me.GroupBox1.Controls.Add(Me.cmb_polizasSeleccionadas)
        Me.GroupBox1.Controls.Add(Me.btn_agregarPoliza)
        Me.GroupBox1.Controls.Add(Me.dgv_polizas)
        Me.GroupBox1.Controls.Add(Me.btn_consultar_polizas)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmb_mes)
        Me.GroupBox1.Controls.Add(Me.cmb_empresasPolizas)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmb_Ejercicio)
        Me.GroupBox1.Controls.Add(Me.cmb_tipoPolizas)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 409)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pólizas"
        '
        'chb_sinXML
        '
        Me.chb_sinXML.AutoSize = True
        Me.chb_sinXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_sinXML.Location = New System.Drawing.Point(213, 113)
        Me.chb_sinXML.Name = "chb_sinXML"
        Me.chb_sinXML.Size = New System.Drawing.Size(189, 20)
        Me.chb_sinXML.TabIndex = 41
        Me.chb_sinXML.Text = "Mostrar unicamente SIN xml"
        Me.chb_sinXML.UseVisualStyleBackColor = True
        '
        'chb_conXML
        '
        Me.chb_conXML.AutoSize = True
        Me.chb_conXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_conXML.Location = New System.Drawing.Point(13, 113)
        Me.chb_conXML.Name = "chb_conXML"
        Me.chb_conXML.Size = New System.Drawing.Size(194, 20)
        Me.chb_conXML.TabIndex = 40
        Me.chb_conXML.Text = "Mostrar unicamente CON xml"
        Me.chb_conXML.UseVisualStyleBackColor = True
        '
        'btn_quitarPoliza
        '
        Me.btn_quitarPoliza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_quitarPoliza.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitarPoliza.Location = New System.Drawing.Point(418, 378)
        Me.btn_quitarPoliza.Name = "btn_quitarPoliza"
        Me.btn_quitarPoliza.Size = New System.Drawing.Size(139, 24)
        Me.btn_quitarPoliza.TabIndex = 39
        Me.btn_quitarPoliza.Text = "Quitar póliza"
        Me.btn_quitarPoliza.UseVisualStyleBackColor = True
        '
        'cmb_polizasSeleccionadas
        '
        Me.cmb_polizasSeleccionadas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb_polizasSeleccionadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_polizasSeleccionadas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_polizasSeleccionadas.FormattingEnabled = True
        Me.cmb_polizasSeleccionadas.Location = New System.Drawing.Point(151, 378)
        Me.cmb_polizasSeleccionadas.Name = "cmb_polizasSeleccionadas"
        Me.cmb_polizasSeleccionadas.Size = New System.Drawing.Size(263, 24)
        Me.cmb_polizasSeleccionadas.TabIndex = 38
        '
        'btn_agregarPoliza
        '
        Me.btn_agregarPoliza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_agregarPoliza.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregarPoliza.Location = New System.Drawing.Point(6, 378)
        Me.btn_agregarPoliza.Name = "btn_agregarPoliza"
        Me.btn_agregarPoliza.Size = New System.Drawing.Size(139, 24)
        Me.btn_agregarPoliza.TabIndex = 37
        Me.btn_agregarPoliza.Text = "Agregar"
        Me.btn_agregarPoliza.UseVisualStyleBackColor = True
        '
        'dgv_polizas
        '
        Me.dgv_polizas.AllowUserToAddRows = False
        Me.dgv_polizas.AllowUserToDeleteRows = False
        Me.dgv_polizas.AllowUserToOrderColumns = True
        Me.dgv_polizas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv_polizas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.dgv_polizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_polizas.Location = New System.Drawing.Point(6, 142)
        Me.dgv_polizas.MultiSelect = False
        Me.dgv_polizas.Name = "dgv_polizas"
        Me.dgv_polizas.ReadOnly = True
        Me.dgv_polizas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_polizas.Size = New System.Drawing.Size(617, 227)
        Me.dgv_polizas.TabIndex = 34
        '
        'btn_consultar_polizas
        '
        Me.btn_consultar_polizas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultar_polizas.Location = New System.Drawing.Point(418, 109)
        Me.btn_consultar_polizas.Name = "btn_consultar_polizas"
        Me.btn_consultar_polizas.Size = New System.Drawing.Size(204, 27)
        Me.btn_consultar_polizas.TabIndex = 24
        Me.btn_consultar_polizas.Text = "Consultar pólizas del periodo"
        Me.btn_consultar_polizas.UseVisualStyleBackColor = True
        '
        'dgv_nomina
        '
        Me.dgv_nomina.AllowUserToAddRows = False
        Me.dgv_nomina.AllowUserToDeleteRows = False
        Me.dgv_nomina.AllowUserToOrderColumns = True
        Me.dgv_nomina.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_nomina.Location = New System.Drawing.Point(6, 127)
        Me.dgv_nomina.MultiSelect = False
        Me.dgv_nomina.Name = "dgv_nomina"
        Me.dgv_nomina.ReadOnly = True
        Me.dgv_nomina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_nomina.Size = New System.Drawing.Size(534, 237)
        Me.dgv_nomina.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(313, 430)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 19)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Total en pólizas:"
        '
        'txt_totalPoliza
        '
        Me.txt_totalPoliza.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_totalPoliza.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totalPoliza.Location = New System.Drawing.Point(445, 427)
        Me.txt_totalPoliza.Name = "txt_totalPoliza"
        Me.txt_totalPoliza.ReadOnly = True
        Me.txt_totalPoliza.Size = New System.Drawing.Size(179, 27)
        Me.txt_totalPoliza.TabIndex = 37
        '
        'txt_totalXML
        '
        Me.txt_totalXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_totalXML.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_totalXML.Location = New System.Drawing.Point(1012, 427)
        Me.txt_totalXML.Name = "txt_totalXML"
        Me.txt_totalXML.ReadOnly = True
        Me.txt_totalXML.Size = New System.Drawing.Size(179, 27)
        Me.txt_totalXML.TabIndex = 39
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(901, 430)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 19)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Total en XML:"
        '
        'btn_AsignarPolizaSemana
        '
        Me.btn_AsignarPolizaSemana.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AsignarPolizaSemana.Location = New System.Drawing.Point(946, 459)
        Me.btn_AsignarPolizaSemana.Name = "btn_AsignarPolizaSemana"
        Me.btn_AsignarPolizaSemana.Size = New System.Drawing.Size(245, 32)
        Me.btn_AsignarPolizaSemana.TabIndex = 40
        Me.btn_AsignarPolizaSemana.Text = "Asignar XML a póliza"
        Me.btn_AsignarPolizaSemana.UseVisualStyleBackColor = True
        '
        'tc_tabs
        '
        Me.tc_tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tc_tabs.Controls.Add(Me.TabPage1)
        Me.tc_tabs.Controls.Add(Me.TabPage2)
        Me.tc_tabs.Controls.Add(Me.TabPage3)
        Me.tc_tabs.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tc_tabs.Location = New System.Drawing.Point(647, 12)
        Me.tc_tabs.Name = "tc_tabs"
        Me.tc_tabs.SelectedIndex = 0
        Me.tc_tabs.Size = New System.Drawing.Size(556, 406)
        Me.tc_tabs.TabIndex = 41
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chb_aguinaldos)
        Me.TabPage1.Controls.Add(Me.chb_vacaciones)
        Me.TabPage1.Controls.Add(Me.chb_liquidaciones)
        Me.TabPage1.Controls.Add(Me.chb_sueldos)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cmb_empresasNomina)
        Me.TabPage1.Controls.Add(Me.dgv_nomina)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmb_nomina)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_semana)
        Me.TabPage1.Controls.Add(Me.cmb_temporadas)
        Me.TabPage1.Controls.Add(Me.btn_consultar_semana)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 32)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(548, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Nómina"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chb_aguinaldos
        '
        Me.chb_aguinaldos.AutoSize = True
        Me.chb_aguinaldos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_aguinaldos.Location = New System.Drawing.Point(419, 81)
        Me.chb_aguinaldos.Name = "chb_aguinaldos"
        Me.chb_aguinaldos.Size = New System.Drawing.Size(89, 20)
        Me.chb_aguinaldos.TabIndex = 41
        Me.chb_aguinaldos.Text = "Aguinaldos"
        Me.chb_aguinaldos.UseVisualStyleBackColor = True
        '
        'chb_vacaciones
        '
        Me.chb_vacaciones.AutoSize = True
        Me.chb_vacaciones.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_vacaciones.Location = New System.Drawing.Point(419, 58)
        Me.chb_vacaciones.Name = "chb_vacaciones"
        Me.chb_vacaciones.Size = New System.Drawing.Size(91, 20)
        Me.chb_vacaciones.TabIndex = 40
        Me.chb_vacaciones.Text = "Vacaciones"
        Me.chb_vacaciones.UseVisualStyleBackColor = True
        '
        'chb_liquidaciones
        '
        Me.chb_liquidaciones.AutoSize = True
        Me.chb_liquidaciones.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_liquidaciones.Location = New System.Drawing.Point(419, 32)
        Me.chb_liquidaciones.Name = "chb_liquidaciones"
        Me.chb_liquidaciones.Size = New System.Drawing.Size(103, 20)
        Me.chb_liquidaciones.TabIndex = 39
        Me.chb_liquidaciones.Text = "Liquidaciones"
        Me.chb_liquidaciones.UseVisualStyleBackColor = True
        '
        'chb_sueldos
        '
        Me.chb_sueldos.AutoSize = True
        Me.chb_sueldos.Checked = True
        Me.chb_sueldos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chb_sueldos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chb_sueldos.Location = New System.Drawing.Point(419, 6)
        Me.chb_sueldos.Name = "chb_sueldos"
        Me.chb_sueldos.Size = New System.Drawing.Size(130, 20)
        Me.chb_sueldos.TabIndex = 38
        Me.chb_sueldos.Text = "Sueldos y salarios"
        Me.chb_sueldos.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 16)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Empresa:"
        '
        'cmb_empresasNomina
        '
        Me.cmb_empresasNomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresasNomina.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_empresasNomina.FormattingEnabled = True
        Me.cmb_empresasNomina.Location = New System.Drawing.Point(96, 6)
        Me.cmb_empresasNomina.Name = "cmb_empresasNomina"
        Me.cmb_empresasNomina.Size = New System.Drawing.Size(317, 24)
        Me.cmb_empresasNomina.TabIndex = 37
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txt_UUIDXML)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txt_FechaEMISION)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.btn_QuitarXMLCombo)
        Me.TabPage2.Controls.Add(Me.txt_descReceptor)
        Me.TabPage2.Controls.Add(Me.cmb_xmlAgregados)
        Me.TabPage2.Controls.Add(Me.btn_agregarXMLCombo)
        Me.TabPage2.Controls.Add(Me.txt_descEmisor)
        Me.TabPage2.Controls.Add(Me.txt_RFCReceptorXML)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.txt_RFCEmisorXML)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txt_folioXML)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.txt_ImporteXML)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.wb)
        Me.TabPage2.Controls.Add(Me.btn_buscarXML)
        Me.TabPage2.Controls.Add(Me.txt_rutaArchivoXML)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(548, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Adjuntar XML Manual"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txt_UUIDXML
        '
        Me.txt_UUIDXML.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_UUIDXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_UUIDXML.Location = New System.Drawing.Point(301, 249)
        Me.txt_UUIDXML.Name = "txt_UUIDXML"
        Me.txt_UUIDXML.ReadOnly = True
        Me.txt_UUIDXML.Size = New System.Drawing.Size(240, 23)
        Me.txt_UUIDXML.TabIndex = 56
        '
        'Label17
        '
        Me.Label17.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(257, 252)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 16)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "UUID:"
        '
        'txt_FechaEMISION
        '
        Me.txt_FechaEMISION.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_FechaEMISION.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FechaEMISION.Location = New System.Drawing.Point(102, 249)
        Me.txt_FechaEMISION.Name = "txt_FechaEMISION"
        Me.txt_FechaEMISION.ReadOnly = True
        Me.txt_FechaEMISION.Size = New System.Drawing.Size(146, 23)
        Me.txt_FechaEMISION.TabIndex = 54
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(5, 252)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 16)
        Me.Label16.TabIndex = 53
        Me.Label16.Text = "Fecha Emisión:"
        '
        'btn_QuitarXMLCombo
        '
        Me.btn_QuitarXMLCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_QuitarXMLCombo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_QuitarXMLCombo.Location = New System.Drawing.Point(400, 336)
        Me.btn_QuitarXMLCombo.Name = "btn_QuitarXMLCombo"
        Me.btn_QuitarXMLCombo.Size = New System.Drawing.Size(141, 24)
        Me.btn_QuitarXMLCombo.TabIndex = 42
        Me.btn_QuitarXMLCombo.Text = "Quitar XML"
        Me.btn_QuitarXMLCombo.UseVisualStyleBackColor = True
        '
        'txt_descReceptor
        '
        Me.txt_descReceptor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descReceptor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descReceptor.Location = New System.Drawing.Point(254, 307)
        Me.txt_descReceptor.Name = "txt_descReceptor"
        Me.txt_descReceptor.ReadOnly = True
        Me.txt_descReceptor.Size = New System.Drawing.Size(287, 23)
        Me.txt_descReceptor.TabIndex = 52
        '
        'cmb_xmlAgregados
        '
        Me.cmb_xmlAgregados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmb_xmlAgregados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_xmlAgregados.DropDownWidth = 500
        Me.cmb_xmlAgregados.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_xmlAgregados.FormattingEnabled = True
        Me.cmb_xmlAgregados.Location = New System.Drawing.Point(131, 336)
        Me.cmb_xmlAgregados.Name = "cmb_xmlAgregados"
        Me.cmb_xmlAgregados.Size = New System.Drawing.Size(263, 24)
        Me.cmb_xmlAgregados.TabIndex = 41
        '
        'btn_agregarXMLCombo
        '
        Me.btn_agregarXMLCombo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_agregarXMLCombo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregarXMLCombo.Location = New System.Drawing.Point(5, 336)
        Me.btn_agregarXMLCombo.Name = "btn_agregarXMLCombo"
        Me.btn_agregarXMLCombo.Size = New System.Drawing.Size(120, 24)
        Me.btn_agregarXMLCombo.TabIndex = 40
        Me.btn_agregarXMLCombo.Text = "Agregar"
        Me.btn_agregarXMLCombo.UseVisualStyleBackColor = True
        '
        'txt_descEmisor
        '
        Me.txt_descEmisor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_descEmisor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_descEmisor.Location = New System.Drawing.Point(254, 278)
        Me.txt_descEmisor.Name = "txt_descEmisor"
        Me.txt_descEmisor.ReadOnly = True
        Me.txt_descEmisor.Size = New System.Drawing.Size(287, 23)
        Me.txt_descEmisor.TabIndex = 51
        '
        'txt_RFCReceptorXML
        '
        Me.txt_RFCReceptorXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_RFCReceptorXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_RFCReceptorXML.Location = New System.Drawing.Point(102, 307)
        Me.txt_RFCReceptorXML.Name = "txt_RFCReceptorXML"
        Me.txt_RFCReceptorXML.ReadOnly = True
        Me.txt_RFCReceptorXML.Size = New System.Drawing.Size(146, 23)
        Me.txt_RFCReceptorXML.TabIndex = 50
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 310)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 16)
        Me.Label15.TabIndex = 49
        Me.Label15.Text = "Receptor:"
        '
        'txt_RFCEmisorXML
        '
        Me.txt_RFCEmisorXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_RFCEmisorXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_RFCEmisorXML.Location = New System.Drawing.Point(102, 278)
        Me.txt_RFCEmisorXML.Name = "txt_RFCEmisorXML"
        Me.txt_RFCEmisorXML.ReadOnly = True
        Me.txt_RFCEmisorXML.Size = New System.Drawing.Size(146, 23)
        Me.txt_RFCEmisorXML.TabIndex = 48
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 281)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 16)
        Me.Label14.TabIndex = 47
        Me.Label14.Text = "Emisor:"
        '
        'txt_folioXML
        '
        Me.txt_folioXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txt_folioXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_folioXML.Location = New System.Drawing.Point(102, 219)
        Me.txt_folioXML.Name = "txt_folioXML"
        Me.txt_folioXML.ReadOnly = True
        Me.txt_folioXML.Size = New System.Drawing.Size(146, 23)
        Me.txt_folioXML.TabIndex = 46
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 222)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 16)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Folio:"
        '
        'txt_ImporteXML
        '
        Me.txt_ImporteXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_ImporteXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ImporteXML.Location = New System.Drawing.Point(395, 219)
        Me.txt_ImporteXML.Name = "txt_ImporteXML"
        Me.txt_ImporteXML.ReadOnly = True
        Me.txt_ImporteXML.Size = New System.Drawing.Size(146, 23)
        Me.txt_ImporteXML.TabIndex = 44
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(298, 222)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 16)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Importe:"
        '
        'wb
        '
        Me.wb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wb.Location = New System.Drawing.Point(4, 50)
        Me.wb.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(541, 163)
        Me.wb.TabIndex = 3
        '
        'btn_buscarXML
        '
        Me.btn_buscarXML.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_buscarXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_buscarXML.Location = New System.Drawing.Point(465, 12)
        Me.btn_buscarXML.Name = "btn_buscarXML"
        Me.btn_buscarXML.Size = New System.Drawing.Size(75, 23)
        Me.btn_buscarXML.TabIndex = 2
        Me.btn_buscarXML.Text = "Buscar"
        Me.btn_buscarXML.UseVisualStyleBackColor = True
        '
        'txt_rutaArchivoXML
        '
        Me.txt_rutaArchivoXML.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_rutaArchivoXML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rutaArchivoXML.Location = New System.Drawing.Point(56, 12)
        Me.txt_rutaArchivoXML.Name = "txt_rutaArchivoXML"
        Me.txt_rutaArchivoXML.ReadOnly = True
        Me.txt_rutaArchivoXML.Size = New System.Drawing.Size(403, 23)
        Me.txt_rutaArchivoXML.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "XML:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btn_quitarPolizaFAC_XML)
        Me.TabPage3.Controls.Add(Me.cmb_polizasFAC_XML)
        Me.TabPage3.Controls.Add(Me.btn_agregarPolizaFAC_XML)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.dgv_polizasCargosFAC_XML)
        Me.TabPage3.Controls.Add(Me.btn_consultarPolizasFAC_XML)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.cmb_mesFAC_XML)
        Me.TabPage3.Controls.Add(Me.cmb_empresasPolizasFAC_XML)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.cmb_EjercicioFAC_XML)
        Me.TabPage3.Controls.Add(Me.cmb_tipoPolizasFAC_XML)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Location = New System.Drawing.Point(4, 32)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(548, 370)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Relacionar abonos con cargos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btn_quitarPolizaFAC_XML
        '
        Me.btn_quitarPolizaFAC_XML.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_quitarPolizaFAC_XML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_quitarPolizaFAC_XML.Location = New System.Drawing.Point(428, 338)
        Me.btn_quitarPolizaFAC_XML.Name = "btn_quitarPolizaFAC_XML"
        Me.btn_quitarPolizaFAC_XML.Size = New System.Drawing.Size(112, 24)
        Me.btn_quitarPolizaFAC_XML.TabIndex = 47
        Me.btn_quitarPolizaFAC_XML.Text = "Quitar póliza"
        Me.btn_quitarPolizaFAC_XML.UseVisualStyleBackColor = True
        '
        'cmb_polizasFAC_XML
        '
        Me.cmb_polizasFAC_XML.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmb_polizasFAC_XML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_polizasFAC_XML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_polizasFAC_XML.FormattingEnabled = True
        Me.cmb_polizasFAC_XML.Location = New System.Drawing.Point(132, 338)
        Me.cmb_polizasFAC_XML.Name = "cmb_polizasFAC_XML"
        Me.cmb_polizasFAC_XML.Size = New System.Drawing.Size(290, 24)
        Me.cmb_polizasFAC_XML.TabIndex = 46
        '
        'btn_agregarPolizaFAC_XML
        '
        Me.btn_agregarPolizaFAC_XML.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_agregarPolizaFAC_XML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_agregarPolizaFAC_XML.Location = New System.Drawing.Point(10, 338)
        Me.btn_agregarPolizaFAC_XML.Name = "btn_agregarPolizaFAC_XML"
        Me.btn_agregarPolizaFAC_XML.Size = New System.Drawing.Size(112, 24)
        Me.btn_agregarPolizaFAC_XML.TabIndex = 45
        Me.btn_agregarPolizaFAC_XML.Text = "Agregar"
        Me.btn_agregarPolizaFAC_XML.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(7, 102)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(143, 16)
        Me.Label22.TabIndex = 44
        Me.Label22.Text = "POLIZAS DE CARGOS:"
        '
        'dgv_polizasCargosFAC_XML
        '
        Me.dgv_polizasCargosFAC_XML.AllowUserToAddRows = False
        Me.dgv_polizasCargosFAC_XML.AllowUserToDeleteRows = False
        Me.dgv_polizasCargosFAC_XML.AllowUserToOrderColumns = True
        Me.dgv_polizasCargosFAC_XML.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_polizasCargosFAC_XML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_polizasCargosFAC_XML.Location = New System.Drawing.Point(10, 123)
        Me.dgv_polizasCargosFAC_XML.MultiSelect = False
        Me.dgv_polizasCargosFAC_XML.Name = "dgv_polizasCargosFAC_XML"
        Me.dgv_polizasCargosFAC_XML.ReadOnly = True
        Me.dgv_polizasCargosFAC_XML.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_polizasCargosFAC_XML.Size = New System.Drawing.Size(530, 207)
        Me.dgv_polizasCargosFAC_XML.TabIndex = 43
        '
        'btn_consultarPolizasFAC_XML
        '
        Me.btn_consultarPolizasFAC_XML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_consultarPolizasFAC_XML.Location = New System.Drawing.Point(336, 91)
        Me.btn_consultarPolizasFAC_XML.Name = "btn_consultarPolizasFAC_XML"
        Me.btn_consultarPolizasFAC_XML.Size = New System.Drawing.Size(204, 27)
        Me.btn_consultarPolizasFAC_XML.TabIndex = 34
        Me.btn_consultarPolizasFAC_XML.Text = "Consultar pólizas del periodo"
        Me.btn_consultarPolizasFAC_XML.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 10)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 16)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Empresa:"
        '
        'cmb_mesFAC_XML
        '
        Me.cmb_mesFAC_XML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_mesFAC_XML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_mesFAC_XML.FormattingEnabled = True
        Me.cmb_mesFAC_XML.Location = New System.Drawing.Point(400, 63)
        Me.cmb_mesFAC_XML.Name = "cmb_mesFAC_XML"
        Me.cmb_mesFAC_XML.Size = New System.Drawing.Size(140, 24)
        Me.cmb_mesFAC_XML.TabIndex = 42
        '
        'cmb_empresasPolizasFAC_XML
        '
        Me.cmb_empresasPolizasFAC_XML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_empresasPolizasFAC_XML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_empresasPolizasFAC_XML.FormattingEnabled = True
        Me.cmb_empresasPolizasFAC_XML.Location = New System.Drawing.Point(83, 6)
        Me.cmb_empresasPolizasFAC_XML.Name = "cmb_empresasPolizasFAC_XML"
        Me.cmb_empresasPolizasFAC_XML.Size = New System.Drawing.Size(457, 24)
        Me.cmb_empresasPolizasFAC_XML.TabIndex = 36
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(358, 66)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 16)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "Mes:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(7, 39)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 16)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "Tipo póliza:"
        '
        'cmb_EjercicioFAC_XML
        '
        Me.cmb_EjercicioFAC_XML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_EjercicioFAC_XML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_EjercicioFAC_XML.FormattingEnabled = True
        Me.cmb_EjercicioFAC_XML.Location = New System.Drawing.Point(83, 63)
        Me.cmb_EjercicioFAC_XML.Name = "cmb_EjercicioFAC_XML"
        Me.cmb_EjercicioFAC_XML.Size = New System.Drawing.Size(153, 24)
        Me.cmb_EjercicioFAC_XML.TabIndex = 40
        '
        'cmb_tipoPolizasFAC_XML
        '
        Me.cmb_tipoPolizasFAC_XML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_tipoPolizasFAC_XML.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_tipoPolizasFAC_XML.FormattingEnabled = True
        Me.cmb_tipoPolizasFAC_XML.Location = New System.Drawing.Point(83, 35)
        Me.cmb_tipoPolizasFAC_XML.Name = "cmb_tipoPolizasFAC_XML"
        Me.cmb_tipoPolizasFAC_XML.Size = New System.Drawing.Size(457, 24)
        Me.cmb_tipoPolizasFAC_XML.TabIndex = 38
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(7, 67)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 16)
        Me.Label21.TabIndex = 39
        Me.Label21.Text = "Ejercicio:"
        '
        'AdjuntarXMLAPolizas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 520)
        Me.Controls.Add(Me.tc_tabs)
        Me.Controls.Add(Me.btn_AsignarPolizaSemana)
        Me.Controls.Add(Me.txt_totalXML)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_totalPoliza)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AdjuntarXMLAPolizas"
        Me.ReferenciaRapidaVisible = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjuntar XML A Pólizas"
        Me.Controls.SetChildIndex(Me.lblToolTip, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txt_totalPoliza, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.txt_totalXML, 0)
        Me.Controls.SetChildIndex(Me.btn_AsignarPolizaSemana, 0)
        Me.Controls.SetChildIndex(Me.tc_tabs, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgv_polizas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_nomina, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc_tabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgv_polizasCargosFAC_XML, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_temporadas As System.Windows.Forms.ComboBox
    Friend WithEvents btn_consultar_semana As System.Windows.Forms.Button
    Friend WithEvents cmb_nomina As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_semana As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresasPolizas As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmb_tipoPolizas As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_Ejercicio As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_mes As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_consultar_polizas As System.Windows.Forms.Button
    Friend WithEvents dgv_polizas As System.Windows.Forms.DataGridView
    Friend WithEvents dgv_nomina As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_totalPoliza As System.Windows.Forms.TextBox
    Friend WithEvents txt_totalXML As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btn_AsignarPolizaSemana As System.Windows.Forms.Button
    Friend WithEvents tc_tabs As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmb_empresasNomina As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btn_agregarPoliza As System.Windows.Forms.Button
    Friend WithEvents cmb_polizasSeleccionadas As System.Windows.Forms.ComboBox
    Friend WithEvents btn_quitarPoliza As System.Windows.Forms.Button
    Friend WithEvents btn_buscarXML As System.Windows.Forms.Button
    Friend WithEvents txt_rutaArchivoXML As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents wb As System.Windows.Forms.WebBrowser
    Friend WithEvents txt_folioXML As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_ImporteXML As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txt_RFCReceptorXML As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_RFCEmisorXML As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_descReceptor As System.Windows.Forms.TextBox
    Friend WithEvents txt_descEmisor As System.Windows.Forms.TextBox
    Friend WithEvents btn_QuitarXMLCombo As System.Windows.Forms.Button
    Friend WithEvents cmb_xmlAgregados As System.Windows.Forms.ComboBox
    Friend WithEvents btn_agregarXMLCombo As System.Windows.Forms.Button
    Friend WithEvents txt_UUIDXML As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_FechaEMISION As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents chb_vacaciones As System.Windows.Forms.CheckBox
    Friend WithEvents chb_liquidaciones As System.Windows.Forms.CheckBox
    Friend WithEvents chb_sueldos As System.Windows.Forms.CheckBox
    Friend WithEvents chb_aguinaldos As System.Windows.Forms.CheckBox
    Friend WithEvents chb_sinXML As System.Windows.Forms.CheckBox
    Friend WithEvents chb_conXML As System.Windows.Forms.CheckBox
    Friend WithEvents btn_consultarPolizasFAC_XML As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmb_mesFAC_XML As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_empresasPolizasFAC_XML As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmb_EjercicioFAC_XML As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_tipoPolizasFAC_XML As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dgv_polizasCargosFAC_XML As System.Windows.Forms.DataGridView
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btn_quitarPolizaFAC_XML As System.Windows.Forms.Button
    Friend WithEvents cmb_polizasFAC_XML As System.Windows.Forms.ComboBox
    Friend WithEvents btn_agregarPolizaFAC_XML As System.Windows.Forms.Button
End Class
