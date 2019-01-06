namespace VNCViewerLauncher
{
    partial class Acceso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceso));
            this.pb_icono = new System.Windows.Forms.PictureBox();
            this.pb_cancelar = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancelar)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_icono
            // 
            this.pb_icono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_icono.Image = global::VNCViewerLauncher.Properties.Resources._1445996309_tick_green;
            this.pb_icono.Location = new System.Drawing.Point(245, 45);
            this.pb_icono.Name = "pb_icono";
            this.pb_icono.Size = new System.Drawing.Size(30, 30);
            this.pb_icono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_icono.TabIndex = 2;
            this.pb_icono.TabStop = false;
            this.pb_icono.Click += new System.EventHandler(this.pb_icono_Click);
            // 
            // pb_cancelar
            // 
            this.pb_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_cancelar.Image = global::VNCViewerLauncher.Properties.Resources._1445996357_close_red;
            this.pb_cancelar.Location = new System.Drawing.Point(209, 45);
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Size = new System.Drawing.Size(30, 30);
            this.pb_cancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_cancelar.TabIndex = 3;
            this.pb_cancelar.TabStop = false;
            this.pb_cancelar.Click += new System.EventHandler(this.pb_cancelar_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contraseña:";
            // 
            // txt_pass
            // 
            this.txt_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pass.Location = new System.Drawing.Point(98, 14);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(178, 22);
            this.txt_pass.TabIndex = 8;
            // 
            // Acceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(293, 88);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.pb_cancelar);
            this.Controls.Add(this.pb_icono);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Acceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso";
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancelar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_icono;
        private System.Windows.Forms.PictureBox pb_cancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_pass;
    }
}