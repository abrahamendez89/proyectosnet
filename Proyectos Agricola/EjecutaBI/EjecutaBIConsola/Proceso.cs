using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjecutaBIConsola
{
    public class Proceso
    {
        public enum Tipo
        {
            EsExcel = 0,
            EsScript = 1
        }
        public enum Servidor
        {
            SQLServer = 0,
            Firebird = 1
        }
        public String Nombre { get; set; }
        public Tipo TipoEjecucion { get; set; }
        public Servidor TipoServidor { get; set; }
        public String Ruta { get; set; }
        public int Hora { get; set; }
        public int Minuto { get; set; }
        public Boolean EstaActivo { get; set; }
        public Boolean SeEstaEjecutando { get; set; }
    }
}
