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
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ContabilidadElectronica.Formularios
{
    public partial class CargarCatalogoSatDeExcel : Form
    {
        String tabla;
        int numeroDeHoja;
        List<String> columnas;
        List<String> columnasDescripcion;

        String columnasConsulta;
        String columnasConsultaArrobas;

        public CargarCatalogoSatDeExcel(String tabla, int numeroDeHoja, List<String> columnas, List<String> columnasDescripcion)
        {
            InitializeComponent();

            this.tabla = tabla;
            this.numeroDeHoja = numeroDeHoja;
            this.columnas = columnas;
            this.columnasDescripcion = columnasDescripcion;


            foreach (String columna in columnas)
            {
                columnasConsulta += columna + ", ";
                columnasConsultaArrobas += "@" + columna + ", ";
            }
            columnasConsulta = columnasConsulta.Substring(0, columnasConsulta.Length - 2);
            columnasConsultaArrobas = columnasConsultaArrobas.Substring(0, columnasConsultaArrobas.Length - 2);

            CheckForIllegalCrossThreadCalls = false;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        private void GuardarCatalogoABD()
        {
            //ELEC_CATALOGO_SAT
            if (dt.Rows.Count == 0)
            {
                Mensajes.Exclamacion("Debe cargar un archivo Excel que contenga los registros.");
                return;
            }
            iSQL sql = Login.sql;
            sql.IniciarTransaccion();
            String queryDelete = "delete empresas.."+tabla;
            sql.EjecutarConsulta(queryDelete);
            try
            {
                foreach (DataRow dr in dt.Rows)
                {

                    String query = "insert into empresas.." + tabla + "("+columnasConsulta+") values("+columnasConsultaArrobas+")";

                    List<Object> valores = new List<object>();
                    for(int i = 0; i < columnas.Count; i++)
                        valores.Add(dr[i]);

                    sql.EjecutarConsulta(query, valores);
                }
            }
            catch (Exception ex)
            {
                sql.DeshacerTransaccion();
                Mensajes.Error(ex.Message);
            }
            sql.TerminarTransaccion();
            Mensajes.Informacion("Terminó de subir el catálogo.");
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            txt_rutaArchivo.Text = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo de excel" }, new List<string>() { "xlsx" });
            if (!txt_rutaArchivo.Text.Trim().Equals(""))
            {
                Thread t = new Thread(CargarArchivo);
                t.Start();
            }
        }
        DataTable dt;
        private void CargarArchivo()
        {
            dt = new DataTable();
            btn_buscar.Enabled = false;
            btn_mostrar.Enabled = false;
            btn_guardarBD.Enabled = false;

            foreach (String descripcion in columnasDescripcion)
            {
                dt.Columns.Add(descripcion);
            }

            pb_avance.Value = 0;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string str;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(txt_rutaArchivo.Text.Trim(), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(numeroDeHoja);

            range = xlWorkSheet.UsedRange;


            String[] Anterior = null;
            for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                String[] valores = new string[columnas.Count];

                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    valores[cCnt - 1] = Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value);
                    if (valores[1] != null && valores[1].Equals("703.17"))
                    {

                    }
                }

                if (valores[0] == null)
                {
                    Anterior = valores;
                    continue;
                }
                if (Anterior != null)
                {
                    Anterior[0] = valores[0];
                    valores = Anterior;
                }

                dt.Rows.Add(valores); //valores[0], valores[1], valores[2]);
                Anterior = null;

                pb_avance.Value = (100 * rCnt) / range.Rows.Count;
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            Mensajes.Informacion("Catálogo cargado correctamente.");
            btn_mostrar.Enabled = true;
        }

        private void btn_mostrar_Click(object sender, EventArgs e)
        {
            dgv_catalogo.DataSource = dt;
            dgv_catalogo.Refresh();
            btn_buscar.Enabled = true;
            btn_mostrar.Enabled = false;
            btn_guardarBD.Enabled = true;
        }

        private void btn_guardarBD_Click(object sender, EventArgs e)
        {
            GuardarCatalogoABD();
        }
    }
}
