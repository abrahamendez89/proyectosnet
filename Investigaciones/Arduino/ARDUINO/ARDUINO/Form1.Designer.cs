namespace ARDUINO
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_EncenderApagarLed = new System.Windows.Forms.Button();
            this.tb_Intensidad = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdb_LED = new System.Windows.Forms.RadioButton();
            this.rdb_MOTOR = new System.Windows.Forms.RadioButton();
            this.rdb_TODOS = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_CambiarColorLed = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btn_NotaMusical = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.txt_notas = new System.Windows.Forms.TextBox();
            this.btn_enviarNotas = new System.Windows.Forms.Button();
            this.btn_Cancion1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Cancion2 = new System.Windows.Forms.Button();
            this.txt_portName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Horizontal = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Vertical = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Intensidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Horizontal)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Vertical)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            // 
            // btn_EncenderApagarLed
            // 
            this.btn_EncenderApagarLed.Location = new System.Drawing.Point(92, 56);
            this.btn_EncenderApagarLed.Name = "btn_EncenderApagarLed";
            this.btn_EncenderApagarLed.Size = new System.Drawing.Size(75, 23);
            this.btn_EncenderApagarLed.TabIndex = 0;
            this.btn_EncenderApagarLed.Text = "Encender";
            this.btn_EncenderApagarLed.UseVisualStyleBackColor = true;
            this.btn_EncenderApagarLed.Click += new System.EventHandler(this.btn_EncenderApagarLed_Click);
            // 
            // tb_Intensidad
            // 
            this.tb_Intensidad.Location = new System.Drawing.Point(231, 92);
            this.tb_Intensidad.Maximum = 255;
            this.tb_Intensidad.Name = "tb_Intensidad";
            this.tb_Intensidad.Size = new System.Drawing.Size(194, 45);
            this.tb_Intensidad.TabIndex = 2;
            this.tb_Intensidad.ValueChanged += new System.EventHandler(this.tb_Intensidad_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Led azul:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Motor:";
            // 
            // rdb_LED
            // 
            this.rdb_LED.AutoSize = true;
            this.rdb_LED.Location = new System.Drawing.Point(239, 59);
            this.rdb_LED.Name = "rdb_LED";
            this.rdb_LED.Size = new System.Drawing.Size(46, 17);
            this.rdb_LED.TabIndex = 7;
            this.rdb_LED.TabStop = true;
            this.rdb_LED.Text = "LED";
            this.rdb_LED.UseVisualStyleBackColor = true;
            this.rdb_LED.CheckedChanged += new System.EventHandler(this.rdb_LED_CheckedChanged);
            // 
            // rdb_MOTOR
            // 
            this.rdb_MOTOR.AutoSize = true;
            this.rdb_MOTOR.Location = new System.Drawing.Point(291, 59);
            this.rdb_MOTOR.Name = "rdb_MOTOR";
            this.rdb_MOTOR.Size = new System.Drawing.Size(65, 17);
            this.rdb_MOTOR.TabIndex = 8;
            this.rdb_MOTOR.TabStop = true;
            this.rdb_MOTOR.Text = "MOTOR";
            this.rdb_MOTOR.UseVisualStyleBackColor = true;
            this.rdb_MOTOR.CheckedChanged += new System.EventHandler(this.rdb_MOTOR_CheckedChanged);
            // 
            // rdb_TODOS
            // 
            this.rdb_TODOS.AutoSize = true;
            this.rdb_TODOS.Location = new System.Drawing.Point(362, 59);
            this.rdb_TODOS.Name = "rdb_TODOS";
            this.rdb_TODOS.Size = new System.Drawing.Size(63, 17);
            this.rdb_TODOS.TabIndex = 9;
            this.rdb_TODOS.TabStop = true;
            this.rdb_TODOS.Text = "TODOS";
            this.rdb_TODOS.UseVisualStyleBackColor = true;
            this.rdb_TODOS.CheckedChanged += new System.EventHandler(this.rdb_TODOS_CheckedChanged);
            // 
            // btn_CambiarColorLed
            // 
            this.btn_CambiarColorLed.Location = new System.Drawing.Point(92, 92);
            this.btn_CambiarColorLed.Name = "btn_CambiarColorLed";
            this.btn_CambiarColorLed.Size = new System.Drawing.Size(86, 53);
            this.btn_CambiarColorLed.TabIndex = 10;
            this.btn_CambiarColorLed.Text = "Color";
            this.btn_CambiarColorLed.UseVisualStyleBackColor = true;
            this.btn_CambiarColorLed.Click += new System.EventHandler(this.btn_CambiarColorLed_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(11, 169);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 85);
            this.button4.TabIndex = 11;
            this.button4.Tag = "0";
            this.button4.Text = "c";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_NotaMusical_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(52, 169);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 85);
            this.button5.TabIndex = 12;
            this.button5.Tag = "1";
            this.button5.Text = "d";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btn_NotaMusical_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(93, 169);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(35, 85);
            this.button6.TabIndex = 13;
            this.button6.Tag = "2";
            this.button6.Text = "e";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btn_NotaMusical_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(135, 169);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(35, 85);
            this.button7.TabIndex = 14;
            this.button7.Tag = "3";
            this.button7.Text = "f";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btn_NotaMusical_Click);
            // 
            // btn_NotaMusical
            // 
            this.btn_NotaMusical.Location = new System.Drawing.Point(179, 169);
            this.btn_NotaMusical.Name = "btn_NotaMusical";
            this.btn_NotaMusical.Size = new System.Drawing.Size(35, 85);
            this.btn_NotaMusical.TabIndex = 15;
            this.btn_NotaMusical.Tag = "4";
            this.btn_NotaMusical.Text = "g";
            this.btn_NotaMusical.UseVisualStyleBackColor = true;
            this.btn_NotaMusical.Click += new System.EventHandler(this.btn_NotaMusical_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(223, 169);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(35, 85);
            this.button9.TabIndex = 16;
            this.button9.Tag = "5";
            this.button9.Text = "a";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btn_NotaMusical_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(265, 169);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(35, 85);
            this.button10.TabIndex = 17;
            this.button10.Tag = "6";
            this.button10.Text = "b";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btn_NotaMusical_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(305, 169);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(35, 85);
            this.button11.TabIndex = 18;
            this.button11.Tag = "7";
            this.button11.Text = "C";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.btn_NotaMusical_Click);
            // 
            // txt_notas
            // 
            this.txt_notas.Location = new System.Drawing.Point(11, 260);
            this.txt_notas.Name = "txt_notas";
            this.txt_notas.Size = new System.Drawing.Size(247, 20);
            this.txt_notas.TabIndex = 19;
            // 
            // btn_enviarNotas
            // 
            this.btn_enviarNotas.Location = new System.Drawing.Point(265, 258);
            this.btn_enviarNotas.Name = "btn_enviarNotas";
            this.btn_enviarNotas.Size = new System.Drawing.Size(75, 23);
            this.btn_enviarNotas.TabIndex = 20;
            this.btn_enviarNotas.Text = "Enviar";
            this.btn_enviarNotas.UseVisualStyleBackColor = true;
            this.btn_enviarNotas.Click += new System.EventHandler(this.btn_enviarNotas_Click);
            // 
            // btn_Cancion1
            // 
            this.btn_Cancion1.Location = new System.Drawing.Point(346, 169);
            this.btn_Cancion1.Name = "btn_Cancion1";
            this.btn_Cancion1.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancion1.TabIndex = 21;
            this.btn_Cancion1.Text = "Canción 1";
            this.btn_Cancion1.UseVisualStyleBackColor = true;
            this.btn_Cancion1.Click += new System.EventHandler(this.btn_Cancion1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Led multicolor:";
            // 
            // btn_Cancion2
            // 
            this.btn_Cancion2.Location = new System.Drawing.Point(346, 198);
            this.btn_Cancion2.Name = "btn_Cancion2";
            this.btn_Cancion2.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancion2.TabIndex = 23;
            this.btn_Cancion2.Text = "Canción 2";
            this.btn_Cancion2.UseVisualStyleBackColor = true;
            this.btn_Cancion2.Click += new System.EventHandler(this.btn_Cancion2_Click);
            // 
            // txt_portName
            // 
            this.txt_portName.Location = new System.Drawing.Point(59, 12);
            this.txt_portName.Name = "txt_portName";
            this.txt_portName.Size = new System.Drawing.Size(100, 20);
            this.txt_portName.TabIndex = 24;
            this.txt_portName.Text = "COM3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Puerto:";
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.Location = new System.Drawing.Point(165, 10);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_Aceptar.TabIndex = 26;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = true;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 52);
            this.panel1.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Brazo robótico:";
            // 
            // tb_Horizontal
            // 
            this.tb_Horizontal.Location = new System.Drawing.Point(75, 72);
            this.tb_Horizontal.Maximum = 180;
            this.tb_Horizontal.Name = "tb_Horizontal";
            this.tb_Horizontal.Size = new System.Drawing.Size(156, 45);
            this.tb_Horizontal.TabIndex = 29;
            this.tb_Horizontal.ValueChanged += new System.EventHandler(this.tb_Horizontal_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tb_Vertical);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tb_Horizontal);
            this.panel2.Location = new System.Drawing.Point(444, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 292);
            this.panel2.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Horizontal:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Vertical:";
            // 
            // tb_Vertical
            // 
            this.tb_Vertical.Location = new System.Drawing.Point(127, 137);
            this.tb_Vertical.Maximum = 180;
            this.tb_Vertical.Name = "tb_Vertical";
            this.tb_Vertical.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_Vertical.Size = new System.Drawing.Size(45, 132);
            this.tb_Vertical.TabIndex = 31;
            this.tb_Vertical.ValueChanged += new System.EventHandler(this.tb_Vertical_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 365);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_portName);
            this.Controls.Add(this.btn_Cancion2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Cancion1);
            this.Controls.Add(this.btn_enviarNotas);
            this.Controls.Add(this.txt_notas);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.btn_NotaMusical);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_CambiarColorLed);
            this.Controls.Add(this.rdb_TODOS);
            this.Controls.Add(this.rdb_MOTOR);
            this.Controls.Add(this.rdb_LED);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Intensidad);
            this.Controls.Add(this.btn_EncenderApagarLed);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tb_Intensidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Horizontal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_Vertical)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_EncenderApagarLed;
        private System.Windows.Forms.TrackBar tb_Intensidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdb_LED;
        private System.Windows.Forms.RadioButton rdb_MOTOR;
        private System.Windows.Forms.RadioButton rdb_TODOS;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_CambiarColorLed;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btn_NotaMusical;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox txt_notas;
        private System.Windows.Forms.Button btn_enviarNotas;
        private System.Windows.Forms.Button btn_Cancion1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Cancion2;
        private System.Windows.Forms.TextBox txt_portName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Aceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tb_Horizontal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar tb_Vertical;
    }
}

