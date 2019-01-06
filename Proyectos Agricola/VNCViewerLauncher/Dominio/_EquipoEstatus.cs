using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _EquipoEstatus : ObjetoBase
    {
        private String _MAC;
        private String _NombreEquipo;
        private String _IP;
        private String _UsuarioLogin;
        private double _PorcentajeMemoriaRAMUsada;
        private String _PorcentajeHDUsados;
        private String _UsuarioAdminWindows;
        private String _PassAdminWindows;
        private String _PassVNC;
        private String _Marca;
        private String _Modelo;
        private String _VersionWindows;
        private Bitmap _ImagenPreview;
        private Boolean _PermisoParaEjecutarAplicacion;
        private String _TempMensaje;
        private _Grupo _GrupoPertenece;
        private String _NombreReferencia;
        private String _Anotaciones;
        private String _CoordenadasCursorCliente;
        private String _CoordenadasCursorEnviadas;
        private String _ResolucionMonitorPrimario;
        private String _AccionClick;
        private String _ComandoTeclado;
        private Boolean _AccesoRemotoActivado;
        private String _ModificadorAcceso;
        private String _CombinacionEspecialTeclas;

        public String ModificadorAcceso
        {
            get { return _ModificadorAcceso; }
            set { _ModificadorAcceso = value; }
        }
        
        public String CombinacionEspecialTeclas
        {
            get { return _CombinacionEspecialTeclas; }
            set { _CombinacionEspecialTeclas = value; }
        }

        public Boolean AccesoRemotoActivado
        {
            get { return _AccesoRemotoActivado; }
            set { _AccesoRemotoActivado = value; }
        }

        public String ComandoTeclado
        {
            get { return _ComandoTeclado; }
            set { _ComandoTeclado = value; }
        }

        public String AccionClick
        {
            get { return _AccionClick; }
            set { _AccionClick = value; }
        }

        public String ResolucionMonitorPrimario
        {
            get { return _ResolucionMonitorPrimario; }
            set { _ResolucionMonitorPrimario = value; }
        }

        public String CoordenadasCursorCliente
        {
            get { return _CoordenadasCursorCliente; }
            set { _CoordenadasCursorCliente = value; }
        }
        public String CoordenadasCursorEnviadas
        {
            get { return _CoordenadasCursorEnviadas; }
            set { _CoordenadasCursorEnviadas = value; }
        }
        public String NombreReferencia
        {
            get { return _NombreReferencia; }
            set { _NombreReferencia = value; }
        }

        public String Anotaciones
        {
            get { return _Anotaciones; }
            set { _Anotaciones = value; }
        }

        public _Grupo GrupoPertenece
        {
            get { return GetAtributoRelacionado<_Grupo>("_GrupoPertenece"); }
            set { SetAtributoRelacionado("_GrupoPertenece", value); }
        }

        public String TempMensaje
        {
            get { return _TempMensaje; }
            set { _TempMensaje = value; }
        }

        public Boolean PermisoParaEjecutarAplicacion
        {
            get { return _PermisoParaEjecutarAplicacion; }
            set { _PermisoParaEjecutarAplicacion = value; }
        }

        public Bitmap ImagenPreview
        {
            get { return _ImagenPreview; }
            set { _ImagenPreview = value; }
        }

        public String MAC
        {
            get { return _MAC; }
            set { _MAC = value; }
        }

        public String NombreEquipo
        {
            get { return _NombreEquipo; }
            set { _NombreEquipo = value; }
        }

        public String IP
        {
            get { return _IP; }
            set { _IP = value; }
        }

        public String UsuarioLogin
        {
            get { return _UsuarioLogin; }
            set { _UsuarioLogin = value; }
        }

        public double PorcentajeMemoriaRAMUsada
        {
            get { return _PorcentajeMemoriaRAMUsada; }
            set { _PorcentajeMemoriaRAMUsada = value; }
        }

        public String PorcentajeHDUsados
        {
            get { return _PorcentajeHDUsados; }
            set { _PorcentajeHDUsados = value; }
        }

        public String UsuarioAdminWindows
        {
            get { return _UsuarioAdminWindows; }
            set { _UsuarioAdminWindows = value; }
        }

        public String PassAdminWindows
        {
            get { return _PassAdminWindows; }
            set { _PassAdminWindows = value; }
        }

        public String PassVNC
        {
            get { return _PassVNC; }
            set { _PassVNC = value; }
        }

        public String Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        public String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public String VersionWindows
        {
            get { return _VersionWindows; }
            set { _VersionWindows = value; }
        }

    }
}
