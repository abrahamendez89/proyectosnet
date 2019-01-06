using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.ProgramaSiembra.Clases
{
    public class Presupuesto
    {
        public List<EspacioFisico> Espacios { get; set; }
        public DateTime FechaMenor { get; set; }
        public DateTime FechaMayor { get; set; }
        public Double[] CostoTotalPorSemanaActividades { get; set; }
        public Double[] JornalesTotalesPorSemanaActividades { get; set; }
        public Double[] CostoTotalPorSemanaMateriales { get; set; }
    }
}
