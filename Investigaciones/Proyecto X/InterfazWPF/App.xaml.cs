using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //si ocurre un error en la aplicacion q no se haya manejado, pasa por esta opcion y se maneja en el 
            //evento registrado.
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //aqui indicamos al sistema q oculte la excepcion
            e.Handled = true;
            //Application.Current.Shutdown();
        }
    }
}
