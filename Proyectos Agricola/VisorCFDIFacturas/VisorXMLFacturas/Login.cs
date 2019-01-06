using Dominio;
using Herramientas.Archivos;
using Herramientas.ORM;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisorXMLFacturas
{
    public partial class Login : Form
    {
        Variable var;
        ManejadorDB manejador;
        iSQL sql;
        public Login()
        {
            InitializeComponent();

            try
            {
                SQLite sql = new SQLite();
                sql.ConfigurarConexion("DATA.db", false);
                manejador = new ManejadorDB(sql);
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Error: " + ex.Message);
            }

            String documentos = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            var = new Variable(documentos+"\\dataTemp.dat");
            txt_usuario.Text = var.ObtenerValorVariable<String>("UltimoLogin");
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            _Usuario usuario = manejador.Cargar<_Usuario>("select * from _Usuario where _Cuenta = @_Cuenta and _Contrasena = @_Contrasena", new List<object>() { txt_usuario.Text, txt_contrasena.Text});

            if (usuario != null)
            {
                if (usuario.PrimeraVezLogin)
                {
                    CambioContrasena cam = new CambioContrasena();
                    cam.ShowDialog();

                    if (cam.ContrasenaNueva != null && !cam.ContrasenaNueva.Equals(""))
                    {
                        try
                        {
                            usuario.EsModificado = true;
                            usuario.Contrasena = cam.ContrasenaNueva;
                            usuario.PrimeraVezLogin = false;
                            manejador.Guardar(usuario);
                        }

                        catch
                        {
                            Herramientas.Forms.Mensajes.Error("Ocurrió un error al cambiar la contraseña.");
                        }
                    }
                    cam.Close();
                }

                VisorXMLCFDI visor = new VisorXMLCFDI(usuario.NombreCompleto);
                visor.Responsable = usuario.NombreCompleto;
                Hide();
                visor.ShowDialog();




                var.GuardarValorVariable("UltimoLogin", txt_usuario.Text.Trim());
                var.ActualizarArchivo();

                Close();
            }
            else
            {
                Herramientas.Forms.Mensajes.Exclamacion("Usuario o contraseña incorrectos.");
            }

            
        }
    }
}
