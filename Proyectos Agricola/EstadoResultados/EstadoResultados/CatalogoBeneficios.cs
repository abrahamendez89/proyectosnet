using Herramientas.SQL;
using Herramientas.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EstadoResultados
{
    public partial class CatalogoBeneficios : Form
    {
        DBAcceso dbAcceso;
        public CatalogoBeneficios()
        {
            InitializeComponent();
            txt_id.Enabled = false;
            dbAcceso = DBAcceso.ObtenerInstancia();
            lb_beneficiosGuardados.MouseClick += lb_beneficiosGuardados_MouseClick;
            btn_guardar.Click += btn_guardar_Click;
            CargarBeneficiosCatalogo();
        }

        void btn_guardar_Click(object sender, EventArgs e)
        {
            Guardar();
            CargarBeneficiosCatalogo();
        }

        void lb_beneficiosGuardados_MouseClick(object sender, MouseEventArgs e)
        {
            if (lb_beneficiosGuardados.SelectedItem != null)
            {
                String seleccionado = lb_beneficiosGuardados.SelectedItem.ToString();
                String[] partes = seleccionado.Split('-');
                txt_id.Text = partes[0].Trim();
                txt_nombreBeneficio.Text = partes[1].Trim();
            }
        }

        private void CargarBeneficiosCatalogo()
        {
            lb_beneficiosGuardados.Items.Clear();
            String queryBeneficios = "select * from tb_beneficios";
            DataTable dt = dbAcceso.EjecutarConsulta(queryBeneficios);

            foreach (DataRow dr in dt.Rows)
            {
                lb_beneficiosGuardados.Items.Add(dr["id"] + " - " + dr["cNombreBeneficio"]); 
            }

        }
        private void Guardar()
        {
            try
            {
                String id = txt_id.Text;
                String nombre = txt_nombreBeneficio.Text;

                String query = "";
                List<Object> parametros = new List<object>();
                if (txt_id.Text.Trim().Equals(""))
                {
                    // es nuevo
                    query = "insert into tb_beneficios(cNombreBeneficio) values(@valor)";
                    parametros.Add(txt_nombreBeneficio.Text.Trim());
                }
                else
                {
                    // es actualizacion
                    query = "update tb_beneficios set cNombreBeneficio = @nombreBeneficio where id = @id";
                    parametros.Add(txt_nombreBeneficio.Text.Trim());
                    parametros.Add(Convert.ToInt32(txt_id.Text.Trim()));
                }

                dbAcceso.EjecutarConsulta(query, parametros);

                Mensajes.Informacion("Beneficio guardado correctamente.");
            }
            catch (Exception ex)
            {
                Mensajes.Error("Error: " + ex.Message);
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_nombreBeneficio.Text = "";
        }
    }
}
