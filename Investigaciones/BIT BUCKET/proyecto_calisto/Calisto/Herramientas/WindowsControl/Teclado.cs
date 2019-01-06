using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsInput;

namespace Herramientas.WindowsControl
{
    public class Teclado
    {
        public static void PulsarTecla(String codigoTecla)
        {
            VirtualKeyCode key = (VirtualKeyCode)System.Enum.Parse(typeof(VirtualKeyCode), codigoTecla);
            InputSimulator.SimulateKeyPress(key);
        }

        public static String ConvertirFormsKeyACodigo(Keys formKeys)
        {
            System.Windows.Input.Key kW = (System.Windows.Input.Key)Enum.Parse(typeof(System.Windows.Input.Key), formKeys.ToString());
            VirtualKeyCode CodeOfKeyToEmulate = (VirtualKeyCode)KeyInterop.VirtualKeyFromKey(kW);
            String keyString = CodeOfKeyToEmulate.ToString();
            return keyString;
        }

        public static String ConvertirWindowsKeyACodigo(Key formKeys)
        {
            VirtualKeyCode CodeOfKeyToEmulate = (VirtualKeyCode)KeyInterop.VirtualKeyFromKey(formKeys);
            String keyString = CodeOfKeyToEmulate.ToString();
            return keyString;
        }

    }
}
