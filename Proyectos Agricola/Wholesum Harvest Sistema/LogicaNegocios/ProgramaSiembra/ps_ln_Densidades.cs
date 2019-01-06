using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.ProgramaSiembra;

namespace LogicaNegocios.ProgramaSiembra
{
    public class ps_ln_Densidades
    {
        public static string ObtenerFormatoDeDensidad(_ps_DensidadPlanteo densidad)
        {
            if (densidad != null)
                return "." + densidad.fl_Centimetros_de_separacion.ToString("00") + "/ " + densidad.in_Numero_de_hileras + " HIL C." + densidad.Fl_CentimetrosCorazon.ToString("00");
            else
                return "";
        }
    }
}
