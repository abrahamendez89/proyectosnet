namespace MenosDelMinimo
{
    partial class MenosDelMinimo
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
            this.dgv_datos = new System.Windows.Forms.DataGridView();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_temporadas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_semana = new System.Windows.Forms.TextBox();
            this.btn_enviarExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_datos
            // 
            this.dgv_datos.AllowUserToAddRows = false;
            this.dgv_datos.AllowUserToDeleteRows = false;
            this.dgv_datos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_datos.Location = new System.Drawing.Point(12, 35);
            this.dgv_datos.Name = "dgv_datos";
            this.dgv_datos.ReadOnly = true;
            this.dgv_datos.Size = new System.Drawing.Size(648, 275);
            this.dgv_datos.TabIndex = 0;
            // 
            // btn_consultar
            // 
            this.btn_consultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_consultar.Location = new System.Drawing.Point(478, 7);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_consultar.TabIndex = 1;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Temporada:";
            // 
            // cmb_temporadas
            // 
            this.cmb_temporadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_temporadas.FormattingEnabled = true;
            this.cmb_temporadas.Location = new System.Drawing.Point(82, 8);
            this.cmb_temporadas.Name = "cmb_temporadas";
            this.cmb_temporadas.Size = new System.Drawing.Size(131, 21);
            this.cmb_temporadas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Semana:";
            // 
            // txt_semana
            // 
            this.txt_semana.Location = new System.Drawing.Point(301, 9);
            this.txt_semana.Name = "txt_semana";
            this.txt_semana.Size = new System.Drawing.Size(100, 20);
            this.txt_semana.TabIndex = 5;
            // 
            // btn_enviarExcel
            // 
            this.btn_enviarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_enviarExcel.Location = new System.Drawing.Point(559, 7);
            this.btn_enviarExcel.Name = "btn_enviarExcel";
            this.btn_enviarExcel.Size = new System.Drawing.Size(101, 23);
            this.btn_enviarExcel.TabIndex = 6;
            this.btn_enviarExcel.Text = "Enviar a excel";
            this.btn_enviarExcel.UseVisualStyleBackColor = true;
            this.btn_enviarExcel.Click += new System.EventHandler(this.btn_enviarExcel_Click);
            // 
            // MenosDelMinimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 322);
            this.Controls.Add(this.btn_enviarExcel);
            this.Controls.Add(this.txt_semana);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_temporadas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.dgv_datos);
            this.Name = "MenosDelMinimo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trabajadores que ganaron menos del minimo.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_datos;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_temporadas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_semana;
        private System.Windows.Forms.Button btn_enviarExcel;
    }
}

