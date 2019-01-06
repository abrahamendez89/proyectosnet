using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.General;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_ActividadSiembra: ObjetoBase
    {
        #region atributos privados
        private String _st_Nombre;
        private double _do_Duracion;
        private _gen_UnidadDeTiempo _oo_UnidadTiempo;
        #endregion
        #region propiedades publicas
        public String St_Nombre
        {
            get { return _st_Nombre; }
            set { _st_Nombre = value; }
        }
        public double Do_Duracion
        {
            get { return _do_Duracion; }
            set { _do_Duracion = value; }
        }
        public _gen_UnidadDeTiempo Oo_UnidadTiempo
        {
            get { return GetAtributoRelacionado<_gen_UnidadDeTiempo>("_oo_UnidadTiempo"); }
            set { SetAtributoRelacionado("_oo_UnidadTiempo",value); }
        }
        
        #endregion
        #region metodos publicos estaticos
        #endregion
    }
}
