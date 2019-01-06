using Herramientas.Archivos;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EstadoResultados
{
    public partial class AgendadoServicioEstadoResultados : Form
    {
        Variable vars;
        public AgendadoServicioEstadoResultados()
        {
            InitializeComponent();
            vars = new Variable("data");
            int diaSemana = vars.ObtenerValorVariable<Int32>("DiaSemana");
            int hora = vars.ObtenerValorVariable<Int32>("horaDia24H");
            int minuto = vars.ObtenerValorVariable<Int32>("minutoDia24H");
            chb_todosLosDias.Checked = ConvierteTextoABoolean(vars.ObtenerValorVariable<String>("ejecutarTodosDias"));

            for (int i = 0; i < 60; i++)
            {
                cmb_minuto.Items.Add(i.ToString("00"));
            }
            for (int i = 0; i < 24; i++)
            {
                cmb_hora.Items.Add(i.ToString("00"));
            }

            cmb_hora.SelectedItem = hora.ToString("00");
            cmb_minuto.SelectedItem = minuto.ToString("00");
            if(diaSemana != 0) cmb_dia.SelectedIndex = diaSemana - 1;

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                vars.GuardarValorVariable("DiaSemana", (cmb_dia.SelectedIndex+1).ToString());
                vars.GuardarValorVariable("horaDia24H", (cmb_hora.SelectedItem).ToString());
                vars.GuardarValorVariable("minutoDia24H", (cmb_minuto.SelectedItem).ToString());
                vars.GuardarValorVariable("ejecutarTodosDias", ConvierteBooleanATexto(chb_todosLosDias.Checked));
                vars.ActualizarArchivo();
                Mensajes.Informacion("Se ha guardado los emails correctamente.");
            }
            catch (Exception ex)
            {
                Mensajes.Error("Error al intentar guardar: " + ex.Message);
            }
        }
        public static String ConvierteBooleanATexto(Boolean valor)
        {
            if (valor) return "SI";
            else return "NO";
        }
        public static Boolean ConvierteTextoABoolean(String valor)
        {
            if (valor != null && valor.Trim().ToUpper().Equals("SI")) return true;
            else return false;
        }
    }
}
