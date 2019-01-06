using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisorXMLFacturas
{
    public class Impuesto
    {
        public String Nombre { get; set; }
        public String Tasa { get; set; }
        public double Importe { get; set; }

        public String GenerarHTML()
        {
            String html = @"<tr>
							<td><b>@Nombre @Tasa:</b></td>
							<td class='importeConcepto'>@Importe</td>
						</tr>".Replace("@Nombre", Nombre).Replace("@Tasa","("+Tasa+")").Replace("@Importe", Herramientas.Conversiones.Formatos.DoubleAMoneda( Importe)); ;
            if (Tasa == null || Tasa.Equals(""))
            {
                html = html.Replace("()", "");
            }

            return html;
        }
    }
}
