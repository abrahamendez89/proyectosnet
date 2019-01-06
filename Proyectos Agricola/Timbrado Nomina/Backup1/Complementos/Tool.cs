using System;
using System.Windows.Forms;
using System.Data;

namespace Sistema
{
	/// <summary>	
	/// Desarrollado Por : Lic. Alejandro Cons Gastélum Arámburo
	/// Fecha V1.1		 : Septiembre 2004
	/// Clase			 : Tool
	/// Descripcion      : Clase de Herramientas Varias Totalmente Estática
	/// Que Hace		 : Esta Clase Contiene Diversas Funciones Complementarias 
	///					   utilizadas en el Desarrollo del MetaCatálogo
	/// </summary>
	public class Tool
	{
		#region Metodos Estáticos

		/// <summary>
		/// Verifica si una cadena en particular se encuentra contenida en un arreglo de cadenas
		/// </summary>
		/// <param name="prmCadenas">Arrego de Cadenas donde buscar</param>
		/// <param name="prmCadena">Cadena a buscar</param>
		/// <returns>regresa Cierto la cadena se encuentra en el arreglo o falso si no es asi</returns>		
		public static bool ExisteCadenaEnArreglo(string[] prmCadenas, string prmCadena)
		{
			if (prmCadenas == null) return false;
			foreach (string c in prmCadenas)
				if (c == prmCadena) return true;
			return false;
		}

		/// <summary>
		/// Verifica si un objeto en particular se encuentra contenido en un arreglo de objetos
		/// </summary>
		/// <param name="prmArreglo">Arrego de Objetos donde buscar</param>
		/// <param name="prmObjeto">Objeto a buscar</param>
		/// <returns>regresa Cierto el Objeto se encuentra en el arreglo de Objetos o falso si no es asi</returns>
		public static bool ExisteObjetoEnArreglo(System.Array prmArreglo, object prmObjeto)
		{
			if (prmArreglo == null) return false;
			foreach (object o in prmArreglo)
				if (o == prmObjeto) return true;
			return false;
		}

		/// <summary>
		/// Copia un arreglo Bidimensional de Objetos a un arreglo destino de igual o mayora tamaño
		/// </summary>
		/// <param name="prmArregloOrigen">Arreglo Bidimensional Origen</param>
		/// <param name="prmArregloDestino">Arreglo Bidimensional Destino</param>
		public static void CopiaArregloBidimensional(System.Array prmArregloOrigen, ref System.Array prmArregloDestino)
		{
			for (int x = 0 ; x < prmArregloOrigen.GetUpperBound(0) ; x ++)
			{
				for (int y = 0 ; y < prmArregloOrigen.GetUpperBound(1) ; y ++)
				{
					prmArregloDestino.SetValue(prmArregloOrigen.GetValue(x,y),x,y);
				}
			}
		}
		/// <summary>
		/// Copia un arreglo Tridimensional de Objetos a un arreglo destino de igual o mayora tamaño
		/// </summary>
		/// <param name="prmArregloOrigen">Arreglo Tridimensional Origen</param>
		/// <param name="prmArregloDestino">Arreglo Tridimensional Destino</param>
		public static void CopiaArregloTridimensional(System.Array prmArregloOrigen, ref System.Array prmArregloDestino)
		{
			object[,,] vOrigen = (object[,,])prmArregloOrigen;
			object[,,] vDestino = (object[,,])prmArregloDestino;
			for (int x = 0 ; x < vOrigen.GetUpperBound(0) ; x ++)
			{
				for (int y = 0 ; y < vOrigen.GetUpperBound(1) ; y ++)
				{
					for (int z = 0 ; z < vOrigen.GetUpperBound(2) ; z ++)
					{
						vDestino[x,y,z] = vOrigen[x,y,z];
					}
				}
			}
		}

		/// <summary>
		/// Llena un control ListView con los Datos de un DataTable especificado -alexCons
		/// </summary>
		/// <param name="prmLista">Control List View que se llenará con los datos de la Tabla</param>
		/// <param name="prmTabla">Tabla de la cual se tomarán los Datos para llenar el List View</param>
		/// <returns>Regresa Cierto si tuvo éxito o Falso si fracasó</returns>
		public static bool LlenarListViewConTabla(System.Windows.Forms.ListView prmLista, System.Data.DataTable prmTabla)
		{
			if (prmLista==null || prmTabla==null) {return false;}
			int i = 0;
			prmLista.Clear();
			foreach(System.Data.DataRow row in prmTabla.Rows)
			{
				prmLista.Items.Add(row[0].ToString());
				if (i == 0)
				{
					prmLista.Columns.Add(prmTabla.Columns[0].ColumnName, 80, System.Windows.Forms.HorizontalAlignment.Left);
				}
				for(int j = 1;j<row.ItemArray.Length;j++)
				{
					if (i == 0)
					{
						prmLista.Columns.Add(prmTabla.Columns[j].ColumnName, 80, System.Windows.Forms.HorizontalAlignment.Left);
					}					
					prmLista.Items[i].SubItems.Add(row[j].ToString());
				}
				i++;
			}
			return true;
		}

		/// <summary>
		/// Verifica si la cadena es un numero entero válido
		/// </summary>
		/// <param name="prmCadena">Cadena a verificar</param>
		/// <returns>Regresa Cierto si la cadena contiene un valor entero válido o falso si no lo es</returns>
		public static bool EsNumeroEntero(string prmCadena)
		{				
			if (prmCadena == null || prmCadena == "" )
			{
				return false;
			}
			System.Text.RegularExpressions.Regex IsNumberExp = new System.Text.RegularExpressions.Regex(@"^\d+$");
			System.Text.RegularExpressions.Match m = IsNumberExp.Match(prmCadena.Trim());
			return m.Success;		
		}

		/// <summary>
		/// Verifica si la cadena es un numero entero válido
		/// </summary>
		/// <param name="prmCadena">Cadena a verificar</param>
		/// <returns>Regresa Cierto si la cadena contiene un valor entero válido o falso si no lo es</returns>
		public static bool EsNumeroReal(string prmCadena)
		{
			if (prmCadena == null || prmCadena == "" )
			{
				return false;
			}

			System.Text.RegularExpressions.Regex IsNumberExp = new System.Text.RegularExpressions.Regex(@"^\d*\.\d+$");
			System.Text.RegularExpressions.Match m = IsNumberExp.Match(prmCadena.Trim());
			return m.Success||EsNumeroEntero(prmCadena);
		}		

		/// <summary>
		/// llenar a unh Listview con un arreglo de MetaCampos
		/// </summary>
		/// <param name="prmListaCampos">ListView a Poblar con las propiedades de los MetaCampos</param>
		/// <param name="prmMetaCampos">Arreglo de MetaCampos a desplegar</param>
		public static void LlenaListaConMetaCampos(System.Windows.Forms.ListView prmListaCampos, MetaCampo[] prmMetaCampos)
		{
			prmListaCampos.Clear();
			prmListaCampos.Columns.Add("NombreCampo", 80, System.Windows.Forms.HorizontalAlignment.Left);
			prmListaCampos.Columns.Add("NumeroCampo", 80, System.Windows.Forms.HorizontalAlignment.Left);
			prmListaCampos.Columns.Add("TipoCampo", 80, System.Windows.Forms.HorizontalAlignment.Left);
			prmListaCampos.Columns.Add("MaxCaracteres", 80, System.Windows.Forms.HorizontalAlignment.Right);
			prmListaCampos.Columns.Add("Opcional", 80, System.Windows.Forms.HorizontalAlignment.Center);
			prmListaCampos.Columns.Add("Descripcion", 80, System.Windows.Forms.HorizontalAlignment.Left);
			prmListaCampos.Columns.Add("DependenciaObligatoria", 80, System.Windows.Forms.HorizontalAlignment.Left);
			prmListaCampos.Columns.Add("DependenciaNoObligatoria", 80, System.Windows.Forms.HorizontalAlignment.Left);
			prmListaCampos.Columns.Add("Dependencia", 80, System.Windows.Forms.HorizontalAlignment.Left);

			int i = 0;		
			foreach(MetaCampo vMetacampo in prmMetaCampos)
			{
				prmListaCampos.Items.Add(vMetacampo.NombreCampo);
				prmListaCampos.Items[i].SubItems.Add(vMetacampo.NumeroCampo.ToString());
				prmListaCampos.Items[i].SubItems.Add(vMetacampo.TipoCampo);
				prmListaCampos.Items[i].SubItems.Add(vMetacampo.MaxCaracteres.ToString());
				prmListaCampos.Items[i].SubItems.Add(vMetacampo.Opcional.ToString());
				prmListaCampos.Items[i].SubItems.Add(vMetacampo.Descripcion);
				prmListaCampos.Items[i].SubItems.Add(vMetacampo.DependenciaObligatoria.ToString());
				prmListaCampos.Items[i].SubItems.Add(vMetacampo.DependenciaNoObligatoria.ToString());
				if (vMetacampo.Dependencia!=null)
					prmListaCampos.Items[i].SubItems.Add(vMetacampo.Dependencia.ToString());
				i++;
			}
		}
		
		
		/// <summary>
		/// Esto sirve para determinar si el Campo Primario del Metacatálogo es Numerico
		/// </summary>
		/// <param name="prmTipoDeDatosSql">Nombre de tipo de Dato SQL</param>
		/// <returns></returns>
		public static bool EsTipoSqlNumerico(string prmTipoDeDatosSql)
		{
			switch(prmTipoDeDatosSql)
			{
				case "bigint":
				case "binary":
				case "bit":
				case "decimal":
				case "float":
				case "int":
				case "money":
				case "numeric":
				case "real":
				case "smallint":
				case "smallmoney":
				case "tinyint":
					return true;
				default:
					return false;
			}
		}

        /// <summary>
        /// Despliega un cuadro de dialogo para una entrada de Datos sencilla
        /// </summary>
        /// <param name="prmMensaje">Mensaje a desplegar</param>
        /// <param name="prmTitulo">Titulo del Cuadro de Dialogo</param>
        /// <param name="prmValorDefault">Valor por default para colocar en el cuadro de dialogo</param>
        /// <param name="maxLength">Longitud maxima del texto</param>
        /// <returns></returns>
        public static string ShowInputBox(string prmMensaje, string prmTitulo, string prmValorDefault ,int maxLength)
        {
            return InputBox.ShowInputBox(prmMensaje, prmTitulo, prmValorDefault ,maxLength);
        }

		/// <summary>
		/// Despliega un cuadro de dialogo para una entrada de Datos sencilla
		/// </summary>
		/// <param name="prmMensaje">Mensaje a desplegar</param>
		/// <param name="prmTitulo">Titulo del Cuadro de Dialogo</param>
		/// <param name="prmValorDefault">Valor por default para colocar en el cuadro de dialogo</param>
		/// <returns></returns>
		public static string ShowInputBox(string prmMensaje, string prmTitulo, string prmValorDefault)
		{
            return ShowInputBox(prmMensaje, prmTitulo, prmValorDefault ,100);
		}

		/// <summary>
		/// Despliega un cuadro de dialogo para una entrada de Datos sencilla
		/// </summary>
		/// <param name="prmMensaje">Mensaje a desplegar</param>
		public static string ShowInputBox(string prmMensaje)
		{
            return ShowInputBox(prmMensaje, "Access - Software", "");
		}

		/// <summary>
		/// Sirve para estandarizar el mostrado de Errores
		/// </summary>
		/// <param name="prmMensaje">Mensaje a desplegar</param>
		public static void RaiseError(string prmMensaje)
		{
			//TODO : Elaborar una formita mas bonita
			MessageBox.Show(prmMensaje,"TODO: Elaborar una Forma mas bonita");
		}

		
        ///// <summary>
        ///// Invierte los campos y colunas de un sheetview
        ///// </summary>
        ///// <param name="prmSheetToInvert">Hoja del FpSpread que se desea invertir</param>
        //public static void InvertirSheetView(FarPoint.Win.Spread.SheetView prmSheetToInvert)
        //{			
        //    int vCols = prmSheetToInvert.ColumnCount;
        //    int vRows = prmSheetToInvert.RowCount;

        //    int vMin = vCols;
        //    int vMax = vRows;

        //    if (vRows < vCols)
        //    {
        //        vMin = vRows;
        //        vMax = vCols;				
        //    }
			
        //    prmSheetToInvert.RowCount = vMax;
        //    prmSheetToInvert.ColumnCount = vMax;
			
        //    bool aux = prmSheetToInvert.ColumnHeaderVisible;
        //    prmSheetToInvert.ColumnHeaderVisible = prmSheetToInvert.RowHeaderVisible;
        //    prmSheetToInvert.RowHeaderVisible = aux;

        //    for(int i=0 ; i<vMax ; i++)
        //    {
        //        string header = prmSheetToInvert.Columns[i].Label;
        //        prmSheetToInvert.Columns[i].Label = prmSheetToInvert.Rows[i].Label;
        //        prmSheetToInvert.Rows[i].Label = header;
        //    }

				
        //    for(int i=0 ; i<vMin ; i++)
        //    {
        //        for(int j = i ; j<vMax; j++)
        //            prmSheetToInvert.SwapRange(i, j, j, i,1,1,false);
        //    }
			
        //    prmSheetToInvert.RowCount = vCols;
        //    prmSheetToInvert.ColumnCount = vRows;

        //}
		
		/// <summary>
		/// Funcion para emular la funcion IIF de Visua Basic
		/// </summary>
		/// <param name="prmCond">Condicion a Evaluar</param>
		/// <param name="prmTrueValue">Valor para el resultado Verdadero</param>
		/// <param name="prmFalseValue">Valor para el resultado Falso</param>
		/// <returns></returns>
		public static object IIF(bool prmCond, object prmTrueValue, object prmFalseValue)
		{
			if (prmCond)
				return prmTrueValue;
			return prmFalseValue;
		}
		
		/// <summary>
		/// Funcion que eqiuvale al Coalesce de SQL, regresa al prmValorOpciona en caso que prmValor sea Nulo
		/// </summary>
		/// <param name="prmValor">Valor a Verificar si es nulo</param>
		/// <param name="prmValorOpcional">Valor a Regresar en caso que prmValor sea nulo</param>
		/// <returns>prmValor si este no es nulo de lo contrario regresa prmValorOpcional</returns>
		public static object IfNull(object prmValor, object prmValorOpcional)
		{
			if (prmValor == null || prmValor == DBNull.Value)
				return prmValorOpcional;
			return prmValor;
		}

		/// <summary>
		/// Agrega un Elemento a cualquier Arreglo de elemntos
		/// </summary>
		/// <param name="prmArreglo">Arreglo</param>
		/// <param name="prmItem">Elemento para Agregar</param>
		public static void AgregaElementoEnArreglo(ref System.Collections.ArrayList prmArreglo, object prmItem)
		{
			if (prmArreglo==null)
				prmArreglo = new System.Collections.ArrayList();
			prmArreglo.Add(prmItem);			
			return;
		}

		/// <summary>
		/// Quita un Elemento a cualquier Arreglo de elemntos
		/// </summary>
		/// <param name="prmArreglo">Arreglo</param>
		/// <param name="prmItem">Elemento para Quitar</param>
		public static bool QuitaElementoDeArreglo(ref System.Collections.ArrayList prmArreglo, object prmItem)
		{
			if (prmArreglo.Contains(prmItem))
			{
				prmArreglo.Remove(prmItem);
				return true;
			}
			else
				return false;
		}
		
		/// <summary>
		/// Rellena una Cadena con caracteres de relleno a la izquierda
		/// </summary>
		/// <param name="prmCadena">Cadena a Rellenar</param>
		/// <param name="prmNumeroCaracteres">Longitud de la Nueva Cadena</param>
		/// <param name="prmCaracterRelleno">Caracter de Relleno</param>
		/// <returns></returns>
		public static string RellenaCon(string prmCadena , int prmNumeroCaracteres, char prmCaracterRelleno )
		{			
			prmCadena = prmCadena.Trim().ToUpper();
			if (prmNumeroCaracteres > 0)
			{				
				string vRetValue = "";
				for (int i = 0; i < prmNumeroCaracteres; i++)
				{
					vRetValue += prmCaracterRelleno;
				}
				vRetValue += prmCadena.Trim();
				vRetValue = vRetValue.Substring(vRetValue.Length - prmNumeroCaracteres, prmNumeroCaracteres);
				return vRetValue;
			}
			return prmCadena;
		}		

		/// <summary>
		/// Rellena una cadena de texto con el valor proporcionado a la derecha
		/// </summary>
		/// <param name="prmCadena">Cadena a Rellenar</param>
		/// <param name="prmNumeroCaracteres">Longitud de la Nueva Cadena</param>
		/// <param name="prmCaracterRelleno">Caracter de Relleno</param>
		/// <returns></returns>
		public static string RellenaConDerecha(string prmCadena , int prmNumeroCaracteres, char prmCaracterRelleno )
		{
			prmCadena = prmCadena.Trim();
			if (prmNumeroCaracteres > 0)
			{				
				string vRetValue = prmCadena;
				for (int i = 0; i < prmNumeroCaracteres; i++)
				{
					vRetValue += prmCaracterRelleno;
				}				
				vRetValue = vRetValue.Substring(0, prmNumeroCaracteres);
				return vRetValue;
			}
			return prmCadena;
		}

				
		#endregion //Metodos 

		#region Metodos Xml

		/// <summary>
		/// LLena una tabla con los valores de otra tabla. (en pocas palabras hace que la tabla destino sea igual a la origen)
		/// este metodo se utiliza para la actualizacion de datos entre unidades de negocio mediante archivos XML.
		/// Nota: Este metodo se utiliza para hacer actualizaciones masivas. por lo tanto la tabla destino, debe de llenarse con el metodo
		/// LLenarTablaDeDatos del DataAccessCls para posteriormente ejecutar las actualizaciones.
		/// </summary>
		/// <param name="vTablaDatos">Tabla con el conjunto de valores finales</param>
		/// <param name="vTablaDestino">Tabla donde se copiaran estos valores</param>
		public static bool LLenaTablaConValoresDeOtra(DataTable vTablaDatos,DataTable vTablaDestino)
		{
			string miMensaje = "";
			if(vTablaDatos == null || vTablaDestino == null)
				return false;
			
			try
			{
				vTablaDestino.BeginLoadData();
				foreach(DataRow vRow in vTablaDatos.Rows)
				{
					vTablaDestino.LoadDataRow(vRow.ItemArray ,false);
				}
				vTablaDestino.EndLoadData();
				return true;
			}
			catch(ArgumentException ArEx)
			{
				miMensaje = "El numero de columnas de la tabla origen y destino no coinciden. Origen = " + vTablaDatos.Columns.Count.ToString()
					+ " - Destino = " + vTablaDestino.Columns.Count.ToString() + ". " + ArEx.Message;				
			}
			catch(InvalidCastException InEx)
			{
				miMensaje = "El tipo de datos no coincide para una columna de las tablas involucradas. " + InEx.Message;
				//MessageBox.Show("El tipo de datos no coincide para una columna de las tablas involucradas. " + InEx.Message ,"Tool" ,MessageBoxButtons.OK ,MessageBoxIcon.Error);
			}
			catch(ConstraintException CoEx)
			{
				miMensaje = "La Instruccion esta violando un constraint definido para la tabla. " + CoEx.Message ;				
			}
			catch(NoNullAllowedException NullEx)
			{
				miMensaje = "La Columna no permite valores nulos." + NullEx.Message ;				
			}
			finally
			{
				DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
				if(miMensaje != "")
				{
					MessageBox.Show(miMensaje ,"Tool" ,MessageBoxButtons.OK ,MessageBoxIcon.Error);
				}
				
			}
			return false;
			
		}

		/// <summary>
		/// Solo inserta los registros como nuevos en la bd.. en el caso de exxistir estos se generara un error
		/// </summary>
		/// <param name="prmTabla">Tabla con los datos finales</param>		
		/// <returns>Exito</returns>
		public static bool InsertaTablaDeBD(DataTable prmTabla)
		{
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			try
			{
				
				DataTable vTabla = new DataTable();
				System.Data.SqlClient.SqlDataAdapter vAdapter = new System.Data.SqlClient.SqlDataAdapter();
				string vNombresCampos = GetListaNombresDeCampos(prmTabla);
				string vSql = "SELECT " + vNombresCampos + " FROM " + prmTabla.TableName + "(NOLOCK) WHERE 1 = 0";
				if(!DAO.RegresaEsquemaDeDatos(vSql ,ref vTabla))
					return false;
				vSql = "SELECT " + vNombresCampos + " FROM " + prmTabla.TableName + "(NOLOCK) WHERE 1 = 0";
				if(!DAO.LlenaTablaDeDatos(vSql ,ref vAdapter ,ref vTabla))
					return false;
				if(!LLenaTablaConValoresDeOtra(prmTabla ,vTabla))
					return false;

				DataTable vInserciones = vTabla.GetChanges(DataRowState.Added);
				if(vInserciones != null)
				{
					if(vInserciones.Rows.Count > 0)
						return DAO.InsertaDatosDeTablaSql(ref vAdapter ,ref vInserciones);
				}

				//El rollo para la eliminacion de registros no esta contemplada en este caso
				//por que el uso que se le da a esta funcion es en tablas de catalogo, en las cuales
				//no se eliminan registros.
				return true;

			}
			catch(Exception Ex)
			{				
				MessageBox.Show("Ocurrio el siguiente error en el proceso de actualizacion. " + Ex.Message ,"Tool" ,MessageBoxButtons.OK ,MessageBoxIcon.Error);
				return false;
			}
		}
		

		/// <summary>
		/// En base a una tabla con la misma estructura de la tabla de la bd y datos, actualiza los datos.
		/// esta sobrecarga aplica un filtro a la hora de llenar la tabla de la bd, para que todo sea mas ligero
		/// </summary>
		/// <param name="prmTabla">Tabla con los datos finales</param>
		/// <param name="filtro">filtro que se aplicara. Ejemplo "WHERE nCanalDistribucion = 64"</param>
		/// <returns>exito</returns>
		public static bool InsertaYActualizaTablaDeBD(DataTable prmTabla ,string filtro)
		{
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			try
			{
				bool bResult = true;
				
				DataTable vTabla = new DataTable();
				System.Data.SqlClient.SqlDataAdapter vAdapter = new System.Data.SqlClient.SqlDataAdapter();
				string vNombresCampos = GetListaNombresDeCampos(prmTabla);
				string vSql = "SELECT " + vNombresCampos + " FROM " + prmTabla.TableName + "(NOLOCK) WHERE 1 = 0";
				if(!DAO.RegresaEsquemaDeDatos(vSql ,ref vTabla))
					return false;
				vSql = "SELECT " + vNombresCampos + " FROM " + prmTabla.TableName + "(NOLOCK) " + filtro;
				if(!DAO.LlenaTablaDeDatos(vSql ,ref vAdapter ,ref vTabla))
					return false;
				if(!LLenaTablaConValoresDeOtra(prmTabla ,vTabla))
					return false;

				DataTable vActualizaciones = vTabla.GetChanges(DataRowState.Modified);
				if(vActualizaciones != null)
				{
					if(vActualizaciones.Rows.Count > 0)
						bResult = DAO.ActualizaDatosDeTablaSql(ref vAdapter ,ref vActualizaciones);
				}

				if(!bResult)
					return false;

				DataTable vInserciones = vTabla.GetChanges(DataRowState.Added);
				if(vInserciones != null)
				{
					if(vInserciones.Rows.Count > 0)
						bResult = DAO.InsertaDatosDeTablaSql(ref vAdapter ,ref vInserciones);
				}

				//El rollo para la eliminacion de registros no esta contemplada en este caso
				//por que el uso que se le da a esta funcion es en tablas de catalogo, en las cuales
				//no se eliminan registros.
				return bResult;

			}
			catch(Exception Ex)
			{
				MessageBox.Show("Ocurrio el siguiente error en el proceso de actualizacion. " + Ex.Message ,"Tool" ,MessageBoxButtons.OK ,MessageBoxIcon.Error);
				return false;
			}
		}

		/// <summary>
		/// En base a una tabla con la misma estructura de la tabla de la bd y datos, actualiza los datos.
		/// </summary>
		/// <param name="prmTabla">Tabla con los datos finales</param>
		/// <returns>Exito o fracaso</returns>
		public static bool InsertaYActualizaTablaDeBD(DataTable prmTabla)
		{
			return InsertaYActualizaTablaDeBD(prmTabla ,"");			
		}

		/// <summary>
		/// Devuleve una lista con los nombres de campos que contiene la tabla
		/// </summary>
		/// <param name="prmTabla">Tabla la cual se recorrera para obtener sus nombres de campos</param>
		/// <returns>Lista con los nombres de campos</returns>
		public static string GetListaNombresDeCampos(DataTable prmTabla)
		{
			string vListaCampos = "";
			if(prmTabla == null)
				return vListaCampos;

			foreach(DataColumn vColumna in prmTabla.Columns)
			{
				if(vListaCampos != "")
					vListaCampos += " ," + vColumna.ColumnName;				
				else
					vListaCampos = vColumna.ColumnName;
			}

			return vListaCampos;
		}


		/// <summary>
		/// Metodo estatico que en base a la ruta de 2 archivos xml. Uno con los datos de la tabla y otro con la estructura
		/// </summary>
		/// <param name="prmNombreArchivoDatosConRutaYExtension">Ruta y Nombre del Archivo de datos</param>
		/// <param name="prmNombreArchivoSchemaConRutaYExtension">Ruta y Nombre del Archivo de esquema</param>
		/// <returns>Una Tabla con los datos</returns>
		public static DataTable CargaTablaDeUnXML(string prmNombreArchivoDatosConRutaYExtension, string prmNombreArchivoSchemaConRutaYExtension)
		{
			try
			{
				DataSet dsTabla = new DataSet();
				EsperarHastaEncontrarArchivo(prmNombreArchivoSchemaConRutaYExtension);
				dsTabla.ReadXmlSchema(prmNombreArchivoSchemaConRutaYExtension);
				EsperarHastaEncontrarArchivo(prmNombreArchivoDatosConRutaYExtension);
				dsTabla.ReadXml(prmNombreArchivoDatosConRutaYExtension);
				return dsTabla.Tables[0];
			}
			catch(Exception Ex)
			{
				return null;
			}
			
		}


		/// <summary>
		/// Metodo estatico que busca un archivo el cual se encuantra en proceso de descompresion hasta que el lo pueda abrir.
		/// </summary>
		/// <param name="prmNombreArchivoConRutaYExtension">nombre completo del archivo con ruta y extension</param>
		public static void EsperarHastaEncontrarArchivo(string prmNombreArchivoConRutaYExtension)
		{
			bool vEncontrado = false;
			while(!vEncontrado)
			{
				try
				{
					System.IO.StreamReader vArchivo = new System.IO.StreamReader(prmNombreArchivoConRutaYExtension);
					vEncontrado = true;
					vArchivo.Close();
				}
				catch(System.IO.IOException Ex)
				{
					vEncontrado = false;
				}
			}
		}


		#endregion

	}
}
