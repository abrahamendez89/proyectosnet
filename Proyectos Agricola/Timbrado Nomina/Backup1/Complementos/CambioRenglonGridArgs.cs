using System;
using System.Drawing;

namespace Sistema
{
	/// <summary>
	/// Clase utilizada para el envio de información en el evento
	/// Cambio de Renglon del Access Grid.
	/// </summary>
	public class CambioRenglonGridArgs
	{

		private Color atrDefault_RenglonInvalido = Color.Red;
		private int atrRenglon_Salir;
		private bool atrCancelar;
		private bool atrMarcar_Renglon_Invalido;
		private Color atrColor_Renglon_Invalido;
		private bool atrPermitir_Nuevo_Renglon;
		private int atrColumna_A_Activar;

		/// <summary>
		/// Valor default que identifica el indice de la columna actual en el grid.
		/// </summary>
		public const int DefaultColumnaActual = -2;

		/// <summary>
		/// Indice de la columna que obtendra el foco en caso de cancelar la salida del renglon.
		/// </summary>
		public int Columna_A_Activar{
			get{return atrColumna_A_Activar;}
			set{atrColumna_A_Activar = value;}
		}


		/// <summary>
		/// Determina si se agregara un nuevo renglon al grid en el caso de ser 
		/// el ultimo renglon, el renglon del cual se esta saliendo.
		/// </summary>
		public bool Permitir_Nuevo_Renglon{
			get{return atrPermitir_Nuevo_Renglon;}
			set{atrPermitir_Nuevo_Renglon = value;}
		}

		/// <summary>
		/// Devuelve el indice del Renglon del cual va a salir el cursor.
		/// </summary>
		public int Renglon
		{
			get{return atrRenglon_Salir;}
		}

		/// <summary>
		/// Determina si la accion sera cancelada.
		/// </summary>
		public bool Cancelar
		{
			get{return atrCancelar;}
			set{atrCancelar = value;}
		}

		/// <summary>
		/// Propiedad que determina si el renglon del cual se esta saliendo es invalido.
		/// </summary>
		public bool Marcar_Renglon_Invalido
		{
			get{return atrMarcar_Renglon_Invalido;}
			set{atrMarcar_Renglon_Invalido = value;}
		}

		/// <summary>
		/// Propiedad que determina de que color sera pintado el color invalido.
		/// </summary>
		public Color Color_Renglon_Invalido
		{
			get{return atrColor_Renglon_Invalido;}
			set{atrColor_Renglon_Invalido = value;}
		}
		
		/// <summary>
		/// Constructor base.
		/// </summary>
		/// <param name="prmRenglon_Salir">Indice del renglon del cual se esta saliendo el cursor</param>
		public CambioRenglonGridArgs(int prmRenglon_Salir )
			
		{
			atrRenglon_Salir= prmRenglon_Salir;
			atrPermitir_Nuevo_Renglon = false;
			atrCancelar = false;
			atrMarcar_Renglon_Invalido = false;
			atrColor_Renglon_Invalido = atrDefault_RenglonInvalido;
			atrColumna_A_Activar = CambioRenglonGridArgs.DefaultColumnaActual;
			

		}

		/// <summary>
		/// Aplica valores estandar al objeto. (Sobrecarga 1)
		/// </summary>
		public void PermitirAvance_MarcarInvalido_No_NuevoRenglon(){
			atrCancelar = false;
			atrMarcar_Renglon_Invalido = true;
			atrPermitir_Nuevo_Renglon = false;
		}
		
		/// <summary>
		/// Aplica valores estandar al objeto. (Sobrecarga 2)
		/// </summary>
		/// <param name="prmColor">Color del cual se pintara el renglon invalido</param>
		public void PermitirAvance_MarcarInvalido_No_NuevoRenglon(System.Drawing.Color prmColor)
		{
			atrCancelar = false;
			atrMarcar_Renglon_Invalido = true;
			atrPermitir_Nuevo_Renglon = false;
			atrColor_Renglon_Invalido = prmColor;
		}

		/// <summary>
		/// Aplica valores estandar al objeto. (Sobrecarga 1)
		/// </summary>
		public void No_PermitirAvance_MarcarInvalido_No_NuevoRenglon()
		{
			atrCancelar = true;
			atrMarcar_Renglon_Invalido = true;
			atrPermitir_Nuevo_Renglon = false;
		}

		
		/// <summary>
		/// Aplica valores estandar al objeto. (Sobrecarga 2)
		/// </summary>
		/// <param name="prmColor">Color del cual se pintara el renglon invalido</param>
		public void No_PermitirAvance_MarcarInvalido_No_NuevoRenglon(System.Drawing.Color prmColor)
		{
			atrCancelar = true;
			atrMarcar_Renglon_Invalido = true;
			atrPermitir_Nuevo_Renglon = false;
			atrColor_Renglon_Invalido = prmColor;
		}

		

	}

	/// <summary>
	/// Clase que determina los valores resultantes del evento Cambio_Celda.
	/// </summary>
	public class CambioCeldaGridArgs{

		private int atrRenglon;
		private int atrColumna;
		private bool atrCancelar;

		/// <summary>
		/// Obtiene el indice del renglon del cual se esta saliendo
		/// </summary>
		public int Renglon{
			get{return atrRenglon;}
		}

		/// <summary>
		/// Obtiene el indice del columna del cual se esta saliendo
		/// </summary>
		public int Columna
		{
			get{return atrColumna;}
		}

		/// <summary>
		/// Obtiene o establece si el la Celda es valida y por lo tanto si se cancelara la accion.
		/// </summary>
		public bool Cancelar{
			get{return atrCancelar;}
			set{atrCancelar = value;}
		}

		/// <summary>
		/// Constructor base de la clase.
		/// </summary>
		/// <param name="prmRenglon">indice del renglon de la celda del cual se esta saliendo</param>
		/// <param name="prmColumna">indice del columna de la celda del cual se esta saliendo</param>
		public CambioCeldaGridArgs(int prmRenglon ,int prmColumna){
			atrRenglon = prmRenglon;
			atrColumna = prmColumna;
			atrCancelar = false;
			
		}

	}

	/// <summary>
	/// Clase que proporciona la informacion arrojada al intentar eliminar un renglon del grid.
	/// </summary>
	public class EliminacionRenglonGridArgs : System.EventArgs{

		private bool atrCancelar;
		private int atrRenglon;

		/// <summary>
		/// Obtiene o establece si la eliminacion del renglon sera cancelada.
		/// </summary>
		public bool Cancelar{
			get{return atrCancelar;}
			set{atrCancelar = value;}
		}

		/// <summary>
		/// Obtiene el indice del renglon que se quiere eliminar.
		/// </summary>
		public int Renglon{
			get{return atrRenglon;}			
		}

		/// <summary>
		/// Constructor base.
		/// </summary>
		/// <param name="prmRenglon">Indice del renglon que se quiere eliminar</param>
		public EliminacionRenglonGridArgs(int prmRenglon){
			atrCancelar = false;
			atrRenglon = prmRenglon;
		}
	}
}
