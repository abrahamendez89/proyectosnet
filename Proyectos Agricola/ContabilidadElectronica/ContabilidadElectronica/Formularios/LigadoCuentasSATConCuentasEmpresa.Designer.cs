namespace ContabilidadElectronica.Formularios
{
    partial class LigadoCuentasSATConCuentasEmpresa
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
            this.dgv_ligadoCuentas = new System.Windows.Forms.DataGridView();
            this.btn_consultarCuentasInternas = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_subirCuentaPadre = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cuenta_crop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_cuenta_interna = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agrupador_sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion_cuenta_sat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ligadoCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ligadoCuentas
            // 
            this.dgv_ligadoCuentas.AllowUserToAddRows = false;
            this.dgv_ligadoCuentas.AllowUserToDeleteRows = false;
            this.dgv_ligadoCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ligadoCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ligadoCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cuenta_crop,
            this.descripcion_cuenta_interna,
            this.agrupador_sat,
            this.descripcion_cuenta_sat});
            this.dgv_ligadoCuentas.Location = new System.Drawing.Point(12, 45);
            this.dgv_ligadoCuentas.MultiSelect = false;
            this.dgv_ligadoCuentas.Name = "dgv_ligadoCuentas";
            this.dgv_ligadoCuentas.RowHeadersWidth = 10;
            this.dgv_ligadoCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ligadoCuentas.Size = new System.Drawing.Size(727, 265);
            this.dgv_ligadoCuentas.TabIndex = 0;
            this.dgv_ligadoCuentas.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_ligadoCuentas_CellMouseDoubleClick);
            this.dgv_ligadoCuentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_ligadoCuentas_KeyDown);
            // 
            // btn_consultarCuentasInternas
            // 
            this.btn_consultarCuentasInternas.Location = new System.Drawing.Point(12, 16);
            this.btn_consultarCuentasInternas.Name = "btn_consultarCuentasInternas";
            this.btn_consultarCuentasInternas.Size = new System.Drawing.Size(263, 23);
            this.btn_consultarCuentasInternas.TabIndex = 3;
            this.btn_consultarCuentasInternas.Text = "Obtener cuentas contables de primer nivel";
            this.btn_consultarCuentasInternas.UseVisualStyleBackColor = true;
            this.btn_consultarCuentasInternas.Click += new System.EventHandler(this.btn_consultarCuentasInternas_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_guardar.Location = new System.Drawing.Point(640, 316);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(99, 23);
            this.btn_guardar.TabIndex = 4;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_subirCuentaPadre
            // 
            this.btn_subirCuentaPadre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_subirCuentaPadre.Location = new System.Drawing.Point(566, 16);
            this.btn_subirCuentaPadre.Name = "btn_subirCuentaPadre";
            this.btn_subirCuentaPadre.Size = new System.Drawing.Size(173, 23);
            this.btn_subirCuentaPadre.TabIndex = 5;
            this.btn_subirCuentaPadre.Text = "Subir a la cuenta padre";
            this.btn_subirCuentaPadre.UseVisualStyleBackColor = true;
            this.btn_subirCuentaPadre.Click += new System.EventHandler(this.btn_subirCuentaPadre_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(1, 344);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(751, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "F1 - Mostrar buscador de cuentas SAT,    SUPRIMIR - Eliminar cuenta SAT asignada," +
    "      DOBLE CLICK - Ver cuentas contables hijas";
            // 
            // cuenta_crop
            // 
            this.cuenta_crop.HeaderText = "Cuenta interna";
            this.cuenta_crop.Name = "cuenta_crop";
            this.cuenta_crop.ReadOnly = true;
            this.cuenta_crop.Width = 400;
            // 
            // descripcion_cuenta_interna
            // 
            this.descripcion_cuenta_interna.HeaderText = "Descripción de cuenta interna";
            this.descripcion_cuenta_interna.Name = "descripcion_cuenta_interna";
            this.descripcion_cuenta_interna.ReadOnly = true;
            this.descripcion_cuenta_interna.Width = 200;
            // 
            // agrupador_sat
            // 
            this.agrupador_sat.HeaderText = "Código agrupador SAT";
            this.agrupador_sat.Name = "agrupador_sat";
            this.agrupador_sat.ReadOnly = true;
            this.agrupador_sat.Width = 80;
            // 
            // descripcion_cuenta_sat
            // 
            this.descripcion_cuenta_sat.HeaderText = "Descripción de la cuenta SAT";
            this.descripcion_cuenta_sat.Name = "descripcion_cuenta_sat";
            this.descripcion_cuenta_sat.ReadOnly = true;
            this.descripcion_cuenta_sat.Width = 200;
            // 
            // LigadoCuentasSATConCuentasEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 363);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_subirCuentaPadre);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_consultarCuentasInternas);
            this.Controls.Add(this.dgv_ligadoCuentas);
            this.Name = "LigadoCuentasSATConCuentasEmpresa";
            this.Text = "LigadoCuentasSATConCuentasEmpresa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ligadoCuentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ligadoCuentas;
        private System.Windows.Forms.Button btn_consultarCuentasInternas;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_subirCuentaPadre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuenta_crop;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_cuenta_interna;
        private System.Windows.Forms.DataGridViewTextBoxColumn agrupador_sat;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion_cuenta_sat;
    }
}