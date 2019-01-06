using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControlsSIZ.Contables
{
    /// <summary>
    /// Interaction logic for SIZUCContabilizacion.xaml
    /// </summary>
    public partial class SIZUCContabilizacion : UserControl, INotifyPropertyChanged
    {
        //eventos
        public delegate String _SIZUC_BuscarVariableContable(SIZUCContabilizacion objeto);
        public event _SIZUC_BuscarVariableContable SIZUC_BuscarVariableContable;
        public delegate String _SIZUC_BuscarCuentaContable(SIZUCContabilizacion objeto);
        public event _SIZUC_BuscarCuentaContable SIZUC_BuscarCuentaContable;
        public event PropertyChangedEventHandler PropertyChanged;

        Boolean esPosibleAgregarCuenta = false;

        int numeroControles;

        int caracteresOcupados;
        int caracteresTotales;

        public SIZUCContabilizacion()
        {
            InitializeComponent();

            btnAgregarModuloCuenta.MouseUp += BtnAgregarModuloCuenta_MouseUp;
            btnAgregarModuloVariable.MouseUp += BtnAgregarModuloVariable_MouseUp;

            Loaded += SIZUCContabilizacion_Loaded;

        }

        private void SIZUCContabilizacion_Loaded(object sender, RoutedEventArgs e)
        {
            CalculaMascaraCuenta(MascaraContable);
            MascaraCuentaContable = MascaraContable;
        }

        private static String MascaraContable;
        public static void SetMascaraContable(String mascara)
        {
            MascaraContable = mascara;
        }

        private void BtnAgregarModuloVariable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (numeroControles == NivelesCuentaContable.Count)
                return;

            foreach (Control ctrl in stpModulos.Children)
            {
                if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaCuenta) && ((SIZUCContabilizacionCapturaCuenta)ctrl).CuentaContable.Length == 0)
                    return;
            }
            esPosibleAgregarCuenta = true;
            EsSetGrafico = true;
            AgregarCapturaVariable(null, 0, 0);

            ArmarExpresion();
            EsSetGrafico = false;
        }

        private void AgregarCapturaVariable(String valorStr, int rangoInferior, int caracteres)
        {
            SIZUCContabilizacionCapturaVariable variable = new SIZUCContabilizacionCapturaVariable();
            variable.SIZUC_BuscarVariableContable += Variable_SIZUC_BuscarVariableContable;
            variable.SIZUC_EliminarElemento += Variable_SIZUC_EliminarElemento;
            variable.SIZUC_Actualizar += SIZUC_Actualizar;
            if (stpModulos.Children.Count > 0)
            {
                SIZUCContabilizacionCapturaSeparador separador = new SIZUCContabilizacionCapturaSeparador();
                variable.Separador = separador;
                stpModulos.Children.Add(separador);
            }

            if (valorStr != null)
            {
                variable.Variable = valorStr;
                variable.txtCapturaRangoInferior.Text = rangoInferior.ToString();
                variable.txtCapturaRangoSuperior.Text = caracteres.ToString();
            }
            if (EsSetGrafico)
                variable.Longitud = NivelesCuentaContable[numeroControles];
            else
                variable.Longitud = caracteres;

            stpModulos.Children.Add(variable);
            numeroControles++;
            ActualizarElimninarControles();

        }

        private void ActualizarElimninarControles()
        {
            foreach (Control ctr in stpModulos.Children)
            {
                if (ctr.GetType() == typeof(SIZUCContabilizacionCapturaCuenta))
                {
                    ((SIZUCContabilizacionCapturaCuenta)ctr).BotonEliminarVisible = false;
                }
                else if (ctr.GetType() == typeof(SIZUCContabilizacionCapturaVariable))
                {
                    ((SIZUCContabilizacionCapturaVariable)ctr).BotonEliminarVisible = false;
                }
            }

            if (stpModulos.Children.Count > 0)
            {
                var ctrl = stpModulos.Children[stpModulos.Children.Count - 1];
                if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaCuenta))
                {
                    ((SIZUCContabilizacionCapturaCuenta)ctrl).BotonEliminarVisible = true;
                }
                else if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaVariable))
                {
                    ((SIZUCContabilizacionCapturaVariable)ctrl).BotonEliminarVisible = true;
                }
            }

            if (stpModulos.Children.Count == 0)
                esPosibleAgregarCuenta = true;

            ArmarExpresion();

        }

        private void SIZUC_Actualizar()
        {
            EsSetGrafico = true;
            ArmarExpresion();
            EsSetGrafico = false;
        }

        private void Variable_SIZUC_EliminarElemento(SIZUCContabilizacionCapturaVariable objeto)
        {
            if (stpModulos.Children.IndexOf(objeto) == stpModulos.Children.Count - 1)
            {
                stpModulos.Children.Remove(objeto);
                stpModulos.Children.Remove(objeto.Separador);
                numeroControles--;
                EsSetGrafico = true;
                ActualizarElimninarControles();
                EsSetGrafico = false;
            }

        }
        SIZUCContabilizacionCapturaVariable objVariable;
        SIZUCContabilizacionCapturaCuenta objCuenta;
        private string Variable_SIZUC_BuscarVariableContable(SIZUCContabilizacionCapturaVariable objeto)
        {
            String variableContable = "Seleccione";
            if (SIZUC_BuscarVariableContable != null)
            {
                variableContable = SIZUC_BuscarVariableContable(this);
            }
            this.objVariable = objeto;
            EsSetGrafico = true;
            ArmarExpresion();
            EsSetGrafico = false;
            return variableContable;
        }

        private void BtnAgregarModuloCuenta_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (stpModulos.Children.Count == 0)
            {
                esPosibleAgregarCuenta = false;
                numeroControles = 0;
            }
            if (numeroControles == NivelesCuentaContable.Count)
                return;

            if (esPosibleAgregarCuenta)
                return;
            esPosibleAgregarCuenta = true;
            EsSetGrafico = true;
            AgregarCapturaCuenta(null);
            ArmarExpresion();
            EsSetGrafico = false;
        }

        private void AgregarCapturaCuenta(String cuentaStr)
        {
            SIZUCContabilizacionCapturaCuenta cuenta = new SIZUCContabilizacionCapturaCuenta();
            cuenta.SIZUC_BuscarCuentaContable += Cuenta_SIZUC_BuscarCuentaContable;
            cuenta.SIZUC_EliminarElemento += Cuenta_SIZUC_EliminarElemento;
            cuenta.SIZUC_Actualizar += SIZUC_Actualizar;
            if (stpModulos.Children.Count > 0)
            {
                SIZUCContabilizacionCapturaSeparador separador = new SIZUCContabilizacionCapturaSeparador();
                cuenta.Separador = separador;
                stpModulos.Children.Add(separador);
            }
            if (cuentaStr != null) cuenta.CuentaContable = cuentaStr;
            stpModulos.Children.Add(cuenta);
            numeroControles++;
            ActualizarElimninarControles();
        }

        private void Cuenta_SIZUC_EliminarElemento(SIZUCContabilizacionCapturaCuenta objeto)
        {
            if (stpModulos.Children.IndexOf(objeto) == stpModulos.Children.Count - 1)
            {
                stpModulos.Children.Remove(objeto);
                stpModulos.Children.Remove(objeto.Separador);
                numeroControles--;
                EsSetGrafico = true;
                ActualizarElimninarControles();
                esPosibleAgregarCuenta = false;
                EsSetGrafico = false;
            }


        }

        private string Cuenta_SIZUC_BuscarCuentaContable(SIZUCContabilizacionCapturaCuenta objeto)
        {
            String cuentaContable = "Seleccione";
            if (SIZUC_BuscarCuentaContable != null)
            {
                cuentaContable = SIZUC_BuscarCuentaContable(this);
            }
            this.objCuenta = objeto;
            EsSetGrafico = true;
            ArmarExpresion();
            EsSetGrafico = false;
            return cuentaContable;
        }

        public void SetValorEncontrado(String valor)
        {
            if (this.objCuenta != null)
                this.objCuenta.CuentaContable = valor;
            if (this.objVariable != null)
                this.objVariable.Variable = valor;

            this.objCuenta = null;
            this.objVariable = null;

        }
        private List<int> NivelesCuentaContable = new List<int>();
        private void ArmarExpresion()
        {
            //if (!EsSetGrafico)
            //    return;

            String expresion = "";
            caracteresOcupados = 0;

            List<Control> remover = new List<Control>();

            foreach (Control ctrl in stpModulos.Children)
            {
                if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaCuenta))
                {
                    expresion += ((SIZUCContabilizacionCapturaCuenta)ctrl).CuentaContable + "-";

                    long cuenta = 0;

                    try
                    {
                        cuenta = Convert.ToInt64(((SIZUCContabilizacionCapturaCuenta)ctrl).CuentaContable);
                        caracteresOcupados += ((SIZUCContabilizacionCapturaCuenta)ctrl).CuentaContable.Length;
                    }
                    catch
                    {

                    }
                }
                else if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaVariable))
                {
                    expresion += ((SIZUCContabilizacionCapturaVariable)ctrl).Variable + "[@i&@s]".Replace("@i", ((SIZUCContabilizacionCapturaVariable)ctrl).txtCapturaRangoInferior.Text).Replace("@s", ((SIZUCContabilizacionCapturaVariable)ctrl).txtCapturaRangoSuperior.Text) + "-";
                    caracteresOcupados += ((SIZUCContabilizacionCapturaVariable)ctrl).Longitud;

                    if (caracteresOcupados > caracteresTotales)
                    {
                        remover.Add(ctrl);
                        remover.Add(((SIZUCContabilizacionCapturaVariable)ctrl).Separador);
                    }
                }
            }

            //remover.ForEach(x => stpModulos.Children.Remove(x));

            if (expresion.Length > 0)
                expresion = expresion.Substring(0, expresion.Length - 1);

            int nivelesCount = 0;
            for (int i = 0; i < NivelesCuentaContable.Count; i++)
            {
                nivelesCount += NivelesCuentaContable[i];
                if (caracteresOcupados == nivelesCount)
                    numeroControles = i + 1;
            }


            this.ExpresionFormada = expresion;
        }
        //propiedades

        public static readonly DependencyProperty MascaraContableProperty =
        DependencyProperty.Register("MascaraCuentaContable", typeof(String), typeof(SIZUCContabilizacion), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(MascaraCuentaContableChange)));
        private static void MascaraCuentaContableChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var obj = d as SIZUCContabilizacion;
                obj.MascaraCuentaContable = (String)e.NewValue;
                obj.ToolTip = "Mascara = " + obj.MascaraCuentaContable;
            }
            catch { }
        }
        public String MascaraCuentaContable { get { return (String)GetValue(MascaraContableProperty); } set { CalculaMascaraCuenta(value); SetValue(MascaraContableProperty, value); } }

        private void CalculaMascaraCuenta(string value)
        {
            NivelesCuentaContable.Clear();
            caracteresTotales = 0;
            value.Split('-').ToList().ForEach(x => { NivelesCuentaContable.Add(x.Length); caracteresTotales += x.Length; });
        }

        public static readonly DependencyProperty ExpresionFormadaProperty =
        DependencyProperty.Register("ExpresionFormada", typeof(String), typeof(SIZUCContabilizacion), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ExpresionFormadaChange)));
        private static void ExpresionFormadaChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var icono = d as SIZUCContabilizacion;
                icono.ExpresionFormada = (String)e.NewValue;
            }
            catch { }
        }
        public Boolean EsSetGrafico { get; set; }
        public String ExpresionFormada
        {
            get { return (String)GetValue(ExpresionFormadaProperty); }
            set
            {
                if (ExpresionFormada == value)
                    return;

                CargarExpresion(value);

                SetValue(ExpresionFormadaProperty, value);
            }
        }

        private void CargarExpresion(string value)
        {
            if (EsSetGrafico)
                return;

            List<String> partes = value.Split('-').ToList();

            foreach (String parte in partes)
            {
                if (parte.Trim().Equals(""))
                    continue;

                if (parte.Contains("["))
                {
                    List<String> vars = parte.Replace("[", "-").Replace("]", "").Replace("&", "-").Split('-').ToList();
                    AgregarCapturaVariable(vars[0], Convert.ToInt32(vars[1]), Convert.ToInt32(vars[2]));
                }
                else
                {
                    AgregarCapturaCuenta(parte);
                }
            }
        }
    }
}

