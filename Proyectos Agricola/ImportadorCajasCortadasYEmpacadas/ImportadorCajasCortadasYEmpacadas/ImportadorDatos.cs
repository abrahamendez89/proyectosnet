using Herramientas.Archivos;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImportadorCajasCortadasYEmpacadas
{
    public partial class ImportadorDatos : Form
    {
        Variable variable;

        Access access;

        public ImportadorDatos()
        {
            InitializeComponent();
            variable = new Variable("cache.txt");
            this.FormClosing += ImportadorDatos_FormClosing;
            txt_ruta.Text = variable.ObtenerValorVariable<String>("ArchivoAccess");
            txt_query.Text = variable.ObtenerValorVariable<String>("Query");

            access = new Access();
            
        }

        void ImportadorDatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            String query = txt_query.Text.Replace("\r\n", " ");
            variable.GuardarValorVariable("Query", query);
            variable.GuardarValorVariable("ArchivoAccess", txt_ruta.Text.Trim());
            variable.ActualizarArchivo();
        }
        
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            String archivo = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "BD de Access" }, new List<string>() { "accdb" });
            if (archivo != null)
            {
                txt_ruta.Text = archivo;
                access.ConfigurarConexion(null, txt_ruta.Text.Trim());
            }
        }
        DataTable dtResultado;
        private void btn_consultar_Click(object sender, EventArgs e)
        {
            String query = txt_query.Text.Trim();
            if (query.Equals(""))
            {
                Herramientas.Forms.Mensajes.Informacion("Se requiere de un query!");
                return;
            }
            if (txt_ruta.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Informacion("Se requiere de un archivo de access!");
                return;
            }
            try
            {
                access.ConfigurarConexion(null, txt_ruta.Text.Trim());
                access.AbrirConexion();
                dtResultado = access.EjecutarConsulta(query);
                dgv_resultados.DataSource = dtResultado;
                access.CerrarConexion();
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }

        private void btn_EnviarAExcel_Click(object sender, EventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de Excel" }, new List<string>() { "xls" }, "Cajas proyectadas " + Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now)+".xls");

            if (ruta != null)
            {
                try
                {

                    Herramientas.Forms.ExcelAPI excel = new Herramientas.Forms.ExcelAPI();
                    excel.terminoConversion += excel_terminoConversion;
                    excel.ConvertirDataTableAExcel(ruta, dtResultado);
                }
                catch(Exception ex)
                {
                    Herramientas.Forms.Mensajes.Error("Error al convertir el archivo: "+ex.Message);
                }
            }
        }

        void excel_terminoConversion(string rutaGuardado)
        {
            Herramientas.Forms.Mensajes.Informacion("Archivo guardado con éxito.");
        }

    }
}
