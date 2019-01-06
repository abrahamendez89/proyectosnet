using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karaoke.Clases
{
    public class ElementoMultimedia
    {

        public enum TipoElementoMultimedia
	    {
	        Karaoke = 0,
            Musica = 1,
            Video = 2,
            YouTube = 3,
            Calificador
	    }
        public int Codigo { get; set; }
        public TipoElementoMultimedia TipoElemento { get; set; }
        public String Titulo { get; set; }
        public String URL { get; set; }
        public Agrupador AgrupadorContiene { get; set; }
        public int SegundosDuracion { get; set; }
        //public Boolean Descargado { get; set; }
        //public Double ProgresoDescargado { get; set; }
        //public Boolean CancelarDescarga { get; set; }
    }
}
