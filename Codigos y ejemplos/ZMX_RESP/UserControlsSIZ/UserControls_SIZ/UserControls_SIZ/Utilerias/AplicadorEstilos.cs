using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace UserControlsSIZ.Utilerias
{
    public static class AplicadorEstilos
    {
        public static void EfectoZebraGrid(RadGridView grid)
        {
            grid.AlternationCount = 2;
            grid.AlternateRowBackground = (Brush)new BrushConverter().ConvertFrom("#f0f0f0");
        }
    }
}
