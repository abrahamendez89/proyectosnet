using Herramientas.Archivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Karaoke.Configuracion
{
    public class ProcesoArchivos
    {
        public delegate void MostrarMensaje(String mensaje);
        public event MostrarMensaje mostrarMensaje;

        public delegate void MostrarPorcentaje(double porcentaje);
        public event MostrarPorcentaje mostrarPorcentaje;

        public delegate void TerminoCargado();
        public event TerminoCargado terminoCargado;

        List<String> carpetasCargadasTotal = new List<string>();

        private void ProcesoPrincipal()
        {

        }
        private Dictionary<String, Dictionary<String, List<String>>> ObtenerCategoriaOrdenada(Dictionary<String, Dictionary<String, List<String>>> Categoria)
        {
            mostrarMensaje("Ordenando categoría por alfabeto...");
            Dictionary<String, Dictionary<String, List<String>>> CategoriaOrdenada = new Dictionary<string, Dictionary<string, List<string>>>();

            foreach (String nombreGrupo in Categoria.Keys)
            {
                Dictionary<String, List<String>> GrupoTemp = Categoria[nombreGrupo];

                List<String> keys = GrupoTemp.Keys.ToList();
                keys.Sort();

                Dictionary<String, List<String>> grupoOrdenado = new Dictionary<string, List<string>>();

                foreach (String keyOrden in keys)
                {
                    grupoOrdenado.Add(keyOrden, GrupoTemp[keyOrden]);
                }

                CategoriaOrdenada.Add(nombreGrupo, grupoOrdenado);
            }
            return CategoriaOrdenada;
        }
        private void GuardarContenidoAArchivo()
        {
            varContenido = Compartidos.ObtenerVariablesContenido();
            varContenido.BorrarVariables();
            GuardarCategoria(ObtenerCategoriaOrdenada(categoriaKaraoke), "KARAOKE");
            GuardarCategoria(ObtenerCategoriaOrdenada(categoriaMusica), "MUSICA");
            GuardarCategoria(ObtenerCategoriaOrdenada(categoriaVideos), "VIDEOS");
            varContenido.ActualizarArchivo();
        }
        int agrupadoresGuardados = 0;
        private void GuardarCategoria(Dictionary<String, Dictionary<String, List<String>>> categoria, String nombreCategoria)
        {
            varContenido.GuardarValorVariable(nombreCategoria + "_GRUPOS", categoria.Values.Count.ToString());
            int indiceGrupo = 0;
            foreach (Dictionary<String, List<String>> grupo in categoria.Values)
            {

                String nombreGrupo = categoria.Keys.ToList()[indiceGrupo];
                varContenido.GuardarValorVariable(nombreCategoria + "_GRUPOS_" + indiceGrupo, nombreGrupo);
                varContenido.GuardarValorVariable(nombreCategoria + "_GRUPOS_" + indiceGrupo + "_AGRUPADORES", grupo.Values.Count.ToString());

                int indiceAgrupadores = 0;
                foreach (String nombreAgrupador in grupo.Keys)
                {
                    //Dispatcher.Invoke(new Action(() =>
                    //{
                    //    double calculo = (100 * agrupadoresGuardados) / totalAgrupadores;
                    //    calculo = Math.Round(calculo);
                    //    lbl_progreso.Content = "Progreso: " + calculo + "%";
                    //    pb_progreso.Value = calculo;
                    //}));

                    double calculo = (100 * agrupadoresGuardados) / totalAgrupadores;
                    calculo = Math.Round(calculo);
                    mostrarPorcentaje(calculo);
                   

                    varContenido.GuardarValorVariable(nombreCategoria + "_GRUPOS_" + indiceGrupo + "_AGRUPADORES_" + indiceAgrupadores, nombreAgrupador);
                    String rutaImagen = grupo.Values.ToList()[indiceAgrupadores][0];
                    varContenido.GuardarValorVariable(nombreCategoria + "_GRUPOS_" + indiceGrupo + "_AGRUPADORES_" + indiceAgrupadores + "_IMAGEN", rutaImagen);
                    varContenido.GuardarValorVariable(nombreCategoria + "_GRUPOS_" + indiceGrupo + "_AGRUPADORES_" + indiceAgrupadores + "_PISTAS", (grupo.Values.ToList()[indiceAgrupadores].Count - 1).ToString());
                    for (int i = 1; i < grupo.Values.ToList()[indiceAgrupadores].Count; i++)
                    {
                        String rutaPista = grupo.Values.ToList()[indiceAgrupadores][i];
                        varContenido.GuardarValorVariable(nombreCategoria + "_GRUPOS_" + indiceGrupo + "_AGRUPADORES_" + indiceAgrupadores + "_PISTA_" + (i - 1), rutaPista);
                        //MostrarMensaje(@"Guardando: " + nombreCategoria + @"\" + nombreGrupo + @"\" + nombreAgrupador + @"\" + System.IO.Path.GetFileName(rutaPista) + "...");

                        mostrarMensaje(@"Guardando " + nombreCategoria + @"\" + nombreGrupo + @"\" + nombreAgrupador + @"\" + System.IO.Path.GetFileName(rutaPista) + "...");
                    }
                    indiceAgrupadores++;
                    agrupadoresGuardados++;
                }
                indiceGrupo++;
            }
        }
        private void CargarCarpetasKaraoke()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            int totalCVideos = var.ObtenerValorVariable<int>("VIDEOS_CARPETAS");
            for (int i = 0; i < totalCVideos; i++)
                carpetasCargadasTotal.Add(var.ObtenerValorVariable<String>("VIDEOS_CARPETAS_" + i));
        }
        private void CargarCarpetasMusica()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            int totalCVideos = var.ObtenerValorVariable<int>("MUSICA_CARPETAS");
            for (int i = 0; i < totalCVideos; i++)
                carpetasCargadasTotal.Add(var.ObtenerValorVariable<String>("MUSICA_CARPETAS_" + i));
        }
        private void CargarCarpetasVideos()
        {
            Variable var = Compartidos.ObtenerVariablesConfiguracion();
            int totalCVideos = var.ObtenerValorVariable<int>("KARAOKE_CARPETAS");
            for (int i = 0; i < totalCVideos; i++)
                carpetasCargadasTotal.Add(var.ObtenerValorVariable<String>("KARAOKE_CARPETAS_" + i));
        }
        private void ProcesarArchivos()
        {
            List<String> carpetas = new List<string>();

            carpetas.AddRange(carpetasCargadasTotal);

            foreach (String elemento in carpetas)
            {
                String[] splitted = elemento.Split('|');

                Dictionary<String, Dictionary<String, List<String>>> categoria = null;

                if (elemento.StartsWith("K="))
                    categoria = categoriaKaraoke;
                if (elemento.StartsWith("V="))
                    categoria = categoriaVideos;
                if (elemento.StartsWith("M="))
                    categoria = categoriaMusica;

                String ruta = splitted[0].Replace("K=", "").Replace("V=", "").Replace("M=", "");
                String grupo = "";
                if (splitted.Length > 1)
                    grupo = splitted[1].ToUpper();
                else
                    grupo = "SIN CATEGORIA";

                if (!categoria.ContainsKey(grupo))
                {
                    categoria.Add(grupo, new Dictionary<string, List<String>>());
                }
                List<String> extensiones = null;
                if (elemento.StartsWith("K="))
                    extensiones = new List<string>() { ".cdg", ".avi", ".mp4", ".wmv", ".3gp" };
                if (elemento.StartsWith("M="))
                    extensiones = new List<string>() { ".mp3", ".wma" };
                if (elemento.StartsWith("V="))
                    extensiones = new List<string>() { ".avi", ".mp4", ".wmv", ".3gp", ".flv" };

                if (elemento.Contains(" (Incluir subcarpetas)"))
                {
                    BuscarCarpetasRecursivo(categoria[grupo], ruta.Trim().Replace(" (Incluir subcarpetas)", ""), extensiones, true);
                }
                else
                {
                    BuscarCarpetasRecursivo(categoria[grupo], ruta.Trim(), extensiones, false);
                }
            }
        }
        int totalAgrupadores = 0;
        Variable varContenido;

        public void ProcesoPrincipalMain()
        {
            mostrarMensaje("Cargando metadata de karaoke...");
            CargarCarpetasKaraoke();
            mostrarMensaje("Cargando metadata de música...");
            CargarCarpetasMusica();
            mostrarMensaje("Cargando metadata de videos...");
            CargarCarpetasVideos();
            ProcesarArchivos();
            GuardarContenidoAArchivo();
            mostrarPorcentaje(100);
            mostrarMensaje("Es necesario reiniciar para cargar de nuevo el contenido multimedia.");
            if (terminoCargado != null)
            {
                terminoCargado();
            }
        }

        private void BuscarCarpetasRecursivo(Dictionary<String, List<String>> Grupo, String ruta, List<String> extensiones, Boolean esRecursivo)
        {
            try
            {
                //MostrarMensaje("Procesando: " + ruta + "...");
                mostrarMensaje("Procesando " + ruta + "...");
                List<string> imagenes = Directory.GetFiles(ruta, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png") || s.EndsWith(".gif")).ToList();
                List<String> multimedia = new List<string>();
                foreach (String extension in extensiones)
                    multimedia.AddRange(Directory.GetFiles(ruta, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(extension)).ToList());

                String agrupador = new DirectoryInfo(ruta).Name;
                List<String> filtrados = new List<string>();

                if (imagenes.Count > 0)
                    filtrados.Add(imagenes[0]);
                else
                    filtrados.Add(null);

                filtrados.AddRange(multimedia);

                if (filtrados.Count > 1)
                {
                    if (!Grupo.ContainsKey(agrupador))
                        Grupo.Add(agrupador, new List<string>());

                    Grupo[agrupador] = filtrados;
                    totalAgrupadores++;
                }

                if (esRecursivo)
                {
                    List<string> folders = System.IO.Directory.GetDirectories(ruta).ToList();
                    foreach (string folder in folders)
                    {
                        BuscarCarpetasRecursivo(Grupo, folder, extensiones, esRecursivo);
                    }
                }
            }
            catch (Exception ex)
            {
                mostrarMensaje("Error " + ex.Message + "...");
            }

        }

        Dictionary<String, Dictionary<String, List<String>>> categoriaKaraoke = new Dictionary<String, Dictionary<String, List<String>>>();
        Dictionary<String, Dictionary<String, List<String>>> categoriaMusica = new Dictionary<String, Dictionary<String, List<String>>>();
        Dictionary<String, Dictionary<String, List<String>>> categoriaVideos = new Dictionary<String, Dictionary<String, List<String>>>();

    }
}
