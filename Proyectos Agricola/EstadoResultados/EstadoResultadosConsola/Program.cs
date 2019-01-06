using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstadoResultados;
using System.Threading;
using Herramientas.Archivos;
using Herramientas.SQL;
namespace EstadoResultadosConsola
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Variable varConn = new Variable("conn");


            String servidorCrop = varConn.ObtenerValorVariable<String>("servidorCrop");
            String BaseDatos = varConn.ObtenerValorVariable<String>("baseDatos");
            String usuario = varConn.ObtenerValorVariable<String>("usuarioCrop");
            String contra = varConn.ObtenerValorVariable<String>("ContraseñaCrop");
            new DBAcceso(servidorCrop, BaseDatos, usuario, contra);

            EjecutarServicioEstadoResultados ej = new EjecutarServicioEstadoResultados();
            ej.mostrarMensaje += ej_mostrarMensaje;
            ej.mostrarPorcentaje += ej_mostrarPorcentaje;
            ej.terminoProceso += ej_terminoProceso;

            ej.IniciarProceso();
            
        }

        static void ej_terminoProceso()
        {
            
        }

        static void ej_mostrarPorcentaje(double porcentaje)
        {
            Console.WriteLine(porcentaje.ToString());
        }

        static void ej_mostrarMensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
