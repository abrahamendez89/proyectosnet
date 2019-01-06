using System;
using System.Data;


namespace Sistema
{
	/// <summary>
	/// Desarrollado Por : Lic. Alejandro Cons Gastélum Arámburo
	/// Fecha V1.1		 : Septiembre 2004
	/// Clase			 : Catalogo
	/// Descripcion      : Tecnología de Catálogo
	/// Que Hace		 : Esta es la Clase principal de la Funcionalidad de los MetaCatálogos
	///					   Es Aqui donde se llevan a cabo los accesos al Servidor para la 
	///					   consulta de Datos y su manejo para la implementacion de un Catálogo
	///					   en cualquier tipo de Control.
	///					   Contiene las Funciones necesarias para la Busqueda y la presentacion de
	///					   Grids de Seleccion de Elementos entre otras
	///					   
	/// </summary>		
	public class Catalogo
	{	
		/// <summary>
		/// Evnto que se dispara al llenar la tabla del Catalogo.
		/// </summary>
		public event EventHandler LlenoTabla;
		/// <summary>
		/// Evento que se dispara al cambiar el valor de dependencia del Catalogo.
		/// </summary>
		public event EventHandler CambioValorDependencia;
		/// <summary>
		/// Evnto que se dispara al cambiar de Catalogo.
		/// </summary>
		public event EventHandler CambioCatalogo;
		/// <summary>
		/// Evnto que se dispara al darse el Evento CambioElemento.
		/// </summary>
		public event EventHandler SeleccionoElemento;

//		/// <summary>
//		/// Delegado para el evento ObtencionElemento.
//		/// </summary>
//		public delegate void ObtenElementoRowEventHandler(object sender ,DataRow Row);
//
//		/// <summary>
//		/// Evento que se dispara al ejecutarse el metodo ObtenElementoRow.
//		/// </summary>
//		public event ObtenElementoRowEventHandler ObtencionElemento;

		/// <summary>
		/// Delegado para el evento ObtenerObjetoCatalogo
		/// </summary>
		public delegate object ObtenerObjetoCatalogoEventHandler(DataRow Row);

		/// <summary>
		/// Evento que se dispara al darse un cambio de elemento.
		/// </summary>
		public event ObtenerObjetoCatalogoEventHandler ObtenerObjetoCatalogo;


		
		#region Atributos 
		
		#region Privados
		
		private MetaCatalogo		atrMetaCatalogoBase;
		private DataTable			atrTablaCatalogo;		
		private ValorDependencia[]	atrValoresDeDependencias;
		private string				atrCriterio;
		
		private string				atrCadenaDescripcionNoValida;
		internal string				atrCadenaCriterioObligatorio;

		private string				atrFiltroExtendido = "";
		private string				atrCamposOrdenados = "";

		private string				atrCamposMostradosBR = "";
		private bool				atrMostrarAyudaConNuevoFiltrado;
		private ClsParametrosRegresaNuevaEleccionUsuario atrParametrosRegresaNuevaEleccionUsuario;
		
		private Object atrObjetoActual;

		#endregion //Privados
		
		#region Públicos


		/// <summary>
		/// Define los parametros adicionales para la nueva eleccion de usuario
		/// </summary>
		public ClsParametrosRegresaNuevaEleccionUsuario ParametrosRegresaNuevaEleccionUsuario{
			get{return atrParametrosRegresaNuevaEleccionUsuario;}
		}

		/// <summary>
		/// Define si se mostrara la nueva opcion de ayuda rapida en el catalogo
		/// </summary>
		public bool MostrarAyudaConNuevoFiltrado{
			get{return atrMostrarAyudaConNuevoFiltrado;}
			set{atrMostrarAyudaConNuevoFiltrado = value;}
		}

		/// <summary>
		/// Instancia del objeto actual del catalogo que se obtiene a traves del evento ObtenerObjetoCatalogo.
		/// </summary>
		public object ObjetoActual{
			get{return atrObjetoActual;}
			set{atrObjetoActual = value;}
		}

		/// <summary>
		/// Obtiene el Metacatalogo base para este Catalogo.
		/// </summary>
		public MetaCatalogo MetaCatalogoBase			
		{
			get {return atrMetaCatalogoBase;}
		}

		/// <summary>
		/// Obtiene el Objeto DataTable de este Catalogo.
		/// </summary>
		public DataTable TablaCatalogo					
		{
			get {
				if (atrTablaCatalogo == null)
					LlenarTablaDelCatalogo();
				return atrTablaCatalogo;
			}
		}		

		/// <summary>
		/// Obtiene o establece el criterio del Catalogo.
		/// </summary>
		public string Criterio							
		{
			get {return atrMetaCatalogoBase.ValorConCriterio(atrCriterio);}
			set {atrCriterio = value;}
		}

		/// <summary>
		/// Obtiene un arreglo con los valores de dependencia del Catalogo.
		/// </summary>
		public ValorDependencia[] ValoresDeDependencias	
		{
			get{return atrValoresDeDependencias;}
		}

		/// <summary>
		/// Obtiene o establece la cadena de descripcion que se desplegara en el
		/// control destino cuando se produzca un valor no valido en el Catalogo.
		/// </summary>
		public string		CadenaDescripcionNoValida	
		{
			get{return  atrCadenaDescripcionNoValida;}
			set{atrCadenaDescripcionNoValida = value;}
		}

		/// <summary>
		/// Obtiene el nombre del metacatalogo que contiene este Catalogo.
		/// </summary>
		public string		NombreMetaCatalogo			
		{
			get { return atrMetaCatalogoBase.NombreMetaCatalogo; }
		}
		
		/// <summary>
		/// Determina si el valor actual del Catalogo es vacio.
		/// </summary>
		public bool Vacio								
		{
			get 
			{
				if (atrMetaCatalogoBase!=null)
					return atrMetaCatalogoBase.Vacio;
				return true;
			}
		}

		/// <summary>
		/// Obtiene o establece la cadena que se utilizara como un filtro adicional
		/// al query que obtendra los datos del catalogo.
		/// Ejemplo. " nClave = 10 AND bEstatus = 1".
		/// </summary>
		public string FiltroExtendido
		{
			get{return atrFiltroExtendido ;}
			set{atrFiltroExtendido = value;}
		}

		/// <summary>
		/// Obtiene o establece una cadena con los nombres de los campos
		/// con los cuales se ordenara la Ayuda Rapida, estos nombres de campo deben de existir
		/// en la Vista o Tabla especeificadas para el Metacatalogo.
		/// Ejemplo. "nClave DESC".
		/// </summary>
		public string CamposOrdenados
		{
			get{return atrCamposOrdenados ;}
			set{atrCamposOrdenados = value;}
		}

		/// <summary>
		/// Obtiene o establece una cadena con los nombres de los campos
		/// a mostrar en la Ayuda Rapida, estos nombres de campo deben de existir
		/// en la Vista o Tabla especeificadas para el Metacatalogo.
		/// Ejemplo. " cDescripcion AS Descripcion ,nClave".
		/// Nota: Recuerde que el ultimo campo de esta vista debe ser la llave del Catalogo.
		/// </summary>
		public string CamposMostrados
		{
			get{return atrCamposMostradosBR;}
			set
			{ 
				DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
				if (DAO.EjecutaComandoSQL("SELECT " + value + " FROM " + atrMetaCatalogoBase.SqlVistaBusquedaRapida + " WHERE (1 = 0)"))
					atrCamposMostradosBR = value;
				else
				{
					throw (new Exception("Alguno de los Campos : '" + value +
						"' no existen en la vista del Metacatálogo : " + atrMetaCatalogoBase.NombreMetaCatalogo + 
						", en su vista de Busqueda Rápida: " + atrMetaCatalogoBase.SqlVistaBusquedaRapida));
				}			
			}
		}
		
		#endregion //Públicos
		
		#endregion //Atributos 
		
		#region Constructor

		/// <summary>
		/// Constructor base del Catalogo.
		/// </summary>
		/// <param name="metaCatalogoBase">Objeto Metacatalogo del cual se partira para crear el Catalogo</param>
		public Catalogo(MetaCatalogo metaCatalogoBase)
		{			
			SetCatalogo(metaCatalogoBase);
			atrCadenaCriterioObligatorio = "Por favor especifique un criterio ya que es obligatorio para el catálogo : ";
			atrCadenaDescripcionNoValida = "";
			atrCamposOrdenados = metaCatalogoBase.CampoDescripcion;
			atrMostrarAyudaConNuevoFiltrado = true;
			atrParametrosRegresaNuevaEleccionUsuario = new ClsParametrosRegresaNuevaEleccionUsuario();
		}		
		
		
		#endregion //Constructor

		#region Métodos 

		#region Privados

		private void Catalogo_CambioValorDependencia(object sender, EventArgs e)
		{
			OnCambioValorDependencia(sender, e);
		}		

		#endregion //Privados

		#region Públicos
		/// <summary>
		/// Formula una Sentencia Select para una eleccion de una clave
		/// basado en la Vista SQLBusquedaRapida
		/// </summary>
		/// <param name="prmCriterioDeBusqueda">Criterio de busqueda para filtrar los registrso</param>
		/// <returns>Regresa una cadena con una instruccion Select</returns>
		public string GetQueryBusquedaRapida(string prmCriterioDeBusqueda)
		{
			if (Vacio) return "";
			return GetQuery(atrMetaCatalogoBase.SqlVistaBusquedaRapida, prmCriterioDeBusqueda, false);
		}	
		/// <summary>
		/// Formula una Sentencia Select para obtener un elemento único
		/// basado en la Vista de SQLCatalogo
		/// </summary>
		/// <param name="prmValorPrimario">Clave primaria del elemento a buscar</param>
		/// <returns>Regresa una cadena con una instruccion Select</returns>
		public string GetQueryElementoUnico(string prmValorPrimario)
		{
			if (Vacio) return "";
			return GetQuery(atrMetaCatalogoBase.SqlVistaCatalogo, prmValorPrimario, true);
		}
		/// <summary>
		/// Formula una Sentencia Select para llenar la tabla de elementos del Catalogo
		/// basado en la Vista de SQLCatalogo
		/// </summary>	
		/// <returns>Regresa una cadena con una instruccion Select</returns>
		public string GetQueryParaTabla()
		{
			if (Vacio) return "";
			return GetQuery(atrMetaCatalogoBase.SqlVistaCatalogo, "", false);
		}

		/// <summary>
		/// Arma un Query de SQL apartir de los valores de las Dependencias del catálogo, segun
		/// </summary>
		/// <param name="prmVistaDeBusqueda">Vista en la cual se basará para armar el query</param>
		/// <param name="prmCriterioActual">Criterio de busqueda para el filtrado de los Datos</param>
		/// <param name="prmCriterioActualPrimario">
		/// Determina si el criterio proporcionado es en realidad una clave primaria
		/// </param>
		/// <returns>Regresa una cadena con una instruccion Select 
		/// o una cadena vacia si no fue posible armar el query
		/// </returns>
		private string GetQuery(string prmVistaDeBusqueda, string prmCriterioActual, bool prmCriterioActualPrimario)
		{
			if (Vacio) return "";
			string sqlQuery  = "SELECT * FROM " + prmVistaDeBusqueda + "(NOLOCK)";
			if ((prmVistaDeBusqueda == atrMetaCatalogoBase.SqlVistaBusquedaRapida )&& atrCamposMostradosBR != "")
				sqlQuery  = "SELECT " + atrCamposMostradosBR + " FROM " + prmVistaDeBusqueda;
			
			atrCriterio = prmCriterioActual;

			if (!prmCriterioActualPrimario)
			{
//				sqlQuery += " WHERE (" +	atrMetaCatalogoBase.CampoDeBusqueda;
//				sqlQuery += " LIKE '"	 +	Criterio + "'";
//				sqlQuery += " OR     " +	atrMetaCatalogoBase.CampoDescripcion;
//				sqlQuery += " LIKE '"	 +	Criterio + "')";
				sqlQuery += " WHERE (1 = 1) ";
			}
			else
			{
				sqlQuery += " WHERE (" + atrMetaCatalogoBase.CampoPrimario;
				if (atrMetaCatalogoBase.CampoPrimarioNumerico)
				{
					if (!Tool.EsNumeroEntero(prmCriterioActual)) return "";
					sqlQuery += " = "  + prmCriterioActual +  ")";
				}
				else
				{
					sqlQuery += " = '" + prmCriterioActual + "')";
				}
			}
			

			if (atrValoresDeDependencias != null)
			{				
				foreach (ValorDependencia valorDep in atrValoresDeDependencias)
				{
					if (valorDep.Valor == "" && valorDep.DependenciaObligatoria) 
						return "";
					if (valorDep.Valor != "")
					{
						sqlQuery += " AND " + valorDep.MetaCampoDependiente.NombreCampo;					
						if (valorDep.MetaCatalogoDependencia.CampoPrimarioNumerico)
						{
							sqlQuery += " =  " + valorDep.Valor ;
						}
						else
						{
							sqlQuery += " = '" + valorDep.Valor + "'";
						}
					}
				}
			}
			if ("" + atrFiltroExtendido != "" )
				sqlQuery += " AND " + atrFiltroExtendido;

			if ("" + atrCamposOrdenados!="" && !atrMostrarAyudaConNuevoFiltrado)
				sqlQuery += " ORDER BY " + atrCamposOrdenados;

			return sqlQuery;
		}
	
		/// <summary>
		/// Determina el Metacatalogo en base al cual se creará el Catálogo
		/// </summary>
		/// <param name="prmMetaCatalogo">Nombre del MetaCatálogo</param>
		/// <returns>Regresa Cierto si tuvo éxito o Falso si fracasó</returns>
		public bool SetCatalogo(MetaCatalogo prmMetaCatalogo)
		{
			atrMetaCatalogoBase = prmMetaCatalogo;

			atrTablaCatalogo = null;
			atrCriterio="";
			
			MetaCampo[] metaCamposDependientes = MetaCatalogoBase.ObtenMetaCamposDependientes();
			if (metaCamposDependientes!=null)
			{
				atrValoresDeDependencias = new ValorDependencia[metaCamposDependientes.Length];
				for(int i = 0 ; i < metaCamposDependientes.Length ; i++ )
				{
					MetaCatalogo mc = new MetaCatalogo(metaCamposDependientes[i].Dependencia);
					atrValoresDeDependencias[i] = new ValorDependencia(this, mc, metaCamposDependientes[i]);
					atrValoresDeDependencias[i].CambioValorDependencia += new EventHandler(Catalogo_CambioValorDependencia);
				}
			}
			OnCambioCatalogo(this, new EventArgs());
			return true;
		}

		/// <summary>
		///  Llenar la Tabla del Catalogo con los Datos del catálogo filtrados por sus Dependencias
		/// </summary>		
		/// <returns>Devuelve cierto si fué posible llenar la Tabla o Falso si fracasó</returns>
		public bool LlenarTablaDelCatalogo()
		{
			if (Vacio) return false;			
			atrTablaCatalogo = new System.Data.DataTable(NombreMetaCatalogo);
			string sqlQuery = GetQueryParaTabla();
			if (sqlQuery == "") return false;			 
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			DAO.RegresaConsultaSQL(sqlQuery, ref atrTablaCatalogo);			
			if (atrTablaCatalogo.Rows.Count != 0)
			{				
				OnLlenarTabla(this, new EventArgs());
				return true;
			}
			return false;
		}
		/// <summary>
		/// Regresa un string con la selección de un elemento segun catalogo 
		/// a partir de un criterio
		/// </summary>
		/// <param name="prmCriterio">Criterio para la busqueda</param>	
		/// <returns> Devuelve el valor de la ultima columna de la vista de Busqueda Rápida del Catalogo
		/// o regresa "*" si no fue posible armar el Query, por que no se Obtuvieron todas las Dependencias
		/// </returns>
		public string  RegresaEleccionDeUsuario(string prmCriterio)
		{			
			if (Vacio || !this.ObtenValoresDependencias()) return "*";			
			while (prmCriterio == "" && atrMetaCatalogoBase.CriterioObligatorio && !atrMostrarAyudaConNuevoFiltrado)
			{
				prmCriterio = Tool.ShowInputBox(atrCadenaCriterioObligatorio);
			}
			if (prmCriterio == "*")
			{
                return  "*";
			}
			string sqlQuery = GetQueryBusquedaRapida(prmCriterio);
			if (sqlQuery == "")
				return "*";		
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			string sel = "*";
			if(atrMostrarAyudaConNuevoFiltrado)				
				sel = DAO.RegresaEleccionDeUsuarioSobreConsultaSQL(sqlQuery ,atrMetaCatalogoBase.CriterioObligatorio ,atrMetaCatalogoBase.CampoDescripcion ,atrParametrosRegresaNuevaEleccionUsuario.NombresFisicosDeColumnas ,atrParametrosRegresaNuevaEleccionUsuario.ConsultaSQLComplementaria ,atrParametrosRegresaNuevaEleccionUsuario.CamposDeRelacion);
			else
				sel = DAO.RegresaEleccionDeUsuarioSobreConsultaSQL(sqlQuery);
			if (sel == "*")	return "*";
			OnSeleccionoElemento(this, new EventArgs());
			return ValorPrimarioConCeros(sel);
		}
		/// <summary>
		/// Obtener un elemento determinado a partir de su 
		/// Campo Primario en un DataRow con todos sus campos
		/// </summary>
		/// <param name="prmValorPrimario">Valor del campo primario del catlogo</param>
		/// <returns>Devuelve un DataRow con el elemnto ecnontrado o null si no lo encontró</returns>
		public DataRow ObtenElementoRow(string prmValorPrimario)
		{			
			if (Vacio || prmValorPrimario == "" || (atrMetaCatalogoBase.CampoPrimarioNumerico && !Tool.EsNumeroEntero(prmValorPrimario))){
				atrObjetoActual = null;
				return null;
			}
				
			DataTable dttElemento = new DataTable();
			string sqlQuery = GetQueryElementoUnico(prmValorPrimario);
			if (sqlQuery == "") return null;			
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			DAO.RegresaConsultaSQL(sqlQuery, ref dttElemento);
			if (dttElemento.Rows.Count > 0 ){
				OnObtenerObjetoCatalogo(dttElemento.Rows[0]);
				return dttElemento.Rows[0];
					}				
			atrObjetoActual = null;
			return null;
		}

		/// <summary>
		/// Metodo protegido que determina si existen delegados para el evento ObtenerObjetoCatalogo.
		/// </summary>
		/// <param name="Row">DaataRow de la vista principal del catalogo</param>
		protected void OnObtenerObjetoCatalogo(DataRow Row){
			if (this.ObtenerObjetoCatalogo != null)
				atrObjetoActual = this.ObtenerObjetoCatalogo(Row);
			else
				atrObjetoActual = null;
		}

		/// <summary>
		/// Obtiene el valor Rellenado con los ceros especificados en el MetaCatálogo
		/// </summary>
		/// <param name="prmValorPrimario">Recibe el valor a rellenar con ceros</param>
		/// <returns>Devuelve el valor primario con los ceros segun el MetaCatalogo</returns>
		public string ValorPrimarioConCeros(string prmValorPrimario)
		{
			return atrMetaCatalogoBase.ValorPrimarioConCeros(prmValorPrimario);
		}

		/// <summary>
		/// Obtiene los valores de las dependencias Obligatorias del catálogo que estén vacios
		/// </summary>
		/// <returns>Devuelve Verdadero si las Obtuvo Todas o Falso si el usuario 
		/// no selecciono alguna dependencia obligatoria
		/// </returns>
		public bool ObtenValoresDependencias()
		{
			if (Vacio) return false;
			if (atrValoresDeDependencias == null) return true;
			foreach(ValorDependencia valorDep in atrValoresDeDependencias)
			{
				if (valorDep.DependenciaObligatoria && valorDep.Valor == "")
				{							
					Catalogo catalogoDependencia = new Catalogo(valorDep.MetaCatalogoDependencia);
					string seleccion = catalogoDependencia.RegresaEleccionDeUsuario("");
					if (seleccion != "*")
						valorDep.Valor = seleccion;
					else
						return false;
				}				
			}
			return true;
		}
		
		/// <summary>
		/// Busca la dependencia con el Metacatálogo especificado y le asigna el valor señalado
		/// </summary>
		/// <param name="prmMetaCatalogoDependencia">
		/// Nombre del MetaCatálogo de la dependencia 
		/// a la que se le va a aplicar el valor
		/// </param>
		/// <param name="prmValorPrimario">Valor a asignar al "Valor de dependencia"</param>
		/// <returns>Regresa Cierto si encontró el MetaCatálogo especificado en los Valores 
		/// de dependencia del Catalogo o Falso si no lo hizo
		/// </returns>
		public bool SetValorDeDependecia(string prmMetaCatalogoDependencia, string prmValorPrimario)
		{
			if (Vacio || atrValoresDeDependencias == null) return false;
			foreach (ValorDependencia valorDep in atrValoresDeDependencias)
			{
				if (valorDep.MetaCatalogoDependencia.NombreMetaCatalogo == prmMetaCatalogoDependencia)
				{					
					valorDep.Valor = (string)Tool.IIF(prmValorPrimario == "", "", valorDep.MetaCatalogoDependencia.ValorPrimarioConCeros(prmValorPrimario));
					return true;
				}
			}
			Tool.RaiseError("El Metacatálogo '" + this.NombreMetaCatalogo + "' no depende del MetaCatalogo '" + prmMetaCatalogoDependencia + "'");
			return false;
		}

		/// <summary>
		/// Le asigna el valor especificado al valor de dependencia especificado
		/// </summary>
		/// <param name="prmValorDep">Valor de Dependencia al que se le va a aplicar el valor</param>
		/// <param name="prmValorPrimario">Valor a especificar en el "Valor de dependencia"</param>		
		public void SetValorDeDependecia(ValorDependencia prmValorDep, string prmValorPrimario)
		{
			prmValorDep.Valor = prmValorDep.MetaCatalogoDependencia.ValorPrimarioConCeros(prmValorPrimario);
		}			
		/// <summary>
		/// Busca la dependencia con el Metacatálogo especificado y limpia su valor
		/// </summary>
		/// <param name="prmMetaCatalogoDependencia">Nombre del MetaCatálogo de la dependencia a la que se le va a aplicar el valor</param>
		/// <returns>Regresa Cierto si encontró el MetaCatálogo especificado en los Valores 
		/// de dependencia del Catalogo o Falso si no lo hizo
		/// </returns>
		public bool LimpiarValorDependencia(string prmMetaCatalogoDependencia)
		{
			if (Vacio || atrValoresDeDependencias == null) return false;
			return SetValorDeDependecia(prmMetaCatalogoDependencia, "");
		}
		/// <summary>
		/// Limpia los todos los Valores de dependencia del Catalogo
		/// </summary>
		public void LimpiarValoresDependencias()
		{			
			if (Vacio || atrValoresDeDependencias == null)
				return;
			foreach (ValorDependencia valorDep in atrValoresDeDependencias)
			{
				valorDep.Valor = "";
			}
		}

		/// <summary>
		/// Verifica si el Catalogo depende del MetaCatalogo especificado
		/// </summary>
		/// <param name="prmMetaCatalogo">Nombre del Metacatalogo</param>
		/// <returns>Devuelve cierto si depende de tal Metacatalogo</returns>
		public bool DependoDe(string prmMetaCatalogo)
		{
			if (Vacio) return false;
			return atrMetaCatalogoBase.DependoDe(prmMetaCatalogo);
		}
		/// <summary>
		/// Verifica si el Catalogo depende del Catalogo especificado
		/// </summary>
		/// <param name="prmCatalogo">Catalogo</param>
		/// <returns>Devuelve cierto si depende de tal Catalogo</returns>
		public bool DependoDe(Catalogo prmCatalogo)
		{	
			if (Vacio) return false;
			return DependoDe(prmCatalogo.atrMetaCatalogoBase.NombreMetaCatalogo);
		}
		


		#endregion //Públicos
		
		#endregion //Métodos 

		#region Eventos Protegidos 
		
		
		/// <summary>
		/// Metodo que determina si se lanzara el evento LlenoTabla.
		/// </summary>
		/// <param name="sender">Objeto que dispara este evento</param>
		/// <param name="e">Valores del evento</param>
		protected void OnLlenarTabla(Object sender, EventArgs e)
		{
			if (LlenoTabla != null) 	
			{					
				LlenoTabla(sender, e); 
			}
		}

		/// <summary>
		/// Metodo que determina si se lanzara el evento CambioValorDependencia.
		/// </summary>
		/// <param name="sender">Objeto que dispara este evento</param>
		/// <param name="e">Valores del evento</param>
		protected void OnCambioValorDependencia(Object sender, EventArgs e)
		{
			if (CambioValorDependencia != null) 	
			{					
				CambioValorDependencia(sender, e); 
			}
		}

		/// <summary>
		/// Metodo que determina si se lanzara el evento CambioCatalogo.
		/// </summary>
		/// <param name="sender">Objeto que dispara este evento</param>
		/// <param name="e">Valores del evento</param>
		protected void OnCambioCatalogo(Object sender, EventArgs e)
		{
			if (CambioCatalogo != null) 	
			{					
				CambioCatalogo(sender, e); 
			}
		}		

		



		/// <summary>
		/// Metodo que determina si se lanzara el evento SeleccionoElemento.
		/// </summary>
		/// <param name="sender">Objeto que dispara este evento</param>
		/// <param name="e">Valores del evento.</param>
		protected void OnSeleccionoElemento(Object sender, EventArgs e)
		{
			if (SeleccionoElemento != null) 	
			{					
				SeleccionoElemento(sender, e); 
			}
		}
		
		#endregion //Eventos Protegidos 
	}
}
