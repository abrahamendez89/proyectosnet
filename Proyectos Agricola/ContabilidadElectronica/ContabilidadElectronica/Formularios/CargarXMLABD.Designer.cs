namespace ContabilidadElectronica.Formularios
{
    partial class CargarXMLABD
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
            this.txt_directorio = new System.Windows.Forms.TextBox();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_Archivos = new System.Windows.Forms.DataGridView();
            this.Archivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTENIDOARCHIVO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOLIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUS_SAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFCEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFCReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_cargarXML = new System.Windows.Forms.Button();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.btn_SubirAlServidor = new System.Windows.Forms.Button();
            this.pb_avance = new System.Windows.Forms.ProgressBar();
            this.btn_validar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Archivos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directorio:";
            // 
            // txt_directorio
            // 
            this.txt_directorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_directorio.BackColor = System.Drawing.Color.White;
            this.txt_directorio.Location = new System.Drawing.Point(77, 6);
            this.txt_directorio.Name = "txt_directorio";
            this.txt_directorio.ReadOnly = true;
            this.txt_directorio.Size = new System.Drawing.Size(465, 20);
            this.txt_directorio.TabIndex = 1;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Buscar.Location = new System.Drawing.Point(548, 3);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Archivos XML encontrados:";
            // 
            // dgv_Archivos
            // 
            this.dgv_Archivos.AllowUserToAddRows = false;
            this.dgv_Archivos.AllowUserToDeleteRows = false;
            this.dgv_Archivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Archivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Archivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Archivo,
            this.CONTENIDOARCHIVO,
            this.UUID,
            this.FOLIO,
            this.ESTATUS,
            this.ESTATUS_SAT,
            this.RFCEmisor,
            this.RFCReceptor,
            this.MONTO,
            this.FechaEmision});
            this.dgv_Archivos.Location = new System.Drawing.Point(12, 65);
            this.dgv_Archivos.MultiSelect = false;
            this.dgv_Archivos.Name = "dgv_Archivos";
            this.dgv_Archivos.ReadOnly = true;
            this.dgv_Archivos.Size = new System.Drawing.Size(818, 247);
            this.dgv_Archivos.TabIndex = 5;
            // 
            // Archivo
            // 
            this.Archivo.HeaderText = "ARCHIVO";
            this.Archivo.Name = "Archivo";
            this.Archivo.ReadOnly = true;
            // 
            // CONTENIDOARCHIVO
            // 
            this.CONTENIDOARCHIVO.HeaderText = "CONTENIDO ARCHIVO";
            this.CONTENIDOARCHIVO.Name = "CONTENIDOARCHIVO";
            this.CONTENIDOARCHIVO.ReadOnly = true;
            // 
            // UUID
            // 
            this.UUID.HeaderText = "UUID";
            this.UUID.Name = "UUID";
            this.UUID.ReadOnly = true;
            // 
            // FOLIO
            // 
            this.FOLIO.HeaderText = "FOLIO";
            this.FOLIO.Name = "FOLIO";
            this.FOLIO.ReadOnly = true;
            // 
            // ESTATUS
            // 
            this.ESTATUS.HeaderText = "ESTATUS";
            this.ESTATUS.Name = "ESTATUS";
            this.ESTATUS.ReadOnly = true;
            // 
            // ESTATUS_SAT
            // 
            this.ESTATUS_SAT.HeaderText = "ESTATUS SAT";
            this.ESTATUS_SAT.Name = "ESTATUS_SAT";
            this.ESTATUS_SAT.ReadOnly = true;
            // 
            // RFCEmisor
            // 
            this.RFCEmisor.HeaderText = "RFC EMISOR";
            this.RFCEmisor.Name = "RFCEmisor";
            this.RFCEmisor.ReadOnly = true;
            // 
            // RFCReceptor
            // 
            this.RFCReceptor.HeaderText = "RFC RECEPTOR";
            this.RFCReceptor.Name = "RFCReceptor";
            this.RFCReceptor.ReadOnly = true;
            // 
            // MONTO
            // 
            this.MONTO.HeaderText = "MONTO";
            this.MONTO.Name = "MONTO";
            this.MONTO.ReadOnly = true;
            // 
            // FechaEmision
            // 
            this.FechaEmision.HeaderText = "FECHA DE EMISION";
            this.FechaEmision.Name = "FechaEmision";
            this.FechaEmision.ReadOnly = true;
            // 
            // btn_cargarXML
            // 
            this.btn_cargarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cargarXML.Location = new System.Drawing.Point(643, 4);
            this.btn_cargarXML.Name = "btn_cargarXML";
            this.btn_cargarXML.Size = new System.Drawing.Size(75, 23);
            this.btn_cargarXML.TabIndex = 6;
            this.btn_cargarXML.Text = "Cargar XML";
            this.btn_cargarXML.UseVisualStyleBackColor = true;
            this.btn_cargarXML.Click += new System.EventHandler(this.btn_cargarXML_Click);
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(158, 39);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(100, 20);
            this.txt_total.TabIndex = 7;
            this.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_SubirAlServidor
            // 
            this.btn_SubirAlServidor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_SubirAlServidor.Location = new System.Drawing.Point(12, 318);
            this.btn_SubirAlServidor.Name = "btn_SubirAlServidor";
            this.btn_SubirAlServidor.Size = new System.Drawing.Size(132, 23);
            this.btn_SubirAlServidor.TabIndex = 8;
            this.btn_SubirAlServidor.Text = "Subir al servidor";
            this.btn_SubirAlServidor.UseVisualStyleBackColor = true;
            this.btn_SubirAlServidor.Click += new System.EventHandler(this.btn_SubirAlServidor_Click);
            // 
            // pb_avance
            // 
            this.pb_avance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_avance.Location = new System.Drawing.Point(150, 325);
            this.pb_avance.Name = "pb_avance";
            this.pb_avance.Size = new System.Drawing.Size(680, 10);
            this.pb_avance.TabIndex = 9;
            // 
            // btn_validar
            // 
            this.btn_validar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_validar.Location = new System.Drawing.Point(724, 4);
            this.btn_validar.Name = "btn_validar";
            this.btn_validar.Size = new System.Drawing.Size(106, 23);
            this.btn_validar.TabIndex = 10;
            this.btn_validar.Text = "Validar CFDI SAT";
            this.btn_validar.UseVisualStyleBackColor = true;
            this.btn_validar.Click += new System.EventHandler(this.btn_validar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 360);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(843, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "F1 - Mostrar buscador manual de XML";
            // 
            // CargarXMLABD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 379);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_validar);
            this.Controls.Add(this.pb_avance);
            this.Controls.Add(this.btn_SubirAlServidor);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.btn_cargarXML);
            this.Controls.Add(this.dgv_Archivos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.txt_directorio);
            this.Controls.Add(this.label1);
            this.Name = "CargarXMLABD";
            this.Text = "CargarXMLABD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Archivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_directorio;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_Archivos;
        private System.Windows.Forms.Button btn_cargarXML;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Button btn_SubirAlServidor;
        private System.Windows.Forms.ProgressBar pb_avance;
        private System.Windows.Forms.Button btn_validar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Archivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTENIDOARCHIVO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOLIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUS_SAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFCEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFCReceptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEmision;
    }
}