namespace ContabilidadElectronica.Formularios
{
    partial class LigadoXMLConPolizas
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
            this.dgv_xmlEnBD = new System.Windows.Forms.DataGridView();
            this.RFC_EMISOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLIO_FACTURA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_EMISION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XML = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POLIZA_LIGADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_cargar = new System.Windows.Forms.Button();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_xmlEnBD)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_xmlEnBD
            // 
            this.dgv_xmlEnBD.AllowUserToAddRows = false;
            this.dgv_xmlEnBD.AllowUserToDeleteRows = false;
            this.dgv_xmlEnBD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_xmlEnBD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_xmlEnBD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RFC_EMISOR,
            this.FOLIO_FACTURA,
            this.UUID,
            this.FECHA_EMISION,
            this.IMPORTE,
            this.XML,
            this.POLIZA_LIGADA,
            this.ESTATUS});
            this.dgv_xmlEnBD.Location = new System.Drawing.Point(7, 41);
            this.dgv_xmlEnBD.Name = "dgv_xmlEnBD";
            this.dgv_xmlEnBD.ReadOnly = true;
            this.dgv_xmlEnBD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_xmlEnBD.Size = new System.Drawing.Size(845, 322);
            this.dgv_xmlEnBD.TabIndex = 0;
            this.dgv_xmlEnBD.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_xmlEnBD_CellContentDoubleClick);
            // 
            // RFC_EMISOR
            // 
            this.RFC_EMISOR.HeaderText = "RFC EMISOR";
            this.RFC_EMISOR.Name = "RFC_EMISOR";
            this.RFC_EMISOR.ReadOnly = true;
            // 
            // FOLIO_FACTURA
            // 
            this.FOLIO_FACTURA.HeaderText = "FOLIO FACTURA";
            this.FOLIO_FACTURA.Name = "FOLIO_FACTURA";
            this.FOLIO_FACTURA.ReadOnly = true;
            // 
            // UUID
            // 
            this.UUID.HeaderText = "UUID";
            this.UUID.Name = "UUID";
            this.UUID.ReadOnly = true;
            // 
            // FECHA_EMISION
            // 
            this.FECHA_EMISION.HeaderText = "FECHA EMISION";
            this.FECHA_EMISION.Name = "FECHA_EMISION";
            this.FECHA_EMISION.ReadOnly = true;
            // 
            // IMPORTE
            // 
            this.IMPORTE.HeaderText = "IMPORTE";
            this.IMPORTE.Name = "IMPORTE";
            this.IMPORTE.ReadOnly = true;
            // 
            // XML
            // 
            this.XML.HeaderText = "XML";
            this.XML.Name = "XML";
            this.XML.ReadOnly = true;
            // 
            // POLIZA_LIGADA
            // 
            this.POLIZA_LIGADA.HeaderText = "POLIZA LIGADA";
            this.POLIZA_LIGADA.Name = "POLIZA_LIGADA";
            this.POLIZA_LIGADA.ReadOnly = true;
            // 
            // ESTATUS
            // 
            this.ESTATUS.HeaderText = "ESTATUS";
            this.ESTATUS.Name = "ESTATUS";
            this.ESTATUS.ReadOnly = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_guardar.Location = new System.Drawing.Point(726, 369);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(126, 23);
            this.btn_guardar.TabIndex = 1;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            // 
            // btn_cargar
            // 
            this.btn_cargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cargar.Location = new System.Drawing.Point(726, 9);
            this.btn_cargar.Name = "btn_cargar";
            this.btn_cargar.Size = new System.Drawing.Size(126, 23);
            this.btn_cargar.TabIndex = 2;
            this.btn_cargar.Text = "Cargar";
            this.btn_cargar.UseVisualStyleBackColor = true;
            this.btn_cargar.Click += new System.EventHandler(this.btn_cargar_Click);
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Location = new System.Drawing.Point(456, 11);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(200, 20);
            this.dtp_hasta.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "hasta:";
            // 
            // dtp_desde
            // 
            this.dtp_desde.Location = new System.Drawing.Point(208, 12);
            this.dtp_desde.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(200, 20);
            this.dtp_desde.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha de emisión de XML CFDI desde:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(-2, 404);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(862, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "F1 - Mostrar buscador de pólizas,      F2 -  Ver XML CFDI";
            // 
            // LigadoXMLConPolizas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 422);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtp_hasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_desde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cargar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.dgv_xmlEnBD);
            this.Name = "LigadoXMLConPolizas";
            this.Text = "LigadoXMLConPolizas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_xmlEnBD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_xmlEnBD;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_cargar;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC_EMISOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO_FACTURA;
        private System.Windows.Forms.DataGridViewTextBoxColumn UUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_EMISION;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn XML;
        private System.Windows.Forms.DataGridViewTextBoxColumn POLIZA_LIGADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUS;
        private System.Windows.Forms.TextBox textBox1;
    }
}