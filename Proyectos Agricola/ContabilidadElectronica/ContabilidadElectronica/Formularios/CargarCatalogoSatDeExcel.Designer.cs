namespace ContabilidadElectronica.Formularios
{
    partial class CargarCatalogoSatDeExcel
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
            this.dgv_catalogo = new System.Windows.Forms.DataGridView();
            this.txt_rutaArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.pb_avance = new System.Windows.Forms.ProgressBar();
            this.btn_mostrar = new System.Windows.Forms.Button();
            this.btn_guardarBD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_catalogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_catalogo
            // 
            this.dgv_catalogo.AllowUserToAddRows = false;
            this.dgv_catalogo.AllowUserToDeleteRows = false;
            this.dgv_catalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_catalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_catalogo.Location = new System.Drawing.Point(12, 69);
            this.dgv_catalogo.Name = "dgv_catalogo";
            this.dgv_catalogo.ReadOnly = true;
            this.dgv_catalogo.Size = new System.Drawing.Size(531, 246);
            this.dgv_catalogo.TabIndex = 0;
            // 
            // txt_rutaArchivo
            // 
            this.txt_rutaArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rutaArchivo.Location = new System.Drawing.Point(150, 9);
            this.txt_rutaArchivo.Name = "txt_rutaArchivo";
            this.txt_rutaArchivo.Size = new System.Drawing.Size(312, 20);
            this.txt_rutaArchivo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ruta Excel Catalogo SAT:";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscar.Location = new System.Drawing.Point(468, 7);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 3;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // pb_avance
            // 
            this.pb_avance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_avance.Location = new System.Drawing.Point(12, 47);
            this.pb_avance.Name = "pb_avance";
            this.pb_avance.Size = new System.Drawing.Size(450, 10);
            this.pb_avance.TabIndex = 4;
            // 
            // btn_mostrar
            // 
            this.btn_mostrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_mostrar.Enabled = false;
            this.btn_mostrar.Location = new System.Drawing.Point(468, 40);
            this.btn_mostrar.Name = "btn_mostrar";
            this.btn_mostrar.Size = new System.Drawing.Size(75, 23);
            this.btn_mostrar.TabIndex = 5;
            this.btn_mostrar.Text = "Mostrar";
            this.btn_mostrar.UseVisualStyleBackColor = true;
            this.btn_mostrar.Click += new System.EventHandler(this.btn_mostrar_Click);
            // 
            // btn_guardarBD
            // 
            this.btn_guardarBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_guardarBD.Location = new System.Drawing.Point(429, 321);
            this.btn_guardarBD.Name = "btn_guardarBD";
            this.btn_guardarBD.Size = new System.Drawing.Size(114, 23);
            this.btn_guardarBD.TabIndex = 6;
            this.btn_guardarBD.Text = "Guardar en BD";
            this.btn_guardarBD.UseVisualStyleBackColor = true;
            this.btn_guardarBD.Click += new System.EventHandler(this.btn_guardarBD_Click);
            // 
            // CargarCatalogoSatDeExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 349);
            this.Controls.Add(this.btn_guardarBD);
            this.Controls.Add(this.btn_mostrar);
            this.Controls.Add(this.pb_avance);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_rutaArchivo);
            this.Controls.Add(this.dgv_catalogo);
            this.Name = "CargarCatalogoSatDeExcel";
            this.Text = "CargarCatalogoSatDeExcel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_catalogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_catalogo;
        private System.Windows.Forms.TextBox txt_rutaArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.ProgressBar pb_avance;
        private System.Windows.Forms.Button btn_mostrar;
        private System.Windows.Forms.Button btn_guardarBD;
    }
}