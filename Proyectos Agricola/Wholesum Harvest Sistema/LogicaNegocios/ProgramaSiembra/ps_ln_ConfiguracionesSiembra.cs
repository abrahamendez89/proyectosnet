using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Dominio.Modulos.ProgramaSiembra;

namespace LogicaNegocios.ProgramaSiembra
{
    public class ps_ln_ConfiguracionesSiembra
    {
        public static _ps_VariedadSemilla ObtenerVariedadSemillaDeListado(List<_ps_VariedadSemilla> listado, String nombre)
        {
            foreach (_ps_VariedadSemilla variedad in listado)
            {
                if (variedad.st_Nombre.Equals(nombre))
                {
                    return variedad;
                }
            }
            return null;
        }
    }
}
