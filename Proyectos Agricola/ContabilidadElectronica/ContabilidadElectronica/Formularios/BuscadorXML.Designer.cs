namespace ContabilidadElectronica.Formularios
{
    partial class BuscadorXML
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
            this.dgv_xmlFacturas = new System.Windows.Forms.DataGridView();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.FECHA_EMISION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFC_EMISOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFC_RECEPTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLIO_FACTURA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XML = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_xmlFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_xmlFacturas
            // 
            this.dgv_xmlFacturas.AllowUserToAddRows = false;
            this.dgv_xmlFacturas.AllowUserToDeleteRows = false;
            this.dgv_xmlFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_xmlFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_xmlFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FECHA_EMISION,
            this.RFC_EMISOR,
            this.RFC_RECEPTOR,
            this.FOLIO_FACTURA,
            this.IMPORTE,
            this.XML});
            this.dgv_xmlFacturas.Location = new System.Drawing.Point(1, 1);
            this.dgv_xmlFacturas.MultiSelect = false;
            this.dgv_xmlFacturas.Name = "dgv_xmlFacturas";
            this.dgv_xmlFacturas.ReadOnly = true;
            this.dgv_xmlFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_xmlFacturas.Size = new System.Drawing.Size(787, 329);
            this.dgv_xmlFacturas.TabIndex = 0;
            this.dgv_xmlFacturas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_xmlFacturas_CellContentDoubleClick);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_aceptar.Location = new System.Drawing.Point(709, 336);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 1;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancelar.Location = new System.Drawing.Point(629, 336);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 2;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // FECHA_EMISION
            // 
            this.FECHA_EMISION.HeaderText = "FECHA EMISION";
            this.FECHA_EMISION.Name = "FECHA_EMISION";
            this.FECHA_EMISION.ReadOnly = true;
            this.FECHA_EMISION.Width = 160;
            // 
            // RFC_EMISOR
            // 
            this.RFC_EMISOR.HeaderText = "RFC EMISOR";
            this.RFC_EMISOR.Name = "RFC_EMISOR";
            this.RFC_EMISOR.ReadOnly = true;
            // 
            // RFC_RECEPTOR
            // 
            this.RFC_RECEPTOR.HeaderText = "RFC RECEPTOR";
            this.RFC_RECEPTOR.Name = "RFC_RECEPTOR";
            this.RFC_RECEPTOR.ReadOnly = true;
            this.RFC_RECEPTOR.Width = 150;
            // 
            // FOLIO_FACTURA
            // 
            this.FOLIO_FACTURA.HeaderText = "FOLIO FACTURA";
            this.FOLIO_FACTURA.Name = "FOLIO_FACTURA";
            this.FOLIO_FACTURA.ReadOnly = true;
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
            // BuscadorXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 361);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.dgv_xmlFacturas);
            this.Name = "BuscadorXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscadorXML";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_xmlFacturas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_xmlFacturas;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_EMISION;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC_EMISOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC_RECEPTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO_FACTURA;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn XML;
    }
}