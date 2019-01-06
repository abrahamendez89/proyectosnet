namespace VNCViewerLauncher
{
    partial class Principal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.pnl_grupos = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_equiposEnGrupo = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_busqueda = new System.Windows.Forms.TextBox();
            this.tc = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_eliminar = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_guardarSolucion = new System.Windows.Forms.Button();
            this.txt_solucion = new System.Windows.Forms.TextBox();
            this.lbl_seleccionado = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_conexiones = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_soporte = new System.Windows.Forms.DataGridView();
            this.pb_ultravnc = new System.Windows.Forms.PictureBox();
            this.pb_realvnc = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_mensaje = new System.Windows.Forms.Button();
            this.btn_notificacion = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_mensaje = new System.Windows.Forms.TextBox();
            this.pb_actualizarConectados = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_equiposConectados = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.pb_BuscarConFiltroEquiposConectados = new System.Windows.Forms.PictureBox();
            this.txt_filtroEquiposConectados = new System.Windows.Forms.TextBox();
            this.tc.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eliminar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_soporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ultravnc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_realvnc)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_actualizarConectados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_equiposConectados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_BuscarConFiltroEquiposConectados)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_grupos
            // 
            this.pnl_grupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_grupos.AutoScroll = true;
            this.pnl_grupos.Location = new System.Drawing.Point(1, 34);
            this.pnl_grupos.Name = "pnl_grupos";
            this.pnl_grupos.Size = new System.Drawing.Size(323, 341);
            this.pnl_grupos.TabIndex = 0;
            // 
            // pnl_equiposEnGrupo
            // 
            this.pnl_equiposEnGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_equiposEnGrupo.AutoScroll = true;
            this.pnl_equiposEnGrupo.Location = new System.Drawing.Point(6, 40);
            this.pnl_equiposEnGrupo.Name = "pnl_equiposEnGrupo";
            this.pnl_equiposEnGrupo.Size = new System.Drawing.Size(552, 218);
            this.pnl_equiposEnGrupo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grupos:";
            // 
            // txt_busqueda
            // 
            this.txt_busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_busqueda.Location = new System.Drawing.Point(344, 10);
            this.txt_busqueda.Name = "txt_busqueda";
            this.txt_busqueda.Size = new System.Drawing.Size(183, 20);
            this.txt_busqueda.TabIndex = 4;
            this.txt_busqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_busqueda_KeyPress);
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.Controls.Add(this.tabPage1);
            this.tc.Controls.Add(this.tabPage2);
            this.tc.Controls.Add(this.tabPage3);
            this.tc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc.Location = new System.Drawing.Point(333, 34);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(714, 341);
            this.tc.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pnl_equiposEnGrupo);
            this.tabPage1.Controls.Add(this.pb_eliminar);
            this.tabPage1.Controls.Add(this.txt_busqueda);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(564, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Equipos";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(292, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filtro:";
            // 
            // pb_eliminar
            // 
            this.pb_eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_eliminar.Image = global::VNCViewerLauncher.Properties.Resources._1446064182_magnifier;
            this.pb_eliminar.Location = new System.Drawing.Point(532, 7);
            this.pb_eliminar.Name = "pb_eliminar";
            this.pb_eliminar.Size = new System.Drawing.Size(25, 25);
            this.pb_eliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eliminar.TabIndex = 5;
            this.pb_eliminar.TabStop = false;
            this.pb_eliminar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_eliminar_MouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.btn_guardarSolucion);
            this.tabPage2.Controls.Add(this.txt_solucion);
            this.tabPage2.Controls.Add(this.lbl_seleccionado);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.cmb_conexiones);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dgv_soporte);
            this.tabPage2.Controls.Add(this.pb_ultravnc);
            this.tabPage2.Controls.Add(this.pb_realvnc);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(564, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Solicitudes de soporte";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::VNCViewerLauncher.Properties.Resources._1446623607_reload;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_guardarSolucion
            // 
            this.btn_guardarSolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_guardarSolucion.Location = new System.Drawing.Point(428, 238);
            this.btn_guardarSolucion.Name = "btn_guardarSolucion";
            this.btn_guardarSolucion.Size = new System.Drawing.Size(129, 23);
            this.btn_guardarSolucion.TabIndex = 15;
            this.btn_guardarSolucion.Text = "Guardar solución";
            this.btn_guardarSolucion.UseVisualStyleBackColor = true;
            this.btn_guardarSolucion.Click += new System.EventHandler(this.btn_guardarSolucion_Click);
            // 
            // txt_solucion
            // 
            this.txt_solucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_solucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_solucion.Location = new System.Drawing.Point(9, 181);
            this.txt_solucion.Multiline = true;
            this.txt_solucion.Name = "txt_solucion";
            this.txt_solucion.Size = new System.Drawing.Size(548, 53);
            this.txt_solucion.TabIndex = 14;
            // 
            // lbl_seleccionado
            // 
            this.lbl_seleccionado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_seleccionado.AutoSize = true;
            this.lbl_seleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_seleccionado.Location = new System.Drawing.Point(170, 163);
            this.lbl_seleccionado.Name = "lbl_seleccionado";
            this.lbl_seleccionado.Size = new System.Drawing.Size(51, 16);
            this.lbl_seleccionado.TabIndex = 13;
            this.lbl_seleccionado.Text = "label6";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Solución del problema de:";
            // 
            // cmb_conexiones
            // 
            this.cmb_conexiones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_conexiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_conexiones.FormattingEnabled = true;
            this.cmb_conexiones.Location = new System.Drawing.Point(352, 10);
            this.cmb_conexiones.Name = "cmb_conexiones";
            this.cmb_conexiones.Size = new System.Drawing.Size(142, 21);
            this.cmb_conexiones.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Conectar a:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Solicitudes enviadas a soporte:";
            // 
            // dgv_soporte
            // 
            this.dgv_soporte.AllowUserToAddRows = false;
            this.dgv_soporte.AllowUserToDeleteRows = false;
            this.dgv_soporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_soporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_soporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_soporte.Location = new System.Drawing.Point(6, 35);
            this.dgv_soporte.MultiSelect = false;
            this.dgv_soporte.Name = "dgv_soporte";
            this.dgv_soporte.ReadOnly = true;
            this.dgv_soporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_soporte.Size = new System.Drawing.Size(552, 123);
            this.dgv_soporte.TabIndex = 0;
            this.dgv_soporte.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_soporte_CellClick);
            this.dgv_soporte.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_soporte_CellMouseDoubleClick);
            // 
            // pb_ultravnc
            // 
            this.pb_ultravnc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ultravnc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ultravnc.Image = global::VNCViewerLauncher.Properties.Resources.ultravnc1;
            this.pb_ultravnc.Location = new System.Drawing.Point(500, 8);
            this.pb_ultravnc.Name = "pb_ultravnc";
            this.pb_ultravnc.Size = new System.Drawing.Size(25, 25);
            this.pb_ultravnc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ultravnc.TabIndex = 11;
            this.pb_ultravnc.TabStop = false;
            this.pb_ultravnc.Click += new System.EventHandler(this.pb_ultravnc_Click);
            // 
            // pb_realvnc
            // 
            this.pb_realvnc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_realvnc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_realvnc.Image = global::VNCViewerLauncher.Properties.Resources.realvnc1;
            this.pb_realvnc.Location = new System.Drawing.Point(532, 8);
            this.pb_realvnc.Name = "pb_realvnc";
            this.pb_realvnc.Size = new System.Drawing.Size(25, 25);
            this.pb_realvnc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_realvnc.TabIndex = 10;
            this.pb_realvnc.TabStop = false;
            this.pb_realvnc.Click += new System.EventHandler(this.pb_realvnc_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.pb_BuscarConFiltroEquiposConectados);
            this.tabPage3.Controls.Add(this.txt_filtroEquiposConectados);
            this.tabPage3.Controls.Add(this.btn_mensaje);
            this.tabPage3.Controls.Add(this.btn_notificacion);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.txt_mensaje);
            this.tabPage3.Controls.Add(this.pb_actualizarConectados);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dgv_equiposConectados);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(706, 315);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Equipos conectados";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_mensaje
            // 
            this.btn_mensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_mensaje.Location = new System.Drawing.Point(603, 284);
            this.btn_mensaje.Name = "btn_mensaje";
            this.btn_mensaje.Size = new System.Drawing.Size(99, 23);
            this.btn_mensaje.TabIndex = 31;
            this.btn_mensaje.Text = "Ventana";
            this.btn_mensaje.UseVisualStyleBackColor = true;
            this.btn_mensaje.Click += new System.EventHandler(this.btn_mensaje_Click);
            // 
            // btn_notificacion
            // 
            this.btn_notificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_notificacion.Location = new System.Drawing.Point(505, 284);
            this.btn_notificacion.Name = "btn_notificacion";
            this.btn_notificacion.Size = new System.Drawing.Size(95, 23);
            this.btn_notificacion.TabIndex = 30;
            this.btn_notificacion.Text = "Notificación";
            this.btn_notificacion.UseVisualStyleBackColor = true;
            this.btn_notificacion.Click += new System.EventHandler(this.btn_notificacion_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Enviar Mensaje para todos:";
            // 
            // txt_mensaje
            // 
            this.txt_mensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_mensaje.Location = new System.Drawing.Point(148, 286);
            this.txt_mensaje.Name = "txt_mensaje";
            this.txt_mensaje.Size = new System.Drawing.Size(351, 20);
            this.txt_mensaje.TabIndex = 29;
            // 
            // pb_actualizarConectados
            // 
            this.pb_actualizarConectados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_actualizarConectados.Image = global::VNCViewerLauncher.Properties.Resources._1446623607_reload;
            this.pb_actualizarConectados.Location = new System.Drawing.Point(9, 4);
            this.pb_actualizarConectados.Name = "pb_actualizarConectados";
            this.pb_actualizarConectados.Size = new System.Drawing.Size(25, 25);
            this.pb_actualizarConectados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_actualizarConectados.TabIndex = 18;
            this.pb_actualizarConectados.TabStop = false;
            this.pb_actualizarConectados.Click += new System.EventHandler(this.pb_actualizarConectados_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(321, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Equipos conectados en este momento:";
            // 
            // dgv_equiposConectados
            // 
            this.dgv_equiposConectados.AllowUserToAddRows = false;
            this.dgv_equiposConectados.AllowUserToDeleteRows = false;
            this.dgv_equiposConectados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_equiposConectados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_equiposConectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_equiposConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_equiposConectados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_equiposConectados.Location = new System.Drawing.Point(7, 30);
            this.dgv_equiposConectados.MultiSelect = false;
            this.dgv_equiposConectados.Name = "dgv_equiposConectados";
            this.dgv_equiposConectados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_equiposConectados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_equiposConectados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_equiposConectados.Size = new System.Drawing.Size(694, 247);
            this.dgv_equiposConectados.TabIndex = 1;
            this.dgv_equiposConectados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_equiposConectados_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(436, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "Filtro:";
            // 
            // pb_BuscarConFiltroEquiposConectados
            // 
            this.pb_BuscarConFiltroEquiposConectados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_BuscarConFiltroEquiposConectados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_BuscarConFiltroEquiposConectados.Image = global::VNCViewerLauncher.Properties.Resources._1446064182_magnifier;
            this.pb_BuscarConFiltroEquiposConectados.Location = new System.Drawing.Point(676, 4);
            this.pb_BuscarConFiltroEquiposConectados.Name = "pb_BuscarConFiltroEquiposConectados";
            this.pb_BuscarConFiltroEquiposConectados.Size = new System.Drawing.Size(25, 25);
            this.pb_BuscarConFiltroEquiposConectados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_BuscarConFiltroEquiposConectados.TabIndex = 33;
            this.pb_BuscarConFiltroEquiposConectados.TabStop = false;
            this.pb_BuscarConFiltroEquiposConectados.Click += new System.EventHandler(this.pb_BuscarConFiltroEquiposConectados_Click);
            // 
            // txt_filtroEquiposConectados
            // 
            this.txt_filtroEquiposConectados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filtroEquiposConectados.Location = new System.Drawing.Point(488, 7);
            this.txt_filtroEquiposConectados.Name = "txt_filtroEquiposConectados";
            this.txt_filtroEquiposConectados.Size = new System.Drawing.Size(183, 20);
            this.txt_filtroEquiposConectados.TabIndex = 32;
            this.txt_filtroEquiposConectados.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_filtroEquiposConectados_KeyPress);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 377);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_grupos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNC Viewer Launcher 2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Principal_Resize);
            this.tc.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eliminar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_soporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ultravnc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_realvnc)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_actualizarConectados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_equiposConectados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_BuscarConFiltroEquiposConectados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnl_grupos;
        private System.Windows.Forms.FlowLayoutPanel pnl_equiposEnGrupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_busqueda;
        private System.Windows.Forms.PictureBox pb_eliminar;
        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_soporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_conexiones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pb_ultravnc;
        private System.Windows.Forms.PictureBox pb_realvnc;
        private System.Windows.Forms.TextBox txt_solucion;
        private System.Windows.Forms.Label lbl_seleccionado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_guardarSolucion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgv_equiposConectados;
        private System.Windows.Forms.PictureBox pb_actualizarConectados;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_mensaje;
        private System.Windows.Forms.Button btn_notificacion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_mensaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pb_BuscarConFiltroEquiposConectados;
        private System.Windows.Forms.TextBox txt_filtroEquiposConectados;

    }
}