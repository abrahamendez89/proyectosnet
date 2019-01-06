using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Herramientas.WPF
{
    class MouseOperations
    {
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static void SetCursorPosition(int X, int Y)
        {
            SetCursorPos(X, Y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0)
                ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }

        }

    }
    public class TecladoMouseControl
    {
        public static void SeleccionarControl(UIElement Objetivo, int tiempoLlegada, Boolean regresarMouseAPosicionInicial, int tiempoRegreso)
        {
            //Call the imported function with the cursor's current position
            
            System.Drawing.Point CurrentPosition = System.Windows.Forms.Control.MousePosition;



            Point controlPosition = new Point(0, 0);
            Objetivo.Dispatcher.Invoke(new Action(() =>
            {
                var element = VisualTreeHelper.GetParent(Objetivo) as UIElement;
                controlPosition = Objetivo.PointToScreen(new Point(Objetivo.RenderSize.Width / 2, Objetivo.RenderSize.Height/2));
            }));
            Point mousePosition = new Point(MouseOperations.GetCursorPosition().X, MouseOperations.GetCursorPosition().Y);

            int diviciones = 40;

            double diferenciaX = controlPosition.X + 5 - mousePosition.X;
            double diferenciaY = controlPosition.Y + 5 - mousePosition.Y;
            double avanceX = diferenciaX / diviciones;
            double avanceY = diferenciaY / diviciones;

            double inicioX = mousePosition.X;
            double inicioY = mousePosition.Y;

            int pause = tiempoLlegada / diviciones;

            for (int t = 0; t < diviciones; t++)
            {
                inicioX += avanceX;
                inicioY += avanceY;
                MouseOperations.SetCursorPosition((int)inicioX, (int)inicioY);

                Thread.Sleep(pause);
            }

            
            Point point = controlPosition;

            //MouseOperations.SetCursorPosition((int)point.X + 5, (int)point.Y + 5);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            if (regresarMouseAPosicionInicial)
            {
                MouseOperations.SetCursorPosition(CurrentPosition.X, CurrentPosition.Y);
            }
        }
    }
}
