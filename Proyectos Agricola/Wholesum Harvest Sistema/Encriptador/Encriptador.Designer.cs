namespace Encriptador
{
    partial class Encriptador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encriptador));
            this.txt_original = new System.Windows.Forms.TextBox();
            this.btn_encriptar = new System.Windows.Forms.Button();
            this.cmb_tipoCifrado = new System.Windows.Forms.ComboBox();
            this.txt_encriptado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_original
            // 
            this.txt_original.Location = new System.Drawing.Point(85, 12);
            this.txt_original.Name = "txt_original";
            this.txt_original.Size = new System.Drawing.Size(306, 20);
            this.txt_original.TabIndex = 0;
            // 
            // btn_encriptar
            // 
            this.btn_encriptar.Location = new System.Drawing.Point(316, 38);
            this.btn_encriptar.Name = "btn_encriptar";
            this.btn_encriptar.Size = new System.Drawing.Size(75, 23);
            this.btn_encriptar.TabIndex = 1;
            this.btn_encriptar.Text = "Encriptar";
            this.btn_encriptar.UseVisualStyleBackColor = true;
            this.btn_encriptar.Click += new System.EventHandler(this.btn_encriptar_Click);
            // 
            // cmb_tipoCifrado
            // 
            this.cmb_tipoCifrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipoCifrado.FormattingEnabled = true;
            this.cmb_tipoCifrado.Items.AddRange(new object[] {
            "AES",
            "MD5"});
            this.cmb_tipoCifrado.Location = new System.Drawing.Point(154, 40);
            this.cmb_tipoCifrado.Name = "cmb_tipoCifrado";
            this.cmb_tipoCifrado.Size = new System.Drawing.Size(121, 21);
            this.cmb_tipoCifrado.TabIndex = 2;
            this.cmb_tipoCifrado.Visible = false;
            this.cmb_tipoCifrado.SelectedIndexChanged += new System.EventHandler(this.cmb_tipoCifrado_SelectedIndexChanged);
            // 
            // txt_encriptado
            // 
            this.txt_encriptado.Location = new System.Drawing.Point(85, 70);
            this.txt_encriptado.Name = "txt_encriptado";
            this.txt_encriptado.Size = new System.Drawing.Size(306, 20);
            this.txt_encriptado.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo cifrado:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Texto original:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Texto cifrado:";
            // 
            // Encriptador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 105);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_encriptado);
            this.Controls.Add(this.cmb_tipoCifrado);
            this.Controls.Add(this.btn_encriptar);
            this.Controls.Add(this.txt_original);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Encriptador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encriptador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_original;
        private System.Windows.Forms.Button btn_encriptar;
        private System.Windows.Forms.ComboBox cmb_tipoCifrado;
        private System.Windows.Forms.TextBox txt_encriptado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

