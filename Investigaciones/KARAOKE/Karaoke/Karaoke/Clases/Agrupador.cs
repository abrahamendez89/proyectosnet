using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Karaoke.Clases
{
    public class Agrupador
    {
        public int Codigo { get; set; }
        public String NombreAgrupador { get; set; }
        public ImageSource Imagen { get; set; }
        public String ImagenTexto { get; set; }
        public List<ElementoMultimedia> ElementosMultimedia { get; set; }
        public List<Agrupador> AgrupadoresHijos { get; set; }
        public Agrupador AgrupadorPadre { get; set; }

        public Agrupador Siguiente { get; set; }
        public Agrupador Anterior { get; set; }
    }
}
