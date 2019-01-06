namespace probandoWS_SAT_VALIDACION
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_rfcEmisor = new System.Windows.Forms.TextBox();
            this.txt_rfcReceptor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_uuid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_estatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RFC Emisor:";
            // 
            // txt_rfcEmisor
            // 
            this.txt_rfcEmisor.Location = new System.Drawing.Point(96, 18);
            this.txt_rfcEmisor.Name = "txt_rfcEmisor";
            this.txt_rfcEmisor.Size = new System.Drawing.Size(100, 20);
            this.txt_rfcEmisor.TabIndex = 1;
            // 
            // txt_rfcReceptor
            // 
            this.txt_rfcReceptor.Location = new System.Drawing.Point(96, 44);
            this.txt_rfcReceptor.Name = "txt_rfcReceptor";
            this.txt_rfcReceptor.Size = new System.Drawing.Size(100, 20);
            this.txt_rfcReceptor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "RFC Receptor:";
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(96, 70);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(100, 20);
            this.txt_total.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total:";
            // 
            // txt_uuid
            // 
            this.txt_uuid.Location = new System.Drawing.Point(96, 96);
            this.txt_uuid.Name = "txt_uuid";
            this.txt_uuid.Size = new System.Drawing.Size(100, 20);
            this.txt_uuid.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "UUID:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "Verificar estatus";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_estatus
            // 
            this.txt_estatus.Location = new System.Drawing.Point(11, 163);
            this.txt_estatus.Name = "txt_estatus";
            this.txt_estatus.ReadOnly = true;
            this.txt_estatus.Size = new System.Drawing.Size(190, 20);
            this.txt_estatus.TabIndex = 9;
            this.txt_estatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 195);
            this.Controls.Add(this.txt_estatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_uuid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_rfcReceptor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_rfcEmisor);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Verificador CFDI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_rfcEmisor;
        private System.Windows.Forms.TextBox txt_rfcReceptor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_uuid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_estatus;
    }
}

