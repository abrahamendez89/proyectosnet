using Herramientas.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using VisorXMLFacturas.ValidarCFDI;

namespace VisorXMLFacturas
{
    public partial class VisorXMLCFDI : Form
    {
        public String Responsable { get; set; }
        public VisorXMLCFDI(String responsable)
        {
            InitializeComponent();

            Text += " - "+responsable;
            Responsable = responsable;
        }
        private void btn_cargarXML_Click(object sender, EventArgs e)
        {
            String ruta = Herramientas.Archivos.Dialogos.BuscarArchivo(new List<string>() { "Archivo XML CFDI" }, new List<string>() { "XML" });
            if (ruta != null && !ruta.Equals(""))
            {
                txt_xmlArchivo.Text = ruta;

                ProcesamientoCFDI.ProcesarXML(Responsable, ruta);
            }
        }

        
    }
}
