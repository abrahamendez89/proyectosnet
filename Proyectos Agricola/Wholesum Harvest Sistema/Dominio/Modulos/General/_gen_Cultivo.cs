using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.ProgramaSiembra;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_Cultivo:ObjetoBase
    {
        #region atributos privados
        private String _st_Nombre_cultivo;
        private String _st_Abreviatura;
        private List<_ps_VariedadSemilla> _ll_VariedadesDisponibles; //representacion de la relacion 1 a muchos con un List
        private int _in_DiasAntesSiembra;
        private int _in_DiasDespuesCosecha;
        private Double _do_PorcentajeDeSemillaAdicional;

        #endregion

        #region propiedades publicas
        public Double Do_PorcentajeDeSemillaAdicional
        {
            get { return _do_PorcentajeDeSemillaAdicional; }
            set { _do_PorcentajeDeSemillaAdicional = value; }
        }
        public String St_Abreviatura
        {
            get { return _st_Abreviatura; }
            set { _st_Abreviatura = value; }
        }
        public int In_DiasAntesSiembra
        {
            get { return _in_DiasAntesSiembra; }
            set { _in_DiasAntesSiembra = value; }
        }
        public int In_DiasDespuesCosecha
        {
            get { return _in_DiasDespuesCosecha; }
            set { _in_DiasDespuesCosecha = value; }
        }
        public List<_ps_VariedadSemilla> Ll_VariedadesDisponibles
        {
            get { return GetListaRelacionados<_ps_VariedadSemilla>("_ll_VariedadesDisponibles"); }
            set { SetListaRelacionados("_ll_VariedadesDisponibles", value); }
        }
        public String st_Nombre_cultivo
        {
            get { return _st_Nombre_cultivo; }
            set { _st_Nombre_cultivo = value; }
        }
        #endregion

        #region consultas
        public static readonly String ConsultaTodos = "select * from _gen_Cultivo";
        #endregion
        
        

    }
}
