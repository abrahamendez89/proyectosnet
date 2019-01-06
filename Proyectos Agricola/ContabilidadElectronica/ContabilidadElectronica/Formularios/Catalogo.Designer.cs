namespace ContabilidadElectronica.Formularios
{
    partial class Catalogo
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
            this.dgv_cuentas = new System.Windows.Forms.DataGridView();
            this.btn_Guardar = new ContabilidadElectronica.ControlesDeUsuario.BotonConImagen();
            this.btn_cargarCuentas = new ContabilidadElectronica.ControlesDeUsuario.BotonConImagen();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodAgrup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumCta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCuentaDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naturaleza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Validacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_cuentas
            // 
            this.dgv_cuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_cuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_cuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CodAgrup,
            this.NumCta,
            this.Descripcion,
            this.SubCuentaDe,
            this.Nivel,
            this.Naturaleza,
            this.Validacion});
            this.dgv_cuentas.Location = new System.Drawing.Point(12, 52);
            this.dgv_cuentas.Name = "dgv_cuentas";
            this.dgv_cuentas.Size = new System.Drawing.Size(816, 399);
            this.dgv_cuentas.TabIndex = 0;
            this.dgv_cuentas.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgv_cuentas_UserDeletingRow);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Guardar.Imagen = global::ContabilidadElectronica.Properties.Resources.Guardar;
            this.btn_Guardar.Location = new System.Drawing.Point(620, 8);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(208, 29);
            this.btn_Guardar.TabIndex = 4;
            this.btn_Guardar.Texto = "Guardar cuentas contables";
            // 
            // btn_cargarCuentas
            // 
            this.btn_cargarCuentas.Imagen = global::ContabilidadElectronica.Properties.Resources._1418194907_ark2;
            this.btn_cargarCuentas.Location = new System.Drawing.Point(12, 8);
            this.btn_cargarCuentas.Name = "btn_cargarCuentas";
            this.btn_cargarCuentas.Size = new System.Drawing.Size(208, 29);
            this.btn_cargarCuentas.TabIndex = 3;
            this.btn_cargarCuentas.Texto = "Cargar cuentas contables";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 43;
            // 
            // CodAgrup
            // 
            this.CodAgrup.HeaderText = "CodAgrup";
            this.CodAgrup.Name = "CodAgrup";
            this.CodAgrup.Width = 79;
            // 
            // NumCta
            // 
            this.NumCta.HeaderText = "NumCta";
            this.NumCta.Name = "NumCta";
            this.NumCta.Width = 70;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 88;
            // 
            // SubCuentaDe
            // 
            this.SubCuentaDe.HeaderText = "SubCuentaDe";
            this.SubCuentaDe.Name = "SubCuentaDe";
            this.SubCuentaDe.Width = 99;
            // 
            // Nivel
            // 
            this.Nivel.HeaderText = "Nivel";
            this.Nivel.Name = "Nivel";
            this.Nivel.Width = 56;
            // 
            // Naturaleza
            // 
            this.Naturaleza.HeaderText = "Naturaleza";
            this.Naturaleza.Name = "Naturaleza";
            this.Naturaleza.Width = 83;
            // 
            // Validacion
            // 
            this.Validacion.FillWeight = 200F;
            this.Validacion.HeaderText = "Validación";
            this.Validacion.Name = "Validacion";
            this.Validacion.ReadOnly = true;
            this.Validacion.Width = 81;
            // 
            // Catalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 463);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.btn_cargarCuentas);
            this.Controls.Add(this.dgv_cuentas);
            this.Name = "Catalogo";
            this.Text = "Catálogo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cuentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_cuentas;
        private ControlesDeUsuario.BotonConImagen btn_cargarCuentas;
        private ControlesDeUsuario.BotonConImagen btn_Guardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodAgrup;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumCta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCuentaDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naturaleza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Validacion;


    }
}