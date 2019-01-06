namespace OneDrive
{
    partial class frm_drive
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_SessionID = new System.Windows.Forms.Label();
            this.lbl_userID = new System.Windows.Forms.Label();
            this.lbl_disponible = new System.Windows.Forms.Label();
            this.lbl_espacio = new System.Windows.Forms.Label();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_nombreCarpeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_userID);
            this.groupBox1.Controls.Add(this.lbl_disponible);
            this.groupBox1.Controls.Add(this.lbl_espacio);
            this.groupBox1.Controls.Add(this.lbl_usuario);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "One Drive STATUS";
            // 
            // lbl_SessionID
            // 
            this.lbl_SessionID.AutoSize = true;
            this.lbl_SessionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SessionID.Location = new System.Drawing.Point(311, 248);
            this.lbl_SessionID.Name = "lbl_SessionID";
            this.lbl_SessionID.Size = new System.Drawing.Size(14, 20);
            this.lbl_SessionID.TabIndex = 4;
            this.lbl_SessionID.Text = "-";
            // 
            // lbl_userID
            // 
            this.lbl_userID.AutoSize = true;
            this.lbl_userID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_userID.Location = new System.Drawing.Point(7, 105);
            this.lbl_userID.Name = "lbl_userID";
            this.lbl_userID.Size = new System.Drawing.Size(81, 20);
            this.lbl_userID.TabIndex = 3;
            this.lbl_userID.Text = "lbl_userID";
            // 
            // lbl_disponible
            // 
            this.lbl_disponible.AutoSize = true;
            this.lbl_disponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_disponible.Location = new System.Drawing.Point(6, 79);
            this.lbl_disponible.Name = "lbl_disponible";
            this.lbl_disponible.Size = new System.Drawing.Size(104, 20);
            this.lbl_disponible.TabIndex = 2;
            this.lbl_disponible.Text = "lbl_disponible";
            // 
            // lbl_espacio
            // 
            this.lbl_espacio.AutoSize = true;
            this.lbl_espacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_espacio.Location = new System.Drawing.Point(6, 53);
            this.lbl_espacio.Name = "lbl_espacio";
            this.lbl_espacio.Size = new System.Drawing.Size(88, 20);
            this.lbl_espacio.TabIndex = 1;
            this.lbl_espacio.Text = "lbl_espacio";
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usuario.Location = new System.Drawing.Point(6, 27);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(85, 20);
            this.lbl_usuario.TabIndex = 0;
            this.lbl_usuario.Text = "lbl_usuario";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Subir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_nombreCarpeta
            // 
            this.txt_nombreCarpeta.Location = new System.Drawing.Point(315, 225);
            this.txt_nombreCarpeta.Name = "txt_nombreCarpeta";
            this.txt_nombreCarpeta.Size = new System.Drawing.Size(143, 20);
            this.txt_nombreCarpeta.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre carpeta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "id:";
            // 
            // frm_drive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_SessionID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nombreCarpeta);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_drive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_drive";
            this.Load += new System.EventHandler(this.frm_drive_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.Label lbl_disponible;
        private System.Windows.Forms.Label lbl_espacio;
        private System.Windows.Forms.Label lbl_userID;
        private System.Windows.Forms.Label lbl_SessionID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_nombreCarpeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}