namespace RespaldosAutomaticos
{
    partial class RespaldoAutomatico
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
            this.labe = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_rutas = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_hora = new System.Windows.Forms.ComboBox();
            this.cmb_minuto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chb_lunes = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chb_martes = new System.Windows.Forms.CheckBox();
            this.chb_miercoles = new System.Windows.Forms.CheckBox();
            this.chb_jueves = new System.Windows.Forms.CheckBox();
            this.chb_viernes = new System.Windows.Forms.CheckBox();
            this.chb_domingo = new System.Windows.Forms.CheckBox();
            this.chb_sabado = new System.Windows.Forms.CheckBox();
            this.txt_carpetaDestino = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pb_guardar = new System.Windows.Forms.PictureBox();
            this.pb_agregarRuta = new System.Windows.Forms.PictureBox();
            this.pb_quitarRuta = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_guardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_agregarRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_quitarRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labe
            // 
            this.labe.AutoSize = true;
            this.labe.Location = new System.Drawing.Point(97, 25);
            this.labe.Name = "labe";
            this.labe.Size = new System.Drawing.Size(46, 13);
            this.labe.TabIndex = 1;
            this.labe.Text = "Usuario:";
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(156, 22);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(168, 20);
            this.txt_usuario.TabIndex = 2;
            // 
            // txt_contra
            // 
            this.txt_contra.Location = new System.Drawing.Point(400, 22);
            this.txt_contra.Name = "txt_contra";
            this.txt_contra.PasswordChar = '*';
            this.txt_contra.Size = new System.Drawing.Size(178, 20);
            this.txt_contra.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraseña:";
            // 
            // lb_rutas
            // 
            this.lb_rutas.FormattingEnabled = true;
            this.lb_rutas.Location = new System.Drawing.Point(12, 145);
            this.lb_rutas.Name = "lb_rutas";
            this.lb_rutas.Size = new System.Drawing.Size(530, 95);
            this.lb_rutas.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Carpetas a respaldar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hora de respaldo:";
            // 
            // cmb_hora
            // 
            this.cmb_hora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_hora.FormattingEnabled = true;
            this.cmb_hora.Location = new System.Drawing.Point(109, 84);
            this.cmb_hora.Name = "cmb_hora";
            this.cmb_hora.Size = new System.Drawing.Size(55, 21);
            this.cmb_hora.TabIndex = 10;
            // 
            // cmb_minuto
            // 
            this.cmb_minuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_minuto.FormattingEnabled = true;
            this.cmb_minuto.Location = new System.Drawing.Point(177, 84);
            this.cmb_minuto.Name = "cmb_minuto";
            this.cmb_minuto.Size = new System.Drawing.Size(55, 21);
            this.cmb_minuto.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = ":";
            // 
            // chb_lunes
            // 
            this.chb_lunes.AutoSize = true;
            this.chb_lunes.Location = new System.Drawing.Point(109, 111);
            this.chb_lunes.Name = "chb_lunes";
            this.chb_lunes.Size = new System.Drawing.Size(55, 17);
            this.chb_lunes.TabIndex = 13;
            this.chb_lunes.Text = "Lunes";
            this.chb_lunes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Días de respaldo:";
            // 
            // chb_martes
            // 
            this.chb_martes.AutoSize = true;
            this.chb_martes.Location = new System.Drawing.Point(170, 111);
            this.chb_martes.Name = "chb_martes";
            this.chb_martes.Size = new System.Drawing.Size(58, 17);
            this.chb_martes.TabIndex = 15;
            this.chb_martes.Text = "Martes";
            this.chb_martes.UseVisualStyleBackColor = true;
            // 
            // chb_miercoles
            // 
            this.chb_miercoles.AutoSize = true;
            this.chb_miercoles.Location = new System.Drawing.Point(234, 111);
            this.chb_miercoles.Name = "chb_miercoles";
            this.chb_miercoles.Size = new System.Drawing.Size(71, 17);
            this.chb_miercoles.TabIndex = 16;
            this.chb_miercoles.Text = "Miércoles";
            this.chb_miercoles.UseVisualStyleBackColor = true;
            // 
            // chb_jueves
            // 
            this.chb_jueves.AutoSize = true;
            this.chb_jueves.Location = new System.Drawing.Point(311, 111);
            this.chb_jueves.Name = "chb_jueves";
            this.chb_jueves.Size = new System.Drawing.Size(60, 17);
            this.chb_jueves.TabIndex = 17;
            this.chb_jueves.Text = "Jueves";
            this.chb_jueves.UseVisualStyleBackColor = true;
            // 
            // chb_viernes
            // 
            this.chb_viernes.AutoSize = true;
            this.chb_viernes.Location = new System.Drawing.Point(377, 111);
            this.chb_viernes.Name = "chb_viernes";
            this.chb_viernes.Size = new System.Drawing.Size(61, 17);
            this.chb_viernes.TabIndex = 18;
            this.chb_viernes.Text = "Viernes";
            this.chb_viernes.UseVisualStyleBackColor = true;
            // 
            // chb_domingo
            // 
            this.chb_domingo.AutoSize = true;
            this.chb_domingo.Location = new System.Drawing.Point(513, 111);
            this.chb_domingo.Name = "chb_domingo";
            this.chb_domingo.Size = new System.Drawing.Size(68, 17);
            this.chb_domingo.TabIndex = 19;
            this.chb_domingo.Text = "Domingo";
            this.chb_domingo.UseVisualStyleBackColor = true;
            // 
            // chb_sabado
            // 
            this.chb_sabado.AutoSize = true;
            this.chb_sabado.Location = new System.Drawing.Point(444, 111);
            this.chb_sabado.Name = "chb_sabado";
            this.chb_sabado.Size = new System.Drawing.Size(63, 17);
            this.chb_sabado.TabIndex = 20;
            this.chb_sabado.Text = "Sábado";
            this.chb_sabado.UseVisualStyleBackColor = true;
            // 
            // txt_carpetaDestino
            // 
            this.txt_carpetaDestino.Location = new System.Drawing.Point(410, 80);
            this.txt_carpetaDestino.Name = "txt_carpetaDestino";
            this.txt_carpetaDestino.Size = new System.Drawing.Size(168, 20);
            this.txt_carpetaDestino.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Respaldar en:";
            // 
            // pb_guardar
            // 
            this.pb_guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_guardar.Image = global::RespaldosAutomaticos.Properties.Resources._1446792133_floppy_disk;
            this.pb_guardar.Location = new System.Drawing.Point(548, 178);
            this.pb_guardar.Name = "pb_guardar";
            this.pb_guardar.Size = new System.Drawing.Size(30, 30);
            this.pb_guardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_guardar.TabIndex = 23;
            this.pb_guardar.TabStop = false;
            // 
            // pb_agregarRuta
            // 
            this.pb_agregarRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_agregarRuta.Image = global::RespaldosAutomaticos.Properties.Resources._1445996319_add_blue;
            this.pb_agregarRuta.Location = new System.Drawing.Point(548, 145);
            this.pb_agregarRuta.Name = "pb_agregarRuta";
            this.pb_agregarRuta.Size = new System.Drawing.Size(30, 30);
            this.pb_agregarRuta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_agregarRuta.TabIndex = 8;
            this.pb_agregarRuta.TabStop = false;
            // 
            // pb_quitarRuta
            // 
            this.pb_quitarRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_quitarRuta.Image = global::RespaldosAutomaticos.Properties.Resources._1445996357_close_red;
            this.pb_quitarRuta.Location = new System.Drawing.Point(548, 211);
            this.pb_quitarRuta.Name = "pb_quitarRuta";
            this.pb_quitarRuta.Size = new System.Drawing.Size(30, 30);
            this.pb_quitarRuta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_quitarRuta.TabIndex = 7;
            this.pb_quitarRuta.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::RespaldosAutomaticos.Properties.Resources._1446507214_onedrive_256;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // RespaldoAutomatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(596, 252);
            this.Controls.Add(this.pb_guardar);
            this.Controls.Add(this.txt_carpetaDestino);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chb_sabado);
            this.Controls.Add(this.chb_domingo);
            this.Controls.Add(this.chb_viernes);
            this.Controls.Add(this.chb_jueves);
            this.Controls.Add(this.chb_miercoles);
            this.Controls.Add(this.chb_martes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chb_lunes);
            this.Controls.Add(this.cmb_minuto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_hora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pb_agregarRuta);
            this.Controls.Add(this.pb_quitarRuta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_rutas);
            this.Controls.Add(this.txt_contra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.labe);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RespaldoAutomatico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Respaldos automáticos";
            ((System.ComponentModel.ISupportInitialize)(this.pb_guardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_agregarRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_quitarRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labe;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_rutas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pb_quitarRuta;
        private System.Windows.Forms.PictureBox pb_agregarRuta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_hora;
        private System.Windows.Forms.ComboBox cmb_minuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chb_lunes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chb_martes;
        private System.Windows.Forms.CheckBox chb_miercoles;
        private System.Windows.Forms.CheckBox chb_jueves;
        private System.Windows.Forms.CheckBox chb_viernes;
        private System.Windows.Forms.CheckBox chb_domingo;
        private System.Windows.Forms.CheckBox chb_sabado;
        private System.Windows.Forms.TextBox txt_carpetaDestino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pb_guardar;
    }
}

