namespace ContabilidadElectronica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tp_forms = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_Empresas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_menu = new System.Windows.Forms.FlowLayoutPanel();
            this.eCatalogo = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eBalanzaComprobacion = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eLigadoCuentas = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eGeneracionXMLCatalogoCuentas = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eGeneracionXMLPolizas = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eUnirXMLPolizas = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eReporteFacturasSinXML = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eCatalogoBancos = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eCatalogoFormasPago = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.eCatalogoMonedas = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.pb_cerrarTab = new System.Windows.Forms.PictureBox();
            this.pb_fondo = new System.Windows.Forms.PictureBox();
            this.eVisorXML345 = new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu();
            this.panel1.SuspendLayout();
            this.pnl_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cerrarTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fondo)).BeginInit();
            this.SuspendLayout();
            // 
            // tp_forms
            // 
            this.tp_forms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tp_forms.Location = new System.Drawing.Point(123, 12);
            this.tp_forms.Name = "tp_forms";
            this.tp_forms.SelectedIndex = 0;
            this.tp_forms.Size = new System.Drawing.Size(713, 534);
            this.tp_forms.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmb_Empresas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 547);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 30);
            this.panel1.TabIndex = 2;
            // 
            // cmb_Empresas
            // 
            this.cmb_Empresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Empresas.DropDownWidth = 340;
            this.cmb_Empresas.FormattingEnabled = true;
            this.cmb_Empresas.Location = new System.Drawing.Point(143, 4);
            this.cmb_Empresas.Name = "cmb_Empresas";
            this.cmb_Empresas.Size = new System.Drawing.Size(281, 21);
            this.cmb_Empresas.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa seleccionada:";
            // 
            // pnl_menu
            // 
            this.pnl_menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_menu.AutoScroll = true;
            this.pnl_menu.BackColor = System.Drawing.Color.White;
            this.pnl_menu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_menu.Controls.Add(this.eCatalogo);
            this.pnl_menu.Controls.Add(this.eBalanzaComprobacion);
            this.pnl_menu.Controls.Add(this.eLigadoCuentas);
            this.pnl_menu.Controls.Add(this.eGeneracionXMLCatalogoCuentas);
            this.pnl_menu.Controls.Add(this.eGeneracionXMLPolizas);
            this.pnl_menu.Controls.Add(this.eUnirXMLPolizas);
            this.pnl_menu.Controls.Add(this.eVisorXML345);
            this.pnl_menu.Controls.Add(this.eReporteFacturasSinXML);
            this.pnl_menu.Controls.Add(this.eCatalogoBancos);
            this.pnl_menu.Controls.Add(this.eCatalogoFormasPago);
            this.pnl_menu.Controls.Add(this.eCatalogoMonedas);
            this.pnl_menu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_menu.Location = new System.Drawing.Point(7, 10);
            this.pnl_menu.Name = "pnl_menu";
            this.pnl_menu.Size = new System.Drawing.Size(118, 536);
            this.pnl_menu.TabIndex = 4;
            this.pnl_menu.WrapContents = false;
            // 
            // eCatalogo
            // 
            this.eCatalogo.Imagen = global::ContabilidadElectronica.Properties.Resources._1403902514_onebit_39;
            this.eCatalogo.Location = new System.Drawing.Point(3, 3);
            this.eCatalogo.Name = "eCatalogo";
            this.eCatalogo.Size = new System.Drawing.Size(75, 71);
            this.eCatalogo.TabIndex = 0;
            this.eCatalogo.Titulo = "Importar catálogos SAT de Excel";
            // 
            // eBalanzaComprobacion
            // 
            this.eBalanzaComprobacion.Imagen = global::ContabilidadElectronica.Properties.Resources._1408401789_Business;
            this.eBalanzaComprobacion.Location = new System.Drawing.Point(3, 80);
            this.eBalanzaComprobacion.Name = "eBalanzaComprobacion";
            this.eBalanzaComprobacion.Size = new System.Drawing.Size(75, 71);
            this.eBalanzaComprobacion.TabIndex = 1;
            this.eBalanzaComprobacion.Titulo = "Balanza de comprobación";
            this.eBalanzaComprobacion.doubleClickCustom += new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu.DoubleClickCustom(this.eBalanzaComprobacion_doubleClickCustom);
            // 
            // eLigadoCuentas
            // 
            this.eLigadoCuentas.Imagen = global::ContabilidadElectronica.Properties.Resources._1424385331_edit_file;
            this.eLigadoCuentas.Location = new System.Drawing.Point(3, 157);
            this.eLigadoCuentas.Name = "eLigadoCuentas";
            this.eLigadoCuentas.Size = new System.Drawing.Size(75, 71);
            this.eLigadoCuentas.TabIndex = 4;
            this.eLigadoCuentas.Titulo = "Ligado de cuentas contables con agrupador SAT";
            this.eLigadoCuentas.doubleClickCustom += new ContabilidadElectronica.ControlesDeUsuario.ElementoMenu.DoubleClickCustom(this.eLigadoCuentas_doubleClickCustom);
            // 
            // eGeneracionXMLCatalogoCuentas
            // 
            this.eGeneracionXMLCatalogoCuentas.Imagen = global::ContabilidadElectronica.Properties.Resources._1425075450_XML;
            this.eGeneracionXMLCatalogoCuentas.Location = new System.Drawing.Point(3, 234);
            this.eGeneracionXMLCatalogoCuentas.Name = "eGeneracionXMLCatalogoCuentas";
            this.eGeneracionXMLCatalogoCuentas.Size = new System.Drawing.Size(75, 71);
            this.eGeneracionXMLCatalogoCuentas.TabIndex = 5;
            this.eGeneracionXMLCatalogoCuentas.Titulo = "Generación de XML con cuentas contables";
            // 
            // eGeneracionXMLPolizas
            // 
            this.eGeneracionXMLPolizas.Imagen = global::ContabilidadElectronica.Properties.Resources._1442091504_application_xml;
            this.eGeneracionXMLPolizas.Location = new System.Drawing.Point(3, 311);
            this.eGeneracionXMLPolizas.Name = "eGeneracionXMLPolizas";
            this.eGeneracionXMLPolizas.Size = new System.Drawing.Size(75, 71);
            this.eGeneracionXMLPolizas.TabIndex = 9;
            this.eGeneracionXMLPolizas.Titulo = "Generación de XML Polizas";
            // 
            // eUnirXMLPolizas
            // 
            this.eUnirXMLPolizas.Imagen = global::ContabilidadElectronica.Properties.Resources._1450335171_merge;
            this.eUnirXMLPolizas.Location = new System.Drawing.Point(3, 388);
            this.eUnirXMLPolizas.Name = "eUnirXMLPolizas";
            this.eUnirXMLPolizas.Size = new System.Drawing.Size(75, 71);
            this.eUnirXMLPolizas.TabIndex = 10;
            this.eUnirXMLPolizas.Titulo = "Unir XML Pólizas";
            // 
            // eReporteFacturasSinXML
            // 
            this.eReporteFacturasSinXML.Imagen = global::ContabilidadElectronica.Properties.Resources._1450481946_reports;
            this.eReporteFacturasSinXML.Location = new System.Drawing.Point(3, 542);
            this.eReporteFacturasSinXML.Name = "eReporteFacturasSinXML";
            this.eReporteFacturasSinXML.Size = new System.Drawing.Size(75, 71);
            this.eReporteFacturasSinXML.TabIndex = 11;
            this.eReporteFacturasSinXML.Titulo = "Reporte Facturas SIN XML";
            // 
            // eCatalogoBancos
            // 
            this.eCatalogoBancos.Imagen = global::ContabilidadElectronica.Properties.Resources._1441741251_Bank;
            this.eCatalogoBancos.Location = new System.Drawing.Point(3, 619);
            this.eCatalogoBancos.Name = "eCatalogoBancos";
            this.eCatalogoBancos.Size = new System.Drawing.Size(75, 71);
            this.eCatalogoBancos.TabIndex = 6;
            this.eCatalogoBancos.Titulo = "Catálogo Bancos";
            // 
            // eCatalogoFormasPago
            // 
            this.eCatalogoFormasPago.Imagen = global::ContabilidadElectronica.Properties.Resources._1441764734_Purse;
            this.eCatalogoFormasPago.Location = new System.Drawing.Point(3, 696);
            this.eCatalogoFormasPago.Name = "eCatalogoFormasPago";
            this.eCatalogoFormasPago.Size = new System.Drawing.Size(75, 71);
            this.eCatalogoFormasPago.TabIndex = 7;
            this.eCatalogoFormasPago.Titulo = "Catálogo Formas pago";
            // 
            // eCatalogoMonedas
            // 
            this.eCatalogoMonedas.Imagen = global::ContabilidadElectronica.Properties.Resources._1441767212_coin_search;
            this.eCatalogoMonedas.Location = new System.Drawing.Point(3, 773);
            this.eCatalogoMonedas.Name = "eCatalogoMonedas";
            this.eCatalogoMonedas.Size = new System.Drawing.Size(75, 71);
            this.eCatalogoMonedas.TabIndex = 8;
            this.eCatalogoMonedas.Titulo = "Catálogo Monedas";
            // 
            // pb_cerrarTab
            // 
            this.pb_cerrarTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_cerrarTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_cerrarTab.Image = global::ContabilidadElectronica.Properties.Resources._1403562203_Close_Box_Red;
            this.pb_cerrarTab.Location = new System.Drawing.Point(808, 10);
            this.pb_cerrarTab.Name = "pb_cerrarTab";
            this.pb_cerrarTab.Size = new System.Drawing.Size(25, 25);
            this.pb_cerrarTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_cerrarTab.TabIndex = 0;
            this.pb_cerrarTab.TabStop = false;
            // 
            // pb_fondo
            // 
            this.pb_fondo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_fondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_fondo.Image = global::ContabilidadElectronica.Properties.Resources.contabilidad;
            this.pb_fondo.Location = new System.Drawing.Point(123, 11);
            this.pb_fondo.Name = "pb_fondo";
            this.pb_fondo.Size = new System.Drawing.Size(713, 535);
            this.pb_fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_fondo.TabIndex = 3;
            this.pb_fondo.TabStop = false;
            // 
            // eVisorXML345
            // 
            this.eVisorXML345.Imagen = global::ContabilidadElectronica.Properties.Resources._1446064182_magnifier;
            this.eVisorXML345.Location = new System.Drawing.Point(3, 465);
            this.eVisorXML345.Name = "eVisorXML345";
            this.eVisorXML345.Size = new System.Drawing.Size(75, 71);
            this.eVisorXML345.TabIndex = 12;
            this.eVisorXML345.Titulo = "Visor XML 345";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(840, 577);
            this.Controls.Add(this.pnl_menu);
            this.Controls.Add(this.pb_cerrarTab);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tp_forms);
            this.Controls.Add(this.pb_fondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contabilidad electronica";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_cerrarTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fondo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesDeUsuario.ElementoMenu eCatalogo;
        private ControlesDeUsuario.ElementoMenu eBalanzaComprobacion;
        private System.Windows.Forms.TabControl tp_forms;
        private System.Windows.Forms.PictureBox pb_cerrarTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Empresas;
        private System.Windows.Forms.PictureBox pb_fondo;
        private ControlesDeUsuario.ElementoMenu eLigadoCuentas;
        private ControlesDeUsuario.ElementoMenu eGeneracionXMLCatalogoCuentas;
        private ControlesDeUsuario.ElementoMenu eCatalogoBancos;
        private System.Windows.Forms.FlowLayoutPanel pnl_menu;
        private ControlesDeUsuario.ElementoMenu eCatalogoFormasPago;
        private ControlesDeUsuario.ElementoMenu eCatalogoMonedas;
        private ControlesDeUsuario.ElementoMenu eGeneracionXMLPolizas;
        private ControlesDeUsuario.ElementoMenu eUnirXMLPolizas;
        private ControlesDeUsuario.ElementoMenu eReporteFacturasSinXML;
        private ControlesDeUsuario.ElementoMenu eVisorXML345;
    }
}