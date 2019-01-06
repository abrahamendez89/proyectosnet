namespace ContabilidadElectronica.Formularios
{
    partial class CatalogoBancos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.txt_descripcionCorta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_descripcionLarga = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.chb_estaActivo = new System.Windows.Forms.CheckBox();
            this.chb_esBancoNacional = new System.Windows.Forms.CheckBox();
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
            this.dgv_catalogo.Location = new System.Drawing.Point(1, 1);
            this.dgv_catalogo.MultiSelect = false;
            this.dgv_catalogo.Name = "dgv_catalogo";
            this.dgv_catalogo.ReadOnly = true;
            this.dgv_catalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_catalogo.Size = new System.Drawing.Size(808, 302);
            this.dgv_catalogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_codigo.Location = new System.Drawing.Point(112, 307);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(100, 20);
            this.txt_codigo.TabIndex = 2;
            // 
            // txt_descripcionCorta
            // 
            this.txt_descripcionCorta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_descripcionCorta.Location = new System.Drawing.Point(112, 333);
            this.txt_descripcionCorta.Name = "txt_descripcionCorta";
            this.txt_descripcionCorta.Size = new System.Drawing.Size(100, 20);
            this.txt_descripcionCorta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción corta:";
            // 
            // txt_descripcionLarga
            // 
            this.txt_descripcionLarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_descripcionLarga.Location = new System.Drawing.Point(111, 359);
            this.txt_descripcionLarga.Name = "txt_descripcionLarga";
            this.txt_descripcionLarga.Size = new System.Drawing.Size(322, 20);
            this.txt_descripcionLarga.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descripción larga:";
            // 
            // btn_guardar
            // 
            this.btn_guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_guardar.Location = new System.Drawing.Point(727, 383);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 7;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // chb_estaActivo
            // 
            this.chb_estaActivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chb_estaActivo.AutoSize = true;
            this.chb_estaActivo.Location = new System.Drawing.Point(16, 387);
            this.chb_estaActivo.Name = "chb_estaActivo";
            this.chb_estaActivo.Size = new System.Drawing.Size(79, 17);
            this.chb_estaActivo.TabIndex = 8;
            this.chb_estaActivo.Text = "Está activo";
            this.chb_estaActivo.UseVisualStyleBackColor = true;
            // 
            // chb_esBancoNacional
            // 
            this.chb_esBancoNacional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chb_esBancoNacional.AutoSize = true;
            this.chb_esBancoNacional.Location = new System.Drawing.Point(319, 309);
            this.chb_esBancoNacional.Name = "chb_esBancoNacional";
            this.chb_esBancoNacional.Size = new System.Drawing.Size(114, 17);
            this.chb_esBancoNacional.TabIndex = 9;
            this.chb_esBancoNacional.Text = "Es banco nacional";
            this.chb_esBancoNacional.UseVisualStyleBackColor = true;
            // 
            // CatalogoBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 422);
            this.Controls.Add(this.chb_esBancoNacional);
            this.Controls.Add(this.chb_estaActivo);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.txt_descripcionLarga);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_descripcionCorta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_catalogo);
            this.Name = "CatalogoBancos";
            this.Text = "CatalogoBancos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_catalogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_catalogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.TextBox txt_descripcionCorta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_descripcionLarga;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.CheckBox chb_estaActivo;
        private System.Windows.Forms.CheckBox chb_esBancoNacional;
    }
}