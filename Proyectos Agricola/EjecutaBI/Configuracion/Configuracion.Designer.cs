namespace Configuracion
{
    partial class Configuracion
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_ruta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chb_estaActivo = new System.Windows.Forms.CheckBox();
            this.cmb_Servidor = new System.Windows.Forms.ComboBox();
            this.lbl_servidor = new System.Windows.Forms.Label();
            this.cmb_tipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_minuto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Hora = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombreProceso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_procesos = new System.Windows.Forms.DataGridView();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HORA_INICIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RUTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERVIDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_procesos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(617, 390);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_eliminar);
            this.tabPage1.Controls.Add(this.btn_nuevo);
            this.tabPage1.Controls.Add(this.btn_Guardar);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txt_ruta);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.chb_estaActivo);
            this.tabPage1.Controls.Add(this.cmb_Servidor);
            this.tabPage1.Controls.Add(this.lbl_servidor);
            this.tabPage1.Controls.Add(this.cmb_tipo);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cmb_minuto);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmb_Hora);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_nombreProceso);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dgv_procesos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(609, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Procesos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Location = new System.Drawing.Point(525, 335);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_Guardar.TabIndex = 17;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = true;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Está activo:";
            // 
            // txt_ruta
            // 
            this.txt_ruta.Location = new System.Drawing.Point(107, 218);
            this.txt_ruta.Name = "txt_ruta";
            this.txt_ruta.Size = new System.Drawing.Size(463, 20);
            this.txt_ruta.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ruta:";
            // 
            // chb_estaActivo
            // 
            this.chb_estaActivo.AutoSize = true;
            this.chb_estaActivo.Location = new System.Drawing.Point(107, 300);
            this.chb_estaActivo.Name = "chb_estaActivo";
            this.chb_estaActivo.Size = new System.Drawing.Size(15, 14);
            this.chb_estaActivo.TabIndex = 13;
            this.chb_estaActivo.UseVisualStyleBackColor = true;
            // 
            // cmb_Servidor
            // 
            this.cmb_Servidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Servidor.FormattingEnabled = true;
            this.cmb_Servidor.Items.AddRange(new object[] {
            "SQL Server",
            "Firebird"});
            this.cmb_Servidor.Location = new System.Drawing.Point(295, 273);
            this.cmb_Servidor.Name = "cmb_Servidor";
            this.cmb_Servidor.Size = new System.Drawing.Size(116, 21);
            this.cmb_Servidor.TabIndex = 12;
            this.cmb_Servidor.Visible = false;
            // 
            // lbl_servidor
            // 
            this.lbl_servidor.AutoSize = true;
            this.lbl_servidor.Location = new System.Drawing.Point(240, 276);
            this.lbl_servidor.Name = "lbl_servidor";
            this.lbl_servidor.Size = new System.Drawing.Size(49, 13);
            this.lbl_servidor.TabIndex = 11;
            this.lbl_servidor.Text = "Servidor:";
            this.lbl_servidor.Visible = false;
            // 
            // cmb_tipo
            // 
            this.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo.FormattingEnabled = true;
            this.cmb_tipo.Items.AddRange(new object[] {
            "Script",
            "Excel"});
            this.cmb_tipo.Location = new System.Drawing.Point(107, 273);
            this.cmb_tipo.Name = "cmb_tipo";
            this.cmb_tipo.Size = new System.Drawing.Size(116, 21);
            this.cmb_tipo.TabIndex = 10;
            this.cmb_tipo.SelectedIndexChanged += new System.EventHandler(this.cmb_tipo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tipo:";
            // 
            // cmb_minuto
            // 
            this.cmb_minuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_minuto.FormattingEnabled = true;
            this.cmb_minuto.Location = new System.Drawing.Point(187, 245);
            this.cmb_minuto.Name = "cmb_minuto";
            this.cmb_minuto.Size = new System.Drawing.Size(58, 21);
            this.cmb_minuto.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = ":";
            // 
            // cmb_Hora
            // 
            this.cmb_Hora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Hora.FormattingEnabled = true;
            this.cmb_Hora.Location = new System.Drawing.Point(107, 245);
            this.cmb_Hora.Name = "cmb_Hora";
            this.cmb_Hora.Size = new System.Drawing.Size(58, 21);
            this.cmb_Hora.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hora ejecución:";
            // 
            // txt_nombreProceso
            // 
            this.txt_nombreProceso.Location = new System.Drawing.Point(107, 192);
            this.txt_nombreProceso.Name = "txt_nombreProceso";
            this.txt_nombreProceso.Size = new System.Drawing.Size(304, 20);
            this.txt_nombreProceso.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Procesos:";
            // 
            // dgv_procesos
            // 
            this.dgv_procesos.AllowUserToAddRows = false;
            this.dgv_procesos.AllowUserToDeleteRows = false;
            this.dgv_procesos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_procesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_procesos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOMBRE,
            this.HORA_INICIO,
            this.RUTA,
            this.TIPO,
            this.SERVIDOR});
            this.dgv_procesos.Location = new System.Drawing.Point(3, 28);
            this.dgv_procesos.MultiSelect = false;
            this.dgv_procesos.Name = "dgv_procesos";
            this.dgv_procesos.ReadOnly = true;
            this.dgv_procesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_procesos.Size = new System.Drawing.Size(597, 123);
            this.dgv_procesos.TabIndex = 0;
            this.dgv_procesos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_procesos_CellClick);
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "Nombre proceso";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NOMBRE.Width = 200;
            // 
            // HORA_INICIO
            // 
            this.HORA_INICIO.HeaderText = "Hora inicio";
            this.HORA_INICIO.Name = "HORA_INICIO";
            this.HORA_INICIO.ReadOnly = true;
            this.HORA_INICIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RUTA
            // 
            this.RUTA.HeaderText = "Ruta";
            this.RUTA.Name = "RUTA";
            this.RUTA.ReadOnly = true;
            this.RUTA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RUTA.Width = 150;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "Tipo";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            this.TIPO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SERVIDOR
            // 
            this.SERVIDOR.HeaderText = "Servidor";
            this.SERVIDOR.Name = "SERVIDOR";
            this.SERVIDOR.ReadOnly = true;
            this.SERVIDOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(773, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servidores";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(773, 331);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Correo electrónico";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Location = new System.Drawing.Point(9, 157);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(75, 23);
            this.btn_nuevo.TabIndex = 18;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(9, 335);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar.TabIndex = 19;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 394);
            this.Controls.Add(this.tabControl1);
            this.Name = "Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración de procesos";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_procesos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgv_procesos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nombreProceso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_minuto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Hora;
        private System.Windows.Forms.ComboBox cmb_Servidor;
        private System.Windows.Forms.Label lbl_servidor;
        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chb_estaActivo;
        private System.Windows.Forms.TextBox txt_ruta;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HORA_INICIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERVIDOR;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Button btn_eliminar;
    }
}

