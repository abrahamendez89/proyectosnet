using System;

namespace Sistema
{
	/// <summary>
	/// Descripción breve de tbFormats.
	/// </summary>
	public enum tbFormats
	{
		/// <summary>
		/// Todos los caracteres y números con espacios. Valor por
		/// defecto de la propiedad Format
		/// </summary>
		SpacedAlphaNumeric,
		/// <summary>
		/// Todos los caracteres y números sin espacios
		/// </summary>
		NoSpacedAlphaNumeric,
		/// <summary>
		/// Sólo las letras con espacios
		/// </summary>
		SpacedAlphabetic,
		/// <summary>
		/// Sólo las letras sin espacios
		/// </summary>
		NoSpacedAlphabetic,
		/// <summary>
		/// Sólo números enteros sin signo
		/// </summary>
		UnsignedNumber,
		/// <summary>
		/// Sólo números enteros con signo
		/// </summary>
		SignedNumber,
		/// <summary>
		/// Sólo números con coma decimal flotante sin signo
		/// </summary>
		UnsignedFloatingPointNumber,
		/// <summary>
		/// Sólo números con coma decimal flotante con signo
		/// </summary>
		SignedFloatingPointNumber,
		/// <summary>
		/// Sólo números con coma decimal fija sin signo. El número
		/// de decimales se debe especificar en la propiedad Decimals
		/// </summary>
		UnsignedFixedPointNumber,
		/// <summary>
		/// Sólo números con coma decimal fija con signo. El número
		/// de decimales se debe especificar en la propiedad Decimals
		/// </summary>
		SignedFixedPointNumber,
		/// <summary>
		/// Sólo números en formato hexadecimal
		/// </summary>
		HexadecNumber,
		/// <summary>
		/// Sólo números en formato octal
		/// </summary>
		OctalNumber,
		/// <summary>
		/// Sólo números en formato binario
		/// </summary>
		BynaryNumber,
		/// <summary>
		/// Definido por usuario
		/// </summary>
		UserDefined
	}
}
