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
using UserControlsSIZ.Utilerias;

namespace UserControlsSIZ.Contables
{
    /// <summary>
    /// Interaction logic for SIZUCContabilizacion.xaml
    /// </summary>
    public partial class SIZUCContabilizacion : UserControl
    {
        //eventos
        public delegate String _SIZUC_BuscarVariableContable(SIZUCContabilizacion objeto);
        public event _SIZUC_BuscarVariableContable SIZUC_BuscarVariableContable;
        public delegate String _SIZUC_BuscarCuentaContable(SIZUCContabilizacion objeto);
        public event _SIZUC_BuscarCuentaContable SIZUC_BuscarCuentaContable;

        public delegate void _SIZUC_CambioExpresion(SIZUCContabilizacion objeto, String expresion);
        public event _SIZUC_CambioExpresion SIZUC_CambioExpresion;

        public delegate String _SIZUC_DibujarExpresion(SIZUCContabilizacion objeto);
        public event _SIZUC_DibujarExpresion SIZUC_DibujarExpresion;

        int caracteresOcupados;
        int caracteresTotales;
        int caracteresFaltantes;

        public SIZUCContabilizacion()
        {
            InitializeComponent();

            btnAgregarModuloCuenta.MouseUp += BtnAgregarModuloCuenta_MouseUp;
            btnAgregarModuloVariable.MouseUp += BtnAgregarModuloVariable_MouseUp;
            btnAgregarModuloCapturaLibre.MouseUp += BtnAgregarModuloCapturaLibre_MouseUp;

            Loaded += SIZUCContabilizacion_Loaded;
        }

        private void CalcularCaracteres()
        {
            caracteresOcupados = 0;
            caracteresTotales = MascaraCuentaContable.Replace("-", "").Length;
            foreach (Control ctr in stpModulos.Children)
            {
                if (ctr.GetType() == typeof(SIZUCContabilizacionCapturaCuenta))
                {
                    caracteresOcupados += ((SIZUCContabilizacionCapturaCuenta)ctr).CuentaContable.Length;
                }
                else if (ctr.GetType() == typeof(SIZUCContabilizacionCapturaVariable))
                {
                    caracteresOcupados += ((SIZUCContabilizacionCapturaVariable)ctr).Longitud;
                }
                else if (ctr.GetType() == typeof(SIZUCContabilizacionCapturaLibre))
                {
                    caracteresOcupados += ((SIZUCContabilizacionCapturaLibre)ctr).Captura.Length;
                }
            }

            caracteresFaltantes = caracteresTotales - caracteresOcupados;

            ToolTip = "Mascara = " + MascaraCuentaContable + "\nCaptura = " + caracteresOcupados + "/" + caracteresTotales;

            double widthActual = rtgAvanceReferencia.ActualWidth;

            double widthAvance = widthActual * caracteresOcupados / caracteresTotales;

            Brush colorClaro = Colores.ConvertirColorABrush(Colores.AclararColor(Colores.ConvertirBrushAColor(ColorBase), 5));
            Brush colorOscuro = Colores.ConvertirColorABrush(Colores.OscurecerColor(Colores.ConvertirBrushAColor(ColorBase), 85));

            if (caracteresOcupados != caracteresTotales)
                rtgAvance.Fill = colorClaro; // (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF96F6F"));
            else
                rtgAvance.Fill = colorOscuro; // (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF82E87E"));

            rtgAvance.Width = widthAvance;

        }


        private void BtnAgregarModuloCapturaLibre_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ValidarCuentasCapturadas())
                return;
            CalcularCaracteres();
            SIZUCContabilizacionCapturaLibre cuenta = new SIZUCContabilizacionCapturaLibre();
            cuenta.SetColor(ColorBase);
            cuenta.BotonEliminarVisible = true;
            cuenta.CaracteresFaltantes = caracteresFaltantes;
            if (stpModulos.Children.Count > 0)
            {
                SIZUCContabilizacionCapturaSeparador separador = new SIZUCContabilizacionCapturaSeparador();
                cuenta.Separador = separador;
                stpModulos.Children.Add(separador);
            }
            stpModulos.Children.Add(cuenta);
            cuenta.SIZUC_EliminarElemento += Cuenta_SIZUC_EliminarElemento1;
            cuenta.SIZUC_Actualizar += SIZUC_Actualizar;
            ActualizarElimninarControles();
        }

        private void Cuenta_SIZUC_EliminarElemento1(SIZUCContabilizacionCapturaLibre objeto)
        {
            if (stpModulos.Children.IndexOf(objeto) == stpModulos.Children.Count - 1)
            {
                stpModulos.Children.Remove(objeto);
                stpModulos.Children.Remove(objeto.Separador);
                ActualizarElimninarControles();
            }
        }

        private void SIZUCContabilizacion_Loaded(object sender, RoutedEventArgs e)
        {
            CalculaMascaraCuenta(MascaraContable);
            MascaraCuentaContable = MascaraContable;
            CalcularCaracteres();

            setColor(ColorBase);

        }

        private void setColor(Brush colorBase)
        {
            btnAgregarModuloCapturaLibre.IconoColor = Brushes.White; // colorBase;
            btnAgregarModuloCuenta.IconoColor = Brushes.White; // colorBase;
            btnAgregarModuloVariable.IconoColor = Brushes.White; // colorBase;
            Brush colorClaro = Colores.ConvertirColorABrush(Colores.AclararColor(Colores.ConvertirBrushAColor(ColorBase), 20));
            rtgAvanceReferencia.Fill = colorClaro;
        }

        private static String MascaraContable;
        public static void SetMascaraContable(String mascara)
        {
            MascaraContable = mascara;
        }
        private static Brush ColorBase;
        public static void SetColor(Brush colorBase)
        {
            ColorBase = colorBase;
        }
        private Boolean ValidarCuentasCapturadas()
        {
            foreach (Control ctrl in stpModulos.Children)
            {
                if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaCuenta) && ((SIZUCContabilizacionCapturaCuenta)ctrl).CuentaContable.Equals("Seleccione"))
                    return true;
                if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaLibre) && ((SIZUCContabilizacionCapturaLibre)ctrl).Captura.Trim().Length == 0)
                    return true;
                if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaVariable) && (((SIZUCContabilizacionCapturaVariable)ctrl).Variable.Equals("Seleccione")))
                    return true;
            }

            if (caracteresOcupados == caracteresTotales)
                return true;

            return false;
        }

        private void BtnAgregarModuloVariable_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ValidarCuentasCapturadas())
                return;
            CalcularCaracteres();
            SIZUCContabilizacionCapturaVariable variable = new SIZUCContabilizacionCapturaVariable();
            variable.SetColor(ColorBase);
            variable.CaracteresFaltantes = caracteresFaltantes;
            if (stpModulos.Children.Count > 0)
            {
                SIZUCContabilizacionCapturaSeparador separador = new SIZUCContabilizacionCapturaSeparador();
                variable.Separador = separador;
                stpModulos.Children.Add(separador);
            }
            stpModulos.Children.Add(variable);
            variable.SIZUC_BuscarVariableContable += Variable_SIZUC_BuscarVariableContable;
            variable.SIZUC_EliminarElemento += Variable_SIZUC_EliminarElemento;
            variable.SIZUC_Actualizar += SIZUC_Actualizar;
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
                else if (ctr.GetType() == typeof(SIZUCContabilizacionCapturaLibre))
                {
                    ((SIZUCContabilizacionCapturaLibre)ctr).BotonEliminarVisible = false;
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
                else if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaLibre))
                {
                    ((SIZUCContabilizacionCapturaLibre)ctrl).BotonEliminarVisible = true;
                }
            }
            ArmarExpresion();

        }

        private void SIZUC_Actualizar()
        {
            ArmarExpresion();
            CalcularCaracteres();
        }

        private void Variable_SIZUC_EliminarElemento(SIZUCContabilizacionCapturaVariable objeto)
        {
            if (stpModulos.Children.IndexOf(objeto) == stpModulos.Children.Count - 1)
            {
                stpModulos.Children.Remove(objeto);
                stpModulos.Children.Remove(objeto.Separador);
                ActualizarElimninarControles();
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
            ArmarExpresion();
            return variableContable;

        }

        private void BtnAgregarModuloCuenta_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (ValidarCuentasCapturadas())
                return;
            CalcularCaracteres();
            SIZUCContabilizacionCapturaCuenta cuenta = new SIZUCContabilizacionCapturaCuenta();
            cuenta.SetColor(ColorBase);
            cuenta.CaracteresFaltantes = caracteresFaltantes;
            if (stpModulos.Children.Count > 0)
            {
                SIZUCContabilizacionCapturaSeparador separador = new SIZUCContabilizacionCapturaSeparador();
                cuenta.Separador = separador;
                stpModulos.Children.Add(separador);
            }
            stpModulos.Children.Add(cuenta);
            cuenta.SIZUC_BuscarCuentaContable += Cuenta_SIZUC_BuscarCuentaContable;
            cuenta.SIZUC_EliminarElemento += Cuenta_SIZUC_EliminarElemento;
            cuenta.SIZUC_Actualizar += SIZUC_Actualizar;
            ActualizarElimninarControles();
        }


        private void Cuenta_SIZUC_EliminarElemento(SIZUCContabilizacionCapturaCuenta objeto)
        {
            if (stpModulos.Children.IndexOf(objeto) == stpModulos.Children.Count - 1)
            {
                stpModulos.Children.Remove(objeto);
                stpModulos.Children.Remove(objeto.Separador);
                ActualizarElimninarControles();
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
            ArmarExpresion();
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
            String expresion = "";
            caracteresOcupados = 0;

            List<Control> remover = new List<Control>();

            foreach (Control ctrl in stpModulos.Children)
            {
                if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaCuenta))
                {
                    expresion += ((SIZUCContabilizacionCapturaCuenta)ctrl).CuentaContable + "|" + ((SIZUCContabilizacionCapturaCuenta)ctrl).CuentaNombre + "-";

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
                else if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaLibre))
                {
                    expresion += ((SIZUCContabilizacionCapturaLibre)ctrl).Captura + "-";

                    long cuenta = 0;

                    try
                    {
                        cuenta = Convert.ToInt64(((SIZUCContabilizacionCapturaLibre)ctrl).Captura);
                        caracteresOcupados += ((SIZUCContabilizacionCapturaLibre)ctrl).Captura.Length;
                    }
                    catch
                    {

                    }
                }
                else if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaVariable))
                {
                    expresion += ((SIZUCContabilizacionCapturaVariable)ctrl).Variable + "[@i&@s]".Replace("@i", ((SIZUCContabilizacionCapturaVariable)ctrl).txtCapturaEncriptadoRangoInferior.Text).Replace("@s", ((SIZUCContabilizacionCapturaVariable)ctrl).txtCapturaEncriptadoRangoSuperior.Text) + "-";
                    caracteresOcupados += ((SIZUCContabilizacionCapturaVariable)ctrl).Longitud;

                    if (caracteresOcupados > caracteresTotales)
                    {
                        remover.Add(ctrl);
                        remover.Add(((SIZUCContabilizacionCapturaVariable)ctrl).Separador);
                    }
                }
            }

            if (expresion.Length > 0)
                expresion = expresion.Substring(0, expresion.Length - 1);
            Bloquear = true;
            this.ExpresionFormada = expresion;
            Bloquear = false;
            CalcularCaracteres();
        }
        //propiedades
        public Boolean Bloquear { get; set; }
        public static readonly DependencyProperty MascaraContableProperty =
        DependencyProperty.Register("MascaraCuentaContable", typeof(String), typeof(SIZUCContabilizacion), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(MascaraCuentaContableChange)));
        private static void MascaraCuentaContableChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var obj = d as SIZUCContabilizacion;
                obj.MascaraCuentaContable = (String)e.NewValue;
            }
            catch { }
        }
        public String MascaraCuentaContable { get { return (String)GetValue(MascaraContableProperty); } set { CalculaMascaraCuenta(value); SetValue(MascaraContableProperty, value); } }
        //-----
        public static readonly DependencyProperty DatoProperty =
        DependencyProperty.Register("Dato", typeof(object), typeof(SIZUCContabilizacion), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(DatoChange)));
        private static void DatoChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var obj = d as SIZUCContabilizacion;
                obj.Dato = (object)e.NewValue;
            }
            catch { }
        }
        public object Dato { get { return (object)GetValue(DatoProperty); } set { SetValue(DatoProperty, value); } }
        //-------
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
                var ctrl = d as SIZUCContabilizacion;
                ctrl.ExpresionFormada = (String)e.NewValue;
                if (!ctrl.Bloquear)
                    ctrl.CargarExpresion(ctrl.ExpresionFormada);

            }
            catch { }
        }
        public String ExpresionFormada
        {
            get
            {
                return (String)GetValue(ExpresionFormadaProperty);
            }
            set
            {
                SetValue(ExpresionFormadaProperty, value);
            }
        }

        public void CargarExpresion(string value)
        {
            CalculaMascaraCuenta(MascaraContable);
            stpModulos.Children.Clear();
            List<String> partes = new List<string>();
            if (value != null)
            {
                partes = value.Split('-').ToList();
            }
            caracteresFaltantes = caracteresTotales;
            foreach (String parte in partes)
            {
                if (parte.Trim().Equals(""))
                    continue;

                if (parte.Contains("["))
                {
                    List<String> vars = parte.Replace("[", "-").Replace("]", "").Replace("&", "-").Split('-').ToList();

                    DibujarControlVariable(vars[0], Convert.ToInt32(vars[1]), Convert.ToInt32(vars[2]), caracteresFaltantes);
                    caracteresFaltantes -= Convert.ToInt32(vars[2]) - Convert.ToInt32(vars[1]);
                }
                else if (parte.Contains("|"))
                {
                    DibujarControlCuenta(parte, caracteresFaltantes);
                    caracteresFaltantes -= parte.Split('|')[0].Length;
                }
                else
                {
                    DibujarControlLibre(parte, caracteresFaltantes);
                    caracteresFaltantes -= parte.Length;
                }
            }

            //ActualizarElimninarControles();
            //se desbloquea el ultimo elemento
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
                else if (ctrl.GetType() == typeof(SIZUCContabilizacionCapturaLibre))
                {
                    ((SIZUCContabilizacionCapturaLibre)ctrl).BotonEliminarVisible = true;
                }
            }

        }

        private void DibujarControlLibre(string parte, int caracteres)
        {
            //CalcularCaracteres();
            SIZUCContabilizacionCapturaLibre cuenta = new SIZUCContabilizacionCapturaLibre();
            cuenta.SetColor(ColorBase);
            cuenta.BotonEliminarVisible = false;
            cuenta.CaracteresFaltantes = caracteres;
            if (stpModulos.Children.Count > 0)
            {
                SIZUCContabilizacionCapturaSeparador separador = new SIZUCContabilizacionCapturaSeparador();
                cuenta.Separador = separador;
                stpModulos.Children.Add(separador);
            }
            if (parte != null)
                cuenta.Captura = parte;
            stpModulos.Children.Add(cuenta);
            cuenta.SIZUC_EliminarElemento += Cuenta_SIZUC_EliminarElemento2;
            cuenta.SIZUC_Actualizar += SIZUC_Actualizar;
        }

        private void Cuenta_SIZUC_EliminarElemento2(SIZUCContabilizacionCapturaLibre objeto)
        {
            if (stpModulos.Children.IndexOf(objeto) == stpModulos.Children.Count - 1)
            {
                stpModulos.Children.Remove(objeto);
                stpModulos.Children.Remove(objeto.Separador);
                ActualizarElimninarControles();
            }
        }

        private void DibujarControlVariable(String valorStr, int rangoInferior, int rangoSuperior, int caracteres)
        {
            //CalcularCaracteres();
            SIZUCContabilizacionCapturaVariable variable = new SIZUCContabilizacionCapturaVariable();
            variable.SetColor(ColorBase);
            variable.BotonEliminarVisible = false;
            variable.CaracteresFaltantes = caracteres;
            if (stpModulos.Children.Count > 0)
            {
                SIZUCContabilizacionCapturaSeparador separador = new SIZUCContabilizacionCapturaSeparador();
                variable.Separador = separador;
                stpModulos.Children.Add(separador);
            }

            if (valorStr != null)
            {
                variable.Variable = valorStr;
                variable.txtCapturaEncriptadoRangoInferior.Text = rangoInferior.ToString();
                variable.txtCapturaEncriptadoRangoSuperior.Text = rangoSuperior.ToString();

            }

            stpModulos.Children.Add(variable);
            variable.SIZUC_BuscarVariableContable += Variable_SIZUC_BuscarVariableContable;
            variable.SIZUC_EliminarElemento += Variable_SIZUC_EliminarElemento;
            variable.SIZUC_Actualizar += SIZUC_Actualizar;

        }
        private void DibujarControlCuenta(String cuentaStr, int caracteres)
        {
            //CalcularCaracteres();
            SIZUCContabilizacionCapturaCuenta cuenta = new SIZUCContabilizacionCapturaCuenta();
            cuenta.SetColor(ColorBase);
            cuenta.BotonEliminarVisible = false;
            cuenta.CaracteresFaltantes = caracteres;
            if (stpModulos.Children.Count > 0)
            {
                SIZUCContabilizacionCapturaSeparador separador = new SIZUCContabilizacionCapturaSeparador();
                cuenta.Separador = separador;
                stpModulos.Children.Add(separador);
            }
            if (cuentaStr != null)
                cuenta.CuentaContable = cuentaStr;

            stpModulos.Children.Add(cuenta);
            cuenta.SIZUC_BuscarCuentaContable += Cuenta_SIZUC_BuscarCuentaContable;
            cuenta.SIZUC_EliminarElemento += Cuenta_SIZUC_EliminarElemento;
            cuenta.SIZUC_Actualizar += SIZUC_Actualizar;
        }

    }
}

