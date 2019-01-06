using System;
using System.Windows.Forms;

namespace Sistema.Componentes
{
	/// <summary>
	/// Control que implementa la funcionalidad de poder cancelar el cambio de pestañas
	/// Elaboro		:Lic. David Adan Velazquez Sanchez
	/// Fecha		:12 de Febrero del 2006
	/// </summary>
	public class AccTabControl : TabControl
	{
		/// <summary>
		/// Constructor base
		/// </summary>
        public AccTabControl()
        {			
			InitializeComponent();		
		}

		#region  ATRIBUTOS	

		private System.ComponentModel.Container components = null;
		private TabPage atrCurrent;
		private System.Drawing.Color atrBackColor;
		private System.Drawing.Color atrSelectedTabColor;
		
		/// <summary>
		/// Delegado para el evento SelectedIndexChanging
		/// </summary>
		public delegate void TabPageChangingEventHandler(object sender ,TabPageChangingEventArgs e);

		/// <summary>
		/// Evento que se dispara antes de cambiar el tabpage actual
		/// </summary>
		public event TabPageChangingEventHandler SelectedIndexChanging;


		#endregion

		#region Component Designer generated code 
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();			
			atrCurrent = null;		
			atrBackColor = System.Drawing.Color.Empty;
			atrSelectedTabColor = System.Drawing.Color.Empty;
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

		#region PROTEGIDOS

		/// <summary>
		/// Metodo que dispara el evento SelectedIndexChanging
		/// </summary>
		/// <param name="e">argumentos del evento</param>
		protected virtual void OnSelectedIndexChanging(TabPageChangingEventArgs e){
			if(SelectedIndexChanging != null)
				SelectedIndexChanging(this ,e);
		}

		/// <summary>
		/// Dispara el Evento
		/// </summary>
		/// <param name="e">argumentos del evnto</param>
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			///Cachamos la primera vez que entramos al control
			if(atrCurrent == null){
				base.OnSelectedIndexChanged (e);
				atrCurrent = this.SelectedTab;
				return;
			}
			TabPageChangingEventArgs args = new TabPageChangingEventArgs(atrCurrent ,this.SelectedTab);
			OnSelectedIndexChanging(args);
			//Se se cancela la accion devolvemos el foco al TabPage anterior
			if(args.Cancel){
				this.SelectedTab = atrCurrent;
				this.SelectedTab.Focus();
				return;
			}
			base.OnSelectedIndexChanged (e);
			atrCurrent = this.SelectedTab;
		}
		

		
		#endregion

	}

	/// <summary>
	/// Argumentos del eventos SelectedIndexChanging
	/// </summary>
	public class TabPageChangingEventArgs : System.ComponentModel.CancelEventArgs{

		private TabPage atrCurrentTab;
		private TabPage atrNextTab;

		/// <summary>
		/// Constructor Base.
		/// </summary>
		/// <param name="current">Tab del cual se esta saliendo</param>
		/// <param name="next">Tab al cual se desea cambiar</param>
		public TabPageChangingEventArgs(TabPage current ,TabPage next):base(false){			
			atrCurrentTab = current;
			atrNextTab = next;
		}

		/// <summary>
		/// Obtiene la carpeta actual
		/// </summary>
		public TabPage CurrentTab{
			get{return atrCurrentTab;}
		}

		/// <summary>
		/// Obtiene la carpeta a la cual se desea ir
		/// </summary>
		public TabPage NextTab{
			get{return atrNextTab;}
		}

	}
}
