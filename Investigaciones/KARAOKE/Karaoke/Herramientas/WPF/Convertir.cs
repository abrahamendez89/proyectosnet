using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Herramientas.WPF
{
    public class Convertir
    {
        public static String KeyAString(Key key)
        {
            return key.ToString();
        }
        public static Key StringAKey(String str)
        {
            KeyConverter k = new KeyConverter();
            Key mykey = (Key)k.ConvertFromString(str);
            return mykey;
        }
    }
}
