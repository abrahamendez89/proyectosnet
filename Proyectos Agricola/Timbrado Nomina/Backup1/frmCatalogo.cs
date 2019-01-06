using System;
//using System.Drawing;
//using System.Collections;
//using System.ComponentModel;
using System.Windows.Forms;

namespace Sistema.Mantenimiento
{
	/// <summary>
	/// Forma para el Mantenimiento de Catálogos
	/// ********** INCOMPLETA *************************
	/// ********** INCOMPLETA *************************
	/// ********** INCOMPLETA *************************
	/// </summary>
	public class frmCatalogo : System.Windows.Forms.Form
	{
		#region Atributos 

		#region Privados 
		
		private Catalogo catalogoBase;
		private System.Windows.Forms.TextBox textBox1;

		private System.ComponentModel.Container components = null;
		
		#endregion 
		
		#region Públicos 
		
		public Catalogo CatalogoBase
		{
			get {return catalogoBase;}
		}
		
		
		#endregion 
		
		#endregion //Atributos 

		#region Contructor

		public frmCatalogo(Catalogo prmCatalogo)
		{			
			if (prmCatalogo == null || prmCatalogo.Vacio)			
				this.Close();

			InitializeComponent();
			catalogoBase = prmCatalogo;
			drawForm();
		}

//		public frmCatalogo(string prmMetaCatalogo)
//		{
//			InitializeComponent();
//			MetaCatalogo MetaCatalogoBase = new MetaCatalogo(prmMetaCatalogo);
//			catalogoBase = new Catalogo(MetaCatalogoBase);
//			drawForm();
//		}

		
		#endregion //Contructor

		#region Destructor
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
		#endregion //Destructor

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(288, 224);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// frmCatalogo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 381);
			this.Controls.Add(this.textBox1);
			this.Name = "frmCatalogo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmMetaCatalogo";
			this.ResumeLayout(false);

		}
		#endregion

		#region Métodos
		
		#region Privados
		
		private void drawForm()
		{
			int i=0;
			MetaCatalogo metaCatalogoBase = CatalogoBase.MetaCatalogoBase;

			foreach(MetaCampo metaCampo in metaCatalogoBase.MetaCampos)
			{
				Label etiqueta = new Label();
				etiqueta.Height = 20;
				etiqueta.Width = 200;						
				etiqueta.Left = 25 ;
				etiqueta.Top = 25 + i * 25;
				etiqueta.Name = "lbl" + metaCampo.NombreCampo;
				etiqueta.Text = metaCampo.NombreCampo;		
				base.Controls.Add(etiqueta);

				switch(metaCampo.TipoCampo)
				{		
					case "varchar":
					{
						//createTextBoxInput();
						break;
					}
					case "char":
					{
						TextBox control = new TextBox();
						control.Height = 20;
						control.Width = 20;
						control.Left = 245 ;
						control.Top = 25 + i * 25;
						control.TabIndex = i;						
						control.Name = "txt" + metaCampo.NombreCampo;
						control.MaxLength = 1;
						//control.Text=campo.valorDefault.ToString();
						base.Controls.Add(control);
						i++;
						break;
					}
					case "smallint":
					{
						TextBox control = new TextBox();
						control.Height = 20;
						control.Width = 50;
						control.Left = 245 ;
						control.Top = 25 + i * 25;
						control.TabIndex = i;						
						control.Name = "txt" + metaCampo.NombreCampo;
						control.MaxLength = 3;
						//control.Text=campo.valorDefault.ToString();
						base.Controls.Add(control);
						i++;
						break;
					}
					case "int":
					{
						TextBox control = new TextBox();
						control.Height = 20;
						control.Width = 100;
						control.Left = 245 ;
						control.Top = 25 + i * 25;
						control.TabIndex = i;						
						control.Name = "txt" + metaCampo.NombreCampo;
						control.MaxLength = 10;
						//control.Text=campo.valorDefault.ToString();
						base.Controls.Add(control);
						i++;
						break;
					}
					case "bit":
					{
						CheckBox control = new CheckBox();						
						control.Height = 20;
						control.Width = 20;
						control.Left = 245 ;
						control.Top = 25 + i * 25;
						control.TabIndex = i;						
						control.Name = "chk" + metaCampo.NombreCampo;						
						base.Controls.Add(control);
						i++;					
						break;
					}
					default:
					{
						i++;
						break;
					}					
				}
			}			
		}


		private void createTextBoxInput(MetaCampo metaCampo, int alto, int ancho, int x, int y, int tabIndex)
		{
			TextBox control = new TextBox();
			control.Height = alto;
			control.Width  = ancho;
//			control.Location.X = x;
//			control.Location.Y = y;
/*
			control.Left = 245 ;
			control.Top = 25 + i * 25;
			control.TabIndex = i;	
*/					
			control.Name = "txt" + metaCampo.NombreCampo;
			control.MaxLength = metaCampo.MaxCaracteres;
			base.Controls.Add(control);
		}

		#endregion //Privados

		#endregion //Métodos
	}
}
