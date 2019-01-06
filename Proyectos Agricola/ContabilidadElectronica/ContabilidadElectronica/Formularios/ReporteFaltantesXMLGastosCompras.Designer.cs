namespace ContabilidadElectronica.Formularios
{
    partial class ReporteFaltantesXMLGastosCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_facturas = new System.Windows.Forms.DataGridView();
            this.cmb_anios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_mes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.btn_generarPDF = new System.Windows.Forms.Button();
            this.btn_generarExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_facturas
            // 
            this.dgv_facturas.AllowUserToAddRows = false;
            this.dgv_facturas.AllowUserToDeleteRows = false;
            this.dgv_facturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_facturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_facturas.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgv_facturas.Location = new System.Drawing.Point(12, 35);
            this.dgv_facturas.MultiSelect = false;
            this.dgv_facturas.Name = "dgv_facturas";
            this.dgv_facturas.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_facturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgv_facturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_facturas.Size = new System.Drawing.Size(702, 338);
            this.dgv_facturas.TabIndex = 0;
            // 
            // cmb_anios
            // 
            this.cmb_anios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_anios.FormattingEnabled = true;
            this.cmb_anios.Location = new System.Drawing.Point(48, 8);
            this.cmb_anios.Name = "cmb_anios";
            this.cmb_anios.Size = new System.Drawing.Size(168, 21);
            this.cmb_anios.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Año:";
            // 
            // cmb_mes
            // 
            this.cmb_mes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mes.FormattingEnabled = true;
            this.cmb_mes.Location = new System.Drawing.Point(257, 9);
            this.cmb_mes.Name = "cmb_mes";
            this.cmb_mes.Size = new System.Drawing.Size(173, 21);
            this.cmb_mes.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Mes:";
            // 
            // btn_consultar
            // 
            this.btn_consultar.Location = new System.Drawing.Point(436, 7);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_consultar.TabIndex = 48;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // btn_generarPDF
            // 
            this.btn_generarPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generarPDF.Location = new System.Drawing.Point(628, 7);
            this.btn_generarPDF.Name = "btn_generarPDF";
            this.btn_generarPDF.Size = new System.Drawing.Size(86, 23);
            this.btn_generarPDF.TabIndex = 49;
            this.btn_generarPDF.Text = "Generar PDF";
            this.btn_generarPDF.UseVisualStyleBackColor = true;
            this.btn_generarPDF.Click += new System.EventHandler(this.btn_generarPDF_Click);
            // 
            // btn_generarExcel
            // 
            this.btn_generarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generarExcel.Location = new System.Drawing.Point(533, 7);
            this.btn_generarExcel.Name = "btn_generarExcel";
            this.btn_generarExcel.Size = new System.Drawing.Size(89, 23);
            this.btn_generarExcel.TabIndex = 50;
            this.btn_generarExcel.Text = "Generar Excel";
            this.btn_generarExcel.UseVisualStyleBackColor = true;
            this.btn_generarExcel.Click += new System.EventHandler(this.btn_generarExcel_Click);
            // 
            // ReporteFaltantesXMLGastosCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 385);
            this.Controls.Add(this.btn_generarExcel);
            this.Controls.Add(this.btn_generarPDF);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.cmb_anios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_mes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_facturas);
            this.Name = "ReporteFaltantesXMLGastosCompras";
            this.Text = "ReporteFaltantesXMLGastosCompras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_facturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_facturas;
        private System.Windows.Forms.ComboBox cmb_anios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_mes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.Button btn_generarPDF;
        private System.Windows.Forms.Button btn_generarExcel;
    }
}