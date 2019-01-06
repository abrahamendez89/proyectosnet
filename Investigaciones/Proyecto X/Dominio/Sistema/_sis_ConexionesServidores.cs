using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_ConexionesServidores:ObjetoBase
    {
        private String _sIdentificadorServidor;
        private String _sServidorInstancia;
        private String _sBaseDatos;
        private String _sUsuario;
        private String _sContrasena;


        public String SIdentificadorServidor
        {
            get { return _sIdentificadorServidor; }
            set { _sIdentificadorServidor = value; }
        }
        
        public String SServidorInstancia
        {
            get { return _sServidorInstancia; }
            set { _sServidorInstancia = value; }
        }
        
        public String SBaseDatos
        {
            get { return _sBaseDatos; }
            set { _sBaseDatos = value; }
        }
        
        public String SUsuario
        {
            get { return _sUsuario; }
            set { _sUsuario = value; }
        }
        

        public String SContrasena
        {
            get { return _sContrasena; }
            set { _sContrasena = value; }
        }

        #region consultas
        public static String ConsultaTodos = "select * from _sis_ConexionesServidores";
        #endregion
    }
}
