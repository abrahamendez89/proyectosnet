namespace VNCViewerLauncher.ControlesUsuario
{
    partial class UCAgregarEquipoComputo
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
            this.lbl_equipo = new System.Windows.Forms.Label();
            this.pb_icono = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_equipo
            // 
            this.lbl_equipo.AutoSize = true;
            this.lbl_equipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_equipo.Location = new System.Drawing.Point(70, 57);
            this.lbl_equipo.Name = "lbl_equipo";
            this.lbl_equipo.Size = new System.Drawing.Size(132, 20);
            this.lbl_equipo.TabIndex = 1;
            this.lbl_equipo.Text = "Agregar equipo";
            // 
            // pb_icono
            // 
            this.pb_icono.Image = global::VNCViewerLauncher.Properties.Resources._1445996319_add_blue;
            this.pb_icono.Location = new System.Drawing.Point(9, 43);
            this.pb_icono.Name = "pb_icono";
            this.pb_icono.Size = new System.Drawing.Size(50, 50);
            this.pb_icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_icono.TabIndex = 0;
            this.pb_icono.TabStop = false;
            // 
            // UCAgregarEquipoComputo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_equipo);
            this.Controls.Add(this.pb_icono);
            this.Name = "UCAgregarEquipoComputo";
            this.Size = new System.Drawing.Size(252, 145);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCAgregarEquipoComputo_MouseClick);
            this.MouseEnter += new System.EventHandler(this.UCEquipoComputo_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UCEquipoComputo_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_icono;
        private System.Windows.Forms.Label lbl_equipo;
    }
}
