namespace EjecutaBI
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_proceso_archivo = new System.Windows.Forms.TextBox();
            this.btn_buscarArchivo = new System.Windows.Forms.Button();
            this.lb_ejecucion = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pb_progreso = new System.Windows.Forms.ProgressBar();
            this.lbl_mensaje = new System.Windows.Forms.Label();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.tc_opciones = new System.Windows.Forms.TabControl();
            this.tp_EjecucionActual = new System.Windows.Forms.TabPage();
            this.btn_actualizarLog = new System.Windows.Forms.Button();
            this.btn_ejecutarProceso = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_procesosEjecucion = new System.Windows.Forms.ComboBox();
            this.tp_ConfiguracionProceso = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.chb_proceso_EnviarNotificaciones = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_proceso_correoNotificaciones = new System.Windows.Forms.TextBox();
            this.btn_proceso_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_proceso_actualizar = new System.Windows.Forms.Button();
            this.cmb_proceso_tipoServer = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_proceso_minutos = new System.Windows.Forms.ComboBox();
            this.cmb_proceso_hora = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chb_proceso_Agendado = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_proceso_nombre = new System.Windows.Forms.TextBox();
            this.btn_proceso_agregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_proceso_procesosRegistrados = new System.Windows.Forms.ComboBox();
            this.chb_detenerMonitoreo = new System.Windows.Forms.CheckBox();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuNotificacion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAbrirPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEnEjecucion = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCerrarPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tc_opciones.SuspendLayout();
            this.tp_EjecucionActual.SuspendLayout();
            this.tp_ConfiguracionProceso.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuNotificacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Archivo de proceso:";
            // 
            // txt_proceso_archivo
            // 
            this.txt_proceso_archivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_proceso_archivo.BackColor = System.Drawing.Color.White;
            this.txt_proceso_archivo.Location = new System.Drawing.Point(118, 57);
            this.txt_proceso_archivo.Name = "txt_proceso_archivo";
            this.txt_proceso_archivo.ReadOnly = true;
            this.txt_proceso_archivo.Size = new System.Drawing.Size(533, 20);
            this.txt_proceso_archivo.TabIndex = 2;
            // 
            // btn_buscarArchivo
            // 
            this.btn_buscarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buscarArchivo.Location = new System.Drawing.Point(657, 55);
            this.btn_buscarArchivo.Name = "btn_buscarArchivo";
            this.btn_buscarArchivo.Size = new System.Drawing.Size(61, 23);
            this.btn_buscarArchivo.TabIndex = 3;
            this.btn_buscarArchivo.Text = "Buscar";
            this.btn_buscarArchivo.UseVisualStyleBackColor = true;
            this.btn_buscarArchivo.Click += new System.EventHandler(this.btn_buscarArchivo_Click);
            // 
            // lb_ejecucion
            // 
            this.lb_ejecucion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ejecucion.FormattingEnabled = true;
            this.lb_ejecucion.HorizontalScrollbar = true;
            this.lb_ejecucion.Location = new System.Drawing.Point(6, 32);
            this.lb_ejecucion.Name = "lb_ejecucion";
            this.lb_ejecucion.Size = new System.Drawing.Size(814, 264);
            this.lb_ejecucion.TabIndex = 4;
            this.lb_ejecucion.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_ejecucion_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ejecutando:";
            // 
            // pb_progreso
            // 
            this.pb_progreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_progreso.Location = new System.Drawing.Point(6, 332);
            this.pb_progreso.Name = "pb_progreso";
            this.pb_progreso.Size = new System.Drawing.Size(733, 11);
            this.pb_progreso.TabIndex = 6;
            this.pb_progreso.Visible = false;
            // 
            // lbl_mensaje
            // 
            this.lbl_mensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_mensaje.AutoSize = true;
            this.lbl_mensaje.Location = new System.Drawing.Point(11, 311);
            this.lbl_mensaje.Name = "lbl_mensaje";
            this.lbl_mensaje.Size = new System.Drawing.Size(0, 13);
            this.lbl_mensaje.TabIndex = 7;
            this.lbl_mensaje.Visible = false;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancelar.Enabled = false;
            this.btn_cancelar.Location = new System.Drawing.Point(745, 321);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 24);
            this.btn_cancelar.TabIndex = 8;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // tc_opciones
            // 
            this.tc_opciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_opciones.Controls.Add(this.tp_EjecucionActual);
            this.tc_opciones.Controls.Add(this.tp_ConfiguracionProceso);
            this.tc_opciones.Location = new System.Drawing.Point(12, 12);
            this.tc_opciones.Name = "tc_opciones";
            this.tc_opciones.SelectedIndex = 0;
            this.tc_opciones.Size = new System.Drawing.Size(834, 377);
            this.tc_opciones.TabIndex = 9;
            // 
            // tp_EjecucionActual
            // 
            this.tp_EjecucionActual.Controls.Add(this.btn_actualizarLog);
            this.tp_EjecucionActual.Controls.Add(this.btn_ejecutarProceso);
            this.tp_EjecucionActual.Controls.Add(this.label3);
            this.tp_EjecucionActual.Controls.Add(this.cmb_procesosEjecucion);
            this.tp_EjecucionActual.Controls.Add(this.label2);
            this.tp_EjecucionActual.Controls.Add(this.lbl_mensaje);
            this.tp_EjecucionActual.Controls.Add(this.btn_cancelar);
            this.tp_EjecucionActual.Controls.Add(this.lb_ejecucion);
            this.tp_EjecucionActual.Controls.Add(this.pb_progreso);
            this.tp_EjecucionActual.Location = new System.Drawing.Point(4, 22);
            this.tp_EjecucionActual.Name = "tp_EjecucionActual";
            this.tp_EjecucionActual.Padding = new System.Windows.Forms.Padding(3);
            this.tp_EjecucionActual.Size = new System.Drawing.Size(826, 351);
            this.tp_EjecucionActual.TabIndex = 0;
            this.tp_EjecucionActual.Text = "Ejecución actual";
            this.tp_EjecucionActual.UseVisualStyleBackColor = true;
            // 
            // btn_actualizarLog
            // 
            this.btn_actualizarLog.Location = new System.Drawing.Point(98, 5);
            this.btn_actualizarLog.Name = "btn_actualizarLog";
            this.btn_actualizarLog.Size = new System.Drawing.Size(109, 23);
            this.btn_actualizarLog.TabIndex = 12;
            this.btn_actualizarLog.Text = "Actualizar Log";
            this.btn_actualizarLog.UseVisualStyleBackColor = true;
            this.btn_actualizarLog.Click += new System.EventHandler(this.btn_actualizarLog_Click);
            // 
            // btn_ejecutarProceso
            // 
            this.btn_ejecutarProceso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ejecutarProceso.Location = new System.Drawing.Point(698, 6);
            this.btn_ejecutarProceso.Name = "btn_ejecutarProceso";
            this.btn_ejecutarProceso.Size = new System.Drawing.Size(122, 23);
            this.btn_ejecutarProceso.TabIndex = 11;
            this.btn_ejecutarProceso.Text = "Ejecutar proceso";
            this.btn_ejecutarProceso.UseVisualStyleBackColor = true;
            this.btn_ejecutarProceso.Click += new System.EventHandler(this.btn_ejecutarProceso_Click_1);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Proceso:";
            // 
            // cmb_procesosEjecucion
            // 
            this.cmb_procesosEjecucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_procesosEjecucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_procesosEjecucion.FormattingEnabled = true;
            this.cmb_procesosEjecucion.Location = new System.Drawing.Point(365, 7);
            this.cmb_procesosEjecucion.Name = "cmb_procesosEjecucion";
            this.cmb_procesosEjecucion.Size = new System.Drawing.Size(327, 21);
            this.cmb_procesosEjecucion.TabIndex = 9;
            this.cmb_procesosEjecucion.SelectedIndexChanged += new System.EventHandler(this.cmb_procesosEjecucion_SelectedIndexChanged);
            // 
            // tp_ConfiguracionProceso
            // 
            this.tp_ConfiguracionProceso.Controls.Add(this.label11);
            this.tp_ConfiguracionProceso.Controls.Add(this.chb_proceso_EnviarNotificaciones);
            this.tp_ConfiguracionProceso.Controls.Add(this.label10);
            this.tp_ConfiguracionProceso.Controls.Add(this.txt_proceso_correoNotificaciones);
            this.tp_ConfiguracionProceso.Controls.Add(this.btn_proceso_guardar);
            this.tp_ConfiguracionProceso.Controls.Add(this.groupBox1);
            this.tp_ConfiguracionProceso.Controls.Add(this.btn_proceso_agregar);
            this.tp_ConfiguracionProceso.Controls.Add(this.label4);
            this.tp_ConfiguracionProceso.Controls.Add(this.cmb_proceso_procesosRegistrados);
            this.tp_ConfiguracionProceso.Location = new System.Drawing.Point(4, 22);
            this.tp_ConfiguracionProceso.Name = "tp_ConfiguracionProceso";
            this.tp_ConfiguracionProceso.Padding = new System.Windows.Forms.Padding(3);
            this.tp_ConfiguracionProceso.Size = new System.Drawing.Size(826, 351);
            this.tp_ConfiguracionProceso.TabIndex = 1;
            this.tp_ConfiguracionProceso.Text = "Configuración de procesos";
            this.tp_ConfiguracionProceso.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(560, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "(Separados por punto y coma \';\')";
            // 
            // chb_proceso_EnviarNotificaciones
            // 
            this.chb_proceso_EnviarNotificaciones.AutoSize = true;
            this.chb_proceso_EnviarNotificaciones.Location = new System.Drawing.Point(26, 51);
            this.chb_proceso_EnviarNotificaciones.Name = "chb_proceso_EnviarNotificaciones";
            this.chb_proceso_EnviarNotificaciones.Size = new System.Drawing.Size(175, 17);
            this.chb_proceso_EnviarNotificaciones.TabIndex = 20;
            this.chb_proceso_EnviarNotificaciones.Text = "Enviar notificaciones por correo";
            this.chb_proceso_EnviarNotificaciones.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(230, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Email(s):";
            // 
            // txt_proceso_correoNotificaciones
            // 
            this.txt_proceso_correoNotificaciones.Location = new System.Drawing.Point(277, 49);
            this.txt_proceso_correoNotificaciones.Name = "txt_proceso_correoNotificaciones";
            this.txt_proceso_correoNotificaciones.Size = new System.Drawing.Size(277, 20);
            this.txt_proceso_correoNotificaciones.TabIndex = 18;
            // 
            // btn_proceso_guardar
            // 
            this.btn_proceso_guardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_proceso_guardar.Location = new System.Drawing.Point(683, 15);
            this.btn_proceso_guardar.Name = "btn_proceso_guardar";
            this.btn_proceso_guardar.Size = new System.Drawing.Size(119, 23);
            this.btn_proceso_guardar.TabIndex = 13;
            this.btn_proceso_guardar.Text = "Guardar cambios";
            this.btn_proceso_guardar.UseVisualStyleBackColor = true;
            this.btn_proceso_guardar.Click += new System.EventHandler(this.btn_proceso_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btn_proceso_actualizar);
            this.groupBox1.Controls.Add(this.cmb_proceso_tipoServer);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmb_proceso_minutos);
            this.groupBox1.Controls.Add(this.cmb_proceso_hora);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chb_proceso_Agendado);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_proceso_nombre);
            this.groupBox1.Controls.Add(this.txt_proceso_archivo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_buscarArchivo);
            this.groupBox1.Location = new System.Drawing.Point(26, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 246);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del proceso seleccionado";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Hrs.";
            // 
            // btn_proceso_actualizar
            // 
            this.btn_proceso_actualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_proceso_actualizar.Location = new System.Drawing.Point(9, 217);
            this.btn_proceso_actualizar.Name = "btn_proceso_actualizar";
            this.btn_proceso_actualizar.Size = new System.Drawing.Size(119, 23);
            this.btn_proceso_actualizar.TabIndex = 14;
            this.btn_proceso_actualizar.Text = "Actualizar";
            this.btn_proceso_actualizar.UseVisualStyleBackColor = true;
            this.btn_proceso_actualizar.Click += new System.EventHandler(this.btn_proceso_actualizar_Click);
            // 
            // cmb_proceso_tipoServer
            // 
            this.cmb_proceso_tipoServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_proceso_tipoServer.FormattingEnabled = true;
            this.cmb_proceso_tipoServer.Items.AddRange(new object[] {
            "SQL SERVER",
            "FIREBIRD"});
            this.cmb_proceso_tipoServer.Location = new System.Drawing.Point(118, 109);
            this.cmb_proceso_tipoServer.Name = "cmb_proceso_tipoServer";
            this.cmb_proceso_tipoServer.Size = new System.Drawing.Size(121, 21);
            this.cmb_proceso_tipoServer.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tipo servidor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // cmb_proceso_minutos
            // 
            this.cmb_proceso_minutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_proceso_minutos.Enabled = false;
            this.cmb_proceso_minutos.FormattingEnabled = true;
            this.cmb_proceso_minutos.Location = new System.Drawing.Point(222, 80);
            this.cmb_proceso_minutos.Name = "cmb_proceso_minutos";
            this.cmb_proceso_minutos.Size = new System.Drawing.Size(53, 21);
            this.cmb_proceso_minutos.TabIndex = 9;
            // 
            // cmb_proceso_hora
            // 
            this.cmb_proceso_hora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_proceso_hora.Enabled = false;
            this.cmb_proceso_hora.FormattingEnabled = true;
            this.cmb_proceso_hora.Location = new System.Drawing.Point(154, 80);
            this.cmb_proceso_hora.Name = "cmb_proceso_hora";
            this.cmb_proceso_hora.Size = new System.Drawing.Size(53, 21);
            this.cmb_proceso_hora.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Agendar:";
            // 
            // chb_proceso_Agendado
            // 
            this.chb_proceso_Agendado.AutoSize = true;
            this.chb_proceso_Agendado.Location = new System.Drawing.Point(118, 85);
            this.chb_proceso_Agendado.Name = "chb_proceso_Agendado";
            this.chb_proceso_Agendado.Size = new System.Drawing.Size(15, 14);
            this.chb_proceso_Agendado.TabIndex = 6;
            this.chb_proceso_Agendado.UseVisualStyleBackColor = true;
            this.chb_proceso_Agendado.CheckedChanged += new System.EventHandler(this.chb_proceso_Agendado_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nombre:";
            // 
            // txt_proceso_nombre
            // 
            this.txt_proceso_nombre.Location = new System.Drawing.Point(118, 31);
            this.txt_proceso_nombre.Name = "txt_proceso_nombre";
            this.txt_proceso_nombre.Size = new System.Drawing.Size(277, 20);
            this.txt_proceso_nombre.TabIndex = 4;
            // 
            // btn_proceso_agregar
            // 
            this.btn_proceso_agregar.Location = new System.Drawing.Point(501, 15);
            this.btn_proceso_agregar.Name = "btn_proceso_agregar";
            this.btn_proceso_agregar.Size = new System.Drawing.Size(125, 23);
            this.btn_proceso_agregar.TabIndex = 6;
            this.btn_proceso_agregar.Text = "Agregar proceso";
            this.btn_proceso_agregar.UseVisualStyleBackColor = true;
            this.btn_proceso_agregar.Click += new System.EventHandler(this.btn_proceso_agregar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Proceso seleccionado:";
            // 
            // cmb_proceso_procesosRegistrados
            // 
            this.cmb_proceso_procesosRegistrados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_proceso_procesosRegistrados.FormattingEnabled = true;
            this.cmb_proceso_procesosRegistrados.Location = new System.Drawing.Point(144, 17);
            this.cmb_proceso_procesosRegistrados.Name = "cmb_proceso_procesosRegistrados";
            this.cmb_proceso_procesosRegistrados.Size = new System.Drawing.Size(340, 21);
            this.cmb_proceso_procesosRegistrados.TabIndex = 4;
            this.cmb_proceso_procesosRegistrados.SelectedIndexChanged += new System.EventHandler(this.cmb_proceso_procesosRegistrados_SelectedIndexChanged);
            // 
            // chb_detenerMonitoreo
            // 
            this.chb_detenerMonitoreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_detenerMonitoreo.AutoSize = true;
            this.chb_detenerMonitoreo.Location = new System.Drawing.Point(730, 12);
            this.chb_detenerMonitoreo.Name = "chb_detenerMonitoreo";
            this.chb_detenerMonitoreo.Size = new System.Drawing.Size(113, 17);
            this.chb_detenerMonitoreo.TabIndex = 10;
            this.chb_detenerMonitoreo.Text = "Detener monitoreo";
            this.chb_detenerMonitoreo.UseVisualStyleBackColor = true;
            // 
            // notify
            // 
            this.notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify.BalloonTipText = "La lista de procesos continuará con su ejecución normal, con doble click puedes r" +
    "estaurar la ventana.";
            this.notify.BalloonTipTitle = "Ejecuta BI";
            this.notify.ContextMenuStrip = this.menuNotificacion;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Ejecuta Procesos de BI";
            this.notify.Visible = true;
            this.notify.DoubleClick += new System.EventHandler(this.notify_DoubleClick);
            // 
            // menuNotificacion
            // 
            this.menuNotificacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbrirPrograma,
            this.itemEnEjecucion,
            this.itemCerrarPrograma});
            this.menuNotificacion.Name = "menuNotificacion";
            this.menuNotificacion.Size = new System.Drawing.Size(192, 70);
            // 
            // itemAbrirPrograma
            // 
            this.itemAbrirPrograma.Name = "itemAbrirPrograma";
            this.itemAbrirPrograma.Size = new System.Drawing.Size(191, 22);
            this.itemAbrirPrograma.Text = "Abrir programa";
            this.itemAbrirPrograma.Click += new System.EventHandler(this.itemAbrirPrograma_Click);
            // 
            // itemEnEjecucion
            // 
            this.itemEnEjecucion.Name = "itemEnEjecucion";
            this.itemEnEjecucion.Size = new System.Drawing.Size(191, 22);
            this.itemEnEjecucion.Text = "Procesos en ejecución";
            // 
            // itemCerrarPrograma
            // 
            this.itemCerrarPrograma.Name = "itemCerrarPrograma";
            this.itemCerrarPrograma.Size = new System.Drawing.Size(191, 22);
            this.itemCerrarPrograma.Text = "Cerrar programa";
            this.itemCerrarPrograma.Click += new System.EventHandler(this.itemCerrarPrograma_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 401);
            this.Controls.Add(this.chb_detenerMonitoreo);
            this.Controls.Add(this.tc_opciones);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ejecuta BI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tc_opciones.ResumeLayout(false);
            this.tp_EjecucionActual.ResumeLayout(false);
            this.tp_EjecucionActual.PerformLayout();
            this.tp_ConfiguracionProceso.ResumeLayout(false);
            this.tp_ConfiguracionProceso.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuNotificacion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_proceso_archivo;
        private System.Windows.Forms.Button btn_buscarArchivo;
        private System.Windows.Forms.ListBox lb_ejecucion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pb_progreso;
        private System.Windows.Forms.Label lbl_mensaje;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.TabControl tc_opciones;
        private System.Windows.Forms.TabPage tp_EjecucionActual;
        private System.Windows.Forms.TabPage tp_ConfiguracionProceso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_procesosEjecucion;
        private System.Windows.Forms.Button btn_ejecutarProceso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_proceso_procesosRegistrados;
        private System.Windows.Forms.Button btn_proceso_agregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_proceso_nombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chb_proceso_Agendado;
        private System.Windows.Forms.ComboBox cmb_proceso_hora;
        private System.Windows.Forms.ComboBox cmb_proceso_minutos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_proceso_tipoServer;
        private System.Windows.Forms.Button btn_proceso_guardar;
        private System.Windows.Forms.Button btn_proceso_actualizar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chb_detenerMonitoreo;
        private System.Windows.Forms.Button btn_actualizarLog;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_proceso_correoNotificaciones;
        private System.Windows.Forms.CheckBox chb_proceso_EnviarNotificaciones;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip menuNotificacion;
        private System.Windows.Forms.ToolStripMenuItem itemAbrirPrograma;
        private System.Windows.Forms.ToolStripMenuItem itemEnEjecucion;
        private System.Windows.Forms.ToolStripMenuItem itemCerrarPrograma;
    }
}

