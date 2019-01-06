using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas.Forms.ExcelElements
{
    public class ExcelArchivo
    {
        public List<ExcelHoja> Hojas { get; set; }
        public static ExcelArchivo ObtenerDataDeArchivoExcel(String ruta)
        {
            return Herramientas.Forms.ExcelAPI.ObtenerDataDeArchivoExcel(ruta);
        }
    }
}
