using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Excepciones
{
    public class EX_PrecisionNumericaException : Exception
    {
        public EX_PrecisionNumericaException(Object objeto, String mensaje, String propiedadError, String propiedadValor, int enteros, int decimales, double numeroMaximo, double numeroMinimo): base(mensaje)
        {
            this.Objeto = objeto;
            this.Mensaje = mensaje;
            this.PropiedadError = propiedadError;
            this.PropiedadValor = propiedadValor;
            this.Enteros = enteros;
            this.Decimales = decimales;
            this.NumeroMaximo = numeroMaximo;
            this.NumeroMinimo = numeroMinimo;
        }
        public Object Objeto { get; set; }
        public String Mensaje { get; set; }
        public String PropiedadError { get; set; }
        public String PropiedadValor { get; set; }
        public String AnotacionInvalida { get; set; }
        public int Enteros { get; set; }
        public int Decimales { get; set; }
        public double NumeroMaximo { get; set; }
        public double NumeroMinimo { get; set; }
    }
}


