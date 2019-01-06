namespace OneDrive
{
    partial class Test
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_contra = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_rutaArchivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Carpeta = new System.Windows.Forms.TextBox();
            this.btn_subir = new System.Windows.Forms.Button();
            this.pb_progreso = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(90, 15);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(262, 20);
            this.txt_usuario.TabIndex = 2;
            // 
            // txt_contra
            // 
            this.txt_contra.Location = new System.Drawing.Point(90, 41);
            this.txt_contra.Name = "txt_contra";
            this.txt_contra.PasswordChar = '*';
            this.txt_contra.Size = new System.Drawing.Size(262, 20);
            this.txt_contra.TabIndex = 3;
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(277, 117);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 4;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_rutaArchivo
            // 
            this.txt_rutaArchivo.BackColor = System.Drawing.Color.White;
            this.txt_rutaArchivo.Location = new System.Drawing.Point(90, 119);
            this.txt_rutaArchivo.Name = "txt_rutaArchivo";
            this.txt_rutaArchivo.ReadOnly = true;
            this.txt_rutaArchivo.Size = new System.Drawing.Size(181, 20);
            this.txt_rutaArchivo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Archivo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Carpeta:";
            // 
            // txt_Carpeta
            // 
            this.txt_Carpeta.Location = new System.Drawing.Point(90, 145);
            this.txt_Carpeta.Name = "txt_Carpeta";
            this.txt_Carpeta.Size = new System.Drawing.Size(181, 20);
            this.txt_Carpeta.TabIndex = 7;
            // 
            // btn_subir
            // 
            this.btn_subir.Location = new System.Drawing.Point(159, 205);
            this.btn_subir.Name = "btn_subir";
            this.btn_subir.Size = new System.Drawing.Size(75, 23);
            this.btn_subir.TabIndex = 9;
            this.btn_subir.Text = "Subir";
            this.btn_subir.UseVisualStyleBackColor = true;
            this.btn_subir.Click += new System.EventHandler(this.btn_subir_Click);
            // 
            // pb_progreso
            // 
            this.pb_progreso.Location = new System.Drawing.Point(18, 232);
            this.pb_progreso.Name = "pb_progreso";
            this.pb_progreso.Size = new System.Drawing.Size(368, 10);
            this.pb_progreso.TabIndex = 10;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 251);
            this.Controls.Add(this.pb_progreso);
            this.Controls.Add(this.btn_subir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Carpeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_rutaArchivo);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_contra);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.TextBox txt_contra;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_rutaArchivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Carpeta;
        private System.Windows.Forms.Button btn_subir;
        private System.Windows.Forms.ProgressBar pb_progreso;
    }
}