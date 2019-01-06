using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _XMLCFDI:ObjetoBase
    {
        private String _st_RFCEmisor;
        private String _st_RFCReceptor;
        private String _st_FolioFactura;
        private String _st_UUID;
        private double _do_Monto;
        private DateTime _dt_FechaEmisionFactura;
        private String _st_ContenidoXML;

        public String St_RFCEmisor
        {
            get { return _st_RFCEmisor; }
            set { _st_RFCEmisor = value; }
        }
        
        public String St_RFCReceptor
        {
            get { return _st_RFCReceptor; }
            set { _st_RFCReceptor = value; }
        }
        
        public String St_FolioFactura
        {
            get { return _st_FolioFactura; }
            set { _st_FolioFactura = value; }
        }
       
        public String St_UUID
        {
            get { return _st_UUID; }
            set { _st_UUID = value; }
        }
       
        public double Do_Monto
        {
            get { return _do_Monto; }
            set { _do_Monto = value; }
        }
       
        public DateTime Dt_FechaEmisionFactura
        {
            get { return _dt_FechaEmisionFactura; }
            set { _dt_FechaEmisionFactura = value; }
        }
        

        public String St_ContenidoXML
        {
            get { return _st_ContenidoXML; }
            set { _st_ContenidoXML = value; }
        }
    }
}
