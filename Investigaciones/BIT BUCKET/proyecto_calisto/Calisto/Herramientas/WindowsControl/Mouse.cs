using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Herramientas.WindowsControl
{
    public class Mouse
    {
        public static void MoverCursorACoordenada(int x, int y)
        {
            Cursor.Position = new Point(x,y);
        }
    }
}
