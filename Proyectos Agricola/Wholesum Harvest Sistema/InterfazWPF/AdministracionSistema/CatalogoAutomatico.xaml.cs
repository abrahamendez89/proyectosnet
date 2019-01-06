using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dominio;
using System.Reflection;
using InterfazWPF.AdministracionSistema.ControlesUsuario;
using Herramientas.ORM;

namespace InterfazWPF.AdministracionSistema
{
    /// <summary>
    /// Lógica de interacción para CatalogoAutomatico.xaml
    /// </summary>
    public partial class CatalogoAutomatico : Window
    {
        ObjetoBase objetoBase;
        Type tipoObjeto;
        public CatalogoAutomatico(ObjetoBase objeto, Type tipoObjeto)
        {
            InitializeComponent();
            objetoBase = objeto;
            this.tipoObjeto = tipoObjeto;
            FieldInfo[] campos = tipoObjeto.GetFields(BindingFlags.CreateInstance | BindingFlags.NonPublic | BindingFlags.Instance);

            int altoEstandar = 25;
            int altoEstandarAumento = 10;



            int altoGrid = 0;

            int i = 0;
            foreach (FieldInfo campo in campos)
            {
                if (!campo.Name.StartsWith("_")) continue;
                if (campo.FieldType == typeof(String) || campo.FieldType == typeof(Double) || campo.FieldType == typeof(Int32) || campo.FieldType == typeof(Int64) || campo.FieldType == typeof(Decimal))
                {
                    RowDefinition renglon = new RowDefinition();
                    renglon.Height = new GridLength(altoEstandar + altoEstandarAumento);

                    altoGrid += altoEstandar + altoEstandarAumento;

                    grd_GridControles.RowDefinitions.Add(renglon);
                    Label label = new Label();
                    label.Name = "lbl_" + campo.Name;
                    label.Content = ObtenerNombreCampo(campo.Name);
                    label.Height = altoEstandar;
                    UserControl textbox = null;
                    if (campo.FieldType == typeof(String))
                    {
                        textbox = new TextboxNormal();
                        ((TextboxNormal)textbox).TipoTextBox = TextboxNormal.Tipo.conEspacios;
                    }
                    else if (campo.FieldType == typeof(Int32) || campo.FieldType == typeof(Int64))
                    {
                        textbox = new TextboxSoloNumero();
                    }
                    else if (campo.FieldType == typeof(Double) || campo.FieldType == typeof(float) || campo.FieldType == typeof(Decimal))
                    {
                        textbox = new TextboxSoloNumeroDecimal();
                    }
                    textbox.Name = "txt_" + campo.Name;
                    textbox.Height = altoEstandar;

                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, 0);

                    Grid.SetRow(textbox, i);
                    Grid.SetColumn(textbox, 1);

                    grd_GridControles.Children.Add(label);
                    grd_GridControles.Children.Add(textbox);
                    i++;
                }
                else if (campo.FieldType == typeof(Boolean))
                {
                    RowDefinition renglon = new RowDefinition();
                    renglon.Height = new GridLength(altoEstandar + altoEstandarAumento);
                    altoGrid += altoEstandar + altoEstandarAumento;
                    grd_GridControles.RowDefinitions.Add(renglon);
                    Label label = new Label();
                    label.Name = "lbl_" + campo.Name;
                    label.Content = ObtenerNombreCampo(campo.Name);

                    CheckBox checkbox = new CheckBox();
                    checkbox.Name = "chb_" + campo.Name;

                    checkbox.Width = 160;
                    checkbox.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    checkbox.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                    label.Height = altoEstandar;
                    checkbox.Height = 15;

                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, 0);

                    Grid.SetRow(checkbox, i);
                    Grid.SetColumn(checkbox, 1);

                    grd_GridControles.Children.Add(label);
                    grd_GridControles.Children.Add(checkbox);

                    i++;
                }
                else if (campo.FieldType == typeof(DateTime))
                {
                    RowDefinition renglon = new RowDefinition();
                    renglon.Height = new GridLength(altoEstandar + altoEstandarAumento);
                    altoGrid += altoEstandar + altoEstandarAumento;
                    grd_GridControles.RowDefinitions.Add(renglon);
                    Label label = new Label();
                    label.Name = "lbl_" + campo.Name;
                    label.Content = ObtenerNombreCampo(campo.Name);

                    DatePicker datePicker = new DatePicker();
                    datePicker.Name = "dtp_" + campo.Name;

                    datePicker.Width = 160;
                    datePicker.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;

                    label.Height = altoEstandar;
                    datePicker.Height = altoEstandar;

                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, 0);

                    Grid.SetRow(datePicker, i);
                    Grid.SetColumn(datePicker, 1);

                    grd_GridControles.Children.Add(label);
                    grd_GridControles.Children.Add(datePicker);

                    i++;
                }

                else if (campo.FieldType.BaseType == typeof(ObjetoBase))
                {
                    RowDefinition renglon = new RowDefinition();
                    renglon.Height = new GridLength(altoEstandar + altoEstandarAumento);
                    altoGrid += altoEstandar + altoEstandarAumento;

                    grd_GridControles.RowDefinitions.Add(renglon);
                    Label label = new Label();
                    label.Name = "lbl_" + campo.Name;
                    label.Content = ObtenerNombreCampo(campo.Name);

                    Boton boton = new Boton();
                    boton.Name = "btn_" + campo.Name;
                    boton.Text = "Seleccionar";
                    boton.Width = boton.Text.Length * 12;
                    boton.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    boton.MouseDown += boton_MouseDown;
                    label.Height = altoEstandar;
                    boton.Height = altoEstandar;

                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, 0);

                    Grid.SetRow(boton, i);
                    Grid.SetColumn(boton, 1);

                    grd_GridControles.Children.Add(label);
                    grd_GridControles.Children.Add(boton);

                    i++;
                }
                else if (campo.FieldType.Name.Contains("List") && campo.FieldType.GetGenericArguments()[0].Name.StartsWith("_"))
                {
                    RowDefinition renglon = new RowDefinition();
                    renglon.Height = new GridLength(125);
                    altoGrid += 125;

                    grd_GridControles.RowDefinitions.Add(renglon);
                    Label label = new Label();
                    label.Name = "lbl_" + campo.Name;
                    label.Content = ObtenerNombreCampo(campo.Name);
                    label.VerticalAlignment = System.Windows.VerticalAlignment.Top;

                    ListBox listBox = new ListBox();
                    listBox.Name = "lb_" + campo.Name;
                    listBox.Height = 100;
                    listBox.VerticalAlignment = System.Windows.VerticalAlignment.Top;

                    Boton boton = new Boton();
                    boton.Name = "btn_" + campo.Name;
                    boton.Text = "Agregar";
                    boton.Width = boton.Text.Length * 12;
                    boton.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    boton.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                    boton.MouseDown += boton_MouseDownLista;

                    label.Height = altoEstandar;
                    boton.Height = altoEstandar;

                    Grid.SetRow(label, i);
                    Grid.SetColumn(label, 0);

                    Grid.SetRow(listBox, i);
                    Grid.SetColumn(listBox, 1);

                    Grid.SetRow(boton, i);
                    Grid.SetColumn(boton, 1);

                    grd_GridControles.Children.Add(label);
                    grd_GridControles.Children.Add(listBox);
                    grd_GridControles.Children.Add(boton);


                    i++;
                }

            }
            grd_GridControles.Height = altoGrid;
        }

        void boton_MouseDownLista(object sender, MouseButtonEventArgs e)
        {
            Boton botonEvento = (Boton)sender;
            FieldInfo campo = tipoObjeto.GetField(botonEvento.Name.Replace("btn_", ""), BindingFlags.Instance | BindingFlags.NonPublic);

            Type tipoLista = campo.FieldType.GetGenericArguments()[0];

            //ObjetoBase objeto = (ObjetoBase)campo.GetValue(objetoBase);


            CatalogoAutomatico cat = new CatalogoAutomatico(null, tipoLista);
            cat.ShowDialog();
        }


        void boton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Boton botonEvento = (Boton)sender;
            FieldInfo campo = tipoObjeto.GetField(botonEvento.Name.Replace("btn_", ""), BindingFlags.Instance | BindingFlags.NonPublic);
            //ObjetoBase objeto = (ObjetoBase)campo.GetValue(objetoBase);


            CatalogoAutomatico cat = new CatalogoAutomatico(null, campo.FieldType);
            cat.ShowDialog();
        }

        private void btn_guardar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void btn_cancelar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private String ObtenerNombreCampo(String nombreCampo)
        {
            //  _in_edad_usuario

            String[] secciones = nombreCampo.Split('_');
            String nombre = "";
            for (int i = 2; i < secciones.Length; i++)
                nombre += secciones[i] + " ";
            nombre = nombre.Substring(0, nombre.Length - 1);
            return nombre;
        }
    }
}
