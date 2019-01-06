using Herramientas.Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Dominio.algo
{
    public class AlmacenObjetos
    {
        //public static delegate void SeBorroAlmacen();
        //public static event SeBorroAlmacen seBorroAlmacen;
        
        static Dictionary<Type, Dictionary<long, ObjetoBase>> almacen = new Dictionary<Type, Dictionary<long, ObjetoBase>>();
        static int SegundosTotales;
        static Thread hiloT;
        static long contador;
        private static Boolean ActivarLog = false;

        public static void TiempoExistenciaCache(int segundos)
        {
            if (segundos == 0)
                segundos = 300;
            SegundosTotales = segundos;
            if(ActivarLog) Log.EscribirLog("ALAMCEN MENSAJE: El almacen se inicio con un tiempo de "+SegundosTotales +" segundos.");

            if (hiloT != null)
                hiloT.Abort();

            hiloT = new Thread(AutoReseteo);
            hiloT.Start();

        }
        public static void BorrarAlmacen()
        {
            almacen.Clear();
            contador = 0;
        }
        public static void CerrarAlmacen()
        {
            if(hiloT != null)// && hiloT.ThreadState == ThreadState.Running)
                hiloT.Abort();
        }
        private static void AutoReseteo()
        {
            contador = 0;
            while (true)
            {
                Thread.Sleep(1000);
                if (SegundosTotales != 0 && contador != 0 && contador % SegundosTotales == 0)
                {
                    almacen.Clear();
                    if (ActivarLog) Log.EscribirLog("ALAMCEN MENSAJE: Se eliminaron los elementos del almacen.");

                    ////Log.EscribirLog("----------------");
                    ////Log.EscribirLog("Objetos guardados en el almacen:");
                    ////foreach (Type tc in almacen.Keys)
                    ////{
                    ////    Log.EscribirLog(tc.Name + ": " + almacen[tc].Count);
                    ////}
                    ////Log.EscribirLog("----------------");
                    contador = 0;
                    //if (seBorroAlmacen != null)
                    //    seBorroAlmacen();
                }
                //else if (contador % 20 == 0)
                //{
                //    Log.EscribirLog("----------------");
                //    Log.EscribirLog("Objetos guardados en el almacen:");
                //    foreach (Type tc in almacen.Keys)
                //    {
                //        Log.EscribirLog(tc.Name + ": " + almacen[tc].Count);
                //        foreach (long obj in almacen[tc].Keys)
                //            Log.EscribirLog("     " + almacen[tc][obj].Id);
                //    }
                //    Log.EscribirLog("----------------");
                //}
                contador++;
            }
        }

        public static void GuardarObjeto<T>(T objetoGuardar)
        {
            GuardarObjeto((ObjetoBase)(Object)objetoGuardar);
        }
        public static void GuardarObjeto(ObjetoBase objetoGuardar)
        {
            Type tipo = objetoGuardar.GetType();
            
            if (!almacen.ContainsKey(tipo))
            {
                
                almacen.Add(tipo, new Dictionary<long, ObjetoBase>());
            }

            if (almacen[tipo].ContainsKey(objetoGuardar.Id))
            {
                if (ActivarLog) Log.EscribirLog("ALAMCEN <-   : ACTUALIZADO. [OBJETO: " + tipo.Name + " ID: " + objetoGuardar.Id + "]");
                almacen[tipo][objetoGuardar.Id] = objetoGuardar;
            }
            else
            {
                if (ActivarLog) Log.EscribirLog("ALAMCEN <-   : AGREGADO [OBJETO: " + tipo.Name + " ID: " + objetoGuardar.Id + "]");
                almacen[tipo].Add(objetoGuardar.Id, objetoGuardar);
            }

        }

        public static ObjetoBase ObtenerObjeto(Type tipo, long id)
        {
            if (almacen.ContainsKey(tipo))
            {
                if (almacen[tipo].ContainsKey(id))
                {
                    if (ActivarLog) Log.EscribirLog("ALAMCEN    ->: OBTENIDO [OBJETO: " + tipo.Name + " ID: " + id + "]");
                    ObjetoBase objeto = almacen[tipo][id];
                    //objeto.EliminarCache();
                    return objeto;
                }
            }
            return null;
        }
        public static T ObtenerObjeto<T>(long id)
        {
            return (T)Convert.ChangeType(ObtenerObjeto(typeof(T), id), typeof(T));
        }

    }
}
