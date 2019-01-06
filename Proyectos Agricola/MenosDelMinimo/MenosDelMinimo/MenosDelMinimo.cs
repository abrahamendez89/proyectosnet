using Herramientas.Archivos;
using Herramientas.Forms;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenosDelMinimo
{
    public partial class MenosDelMinimo : Form
    {
        Variable variable;
        SQLServer sql;
        public MenosDelMinimo()
        {
            InitializeComponent();
            sql = new SQLServer();
            variable = new Variable("parametros.ini");

            String anterior = (DateTime.Now.Year - 2).ToString().Substring(2, 2) + "-" + (DateTime.Now.Year - 1).ToString().Substring(2, 2);
            String actual = (DateTime.Now.Year - 1).ToString().Substring(2, 2) + "-" + (DateTime.Now.Year).ToString().Substring(2, 2);
            String siguiente = (DateTime.Now.Year).ToString().Substring(2, 2) + "-" + (DateTime.Now.Year + 1).ToString().Substring(2, 2);

            cmb_temporadas.Items.Add(anterior);
            cmb_temporadas.Items.Add(actual);
            cmb_temporadas.Items.Add(siguiente);

            Herramientas.Forms.Validaciones.TextboxSoloNumerosEnteros(txt_semana);

            cmb_temporadas.SelectedItem = variable.ObtenerValorVariable<String>("TEMPORADA");
            txt_semana.Text = variable.ObtenerValorVariable<String>("SEMANA");
            String servidor = variable.ObtenerValorVariable<String>("SERVIDOR");
            String BD = variable.ObtenerValorVariable<String>("BD");
            String usuario = variable.ObtenerValorVariable<String>("USUARIO");
            String contra = variable.ObtenerValorVariable<String>("CONTRASEÑA");

            try
            {
                sql.ConfigurarConexion(servidor, BD, usuario, contra);
            }
            catch (Exception ex)
            {
                sql = null;
                Herramientas.Forms.Mensajes.Error(ex.Message);
            }

        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            if (sql == null)
            {
                Herramientas.Forms.Mensajes.Error("Ocurrió un error con la conexión a la base de datos.");
                return;
            }

            if (cmb_temporadas.SelectedItem == null)
            {
                Herramientas.Forms.Mensajes.Advertencia("Selecciona una temporada.");
                return;
            }
            if (txt_semana.Text.Trim().Equals(""))
            {
                Herramientas.Forms.Mensajes.Advertencia("Introduce una semana.");
                return;
            }

            variable.GuardarValorVariable("TEMPORADA", cmb_temporadas.SelectedItem.ToString());
            variable.GuardarValorVariable("SEMANA", txt_semana.Text.Trim());
            variable.ActualizarArchivo();

            String query = Herramientas.Archivos.Archivo.LeerArchivoTexto(Environment.CurrentDirectory + "\\query.txt");

            if (query == null)
            {
                Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(Environment.CurrentDirectory+"\\query.txt","");
                Herramientas.Forms.Mensajes.Advertencia("Guarde el query en el archivo 'query.txt'.");
                return;
            }

            if (!query.Contains("@TEMPORADA") || !query.Contains("@SEMANA"))
            {
                Herramientas.Forms.Mensajes.Advertencia("El query requiere que exista la variable '@TEMPORADA' y '@SEMANA', requiere configuración.");
                return;
            }

            query = query.Replace("@TEMPORADA", cmb_temporadas.SelectedItem.ToString()).Replace("@SEMANA", txt_semana.Text);


//            String query = @"
//                            SELECT N.CCVE_EMPL, 
//	                        MAX(N.NIMP_DIA1+N.NANT_DIA1+NSEP_DIA1+NPROD_DIA1)-SUM(CASE WHEN CDIA=1 THEN S.NIMPORTE ELSE 0 END) AS DIA1,
//	
//	                        MAX(N.NIMP_DIA2+N.NANT_DIA2+NSEP_DIA2+NPROD_DIA2)-SUM(CASE WHEN CDIA=2 THEN S.NIMPORTE ELSE 0 END) AS DIA2,
//	
//	                        MAX(N.NIMP_DIA3+N.NANT_DIA3+NSEP_DIA3+NPROD_DIA3)-SUM(CASE WHEN CDIA=3 THEN S.NIMPORTE ELSE 0 END) AS DIA3,
//	
//	                        MAX(N.NIMP_DIA4+N.NANT_DIA4+NSEP_DIA4+NPROD_DIA4)-SUM(CASE WHEN CDIA=4 THEN S.NIMPORTE ELSE 0 END) AS DIA4,		
//
//	                        MAX(N.NIMP_DIA5+N.NANT_DIA5+NSEP_DIA5+NPROD_DIA5)-SUM(CASE WHEN CDIA=5 THEN S.NIMPORTE ELSE 0 END) AS DIA5,
//	
//	                        MAX(N.NIMP_DIA6+N.NANT_DIA6+NSEP_DIA6+NPROD_DIA6)-SUM(CASE WHEN CDIA=6 THEN S.NIMPORTE ELSE 0 END) AS DIA6,
//	
//	                        MAX(N.NIMP_DIA7+N.NANT_DIA7+NSEP_DIA7+NPROD_DIA7)-SUM(CASE WHEN CDIA=7 THEN S.NIMPORTE ELSE 0 END) AS DIA7
//
//                        FROM NOM_REAL N
//                        JOIN NOM_SUELDOS S ON N.CCVE_TEMPORADA=S.CCVE_TEMPORADA AND N.CCVE_NOMINA=S.CCVE_NOMINA AND N.CSEMANA=S.CSEMANA AND N.CCVE_EMPL=S.CCVE_EMPL
//                        WHERE N.CCVE_TEMPORADA = '"+cmb_temporadas.SelectedItem.ToString()+@"' AND N.CCVE_NOMINA='01' AND N.CSEMANA='"+txt_semana.Text+@"' --and substring(CCVE_COS,9,4) not in ('4501') --and n.CCVE_EMPL in (60127,60674,60712,60763,60781,61549,71048,71188,71714,71803,71900,71994,72052,72087,72095,72133,72168)
//                        GROUP BY N.CCVE_EMPL
//                        HAVING (
//		                        (MAX(N.NIMP_DIA1+N.NANT_DIA1+NSEP_DIA1+NPROD_DIA1)<>SUM(CASE WHEN CDIA=1 THEN S.NIMPORTE ELSE 0 END))
//		                        OR
//		                        (MAX(N.NIMP_DIA2+N.NANT_DIA2+NSEP_DIA2+NPROD_DIA2)<>SUM(CASE WHEN CDIA=2 THEN S.NIMPORTE ELSE 0 END))
//		                        OR
//		                        (MAX(N.NIMP_DIA3+N.NANT_DIA3+NSEP_DIA3+NPROD_DIA3)<>SUM(CASE WHEN CDIA=3 THEN S.NIMPORTE ELSE 0 END))
//		                        OR
//		                        (MAX(N.NIMP_DIA4+N.NANT_DIA4+NSEP_DIA4+NPROD_DIA4)<>SUM(CASE WHEN CDIA=4 THEN S.NIMPORTE ELSE 0 END))		
//		                        OR
//		                        (MAX(N.NIMP_DIA5+N.NANT_DIA5+NSEP_DIA5+NPROD_DIA5)<>SUM(CASE WHEN CDIA=5 THEN S.NIMPORTE ELSE 0 END))
//		                        OR
//		                        (MAX(N.NIMP_DIA6+N.NANT_DIA6+NSEP_DIA6+NPROD_DIA6)<>SUM(CASE WHEN CDIA=6 THEN S.NIMPORTE ELSE 0 END))
//		                        OR
//		                        (MAX(N.NIMP_DIA7+N.NANT_DIA7+NSEP_DIA7+NPROD_DIA7)<>SUM(CASE WHEN CDIA=7 THEN S.NIMPORTE ELSE 0 END))
//		                        )
//
//                        ORDER BY N.CCVE_EMPL
//                            ";

            DataTable dt = sql.EjecutarConsulta(query);
            dgv_datos.DataSource = dt;
        }

        private void btn_enviarExcel_Click(object sender, EventArgs e)
        {
            if (dgv_datos.Rows.Count == 0)
            {
                Herramientas.Forms.Mensajes.Exclamacion("No hay datos para exportar.");
                return;
            }
            String ruta = Herramientas.Archivos.Dialogos.GuardarArchivoRuta(new List<string>() { "Archivo de excel." }, new List<string>() { "xls" }, "MENOS_DEL_MINIMO_TEMPORADA_"+cmb_temporadas.SelectedItem.ToString()+"_SEMANA_"+txt_semana.Text.Trim()+"_V_"+Herramientas.Conversiones.Formatos.DateTimeAFechaLOGArchivo(DateTime.Now)+".xls");
            if (ruta != null)
            {
                ExcelAPI excel = new ExcelAPI();
                excel.terminoConversion += excel_terminoConversion;
                excel.ConvertirDataGridViewAExcel(ruta, dgv_datos, Color.Orange, Color.Black);
            }
        }

        void excel_terminoConversion(string rutaGuardado)
        {
            Herramientas.Forms.Mensajes.Exclamacion("Archivo enviado a: "+rutaGuardado+".");
        }
    }
}
