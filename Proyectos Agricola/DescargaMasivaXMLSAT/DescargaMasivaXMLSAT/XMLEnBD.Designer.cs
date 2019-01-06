namespace DescargaMasivaXMLSAT
{
    partial class XMLEnBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XMLEnBD));
            this.btn_emitidos = new System.Windows.Forms.Button();
            this.btn_recibidos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_Desde = new System.Windows.Forms.DateTimePicker();
            this.dtp_Hasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_consulta = new System.Windows.Forms.DataGridView();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.btn_exportarExcel = new System.Windows.Forms.Button();
            this.btn_descargarXML = new System.Windows.Forms.Button();
            this.cmb_rfc = new System.Windows.Forms.ComboBox();
            this.btn_descargarTodosXML = new System.Windows.Forms.Button();
            this.pb_progreso = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consulta)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_emitidos
            // 
            this.btn_emitidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_emitidos.Location = new System.Drawing.Point(612, 9);
            this.btn_emitidos.Name = "btn_emitidos";
            this.btn_emitidos.Size = new System.Drawing.Size(143, 23);
            this.btn_emitidos.TabIndex = 0;
            this.btn_emitidos.Text = "Ver CFDI Emitidos";
            this.btn_emitidos.UseVisualStyleBackColor = true;
            this.btn_emitidos.Click += new System.EventHandler(this.btn_emitidos_Click);
            // 
            // btn_recibidos
            // 
            this.btn_recibidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_recibidos.Location = new System.Drawing.Point(761, 9);
            this.btn_recibidos.Name = "btn_recibidos";
            this.btn_recibidos.Size = new System.Drawing.Size(143, 23);
            this.btn_recibidos.TabIndex = 1;
            this.btn_recibidos.Text = "Ver CFDI Recibidos";
            this.btn_recibidos.UseVisualStyleBackColor = true;
            this.btn_recibidos.Click += new System.EventHandler(this.btn_recibidos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desde:";
            // 
            // dtp_Desde
            // 
            this.dtp_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Desde.Location = new System.Drawing.Point(51, 12);
            this.dtp_Desde.Name = "dtp_Desde";
            this.dtp_Desde.Size = new System.Drawing.Size(92, 20);
            this.dtp_Desde.TabIndex = 3;
            // 
            // dtp_Hasta
            // 
            this.dtp_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Hasta.Location = new System.Drawing.Point(194, 12);
            this.dtp_Hasta.Name = "dtp_Hasta";
            this.dtp_Hasta.Size = new System.Drawing.Size(92, 20);
            this.dtp_Hasta.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasta:";
            // 
            // dgv_consulta
            // 
            this.dgv_consulta.AllowUserToAddRows = false;
            this.dgv_consulta.AllowUserToDeleteRows = false;
            this.dgv_consulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_consulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_consulta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FECHA,
            this.RFC,
            this.Nombre,
            this.MONTO,
            this.Folio,
            this.UUID});
            this.dgv_consulta.Location = new System.Drawing.Point(12, 49);
            this.dgv_consulta.MultiSelect = false;
            this.dgv_consulta.Name = "dgv_consulta";
            this.dgv_consulta.ReadOnly = true;
            this.dgv_consulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_consulta.Size = new System.Drawing.Size(522, 258);
            this.dgv_consulta.TabIndex = 6;
            this.dgv_consulta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_consulta_CellClick);
            // 
            // FECHA
            // 
            this.FECHA.HeaderText = "Fecha Emisión";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            this.FECHA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FECHA.Width = 88;
            // 
            // RFC
            // 
            this.RFC.HeaderText = "RFC";
            this.RFC.Name = "RFC";
            this.RFC.ReadOnly = true;
            this.RFC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Nombre.Width = 250;
            // 
            // MONTO
            // 
            this.MONTO.HeaderText = "Monto";
            this.MONTO.Name = "MONTO";
            this.MONTO.ReadOnly = true;
            this.MONTO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Folio
            // 
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            this.Folio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UUID
            // 
            this.UUID.HeaderText = "UUID";
            this.UUID.Name = "UUID";
            this.UUID.ReadOnly = true;
            this.UUID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UUID.Width = 250;
            // 
            // wb
            // 
            this.wb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wb.Location = new System.Drawing.Point(540, 49);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(364, 258);
            this.wb.TabIndex = 7;
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            // 
            // btn_exportarExcel
            // 
            this.btn_exportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_exportarExcel.Location = new System.Drawing.Point(12, 313);
            this.btn_exportarExcel.Name = "btn_exportarExcel";
            this.btn_exportarExcel.Size = new System.Drawing.Size(131, 23);
            this.btn_exportarExcel.TabIndex = 8;
            this.btn_exportarExcel.Text = "Exportar a Excel";
            this.btn_exportarExcel.UseVisualStyleBackColor = true;
            this.btn_exportarExcel.Click += new System.EventHandler(this.btn_exportarExcel_Click);
            // 
            // btn_descargarXML
            // 
            this.btn_descargarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_descargarXML.Location = new System.Drawing.Point(540, 313);
            this.btn_descargarXML.Name = "btn_descargarXML";
            this.btn_descargarXML.Size = new System.Drawing.Size(111, 23);
            this.btn_descargarXML.TabIndex = 9;
            this.btn_descargarXML.Text = "Descargar XML";
            this.btn_descargarXML.UseVisualStyleBackColor = true;
            this.btn_descargarXML.Click += new System.EventHandler(this.btn_descargarXML_Click);
            // 
            // cmb_rfc
            // 
            this.cmb_rfc.FormattingEnabled = true;
            this.cmb_rfc.Location = new System.Drawing.Point(304, 11);
            this.cmb_rfc.Name = "cmb_rfc";
            this.cmb_rfc.Size = new System.Drawing.Size(230, 21);
            this.cmb_rfc.TabIndex = 10;
            // 
            // btn_descargarTodosXML
            // 
            this.btn_descargarTodosXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_descargarTodosXML.Location = new System.Drawing.Point(149, 313);
            this.btn_descargarTodosXML.Name = "btn_descargarTodosXML";
            this.btn_descargarTodosXML.Size = new System.Drawing.Size(229, 23);
            this.btn_descargarTodosXML.TabIndex = 11;
            this.btn_descargarTodosXML.Text = "Descargar todos los XML en archivos";
            this.btn_descargarTodosXML.UseVisualStyleBackColor = true;
            this.btn_descargarTodosXML.Click += new System.EventHandler(this.btn_descargarTodosXML_Click);
            // 
            // pb_progreso
            // 
            this.pb_progreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_progreso.Location = new System.Drawing.Point(13, 342);
            this.pb_progreso.Name = "pb_progreso";
            this.pb_progreso.Size = new System.Drawing.Size(891, 11);
            this.pb_progreso.TabIndex = 12;
            // 
            // XMLEnBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 362);
            this.Controls.Add(this.pb_progreso);
            this.Controls.Add(this.btn_descargarTodosXML);
            this.Controls.Add(this.cmb_rfc);
            this.Controls.Add(this.btn_descargarXML);
            this.Controls.Add(this.btn_exportarExcel);
            this.Controls.Add(this.wb);
            this.Controls.Add(this.dgv_consulta);
            this.Controls.Add(this.dtp_Hasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_Desde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_recibidos);
            this.Controls.Add(this.btn_emitidos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XMLEnBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor de XML en BD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_emitidos;
        private System.Windows.Forms.Button btn_recibidos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_Desde;
        private System.Windows.Forms.DateTimePicker dtp_Hasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_consulta;
        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.Button btn_exportarExcel;
        private System.Windows.Forms.Button btn_descargarXML;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn UUID;
        private System.Windows.Forms.ComboBox cmb_rfc;
        private System.Windows.Forms.Button btn_descargarTodosXML;
        private System.Windows.Forms.ProgressBar pb_progreso;
    }
}