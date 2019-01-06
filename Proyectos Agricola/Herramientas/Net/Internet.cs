using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Herramientas.Net
{
    public class Internet
    {
        public static double ObtenerVelocidadInternet()
        {
            try
            {
                double velocidadInternet = 0;

                WebClient client = new WebClient();
                //Uri URL = new Uri("http://chandra.harvard.edu/graphics/resources/desktops/2006/1e0657_1280.jpg");
                Uri URL = new Uri("https://dl.dropboxusercontent.com/u/10229762/1MB.txt");
                DateTime Inicio = DateTime.Now;
                byte[] data = client.DownloadData(URL);
                DateTime Termino = DateTime.Now;

                TimeSpan transcurrido = Termino - Inicio;

                double kilobitsEntreTiempo = (Convert.ToDouble(data.Length) / 1024.0 / 1024.0) * 8.0 / (transcurrido.TotalSeconds);

                velocidadInternet = Math.Round(kilobitsEntreTiempo, 2);
                return velocidadInternet;
            }
            catch
            {
                return 0;
            }

        }
        public static double ObtenerUsoAnchoBanda()
        {
            try
            {
                long bytesReceivedPrev = 0;
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                long bytesReceived = 0;
                foreach (NetworkInterface inf in interfaces)
                {
                    if (inf.OperationalStatus == OperationalStatus.Up &&
                        inf.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        inf.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&
                        inf.NetworkInterfaceType != NetworkInterfaceType.Unknown && !inf.IsReceiveOnly)
                    {
                        bytesReceived += inf.GetIPv4Statistics().BytesReceived;
                    }
                }

                if (bytesReceivedPrev == 0)
                {
                    bytesReceivedPrev = bytesReceived;
                }
                long bytesUsed = bytesReceived - bytesReceivedPrev;
                double kBytesUsed = bytesUsed / 1024;
                double mBytesUsed = kBytesUsed / 1024;
                //internetUsage.Add(now, mBytesUsed);
                //if (internetUsage.Count > 20)
                //{
                //    internetUsage.Remove(internetUsage.Keys.First());
                //}
                bytesReceivedPrev = bytesReceived;

                return mBytesUsed;
            }
            catch
            {
                return 0;
            }
        }
    }
}
