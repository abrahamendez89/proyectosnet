using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorEntidades.Modelo
{
    public class propiedad_base
    {
        public string columna { get; set; }
        public string tipo { get; set; }
        public int longitud { get; set; }
        public int precision { get; set; }
        public int decimales { get; set; }
        public bool nullable { get; set; }
    }
}
