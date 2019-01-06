using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Herramientas.Sys
{
    public class PCInfo
    {
        public static double ObtenerPorcentajeMemoriaRAMEnuso()
        {
            var wmiObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            var memoryValues = wmiObject.Get().Cast<ManagementObject>().Select(mo => new
            {
                FreePhysicalMemory = Double.Parse(mo["FreePhysicalMemory"].ToString()),
                TotalVisibleMemorySize = Double.Parse(mo["TotalVisibleMemorySize"].ToString())
            }).FirstOrDefault();
            double percent = 0;
            if (memoryValues != null)
            {
                percent = ((memoryValues.TotalVisibleMemorySize - memoryValues.FreePhysicalMemory) / memoryValues.TotalVisibleMemorySize) * 100;
            }
            return percent;
        }
        public static List<String> ObtenerPorcentajeEspacioDisponibleEnDisco()
        {
            List<String> info = new List<string>();
            foreach (ManagementObject volume in new ManagementObjectSearcher("Select * from Win32_Volume").Get())
            {
                if (volume["FreeSpace"] != null && !volume["Name"].ToString().ToLower().Contains("volume"))
                {
                    double porcentaje = (Convert.ToDouble(volume["FreeSpace"].ToString()) * 100) / Convert.ToDouble(volume["Capacity"].ToString());
                    info.Add(volume["Name"].ToString().Replace("\\", "").Replace(":", "").Replace("?", "") + ": " + (Convert.ToDouble(100) - porcentaje).ToString("0.00") + "%");

                }
            }
            info.Sort();
            return info;
        }
        public static String ObtenerMACAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = string.Empty;
            long maxSpeed = -1;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                //log.Debug(
                //    "Found MAC Address: " + nic.GetPhysicalAddress() +
                //    " Type: " + nic.NetworkInterfaceType);

                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed &&
                    !string.IsNullOrEmpty(tempMac) &&
                    tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    //log.Debug("New Max Speed = " + nic.Speed + ", MAC: " + tempMac);
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }

            return macAddress;
        }
        public static String ObtenerVersionWindows()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }
        public static String ObtenerMarca()
        {
            String modelo = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject mo in mos.Get())
            {
                modelo = mo["manufacturer"].ToString();
            }
            return modelo;
        }
        public static String ObtenerModelo()
        {
            String modelo = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject mo in mos.Get())
            {
                modelo = mo["model"].ToString();
            }
            return modelo;
        }

    }

}
