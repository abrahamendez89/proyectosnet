using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace UserControlsSIZ.Utilerias
{
    public class UtileriasControles
    {
        #region tooltips

        public enum Posicion
        {
            Izquierda = 0,
            Arriba = 1,
            Derecha = 2,
            Abajo = 3,
            Custom = 4
        }
        public static void MuestraToolTipSobreControl(DependencyObject padre, Control ctrl, String mensaje, int tiempo, Posicion posicion)
        {
            if (String.IsNullOrEmpty(mensaje))
                return;
            ToolTip t = new System.Windows.Controls.ToolTip();
            t.PlacementTarget = ctrl;
            t.Content = mensaje;
            ctrl.ToolTip = t;
            if (posicion == Posicion.Izquierda)
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Left;
            if (posicion == Posicion.Arriba)
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
            if (posicion == Posicion.Derecha)
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            if (posicion == Posicion.Abajo)
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            if (posicion == Posicion.Custom)
            {
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Custom;
                t.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(PositionTooltip);
            }

            t.IsOpen = true;

            Thread tCierraToolTip = new Thread(CierraToolTip);
            tCierraToolTip.IsBackground = true;
            tCierraToolTip.Start(new PaqueteControlToolTip() { Control = ctrl, ToolTip = t, Tiempo = tiempo, padre = padre });
        }
        public static void MuestraToolTipSobreControl(DependencyObject padre, Control ctrl, String mensaje, Posicion posicion)
        {
            if (padre == null || String.IsNullOrEmpty(mensaje))
                return;
            ToolTip t = new System.Windows.Controls.ToolTip();
            t.PlacementTarget = ctrl;
            t.Content = mensaje;
            ctrl.ToolTip = t;

            if (posicion == Posicion.Izquierda)
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Left;
            if (posicion == Posicion.Arriba)
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
            if (posicion == Posicion.Derecha)
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Right;
            if (posicion == Posicion.Abajo)
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            if (posicion == Posicion.Custom)
            {
                t.Placement = System.Windows.Controls.Primitives.PlacementMode.Custom;
                t.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(PositionTooltip);
            }

            t.IsOpen = true;

            ctrl.MouseLeave -= Ctrl_MouseLeave;
            ctrl.MouseLeave += Ctrl_MouseLeave;

            Thread tCierraToolTip = new Thread(CierraToolTip);
            tCierraToolTip.IsBackground = true;
            tCierraToolTip.Start(new PaqueteControlToolTip() { Control = ctrl, ToolTip = t, padre = padre });
        }

        private static void Ctrl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ToolTip t = (ToolTip)((Control)sender).ToolTip;
            if(t == null)
                return;
            t.IsOpen = false;
            ((Control)sender).ToolTip = null;
        }

        public static CustomPopupPlacement[] PositionTooltip(Size popupSize, Size targetSize, Point offset)
        {
            double offsetY = targetSize.Height / 2;// + popupSize.Height;
            double offsetX = targetSize.Width;

            return new CustomPopupPlacement[] { new CustomPopupPlacement(new Point(offsetX, offsetY), PopupPrimaryAxis.None) };
        }
        private static void CierraToolTip(Object o)
        {
            PaqueteControlToolTip paq = ((PaqueteControlToolTip)o);
            if (paq.Tiempo == 0)
                Thread.Sleep(5000);
            else
                Thread.Sleep(paq.Tiempo);

            //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(delegate (Object state)
            //{
            //    paq.ToolTip.IsOpen = false;
            //    paq.Control.ToolTip = null;
            //    return null;
            //}), null);

            if (paq.padre != null)
            {
                paq.padre.Dispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(delegate (Object state)
                {
                    paq.ToolTip.IsOpen = false;
                    paq.Control.ToolTip = null;
                    return null;
                }), null);
            }
            //else
            //{
            //    paq.ToolTip.IsOpen = false;
            //    paq.Control.ToolTip = null;
            //}

        }
        #endregion  
    }
    class PaqueteControlToolTip
    {
        public DependencyObject padre { get; set; }
        public Control Control { get; set; }
        public ToolTip ToolTip { get; set; }
        public int Tiempo { get; set; }
    }
}
