using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Control
{
    public class UtileriaAD
    {
        public static String CnvDateToString(DateTime dtime)
        {
            String valor = (dtime).ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            return "TO_DATE('" + valor + "', 'yyyy/mm/dd hh24:mi:ss')";
        }

        public static String CnvBoolToString(Boolean boolean)
        {
            if (boolean)
                return "1";
            else
                return "0";
        }
        public static byte[] CnvObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            Byte[] array = ms.ToArray();

            ms.Close();
            ms.Dispose();
            bf = null;
            ms = null;

            return array;
        }
    }
}
