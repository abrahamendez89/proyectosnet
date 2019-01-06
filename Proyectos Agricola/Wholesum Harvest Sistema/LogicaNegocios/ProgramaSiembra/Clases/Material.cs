using Dominio.Modulos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocios.ProgramaSiembra.Clases
{
    public class Material
    {
        public _gen_Material MaterialDominio { get; set; }
        public List<DateTime> Fechas { get; set; }
        public Dictionary<int, double> GastoPorSemana { get; set; }
        public Dictionary<int, double> UnidadesPorSemana { get; set; }
        public double CostoPorDia { get; set; }
        public double UnidadesPorDia { get; set; }
        public String Medida { get; set; }
        public double NumeroJornales { get; set; }
        public double CostoTotalTemporada { get; set; }
        public double UnidadesTotalestemporada { get; set; }
    }
}
