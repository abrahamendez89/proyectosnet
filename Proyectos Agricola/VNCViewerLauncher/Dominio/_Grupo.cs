using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _Grupo : ObjetoBase
    {
        private String _st_NombreGrupo;
        private List<_Equipo> _ll_equiposEnGrupo;

        public String St_NombreGrupo
        {
            get { return _st_NombreGrupo; }
            set { _st_NombreGrupo = value; }
        }

        public List<_Equipo> Ll_equiposEnGrupo
        {
            get { return GetListaRelacionados<_Equipo>("_ll_equiposEnGrupo"); }
            set { SetListaRelacionados("_ll_equiposEnGrupo",value); }
        }

        public int EquiposEnGrupo { get { int cantidad = 0; if (Ll_equiposEnGrupo != null) { cantidad = Ll_equiposEnGrupo.Count; } return cantidad; } }

    }
}
