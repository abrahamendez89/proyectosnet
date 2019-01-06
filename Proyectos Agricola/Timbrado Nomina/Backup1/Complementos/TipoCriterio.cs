using System;

namespace Sistema
{
	/// <summary>	
	/// Desarrollado Por : Lic. Alejandro Cons Gastélum Arámburo
	/// Fecha V1.1		 : Septiembre 2004
	/// Interfase		 : TipoCriterio
	/// Descripcion      : Clase para Manejar los Tipos de Criterios
	/// Que Hace		 : Maneja los Diferentes modos de Criterio de busqueda posibles en un MetaCatálogo
	/// </summary>
	public class TipoCriterio
	{		
		#region Atributos
		
		private int atrCriterio;

		/// <summary>
		/// Obtiene o establece el Tipo de criterio para el Catalogo.
		/// </summary>
		public int Criterio
		{
			get{return atrCriterio;}
			set{
				if (value <= 3 && value > 0)			
					atrCriterio = value;
				else
					atrCriterio = 1;
				}
		}		

		#endregion 

		#region Constructor 
		
		/// <summary>
		/// Constructor base.
		/// </summary>
		/// <param name="prmCriterio">Tipo de criterio</param>
		public TipoCriterio(int prmCriterio)
		{
			if (prmCriterio <= 3 && prmCriterio > 0)
				atrCriterio = prmCriterio;
			else
				atrCriterio = 1;
		}

		/// <summary>
		/// Constructor base.
		/// </summary>
		public TipoCriterio()
		{
			atrCriterio = 1;
		}		
		

		#endregion 

		#region Métodos Públicos

		/// <summary>
		/// Devuelve el criterio especificado con el tipo de criterio que le corresponde
		/// </summary>
		/// <param name="prmCriterio">Criterio a especificar</param>
		/// <returns>Devuelve el Criterio con su tipo de Criterio aplicado</returns>
		public string ValorConCriterio(string prmCriterio) 
		{
			if (prmCriterio == "")
			{
				return "%";
			}
			switch(atrCriterio)
			{
				case 1:
					return prmCriterio;
				case 2:
					return prmCriterio + "%";
				case 3: //Encuentralo donde sea
					return  "%" + prmCriterio.Replace(" ","%") + "%"; 
				default:
					return prmCriterio;
			}		
		}
		
		
		#endregion

	}
}
