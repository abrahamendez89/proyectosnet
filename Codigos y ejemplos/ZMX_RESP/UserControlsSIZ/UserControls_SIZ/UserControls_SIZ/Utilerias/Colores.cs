using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UserControlsSIZ.Utilerias
{
    public class Colores
    {
        //public static Color AclararColor(Color color, float factor)
        //{
        //    float correctionFactor = 0.5f;
        //    float red = (255 - color.R) * correctionFactor + color.R;
        //    float green = (255 - color.G) * correctionFactor + color.G;
        //    float blue = (255 - color.B) * correctionFactor + color.B;
        //    Color lighterColor = Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        //    return lighterColor;
        //}

        //public static Color OscurecerColor(Color color, float factor)
        //{
        //    float correctionFactor = 0.5f;
        //    float red = (255 - color.R) * correctionFactor + color.R;
        //    float green = (255 - color.G) * correctionFactor + color.G;
        //    float blue = (255 - color.B) * correctionFactor + color.B;
        //    Color lighterColor = Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        //    return lighterColor;
        //}

        public static Color OscurecerColor(Color color, float correctionfactory = 50f)
        {
            const float hundredpercent = 100f;
            return Color.FromArgb
                (
                (byte)((float)color.A),
                (byte)(((float)color.R / hundredpercent) * correctionfactory),
                (byte)(((float)color.G / hundredpercent) * correctionfactory), 
                (byte)(((float)color.B / hundredpercent) * correctionfactory)
                );
        }
        public static Color AclararColor(Color color, float correctionfactory = 50f)
        {
            correctionfactory = correctionfactory / 100f;
            const float rgb255 = 255f;
            return Color.FromArgb
                (
                (byte)((float)color.A),
                (byte)((float)color.R + ((rgb255 - (float)color.R) * correctionfactory)), 
                (byte)((float)color.G + ((rgb255 - (float)color.G) * correctionfactory)), 
                (byte)((float)color.B + ((rgb255 - (float)color.B) * correctionfactory))
                );
        }

        public static Color ConvertirBrushAColor(Brush brush)
        {
            Ellipse e = new Ellipse();
            e.Fill = brush;
            Color c = ((System.Windows.Media.SolidColorBrush)(e.Fill)).Color;
            return c;
        }
        public static Brush ConvertirColorABrush(Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}
