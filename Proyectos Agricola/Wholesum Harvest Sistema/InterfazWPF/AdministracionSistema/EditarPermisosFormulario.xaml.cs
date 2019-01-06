using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dominio.Sistema;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para EditarPermisosFormulario.xaml
    /// </summary>
    public partial class EditarPermisosFormulario : Window
    {
        Assembly assem = Assembly.GetExecutingAssembly();
        _sis_FormularioPermisosPorRol permisos;
        public EditarPermisosFormulario(_sis_FormularioPermisosPorRol permisos)
        {
            InitializeComponent();

            this.permisos = permisos;
            String referencia = permisos.Formulario.SReferenciaFormulario;

            ObjectHandle obj = null;
            try
            {
                obj = AppDomain.CurrentDomain.CreateInstance(assem.FullName, referencia);

            }
            catch { HerramientasWindow.MensajeErrorSimple("La referencia registrada en la configuración del sistema para este formulario es incorrecta. Verificar", "Error al cargar el formulario"); return; }
            Window window = (Window)obj.Unwrap();

            window.Close();

            Type t = window.GetType();

            MethodInfo[] metodos = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            if (permisos.MetodosPermisos == null) permisos.MetodosPermisos = "";
            String[] checados = permisos.MetodosPermisos.Split('|');

            foreach (MethodInfo metodo in metodos)
            {
                if (metodo.Name.ToLower().StartsWith("toolbox_"))
                {
                    String nombreMetodo = metodo.Name.Replace("toolbox_", "").Replace("_", " ");
                    CheckBox chb_Agregar = new CheckBox();
                    chb_Agregar.Content = nombreMetodo;

                    chb_Agregar.IsChecked = checados.Contains(nombreMetodo);

                    pnl_opciones.Children.Add(chb_Agregar);

                }
            }

        }

        private void btn_aceptar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            permisos.MetodosPermisos = "";
            foreach (CheckBox check in pnl_opciones.Children)
            {
                if ((bool)check.IsChecked)
                    permisos.MetodosPermisos += check.Content.ToString() + "|";
            }
            if (permisos.MetodosPermisos.Length > 0)
                permisos.MetodosPermisos = permisos.MetodosPermisos.Substring(0, permisos.MetodosPermisos.Length - 1);
            else
                permisos.MetodosPermisos = null;

            Close();
        }

        private void btn_cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
