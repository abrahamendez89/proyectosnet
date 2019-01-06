using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_VersionesDeSistema: ObjetoBase
    {
        private String _sCambiosEnLaVersion;
        private Boolean _bEsVersionLiberada;
        private Object _oArchivoDeVersion;

        public String SCambiosEnLaVersion
        {
            get { return _sCambiosEnLaVersion; }
            set { _sCambiosEnLaVersion = value; }
        }
        
        public Boolean BEsVersionLiberada
        {
            get { return _bEsVersionLiberada; }
            set { _bEsVersionLiberada = value; }
        }
        
        public Object OArchivoDeVersion
        {
            get { return _oArchivoDeVersion; }
            set { _oArchivoDeVersion = value; }
        }

        #region consultas
        public static readonly string ConsultaPorID = "select * from _sis_VersionesDeSistema where id = @id";
        public static readonly string ConsultaExisteNuevaVersion = "select top 1 id, _sCambiosEnLaVersion from _sis_VersionesDeSistema where _bEsVersionLiberada = 'True' order by id desc";
        public static readonly string ConsultaExisteNuevaVersionPruebas = "select top 1 id, _sCambiosEnLaVersion from _sis_VersionesDeSistema order by id desc";
        #endregion

    }
}
