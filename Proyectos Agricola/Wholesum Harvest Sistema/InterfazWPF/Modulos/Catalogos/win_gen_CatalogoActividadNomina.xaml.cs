using Dominio;
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
using Dominio.Modulos.General;
using InterfazWPF.AdministracionSistema;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    /// <summary>
    /// Lógica de interacción para win_gen_CatalogoActividadNomina.xaml
    /// </summary>
    public partial class win_gen_CatalogoActividadNomina : Window, iCatalogo
    {
        ManejadorDB manejador = new ManejadorDB();
        _gen_ActividadNomina objetoActual;
        _gen_Formula formula;
        _gen_UnidadDeTiempo duracionTiempoUnidad;
        _gen_UnidadDeMedida unidadDeMedida;
        public win_gen_CatalogoActividadNomina()
        {
            InitializeComponent();
            ConfigurarBuscadores();

            txt_SalarioDiario.ValorDouble = Convert.ToDouble(HerramientasWindow.ObtenerValorVariable(manejador, "SALARIO_DIARIO"));
            //txt_SalarioDiario.SoloLectura = true;

            txt_CantidadUnidadMedida.txt_Algo.TextChanged += txt_Algo_TextChanged;
            txt_jornalesNecesarios.txt_Algo.TextChanged += txt_Algo_TextChanged;
            txt_SalarioDiario.TextChanged += txt_SalarioDiario_TextChanged;

            CalcularCostoPorUnidad();

            CargarDuracionDefault();


            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_materiales, "Material", "Material");
            HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_materiales, "Formula", "Formula");
            //HerramientasWindow.AgregarColumnaConBindingADataGridView(dgv_materiales, "Unidad", "Unidad");

        }

        void txt_SalarioDiario_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularCostoPorUnidad();
        }

        void txt_Algo_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularCostoPorUnidad();
        }
        private void CargarDuracionDefault()
        {
            duracionTiempoUnidad = manejador.Cargar<_gen_UnidadDeTiempo>(_gen_UnidadDeTiempo.ConsultaPor1Hora);
            txt_BuscadorUnidadDuracionDiaria.SetObjetoAsignado(duracionTiempoUnidad, duracionTiempoUnidad.St_Nombre);
            txt_TiempoDuracion.ValorDouble = 4;
        }
        private void ConfigurarBuscadores()
        {
            txt_Buscador.AsignarManejadorDB(manejador);
            txt_Buscador.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoActividadNomina");
            txt_Buscador.ConfigurarBusqueda(typeof(_gen_ActividadNomina), "_st_Nombre", "_st_Nombre", false, true);
            txt_Buscador.mostrarResultado += txt_Buscador_mostrarResultado;
            txt_Buscador.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de Actividad");
            txt_Buscador.AgregarCampoAMostrarConAlias("_in_idCrop|Código CROP");

            txt_BuscadorUnidadDuracionDiaria.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadDuracionDiaria.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadTiempo");
            txt_BuscadorUnidadDuracionDiaria.ConfigurarBusqueda(typeof(_gen_UnidadDeTiempo), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadDuracionDiaria.mostrarResultado += txt_BuscadorUnidadTiempoDuracion_mostrarResultado;
            txt_BuscadorUnidadDuracionDiaria.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de Unidad de Tiempo");

            txt_BuscadorFormula.AsignarManejadorDB(manejador);
            txt_BuscadorFormula.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoFormulas");
            txt_BuscadorFormula.ConfigurarBusqueda(typeof(_gen_Formula), "_st_Formula", "_st_Formula", false, true);
            txt_BuscadorFormula.mostrarResultado += txt_BuscadorFormula_mostrarResultado;
            txt_BuscadorFormula.AgregarCampoAMostrarConAlias("_st_Formula|Formula");

            txt_BuscadorUnidadMedida.AsignarManejadorDB(manejador);
            txt_BuscadorUnidadMedida.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoUnidadesMedida");
            txt_BuscadorUnidadMedida.ConfigurarBusqueda(typeof(_gen_UnidadDeMedida), "_st_Nombre", "_st_Nombre", false, true);
            txt_BuscadorUnidadMedida.mostrarResultado += txt_BuscadorUnidadMedida_mostrarResultado;
            txt_BuscadorUnidadMedida.AgregarCampoAMostrarConAlias("_st_Nombre|Nombre de Unidad de Medida");
            txt_BuscadorUnidadMedida.AgregarCampoAMostrarConAlias("_st_Clasificacion|Clasificación");

            txt_buscadorMaterialAsociado.AsignarManejadorDB(manejador);
            txt_buscadorMaterialAsociado.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoMateriales");
            txt_buscadorMaterialAsociado.ConfigurarBusqueda(typeof(_gen_Material), "_st_Descripcion", "_st_Descripcion", false, true);
            txt_buscadorMaterialAsociado.mostrarResultado += txt_buscadorMaterialAsociado_mostrarResultado;
            txt_buscadorMaterialAsociado.AgregarCampoAMostrarConAlias("_in_CodigoCrop|Código crop");
            txt_buscadorMaterialAsociado.AgregarCampoAMostrarConAlias("_st_Descripcion|Descripción material");
            txt_buscadorMaterialAsociado.AgregarCampoAMostrarConAlias("_st_DescripcionCorta|Descripción corta material");

            txt_buscadorFormulaMaterial.AsignarManejadorDB(manejador);
            txt_buscadorFormulaMaterial.AsignarCatalogoParaAltas("InterfazWPF.Modulos.Catalogos.win_gen_CatalogoFormulas");
            txt_buscadorFormulaMaterial.ConfigurarBusqueda(typeof(_gen_Formula), "_st_Formula", "_st_Formula", false, true);
            txt_buscadorFormulaMaterial.AgregarCampoAMostrarConAlias("_st_Formula|Formula");

        }
        void txt_buscadorMaterialAsociado_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                _gen_Material material = (_gen_Material)listaObjetos[0];
                txt_buscadorMaterialAsociado.SetObjetoAsignado(material, material.In_CodigoCrop + " - " + material.St_Descripcion);

            }
        }

        void txt_BuscadorFormula_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                formula = (_gen_Formula)listaObjetos[0];
                txt_BuscadorFormula.SetObjetoAsignado(formula, formula.St_Formula);
            }
        }

        void txt_BuscadorUnidadMedida_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                unidadDeMedida = (_gen_UnidadDeMedida)listaObjetos[0];
                txt_BuscadorUnidadMedida.SetObjetoAsignado(unidadDeMedida, unidadDeMedida.St_Nombre);
            }
        }

        void txt_BuscadorUnidadTiempoDuracion_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                duracionTiempoUnidad = (_gen_UnidadDeTiempo)listaObjetos[0];
                txt_BuscadorUnidadDuracionDiaria.SetObjetoAsignado(duracionTiempoUnidad, duracionTiempoUnidad.St_Nombre);
            }
        }
        void txt_Buscador_mostrarResultado(List<ObjetoBase> listaObjetos)
        {
            if (listaObjetos != null)
            {
                objetoActual = (_gen_ActividadNomina)listaObjetos[0];
                txt_Buscador.Limpiar();
                CargarObjeto();
            }
        }
        private void CargarObjeto()
        {
            txt_SalarioDiario.ValorDouble = Convert.ToDouble(HerramientasWindow.ObtenerValorVariable(manejador, "SALARIO_DIARIO"));
            Limpiar();
            if (objetoActual.Do_salarioDiarioRegistrado != 0)
                txt_SalarioDiario.ValorDouble = objetoActual.Do_salarioDiarioRegistrado;
            txt_nombre.Text = objetoActual.St_Nombre;
            txt_idCrop.Valor = objetoActual.In_idCrop;
            txt_jornalesNecesarios.Valor = objetoActual.In_jornalesNecesarios;
            duracionTiempoUnidad = objetoActual.Oo_unidadTiempoDuracion;
            txt_costoPorUnidad.ValorDouble = objetoActual.Do_CostoPorUnidad;
            if (objetoActual.Oo_unidadTiempoDuracion != null)
            {
                duracionTiempoUnidad = objetoActual.Oo_unidadTiempoDuracion;
                txt_BuscadorUnidadDuracionDiaria.SetObjetoAsignado(objetoActual.Oo_unidadTiempoDuracion, objetoActual.Oo_unidadTiempoDuracion.St_Nombre);
                txt_TiempoDuracion.ValorDouble = objetoActual.Do_duracion;
            }
            else
            {
                CargarDuracionDefault();
            }
            if (objetoActual.Oo_UnidadMedidaDeTarea != null)
            {
                unidadDeMedida = objetoActual.Oo_UnidadMedidaDeTarea;
                txt_BuscadorUnidadMedida.SetObjetoAsignado(objetoActual.Oo_UnidadMedidaDeTarea, objetoActual.Oo_UnidadMedidaDeTarea.St_Nombre);
            }
            txt_CantidadUnidadMedida.ValorDouble = objetoActual.Do_unidadesTarea;

            if (objetoActual.Oo_formulaCosto != null)
            {
                formula = objetoActual.Oo_formulaCosto;
                txt_BuscadorFormula.SetObjetoAsignado(objetoActual.Oo_formulaCosto, objetoActual.Oo_formulaCosto.St_Formula);
            }
            CalcularCostoPorUnidad();
            CargarMaterialesAsociados();
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
        private void GuardarObjetoSinLimpiar()
        {
            try
            {
                objetoActual.EsModificado = true;
                manejador.Guardar(objetoActual);
            }
            catch (Exception ex)
            {
                HerramientasWindow.MensajeError(ex, "Error: " + ex.Message, "Error");
            }
        }
        private void LimpiarMaterialesAsociados()
        {
            txt_buscadorFormulaMaterial.Limpiar();
            txt_buscadorMaterialAsociado.Limpiar();
            dgv_materiales.Items.Clear();
        }
        private void Limpiar()
        {
            txt_SalarioDiario.ValorDouble = Convert.ToDouble(HerramientasWindow.ObtenerValorVariable(manejador, "SALARIO_DIARIO"));
            txt_Buscador.Limpiar();
            txt_nombre.Text = "";
            duracionTiempoUnidad = null;
            formula = null;
            unidadDeMedida = null;
            txt_BuscadorFormula.Limpiar();
            txt_TiempoDuracion.ValorDouble = 0;
            txt_jornalesNecesarios.Valor = 0;
            txt_BuscadorUnidadDuracionDiaria.Limpiar();
            txt_CantidadUnidadMedida.ValorDouble = 0;
            txt_BuscadorUnidadMedida.Limpiar();
            txt_idCrop.Valor = 0;
            CargarDuracionDefault();
            LimpiarMaterialesAsociados();
        }
        private void CalcularCostoPorUnidad()
        {
            txt_costoPorUnidad.ValorDouble = Herramientas.Conversiones.Formatos.DoubleRedondearANDecimales((txt_SalarioDiario.ValorDouble * txt_jornalesNecesarios.Valor) / txt_CantidadUnidadMedida.ValorDouble, 2);
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
                objetoActual = manejador.CrearObjeto<_gen_ActividadNomina>();
            objetoActual.Do_unidadesTarea = txt_CantidadUnidadMedida.ValorDouble;
            objetoActual.Oo_UnidadMedidaDeTarea = unidadDeMedida;
            objetoActual.Do_salarioDiarioRegistrado = txt_SalarioDiario.ValorDouble;
            objetoActual.Do_duracion = txt_TiempoDuracion.ValorDouble;
            objetoActual.Oo_unidadTiempoDuracion = duracionTiempoUnidad;
            objetoActual.In_jornalesNecesarios = txt_jornalesNecesarios.Valor;
            objetoActual.Do_CostoPorUnidad = txt_costoPorUnidad.ValorDouble;
            objetoActual.Oo_formulaCosto = formula;
            objetoActual.St_Nombre = txt_nombre.Text;
            objetoActual.In_idCrop = txt_idCrop.Valor;
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
        _gen_ConfMatActividadNom configuracionTemporal;
        private void CargarMaterialesAsociados()
        {
            LimpiarMaterialesAsociados();
            if (objetoActual != null && objetoActual.Ll_MaterialesUsados != null)
            {
                foreach (_gen_ConfMatActividadNom confi in objetoActual.Ll_MaterialesUsados)
                {
                    ModeloMateriales modelo = new ModeloMateriales();
                    modelo.Material = confi.Oo_MaterialAUsar.In_CodigoCrop + " - " + confi.Oo_MaterialAUsar.St_Descripcion;
                    if (confi.Oo_FormulaCalculoMaterial != null)
                        modelo.Formula = confi.Oo_FormulaCalculoMaterial.St_Formula;
                    dgv_materiales.Items.Add(modelo);
                }
            }
        }


        public void AsignarObjetoDominio(ObjetoBase objeto)
        {
            objetoActual = (_gen_ActividadNomina)objeto;
            CargarObjeto();
        }

        private void btn_quitar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int n = dgv_materiales.SelectedIndex;
            if (n >= 0)
            {
                objetoActual.Ll_MaterialesUsados.RemoveAt(n);
                LimpiarMaterialesAsociados();
                configuracionTemporal.BorrarObjetoPermanentemente();
                CargarMaterialesAsociados();
                //LimpiarMaterialesAsociados();
                configuracionTemporal = null;
            }
        }

        private void btn_guardar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (configuracionTemporal == null) configuracionTemporal = new _gen_ConfMatActividadNom();
            configuracionTemporal.Oo_MaterialAUsar = (_gen_Material)txt_buscadorMaterialAsociado.GetObjetoAsignado();
            configuracionTemporal.Oo_FormulaCalculoMaterial = (_gen_Formula)txt_buscadorFormulaMaterial.GetObjetoAsignado<_gen_Formula>();

            if (objetoActual.Ll_MaterialesUsados == null) objetoActual.Ll_MaterialesUsados = new List<_gen_ConfMatActividadNom>();

            if (configuracionTemporal.Id == 0)
                objetoActual.Ll_MaterialesUsados.Add(configuracionTemporal);
            configuracionTemporal.EsModificado = true;
            GuardarObjetoSinLimpiar();

            CargarMaterialesAsociados();
            configuracionTemporal = null;

        }
        private void CargarConfiguracionMaterial()
        {
            if (configuracionTemporal != null)
            {
                if (configuracionTemporal.Oo_FormulaCalculoMaterial != null)
                    txt_buscadorFormulaMaterial.SetObjetoAsignado(configuracionTemporal.Oo_FormulaCalculoMaterial, configuracionTemporal.Oo_FormulaCalculoMaterial.St_Formula);
                else
                    txt_buscadorFormulaMaterial.Limpiar();
                txt_buscadorMaterialAsociado.SetObjetoAsignado(configuracionTemporal.Oo_MaterialAUsar, configuracionTemporal.Oo_MaterialAUsar.In_CodigoCrop + " - " + configuracionTemporal.Oo_MaterialAUsar.St_Descripcion);

            }
        }
        private void dgv_materiales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int n = dgv_materiales.SelectedIndex;
            if (n >= 0)
            {
                configuracionTemporal = objetoActual.Ll_MaterialesUsados[n];
                CargarConfiguracionMaterial();
                //CargarMaterialesAsociados();
            }
        }
    }
    class ModeloMateriales
    {
        public String Material { get; set; }
        public String Formula { get; set; }
    }
}
