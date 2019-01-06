using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisorXMLFacturas
{
    public class Concepto
    {
        public int Cantidad { get; set; }
        public String Unidad { get; set; }
        public String ConceptoDescripcion { get; set; }
        public double ValorUnitario { get; set; }
        public double Importe { get; set; }

        public String GenerarHTML()
        {
            String html = @"<tr id='concepto'>
						<td>@ConceptoCantidad</td>
						<td>@ConceptoUnidad</td>
						<td class='descripcion'>@ConceptoDescripcion</td>
						<td class='importeConcepto'>@ConceptoValorUnitario</td>
						<td class='importeConcepto'>@ConceptoImporte</td>
					</tr>	".Replace("@ConceptoCantidad", Cantidad.ToString()).Replace("@ConceptoUnidad", Unidad).Replace("@ConceptoDescripcion", ConceptoDescripcion).Replace("@ConceptoValorUnitario", Herramientas.Conversiones.Formatos.DoubleAMoneda(ValorUnitario)).Replace("@ConceptoImporte", Herramientas.Conversiones.Formatos.DoubleAMoneda(Importe));

            return html;
        }
    }
}
