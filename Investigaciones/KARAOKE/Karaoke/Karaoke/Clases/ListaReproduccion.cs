using Herramientas.Archivos;
using Karaoke.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Karaoke.Clases
{
    public class ListaReproduccion
    {
        public delegate void SeDescargoElemento(ListaReproduccion instancia, ElementoMultimedia elementoMultimediaDescargado);
        public event SeDescargoElemento seDescargoElemento;

        public delegate void ActualizarControl(ListaReproduccion instancia);
        public event ActualizarControl actualizarControl;

        public List<ElementoListaReproduccion> ElementosLista { get; set; }
        public ListaReproduccion()
        {
            CargarListaReproduccionGuardada();
        }
        public ElementoMultimedia ObtenerSiguiente()
        {
            if (ElementosLista.Count > 0)
            {
                ElementoMultimedia siguiente = ElementosLista[0].elemento;
                ElementosLista.RemoveAt(0);
                ReasignarIndices();
                return siguiente;
            }
            return null;
        }
        public void AgregarElementoReproduccion(ElementoListaReproduccion elemento)
        {
            if (ElementosLista == null) ElementosLista = new List<ElementoListaReproduccion>();
            ElementosLista.Add(elemento);
            ReasignarIndices();

            //if (elemento.elemento.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.YouTube)
            //{
            //    Thread tDescarga = new Thread(DescargarDeYouTube);
            //    tDescarga.Start(elemento.elemento);
            //}
        }

        private void ReasignarIndices()
        {
            for (int i = 0; i < ElementosLista.Count; i++)
            {
                ElementosLista[i].NumeroPista = i + 1;
            }
            GuardarListaReproduccion();
        }
        public void EliminarPorIndice(int indice)
        {
            if (ElementosLista.Count > 0)
            {
                ElementoMultimedia eliminar = ElementosLista[indice].elemento;
                //eliminar.CancelarDescarga = true;
                ElementosLista.RemoveAt(indice);
                ReasignarIndices();
            }
        }
        public ElementoMultimedia ReproducirPorIndice(int indice)
        {
            if (ElementosLista != null && ElementosLista.Count > 0 && indice < ElementosLista.Count)
            {
                ElementoMultimedia siguiente = ElementosLista[indice].elemento;
                //if (siguiente.TipoElemento == ElementoMultimedia.TipoElementoMultimedia.YouTube && !siguiente.Descargado)
                //{
                //    return ReproducirPorIndice(indice + 1); ;
                //}
                ElementosLista.RemoveAt(indice);
                ReasignarIndices();
                return siguiente;
            }
            return null;
        }

        private void GuardarListaReproduccion()
        {

            if (ElementosLista != null)
            {
                Variable var = Compartidos.ObtenerVariablesListaReproduccion();
                var.BorrarVariables();
                var.GuardarValorVariable("NUMERO_ELEMENTOS", ElementosLista.Count.ToString());
                for (int i = 0; i < ElementosLista.Count; i++)
                {
                    ElementoListaReproduccion elemento = ElementosLista[i];
                    var.GuardarValorVariable("ELEMENTO_"+i+"_TITULO", elemento.elemento.Titulo);
                    var.GuardarValorVariable("ELEMENTO_" + i + "_TIPO", elemento.elemento.TipoElemento.ToString());
                    var.GuardarValorVariable("ELEMENTO_" + i + "_URL", elemento.elemento.URL);
                   
                    if (elemento.elemento.AgrupadorContiene == null)
                    {
                        var.GuardarValorVariable("ELEMENTO_" + i + "_IMAGEN", @"Imagenes\categoria_youtube.png");
                        var.GuardarValorVariable("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR", "");
                        var.GuardarValorVariable("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR_PADRE", "");
                        var.GuardarValorVariable("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR_CATEGORIA", "");
                    }
                    else
                    {
                        var.GuardarValorVariable("ELEMENTO_" + i + "_IMAGEN", elemento.elemento.AgrupadorContiene.ImagenTexto);
                        var.GuardarValorVariable("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR", elemento.elemento.AgrupadorContiene.NombreAgrupador);
                        var.GuardarValorVariable("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR_PADRE", elemento.elemento.AgrupadorContiene.AgrupadorPadre.NombreAgrupador);
                        var.GuardarValorVariable("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR_CATEGORIA", elemento.elemento.AgrupadorContiene.AgrupadorPadre.AgrupadorPadre.NombreAgrupador);
                    }
                    
                }
                var.ActualizarArchivo();
            }
        }
        private void CargarListaReproduccionGuardada()
        {
            Variable var = Compartidos.ObtenerVariablesListaReproduccion();
            int numeroElementos = var.ObtenerValorVariable<Int32>("NUMERO_ELEMENTOS");
            if (numeroElementos == 0) return;
            
            ElementosLista = new List<ElementoListaReproduccion>();
            for (int i = 0; i < numeroElementos; i++)
            {
                try
                {
                    Agrupador agrupadorTemp = new Agrupador();
                    Agrupador agrupadorPadreTemp = new Agrupador();
                    ElementoListaReproduccion elemento = new ElementoListaReproduccion();
                    elemento.NumeroPista = i + 1;
                    ElementoMultimedia elMul = new ElementoMultimedia();
                    elMul.Titulo = var.ObtenerValorVariable<String>("ELEMENTO_" + i + "_TITULO");//, elemento.elemento.Titulo);
                    String tipo = var.ObtenerValorVariable<String>("ELEMENTO_" + i + "_TIPO");//, elemento.elemento.TipoElemento.ToString());
                    agrupadorTemp.NombreAgrupador = var.ObtenerValorVariable<String>("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR");
                    agrupadorPadreTemp.NombreAgrupador = var.ObtenerValorVariable<String>("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR_PADRE");
                    agrupadorTemp.AgrupadorPadre = agrupadorPadreTemp;

                    agrupadorPadreTemp.AgrupadorPadre = new Agrupador() { NombreAgrupador = var.ObtenerValorVariable<String>("ELEMENTO_" + i + "_NOMBRE_AGRUPADOR_CATEGORIA") };

                    if (tipo.Equals("Karaoke"))
                        elMul.TipoElemento = ElementoMultimedia.TipoElementoMultimedia.Karaoke;
                    else if (tipo.Equals("Musica"))
                        elMul.TipoElemento = ElementoMultimedia.TipoElementoMultimedia.Musica;
                    else if (tipo.Equals("Video"))
                        elMul.TipoElemento = ElementoMultimedia.TipoElementoMultimedia.Video;

                    elMul.URL = var.ObtenerValorVariable<String>("ELEMENTO_" + i + "_URL");//, elemento.elemento.URL);
                    elemento.ImagenRuta = var.ObtenerValorVariable<String>("ELEMENTO_" + i + "_IMAGEN");//, elemento.ImagenRuta);
                    if (elemento.ImagenRuta.Equals(""))
                        elemento.Imagen = Herramientas.WPF.Utilidades.CargarImagenURLABitmapImage(@"Imagenes\cd_estandar.png");
                    else
                        elemento.Imagen = Herramientas.WPF.Utilidades.CargarImagenURLABitmapImage(elemento.ImagenRuta);

                    agrupadorTemp.ImagenTexto = elemento.ImagenRuta;
                    elemento.elemento = elMul;
                    elMul.AgrupadorContiene = agrupadorTemp;
                    if (agrupadorTemp.NombreAgrupador.Equals(""))
                        elMul.AgrupadorContiene = null;
                    ElementosLista.Add(elemento);
                }
                catch { }
            }

        }

    }
}
