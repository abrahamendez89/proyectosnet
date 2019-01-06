namespace CuentasParaPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarUnMovimientoAUnaCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDeMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyecciónFuturaDeMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enviarUnCorreoAlDesarrolladorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desarrolladoPorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contenedorCuentasMovimientosFuturos1 = new CuentasParaPagar.ControlesDeUsuario.ContenedorCuentasMovimientosFuturos();
            this.contenedorSaldosAlDiaCuentas1 = new CuentasParaPagar.ControlesDeUsuario.ContenedorSaldosAlDiaCuentas();
            this.enviarAlCorreoUnRespaldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentasToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1358, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cuentasToolStripMenuItem
            // 
            this.cuentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarCuentaToolStripMenuItem,
            this.tiposDeMovimientosToolStripMenuItem});
            this.cuentasToolStripMenuItem.Name = "cuentasToolStripMenuItem";
            this.cuentasToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.cuentasToolStripMenuItem.Text = "Catálogos";
            // 
            // agregarCuentaToolStripMenuItem
            // 
            this.agregarCuentaToolStripMenuItem.Name = "agregarCuentaToolStripMenuItem";
            this.agregarCuentaToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.agregarCuentaToolStripMenuItem.Text = "Cuentas";
            this.agregarCuentaToolStripMenuItem.Click += new System.EventHandler(this.agregarCuentaToolStripMenuItem_Click);
            // 
            // tiposDeMovimientosToolStripMenuItem
            // 
            this.tiposDeMovimientosToolStripMenuItem.Name = "tiposDeMovimientosToolStripMenuItem";
            this.tiposDeMovimientosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.tiposDeMovimientosToolStripMenuItem.Text = "Tipos de movimientos";
            this.tiposDeMovimientosToolStripMenuItem.Click += new System.EventHandler(this.tiposDeMovimientosToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarUnMovimientoAUnaCuentaToolStripMenuItem,
            this.enviarAlCorreoUnRespaldoToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // registrarUnMovimientoAUnaCuentaToolStripMenuItem
            // 
            this.registrarUnMovimientoAUnaCuentaToolStripMenuItem.Name = "registrarUnMovimientoAUnaCuentaToolStripMenuItem";
            this.registrarUnMovimientoAUnaCuentaToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.registrarUnMovimientoAUnaCuentaToolStripMenuItem.Text = "Registrar un movimiento a una cuenta";
            this.registrarUnMovimientoAUnaCuentaToolStripMenuItem.Click += new System.EventHandler(this.registrarUnMovimientoAUnaCuentaToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialDeMovimientosToolStripMenuItem,
            this.proyecciónFuturaDeMovimientosToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // historialDeMovimientosToolStripMenuItem
            // 
            this.historialDeMovimientosToolStripMenuItem.Name = "historialDeMovimientosToolStripMenuItem";
            this.historialDeMovimientosToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.historialDeMovimientosToolStripMenuItem.Text = "Historial de movimientos";
            this.historialDeMovimientosToolStripMenuItem.Click += new System.EventHandler(this.historialDeMovimientosToolStripMenuItem_Click);
            // 
            // proyecciónFuturaDeMovimientosToolStripMenuItem
            // 
            this.proyecciónFuturaDeMovimientosToolStripMenuItem.Name = "proyecciónFuturaDeMovimientosToolStripMenuItem";
            this.proyecciónFuturaDeMovimientosToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.proyecciónFuturaDeMovimientosToolStripMenuItem.Text = "Proyección futura de movimientos";
            this.proyecciónFuturaDeMovimientosToolStripMenuItem.Click += new System.EventHandler(this.proyecciónFuturaDeMovimientosToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enviarUnCorreoAlDesarrolladorToolStripMenuItem,
            this.desarrolladoPorToolStripMenuItem});
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // enviarUnCorreoAlDesarrolladorToolStripMenuItem
            // 
            this.enviarUnCorreoAlDesarrolladorToolStripMenuItem.Name = "enviarUnCorreoAlDesarrolladorToolStripMenuItem";
            this.enviarUnCorreoAlDesarrolladorToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.enviarUnCorreoAlDesarrolladorToolStripMenuItem.Text = "Enviar un correo al desarrollador";
            this.enviarUnCorreoAlDesarrolladorToolStripMenuItem.Click += new System.EventHandler(this.enviarUnCorreoAlDesarrolladorToolStripMenuItem_Click);
            // 
            // desarrolladoPorToolStripMenuItem
            // 
            this.desarrolladoPorToolStripMenuItem.Name = "desarrolladoPorToolStripMenuItem";
            this.desarrolladoPorToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.desarrolladoPorToolStripMenuItem.Text = "Desarrollado por";
            this.desarrolladoPorToolStripMenuItem.Click += new System.EventHandler(this.desarrolladoPorToolStripMenuItem_Click);
            // 
            // contenedorCuentasMovimientosFuturos1
            // 
            this.contenedorCuentasMovimientosFuturos1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedorCuentasMovimientosFuturos1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contenedorCuentasMovimientosFuturos1.Location = new System.Drawing.Point(12, 28);
            this.contenedorCuentasMovimientosFuturos1.Name = "contenedorCuentasMovimientosFuturos1";
            this.contenedorCuentasMovimientosFuturos1.Size = new System.Drawing.Size(1130, 463);
            this.contenedorCuentasMovimientosFuturos1.TabIndex = 2;
            // 
            // contenedorSaldosAlDiaCuentas1
            // 
            this.contenedorSaldosAlDiaCuentas1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedorSaldosAlDiaCuentas1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contenedorSaldosAlDiaCuentas1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contenedorSaldosAlDiaCuentas1.Location = new System.Drawing.Point(1148, 28);
            this.contenedorSaldosAlDiaCuentas1.Name = "contenedorSaldosAlDiaCuentas1";
            this.contenedorSaldosAlDiaCuentas1.Size = new System.Drawing.Size(198, 463);
            this.contenedorSaldosAlDiaCuentas1.TabIndex = 1;
            // 
            // enviarAlCorreoUnRespaldoToolStripMenuItem
            // 
            this.enviarAlCorreoUnRespaldoToolStripMenuItem.Name = "enviarAlCorreoUnRespaldoToolStripMenuItem";
            this.enviarAlCorreoUnRespaldoToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.enviarAlCorreoUnRespaldoToolStripMenuItem.Text = "Enviar al correo un respaldo";
            this.enviarAlCorreoUnRespaldoToolStripMenuItem.Click += new System.EventHandler(this.enviarAlCorreoUnRespaldoToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 503);
            this.Controls.Add(this.contenedorCuentasMovimientosFuturos1);
            this.Controls.Add(this.contenedorSaldosAlDiaCuentas1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Principal_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarUnMovimientoAUnaCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDeMovimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeMovimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proyecciónFuturaDeMovimientosToolStripMenuItem;
        private ControlesDeUsuario.ContenedorSaldosAlDiaCuentas contenedorSaldosAlDiaCuentas1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarUnCorreoAlDesarrolladorToolStripMenuItem;
        private ControlesDeUsuario.ContenedorCuentasMovimientosFuturos contenedorCuentasMovimientosFuturos1;
        private System.Windows.Forms.ToolStripMenuItem desarrolladoPorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enviarAlCorreoUnRespaldoToolStripMenuItem;
    }
}

