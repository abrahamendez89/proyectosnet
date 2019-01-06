using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas.Conversiones;

namespace ContabilidadElectronica.ControlesDeUsuario
{
    public partial class ParametroConsultaForm : UserControl
    {
        public Object Valor
        {
            get
            {
                if (tipoParametro == typeof(DateTime))
                {
                    DateTimePicker dtp = (DateTimePicker)pnl_control.Controls[0];
                    return dtp.Value;
                }
                else if (tipoParametro == typeof(Int32))
                {
                    TextBox tNumeroEntero = (TextBox)pnl_control.Controls[0];
                    try
                    {
                        return Convert.ToInt32(tNumeroEntero.Text);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                else if (tipoParametro == typeof(double))
                {
                    TextBox tNumeroDecimal = (TextBox)pnl_control.Controls[0];
                    try
                    {
                        return Convert.ToDouble(tNumeroDecimal.Text);
                    }
                    catch
                    {
                        return 0;
                    }
                }
                else if (tipoParametro == typeof(String))
                {
                    TextBox texto = (TextBox)pnl_control.Controls[0];
                    return texto.Text;
                }
                else if (tipoParametro == typeof(Boolean))
                {
                    CheckBox boleano = (CheckBox)pnl_control.Controls[0];
                    return boleano.Checked;
                }
                return null;
            }
        }
        Type tipoParametro;
        public ParametroConsultaForm(String titulo, Type tipo)
        {
            InitializeComponent();
            tipoParametro = tipo;
            lbl_tituloParametro.Text = titulo + ":";
            int height = 20;
            Control aAgregar = null;
            if (tipo == typeof(DateTime))
            {
                DateTimePicker dtp = new DateTimePicker();
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd-MM-yyyy";
                dtp.Height = height;
                aAgregar = dtp;
            }
            else if (tipo == typeof(Int32))
            {
                TextBox tNumeroEntero = new TextBox();
                tNumeroEntero.Width = 80;
                tNumeroEntero.Height = height;
                tNumeroEntero.KeyPress += tNumeroEntero_KeyPress;
                aAgregar = tNumeroEntero;
            }
            else if (tipo == typeof(double))
            {
                TextBox tNumeroDecimal = new TextBox();
                tNumeroDecimal.Width = 80;
                tNumeroDecimal.Height = height;
                tNumeroDecimal.KeyPress += tNumeroDecimal_KeyPress;
                aAgregar = tNumeroDecimal;
            }
            else if (tipo == typeof(String))
            {
                TextBox texto = new TextBox();
                texto.Width = 200;
                texto.Height = height;
                aAgregar = texto;
            }
            else if (tipo == typeof(Boolean))
            {
                CheckBox boleano = new CheckBox();
                boleano.Width = height;
                boleano.Height = height;
                aAgregar = boleano;
            }
            pnl_control.Controls.Add(aAgregar);
        }

        void tNumeroDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((((TextBox)sender).Text.Contains(".") || ((TextBox)sender).Text.Equals("")) && e.KeyChar == (char)46)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)46)
            {
                e.Handled = true;
                return;
            }
        }

        void tNumeroEntero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
