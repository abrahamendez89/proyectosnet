namespace SendKeys
{
    partial class SendKeysToApps
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboWindows = new System.Windows.Forms.ComboBox();
            this.rbManual = new System.Windows.Forms.RadioButton();
            this.rbAuto = new System.Windows.Forms.RadioButton();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDlg = new System.Windows.Forms.SaveFileDialog();
            this.lnkRefresh = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_tiempoRetardo = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lb_acciones2 = new System.Windows.Forms.ListBox();
            this.lb_comandosTeclas = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txt_cmd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_cantidadCaracteres = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_probando = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventana a atacar:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(35, 41);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(480, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(32, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Teclas y funciones:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(288, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Secuencia de acciones:";
            // 
            // cboWindows
            // 
            this.cboWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWindows.FormattingEnabled = true;
            this.cboWindows.Location = new System.Drawing.Point(35, 41);
            this.cboWindows.Name = "cboWindows";
            this.cboWindows.Size = new System.Drawing.Size(480, 21);
            this.cboWindows.TabIndex = 13;
            this.cboWindows.SelectedIndexChanged += new System.EventHandler(this.OptionSelection);
            // 
            // rbManual
            // 
            this.rbManual.AutoSize = true;
            this.rbManual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.rbManual.Location = new System.Drawing.Point(312, 18);
            this.rbManual.Name = "rbManual";
            this.rbManual.Size = new System.Drawing.Size(72, 18);
            this.rbManual.TabIndex = 14;
            this.rbManual.Text = "Manual";
            this.rbManual.UseVisualStyleBackColor = true;
            this.rbManual.Click += new System.EventHandler(this.OptionSelection);
            // 
            // rbAuto
            // 
            this.rbAuto.AutoSize = true;
            this.rbAuto.Checked = true;
            this.rbAuto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.rbAuto.Location = new System.Drawing.Point(209, 18);
            this.rbAuto.Name = "rbAuto";
            this.rbAuto.Size = new System.Drawing.Size(55, 18);
            this.rbAuto.TabIndex = 15;
            this.rbAuto.TabStop = true;
            this.rbAuto.Text = "Auto";
            this.rbAuto.UseVisualStyleBackColor = true;
            this.rbAuto.Click += new System.EventHandler(this.OptionSelection);
            // 
            // lnkAdd
            // 
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lnkAdd.Location = new System.Drawing.Point(198, 172);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(60, 14);
            this.lnkAdd.TabIndex = 20;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Agregar";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // openFileDlg
            // 
            this.openFileDlg.Filter = "SendKeys Files (*.sky)|*.sky";
            // 
            // saveFileDlg
            // 
            this.saveFileDlg.DefaultExt = "sky";
            this.saveFileDlg.Filter = "SendKeys Files (*.sky)|*.sky";
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.AutoSize = true;
            this.lnkRefresh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.lnkRefresh.Location = new System.Drawing.Point(457, 18);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(73, 14);
            this.lnkRefresh.TabIndex = 22;
            this.lnkRefresh.TabStop = true;
            this.lnkRefresh.Text = "Actualizar";
            this.lnkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefresh_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 27);
            this.button1.TabIndex = 23;
            this.button1.Text = "Iniciar ataque";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_tiempoRetardo
            // 
            this.txt_tiempoRetardo.Location = new System.Drawing.Point(35, 263);
            this.txt_tiempoRetardo.Name = "txt_tiempoRetardo";
            this.txt_tiempoRetardo.Size = new System.Drawing.Size(157, 20);
            this.txt_tiempoRetardo.TabIndex = 25;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.linkLabel1.Location = new System.Drawing.Point(198, 269);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(60, 14);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Agregar";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lb_acciones2
            // 
            this.lb_acciones2.FormattingEnabled = true;
            this.lb_acciones2.Location = new System.Drawing.Point(291, 121);
            this.lb_acciones2.Name = "lb_acciones2";
            this.lb_acciones2.Size = new System.Drawing.Size(224, 225);
            this.lb_acciones2.TabIndex = 27;
            // 
            // lb_comandosTeclas
            // 
            this.lb_comandosTeclas.FormattingEnabled = true;
            this.lb_comandosTeclas.Location = new System.Drawing.Point(35, 121);
            this.lb_comandosTeclas.Name = "lb_comandosTeclas";
            this.lb_comandosTeclas.Size = new System.Drawing.Size(157, 108);
            this.lb_comandosTeclas.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(35, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 14);
            this.label4.TabIndex = 29;
            this.label4.Text = "Tiempo (ms):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(35, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "Teclas y funciones:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(35, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 14);
            this.label6.TabIndex = 33;
            this.label6.Text = "Comando (cmd):";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.linkLabel2.Location = new System.Drawing.Point(198, 328);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(60, 14);
            this.linkLabel2.TabIndex = 32;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Agregar";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // txt_cmd
            // 
            this.txt_cmd.Location = new System.Drawing.Point(35, 322);
            this.txt_cmd.Name = "txt_cmd";
            this.txt_cmd.Size = new System.Drawing.Size(157, 20);
            this.txt_cmd.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(191, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 14);
            this.label7.TabIndex = 35;
            this.label7.Text = "Cantidad de caracteres:";
            // 
            // txt_cantidadCaracteres
            // 
            this.txt_cantidadCaracteres.Location = new System.Drawing.Point(361, 74);
            this.txt_cantidadCaracteres.Name = "txt_cantidadCaracteres";
            this.txt_cantidadCaracteres.Size = new System.Drawing.Size(154, 20);
            this.txt_cantidadCaracteres.TabIndex = 34;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(291, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 36;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(206, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 14);
            this.label8.TabIndex = 37;
            this.label8.Text = "Probando:";
            // 
            // txt_probando
            // 
            this.txt_probando.Location = new System.Drawing.Point(291, 384);
            this.txt_probando.Name = "txt_probando";
            this.txt_probando.ReadOnly = true;
            this.txt_probando.Size = new System.Drawing.Size(224, 20);
            this.txt_probando.TabIndex = 38;
            // 
            // SendKeysToApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 409);
            this.Controls.Add(this.txt_probando);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_cantidadCaracteres);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.txt_cmd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_comandosTeclas);
            this.Controls.Add(this.lb_acciones2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txt_tiempoRetardo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lnkRefresh);
            this.Controls.Add(this.lnkAdd);
            this.Controls.Add(this.rbAuto);
            this.Controls.Add(this.rbManual);
            this.Controls.Add(this.cboWindows);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SendKeysToApps";
            this.Text = "Ataque";
            this.Load += new System.EventHandler(this.SendKeysToApps_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWindows;
        private System.Windows.Forms.RadioButton rbManual;
        private System.Windows.Forms.RadioButton rbAuto;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDlg;
        private System.Windows.Forms.LinkLabel lnkRefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_tiempoRetardo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox lb_acciones2;
        private System.Windows.Forms.ListBox lb_comandosTeclas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox txt_cmd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_cantidadCaracteres;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_probando;
    }
}

