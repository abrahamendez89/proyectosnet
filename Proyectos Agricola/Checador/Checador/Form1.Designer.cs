namespace Checador
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_empleado = new System.Windows.Forms.TextBox();
            this.txt_nomina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_temporada = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_bd = new System.Windows.Forms.TextBox();
            this.pnl_contenido = new System.Windows.Forms.Panel();
            this.lbl_modoPrueba = new System.Windows.Forms.Label();
            this.pb_huella = new System.Windows.Forms.PictureBox();
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.txt_hora = new System.Windows.Forms.TextBox();
            this.pb_fotoEmpleado = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.pb_cerrar = new System.Windows.Forms.PictureBox();
            this.pb_logoEmpresa = new System.Windows.Forms.PictureBox();
            this.txt_mensaje = new System.Windows.Forms.TextBox();
            this.pnl_contenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_huella)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fotoEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logoEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_empleado
            // 
            this.txt_empleado.BackColor = System.Drawing.SystemColors.Window;
            this.txt_empleado.Enabled = false;
            this.txt_empleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_empleado.Location = new System.Drawing.Point(4, 358);
            this.txt_empleado.Name = "txt_empleado";
            this.txt_empleado.ReadOnly = true;
            this.txt_empleado.Size = new System.Drawing.Size(600, 35);
            this.txt_empleado.TabIndex = 2;
            this.txt_empleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_nomina
            // 
            this.txt_nomina.BackColor = System.Drawing.SystemColors.Window;
            this.txt_nomina.Enabled = false;
            this.txt_nomina.Location = new System.Drawing.Point(64, 6);
            this.txt_nomina.Name = "txt_nomina";
            this.txt_nomina.ReadOnly = true;
            this.txt_nomina.Size = new System.Drawing.Size(93, 20);
            this.txt_nomina.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nómina:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Temporada:";
            // 
            // txt_temporada
            // 
            this.txt_temporada.BackColor = System.Drawing.SystemColors.Window;
            this.txt_temporada.Enabled = false;
            this.txt_temporada.Location = new System.Drawing.Point(233, 6);
            this.txt_temporada.Name = "txt_temporada";
            this.txt_temporada.ReadOnly = true;
            this.txt_temporada.Size = new System.Drawing.Size(93, 20);
            this.txt_temporada.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "BD:";
            // 
            // txt_bd
            // 
            this.txt_bd.BackColor = System.Drawing.SystemColors.Window;
            this.txt_bd.Enabled = false;
            this.txt_bd.Location = new System.Drawing.Point(537, 6);
            this.txt_bd.Name = "txt_bd";
            this.txt_bd.ReadOnly = true;
            this.txt_bd.Size = new System.Drawing.Size(124, 20);
            this.txt_bd.TabIndex = 7;
            // 
            // pnl_contenido
            // 
            this.pnl_contenido.Controls.Add(this.lbl_modoPrueba);
            this.pnl_contenido.Controls.Add(this.pb_huella);
            this.pnl_contenido.Controls.Add(this.txt_fecha);
            this.pnl_contenido.Controls.Add(this.txt_hora);
            this.pnl_contenido.Controls.Add(this.pb_fotoEmpleado);
            this.pnl_contenido.Controls.Add(this.txt_empleado);
            this.pnl_contenido.Location = new System.Drawing.Point(124, 48);
            this.pnl_contenido.Name = "pnl_contenido";
            this.pnl_contenido.Size = new System.Drawing.Size(616, 628);
            this.pnl_contenido.TabIndex = 9;
            // 
            // lbl_modoPrueba
            // 
            this.lbl_modoPrueba.AutoSize = true;
            this.lbl_modoPrueba.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modoPrueba.Location = new System.Drawing.Point(132, 594);
            this.lbl_modoPrueba.Name = "lbl_modoPrueba";
            this.lbl_modoPrueba.Size = new System.Drawing.Size(339, 25);
            this.lbl_modoPrueba.TabIndex = 15;
            this.lbl_modoPrueba.Text = "MODO DE PRUEBA ACTIVADO";
            this.lbl_modoPrueba.Visible = false;
            // 
            // pb_huella
            // 
            this.pb_huella.BackColor = System.Drawing.Color.White;
            this.pb_huella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_huella.Location = new System.Drawing.Point(238, 448);
            this.pb_huella.Name = "pb_huella";
            this.pb_huella.Size = new System.Drawing.Size(128, 135);
            this.pb_huella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_huella.TabIndex = 14;
            this.pb_huella.TabStop = false;
            this.pb_huella.Click += new System.EventHandler(this.pb_huella_Click);
            this.pb_huella.DoubleClick += new System.EventHandler(this.pb_huella_DoubleClick);
            // 
            // txt_fecha
            // 
            this.txt_fecha.BackColor = System.Drawing.SystemColors.Window;
            this.txt_fecha.Enabled = false;
            this.txt_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fecha.Location = new System.Drawing.Point(4, 3);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.ReadOnly = true;
            this.txt_fecha.Size = new System.Drawing.Size(609, 29);
            this.txt_fecha.TabIndex = 13;
            this.txt_fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_hora
            // 
            this.txt_hora.BackColor = System.Drawing.SystemColors.Window;
            this.txt_hora.Enabled = false;
            this.txt_hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_hora.Location = new System.Drawing.Point(3, 402);
            this.txt_hora.Name = "txt_hora";
            this.txt_hora.ReadOnly = true;
            this.txt_hora.Size = new System.Drawing.Size(601, 40);
            this.txt_hora.TabIndex = 12;
            this.txt_hora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pb_fotoEmpleado
            // 
            this.pb_fotoEmpleado.BackColor = System.Drawing.Color.White;
            this.pb_fotoEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_fotoEmpleado.Location = new System.Drawing.Point(178, 51);
            this.pb_fotoEmpleado.Name = "pb_fotoEmpleado";
            this.pb_fotoEmpleado.Size = new System.Drawing.Size(253, 281);
            this.pb_fotoEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_fotoEmpleado.TabIndex = 1;
            this.pb_fotoEmpleado.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "ID checador:";
            // 
            // txt_id
            // 
            this.txt_id.BackColor = System.Drawing.SystemColors.Window;
            this.txt_id.Enabled = false;
            this.txt_id.Location = new System.Drawing.Point(407, 6);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(93, 20);
            this.txt_id.TabIndex = 10;
            // 
            // pb_cerrar
            // 
            this.pb_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_cerrar.Image = global::Checador.Properties.Resources._1403562203_Close_Box_Red;
            this.pb_cerrar.Location = new System.Drawing.Point(814, 6);
            this.pb_cerrar.Name = "pb_cerrar";
            this.pb_cerrar.Size = new System.Drawing.Size(53, 50);
            this.pb_cerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_cerrar.TabIndex = 13;
            this.pb_cerrar.TabStop = false;
            this.pb_cerrar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_cerrar_MouseClick);
            // 
            // pb_logoEmpresa
            // 
            this.pb_logoEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_logoEmpresa.Image = global::Checador.Properties.Resources.logo_wholesumHarvest;
            this.pb_logoEmpresa.Location = new System.Drawing.Point(12, 652);
            this.pb_logoEmpresa.Name = "pb_logoEmpresa";
            this.pb_logoEmpresa.Size = new System.Drawing.Size(145, 97);
            this.pb_logoEmpresa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logoEmpresa.TabIndex = 12;
            this.pb_logoEmpresa.TabStop = false;
            this.pb_logoEmpresa.Click += new System.EventHandler(this.pb_logoEmpresa_Click);
            // 
            // txt_mensaje
            // 
            this.txt_mensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_mensaje.BackColor = System.Drawing.SystemColors.Window;
            this.txt_mensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_mensaje.Enabled = false;
            this.txt_mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mensaje.Location = new System.Drawing.Point(163, 714);
            this.txt_mensaje.Name = "txt_mensaje";
            this.txt_mensaje.ReadOnly = true;
            this.txt_mensaje.Size = new System.Drawing.Size(699, 28);
            this.txt_mensaje.TabIndex = 14;
            this.txt_mensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(874, 761);
            this.Controls.Add(this.txt_mensaje);
            this.Controls.Add(this.pb_cerrar);
            this.Controls.Add(this.pb_logoEmpresa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.pnl_contenido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_bd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_temporada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nomina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnl_contenido.ResumeLayout(false);
            this.pnl_contenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_huella)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fotoEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logoEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_fotoEmpleado;
        private System.Windows.Forms.TextBox txt_empleado;
        private System.Windows.Forms.TextBox txt_nomina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_temporada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_bd;
        private System.Windows.Forms.Panel pnl_contenido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_hora;
        private System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.PictureBox pb_huella;
        private System.Windows.Forms.PictureBox pb_logoEmpresa;
        private System.Windows.Forms.PictureBox pb_cerrar;
        private System.Windows.Forms.Label lbl_modoPrueba;
        private System.Windows.Forms.TextBox txt_mensaje;

    }
}

