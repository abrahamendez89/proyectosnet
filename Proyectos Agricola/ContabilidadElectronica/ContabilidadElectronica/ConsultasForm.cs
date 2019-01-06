using ContabilidadElectronica.ControlesDeUsuario;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContabilidadElectronica
{
    public partial class ConsultasForm : Form
    {
        public DataRow DataRowSeleccionado { get; set; }
        String query = "";
        public ConsultasForm(String query, List<String> titulosParametros, List<Type> tiposParametros)
        {
            InitializeComponent();
            this.query = query;
            for (int i = 0; i < titulosParametros.Count; i++)
            {
                ParametroConsultaForm parametro = new ParametroConsultaForm(titulosParametros[i], tiposParametros[i]);
                parametro.Width = pnl_parametros.Width-40;
                pnl_parametros.Controls.Add(parametro);
            }
        }
        DataTable dtResultado;
        private void btn_consultar_Click(object sender, EventArgs e)
        {
            List<Object> valoresParamtros = new List<object>();
            foreach (ParametroConsultaForm parametro in pnl_parametros.Controls)
            {
                valoresParamtros.Add(parametro.Valor);
            }

            iSQL db = Login.sql;
            dtResultado = db.EjecutarConsulta(query, valoresParamtros);
            dgv_resultados.DataSource = dtResultado;
            dgv_resultados.Refresh();

            pnl_consultar.Visible = false;

        }

        private void btn_detalles_Click(object sender, EventArgs e)
        {
            pnl_consultar.Visible = true;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowSeleccionado = dtResultado.Rows[dgv_resultados.SelectedRows[0].Index];
            }
            catch
            {
                DataRowSeleccionado = null;
            }
            Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DataRowSeleccionado = null;
            Hide();
        }
    }
}
