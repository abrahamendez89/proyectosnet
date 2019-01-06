namespace VNCViewerLauncher.ControlesUsuario
{
    partial class UCEquipoComputo
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
            this.lbl_rutaEquipo = new System.Windows.Forms.Label();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.pb_ultravnc = new System.Windows.Forms.PictureBox();
            this.pb_editar = new System.Windows.Forms.PictureBox();
            this.pb_realvnc = new System.Windows.Forms.PictureBox();
            this.pb_eliminar = new System.Windows.Forms.PictureBox();
            this.pb_icono = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ultravnc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_realvnc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_equipo
            // 
            this.lbl_equipo.AutoSize = true;
            this.lbl_equipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_equipo.Location = new System.Drawing.Point(70, 13);
            this.lbl_equipo.Name = "lbl_equipo";
            this.lbl_equipo.Size = new System.Drawing.Size(159, 20);
            this.lbl_equipo.TabIndex = 1;
            this.lbl_equipo.Text = "Nombre del equipo";
            // 
            // lbl_rutaEquipo
            // 
            this.lbl_rutaEquipo.AutoSize = true;
            this.lbl_rutaEquipo.Location = new System.Drawing.Point(72, 34);
            this.lbl_rutaEquipo.Name = "lbl_rutaEquipo";
            this.lbl_rutaEquipo.Size = new System.Drawing.Size(88, 13);
            this.lbl_rutaEquipo.TabIndex = 2;
            this.lbl_rutaEquipo.Text = "192.168.140.126";
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_descripcion.BackColor = System.Drawing.Color.White;
            this.txt_descripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_descripcion.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_descripcion.Location = new System.Drawing.Point(9, 67);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.ReadOnly = true;
            this.txt_descripcion.Size = new System.Drawing.Size(233, 40);
            this.txt_descripcion.TabIndex = 6;
            this.txt_descripcion.Text = "Esta es una descripcion muy larga acerca de quien es el equipo que esta registrad" +
    "o.";
            // 
            // pb_ultravnc
            // 
            this.pb_ultravnc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ultravnc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ultravnc.Image = global::VNCViewerLauncher.Properties.Resources.ultravnc1;
            this.pb_ultravnc.Location = new System.Drawing.Point(185, 113);
            this.pb_ultravnc.Name = "pb_ultravnc";
            this.pb_ultravnc.Size = new System.Drawing.Size(25, 25);
            this.pb_ultravnc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ultravnc.TabIndex = 8;
            this.pb_ultravnc.TabStop = false;
            this.pb_ultravnc.Click += new System.EventHandler(this.pb_ultravnc_Click);
            // 
            // pb_editar
            // 
            this.pb_editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_editar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_editar.Image = global::VNCViewerLauncher.Properties.Resources._1445996814_icon_136_document_edit;
            this.pb_editar.Location = new System.Drawing.Point(39, 113);
            this.pb_editar.Name = "pb_editar";
            this.pb_editar.Size = new System.Drawing.Size(25, 25);
            this.pb_editar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_editar.TabIndex = 5;
            this.pb_editar.TabStop = false;
            this.pb_editar.Click += new System.EventHandler(this.pb_editar_Click);
            // 
            // pb_realvnc
            // 
            this.pb_realvnc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_realvnc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_realvnc.Image = global::VNCViewerLauncher.Properties.Resources.realvnc1;
            this.pb_realvnc.Location = new System.Drawing.Point(217, 113);
            this.pb_realvnc.Name = "pb_realvnc";
            this.pb_realvnc.Size = new System.Drawing.Size(25, 25);
            this.pb_realvnc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_realvnc.TabIndex = 4;
            this.pb_realvnc.TabStop = false;
            this.pb_realvnc.Click += new System.EventHandler(this.pb_conectar_Click);
            // 
            // pb_eliminar
            // 
            this.pb_eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_eliminar.Image = global::VNCViewerLauncher.Properties.Resources._1445996357_close_red;
            this.pb_eliminar.Location = new System.Drawing.Point(9, 113);
            this.pb_eliminar.Name = "pb_eliminar";
            this.pb_eliminar.Size = new System.Drawing.Size(25, 25);
            this.pb_eliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eliminar.TabIndex = 3;
            this.pb_eliminar.TabStop = false;
            this.pb_eliminar.Click += new System.EventHandler(this.pb_eliminar_Click);
            // 
            // pb_icono
            // 
            this.pb_icono.Image = global::VNCViewerLauncher.Properties.Resources._1445996563_desktop_monitor_screen;
            this.pb_icono.Location = new System.Drawing.Point(9, 8);
            this.pb_icono.Name = "pb_icono";
            this.pb_icono.Size = new System.Drawing.Size(50, 50);
            this.pb_icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_icono.TabIndex = 0;
            this.pb_icono.TabStop = false;
            // 
            // UCEquipoComputo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pb_ultravnc);
            this.Controls.Add(this.txt_descripcion);
            this.Controls.Add(this.pb_editar);
            this.Controls.Add(this.pb_realvnc);
            this.Controls.Add(this.pb_eliminar);
            this.Controls.Add(this.lbl_rutaEquipo);
            this.Controls.Add(this.lbl_equipo);
            this.Controls.Add(this.pb_icono);
            this.Name = "UCEquipoComputo";
            this.Size = new System.Drawing.Size(252, 145);
            this.MouseEnter += new System.EventHandler(this.UCEquipoComputo_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UCEquipoComputo_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ultravnc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_editar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_realvnc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_icono;
        private System.Windows.Forms.Label lbl_equipo;
        private System.Windows.Forms.Label lbl_rutaEquipo;
        private System.Windows.Forms.PictureBox pb_eliminar;
        private System.Windows.Forms.PictureBox pb_realvnc;
        private System.Windows.Forms.PictureBox pb_editar;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.PictureBox pb_ultravnc;
    }
}
