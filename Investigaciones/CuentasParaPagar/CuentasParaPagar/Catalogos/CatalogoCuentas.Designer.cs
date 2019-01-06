namespace CuentasParaPagar.Catalogos
{
    partial class CatalogoCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoCuentas));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_diaCorte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_diasParaPago = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_imagen = new System.Windows.Forms.PictureBox();
            this.txt_PorcentajeInteres = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chb_Activo = new System.Windows.Forms.CheckBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_cuentas = new System.Windows.Forms.ComboBox();
            this.txt_saldo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chb_esDeAhorro = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre cuenta:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(99, 65);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(156, 20);
            this.txt_nombre.TabIndex = 1;
            // 
            // txt_diaCorte
            // 
            this.txt_diaCorte.Location = new System.Drawing.Point(189, 91);
            this.txt_diaCorte.Name = "txt_diaCorte";
            this.txt_diaCorte.Size = new System.Drawing.Size(66, 20);
            this.txt_diaCorte.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dia corte:";
            // 
            // txt_diasParaPago
            // 
            this.txt_diasParaPago.Location = new System.Drawing.Point(189, 117);
            this.txt_diasParaPago.Name = "txt_diasParaPago";
            this.txt_diasParaPago.Size = new System.Drawing.Size(66, 20);
            this.txt_diasParaPago.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dias para pagar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Imagen:";
            // 
            // pb_imagen
            // 
            this.pb_imagen.BackColor = System.Drawing.Color.White;
            this.pb_imagen.Location = new System.Drawing.Point(287, 85);
            this.pb_imagen.Name = "pb_imagen";
            this.pb_imagen.Size = new System.Drawing.Size(172, 86);
            this.pb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_imagen.TabIndex = 7;
            this.pb_imagen.TabStop = false;
            this.pb_imagen.Click += new System.EventHandler(this.pb_imagen_Click);
            // 
            // txt_PorcentajeInteres
            // 
            this.txt_PorcentajeInteres.Location = new System.Drawing.Point(189, 143);
            this.txt_PorcentajeInteres.Name = "txt_PorcentajeInteres";
            this.txt_PorcentajeInteres.Size = new System.Drawing.Size(66, 20);
            this.txt_PorcentajeInteres.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Porcentaje Interes Mensual";
            // 
            // chb_Activo
            // 
            this.chb_Activo.AutoSize = true;
            this.chb_Activo.Location = new System.Drawing.Point(13, 234);
            this.chb_Activo.Name = "chb_Activo";
            this.chb_Activo.Size = new System.Drawing.Size(79, 17);
            this.chb_Activo.TabIndex = 10;
            this.chb_Activo.Text = "Está activo";
            this.chb_Activo.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(203, 251);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 11;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cuenta:";
            // 
            // cmb_cuentas
            // 
            this.cmb_cuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cuentas.FormattingEnabled = true;
            this.cmb_cuentas.Location = new System.Drawing.Point(63, 10);
            this.cmb_cuentas.Name = "cmb_cuentas";
            this.cmb_cuentas.Size = new System.Drawing.Size(396, 21);
            this.cmb_cuentas.TabIndex = 13;
            this.cmb_cuentas.SelectedIndexChanged += new System.EventHandler(this.cmb_cuentas_SelectedIndexChanged);
            // 
            // txt_saldo
            // 
            this.txt_saldo.Location = new System.Drawing.Point(144, 172);
            this.txt_saldo.Name = "txt_saldo";
            this.txt_saldo.Size = new System.Drawing.Size(111, 20);
            this.txt_saldo.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Saldo";
            // 
            // chb_esDeAhorro
            // 
            this.chb_esDeAhorro.AutoSize = true;
            this.chb_esDeAhorro.Location = new System.Drawing.Point(12, 200);
            this.chb_esDeAhorro.Name = "chb_esDeAhorro";
            this.chb_esDeAhorro.Size = new System.Drawing.Size(87, 17);
            this.chb_esDeAhorro.TabIndex = 16;
            this.chb_esDeAhorro.Text = "Es de Ahorro";
            this.chb_esDeAhorro.UseVisualStyleBackColor = true;
            this.chb_esDeAhorro.CheckedChanged += new System.EventHandler(this.chb_esDeAhorro_CheckedChanged);
            // 
            // CatalogoCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 295);
            this.Controls.Add(this.chb_esDeAhorro);
            this.Controls.Add(this.txt_saldo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_cuentas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.chb_Activo);
            this.Controls.Add(this.txt_PorcentajeInteres);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pb_imagen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_diasParaPago);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_diaCorte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CatalogoCuentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo  de Cuentas";
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_diaCorte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_diasParaPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pb_imagen;
        private System.Windows.Forms.TextBox txt_PorcentajeInteres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chb_Activo;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_cuentas;
        private System.Windows.Forms.TextBox txt_saldo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chb_esDeAhorro;
    }
}