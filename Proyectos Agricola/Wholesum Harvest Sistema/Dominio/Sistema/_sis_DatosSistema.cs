using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_DatosSistema:ObjetoBase
    {
        private String _sTitulo;
        private Bitmap _bImagenFondoPrincipal;
        private Bitmap _bImagenFondoLogin;
        private Bitmap _bImagenIcono;
        private int _iSegundosAutobloqueo;
        private int _iSegundosParaAlmacenObjetos;
        private Boolean _bUsarProteccionDeCuentasEnLogin;

        public Boolean BUsarProteccionDeCuentasEnLogin
        {
            get { return _bUsarProteccionDeCuentasEnLogin; }
            set { _bUsarProteccionDeCuentasEnLogin = value; }
        }

        public int ISegundosParaAlmacenObjetos
        {
            get { return _iSegundosParaAlmacenObjetos; }
            set { _iSegundosParaAlmacenObjetos = value; }
        }

        public int ISegundosAutobloqueo
        {
            get { return _iSegundosAutobloqueo; }
            set { _iSegundosAutobloqueo = value; }
        }

        public String STitulo
        {
            get { return _sTitulo; }
            set { _sTitulo = value; }
        }
        public Bitmap BImagenFondoPrincipal
        {
            get { return _bImagenFondoPrincipal; }
            set { _bImagenFondoPrincipal = value; }
        }
        public Bitmap BImagenIcono
        {
            get { return _bImagenIcono; }
            set { _bImagenIcono = value; }
        }
        public Bitmap BImagenFondoLogin
        {
            get { return _bImagenFondoLogin; }
            set { _bImagenFondoLogin = value; }
        }

        #region consultas
        public static readonly String ConsultaTodos = "select * from _sis_DatosSistema";
        #endregion
    }
}
