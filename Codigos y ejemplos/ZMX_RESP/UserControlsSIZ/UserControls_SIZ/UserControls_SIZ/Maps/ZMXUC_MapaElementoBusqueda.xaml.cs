using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControlsSIZ.Utilerias;

namespace UserControlsSIZ.Maps
{
    /// <summary>
    /// Interaction logic for ZMXUC_MapaElementoBusqueda.xaml
    /// </summary>
    public partial class ZMXUC_MapaElementoBusqueda : UserControl
    {
        public String ZMX_LocalidadNombre { get { return txtTitulo.Text; } set { txtTitulo.Text = value; } }
        public object ZMX_LocalidadObject { get; set; }

        public String ZMX_MunicipioNombre { get; set; }
        public String ZMX_EstadoNombre { get; set; }
        public String ZMX_PaisNombre { get; set; }


        public delegate void _ZMX_Click(ZMXUC_MapaElementoBusqueda meb);
        public event _ZMX_Click ZMX_Click;

        public ZMXUC_MapaElementoBusqueda()
        {
            InitializeComponent();
            this.MouseDown += ZMXUC_MapaElementoBusqueda_MouseDown;
        }



        public void SetColor(Brush color)
        {
            Color colorOscuroClr = Colores.OscurecerColor(Colores.ConvertirBrushAColor(color), 80);
            Brush colorOscuro = Colores.ConvertirColorABrush(colorOscuroClr);



            txtSubtitulo.Foreground = colorOscuro;
            txtTitulo.Foreground = colorOscuro;
            txtMensaje.Foreground = colorOscuro;
            iconAwesomeSIZ.IconoColor = colorOscuro;


            Color colr = Colores.ConvertirBrushAColor(color);

            Storyboard sb1 = (Storyboard)this.FindResource("OnMouseEnter1");
            Storyboard sb2 = (Storyboard)this.FindResource("OnMouseLeave1");

            //animacion del seleccionar
            ((ColorAnimationUsingKeyFrames)sb1.Children[0]).KeyFrames[0].Value = colorOscuroClr;
            ((ColorAnimationUsingKeyFrames)sb2.Children[0]).KeyFrames[0].Value = colorOscuroClr;
            ((ColorAnimationUsingKeyFrames)sb2.Children[0]).KeyFrames[1].Value = Colors.White;

            //animacion del resto de elementos
            ((ColorAnimationUsingKeyFrames)sb1.Children[1]).KeyFrames[0].Value = Colors.White;
            ((ColorAnimationUsingKeyFrames)sb1.Children[2]).KeyFrames[0].Value = Colors.White;
            ((ColorAnimationUsingKeyFrames)sb1.Children[3]).KeyFrames[0].Value = Colors.White;

            ((ColorAnimationUsingKeyFrames)sb2.Children[1]).KeyFrames[0].Value = Colors.White;
            ((ColorAnimationUsingKeyFrames)sb2.Children[1]).KeyFrames[1].Value = colorOscuroClr;

            ((ColorAnimationUsingKeyFrames)sb2.Children[2]).KeyFrames[0].Value = Colors.White;
            ((ColorAnimationUsingKeyFrames)sb2.Children[2]).KeyFrames[1].Value = colorOscuroClr;

            ((ColorAnimationUsingKeyFrames)sb2.Children[3]).KeyFrames[0].Value = Colors.White;
            ((ColorAnimationUsingKeyFrames)sb2.Children[3]).KeyFrames[1].Value = colorOscuroClr;
        }
        public void ZMX_MostrarMensaje(String mensaje)
        {
            txtMensaje.Text = mensaje;
        }
        public void ZMX_ActualizarSubtitulo()
        {
            txtSubtitulo.Text = ZMX_PaisNombre + ", " + ZMX_EstadoNombre + ", " + ZMX_MunicipioNombre;
        }
        private void ZMXUC_MapaElementoBusqueda_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ZMX_Click != null)
            {
                ZMX_Click(this);
            }
        }
    }
}
