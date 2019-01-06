using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class CatalogoBancos : Form
    {
        iSQL sql;
        public CatalogoBancos()
        {
            InitializeComponent();
            this.sql = Login.sql;
            CargarCatalogo();

            dgv_catalogo.CellClick += dgv_catalogo_CellClick;
        }

        void dgv_catalogo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txt_codigo.Text = dgv_catalogo.Rows[e.RowIndex].Cells["Código"].Value.ToString();
            txt_descripcionCorta.Text = dgv_catalogo.Rows[e.RowIndex].Cells["Descripción corta"].Value.ToString();
            txt_descripcionLarga.Text = dgv_catalogo.Rows[e.RowIndex].Cells["Descripción larga"].Value.ToString();
            chb_estaActivo.Checked = Herramientas.Conversiones.Formatos.BooleanStringABoolean(dgv_catalogo.Rows[e.RowIndex].Cells["Está activo"].Value.ToString());
            chb_esBancoNacional.Checked = Herramientas.Conversiones.Formatos.BooleanStringABoolean(dgv_catalogo.Rows[e.RowIndex].Cells["Es banco nacional"].Value.ToString());
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            String queryBuscar = "select CodigoBanco from empresas..elec_catalogo_bancos where CodigoBanco = '"+txt_codigo.Text.Trim()+"'";

            DataTable dt = sql.EjecutarConsulta(queryBuscar);
                            String query = "";

                            List<Object> valores = new List<object>();
            if (dt.Rows.Count > 0)
            {

                query = @"update 
                          empresas..elec_catalogo_bancos
                           set DescripcionCorta = @descripcionCorta	
                          	,DescripcionLarga = @descripcionLarga
                          	,EstaActivo = @estaActivo
                            ,EsBancoNacional = @EsBancoNacional
                          where CodigoBanco = '" + txt_codigo.Text.Trim() + @"'
                        ";
                valores.Add(txt_descripcionCorta.Text.Trim());
                valores.Add(txt_descripcionLarga.Text.Trim());
                valores.Add(chb_estaActivo.Checked);
                valores.Add(chb_esBancoNacional.Checked);
            }
            else
            {
                query = "insert into empresas..elec_catalogo_bancos(CodigoBanco, DescripcionCorta, DescripcionLarga,EstaActivo,EsBancoNacional) values(@codigo, @descripCorta, @descripLarga, @estaActivo, @EsBancoNacional)";
                valores.Add(txt_codigo.Text.Trim());
                valores.Add(txt_descripcionCorta.Text.Trim());
                valores.Add(txt_descripcionLarga.Text.Trim());
                valores.Add(chb_estaActivo.Checked);
                valores.Add(chb_esBancoNacional.Checked);
            }
            try
            {
                sql.EjecutarConsulta(query, valores);
                CargarCatalogo();
                Limpiar();
                Herramientas.Forms.Mensajes.Informacion("Guardado con éxito");
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }
        }
        private void CargarCatalogo()
        {
            String query = "select CodigoBanco as [Código], DescripcionCorta as [Descripción corta], DescripcionLarga as [Descripción larga], estaActivo as [Está activo], EsBancoNacional as [Es banco nacional]  from empresas..elec_catalogo_bancos";
            DataTable dt = sql.EjecutarConsulta(query);
            dgv_catalogo.DataSource = dt;
        }
        private void Limpiar()
        {
            txt_codigo.Text = "";
            txt_descripcionCorta.Text = "";
            txt_descripcionLarga.Text = "";
            chb_estaActivo.Checked = false;
            chb_esBancoNacional.Checked = false;
        }

    }
}
