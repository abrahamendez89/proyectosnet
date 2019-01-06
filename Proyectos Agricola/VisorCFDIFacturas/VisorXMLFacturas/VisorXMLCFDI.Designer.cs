namespace VisorXMLFacturas
{
    partial class VisorXMLCFDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisorXMLCFDI));
            this.btn_cargarXML = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_xmlArchivo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_cargarXML
            // 
            this.btn_cargarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cargarXML.Location = new System.Drawing.Point(640, 12);
            this.btn_cargarXML.Name = "btn_cargarXML";
            this.btn_cargarXML.Size = new System.Drawing.Size(75, 23);
            this.btn_cargarXML.TabIndex = 0;
            this.btn_cargarXML.Text = "Cargar";
            this.btn_cargarXML.UseVisualStyleBackColor = true;
            this.btn_cargarXML.Click += new System.EventHandler(this.btn_cargarXML_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archivo CFDI:";
            // 
            // txt_xmlArchivo
            // 
            this.txt_xmlArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_xmlArchivo.Location = new System.Drawing.Point(91, 14);
            this.txt_xmlArchivo.Name = "txt_xmlArchivo";
            this.txt_xmlArchivo.ReadOnly = true;
            this.txt_xmlArchivo.Size = new System.Drawing.Size(543, 20);
            this.txt_xmlArchivo.TabIndex = 2;
            // 
            // VisorXMLCFDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 53);
            this.Controls.Add(this.txt_xmlArchivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cargarXML);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VisorXMLCFDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Examinar XML CFDI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cargarXML;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_xmlArchivo;
    }
}

