using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace Sistema.Mantenimiento
{
	/// <summary>
	/// Forma de Creacion de MetaCatalogos.
	/// </summary>
	public class frmCreacionMetaCatalogos : System.Windows.Forms.Form
	{

		private string atrSqlScriptCatalogo;
		private string atrSqlScriptBusquedaRapida;
		private string atrSqlScriptMetaCatalogo;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private Sistema.AccTextBox txtMetaCatalogo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtVistaCatalogo;
		private System.Windows.Forms.TextBox txtVistaBusquedaRapida;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkCriterioObligatorio;
		private System.Windows.Forms.RadioButton radEmpiezaCon;
		private System.Windows.Forms.RadioButton radContiene;
		private System.Windows.Forms.RadioButton radEsIgualA;
		private System.Windows.Forms.GroupBox linea;
		private System.Windows.Forms.Button btnQuitar;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.ComboBox cboCampoDescripcion;
		private System.Windows.Forms.ComboBox cboCampoPrimario;
		private System.Windows.Forms.ComboBox cboCampoBusqueda;
		private System.Windows.Forms.Button btnVistaBusquedaRapida;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ComboBox cboCerosJustificar;
		private System.Windows.Forms.Button btnVistaCatalogo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCreacionMetaCatalogos()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtVistaCatalogo = new System.Windows.Forms.TextBox();
			this.txtVistaBusquedaRapida = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.chkCriterioObligatorio = new System.Windows.Forms.CheckBox();
			this.radEmpiezaCon = new System.Windows.Forms.RadioButton();
			this.radContiene = new System.Windows.Forms.RadioButton();
			this.radEsIgualA = new System.Windows.Forms.RadioButton();
			this.label8 = new System.Windows.Forms.Label();
            this.txtMetaCatalogo = new Sistema.AccTextBox();
			this.linea = new System.Windows.Forms.GroupBox();
			this.btnQuitar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnVistaCatalogo = new System.Windows.Forms.Button();
			this.btnVistaBusquedaRapida = new System.Windows.Forms.Button();
			this.cboCampoPrimario = new System.Windows.Forms.ComboBox();
			this.cboCampoDescripcion = new System.Windows.Forms.ComboBox();
			this.cboCampoBusqueda = new System.Windows.Forms.ComboBox();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.cboCerosJustificar = new System.Windows.Forms.ComboBox();
			this.linea.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nombre del MetaCatalogo";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Vista de Catalogo";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 24);
			this.label3.TabIndex = 1;
			this.label3.Text = "Vista de Busqueda Rapida";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(144, 24);
			this.label5.TabIndex = 1;
			this.label5.Text = "Campo de Descripción";
			// 
			// txtVistaCatalogo
			// 
			this.txtVistaCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtVistaCatalogo.Location = new System.Drawing.Point(176, 56);
			this.txtVistaCatalogo.Name = "txtVistaCatalogo";
			this.txtVistaCatalogo.Size = new System.Drawing.Size(216, 20);
			this.txtVistaCatalogo.TabIndex = 2;
			this.txtVistaCatalogo.Text = "";
			// 
			// txtVistaBusquedaRapida
			// 
			this.txtVistaBusquedaRapida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtVistaBusquedaRapida.Location = new System.Drawing.Point(176, 88);
			this.txtVistaBusquedaRapida.Name = "txtVistaBusquedaRapida";
			this.txtVistaBusquedaRapida.Size = new System.Drawing.Size(216, 20);
			this.txtVistaBusquedaRapida.TabIndex = 2;
			this.txtVistaBusquedaRapida.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(24, 184);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(144, 24);
			this.label6.TabIndex = 1;
			this.label6.Text = "Campo de Búsqueda";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(24, 216);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(144, 24);
			this.label7.TabIndex = 1;
			this.label7.Text = "Ceros a Justificar";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(144, 24);
			this.label4.TabIndex = 3;
			this.label4.Text = "Campo Primario";
			// 
			// chkCriterioObligatorio
			// 
			this.chkCriterioObligatorio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkCriterioObligatorio.Location = new System.Drawing.Point(24, 248);
			this.chkCriterioObligatorio.Name = "chkCriterioObligatorio";
			this.chkCriterioObligatorio.Size = new System.Drawing.Size(168, 24);
			this.chkCriterioObligatorio.TabIndex = 5;
			this.chkCriterioObligatorio.Text = "Criterio Obligatorio";
			// 
			// radEmpiezaCon
			// 
			this.radEmpiezaCon.Location = new System.Drawing.Point(176, 312);
			this.radEmpiezaCon.Name = "radEmpiezaCon";
			this.radEmpiezaCon.Size = new System.Drawing.Size(160, 24);
			this.radEmpiezaCon.TabIndex = 6;
			this.radEmpiezaCon.Text = "Empieza con [Criterio%]";
			// 
			// radContiene
			// 
			this.radContiene.Checked = true;
			this.radContiene.Location = new System.Drawing.Point(176, 344);
			this.radContiene.Name = "radContiene";
			this.radContiene.Size = new System.Drawing.Size(160, 24);
			this.radContiene.TabIndex = 6;
			this.radContiene.TabStop = true;
			this.radContiene.Text = "Contiene [%Criterio%]";
			// 
			// radEsIgualA
			// 
			this.radEsIgualA.Location = new System.Drawing.Point(176, 280);
			this.radEsIgualA.Name = "radEsIgualA";
			this.radEsIgualA.Size = new System.Drawing.Size(160, 24);
			this.radEsIgualA.TabIndex = 6;
			this.radEsIgualA.Text = "Es igual a  [Criterio]";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 280);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(144, 24);
			this.label8.TabIndex = 1;
			this.label8.Text = "Tipo de Criterio";
			// 
			// txtMetaCatalogo
			// 
			this.txtMetaCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMetaCatalogo.CadenaDescripcionNoValida = "";
			this.txtMetaCatalogo.CatalogoBase = null;
			this.txtMetaCatalogo.ControlDestinoDescripcion = null;
			this.txtMetaCatalogo.Location = new System.Drawing.Point(176, 24);
			this.txtMetaCatalogo.Name = "txtMetaCatalogo";
			this.txtMetaCatalogo.Size = new System.Drawing.Size(248, 20);
			this.txtMetaCatalogo.TabIndex = 0;
			this.txtMetaCatalogo.Text = "";
			this.txtMetaCatalogo.TextChanged += new System.EventHandler(this.txtMetaCatalogo_TextChanged);
			// 
			// linea
			// 
			this.linea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.linea.Controls.Add(this.btnQuitar);
			this.linea.Controls.Add(this.btnGuardar);
			this.linea.Location = new System.Drawing.Point(8, 376);
			this.linea.Name = "linea";
			this.linea.Size = new System.Drawing.Size(416, 48);
			this.linea.TabIndex = 7;
			this.linea.TabStop = false;
			// 
			// btnQuitar
			// 
			this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnQuitar.Location = new System.Drawing.Point(8, 16);
			this.btnQuitar.Name = "btnQuitar";
			this.btnQuitar.TabIndex = 2;
			this.btnQuitar.Text = "Quitar";
			this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGuardar.Location = new System.Drawing.Point(327, 16);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.TabIndex = 1;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnVistaCatalogo
			// 
			this.btnVistaCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVistaCatalogo.Location = new System.Drawing.Point(400, 56);
			this.btnVistaCatalogo.Name = "btnVistaCatalogo";
			this.btnVistaCatalogo.Size = new System.Drawing.Size(24, 24);
			this.btnVistaCatalogo.TabIndex = 10;
			this.btnVistaCatalogo.Text = "...";
			this.btnVistaCatalogo.Click += new System.EventHandler(this.btnVistaCatalogo_Click);
			// 
			// btnVistaBusquedaRapida
			// 
			this.btnVistaBusquedaRapida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVistaBusquedaRapida.Location = new System.Drawing.Point(400, 88);
			this.btnVistaBusquedaRapida.Name = "btnVistaBusquedaRapida";
			this.btnVistaBusquedaRapida.Size = new System.Drawing.Size(24, 24);
			this.btnVistaBusquedaRapida.TabIndex = 10;
			this.btnVistaBusquedaRapida.Text = "...";
			this.btnVistaBusquedaRapida.Click += new System.EventHandler(this.btnVistaBusquedaRapida_Click);
			// 
			// cboCampoPrimario
			// 
			this.cboCampoPrimario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cboCampoPrimario.Location = new System.Drawing.Point(176, 120);
			this.cboCampoPrimario.Name = "cboCampoPrimario";
			this.cboCampoPrimario.Size = new System.Drawing.Size(184, 21);
			this.cboCampoPrimario.TabIndex = 11;
			// 
			// cboCampoDescripcion
			// 
			this.cboCampoDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cboCampoDescripcion.Location = new System.Drawing.Point(176, 152);
			this.cboCampoDescripcion.Name = "cboCampoDescripcion";
			this.cboCampoDescripcion.Size = new System.Drawing.Size(184, 21);
			this.cboCampoDescripcion.TabIndex = 11;
			// 
			// cboCampoBusqueda
			// 
			this.cboCampoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cboCampoBusqueda.Location = new System.Drawing.Point(176, 184);
			this.cboCampoBusqueda.Name = "cboCampoBusqueda";
			this.cboCampoBusqueda.Size = new System.Drawing.Size(184, 21);
			this.cboCampoBusqueda.TabIndex = 12;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Location = new System.Drawing.Point(368, 120);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(56, 88);
			this.btnRefresh.TabIndex = 13;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// cboCerosJustificar
			// 
			this.cboCerosJustificar.Items.AddRange(new object[] {
																	"00",
																	"01",
																	"02",
																	"03",
																	"04",
																	"05",
																	"06",
																	"07",
																	"08",
																	"09",
																	"10",
																	"11",
																	"12",
																	"13",
																	"14",
																	"15",
																	"16",
																	"17",
																	"18",
																	"19",
																	"20"});
			this.cboCerosJustificar.Location = new System.Drawing.Point(176, 216);
			this.cboCerosJustificar.Name = "cboCerosJustificar";
			this.cboCerosJustificar.Size = new System.Drawing.Size(184, 21);
			this.cboCerosJustificar.TabIndex = 14;
			// 
			// frmCreacionMetaCatalogos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 437);
			this.Controls.Add(this.cboCerosJustificar);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.cboCampoPrimario);
			this.Controls.Add(this.btnVistaCatalogo);
			this.Controls.Add(this.txtMetaCatalogo);
			this.Controls.Add(this.txtVistaCatalogo);
			this.Controls.Add(this.txtVistaBusquedaRapida);
			this.Controls.Add(this.linea);
			this.Controls.Add(this.radEmpiezaCon);
			this.Controls.Add(this.chkCriterioObligatorio);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.radContiene);
			this.Controls.Add(this.radEsIgualA);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnVistaBusquedaRapida);
			this.Controls.Add(this.cboCampoDescripcion);
			this.Controls.Add(this.cboCampoBusqueda);
			this.MinimumSize = new System.Drawing.Size(440, 464);
			this.Name = "frmCreacionMetaCatalogos";
			this.Text = "Captura de MetaCatalogos";
			this.Load += new System.EventHandler(this.frmCreacionMetaCatalogos_Load);
			this.linea.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		private void frmCreacionMetaCatalogos_Load(object sender, System.EventArgs e)
		{			
			Catalogo catMetaCatalogos = new Catalogo(new MetaCatalogo("MetaCatalogos"));
			txtMetaCatalogo.CatalogoBase = catMetaCatalogos;
            txtMetaCatalogo.SeleccionoElemento += new Sistema.AccTextBox.SeleccionoElementoEventHandler(txtMetaCatalogo_SeleccionoElemento);

		}

		private void btnGuardar_Click(object sender, System.EventArgs e)
		{			
			int vCeros;
			if (cboCerosJustificar.Text == "")
				cboCerosJustificar.SelectedIndex=0;

			vCeros = int.Parse(cboCerosJustificar.Text);			
			atrSqlScriptMetaCatalogo = ClsMetaCatalogosManager.GenerarSqlScriptCrearMetaCatalogo(txtMetaCatalogo.Text, txtVistaCatalogo.Text, txtVistaBusquedaRapida.Text, atrSqlScriptCatalogo, atrSqlScriptBusquedaRapida, cboCampoPrimario.Text, cboCampoDescripcion.Text, cboCampoBusqueda.Text, vCeros, getTipoCriterio(), chkCriterioObligatorio.Checked);
			
			frmResultado vResultado = new frmResultado();
			vResultado.txtResultado.Text = atrSqlScriptMetaCatalogo;
			vResultado.ShowDialog();
		}

		private void btnQuitar_Click(object sender, System.EventArgs e)
		{
		
		}

		
		private void btnVistaCatalogo_Click(object sender, System.EventArgs e)
		{
			frmCreacionVista frmCrearVista = new frmCreacionVista();
			frmCrearVista.atrNombreVista = txtVistaCatalogo.Text;
			if(atrSqlScriptCatalogo == null ||atrSqlScriptCatalogo == "")
				frmCrearVista.atrSqlScript = ClsMetaCatalogosManager.ObtenSqlSelectVista(txtVistaCatalogo.Text);
			else
				frmCrearVista.atrSqlScript = atrSqlScriptCatalogo;
			frmCrearVista.ShowDialog();
			txtVistaCatalogo.Text = frmCrearVista.atrNombreVista;
			atrSqlScriptCatalogo = frmCrearVista.atrSqlScript;
			cargarCamposEnCombos(txtVistaCatalogo.Text);
		}

		private void btnVistaBusquedaRapida_Click(object sender, System.EventArgs e)
		{
			frmCreacionVista frmCrearVista = new frmCreacionVista();
			frmCrearVista.atrNombreVista = txtVistaBusquedaRapida.Text;
			if(atrSqlScriptBusquedaRapida  == null ||atrSqlScriptBusquedaRapida  == "")
				frmCrearVista.atrSqlScript = ClsMetaCatalogosManager.ObtenSqlSelectVista(txtVistaBusquedaRapida.Text);
			else
				frmCrearVista.atrSqlScript = atrSqlScriptBusquedaRapida ;
			frmCrearVista.ShowDialog();
			txtVistaBusquedaRapida.Text = frmCrearVista.atrNombreVista;			
			atrSqlScriptBusquedaRapida = frmCrearVista.atrSqlScript;
			cargarCamposEnCombos(txtVistaCatalogo.Text);		
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			cargarCamposEnCombos(txtVistaCatalogo.Text);
		}

		private void txtMetaCatalogo_SeleccionoElemento(Object sender, SelectedElementArgs e)
		{
			cargarDatos(e.Row);
		}

		private void txtMetaCatalogo_TextChanged(object sender, System.EventArgs e)
		{
			txtVistaCatalogo.Text = "mtc" + txtMetaCatalogo.Text + "Catalogo";
			txtVistaBusquedaRapida.Text = "mtc" + txtMetaCatalogo.Text + "BusquedaRapida";
		}


		#endregion //Eventos

		#region Metodos

		private int getTipoCriterio()
		{
			if (radEsIgualA.Checked)	return 1;
			if (radEmpiezaCon.Checked)	return 2;
			if (radContiene.Checked)	return 3;
			return 0;
		}


		private void cargarDatos(System.Data.DataRow row)
		{
			cboCampoBusqueda.Text = (string)row["CampoBusqueda"];
			cboCampoDescripcion.Text = (string)row["CampoDescripcion"];
			cboCampoPrimario.Text = (string)row["CampoPrimario"];
			cboCerosJustificar.Text = row["CerosAJustificar"].ToString();			
			txtVistaBusquedaRapida.Text = (string)row["SqlBusquedaRapida"];
			txtVistaCatalogo.Text = (string)row["SqlCatalogo"];
			chkCriterioObligatorio.Checked= (bool)row["CriterioObligatorio"];
			switch((Int16)row["TipoCriterio"])
			{
				case 1 : radEsIgualA.Checked = true;
					break;
				case 2 : radEmpiezaCon.Checked = true;
					break;
				case 3 : radContiene.Checked = true;
					break;
			}

		}


		private void cargarCamposEnCombos(string prmTabla)
		{
			System.Data.DataTable vTblCampos = ClsMetaCatalogosManager.ObtenTablaCampos(prmTabla);
			cboCampoPrimario.DataSource		=	vTblCampos.Copy();
			cboCampoBusqueda.DataSource		=	vTblCampos.Copy();
			cboCampoDescripcion.DataSource	=	vTblCampos.Copy();
			cboCampoPrimario.DisplayMember	=	"Campos";
			cboCampoBusqueda.DisplayMember	=	"Campos";
			cboCampoDescripcion.DisplayMember = "Campos";
		}

		
		#endregion //Metodos

	}
}
