using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladores
{
    public class MenuCtrl
    {
        ManejadorDB manejador;
        public MenuCtrl(ManejadorDB manejador)
        {
            this.manejador = manejador;
        }
        public List<String> ObtenerMenuPorModulo(String formasPermisos)
        {
            List<String> formas = new List<string>();

            List<string> forms = formasPermisos.Split('|').ToList<String>();

            foreach (String f in forms)
            {
                if (f.Equals("#001")) formas.Add("Forma 1|HotelAdmin.Catalogos.CatalogoUsuario");
                if (f.Equals("#002")) formas.Add("Forma 2|HotelAdmin.Catalogos.CatalogoHuesped");
                if (f.Equals("#003")) formas.Add("Forma 3|forma3.frm");
                if (f.Equals("#004")) formas.Add("Forma 4|forma4.frm");

            }

            return formas;
        }
    }
}
