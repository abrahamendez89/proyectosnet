using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;


namespace Sistema
{ 
	/// <summary>
	/// Desarrollado Por : Lic. Alejandro Cons Gastélum Arámburo
	/// Fecha V1.1		 : Septiembre 2004
	/// Clase			 : AccTextBox
	/// Descripcion      : Componente de Texto para el Manejo de MetaCatalogos
	/// Hereda de		 : System.Windows.Forms.TextBox
	/// Que Hace		 : Esta Clase Maneja y Administra una Caja de Texto para 
	///					   Agregarle la Funcionalidad de los MetaCatalogos.
	///					   Utilizese en Sustitucion de un TextBox en donde se quiera
	///					   implementar la Clave de un Catálogo
	/// </summary>
	[ToolboxBitmap(typeof(TextBox))]
	public class AccTextBox : System.Windows.Forms.TextBox
	{
		#region Eventos y Delegados

		/// <summary>
		/// Delegado para el evento SeleccionoElemento
		/// </summary>
		public delegate void SeleccionoElementoEventHandler(Object sender, SelectedElementArgs e);
		/// <summary>
		/// Delegado para el evento BeforeCambioElemento
		/// </summary>
		public delegate void BeforeCambioElementoEventHandler(Object sender, BeforeCambioEventArgs e);

		/// <summary>
		/// Delegado para el evento ElementoInvalido
		/// </summary>
		public delegate void ElementoInvalidoEventHandler(object sender ,Complementos.ElementoInvalidoEventArgs e);

		/// <summary>
		/// Declaracion del evento SeleccionoElemento
		/// </summary>
		public event SeleccionoElementoEventHandler SeleccionoElemento;
		/// <summary>
		/// Declaracion del evento CambioElemento
		/// </summary>
		public event SeleccionoElementoEventHandler CambioElemento;
		/// <summary>
		/// Declaracion del evento BeforeCambioElemento
		/// </summary>
		public event BeforeCambioElementoEventHandler BeforeCambioElemento;

		/// <summary>
		/// Declaracion del evento ElementoInvalido
		/// </summary>
		public event ElementoInvalidoEventHandler ElementoInvalido;

		#endregion //Eventos y Delegados
		
		#region Atributos

		#region Privados
		
//		private bool atrSoloNumeros;
//		private bool atrSoloNumerosConPuntoDecimal;

 		private System.ComponentModel.Container components = null;
				
		//Variable que almacena el OldValue de la cadena de Descripcion.
		private string atrDescripcion;
		private Catalogo	atrCatalogoBase;
		private Control		atrControlDestinoDescripcion;
		private bool		atrValorValido;
		
		private bool		atrCambioPorRelleno;
		private string		atrOldValue = "";
		
		private Color		atrColorDesactivado;
		internal const string  TituloMessageBox = "Sistema Access";

		//Nuevos Requerimientos Vizur
		private bool atrPermiteAvanceElementoInvalido;
		private string atrDescripcionElementoInvalido;
		private bool atrPermiteSoloCapturarAlfanumericos;
		private bool atrValidarEventos;
		private bool atrPermiteAyudarapida;
		private KeyEventArgs atrLastKeyPress;
		private bool atrTextChangedByUser;

		private bool atrLeaveRaised;
		private bool atrValidatedRaised;
        private string atrTituloMensaje="";

        private System.Windows.Forms.Keys atrTeclaAyuda = Keys.F1;
        private bool atrBlancoEsValorInvalido=true;
        private bool atrCatalogoPrincipal = false;
        private char atrCaracterValorNuevo = '*';
        private bool atrEnPantalla = true;
		
		#endregion 

		#region Publicos

        /// <summary>
        /// Estable si el metacatalogo aun esta en pantalla
        /// </summary>
        public bool EnPantalla
        {
            get { return atrEnPantalla; }
            set { atrEnPantalla = value; }
        }



        /// <summary>
        /// Estable con que si es el componente del catalogo principal
        /// </summary>
        public bool CatalogoPrincipal
        {
            get { return atrCatalogoPrincipal ; }
            set { atrCatalogoPrincipal  = value; }
        }

        /// <summary>
        /// Estable con que si es el componente del catalogo principal
        /// </summary>
        public char CaracterValorNuevo
        {
            get { return atrCaracterValorNuevo; }
            set { atrCaracterValorNuevo = value; }
        }

        /// <summary>
        /// Estable con que si el blanco es valor invalido o valido
        /// </summary>
        public bool BlancoEsValorInvalido
        {
            get { return atrBlancoEsValorInvalido; }
            set { atrBlancoEsValorInvalido = value; }
        }


        /// <summary>
        /// Estable con que tecla aparecera la ayuda
        /// </summary>
        public System.Windows.Forms.Keys TeclaAyuda
        {
            get { return atrTeclaAyuda ; }
            set { atrTeclaAyuda  = value; }
        }

        
        /// <summary>
        /// Obtiene o estable el mensaje del titulo para el error
        /// </summary>
        public string  TituloMensaje
        {
            get { return atrTituloMensaje; }
            set { atrTituloMensaje = value; }
        }


		/// <summary>
		/// Obtiene o establece la ultima combinacion de teclas presionadas en el control :D
		/// </summary>
		public KeyEventArgs LastKeyPress{
			get{return atrLastKeyPress;}
			set{atrLastKeyPress = value;}
		}

		/// <summary>
		/// Determina si se permitira la ayuda rapida para el control.
		/// </summary>
		[Description("Determina si se permitira la ayuda rapida para el control."),Category("Configuración")]
		public bool PermiteAyudaRapida{
			get{return atrPermiteAyudarapida;}
			set{atrPermiteAyudarapida = value;}
		}

		/// <summary>
		/// Determina si solo se permitiran caracteres alfanumericos esto para evitar usuarios mal intencionados y todos aquellos errores derivados de la ayuda
		/// </summary>
		[Description("Determina si solo se permitiran caracteres alfanumericos esto para evitar usuarios mal intencionados y todos aquellos errores derivados de la ayuda."),Category("Configuración")]
		public bool PermiteSoloCapturarAlfanumericos{
			get{return atrPermiteSoloCapturarAlfanumericos;}
			set{atrPermiteSoloCapturarAlfanumericos = value;}
		}

		/// <summary>
		/// Obtiene o establece si se podra abandonar el control en caso de que este presente un dato invalido
		/// </summary>
		[Description("Obtiene o establece si se podra abandonar el control en caso de que este presente un dato invalido."),Category("Configuración")]
		public bool PermiteAvanceElementoInvalido{
			get{return atrPermiteAvanceElementoInvalido;}
			set{atrPermiteAvanceElementoInvalido = value;}
		}

		/// <summary>
		/// Obtiene o establece la cadena que se mostrara al informar de que el elemento es invalido
		/// </summary>
		[Description("Obtiene o establece la cadena que se mostrara al informar de que el elemento es invalido."),Category("Configuración")]
		public string DescripcionElementoInvalido{
			get{return atrDescripcionElementoInvalido;}
			set{atrDescripcionElementoInvalido = value;}
		}

		/// <summary>
		/// Obtiene o establece Catalogo base del control.
		/// </summary>
		public Catalogo		CatalogoBase				
		{
			get{ return atrCatalogoBase;  }
			set{ atrCatalogoBase = value; }
		}

		/// <summary>
		/// Obtiene o establece Control en el cual se desplegara la descipcion del catalogo
		/// </summary>
		public Control		ControlDestinoDescripcion	
		{
			get{ return atrControlDestinoDescripcion;}
			set{ atrControlDestinoDescripcion = value;}
		}

		/// <summary>
		/// Determina si el valor actual del control es valido.
		/// </summary>
		public bool			ValorValido					
		{
			get{return atrValorValido;}						
		}
		
		
		/// <summary>
		/// Obtiene o establece la cadena que se desplegara en el ControlDestinoDescripcion
		///  en caso de darse un valor no validp
		/// </summary>
		public string		CadenaDescripcionNoValida	
		{
			get
			{
				if (Vacio)
					return "";
				return  atrCatalogoBase.CadenaDescripcionNoValida;
			}
			
			set
			{
				if (Vacio)
					return;
				atrCatalogoBase.CadenaDescripcionNoValida = value;
			}
		}
		
		/// <summary>
		/// Obtiene el nombre del metacatalogo del catalogo.
		/// </summary>
		public string		NombreMetaCatalogo			
		{
			get 
			{ 
				if (Vacio)
					  return"";
				return atrCatalogoBase.NombreMetaCatalogo; 
			}
		}


		/// <summary>
		/// Determina si el Control tiene un valor vacio.
		/// </summary>
		public bool			Vacio						
		{
			get 
			{
				if (atrCatalogoBase==null || atrCatalogoBase.Vacio) 
					return true;
				return false;
			}
		}
		
		/// <summary>
		/// Obtiene o establece el color del control cuando este se encuentre desactivado.
		/// </summary>
		[Description("Determina el Color a aplicar al control cuando este este desactivado."),Category("Presentación")]
		public Color		ColorDesactivado			
		{
			get {return atrColorDesactivado;}
			set {atrColorDesactivado = value;}
		}
		

		#endregion
		
		#endregion 

		#region Constructor 

		/// <summary>
		/// Constructor base.
		/// </summary>
		public AccTextBox()
		{
			InitializeComponent();
			atrOldValue = "";
			atrCambioPorRelleno = false;
			atrValorValido = false;
			atrDescripcion = "";		
			atrDescripcionElementoInvalido = "";
			atrPermiteAvanceElementoInvalido = true;
			atrPermiteSoloCapturarAlfanumericos = false;
			atrValidarEventos = true;
			atrPermiteAyudarapida = true;
			atrTextChangedByUser = true;
			atrLeaveRaised = false;
			atrValidatedRaised = false;
		}

		#endregion //Constructor


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
		
		#region Component Designer generated code 
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
            this.GotFocus += new EventHandler(AccTextBox_GotFocus); 
		}
		
		
		#endregion

		#region Métodos 
		
		#region Eventos





//		/// <summary>
//		/// Dejamos al usuario que pueda validar el control cuando lo necesite
//		/// Nota solo para japac se lanzara el evento leave y cambio elemento en caso de que el control este en blanco debido a su progrmacion
//		/// </summary>
//		/// <returns></returns>
//		public virtual bool DoValidate()
//		{
//			return DoValidate(true);
//		}
//		
//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="raiseLeave"></param>
//		/// <returns></returns>
//		private bool DoValidate(bool raiseLeave)
//		{
//			CancelEventArgs miArgumento = new CancelEventArgs(false);
//			OnValidating(miArgumento);
//			if(!miArgumento.Cancel)
//			{				
//				if(base.Text.Trim().Equals(""))
//				{
//					//SetTextBoxValue(base.Text);	
//					//if(raiseLeave) base.OnLeave (EventArgs.Empty);	
//					SelectNextControl(this ,true ,false ,true ,true);
//				}
//				return true;
//			}
//			return false;
//		}

		/// <summary>
		/// Remplazo del metodo para manejar antes el evento validating
		/// </summary>
		/// <param name="e">argumentos del metodo</param>
		protected override void OnValidating(CancelEventArgs e)
		{
			if(!atrValidarEventos) return;
			//Aqui cambiamos el valor valido por una consulta directa ya que el cambio de elemento se raisea en el validated
			//que se ejecuta despues del validating y por lo tanto tiene un valor invalido
			atrValorValido = true;
            if (atrCatalogoPrincipal && this.Text.Trim() == "" && atrEnPantalla )//&&atrSaliendoEnterTab )
            {
                this.Text = atrCaracterValorNuevo.ToString();
                this.Enabled = false;
                atrValorValido = true;
                e.Cancel = false;
            }
            else
            {
                if (!atrPermiteAvanceElementoInvalido && this.ObtenElementoRowActual() == null && this.Text.Trim() != "")
                {
                    //Aqui delegamos la descripcion y la cancelacion de valor al programador
                    //esto mediante el disparo del evento ElementoInvalido
                    if ((!atrBlancoEsValorInvalido && this.Text.Trim() == "")||(atrCatalogoPrincipal  && (this.Text.Trim()=="*"||this.Text.Trim()=="")))
                    {
                        if (this.Text == "*")
                            this.Enabled = false;
                        atrValorValido = true;
                        e.Cancel = false;
                    }
                    else
                    {
                        Complementos.ElementoInvalidoEventArgs miArgumento = new Sistema.Complementos.ElementoInvalidoEventArgs(true, atrDescripcionElementoInvalido, this.Text);
                        OnElementoInvalido(miArgumento);
                        if (miArgumento.Cancel)
                        {
                            if (atrTituloMensaje != "")
                            {
                                MessageBox.Show(this, miArgumento.Mensaje, atrTituloMensaje, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show(this, miArgumento.Mensaje, TituloMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            this.Text = "";
                            e.Cancel = true;
                            atrValorValido = false;
                            return;
                        }
                    }
                }
			}
            //if (atrSaliendoEnterTab)
            //{
            //    atrSaliendoEnterTab = false; 
            //}

			base.OnValidating (e);
		}


		/// <summary>
		/// Disparador del evento ElementoInvalido
		/// </summary>
		/// <param name="e">argumentos del evento</param>
		protected virtual void OnElementoInvalido(Complementos.ElementoInvalidoEventArgs e){
			if(ElementoInvalido != null)
				ElementoInvalido(this ,e);
		}


		/// <summary>
		/// Manejo Interno del Evento KeyDown
		/// </summary>
		/// <param name="e">args</param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(!atrValidarEventos) return;
			AccTextBox_KeyDown(this ,e);
			if(!e.Handled)
				base.OnKeyDown (e);
		}

		/// <summary>
		/// Cacha el evento KeyPress para su previa validacion
		/// </summary>
		/// <param name="e">argumentos</param>
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if(!atrValidarEventos) return;
			if(atrPermiteSoloCapturarAlfanumericos)
				//			Letras							Numeros						Enter							Backspace				esapcio							Suprimir	
				e.Handled = !Char.IsLetter(e.KeyChar) && !Char.IsDigit(e.KeyChar) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)32 && e.KeyChar != (char)46;												
			base.OnKeyPress (e);
		}

		/// <summary>
		/// Sobrescribimos el metodo para raisearlo ne el keydown del control
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if(keyData == Keys.Tab)
			{
				OnKeyDown(new KeyEventArgs(keyData));				
				return base.ProcessCmdKey (ref msg, Keys.Enter);
			}
			else
				return base.ProcessCmdKey (ref msg, keyData);
		}


		private void AccTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			
			//Se coloco aqui para no interferir y que el teclazo lo vea el usuario
			
            atrLastKeyPress = new KeyEventArgs(e.KeyCode);
			
			if (Vacio) return;
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
			{
               // atrSaliendoEnterTab = true;
                //if (Text.Trim() != "" && atrBlancoEsValorInvalido  )
                //{
                    SetTextBoxValue(this.Text);
                //}
			}

			//Se coloco aqui para no interferir y que el teclazo lo vea el usuario
			atrLastKeyPress = new KeyEventArgs(e.KeyCode);

			if (e.KeyCode == atrTeclaAyuda  && atrPermiteAyudarapida)
			{
				//SeleccionDeElemento(this.Text);
				if (SeleccionDeElemento(this.Text))
					SendKeys.Send("{TAB}");
			}
		}

		/// <summary>
		/// Manejo Interno del Evento Enter
		/// </summary>
		/// <param name="e">args</param>
		protected override void OnEnter(EventArgs e)
		{
			atrLeaveRaised = false;
			atrValidatedRaised = false;
			if(!atrValidarEventos) return;
			AccTextBox_Enter(this ,e);
			base.OnEnter (e);
		}

		/// <summary>
		/// Obtiene o establece el Texto de la caja
		/// Nota: Se sobrescribio para limpiar el valor de LastKeyPress
		/// </summary>
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if(atrTextChangedByUser)
					atrLastKeyPress = null;
			}
		}
		
//		/// <summary>
//		/// Sobreescribimos este metodo para poder cahcar el TAB y asi poder lanzar el cambio de elemento
//		/// </summary>
//		/// <param name="m"></param>
//		protected override void WndProc(ref Message m)
//		{
//			//Constante que envia windows al presionar TAB
//			const int WM_TAB=297;
//			if (m.Msg==WM_TAB)
//				OnKeyDown(new KeyEventArgs(Keys.Tab));			
//			base.WndProc (ref m);
//		}


		/// <summary>
		/// Sobreescribimos la propiedad readonly para limpiar el color del control al esta cambiar
		/// </summary>
		[Description("Determina si el control sera de solo lectura."),Category("Configuración")]
		new public bool ReadOnly{
			get{return base.ReadOnly;}
			set{
				base.ReadOnly = value;
				this.BackColor = Color.Empty;
			}
		}

		private void AccTextBox_Enter(object sender, EventArgs e)		
		{	
			if(base.ReadOnly)
				this.BackColor = Color.Empty;
			else
				this.BackColor = Color.Yellow;
		}


		/// <summary>
		/// Sobreescribimos el OnLeave para validaciones de control
		/// esto debido a la cantidad de programacion hecha en japac
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLeave(EventArgs e)
		{			
			if(!atrValidatedRaised)
				this.OnValidated(e);
			base.OnLeave (e);	
		}

		/// <summary>
		/// Manejo Interno del Evento Validated
		/// </summary>
		/// <param name="e">args</param>
		protected override void OnValidated(EventArgs e)
		{
			if(!atrValidarEventos) return;
			this.BackColor = Color.Empty;
			//if(!atrLeaveRaised)OnLeave(EventArgs.Empty);
			AccTextBox_Validated(this ,e);		
			atrValidatedRaised = true;
			base.OnValidated (e);
		}
				

		private void AccTextBox_Validated(object sender, EventArgs e)	
		{
			atrTextChangedByUser = false;
			SetTextBoxValue(this.Text);
			this.BackColor = Color.Empty;
			atrTextChangedByUser = true;
		}	

		/// <summary>
		/// Manejo Interno del Evento TextChanged
		/// </summary>
		/// <param name="e">args</param>
		protected override void OnTextChanged(EventArgs e)
		{
			AccTextBox_TextChanged(this ,e);
			base.OnTextChanged (e);
		}

		private void AccTextBox_TextChanged(object sender, EventArgs e)
		{
			if (Vacio) return;
			if (!atrCambioPorRelleno)
			{						
				LimpiaCajasTextoDependientes();
			}
		}

        private void AccTextBox_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Yellow; 
        }

		/// <summary>
		/// Manejo Interno del Evento EnableChanged
		/// </summary>
		/// <param name="e">args</param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			AccTextBox_EnabledChanged(this ,e);
			base.OnEnabledChanged (e);
		}

		private void AccTextBox_EnabledChanged(object sender, EventArgs e)
		{			
			if (this.Enabled)			
				this.BackColor = Color.Empty;			
			else
				this.BackColor = atrColorDesactivado;				
		}

		/// <summary>
		/// De uso interno para lanzar el abandono de pantalla
		/// </summary>
		public void RaiseLeave(){
			//SendKeys.Send("{TAB}");
			if(this.Parent != null)
				this.Parent.SelectNextControl(this ,true ,false ,true ,true);
		}
		
		#endregion //Eventos

		#region Privados

		/// <summary>
		/// Funcion para Obtener los Valores de Dependencia
		/// </summary>
		/// <param name="prmPedirValores">Determina si se pedirá que el usuario 
		/// seleccione el valor de un catálogo en caso que no encuentre el valor disponible
		/// </param>
		/// <returns>Devuelve Cierto si Obtuvo todos los Valores de Dependencia Obligatorias</returns>		
		private bool getValoresDependencias(bool prmPedirValores)
		{
			if (Vacio) return false;
			if (atrCatalogoBase.ValoresDeDependencias == null) return true;

			foreach(ValorDependencia valorDep in atrCatalogoBase.ValoresDeDependencias)
			{
				if (valorDep.Valor == "" && valorDep.DependenciaObligatoria)
				{
					AccTextBox cajaTextoDependencia = this.ObtenCajaTextoConMetacatalogo(valorDep.MetaCatalogoDependencia.NombreMetaCatalogo);
					if (cajaTextoDependencia != null)
					{
						if (prmPedirValores)
						{							
							if (!cajaTextoDependencia.SeleccionDeElemento(""))
								return false;
						}
						else
							return false;
					}
					else
					{
						if (prmPedirValores)
						{
							Catalogo catalogoDependencia = new Catalogo(valorDep.MetaCatalogoDependencia);
							string val = catalogoDependencia.RegresaEleccionDeUsuario("");
							if (val == "*")
								return false;
							valorDep.Valor = val;
						}
						else
						{							
							return false;
						}
					}
				}
			}
			return true;
		}
		
		
		#endregion //Privados

		#region Públicos
		


		/// <summary>
		/// Remplaza la funcion Folio_Valido que existia en el ClsTool para validar el elemento del Control.
		/// </summary>
		/// <param name="TIEMPO_REAL">Validar con consulta a la Base de Datos o no</param>
		/// <returns>Cierto o Falso</returns>
		public bool ElementoValido(bool TIEMPO_REAL){
			if((this.Text == null) || (this.Text.Trim() == ""))
				return false;

			if(TIEMPO_REAL)
				return (this.ObtenElementoRowActual() != null);
			else
				return this.ValorValido;
		}

		/// <summary>
		/// Muestra el Cuadro de Seleccion de Elemento del atrCatalogoBase
		/// </summary>
		/// <param name="prmCriterio">Criterio para el filtrado de registros </param>
		/// <returns> regresa cierto si el usuario eligió algun elemnto</returns>
		public bool SeleccionDeElemento(string prmCriterio)
		{
			string strSeleccion = RegresaEleccionDeUsuario(prmCriterio);
			if (strSeleccion != "*")
			{	
				//Se comentario esta linea ya que el SetTextBoxValue se vuelve a ejecutar al validarse el control
				this.SetTextBoxValue(strSeleccion);
				this.Text = strSeleccion;
				OnSeleccionoElemento(this, new SelectedElementArgs( ObtenElementoRowActual(), atrCatalogoBase));
				return true;
			}
			return false;
		}

		/// <summary>
		/// Le muestra una ayuda rapida al usuario para que seleccione un elemento del catalogo del la Caja de Texto
		/// </summary>
		/// <param name="prmCriterio">Criterio para filtrar los Registros</param>
		/// <returns>Regresa el valor de la ultima columna del grid de la vista de Busqueda Rapida</returns>
		public string RegresaEleccionDeUsuario(string prmCriterio)
		{
			if (atrCatalogoBase.Vacio) {return "*";}
			if (PedirValoresDependenciasObligatorias())
				return atrCatalogoBase.RegresaEleccionDeUsuario(prmCriterio);
			return "*";
		}
		
		/// <summary>
		/// Regresa la Descripcion de la clave escrita en la Caja de Texto y verifica que el valor sea válido
		/// </summary>
		/// <returns>Devuelve la descripción de la clave especificada en la caja de Texto o una cadena de "No Validez" en caso de que no sea un valor válido</returns>
		public string ValidayObtenDescripcion()
		{
			atrValorValido = true;
			if (this.atrCatalogoBase == null || this.atrCatalogoBase.Vacio) return this.Text;
			atrValorValido = false;
			if (this.Text == "") return CadenaDescripcionNoValida;
			DataRow row = atrCatalogoBase.ObtenElementoRow(this.Text);
			if (row != null)
			{				
				atrValorValido = true;
				return row[this.atrCatalogoBase.MetaCatalogoBase.CampoDescripcion].ToString();
			}
			return CadenaDescripcionNoValida;
		}
		
		/// <summary>
		/// Regresa un arreglo de Cajas de Texto de quienes depende la Caja de Texto Actual y que se encuentren en el contenedor
		/// </summary>
		/// <returns>Devuelve un Arreglo de Cajas de Texto con las dependencias que existan en el mismo contenedor </returns>
		public AccTextBox[] ObtenCajasTextoDependencias()	
		{
			if (this.atrCatalogoBase == null || this.atrCatalogoBase.Vacio || this.atrCatalogoBase.MetaCatalogoBase.TieneDependencias) return null;
			
			AccTextBox[] cajasTextoDependencias = new AccTextBox[0];
			AccTextBox   cajaTextoDependencia;			
			foreach (Control ctrl in this.Parent.Controls)
			{
				if (ctrl.GetType() == this.GetType() && !(this == ctrl))
				{
					cajaTextoDependencia = (AccTextBox)ctrl;
					if (!cajaTextoDependencia.atrCatalogoBase.Vacio)
					{
						if (this.atrCatalogoBase.DependoDe(cajaTextoDependencia.atrCatalogoBase))						
						{
							AccTextBox[] aux = new AccTextBox[cajasTextoDependencias.Length + 1];
							cajasTextoDependencias.CopyTo(aux,0);
							aux[aux.Length-1] = cajaTextoDependencia;
							cajasTextoDependencias = aux;
						}
					}
				}
			}
			if (cajasTextoDependencias.Length > 0)
			{
				return cajasTextoDependencias;
			}
			return null;
		}
		
		/// <summary>
		/// Obtiene las Cajas de Texto que dependen de la Caja de Texto actual
		/// </summary>
		/// <returns>Devuelve un Arreglo de Cajas de Texto con las Cajas de Texto dependientes que existan en el mismo contenedor </returns>
		public AccTextBox[] ObtenCajasTextoDepedientes()	
		{
			if (this.atrCatalogoBase == null || this.atrCatalogoBase.Vacio) {return null;}
			AccTextBox[] cajasTextoDependientes = new AccTextBox[0];
			AccTextBox   cajaTextoDependiente;
			foreach (Control ctrl in this.Parent.Controls)
			{
				if (ctrl.GetType() == this.GetType() && !(this == ctrl))
				{
					cajaTextoDependiente = (AccTextBox)ctrl;
					if (!cajaTextoDependiente.Vacio)
					{
						if (cajaTextoDependiente.atrCatalogoBase.DependoDe(this.atrCatalogoBase))
						{
							AccTextBox[] aux = new AccTextBox[cajasTextoDependientes.Length + 1];
							cajasTextoDependientes.CopyTo(aux,0);
							aux[aux.Length-1] = cajaTextoDependiente;
							cajasTextoDependientes = aux;
						}
					}
				}
			}
			if (cajasTextoDependientes.Length > 0)
			{
				return cajasTextoDependientes;
			}
			return null;
		}
		
		/// <summary>
		/// Con esta función se buscan a todos las Cajas de Texto que 
		/// dependan de esta y los limpia
		/// </summary>		
		public void LimpiaCajasTextoDependientes()
		{
			if (this.atrCatalogoBase == null || this.atrCatalogoBase.Vacio ) return;
			if (atrControlDestinoDescripcion != null)
			{
				this.atrControlDestinoDescripcion.Text = "";					
			}
			AccTextBox[] cajasParaLimpiar = this.ObtenCajasTextoDepedientes();
			if (cajasParaLimpiar != null)
			{
				foreach(AccTextBox cajaTexto in cajasParaLimpiar)
				{
					cajaTexto.Text = "";
					cajaTexto.atrCatalogoBase.LimpiarValorDependencia(this.atrCatalogoBase.MetaCatalogoBase.NombreMetaCatalogo);
				}
			}
		}
		
		/// <summary>
		/// Con esta función se buscan a todas las Cajas de Texto que dependan de la 
		/// Caja de texto Actual y les asigna el valor de dependencia correspondiente
		/// </summary>		
		public void SetMiValorEnCajasDependientes()
		{
			AccTextBox[] cajasDependientes = this.ObtenCajasTextoDepedientes();
			if (cajasDependientes == null) return;
			foreach(AccTextBox cajaTexto in cajasDependientes)
			{					
				cajaTexto.atrCatalogoBase.SetValorDeDependecia(this.atrCatalogoBase.MetaCatalogoBase.NombreMetaCatalogo, this.Text);
			}

		}

		/// <summary>
		/// Se encarga de Obtener lo valores de Dependencias del Catalogo base 
		/// a partir de las Cajas de Texto Dependencia que existan en la forma
		/// y si no encuentra alguna, o tiene un valor inválido, pide el valor
		/// y llena la caja de Texto de dependencia
		/// </summary>
		/// <returns>Devuelve cierto si Lleno todas los Valores de Dependencia Obligatorios</returns>
		public bool PedirValoresDependenciasObligatorias()
		{
			return getValoresDependencias(true);
		}
		/// <summary>
		/// Obtiene los valores de Dependencia que existan en la forma
		/// </summary>
		/// <returns>Devuelve cierto si encontró a todas las dependencias Obligatorias 
		/// del catalogo en la forma y además con valores válidos
		/// </returns>
		public bool ObtenValoresDependenciasExistentes()
		{
			return getValoresDependencias(false);
		}
//		/// <summary>
//		/// Obtener el elemento DataRow del Valor valido 		
//		/// que se encuentre en la Caja de Texto
//		/// </summary>
//		/// <returns>Regresa un DataRow con el Renglon Actual</returns>		
//		public DataRow ObtenElementoRowActual()
//		{
//			if(this.atrCatalogoBase == null)
//				return null;
//
//			if (this.atrCatalogoBase.Vacio || this.Text == "" ) {return null;}
//			if (atrValorValido)
//			{
//				return this.atrCatalogoBase.ObtenElementoRow(this.Text);
//			}
//			else
//			{
//				return null;
//			}
//		}

		/// <summary>
		/// Obtener el elemento DataRow del Valor valido 		
		/// que se encuentre en la Caja de Texto
		/// </summary>
		/// <returns>Regresa un DataRow con el Renglon Actual</returns>
		public DataRow ObtenElementoRowActual()
		{
			return ObtenElementoRowActual(this.Text);
		}


		/// <summary>
		/// Obtener el elemento DataRow del Valor valido 		
		/// que se encuentre en la Caja de Texto
		/// </summary>
		/// <param name="prmValor">Valor a establecer</param>
		/// <returns>Regresa un DataRow con el Renglon Actual</returns>
		public DataRow ObtenElementoRowActual(string prmValor)
		{
			if(this.atrCatalogoBase == null)
				return null;

			if (this.atrCatalogoBase.Vacio || prmValor == "" ) {return null;}
			if (atrValorValido)
			{
				return this.atrCatalogoBase.ObtenElementoRow(prmValor);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// Regresa una Caja de Texto que tenga asociado el metacatalogo especificado
		/// </summary>
		/// <param name="prmMetacatalogo">Nombre del MetaCatálogo a buscar</param>
		/// <returns>Devuelve una Caja de Texto</returns>
		public AccTextBox ObtenCajaTextoConMetacatalogo(string prmMetacatalogo)
		{	
			foreach (Control ctrl in this.Parent.Controls)
			{
				if (ctrl.GetType() == this.GetType())
				{
					AccTextBox cajaTextoDependencia = (AccTextBox)ctrl;
					if(cajaTextoDependencia.CatalogoBase != null)
					{
						if(cajaTextoDependencia != null)
						{
							if (!cajaTextoDependencia.atrCatalogoBase.Vacio && cajaTextoDependencia.atrCatalogoBase.MetaCatalogoBase.NombreMetaCatalogo == prmMetacatalogo)
							{
								return cajaTextoDependencia;
							}
						}
					}
				}
			}
			return null;
		}


		/// <summary>
		/// Pinta el control con el color de elemento invalido default
		/// </summary>
		public void SetColorElementoInvalido(){
			this.BackColor = Color.Orange;
		}

		/// <summary>
		/// Asigna a la Caja de Texto el Valor para se evaluado como elemento del Catalogo
		/// </summary>
		/// <param name="prmValor">Valor Primario</param>
		public void SetTextBoxValue(string prmValor)
		{
			this.Text = prmValor;
			if (Vacio || atrOldValue == prmValor)
			{				
				atrOldValue = prmValor;
				if (atrControlDestinoDescripcion != null){
					atrDescripcion = ValidayObtenDescripcion();
					if (atrControlDestinoDescripcion != null)						
						atrControlDestinoDescripcion.Text = atrDescripcion;
					this.SetMiValorEnCajasDependientes();					
				}
				OnCambioElemento(this, new SelectedElementArgs(ObtenElementoRowActual(prmValor), atrCatalogoBase));
				return;
			}
			if (!OnBeforeCambio(this, new BeforeCambioEventArgs(ObtenElementoRowActual(prmValor), this.CatalogoBase)))
			{
				this.Text = atrOldValue;
				return;
			}

			LimpiaCajasTextoDependientes();
			//string descripcion = ValidayObtenDescripcion();
			atrDescripcion = ValidayObtenDescripcion();
			if (atrControlDestinoDescripcion != null)
				//atrControlDestinoDescripcion.Text = descripcion;
				atrControlDestinoDescripcion.Text = atrDescripcion;
			if (atrValorValido)
			{
				atrCambioPorRelleno = true;
				this.Text = atrCatalogoBase.ValorPrimarioConCeros(prmValor);
				atrCambioPorRelleno = false;
				this.SetMiValorEnCajasDependientes();
			}
			atrOldValue = this.Text;
			OnCambioElemento(this, new SelectedElementArgs(ObtenElementoRowActual(prmValor), atrCatalogoBase));
			}

		
		#endregion Públicos

		#region Protegidos 
		
		/// <summary>
		/// Metodo que determina el evento tiene delegados asociados para disparar el evento SeleccionoElemento.
		/// </summary>
		/// <param name="sender">Objeto que dispara este evento</param>
		/// <param name="e">Valores del evento</param>
		protected virtual void OnSeleccionoElemento (object sender, SelectedElementArgs e)
		{
			if (SeleccionoElemento!=null)
			{
				SeleccionoElemento(sender, e);
			}
		}

		/// <summary>
		/// Metodo que determina el evento tiene delegados asociados para disparar el evento CambioElemento.
		/// </summary>
		/// <param name="sender">Objeto que dispara este evento</param>
		/// <param name="e">Valores del evento</param>
		protected virtual void OnCambioElemento (object sender, SelectedElementArgs e)
		{
			if (CambioElemento!=null)
			{
				CambioElemento(sender, e);
			}
		}	

		/// <summary>
		/// Metodo que determina el evento tiene delegados asociados para disparar el evento BeforeCambioElemento.
		/// </summary>
		/// <param name="sender">Objeto que dispara este evento</param>
		/// <param name="e">Valores del evento</param>
		protected virtual bool OnBeforeCambio(object sender, BeforeCambioEventArgs e)
		{
			if (BeforeCambioElemento!=null)
			{
				BeforeCambioElemento(sender, e);
				return !e.Cancel;
			}
			return true;
		}	

		
		#endregion //Protegidos



		#endregion //Métodos

		
	}
}
