using Herramientas.Archivos;
using Herramientas.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContabilidadElectronica.Formularios
{
    public partial class UnionXMLPolizas : Form
    {
        public UnionXMLPolizas()
        {
            InitializeComponent();
        }
        XML xml1;
        XML xml2;
        private void btn_buscarArchivo1_Click(object sender, EventArgs e)
        {
            if (cmb_tipoXML.SelectedItem == null)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Por favor seleccione un tipo de XML.");
                return;
            }
            String ruta = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo XML" }, new List<String>() { "xml" });
            if (ruta != null && !ruta.Equals(""))
            {
                    xml1 = new XML(ruta);
                    String nombreArchivo = Herramientas.Archivos.Archivo.ObtenerNombreArchivo(ruta);
                    List<String> valores = ObtenerValores(xml1);
                    String RFC = valores[0];// xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "RFC");
                    String Mes = valores[1]; // xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "Mes");
                    String Anio = valores[2]; // xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "Anio");
                    String TipoSolicitud = valores[3];//  xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "TipoSolicitud");
                    String NumOrden = valores[4];//  xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "NumOrden");
                    String NumTramite = valores[5]; // xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "NumTramite");

                    txt_archivo1.Text = ruta;
                    ll_archivo1.Text = nombreArchivo;
                    txt_rfc1.Text = RFC;
                    txt_ano1.Text = Anio;
                    txt_mes1.Text = Mes;
                    txt_tiposol1.Text = TipoSolicitud;
                    txt_NumOrden1.Text = NumOrden;
                    txt_numTram1.Text = NumTramite;
            }
        }

        private void btn_BuscarArchivo2_Click(object sender, EventArgs e)
        {
            if (cmb_tipoXML.SelectedItem == null)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Por favor seleccione un tipo de XML.");
                return;
            }
            String ruta = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo XML" }, new List<String>() { "xml" });
            if (ruta != null && !ruta.Equals(""))
            {
                    xml2 = new XML(ruta);
                    String nombreArchivo = Herramientas.Archivos.Archivo.ObtenerNombreArchivo(ruta);
                    List<String> valores = ObtenerValores(xml2);
                    String RFC = valores[0];// xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "RFC");
                    String Mes = valores[1]; // xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "Mes");
                    String Anio = valores[2]; // xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "Anio");
                    String TipoSolicitud = valores[3];//  xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "TipoSolicitud");
                    String NumOrden = valores[4];//  xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "NumOrden");
                    String NumTramite = valores[5]; // xml2.ObtenerValorDePropiedad_NODO_XML("PLZ", "Polizas", "NumTramite");

                    txt_archivo2.Text = ruta;
                    ll_archivo2.Text = nombreArchivo;
                    txt_rfc2.Text = RFC;
                    txt_ano2.Text = Anio;
                    txt_mes2.Text = Mes;
                    txt_tiposol2.Text = TipoSolicitud;
                    txt_numOrden2.Text = NumOrden;
                    txt_numTram2.Text = NumTramite;

            }
        }
        private List<String> ObtenerValores(XML xml)
        {
            String nameSpace = "";
            String elementoBase = "";
            if (cmb_tipoXML.SelectedIndex == 0)
            {
                nameSpace = "PLZ";
                elementoBase = "Polizas";
            }
            if (cmb_tipoXML.SelectedIndex == 1)
            {
                nameSpace = "RepAux";
                elementoBase = "RepAuxFol";
            }
            if (cmb_tipoXML.SelectedIndex == 2)
            {
                nameSpace = "AuxiliarCtas";
                elementoBase = "AuxiliarCtas";
            }

            List<String> valores = new List<string>();
            valores.Add(xml.ObtenerValorDePropiedad_NODO_XML(nameSpace, elementoBase, "RFC"));
            valores.Add(xml.ObtenerValorDePropiedad_NODO_XML(nameSpace, elementoBase, "Mes"));
            valores.Add(xml.ObtenerValorDePropiedad_NODO_XML(nameSpace, elementoBase, "Anio"));
            valores.Add(xml.ObtenerValorDePropiedad_NODO_XML(nameSpace, elementoBase, "TipoSolicitud"));
            valores.Add(xml.ObtenerValorDePropiedad_NODO_XML(nameSpace, elementoBase, "NumOrden"));
            valores.Add(xml.ObtenerValorDePropiedad_NODO_XML(nameSpace, elementoBase, "NumTramite"));
            return valores;
        }
        String xmlFinal;
        private void btn_generarXML_Click(object sender, EventArgs e)
        {
            if (cmb_tipoXML.SelectedItem == null)
            {
                Herramientas.Forms.Mensajes.Exclamacion("Por favor seleccione un tipo de XML.");
                return;
            }

            if (txt_rfc1.Text.Equals(txt_rfc2.Text) && txt_ano1.Text.Equals(txt_ano2.Text)
                && txt_mes1.Text.Equals(txt_mes2.Text) && txt_tiposol1.Text.Equals(txt_tiposol2.Text) &&
                txt_NumOrden1.Text.Equals(txt_numOrden2.Text) && txt_numTram1.Text.Equals(txt_numTram2.Text))
            {
                String nameSpace = "";
                String elementoBase = "";
                String ruta = "";
                if (cmb_tipoXML.SelectedIndex == 0)
                {
                    nameSpace = "PLZ";
                    elementoBase = "Polizas";
                    ruta = "http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/PolizasPeriodo";
                }
                if (cmb_tipoXML.SelectedIndex == 1)
                {
                    nameSpace = "RepAux";
                    elementoBase = "RepAuxFol";
                    ruta = "http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/AuxiliarFolios";
                }
                if (cmb_tipoXML.SelectedIndex == 2)
                {
                    nameSpace = "AuxiliarCtas";
                    elementoBase = "AuxiliarCtas";
                    ruta = "http://www.sat.gob.mx/esquemas/ContabilidadE/1_1/AuxiliarCtas";
                }

                List<String> nodos = xml2.ObtenerNodos_XML(nameSpace, elementoBase);
                xmlFinal = xml1.ContenidoTexto;
                xmlFinal = xmlFinal.Replace("</" + nameSpace + ":" + elementoBase + ">", "");
                String nuevas = "";
                foreach (String poliza in nodos)
                {
                    nuevas += poliza;
                }
                nuevas = nuevas.Replace("xmlns:" + nameSpace + "=\"" + ruta + "\"", "");
                nuevas = nuevas.Replace("xmlns:" + nameSpace + "=\" " + ruta + "\"", "");
                xmlFinal += nuevas;
                xmlFinal += "</" + nameSpace + ":" + elementoBase + ">";

                var path = Path.GetTempPath();
                var fileName = Guid.NewGuid().ToString() + ".xml";
                var fullFileName = Path.Combine(path, fileName);
                File.WriteAllText(fullFileName, xmlFinal);
                wb.Navigate(fullFileName);
            }
            else
            {
                Herramientas.Forms.Mensajes.Informacion("Los archivos no corresponden en sus datos, por favor verifique.");
            }
        }

        private void btn_guardarXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_tipoXML.SelectedItem == null)
                {
                    Herramientas.Forms.Mensajes.Exclamacion("Por favor seleccione un tipo de XML.");
                    return;
                }
                String ruta = Herramientas.Archivos.Dialogos.BuscarCarpeta(null);
                String caracteresFinales = "";
                if (cmb_tipoXML.SelectedIndex == 0) //xml de polizas del periodo
                    caracteresFinales = "PL";
                if (cmb_tipoXML.SelectedIndex == 1) //xml de auxiliar de folios
                    caracteresFinales = "XF";
                if (cmb_tipoXML.SelectedIndex == 2) //xml de auxiliar de cuentas
                    caracteresFinales = "XC";

                if (ruta != null && !ruta.Equals(""))
                {
                    String nombreArchivo = txt_rfc1.Text + txt_ano1.Text + txt_mes1.Text + caracteresFinales + ".xml";
                    String rutaGuardado = ruta + "\\" + nombreArchivo;
                    Herramientas.Archivos.Archivo.GuardarArchivoDeTexto(rutaGuardado, xmlFinal);
                    Herramientas.Forms.Mensajes.Informacion("Archivo generado correctamente en: " + rutaGuardado + ".");
                }
            }
            catch (Exception ex)
            {
                Herramientas.Forms.Mensajes.Error("Error: " + ex.Message);
            }
        }

        private void ll_archivo1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VisorXML visor = new VisorXML(xml1.ContenidoTexto);
            visor.Show();
        }

        private void ll_archivo2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VisorXML visor = new VisorXML(xml2.ContenidoTexto);
            visor.Show();
        }
    }
}
