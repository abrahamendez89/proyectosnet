namespace CuentasParaPagar.ControlesDeUsuario
{
    partial class ContenedorSaldosAlDiaCuentas
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
            this.label1 = new System.Windows.Forms.Label();
            this.saldoAlDiaCuenta1 = new CuentasParaPagar.ControlesDeUsuario.SaldoAlDiaCuenta();
            this.saldoAlDiaCuenta2 = new CuentasParaPagar.ControlesDeUsuario.SaldoAlDiaCuenta();
            this.pnl_cuentas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_cuentas
            // 
            this.pnl_cuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_cuentas.AutoScroll = true;
            this.pnl_cuentas.Controls.Add(this.saldoAlDiaCuenta1);
            this.pnl_cuentas.Controls.Add(this.saldoAlDiaCuenta2);
            this.pnl_cuentas.Location = new System.Drawing.Point(3, 49);
            this.pnl_cuentas.Name = "pnl_cuentas";
            this.pnl_cuentas.Size = new System.Drawing.Size(228, 393);
            this.pnl_cuentas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Saldos al día de hoy:";
            // 
            // saldoAlDiaCuenta1
            // 
            this.saldoAlDiaCuenta1.BackColor = System.Drawing.Color.Beige;
            this.saldoAlDiaCuenta1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saldoAlDiaCuenta1.Location = new System.Drawing.Point(3, 3);
            this.saldoAlDiaCuenta1.Name = "saldoAlDiaCuenta1";
            this.saldoAlDiaCuenta1.Size = new System.Drawing.Size(194, 181);
            this.saldoAlDiaCuenta1.TabIndex = 0;
            // 
            // saldoAlDiaCuenta2
            // 
            this.saldoAlDiaCuenta2.BackColor = System.Drawing.Color.Beige;
            this.saldoAlDiaCuenta2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saldoAlDiaCuenta2.Location = new System.Drawing.Point(3, 190);
            this.saldoAlDiaCuenta2.Name = "saldoAlDiaCuenta2";
            this.saldoAlDiaCuenta2.Size = new System.Drawing.Size(194, 181);
            this.saldoAlDiaCuenta2.TabIndex = 1;
            // 
            // ContenedorSaldosAlDiaCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_cuentas);
            this.Name = "ContenedorSaldosAlDiaCuentas";
            this.Size = new System.Drawing.Size(234, 445);
            this.pnl_cuentas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnl_cuentas;
        private SaldoAlDiaCuenta saldoAlDiaCuenta1;
        private SaldoAlDiaCuenta saldoAlDiaCuenta2;
        private System.Windows.Forms.Label label1;
    }
}
