namespace ContabilidadElectronica.Formularios
{
    partial class BalanzaComprobacion
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
            this.dgv_balanza = new System.Windows.Forms.DataGridView();
            this.CUENTA_CONTABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODIGO_AGRU_SAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION_CUENTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALDO_INICIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEBE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HABER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALDO_FINAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_mes = new System.Windows.Forms.ComboBox();
            this.btn_mostrarBalanza = new System.Windows.Forms.Button();
            this.txt_anio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cuentasCargadas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cuentasSinAgrupador = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cuentasConAgrupador = new System.Windows.Forms.TextBox();
            this.btn_generarXML = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_tipoEnvio = new System.Windows.Forms.ComboBox();
            this.btn_exportarExcel = new System.Windows.Forms.Button();
            this.lbl_exportandoExcel = new System.Windows.Forms.Label();
            this.pb_progresoExport = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_balanza)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_balanza
            // 
            this.dgv_balanza.AllowUserToAddRows = false;
            this.dgv_balanza.AllowUserToDeleteRows = false;
            this.dgv_balanza.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_balanza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_balanza.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CUENTA_CONTABLE,
            this.CODIGO_AGRU_SAT,
            this.DESCRIPCION_CUENTA,
            this.SALDO_INICIAL,
            this.DEBE,
            this.HABER,
            this.SALDO_FINAL});
            this.dgv_balanza.Location = new System.Drawing.Point(2, 33);
            this.dgv_balanza.MultiSelect = false;
            this.dgv_balanza.Name = "dgv_balanza";
            this.dgv_balanza.ReadOnly = true;
            this.dgv_balanza.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_balanza.Size = new System.Drawing.Size(964, 358);
            this.dgv_balanza.TabIndex = 0;
            // 
            // CUENTA_CONTABLE
            // 
            this.CUENTA_CONTABLE.HeaderText = "CUENTA CONTABLE";
            this.CUENTA_CONTABLE.Name = "CUENTA_CONTABLE";
            this.CUENTA_CONTABLE.ReadOnly = true;
            this.CUENTA_CONTABLE.Width = 150;
            // 
            // CODIGO_AGRU_SAT
            // 
            this.CODIGO_AGRU_SAT.HeaderText = "CODIGO AGRUPADOR SAT";
            this.CODIGO_AGRU_SAT.Name = "CODIGO_AGRU_SAT";
            this.CODIGO_AGRU_SAT.ReadOnly = true;
            // 
            // DESCRIPCION_CUENTA
            // 
            this.DESCRIPCION_CUENTA.HeaderText = "DESCRIPCION CUENTA";
            this.DESCRIPCION_CUENTA.Name = "DESCRIPCION_CUENTA";
            this.DESCRIPCION_CUENTA.ReadOnly = true;
            this.DESCRIPCION_CUENTA.Width = 250;
            // 
            // SALDO_INICIAL
            // 
            this.SALDO_INICIAL.HeaderText = "SALDO INICIAL";
            this.SALDO_INICIAL.Name = "SALDO_INICIAL";
            this.SALDO_INICIAL.ReadOnly = true;
            // 
            // DEBE
            // 
            this.DEBE.HeaderText = "DEBE";
            this.DEBE.Name = "DEBE";
            this.DEBE.ReadOnly = true;
            // 
            // HABER
            // 
            this.HABER.HeaderText = "HABER";
            this.HABER.Name = "HABER";
            this.HABER.ReadOnly = true;
            // 
            // SALDO_FINAL
            // 
            this.SALDO_FINAL.HeaderText = "SALDO FINAL";
            this.SALDO_FINAL.Name = "SALDO_FINAL";
            this.SALDO_FINAL.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mes:";
            // 
            // cmb_mes
            // 
            this.cmb_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mes.FormattingEnabled = true;
            this.cmb_mes.Location = new System.Drawing.Point(35, 6);
            this.cmb_mes.Name = "cmb_mes";
            this.cmb_mes.Size = new System.Drawing.Size(173, 21);
            this.cmb_mes.TabIndex = 2;
            // 
            // btn_mostrarBalanza
            // 
            this.btn_mostrarBalanza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_mostrarBalanza.Location = new System.Drawing.Point(758, 4);
            this.btn_mostrarBalanza.Name = "btn_mostrarBalanza";
            this.btn_mostrarBalanza.Size = new System.Drawing.Size(208, 23);
            this.btn_mostrarBalanza.TabIndex = 3;
            this.btn_mostrarBalanza.Text = "Cargar Balanza de comprobación";
            this.btn_mostrarBalanza.UseVisualStyleBackColor = true;
            this.btn_mostrarBalanza.Click += new System.EventHandler(this.btn_mostrarBalanza_Click);
            // 
            // txt_anio
            // 
            this.txt_anio.Location = new System.Drawing.Point(249, 7);
            this.txt_anio.Name = "txt_anio";
            this.txt_anio.ReadOnly = true;
            this.txt_anio.Size = new System.Drawing.Size(100, 20);
            this.txt_anio.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Año:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cuentas cargadas:";
            // 
            // txt_cuentasCargadas
            // 
            this.txt_cuentasCargadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_cuentasCargadas.Location = new System.Drawing.Point(110, 411);
            this.txt_cuentasCargadas.Name = "txt_cuentasCargadas";
            this.txt_cuentasCargadas.ReadOnly = true;
            this.txt_cuentasCargadas.Size = new System.Drawing.Size(100, 20);
            this.txt_cuentasCargadas.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 414);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cuentas sin agrupador:";
            // 
            // txt_cuentasSinAgrupador
            // 
            this.txt_cuentasSinAgrupador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_cuentasSinAgrupador.Location = new System.Drawing.Point(334, 411);
            this.txt_cuentasSinAgrupador.Name = "txt_cuentasSinAgrupador";
            this.txt_cuentasSinAgrupador.ReadOnly = true;
            this.txt_cuentasSinAgrupador.Size = new System.Drawing.Size(100, 20);
            this.txt_cuentasSinAgrupador.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(446, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cuentas con agrupador:";
            // 
            // txt_cuentasConAgrupador
            // 
            this.txt_cuentasConAgrupador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_cuentasConAgrupador.Location = new System.Drawing.Point(573, 411);
            this.txt_cuentasConAgrupador.Name = "txt_cuentasConAgrupador";
            this.txt_cuentasConAgrupador.ReadOnly = true;
            this.txt_cuentasConAgrupador.Size = new System.Drawing.Size(100, 20);
            this.txt_cuentasConAgrupador.TabIndex = 10;
            // 
            // btn_generarXML
            // 
            this.btn_generarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generarXML.Location = new System.Drawing.Point(841, 409);
            this.btn_generarXML.Name = "btn_generarXML";
            this.btn_generarXML.Size = new System.Drawing.Size(125, 23);
            this.btn_generarXML.TabIndex = 12;
            this.btn_generarXML.Text = "Generar XML";
            this.btn_generarXML.UseVisualStyleBackColor = true;
            this.btn_generarXML.Click += new System.EventHandler(this.btn_generarXML_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tipo de envío:";
            // 
            // cmb_tipoEnvio
            // 
            this.cmb_tipoEnvio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipoEnvio.FormattingEnabled = true;
            this.cmb_tipoEnvio.Items.AddRange(new object[] {
            "NORMAL",
            "COMPLEMENTARIA"});
            this.cmb_tipoEnvio.Location = new System.Drawing.Point(438, 6);
            this.cmb_tipoEnvio.Name = "cmb_tipoEnvio";
            this.cmb_tipoEnvio.Size = new System.Drawing.Size(142, 21);
            this.cmb_tipoEnvio.TabIndex = 14;
            // 
            // btn_exportarExcel
            // 
            this.btn_exportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportarExcel.Location = new System.Drawing.Point(624, 4);
            this.btn_exportarExcel.Name = "btn_exportarExcel";
            this.btn_exportarExcel.Size = new System.Drawing.Size(128, 23);
            this.btn_exportarExcel.TabIndex = 15;
            this.btn_exportarExcel.Text = "Exportar a excel";
            this.btn_exportarExcel.UseVisualStyleBackColor = true;
            this.btn_exportarExcel.Click += new System.EventHandler(this.btn_exportarExcel_Click);
            // 
            // lbl_exportandoExcel
            // 
            this.lbl_exportandoExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_exportandoExcel.AutoSize = true;
            this.lbl_exportandoExcel.Location = new System.Drawing.Point(5, 393);
            this.lbl_exportandoExcel.Name = "lbl_exportandoExcel";
            this.lbl_exportandoExcel.Size = new System.Drawing.Size(101, 13);
            this.lbl_exportandoExcel.TabIndex = 16;
            this.lbl_exportandoExcel.Text = "Exportando a excel:";
            this.lbl_exportandoExcel.Visible = false;
            // 
            // pb_progresoExport
            // 
            this.pb_progresoExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_progresoExport.Location = new System.Drawing.Point(112, 395);
            this.pb_progresoExport.Name = "pb_progresoExport";
            this.pb_progresoExport.Size = new System.Drawing.Size(854, 10);
            this.pb_progresoExport.TabIndex = 17;
            this.pb_progresoExport.Visible = false;
            // 
            // BalanzaComprobacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 439);
            this.Controls.Add(this.pb_progresoExport);
            this.Controls.Add(this.lbl_exportandoExcel);
            this.Controls.Add(this.btn_exportarExcel);
            this.Controls.Add(this.cmb_tipoEnvio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_generarXML);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_cuentasConAgrupador);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cuentasSinAgrupador);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_cuentasCargadas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_anio);
            this.Controls.Add(this.btn_mostrarBalanza);
            this.Controls.Add(this.cmb_mes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_balanza);
            this.Name = "BalanzaComprobacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BalanzaComprobacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_balanza)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_balanza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_mes;
        private System.Windows.Forms.Button btn_mostrarBalanza;
        private System.Windows.Forms.TextBox txt_anio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUENTA_CONTABLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO_AGRU_SAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION_CUENTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALDO_INICIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEBE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HABER;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALDO_FINAL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_cuentasCargadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cuentasSinAgrupador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cuentasConAgrupador;
        private System.Windows.Forms.Button btn_generarXML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_tipoEnvio;
        private System.Windows.Forms.Button btn_exportarExcel;
        private System.Windows.Forms.Label lbl_exportandoExcel;
        private System.Windows.Forms.ProgressBar pb_progresoExport;
    }
}