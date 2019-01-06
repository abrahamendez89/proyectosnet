namespace EstadoResultados
{
    partial class CatalogoEstadoResultados
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
            this.components = new System.ComponentModel.Container();
            this.tv_conceptosEstadoResultados = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombreConcepto = new System.Windows.Forms.TextBox();
            this.chb_directo = new System.Windows.Forms.CheckBox();
            this.chb_indirecto = new System.Windows.Forms.CheckBox();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.lbl_query = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_actualizarBD = new System.Windows.Forms.Button();
            this.txt_query = new System.Windows.Forms.RichTextBox();
            this.btn_formato = new System.Windows.Forms.Button();
            this.btn_modificarConcepto = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_cortar = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmb_beneficios = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tv_conceptosEstadoResultados
            // 
            this.tv_conceptosEstadoResultados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tv_conceptosEstadoResultados.Location = new System.Drawing.Point(8, 31);
            this.tv_conceptosEstadoResultados.Name = "tv_conceptosEstadoResultados";
            this.tv_conceptosEstadoResultados.Size = new System.Drawing.Size(344, 226);
            this.tv_conceptosEstadoResultados.TabIndex = 0;
            this.tv_conceptosEstadoResultados.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_conceptosEstadoResultados_NodeMouseClick);
            this.tv_conceptosEstadoResultados.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_conceptosEstadoResultados_NodeMouseClick);
            this.tv_conceptosEstadoResultados.Click += new System.EventHandler(this.tv_conceptosEstadoResultados_Click);
            this.tv_conceptosEstadoResultados.DoubleClick += new System.EventHandler(this.tv_conceptosEstadoResultados_DoubleClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del concepto:";
            // 
            // txt_nombreConcepto
            // 
            this.txt_nombreConcepto.Location = new System.Drawing.Point(513, 17);
            this.txt_nombreConcepto.Name = "txt_nombreConcepto";
            this.txt_nombreConcepto.Size = new System.Drawing.Size(425, 20);
            this.txt_nombreConcepto.TabIndex = 2;
            // 
            // chb_directo
            // 
            this.chb_directo.AutoSize = true;
            this.chb_directo.Location = new System.Drawing.Point(513, 43);
            this.chb_directo.Name = "chb_directo";
            this.chb_directo.Size = new System.Drawing.Size(73, 17);
            this.chb_directo.TabIndex = 3;
            this.chb_directo.Text = "Es directo";
            this.chb_directo.UseVisualStyleBackColor = true;
            this.chb_directo.CheckedChanged += new System.EventHandler(this.chb_directo_CheckedChanged);
            // 
            // chb_indirecto
            // 
            this.chb_indirecto.AutoSize = true;
            this.chb_indirecto.Location = new System.Drawing.Point(592, 43);
            this.chb_indirecto.Name = "chb_indirecto";
            this.chb_indirecto.Size = new System.Drawing.Size(81, 17);
            this.chb_indirecto.TabIndex = 4;
            this.chb_indirecto.Text = "Es indirecto";
            this.chb_indirecto.UseVisualStyleBackColor = true;
            this.chb_indirecto.CheckedChanged += new System.EventHandler(this.chb_indirecto_CheckedChanged);
            // 
            // btn_guardar
            // 
            this.btn_guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_guardar.Location = new System.Drawing.Point(863, 285);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // lbl_query
            // 
            this.lbl_query.AutoSize = true;
            this.lbl_query.Location = new System.Drawing.Point(398, 84);
            this.lbl_query.Name = "lbl_query";
            this.lbl_query.Size = new System.Drawing.Size(38, 13);
            this.lbl_query.TabIndex = 7;
            this.lbl_query.Text = "Query:";
            this.lbl_query.Visible = false;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancelar.Location = new System.Drawing.Point(578, 285);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_actualizarBD
            // 
            this.btn_actualizarBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_actualizarBD.Location = new System.Drawing.Point(8, 285);
            this.btn_actualizarBD.Name = "btn_actualizarBD";
            this.btn_actualizarBD.Size = new System.Drawing.Size(344, 23);
            this.btn_actualizarBD.TabIndex = 9;
            this.btn_actualizarBD.Text = "Actualizar estado de resultados a BD";
            this.btn_actualizarBD.UseVisualStyleBackColor = true;
            this.btn_actualizarBD.Click += new System.EventHandler(this.btn_actualizarBD_Click);
            // 
            // txt_query
            // 
            this.txt_query.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_query.Location = new System.Drawing.Point(398, 100);
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(540, 179);
            this.txt_query.TabIndex = 10;
            this.txt_query.Text = "";
            this.txt_query.Visible = false;
            // 
            // btn_formato
            // 
            this.btn_formato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_formato.Location = new System.Drawing.Point(398, 285);
            this.btn_formato.Name = "btn_formato";
            this.btn_formato.Size = new System.Drawing.Size(75, 23);
            this.btn_formato.TabIndex = 11;
            this.btn_formato.Text = "Formato";
            this.btn_formato.UseVisualStyleBackColor = true;
            this.btn_formato.Click += new System.EventHandler(this.btn_formato_Click);
            // 
            // btn_modificarConcepto
            // 
            this.btn_modificarConcepto.Location = new System.Drawing.Point(243, 2);
            this.btn_modificarConcepto.Name = "btn_modificarConcepto";
            this.btn_modificarConcepto.Size = new System.Drawing.Size(109, 23);
            this.btn_modificarConcepto.TabIndex = 12;
            this.btn_modificarConcepto.Text = "Modificar";
            this.btn_modificarConcepto.UseVisualStyleBackColor = true;
            this.btn_modificarConcepto.Click += new System.EventHandler(this.btn_modificarConcepto_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(121, 2);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(102, 23);
            this.btn_agregar.TabIndex = 13;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(8, 2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(92, 23);
            this.btn_eliminar.TabIndex = 14;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_cortar
            // 
            this.btn_cortar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cortar.Location = new System.Drawing.Point(94, 259);
            this.btn_cortar.Name = "btn_cortar";
            this.btn_cortar.Size = new System.Drawing.Size(166, 23);
            this.btn_cortar.TabIndex = 15;
            this.btn_cortar.Text = "Cortar";
            this.btn_cortar.UseVisualStyleBackColor = true;
            this.btn_cortar.Click += new System.EventHandler(this.btn_cortar_Click);
            // 
            // cmb_beneficios
            // 
            this.cmb_beneficios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_beneficios.FormattingEnabled = true;
            this.cmb_beneficios.Location = new System.Drawing.Point(760, 41);
            this.cmb_beneficios.Name = "cmb_beneficios";
            this.cmb_beneficios.Size = new System.Drawing.Size(178, 21);
            this.cmb_beneficios.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(700, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Beneficio:";
            // 
            // CatalogoEstadoResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 315);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_beneficios);
            this.Controls.Add(this.btn_cortar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_modificarConcepto);
            this.Controls.Add(this.btn_formato);
            this.Controls.Add(this.txt_query);
            this.Controls.Add(this.btn_actualizarBD);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.lbl_query);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.chb_indirecto);
            this.Controls.Add(this.chb_directo);
            this.Controls.Add(this.txt_nombreConcepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tv_conceptosEstadoResultados);
            this.Name = "CatalogoEstadoResultados";
            this.Text = "CatalogoEstadoResultados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_conceptosEstadoResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombreConcepto;
        private System.Windows.Forms.CheckBox chb_directo;
        private System.Windows.Forms.CheckBox chb_indirecto;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Label lbl_query;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_actualizarBD;
        private System.Windows.Forms.RichTextBox txt_query;
        private System.Windows.Forms.Button btn_formato;
        private System.Windows.Forms.Button btn_modificarConcepto;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_cortar;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cmb_beneficios;
        private System.Windows.Forms.Label label2;
    }
}