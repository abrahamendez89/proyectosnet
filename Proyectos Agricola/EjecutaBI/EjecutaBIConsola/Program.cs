using Herramientas.Forms;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Herramientas.Forms.ExcelElements;

namespace EjecutaBIConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            EjecutaProceso ejecuta = new EjecutaProceso();
            ejecuta.IniciarMonitoreo();

            //ExcelArchivo ex = Herramientas.Forms.ExcelAPI.ObtenerDataDeArchivoExcel(@"D:\Proyectos\EjecutaBI\EjecutaBIConsola\bin\Debug\ARCHIVOS\Layaout_Bonos_Warehouse.xlsx");

            //ISQL sql = new Firebird();

            //sql.CrearEInsertarArchivoDataExcel(ex);

        }
    }
}
