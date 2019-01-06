using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Herramientas.Archivos
{
    public class Dialogos
    {
        public static String BuscarArchivo(List<String> DescripcionesFiltro, List<String> extensionesFiltro)
        {
            String filtros = "";
            if (DescripcionesFiltro != null)
            {
                for (int i = 0; i < DescripcionesFiltro.Count; i++)
                {
                    filtros += DescripcionesFiltro[i] + "(*." + extensionesFiltro[i] + ")|*." + extensionesFiltro[i] + "|";
                }

                filtros = filtros.Substring(0, filtros.Length - 1);
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filtros;
            ofd.Multiselect = false;
            ofd.Title = "Seleccione un archivo";
            String archivo = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                archivo = ofd.FileName;
            }
            return archivo;
        }
        public static String BuscarArchivoDeImagen()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Multiselect = false;
            ofd.Title = "Seleccione un archivo";
            String archivo = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                archivo = ofd.FileName;
            }
            return archivo;
        }
        public static String GuardarArchivoRuta(List<String> DescripcionesFiltro, List<String> extensionesFiltro, String nombreArchivoDefault)
        {
            String filtros = "";
            for (int i = 0; i < DescripcionesFiltro.Count; i++)
            {
                filtros += DescripcionesFiltro[i] + "(*." + extensionesFiltro[i] + ")|*." + extensionesFiltro[i] + "|";
            }

            filtros = filtros.Substring(0, filtros.Length - 1);
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = filtros;
            ofd.FileName = nombreArchivoDefault;
            ofd.Title = "Guardar archivo";
            String archivo = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                archivo = ofd.FileName;
            }
            return archivo;
        }
        public static String BuscarCarpeta(String directorioInicial)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (directorioInicial != null)
                ofd.SelectedPath = directorioInicial;
            ofd.ShowNewFolderButton = false;
            String retorno = null;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                retorno = ofd.SelectedPath;
            }
            return retorno;
        }
    }
}
