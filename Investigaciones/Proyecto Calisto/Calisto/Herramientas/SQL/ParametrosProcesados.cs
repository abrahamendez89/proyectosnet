using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas.SQL
{
    public class ParametrosProcesados
    {
        public String Consulta { get; set; }
        public List<String> ParametrosIdentificadores { get; set; }
        public List<Object> ValoresProcesados { get; set; }
    }
}
