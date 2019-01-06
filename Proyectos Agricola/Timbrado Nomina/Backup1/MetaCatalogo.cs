using System;
using System.Data;

namespace Sistema
{
	/// <summary>	
	/// Desarrollado Por : Lic. Alejandro Cons Gastélum Arámburo
	/// Fecha V1.1		 : Septiembre 2004
	/// Clase			 : MetaCatalogo
	/// Descripcion      : Tecnología de Catálogo
	/// Que Hace		 : Esta es la Clase que contiene la informacion obtenida de las 
	///					   tablas de Arquitectura de "MetaCatáogos" y "MetaCampos" necesarias
	///					   para la Generacion de Catalogos, tiene poca Funcionalidad debido a que
	///					   su único Objetivo es el de Contener los Metadatos sobre los cuales se
	///					   crearán los verdaderos Catálogos
	///					   
	/// </summary>	
	public class MetaCatalogo 
	{
		/// <summary>
		/// Evento que se dispara la cambiar el metacatalogo del catalogo
		/// </summary>
		public event EventHandler CambioMetaCatalogo;

		const string cnstTablaMetaCatalogos = "MetaCatalogos";
		const string cnstTablaMetaCampos    = "vwMetaCampos";

		#region Atributos

		#region Privados 
		
		private System.Collections.ArrayList	atrMetaCampos = new System.Collections.ArrayList();

		private TipoCriterio	atrTipoCriterioBusqueda;
		private string			atrNombreMetaCatalogo;
		private string			atrCampoPrimario;
		private string			atrCampoDescripcion;
		private string			atrCampoBusqueda;
		private string			atrSqlCatalogo;
		private string			atrSqlBusquedaRapida;		
		private int				atrCerosJustificar;
		private bool			atrCriterioObligatorio;
		private bool			atrCampoPrimarioNumerico;
		private bool			atrVacio;
		#endregion //Privados 

		#region Públicos
		
		/// <summary>
		/// Obtiene un arreglo con los metacampos del metacatalogo.
		/// </summary>
		public MetaCampo[]	MetaCampos
		{
			get
			{
				MetaCatalogo MC = null;
				return (MetaCampo[])atrMetaCampos.ToArray(MC.GetType());
			}
		}

		/// <summary>
		/// Obtiene el nombre del metacatlogo.
		/// </summary>
		public string		NombreMetaCatalogo		
		{
			get{return atrNombreMetaCatalogo;}
		}

		/// <summary>
		/// Obtiene el nombre del campo primario del metacatalogo
		/// </summary>
		public string		CampoPrimario			
		{
			get{return atrCampoPrimario;}
		}

		/// <summary>
		/// Obtiene el nombre del campo descripcion del metacatalogo.
		/// </summary>
		public string		CampoDescripcion		
		{
			get{return atrCampoDescripcion;}
		}

		/// <summary>
		/// Obtiene el nombre del campo de busqueda en el metacatalogo.
		/// </summary>
		public string		CampoDeBusqueda			
		{
			get{return atrCampoBusqueda;}
		}

		/// <summary>
		/// Obtiene el nombre de la vista de sql que utiliza el metacatalogo.
		/// </summary>
		public string		SqlVistaCatalogo		
		{
			get{return atrSqlCatalogo;}
		}	
	
		/// <summary>
		/// Obtiene el nombre de la vista de sql que se muestra en la ayuda del metacatalogo.
		/// </summary>
		public string		SqlVistaBusquedaRapida	
		{
			get{return atrSqlBusquedaRapida;}
		}

		/// <summary>
		/// Obtiene la cantidad de ceros a justificar hacia la izquierda en el campo primario del metacatalogo.
		/// </summary>
		public int			CerosJustificar		
		{
			get{return atrCerosJustificar;}
		}		

		/// <summary>
		/// Obtiene si es necesario proporcionar un criterio de busqueda obligatorio al solicitar la ayuda rapida.
		/// </summary>
		public bool			CriterioObligatorio		
		{
			get{return atrCriterioObligatorio;}
		}

		/// <summary>
		/// Determina si el campo primario es de tipo numerico.
		/// </summary>
		public bool			CampoPrimarioNumerico	
		{
			get{return atrCampoPrimarioNumerico;}
		}

		/// <summary>
		/// Determina si el metacatalogo cuenta con dependencias.
		/// </summary>
		public bool			TieneDependencias		
		{
			get{return (ObtenMetaCamposDependientes().Length!=0);	}
		}

		/// <summary>
		/// Determina si el valor del metacatalogo es vacio.
		/// </summary>
		public bool			Vacio					
		{
			get{return atrVacio;}
		}				

	
		#endregion //Públicos		

		#endregion //Atributos
		
		#region  Constructor 

		/// <summary>
		/// Sobrecarga 1.
		/// </summary>
		/// <param name="prmNombreMetaCatalogo">Nombre del Metacatlogo creado en la base de datos</param>
		public MetaCatalogo(string prmNombreMetaCatalogo)
		{			
			atrVacio = !SetMetaCatalogo(prmNombreMetaCatalogo);
		}

		/// <summary>
		/// Sobrecarga 2
		/// </summary>
		/// <param name="prmNombreMetaCatalogo">Nombre del Metacatlogo creado en la base de datos</param>
		/// <param name="prmCampoPrimario">Nombre del campo primario llave (este campo debe de existir en las 2 vistas del catalogo)</param>
		/// <param name="prmCampoDescripcion">Nombre del campo descripcion (este campo debe de existir en las 2 vistas del catalogo)</param>
		/// <param name="prmCampoBusqueda">Nombre del campo por el cual se realizara la busqueda (este campo debe de existir en las 2 vistas del catalogo)</param>
		/// <param name="prmSqlCatalogo">Nombre de la vista o tabla principal del catalogo</param>
		/// <param name="prmSqlBusquedaRapida">Nombre de la vista o tabla que se mostrara en la ayuda rapida</param>
		/// <param name="prmCerosJustificar">Numero de ceros a justificar en el campo principal</param>
		/// <param name="prmTipoCriterioBusqueda">Tipo de criterio de busqueda a aplicar</param>
		/// <param name="prmCriterioObligatorio">Determina si es obligatorio que al realizar una busqueda exista un criterio de filtrado o no</param>
		/// <param name="prmCampoPrimarioNumerico">Determina si tipo de dato del campo primario es numerico o no</param>
		/// <param name="prmMetaCampos">Arreglo con los metacampos de metacatalogo</param>
		public MetaCatalogo(string prmNombreMetaCatalogo,string prmCampoPrimario, string prmCampoDescripcion, string prmCampoBusqueda, string prmSqlCatalogo, string prmSqlBusquedaRapida, int prmCerosJustificar, int prmTipoCriterioBusqueda , bool prmCriterioObligatorio, bool prmCampoPrimarioNumerico, MetaCampo[] prmMetaCampos)
		{
			atrNombreMetaCatalogo = prmNombreMetaCatalogo;
			atrTipoCriterioBusqueda = new TipoCriterio(prmTipoCriterioBusqueda);
			atrCampoPrimario = prmCampoPrimario;
			atrCampoBusqueda = prmCampoBusqueda;
			atrCampoDescripcion = prmCampoDescripcion;
			atrSqlCatalogo = prmSqlCatalogo;
			atrSqlBusquedaRapida = prmSqlBusquedaRapida;
			atrCerosJustificar = prmCerosJustificar;
			atrCriterioObligatorio = prmCriterioObligatorio;
			atrCampoPrimarioNumerico = prmCampoPrimarioNumerico;
			
			atrMetaCampos.InsertRange(0, prmMetaCampos);
			atrVacio=false;
		}

		
		#endregion

		#region  Métodos 

		#region  Públicos 
	
		/// <summary>
		/// Funcion para Asignar el MetaCampo que al que pertenecerá el MetaCatálogo
		/// </summary>
		/// <param name="prmMetaCatalogo">Nombre del nuevo Metacatálogo</param>
		/// <returns>Regresa Cierto si logró aplicar el nuevo MetaCáologo o falso si no lo logró</returns>
		public bool SetMetaCatalogo(string prmMetaCatalogo)
		{	
			
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			
			//Select para Obtener los datos del MetaCatalogo desde las Tablas de Sistema
			string vSqlQuery = "SELECT * FROM " + cnstTablaMetaCatalogos + " WHERE cMetaCatalogo = '" + prmMetaCatalogo + "'";
			
			//Instanciamos una DataReader y le alimentamos los Datos del MetaCatálogo
			System.Data.SqlClient.SqlDataReader drMetaCatalogo = null;
			DAO.RegresaConsultaSQL(vSqlQuery, ref drMetaCatalogo);
			if (!drMetaCatalogo.Read())
			{				
				Tool.RaiseError("No se pudo Cargar cMetaCatálogo : " + prmMetaCatalogo + ". El MetaCatálogo no Existe");
				drMetaCatalogo.Close();
				return false;
			}
			
			//Select para Obtener los datos de los MetaCampos del MetaCatalogo desde las Tablas de Sistema
			vSqlQuery = "SELECT * FROM "+ cnstTablaMetaCampos +" WHERE cMetaCatalogo = '" + prmMetaCatalogo + "'";

			//Instanciamos una DataTable y le alimentamos los MetaCampos del MetaCatálogo
			System.Data.SqlClient.SqlDataReader drMetaCampos = null;
			DAO.RegresaConsultaSQL(vSqlQuery, ref drMetaCampos);

			if (!drMetaCampos.Read())
			{
				Tool.RaiseError("No se pudo Cargar MetaCatálogo : " + prmMetaCatalogo + ". El MetaCatálogo no tienen ni un solo MetaCampo");
				drMetaCampos.Close();
				drMetaCatalogo.Close();				
				return false;
			}
			
			//Pasamos los datos del Metacatálogo a lo Atributos de la Clase			
			atrNombreMetaCatalogo		= (string)drMetaCatalogo["cMetaCatalogo"];
			atrCampoPrimario			= (string)drMetaCatalogo["cCampoPrimario"];
			atrCampoDescripcion			= (string)drMetaCatalogo["cCampoDescripcion"];
			atrCampoBusqueda			= (string)drMetaCatalogo["cCampoBusqueda"];
			atrSqlCatalogo				= (string)drMetaCatalogo["cSQLCatalogo"];
			atrSqlBusquedaRapida		= (string)drMetaCatalogo["cSQLBusquedaRapida"];
			atrCerosJustificar			= (Int16)drMetaCatalogo["nCerosJustificar"];
			atrTipoCriterioBusqueda		= new TipoCriterio((Int16)drMetaCatalogo["ntipoCriterio"]);
			atrCriterioObligatorio		= (Boolean)drMetaCatalogo["bCriterioObligatorio"];
		

			//Pasamos los renglones de los MetaCampos a un arreglo de Objetos MetaCampos		
			atrMetaCampos.Clear();
			do
			{
				MetaCampo vMetaCampo =new MetaCampo(drMetaCampos);                
				if (vMetaCampo.NombreCampo.Trim().ToUpper() == atrCampoPrimario.Trim().ToUpper())
				{
					atrCampoPrimarioNumerico = Tool.EsTipoSqlNumerico(vMetaCampo.TipoCampo);
				}
				atrMetaCampos.Add(vMetaCampo);                
			}while (drMetaCampos.Read());
			
			
			drMetaCampos.Close();
			drMetaCatalogo.Close();			
			atrVacio = false;
			OnCambioMetaCatalogo();
			return true;			
		}

		/// <summary>
		/// Devuelve el valor primario especificado con el tipo de criterio correspondiente aplicado
		/// </summary>
		/// <param name="prmCriterio">Criterio a formular</param>
		/// <returns>Devuelve el ValorPrimario con el criterio aplicado necesario</returns>
		public string ValorConCriterio(string prmCriterio)
		{
			if (atrVacio) return "";
			return atrTipoCriterioBusqueda.ValorConCriterio(prmCriterio);
		}
		
		/// <summary>
		/// Obtiene el MetaCampo al que corresponda el Nombre de Metacampo especificado
		/// </summary>
		/// <param name="prmNombreMetaCampo">Nombre de MetaCampo a buscar</param>
		/// <returns>Devuelve una objeto Metacampo si encuentra ese nombre o null si no lo encuetra</returns>
		public MetaCampo ObtenMetaCampo(string prmNombreMetaCampo)
		{
			if (atrVacio) return null;
			foreach (MetaCampo campo in atrMetaCampos)
			{
				if (campo.NombreCampo == prmNombreMetaCampo)
				{
					return campo;
				}
			}
			return null;
		}

		/// <summary>
		/// Devuelve el valor primario especificado rellenado con los ceros designados en el Metacatálogo
		/// </summary>
		/// <param name="prmValorPrimario">Valor Primario a Rellenar</param>
		/// <returns>Devuelve el ValorPrimario con los ceros necesarios</returns>
		public string ValorPrimarioConCeros(string prmValorPrimario)
		{
			if (atrVacio || prmValorPrimario == "") return "";
			if (!atrCampoPrimarioNumerico)
			{
				return prmValorPrimario.Trim().ToUpper();
			}
			return Tool.RellenaCon(prmValorPrimario,atrCerosJustificar,'0');
		}
		
		/// <summary>
		/// Obtiene un vector de lo MetaCampos que son dependientes de algun metacatálogo
		/// </summary>
		/// <returns>Vector de MetaCampos Dependientes</returns>
		public MetaCampo[] ObtenMetaCamposDependientes()
		{
			if (atrVacio) return null;
			MetaCampo[] metaCamposDependientes = new MetaCampo[0];
			foreach (MetaCampo metaCampo in atrMetaCampos)
			{								
				if(metaCampo.DependenciaNoObligatoria || metaCampo.DependenciaObligatoria)
				{
					MetaCampo[] aux = new MetaCampo[metaCamposDependientes.Length+1];
					metaCamposDependientes.CopyTo(aux,0);
					aux[aux.Length-1] = metaCampo;
					metaCamposDependientes = aux;
				}
			}
			return metaCamposDependientes;
		}

		/// <summary>
		/// Devuelve la Lista de los Nombres de los Metacatalogos con quien tiene Dependencia
		/// </summary>
		/// <returns>Nombres de MegaCatalogos de quien depende</returns>
		public string[]	NombresMetaCatalogosDependencias()
		{
			if (atrVacio) return null;
			MetaCampo[] camposDep = this.ObtenMetaCamposDependientes();
			string[] dependencias = new string[camposDep.Length];
			for (int i = 0 ;i<camposDep.Length;i++)
				dependencias[i] = camposDep[i].Dependencia;
			return dependencias;
		}
		/// <summary>
		/// Verifica si el MetaCatalogo depende del MetaCatalogo especificado
		/// </summary>
		/// <param name="prmMetaCatalogo">Nombre del MetaCatalogo</param>
		/// <returns>Devuelve cierto si depende de tal Catalogo</returns>
		public bool DependoDe(string prmMetaCatalogo)
		{
			if (atrVacio) return false;
			return Tool.ExisteCadenaEnArreglo(this.NombresMetaCatalogosDependencias() , prmMetaCatalogo);
		}		
		/// <summary>
		/// Verifica si el MetaCatalogo depende del MetaCatalogo especificado
		/// </summary>
		/// <param name="prmMetaCatalogo">MetaCatalogo</param>
		/// <returns>Devuelve cierto si depende de tal Catalogo</returns>
		public bool DependoDe(MetaCatalogo prmMetaCatalogo)
		{
			if (atrVacio) return false;
			return DependoDe(prmMetaCatalogo.NombreMetaCatalogo);
		}		

		
		#endregion //Públicos

		#region  Protegidos 

		/// <summary>
		/// Metodo portegido que determina si el evento tiene asociados delegados y en caso de tenerlos los dispara.
		/// </summary>
		protected void OnCambioMetaCatalogo()
		{
			if (CambioMetaCatalogo != null)
			{
				CambioMetaCatalogo(this, new EventArgs());
			}
		}				

		
		#endregion  //Protegidos
		
		#endregion  //Métodos
	}
}