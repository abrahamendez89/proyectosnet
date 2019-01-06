using Dominio.Modulos.ProgramaSiembra;
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
using LogicaNegocios.ProgramaSiembra;

namespace InterfazWPF
{
	/// <summary>
	/// Lógica de interacción para EspacioSeleccionadoInicio.xaml
	/// </summary>
	public partial class EspacioSeleccionadoInicio : UserControl
	{
        public delegate void ClickInicioRecorrido();
        public event ClickInicioRecorrido clickInicioRecorrido;

        public delegate void SeAgregoEspacioEvento(EspacioGrafico espacioSeleccionado);
        public event SeAgregoEspacioEvento seAgregoEspacioEvento;

        public _ps_EspacioFisico EspacioPadre { get; set; }

		public EspacioSeleccionadoInicio()
		{
			this.InitializeComponent();
            this.MouseDown += EspacioSeleccionadoInicio_MouseDown;
            Drop += EspacioGrafico_Drop;
		}
        void EspacioGrafico_Drop(object sender, DragEventArgs e)
        {
            EspacioGrafico espacio = (EspacioGrafico)e.Data.GetData(typeof(EspacioGrafico));

            if (!espacio.EspacioRepresentado.st_Nombre_espacio.Equals(EspacioPadre.st_Nombre_espacio))
            {
                //this.EspacioPadre.ll_Espacios_fisicos_dentro.Add(espacio.EspacioRepresentado);
                ps_ln_Espacios.AgregarEspacioAEspacio(EspacioPadre, espacio.EspacioRepresentado);
                

                if (seAgregoEspacioEvento != null)
                    seAgregoEspacioEvento(espacio);
            }
        }
        void EspacioSeleccionadoInicio_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(clickInicioRecorrido != null)
                clickInicioRecorrido();
        }
	}
}