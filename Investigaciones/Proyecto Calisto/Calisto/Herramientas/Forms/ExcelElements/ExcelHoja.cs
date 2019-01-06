using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas.Forms.ExcelElements
{
    public class ExcelHoja
    {
        public String NombreHoja { get; set; }
        public List<String> NombresColumnas { get; set; }
        public List<ExcelFila> ExcelFilasDatos { get; set; }
    }
}
