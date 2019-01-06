namespace VNCViewerLauncher
{
    partial class AgregarGrupo
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
            this.txt_nombreGrupo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_iconoAceptar = new System.Windows.Forms.PictureBox();
            this.pb_cancelar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_iconoAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancelar)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nombreGrupo
            // 
            this.txt_nombreGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreGrupo.Location = new System.Drawing.Point(138, 20);
            this.txt_nombreGrupo.Name = "txt_nombreGrupo";
            this.txt_nombreGrupo.Size = new System.Drawing.Size(185, 22);
            this.txt_nombreGrupo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del grupo:";
            // 
            // pb_iconoAceptar
            // 
            this.pb_iconoAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_iconoAceptar.Image = global::VNCViewerLauncher.Properties.Resources._1445996309_tick_green;
            this.pb_iconoAceptar.Location = new System.Drawing.Point(379, 16);
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
            this.pb_cancelar.Location = new System.Drawing.Point(343, 16);
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Size = new System.Drawing.Size(30, 30);
            this.pb_cancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_cancelar.TabIndex = 3;
            this.pb_cancelar.TabStop = false;
            this.pb_cancelar.Click += new System.EventHandler(this.pb_cancelar_Click);
            // 
            // AgregarGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(432, 58);
            this.Controls.Add(this.pb_cancelar);
            this.Controls.Add(this.pb_iconoAceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nombreGrupo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Grupo";
            ((System.ComponentModel.ISupportInitialize)(this.pb_iconoAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancelar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nombreGrupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_iconoAceptar;
        private System.Windows.Forms.PictureBox pb_cancelar;
    }
}