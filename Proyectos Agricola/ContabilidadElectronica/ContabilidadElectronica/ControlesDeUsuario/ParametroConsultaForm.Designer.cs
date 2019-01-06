namespace ContabilidadElectronica.ControlesDeUsuario
{
    partial class ParametroConsultaForm
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_controles = new System.Windows.Forms.Panel();
            this.pnl_control = new System.Windows.Forms.Panel();
            this.lbl_tituloParametro = new System.Windows.Forms.Label();
            this.pnl_controles.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_controles
            // 
            this.pnl_controles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_controles.BackColor = System.Drawing.Color.White;
            this.pnl_controles.Controls.Add(this.lbl_tituloParametro);
            this.pnl_controles.Controls.Add(this.pnl_control);
            this.pnl_controles.Location = new System.Drawing.Point(0, 3);
            this.pnl_controles.Name = "pnl_controles";
            this.pnl_controles.Size = new System.Drawing.Size(403, 56);
            this.pnl_controles.TabIndex = 0;
            // 
            // pnl_control
            // 
            this.pnl_control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_control.Location = new System.Drawing.Point(10, 26);
            this.pnl_control.Name = "pnl_control";
            this.pnl_control.Size = new System.Drawing.Size(390, 27);
            this.pnl_control.TabIndex = 0;
            // 
            // lbl_tituloParametro
            // 
            this.lbl_tituloParametro.AutoSize = true;
            this.lbl_tituloParametro.Location = new System.Drawing.Point(7, 8);
            this.lbl_tituloParametro.Name = "lbl_tituloParametro";
            this.lbl_tituloParametro.Size = new System.Drawing.Size(35, 13);
            this.lbl_tituloParametro.TabIndex = 1;
            this.lbl_tituloParametro.Text = "label1";
            // 
            // ParametroConsultaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnl_controles);
            this.Name = "ParametroConsultaForm";
            this.Size = new System.Drawing.Size(403, 79);
            this.pnl_controles.ResumeLayout(false);
            this.pnl_controles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_controles;
        private System.Windows.Forms.Panel pnl_control;
        private System.Windows.Forms.Label lbl_tituloParametro;
    }
}
