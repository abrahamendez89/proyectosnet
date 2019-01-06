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
    public partial class CatalogoFormasPago : Form
    {
        iSQL sql;
        public CatalogoFormasPago()
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
            txt_descripcion.Text = dgv_catalogo.Rows[e.RowIndex].Cells["Descripción"].Value.ToString();
            chb_estaActivo.Checked = Herramientas.Conversiones.Formatos.BooleanStringABoolean(dgv_catalogo.Rows[e.RowIndex].Cells["Está activo"].Value.ToString());
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            String queryBuscar = "select codigoFormaPago from empresas..ELEC_CATALOGO_FORMAPAGO where codigoFormaPago = '" + txt_codigo.Text.Trim() + "'";

            DataTable dt = sql.EjecutarConsulta(queryBuscar);
                            String query = "";

                            List<Object> valores = new List<object>();
            if (dt.Rows.Count > 0)
            {

                query = @"update 
                          empresas..ELEC_CATALOGO_FORMAPAGO
                           set DescripcionFormaPago = @descripcion	
                          	,EstaActivo = @estaActivo
                          where codigoFormaPago = '" + txt_codigo.Text.Trim() + @"'
                        ";
                valores.Add(txt_descripcion.Text.Trim());
                valores.Add(chb_estaActivo.Checked);
            }
            else
            {
                query = "insert into empresas..ELEC_CATALOGO_FORMAPAGO(codigoFormaPago, DescripcionFormaPago,EstaActivo) values(@codigo, @descrip, @estaActivo)";
                valores.Add(txt_codigo.Text.Trim());
                valores.Add(txt_descripcion.Text.Trim());
                valores.Add(chb_estaActivo.Checked);
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
            String query = "select codigoFormaPago as [Código], DescripcionFormaPago as [Descripción], estaActivo as [Está activo]  from empresas..ELEC_CATALOGO_FORMAPAGO";
            DataTable dt = sql.EjecutarConsulta(query);
            dgv_catalogo.DataSource = dt;
        }
        private void Limpiar()
        {
            txt_codigo.Text = "";
            txt_descripcion.Text = "";
            chb_estaActivo.Checked = false;

        }
    }
}
