using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Herramientas.Net
{
    public class IPNet
    {
        public static String ObtenerIPLocal()
        {
            IPAddress[] IPS = Dns.GetHostAddresses(Dns.GetHostName());
            String ipLocal = "";
            foreach (IPAddress ip in IPS)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    ipLocal = ip.ToString();
            }
            return ipLocal;
        }
        public static String ObtenerIPInternet()
        {
            string strIP = "";
            try
            {
                WebClient wc = new WebClient();
                strIP = wc.DownloadString("http://checkip.dyndns.org");
                strIP = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(strIP).Value;
                wc.Dispose();
            }
            catch { }
            return strIP;
        }
    }
}
