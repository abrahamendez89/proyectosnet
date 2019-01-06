using System;

namespace Sistema
{
	/// <summary>
	/// Descripci�n breve de tbFormats.
	/// </summary>
	public enum tbFormats
	{
		/// <summary>
		/// Todos los caracteres y n�meros con espacios. Valor por
		/// defecto de la propiedad Format
		/// </summary>
		SpacedAlphaNumeric,
		/// <summary>
		/// Todos los caracteres y n�meros sin espacios
		/// </summary>
		NoSpacedAlphaNumeric,
		/// <summary>
		/// S�lo las letras con espacios
		/// </summary>
		SpacedAlphabetic,
		/// <summary>
		/// S�lo las letras sin espacios
		/// </summary>
		NoSpacedAlphabetic,
		/// <summary>
		/// S�lo n�meros enteros sin signo
		/// </summary>
		UnsignedNumber,
		/// <summary>
		/// S�lo n�meros enteros con signo
		/// </summary>
		SignedNumber,
		/// <summary>
		/// S�lo n�meros con coma decimal flotante sin signo
		/// </summary>
		UnsignedFloatingPointNumber,
		/// <summary>
		/// S�lo n�meros con coma decimal flotante con signo
		/// </summary>
		SignedFloatingPointNumber,
		/// <summary>
		/// S�lo n�meros con coma decimal fija sin signo. El n�mero
		/// de decimales se debe especificar en la propiedad Decimals
		/// </summary>
		UnsignedFixedPointNumber,
		/// <summary>
		/// S�lo n�meros con coma decimal fija con signo. El n�mero
		/// de decimales se debe especificar en la propiedad Decimals
		/// </summary>
		SignedFixedPointNumber,
		/// <summary>
		/// S�lo n�meros en formato hexadecimal
		/// </summary>
		HexadecNumber,
		/// <summary>
		/// S�lo n�meros en formato octal
		/// </summary>
		OctalNumber,
		/// <summary>
		/// S�lo n�meros en formato binario
		/// </summary>
		BynaryNumber,
		/// <summary>
		/// Definido por usuario
		/// </summary>
		UserDefined
	}
}
