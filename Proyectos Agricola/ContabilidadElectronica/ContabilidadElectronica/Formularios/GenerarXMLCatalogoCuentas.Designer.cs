namespace ContabilidadElectronica.Formularios
{
    partial class GenerarXMLCatalogoCuentas
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
            this.dgv_cuentasContables = new System.Windows.Forms.DataGridView();
            this.CUENTA_CONTABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODIGO_AGRUPADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_DE_REGISTRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_generarXML = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.txt_cuentasNuevas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cuentasRegistradas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cuentasCargadas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_cuentasSinAgrupador = new System.Windows.Forms.TextBox();
            this.btn_cargarCatalogo = new System.Windows.Forms.Button();
            this.btn_exportarExcel = new System.Windows.Forms.Button();
            this.pb_progresoExport = new System.Windows.Forms.ProgressBar();
            this.lbl_exportandoExcel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_anio = new System.Windows.Forms.TextBox();
            this.cmb_mes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cuentasContables)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_cuentasContables
            // 
            this.dgv_cuentasContables.AllowUserToAddRows = false;
            this.dgv_cuentasContables.AllowUserToDeleteRows = false;
            this.dgv_cuentasContables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_cuentasContables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cuentasContables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CUENTA_CONTABLE,
            this.CODIGO_AGRUPADOR,
            this.DESCRIPCION,
            this.FECHA_DE_REGISTRO});
            this.dgv_cuentasContables.Location = new System.Drawing.Point(3, 31);
            this.dgv_cuentasContables.MultiSelect = false;
            this.dgv_cuentasContables.Name = "dgv_cuentasContables";
            this.dgv_cuentasContables.ReadOnly = true;
            this.dgv_cuentasContables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cuentasContables.Size = new System.Drawing.Size(991, 360);
            this.dgv_cuentasContables.TabIndex = 0;
            // 
            // CUENTA_CONTABLE
            // 
            this.CUENTA_CONTABLE.HeaderText = "CUENTA CONTABLE";
            this.CUENTA_CONTABLE.Name = "CUENTA_CONTABLE";
            this.CUENTA_CONTABLE.ReadOnly = true;
            this.CUENTA_CONTABLE.Width = 150;
            // 
            // CODIGO_AGRUPADOR
            // 
            this.CODIGO_AGRUPADOR.HeaderText = "CODIGO AGRUPADOR";
            this.CODIGO_AGRUPADOR.Name = "CODIGO_AGRUPADOR";
            this.CODIGO_AGRUPADOR.ReadOnly = true;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.Width = 300;
            // 
            // FECHA_DE_REGISTRO
            // 
            this.FECHA_DE_REGISTRO.HeaderText = "FECHA DE REGISTRO";
            this.FECHA_DE_REGISTRO.Name = "FECHA_DE_REGISTRO";
            this.FECHA_DE_REGISTRO.ReadOnly = true;
            this.FECHA_DE_REGISTRO.Width = 150;
            // 
            // btn_generarXML
            // 
            this.btn_generarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generarXML.Location = new System.Drawing.Point(869, 418);
            this.btn_generarXML.Name = "btn_generarXML";
            this.btn_generarXML.Size = new System.Drawing.Size(125, 23);
            this.btn_generarXML.TabIndex = 19;
            this.btn_generarXML.Text = "Generar XML";
            this.btn_generarXML.UseVisualStyleBackColor = true;
            this.btn_generarXML.Click += new System.EventHandler(this.btn_generarXML_Click);
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(446, 423);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(87, 13);
            this.label.TabIndex = 18;
            this.label.Text = "Cuentas nuevas:";
            // 
            // txt_cuentasNuevas
            // 
            this.txt_cuentasNuevas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_cuentasNuevas.Location = new System.Drawing.Point(539, 420);
            this.txt_cuentasNuevas.Name = "txt_cuentasNuevas";
            this.txt_cuentasNuevas.ReadOnly = true;
            this.txt_cuentasNuevas.Size = new System.Drawing.Size(86, 20);
            this.txt_cuentasNuevas.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cuentas registradas al sat:";
            // 
            // txt_cuentasRegistradas
            // 
            this.txt_cuentasRegistradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_cuentasRegistradas.Location = new System.Drawing.Point(353, 420);
            this.txt_cuentasRegistradas.Name = "txt_cuentasRegistradas";
            this.txt_cuentasRegistradas.ReadOnly = true;
            this.txt_cuentasRegistradas.Size = new System.Drawing.Size(81, 20);
            this.txt_cuentasRegistradas.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cuentas cargadas:";
            // 
            // txt_cuentasCargadas
            // 
            this.txt_cuentasCargadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_cuentasCargadas.Location = new System.Drawing.Point(110, 420);
            this.txt_cuentasCargadas.Name = "txt_cuentasCargadas";
            this.txt_cuentasCargadas.ReadOnly = true;
            this.txt_cuentasCargadas.Size = new System.Drawing.Size(100, 20);
            this.txt_cuentasCargadas.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(631, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Cuentas sin agrupador:";
            // 
            // txt_cuentasSinAgrupador
            // 
            this.txt_cuentasSinAgrupador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_cuentasSinAgrupador.Location = new System.Drawing.Point(753, 420);
            this.txt_cuentasSinAgrupador.Name = "txt_cuentasSinAgrupador";
            this.txt_cuentasSinAgrupador.ReadOnly = true;
            this.txt_cuentasSinAgrupador.Size = new System.Drawing.Size(86, 20);
            this.txt_cuentasSinAgrupador.TabIndex = 20;
            // 
            // btn_cargarCatalogo
            // 
            this.btn_cargarCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cargarCatalogo.Location = new System.Drawing.Point(807, 2);
            this.btn_cargarCatalogo.Name = "btn_cargarCatalogo";
            this.btn_cargarCatalogo.Size = new System.Drawing.Size(187, 23);
            this.btn_cargarCatalogo.TabIndex = 22;
            this.btn_cargarCatalogo.Text = "Cargar catálogo de cuentas";
            this.btn_cargarCatalogo.UseVisualStyleBackColor = true;
            this.btn_cargarCatalogo.Click += new System.EventHandler(this.btn_cargarCatalogo_Click);
            // 
            // btn_exportarExcel
            // 
            this.btn_exportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportarExcel.Location = new System.Drawing.Point(673, 2);
            this.btn_exportarExcel.Name = "btn_exportarExcel";
            this.btn_exportarExcel.Size = new System.Drawing.Size(128, 23);
            this.btn_exportarExcel.TabIndex = 23;
            this.btn_exportarExcel.Text = "Exportar a excel";
            this.btn_exportarExcel.UseVisualStyleBackColor = true;
            this.btn_exportarExcel.Click += new System.EventHandler(this.btn_exportarExcel_Click);
            // 
            // pb_progresoExport
            // 
            this.pb_progresoExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_progresoExport.Location = new System.Drawing.Point(110, 399);
            this.pb_progresoExport.Name = "pb_progresoExport";
            this.pb_progresoExport.Size = new System.Drawing.Size(884, 10);
            this.pb_progresoExport.TabIndex = 25;
            this.pb_progresoExport.Visible = false;
            // 
            // lbl_exportandoExcel
            // 
            this.lbl_exportandoExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_exportandoExcel.AutoSize = true;
            this.lbl_exportandoExcel.Location = new System.Drawing.Point(3, 397);
            this.lbl_exportandoExcel.Name = "lbl_exportandoExcel";
            this.lbl_exportandoExcel.Size = new System.Drawing.Size(101, 13);
            this.lbl_exportandoExcel.TabIndex = 24;
            this.lbl_exportandoExcel.Text = "Exportando a excel:";
            this.lbl_exportandoExcel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Año:";
            // 
            // txt_anio
            // 
            this.txt_anio.Location = new System.Drawing.Point(256, 5);
            this.txt_anio.Name = "txt_anio";
            this.txt_anio.ReadOnly = true;
            this.txt_anio.Size = new System.Drawing.Size(100, 20);
            this.txt_anio.TabIndex = 28;
            // 
            // cmb_mes
            // 
            this.cmb_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mes.FormattingEnabled = true;
            this.cmb_mes.Location = new System.Drawing.Point(42, 4);
            this.cmb_mes.Name = "cmb_mes";
            this.cmb_mes.Size = new System.Drawing.Size(173, 21);
            this.cmb_mes.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Mes:";
            // 
            // GenerarXMLCatalogoCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 446);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_anio);
            this.Controls.Add(this.cmb_mes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pb_progresoExport);
            this.Controls.Add(this.lbl_exportandoExcel);
            this.Controls.Add(this.btn_exportarExcel);
            this.Controls.Add(this.btn_cargarCatalogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cuentasSinAgrupador);
            this.Controls.Add(this.btn_generarXML);
            this.Controls.Add(this.label);
            this.Controls.Add(this.txt_cuentasNuevas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cuentasRegistradas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_cuentasCargadas);
            this.Controls.Add(this.dgv_cuentasContables);
            this.Name = "GenerarXMLCatalogoCuentas";
            this.Text = "GenerarXMLCatalogoCuentas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cuentasContables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_cuentasContables;
        private System.Windows.Forms.Button btn_generarXML;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txt_cuentasNuevas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cuentasRegistradas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_cuentasCargadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUENTA_CONTABLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO_AGRUPADOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_DE_REGISTRO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_cuentasSinAgrupador;
        private System.Windows.Forms.Button btn_cargarCatalogo;
        private System.Windows.Forms.Button btn_exportarExcel;
        private System.Windows.Forms.ProgressBar pb_progresoExport;
        private System.Windows.Forms.Label lbl_exportandoExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_anio;
        private System.Windows.Forms.ComboBox cmb_mes;
        private System.Windows.Forms.Label label5;
    }
}