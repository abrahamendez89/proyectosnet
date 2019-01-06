namespace EstadoResultados
{
    partial class ServicioEstadoResultados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicioEstadoResultados));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_diaSemana = new System.Windows.Forms.TextBox();
            this.txt_horaDia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_logActividades = new System.Windows.Forms.ListBox();
            this.txt_estatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pb_progreso = new System.Windows.Forms.ProgressBar();
            this.btn_ejecutarManual = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Día de la semana:";
            // 
            // txt_diaSemana
            // 
            this.txt_diaSemana.Location = new System.Drawing.Point(321, 8);
            this.txt_diaSemana.Name = "txt_diaSemana";
            this.txt_diaSemana.ReadOnly = true;
            this.txt_diaSemana.Size = new System.Drawing.Size(166, 20);
            this.txt_diaSemana.TabIndex = 1;
            // 
            // txt_horaDia
            // 
            this.txt_horaDia.Location = new System.Drawing.Point(613, 8);
            this.txt_horaDia.Name = "txt_horaDia";
            this.txt_horaDia.ReadOnly = true;
            this.txt_horaDia.Size = new System.Drawing.Size(152, 20);
            this.txt_horaDia.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hora ejecución(24H):";
            // 
            // lb_logActividades
            // 
            this.lb_logActividades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_logActividades.FormattingEnabled = true;
            this.lb_logActividades.Location = new System.Drawing.Point(15, 58);
            this.lb_logActividades.Name = "lb_logActividades";
            this.lb_logActividades.Size = new System.Drawing.Size(897, 160);
            this.lb_logActividades.TabIndex = 4;
            // 
            // txt_estatus
            // 
            this.txt_estatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_estatus.Location = new System.Drawing.Point(63, 252);
            this.txt_estatus.Name = "txt_estatus";
            this.txt_estatus.ReadOnly = true;
            this.txt_estatus.Size = new System.Drawing.Size(166, 20);
            this.txt_estatus.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Estatus:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Progreso:";
            // 
            // pb_progreso
            // 
            this.pb_progreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_progreso.Location = new System.Drawing.Point(72, 226);
            this.pb_progreso.Name = "pb_progreso";
            this.pb_progreso.Size = new System.Drawing.Size(838, 12);
            this.pb_progreso.TabIndex = 11;
            // 
            // btn_ejecutarManual
            // 
            this.btn_ejecutarManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ejecutarManual.Location = new System.Drawing.Point(800, 29);
            this.btn_ejecutarManual.Name = "btn_ejecutarManual";
            this.btn_ejecutarManual.Size = new System.Drawing.Size(112, 23);
            this.btn_ejecutarManual.TabIndex = 12;
            this.btn_ejecutarManual.Text = "Ejecutar proceso";
            this.btn_ejecutarManual.UseVisualStyleBackColor = true;
            this.btn_ejecutarManual.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Fecha y  hora Programadas:";
            // 
            // ServicioEstadoResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 284);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_ejecutarManual);
            this.Controls.Add(this.pb_progreso);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_estatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_logActividades);
            this.Controls.Add(this.txt_horaDia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_diaSemana);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServicioEstadoResultados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicio de estado de resultados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServicioEstadoResultados_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_diaSemana;
        private System.Windows.Forms.TextBox txt_horaDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_logActividades;
        private System.Windows.Forms.TextBox txt_estatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar pb_progreso;
        private System.Windows.Forms.Button btn_ejecutarManual;
        private System.Windows.Forms.Label label5;
    }
}