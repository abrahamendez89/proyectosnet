namespace VNCViewerLauncher
{
    partial class Dialogo
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
            this.pb_iconoAceptar = new System.Windows.Forms.PictureBox();
            this.pb_cancelar = new System.Windows.Forms.PictureBox();
            this.txt_dialogo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_iconoAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancelar)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_iconoAceptar
            // 
            this.pb_iconoAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_iconoAceptar.Image = global::VNCViewerLauncher.Properties.Resources._1445996309_tick_green;
            this.pb_iconoAceptar.Location = new System.Drawing.Point(285, 75);
            this.pb_iconoAceptar.Name = "pb_iconoAceptar";
            this.pb_iconoAceptar.Size = new System.Drawing.Size(30, 30);
            this.pb_iconoAceptar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_iconoAceptar.TabIndex = 2;
            this.pb_iconoAceptar.TabStop = false;
            this.pb_iconoAceptar.Click += new System.EventHandler(this.pb_icono_Click);
            // 
            // pb_cancelar
            // 
            this.pb_cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_cancelar.Image = global::VNCViewerLauncher.Properties.Resources._1445996357_close_red;
            this.pb_cancelar.Location = new System.Drawing.Point(249, 75);
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Size = new System.Drawing.Size(30, 30);
            this.pb_cancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_cancelar.TabIndex = 3;
            this.pb_cancelar.TabStop = false;
            this.pb_cancelar.Click += new System.EventHandler(this.pb_cancelar_Click);
            // 
            // txt_dialogo
            // 
            this.txt_dialogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dialogo.BackColor = System.Drawing.Color.White;
            this.txt_dialogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dialogo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_dialogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_dialogo.Location = new System.Drawing.Point(22, 20);
            this.txt_dialogo.Multiline = true;
            this.txt_dialogo.Name = "txt_dialogo";
            this.txt_dialogo.ReadOnly = true;
            this.txt_dialogo.Size = new System.Drawing.Size(516, 39);
            this.txt_dialogo.TabIndex = 0;
            this.txt_dialogo.Text = "adsasdasdasd";
            this.txt_dialogo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_dialogo.TextChanged += new System.EventHandler(this.txt_dialogo_TextChanged);
            // 
            // Dialogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 117);
            this.Controls.Add(this.pb_cancelar);
            this.Controls.Add(this.pb_iconoAceptar);
            this.Controls.Add(this.txt_dialogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dialogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titulo";
            this.Load += new System.EventHandler(this.Dialogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_iconoAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancelar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_iconoAceptar;
        private System.Windows.Forms.PictureBox pb_cancelar;
        private System.Windows.Forms.TextBox txt_dialogo;
    }
}