using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para ImagenConResplandor.xaml
	/// </summary>
	public partial class ImagenConResplandor : UserControl
	{
        public ImageSource Imagen { get { return img_Frente.Source; } set { img_Frente.Source = value; img_Resplandor.Source = value; UpdateLayout(); } }
        public Color ColorResplandor { get { if (img_Resplandor.Effect != null) return ((System.Windows.Media.Effects.DropShadowEffect)img_Resplandor.Effect).Color; else return Colors.Black; } set { img_Resplandor.Effect = new System.Windows.Media.Effects.DropShadowEffect() { Color = value, BlurRadius = 10, ShadowDepth = 0 }; } }
		public ImagenConResplandor()
		{
			this.InitializeComponent();
		}
	}
}