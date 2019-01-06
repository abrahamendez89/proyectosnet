namespace VNCViewerLauncher.ControlesUsuario
{
    partial class UCGrupo
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
            this.lbl_detalles = new System.Windows.Forms.Label();
            this.pb_eliminar = new System.Windows.Forms.PictureBox();
            this.pb_editar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_nombreGrupo
            // 
            this.lbl_nombreGrupo.AutoSize = true;
            this.lbl_nombreGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombreGrupo.Location = new System.Drawing.Point(49, 14);
            this.lbl_nombreGrupo.Name = "lbl_nombreGrupo";
            this.lbl_nombreGrupo.Size = new System.Drawing.Size(239, 18);
            this.lbl_nombreGrupo.TabIndex = 1;
            this.lbl_nombreGrupo.Text = "Este es el nombre de un grupo";
            // 
            // pb_icono
            // 
            this.pb_icono.Image = global::VNCViewerLauncher.Properties.Resources._1445993988_circle;
            this.pb_icono.Location = new System.Drawing.Point(9, 12);
            this.pb_icono.Name = "pb_icono";
            this.pb_icono.Size = new System.Drawing.Size(35, 35);
            this.pb_icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_icono.TabIndex = 0;
            this.pb_icono.TabStop = false;
            // 
            // lbl_detalles
            // 
            this.lbl_detalles.AutoSize = true;
            this.lbl_detalles.Location = new System.Drawing.Point(49, 33);
            this.lbl_detalles.Name = "lbl_detalles";
            this.lbl_detalles.Size = new System.Drawing.Size(113, 13);
            this.lbl_detalles.TabIndex = 2;
            this.lbl_detalles.Text = "10 equipos registrados";
            // 
            // pb_eliminar
            // 
            this.pb_eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_eliminar.Image = global::VNCViewerLauncher.Properties.Resources._1445996357_close_red;
            this.pb_eliminar.Location = new System.Drawing.Point(239, 50);
            this.pb_eliminar.Name = "pb_eliminar";
            this.pb_eliminar.Size = new System.Drawing.Size(25, 25);
            this.pb_eliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eliminar.TabIndex = 7;
            this.pb_eliminar.TabStop = false;
            this.pb_eliminar.Click += new System.EventHandler(this.pb_eliminar_Click);
            // 
            // pb_editar
            // 
            this.pb_editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editar.Image = global::VNCViewerLauncher.Properties.Resources._1445996814_icon_136_document_edit;
            this.pb_editar.Location = new System.Drawing.Point(270, 50);
            this.pb_editar.Name = "pb_editar";
            this.pb_editar.Size = new System.Drawing.Size(25, 25);
            this.pb_editar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_editar.TabIndex = 9;
            this.pb_editar.TabStop = false;
            this.pb_editar.Click += new System.EventHandler(this.pb_editar_Click);
            // 
            // UCGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pb_editar);
            this.Controls.Add(this.pb_eliminar);
            this.Controls.Add(this.lbl_detalles);
            this.Controls.Add(this.lbl_nombreGrupo);
            this.Controls.Add(this.pb_icono);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UCGrupo";
            this.Size = new System.Drawing.Size(309, 83);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCGrupo_MouseClick);
            this.MouseEnter += new System.EventHandler(this.UCGrupo_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UCGrupo_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_icono;
        private System.Windows.Forms.Label lbl_nombreGrupo;
        private System.Windows.Forms.Label lbl_detalles;
        private System.Windows.Forms.PictureBox pb_eliminar;
        private System.Windows.Forms.PictureBox pb_editar;
    }
}
