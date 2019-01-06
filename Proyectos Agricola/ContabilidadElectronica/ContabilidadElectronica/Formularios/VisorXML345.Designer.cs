namespace ContabilidadElectronica.Formularios
{
    partial class VisorXML345
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
            this.label15 = new System.Windows.Forms.Label();
            this.cmb_tipoXML = new System.Windows.Forms.ComboBox();
            this.tv_estructura = new System.Windows.Forms.TreeView();
            this.btn_cargarXML = new System.Windows.Forms.Button();
            this.ll_nombreArchivo = new System.Windows.Forms.LinkLabel();
            this.dgv_datos = new System.Windows.Forms.DataGridView();
            this.DATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Tipo XML:";
            // 
            // cmb_tipoXML
            // 
            this.cmb_tipoXML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipoXML.FormattingEnabled = true;
            this.cmb_tipoXML.Items.AddRange(new object[] {
            "Pólizas del periodo (PL)",
            "Auxiliar de Folios (XF)",
            "Auxiliar de Cuentas (XC)"});
            this.cmb_tipoXML.Location = new System.Drawing.Point(73, 12);
            this.cmb_tipoXML.Name = "cmb_tipoXML";
            this.cmb_tipoXML.Size = new System.Drawing.Size(201, 21);
            this.cmb_tipoXML.TabIndex = 7;
            // 
            // tv_estructura
            // 
            this.tv_estructura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_estructura.Location = new System.Drawing.Point(14, 39);
            this.tv_estructura.Name = "tv_estructura";
            this.tv_estructura.Size = new System.Drawing.Size(636, 392);
            this.tv_estructura.TabIndex = 9;
            this.tv_estructura.Click += new System.EventHandler(this.tv_estructura_Click);
            // 
            // btn_cargarXML
            // 
            this.btn_cargarXML.Location = new System.Drawing.Point(339, 10);
            this.btn_cargarXML.Name = "btn_cargarXML";
            this.btn_cargarXML.Size = new System.Drawing.Size(84, 23);
            this.btn_cargarXML.TabIndex = 10;
            this.btn_cargarXML.Text = "Cargar XML";
            this.btn_cargarXML.UseVisualStyleBackColor = true;
            this.btn_cargarXML.Click += new System.EventHandler(this.btn_cargarXML_Click);
            // 
            // ll_nombreArchivo
            // 
            this.ll_nombreArchivo.AutoSize = true;
            this.ll_nombreArchivo.Location = new System.Drawing.Point(429, 15);
            this.ll_nombreArchivo.Name = "ll_nombreArchivo";
            this.ll_nombreArchivo.Size = new System.Drawing.Size(98, 13);
            this.ll_nombreArchivo.TabIndex = 11;
            this.ll_nombreArchivo.TabStop = true;
            this.ll_nombreArchivo.Text = "Seleccione archivo";
            // 
            // dgv_datos
            // 
            this.dgv_datos.AllowUserToAddRows = false;
            this.dgv_datos.AllowUserToDeleteRows = false;
            this.dgv_datos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DATO,
            this.VALOR});
            this.dgv_datos.Location = new System.Drawing.Point(656, 39);
            this.dgv_datos.MultiSelect = false;
            this.dgv_datos.Name = "dgv_datos";
            this.dgv_datos.ReadOnly = true;
            this.dgv_datos.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgv_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_datos.Size = new System.Drawing.Size(277, 392);
            this.dgv_datos.TabIndex = 12;
            // 
            // DATO
            // 
            this.DATO.HeaderText = "DATO";
            this.DATO.Name = "DATO";
            this.DATO.ReadOnly = true;
            this.DATO.Width = 62;
            // 
            // VALOR
            // 
            this.VALOR.HeaderText = "VALOR";
            this.VALOR.Name = "VALOR";
            this.VALOR.ReadOnly = true;
            this.VALOR.Width = 68;
            // 
            // VisorXML345
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 443);
            this.Controls.Add(this.dgv_datos);
            this.Controls.Add(this.ll_nombreArchivo);
            this.Controls.Add(this.btn_cargarXML);
            this.Controls.Add(this.tv_estructura);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmb_tipoXML);
            this.Name = "VisorXML345";
            this.Text = "VisorXML345";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmb_tipoXML;
        private System.Windows.Forms.TreeView tv_estructura;
        private System.Windows.Forms.Button btn_cargarXML;
        private System.Windows.Forms.LinkLabel ll_nombreArchivo;
        private System.Windows.Forms.DataGridView dgv_datos;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR;

    }
}