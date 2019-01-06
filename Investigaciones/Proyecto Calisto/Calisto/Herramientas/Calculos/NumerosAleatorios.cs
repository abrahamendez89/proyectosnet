using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Herramientas.Calculos
{
    public class NumerosAleatorios
    {
        public static int ObtenerInt(int minimo, int maximo)
        {
            Thread.Sleep(5);
            Random rnd2 = new Random((int)DateTime.Now.Ticks);
            int nRan2 = rnd2.Next(1, 10);

            Thread.Sleep(nRan2);

            Random rnd = new Random((int)DateTime.Now.Ticks * nRan2 + nRan2);
            int nRan = rnd.Next(minimo, maximo);
            return nRan;
        }
    }
}
