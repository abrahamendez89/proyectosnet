namespace CuentasParaPagar.ControlesDeUsuario
{
    partial class ContenedorCuentasMovimientosFuturos
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_cuentas = new System.Windows.Forms.FlowLayoutPanel();
            this.movimientosFuturosDeCuenta3 = new CuentasParaPagar.ControlesDeUsuario.MovimientosFuturosDeCuenta();
            this.movimientosFuturosDeCuenta1 = new CuentasParaPagar.ControlesDeUsuario.MovimientosFuturosDeCuenta();
            this.movimientosFuturosDeCuenta2 = new CuentasParaPagar.ControlesDeUsuario.MovimientosFuturosDeCuenta();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_cuentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_cuentas
            // 
            this.pnl_cuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_cuentas.AutoScroll = true;
            this.pnl_cuentas.Controls.Add(this.movimientosFuturosDeCuenta3);
            this.pnl_cuentas.Controls.Add(this.movimientosFuturosDeCuenta1);
            this.pnl_cuentas.Controls.Add(this.movimientosFuturosDeCuenta2);
            this.pnl_cuentas.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_cuentas.Location = new System.Drawing.Point(14, 41);
            this.pnl_cuentas.Name = "pnl_cuentas";
            this.pnl_cuentas.Size = new System.Drawing.Size(1015, 414);
            this.pnl_cuentas.TabIndex = 0;
            this.pnl_cuentas.WrapContents = false;
            // 
            // movimientosFuturosDeCuenta3
            // 
            this.movimientosFuturosDeCuenta3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.movimientosFuturosDeCuenta3.HayMovimientos = false;
            this.movimientosFuturosDeCuenta3.Location = new System.Drawing.Point(3, 3);
            this.movimientosFuturosDeCuenta3.Name = "movimientosFuturosDeCuenta3";
            this.movimientosFuturosDeCuenta3.Size = new System.Drawing.Size(1005, 202);
            this.movimientosFuturosDeCuenta3.TabIndex = 2;
            // 
            // movimientosFuturosDeCuenta1
            // 
            this.movimientosFuturosDeCuenta1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.movimientosFuturosDeCuenta1.HayMovimientos = false;
            this.movimientosFuturosDeCuenta1.Location = new System.Drawing.Point(3, 211);
            this.movimientosFuturosDeCuenta1.Name = "movimientosFuturosDeCuenta1";
            this.movimientosFuturosDeCuenta1.Size = new System.Drawing.Size(1005, 202);
            this.movimientosFuturosDeCuenta1.TabIndex = 0;
            // 
            // movimientosFuturosDeCuenta2
            // 
            this.movimientosFuturosDeCuenta2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.movimientosFuturosDeCuenta2.HayMovimientos = false;
            this.movimientosFuturosDeCuenta2.Location = new System.Drawing.Point(3, 419);
            this.movimientosFuturosDeCuenta2.Name = "movimientosFuturosDeCuenta2";
            this.movimientosFuturosDeCuenta2.Size = new System.Drawing.Size(1005, 202);
            this.movimientosFuturosDeCuenta2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Calendario de movimientos para los próximos 7 días:";
            // 
            // ContenedorCuentasMovimientosFuturos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_cuentas);
            this.Name = "ContenedorCuentasMovimientosFuturos";
            this.Size = new System.Drawing.Size(1043, 469);
            this.pnl_cuentas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnl_cuentas;
        private MovimientosFuturosDeCuenta movimientosFuturosDeCuenta3;
        private MovimientosFuturosDeCuenta movimientosFuturosDeCuenta1;
        private MovimientosFuturosDeCuenta movimientosFuturosDeCuenta2;
        private System.Windows.Forms.Label label1;
    }
}
