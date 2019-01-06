namespace CompresorImagenes
{
    partial class ConvertidorArchivos
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
            this.txt_ancho = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_resultados = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_seleccionar = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_test = new System.Windows.Forms.PictureBox();
            this.btn_ejecutar = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_tamA = new System.Windows.Forms.Label();
            this.lbl_tamDe = new System.Windows.Forms.Label();
            this.pb_hacia = new System.Windows.Forms.PictureBox();
            this.pb_de = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_directorio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cargarImagenes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btn_seleccionar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_test)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ejecutar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_hacia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_de)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ancho
            // 
            this.txt_ancho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_ancho.Location = new System.Drawing.Point(126, 69);
            this.txt_ancho.Name = "txt_ancho";
            this.txt_ancho.Size = new System.Drawing.Size(92, 20);
            this.txt_ancho.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 90;
            this.label7.Text = "Ancho máximo(pixeles):";
            // 
            // lb_resultados
            // 
            this.lb_resultados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_resultados.FormattingEnabled = true;
            this.lb_resultados.HorizontalScrollbar = true;
            this.lb_resultados.Location = new System.Drawing.Point(364, 121);
            this.lb_resultados.Name = "lb_resultados";
            this.lb_resultados.ScrollAlwaysVisible = true;
            this.lb_resultados.Size = new System.Drawing.Size(484, 134);
            this.lb_resultados.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(361, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 88;
            this.label10.Text = "Resultados:";
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_seleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_seleccionar.Image = global::CompresorImagenes.Properties.Resources._1416552323_folder_search;
            this.btn_seleccionar.Location = new System.Drawing.Point(819, 6);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(29, 30);
            this.btn_seleccionar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_seleccionar.TabIndex = 105;
            this.btn_seleccionar.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_seleccionar, "Seleccionar carpeta de imagenes.");
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::CompresorImagenes.Properties.Resources._1416525629_next;
            this.pictureBox4.Location = new System.Drawing.Point(165, 35);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 103;
            this.pictureBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox4, "Ejecutar conversión con los parametros asignados.");
            // 
            // btn_test
            // 
            this.btn_test.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_test.Image = global::CompresorImagenes.Properties.Resources._1416525374_testbed_protocol;
            this.btn_test.Location = new System.Drawing.Point(3, 3);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(40, 40);
            this.btn_test.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_test.TabIndex = 100;
            this.btn_test.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_test, "Realizar test de conversión con la primer imagen.");
            // 
            // btn_ejecutar
            // 
            this.btn_ejecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ejecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ejecutar.Image = global::CompresorImagenes.Properties.Resources._1416520336_gtk_execute;
            this.btn_ejecutar.Location = new System.Drawing.Point(430, 76);
            this.btn_ejecutar.Name = "btn_ejecutar";
            this.btn_ejecutar.Size = new System.Drawing.Size(40, 40);
            this.btn_ejecutar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_ejecutar.TabIndex = 22;
            this.btn_ejecutar.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_ejecutar, "Ejecutar conversión con los parametros asignados.");
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.lbl_tamA);
            this.panel2.Controls.Add(this.lbl_tamDe);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pb_hacia);
            this.panel2.Controls.Add(this.pb_de);
            this.panel2.Controls.Add(this.btn_test);
            this.panel2.Location = new System.Drawing.Point(15, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(343, 135);
            this.panel2.TabIndex = 101;
            // 
            // lbl_tamA
            // 
            this.lbl_tamA.AutoSize = true;
            this.lbl_tamA.ForeColor = System.Drawing.Color.White;
            this.lbl_tamA.Location = new System.Drawing.Point(211, 116);
            this.lbl_tamA.Name = "lbl_tamA";
            this.lbl_tamA.Size = new System.Drawing.Size(0, 13);
            this.lbl_tamA.TabIndex = 104;
            // 
            // lbl_tamDe
            // 
            this.lbl_tamDe.AutoSize = true;
            this.lbl_tamDe.ForeColor = System.Drawing.Color.White;
            this.lbl_tamDe.Location = new System.Drawing.Point(69, 116);
            this.lbl_tamDe.Name = "lbl_tamDe";
            this.lbl_tamDe.Size = new System.Drawing.Size(0, 13);
            this.lbl_tamDe.TabIndex = 103;
            // 
            // pb_hacia
            // 
            this.pb_hacia.BackColor = System.Drawing.Color.LightGray;
            this.pb_hacia.Location = new System.Drawing.Point(206, 10);
            this.pb_hacia.Name = "pb_hacia";
            this.pb_hacia.Size = new System.Drawing.Size(100, 101);
            this.pb_hacia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_hacia.TabIndex = 102;
            this.pb_hacia.TabStop = false;
            // 
            // pb_de
            // 
            this.pb_de.BackColor = System.Drawing.Color.LightGray;
            this.pb_de.Location = new System.Drawing.Point(64, 10);
            this.pb_de.Name = "pb_de";
            this.pb_de.Size = new System.Drawing.Size(100, 101);
            this.pb_de.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_de.TabIndex = 101;
            this.pb_de.TabStop = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 102;
            this.label12.Text = "Vista previa:";
            // 
            // txt_directorio
            // 
            this.txt_directorio.BackColor = System.Drawing.Color.White;
            this.txt_directorio.Location = new System.Drawing.Point(129, 9);
            this.txt_directorio.Name = "txt_directorio";
            this.txt_directorio.ReadOnly = true;
            this.txt_directorio.Size = new System.Drawing.Size(684, 20);
            this.txt_directorio.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Carpeta de imagenes:";
            // 
            // btn_cargarImagenes
            // 
            this.btn_cargarImagenes.Location = new System.Drawing.Point(126, 35);
            this.btn_cargarImagenes.Name = "btn_cargarImagenes";
            this.btn_cargarImagenes.Size = new System.Drawing.Size(155, 23);
            this.btn_cargarImagenes.TabIndex = 106;
            this.btn_cargarImagenes.Text = "Cargar imagenes";
            this.btn_cargarImagenes.UseVisualStyleBackColor = true;
            this.btn_cargarImagenes.Click += new System.EventHandler(this.btn_cargarImagenes_Click);
            // 
            // ConvertidorArchivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(855, 261);
            this.Controls.Add(this.btn_cargarImagenes);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.txt_directorio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_ejecutar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_resultados);
            this.Controls.Add(this.txt_ancho);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConvertidorArchivos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compresor de imagenes";
            ((System.ComponentModel.ISupportInitialize)(this.btn_seleccionar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_test)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ejecutar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_hacia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_de)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ancho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lb_resultados;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox btn_ejecutar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox btn_test;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pb_hacia;
        private System.Windows.Forms.PictureBox pb_de;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_tamA;
        private System.Windows.Forms.Label lbl_tamDe;
        private System.Windows.Forms.TextBox txt_directorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btn_seleccionar;
        private System.Windows.Forms.Button btn_cargarImagenes;
    }
}

