
using ORM.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GeneradorCodigoSQL
{
    public partial class CodigoGenerado : Form
    {
        DBAcceso acceso;
        public CodigoGenerado(DBAcceso acceso, String codigo)
        {
            InitializeComponent();
            this.acceso = acceso;
            if (acceso == null) btn_ejecutarEnServidor.Enabled = false;
            txt_codigo.Text = codigo;
            //palabras reservadas
            reservadas.Add("create", Color.Blue);
            reservadas.Add("table", Color.Blue);
            reservadas.Add("alter", Color.Blue);
            reservadas.Add("clustered", Color.Blue);
            reservadas.Add("nonclustered", Color.Blue);
            reservadas.Add("identity", Color.Blue);
            reservadas.Add("go", Color.Blue);
            reservadas.Add("add", Color.Blue);
            reservadas.Add("foreign", Color.Blue);
            reservadas.Add("primary", Color.Blue);
            reservadas.Add("key", Color.Blue);
            reservadas.Add("references", Color.Blue);
            reservadas.Add("use", Color.Blue);
            reservadas.Add("id", Color.Red);
            reservadas.Add("constraint", Color.Blue);
            //simbolos
            reservadas.Add("(", Color.Black);
            reservadas.Add(")", Color.Black);
            reservadas.Add(";", Color.Black);
            reservadas.Add(",", Color.Black);
            //tipos
            reservadas.Add("numeric", Color.Blue);
            reservadas.Add("max", Color.Pink);
            reservadas.Add("datetime", Color.Blue);
            reservadas.Add("varchar", Color.Blue);
            reservadas.Add("varbinary", Color.Blue);
            reservadas.Add("null", Color.Blue);
            reservadas.Add("not", Color.Blue);
            reservadas.Add("bigint", Color.Blue);
            reservadas.Add("smallint", Color.Blue);
            reservadas.Add("real", Color.Blue);
            reservadas.Add("float", Color.Blue);
            reservadas.Add("bit", Color.Blue);
            reservadas.Add("decimal", Color.Blue);

            ColorearTexto();
        }

        private void btn_portapapeles_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(txt_codigo.Text, true);
                MessageBox.Show("Se ha enviado el código SQL al portapapeles de Windows con éxito.", "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al copiar texto al portapapeles: " + Environment.NewLine + err.Message, "Error al copiar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<String, Color> reservadas = new Dictionary<string, Color>();

        private void ColorearTexto()
        {
            foreach(String reservada in reservadas.Keys)
            {
                int posicionBusqueda = 0;
                while (posicionBusqueda < txt_codigo.Text.Length)
                {
                    int posTemp = txt_codigo.Find(reservada, posicionBusqueda, RichTextBoxFinds.WholeWord) + reservada.Length;
                    if (posTemp <= posicionBusqueda)
                        break;
                    else
                        posicionBusqueda = posTemp;
                    txt_codigo.SelectionColor = reservadas[reservada];
                }
            }
            txt_codigo.SelectionStart = 0;
            txt_codigo.SelectionLength = 0;
        }

        private void btn_ejecutarEnServidor_Click(object sender, EventArgs e)
        {
            // split script on GO command
            try
            {
                IEnumerable<string> commandStrings = Regex.Split(txt_codigo.Text, @"^\s*GO\s*$",
                                            RegexOptions.Multiline | RegexOptions.IgnoreCase);
            
                foreach (string commandString in commandStrings)
                {
                    if (commandString.Trim() != "")
                    {
                        acceso.EjecutarConsulta(commandString, null);

                    }
                }
                btn_ejecutarEnServidor.Enabled = false;
                MessageBox.Show("Código ejecutado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error al ejecutar en servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
