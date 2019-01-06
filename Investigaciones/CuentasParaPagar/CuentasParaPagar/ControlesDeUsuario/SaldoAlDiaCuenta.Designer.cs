namespace CuentasParaPagar.ControlesDeUsuario
{
    partial class SaldoAlDiaCuenta
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
            this.pb_imagen = new System.Windows.Forms.PictureBox();
            this.lbl_nombreCuenta = new System.Windows.Forms.Label();
            this.lbl_saldo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_imagen
            // 
            this.pb_imagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_imagen.Location = new System.Drawing.Point(12, 10);
            this.pb_imagen.Name = "pb_imagen";
            this.pb_imagen.Size = new System.Drawing.Size(124, 82);
            this.pb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_imagen.TabIndex = 0;
            this.pb_imagen.TabStop = false;
            // 
            // lbl_nombreCuenta
            // 
            this.lbl_nombreCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_nombreCuenta.AutoSize = true;
            this.lbl_nombreCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombreCuenta.Location = new System.Drawing.Point(3, 103);
            this.lbl_nombreCuenta.Name = "lbl_nombreCuenta";
            this.lbl_nombreCuenta.Size = new System.Drawing.Size(141, 15);
            this.lbl_nombreCuenta.TabIndex = 1;
            this.lbl_nombreCuenta.Text = "Nombre de la cuenta";
            // 
            // lbl_saldo
            // 
            this.lbl_saldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_saldo.AutoSize = true;
            this.lbl_saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_saldo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_saldo.Location = new System.Drawing.Point(36, 123);
            this.lbl_saldo.Name = "lbl_saldo";
            this.lbl_saldo.Size = new System.Drawing.Size(65, 24);
            this.lbl_saldo.TabIndex = 2;
            this.lbl_saldo.Text = "$1,000";
            // 
            // SaldoAlDiaCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.lbl_saldo);
            this.Controls.Add(this.lbl_nombreCuenta);
            this.Controls.Add(this.pb_imagen);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "SaldoAlDiaCuenta";
            this.Size = new System.Drawing.Size(151, 167);
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_imagen;
        private System.Windows.Forms.Label lbl_nombreCuenta;
        private System.Windows.Forms.Label lbl_saldo;
    }
}
