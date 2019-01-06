namespace VNCViewerLauncher
{
    partial class AgregarEquipo
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
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_icono = new System.Windows.Forms.PictureBox();
            this.pb_cancelar = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ruta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_passVNC = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancelar)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nombre
            // 
            this.txt_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.Location = new System.Drawing.Point(145, 20);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(178, 22);
            this.txt_nombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del equipo:";
            // 
            // pb_icono
            // 
            this.pb_icono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_icono.Image = global::VNCViewerLauncher.Properties.Resources._1445996309_tick_green;
            this.pb_icono.Location = new System.Drawing.Point(293, 170);
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
            this.pb_cancelar.Location = new System.Drawing.Point(257, 170);
            this.pb_cancelar.Name = "pb_cancelar";
            this.pb_cancelar.Size = new System.Drawing.Size(30, 30);
            this.pb_cancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_cancelar.TabIndex = 3;
            this.pb_cancelar.TabStop = false;
            this.pb_cancelar.Click += new System.EventHandler(this.pb_cancelar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dirección:";
            // 
            // txt_ruta
            // 
            this.txt_ruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ruta.Location = new System.Drawing.Point(145, 48);
            this.txt_ruta.Name = "txt_ruta";
            this.txt_ruta.Size = new System.Drawing.Size(178, 22);
            this.txt_ruta.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Descripción:";
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_descripcion.Location = new System.Drawing.Point(145, 105);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(178, 59);
            this.txt_descripcion.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contraseña VNC:";
            // 
            // txt_passVNC
            // 
            this.txt_passVNC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_passVNC.Location = new System.Drawing.Point(145, 76);
            this.txt_passVNC.Name = "txt_passVNC";
            this.txt_passVNC.PasswordChar = '*';
            this.txt_passVNC.Size = new System.Drawing.Size(178, 22);
            this.txt_passVNC.TabIndex = 8;
            // 
            // AgregarEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(345, 212);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_passVNC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_descripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ruta);
            this.Controls.Add(this.pb_cancelar);
            this.Controls.Add(this.pb_icono);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Equipo";
            ((System.ComponentModel.ISupportInitialize)(this.pb_icono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancelar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pb_icono;
        private System.Windows.Forms.PictureBox pb_cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ruta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_passVNC;
    }
}