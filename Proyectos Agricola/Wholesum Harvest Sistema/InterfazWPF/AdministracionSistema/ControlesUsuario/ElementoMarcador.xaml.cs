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
using Dominio.Sistema;

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para ElementoMarcador.xaml
	/// </summary>
	public partial class ElementoMarcador : UserControl
	{
        private _sis_FormularioPermisosPorRol formularioPermiso;
		public ElementoMarcador(_sis_FormularioPermisosPorRol formularioPermiso)
		{
			this.InitializeComponent();
            this.formularioPermiso = formularioPermiso;
            Titulo = formularioPermiso.Formulario.STituloFormulario;
            this.MouseDown += ElementoMarcador_MouseDown;
            this.MouseEnter += ElementoMarcador_MouseEnter;
            this.MouseLeave += ElementoMarcador_MouseLeave;

		}

        void ElementoMarcador_MouseLeave(object sender, MouseEventArgs e)
        {
            txt_titulo.TextDecorations = null;
        }

        void ElementoMarcador_MouseEnter(object sender, MouseEventArgs e)
        {
            txt_titulo.TextDecorations = TextDecorations.Underline;
        }

        void ElementoMarcador_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (clickElementoMarcador != null)
                clickElementoMarcador(formularioPermiso);
        }
        public String Titulo { get { return txt_titulo.Text; } set { txt_titulo.Text = value; } }
        
        public delegate void ClickElementoMarcador(_sis_FormularioPermisosPorRol formulario);
        public event ClickElementoMarcador clickElementoMarcador;

	}
}