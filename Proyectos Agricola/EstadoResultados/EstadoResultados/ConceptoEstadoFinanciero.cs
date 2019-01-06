using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EstadoResultados
{
    public class ConceptoEstadoFinanciero
    {
        public int ID { get; set; }
        public int IDBeneficio { get; set; }
        public String NombreConcepto { get; set; }
        public Boolean EsIndirecto { get; set; }
        public String Query { get; set; }
        public List<ConceptoEstadoFinanciero> ConceptosHijos { get; set; }
        public TreeNode NodoAsociado { get; set; }
    }
}
