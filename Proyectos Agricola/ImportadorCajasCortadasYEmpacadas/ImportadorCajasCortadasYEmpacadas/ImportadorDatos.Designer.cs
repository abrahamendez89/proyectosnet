namespace ImportadorCajasCortadasYEmpacadas
{
    partial class ImportadorDatos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_resultados = new System.Windows.Forms.DataGridView();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_ruta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_query = new System.Windows.Forms.TextBox();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.btn_EnviarAExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_resultados
            // 
            this.dgv_resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resultados.Location = new System.Drawing.Point(12, 119);
            this.dgv_resultados.Name = "dgv_resultados";
            this.dgv_resultados.Size = new System.Drawing.Size(894, 412);
            this.dgv_resultados.TabIndex = 0;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscar.Location = new System.Drawing.Point(831, 3);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 1;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_ruta
            // 
            this.txt_ruta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ruta.Location = new System.Drawing.Point(135, 5);
            this.txt_ruta.Name = "txt_ruta";
            this.txt_ruta.Size = new System.Drawing.Size(690, 20);
            this.txt_ruta.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Archivo de BD Access:";
            // 
            // txt_query
            // 
            this.txt_query.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_query.Location = new System.Drawing.Point(13, 31);
            this.txt_query.Multiline = true;
            this.txt_query.Name = "txt_query";
            this.txt_query.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_query.Size = new System.Drawing.Size(812, 82);
            this.txt_query.TabIndex = 4;
            // 
            // btn_consultar
            // 
            this.btn_consultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_consultar.Location = new System.Drawing.Point(831, 32);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(75, 81);
            this.btn_consultar.TabIndex = 5;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // btn_EnviarAExcel
            // 
            this.btn_EnviarAExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EnviarAExcel.Location = new System.Drawing.Point(787, 537);
            this.btn_EnviarAExcel.Name = "btn_EnviarAExcel";
            this.btn_EnviarAExcel.Size = new System.Drawing.Size(119, 23);
            this.btn_EnviarAExcel.TabIndex = 6;
            this.btn_EnviarAExcel.Text = "Enviar a excel";
            this.btn_EnviarAExcel.UseVisualStyleBackColor = true;
            this.btn_EnviarAExcel.Click += new System.EventHandler(this.btn_EnviarAExcel_Click);
            // 
            // ImportadorDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 570);
            this.Controls.Add(this.btn_EnviarAExcel);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.txt_query);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ruta);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.dgv_resultados);
            this.Name = "ImportadorDatos";
            this.Text = "Importador";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_resultados;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_ruta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_query;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.Button btn_EnviarAExcel;

    }
}

