using System;

namespace Sistema.Complementos
{
	/// <summary>
	/// Argumentos para el evento ElementoInvalido de AccTextBox
	/// </summary>
	public class ElementoInvalidoEventArgs : System.ComponentModel.CancelEventArgs
	{
		
		
		/// <summary>
		/// Constructor base
		/// </summary>
		/// <param name="cancel">define si se cancelara</param>
		/// <param name="mensaje">mensaje a mostrar</param>
		/// <param name="text">texto invalido del control</param>
		public ElementoInvalidoEventArgs(bool cancel ,string mensaje ,string text):base(cancel){			
			atrMensaje = mensaje;
			atrText = text;
		}

		private string atrMensaje;
		private string atrText;

		/// <summary>
		/// Obtiene o establece el mensaje que se mostrara en el MessageBox de elemento invalido
		/// </summary>
		public string Mensaje
		{
			get{return atrMensaje;}
			set{atrMensaje = value;}
		}

		/// <summary>
		/// Obtiene el texto invalido del control
		/// </summary>
		public string Text{
			get{return atrText;}
		}

	}
}
