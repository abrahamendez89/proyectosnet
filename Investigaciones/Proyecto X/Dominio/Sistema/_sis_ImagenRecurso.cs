using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_ImagenRecurso:ObjetoBase
    {
        private String _st_nombreImagen;
        private Bitmap _bm_Imagen;

        public String St_nombreImagen
        {
            get { return _st_nombreImagen; }
            set { _st_nombreImagen = value; }
        }
        public Bitmap Bm_Imagen
        {
            get { return _bm_Imagen; }
            set { _bm_Imagen = value; }
        }

        public static readonly String ConsultaTodos =  "select * from _sis_ImagenRecurso";
    }
}
