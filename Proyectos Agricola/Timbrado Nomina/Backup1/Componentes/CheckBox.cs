using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Sistema.Componentes
{
	/// <summary>
	/// Implementa 
	/// </summary>
	public class CheckBox : System.Windows.Forms.CheckBox
	{

		private System.ComponentModel.Container components = null;
		private bool atrReadOnly;
		private bool atrRaised;
		private bool atrUserAsigned;

		/// <summary>
		/// Constructor base
		/// </summary>
		public CheckBox(){			
			InitializeComponent();	
			atrReadOnly = false;
			atrRaised = false;
			atrUserAsigned = true;			
		}

		
		#region Component Designer generated code 
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();			
		}
		
		
		#endregion

		
		#region Destructor 

		/// <summary>
		/// .
		/// </summary>
		/// <param name="disposing">.</param>
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

	

		/// <summary>
		/// Obtiene o establece si el control se encuentra de solo lectura
		/// </summary>
		[Description("Determina si el control sera de solo lectura."),Category("Configuración")]
		public bool ReadOnly{
			get{return atrReadOnly;}
			set{atrReadOnly = value;}
		}

		/// <summary>
		/// Sobreescribimos el metodo CheckedChanged para simular que el control es de solo lectura
		/// </summary>
		/// <param name="e"></param>
		protected override void OnCheckedChanged(EventArgs e)
		{
			//if(!atrUserAsigned)return;
			if(atrReadOnly && !atrRaised && atrUserAsigned)
			{
				atrRaised = true;
				base.Checked = !base.Checked;
				return;
			}
			else{
				if(!atrRaised)
					base.OnCheckedChanged (e);
			}			
			atrRaised = false;
		}


		/// <summary>
		/// Sobrescribimos la propiedad Checked para poder cambiar el valor del conrtrol mediante codigo
		/// </summary>
		new public bool Checked{
			get{return base.Checked;}
			set{
				atrUserAsigned = false;
				base.Checked = value;
				atrUserAsigned = true;
			}
		}

	}
}
