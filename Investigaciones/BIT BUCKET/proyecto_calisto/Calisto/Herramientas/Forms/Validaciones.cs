using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Herramientas.Forms
{
    public class Validaciones
    {
        public static void TextboxSoloNumerosEnteros(TextBox txt)
        {
            txt.KeyPress += txt_KeyPress;
        }
        public static void TextboxSoloNumerosDecimales(TextBox txtDecimales, int numeroDecimales)
        {
            txtDecimales.Tag = numeroDecimales;
            txtDecimales.KeyPress += txtDecimales_KeyPress;
        }

        static void txtDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBox textBoxEvento = (TextBox)sender;

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < textBoxEvento.Text.Length; i++)
            {
                if (textBoxEvento.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= (int)textBoxEvento.Tag)
                {
                    e.Handled = true;
                    return;
                }


            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else if (e.KeyChar == 22 || e.KeyChar == 3)
                e.Handled = false;
            else
                e.Handled = true;
        }
        static void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.ControlKey))
            {
                e.Handled = true;
            }
        }
    }
}
