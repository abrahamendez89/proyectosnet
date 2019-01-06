using System.Data;
using System.Drawing;


namespace Sistema
{
	/// <summary>
	/// Clase para Manejar los Argumetos de los Eventos Seleccion de Elemento
	/// </summary>
	public class SelectedElementArgs : System.EventArgs
	{
		#region Atributos 

		#region Privados 
		
		private DataRow atrRow;
		private Catalogo atrCatalogo;
		
		#endregion //Privados

		#region Publicos 

		/// <summary>
		/// Obtiene el Indice del renglon activo.
		/// </summary>
		public DataRow Row			
		{ get{return atrRow;} }

		/// <summary>
		/// Obtiene el Catalogo del cual se lanzo el evento.
		/// </summary>
		public Catalogo CatalogoBase
		{ get{return atrCatalogo;} }

		/// <summary>
		/// Obtiene la descripcion del valor actual.
		/// </summary>
		public virtual string Descripcion	
		{ 
			get
			{
				if (atrRow==null)
					return "";
				else
					return (string)atrRow[atrCatalogo.MetaCatalogoBase.CampoDescripcion];
			} 
		}

		/// <summary>
		/// Obtiene el valor actual.
		/// </summary>
		public virtual object Valor			
		{ 
			get
			{
				if (atrRow==null)
					return "";
				else
					return atrRow[atrCatalogo.MetaCatalogoBase.CampoPrimario];
			} 
		}
		
		#endregion //Publicos

		#endregion //Atributos

		#region Constructor 
		
		/// <summary>
		/// Constructor base.
		/// </summary>
		/// <param name="renglon">Indice del renglon activo</param>
		/// <param name="catalogo">Catalogo que utiliza</param>
		public SelectedElementArgs(DataRow renglon, Catalogo catalogo)
		{ 
			atrRow = renglon;  
			atrCatalogo = catalogo; 
		}

		#endregion //Constructor

	}

	/// <summary>
	/// 
	/// </summary>
	public class BeforeCambioMultiseleccionEventArgs : System.EventArgs
	{
		bool atrCancel = false;
		string atrSeleccionesActuales = "";
		string atrSeleccionesAnteriores = "";

		/// <summary>
		/// Obtiene o establece si se cancelara la accion.
		/// </summary>
		public bool Cancel
		{
			get{return atrCancel;}
			set{atrCancel = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SeleecionActuales
		{
			get{return atrSeleccionesActuales;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SeleccionesAnteriores
		{
			get{return atrSeleccionesAnteriores;}
		}

		/// <summary>
		/// Constructor base.
		/// </summary>
		public BeforeCambioMultiseleccionEventArgs(){}//:base(renglon, catalogo){}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="prmSeleccionesActuales"></param>
		/// <param name="PrmSelecionesAnteriores"></param>
		public BeforeCambioMultiseleccionEventArgs(string prmSeleccionesActuales,string PrmSelecionesAnteriores)
		{
			atrSeleccionesActuales=prmSeleccionesActuales;
			atrSeleccionesAnteriores=PrmSelecionesAnteriores;
		}
	}





	/// <summary>
	/// Clase que denota la imformacion generada por el evento BeforeCambioElemento en un Objeto AccTextBox
	/// </summary>
	public class BeforeCambioEventArgs : SelectedElementArgs
	{
		bool atrCancel = false;

		/// <summary>
		/// Obtiene o establece si se cancelara la accion.
		/// </summary>
		public bool Cancel
		{
			get{return atrCancel;}
			set{atrCancel = value;}
		}


		/// <summary>
		/// Constructor base.
		/// </summary>
		/// <param name="renglon">Objeto DataRow que contiene la informacion del catalogo para el valor actual</param>
		/// <param name="catalogo">Catalogo del cual se esta obteniendo la informacion</param>
		public BeforeCambioEventArgs(DataRow renglon, Catalogo catalogo):base(renglon, catalogo){}
	}

    ///// <summary>
    ///// Clase que denota la imformacion generada por el evento BeforeCambioElemento en un Objeto ManejadorFpSpread
    ///// </summary>
    //public class BeforeCambioGridEventArgs : SelectedElementGridArgs
    //{
    //    bool atrCancel = false;
    //    /// <summary>
    //    /// Obtiene o establece si se cancelara la accion.
    //    /// </summary>
    //    public bool Cancel
    //    {
    //        get{return atrCancel;}
    //        set{atrCancel = value;}
    //    }

    //    /// <summary>
    //    /// Constructor base.
    //    /// </summary>
    //    /// <param name="mspManejador">Objeto ManejadorFpSpread contenedor del catalogo</param>
    //    /// <param name="renglon">Objeto DataRow que contiene la informacion del catalogo para el valor actual</param>
    //    /// <param name="catalogo">Catalogo del cual se esta obteniendo la informacion</param>
    //    /// <param name="rowIndex">Indice del renglon actual</param>
    //    /// <param name="colIndex">Indice de la columna actual</param>
    //    public BeforeCambioGridEventArgs(ManejadorFpSpread mspManejador, DataRow renglon, Catalogo catalogo, int rowIndex, int colIndex):base(mspManejador, renglon, catalogo, rowIndex, colIndex){}
    //}

	/// <summary>
	/// Clase que denota la informacion generada por el evento SelectedItem
	/// </summary>
	public class ItemSelectEventArgs : System.EventArgs
	{
		object atrItem;
		object atrValor;

		/// <summary>
		/// Constructor base.
		/// </summary>
		/// <param name="prmItem">Elemento</param>
		/// <param name="prmValor">Valor</param>
		public ItemSelectEventArgs (object prmItem, object prmValor)
		{
			atrItem = prmItem;
			atrValor = prmValor;
		}

		/// <summary>
		/// Obtiene el valor del elemento seleccionado.
		/// </summary>
		public object ValorSeleccionado
		{
			get{return atrValor;}
		}

		/// <summary>
		/// Obtiene el elemento seleccionado.
		/// </summary>
		public object ItemSeleccionado
		{
			get{return atrItem;}
		}
	}


	/// <summary>
	/// Obtiene el elemento seleccionado.
	/// </summary>
	public class RowColChangeArgs : System.EventArgs
	{
		#region Atributos
			
		#region Privados
		
		private int R;
		private int NR;
		private int C;
		private int NC;		

		#endregion //Privados
			
		#region Publicos

		/// <summary>
		/// Obtiene el Indice del renglon del cual se esta saliendo.
		/// </summary>
		public int Row
		{ get{return R;} }

		/// <summary>
		/// Obtiene el Indice del la columna de la cual se esta saliendo.
		/// </summary>
		public int Column
		{ get{return C;} }

		/// <summary>
		/// Obtiene el Indice del renglon al cual se va a entrar.
		/// </summary>
		public int NewRow
		{ get{return NR;} }

		/// <summary>
		/// Obtiene el Indice de la columna a la cual se va a entrar.
		/// </summary>
		public int NewColumn
		{ get{return NC;} }
			
		#endregion //Publicos

		#endregion //Atributos

		#region Constructor

		/// <summary>
		/// Constructor base.
		/// </summary>
		/// <param name="row">Indice del renglon del cual se esta saliendo.</param>
		/// <param name="col">Indice del la columna de la cual se esta saliendo.</param>
		/// <param name="newRow">Indice del renglon al cual se va a entrar.</param>
		/// <param name="newCol">Indice de la columna a la cual se va a entrar.</param>
		public RowColChangeArgs(int row, int col, int newRow, int newCol)
		{ R=row;  C=col;  NR=newRow;  NC=newCol;}

		#endregion //Constructor

	}


    ///// <summary>
    ///// Clase para el Selection Renderer del Modo de Captura
    ///// </summary>
    //public class srCaptura : FarPoint.Win.Spread.ISelectionRenderer
    //{

    //    /// <summary>
    //    /// Metodod que determina la forma en que se pintara la seleccion de texto en una celda del Grid.
    //    /// </summary>
    //    /// <param name="g">Objeto Graphics del control</param>
    //    /// <param name="x">Coordenada x</param>
    //    /// <param name="y">Coordenada y</param>
    //    /// <param name="width">Ancho en pixeles</param>
    //    /// <param name="height">Alto en pixeles</param>
    //    public void PaintSelection(Graphics g, int x, int y, int width, int height)
    //    {
    //        SolidBrush selectionBrush = new SolidBrush(Color.FromArgb(100, Color.FromArgb(52, 98, 135)));
    //        g.FillRectangle(selectionBrush, x, y, width, height);
    //        selectionBrush.Dispose();
    //    }
    //}

    ///// <summary>
    ///// Clase para el Selection Renderer del Modo de Seleccion
    ///// </summary>
    //public class srSeleccion : FarPoint.Win.Spread.ISelectionRenderer
    //{

    //    /// <summary>
    //    /// Metodod que determina la forma en que se pintara la seleccion de texto en una celda del Grid.
    //    /// </summary>
    //    /// <param name="g">Objeto Graphics del control</param>
    //    /// <param name="x">Coordenada x</param>
    //    /// <param name="y">Coordenada y</param>
    //    /// <param name="width">Ancho en pixeles</param>
    //    /// <param name="height">Alto en pixeles</param>
    //    public void PaintSelection(Graphics g, int x, int y, int width, int height)
    //    {
    //        SolidBrush selectionBrush = new SolidBrush(Color.FromArgb(100, Color.FromArgb(52, 98, 135)));
    //        g.FillRectangle(selectionBrush, x, y, width, height);
    //        selectionBrush.Dispose();
    //    }
    //}


	/// <summary>
	/// Clase que servira como argumentos del evento RowChanging
	/// </summary>
	public class ClsRowChangingEventArgs : System.ComponentModel.CancelEventArgs{
		private int atrRow;
		private int atrNewRow;

		/// <summary>
		/// Row Actual
		/// </summary>
		public int Row{
			get{return atrRow;}
		}

		/// <summary>
		/// Nuevo Row
		/// </summary>
		public int NewRow{
			get{return atrNewRow;}
		}

		
		public ClsRowChangingEventArgs(int Row ,int newRow):base(false){
			atrRow = Row;
			atrNewRow = newRow;
		}

	}

	/// <summary>
	/// Clase para complementar la nueva funcionalidad de la RegresaSeleccionDeUsuario del Asistente
	/// </summary>
	public class ClsParametrosRegresaNuevaEleccionUsuario
	{
		private string atrNombresFisicosDeColumnas;
		private string atrConsultaSQLComplementaria;
		private string atrCamposDeRelacion;

		/// <summary>
		/// Obtiene o establece los nombres fisicos de las columnas
		/// </summary>
		public string NombresFisicosDeColumnas
		{
			get{return atrNombresFisicosDeColumnas;}
			set{atrNombresFisicosDeColumnas = value;}
		}

		/// <summary>
		/// Obtiene o establece una consulta SQL complementaria
		/// </summary>
		public string ConsultaSQLComplementaria
		{
			get{return atrConsultaSQLComplementaria;}
			set{atrConsultaSQLComplementaria = value;}
		}

		/// <summary>
		/// Obtiene o establece la relacion entre campos de la tabla del catalogo y de la complementaria
		/// ejemplo: nFolio = nCodigo ,nRenglon = nRenglon
		/// </summary>
		public string CamposDeRelacion
		{
			get{return atrCamposDeRelacion;}
			set{atrCamposDeRelacion = value;}
		}

		/// <summary>
		/// Constructor Base
		/// </summary>
		public ClsParametrosRegresaNuevaEleccionUsuario()
		{
			atrNombresFisicosDeColumnas = "";
			atrConsultaSQLComplementaria = "";
			atrCamposDeRelacion = "";
		}

	}

}
