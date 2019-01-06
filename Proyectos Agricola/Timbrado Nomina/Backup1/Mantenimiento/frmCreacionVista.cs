using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sistema.Mantenimiento
{
	/// <summary>
	/// Summary description for frmCreacionVista.
	/// </summary>
	public class frmCreacionVista : System.Windows.Forms.Form
	{
		public string atrNombreVista;
		public string atrSqlScript;
		private string atrOldNombreVista;
		private string atrOldSqlScript;

		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statEstado;
		private System.Windows.Forms.TextBox txtNombreVista;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEjecutar;
		public System.Windows.Forms.TextBox txtQuery;
		private System.Windows.Forms.DataGrid grdResultado;
		private System.Windows.Forms.StatusBarPanel statF5;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCreacionVista()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCreacionVista));
			this.txtQuery = new System.Windows.Forms.TextBox();
			this.grdResultado = new System.Windows.Forms.DataGrid();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statEstado = new System.Windows.Forms.StatusBarPanel();
			this.statF5 = new System.Windows.Forms.StatusBarPanel();
			this.txtNombreVista = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEjecutar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grdResultado)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statEstado)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statF5)).BeginInit();
			this.SuspendLayout();
			// 
			// txtQuery
			// 
			this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtQuery.Location = new System.Drawing.Point(8, 40);
			this.txtQuery.Multiline = true;
			this.txtQuery.Name = "txtQuery";
			this.txtQuery.Size = new System.Drawing.Size(592, 104);
			this.txtQuery.TabIndex = 1;
			this.txtQuery.Text = "";
			// 
			// grdResultado
			// 
			this.grdResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grdResultado.DataMember = "";
			this.grdResultado.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.grdResultado.Location = new System.Drawing.Point(8, 184);
			this.grdResultado.Name = "grdResultado";
			this.grdResultado.Size = new System.Drawing.Size(592, 184);
			this.grdResultado.TabIndex = 1;
			this.grdResultado.TabStop = false;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 415);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statEstado,
																						  this.statF5});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(608, 22);
			this.statusBar1.TabIndex = 2;
			// 
			// statEstado
			// 
			this.statEstado.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statEstado.Width = 442;
			// 
			// statF5
			// 
			this.statF5.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.statF5.Icon = ((System.Drawing.Icon)(resources.GetObject("statF5.Icon")));
			this.statF5.Text = "<F5>Ejecutar Consulta";
			this.statF5.Width = 150;
			// 
			// txtNombreVista
			// 
			this.txtNombreVista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNombreVista.Location = new System.Drawing.Point(136, 8);
			this.txtNombreVista.Name = "txtNombreVista";
			this.txtNombreVista.Size = new System.Drawing.Size(464, 20);
			this.txtNombreVista.TabIndex = 0;
			this.txtNombreVista.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Nombre de la Vista :";
			// 
			// btnEjecutar
			// 
			this.btnEjecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEjecutar.Location = new System.Drawing.Point(520, 152);
			this.btnEjecutar.Name = "btnEjecutar";
			this.btnEjecutar.Size = new System.Drawing.Size(80, 24);
			this.btnEjecutar.TabIndex = 4;
			this.btnEjecutar.Text = "Ejecutar";
			this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Location = new System.Drawing.Point(520, 379);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(80, 24);
			this.btnCancelar.TabIndex = 5;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAceptar.Location = new System.Drawing.Point(8, 384);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(80, 24);
			this.btnAceptar.TabIndex = 4;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// frmCreacionVista
			// 
			this.AcceptButton = this.btnAceptar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancelar;
			this.ClientSize = new System.Drawing.Size(608, 437);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.grdResultado);
			this.Controls.Add(this.txtQuery);
			this.Controls.Add(this.txtNombreVista);
			this.Controls.Add(this.btnEjecutar);
			this.Controls.Add(this.btnAceptar);
			this.MinimumSize = new System.Drawing.Size(280, 325);
			this.Name = "frmCreacionVista";
			this.Text = "Modificar Vista";
			this.Load += new System.EventHandler(this.frmCreacionVista_Load);			
			((System.ComponentModel.ISupportInitialize)(this.grdResultado)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statEstado)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statF5)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnEjecutar_Click(object sender, System.EventArgs e)
		{
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			System.Data.DataTable dttResultado = new System.Data.DataTable();
			try
			{
				DAO.RegresaConsultaSQL(txtQuery.Text, ref dttResultado);
			}				
			catch(Exception er)
			{
				Tool.RaiseError("Error en la Consulta : \n" + er.Message);
			}
			grdResultado.DataSource = dttResultado;
		}


		private void frmCreacionVista_Load(object sender, System.EventArgs e)
		{
			atrOldNombreVista = atrNombreVista;
			atrOldSqlScript = atrSqlScript;
			
			txtNombreVista.Text = atrNombreVista;
			txtQuery.Text = atrSqlScript;
		}


		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			atrNombreVista = atrOldNombreVista;
			atrSqlScript = atrOldSqlScript;
			this.Close();

		}

		
		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			atrNombreVista = txtNombreVista.Text;
			atrSqlScript = txtQuery.Text;
			this.Close();
		}
	}
}
