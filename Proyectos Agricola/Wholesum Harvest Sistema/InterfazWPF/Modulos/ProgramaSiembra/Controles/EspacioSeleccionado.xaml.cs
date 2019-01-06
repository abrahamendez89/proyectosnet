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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicaNegocios.ProgramaSiembra;

namespace InterfazWPF
{
    /// <summary>
    /// Lógica de interacción para EspacioSeleccionado.xaml
    /// </summary>
    public partial class EspacioSeleccionado : UserControl
    {
        public delegate void ClickEspacioHistorial(_ps_EspacioFisico espacioFisico, int indice);
        public event ClickEspacioHistorial clickEspacioHistorial;

        public delegate void SeAgregoEspacioEvento(EspacioGrafico espacioSeleccionado);
        public event SeAgregoEspacioEvento seAgregoEspacioEvento;

        public int Indice { get; set; }
        public _ps_EspacioFisico EspacioHistorial { get; set; }
        public String Titulo
        {
            get { return txt_nombreEspacio.Text; }
            set
            {
                //if (value.Length < 10)
                //    Width = 100;
                //else
                Width = value.Length * 7.5 + (20);
                txt_nombreEspacio.Text = value;
            }
        }
        public EspacioSeleccionado()
        {
            this.InitializeComponent();
            this.MouseDown += EspacioSeleccionado_MouseDown;
            CargarAnimaciones();
            AllowDrop = true;
            this.MouseEnter += EspacioSeleccionado_MouseEnter;
            this.MouseLeave += EspacioSeleccionado_MouseLeave;
            Drop += EspacioGrafico_Drop;
        }
        void EspacioGrafico_Drop(object sender, DragEventArgs e)
        {
            EspacioGrafico espacio = (EspacioGrafico)e.Data.GetData(typeof(EspacioGrafico));

            if (espacio.EspacioRepresentado.Id != EspacioHistorial.Id)
            {
                //this.EspacioHistorial.ll_Espacios_fisicos_dentro.Add(espacio.EspacioRepresentado);
                ps_ln_Espacios.AgregarEspacioAEspacio(EspacioHistorial, espacio.EspacioRepresentado);
                if (seAgregoEspacioEvento != null)
                    seAgregoEspacioEvento(espacio);
            }
        }
        void EspacioSeleccionado_MouseLeave(object sender, MouseEventArgs e)
        {
            if (esBotonNormal)
                FueraControlNormal.Begin();
            else
                esUltimo();
        }

        void EspacioSeleccionado_MouseEnter(object sender, MouseEventArgs e)
        {
            sobreControlNormal.Begin();
        }
        Storyboard sobreControlNormal;
        Storyboard FueraControlNormal;
        Storyboard EsUltimo;
        Storyboard EsNormal;
        private void CargarAnimaciones()
        {
            sobreControlNormal = (Storyboard)this.FindResource("EntroControl");
            FueraControlNormal = (Storyboard)this.FindResource("SalioControl");
            EsUltimo = (Storyboard)this.FindResource("EsUltimo");
            EsNormal = (Storyboard)this.FindResource("EsNormal");
        }

        void EspacioSeleccionado_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (clickEspacioHistorial != null)
                clickEspacioHistorial(EspacioHistorial, Indice);
        }
        Boolean esBotonNormal = false;
        public void esUltimo()
        {
            esBotonNormal = false;
            EsUltimo.Begin();
        }
        public void esNormal()
        {
            esBotonNormal = true;
            EsNormal.Begin();
        }
    }
}