using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_VariableGlobal: ObjetoBase
    {
        private String _st_Nombre;
        private String _st_valor;
        public String St_valor
        {
            get { return _st_valor; }
            set { _st_valor = value; }
        }
        public String St_Nombre
        {
            get { return _st_Nombre; }
            set { _st_Nombre = value; }
        }

        public static readonly String ConsultaPorNombre = "select * from _sis_VariableGlobal where _st_Nombre = @_st_Nombre";
    }
}
