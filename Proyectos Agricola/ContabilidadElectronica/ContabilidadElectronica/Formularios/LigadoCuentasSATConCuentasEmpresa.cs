using Herramientas.Forms;
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

namespace ContabilidadElectronica.Formularios
{
    public partial class LigadoCuentasSATConCuentasEmpresa : Form
    {
        iSQL sql;
        private String CuentaPadrePrincipal = "00000000000000000000000000000000000000000000000000";
        public LigadoCuentasSATConCuentasEmpresa()
        {
            InitializeComponent();
            sql = Login.sql;
        }


        private void dgv_ligadoCuentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                List<String> titulos = new List<string>();
                titulos.Add("Descripción");
                titulos.Add("Código agrupador");
                List<Type> tipos = new List<Type>();
                tipos.Add(typeof(String));
                tipos.Add(typeof(double));
                ConsultasForm consulta = new ConsultasForm("select nivel, codAgrupador, descripcionCuenta from empresas..ELEC_CATALOGO_SAT where descripcionCuenta like '%@descripcionCuenta%' and codAgrupador like '%@codAgrupador%'", titulos, tipos);
                consulta.ShowDialog();
                DataRow drSeleccionado = consulta.DataRowSeleccionado;
                consulta.Close();
                if (drSeleccionado != null)
                {
                    dgv_ligadoCuentas.Rows[dgv_ligadoCuentas.SelectedRows[0].Index].Cells[2].Value = drSeleccionado["codAgrupador"];
                    dgv_ligadoCuentas.Rows[dgv_ligadoCuentas.SelectedRows[0].Index].Cells[3].Value = drSeleccionado["descripcionCuenta"];
                }
            }
            else if (e.KeyData == Keys.Delete)
            {
                dgv_ligadoCuentas.Rows[dgv_ligadoCuentas.SelectedRows[0].Index].Cells[2].Value = "-";
                dgv_ligadoCuentas.Rows[dgv_ligadoCuentas.SelectedRows[0].Index].Cells[3].Value = "GUARDAR PARA CONFIRMAR EL BORRADO.";
            }
        }
        DataTable dtResultados;
        private void ConsultarCuentasHijasPorCuentaPadre(String cuentaPadre)
        {
            dgv_ligadoCuentas.Rows.Clear();
            dgv_ligadoCuentas.Refresh();
            iSQL sql = Login.sql;
            String query = "";
            if (cuentaPadre.Equals("00000000000000000000000000000000000000000000000000"))
            {

                query = @"select SUBSTRING(ccuenta_cnt,1,10)+'-'+SUBSTRING(ccuenta_cnt,11,10)+'-'+SUBSTRING(ccuenta_cnt,21,10)+'-'+SUBSTRING(ccuenta_cnt,31,10)+'-'+SUBSTRING(ccuenta_cnt,41,10) as CCUENTA_CNT, CCTA_PADRE, CDESCRIP
                            from cuentas_cnt h
                            where ccuenta_cnt like '__________'+REPLICATE('0',40) and CCUENTA_CNT<>REPLICATE('0',50)";
            }
            else
            {
                query = @"select SUBSTRING(ccuenta_cnt,1,10)+'-'+SUBSTRING(ccuenta_cnt,11,10)+'-'+SUBSTRING(ccuenta_cnt,21,10)+'-'+SUBSTRING(ccuenta_cnt,31,10)+'-'+SUBSTRING(ccuenta_cnt,41,10)as CCUENTA_CNT, CCTA_PADRE, CDESCRIP
                            from cuentas_cnt h
                            where h.ccta_padre='" +cuentaPadre+"'";
            }

            dtResultados = sql.EjecutarConsulta(query);

            foreach (DataRow dr in dtResultados.Rows)
            {
                String queryCon = @"select fon.codigoAgrupadorSAT, sat.descripcionCuenta 
                                from ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT fon inner join 
                                empresas..ELEC_CATALOGO_SAT sat on fon.codigoAgrupadorSAT = sat.codAgrupador
                                where fon.codigoCuentaInterna = @codigoCuentaInterna";
                DataTable temp = sql.EjecutarConsulta(queryCon, new List<object>() { dr["CCUENTA_CNT"].ToString().Replace("-","") });
                if (temp.Rows.Count == 0)
                    dgv_ligadoCuentas.Rows.Add(dr["CCUENTA_CNT"], dr["CDESCRIP"], "", "");
                else
                    dgv_ligadoCuentas.Rows.Add(dr["CCUENTA_CNT"], dr["CDESCRIP"], temp.Rows[0]["codigoAgrupadorSAT"], temp.Rows[0]["descripcionCuenta"]);
            }
        }
        private void btn_consultarCuentasInternas_Click(object sender, EventArgs e)
        {
            ConsultarCuentasHijasPorCuentaPadre(CuentaPadrePrincipal);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                sql.IniciarTransaccion();
                for (int i = 0; i < dgv_ligadoCuentas.Rows.Count; i++)
                {
                    String codigoCuenta = dgv_ligadoCuentas.Rows[i].Cells[0].Value.ToString().Replace("-","");

                    String codigoCuentaPadre = dtResultados.Rows[i]["CCTA_PADRE"].ToString();

                    String agrupadorSat = dgv_ligadoCuentas.Rows[i].Cells[2].Value.ToString();


                    if (agrupadorSat.Equals("-"))
                    {
                        String queryBorrado = @"delete ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT where codigoCuentaInterna = @codigoCuentaInterna";
                        sql.EjecutarConsulta(queryBorrado, new List<object>() { codigoCuenta });
                        continue;
                    }

                    if (!agrupadorSat.Equals(""))
                    {

                        String select = "select * from ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT where codigoCuentaInterna = @codigoCuentaInterna";

                        DataTable temp = sql.EjecutarConsulta(select, new List<object>() { codigoCuenta });
                        String queryGuardar = "";
                        if (temp.Rows.Count > 0)
                        {
                            queryGuardar = "update ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT set codigoCuentaInterna = @codigoCuentaInterna, codigoCuentaPadre = @codigoCuentaPadre, codigoAgrupadorSAT = @codigoAgrupadorSAT where codigoCuentaInterna = @identificador";

                            sql.EjecutarConsulta(queryGuardar, new List<object>() { codigoCuenta, codigoCuentaPadre, agrupadorSat, codigoCuenta });

                        }
                        else
                        {
                            queryGuardar = "insert ELEC_CATALOGO_CUENTAS_INTERNAS_CON_SAT(codigoCuentaInterna, codigoCuentaPadre, codigoAgrupadorSAT) values(@codigoCuentaInterna, @codigoCuentaPadre, @codigoAgrupadorSAT)";

                            sql.EjecutarConsulta(queryGuardar, new List<object>() { codigoCuenta, codigoCuentaPadre, agrupadorSat });

                        }
                    }
                }
                sql.TerminarTransaccion();
                Mensajes.Informacion("Se guardaron las cuentas modificadas.");
            }
            catch (Exception ex)
            {
                sql.DeshacerTransaccion();
                Mensajes.Error(ex.Message);
            }
        }

        private void btn_subirCuentaPadre_Click(object sender, EventArgs e)
        {
            String codigoCuentaPadre = "";
            btn_guardar_Click(null, null);

            if (dgv_ligadoCuentas.SelectedRows.Count == 0)
            {
                codigoCuentaPadre = UltimaCuentaPadre;
            }
            else
            {
                int rowSeleccionado = dgv_ligadoCuentas.SelectedRows[0].Index;

                codigoCuentaPadre = dtResultados.Rows[rowSeleccionado]["CCTA_PADRE"].ToString().Replace("-","");
            }

            String queryCuentaPadreDelPadre = @"select CCTA_PADRE
                                                from cuentas_cnt h
                                                where h.CCUENTA_CNT='"+codigoCuentaPadre+"'";

            DataTable dtTempPadre = sql.EjecutarConsulta(queryCuentaPadreDelPadre);

            if (dtTempPadre.Rows.Count > 0)
            {
                ConsultarCuentasHijasPorCuentaPadre(dtTempPadre.Rows[0][0].ToString());
            }
        }
        private String UltimaCuentaPadre = "";
        private void dgv_ligadoCuentas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btn_guardar_Click(null, null);

            int rowSeleccionado = dgv_ligadoCuentas.SelectedRows[0].Index;

            String codigoCuenta = dgv_ligadoCuentas.Rows[rowSeleccionado].Cells[0].Value.ToString().Replace("-","");

            UltimaCuentaPadre = codigoCuenta;

            ConsultarCuentasHijasPorCuentaPadre(codigoCuenta);
        }
    }
}
