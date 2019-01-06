namespace Herramientas.ORM.Controles
{
    partial class BuscadorCatalogo
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
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.dgr_InformacionObjetos = new System.Windows.Forms.DataGridView();
            this.chb_MasDeUno = new System.Windows.Forms.CheckBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.chb_mostrarDeshabilitados = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_InformacionObjetos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_busqueda.Location = new System.Drawing.Point(61, 6);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(499, 20);
            this.txt_busqueda.TabIndex = 1;
            this.txt_busqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_busqueda_KeyDown);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscar.Location = new System.Drawing.Point(566, 4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // dgr_InformacionObjetos
            // 
            this.dgr_InformacionObjetos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgr_InformacionObjetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_InformacionObjetos.Location = new System.Drawing.Point(15, 55);
            this.dgr_InformacionObjetos.Name = "dgr_InformacionObjetos";
            this.dgr_InformacionObjetos.Size = new System.Drawing.Size(626, 220);
            this.dgr_InformacionObjetos.TabIndex = 3;
            // 
            // chb_MasDeUno
            // 
            this.chb_MasDeUno.AutoSize = true;
            this.chb_MasDeUno.Location = new System.Drawing.Point(61, 32);
            this.chb_MasDeUno.Name = "chb_MasDeUno";
            this.chb_MasDeUno.Size = new System.Drawing.Size(128, 17);
            this.chb_MasDeUno.TabIndex = 4;
            this.chb_MasDeUno.Text = "Seleccionar más de 1";
            this.chb_MasDeUno.UseVisualStyleBackColor = true;
            this.chb_MasDeUno.CheckedChanged += new System.EventHandler(this.chb_MasDeUno_CheckedChanged);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_aceptar.Location = new System.Drawing.Point(566, 279);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 5;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // chb_mostrarDeshabilitados
            // 
            this.chb_mostrarDeshabilitados.AutoSize = true;
            this.chb_mostrarDeshabilitados.Location = new System.Drawing.Point(195, 32);
            this.chb_mostrarDeshabilitados.Name = "chb_mostrarDeshabilitados";
            this.chb_mostrarDeshabilitados.Size = new System.Drawing.Size(131, 17);
            this.chb_mostrarDeshabilitados.TabIndex = 6;
            this.chb_mostrarDeshabilitados.Text = "Mostrar deshabilitados";
            this.chb_mostrarDeshabilitados.UseVisualStyleBackColor = true;
            // 
            // BuscadorCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 305);
            this.Controls.Add(this.chb_mostrarDeshabilitados);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.chb_MasDeUno);
            this.Controls.Add(this.dgr_InformacionObjetos);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_busqueda);
            this.Controls.Add(this.label1);
            this.Name = "BuscadorCatalogo";
            this.Text = "Buscador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuscadorCatalogo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgr_InformacionObjetos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_busqueda;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.DataGridView dgr_InformacionObjetos;
        private System.Windows.Forms.CheckBox chb_MasDeUno;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.CheckBox chb_mostrarDeshabilitados;
    }
}