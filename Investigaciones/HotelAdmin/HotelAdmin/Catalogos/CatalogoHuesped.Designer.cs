namespace HotelAdmin.Catalogos
{
    partial class CatalogoHuesped
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
            this.txt_buscadorHuesped = new Herramientas.ORM.Controles.txt_buscador();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // txt_buscadorHuesped
            // 
            this.txt_buscadorHuesped.AutoSize = true;
            this.txt_buscadorHuesped.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_buscadorHuesped.Location = new System.Drawing.Point(108, 12);
            this.txt_buscadorHuesped.Name = "txt_buscadorHuesped";
            this.txt_buscadorHuesped.PermiteMultipleSeleccion = false;
            this.txt_buscadorHuesped.Size = new System.Drawing.Size(148, 32);
            this.txt_buscadorHuesped.TabIndex = 1;
            this.txt_buscadorHuesped.Tipo = null;
            this.txt_buscadorHuesped.resultadosBusqueda += new Herramientas.ORM.Controles.txt_buscador.ResultadosBusqueda(this.txt_buscadorHuesped_resultadosBusqueda);
            // 
            // CatalogoHuesped
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 260);
            this.Controls.Add(this.txt_buscadorHuesped);
            this.Controls.Add(this.label1);
            this.Name = "CatalogoHuesped";
            this.Text = "CatalogoHuesped";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Herramientas.ORM.Controles.txt_buscador txt_buscadorHuesped;
    }
}