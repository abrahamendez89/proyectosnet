using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.General
{
    public class _gen_UnidadDeTiempo:ObjetoBase
    {
        #region atributos privados
        private String _st_Nombre;
        private double _do_EquivalenciaEn1Hora;
        #endregion
        #region propiedades publicas
        public String St_Nombre
        {
            get { return _st_Nombre; }
            set { _st_Nombre = value; }
        }
        public double Do_EquivalenciaEn1Hora
        {
            get { return _do_EquivalenciaEn1Hora; }
            set { _do_EquivalenciaEn1Hora = value; }
        }
        #endregion

        #region consultas publicas
        public static readonly String ConsultaPor1Hora = "select * from _gen_UnidadDeTiempo where _do_EquivalenciaEn1Hora = 1";
        #endregion
    }
}
