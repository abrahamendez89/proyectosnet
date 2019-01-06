using Controladores;
using Dominio;
using Herramientas.ORM;
using Herramientas.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HotelAdmin
{
    public partial class Principal : Form
    {
        public static iSQL sql;
        public static ManejadorDB manejador;
        //controladores
        public static MenuCtrl menuCtrl;
        public static UsuarioCtrl usuarioCtrl;
        public Principal()
        {
            InitializeComponent();

            //creando la conexion a la bd
            try
            {
                sql = new MySQL();
                sql.ConfigurarConexion("127.0.0.1", "hoteladmin", "root", "12345");
                manejador = new ManejadorDB(sql);
                InicializaControladores();
                Login();
            }
            catch(Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Ocurrio un error al conectarse a la Base de datos: " + ex.Message);
                
            }
            tp_forms.Visible = false;
            //pb_cerrarTab.Visible = false;
        }
        private void InicializaControladores()
        {
            menuCtrl = new MenuCtrl(manejador);
            usuarioCtrl = new UsuarioCtrl(manejador);
        }
        private void Login()
        {
            menu.Items.Clear();
            _Usuario usuario = null;

            Login lo = new Login();
            lo.ShowDialog();

            usuario = lo.UsuarioLogueado;
            lo.Close();
            usuario.DtFechaModificacion = DateTime.Now;
            usuario.EsModificado = true;
            usuario.Ll_modulos.Add(usuario.Ll_modulos[0]);

            //Bitmap fotoCam = Herramientas.WebCam.Foto.ObtenerFotoDeWebCam();

            String json = usuario.ConvertirAJson(2);
            _Usuario user = _Usuario.ConvertirDeJson<_Usuario>(json);

            //Padre padre = new Padre();
            //padre.Edad = 10;
            //padre.Nombre = "nombre";
            //padre.Hijo = new Hijo();
            //padre.Hijo.Otro = "asdasd";

            //String json2 = Herramientas.Web.JSON.ConvertirObjetoAJSON<Padre>(padre, 2);
            //Padre padre2 = Herramientas.Web.JSON.ConvertirJSONAObjeto<Padre>(json2);

            if (usuario != null)
            {
                CargarMenuPermisos(usuario);
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private void CargarMenuPermisos(_Usuario usuario)
        {
            foreach (_ModuloAcceso modulo in usuario.Ll_modulos)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = modulo.St_nombreModulo;
                foreach (String forma in menuCtrl.ObtenerMenuPorModulo(modulo.St_formasPermisos))
                {
                    ToolStripDropDownItem ti = new ToolStripMenuItem();
                    ti.Text = forma.Split('|')[0];
                    ti.Tag = forma.Split('|')[1];
                    ti.Click += ti_Click;
                    mi.DropDownItems.Add(ti);
                }
                menu.Items.Add(mi);
            }
        }

        void ti_Click(object sender, EventArgs e)
        {
            String titulo = ((ToolStripDropDownItem)sender).Text.ToString();
            String forma = ((ToolStripDropDownItem)sender).Tag.ToString();
            AgregarFormulario(CrearFormulario(forma), titulo);
        }
        #region manejo de formularios
        void pb_cerrarTab_MouseClick(object sender, MouseEventArgs e)
        {
            CerrarFormularioActual();
        }
        List<String> tabsNames = new List<string>();

        private Form CrearFormulario(String referencia)
        {
            try
            {
                Type formType = Type.GetType(referencia);
                Form nextForm2 = (Form)Activator.CreateInstance(formType);
                return nextForm2;
            }
            catch
            {
                Herramientas.Forms.Mensajes.Error("Ocurrió un error al cargar la forma.");
                return null;
            }
        }

        private void AgregarFormulario(Form formulario, String titulo)
        {
            if (formulario == null)
                return;
            formulario.Text = titulo;
            //if (cmb_Empresas.SelectedIndex == -1)
            //{
            //    Mensajes.Exclamacion("Debe seleccionar primero una empresa.");
            //    return;
            //}
            try
            {

                if (tabsNames.Contains(formulario.Text))
                    return;
            }
            catch { }

            TabPage tp = new TabPage(formulario.Text);
            tabsNames.Add(formulario.Text);

            foreach (String nombreTab in tabsNames)
            {

            }


            Boolean maximizado = false;
            if (formulario.WindowState == FormWindowState.Maximized)
                maximizado = true;

            tp_forms.Visible = true;
            pb_cerrarTab.Visible = true;
            Panel contenedor = new Panel();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.StartPosition = FormStartPosition.CenterParent;
            tp.AutoScroll = true;


            contenedor.Location = new Point((tp_forms.Size.Width - formulario.Size.Width) / 2, (tp_forms.Size.Height - formulario.Size.Height) / 2);

            tp.Size = new Size(tp_forms.Size.Width - 25, tp_forms.Size.Height - 30);

            contenedor.Size = formulario.Size;

            if (maximizado)
            {
                contenedor.Location = new Point(0, 0);
                contenedor.Size = tp.Size;
                formulario.Size = tp.Size;
            }

            contenedor.Controls.Add(formulario);
            tp.Controls.Add(contenedor);
            tp_forms.TabPages.Add(tp);
            formulario.Show(); //debe ir siempre al final para q los controles se activen
        }
        private void CerrarFormularioActual()
        {
            if (tp_forms.SelectedTab == null)
                return;
            TabPage tp = tp_forms.SelectedTab;
            tabsNames.RemoveAt(tp_forms.SelectedIndex);
            tp_forms.TabPages.Remove(tp);



            if (tp_forms.TabPages.Count == 0)
            {
                tp_forms.Visible = false;
                //pb_cerrarTab.Visible = false;
            }
        }

        #endregion

        private void pb_cerrarTab_Click(object sender, EventArgs e)
        {
            CerrarFormularioActual();
        }
    }
    class Padre
    {
        public int Edad { get; set; }
        public String Nombre { get; set; }
        public Hijo Hijo { get; set; }
    }
    class Hijo
    {
        public String Otro { get; set; }
    }
}
