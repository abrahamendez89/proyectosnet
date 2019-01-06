using CompresorImagenes.Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompresorImagenes
{
    public partial class ConvertidorTablas : Form
    {
        Variable var;
        SQLServer sql;
        public ConvertidorTablas()
        {
            InitializeComponent();
            var = new Variable("data.conf");
            CargarDatosDeArchivo();
            this.FormClosed += Form1_FormClosed;
            btn_ejecutar.Click += btn_ejecutar_Click;
            btn_conectar.Click += btn_conectar_Click;
            btn_test.Click += btn_test_Click;

            pb_de.Click += pb_de_Click;
            pb_hacia.Click += pb_hacia_Click;
        }

        void pb_hacia_Click(object sender, EventArgs e)
        {
            VisorImagenes visor = new VisorImagenes((Bitmap)pb_hacia.Image);
            visor.ShowDialog();
        }

        void pb_de_Click(object sender, EventArgs e)
        {
            VisorImagenes visor = new VisorImagenes((Bitmap)pb_de.Image);
            visor.ShowDialog();
        }
        int wNuevo = 0;
        int hNuevo = 0;
        void btn_test_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "Select top 1 " + txt_condiciones.Text.Trim() + "," + txt_campoImagen.Text.Trim() + " from " + txt_tabla.Text.Trim();
                if (!txt_condicionWhere.Text.Trim().Equals(""))
                {
                    query += " where " + txt_condicionWhere.Text.Trim().Replace("where", "");
                }
                DataTable data = sql.EjecutarConsulta(query);

                String query2 = "select count(*) from " + txt_tabla.Text.Trim();
                if (!txt_condicionWhere.Text.Trim().Equals(""))
                {
                    query2 += " where " + txt_condicionWhere.Text.Trim().Replace("where", "");
                }
                DataTable data2 = sql.EjecutarConsulta(query2);

                int contadorTotal = Convert.ToInt32(data2.Rows[0][0]);
                if (data.Rows.Count == 0)
                {
                    MensajeError("No hay registros con la condición dada.");
                    return;
                }
                if (data.Rows[0][txt_campoImagen.Text.Trim()] == DBNull.Value)
                {
                    MensajeError("El valor de " + txt_campoImagen.Text.Trim() + " es NULL. Use otra condición de filtrado.");
                    return;
                }
                byte[] photo = (byte[])data.Rows[0][txt_campoImagen.Text.Trim()];
                MemoryStream ms = new MemoryStream(photo);
                Bitmap bm = new Bitmap(ms);
                ms.Close();
                pb_de.Image = bm;
                lbl_tamDe.Text = (photo.Length / 1024d / 1024d).ToString("0.##") + " MB";

                int factor = 1;
                int resolucionMeta = Convert.ToInt32(txt_ancho.Text.Trim());
                wNuevo = bm.Width / factor;
                hNuevo = bm.Height / factor;
                while (wNuevo > resolucionMeta)
                {
                    wNuevo = bm.Width / factor;
                    hNuevo = bm.Height / factor;

                    factor++;
                }

                Bitmap transformada = ComprimirImagen(bm, wNuevo, hNuevo, ImageFormat.Jpeg);
                Byte[] bytesTransformada = imageToByteArray(transformada);
                pb_hacia.Image = transformada;
                lbl_tamA.Text = (bytesTransformada.Length / 1024d / 1024d).ToString("0.##") + " MB";
                MensajeInformacion("Se encontraron " + contadorTotal + " registros y se selecciono el primero para la vista previa.");
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }

        void btn_conectar_Click(object sender, EventArgs e)
        {
            ConectarBD();
        }

        void btn_ejecutar_Click(object sender, EventArgs e)
        {
            DataTable data = ObtenerDatosTabla();
            if (data.Rows.Count == 0)
            {
                MensajeError("No hay registros con la condición dada.");
                return;
            }
            ProcesarImagenes(data);

        }
        private void ConectarBD()
        {
            try
            {

                if (!txt_servidor.Text.Trim().Equals("") && !txt_bd.Text.Trim().Equals("") && !txt_usuario.Text.Trim().Equals("") && !txt_contraseña.Text.Trim().Equals(""))
                {
                    String cadenaConexion = "data source = @Servidor; initial catalog = @BD; user id = @Usuario; password = @Contraseña";
                    cadenaConexion = cadenaConexion.Replace("@Servidor", txt_servidor.Text.Trim()).Replace("@BD", txt_bd.Text.Trim()).Replace("@Usuario", txt_usuario.Text.Trim()).Replace("@Contraseña", txt_contraseña.Text.Trim());
                    sql = new SQLServer(cadenaConexion);
                    sql.AbrirConexion();
                    MensajeInformacion("Conexión exitosa a la BD.");
                }
                else
                {
                    MensajeError("Es necesario especificar los datos de conexión del servidor.");
                }
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
            }
        }
        private void MensajeInformacion(String mensaje)
        {
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lb_resultados.Items.Add("Información: " + mensaje);
        }
        private void MensajeError(String mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lb_resultados.Items.Add("Error: "+mensaje);
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuardarDatosAArchivo();
        }
        private void CargarDatosDeArchivo()
        {
            //txt_alto.Text = var.ObtenerValorVariable<String>("txt_alto");
            txt_ancho.Text = var.ObtenerValorVariable<String>("txt_ancho");
            txt_bd.Text = var.ObtenerValorVariable<String>("txt_bd");
            txt_campoImagen.Text = var.ObtenerValorVariable<String>("txt_campoImagen");
            txt_condiciones.Text = var.ObtenerValorVariable<String>("txt_condiciones");
            txt_contraseña.Text = var.ObtenerValorVariable<String>("txt_contraseña");
            txt_servidor.Text = var.ObtenerValorVariable<String>("txt_servidor");
            txt_tabla.Text = var.ObtenerValorVariable<String>("txt_tabla");
            txt_usuario.Text = var.ObtenerValorVariable<String>("txt_usuario");
            txt_condicionWhere.Text = var.ObtenerValorVariable<String>("txt_condicionWhere");
            ConectarBD();
        }
        private void GuardarDatosAArchivo()
        {
            //var.GuardarValorVariable("txt_alto", txt_alto.Text);
            var.GuardarValorVariable("txt_ancho", txt_ancho.Text);
            var.GuardarValorVariable("txt_bd", txt_bd.Text);
            var.GuardarValorVariable("txt_campoImagen", txt_campoImagen.Text);
            var.GuardarValorVariable("txt_condiciones", txt_condiciones.Text);
            var.GuardarValorVariable("txt_contraseña", txt_contraseña.Text);
            var.GuardarValorVariable("txt_servidor", txt_servidor.Text);
            var.GuardarValorVariable("txt_tabla", txt_tabla.Text);
            var.GuardarValorVariable("txt_usuario", txt_usuario.Text);
            var.GuardarValorVariable("txt_condicionWhere", txt_condicionWhere.Text);
        }


        private DataTable ObtenerDatosTabla()
        {

            String query = "Select " + txt_condiciones.Text.Trim() + "," + txt_campoImagen.Text.Trim() + " from " + txt_tabla.Text.Trim();

            if (!txt_condicionWhere.Text.Trim().Equals(""))
            {
                query += " where " + txt_condicionWhere.Text.Trim().Replace("where", "");
            }

            DataTable data = sql.EjecutarConsulta(query);
            return data;
        }

        private void ProcesarImagenes(DataTable data)
        {
            try
            {
                
                int contadorModificados = 0;
                foreach (DataRow dr in data.Rows)
                {
                    List<Object> parametros = new List<object>();

                    if (dr[txt_campoImagen.Text.Trim()] == DBNull.Value)
                        continue;
                    contadorModificados++;
                    byte[] photo = (byte[])dr[txt_campoImagen.Text.Trim()];
                    MemoryStream ms = new MemoryStream(photo);
                    Bitmap bm = new Bitmap(ms);
                    ms.Close();


                    int factor = 1;
                    int resolucionMeta = Convert.ToInt32(txt_ancho.Text.Trim());
                    wNuevo = bm.Width / factor;
                    hNuevo = bm.Height / factor;
                    while (wNuevo > resolucionMeta)
                    {
                        wNuevo = bm.Width / factor;
                        hNuevo = bm.Height / factor;

                        factor++;
                    }


                    Bitmap transformada = ComprimirImagen(bm, wNuevo, hNuevo, ImageFormat.Jpeg);

                    Byte[] bytesTransformada = imageToByteArray(transformada);

                    parametros.Add(bytesTransformada);

                    String queryUpdate = "update " + txt_tabla.Text.Trim() + " set ";

                    queryUpdate += txt_campoImagen.Text.Trim() + " = @" + txt_campoImagen.Text.Trim();

                    queryUpdate += " where ";

                    String[] camposIdentidad = txt_condiciones.Text.Trim().Split(',');

                    foreach (String identidad in camposIdentidad)
                    {
                        queryUpdate += identidad.Trim() + " = @" + identidad.Trim() + " and ";
                        parametros.Add(dr[identidad.Trim()]);
                    }
                    queryUpdate = queryUpdate.Substring(0, queryUpdate.Length - 5);
                    sql.EjecutarConsulta(queryUpdate, parametros);
                }
                MensajeInformacion("La consulta regresó "+data.Rows.Count+" registros de los cuales se procesaron " + contadorModificados + " imagenes.");
                
            }
            catch (Exception ex)
            {
                MensajeError(ex.Message);
                
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static Bitmap ComprimirImagen(Bitmap imagenAComprimir, int ancho, int alto, ImageFormat formato)
        {
            if (imagenAComprimir == null) return null;
            Bitmap imagenConvertida = (Bitmap)((System.Drawing.Image)imagenAComprimir.GetThumbnailImage(ancho, alto, delegate { return false; }, System.IntPtr.Zero));
            MemoryStream ms = new MemoryStream();

            imagenConvertida.Save(ms, formato);

            return (Bitmap)Bitmap.FromStream(ms);
            //return imagenConvertida;
        }

    }
}
