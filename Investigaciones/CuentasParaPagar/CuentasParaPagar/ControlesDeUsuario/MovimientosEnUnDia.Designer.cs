namespace CuentasParaPagar.ControlesDeUsuario
{
    partial class MovimientosEnUnDia
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
            this.components = new System.ComponentModel.Container();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.pnl_movimientos = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pb_imagen = new System.Windows.Forms.PictureBox();
            this.pnl_movimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha.Location = new System.Drawing.Point(3, 122);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(140, 13);
            this.lbl_fecha.TabIndex = 1;
            this.lbl_fecha.Text = "Miercoles 25 de Agosto";
            // 
            // pnl_movimientos
            // 
            this.pnl_movimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_movimientos.AutoScroll = true;
            this.pnl_movimientos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_movimientos.Controls.Add(this.textBox1);
            this.pnl_movimientos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_movimientos.Location = new System.Drawing.Point(3, 11);
            this.pnl_movimientos.Name = "pnl_movimientos";
            this.pnl_movimientos.Size = new System.Drawing.Size(153, 104);
            this.pnl_movimientos.TabIndex = 2;
            this.pnl_movimientos.WrapContents = false;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "asdasdasd";
            // 
            // pb_imagen
            // 
            this.pb_imagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_imagen.Image = global::CuentasParaPagar.Properties.Resources._1441085724_sign_free_red;
            this.pb_imagen.Location = new System.Drawing.Point(44, 49);
            this.pb_imagen.Name = "pb_imagen";
            this.pb_imagen.Size = new System.Drawing.Size(62, 47);
            this.pb_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_imagen.TabIndex = 1;
            this.pb_imagen.TabStop = false;
            // 
            // MovimientosEnUnDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_movimientos);
            this.Controls.Add(this.pb_imagen);
            this.Controls.Add(this.lbl_fecha);
            this.Name = "MovimientosEnUnDia";
            this.Size = new System.Drawing.Size(159, 148);
            this.pnl_movimientos.ResumeLayout(false);
            this.pnl_movimientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_imagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.FlowLayoutPanel pnl_movimientos;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pb_imagen;

    }
}
