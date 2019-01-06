namespace CreadorLicencias
{
    partial class Creador
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
            this.txt_rutaLicencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_generarLicencia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_mac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombreEquipo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_usuarioWindows = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_versionWindows = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_idTarjetaMadre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_idLicencia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_FechaPago = new System.Windows.Forms.DateTimePicker();
            this.dtp_fecCaducidad = new System.Windows.Forms.DateTimePicker();
            this.dtp_FecPrimeraVez = new System.Windows.Forms.DateTimePicker();
            this.txt_meses = new System.Windows.Forms.TextBox();
            this.btn_sumarMeses = new System.Windows.Forms.Button();
            this.btn_actualizarFechaPAgo = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_rutaLicencia
            // 
            this.txt_rutaLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_rutaLicencia.Location = new System.Drawing.Point(103, 10);
            this.txt_rutaLicencia.Name = "txt_rutaLicencia";
            this.txt_rutaLicencia.ReadOnly = true;
            this.txt_rutaLicencia.Size = new System.Drawing.Size(374, 20);
            this.txt_rutaLicencia.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archivo KEY:";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscar.Location = new System.Drawing.Point(483, 8);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_generarLicencia
            // 
            this.btn_generarLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generarLicencia.Location = new System.Drawing.Point(423, 328);
            this.btn_generarLicencia.Name = "btn_generarLicencia";
            this.btn_generarLicencia.Size = new System.Drawing.Size(135, 23);
            this.btn_generarLicencia.TabIndex = 3;
            this.btn_generarLicencia.Text = "Generar Licencia";
            this.btn_generarLicencia.UseVisualStyleBackColor = true;
            this.btn_generarLicencia.Click += new System.EventHandler(this.btn_generarLicencia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "MAC:";
            // 
            // txt_mac
            // 
            this.txt_mac.Location = new System.Drawing.Point(108, 56);
            this.txt_mac.Name = "txt_mac";
            this.txt_mac.ReadOnly = true;
            this.txt_mac.Size = new System.Drawing.Size(237, 20);
            this.txt_mac.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombre Equipo:";
            // 
            // txt_nombreEquipo
            // 
            this.txt_nombreEquipo.Location = new System.Drawing.Point(108, 82);
            this.txt_nombreEquipo.Name = "txt_nombreEquipo";
            this.txt_nombreEquipo.ReadOnly = true;
            this.txt_nombreEquipo.Size = new System.Drawing.Size(237, 20);
            this.txt_nombreEquipo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Usuario Windows:";
            // 
            // txt_usuarioWindows
            // 
            this.txt_usuarioWindows.Location = new System.Drawing.Point(108, 108);
            this.txt_usuarioWindows.Name = "txt_usuarioWindows";
            this.txt_usuarioWindows.ReadOnly = true;
            this.txt_usuarioWindows.Size = new System.Drawing.Size(237, 20);
            this.txt_usuarioWindows.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "VersionWindows:";
            // 
            // txt_versionWindows
            // 
            this.txt_versionWindows.Location = new System.Drawing.Point(108, 134);
            this.txt_versionWindows.Name = "txt_versionWindows";
            this.txt_versionWindows.ReadOnly = true;
            this.txt_versionWindows.Size = new System.Drawing.Size(237, 20);
            this.txt_versionWindows.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "ID Tarjeta Madre:";
            // 
            // txt_idTarjetaMadre
            // 
            this.txt_idTarjetaMadre.Location = new System.Drawing.Point(108, 160);
            this.txt_idTarjetaMadre.Name = "txt_idTarjetaMadre";
            this.txt_idTarjetaMadre.ReadOnly = true;
            this.txt_idTarjetaMadre.Size = new System.Drawing.Size(237, 20);
            this.txt_idTarjetaMadre.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Fec Primera Vez:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Fec caducidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "ID Lic:";
            // 
            // txt_idLicencia
            // 
            this.txt_idLicencia.Location = new System.Drawing.Point(108, 238);
            this.txt_idLicencia.Name = "txt_idLicencia";
            this.txt_idLicencia.ReadOnly = true;
            this.txt_idLicencia.Size = new System.Drawing.Size(237, 20);
            this.txt_idLicencia.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Fecha Pago:";
            // 
            // dtp_FechaPago
            // 
            this.dtp_FechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FechaPago.Location = new System.Drawing.Point(108, 265);
            this.dtp_FechaPago.Name = "dtp_FechaPago";
            this.dtp_FechaPago.Size = new System.Drawing.Size(237, 20);
            this.dtp_FechaPago.TabIndex = 22;
            // 
            // dtp_fecCaducidad
            // 
            this.dtp_fecCaducidad.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecCaducidad.Location = new System.Drawing.Point(108, 212);
            this.dtp_fecCaducidad.Name = "dtp_fecCaducidad";
            this.dtp_fecCaducidad.Size = new System.Drawing.Size(237, 20);
            this.dtp_fecCaducidad.TabIndex = 23;
            // 
            // dtp_FecPrimeraVez
            // 
            this.dtp_FecPrimeraVez.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_FecPrimeraVez.Location = new System.Drawing.Point(108, 186);
            this.dtp_FecPrimeraVez.Name = "dtp_FecPrimeraVez";
            this.dtp_FecPrimeraVez.Size = new System.Drawing.Size(237, 20);
            this.dtp_FecPrimeraVez.TabIndex = 24;
            // 
            // txt_meses
            // 
            this.txt_meses.Location = new System.Drawing.Point(404, 212);
            this.txt_meses.Name = "txt_meses";
            this.txt_meses.Size = new System.Drawing.Size(90, 20);
            this.txt_meses.TabIndex = 25;
            this.txt_meses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_sumarMeses
            // 
            this.btn_sumarMeses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sumarMeses.Location = new System.Drawing.Point(404, 132);
            this.btn_sumarMeses.Name = "btn_sumarMeses";
            this.btn_sumarMeses.Size = new System.Drawing.Size(90, 70);
            this.btn_sumarMeses.TabIndex = 26;
            this.btn_sumarMeses.Text = "Sumar Meses a la Fecha de Caducidad";
            this.btn_sumarMeses.UseVisualStyleBackColor = true;
            this.btn_sumarMeses.Click += new System.EventHandler(this.btn_sumarMeses_Click);
            // 
            // btn_actualizarFechaPAgo
            // 
            this.btn_actualizarFechaPAgo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_actualizarFechaPAgo.Location = new System.Drawing.Point(404, 64);
            this.btn_actualizarFechaPAgo.Name = "btn_actualizarFechaPAgo";
            this.btn_actualizarFechaPAgo.Size = new System.Drawing.Size(90, 38);
            this.btn_actualizarFechaPAgo.TabIndex = 27;
            this.btn_actualizarFechaPAgo.Text = "Actualizar Fecha de pago";
            this.btn_actualizarFechaPAgo.UseVisualStyleBackColor = true;
            this.btn_actualizarFechaPAgo.Click += new System.EventHandler(this.btn_actualizarFechaPAgo_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(387, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "1) Actualizar fecha pago";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(387, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "2) Sumar Meses";
            // 
            // Creador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 363);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_actualizarFechaPAgo);
            this.Controls.Add(this.btn_sumarMeses);
            this.Controls.Add(this.txt_meses);
            this.Controls.Add(this.dtp_FecPrimeraVez);
            this.Controls.Add(this.dtp_fecCaducidad);
            this.Controls.Add(this.dtp_FechaPago);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_idLicencia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_idTarjetaMadre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_versionWindows);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_usuarioWindows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nombreEquipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_mac);
            this.Controls.Add(this.btn_generarLicencia);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_rutaLicencia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Creador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creador Licencias KaraTube";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_rutaLicencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_generarLicencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_mac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nombreEquipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_usuarioWindows;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_versionWindows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_idTarjetaMadre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_idLicencia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_FechaPago;
        private System.Windows.Forms.DateTimePicker dtp_fecCaducidad;
        private System.Windows.Forms.DateTimePicker dtp_FecPrimeraVez;
        private System.Windows.Forms.TextBox txt_meses;
        private System.Windows.Forms.Button btn_sumarMeses;
        private System.Windows.Forms.Button btn_actualizarFechaPAgo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

