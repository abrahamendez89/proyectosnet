using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Herramientas.ORM;

namespace InterfazWPF.Modulos.Catalogos
{
    public interface iCatalogo
    {
        void _toolbox_Guardar();
        void _toolbox_Deshabilitar();
        void _toolbox_Nuevo();
        void AsignarObjetoDominio(ObjetoBase objeto);
    }
}
