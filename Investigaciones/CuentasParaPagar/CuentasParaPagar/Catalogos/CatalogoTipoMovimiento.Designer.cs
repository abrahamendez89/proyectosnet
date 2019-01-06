namespace CuentasParaPagar.Catalogos
{
    partial class CatalogoTipoMovimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoTipoMovimiento));
            this.cmb_TiposMovimientos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chb_EstaActivo = new System.Windows.Forms.CheckBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.chb_entrada = new System.Windows.Forms.CheckBox();
            this.chb_salida = new System.Windows.Forms.CheckBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.chb_esDividido = new System.Windows.Forms.CheckBox();
            this.chb_aplicaInmediato = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmb_TiposMovimientos
            // 
            this.cmb_TiposMovimientos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TiposMovimientos.FormattingEnabled = true;
            this.cmb_TiposMovimientos.Location = new System.Drawing.Point(106, 12);
            this.cmb_TiposMovimientos.Name = "cmb_TiposMovimientos";
            this.cmb_TiposMovimientos.Size = new System.Drawing.Size(207, 21);
            this.cmb_TiposMovimientos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo Movimiento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo:";
            // 
            // chb_EstaActivo
            // 
            this.chb_EstaActivo.AutoSize = true;
            this.chb_EstaActivo.Location = new System.Drawing.Point(18, 159);
            this.chb_EstaActivo.Name = "chb_EstaActivo";
            this.chb_EstaActivo.Size = new System.Drawing.Size(79, 17);
            this.chb_EstaActivo.TabIndex = 4;
            this.chb_EstaActivo.Text = "Está activo";
            this.chb_EstaActivo.UseVisualStyleBackColor = true;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(106, 55);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(207, 20);
            this.txt_nombre.TabIndex = 5;
            // 
            // chb_entrada
            // 
            this.chb_entrada.AutoSize = true;
            this.chb_entrada.Location = new System.Drawing.Point(106, 91);
            this.chb_entrada.Name = "chb_entrada";
            this.chb_entrada.Size = new System.Drawing.Size(76, 17);
            this.chb_entrada.TabIndex = 6;
            this.chb_entrada.Text = "Entrada(E)";
            this.chb_entrada.UseVisualStyleBackColor = true;
            this.chb_entrada.CheckedChanged += new System.EventHandler(this.chb_entrada_CheckedChanged);
            // 
            // chb_salida
            // 
            this.chb_salida.AutoSize = true;
            this.chb_salida.Location = new System.Drawing.Point(188, 91);
            this.chb_salida.Name = "chb_salida";
            this.chb_salida.Size = new System.Drawing.Size(68, 17);
            this.chb_salida.TabIndex = 7;
            this.chb_salida.Text = "Salida(S)";
            this.chb_salida.UseVisualStyleBackColor = true;
            this.chb_salida.CheckedChanged += new System.EventHandler(this.chb_salida_CheckedChanged);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(141, 196);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 8;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // chb_esDividido
            // 
            this.chb_esDividido.AutoSize = true;
            this.chb_esDividido.Location = new System.Drawing.Point(18, 113);
            this.chb_esDividido.Name = "chb_esDividido";
            this.chb_esDividido.Size = new System.Drawing.Size(343, 17);
            this.chb_esDividido.TabIndex = 9;
            this.chb_esDividido.Text = "El importe total del movimiento es dividido entre varios movimientos.";
            this.chb_esDividido.UseVisualStyleBackColor = true;
            // 
            // chb_aplicaInmediato
            // 
            this.chb_aplicaInmediato.AutoSize = true;
            this.chb_aplicaInmediato.Location = new System.Drawing.Point(18, 136);
            this.chb_aplicaInmediato.Name = "chb_aplicaInmediato";
            this.chb_aplicaInmediato.Size = new System.Drawing.Size(338, 17);
            this.chb_aplicaInmediato.TabIndex = 10;
            this.chb_aplicaInmediato.Text = "El movimiento se aplica al instante independientemente de su tipo.";
            this.chb_aplicaInmediato.UseVisualStyleBackColor = true;
            // 
            // CatalogoTipoMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 253);
            this.Controls.Add(this.chb_aplicaInmediato);
            this.Controls.Add(this.chb_esDividido);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.chb_salida);
            this.Controls.Add(this.chb_entrada);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.chb_EstaActivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_TiposMovimientos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CatalogoTipoMovimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de tipos de Movimiento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_TiposMovimientos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chb_EstaActivo;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.CheckBox chb_entrada;
        private System.Windows.Forms.CheckBox chb_salida;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.CheckBox chb_esDividido;
        private System.Windows.Forms.CheckBox chb_aplicaInmediato;
    }
}