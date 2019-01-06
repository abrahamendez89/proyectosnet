using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sistema.Pruebas
{
	/// <summary>
	/// Forma de Prueba Numero 1
	/// </summary>
	public class frmPrueba : System.Windows.Forms.Form
	{
		#region Atributos 		
		
		#endregion //Atributos 
		
		#region Controles 

		private System.Windows.Forms.GroupBox grpMetaCatalogo;

        private Sistema.AccTextBox txtMetacatalogo;
		private System.Windows.Forms.Label lblCampos;
		private System.Windows.Forms.ListView lstCampos;

		private System.Windows.Forms.GroupBox grpCatalogo;
		private System.Windows.Forms.Button btnSetCatalogo;

		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
        private Sistema.AccTextBox txtCategoria;
        private Sistema.AccTextBox txtSupplier;
        private Sistema.AccTextBox txtProducto;	
		
		private System.Windows.Forms.TextBox txtDescCategoria;
		private System.Windows.Forms.TextBox txtDescProducto;		
		private System.Windows.Forms.Label lblSupplier;		
		private System.Windows.Forms.ListView lstRegistros;
		private System.Windows.Forms.Button btnProductos;
		private System.Windows.Forms.Button btnCategorias;
        private Sistema.AccTextBox txtSuperCategoria;
		private System.Windows.Forms.TextBox txtDescSuperCategoria;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSuperCategorias;
		

		private System.ComponentModel.Container components = null;
		
		#endregion //Controles

		#region Constructor 

		public frmPrueba()
		{
			InitializeComponent();			
		}

		#endregion //Constructor 

		#region Destructor

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion //Destructor

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grpCatalogo = new System.Windows.Forms.GroupBox();
            this.txtSuperCategoria = new Sistema.AccTextBox();
			this.txtDescSuperCategoria = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
            this.txtCategoria = new Sistema.AccTextBox();
			this.txtDescCategoria = new System.Windows.Forms.TextBox();
			this.btnSuperCategorias = new System.Windows.Forms.Button();
			this.btnCategorias = new System.Windows.Forms.Button();
			this.btnProductos = new System.Windows.Forms.Button();
			this.txtSupplier = new Sistema.AccTextBox();
			this.lblSupplier = new System.Windows.Forms.Label();
            this.txtProducto = new Sistema.AccTextBox();
			this.txtDescProducto = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lstRegistros = new System.Windows.Forms.ListView();
			this.grpMetaCatalogo = new System.Windows.Forms.GroupBox();
			this.lblCampos = new System.Windows.Forms.Label();
			this.lstCampos = new System.Windows.Forms.ListView();
			this.btnSetCatalogo = new System.Windows.Forms.Button();
            this.txtMetacatalogo = new Sistema.AccTextBox();
			this.grpCatalogo.SuspendLayout();
			this.grpMetaCatalogo.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpCatalogo
			// 
			this.grpCatalogo.Controls.Add(this.txtSuperCategoria);
			this.grpCatalogo.Controls.Add(this.txtDescSuperCategoria);
			this.grpCatalogo.Controls.Add(this.label1);
			this.grpCatalogo.Controls.Add(this.txtCategoria);
			this.grpCatalogo.Controls.Add(this.btnSuperCategorias);
			this.grpCatalogo.Controls.Add(this.btnCategorias);
			this.grpCatalogo.Controls.Add(this.btnProductos);
			this.grpCatalogo.Controls.Add(this.txtSupplier);
			this.grpCatalogo.Controls.Add(this.txtProducto);
			this.grpCatalogo.Controls.Add(this.txtDescCategoria);
			this.grpCatalogo.Controls.Add(this.label4);
			this.grpCatalogo.Controls.Add(this.label3);
			this.grpCatalogo.Controls.Add(this.label2);
			this.grpCatalogo.Controls.Add(this.lblSupplier);
			this.grpCatalogo.Controls.Add(this.txtDescProducto);
			this.grpCatalogo.Controls.Add(this.lstRegistros);
			this.grpCatalogo.Location = new System.Drawing.Point(304, 16);
			this.grpCatalogo.Name = "grpCatalogo";
			this.grpCatalogo.Size = new System.Drawing.Size(328, 360);
			this.grpCatalogo.TabIndex = 14;
			this.grpCatalogo.TabStop = false;
			this.grpCatalogo.Text = "Catalogo";
			// 
			// txtSuperCategoria
			// 
			this.txtSuperCategoria.CadenaDescripcionNoValida = "";
			this.txtSuperCategoria.CatalogoBase = null;
			this.txtSuperCategoria.ControlDestinoDescripcion = this.txtDescSuperCategoria;
			this.txtSuperCategoria.Location = new System.Drawing.Point(112, 24);
			this.txtSuperCategoria.Name = "txtSuperCategoria";
			this.txtSuperCategoria.Size = new System.Drawing.Size(53, 20);
			this.txtSuperCategoria.TabIndex = 1;
			this.txtSuperCategoria.Text = "";
			// 
			// txtDescSuperCategoria
			// 
			this.txtDescSuperCategoria.Location = new System.Drawing.Point(176, 24);
			this.txtDescSuperCategoria.Name = "txtDescSuperCategoria";
			this.txtDescSuperCategoria.Size = new System.Drawing.Size(136, 20);
			this.txtDescSuperCategoria.TabIndex = 5;
			this.txtDescSuperCategoria.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 17);
			this.label1.TabIndex = 33;
			this.label1.Text = "SuperCategorias";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCategoria
			// 
			this.txtCategoria.CadenaDescripcionNoValida = "";
			this.txtCategoria.CatalogoBase = null;
			this.txtCategoria.ControlDestinoDescripcion = this.txtDescCategoria;
			this.txtCategoria.Location = new System.Drawing.Point(112, 56);
			this.txtCategoria.Name = "txtCategoria";
			this.txtCategoria.Size = new System.Drawing.Size(53, 20);
			this.txtCategoria.TabIndex = 2;
			this.txtCategoria.Text = "";
			// 
			// txtDescCategoria
			// 
			this.txtDescCategoria.Location = new System.Drawing.Point(176, 56);
			this.txtDescCategoria.Name = "txtDescCategoria";
			this.txtDescCategoria.Size = new System.Drawing.Size(136, 20);
			this.txtDescCategoria.TabIndex = 6;
			this.txtDescCategoria.Text = "";
			// 
			// btnSuperCategorias
			// 
			this.btnSuperCategorias.Location = new System.Drawing.Point(8, 200);
			this.btnSuperCategorias.Name = "btnSuperCategorias";
			this.btnSuperCategorias.Size = new System.Drawing.Size(104, 24);
			this.btnSuperCategorias.TabIndex = 31;
			this.btnSuperCategorias.Text = "SuperCategorias";
			this.btnSuperCategorias.Click += new System.EventHandler(this.btnSuperCategorias_Click);
			// 
			// btnCategorias
			// 
			this.btnCategorias.Location = new System.Drawing.Point(112, 200);
			this.btnCategorias.Name = "btnCategorias";
			this.btnCategorias.Size = new System.Drawing.Size(104, 24);
			this.btnCategorias.TabIndex = 30;
			this.btnCategorias.Text = "Categorias";
			this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click_1);
			// 
			// btnProductos
			// 
			this.btnProductos.Location = new System.Drawing.Point(216, 200);
			this.btnProductos.Name = "btnProductos";
			this.btnProductos.Size = new System.Drawing.Size(104, 24);
			this.btnProductos.TabIndex = 29;
			this.btnProductos.Text = "Productos";
			this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
			// 
			// txtSupplier
			// 
			this.txtSupplier.CadenaDescripcionNoValida = "";
			this.txtSupplier.CatalogoBase = null;
			this.txtSupplier.ControlDestinoDescripcion = this.lblSupplier;
			this.txtSupplier.Location = new System.Drawing.Point(112, 88);
			this.txtSupplier.Name = "txtSupplier";
			this.txtSupplier.Size = new System.Drawing.Size(53, 20);
			this.txtSupplier.TabIndex = 3;
			this.txtSupplier.Text = "";
			// 
			// lblSupplier
			// 
			this.lblSupplier.Location = new System.Drawing.Point(176, 88);
			this.lblSupplier.Name = "lblSupplier";
			this.lblSupplier.Size = new System.Drawing.Size(136, 18);
			this.lblSupplier.TabIndex = 17;
			this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtProducto
			// 
			this.txtProducto.CadenaDescripcionNoValida = "";
			this.txtProducto.CatalogoBase = null;
			this.txtProducto.ControlDestinoDescripcion = this.txtDescProducto;
			this.txtProducto.Location = new System.Drawing.Point(112, 120);
			this.txtProducto.Name = "txtProducto";
			this.txtProducto.Size = new System.Drawing.Size(53, 20);
			this.txtProducto.TabIndex = 4;
			this.txtProducto.Text = "";
			// 
			// txtDescProducto
			// 
			this.txtDescProducto.Location = new System.Drawing.Point(176, 120);
			this.txtDescProducto.Name = "txtDescProducto";
			this.txtDescProducto.Size = new System.Drawing.Size(136, 20);
			this.txtDescProducto.TabIndex = 7;
			this.txtDescProducto.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 17);
			this.label4.TabIndex = 20;
			this.label4.Text = "Producto";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 17);
			this.label3.TabIndex = 19;
			this.label3.Text = "Categorias";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 18);
			this.label2.TabIndex = 18;
			this.label2.Text = "Supplier";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lstRegistros
			// 
			this.lstRegistros.Location = new System.Drawing.Point(7, 229);
			this.lstRegistros.Name = "lstRegistros";
			this.lstRegistros.Size = new System.Drawing.Size(313, 125);
			this.lstRegistros.TabIndex = 10;
			this.lstRegistros.View = System.Windows.Forms.View.Details;
			// 
			// grpMetaCatalogo
			// 
			this.grpMetaCatalogo.Controls.Add(this.lblCampos);
			this.grpMetaCatalogo.Controls.Add(this.lstCampos);
			this.grpMetaCatalogo.Controls.Add(this.btnSetCatalogo);
			this.grpMetaCatalogo.Controls.Add(this.txtMetacatalogo);
			this.grpMetaCatalogo.Location = new System.Drawing.Point(16, 16);
			this.grpMetaCatalogo.Name = "grpMetaCatalogo";
			this.grpMetaCatalogo.Size = new System.Drawing.Size(253, 360);
			this.grpMetaCatalogo.TabIndex = 13;
			this.grpMetaCatalogo.TabStop = false;
			this.grpMetaCatalogo.Text = "MetaCatalogo";
			// 
			// lblCampos
			// 
			this.lblCampos.Location = new System.Drawing.Point(7, 208);
			this.lblCampos.Name = "lblCampos";
			this.lblCampos.Size = new System.Drawing.Size(113, 14);
			this.lblCampos.TabIndex = 10;
			this.lblCampos.Text = "Campos";
			// 
			// lstCampos
			// 
			this.lstCampos.Location = new System.Drawing.Point(7, 229);
			this.lstCampos.Name = "lstCampos";
			this.lstCampos.Size = new System.Drawing.Size(240, 125);
			this.lstCampos.TabIndex = 9;
			this.lstCampos.View = System.Windows.Forms.View.Details;
			// 
			// btnSetCatalogo
			// 
			this.btnSetCatalogo.Location = new System.Drawing.Point(13, 21);
			this.btnSetCatalogo.Name = "btnSetCatalogo";
			this.btnSetCatalogo.Size = new System.Drawing.Size(107, 21);
			this.btnSetCatalogo.TabIndex = 1;
			this.btnSetCatalogo.Text = "Set MetaCatalogo";
			this.btnSetCatalogo.Click += new System.EventHandler(this.btnSetCatalogo_Click);
			// 
			// txtMetacatalogo
			// 
			this.txtMetacatalogo.CadenaDescripcionNoValida = "";
			this.txtMetacatalogo.CatalogoBase = null;
			this.txtMetacatalogo.ControlDestinoDescripcion = null;
			this.txtMetacatalogo.Location = new System.Drawing.Point(136, 21);
			this.txtMetacatalogo.Name = "txtMetacatalogo";
			this.txtMetacatalogo.Size = new System.Drawing.Size(104, 20);
			this.txtMetacatalogo.TabIndex = 0;
			this.txtMetacatalogo.Text = "";
			// 
			// frmPrueba
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 389);
			this.Controls.Add(this.grpCatalogo);
			this.Controls.Add(this.grpMetaCatalogo);
			this.Name = "frmPrueba";
			this.Text = "frmPrueba";
			this.Load += new System.EventHandler(this.frmPrueba_Load);
			this.grpCatalogo.ResumeLayout(false);
			this.grpMetaCatalogo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos 

		private void frmPrueba_Load(object sender, System.EventArgs e)			
		{
			Catalogo catalogoMC = new Catalogo(new MetaCatalogo("MetaCatalogos"));
			Catalogo catalogoSC = new Catalogo(new MetaCatalogo("SuperCategorias"));
			Catalogo catalogoC =  new Catalogo(new MetaCatalogo("Categorias"));
			Catalogo catalogoS =  new Catalogo(new MetaCatalogo("Proveedores"));
			Catalogo catalogoP =  new Catalogo(new MetaCatalogo("Productos"));
									
			catalogoSC.LlenoTabla += new EventHandler(catalogo_LlenarTabla);
			catalogoP.LlenoTabla  += new EventHandler(catalogo_LlenarTabla);
			catalogoC.LlenoTabla  += new EventHandler(catalogo_LlenarTabla);
			catalogoS.LlenoTabla  += new EventHandler(catalogo_LlenarTabla);
			
			txtMetacatalogo.CatalogoBase	= catalogoMC;
			txtSuperCategoria.CatalogoBase	= catalogoSC;
			txtCategoria.CatalogoBase		= catalogoC;
			txtProducto.CatalogoBase		= catalogoP;
			txtSupplier.CatalogoBase		= catalogoS;

		}

		private void btnSetCatalogo_Click(object sender, System.EventArgs e)	
		{
			MetaCatalogo metaCatalogoX =new MetaCatalogo(txtMetacatalogo.Text);
			if (!metaCatalogoX.Vacio)
				Tool.LlenaListaConMetaCampos(lstCampos, metaCatalogoX.MetaCampos);
		}

		private void btnProductos_Click(object sender, System.EventArgs e)		
		{
			txtProducto.CatalogoBase.LlenarTablaDelCatalogo();
		}

		private void btnCategorias_Click_1(object sender, System.EventArgs e)	
		{
			txtCategoria.CatalogoBase.LlenarTablaDelCatalogo();
		}

		private void btnSuperCategorias_Click(object sender, System.EventArgs e)
		{
			txtSuperCategoria.CatalogoBase.LlenarTablaDelCatalogo();
		}
		
		private void catalogo_LlenarTabla(object sender, EventArgs e)			
		{			
			Tool.LlenarListViewConTabla(lstRegistros, ((Catalogo)sender).TablaCatalogo);
		}

		
		#endregion //Eventos

	}
}

		