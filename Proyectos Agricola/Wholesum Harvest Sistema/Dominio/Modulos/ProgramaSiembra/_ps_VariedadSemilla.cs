using Dominio.Modulos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_VariedadSemilla:ObjetoBase
    {
        #region atributos privados
        private String _st_Nombre;
        private Boolean _bo_esTipoRaiz;
        private Boolean _bo_esTipoProductiva;
        private String _st_Comentario;
        private _gen_Material _oo_VariedadSemillaMaterial;
        #endregion

        #region propiedades publicas
        public _gen_Material Oo_VariedadSemillaMaterial
        {
            get { return GetAtributoRelacionado<_gen_Material>("_oo_VariedadSemillaMaterial") ; }
            set { SetAtributoRelacionado("_oo_VariedadSemillaMaterial",value); }
        }
        public String St_Comentario
        {
            get { return _st_Comentario; }
            set { _st_Comentario = value; }
        }
        public Boolean Bo_esTipoProductiva
        {
            get { return _bo_esTipoProductiva; }
            set { _bo_esTipoProductiva = value; }
        }
        public String st_Nombre
        {
            get { return _st_Nombre; }
            set { _st_Nombre = value; }
        }
        public Boolean Bo_esTipoRaiz
        {
            get { return _bo_esTipoRaiz; }
            set { _bo_esTipoRaiz = value; }
        }
        #endregion

        #region consultas
        #endregion
        

        

    }
}
