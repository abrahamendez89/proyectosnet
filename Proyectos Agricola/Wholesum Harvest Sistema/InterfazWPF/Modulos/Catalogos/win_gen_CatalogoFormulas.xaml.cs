using Dominio;
using Dominio.Modulos.General;
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
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_gen_CatalogoFormulas.xaml
    /// </summary>
    public partial class win_gen_CatalogoFormulas : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _gen_Formula objetoActual;
        public static List<String> Variables { get; set; }
        public win_gen_CatalogoFormulas()
        {
            InitializeComponent();

            lb_constantes.Items.Add("@long_cama");
            lb_constantes.Items.Add("@area_cama");
            lb_constantes.Items.Add("@metros_desague");
            lb_constantes.Items.Add("@metros_perimetro");
            lb_constantes.Items.Add("@no_ha");
            lb_constantes.Items.Add("@separacion_camas");
            lb_constantes.Items.Add("@no_camas");
            lb_constantes.Items.Add("@no_caidas");
            lb_constantes.Items.Add("@no_casetas");
            lb_constantes.Items.Add("@no_perifericas");
            lb_constantes.Items.Add("@dias_totales");
            lb_constantes.Items.Add("@unidades_corte");
            lb_constantes.Items.Add("@unidades_empaque");
            lb_constantes.Items.Add("@densidad_planteo");
            lb_constantes.Items.Add("@porcentaje_semilla_adicional");
            lb_constantes.Items.Add("@ha_totales_cult_tec");

            if (Variables == null) Variables = new List<string>();
            foreach (String item in lb_constantes.Items)
                Variables.Add(item);

            ConfigurarBuscadores();

            lb_constantes.MouseDoubleClick += lb_constantes_MouseDoubleClick;

        }

        void lb_constantes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lb_constantes.SelectedItem != null)
            {
                AgregarVariableSeleccionada();
            }
        }
        private void ConfigurarBuscadores()
        {
            txt_BuscadorFormula.AsignarManejadorDB(manejador);
            txt_BuscadorFormula.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoFormulas");
            txt_BuscadorFormula.ConfigurarBusqueda(typeof(_gen_Formula), "_st_Formula", "_st_Formula", false, true);
            txt_BuscadorFormula.mostrarResultado += txt_BuscadorFormula_mostrarResultado;
            txt_BuscadorFormula.AgregarCampoAMostrarConAlias("_st_Formula|Formula");

        }
        void txt_BuscadorFormula_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_Formula)listaObjetos[0];
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_formula.Text = objetoActual.St_Formula;
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
            txt_BuscadorFormula.Limpiar();
            txt_formula.Text = "";
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
                objetoActual = manejador.CrearObjeto<_gen_Formula>();


            objetoActual.St_Formula = txt_formula.Text;
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
        private void btn_agregar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lb_constantes.SelectedIndex >= 0)
            {
                AgregarVariableSeleccionada();
            }
        }

        private void AgregarVariableSeleccionada()
        {
            String constante = lb_constantes.SelectedItem.ToString();

            int posicion = txt_formula.txt_Algo.SelectionStart;

            String texto = txt_formula.Text;

            texto = texto.Insert(posicion, constante + " ");
            txt_formula.Text = texto;
            txt_formula.txt_Algo.SelectionStart = posicion + texto.Length + 1;
        }

        private void btn_simbolo(object sender, MouseButtonEventArgs e)
        {
            Boton boton = (Boton)sender;
            int posicion = txt_formula.txt_Algo.SelectionStart;

            String texto = txt_formula.Text;

            texto = texto.Insert(posicion, boton.Text + " ");
            txt_formula.Text = texto;
            txt_formula.txt_Algo.SelectionStart = posicion + boton.Text.Length + 1;
        }


        public void AsignarObjetoDominio(ObjetoBase objeto)
        {
            objetoActual = (_gen_Formula)objeto;
            CargarObjeto();
        }
    }
}
