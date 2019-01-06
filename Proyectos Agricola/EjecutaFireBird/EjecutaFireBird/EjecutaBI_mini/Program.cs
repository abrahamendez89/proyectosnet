using Herramientas.Archivos;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EjecutaBI_mini
{
    class Program
    {
        public static void Main(string[] args)
        {
            String Emails = "";
            try
            {
                Variable var = new Variable("parametros.ini");
                String Usuario = var.ObtenerValorVariable<String>("USUARIO");
                String Contra = var.ObtenerValorVariable<String>("CONTRASEÑA");
                String BaseDatos = var.ObtenerValorVariable<String>("BASE_DATOS");
                String Server = var.ObtenerValorVariable<String>("SERVER");
                String Query = var.ObtenerValorVariable<String>("QUERY");
                Emails = var.ObtenerValorVariable<String>("EMAILS");


                var.GuardarValorVariable("USUARIO", Usuario);
                var.GuardarValorVariable("CONTRASEÑA", Contra);
                var.GuardarValorVariable("BASE_DATOS", BaseDatos);
                var.GuardarValorVariable("SERVER", Server);
                var.GuardarValorVariable("QUERY", Query);
                var.GuardarValorVariable("EMAILS", Emails);

                var.ActualizarArchivo();


                Firebird sql = new Firebird();

                sql.ConfigurarConexion(Server, BaseDatos, Usuario, Contra);

                sql.EjecutarConsulta(Query);
                String mensaje = "Terminó la ejecución de la consulta.";
                Console.WriteLine(mensaje);
                if (!Emails.Equals(""))
                    Herramientas.Mail.EmailFormatos.EnviarMailInformacion(mensaje, "EjecutaBI_mini", Emails, null);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (!Emails.Equals(""))
                    Herramientas.Mail.EmailFormatos.EnviarMailError(ex.Message, "EjecutaBI_mini", ex.StackTrace, ex, Emails, null);
            }

        }
    }
}
