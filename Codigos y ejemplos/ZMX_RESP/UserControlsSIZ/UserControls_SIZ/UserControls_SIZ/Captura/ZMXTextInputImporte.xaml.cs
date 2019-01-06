using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace UserControlsSIZ.Captura
{
    /// <summary>
    /// Interaction logic for ZMXTextInputImporte.xaml
    /// </summary>
    public partial class ZMXTextInputImporte : UserControl
    {
        public delegate void _ZMX_ValorCambiado(ZMXTextInputImporte controlCaptura);
        public event _ZMX_ValorCambiado ZMX_ValorCambiado;

        public delegate void _ZMX_GotFocus(ZMXTextInputImporte controlCaptura);
        public event _ZMX_GotFocus ZMX_GotFocus;

        public delegate void _ZMX_LostFocus(ZMXTextInputImporte controlCaptura);
        public event _ZMX_LostFocus ZMX_LostFocus;

        public delegate void _ZMX_ActivarSiguienteControl(ZMXTextInputImporte controlCaptura);
        public event _ZMX_ActivarSiguienteControl ZMX_ActivarSiguienteControl;

        public delegate void _ZMX_ActivarAnteriorControl(ZMXTextInputImporte controlCaptura);
        public event _ZMX_ActivarAnteriorControl ZMX_ActivarAnteriorControl;

        public delegate void _ZMX_CambioValorRequerido(ZMXTextInputImporte controlCaptura);
        public event _ZMX_CambioValorRequerido ZMX_CambioValorRequerido;

        public delegate String _ZMX_FormatearNumeroImplementacion(ZMXTextInputImporte controlCaptura, Decimal zmx_valor);
        public event _ZMX_FormatearNumeroImplementacion ZMX_FormatearNumeroImplementacion;

        public ZMXTextInputImporte()
        {
            InitializeComponent();
            txtValor.TextAlignment = TextAlignment.Right;
            txtValor.PreviewTextInput += TxtValor_PreviewTextInput;
            txtValor.PreviewKeyDown += TxtValor_PreviewKeyDown1;
            txtValor.PreviewKeyUp += TxtValor_KeyUp;
            txtValor.PreviewKeyDown += TxtValor_KeyDown;
            txtValor.LostFocus += TxtValor_LostFocus;
            this.GotFocus += ZMXTextInputImporte_GotFocus;
            txtValor.GotFocus += TxtValor_GotFocus;
            txtValor.TextChanged += TxtValor_TextChanged;

            ZMX_MarcarRequerido = false;

            rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden;

            ZMX_Valor = 0;
            zmx_isEnabled = true;
        }

        public Boolean ZMX_ControlBloqueadoPorSecuencia { get; set; }

        public Decimal ZMX_ValorMaximo { get; set; }
        public Decimal ZMX_ValorMinimo { get; set; }

        private void TxtValor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //try
            //{
            //    ZMX_Valor = Convert.ToDecimal(txtValor.Text);
            //}
            //catch { };
            if (ZMX_ValorCambiado != null)
                ZMX_ValorCambiado(this);
        }
        private Boolean zmx_isEnabled;
        public Boolean ZMX_IsEnabled
        {
            get { return zmx_isEnabled; }
            set
            {
                zmx_isEnabled = value;
                if (!zmx_isEnabled)
                {
                    BrushConverter tb = new BrushConverter();
                    txtValor.Visibility = Visibility.Hidden;
                    txtValorFormateado.Visibility = Visibility.Visible;
                    rtgMarcoNegro.Fill = (Brush)tb.ConvertFromString("#f4f3f2");
                }
                else
                {
                    txtValor.Visibility = Visibility.Visible;
                    txtValorFormateado.Visibility = Visibility.Hidden;
                    rtgMarcoNegro.Fill = Brushes.White;
                }
            }
        }
        private Brush ColorBrush;
        public void SetColor(Brush colorBrush)
        {
            ColorBrush = colorBrush;
            rtgMarcoNegro.Stroke = colorBrush;
        }
        private void TxtValor_KeyDown(object sender, KeyEventArgs e)
        {
            ////bool ctrlV = e.Modifiers == Keys.Control && e.KeyCode == Keys.V;
            ////bool shiftIns = e.Modifiers == Keys.Shift && e.KeyCode == Keys.Insert;

            ////if (ctrlV || shiftIns)
            ////    DoSomething();
            if((Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) && e.Key == Key.Tab)
            {
                if (ZMX_ActivarAnteriorControl != null)
                    ZMX_ActivarAnteriorControl(this);
            }
            else if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.V)
            {
                String text = Clipboard.GetText();

                //se valida que el numero tenga un formato permitido

                String valorSel1 = txtValor.Text.Substring(0, txtValor.SelectionStart);
                String valorSel2 = "";
                try
                {
                    valorSel2 = txtValor.Text.Substring(txtValor.SelectionStart + txtValor.SelectionLength, txtValor.Text.Length - (txtValor.SelectionStart + txtValor.SelectionLength));
                }
                catch { }
                valorSel1 += text + valorSel2;

                //se valida que se este pegando un numero
                try
                {
                    Convert.ToDouble(valorSel1);
                }
                catch
                {
                    e.Handled = true;
                    return;
                }

                e.Handled = EvaluarEstructuraNumero(valorSel1, text);


            }

        }
        public String ZMX_Format { get; set; }
        private void TxtValor_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToDouble(txtValor.Text);

                if (txtValor.Text.EndsWith("."))
                {
                    txtValor.Text = txtValor.Text.Replace(".", "");
                }
                if (txtValor.Text.StartsWith("."))
                {
                    txtValor.Text = txtValor.Text.Replace(".", "0.");
                }
                if (txtValor.Text.StartsWith("-."))
                {
                    txtValor.Text = txtValor.Text.Replace("-.", "0.");
                }

                if (!string.IsNullOrEmpty(ZMX_Format))
                {
                    txtValor.Visibility = Visibility.Hidden;
                    txtValorFormateado.Visibility = Visibility.Visible;
                    txtValorFormateado.Text = ZMX_Valor.ToString(ZMX_Format, CultureInfo.CurrentCulture);
                }
                else if (ZMX_FormatearNumeroImplementacion != null)
                {
                    txtValor.Visibility = Visibility.Hidden;
                    txtValorFormateado.Visibility = Visibility.Visible;
                    txtValorFormateado.Text = ZMX_FormatearNumeroImplementacion(this, this.ZMX_Valor);
                }

            }
            catch { txtValor.Text = "0"; }
            finally
            {
                if (ZMX_LostFocus != null)
                    ZMX_LostFocus(this);
            }
        }

        private void TxtValor_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TxtValor_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ZMX_Format))
            {
                txtValor.Visibility = Visibility.Visible;
                txtValorFormateado.Visibility = Visibility.Hidden;
                txtValorFormateado.Text = "";
            }


            txtValor.SelectionStart = 0;
            txtValor.SelectionLength = txtValor.Text.Length;



        }

        private void ZMXTextInputImporte_GotFocus(object sender, RoutedEventArgs e)
        {
            ZMX_Focus();
        }

        private void TxtValor_PreviewKeyDown1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if ((!Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift)) && (e.Key == Key.Tab || e.Key == Key.Enter))
            {
                e.Handled = true;
                if (ZMX_ActivarSiguienteControl != null)
                    ZMX_ActivarSiguienteControl(this);
            }

            //if(e.Key == Key.Subtract || e.Key == Key.Delete || e.Key == Key.Back)
            //{
            //    String valor = txtValor.Text;
            //}

        }

        private void TxtValor_KeyDown1(object sender, KeyEventArgs e)
        {
            if (ZMX_Decimales > 0)
            {
                if (txtValor.Text.Split('.').Length == 2 && txtValor.Text.Split('.')[1].Length > ZMX_Decimales)
                {
                    e.Handled = true;
                    int caretPosition = txtValor.SelectionStart;
                    txtValor.Text = valorAnterior;
                    txtValor.SelectionStart = caretPosition;
                }
            }
        }

        public int ZMX_Decimales { get; set; }
        public int ZMX_Enteros { get; set; }

        String valorAnterior = "";

        public void ZMX_Focus()
        {
            txtValor.SelectionStart = 0;
            txtValor.SelectionLength = txtValor.Text.Length;
            txtValor.GotFocus -= TxtValor_GotFocus;

            if (!string.IsNullOrEmpty(ZMX_Format) && zmx_isEnabled)
            {
                txtValor.Visibility = Visibility.Visible;
                txtValorFormateado.Visibility = Visibility.Hidden;
                txtValorFormateado.Text = "";
            }

            if (string.IsNullOrEmpty(ZMX_Format) && zmx_isEnabled)
            {
                txtValor.Visibility = Visibility.Visible;
                txtValorFormateado.Visibility = Visibility.Hidden;
                txtValorFormateado.Text = "";
            }

            txtValor.Focus();
            txtValor.GotFocus += TxtValor_GotFocus;
            if (ZMX_GotFocus != null)
                ZMX_GotFocus(this);
        }

        private void TxtValor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            valorAnterior = txtValor.Text;

            if (e.Text.Equals(""))
            {
                e.Handled = true;
                return;
            }
            //validando que no venga un simbolo negativo, si el valor minimo es 0
            if (e.Text.Equals("-") && ZMX_ValorMinimo == 0 && txtValor.SelectionStart == 0)
            {
                Window win = Window.GetWindow(this);
                UtileriasControles.MuestraToolTipSobreControl(win, txtValor, "Valor mínimo: " + ZMX_ValorMinimo, 1500, UtileriasControles.Posicion.Arriba);
                e.Handled = true;
                return;
            }
            //validando q no se tecleen caracteres especiales no permitidos
            if (!e.Text.Equals("-") && !char.IsDigit(e.Text, e.Text.Length - 1) && !e.Text.Equals("."))
            {
                e.Handled = true;
                return;
            }
            //validando q no venga un simbolo negativo despues de un numero
            if (e.Text.Equals("-") && txtValor.SelectionStart > 0)
            {
                e.Handled = true;
                return;
            }
            //validando que no venga un simbolo negativo antes q otro simbolo negativo
            if (e.Text.Equals("-") && txtValor.SelectionStart == 0 && txtValor.Text.StartsWith("-") && txtValor.SelectionLength == 0)
            {
                e.Handled = true;
                return;
            }


            if (txtValor.SelectionStart == 0 && txtValor.SelectionLength == txtValor.Text.Length)
            {
                txtValor.Text = "" + e.Text;
                e.Handled = true;
                txtValor.SelectionStart = 1;
                return;
            }
            if (txtValor.SelectionStart >= 0 && txtValor.SelectionLength > 0)
            {
                //replace de lo seleccionado si trae punto
                if (txtValor.Text.Substring(txtValor.SelectionStart, txtValor.SelectionLength).Contains("."))
                {
                    int indicePunto = txtValor.Text.IndexOf(".");
                    String valorSel1 = txtValor.Text.Substring(0, txtValor.SelectionStart);
                    String valorSel2 = "";
                    try
                    {
                        valorSel2 = txtValor.Text.Substring(txtValor.SelectionStart + txtValor.SelectionLength, txtValor.Text.Length - (txtValor.SelectionStart + txtValor.SelectionLength));
                    }
                    catch { }
                    valorSel1 += e.Text + valorSel2;
                }
            }
            //replace de lo seleccionado si no trae punto
            if (txtValor.SelectionStart >= 0 && txtValor.SelectionLength > 0)
            {
                String valorSel1 = txtValor.Text.Substring(0, txtValor.SelectionStart);
                String valorSel2 = "";
                try
                {
                    valorSel2 = txtValor.Text.Substring(txtValor.SelectionStart + txtValor.SelectionLength, txtValor.Text.Length - (txtValor.SelectionStart + txtValor.SelectionLength));
                }
                catch { }
                valorSel1 += e.Text + valorSel2;
                //se evalua que al cambiar el texto seleccionado por el valor a introducir, conserve el formato.
                EvaluarNumero(e, valorSel1);
                e.Handled = EvaluarEstructuraNumero(valorSel1, e.Text);
                if (e.Handled)
                    return;

                int n = txtValor.SelectionStart;
                txtValor.Text = valorSel1;
                txtValor.SelectionStart = n + 1;
                txtValor.SelectionLength = 0;
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.Text, e.Text.Length - 1) && !e.Text.Equals(".") && !e.Text.Equals("-"))
                e.Handled = true;

            if (e.Text.Equals(".") && txtValor.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            if (e.Text.Equals(".") && ZMX_Decimales == 0)
            {
                e.Handled = true;
                return;
            }

            String valorTemp1 = txtValor.Text.Substring(0, txtValor.SelectionStart);

            if (e.Text.Equals("-") && valorTemp1.Contains("-"))
            {
                e.Handled = true;
                return;
            }



            String valorTemp2 = "";
            try
            {
                valorTemp2 = txtValor.Text.Substring(txtValor.SelectionStart, txtValor.Text.Length - txtValor.SelectionStart);
            }
            catch { }
            valorTemp1 += e.Text + valorTemp2;

            //Evaluando el caso "-."
            if (valorTemp1.StartsWith("-."))
            {
                int indice = txtValor.SelectionStart;

                valorTemp1 = valorTemp1.Replace("-.", "0");
                txtValor.Text = txtValor.Text.Replace("-", "0.");
                e.Handled = true;
                txtValor.SelectionStart = 2;
                return;
            }
            //validando si empieza con .
            if (valorTemp1.StartsWith("."))
            {
                txtValor.Text = txtValor.Text.Replace(".", "0") + valorTemp1;
                e.Handled = true;
                txtValor.SelectionStart = 3;
                return;
            }


            EvaluarNumero(e, valorTemp1);

            e.Handled = EvaluarEstructuraNumero(valorTemp1, e.Text);

            //Validamos que el numero que va a quedar este dentro del rango configurado y que haya pasado las validaciones de estructura
            if (!e.Handled)
            {
                e.Handled = EvaluaRangos(valorTemp1);
            }

        }

        private Boolean EvaluaRangos(string ValorFuturo)
        {
            if (!ZMX_IsEnabled)
                return false;

            Decimal valor = Convert.ToDecimal(ValorFuturo);

            Window win = Window.GetWindow(this);


            if (valor < ZMX_ValorMinimo)
            {
                UtileriasControles.MuestraToolTipSobreControl(win, txtValor, "Valor mínimo: " + ZMX_ValorMinimo, 1500, UtileriasControles.Posicion.Arriba);
                return true;
            }
            else if (ZMX_ValorMaximo != 0 && valor > ZMX_ValorMaximo)
            {
                UtileriasControles.MuestraToolTipSobreControl(win, txtValor, "Valor máximo: " + ZMX_ValorMaximo, 1500, UtileriasControles.Posicion.Arriba);
                return true;
            }

            return false;
        }

        private Boolean EvaluarEstructuraNumero(String valorFuturo, String valorIntroduciendo)
        {
            if (ZMX_Decimales > 0)
            {
                if (valorFuturo.Split('.').Length == 2 && valorFuturo.Split('.')[1].Length > ZMX_Decimales)
                {
                    return true;
                }
            }
            if (ZMX_Enteros > 0)
            {

                if (valorFuturo.Split('.').Length >= 1 && valorFuturo.Replace("-", "").Split('.')[0].Length > ZMX_Enteros)
                {
                    if (ZMX_Decimales > 0)
                    {
                        if (!txtValor.Text.Contains("."))
                        {
                            txtValor.Text += "." + valorIntroduciendo;

                            txtValor.SelectionStart = txtValor.Text.Length;
                            return true;
                        }
                        else
                            return EvaluarEnteros(valorFuturo);
                    }
                    else
                        return true;
                }
            }
            return false;
        }



        public Boolean EvaluarEnteros(String valorFuturo)
        {
            if (ZMX_Enteros == 0 || valorFuturo.Equals("0"))
                return false;
            if (!ZMX_IsEnabled)
                return false;
            if (valorFuturo.Split('.').Length >= 1 && valorFuturo.Split('.')[0].Length > ZMX_Enteros)
            {
                return true;
            }
            return false;
        }

        public Boolean EvaluarDecimales(String valorFuturo)
        {
            if (ZMX_Decimales == 0 || valorFuturo.Equals("0"))
                return false;
            if (!ZMX_IsEnabled)
                return false;
            if (valorFuturo.Split('.').Length == 2 && valorFuturo.Split('.')[1].Length > ZMX_Decimales)
            {
                return true;
            }
            return false;
        }

        private void EvaluarNumero(TextCompositionEventArgs e, String valor)
        {
            if (valor.Equals(""))
                return;
            try { Convert.ToDouble(valor); } catch { e.Handled = true; }
        }
        private Boolean zmx_esRequerido;
        public Boolean ZMX_EsRequerido { get { return zmx_esRequerido; } set { zmx_esRequerido = value; if (ZMX_CambioValorRequerido != null) ZMX_CambioValorRequerido(this); } }
        public Boolean ZMX_MarcarRequerido
        {
            get { return ZMX_EsRequerido; }
            set
            {
                if (value)
                    ZMX_EsRequerido = value;

                if (value && ZMX_Valor != 0)
                    return;

                if (value) { rtgMarcoRojo.Visibility = Visibility.Visible; txtAsterisco.Visibility = Visibility.Visible; }
                else { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden; }
            }
        }
        public Boolean ZMX_MarcarRequeridoInicial
        {
            get { return ZMX_EsRequerido; }
            set
            {
                if (value)
                    ZMX_EsRequerido = value;

                if (value && ZMX_Valor != 0)
                    return;

                if (value) { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Visible; }
                else { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden; }
            }
        }
        public Boolean ZMX_SetTemplateRequerido
        {
            set
            {
                if (value) { rtgMarcoRojo.Visibility = Visibility.Visible; txtAsterisco.Visibility = Visibility.Visible; }
                else { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden; }
            }
        }
        public Boolean ZMX_SetTemplateRequeridoInicial
        {
            set
            {
                if (value) { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Visible; }
                else { rtgMarcoRojo.Visibility = Visibility.Hidden; txtAsterisco.Visibility = Visibility.Hidden; }
            }
        }
        public Decimal ZMX_ValorRedondeado
        {
            get
            {
                return Math.Round(ZMX_Valor, ZMX_Decimales);
            }
        }
        public Decimal ZMX_Valor
        {
            get
            {
                try
                {
                    Decimal valor = Convert.ToDecimal(txtValor.Text);
                    return valor;
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                String valorString = value.ToString();
                if (!EvaluarEnteros(valorString) && !EvaluarDecimales(valorString))
                {
                    if (!EvaluaRangos(valorString))
                    {
                        txtValor.Text = valorString;

                        txtValor.Visibility = Visibility.Hidden;
                        txtValorFormateado.Visibility = Visibility.Visible;

                        if (!string.IsNullOrEmpty(ZMX_Format))
                        {
                            txtValorFormateado.Text = ZMX_Valor.ToString(ZMX_Format, CultureInfo.CurrentCulture);
                        }
                        else if (ZMX_FormatearNumeroImplementacion != null)
                        {
                            txtValor.Visibility = Visibility.Hidden;
                            txtValorFormateado.Visibility = Visibility.Visible;
                            txtValorFormateado.Text = ZMX_FormatearNumeroImplementacion(this, this.ZMX_Valor);
                        }
                        else
                        {
                            txtValorFormateado.Text = txtValor.Text;
                        }
                        if (ZMX_ValorCambiado != null)
                            ZMX_ValorCambiado(this);
                    }
                }
                else
                {
                    Window win = Window.GetWindow(this);
                    UtileriasControles.MuestraToolTipSobreControl(win, txtValor, "Valor fuera del rango permitido en cantidad de Enteros o Decimales.", 3000, UtileriasControles.Posicion.Arriba);
                }
            }
        }

    }
}

