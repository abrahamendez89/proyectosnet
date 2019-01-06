using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Sistema.Componentes
{
	/// <summary>
	/// Descripción breve de SeleccionesDeUsuario.
	/// </summary>
	public class SeleccionesDeUsuario : System.Windows.Forms.TextBox
	{

	
		#region Eventos y Delegados

		/// <summary>
		/// Delegado para el evento SeleccionoElemento
		/// </summary>
		public  delegate void SeleccionoElementoEventHandler(object sender, SelectedElementArgs e);
		/// <summary>
		/// Delegado para el evento BeforeCambioElemento
		/// </summary>
		public  delegate void BeforeCambioElementoEventHandler(object sender, BeforeCambioMultiseleccionEventArgs e);

		/// <summary>
		/// Delegado para el evento ElementoInvalido
		/// </summary>
		public  delegate void ElementoInvalidoEventHandler(object sender ,Complementos.ElementoInvalidoEventArgs e);

		/// <summary>
		/// Declaracion del evento SeleccionoElemento
		/// </summary>
		public  event SeleccionoElementoEventHandler SeleccionoElemento;
		/// <summary>
		/// Declaracion del evento CambioElemento
		/// </summary>
		public  event SeleccionoElementoEventHandler CambioElemento;
		/// <summary>
		/// Declaracion del evento BeforeCambioElemento
		/// </summary>
		public  event BeforeCambioElementoEventHandler AfterCambioElemento;

		/// <summary>
		/// Declaracion del evento ElementoInvalido
		/// </summary>
		public  event ElementoInvalidoEventHandler ElementoInvalido;

		#endregion //Eventos y Delegados
		
		#region Atributos

		#region Privados
		
		//		private bool atrSoloNumeros;
		//		private bool atrSoloNumerosConPuntoDecimal;

		private System.ComponentModel.Container components = null;


		private bool atrValidoMultiseleccion=false;

				
		//Variable que almacena el OldValue de la cadena de Descripcion.
		private string atrDescripcion;
		private Catalogo	atrCatalogoBase;

		private Control		atrControlDestinoDescripcion;
		private bool		atrValorValido;
		
		private bool		atrCambioPorRelleno;
		private string		atrOldValue = "";
		
		private Color		atrColorDesactivado;

		//Nuevos Requerimientos Vizur
		private bool atrPermiteAvanceElementoInvalido;
		private string atrDescripcionElementoInvalido;
		private bool atrPermiteSoloCapturarAlfanumericos;
		private bool atrValidarEventos;
		private bool atrPermiteAyudarapida;
		private KeyEventArgs atrLastKeyPress;
		private bool atrTextChangedByUser;

		internal int                 atrTotalSeleccionados=0;
		internal bool                atrTodosSeleccionados=false;
		internal bool			    atrNingunoSeleccionado=true;
		internal string				atrCadenaDescripcionSelecciones="";
		private string              atrSeleccionesAnteriores = "";
		private string              atrSeleccionesActuales = "";
		private bool				atrControlVacio =true;
		private bool				atrMandarCambioElemento =false;
		private bool				atrMandarBeforeCambioElemento =false;
		private bool				atrMultiseleccionActiva=false;
		private string				atrSeleccionesPreAnteriores="";
		private bool				atrVieneDeMultiseleccion=false;
		bool						YaEntre=false;
		
		#endregion 

		#region Publicos


		/// <summary>
		/// 
		/// </summary>
		public bool ControlVacio
		{
			get{return atrControlVacio;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SeleccionesAnteriores
		{
			get{return atrSeleccionesAnteriores;}
			set{atrSeleccionesAnteriores = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SeleccionesActuales
		{
			get{return atrSeleccionesActuales;}

		}


		/// <summary>
		/// Obtiene o establece la ultima combinacion de teclas presionadas en el control :D
		/// </summary>
		public  KeyEventArgs LastKeyPress
		{
			get{return atrLastKeyPress;}
			set{atrLastKeyPress = value;}
		}

		/// <summary>
		/// Determina si se permitira la ayuda rapida para el control.
		/// </summary>
		[Description("Determina si se permitira la ayuda rapida para el control."),Category("Configuración")]
		public  bool PermiteAyudaRapida
		{
			get{return atrPermiteAyudarapida;}
			set{atrPermiteAyudarapida = value;}
		}

		/// <summary>
		/// Determina si solo se permitiran caracteres alfanumericos esto para evitar usuarios mal intencionados y todos aquellos errores derivados de la ayuda
		/// </summary>
		[Description("Determina si solo se permitiran caracteres alfanumericos esto para evitar usuarios mal intencionados y todos aquellos errores derivados de la ayuda."),Category("Configuración")]
		public  bool PermiteSoloCapturarAlfanumericos
		{
			get{return atrPermiteSoloCapturarAlfanumericos;}
			set{atrPermiteSoloCapturarAlfanumericos = value;}
		}

		/// <summary>
		/// Obtiene o establece si se podra abandonar el control en caso de que este presente un dato invalido
		/// </summary>
		[Description("Obtiene o establece si se podra abandonar el control en caso de que este presente un dato invalido."),Category("Configuración")]
		public  bool PermiteAvanceElementoInvalido
		{
			get{return atrPermiteAvanceElementoInvalido;}
			set{atrPermiteAvanceElementoInvalido = value;}
		}

		/// <summary>
		/// Obtiene o establece la cadena que se mostrara al informar de que el elemento es invalido
		/// </summary>
		[Description("Obtiene o establece la cadena que se mostrara al informar de que el elemento es invalido."),Category("Configuración")]
		public  string DescripcionElementoInvalido
		{
			get{return atrDescripcionElementoInvalido;}
			set{atrDescripcionElementoInvalido = value;}
		}

		/// <summary>
		/// Obtiene o establece Catalogo base del control.
		/// </summary>
		public  Catalogo		CatalogoBase				
		{
			get{ return atrCatalogoBase;  }
			set{ atrCatalogoBase = value; }
		}

		/// <summary>
		/// Obtiene o establece Control en el cual se desplegara la descipcion del catalogo
		/// </summary>
		public  Control		ControlDestinoDescripcion	
		{
			get{ return atrControlDestinoDescripcion;}
			set{ atrControlDestinoDescripcion = value;}
		}

		/// <summary>
		/// Determina si el valor actual del control es valido.
		/// </summary>
		public  bool			ValorValido					
		{
			get{return atrValorValido;}						
		}
		
		
		/// <summary>
		/// Obtiene o establece la cadena que se desplegara en el ControlDestinoDescripcion
		///  en caso de darse un valor no validp
		/// </summary>
		public  string		CadenaDescripcionNoValida	
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
		public  string		NombreMetaCatalogo			
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
		public  bool			Vacio						
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
		public  Color		ColorDesactivado			
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
		public SeleccionesDeUsuario()
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
		}
		
		
		#endregion

		#region Métodos 
		
		#region Eventos


		/// <summary>
		/// Remplazo del metodo para manejar antes el evento validating
		/// </summary>
		/// <param name="e">argumentos del metodo</param>
		protected override void OnValidating(CancelEventArgs e)
		{
			atrSeleccionesAnteriores =atrSeleccionesActuales ;
			if(!atrValidarEventos) return;
			//Aqui cambiamos el valor valido por una consulta directa ya que el cambio de elemento se raisea en el validated
			//que se ejecuta despues del validating y por lo tanto tiene un valor invalido
			//			if(!atrPermiteAvanceElementoInvalido && this.atrCatalogoBase.ObtenElementoRow(this.Text) == null && this.Text.Trim() != "")
			//			{
			//				//Aqui delegamos la descripcion y la cancelacion de valor al programador
			//				//esto mediante el disparo del evento ElementoInvalido				
			//				Complementos.ElementoInvalidoEventArgs miArgumento = new Access.Complementos.ElementoInvalidoEventArgs(true ,atrDescripcionElementoInvalido ,this.Text);
			//				OnElementoInvalido(miArgumento);
			//				if(miArgumento.Cancel)
			//				{
			//					MessageBox.Show(miArgumento.Mensaje ,"Sistema Comercial" ,MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);						
			//					this.Text = "";
			//					e.Cancel = true;
			//					return;
			//				}				
			//			}
			//			if (!ValorValido)
			//			{
			//				if (this.Text.Trim() != "" && !atrValidoMultiseleccion)
			//				{
			//					SeleccionesActuales="";
			//					SeleccionesAnteriores="";
			//					atrTotalSeleccionados=0;
			//					atrTodosSeleccionados=false;
			//					atrNingunoSeleccionado=true;
			//					this.SetTextBoxValue(this.Text);
			//				}
			//				return;
			//
			//			}
			//base.OnValidating (e);
		}


		/// <summary>
		/// Disparador del evento ElementoInvalido
		/// </summary>
		/// <param name="e">argumentos del evento</param>
		protected  void OnElementoInvalido(Complementos.ElementoInvalidoEventArgs e)
		{
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
			AccSeleccionesDeUsuario_KeyDown(this ,e);
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


		private void AccSeleccionesDeUsuario_KeyDown(object sender, KeyEventArgs e)
		{
			
			//Se coloco aqui para no interferir y que el teclazo lo vea el usuario
			atrLastKeyPress = new KeyEventArgs(e.KeyCode);
			
			if (Vacio) return;
			if (e.KeyCode == Keys.Enter)
			{				
				//SetTextBoxValue(this.Text);
			}

			//Se coloco aqui para no interferir y que el teclazo lo vea el usuario
			atrLastKeyPress = new KeyEventArgs(e.KeyCode);

			if (e.KeyCode == Keys.F1 && atrPermiteAyudarapida)
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
			if(!atrValidarEventos) return;
			AccSeleccionesDeUsuario_Enter(this ,e);
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
		

		/// <summary>
		/// Sobreescribimos la propiedad readonly para limpiar el color del control al esta cambiar
		/// </summary>
		[Description("Determina si el control sera de solo lectura."),Category("Configuración")]
		new public bool ReadOnly
		{
			get{return base.ReadOnly;}
			set
			{
				base.ReadOnly = value;
				this.BackColor = Color.Empty;
			}
		}

		private void AccSeleccionesDeUsuario_Enter(object sender, EventArgs e)		
		{	
			if(base.ReadOnly)
				this.BackColor = Color.Empty;
			else
				this.BackColor = Color.Yellow;
		}


		/// <summary>
		/// Manejo Interno del Evento Validated
		/// </summary>
		/// <param name="e">args</param>
		protected override void OnValidated(EventArgs e)
		{
			if(!atrValidarEventos) return;
			this.BackColor = Color.Empty;
			AccSeleccionesDeUsuario_Validated(this ,e);
			base.OnValidated (e);
		}
				

		private void AccSeleccionesDeUsuario_Validated(object sender, EventArgs e)	
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
			AccSeleccionesDeUsuario_TextChanged(this ,e);
			base.OnTextChanged (e);
		}

		private void AccSeleccionesDeUsuario_TextChanged(object sender, EventArgs e)
		{
			if (Vacio) return;
			if (!atrCambioPorRelleno)
			{						
				LimpiaCajasTextoDependientes();
				if (atrTotalSeleccionados==1)
				{
					atrSeleccionesActuales="";

				}
			}
		}
		
		/// <summary>
		/// Manejo Interno del Evento EnableChanged
		/// </summary>
		/// <param name="e">args</param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			AccSeleccionesDeUsuario_EnabledChanged(this ,e);
			base.OnEnabledChanged (e);
		}

		private void AccSeleccionesDeUsuario_EnabledChanged(object sender, EventArgs e)
		{			
			if (this.Enabled)			
				this.BackColor = Color.Empty;			
			else
				this.BackColor = atrColorDesactivado;				
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
					SeleccionesDeUsuario cajaTextoDependencia = this.ObtenCajaTextoConMetacatalogo(valorDep.MetaCatalogoDependencia.NombreMetaCatalogo);
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
		public  bool ElementoValido(bool TIEMPO_REAL)
		{
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
				if (atrSeleccionesActuales!=""  & atrTotalSeleccionados > 1 )
				{
					strSeleccion="";
				}
				this.SetTextBoxValue(strSeleccion);				
				return true;
			}
			return false;
		}

		/// <summary>
		/// Le muestra una ayuda rapida al usuario para que seleccione un elemento del catalogo del la Caja de Texto
		/// </summary>
		/// <param name="prmCriterio">Criterio para filtrar los Registros</param>
		/// <returns>Regresa el valor de la ultima columna del grid de la vista de Busqueda Rapida</returns>
		public  string RegresaEleccionDeUsuario(string prmCriterio)
		{
			if (Vacio) {return "*";}
			if (PedirValoresDependenciasObligatorias())
				return AccRegresaEleccionesDeUsuario(prmCriterio);
			return "*";
		}
		
		/// <summary>
		/// Regresa la Descripcion de la clave escrita en la Caja de Texto y verifica que el valor sea válido
		/// </summary>
		/// <returns>Devuelve la descripción de la clave especificada en la caja de Texto o una cadena de "No Validez" en caso de que no sea un valor válido</returns>
		public string ValidayObtenDescripcion()
		{
			atrValorValido = true;
			if (this.atrCatalogoBase == null || this.Vacio) return this.Text;
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
		/// Regresa la Descripcion de la clave escrita en la Caja de Texto y verifica que el valor sea válido
		/// </summary>
		/// <param name="texto"></param>
		/// <returns></returns>
		
		public string ValidayObtenDescripcion(string texto)
		{
			atrValorValido = true;
			if (this.atrCatalogoBase == null || this.Vacio) return texto;
			atrValorValido = false;
			if (texto == "") return CadenaDescripcionNoValida;
			DataRow row = atrCatalogoBase.ObtenElementoRow(texto);
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
		public  SeleccionesDeUsuario[] ObtenCajasTextoDependencias()	
		{
			if (this.atrCatalogoBase == null || this.atrCatalogoBase.Vacio || this.atrCatalogoBase.MetaCatalogoBase.TieneDependencias) return null;
			
			SeleccionesDeUsuario[] cajasTextoDependencias = new SeleccionesDeUsuario[0];
			SeleccionesDeUsuario   cajaTextoDependencia;			
			foreach (Control ctrl in this.Parent.Controls)
			{
				if (ctrl.GetType() == this.GetType() && !(this == ctrl))
				{
					cajaTextoDependencia = (SeleccionesDeUsuario)ctrl;
					if (!cajaTextoDependencia.atrCatalogoBase.Vacio)
					{
						if (this.atrCatalogoBase.DependoDe(cajaTextoDependencia.atrCatalogoBase))						
						{
							SeleccionesDeUsuario[] aux = new SeleccionesDeUsuario[cajasTextoDependencias.Length + 1];
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
		public  SeleccionesDeUsuario[] ObtenCajasTextoDepedientes()	
		{
			if (this.atrCatalogoBase == null || this.atrCatalogoBase.Vacio) {return null;}
			SeleccionesDeUsuario[] cajasTextoDependientes = new SeleccionesDeUsuario[0];
			SeleccionesDeUsuario   cajaTextoDependiente;
			foreach (Control ctrl in this.Parent.Controls)
			{
				if (ctrl.GetType() == this.GetType() && !(this == ctrl))
				{
					cajaTextoDependiente = (SeleccionesDeUsuario)ctrl;
					if (!cajaTextoDependiente.Vacio)
					{
						if (cajaTextoDependiente.atrCatalogoBase.DependoDe(this.atrCatalogoBase))
						{
							SeleccionesDeUsuario[] aux = new SeleccionesDeUsuario[cajasTextoDependientes.Length + 1];
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
		public   void LimpiaCajasTextoDependientes()
		{
			if (this.atrCatalogoBase == null || this.atrCatalogoBase.Vacio ) return;
			if (atrControlDestinoDescripcion != null)
			{
				this.atrControlDestinoDescripcion.Text = "";					
			}
			SeleccionesDeUsuario[] cajasParaLimpiar = this.ObtenCajasTextoDepedientes();
			if (cajasParaLimpiar != null)
			{
				foreach(SeleccionesDeUsuario cajaTexto in cajasParaLimpiar)
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
		public  void SetMiValorEnCajasDependientes()
		{
			SeleccionesDeUsuario[] cajasDependientes = this.ObtenCajasTextoDepedientes();
			if (cajasDependientes == null) return;
			foreach(SeleccionesDeUsuario cajaTexto in cajasDependientes)
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
		public  bool PedirValoresDependenciasObligatorias()
		{
			return getValoresDependencias(true);
		}
		/// <summary>
		/// Obtiene los valores de Dependencia que existan en la forma
		/// </summary>
		/// <returns>Devuelve cierto si encontró a todas las dependencias Obligatorias 
		/// del catalogo en la forma y además con valores válidos
		/// </returns>
		public  bool ObtenValoresDependenciasExistentes()
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
		public  DataRow ObtenElementoRowActual()
		{
			return ObtenElementoRowActual(this.Text);
		}


		/// <summary>
		/// Obtener el elemento DataRow del Valor valido 		
		/// que se encuentre en la Caja de Texto
		/// </summary>
		/// <param name="prmValor">Valor a establecer</param>
		/// <returns>Regresa un DataRow con el Renglon Actual</returns>
		public  DataRow ObtenElementoRowActual(string prmValor)
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
		public  SeleccionesDeUsuario ObtenCajaTextoConMetacatalogo(string prmMetacatalogo)
		{	
			foreach (Control ctrl in this.Parent.Controls)
			{
				if (ctrl.GetType() == this.GetType())
				{
					SeleccionesDeUsuario cajaTextoDependencia = (SeleccionesDeUsuario)ctrl;
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
		public  void SetColorElementoInvalido()
		{
			this.BackColor = Color.Orange;
		}


		private void PonerTextoEnSetTextboxValue()
		{
			if ( atrTotalSeleccionados >1 )
			{
				atrDescripcion = atrCadenaDescripcionSelecciones;		
			}


			if(atrTodosSeleccionados )
			{
				atrDescripcion = "Todos";
			}

			if (atrNingunoSeleccionado)
			{
				atrDescripcion="";
				atrSeleccionesAnteriores = "";
				atrSeleccionesActuales = "";
				atrTotalSeleccionados=0;
			}

			if (atrControlDestinoDescripcion != null)
				//atrControlDestinoDescripcion.Text = descripcion;
				atrControlDestinoDescripcion.Text = atrDescripcion;

		}

		private  bool IsNumeric(object Expression)
		{
			bool isNum;
			double retNum;
			isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo, out retNum );
			return isNum;
		}

		private void CodigoUnaSolaSeleccion(string prmValor)
		{
			atrMultiseleccionActiva=false;
			
			
			if  (!IsNumeric(prmValor))
			{
				this.Text="";
				prmValor="0";
			}

			if (atrSeleccionesActuales==Convert.ToInt64( prmValor).ToString())
			{
				//Dejar la seleccion actual sin Manadar Eventos
				if (atrControlDestinoDescripcion != null)
				{
					LimpiaCajasTextoDependientes();

					atrDescripcion = ValidayObtenDescripcion(prmValor);
					if (atrControlDestinoDescripcion != null)						
						atrControlDestinoDescripcion.Text = atrDescripcion;
					this.SetMiValorEnCajasDependientes();

					if (ValorValido)
					{
						atrTotalSeleccionados = 1;
						atrCambioPorRelleno = true;
						this.Text = atrCatalogoBase.ValorPrimarioConCeros(prmValor);
						atrCambioPorRelleno = false;
						this.SetMiValorEnCajasDependientes();

						if (atrOldValue!=this.Text)
						{
							atrMandarCambioElemento=true;
							atrMandarBeforeCambioElemento=true;
						}
					}
					else
						atrTotalSeleccionados = 0;

					//string descripcion = ValidayObtenDescripcion();
					//atrDescripcion = ValidayObtenDescripcion();

				}

			}
			else
			{
				//Hubo Cambios y se lanzara los eventos Cambio Elemento y Before Cambio Elemento
				if (atrControlDestinoDescripcion != null)
				{
					LimpiaCajasTextoDependientes();

					atrDescripcion = ValidayObtenDescripcion(prmValor);
					if (atrControlDestinoDescripcion != null)						
						atrControlDestinoDescripcion.Text = atrDescripcion;
					this.SetMiValorEnCajasDependientes();
							
					if (ValorValido)
					{
						atrTotalSeleccionados = 1;
						atrSeleccionesActuales=Convert.ToInt32( prmValor).ToString();
						atrNingunoSeleccionado=false;
						atrCambioPorRelleno = true;
						this.Text = atrCatalogoBase.ValorPrimarioConCeros(prmValor);
						atrCambioPorRelleno = false;
						this.SetMiValorEnCajasDependientes();

					}
					else
					{
						atrNingunoSeleccionado=true;
						atrSeleccionesAnteriores=atrSeleccionesActuales;
						atrSeleccionesActuales="";
						atrTotalSeleccionados=0;
					}

					if (atrOldValue!=this.Text)
					{
						atrMandarCambioElemento=true;
						atrMandarBeforeCambioElemento=true;
					}




				}

			}
			PonerTextoEnSetTextboxValue();

		}

		/// <summary>
		/// Asigna a la Caja de Texto el Valor para se evaluado como elemento del Catalogo
		/// </summary>
		/// <param name="prmValor">Valor Primario</param>
		public void SetTextBoxValue(string prmValor)
		{
						
			atrMandarCambioElemento=false;
			atrMandarBeforeCambioElemento=false;
			//Cuando es mandado de la opcion de multiseleccion
			if (atrVieneDeMultiseleccion)
			{
				if (atrSeleccionesActuales.Trim()!="")
				{
					if (atrTotalSeleccionados==1)
					{
						//Codigo para una sola seleccion
						CodigoUnaSolaSeleccion(prmValor);
					}
					else
					{
						//Codigo Para multiseleeciones
						LimpiaCajasTextoDependientes();
						PonerTextoEnSetTextboxValue();						
						if (atrSeleccionesActuales!=atrSeleccionesAnteriores)
						{
							atrMandarCambioElemento=true;
							atrMandarBeforeCambioElemento=true;							
						}
						this.Text = "";

					}
					
				}
				//Codigo Para una sola Seleccion
				//Cuando es tecleado el valor manualmente
			}
			else
			{
				if (prmValor.Trim()=="")
				{
					//dejar la seleccion Actual sin Mandar Eventos
					if (atrMultiseleccionActiva)
					{
						PonerTextoEnSetTextboxValue();
					}
					else
					{
						atrNingunoSeleccionado=true;
						atrSeleccionesActuales="";
						PonerTextoEnSetTextboxValue();

						if (atrOldValue!=this.Text)
						{
							atrMandarCambioElemento=true;
							atrMandarBeforeCambioElemento=true;
						}
						atrOldValue="";
					}
				}
				else
				{
					CodigoUnaSolaSeleccion(prmValor);
				}
			}

			atrVieneDeMultiseleccion=false;
	

		
			if (atrMandarCambioElemento && !YaEntre)
			{
				PonerTextoEnSetTextboxValue();
				OnCambioElemento(this, new SelectedElementArgs(ObtenElementoRowActual(prmValor), atrCatalogoBase));
			}

			if (atrMandarBeforeCambioElemento && !YaEntre && !OnBeforeCambio(this, new BeforeCambioMultiseleccionEventArgs(atrSeleccionesActuales,atrSeleccionesAnteriores)))
			{
				this.Text = atrOldValue;
				SetTextBoxValue(atrOldValue);
				return;
			}
			

			atrOldValue=this.Text;

		}

//		/// <summary>
//		/// 
//		/// </summary>
//		/// <param name="prmValor"></param>
//		/// <param name="otro"></param>
//		public void SetTextBoxValue(string prmValor,bool otro)
//		{
//		
//			if (SeleccionesActuales==SeleccionesAnteriores)
//			{
//				return;
//			}
//			if (otro)
//			{
//				this.Text = prmValor;
//			}
//			atrValidoMultiseleccion=false;
//			if (Vacio || atrOldValue == prmValor)
//			{				
//				atrOldValue = prmValor;
//				if (atrControlDestinoDescripcion != null)
//				{
//					atrDescripcion = ValidayObtenDescripcion();
//					if (atrControlDestinoDescripcion != null)						
//						atrControlDestinoDescripcion.Text = atrDescripcion;
//					this.SetMiValorEnCajasDependientes();
//					//OnCambioElemento(this, new SelectedElementArgs(ObtenElementoRowActual(prmValor), atrCatalogoBase));
//				}
//				return;
//			}
//
//			LimpiaCajasTextoDependientes();
//			//string descripcion = ValidayObtenDescripcion();
//			atrDescripcion = ValidayObtenDescripcion();
//			//Cuando estan todos seleccionados
//
//			if ( this.Text=="" && atrSeleccionesActuales != ""  && !atrValorValido && atrCatalogoBase.TotalSeleccionados >1 )
//			{
//				atrDescripcion = atrCatalogoBase.CadenaDescripcionSelecciones;		
//				atrValidoMultiseleccion=true;
//			}
//
//
//			if(this.Text=="" && atrCatalogoBase.TodosSeleccionados )
//			{
//				atrDescripcion = "Todos";
//				atrValidoMultiseleccion=true;
//			}
//
//			if (atrCatalogoBase.NingunoSeleccionado==true  && !atrValorValido  )
//			{
//				atrDescripcion="Ninguno";
//				atrCatalogoBase.SeleccionesAnteriores = "";
//				atrCatalogoBase.SeleccionesActuales = "";
//				atrCatalogoBase.TotalSeleccionados=0;
//				atrValidoMultiseleccion=true;
//			}
//
//			if (atrControlDestinoDescripcion != null)
//				//atrControlDestinoDescripcion.Text = descripcion;
//				atrControlDestinoDescripcion.Text = atrDescripcion;
//
//			if (atrValorValido)
//			{
//				if( atrCatalogoBase.SeleccionesActuales != prmValor )
//				{
//					atrCatalogoBase.SeleccionesAnteriores = Convert.ToInt32(prmValor).ToString();
//					atrCatalogoBase.SeleccionesActuales = Convert.ToInt32(prmValor).ToString();
//					atrCatalogoBase.TotalSeleccionados=1;
//				}
//				atrCambioPorRelleno = true;
//				this.Text = atrCatalogoBase.ValorPrimarioConCeros(prmValor);
//				atrCambioPorRelleno = false;
//				this.SetMiValorEnCajasDependientes();
//			}
//			atrOldValue = this.Text;
//			if (atrValidoMultiseleccion)
//			{
//				atrValorValido=true;
//			}
//			//OnCambioElemento(this, new SelectedElementArgs(ObtenElementoRowActual(prmValor), atrCatalogoBase));
//
//		}
		
		#endregion Públicos

		#region Protegidos 
		
		/// <summary>
		/// Metodo que determina el evento tiene delegados asociados para disparar el evento SeleccionoElemento.
		/// </summary>
		/// <param name="sender">Objeto que dispara este evento</param>
		/// <param name="e">Valores del evento</param>
		protected  void OnSeleccionoElemento (object sender, SelectedElementArgs e)
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
		protected  void OnCambioElemento (object sender, SelectedElementArgs e)
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
		/// <returns></returns>
		protected  bool OnBeforeCambio(object sender, BeforeCambioMultiseleccionEventArgs e)
		{
			if (AfterCambioElemento!=null)
			{
				AfterCambioElemento(sender, e);
				if (e.Cancel)
				{
					atrSeleccionesPreAnteriores=atrSeleccionesAnteriores;
					YaEntre=true;
					AsignaSeleecionActual(atrSeleccionesAnteriores);
					YaEntre=false;
					atrSeleccionesAnteriores=atrSeleccionesPreAnteriores;
					base.Focus();
				}
				return !e.Cancel;
			}
			return true;
		}	

		
		#endregion //Protegidos

		private string  AccRegresaEleccionesDeUsuario(string prmCriterio)
		{						
			while (prmCriterio == "" && atrCatalogoBase.MetaCatalogoBase.CriterioObligatorio && !atrCatalogoBase.MostrarAyudaConNuevoFiltrado)
			{
				prmCriterio = Tool.ShowInputBox(atrCatalogoBase.atrCadenaCriterioObligatorio);
			}
			if (prmCriterio == "*")
			{
				return  "*";
			}
			string sqlQuery = atrCatalogoBase.GetQueryBusquedaRapida(prmCriterio);


			int posOrderBy =sqlQuery.IndexOf("ORDER BY",0);		
			if (posOrderBy>0)
			{
				sqlQuery=sqlQuery.Substring(0,posOrderBy  )  ;
			}
			if (sqlQuery == "")
				return "*";		
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			string vlseleccionesActuales=SeleccionesActuales;
			string sel = "*";
			string Separador = ",";
			


			sel = DAO.RegresaEleccionesDeUsuario(
				sqlQuery
				,vlseleccionesActuales
				,Separador,false,true
				,atrCatalogoBase.MetaCatalogoBase.CriterioObligatorio
				,atrCatalogoBase.MetaCatalogoBase.CampoDeBusqueda 
				,atrCatalogoBase.ParametrosRegresaNuevaEleccionUsuario.NombresFisicosDeColumnas
				,atrCatalogoBase.ParametrosRegresaNuevaEleccionUsuario.ConsultaSQLComplementaria
				,atrCatalogoBase.ParametrosRegresaNuevaEleccionUsuario.CamposDeRelacion);
			atrVieneDeMultiseleccion=true;
			atrTodosSeleccionados=false;

			
			if (sel.Length>0 && sel[0] == "*"[0])
			{
				atrTodosSeleccionados=true;
				sel=sel.Substring(1);
			}


			if (sel != atrSeleccionesActuales )
			{
				atrSeleccionesAnteriores = atrSeleccionesActuales;
				atrSeleccionesActuales=sel;
			}
			//sqlQuery  ,atrMetaCatalogoBase.CriterioObligatorio ,atrMetaCatalogoBase.CampoDescripcion ,atrParametrosRegresaNuevaEleccionUsuario.NombresFisicosDeColumnas ,atrParametrosRegresaNuevaEleccionUsuario.ConsultaSQLComplementaria ,atrParametrosRegresaNuevaEleccionUsuario.CamposDeRelacion);

			string[] Elementos = SeleccionesActuales.Split(Separador[0]);
			int cont=0;
			foreach (string s in Elementos)
			{
				cont+=1;
			}
			//atrCatalogoBase.OnSeleccionoElemento(this, new EventArgs());
			
			atrNingunoSeleccionado=false;

			if (sel == "*")
			{
				atrTodosSeleccionados =true;
				sel="";
			}
			if (sel == "" && !atrTodosSeleccionados)
			{
				atrNingunoSeleccionado=true;
			}

			atrTotalSeleccionados=cont;
			switch(cont)
			{
				case 1:
					return atrCatalogoBase.ValorPrimarioConCeros(sel);					
				case 0:
					atrCadenaDescripcionSelecciones="";					
					return atrCatalogoBase.ValorPrimarioConCeros(atrCadenaDescripcionSelecciones);
				default:
					atrMultiseleccionActiva=true;
					atrCadenaDescripcionSelecciones =  cont.ToString() + " Seleccionados";
					return atrCatalogoBase.ValorPrimarioConCeros(atrCadenaDescripcionSelecciones);
			}
		}

		/// <summary>
		/// Asignar la seleccion cuando se pobla el control
		/// </summary>
		/// <param name="prmSeleccion"></param>
		public void AsignaSeleecionActual(string prmSeleccion)
		{
			atrSeleccionesAnteriores="";
			atrSeleccionesActuales=prmSeleccion;

			string sel = atrSeleccionesActuales;				
			string Separador = ",";

			string[] Elementos = atrSeleccionesActuales.Split(Separador[0]);
			int cont=0;
			foreach (string s in Elementos)
			{		
				cont+=1;
			}
			
			atrTodosSeleccionados=false;
			atrNingunoSeleccionado=false;

			if (sel == "" )
			{
				atrNingunoSeleccionado=true;
				cont=0;
			}

			atrTotalSeleccionados=cont;
			switch(cont)
			{
				case 1:
					atrOldValue="";
					this.Text=atrCatalogoBase.ValorPrimarioConCeros(sel);		
					atrVieneDeMultiseleccion=false;
					this.SetTextBoxValue(sel);
					break;
				case 0:
					this.Text="";
					atrCadenaDescripcionSelecciones="";					
					atrMultiseleccionActiva=true;
					atrVieneDeMultiseleccion=false;
					this.SetTextBoxValue("");
					break;
					//ValorPrimarioConCeros(atrCatalogoBase.atrCadenaDescripcionSelecciones);
				default:
					this.Text="";
					atrCadenaDescripcionSelecciones =  cont.ToString() + " Seleccionados";
					atrVieneDeMultiseleccion=true;
					atrMultiseleccionActiva=true;
					this.SetTextBoxValue("");
					break;
					//ValorPrimarioConCeros(atrCatalogoBase.atrCadenaDescripcionSelecciones);
			}





				


		}





		#endregion //Métodos
	}
}
