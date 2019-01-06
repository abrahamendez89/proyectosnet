using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Karaoke.Clases
{
    public class ElementoListaReproduccion
    {
        public ElementoMultimedia elemento { get; set; }
        public String Ruta { get; set; }
        public ImageSource Imagen { get; set; }
        public String ImagenRuta { get; set; }
        public int NumeroPista { get; set; }
        
    }
}
