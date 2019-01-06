using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _DirectoriosRespaldar: ObjetoBase
    {
        private String _ruta;
        private int _horaProgramada;
        private int _MinutoProgramado;
        private Boolean _EnLunes;
        private Boolean _EnMartes;
        private Boolean _EnMiercoles;
        private Boolean _EnJueves;
        private Boolean _EnViernes;
        private Boolean _EnSabado;
        private Boolean _EnDomingo;
        private String _CarpetaDestinoEnServicio;

        public String Ruta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }
        
        public int HoraProgramada
        {
            get { return _horaProgramada; }
            set { _horaProgramada = value; }
        }
        
        public int MinutoProgramado
        {
            get { return _MinutoProgramado; }
            set { _MinutoProgramado = value; }
        }

        
        public Boolean EnLunes
        {
            get { return _EnLunes; }
            set { _EnLunes = value; }
        }
        
        public Boolean EnMartes
        {
            get { return _EnMartes; }
            set { _EnMartes = value; }
        }
        
        public Boolean EnMiercoles
        {
            get { return _EnMiercoles; }
            set { _EnMiercoles = value; }
        }
        
        public Boolean EnJueves
        {
            get { return _EnJueves; }
            set { _EnJueves = value; }
        }
        
        public Boolean EnViernes
        {
            get { return _EnViernes; }
            set { _EnViernes = value; }
        }
        
        public Boolean EnSabado
        {
            get { return _EnSabado; }
            set { _EnSabado = value; }
        }
        
        public Boolean EnDomingo
        {
            get { return _EnDomingo; }
            set { _EnDomingo = value; }
        }

        public String CarpetaDestinoEnServicio
        {
            get { return _CarpetaDestinoEnServicio; }
            set { _CarpetaDestinoEnServicio = value; }
        }
    }
}
