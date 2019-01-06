using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControlsSIZ.Iconos;

namespace UserControlsSIZ.Toolbar
{
    /// <summary>
    /// Interaction logic for btnToolbar.xaml
    /// </summary>
    public partial class ToolbarBtn : UserControl
    {
        private Popup popup;
        private String toolbarTooltip;
        private String ColorDeshabilitado = "#FF888B8E";

        public delegate void ToolbarBtnClick(ToolbarBtn boton);
        public event ToolbarBtnClick toolbarBtnClick;

        public delegate void _ZMX_EjecutarDespuesDeMouseUp(ToolbarBtn boton);
        public event _ZMX_EjecutarDespuesDeMouseUp ZMX_EjecutarDespuesDeMouseUp;

        public delegate Boolean _ZMX_ValidarAntesDeClick(ToolbarBtn boton);
        public event _ZMX_ValidarAntesDeClick ZMX_ValidarAntesDeClick;

        public String ToolbarBtnTooltip
        {
            get { return toolbarTooltip; }
            set
            {
                if (value == null)
                {
                    popup = null;
                    return;
                }
                toolbarTooltip = value;
                popup = new Popup();
                ToolbarTooltip tt = new ToolbarTooltip();
                tt.Margin = new Thickness(20);
                tt.Text = value;
                popup.Child = tt;
                popup.PlacementTarget = this;
                popup.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                popup.AllowsTransparency = true;
            }
        }
        public ToolbarBtn()
        {
            InitializeComponent();
            SizeChanged += BtnToolbar_SizeChanged;
            MouseDown += BtnToolbar_MouseDown;
            MouseUp += BtnToolbar_MouseUp;

            //ico.MouseDown += BtnToolbar_MouseDown;
            //ico.MouseUp += BtnToolbar_MouseUp;

            this.MouseEnter += BtnToolbar_MouseEnter;
            this.MouseLeave += BtnToolbar_MouseLeave;
            BrushConverter tb = new BrushConverter();
            BtnColor = (Color)ColorConverter.ConvertFromString("#25a0d9");

        }

        private void BtnToolbar_MouseLeave(object sender, MouseEventArgs e)
        {
            if (popup != null)
            {
                popup.IsOpen = false;
            }
            if (!ToolbarBtnEstaHabilitado)
                return;
            //Storyboard sb2 = (Storyboard)this.FindResource("OnMouseLeave1");
            //sb2.Begin();

            CirculoExterior.Stroke = new SolidColorBrush(color);
            CirculoInterior.Fill = new SolidColorBrush(color);
            ico.IconoColor = Brushes.White;
        }

        private void BtnToolbar_MouseEnter(object sender, MouseEventArgs e)
        {
            if (popup != null)
            {
                popup.IsOpen = true;
            }
            if (!ToolbarBtnEstaHabilitado)
                return;
            //Storyboard sb1 = (Storyboard)this.FindResource("OnMouseEnter1");
            //sb1.Begin();

            CirculoExterior.Stroke = new SolidColorBrush(color);
            CirculoInterior.Fill = new SolidColorBrush(Colors.White);
            ico.IconoColor = new SolidColorBrush(color);
        }

        private double toolbarBtnFontSize;
        public double ToolbarBtnFontSize { get { return toolbarBtnFontSize; } set { setFontSize(value); toolbarBtnFontSize = value; } }
        private Boolean toolbarBtnEstaHabilitado = true;
        public Boolean ToolbarBtnEstaHabilitado
        {
            get { return toolbarBtnEstaHabilitado; }
            set
            {
                toolbarBtnEstaHabilitado = value;
                if (!toolbarBtnEstaHabilitado)
                {
                    //CirculoInterior.Fill = new BrushConverter().ConvertFromString(ColorDeshabilitado) as SolidColorBrush;
                    //CirculoExterior.Stroke = new BrushConverter().ConvertFromString(ColorDeshabilitado) as SolidColorBrush;

                    AplicarColor((Color)ColorConverter.ConvertFromString(ColorDeshabilitado));

                    this.Cursor = Cursors.Arrow;
                }
                else
                {
                    //CirculoInterior.Fill = new SolidColorBrush(btnColor);
                    //CirculoExterior.Stroke = new SolidColorBrush(color);

                    AplicarColor(color);
                    this.Cursor = Cursors.Hand;
                }
            }
        }
        private void setFontSize(double value)
        {
            ico.IconoFontSize = value;
        }
        Color color;
        private void SetColor(Color color)
        {
            this.color = color;
            if (popup != null)
            {
                ((ToolbarTooltip)popup.Child).StrokeTooltip = new SolidColorBrush(color);
            }
            if (!ToolbarBtnEstaHabilitado)
                return;

            AplicarColor(color);

            //Storyboard sb1 = (Storyboard)this.FindResource("OnMouseEnter1");
            //Storyboard sb2 = (Storyboard)this.FindResource("OnMouseLeave1");
            //Storyboard sb3 = (Storyboard)this.FindResource("OnMouseDown1");
            //Storyboard sb4 = (Storyboard)this.FindResource("OnMouseUp1");
            //BrushConverter bc = new BrushConverter();

            //((ColorAnimationUsingKeyFrames)sb1.Children[1]).KeyFrames[1].Value = color;

            //((ColorAnimationUsingKeyFrames)sb2.Children[0]).KeyFrames[1].Value = color;
            //((ColorAnimationUsingKeyFrames)sb2.Children[1]).KeyFrames[0].Value = color;

            //((ColorAnimationUsingKeyFrames)sb3.Children[1]).KeyFrames[0].Value = color;

            //((ColorAnimationUsingKeyFrames)sb4.Children[1]).KeyFrames[0].Value = color;
            //((ColorAnimationUsingKeyFrames)sb4.Children[1]).KeyFrames[1].Value = color;

            //CirculoExterior.Stroke = new SolidColorBrush(color);
            //CirculoInterior.Fill = new SolidColorBrush(color);

        }
        private void AplicarColor(Color color)
        {
            if (popup != null)
            {
                ((ToolbarTooltip)popup.Child).StrokeTooltip = new SolidColorBrush(color);
            }
            Storyboard sb1 = (Storyboard)this.FindResource("OnMouseEnter1");
            Storyboard sb2 = (Storyboard)this.FindResource("OnMouseLeave1");
            Storyboard sb3 = (Storyboard)this.FindResource("OnMouseDown1");
            Storyboard sb4 = (Storyboard)this.FindResource("OnMouseUp1");
            BrushConverter bc = new BrushConverter();

            ((ColorAnimationUsingKeyFrames)sb1.Children[1]).KeyFrames[1].Value = color;

            ((ColorAnimationUsingKeyFrames)sb2.Children[0]).KeyFrames[1].Value = color;
            ((ColorAnimationUsingKeyFrames)sb2.Children[1]).KeyFrames[0].Value = color;

            ((ColorAnimationUsingKeyFrames)sb3.Children[1]).KeyFrames[0].Value = color;

            ((ColorAnimationUsingKeyFrames)sb4.Children[1]).KeyFrames[0].Value = color;
            ((ColorAnimationUsingKeyFrames)sb4.Children[1]).KeyFrames[1].Value = color;

            CirculoExterior.Stroke = new SolidColorBrush(color);
            CirculoInterior.Fill = new SolidColorBrush(color);
        }
        private Color btnColor;
        private Brush btnBrush;
        public Color BtnColor { get { return btnColor; } set { btnColor = value; SetColor(value); } }
        public Brush BtnBrush { get { return btnBrush; } set { btnBrush = value; if (value != null) SetColor(getColorFromBrush(value)); } }


        //public static readonly DependencyProperty BtnColorProperty =
        //DependencyProperty.Register("BtnColor", typeof(Color), typeof(ToolbarBtn), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(BtnColorChange)));

        //private static void BtnColorChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    try
        //    {
        //        var icono = d as ToolbarBtn;
        //        icono.BtnColor = (Color)e.NewValue;
        //    }
        //    catch { }
        //}

        public static readonly DependencyProperty BtnBrushProperty =
        DependencyProperty.Register("BtnBrush", typeof(Brush), typeof(ToolbarBtn), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(BtnBrushChange)));

        private static void BtnBrushChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (e.NewValue != null)
                {
                    var icono = d as ToolbarBtn;
                    icono.BtnBrush = (Brush)e.NewValue;
                    icono.SetColor(icono.getColorFromBrush((Brush)e.NewValue));
                }
            }
            catch { }
        }


        public Color getColorFromBrush(Brush brush)
        {
            Ellipse e = new Ellipse();
            e.Fill = brush;
            Color c = ((System.Windows.Media.SolidColorBrush)(e.Fill)).Color;
            return c;
        }

        private double heightDefault = 0.55;
        private double heightPresionado = 0.52;

        private void BtnToolbar_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!ToolbarBtnEstaHabilitado)
                return;
            ico.Height = this.ActualHeight * heightDefault;
            CirculoExterior.StrokeThickness = this.ActualHeight * 0.035;

            if (ZMX_ValidarAntesDeClick != null)
            {
                if (!ZMX_ValidarAntesDeClick(this))
                    return;
            }

            if (toolbarBtnClick != null)
            {
                toolbarBtnClick(this);
            }

            if (ToolbarBtnEstaHabilitado)
            {
                //CirculoExterior.Stroke = new SolidColorBrush(color);
                //CirculoInterior.Fill = new SolidColorBrush(color);
                
                AplicarColor(color);
                ico.IconoColor = new SolidColorBrush(Colors.White);
                this.Cursor = Cursors.Hand;
            }
            else
            {
                //CirculoInterior.Fill = new BrushConverter().ConvertFromString(ColorDeshabilitado) as SolidColorBrush;
                //CirculoExterior.Stroke = new BrushConverter().ConvertFromString(ColorDeshabilitado) as SolidColorBrush;
                

                AplicarColor((Color)ColorConverter.ConvertFromString(ColorDeshabilitado));
                ico.IconoColor = new SolidColorBrush(Colors.White);

                this.Cursor = Cursors.Arrow;
            }
            if (ZMX_EjecutarDespuesDeMouseUp != null)
            {
                ZMX_EjecutarDespuesDeMouseUp(this);
            }

        }

        private void BtnToolbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!ToolbarBtnEstaHabilitado)
                return;
            ico.Height = this.ActualHeight * heightPresionado;
            CirculoExterior.StrokeThickness = this.ActualHeight * 0.048;

            CirculoExterior.Stroke = new SolidColorBrush(color);
            CirculoInterior.Fill = new SolidColorBrush(Colors.White);
            ico.IconoColor = new SolidColorBrush(color);
        }

        public double DiametroPx { get { return this.Height; } set { this.Height = value; this.Width = value; } }
        public IconAwesomeSIZ.AwesomeIcons Icono { get { return ico.Icono; } set { ico.Icono = value; } }

        private void BtnToolbar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                this.Height = this.Width;
                ico.Height = this.ActualHeight * heightDefault;
                CirculoExterior.StrokeThickness = this.ActualHeight * 0.035;
                CirculoInterior.Margin = new Thickness(this.ActualHeight * 0.1);
            }
            catch { }
        }
    }
}
