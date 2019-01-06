using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.SuperClase;

namespace ACCESO_DATOS.Mapeo.Interfaces
{
    public interface IMapeoInsert
    {
        String Convertir<T>(T objeto) where T : CLASE_BASE;
        String Convertir<T>(List<T> lista) where T : CLASE_BASE;
    }
}
