using System;

namespace Sistema
{
	/// <summary>	
	/// Clase			 : MetaCampo
	/// Descripcion      : Tecnología de Catálogo
	/// Que Hace		 : Esta es la Clase que contiene la informacion obtenida de las 
	///					   tablas de Arquitectura de "MetaCampos" en la que se definen las
	///					   propiedades del Campo asi como sus relaciones con otros MetaCatálogos
	///					   
	/// </summary>	
	public class MetaCampo 
	{
		#region Atributos 

        #region Privados 

		private string	atrMetaCatalogo;		
		private string	atrNombreCampo;
		private int		atrNumeroCampo;
		private int		atrMaxCaracteres;
		private string	atrTipoCampo;		
		private bool	atrOpcional;
		private string	atrDescripcion;
		private bool	atrSoloLectura;
		private bool	atrDependenciaObligatoria;
		private bool	atrDependenciaNoObligatoria;
		private string	atrDependencia;
//		private string	atrValorDefault;

		#endregion //Publicos 
		
		#region Publicos  

		/// <summary>
		/// Obtiene el nombre del metacatalogo al cual pertenece este metacampo.
		/// </summary>
		public string MetaCatalogo			
		{
			get{return atrMetaCatalogo;}			
		}
	
		/// <summary>
		/// Obtiene el Nombre del campo.
		/// </summary>
		public string NombreCampo			
		{
			get {return atrNombreCampo;}
		}

		/// <summary>
		/// Obtiene el Indice del campo
		/// </summary>
		public int NumeroCampo				
		{
			get{return atrNumeroCampo;}
		}

		/// <summary>
		/// Obtiene el maximo de caracteres que permite el campo
		/// </summary>
		public int MaxCaracteres			
		{
			get {return atrMaxCaracteres;}
		}

		/// <summary>
		/// Obtiene el tipo de dato del campo
		/// </summary>
		public string TipoCampo				
		{
			get {return atrTipoCampo;}
		}

		/// <summary>
		/// Obtiene si el campo es de tipo opcional
		/// </summary>
		public bool Opcional				
		{
			get {return atrOpcional;}
		}

		/// <summary>
		/// Obtiene la descripcion del campo
		/// </summary>
		public string Descripcion			
		{
			get {return atrDescripcion;}
		}

		/// <summary>
		/// Obtiene si este campo es de solo lectura
		/// </summary>
		public bool SoloLectura				
		{
			get {return atrSoloLectura;}
		}

		/// <summary>
		/// Obtiene si este campo tiene alguna dependencia obligatoria
		/// </summary>
		public bool DependenciaObligatoria	
		{
			get {return atrDependenciaObligatoria;}
		}
		/// <summary>
		/// Obtiene si este campo tiene alguna dependencia no obligatoria
		/// </summary>
		public bool DependenciaNoObligatoria
		{
			get {return atrDependenciaNoObligatoria;}
		}		

		/// <summary>
		/// Obtiene el nombre del metacatalogo con el cual tiene la dependencia
		/// </summary>
		public string	Dependencia			
		{
			get{return atrDependencia;}
		}
//		public object ValorDefault	
//		{
//			get {return atrValorDefault;}
//		}
		#endregion //Publicos

		#endregion //Atributos
		
		#region  Constructor 

		/// <summary>
		/// Constructor 1
		/// </summary>
		/// <param name="drMetaCampo">Objeto DataReader que contiene los metacampos</param>
		public MetaCampo(System.Data.SqlClient.SqlDataReader drMetaCampo)
		{
			atrMetaCatalogo					=	(string)	drMetaCampo["cMetaCatalogo"];
			atrNombreCampo					=	(string)	drMetaCampo["cNombreCampo"];
			if (drMetaCampo["cDescripcion"] != System.DBNull.Value)
				atrDescripcion				=	(string)	drMetaCampo["cDescripcion"];
			atrSoloLectura					=	(Boolean)	drMetaCampo["bSoloLectura"];
			if (drMetaCampo["cDependencia"] != System.DBNull.Value)
				atrDependencia				=	(string)	drMetaCampo["cDependencia"];
			if (drMetaCampo["bDependenciaObligatoria"] != System.DBNull.Value)
				atrDependenciaObligatoria	=	(Boolean)	drMetaCampo["bDependenciaObligatoria"];
			if (drMetaCampo["bDependenciaNoObligatoria"] != System.DBNull.Value)
				atrDependenciaNoObligatoria	=	(Boolean)	drMetaCampo["bDependenciaNoObligatoria"];			
			atrNumeroCampo					=	(Int16)		drMetaCampo["nNumero"];
			atrMaxCaracteres				=	(Int16)		drMetaCampo["nMaxCaracteres"];
			atrTipoCampo					=	(string)	drMetaCampo["cTipoCampo"];
			atrOpcional						=	((Int32)	drMetaCampo["bOpcional"])==1;
//			atrValorDefault					=	(string) drMetaCampo["ValorPorDefault"];
		}

		/// <summary>
		/// COnstructor 2
		/// </summary>
		/// <param name="prmMetaCatalogo"></param>
		/// <param name="prmNombreCampo"></param>
		/// <param name="prmNumeroCampo"></param>
		/// <param name="prmMaxCaracteres"></param>
		/// <param name="prmTipoCampo"></param>
		/// <param name="prmOpcional"></param>
		/// <param name="prmDescripcion"></param>
		/// <param name="prmSoloLectura"></param>
		/// <param name="prmDependenciaObligatoria"></param>
		/// <param name="prmDependenciaNoObligatoria"></param>
		/// <param name="prmDependencia"></param>
		public MetaCampo(string prmMetaCatalogo, string prmNombreCampo, int prmNumeroCampo, int prmMaxCaracteres, string prmTipoCampo, bool prmOpcional, string prmDescripcion, bool prmSoloLectura, bool prmDependenciaObligatoria, bool prmDependenciaNoObligatoria, string prmDependencia) //, object prmValorDefault)
		{
			atrMetaCatalogo				=	prmMetaCatalogo;			
			atrNombreCampo				=	prmNombreCampo;
			atrNumeroCampo				=	prmNumeroCampo;
			atrMaxCaracteres			=	prmMaxCaracteres;
			atrTipoCampo				=	prmTipoCampo;
			atrOpcional					=	prmOpcional;
			atrDescripcion				=	prmDescripcion;
			atrSoloLectura				=	prmSoloLectura;
			atrDependenciaObligatoria	=	prmDependenciaObligatoria;
			atrDependenciaNoObligatoria	=	prmDependenciaNoObligatoria;
			atrDependencia				=	prmDependencia;
			//atrValorDefault			=	prmValorDefault;
		}

		
		#endregion  

	}
}
