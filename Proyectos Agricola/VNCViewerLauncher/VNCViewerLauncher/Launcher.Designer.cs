namespace VNCViewerLauncher
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.lv_iconos = new System.Windows.Forms.ListView();
            this.btn_AgregarPC = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lv_iconos
            // 
            this.lv_iconos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_iconos.Location = new System.Drawing.Point(3, 32);
            this.lv_iconos.Name = "lv_iconos";
            this.lv_iconos.Size = new System.Drawing.Size(669, 274);
            this.lv_iconos.TabIndex = 0;
            this.lv_iconos.UseCompatibleStateImageBehavior = false;
            // 
            // btn_AgregarPC
            // 
            this.btn_AgregarPC.Location = new System.Drawing.Point(3, 5);
            this.btn_AgregarPC.Name = "btn_AgregarPC";
            this.btn_AgregarPC.Size = new System.Drawing.Size(75, 21);
            this.btn_AgregarPC.TabIndex = 2;
            this.btn_AgregarPC.Text = "Agregar PC";
            this.btn_AgregarPC.UseVisualStyleBackColor = true;
            this.btn_AgregarPC.Click += new System.EventHandler(this.btn_AgregarPC_Click);
            // 
            // menu
            // 
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtro:";
            // 
            // txt_filtro
            // 
            this.txt_filtro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_filtro.Location = new System.Drawing.Point(501, 6);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(168, 20);
            this.txt_filtro.TabIndex = 5;
            this.txt_filtro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filtro_KeyDown);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 311);
            this.Controls.Add(this.txt_filtro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_AgregarPC);
            this.Controls.Add(this.lv_iconos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Equipos registrados con RealVNC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_iconos;
        private System.Windows.Forms.Button btn_AgregarPC;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_filtro;
    }
}

