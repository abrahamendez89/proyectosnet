namespace ContabilidadElectronica.Formularios
{
    partial class GenerarXMLPolizas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_cargarXML = new System.Windows.Forms.Button();
            this.dgv_polizas = new System.Windows.Forms.DataGridView();
            this.cm_opcionesPolizas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cambiarAVERDEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarAROJOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarAAmarilloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copiarPólizaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_mes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_generarXML = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_tipoSolicitud = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_numeroOrden = new System.Windows.Forms.TextBox();
            this.txt_numeroTramite = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_anios = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv_detalle = new System.Windows.Forms.DataGridView();
            this.txt_totalCargos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_totalAbonos = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_totalPolizas = new System.Windows.Forms.TextBox();
            this.btn_xmlRelacionados = new System.Windows.Forms.Button();
            this.btn_cuentasAfectadas = new System.Windows.Forms.Button();
            this.txt_totalEnXML = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_polizasSinXML = new System.Windows.Forms.Button();
            this.btn_anexarXML = new System.Windows.Forms.Button();
            this.txt_polizaSeleccionada = new System.Windows.Forms.TextBox();
            this.btn_filtroRojo = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_filtroAmarillo = new System.Windows.Forms.Button();
            this.btn_filtroVerde = new System.Windows.Forms.Button();
            this.btn_todos = new System.Windows.Forms.Button();
            this.cm_opcionesFacturas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ll_xmlPolizas = new System.Windows.Forms.LinkLabel();
            this.btn_generarExcel = new System.Windows.Forms.Button();
            this.ll_xmlAuxiliarFolios = new System.Windows.Forms.LinkLabel();
            this.ll_xmlAuxiliarCuentas = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_generarXMLAuxiliarFolios = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_GenerarAuxiliarCuentas = new System.Windows.Forms.Button();
            this.btn_filtroGRIS = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_desde = new System.Windows.Forms.TextBox();
            this.txt_hasta = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_polizas)).BeginInit();
            this.cm_opcionesPolizas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).BeginInit();
            this.cm_opcionesFacturas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cargarXML
            // 
            this.btn_cargarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cargarXML.Location = new System.Drawing.Point(1129, 12);
            this.btn_cargarXML.Name = "btn_cargarXML";
            this.btn_cargarXML.Size = new System.Drawing.Size(86, 23);
            this.btn_cargarXML.TabIndex = 0;
            this.btn_cargarXML.Text = "Cargar Pólizas";
            this.btn_cargarXML.UseVisualStyleBackColor = true;
            this.btn_cargarXML.Click += new System.EventHandler(this.btn_cargarXML_Click);
            // 
            // dgv_polizas
            // 
            this.dgv_polizas.AllowUserToAddRows = false;
            this.dgv_polizas.AllowUserToDeleteRows = false;
            this.dgv_polizas.AllowUserToOrderColumns = true;
            this.dgv_polizas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_polizas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_polizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_polizas.ContextMenuStrip = this.cm_opcionesPolizas;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_polizas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_polizas.Location = new System.Drawing.Point(3, 113);
            this.dgv_polizas.Name = "dgv_polizas";
            this.dgv_polizas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_polizas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_polizas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_polizas.Size = new System.Drawing.Size(1212, 209);
            this.dgv_polizas.TabIndex = 1;
            // 
            // cm_opcionesPolizas
            // 
            this.cm_opcionesPolizas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarAVERDEToolStripMenuItem,
            this.cambiarAROJOToolStripMenuItem,
            this.cambiarAAmarilloToolStripMenuItem,
            this.toolStripSeparator1,
            this.copiarPólizaToolStripMenuItem});
            this.cm_opcionesPolizas.Name = "cm_opcionesPolizas";
            this.cm_opcionesPolizas.Size = new System.Drawing.Size(190, 98);
            // 
            // cambiarAVERDEToolStripMenuItem
            // 
            this.cambiarAVERDEToolStripMenuItem.Name = "cambiarAVERDEToolStripMenuItem";
            this.cambiarAVERDEToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cambiarAVERDEToolStripMenuItem.Text = "Cambiar a VERDE";
            this.cambiarAVERDEToolStripMenuItem.Click += new System.EventHandler(this.cambiarAVERDEToolStripMenuItem_Click);
            // 
            // cambiarAROJOToolStripMenuItem
            // 
            this.cambiarAROJOToolStripMenuItem.Name = "cambiarAROJOToolStripMenuItem";
            this.cambiarAROJOToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cambiarAROJOToolStripMenuItem.Text = "Cambiar a ROJO";
            this.cambiarAROJOToolStripMenuItem.Click += new System.EventHandler(this.cambiarAROJOToolStripMenuItem_Click);
            // 
            // cambiarAAmarilloToolStripMenuItem
            // 
            this.cambiarAAmarilloToolStripMenuItem.Name = "cambiarAAmarilloToolStripMenuItem";
            this.cambiarAAmarilloToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.cambiarAAmarilloToolStripMenuItem.Text = "Cambiar a AMARILLO";
            this.cambiarAAmarilloToolStripMenuItem.Click += new System.EventHandler(this.cambiarAAmarilloToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // copiarPólizaToolStripMenuItem
            // 
            this.copiarPólizaToolStripMenuItem.Name = "copiarPólizaToolStripMenuItem";
            this.copiarPólizaToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.copiarPólizaToolStripMenuItem.Text = "Copiar Póliza";
            this.copiarPólizaToolStripMenuItem.Click += new System.EventHandler(this.copiarPólizaToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Año:";
            // 
            // cmb_mes
            // 
            this.cmb_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mes.FormattingEnabled = true;
            this.cmb_mes.Location = new System.Drawing.Point(42, 13);
            this.cmb_mes.Name = "cmb_mes";
            this.cmb_mes.Size = new System.Drawing.Size(173, 21);
            this.cmb_mes.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Mes:";
            // 
            // btn_generarXML
            // 
            this.btn_generarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_generarXML.Location = new System.Drawing.Point(3, 514);
            this.btn_generarXML.Name = "btn_generarXML";
            this.btn_generarXML.Size = new System.Drawing.Size(75, 23);
            this.btn_generarXML.TabIndex = 34;
            this.btn_generarXML.Text = "Generar";
            this.btn_generarXML.UseVisualStyleBackColor = true;
            this.btn_generarXML.Click += new System.EventHandler(this.btn_generarXML_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Tipo solicitud:";
            // 
            // cmb_tipoSolicitud
            // 
            this.cmb_tipoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipoSolicitud.FormattingEnabled = true;
            this.cmb_tipoSolicitud.Location = new System.Drawing.Point(78, 43);
            this.cmb_tipoSolicitud.Name = "cmb_tipoSolicitud";
            this.cmb_tipoSolicitud.Size = new System.Drawing.Size(213, 21);
            this.cmb_tipoSolicitud.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "No. de Orden:";
            // 
            // txt_numeroOrden
            // 
            this.txt_numeroOrden.Location = new System.Drawing.Point(377, 43);
            this.txt_numeroOrden.Name = "txt_numeroOrden";
            this.txt_numeroOrden.Size = new System.Drawing.Size(134, 20);
            this.txt_numeroOrden.TabIndex = 38;
            // 
            // txt_numeroTramite
            // 
            this.txt_numeroTramite.Location = new System.Drawing.Point(602, 43);
            this.txt_numeroTramite.Name = "txt_numeroTramite";
            this.txt_numeroTramite.Size = new System.Drawing.Size(134, 20);
            this.txt_numeroTramite.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(522, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "No. de Tramite:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Pólizas:";
            // 
            // cmb_anios
            // 
            this.cmb_anios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_anios.FormattingEnabled = true;
            this.cmb_anios.Location = new System.Drawing.Point(256, 13);
            this.cmb_anios.Name = "cmb_anios";
            this.cmb_anios.Size = new System.Drawing.Size(168, 21);
            this.cmb_anios.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Detalles de la póliza:";
            // 
            // dgv_detalle
            // 
            this.dgv_detalle.AllowUserToAddRows = false;
            this.dgv_detalle.AllowUserToDeleteRows = false;
            this.dgv_detalle.AllowUserToOrderColumns = true;
            this.dgv_detalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_detalle.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_detalle.Location = new System.Drawing.Point(3, 354);
            this.dgv_detalle.MultiSelect = false;
            this.dgv_detalle.Name = "dgv_detalle";
            this.dgv_detalle.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_detalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_detalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_detalle.Size = new System.Drawing.Size(1212, 154);
            this.dgv_detalle.TabIndex = 44;
            this.dgv_detalle.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_detalle_CellDoubleClick);
            // 
            // txt_totalCargos
            // 
            this.txt_totalCargos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_totalCargos.Location = new System.Drawing.Point(847, 90);
            this.txt_totalCargos.Name = "txt_totalCargos";
            this.txt_totalCargos.ReadOnly = true;
            this.txt_totalCargos.Size = new System.Drawing.Size(134, 20);
            this.txt_totalCargos.TabIndex = 47;
            this.txt_totalCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(778, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "Total Cargo:";
            // 
            // txt_totalAbonos
            // 
            this.txt_totalAbonos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_totalAbonos.Location = new System.Drawing.Point(1081, 90);
            this.txt_totalAbonos.Name = "txt_totalAbonos";
            this.txt_totalAbonos.ReadOnly = true;
            this.txt_totalAbonos.Size = new System.Drawing.Size(134, 20);
            this.txt_totalAbonos.TabIndex = 49;
            this.txt_totalAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1007, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Total Abono:";
            // 
            // txt_totalPolizas
            // 
            this.txt_totalPolizas.BackColor = System.Drawing.Color.White;
            this.txt_totalPolizas.Location = new System.Drawing.Point(55, 90);
            this.txt_totalPolizas.Name = "txt_totalPolizas";
            this.txt_totalPolizas.ReadOnly = true;
            this.txt_totalPolizas.Size = new System.Drawing.Size(63, 20);
            this.txt_totalPolizas.TabIndex = 50;
            this.txt_totalPolizas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_xmlRelacionados
            // 
            this.btn_xmlRelacionados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_xmlRelacionados.Location = new System.Drawing.Point(987, 327);
            this.btn_xmlRelacionados.Name = "btn_xmlRelacionados";
            this.btn_xmlRelacionados.Size = new System.Drawing.Size(228, 23);
            this.btn_xmlRelacionados.TabIndex = 51;
            this.btn_xmlRelacionados.Text = "Cargar facturas relacionadas";
            this.btn_xmlRelacionados.UseVisualStyleBackColor = true;
            this.btn_xmlRelacionados.Click += new System.EventHandler(this.btn_xmlRelacionados_Click);
            // 
            // btn_cuentasAfectadas
            // 
            this.btn_cuentasAfectadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cuentasAfectadas.Location = new System.Drawing.Point(740, 327);
            this.btn_cuentasAfectadas.Name = "btn_cuentasAfectadas";
            this.btn_cuentasAfectadas.Size = new System.Drawing.Size(241, 23);
            this.btn_cuentasAfectadas.TabIndex = 52;
            this.btn_cuentasAfectadas.Text = "Cargar cuentas contables afectadas";
            this.btn_cuentasAfectadas.UseVisualStyleBackColor = true;
            this.btn_cuentasAfectadas.Click += new System.EventHandler(this.btn_cuentasAfectadas_Click);
            // 
            // txt_totalEnXML
            // 
            this.txt_totalEnXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_totalEnXML.Location = new System.Drawing.Point(638, 90);
            this.txt_totalEnXML.Name = "txt_totalEnXML";
            this.txt_totalEnXML.ReadOnly = true;
            this.txt_totalEnXML.Size = new System.Drawing.Size(134, 20);
            this.txt_totalEnXML.TabIndex = 54;
            this.txt_totalEnXML.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(560, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "Total en XML:";
            // 
            // btn_polizasSinXML
            // 
            this.btn_polizasSinXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_polizasSinXML.Location = new System.Drawing.Point(1029, 58);
            this.btn_polizasSinXML.Name = "btn_polizasSinXML";
            this.btn_polizasSinXML.Size = new System.Drawing.Size(186, 23);
            this.btn_polizasSinXML.TabIndex = 58;
            this.btn_polizasSinXML.Text = "Buscar XML faltantes en pasivos";
            this.btn_polizasSinXML.UseVisualStyleBackColor = true;
            this.btn_polizasSinXML.Click += new System.EventHandler(this.btn_polizasSinXML_Click);
            // 
            // btn_anexarXML
            // 
            this.btn_anexarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_anexarXML.Location = new System.Drawing.Point(563, 327);
            this.btn_anexarXML.Name = "btn_anexarXML";
            this.btn_anexarXML.Size = new System.Drawing.Size(122, 23);
            this.btn_anexarXML.TabIndex = 59;
            this.btn_anexarXML.Text = "Anexar XML";
            this.btn_anexarXML.UseVisualStyleBackColor = true;
            this.btn_anexarXML.Click += new System.EventHandler(this.btn_anexarXML_Click);
            // 
            // txt_polizaSeleccionada
            // 
            this.txt_polizaSeleccionada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_polizaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_polizaSeleccionada.Location = new System.Drawing.Point(116, 329);
            this.txt_polizaSeleccionada.Name = "txt_polizaSeleccionada";
            this.txt_polizaSeleccionada.ReadOnly = true;
            this.txt_polizaSeleccionada.Size = new System.Drawing.Size(186, 20);
            this.txt_polizaSeleccionada.TabIndex = 62;
            this.txt_polizaSeleccionada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_filtroRojo
            // 
            this.btn_filtroRojo.BackColor = System.Drawing.Color.Red;
            this.btn_filtroRojo.ForeColor = System.Drawing.Color.White;
            this.btn_filtroRojo.Location = new System.Drawing.Point(199, 87);
            this.btn_filtroRojo.Name = "btn_filtroRojo";
            this.btn_filtroRojo.Size = new System.Drawing.Size(51, 25);
            this.btn_filtroRojo.TabIndex = 63;
            this.btn_filtroRojo.Text = "9999";
            this.btn_filtroRojo.UseVisualStyleBackColor = false;
            this.btn_filtroRojo.Click += new System.EventHandler(this.btn_filtroRojo_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(124, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 64;
            this.label13.Text = "Filtro/Conteo:";
            // 
            // btn_filtroAmarillo
            // 
            this.btn_filtroAmarillo.BackColor = System.Drawing.Color.Yellow;
            this.btn_filtroAmarillo.ForeColor = System.Drawing.Color.Black;
            this.btn_filtroAmarillo.Location = new System.Drawing.Point(254, 87);
            this.btn_filtroAmarillo.Name = "btn_filtroAmarillo";
            this.btn_filtroAmarillo.Size = new System.Drawing.Size(51, 25);
            this.btn_filtroAmarillo.TabIndex = 65;
            this.btn_filtroAmarillo.Text = "9999";
            this.btn_filtroAmarillo.UseVisualStyleBackColor = false;
            this.btn_filtroAmarillo.Click += new System.EventHandler(this.btn_filtroAmarillo_Click);
            // 
            // btn_filtroVerde
            // 
            this.btn_filtroVerde.BackColor = System.Drawing.Color.Green;
            this.btn_filtroVerde.ForeColor = System.Drawing.Color.White;
            this.btn_filtroVerde.Location = new System.Drawing.Point(309, 87);
            this.btn_filtroVerde.Name = "btn_filtroVerde";
            this.btn_filtroVerde.Size = new System.Drawing.Size(51, 25);
            this.btn_filtroVerde.TabIndex = 66;
            this.btn_filtroVerde.Text = "9999";
            this.btn_filtroVerde.UseVisualStyleBackColor = false;
            this.btn_filtroVerde.Click += new System.EventHandler(this.btn_filtroVerde_Click);
            // 
            // btn_todos
            // 
            this.btn_todos.BackColor = System.Drawing.Color.White;
            this.btn_todos.Location = new System.Drawing.Point(420, 87);
            this.btn_todos.Name = "btn_todos";
            this.btn_todos.Size = new System.Drawing.Size(85, 25);
            this.btn_todos.TabIndex = 67;
            this.btn_todos.Text = "Ver todas";
            this.btn_todos.UseVisualStyleBackColor = false;
            this.btn_todos.Click += new System.EventHandler(this.btn_todos_Click);
            // 
            // cm_opcionesFacturas
            // 
            this.cm_opcionesFacturas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.cm_opcionesFacturas.Name = "cm_opcionesFacturas";
            this.cm_opcionesFacturas.Size = new System.Drawing.Size(134, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "Copiar RFC";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ll_xmlPolizas
            // 
            this.ll_xmlPolizas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ll_xmlPolizas.AutoSize = true;
            this.ll_xmlPolizas.Location = new System.Drawing.Point(84, 519);
            this.ll_xmlPolizas.Name = "ll_xmlPolizas";
            this.ll_xmlPolizas.Size = new System.Drawing.Size(65, 13);
            this.ll_xmlPolizas.TabIndex = 3;
            this.ll_xmlPolizas.TabStop = true;
            this.ll_xmlPolizas.Text = "XML Pólizas";
            this.ll_xmlPolizas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_xmlPolizas_LinkClicked);
            // 
            // btn_generarExcel
            // 
            this.btn_generarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generarExcel.Location = new System.Drawing.Point(1037, 12);
            this.btn_generarExcel.Name = "btn_generarExcel";
            this.btn_generarExcel.Size = new System.Drawing.Size(86, 23);
            this.btn_generarExcel.TabIndex = 69;
            this.btn_generarExcel.Text = "Generar PDF";
            this.btn_generarExcel.UseVisualStyleBackColor = true;
            this.btn_generarExcel.Click += new System.EventHandler(this.btn_generarExcel_Click);
            // 
            // ll_xmlAuxiliarFolios
            // 
            this.ll_xmlAuxiliarFolios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ll_xmlAuxiliarFolios.AutoSize = true;
            this.ll_xmlAuxiliarFolios.Location = new System.Drawing.Point(380, 519);
            this.ll_xmlAuxiliarFolios.Name = "ll_xmlAuxiliarFolios";
            this.ll_xmlAuxiliarFolios.Size = new System.Drawing.Size(136, 13);
            this.ll_xmlAuxiliarFolios.TabIndex = 70;
            this.ll_xmlAuxiliarFolios.TabStop = true;
            this.ll_xmlAuxiliarFolios.Text = "XML Reporte Auxiliar Folios";
            this.ll_xmlAuxiliarFolios.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_xmlAuxiliarFolios_LinkClicked);
            // 
            // ll_xmlAuxiliarCuentas
            // 
            this.ll_xmlAuxiliarCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ll_xmlAuxiliarCuentas.AutoSize = true;
            this.ll_xmlAuxiliarCuentas.Location = new System.Drawing.Point(747, 519);
            this.ll_xmlAuxiliarCuentas.Name = "ll_xmlAuxiliarCuentas";
            this.ll_xmlAuxiliarCuentas.Size = new System.Drawing.Size(107, 13);
            this.ll_xmlAuxiliarCuentas.TabIndex = 71;
            this.ll_xmlAuxiliarCuentas.TabStop = true;
            this.ll_xmlAuxiliarCuentas.Text = "XML Auxiliar Cuentas";
            this.ll_xmlAuxiliarCuentas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_xmlAuxiliarCuentas_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "|";
            // 
            // btn_generarXMLAuxiliarFolios
            // 
            this.btn_generarXMLAuxiliarFolios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_generarXMLAuxiliarFolios.Location = new System.Drawing.Point(301, 514);
            this.btn_generarXMLAuxiliarFolios.Name = "btn_generarXMLAuxiliarFolios";
            this.btn_generarXMLAuxiliarFolios.Size = new System.Drawing.Size(73, 23);
            this.btn_generarXMLAuxiliarFolios.TabIndex = 73;
            this.btn_generarXMLAuxiliarFolios.Text = "Generar";
            this.btn_generarXMLAuxiliarFolios.UseVisualStyleBackColor = true;
            this.btn_generarXMLAuxiliarFolios.Click += new System.EventHandler(this.btn_generarXMLAuxiliarFolios_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(653, 519);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(9, 13);
            this.label12.TabIndex = 75;
            this.label12.Text = "|";
            // 
            // btn_GenerarAuxiliarCuentas
            // 
            this.btn_GenerarAuxiliarCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_GenerarAuxiliarCuentas.Location = new System.Drawing.Point(668, 514);
            this.btn_GenerarAuxiliarCuentas.Name = "btn_GenerarAuxiliarCuentas";
            this.btn_GenerarAuxiliarCuentas.Size = new System.Drawing.Size(73, 23);
            this.btn_GenerarAuxiliarCuentas.TabIndex = 76;
            this.btn_GenerarAuxiliarCuentas.Text = "Generar";
            this.btn_GenerarAuxiliarCuentas.UseVisualStyleBackColor = true;
            this.btn_GenerarAuxiliarCuentas.Click += new System.EventHandler(this.btn_GenerarAuxiliarCuentas_Click);
            // 
            // btn_filtroGRIS
            // 
            this.btn_filtroGRIS.BackColor = System.Drawing.Color.Gray;
            this.btn_filtroGRIS.ForeColor = System.Drawing.Color.White;
            this.btn_filtroGRIS.Location = new System.Drawing.Point(363, 87);
            this.btn_filtroGRIS.Name = "btn_filtroGRIS";
            this.btn_filtroGRIS.Size = new System.Drawing.Size(51, 25);
            this.btn_filtroGRIS.TabIndex = 78;
            this.btn_filtroGRIS.Text = "9999";
            this.btn_filtroGRIS.UseVisualStyleBackColor = false;
            this.btn_filtroGRIS.Click += new System.EventHandler(this.btn_filtroGRIS_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(695, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 79;
            this.label14.Text = "Pólizas desde:";
            // 
            // txt_desde
            // 
            this.txt_desde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_desde.Location = new System.Drawing.Point(771, 14);
            this.txt_desde.Name = "txt_desde";
            this.txt_desde.Size = new System.Drawing.Size(100, 20);
            this.txt_desde.TabIndex = 80;
            // 
            // txt_hasta
            // 
            this.txt_hasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_hasta.Location = new System.Drawing.Point(915, 14);
            this.txt_hasta.Name = "txt_hasta";
            this.txt_hasta.Size = new System.Drawing.Size(100, 20);
            this.txt_hasta.TabIndex = 82;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(873, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(36, 13);
            this.label15.TabIndex = 81;
            this.label15.Text = "hasta:";
            // 
            // GenerarXMLPolizas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 544);
            this.Controls.Add(this.txt_hasta);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_desde);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_filtroGRIS);
            this.Controls.Add(this.btn_GenerarAuxiliarCuentas);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_generarXMLAuxiliarFolios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ll_xmlAuxiliarCuentas);
            this.Controls.Add(this.ll_xmlAuxiliarFolios);
            this.Controls.Add(this.btn_generarExcel);
            this.Controls.Add(this.btn_todos);
            this.Controls.Add(this.btn_filtroVerde);
            this.Controls.Add(this.btn_filtroAmarillo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_filtroRojo);
            this.Controls.Add(this.txt_polizaSeleccionada);
            this.Controls.Add(this.btn_anexarXML);
            this.Controls.Add(this.btn_polizasSinXML);
            this.Controls.Add(this.txt_totalEnXML);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_cuentasAfectadas);
            this.Controls.Add(this.btn_xmlRelacionados);
            this.Controls.Add(this.txt_totalPolizas);
            this.Controls.Add(this.txt_totalAbonos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_totalCargos);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgv_detalle);
            this.Controls.Add(this.cmb_anios);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_numeroTramite);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_numeroOrden);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_tipoSolicitud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_generarXML);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_mes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ll_xmlPolizas);
            this.Controls.Add(this.dgv_polizas);
            this.Controls.Add(this.btn_cargarXML);
            this.Name = "GenerarXMLPolizas";
            this.Text = "GenerarXMLPolizas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_polizas)).EndInit();
            this.cm_opcionesPolizas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_detalle)).EndInit();
            this.cm_opcionesFacturas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cargarXML;
        private System.Windows.Forms.DataGridView dgv_polizas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_mes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_generarXML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_tipoSolicitud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_numeroOrden;
        private System.Windows.Forms.TextBox txt_numeroTramite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_anios;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv_detalle;
        private System.Windows.Forms.TextBox txt_totalCargos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_totalAbonos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_totalPolizas;
        private System.Windows.Forms.Button btn_xmlRelacionados;
        private System.Windows.Forms.Button btn_cuentasAfectadas;
        private System.Windows.Forms.TextBox txt_totalEnXML;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_polizasSinXML;
        private System.Windows.Forms.Button btn_anexarXML;
        private System.Windows.Forms.ContextMenuStrip cm_opcionesPolizas;
        private System.Windows.Forms.ToolStripMenuItem cambiarAVERDEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarAROJOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarAAmarilloToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_polizaSeleccionada;
        private System.Windows.Forms.Button btn_filtroRojo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_filtroAmarillo;
        private System.Windows.Forms.Button btn_filtroVerde;
        private System.Windows.Forms.Button btn_todos;
        private System.Windows.Forms.ContextMenuStrip cm_opcionesFacturas;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copiarPólizaToolStripMenuItem;
        private System.Windows.Forms.LinkLabel ll_xmlPolizas;
        private System.Windows.Forms.Button btn_generarExcel;
        private System.Windows.Forms.LinkLabel ll_xmlAuxiliarFolios;
        private System.Windows.Forms.LinkLabel ll_xmlAuxiliarCuentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_generarXMLAuxiliarFolios;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_GenerarAuxiliarCuentas;
        private System.Windows.Forms.Button btn_filtroGRIS;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_desde;
        private System.Windows.Forms.TextBox txt_hasta;
        private System.Windows.Forms.Label label15;
    }
}