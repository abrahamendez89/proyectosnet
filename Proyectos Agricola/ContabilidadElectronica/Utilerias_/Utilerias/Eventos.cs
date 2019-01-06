using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilerias.Utilerias
{
    class ControlEvento
    {
        private Control controlOrigen;
        private Control controlDestino;
        public ControlEvento(Control controlOrigen, Control controlDestino)
        {
            this.controlDestino = controlDestino;
            this.controlOrigen = controlOrigen;

            this.controlOrigen.KeyPress += controlOrigen_KeyPress;
        }
        private void controlOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                controlDestino.Focus();
            }
        }
    }
    public class Eventos
    {
        public static void AsignarEventoEnterAFocus(Control controlOrigen, Control controlDestino)
        {
            new ControlEvento(controlOrigen, controlDestino);
        }
    }
}
