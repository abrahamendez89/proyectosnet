using Dominio;
using Dominio.Modulos.ProgramaSiembra;
using InterfazWPF.AdministracionSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InterfazWPF.Modulos.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using System.Xml.Serialization;
using System.IO;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_ps_CatalogoSubstratos.xaml
    /// </summary>
    public partial class win_ps_CatalogoSubstratos : Window, iCatalogo
    {
         ManejadorDB manejador = new ManejadorDB();
        _ps_Substrato objetoActual;
        public win_ps_CatalogoSubstratos()
        {
            InitializeComponent();
            //txt_BuscadorCubierta.ConfigurarControl(manejador, typeof(_ps_Substrato), "id", typeof(long), "_st_NombreSubstrato", false, true);
            //txt_BuscadorCubierta.mostrarResultado += txt_Buscador_mostrarResultado;
            //txt_BuscadorCubierta.AgregarCampoConAliasAMostrar("_st_NombreSubstrato|Nombre del Substrato");
        }

        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_ps_Substrato)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_CubiertaDescripcion.Text = objetoActual.St_NombreSubstrato;

        }
        private void GuardarObjeto()
        {
            try
            {
                objetoActual.EsModificado = true;
                manejador.Guardar(objetoActual);
                objetoActual = null;
                Limpiar();
                HerramientasWindow.MensajeInformacion("Se ha guardado correctamente el objeto.", "Guardado exitoso");
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
            }
        }
        private void Limpiar()
        {
            txt_CubiertaDescripcion.Text = "";
        }
        public void _toolbox_Guardar()
        {
            if (objetoActual != null)
            {
                if (!HerramientasWindow.MensajeSIoNOAdvertencia("El objeto actual reemplazará al objeto anterior, ¿Desea continuar?", "Atención"))
                {
                    return;
                }
            }
            else
                objetoActual = manejador.CrearObjeto < _ps_Substrato>();

            objetoActual.St_NombreSubstrato = txt_CubiertaDescripcion.Text;
            objetoActual.EstaDeshabilitado = false;
            GuardarObjeto();
        }
        public void _toolbox_Deshabilitar()
        {
            if (objetoActual == null) return;
            objetoActual.EstaDeshabilitado = true;
            GuardarObjeto();
        }
        public void _toolbox_Nuevo()
        {
            objetoActual = null;
            Limpiar();
        }

        private void Boton_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            rpt_test1 rpt = new rpt_test1();
            //rpt.SetParameterValue("_sCuenta", HerramientasWindow.ObtenerUsuarioLogueado().Cuenta);
            //rpt.SetParameterValue("_sContrasena", HerramientasWindow.ObtenerUsuarioLogueado().Contrasena);
            List<Dominio.Sistema._sis_Usuario> usuarios = manejador.CargarLista<Dominio.Sistema._sis_Usuario>(Dominio.Sistema._sis_Usuario.consultaTodos);

            ReportDocument rdocu = new ReportDocument();
            //rdocu.

            //rpt.SetDataSource(manejador.EjecutarConsulta(Dominio.Sistema._sis_Usuario.consultaTodos));

            //foreach (Dominio.Sistema._sis_Usuario usuario in usuarios)
            //{
            //    (rpt.Section2.ReportObjects[0] as TextObject).Text = usuario.Cuenta;
            //    (rpt.Section2.ReportObjects[1] as TextObject).Text = usuario.Contrasena;

            //}

            
            VisorReporte vr = new VisorReporte(rpt);
            vr.ShowDialog();
        }


        public void AsignarObjetoDominio(ObjetoBase objeto)
        {
            objetoActual = (_ps_Substrato)objeto;
            CargarObjeto();
        }
    }
}
