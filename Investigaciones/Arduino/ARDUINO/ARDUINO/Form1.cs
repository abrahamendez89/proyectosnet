using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace ARDUINO
{
    public partial class Form1 : Form
    {
        String funcion = "T";
        char[] notas = { 'c', 'd', 'e', 'f', 'g', 'a', 'b', 'C'};

        public Form1()
        {
            InitializeComponent();
            rdb_TODOS.Checked = true;
        }

        private void btn_NotaMusical_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            EnviarComando("Z" + b.Tag.ToString() + "\n");
            txt_notas.Text += b.Text;
        }
        private void btn_enviarNotas_Click(object sender, EventArgs e)
        {
            char[] chars = txt_notas.Text.ToCharArray();
            String textoEnviar = "X";
            foreach (char c in chars)
            {
                if (c == ' ')
                {
                    textoEnviar += ' ';
                    continue;
                }
                for (int i = 0; i < notas.Length; i++)
                {
                    if (notas[i] == c)
                    {
                        textoEnviar += i;
                        break;
                    }
                }
            }
            textoEnviar += "\n";
            EnviarComando(textoEnviar);
        }
        private void EnviarComando(String comando)
        {
            try
            {
                byte[] mBuffer = Encoding.ASCII.GetBytes(comando);
                serialPort1.Write(mBuffer, 0, mBuffer.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_CambiarColorLed_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            btn_CambiarColorLed.BackColor = colorDialog1.Color;
            String r = Convert.ToInt32(colorDialog1.Color.R).ToString("000");
            String g = Convert.ToInt32(colorDialog1.Color.G).ToString("000");
            String b = Convert.ToInt32(colorDialog1.Color.B).ToString("000");
            String instruccion = "C" + r + g + b + "\n";
            EnviarComando(instruccion);
        }

        private void btn_EncenderApagarLed_Click(object sender, EventArgs e)
        {
            String comando = "";
            if (btn_EncenderApagarLed.Text.Equals("Encender"))
            {
                comando = "O1" + "\n";
                btn_EncenderApagarLed.Text = "Apagar";
            }
            else if (btn_EncenderApagarLed.Text.Equals("Apagar"))
            {
                comando = "O0" + "\n";
                btn_EncenderApagarLed.Text = "Encender";
            }
            EnviarComando(comando);
        }

        private void rdb_LED_CheckedChanged(object sender, EventArgs e)
        {
            funcion = "L";

            tb_Intensidad.Minimum = 0;
            tb_Intensidad.Maximum = 767;
        }

        private void rdb_MOTOR_CheckedChanged(object sender, EventArgs e)
        {
            funcion = "M";
            tb_Intensidad.Minimum = 0;
            tb_Intensidad.Maximum = 255;
        }

        private void rdb_TODOS_CheckedChanged(object sender, EventArgs e)
        {
            funcion = "T";
            tb_Intensidad.Minimum = 0;
            tb_Intensidad.Maximum = 255;
        }

        private void tb_Intensidad_ValueChanged(object sender, EventArgs e)
        {
            int valor = tb_Intensidad.Value;
            EnviarComando(funcion + tb_Intensidad.Value.ToString() + "\n");
        }

        private void btn_Cancion1_Click(object sender, EventArgs e)
        {
            txt_notas.Text = "eefggfedccdeedd eefggfedccdedcc ddecdefecdefe";
        }

        private void btn_Cancion2_Click(object sender, EventArgs e)
        {
            txt_notas.Text = "gageCag gagagCb fgfdbag";
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            if (txt_portName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Escriba un puerto.");
                return;
            }
            serialPort1.PortName = txt_portName.Text.Trim();
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    MessageBox.Show("Conexión correcta.");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("El puerto es incorrecto.");
                }
            }
        }

        private void tb_Horizontal_ValueChanged(object sender, EventArgs e)
        {
            String comando = "H" + tb_Horizontal.Value + "\n";
            EnviarComando(comando);
        }

        private void tb_Vertical_ValueChanged(object sender, EventArgs e)
        {
            String comando = "V" + tb_Vertical.Value +"\n";
            EnviarComando(comando);
        }
    }
}
