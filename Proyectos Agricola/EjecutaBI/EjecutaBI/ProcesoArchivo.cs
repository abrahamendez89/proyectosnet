using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace EjecutaBI
{
    public class ProcesoArchivo
    {
        public String [] ContenidoEjecucion { get; set; }
        public int PasoActual { get; set; }
        public String RutaArchivo { get; set; }
        public String NombreArchivo { get; set; }
        public Thread HiloProceso { get; set; }
        public List<String> LOG { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public DateTime FechaError { get; set; }
        public String HoraEjecucion { get; set; }
        public String  NombreProceso { get; set; }
        public String TipoServidor { get; set; }
        public String EstaAgendado { get; set; }
        public Boolean EstaEjecutandose { get; set; }
        public ListBox ListBoxControl { get; set; }
        public int PasosTotales { get; set; }
        public ISQLManager SqlManager { get; set; }
        public int PorcentajeCompletado { get; set; }
        public String [] Resultados { get; set; }

        public void AgregarLog(String mensaje)
        {
            LOG.Add(mensaje);
            ListBoxControl.Items.Add(mensaje);
        }

        public void AgregarALogEnPosicion(int posicion, String agregado)
        {
            LOG[posicion] += agregado;
            ListBoxControl.Items[posicion] += agregado;
        }
    }
}
