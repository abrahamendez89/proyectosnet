namespace CuentasParaPagar.Consultas
{
    partial class ProyeccionFutura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProyeccionFutura));
            this.pb_imagen = new System.Windows.Forms.PictureBox();
            this.cmb_cuentas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_proyeccion = new System.Windows.Forms.DataGridView();
            this.FechaAplicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_generar = new System.Windows.Forms.Button();
            this.btn_AgregarPagoSimulado = new System.Windows.Forms.Button();
            this.btn_BorrarPagosSimulados = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_saldoAlDia = new System.Windows.Forms.TextBox();
            this.btn_borrarMovimientoSimulado = new System.Windows.Forms.Button();
            this.btn_enviarAExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_proyeccion)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_imagen
            // 
            this.pb_imagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_imagen.BackColor = System.Drawing.Color.White;
            this.pb_imagen.Location = new System.Drawing.Point(613, 12);
            this.pb_imagen.Name = "pb_imagen";
            this.pb_imagen.Size = new System.Drawing.Size(177, 81);
            this.pb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_imagen.TabIndex = 27;
            this.pb_imagen.TabStop = false;
            // 
            // cmb_cuentas
            // 
            this.cmb_cuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cuentas.FormattingEnabled = true;
            this.cmb_cuentas.Location = new System.Drawing.Point(68, 12);
            this.cmb_cuentas.Name = "cmb_cuentas";
            this.cmb_cuentas.Size = new System.Drawing.Size(396, 21);
            this.cmb_cuentas.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Cuenta:";
            // 
            // dtp_fechaHasta
            // 
            this.dtp_fechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechaHasta.Location = new System.Drawing.Point(151, 132);
            this.dtp_fechaHasta.Name = "dtp_fechaHasta";
            this.dtp_fechaHasta.Size = new System.Drawing.Size(104, 20);
            this.dtp_fechaHasta.TabIndex = 28;
            this.dtp_fechaHasta.ValueChanged += new System.EventHandler(this.dtp_fechaHasta_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Hasta la siguiente fecha:";
            // 
            // dgv_proyeccion
            // 
            this.dgv_proyeccion.AllowUserToAddRows = false;
            this.dgv_proyeccion.AllowUserToDeleteRows = false;
            this.dgv_proyeccion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_proyeccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_proyeccion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaAplicacion,
            this.Fecha,
            this.TipoMovimiento,
            this.Importe,
            this.Saldo,
            this.Detalle});
            this.dgv_proyeccion.Location = new System.Drawing.Point(21, 160);
            this.dgv_proyeccion.MultiSelect = false;
            this.dgv_proyeccion.Name = "dgv_proyeccion";
            this.dgv_proyeccion.ReadOnly = true;
            this.dgv_proyeccion.Size = new System.Drawing.Size(769, 278);
            this.dgv_proyeccion.TabIndex = 30;
            // 
            // FechaAplicacion
            // 
            this.FechaAplicacion.HeaderText = "Fecha aplicación";
            this.FechaAplicacion.Name = "FechaAplicacion";
            this.FechaAplicacion.ReadOnly = true;
            this.FechaAplicacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FechaAplicacion.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha del movimiento";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Fecha.Width = 80;
            // 
            // TipoMovimiento
            // 
            this.TipoMovimiento.HeaderText = "Tipo de movimiento";
            this.TipoMovimiento.Name = "TipoMovimiento";
            this.TipoMovimiento.ReadOnly = true;
            this.TipoMovimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TipoMovimiento.Width = 270;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Importe.Width = 70;
            // 
            // Saldo
            // 
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Saldo.Width = 70;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle del movimiento";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Detalle.Width = 250;
            // 
            // btn_generar
            // 
            this.btn_generar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generar.Location = new System.Drawing.Point(548, 127);
            this.btn_generar.Name = "btn_generar";
            this.btn_generar.Size = new System.Drawing.Size(242, 26);
            this.btn_generar.TabIndex = 31;
            this.btn_generar.Text = "Generar proyección";
            this.btn_generar.UseVisualStyleBackColor = true;
            this.btn_generar.Click += new System.EventHandler(this.btn_generar_Click);
            // 
            // btn_AgregarPagoSimulado
            // 
            this.btn_AgregarPagoSimulado.Location = new System.Drawing.Point(24, 47);
            this.btn_AgregarPagoSimulado.Name = "btn_AgregarPagoSimulado";
            this.btn_AgregarPagoSimulado.Size = new System.Drawing.Size(144, 46);
            this.btn_AgregarPagoSimulado.TabIndex = 34;
            this.btn_AgregarPagoSimulado.Text = "Agregar movimiento simulado";
            this.btn_AgregarPagoSimulado.UseVisualStyleBackColor = true;
            this.btn_AgregarPagoSimulado.Click += new System.EventHandler(this.btn_AgregarPagoSimulado_Click);
            // 
            // btn_BorrarPagosSimulados
            // 
            this.btn_BorrarPagosSimulados.Location = new System.Drawing.Point(205, 47);
            this.btn_BorrarPagosSimulados.Name = "btn_BorrarPagosSimulados";
            this.btn_BorrarPagosSimulados.Size = new System.Drawing.Size(121, 46);
            this.btn_BorrarPagosSimulados.TabIndex = 37;
            this.btn_BorrarPagosSimulados.Text = "Borrar movimientos simulados (TODOS)";
            this.btn_BorrarPagosSimulados.UseVisualStyleBackColor = true;
            this.btn_BorrarPagosSimulados.Click += new System.EventHandler(this.btn_BorrarPagosSimulados_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(610, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Saldo al dia:";
            // 
            // txt_saldoAlDia
            // 
            this.txt_saldoAlDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_saldoAlDia.BackColor = System.Drawing.Color.White;
            this.txt_saldoAlDia.Location = new System.Drawing.Point(681, 95);
            this.txt_saldoAlDia.Name = "txt_saldoAlDia";
            this.txt_saldoAlDia.ReadOnly = true;
            this.txt_saldoAlDia.Size = new System.Drawing.Size(109, 20);
            this.txt_saldoAlDia.TabIndex = 39;
            // 
            // btn_borrarMovimientoSimulado
            // 
            this.btn_borrarMovimientoSimulado.Location = new System.Drawing.Point(332, 47);
            this.btn_borrarMovimientoSimulado.Name = "btn_borrarMovimientoSimulado";
            this.btn_borrarMovimientoSimulado.Size = new System.Drawing.Size(132, 46);
            this.btn_borrarMovimientoSimulado.TabIndex = 40;
            this.btn_borrarMovimientoSimulado.Text = "Borrar movimiento seleccionado";
            this.btn_borrarMovimientoSimulado.UseVisualStyleBackColor = true;
            this.btn_borrarMovimientoSimulado.Click += new System.EventHandler(this.btn_borrarMovimientoSimulado_Click);
            // 
            // btn_enviarAExcel
            // 
            this.btn_enviarAExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_enviarAExcel.Location = new System.Drawing.Point(426, 127);
            this.btn_enviarAExcel.Name = "btn_enviarAExcel";
            this.btn_enviarAExcel.Size = new System.Drawing.Size(116, 26);
            this.btn_enviarAExcel.TabIndex = 41;
            this.btn_enviarAExcel.Text = "Enviar a Excel";
            this.btn_enviarAExcel.UseVisualStyleBackColor = true;
            this.btn_enviarAExcel.Click += new System.EventHandler(this.btn_enviarAExcel_Click);
            // 
            // ProyeccionFutura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 450);
            this.Controls.Add(this.btn_enviarAExcel);
            this.Controls.Add(this.btn_borrarMovimientoSimulado);
            this.Controls.Add(this.txt_saldoAlDia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_BorrarPagosSimulados);
            this.Controls.Add(this.btn_AgregarPagoSimulado);
            this.Controls.Add(this.btn_generar);
            this.Controls.Add(this.dgv_proyeccion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp_fechaHasta);
            this.Controls.Add(this.pb_imagen);
            this.Controls.Add(this.cmb_cuentas);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProyeccionFutura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyección Futura de cuenta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_proyeccion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_imagen;
        private System.Windows.Forms.ComboBox cmb_cuentas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_fechaHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_proyeccion;
        private System.Windows.Forms.Button btn_generar;
        private System.Windows.Forms.Button btn_AgregarPagoSimulado;
        private System.Windows.Forms.Button btn_BorrarPagosSimulados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_saldoAlDia;
        private System.Windows.Forms.Button btn_borrarMovimientoSimulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaAplicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.Button btn_enviarAExcel;
    }
}