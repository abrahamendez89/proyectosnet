namespace GeneradorCodigoSQL
{
    partial class CodigoGenerado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodigoGenerado));
            this.txt_codigo = new System.Windows.Forms.RichTextBox();
            this.btn_portapapeles = new System.Windows.Forms.Button();
            this.btn_ejecutarEnServidor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_codigo
            // 
            this.txt_codigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_codigo.Location = new System.Drawing.Point(2, 2);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(771, 381);
            this.txt_codigo.TabIndex = 0;
            this.txt_codigo.Text = "";
            // 
            // btn_portapapeles
            // 
            this.btn_portapapeles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_portapapeles.Location = new System.Drawing.Point(579, 389);
            this.btn_portapapeles.Name = "btn_portapapeles";
            this.btn_portapapeles.Size = new System.Drawing.Size(194, 23);
            this.btn_portapapeles.TabIndex = 1;
            this.btn_portapapeles.Text = "Copiar al portapapeles";
            this.btn_portapapeles.UseVisualStyleBackColor = true;
            this.btn_portapapeles.Click += new System.EventHandler(this.btn_portapapeles_Click);
            // 
            // btn_ejecutarEnServidor
            // 
            this.btn_ejecutarEnServidor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ejecutarEnServidor.Location = new System.Drawing.Point(390, 389);
            this.btn_ejecutarEnServidor.Name = "btn_ejecutarEnServidor";
            this.btn_ejecutarEnServidor.Size = new System.Drawing.Size(183, 23);
            this.btn_ejecutarEnServidor.TabIndex = 2;
            this.btn_ejecutarEnServidor.Text = "Ejecutar código en el servidor";
            this.btn_ejecutarEnServidor.UseVisualStyleBackColor = true;
            this.btn_ejecutarEnServidor.Click += new System.EventHandler(this.btn_ejecutarEnServidor_Click);
            // 
            // CodigoGenerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 419);
            this.Controls.Add(this.btn_ejecutarEnServidor);
            this.Controls.Add(this.btn_portapapeles);
            this.Controls.Add(this.txt_codigo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CodigoGenerado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodigoGenerado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt_codigo;
        private System.Windows.Forms.Button btn_portapapeles;
        private System.Windows.Forms.Button btn_ejecutarEnServidor;
    }
}