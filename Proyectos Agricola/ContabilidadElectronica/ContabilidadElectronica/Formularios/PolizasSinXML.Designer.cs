namespace ContabilidadElectronica.Formularios
{
    partial class PolizasSinXML
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
            this.btn_BuscarXML = new System.Windows.Forms.Button();
            this.dgv_polizasSinXML = new System.Windows.Forms.DataGridView();
            this.btn_cargarPolizas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_encontrados = new System.Windows.Forms.TextBox();
            this.btn_asignarXML = new System.Windows.Forms.Button();
            this.btn_generarExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_polizasSinXML)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_BuscarXML
            // 
            this.btn_BuscarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_BuscarXML.Location = new System.Drawing.Point(13, 258);
            this.btn_BuscarXML.Name = "btn_BuscarXML";
            this.btn_BuscarXML.Size = new System.Drawing.Size(154, 23);
            this.btn_BuscarXML.TabIndex = 0;
            this.btn_BuscarXML.Text = "Buscar XML en pasivos";
            this.btn_BuscarXML.UseVisualStyleBackColor = true;
            this.btn_BuscarXML.Click += new System.EventHandler(this.btn_BuscarXML_Click);
            // 
            // dgv_polizasSinXML
            // 
            this.dgv_polizasSinXML.AllowUserToAddRows = false;
            this.dgv_polizasSinXML.AllowUserToDeleteRows = false;
            this.dgv_polizasSinXML.AllowUserToOrderColumns = true;
            this.dgv_polizasSinXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_polizasSinXML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_polizasSinXML.Location = new System.Drawing.Point(13, 38);
            this.dgv_polizasSinXML.MultiSelect = false;
            this.dgv_polizasSinXML.Name = "dgv_polizasSinXML";
            this.dgv_polizasSinXML.ReadOnly = true;
            this.dgv_polizasSinXML.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_polizasSinXML.Size = new System.Drawing.Size(691, 214);
            this.dgv_polizasSinXML.TabIndex = 1;
            this.dgv_polizasSinXML.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_polizasSinXML_CellDoubleClick);
            // 
            // btn_cargarPolizas
            // 
            this.btn_cargarPolizas.Location = new System.Drawing.Point(13, 9);
            this.btn_cargarPolizas.Name = "btn_cargarPolizas";
            this.btn_cargarPolizas.Size = new System.Drawing.Size(154, 23);
            this.btn_cargarPolizas.TabIndex = 2;
            this.btn_cargarPolizas.Text = "Cargar Pólizas sin XML";
            this.btn_cargarPolizas.UseVisualStyleBackColor = true;
            this.btn_cargarPolizas.Click += new System.EventHandler(this.btn_cargarPolizas_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Encontrados:";
            // 
            // txt_encontrados
            // 
            this.txt_encontrados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_encontrados.Location = new System.Drawing.Point(578, 11);
            this.txt_encontrados.Name = "txt_encontrados";
            this.txt_encontrados.ReadOnly = true;
            this.txt_encontrados.Size = new System.Drawing.Size(126, 20);
            this.txt_encontrados.TabIndex = 4;
            // 
            // btn_asignarXML
            // 
            this.btn_asignarXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_asignarXML.Location = new System.Drawing.Point(550, 258);
            this.btn_asignarXML.Name = "btn_asignarXML";
            this.btn_asignarXML.Size = new System.Drawing.Size(154, 23);
            this.btn_asignarXML.TabIndex = 5;
            this.btn_asignarXML.Text = "Asignar XML encontrados";
            this.btn_asignarXML.UseVisualStyleBackColor = true;
            this.btn_asignarXML.Click += new System.EventHandler(this.btn_asignarXML_Click);
            // 
            // btn_generarExcel
            // 
            this.btn_generarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_generarExcel.Location = new System.Drawing.Point(173, 258);
            this.btn_generarExcel.Name = "btn_generarExcel";
            this.btn_generarExcel.Size = new System.Drawing.Size(154, 23);
            this.btn_generarExcel.TabIndex = 6;
            this.btn_generarExcel.Text = "Generar excel con faltantes";
            this.btn_generarExcel.UseVisualStyleBackColor = true;
            this.btn_generarExcel.Click += new System.EventHandler(this.btn_generarExcel_Click);
            // 
            // PolizasSinXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 288);
            this.Controls.Add(this.btn_generarExcel);
            this.Controls.Add(this.btn_asignarXML);
            this.Controls.Add(this.txt_encontrados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_cargarPolizas);
            this.Controls.Add(this.dgv_polizasSinXML);
            this.Controls.Add(this.btn_BuscarXML);
            this.Name = "PolizasSinXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pólizas sin XML, busqueda";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_polizasSinXML)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_BuscarXML;
        private System.Windows.Forms.DataGridView dgv_polizasSinXML;
        private System.Windows.Forms.Button btn_cargarPolizas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_encontrados;
        private System.Windows.Forms.Button btn_asignarXML;
        private System.Windows.Forms.Button btn_generarExcel;
    }
}