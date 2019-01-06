using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//using AccesoDatos.Mapeo;
using Dominio;
using System.Xml.Serialization;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    [XmlRoot("_sis_Usuario")]
    [XmlInclude(typeof(_sis_Usuario))] // include type class Person
    public class _sis_Usuario:ObjetoBase
    {
        private String _sCuenta;
        private String _sContrasena;
        private String _sEmail;
        private String _sNombreCompleto;
        private _sis_Rol _rolSistema;
        private _sis_ImagenAsociada _imagenAsociada;
        private Boolean _bEsAdministradorDeSistema;
        //private _sis_SesionGuardada _SesionGuardada;
        private _sis_Contenedor _ContenedorEspecial;
        private Boolean _bEstaDesactivado;
        [XmlArray("_Marcadores")]
        [XmlArrayItem("_sis_FormularioPermisosPorRol")]
        private List<_sis_FormularioPermisosPorRol> _Marcadores;
        private Boolean _bPuedeAccederCatalogoRapido;
        private Boolean _bEsSoporte;
        private Boolean _bEstaConectadoAlSistema;
        private Boolean _bRecibeVersionesPrueba;

        
        private String _sMensajeDeIntentoDeConexionEnOtroEquipo;
        public Boolean BRecibeVersionesPrueba
        {
            get { return _bRecibeVersionesPrueba; }
            set { _bRecibeVersionesPrueba = value; }
        }
        public String SMensajeDeIntentoDeConexionEnOtroEquipo
        {
            get { return _sMensajeDeIntentoDeConexionEnOtroEquipo; }
            set { _sMensajeDeIntentoDeConexionEnOtroEquipo = value; }
        }

        public Boolean BEstaConectadoAlSistema
        {
            get { return _bEstaConectadoAlSistema; }
            set { _bEstaConectadoAlSistema = value; }
        }

        public Boolean BEsSoporte
        {
            get { return _bEsSoporte; }
            set { _bEsSoporte = value; }
        }

        public Boolean BPuedeAccederCatalogoRapido
        {
            get { return _bPuedeAccederCatalogoRapido; }
            set { _bPuedeAccederCatalogoRapido = value; }
        }
        public Boolean BEstaDesactivado
        {
            get { return _bEstaDesactivado; }
            set { _bEstaDesactivado = value; }
        }

        public _sis_Contenedor ContenedorEspecial
        {
            get { return GetAtributoRelacionado<_sis_Contenedor>("_ContenedorEspecial"); }
            set { SetAtributoRelacionado("_ContenedorEspecial",value); }
        }
        //public _sis_SesionGuardada SesionGuardada
        //{
        //    get { return CargarAtributoRelacionado<_sis_SesionGuardada>("_SesionGuardada"); }
        //    set { setAtributoRelacionado("_SesionGuardada", value); }
        //}
        public Boolean EsAdministradorDeSistema
        {
            get { return _bEsAdministradorDeSistema; }
            set { _bEsAdministradorDeSistema = value; }
        }

        public _sis_ImagenAsociada ImagenAsociada
        {
            get { return GetAtributoRelacionado<_sis_ImagenAsociada>("_imagenAsociada"); }
            set { SetAtributoRelacionado("_imagenAsociada", value); }
        }
        public String SNombreCompleto
        {
            get { return _sNombreCompleto; }
            set { _sNombreCompleto = value; }
        }
        public String SEmail
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }
        public _sis_Rol RolSistema
        {
            get { return GetAtributoRelacionado<_sis_Rol>("_rolSistema"); }
            set { SetAtributoRelacionado("_rolSistema",value); }
        }

        public String Cuenta
        {
            get { return _sCuenta; }
            set { _sCuenta = value; }
        }
        public String Contrasena
        {
            get { return _sContrasena; }
            set { _sContrasena = value; }
        }
        #region Consultas usadas 
        public static readonly String consultaPorID = "select * from _sis_usuario where id = @id";
        public static readonly String consultaPorCuenta = "select * from _sis_usuario where _sCuenta = @_sCuenta";
        public static readonly String consultaPorUsuarioYContra = "select * from _sis_usuario where _sCuenta = @_sCuenta and _sContrasena = @_sContrasena";
        public static readonly String consultaTodos = "select * from _sis_usuario";
        public static readonly String consultaCantidadDeUsuariosAdministradores = "select count(id) from _sis_usuario where _bEsAdministradorDeSistema = @valor";
        public static readonly String consultaCantidadDeUsuarios = "select count(id) from _sis_usuario";
        public static readonly String consultaPorUsuariosSoporte = "select * from _sis_usuario where _bEsSoporte = 'True'";
        public static readonly String consultaPorUsuariosAdministradores = "select u.* from _sis_Usuario u inner join _sis_Rol r on u._rolSistema = r.id where u._bEsAdministradorDeSistema = 'True' or r._bEsAdministradorDeSistema = 'True'";
        #endregion
    }
}
