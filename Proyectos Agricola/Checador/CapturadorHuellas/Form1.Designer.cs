namespace CapturadorHuellas
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
            this.btn_guardarHuella = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_bd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_temporada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nomina = new System.Windows.Forms.TextBox();
            this.pb_huella = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_claveBusqueda = new System.Windows.Forms.TextBox();
            this.txt_nombreEmpleado = new System.Windows.Forms.TextBox();
            this.btn_iniciarCaptura = new System.Windows.Forms.Button();
            this.btn_probar = new System.Windows.Forms.Button();
            this.txt_mensaje = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnl_busqueda = new System.Windows.Forms.Panel();
            this.lb_empleados = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_huella)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnl_busqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_guardarHuella
            // 
            this.btn_guardarHuella.Enabled = false;
            this.btn_guardarHuella.Location = new System.Drawing.Point(474, 289);
            this.btn_guardarHuella.Name = "btn_guardarHuella";
            this.btn_guardarHuella.Size = new System.Drawing.Size(185, 39);
            this.btn_guardarHuella.TabIndex = 0;
            this.btn_guardarHuella.Text = "Guardar";
            this.btn_guardarHuella.UseVisualStyleBackColor = true;
            this.btn_guardarHuella.Click += new System.EventHandler(this.btn_guardarHuella_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "BD:";
            // 
            // txt_bd
            // 
            this.txt_bd.BackColor = System.Drawing.SystemColors.Window;
            this.txt_bd.Location = new System.Drawing.Point(362, 12);
            this.txt_bd.Name = "txt_bd";
            this.txt_bd.Size = new System.Drawing.Size(124, 20);
            this.txt_bd.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Temporada:";
            // 
            // txt_temporada
            // 
            this.txt_temporada.BackColor = System.Drawing.SystemColors.Window;
            this.txt_temporada.Location = new System.Drawing.Point(230, 12);
            this.txt_temporada.Name = "txt_temporada";
            this.txt_temporada.Size = new System.Drawing.Size(93, 20);
            this.txt_temporada.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nómina:";
            // 
            // txt_nomina
            // 
            this.txt_nomina.BackColor = System.Drawing.SystemColors.Window;
            this.txt_nomina.Location = new System.Drawing.Point(61, 12);
            this.txt_nomina.Name = "txt_nomina";
            this.txt_nomina.Size = new System.Drawing.Size(93, 20);
            this.txt_nomina.TabIndex = 12;
            // 
            // pb_huella
            // 
            this.pb_huella.BackColor = System.Drawing.Color.White;
            this.pb_huella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_huella.Location = new System.Drawing.Point(245, 73);
            this.pb_huella.Name = "pb_huella";
            this.pb_huella.Size = new System.Drawing.Size(153, 173);
            this.pb_huella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_huella.TabIndex = 20;
            this.pb_huella.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Cve Empleado:";
            // 
            // txt_claveBusqueda
            // 
            this.txt_claveBusqueda.Location = new System.Drawing.Point(97, 47);
            this.txt_claveBusqueda.Name = "txt_claveBusqueda";
            this.txt_claveBusqueda.Size = new System.Drawing.Size(107, 20);
            this.txt_claveBusqueda.TabIndex = 23;
            this.txt_claveBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_claveBusqueda_KeyDown);
            // 
            // txt_nombreEmpleado
            // 
            this.txt_nombreEmpleado.BackColor = System.Drawing.Color.White;
            this.txt_nombreEmpleado.Location = new System.Drawing.Point(210, 47);
            this.txt_nombreEmpleado.Name = "txt_nombreEmpleado";
            this.txt_nombreEmpleado.ReadOnly = true;
            this.txt_nombreEmpleado.Size = new System.Drawing.Size(448, 20);
            this.txt_nombreEmpleado.TabIndex = 24;
            // 
            // btn_iniciarCaptura
            // 
            this.btn_iniciarCaptura.Enabled = false;
            this.btn_iniciarCaptura.Location = new System.Drawing.Point(12, 289);
            this.btn_iniciarCaptura.Name = "btn_iniciarCaptura";
            this.btn_iniciarCaptura.Size = new System.Drawing.Size(185, 39);
            this.btn_iniciarCaptura.TabIndex = 25;
            this.btn_iniciarCaptura.Text = "Capturar";
            this.btn_iniciarCaptura.UseVisualStyleBackColor = true;
            this.btn_iniciarCaptura.Click += new System.EventHandler(this.btn_iniciarCaptura_Click);
            // 
            // btn_probar
            // 
            this.btn_probar.Enabled = false;
            this.btn_probar.Location = new System.Drawing.Point(203, 289);
            this.btn_probar.Name = "btn_probar";
            this.btn_probar.Size = new System.Drawing.Size(185, 39);
            this.btn_probar.TabIndex = 26;
            this.btn_probar.Text = "Probar";
            this.btn_probar.UseVisualStyleBackColor = true;
            this.btn_probar.Click += new System.EventHandler(this.btn_probar_Click);
            // 
            // txt_mensaje
            // 
            this.txt_mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mensaje.Location = new System.Drawing.Point(12, 252);
            this.txt_mensaje.Name = "txt_mensaje";
            this.txt_mensaje.ReadOnly = true;
            this.txt_mensaje.Size = new System.Drawing.Size(646, 31);
            this.txt_mensaje.TabIndex = 27;
            this.txt_mensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(-3, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 22);
            this.panel1.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "F1 = Ayuda";
            // 
            // pnl_busqueda
            // 
            this.pnl_busqueda.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnl_busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_busqueda.Controls.Add(this.lb_empleados);
            this.pnl_busqueda.Location = new System.Drawing.Point(97, 68);
            this.pnl_busqueda.Name = "pnl_busqueda";
            this.pnl_busqueda.Size = new System.Drawing.Size(540, 185);
            this.pnl_busqueda.TabIndex = 29;
            this.pnl_busqueda.Visible = false;
            // 
            // lb_empleados
            // 
            this.lb_empleados.FormattingEnabled = true;
            this.lb_empleados.Location = new System.Drawing.Point(6, 3);
            this.lb_empleados.Name = "lb_empleados";
            this.lb_empleados.Size = new System.Drawing.Size(529, 173);
            this.lb_empleados.TabIndex = 0;
            this.lb_empleados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lb_empleados_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 364);
            this.Controls.Add(this.pnl_busqueda);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_mensaje);
            this.Controls.Add(this.btn_probar);
            this.Controls.Add(this.btn_iniciarCaptura);
            this.Controls.Add(this.txt_nombreEmpleado);
            this.Controls.Add(this.txt_claveBusqueda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pb_huella);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_bd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_temporada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nomina);
            this.Controls.Add(this.btn_guardarHuella);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar huella de empleado";
            ((System.ComponentModel.ISupportInitialize)(this.pb_huella)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_busqueda.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_guardarHuella;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_bd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_temporada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nomina;
        private System.Windows.Forms.PictureBox pb_huella;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_claveBusqueda;
        private System.Windows.Forms.TextBox txt_nombreEmpleado;
        private System.Windows.Forms.Button btn_iniciarCaptura;
        private System.Windows.Forms.Button btn_probar;
        private System.Windows.Forms.TextBox txt_mensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnl_busqueda;
        private System.Windows.Forms.ListBox lb_empleados;
    }
}

