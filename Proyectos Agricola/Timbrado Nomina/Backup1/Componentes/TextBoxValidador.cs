using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


namespace Sistema
{

	/// <summary>
	/// Caja de texto que permite el control autom�ticoo del formato 
	/// de entrada del texto.
	/// </summary>
	public class TextBoxValidador : System.Windows.Forms.TextBox
	{
		private System.ComponentModel.Container components = null;

		#region Campos protected y private

		// Almacena el valor de la propiedad Format
		protected tbFormats format;

 

		/* Mete las teclas TAB, RETORNO e INTRO en la cadena 
		 * ControlKeys para aceptar siempre estas teclas    */
		protected string ControlKeys=((char) 8).ToString()+
			((char) 9).ToString()+((char) 13).ToString();


		// Almacena el valor de la propiedad UserValues
		protected string userValues="";

		// Almacena el valor de la propiedad DecSeparator
		protected char decSeparator='.';

		// Almacena el valor de la propiedad Decimals
		protected byte decimals=0;

		// Almacena los d�gitos v�lidos para algunos formatos
		private string okValues;

		// Color que se aplicara al control al estar desactivado
		private Color		atrColorDesactivado;

		/// <summary>
		/// Bandera para el control de decimales al asignar directamente al control.
		/// </summary>
		private bool atrMedianteAsignacion;


		private decimal atrMaxValue;
		private decimal atrMinValue;

		/// <summary>
		/// Obtiene o establece el color del control cuando este se encuentre desactivado.
		/// </summary>
		[Description("Determina el Color a aplicar al control cuando este este desactivado."),Category("Presentaci�n")]
		public Color		ColorDesactivado			
		{
			get {return atrColorDesactivado;}
			set {atrColorDesactivado = value;}
		}

		/// <summary>
		/// Obtiene o establece el valor maximo a capturar en la caja de texto, default 99,999.999
		/// </summary>
		[Description("Obtiene o establece el valor maximo a capturar en la caja de texto, default 99,999.999"),Category("Configuraci�n")]
		public decimal MaxValue{
			get{return atrMaxValue;}
			set{atrMaxValue = value;}
		}

		/// <summary>
		/// Para uso futuro
		/// </summary>
		public decimal MinValue{
			get{return atrMinValue;}
			set{atrMinValue = value;}
		}

		#endregion

 

		#region Constructor y m�todo protected Dispose

		/// <summary>
		/// Constructor base
		/// </summary>
		public TextBoxValidador():base()
		{
			// Llamada requerida por el Dise�ador de formularios Windows.Forms.
			InitializeComponent();
			// Inicializa el formato por defecto
			this.Format=tbFormats.SpacedAlphabetic;
			atrMaxValue = 99999.99M;
			
		}

 
		/// <summary>
		/// Limpiar los recursos que se est�n utilizando.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Maneja el evneto Enabled changed
		/// </summary>
		/// <param name="e"></param>
		protected override void OnEnabledChanged(EventArgs e)
		{
			if (this.Enabled)			
				this.BackColor = Color.Empty;			
			else
				this.BackColor = atrColorDesactivado;	
			base.OnEnabledChanged (e);
		}


		#endregion

 

		#region Component Designer generated code
		/// <summary> 
		/// M�todo necesario para admitir el Dise�ador, no se puede modificar 
		/// el contenido del m�todo con el editor de c�digo.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();			
		}

		#endregion

 

		#region M�todos privados de apoyo


		/// <summary>
		/// Pinta el control con el color de elemento invalido default
		/// </summary>
		public void SetColorElementoInvalido()
		{
			this.BackColor = Color.Orange;
		}

		/// <summary>
		/// Valida el mensaje WM_CHAR recibido desde WndProc.
		/// </summary>		
		/// <param name="m">
		/// Mensaje WM_CHAR recibido en WndProc
		/// </param>
		/// <returns>
		/// true si la pulsaci�n es v�lida
		/// false si la pulsaci�n no es v�lida
		/// </returns>

		private bool Validar(ref Message m)
		{
			/* Para algunos formatos habr� que aceptar determinados
			 * caracteres dependiendo del texto que contenga y/o
			 * de la posici�n del cursor    */



			string values="";

			switch (this.format)
			{
				case tbFormats.SpacedAlphaNumeric:
					return true;

 
				case tbFormats.NoSpacedAlphaNumeric:
					if (m.WParam.ToInt32()!=(int) ' ')
						return true;
					else
						return false;

				case tbFormats.SignedNumber:
					values="1234567890"+this.ControlKeys;
					this.ComprobarSigno(ref values);
					break;

				case tbFormats.UnsignedFloatingPointNumber:
					values="1234567890"+this.ControlKeys;
					/* Si es una coma o un punto se convierte al separador 
						 * decimal establecido en la propiedad DecSeparator    */
					if (m.WParam==(IntPtr) ',' || m.WParam==(IntPtr) '.')
						m.WParam=(IntPtr) this.DecSeparator;

					this.ComprobarComa(ref values);
					break;

				case tbFormats.SignedFloatingPointNumber:
					values="1234567890"+this.ControlKeys;
					if (m.WParam==(IntPtr) ',' || m.WParam==(IntPtr) '.')
						m.WParam=(IntPtr) this.DecSeparator;

					this.ComprobarComa(ref values);
					this.ComprobarSigno(ref values);
					break;

				case tbFormats.UnsignedFixedPointNumber:
					values=this.ControlKeys;
					if (m.WParam==(IntPtr) ',' || m.WParam==(IntPtr) '.')
						m.WParam=(IntPtr) this.DecSeparator;

					this.ComprobarPosicion(ref values);
					break;

				case tbFormats.SignedFixedPointNumber:
					values=this.ControlKeys;
					if (m.WParam==(IntPtr) ',' || m.WParam==(IntPtr) '.')
						m.WParam=(IntPtr) this.DecSeparator;

					this.ComprobarSigno(ref values);
					this.ComprobarPosicion(ref values);
					break;

				default:
					values=okValues;
					break;
			}

 
			if (values.IndexOf((char) m.WParam)>=0)
				return ValidaMaximos(ref m);
			else
				return false;

		}


		/// <summary>
		/// Valida que el texto tecleado sea menor o igual al maximo permitido
		/// </summary>
		/// <param name="Message">texto a validar</param>
		/// <returns>Exito</returns>
		private bool ValidaMaximos(ref Message m){
			if("1234567890".IndexOf((char)m.WParam) >= 0 && EsFormatoDecimal())
				return Decimal.Parse((this.Text + (char)m.WParam)) <= atrMaxValue;
			return true;
		}

		/// <summary>
		/// Comprueba si el formato actual es de alg�n tipo de 
		/// n�mero decimal
		/// </summary>
		/// <returns>
		/// true si el formato es decimal
		/// false si el formato no es decimal
		/// </returns>
		private bool EsFormatoDecimal()
		{
			return ((int) this.format>=6 && (int) this.format<=9);
		}

 
		/// <summary>
		/// Comprueba si se puede poner la coma con un formato
		/// de n�mero decimal
		/// </summary>
		/// <param name="values">
		/// Cadena con los d�gitos aceptados para el formato. Si
		/// se puede poner el separador decimal, el m�todo lo a�ade
		/// a values, que se pasa por referencia
		/// </param>

		private void ComprobarComa(ref string values)
		{
			if (base.Text.IndexOf(this.decSeparator)>=0)
			{
				if (base.SelectedText.IndexOf(this.decSeparator)>=0)
					values+=this.decSeparator.ToString();
			}
			else
				values+=this.decSeparator.ToString();
		}

 
		/// <summary>
		/// Comprueba si se puede poner el singo en un formato
		/// num�rico seg�n la posici�n del cursor
		/// </summary>
		/// <param name="values">
		/// Cadena con los d�gitos aceptados para el formato. Si
		/// se puede poner el signo, el m�todo lo a�ade
		/// a values, que se pasa por referencia
		/// </param>
		private void ComprobarSigno(ref string values)
		{
			if (base.Text.IndexOf('-')>=0)
			{
				if (base.SelectedText.IndexOf('-')>=0)
					values+='-'.ToString();
			}
			else
			{
				if (base.SelectionStart==0)
					values+='-'.ToString();
			}

		}

 

		/// <summary>
		/// Comprueba si se puede seguir escribiendo n�meros en un
		/// formato FixedPointNumber seg�n la posici�n del cursor
		/// </summary>
		/// <param name="values">
		/// Cadena con los d�gitos aceptados para el formato. Si
		/// se puede poner un n�mero, el m�todo los a�ade
		/// a values, que se pasa por referencia
		/// </param>

		private void ComprobarPosicion(ref string values)
		{
			if (base.Text.Length-(base.SelectionStart+base.SelectionLength)<=this.decimals)
				this.ComprobarComa(ref values);

			int pos=base.Text.IndexOf(this.DecSeparator);
			if (pos>=0)
			{
				if (base.SelectionStart>pos)
				{
					if (base.SelectionLength>0 || base.Text.Length-pos<=this.decimals)
						values+="0123456789";
				}
				else
					values+="0123456789";
			}
			else
				values+="0123456789" + this.DecSeparator;
		}

 

		/// <summary>
		/// Actualiza el separador decimal en el texto ya escrito
		/// </summary>
		private void ActualizarSeparador()
		{
			char[] s=this.Text.ToCharArray();
			base.Text="";
			for (int i=0; i<s.Length;i++)
			{
				if (s[i]==',' || s[i]=='.')
					s[i]=this.DecSeparator;
				base.Text+=s[i].ToString();
			}
		}

 
		/// <summary>
		/// Cambia a base decimal un n�mero escrito en cualquier base
		/// </summary>
		/// <param name="Base">
		/// Base en la que est� escrito el n�mero
		/// </param>
		/// <returns>
		/// El n�mero en base decimal como tipo long
		/// </returns>

		private long BaseADecimal(int Base)
		{
			char[] s=this.Text.ToUpper().ToCharArray();
			long res=0;
			double digito;
			for (int i=s.Length-1; i>=0; i--)
			{
				try
				{
					// Si el d�gito es un n�mero, lo obtenemos
					digito=Double.Parse(s[i].ToString());
				}
				catch
				{
					/* Si el d�gito es una letra, calculamos su 
					 * valor en base decimal    */
					digito=(double) ((int) s[i] - (int) 'A' + 10);
				}
				res+=(long) (Math.Pow((double) Base,(double) (s.Length-1-i))* digito);
			}
			return res;

		}

 

		/// <summary>
		/// Cambia a cualquier base un n�mero escrito en base decimal
		/// </summary>
		/// <param name="num">
		/// n�mero que hay que cambiar
		/// </param>
		/// <param name="Base">
		/// base a la que hay que cambiar
		/// </param>
		/// <returns>
		/// cadena con el n�mero en la nueva base
		/// </returns>
		private string DecimalABase(long num, int Base)
		{

			int resto=0;
			string res="";
			do
			{
				resto=(int) (num % (long) Base);
				if (resto<10)
					/* Si el resto es menor que 10 lo ponemos en la
					 * cadena    */
					res=resto.ToString()+res;
				else
					/* Si es mayor que diez calculamos la letra que 
					 * le corresponde    */
					res=((char) ((int) 'A' - 10 + resto)).ToString()+res;

				num/=Base;

			} while (num!=0);
			return res;
		}


		#endregion

 

		#region Propiedad Text sobreescrita (override)

 
		/// <summary>
		/// Devuelve o establece el texto del control
		/// </summary>

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				/* En lugar de poner la cadena de un s�lo golpe se
				 * valida uno a uno cada d�gito del texto.
				 * As�, el m�todo validar se ocupar�
				 * de filtrar s�lamente los d�gitos v�lidos seg�n
				 * el formato del texto    */
				const int WM_CHAR=258;
				
				char[] s=value.ToCharArray();
				Message m;
				base.Text="";
				foreach (char c in s)
				{
					this.SelectionStart = base.Text.Length;
					m=Message.Create(this.Handle,WM_CHAR,(IntPtr) c,(IntPtr) 0);
					if (this.Validar(ref m))
						base.Text+=c.ToString();
				}

			}

		}

		#endregion

 

		#region M�todo WndProc sobreescrito (override)


		/// <summary>
		/// Cacha el evento Enter del control para seleccionar el texto completo del control
		/// </summary>
		/// <param name="e">argumentos</param>
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter (e);
			this.BackColor = Color.Yellow;
			this.SelectAll();
		}


		/// <summary>
		/// Este el el m�todo que procesa los mensajes de Windows
		/// para el control. Aqu� es donde se valida que dicho 
		/// mensaje sea v�lido seg�n el formato. La pulsaci�n se
		/// enviar� al control solamente cuando se efect�e la
		/// llamada al WndProc de la clase base, que es el que
		/// realmente enviar� el mensaje al control. En caso de
		/// no hacer la llamada, ser� como si nunca se hubiera
		/// pulsado esa tecla, puesto que no se procesa.
		/// 
		/// Si la pulsaci�n no es v�lida no se produce el evento
		/// KeyPress. Si, a pesar de todo queremos que s� se
		/// produzca el evento habr�a que sobreescribir el m�todo
		/// DefWndProc, en lugar de WndProc
		/// </summary>
		/// <param name="m">
		/// mensaje que recibe del sistema operativo
		/// </param>

		protected override void WndProc(ref Message m)
		{
			/* Cuando se pulsa una tecla, Windows lanza el mensaje
			 * WM_CHAR, cuyo valor es 258    */
			const int WM_CHAR=258;
				
			if (m.Msg==WM_CHAR)
			{
				
				// Se valida la pulsaci�n en Validar
				if (this.Validar(ref m) && this.ValidaMaximos(ref m))
					base.WndProc(ref m);
				/* En caso de que validar devolviera false no se
				 * ejecutar�a ninguna llamada a base.WndProc, por 
				 * lo que la pulsaci�n es ignorada    */
			}
			else
				base.WndProc(ref m);

		}

		/// <summary>
		/// Sobrescribimos el metodo solamente para despintar la caja al salir de ella
		/// </summary>
		/// <param name="e">Argumentos</param>
		protected override void OnValidated(EventArgs e)
		{
			this.BackColor = Color.Empty;
			base.OnValidated (e);
		}


		#endregion

 

		#region Propiedades p�blicas nuevas

 
		/// <summary>
		/// Devuelve o establece el n�mero de decimales para un
		/// formato FixedPointNumber
		/// </summary>
		[Description("Obtiene o establece el numero de decimales aceptado para un tipo FixedPoint."),Category("Configuraci�n")]
		public byte Decimals
		{
			get
			{
				return this.decimals;
			}
			set
			{
				this.decimals=value;
			}
		}

		/// <summary>
		/// Devuelve o establece el car�cter de separaci�n decimal
		/// </summary>
		[Description("Obtiene o establece el caracter que sera separador de decimales."),Category("Configuraci�n")]
		public char DecSeparator
		{
			get
			{
				return this.decSeparator;
			}
			set
			{
				if (value==',' || value=='.')
				{
					this.decSeparator=value;
					/* Este if comprueba si se est� utilizando un
					 * formato decimal y modifica el antiguo separador
					 * por el nuevo en caso afirmativo    */
					if (this.EsFormatoDecimal())
					{
						char[] s=this.Text.ToCharArray();
						base.Text="";
						for (int i=0; i<s.Length;i++)
						{
							if (s[i]==',' || s[i]=='.')
								s[i]=this.DecSeparator;

							base.Text+=s[i].ToString();
						}
					}

				}
			}
		}

 

		/// <summary>
		/// Devuelve o establece el formato de entrada en el TextBox
		/// El texto que tuviera el cuadro de texto se modificar�
		/// para ajustarse al nuevo formato
		/// </summary>
		[Description("Obtiene o establece el Formato aceptado por el control."),Category("Configuraci�n")]
		public tbFormats Format
		{
			get
			{
				return this.format;
			}
			set
			{
				this.format=value;
				/* Para algunos formatos los caracteres aceptados
				 * se determinan directamente en este switch    */
				switch (this.format)
				{
					case tbFormats.BynaryNumber:
						okValues="01";
						break;

					case tbFormats.HexadecNumber:
						okValues="0123456789AaBbCcDdEeFf";
						break;

					case tbFormats.NoSpacedAlphabetic:
						okValues="abcdefghijklmn�opqrstuvwxyz��������������������";
						okValues+=okValues.ToUpper();
						break;

					case tbFormats.OctalNumber:
						okValues="01234567";
						break;

					case tbFormats.SpacedAlphabetic:
						okValues="abcdefghijklmn�opqrstuvwxyz��������������������";
						okValues+=okValues.ToUpper()+" ";
						break;

					case tbFormats.UnsignedNumber:
						okValues="0123456789";
						break;

					case tbFormats.UserDefined:
						okValues=userValues;
						break;

					default:
						okValues="";
						break;

				}


				okValues+=this.ControlKeys;
				/* Modificamos la cadena que contiene forzando la
				 * ejecuci�n del bloque set de la propiedad Text
				 * sobreescrita en esta clase    */
				this.Text=base.Text;
			}

		}

        

		/// <summary>
		/// Devuelve o establece los d�gitos v�lidos en el TextBox
		/// cuando Format est� establecido a UserDefined
		/// </summary>
		[Description("Obtiene o establece la cadena de caracteres aceptados por el control."),Category("Configuraci�n")]
		public string UserValues
		{
			get
			{
				return this.userValues;
			}
			set
			{
				this.userValues=value;
				if (this.format==tbFormats.UserDefined)
					this.Text=base.Text;
			}

		}

 

		#endregion

 

		#region Metodos nuevos de conversi�n del contenido

 

		/// <summary>
		/// Devuelve la cadena de la propiedad Text como un valor
		/// de tipo double siempre que sea posible. En caso de que
		/// dicha cadena no se reconozca como un n�mero devolver� 0 
		/// </summary>
		/// <returns></returns>
		public double ToDouble()
		{
			switch (this.format)
			{
				case tbFormats.HexadecNumber:
					return (double) this.BaseADecimal(16);

				case tbFormats.OctalNumber:
					return (double) this.BaseADecimal(8);

				case tbFormats.BynaryNumber:
					return (double) this.BaseADecimal(2);

				case tbFormats.SpacedAlphabetic:

				case tbFormats.NoSpacedAlphabetic:

				case tbFormats.SpacedAlphaNumeric:

				case tbFormats.NoSpacedAlphaNumeric:

				case tbFormats.UserDefined:

					try
					{
						return Double.Parse(this.Text);
					}
					catch
					{
						return 0D;
					}

				case tbFormats.SignedNumber:

				case tbFormats.UnsignedNumber:

					return Double.Parse(this.Text);

				default:

					char[] s=this.Text.ToCharArray();
					string text="";

					for (int i=0; i<s.Length; i++)
					{
						if (s[i]=='.')
							s[i]=',';

						text+=s[i].ToString();
					}

					return Double.Parse(text,System.Globalization.NumberStyles.Float);

			}

		}

 

		/// <summary>
		/// Devuelve la cadena de la propiedad Text como un valor
		/// de tipo long siempre que sea posible. En caso de que 
		/// la cadena no se reconozca como un n�mero devolver� 0 
		/// </summary>
		/// <returns></returns>
		public long ToInt64()
		{
			return (long) this.ToDouble();
		}

 

		/// <summary>
		/// Devuelve una cadena con el n�mero contenido en la 
		/// propiedad Text en formato Octal. En caso de que la
		/// cadena no se reconozca como un n�mero devolver� 0
		/// </summary>
		/// <returns></returns>

		public string ToOctal()
		{
			return this.DecimalABase(this.ToInt64(),8);
		}

 

		/// <summary>
		/// Devuelve una cadena con el n�mero contenido en la 
		/// propiedad Text en formato Hexadecimal. En caso de que la
		/// cadena no se reconozca como un n�mero devolver� 0
		/// </summary>
		/// <returns></returns>

		public string ToHexadecimal()
		{
			return this.DecimalABase(this.ToInt64(),16);
		}

 

		/// <summary>
		/// Devuelve una cadena con el n�mero contenido en la 
		/// propiedad Text en formato Binario. En caso de que la
		/// cadena no se reconozca como un n�mero devolver� 0
		/// </summary>
		/// <returns></returns>
		public string ToBynary()
		{
			return this.DecimalABase(this.ToInt64(),2);
		}

 

		#endregion

		
	}

}

 



