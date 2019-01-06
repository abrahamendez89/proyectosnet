using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCESO_DATOS.SuperClase;

namespace ACCESO_DATOS.Mapeo.Interfaces
{
    public interface IMapeoSelect
    {
        T ConvertirAObjeto<T>(DataRow dr) where T : CLASE_BASE;
        List<T> ConvertirAListaObjeto<T>(DataTable dt) where T : CLASE_BASE;
        String ObtenerQueryConsultaPorIdentificador<T>(T objeto) where T : CLASE_BASE;

    }
}
