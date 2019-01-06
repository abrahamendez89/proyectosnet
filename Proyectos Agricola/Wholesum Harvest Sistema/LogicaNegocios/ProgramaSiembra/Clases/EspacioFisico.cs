using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.ProgramaSiembra;

namespace LogicaNegocios.ProgramaSiembra.Clases
{
    public class EspacioFisico
    {
        public _ps_EspacioFisico Espacio { get; set; }
        public List<PerfilActividad> Perfiles { get; set; }
        public DateTime FechaMenor { get; set; }
        public DateTime FechaMayor { get; set; }
        public Double[] SumatoriaCostosPorSemanaActividades { get; set; }
        public Double[] SumatoriaCostosPorSemanaMateriales { get; set; }
        public Double[] SumatoriaJornalesPorSemana { get; set; }
    }
}
