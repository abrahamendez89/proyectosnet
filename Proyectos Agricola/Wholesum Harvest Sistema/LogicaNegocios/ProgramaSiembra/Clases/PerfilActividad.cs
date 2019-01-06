using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.General;
using Dominio.Modulos.ProgramaSiembra;

namespace LogicaNegocios.ProgramaSiembra.Clases
{
    public class PerfilActividad
    {
        public _gen_PerfilActividades Perfil { get; set; }
        public _ps_EspacioFisico EspacioFisico { get; set; }
        public List<Actividad> Actividades { get; set; }
        public List<Material> Materiales { get; set; }
        public DateTime FechaMenor { get; set; }
        public DateTime FechaMayor { get; set; }
    }
}
