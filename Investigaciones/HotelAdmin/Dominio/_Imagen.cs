using Herramientas.ORM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class _Imagen:ObjetoBase
    {
        private Bitmap _bi_imagen;

        public Bitmap Bi_imagen
        {
            get { return _bi_imagen; }
            set { _bi_imagen = value; }
        }
    }
}
