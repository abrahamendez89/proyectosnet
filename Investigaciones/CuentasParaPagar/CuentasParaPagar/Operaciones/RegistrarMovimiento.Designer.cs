namespace CuentasParaPagar.Operaciones
{
    partial class RegistrarMovimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarMovimiento));
            this.cmb_cuentas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_importe = new System.Windows.Forms.TextBox();
            this.btn_registrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_tipoMovimiento = new System.Windows.Forms.ComboBox();
            this.pb_imagen = new System.Windows.Forms.PictureBox();
            this.chb_varios = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cadaDias = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.chb_cadaMes = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_detalleMovimiento = new System.Windows.Forms.TextBox();
            this.txt_saldoAlDia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_TiposdeMovimiento = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_CuentasAAfectar = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_cuentas
            // 
            this.cmb_cuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cuentas.FormattingEnabled = true;
            this.cmb_cuentas.Location = new System.Drawing.Point(68, 12);
            this.cmb_cuentas.Name = "cmb_cuentas";
            this.cmb_cuentas.Size = new System.Drawing.Size(396, 21);
            this.cmb_cuentas.TabIndex = 15;
            this.cmb_cuentas.SelectedIndexChanged += new System.EventHandler(this.cmb_cuentas_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Cuenta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Importe:";
            // 
            // txt_importe
            // 
            this.txt_importe.Location = new System.Drawing.Point(142, 48);
            this.txt_importe.Name = "txt_importe";
            this.txt_importe.Size = new System.Drawing.Size(122, 20);
            this.txt_importe.TabIndex = 17;
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(200, 329);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(75, 23);
            this.btn_registrar.TabIndex = 18;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tipo de movimiento:";
            // 
            // cmb_tipoMovimiento
            // 
            this.cmb_tipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipoMovimiento.DropDownWidth = 350;
            this.cmb_tipoMovimiento.FormattingEnabled = true;
            this.cmb_tipoMovimiento.Items.AddRange(new object[] {
            "Pago o depósito",
            "Compra o gasto"});
            this.cmb_tipoMovimiento.Location = new System.Drawing.Point(142, 76);
            this.cmb_tipoMovimiento.Name = "cmb_tipoMovimiento";
            this.cmb_tipoMovimiento.Size = new System.Drawing.Size(121, 21);
            this.cmb_tipoMovimiento.TabIndex = 20;
            this.cmb_tipoMovimiento.SelectedIndexChanged += new System.EventHandler(this.cmb_tipoMovimiento_SelectedIndexChanged);
            // 
            // pb_imagen
            // 
            this.pb_imagen.BackColor = System.Drawing.Color.White;
            this.pb_imagen.Location = new System.Drawing.Point(311, 48);
            this.pb_imagen.Name = "pb_imagen";
            this.pb_imagen.Size = new System.Drawing.Size(153, 62);
            this.pb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_imagen.TabIndex = 21;
            this.pb_imagen.TabStop = false;
            // 
            // chb_varios
            // 
            this.chb_varios.AutoSize = true;
            this.chb_varios.Location = new System.Drawing.Point(18, 16);
            this.chb_varios.Name = "chb_varios";
            this.chb_varios.Size = new System.Drawing.Size(139, 17);
            this.chb_varios.TabIndex = 22;
            this.chb_varios.Text = "Repetir este movimiento";
            this.chb_varios.UseVisualStyleBackColor = true;
            this.chb_varios.CheckedChanged += new System.EventHandler(this.chb_varios_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Número de movimientos:";
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(141, 43);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(63, 20);
            this.txt_cantidad.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Cada:";
            // 
            // txt_cadaDias
            // 
            this.txt_cadaDias.Location = new System.Drawing.Point(53, 87);
            this.txt_cadaDias.Name = "txt_cadaDias";
            this.txt_cadaDias.Size = new System.Drawing.Size(63, 20);
            this.txt_cadaDias.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "dias.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Fecha del movimiento:";
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha.Location = new System.Drawing.Point(142, 107);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(121, 20);
            this.dtp_fecha.TabIndex = 29;
            // 
            // chb_cadaMes
            // 
            this.chb_cadaMes.AutoSize = true;
            this.chb_cadaMes.Location = new System.Drawing.Point(53, 114);
            this.chb_cadaMes.Name = "chb_cadaMes";
            this.chb_cadaMes.Size = new System.Drawing.Size(72, 17);
            this.chb_cadaMes.TabIndex = 30;
            this.chb_cadaMes.Text = "cada mes";
            this.chb_cadaMes.UseVisualStyleBackColor = true;
            this.chb_cadaMes.CheckedChanged += new System.EventHandler(this.chb_cadaMes_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Detalle del movimiento:";
            // 
            // txt_detalleMovimiento
            // 
            this.txt_detalleMovimiento.Location = new System.Drawing.Point(142, 152);
            this.txt_detalleMovimiento.Name = "txt_detalleMovimiento";
            this.txt_detalleMovimiento.Size = new System.Drawing.Size(322, 20);
            this.txt_detalleMovimiento.TabIndex = 32;
            // 
            // txt_saldoAlDia
            // 
            this.txt_saldoAlDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_saldoAlDia.BackColor = System.Drawing.Color.White;
            this.txt_saldoAlDia.Location = new System.Drawing.Point(364, 122);
            this.txt_saldoAlDia.Name = "txt_saldoAlDia";
            this.txt_saldoAlDia.ReadOnly = true;
            this.txt_saldoAlDia.Size = new System.Drawing.Size(100, 20);
            this.txt_saldoAlDia.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Saldo al día:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_cadaMes);
            this.groupBox1.Controls.Add(this.chb_varios);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_cantidad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_cadaDias);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(26, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 143);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frecuencia y número de movimientos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cmb_TiposdeMovimiento);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmb_CuentasAAfectar);
            this.groupBox2.Location = new System.Drawing.Point(255, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 143);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Afectar otra cuenta";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Tipo de movimiento a usar:";
            // 
            // cmb_TiposdeMovimiento
            // 
            this.cmb_TiposdeMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TiposdeMovimiento.DropDownWidth = 350;
            this.cmb_TiposdeMovimiento.FormattingEnabled = true;
            this.cmb_TiposdeMovimiento.Location = new System.Drawing.Point(6, 82);
            this.cmb_TiposdeMovimiento.Name = "cmb_TiposdeMovimiento";
            this.cmb_TiposdeMovimiento.Size = new System.Drawing.Size(196, 21);
            this.cmb_TiposdeMovimiento.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Cuenta a afectar:";
            // 
            // cmb_CuentasAAfectar
            // 
            this.cmb_CuentasAAfectar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CuentasAAfectar.DropDownWidth = 350;
            this.cmb_CuentasAAfectar.FormattingEnabled = true;
            this.cmb_CuentasAAfectar.Location = new System.Drawing.Point(7, 37);
            this.cmb_CuentasAAfectar.Name = "cmb_CuentasAAfectar";
            this.cmb_CuentasAAfectar.Size = new System.Drawing.Size(196, 21);
            this.cmb_CuentasAAfectar.TabIndex = 0;
            // 
            // RegistrarMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 375);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_saldoAlDia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_detalleMovimiento);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pb_imagen);
            this.Controls.Add(this.cmb_tipoMovimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_registrar);
            this.Controls.Add(this.txt_importe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_cuentas);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistrarMovimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Movimiento";
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_cuentas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_importe;
        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_tipoMovimiento;
        private System.Windows.Forms.PictureBox pb_imagen;
        private System.Windows.Forms.CheckBox chb_varios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cadaDias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
        private System.Windows.Forms.CheckBox chb_cadaMes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_detalleMovimiento;
        private System.Windows.Forms.TextBox txt_saldoAlDia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_CuentasAAfectar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_TiposdeMovimiento;
    }
}