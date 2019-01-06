using Herramientas.Archivos;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EstadoResultados
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Variable varConn = new Variable("conn");


            String servidorCrop = varConn.ObtenerValorVariable<String>("servidorCrop");
            String BaseDatos = varConn.ObtenerValorVariable<String>("baseDatos");
            String usuario = varConn.ObtenerValorVariable<String>("usuarioCrop");
            String contra = varConn.ObtenerValorVariable<String>("ContraseñaCrop");
            new DBAcceso(servidorCrop, BaseDatos, usuario, contra);

            Application.Run(new Principal());
        }
    }
}
