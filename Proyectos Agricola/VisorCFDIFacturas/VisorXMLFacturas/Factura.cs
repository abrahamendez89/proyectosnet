using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisorXMLFacturas
{
    public class Factura
    {
        private String FormatoHTML = "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
"<head>"+
	"<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">" +
    @"<title>Factura</title>
	<style>
		body{
			background: gray;
		}

		#pagina { 
			width: 800px; 
			margin: 0 auto; 
			background: white;
		}
		#datosFactura{
			width: 250px;
			float: right;
			border: 1px solid;
			padding: 5px;
		}
		#datosXML{
			width: 250px;
			float: right;
			margin-top: 10px;
			border: 1px solid;
			padding: 5px;
		}
		#encabezado {
		    position: relative;
		    overflow: hidden;
		    background: #ecf0f1;
		}
		#datosEmisor{
			position: relative;
			width: 400px;
			float: left;
			border: 1px solid;
			padding: 5px;
		}
		#datosReceptor{
			border: 1px solid;
			padding: 5px;
		}
		#contenedorPago {
		    position: relative;
		    overflow: hidden;
		    margin-top: 10px;
		}
		#contenedorDatosFiscales {
		    position: relative;
		    overflow: hidden;
		    background: #ecf0f1;
		    margin-top: 10px;
		}
		#totalesConImpuestos{
			float: right;
		}

		#formaPago {
		    float: left;
		}
		#cadenasSAT {
		    float: left;
		}
		#datosSAT {
		    float: right;
		}
		.contenedor{
			padding: 10px;
		}
		table { 
			border-collapse: collapse; 
			width: 100%
		}
		table td, table th {
			padding: 2px;
			font-size: 12px;
		}

		#concepto td {
		    text-align: center;
		}
		.descripcion{
			text-align: left !important;
		}
        .importeConcepto{
			text-align: right !important;
		}
		#mensajeInicio{
			margin: 10px;
			text-align: center;
		}
		.emisorDato{
			width: 120px;
		}
		.facturaDato{
			width: 80px;
		}

		#datosReceptor1 {
		    float: left;
		    width: 400px;
		}

		#datosReceptor2 {
		    float: right;
		    width: 250px;
		}

		#contenedorReceptor{
			overflow: hidden;
			/* border: 1px solid; */
			padding: 10px;
			/* margin: 10px; */
			background: #ecf0f1;
			margin-top: 10px;
		}

		#tablaConceptos tr, #tablaConceptos td, #tablaConceptos th {
		    border: 1px solid;
		}

		#pagina {
		    padding: 10px;
		}

		#contenedorConceptos {
		    background: #ecf0f1;
		    margin-top: 10px;
		}

		#contenedorSecundario {
		    overflow: hidden;
		    border: 1px solid;
		    padding: 5px;
		}

		#totalesConImpuestos table td {
		    border: 1px solid;
		}

		#totalesConImpuestos td {
		    width: 100px;
		}

		#cadenasSAT td {
		    border: 1px solid;
		}

		#datosSAT td {
		    border: 1px solid;
		}
        #estatusCFDI {
            color: @colorStatusCFDI;
            font-size: 15px;
        }
	</style>
</head>
<body>
	<div id='pagina'>
		<div id='mensajeInicio'>
			Esta es una representación gráfica de un CFDI.
		</div>
		<div class='contenedor' id='encabezado'>
			<div id='datosEmisor'>
				<div>Datos del Emisor:</div>
				<table>
					<tr>
						<td class='emisorDato'><b>Nombre:</b></td>
						<td>@EmisorNombre</td>
					</tr>
					<tr>
						<td class='emisorDato'><b>RFC:</b></td>
						<td>@EmisorRFC</td>
					</tr>
					<tr>
						<td class='emisorDato'><b>Expedido en:</b></td>
						<td>@EmisorExpedidoEn</td>
					</tr>
					<tr>
						<td class='emisorDato'><b>Regimen:</b></td>
						<td>@EmisorRegimen</td>
					</tr>
					<tr>
						<td class='emisorDato'><b>Domicilio fiscal:</b></td>
						<td>@EmisorDomicilioFiscal</td>
					</tr>
				</table>
			</div>
			<div id='datosFactura'>
				<div>Datos de la factura:</div>
				<table>
					<tr>
						<td class='facturaDato'><b>Serie:</b></td>
						<td>@FacturaSerie</td>
					</tr>
					<tr>
						<td><b>Folio:</b></td>
						<td>@FacturaFolio</td>
					</tr>
					<tr>
						<td><b>Fecha:</b></td>
						<td>@FacturaFecha</td>
					</tr>
					<tr>
						<td><b>No. Certificado:</b></td>
						<td>@FacturaCertificado</td>
					</tr>
				</table>
			</div>
			<div id='datosXML'>
				<table>
					<tr>
						<td class='facturaDato'><b>Estatus en el SAT:</b></td>
						<td id='estatusCFDI'>@SATEstatus</td>
					</tr>
				</table>
			</div>
		</div>
		<div class='contenedor' id='contenedorReceptor'>
			<div id='contenedorSecundario'>
				<div>
					Datos del Receptor:
				</div>
				<div id='datosReceptor1'>
					<table>
						<tr>
							<td class='emisorDato'><b>Nombre:</b></td>
							<td>@ReceptorNombre</td>
						</tr>
						<tr>
							<td class='emisorDato'><b>RFC:</b></td>
							<td>@ReceptorRFC</td>
						</tr>
						<tr>
							<td class='emisorDato'><b>Domicilio:</b></td>
							<td>@ReceptorDomicilio</td>
						</tr>
						<tr>
							<td class='emisorDato'><b>Código Postal:</b></td>
							<td>@ReceptorCodigoPostal</td>
						</tr>
					</table>
				</div>
				<div id='datosReceptor2'>
					<table>
						<tr>
							<td class='emisorDato'><b>Colonia:</b></td>
							<td>@ReceptorColonia</td>
						</tr>
						<tr>
							<td class='emisorDato'><b>Municipio:</b></td>
							<td>@ReceptorMunicipio</td>
						</tr>
						<tr>
							<td class='emisorDato'><b>Estado:</b></td>
							<td>@ReceptorEstado</td>
						</tr>
						<tr>
							<td class='emisorDato'><b>Pais:</b></td>
							<td>@ReceptorPais</td>
						</tr>
					</table>
				</div>
			</div>
		</div>
		<div class='contenedor' id='contenedorConceptos'>
			<div  id='conceptos'>
				<div>
					Conceptos:
				</div>
				<table id='tablaConceptos'>
					<tr id='encabezadoConceptos'>
						<th>Cantidad</th>
						<th>Unidad</th>
						<th>Concepto/descripción</th>
						<th>Valor unitario</th>
						<th>Importe</th>
					</tr>	
					@Conceptos
				</table>	
			</div >	
			<div id='contenedorPago'>
				<div id='totalesConImpuestos'>
					<table>
						<tr>
							<td><b>Subtotal:</b></td>
							<td class='importeConcepto'>@Subtotal</td>
						</tr>
						@Impuestos
						<tr>
							<td><b>Total:</b></td>
							<td class='importeConcepto'>@Total</td>
						</tr>
						
					</table>	
				</div>
				<div id='formaPago'>
					<table>
						<tr>
							<td><b>Forma de pago:</b></td>
							<td>@FormaPagoTips</td>
						</tr>
						<tr>
							<td><b>Condiciones de pago:</b></td>
							<td>@FormaPagoCondiciones</td>
						</tr>
						<tr>
							<td><b>Método de pago:</b></td>
							<td>@FormaPagoMetodo</td>
						</tr>
						<tr>
							<td><b>Tipo de comprobante:</b></td>
							<td>@FormaPagoTipoComprobante</td>
						</tr>
					</table>	
				</div>
			</div>
		</div>
		
		<div class='contenedor' id='contenedorDatosFiscales'>
			<div id='cadenasSAT'>
				<div>Cadenas SAT:</div>
				<table>
						<tr>
							<td><b>Sello digital:</b></td>
							<td>@SelloDigital</td>
						</tr>
						<tr>
							<td><b>Sello SAT:</b></td>
							<td>@SelloSAT</td>
						</tr>
					</table>	
			</div>
			<div id='datosSAT'>
				<div>Datos timbrado:</div>
				<table>
						<tr>
							<td><b>Certificado SAT:</b></td>
							<td>@CertificadoSAT</td>
						</tr>
						<tr>
							<td><b>Folio fiscal (UUID):</b></td>
							<td>@UUID</td>
						</tr>
						<tr>
							<td><b>Fecha de Timbrado:</b></td>
							<td>@FechaTimbrado</td>
						</tr>
					</table>	
			</div>
		</div>
        <div id='mensajeInicio'>
			    Este XML fue revisado por: <b>@PersonaReviso</b> en la fecha: <b>@fechaReviso</b>.
	    </div>
	</div>
</body>
</html>";



        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public List<Impuesto> Impuestos { get; set; }
        public List<Concepto> Conceptos { get; set; }

        public String Serie { get; set; }
        public String Folio { get; set; }
        public DateTime FechaFactura { get; set; }
        public String Certificado { get; set; }

        public String EstatusCDFI { get; set; }

        public double Subtotal { get; set; }
        public double Total { get; set; }

        public String FormaPago { get; set; }
        public String CondicionesPago { get; set; }
        public String MetodoPago { get; set; }
        public String TipoComprobante { get; set; }

        public String SelloDigital { get; set; }
        public String SelloSAT { get; set; }

        public String CertificadoSAT { get; set; }
        public String UUID { get; set; }
        public DateTime FechaTimbrado { get; set; }

        public String Responsable { get; set; }

        public String GenerarHTML()
        {
            FormatoHTML = FormatoHTML.Replace("@FacturaSerie", Serie);
            FormatoHTML = FormatoHTML.Replace("@FacturaFolio", Folio);
            FormatoHTML = FormatoHTML.Replace("@FacturaFecha", Herramientas.Conversiones.Formatos.DateTimeAFechaLarga(FechaFactura));
            FormatoHTML = FormatoHTML.Replace("@FacturaCertificado", Certificado);
            FormatoHTML = FormatoHTML.Replace("@SATEstatus", EstatusCDFI);

            FormatoHTML = FormatoHTML.Replace("@EmisorNombre", Emisor.Nombre);
            FormatoHTML = FormatoHTML.Replace("@EmisorRFC", Emisor.RFC);
            FormatoHTML = FormatoHTML.Replace("@EmisorExpedidoEn", Emisor.ExpedidoEn);
            FormatoHTML = FormatoHTML.Replace("@EmisorRegimen", Emisor.Regimen);
            FormatoHTML = FormatoHTML.Replace("@EmisorDomicilioFiscal", Emisor.DomicilioFiscal);

            FormatoHTML = FormatoHTML.Replace("@ReceptorNombre", Receptor.Nombre);
            FormatoHTML = FormatoHTML.Replace("@ReceptorRFC", Receptor.RFC);
            FormatoHTML = FormatoHTML.Replace("@ReceptorDomicilio", Receptor.Domicilio);
            FormatoHTML = FormatoHTML.Replace("@ReceptorCodigoPostal", Receptor.CodigoPostal);
            FormatoHTML = FormatoHTML.Replace("@ReceptorColonia", Receptor.Colonia);
            FormatoHTML = FormatoHTML.Replace("@ReceptorMunicipio", Receptor.Municipio);
            FormatoHTML = FormatoHTML.Replace("@ReceptorEstado", Receptor.Estado);
            FormatoHTML = FormatoHTML.Replace("@ReceptorPais", Receptor.Pais);

            FormatoHTML = FormatoHTML.Replace("@CertificadoSAT", CertificadoSAT);
            FormatoHTML = FormatoHTML.Replace("@UUID", UUID);
            FormatoHTML = FormatoHTML.Replace("@FechaTimbrado", Herramientas.Conversiones.Formatos.DateTimeAFechaLarga(FechaTimbrado));



            String temp = SelloDigital.Substring(0, SelloDigital.Length / 2) + " " + SelloDigital.Substring(SelloDigital.Length / 2, SelloDigital.Length - SelloDigital.Length / 2);


            FormatoHTML = FormatoHTML.Replace("@SelloDigital", ""); //SelloDigital);
            FormatoHTML = FormatoHTML.Replace("@SelloSAT", ""); // SelloSAT);

            FormatoHTML = FormatoHTML.Replace("@FormaPagoTips", FormaPago);
            FormatoHTML = FormatoHTML.Replace("@FormaPagoCondiciones", CondicionesPago);
            FormatoHTML = FormatoHTML.Replace("@FormaPagoMetodo", MetodoPago);
            FormatoHTML = FormatoHTML.Replace("@FormaPagoTipoComprobante", TipoComprobante);

            FormatoHTML = FormatoHTML.Replace("@Subtotal", Herramientas.Conversiones.Formatos.DoubleAMoneda(Subtotal));
            FormatoHTML = FormatoHTML.Replace("@Total", Herramientas.Conversiones.Formatos.DoubleAMoneda(Total));

            if (Impuestos != null && Impuestos.Count > 0)
            {
                String imps = "";
                foreach (Impuesto imp in Impuestos)
                {
                    imps += imp.GenerarHTML();
                }
                FormatoHTML = FormatoHTML.Replace("@Impuestos", imps);
            }
            else
            {
                FormatoHTML = FormatoHTML.Replace("@Impuestos", "");
            }
            if (Conceptos != null && Conceptos.Count > 0)
            {
                String imps = "";
                foreach (Concepto con in Conceptos)
                {
                    imps += con.GenerarHTML();
                }
                FormatoHTML = FormatoHTML.Replace("@Conceptos", imps);
            }
            else
            {
                FormatoHTML = FormatoHTML.Replace("@Conceptos", "");
            }

            if (EstatusCDFI.Equals("Vigente"))
            {
                FormatoHTML = FormatoHTML.Replace("@colorStatusCFDI", "green");
            }
            else
            {
                FormatoHTML = FormatoHTML.Replace("@colorStatusCFDI", "red");
            }
            FormatoHTML = FormatoHTML.Replace("@PersonaReviso", Responsable);
            FormatoHTML = FormatoHTML.Replace("@fechaReviso", Herramientas.Conversiones.Formatos.DateTimeAFechaLargaTextoDescripciones(DateTime.Now));
            return FormatoHTML;
        }
    }
}
