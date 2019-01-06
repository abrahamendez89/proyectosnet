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
    /// Lógica de interacción para win_gen_CatalogoMateriales.xaml
    /// </summary>
    public partial class win_gen_CatalogoMateriales : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _gen_Material objetoActual;
        _gen_UnidadDeMedida unidadDeMedida;
        public win_gen_CatalogoMateriales()
        {
            InitializeComponent();
            ConfigurarBuscadores();
        }

        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoMateriales");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_Material), "_st_Descripcion", "_st_Descripcion", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_Descripcion|Descripción de Material");
            txt_Buscador.AgregarCampoAMostrarConAlias("_in_CodigoCrop|Código CROP");

            txt_BuscadorUnidadMedida.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadMedida.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadesMedida");
            txt_BuscadorUnidadMedida.ConfigurarBusqueda(typeof(_gen_UnidadDeMedida), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadMedida.mostrarResultado += txt_BuscadorUnidadMedida_mostrarResultado;
            txt_BuscadorUnidadMedida.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de Unidad de Medida");
            txt_BuscadorUnidadMedida.AgregarCampoAMostrarConAlias("_st_Clasificacion|Clasificación");
            
            txt_BuscadorMaterialDefault.AsignarManejadorDB(manejador);
            txt_BuscadorMaterialDefault.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoMateriales");
            txt_BuscadorMaterialDefault.ConfigurarBusqueda(typeof(_gen_Material), "_st_Descripcion", "_st_Descripcion", false, true);
            txt_BuscadorMaterialDefault.mostrarResultado += txt_BuscadorMaterialDefault_mostrarResultado;
            txt_BuscadorMaterialDefault.AgregarCampoAMostrarConAlias("_st_Descripcion|Descripción de Material");
            txt_BuscadorMaterialDefault.AgregarCampoAMostrarConAlias("_in_CodigoCrop|Código CROP");
        }

        void txt_BuscadorMaterialDefault_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                _gen_Material material = (_gen_Material)listaObjetos[0];
                txt_BuscadorMaterialDefault.SetObjetoAsignado(material, material.In_CodigoCrop + " - " + material.St_Descripcion);
            }
        }

        void txt_BuscadorUnidadMedida_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                unidadDeMedida = (_gen_UnidadDeMedida)listaObjetos[0];
            }
        }

        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_Material)listaObjetos[0];
                txt_Buscador.Limpiar();
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_descripcion.Text = objetoActual.St_Descripcion;
            txt_descripcionCorta.Text = objetoActual.St_DescripcionCorta;
            txt_codigoCrop.Valor = objetoActual.In_CodigoCrop;
            if (objetoActual.Oo_MaterialEspecifico != null)
                txt_BuscadorMaterialDefault.SetObjetoAsignado(objetoActual.Oo_MaterialEspecifico, objetoActual.Oo_MaterialEspecifico.In_CodigoCrop + " - " + objetoActual.Oo_MaterialEspecifico.St_Descripcion);

            chb_EsMaterialVariable.IsChecked = objetoActual.Bo_EsMaterialVariable;
            txt_cantidadUnidad.ValorDouble = objetoActual.Do_UnidadMedidaMinimo;
            txt_precioUnitario.ValorDouble = objetoActual.Do_PrecioUnitario;

            if (objetoActual.Oo_UnidadMedida != null)
            {
                txt_BuscadorUnidadMedida.SetObjetoAsignado(objetoActual.Oo_UnidadMedida, objetoActual.Oo_UnidadMedida.St_Nombre);
            }
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
            txt_Buscador.Limpiar();
            unidadDeMedida = null;
            txt_codigoCrop.Text = "";
            txt_descripcionCorta.Text = "";
            txt_descripcion.Text = "";
            txt_cantidadUnidad.ValorDouble = 0;
            txt_precioUnitario.ValorDouble = 0;
            txt_BuscadorUnidadMedida.Limpiar();
            txt_BuscadorMaterialDefault.Limpiar();
            chb_EsMaterialVariable.IsChecked = false;
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
                objetoActual = manejador.CrearObjeto<_gen_Material>();
            objetoActual.In_CodigoCrop = txt_codigoCrop.Valor;
            objetoActual.St_Descripcion = txt_descripcion.Text;
            objetoActual.St_DescripcionCorta = txt_descripcionCorta.Text;
            objetoActual.Do_UnidadMedidaMinimo = txt_cantidadUnidad.ValorDouble;
            objetoActual.Oo_UnidadMedida = (_gen_UnidadDeMedida)txt_BuscadorUnidadMedida.GetObjetoAsignado();
            objetoActual.Oo_MaterialEspecifico = (_gen_Material)txt_BuscadorMaterialDefault.GetObjetoAsignado();
            objetoActual.Bo_EsMaterialVariable = (Boolean)chb_EsMaterialVariable.IsChecked;
            objetoActual.Do_PrecioUnitario = txt_precioUnitario.ValorDouble;
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


        public void AsignarObjetoDominio(ObjetoBase objeto)
        {
            objetoActual = (_gen_Material)objeto;
            CargarObjeto();
        }
    }
}
