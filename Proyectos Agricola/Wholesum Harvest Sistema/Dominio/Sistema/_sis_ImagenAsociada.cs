﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace Dominio.Sistema
{
    public class _sis_ImagenAsociada:ObjetoBase
    {
        private Bitmap _Imagen;

        public Bitmap Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
       
    }
}
