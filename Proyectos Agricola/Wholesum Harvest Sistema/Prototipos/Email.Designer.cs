namespace Prototipos
{
    partial class Email
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_enviarA = new System.Windows.Forms.TextBox();
            this.txt_Asunto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_contenido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombreMostrar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enviar a:";
            // 
            // txt_enviarA
            // 
            this.txt_enviarA.Location = new System.Drawing.Point(174, 61);
            this.txt_enviarA.Name = "txt_enviarA";
            this.txt_enviarA.Size = new System.Drawing.Size(243, 20);
            this.txt_enviarA.TabIndex = 2;
            // 
            // txt_Asunto
            // 
            this.txt_Asunto.Location = new System.Drawing.Point(174, 98);
            this.txt_Asunto.Name = "txt_Asunto";
            this.txt_Asunto.Size = new System.Drawing.Size(243, 20);
            this.txt_Asunto.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Asunto:";
            // 
            // txt_contenido
            // 
            this.txt_contenido.Location = new System.Drawing.Point(174, 149);
            this.txt_contenido.Multiline = true;
            this.txt_contenido.Name = "txt_contenido";
            this.txt_contenido.Size = new System.Drawing.Size(243, 96);
            this.txt_contenido.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contenido";
            // 
            // txt_nombreMostrar
            // 
            this.txt_nombreMostrar.Location = new System.Drawing.Point(210, 25);
            this.txt_nombreMostrar.Name = "txt_nombreMostrar";
            this.txt_nombreMostrar.Size = new System.Drawing.Size(207, 20);
            this.txt_nombreMostrar.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre a mostrar:";
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 367);
            this.Controls.Add(this.txt_nombreMostrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_contenido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Asunto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_enviarA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Email";
            this.Text = "Email";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_enviarA;
        private System.Windows.Forms.TextBox txt_Asunto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_contenido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nombreMostrar;
        private System.Windows.Forms.Label label4;
    }
}