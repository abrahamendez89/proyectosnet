namespace VNCViewerLauncher.ControlesUsuario
{
    partial class UCAgregarGrupo
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
            this.lbl_nombreGrupo = new System.Windows.Forms.Label();
            this.pb_icono = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_nombreGrupo
            // 
            this.lbl_nombreGrupo.AutoSize = true;
            this.lbl_nombreGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombreGrupo.Location = new System.Drawing.Point(53, 31);
            this.lbl_nombreGrupo.Name = "lbl_nombreGrupo";
            this.lbl_nombreGrupo.Size = new System.Drawing.Size(114, 18);
            this.lbl_nombreGrupo.TabIndex = 1;
            this.lbl_nombreGrupo.Text = "Agregar grupo";
            // 
            // pb_icono
            // 
            this.pb_icono.Image = global::VNCViewerLauncher.Properties.Resources._1445996319_add_blue;
            this.pb_icono.Location = new System.Drawing.Point(10, 23);
            this.pb_icono.Name = "pb_icono";
            this.pb_icono.Size = new System.Drawing.Size(35, 35);
            this.pb_icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_icono.TabIndex = 0;
            this.pb_icono.TabStop = false;
            // 
            // UCAgregarGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_nombreGrupo);
            this.Controls.Add(this.pb_icono);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UCAgregarGrupo";
            this.Size = new System.Drawing.Size(309, 83);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCGrupo_MouseClick);
            this.MouseEnter += new System.EventHandler(this.UCGrupo_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UCGrupo_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_icono;
        private System.Windows.Forms.Label lbl_nombreGrupo;
    }
}
