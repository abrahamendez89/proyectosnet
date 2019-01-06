namespace ContabilidadElectronica.Formularios
{
    partial class PolizasSistemaConXML
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_cargarPolizas = new System.Windows.Forms.Button();
            this.dgv_polizas = new System.Windows.Forms.DataGridView();
            this.OMITIR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POLIZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FACTURA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFC_PROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROVEEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONCEPTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XML = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_EMISION_XML = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_estatus = new System.Windows.Forms.Label();
            this.btn_validar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_exportarExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_polizas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pólizas desde:";
            // 
            // dtp_desde
            // 
            this.dtp_desde.Location = new System.Drawing.Point(91, 6);
            this.dtp_desde.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(200, 20);
            this.dtp_desde.TabIndex = 1;
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Location = new System.Drawing.Point(349, 6);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(200, 20);
            this.dtp_hasta.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "hasta:";
            // 
            // btn_cargarPolizas
            // 
            this.btn_cargarPolizas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cargarPolizas.Location = new System.Drawing.Point(859, 6);
            this.btn_cargarPolizas.Name = "btn_cargarPolizas";
            this.btn_cargarPolizas.Size = new System.Drawing.Size(108, 23);
            this.btn_cargarPolizas.TabIndex = 4;
            this.btn_cargarPolizas.Text = "Cargar pólizas";
            this.btn_cargarPolizas.UseVisualStyleBackColor = true;
            this.btn_cargarPolizas.Click += new System.EventHandler(this.btn_cargarPolizas_Click);
            // 
            // dgv_polizas
            // 
            this.dgv_polizas.AllowUserToAddRows = false;
            this.dgv_polizas.AllowUserToDeleteRows = false;
            this.dgv_polizas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_polizas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_polizas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OMITIR,
            this.FECHA,
            this.POLIZA,
            this.FACTURA,
            this.RFC_PROVEEDOR,
            this.PROVEEDOR,
            this.IMPORTE,
            this.CONCEPTO,
            this.UUID,
            this.XML,
            this.FECHA_EMISION_XML});
            this.dgv_polizas.Location = new System.Drawing.Point(15, 32);
            this.dgv_polizas.MultiSelect = false;
            this.dgv_polizas.Name = "dgv_polizas";
            this.dgv_polizas.ReadOnly = true;
            this.dgv_polizas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_polizas.Size = new System.Drawing.Size(952, 251);
            this.dgv_polizas.TabIndex = 5;
            this.dgv_polizas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_polizas_KeyDown);
            // 
            // OMITIR
            // 
            this.OMITIR.HeaderText = "OMITIR";
            this.OMITIR.Name = "OMITIR";
            this.OMITIR.ReadOnly = true;
            this.OMITIR.Width = 40;
            // 
            // FECHA
            // 
            this.FECHA.HeaderText = "FECHA";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            // 
            // POLIZA
            // 
            this.POLIZA.HeaderText = "POLIZA";
            this.POLIZA.Name = "POLIZA";
            this.POLIZA.ReadOnly = true;
            // 
            // FACTURA
            // 
            this.FACTURA.HeaderText = "FACTURA";
            this.FACTURA.Name = "FACTURA";
            this.FACTURA.ReadOnly = true;
            // 
            // RFC_PROVEEDOR
            // 
            this.RFC_PROVEEDOR.HeaderText = "RFC";
            this.RFC_PROVEEDOR.Name = "RFC_PROVEEDOR";
            this.RFC_PROVEEDOR.ReadOnly = true;
            // 
            // PROVEEDOR
            // 
            this.PROVEEDOR.HeaderText = "PROVEEDOR";
            this.PROVEEDOR.Name = "PROVEEDOR";
            this.PROVEEDOR.ReadOnly = true;
            // 
            // IMPORTE
            // 
            this.IMPORTE.HeaderText = "IMPORTE";
            this.IMPORTE.Name = "IMPORTE";
            this.IMPORTE.ReadOnly = true;
            // 
            // CONCEPTO
            // 
            this.CONCEPTO.HeaderText = "CONCEPTO";
            this.CONCEPTO.Name = "CONCEPTO";
            this.CONCEPTO.ReadOnly = true;
            // 
            // UUID
            // 
            this.UUID.HeaderText = "UUID";
            this.UUID.Name = "UUID";
            this.UUID.ReadOnly = true;
            // 
            // XML
            // 
            this.XML.HeaderText = "XML";
            this.XML.Name = "XML";
            this.XML.ReadOnly = true;
            // 
            // FECHA_EMISION_XML
            // 
            this.FECHA_EMISION_XML.HeaderText = "FECHA EMISION CFDI";
            this.FECHA_EMISION_XML.Name = "FECHA_EMISION_XML";
            this.FECHA_EMISION_XML.ReadOnly = true;
            // 
            // lbl_estatus
            // 
            this.lbl_estatus.AutoSize = true;
            this.lbl_estatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estatus.Location = new System.Drawing.Point(669, 9);
            this.lbl_estatus.Name = "lbl_estatus";
            this.lbl_estatus.Size = new System.Drawing.Size(0, 16);
            this.lbl_estatus.TabIndex = 6;
            // 
            // btn_validar
            // 
            this.btn_validar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_validar.Location = new System.Drawing.Point(859, 6);
            this.btn_validar.Name = "btn_validar";
            this.btn_validar.Size = new System.Drawing.Size(108, 23);
            this.btn_validar.TabIndex = 7;
            this.btn_validar.Text = "Validar";
            this.btn_validar.UseVisualStyleBackColor = true;
            this.btn_validar.Click += new System.EventHandler(this.btn_validar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 299);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(980, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "F1 - Buscar XML manualmente,    SUPRIMIR - Borrar XML relacionado,    ESPACIO - O" +
    "mitir/Incluir poliza";
            // 
            // btn_exportarExcel
            // 
            this.btn_exportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exportarExcel.Location = new System.Drawing.Point(725, 6);
            this.btn_exportarExcel.Name = "btn_exportarExcel";
            this.btn_exportarExcel.Size = new System.Drawing.Size(128, 23);
            this.btn_exportarExcel.TabIndex = 14;
            this.btn_exportarExcel.Text = "Exportar a excel";
            this.btn_exportarExcel.UseVisualStyleBackColor = true;
            this.btn_exportarExcel.Click += new System.EventHandler(this.btn_exportarExcel_Click);
            // 
            // PolizasSistemaConXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 319);
            this.Controls.Add(this.btn_exportarExcel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_estatus);
            this.Controls.Add(this.dgv_polizas);
            this.Controls.Add(this.btn_cargarPolizas);
            this.Controls.Add(this.dtp_hasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_desde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_validar);
            this.Name = "PolizasSistemaConXML";
            this.Text = "PolizasSistemaConXML";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_polizas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cargarPolizas;
        private System.Windows.Forms.DataGridView dgv_polizas;
        private System.Windows.Forms.Label lbl_estatus;
        private System.Windows.Forms.Button btn_validar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_exportarExcel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OMITIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn POLIZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FACTURA;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC_PROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn PROVEEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONCEPTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn XML;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_EMISION_XML;
    }
}