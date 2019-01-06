using System;

namespace Sistema
{
	/// <summary>	
	/// Desarrollado Por : Lic. Alejandro Cons Gast�lum Ar�mburo
	/// Fecha V1.1		 : Septiembre 2004
	/// Clase			 : ValorDependencia
	/// Descripcion      : Clase para controlar los Valores de Dependencia del Cat�logo
	/// Que Hace		 : Esta Clase Contiene los Valores de las Dependencias del Cat�logo
	///					   Que la contiene, necesarias cuando el Metacat�logo depende de
	///					   otro Metacat�logo en una Dependencia Primaria u Obligatoria
	/// </summary>
	public class ValorDependencia
	{
		/// <summary>
		/// Evento CambioValorDependencia.
		/// </summary>
		public event EventHandler CambioValorDependencia;	
		
		#region Atributos
		
		#region Privados

		private Catalogo		atrCatalogoPadre;
		private MetaCampo		atrMetaCampoDependiente;
		private MetaCatalogo	atrMetaCatalogoDependencia ;
		private string			atrValor;
		private bool			atrDependenciaObligatoria;

		
		
		#endregion //Privados

		#region P�blicos


	
		/// <summary>
		/// MetaCampo Dependiente.
		/// </summary>
		public MetaCampo		MetaCampoDependiente{
			get{return atrMetaCampoDependiente;}
		}

		/// <summary>
		/// Obtiene el catalogo de padre para este catalogo.
		/// </summary>
		public Catalogo		CatalogoPadre			
		{
			get{return atrCatalogoPadre;}
		}

		/// <summary>
		/// Obtiene el Metacatalogo depenciencia.
		/// </summary>
		public MetaCatalogo MetaCatalogoDependencia		
		{
			get{return atrMetaCatalogoDependencia;}
		}

		/// <summary>
		/// Obtiene si este valor tiene una dependiencia obligatoria
		/// </summary>
		public bool			DependenciaObligatoria	
		{
			get{return atrDependenciaObligatoria;}			
		}

		/// <summary>
		/// Obtiene o establece el valor de la dependencia.
		/// </summary>
		public string		Valor					
		{
			get{return  atrValor;}
			set
			{
				if (atrValor != value)
				{
					atrValor = value;
					OnCambioValorDependencia(this, new EventArgs());
				}
			}
		}
		
		
		#endregion //P�blicos
		
		#endregion //Atributos

		#region Constructor 

		/// <summary>
		/// Constructor base.
		/// </summary>
		/// <param name="prmCatalogoPadre">Catalogo padre de la dependencia</param>
		/// <param name="prmMetacatalogo">Metacatlogo de la dependencia</param>
		/// <param name="prmMetaCampo">Metacampo de la dependencia</param>
		public ValorDependencia(Catalogo prmCatalogoPadre, MetaCatalogo prmMetacatalogo, MetaCampo prmMetaCampo)
		{
			atrMetaCatalogoDependencia = prmMetacatalogo;
			atrMetaCampoDependiente = prmMetaCampo;
			atrCatalogoPadre = prmCatalogoPadre;			
			atrDependenciaObligatoria = atrMetaCampoDependiente.DependenciaObligatoria;
			atrValor = "";

		}
		
		#endregion //Constructor 

		#region Eventos Protegidos
		
		/// <summary>
		/// Metodo que determina si el evento tiene delegados asociados y los dispara en caso de.
		/// </summary>
		/// <param name="sender">Objeto que intenta disparar el evento</param>
		/// <param name="e">Valores del evento</param>
		protected void OnCambioValorDependencia(Object sender, EventArgs e)
		{
			if (CambioValorDependencia != null) 	
			{					
				CambioValorDependencia(sender, e); 
			}
		}

		#endregion //Protegidos
	}
}
