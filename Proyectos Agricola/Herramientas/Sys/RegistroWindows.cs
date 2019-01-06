using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas.Sys
{
    public class RegistroWindows
    {
        public static void EscribirClaveWindows(String ruta, String valor)
        {
            // Abrimos la clave del registro con la que queremos trabajar
            RegistryKey rk1 = Registry.LocalMachine;
            // Nos movemos hasta la subclave donde queremos trabajar.
            // El parámetro boleano indica si la abrimos en solo lectura (false)
            // ó en lectura/escritura (true).
            rk1 = rk1.OpenSubKey(@"SOFTWARE\EBUTARKA", true);

            // Si devuelve null es que la clave no existe
            if (rk1 == null)
            {
                rk1 = Registry.LocalMachine;
                rk1.CreateSubKey(@"SOFTWARE\EBUTARKA", RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            // Crear una nueva clave
            // El método devuelve un RegistryKey apuntando
            // a la nueva entrada.

            

            RegistryKey rk2 = rk1.CreateSubKey("Prueba");

            // Obtener todas las subclaves contenidas en esta:
            String[] subKeys = rk1.GetSubKeyNames();

            // Borrar una clave vacia:
            rk1.DeleteSubKey("Prueba");

            // Borrar una clave recursivamente:
            rk1.DeleteSubKeyTree("Prueba");
        }
    }
}
