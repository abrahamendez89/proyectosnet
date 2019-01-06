using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_TecnologiaCultivo:ObjetoBase
    {
        //lo anterior visto es como se relacionan objetos de dominio y esto se traduce en una base de datos bien diseñada
        //para esto se usará la herramienta de sincronización de dominio-sql
        #region atributos privados
        private String _st_Descripcion;
        private List<_ps_Cubierta> _ll_CubiertasParaTecnologia;
        
        #endregion

        #region propiedades publicas
        public String st_Descripcion
        {
            get { return _st_Descripcion; }
            set { _st_Descripcion = value; }
        }
        public List<_ps_Cubierta> Ll_CubiertasParaTecnologia
        {
            get { return GetListaRelacionados< _ps_Cubierta>("_ll_CubiertasParaTecnologia"); }
            set { SetListaRelacionados("_ll_CubiertasParaTecnologia", value); }
        }
        #endregion

        #region consultas
        #endregion

        

        
    }
}
