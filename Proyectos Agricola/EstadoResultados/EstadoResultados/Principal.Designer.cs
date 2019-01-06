namespace EstadoResultados
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.catálogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaciónDeEstadoDeResultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogoBeneficiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailsDeNotifiaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecuciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejecutarConstrucciónDeFuentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuContextualSystemTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirProgramaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminarEjecuciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.menuContextualSystemTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catálogosToolStripMenuItem,
            this.configuraciónToolStripMenuItem,
            this.ejecuciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(825, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // catálogosToolStripMenuItem
            // 
            this.catálogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaciónDeEstadoDeResultadosToolStripMenuItem,
            this.catálogoBeneficiosToolStripMenuItem});
            this.catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            this.catálogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.catálogosToolStripMenuItem.Text = "Catálogos";
            // 
            // creaciónDeEstadoDeResultadosToolStripMenuItem
            // 
            this.creaciónDeEstadoDeResultadosToolStripMenuItem.Name = "creaciónDeEstadoDeResultadosToolStripMenuItem";
            this.creaciónDeEstadoDeResultadosToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.creaciónDeEstadoDeResultadosToolStripMenuItem.Text = "Creación de estado de resultados";
            this.creaciónDeEstadoDeResultadosToolStripMenuItem.Click += new System.EventHandler(this.creaciónDeEstadoDeResultadosToolStripMenuItem_Click);
            // 
            // catálogoBeneficiosToolStripMenuItem
            // 
            this.catálogoBeneficiosToolStripMenuItem.Name = "catálogoBeneficiosToolStripMenuItem";
            this.catálogoBeneficiosToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.catálogoBeneficiosToolStripMenuItem.Text = "Catálogo beneficios";
            this.catálogoBeneficiosToolStripMenuItem.Click += new System.EventHandler(this.catálogoBeneficiosToolStripMenuItem_Click);
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem,
            this.emailsDeNotifiaciónToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem
            // 
            this.agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem.Name = "agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem";
            this.agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem.Size = new System.Drawing.Size(344, 22);
            this.agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem.Text = "Agendado de construcción de estado de resultados";
            this.agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem.Click += new System.EventHandler(this.agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem_Click);
            // 
            // emailsDeNotifiaciónToolStripMenuItem
            // 
            this.emailsDeNotifiaciónToolStripMenuItem.Name = "emailsDeNotifiaciónToolStripMenuItem";
            this.emailsDeNotifiaciónToolStripMenuItem.Size = new System.Drawing.Size(344, 22);
            this.emailsDeNotifiaciónToolStripMenuItem.Text = "Emails de notifiación";
            this.emailsDeNotifiaciónToolStripMenuItem.Click += new System.EventHandler(this.emailsDeNotifiaciónToolStripMenuItem_Click);
            // 
            // ejecuciónToolStripMenuItem
            // 
            this.ejecuciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejecutarConstrucciónDeFuentesToolStripMenuItem});
            this.ejecuciónToolStripMenuItem.Name = "ejecuciónToolStripMenuItem";
            this.ejecuciónToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.ejecuciónToolStripMenuItem.Text = "Ejecución";
            // 
            // ejecutarConstrucciónDeFuentesToolStripMenuItem
            // 
            this.ejecutarConstrucciónDeFuentesToolStripMenuItem.Name = "ejecutarConstrucciónDeFuentesToolStripMenuItem";
            this.ejecutarConstrucciónDeFuentesToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.ejecutarConstrucciónDeFuentesToolStripMenuItem.Text = "Ejecutar construcción de fuentes";
            this.ejecutarConstrucciónDeFuentesToolStripMenuItem.Click += new System.EventHandler(this.ejecutarConstrucciónDeFuentesToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuContextualSystemTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Servicio para generación de estado de resultados.";
            this.notifyIcon.Visible = true;
            // 
            // menuContextualSystemTray
            // 
            this.menuContextualSystemTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirProgramaToolStripMenuItem,
            this.terminarEjecuciónToolStripMenuItem});
            this.menuContextualSystemTray.Name = "menuContextualSystemTray";
            this.menuContextualSystemTray.Size = new System.Drawing.Size(162, 70);
            // 
            // abrirProgramaToolStripMenuItem
            // 
            this.abrirProgramaToolStripMenuItem.Name = "abrirProgramaToolStripMenuItem";
            this.abrirProgramaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.abrirProgramaToolStripMenuItem.Text = "Abrir programa";
            this.abrirProgramaToolStripMenuItem.Click += new System.EventHandler(this.abrirProgramaToolStripMenuItem_Click_1);
            // 
            // terminarEjecuciónToolStripMenuItem
            // 
            this.terminarEjecuciónToolStripMenuItem.Name = "terminarEjecuciónToolStripMenuItem";
            this.terminarEjecuciónToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.terminarEjecuciónToolStripMenuItem.Text = "Cerrar programa";
            this.terminarEjecuciónToolStripMenuItem.Click += new System.EventHandler(this.terminarEjecuciónToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 280);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de configuración para generación de estado de resultados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuContextualSystemTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catálogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaciónDeEstadoDeResultadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agendadoDeConstrucciónDeEstadoDeResultadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailsDeNotifiaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecuciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejecutarConstrucciónDeFuentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catálogoBeneficiosToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menuContextualSystemTray;
        private System.Windows.Forms.ToolStripMenuItem abrirProgramaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminarEjecuciónToolStripMenuItem;
    }
}

