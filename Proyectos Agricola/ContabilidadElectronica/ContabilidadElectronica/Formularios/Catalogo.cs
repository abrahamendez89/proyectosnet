using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EstructuraContable;
using Herramientas;
using Herramientas.WPF;
using Herramientas.SQL;
using Herramientas.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class Catalogo : Form
    {
        iSQL sql;
        public Catalogo()
        {
            InitializeComponent();
            sql = Login.sql;
            btn_cargarCuentas.customClick += btn_cargarCuentas_customClick;
            btn_Guardar.customClick += btn_Guardar_customClick;
        }

        void btn_Guardar_customClick(ControlesDeUsuario.BotonConImagen boton)
        {
            GuardarCuentas();
        }

        void btn_cargarCuentas_customClick(ControlesDeUsuario.BotonConImagen boton)
        {
            CargarCuentas();
        }

        private void CargarCuentas()
        {
            DataTable dt = sql.EjecutarConsulta("select id, CodAgrup, NumCta, Descripcion, SubCtaDe, Nivel, Naturaleza from empresas..ctl_cuentas_contables_sat");
            dgv_cuentas.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv_cuentas);
                for (int i = 0; i < dt.Columns.Count; i++)
                    row.Cells[i].Value = dr[i];
                dgv_cuentas.Rows.Add(row);
            }
            dgv_cuentas.Refresh();
        }
        private void GuardarCuentas()
        {
            List<CatalogoCuenta> cuentas = new List<CatalogoCuenta>();
            Boolean hayErrores = false;
            if (dgv_cuentas.Rows.Count == 1)
                return;
            for (int i = 0; i < dgv_cuentas.Rows.Count - 1; i++)
            {
                DataGridViewRow dr = dgv_cuentas.Rows[i];
                dr.DefaultCellStyle.BackColor = Color.White;
                dr.DefaultCellStyle.ForeColor = Color.Black;
                try
                {
                    CatalogoCuenta cc = new CatalogoCuenta();
                    if (dr.Cells["ID"].Value != null)
                        cc.ID = (int)dr.Cells["ID"].Value;
                    cc.CodAgrup = (String)dr.Cells["CodAgrup"].Value;
                    cc.NumCuenta = (String)dr.Cells["NumCta"].Value;
                    cc.Descripcion = (String)dr.Cells["Descripcion"].Value;
                    cc.SubCtaDe = (String)dr.Cells["SubCuentaDe"].Value;
                    cc.Nivel = Convert.ToInt32(dr.Cells["Nivel"].Value);
                    cc.Naturaleza = Convert.ToChar(dr.Cells["Naturaleza"].Value);
                    String resu = cc.ValidarDatos();

                    if (!resu.Equals(""))
                    {
                        dr.Cells["Validacion"].Value = "Falla con reglas de SAT: " + resu;
                        dr.DefaultCellStyle.BackColor = Color.Red;
                        dr.DefaultCellStyle.ForeColor = Color.White;
                        hayErrores = true;
                        continue;
                    }
                    dr.Cells["Validacion"].Value = "Datos correctos.";
                    dr.Cells["Validacion"].Style.BackColor = Color.Green;
                    dr.Cells["Validacion"].Style.ForeColor = Color.White;
                    cuentas.Add(cc);

                }
                catch (Exception ex)
                {
                    dr.Cells["Validacion"].Value = "Excepción: " + ex.Message;
                    dr.DefaultCellStyle.BackColor = Color.Red;
                    dr.DefaultCellStyle.ForeColor = Color.White;
                    hayErrores = true;
                }
            }
            if (!hayErrores)
            {
                try
                {
                    sql.IniciarTransaccion();
                    foreach (int eliminado in eliminados)
                    {
                        sql.EjecutarConsulta("delete empresas..ctl_cuentas_contables_sat where id = " + eliminado);
                    }
                    foreach (CatalogoCuenta cuenta in cuentas)
                    {
                        cuenta.Guardar(sql);
                    }
                    sql.TerminarTransaccion();
                    eliminados.Clear();
                    Mensajes.Informacion("Cuentas guardadas exitosamente.");
                    CargarCuentas();
                }
                catch (Exception ex)
                {
                    sql.DeshacerTransaccion();
                    Mensajes.Error("Error: " + ex.Message);
                }
            }
            else
            {
                Mensajes.Error("Hubo errores al validar las cuentas contables, favor de verificar.");
            }

        }
        private List<int> eliminados = new List<int>();
        private void dgv_cuentas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow dr = e.Row;
            if (dr.Cells["ID"].Value != null)
                eliminados.Add((int)dr.Cells["ID"].Value);
        }
    }
}
