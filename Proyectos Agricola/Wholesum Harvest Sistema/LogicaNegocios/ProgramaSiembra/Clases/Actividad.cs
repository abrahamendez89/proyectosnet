using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio.Modulos.General;

namespace LogicaNegocios.ProgramaSiembra.Clases
{
    public class Actividad
    {
        public _gen_ActividadNomina ActividadDominio { get; set; }
        public List<DateTime> Fechas { get; set; }
        public Dictionary<int, double> GastoPorSemana { get; set; }
        public Dictionary<int, double> JornalesPorSemana { get; set; }
        public double CostoPorDia { get; set; }
        public double NumeroJornales { get; set; }
        public double CostoTotalTemporada { get; set; }
        public double JornalesTotalTemporada { get; set; }
    }
}
