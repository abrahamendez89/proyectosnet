using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _TipoMovimiento:ObjetoBase
    {
        private String _st_Nombre;
        private String _st_Tipo;
        private double _do_MultiplicadorSigno;
        private Boolean _bo_SeDivideEnMultiplesPagos;
        private Boolean _bo_SeAplicaInmediato;

        public Boolean Bo_SeAplicaInmediato
        {
            get { return _bo_SeAplicaInmediato; }
            set { _bo_SeAplicaInmediato = value; }
        }

        public Boolean Bo_SeDivideEnMultiplesPagos
        {
            get { return _bo_SeDivideEnMultiplesPagos; }
            set { _bo_SeDivideEnMultiplesPagos = value; }
        }

        public double Do_MultiplicadorSigno
        {
            get { return _do_MultiplicadorSigno; }
            set { _do_MultiplicadorSigno = value; }
        }

        public String St_Nombre
        {
            get { return _st_Nombre; }
            set { _st_Nombre = value; }
        }
        

        public String St_Tipo
        {
            get { return _st_Tipo; }
            set { _st_Tipo = value; }
        }
    }
}
