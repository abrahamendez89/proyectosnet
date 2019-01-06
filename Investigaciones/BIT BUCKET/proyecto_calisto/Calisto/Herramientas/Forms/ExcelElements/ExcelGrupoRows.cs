using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas.Forms.ExcelElements
{
    public class ExcelGrupoRows
    {
        public int RowInicio { get; set; }
        public int RowFin { get; set; }

        public List<ExcelGrupoRows> GruposInternos { get; set; }

        public ExcelGrupoRows GrupoPadre { get; set; }

        public int Nivel { get; set; }

    }
}
