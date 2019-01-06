using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Herramientas.WebCam
{
    public class Foto
    {
        #region fotos webcam
        private static Bitmap fotoWebCam = null;
        private static void video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            fotoWebCam = (Bitmap)eventArgs.Frame.Clone();
        }
        public static Bitmap ObtenerFotoDeWebCam()
        {
            try
            {
                VideoCaptureDevice FuenteDeVideo = null;
                FilterInfoCollection DispositivosDeVideo;
                fotoWebCam = null;
                DispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (DispositivosDeVideo.Count > 0)
                {
                    FuenteDeVideo = new VideoCaptureDevice(DispositivosDeVideo[0].MonikerString);
                    FuenteDeVideo.NewFrame += new NewFrameEventHandler(video_NuevoFrame);
                    if (FuenteDeVideo != null)
                    {
                        FuenteDeVideo.Start();
                        DateTime inicio = DateTime.Now;
                        while (fotoWebCam == null)
                        {
                            DateTime final = DateTime.Now;
                            TimeSpan duracion = final - inicio;
                            double segundosTotales = duracion.TotalSeconds;
                            int segundos = duracion.Seconds;
                            if (segundos == 3)
                            {
                                break;
                            }
                        }
                        FuenteDeVideo.SignalToStop();
                    }
                }
                return fotoWebCam;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
