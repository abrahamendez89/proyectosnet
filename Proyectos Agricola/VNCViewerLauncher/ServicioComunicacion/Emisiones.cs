using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace ServicioComunicacion
{
    public partial class Emisiones : ServiceBase
    {
        public Emisiones()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //while (true)
            //{
            //    Herramientas.Forms.Mensajes.Informacion("funciono");
            //    Thread.Sleep(30000);
            //}
        }

        protected override void OnStop()
        {
        }
    }
}
