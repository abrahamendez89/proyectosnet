namespace CuentasParaPagar.Consultas
{
    partial class HistorialDeMovimientos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialDeMovimientos));
            this.pb_imagen = new System.Windows.Forms.PictureBox();
            this.cmb_cuentas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_historialMovimientos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaAplicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_fechaMinima = new System.Windows.Forms.DateTimePicker();
            this.btn_verHistorial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_saldoAlDia = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_historialMovimientos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_imagen
            // 
            this.pb_imagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_imagen.BackColor = System.Drawing.Color.White;
            this.pb_imagen.Location = new System.Drawing.Point(726, 13);
            this.pb_imagen.Name = "pb_imagen";
            this.pb_imagen.Size = new System.Drawing.Size(153, 78);
            this.pb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_imagen.TabIndex = 24;
            this.pb_imagen.TabStop = false;
            // 
            // cmb_cuentas
            // 
            this.cmb_cuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cuentas.FormattingEnabled = true;
            this.cmb_cuentas.Location = new System.Drawing.Point(61, 12);
            this.cmb_cuentas.Name = "cmb_cuentas";
            this.cmb_cuentas.Size = new System.Drawing.Size(435, 21);
            this.cmb_cuentas.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Cuenta:";
            // 
            // dgv_historialMovimientos
            // 
            this.dgv_historialMovimientos.AllowUserToAddRows = false;
            this.dgv_historialMovimientos.AllowUserToDeleteRows = false;
            this.dgv_historialMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_historialMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_historialMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.fechaAplicacion,
            this.Tipo,
            this.Importe,
            this.Saldo,
            this.detalle});
            this.dgv_historialMovimientos.Location = new System.Drawing.Point(6, 6);
            this.dgv_historialMovimientos.Name = "dgv_historialMovimientos";
            this.dgv_historialMovimientos.ReadOnly = true;
            this.dgv_historialMovimientos.Size = new System.Drawing.Size(845, 290);
            this.dgv_historialMovimientos.TabIndex = 25;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha de aplicación";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Fecha.Width = 70;
            // 
            // fechaAplicacion
            // 
            this.fechaAplicacion.HeaderText = "Fecha del movimiento";
            this.fechaAplicacion.Name = "fechaAplicacion";
            this.fechaAplicacion.ReadOnly = true;
            this.fechaAplicacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.fechaAplicacion.Width = 70;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo de movimiento";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Tipo.Width = 270;
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Importe.Width = 80;
            // 
            // Saldo
            // 
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Saldo.Width = 80;
            // 
            // detalle
            // 
            this.detalle.HeaderText = "Detalle del movimiento";
            this.detalle.Name = "detalle";
            this.detalle.ReadOnly = true;
            this.detalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.detalle.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Desde la fecha:";
            // 
            // dtp_fechaMinima
            // 
            this.dtp_fechaMinima.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechaMinima.Location = new System.Drawing.Point(103, 96);
            this.dtp_fechaMinima.Name = "dtp_fechaMinima";
            this.dtp_fechaMinima.Size = new System.Drawing.Size(99, 20);
            this.dtp_fechaMinima.TabIndex = 27;
            this.dtp_fechaMinima.ValueChanged += new System.EventHandler(this.dtp_fechaMinima_ValueChanged);
            // 
            // btn_verHistorial
            // 
            this.btn_verHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_verHistorial.Location = new System.Drawing.Point(547, 94);
            this.btn_verHistorial.Name = "btn_verHistorial";
            this.btn_verHistorial.Size = new System.Drawing.Size(153, 23);
            this.btn_verHistorial.TabIndex = 28;
            this.btn_verHistorial.Text = "Ver historial";
            this.btn_verHistorial.UseVisualStyleBackColor = true;
            this.btn_verHistorial.Click += new System.EventHandler(this.btn_verHistorial_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(706, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Saldo al día:";
            // 
            // txt_saldoAlDia
            // 
            this.txt_saldoAlDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_saldoAlDia.BackColor = System.Drawing.Color.White;
            this.txt_saldoAlDia.Location = new System.Drawing.Point(779, 97);
            this.txt_saldoAlDia.Name = "txt_saldoAlDia";
            this.txt_saldoAlDia.ReadOnly = true;
            this.txt_saldoAlDia.Size = new System.Drawing.Size(100, 20);
            this.txt_saldoAlDia.TabIndex = 30;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 123);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(865, 328);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_historialMovimientos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(857, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tabla";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(857, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gráfica";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(6, 6);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(845, 290);
            this.chart.TabIndex = 0;
            this.chart.Text = "grafica";
            // 
            // HistorialDeMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 463);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txt_saldoAlDia);
            this.Controls.Add(this.dtp_fechaMinima);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_verHistorial);
            this.Controls.Add(this.pb_imagen);
            this.Controls.Add(this.cmb_cuentas);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HistorialDeMovimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de movimientos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_historialMovimientos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_imagen;
        private System.Windows.Forms.ComboBox cmb_cuentas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_historialMovimientos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_fechaMinima;
        private System.Windows.Forms.Button btn_verHistorial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_saldoAlDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaAplicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}