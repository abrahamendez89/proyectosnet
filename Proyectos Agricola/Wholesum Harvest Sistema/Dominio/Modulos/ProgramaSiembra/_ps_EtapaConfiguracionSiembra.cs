using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Modulos.ProgramaSiembra
{
    public class _ps_EtapaConfiguracionSiembra:ObjetoBase
    {
        private String _st_NombreEtapa;

        public String St_NombreEtapa
        {
            get { return _st_NombreEtapa; }
            set { _st_NombreEtapa = value; }
        }
    }
}
