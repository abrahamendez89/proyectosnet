namespace EstadoResultados
{
    partial class AgendadoServicioEstadoResultados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendadoServicioEstadoResultados));
            this.btn_guardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_dia = new System.Windows.Forms.ComboBox();
            this.cmb_hora = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_minuto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chb_todosLosDias = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(235, 92);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 7;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(523, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Configuración del dia y hora de ejecución automática del proceso de estado de res" +
    "ultados.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dia:";
            // 
            // cmb_dia
            // 
            this.cmb_dia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_dia.FormattingEnabled = true;
            this.cmb_dia.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.cmb_dia.Location = new System.Drawing.Point(49, 40);
            this.cmb_dia.Name = "cmb_dia";
            this.cmb_dia.Size = new System.Drawing.Size(142, 21);
            this.cmb_dia.TabIndex = 8;
            // 
            // cmb_hora
            // 
            this.cmb_hora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_hora.FormattingEnabled = true;
            this.cmb_hora.Location = new System.Drawing.Point(287, 40);
            this.cmb_hora.Name = "cmb_hora";
            this.cmb_hora.Size = new System.Drawing.Size(69, 21);
            this.cmb_hora.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hora(24H):";
            // 
            // cmb_minuto
            // 
            this.cmb_minuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_minuto.FormattingEnabled = true;
            this.cmb_minuto.Location = new System.Drawing.Point(378, 40);
            this.cmb_minuto.Name = "cmb_minuto";
            this.cmb_minuto.Size = new System.Drawing.Size(67, 21);
            this.cmb_minuto.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = ":";
            // 
            // chb_todosLosDias
            // 
            this.chb_todosLosDias.AutoSize = true;
            this.chb_todosLosDias.Location = new System.Drawing.Point(49, 67);
            this.chb_todosLosDias.Name = "chb_todosLosDias";
            this.chb_todosLosDias.Size = new System.Drawing.Size(134, 17);
            this.chb_todosLosDias.TabIndex = 13;
            this.chb_todosLosDias.Text = "Ejecutar todos los días";
            this.chb_todosLosDias.UseVisualStyleBackColor = true;
            // 
            // AgendadoServicioEstadoResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 125);
            this.Controls.Add(this.chb_todosLosDias);
            this.Controls.Add(this.cmb_minuto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_hora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb_dia);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgendadoServicioEstadoResultados";
            this.Text = "Hora de agendado";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_dia;
        private System.Windows.Forms.ComboBox cmb_hora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_minuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chb_todosLosDias;

    }
}