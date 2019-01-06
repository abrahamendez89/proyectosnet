using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Herramientas.Forms.ExcelElements;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace Herramientas.Forms
{
    public class ExcelAPI
    {
        public delegate void MostrarProgresoConversion(double progresoPorcentaje);
        public event MostrarProgresoConversion mostrarProgresoConversion;

        public delegate void TerminoConversion(String rutaGuardado);
        public event TerminoConversion terminoConversion;

        private String rutaGuardado;
        private DataGridView dataGrid;
        private DataTable dataTable;
        private Color ColorFondoEncabezado;
        private Color ColorTextoEncabezado;

        public void ConvertirDataGridViewAExcel(String rutaGuardado, DataGridView dataGrid, Color ColorFondoEncabezado, Color ColorTextoEncabezado)
        {
            this.ColorFondoEncabezado = ColorFondoEncabezado;
            this.ColorTextoEncabezado = ColorTextoEncabezado;
            this.rutaGuardado = rutaGuardado;
            this.dataGrid = dataGrid;
            Thread t = new Thread(ConvertirHiloDataGridView);
            t.Start();

            //ConvertirHilo();
        }
        public void ConvertirDataTableAExcel(String rutaGuardado, DataTable dataTable)
        {
            this.rutaGuardado = rutaGuardado;
            this.dataTable = dataTable;
            this.dtColorAlternado1 = Color.LightBlue;
            this.dtColorAlternado2 = Color.White;
            this.dtColorEncabezado = Color.Orange;
            this.dtColorEncabezadoTexto = Color.White;
            Thread t = new Thread(ConvertirHiloDataTable);
            t.Start();

            //ConvertirHilo();
        }
        public void ConvertirDataTableAExcel(String rutaGuardado, DataTable dataTable, Color colorEncabezado, Color colorEncabezadoTexto, Color colorAlternado1, Color colorAlternado2)
        {
            this.rutaGuardado = rutaGuardado;
            this.dataTable = dataTable;
            this.dtColorAlternado1 = colorAlternado1;
            this.dtColorAlternado2 = colorAlternado2;
            this.dtColorEncabezado = colorEncabezado;
            this.dtColorEncabezadoTexto = colorEncabezadoTexto;
            Thread t = new Thread(ConvertirHiloDataTable);
            t.Start();

            //ConvertirHilo();
        }
        //public void ConvertirDataGridViewAExcel(String rutaGuardado, DataTable dataTable)
        //{
        //    this.rutaGuardado = rutaGuardado;
        //    this.dataGrid = dataGrid;
        //    this.dataTable = dataTable;

        //    Thread t = new Thread(ConvertirHilo);
        //    t.Start();

        //    //ConvertirHilo();

        //}
        private void ConvertirHiloDataGridView()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Columns.AutoFit();
            xlWorkBook.CheckCompatibility = false;

            for (int k = 0; k < dataGrid.Columns.Count; k++)
            {
                xlWorkSheet.Cells[1, k + 1] = dataGrid.Columns[k].HeaderText;

                ((Excel.Range)xlWorkSheet.Cells[1, k + 1]).Interior.Color = ColorTranslator.ToOle(ColorFondoEncabezado);
                ((Excel.Range)xlWorkSheet.Cells[1, k + 1]).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);
                ((Excel.Range)xlWorkSheet.Cells[1, k + 1]).Font.Color = ColorTranslator.ToOle(ColorTextoEncabezado);
                ((Excel.Range)xlWorkSheet.Cells[1, k + 1]).Font.Bold = true;
            }

            for (int i = 0; i <= dataGrid.RowCount - 1; i++)
            {
                for (int j = 0; j <= dataGrid.ColumnCount - 1; j++)
                {

                    DataGridViewCell cell = dataGrid[j, i];
                    String valor = "";
                    if (cell.Value != null)
                        valor = cell.Value.ToString();

                    #region alineando el valor
                    try
                    {
                        Convert.ToDateTime(valor);
                        ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }
                    catch { }

                    try
                    {
                        Convert.ToDouble(valor);
                        ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    }
                    catch { }

                    try
                    {
                        Convert.ToInt32(valor);
                        ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    }
                    catch { }
                    #endregion

                    ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).NumberFormat = "@";
                    ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).Value2 = valor;

                    if (cell.Style.BackColor.A != 0 && cell.Style.BackColor.R != 0 && cell.Style.BackColor.G != 0 && cell.Style.BackColor.B != 0)
                        ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).Interior.Color = ColorTranslator.ToOle(cell.Style.BackColor);
                    else
                        ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).Interior.Color = ColorTranslator.ToOle(Color.White);
                    ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).Font.Color = ColorTranslator.ToOle(cell.Style.ForeColor);

                    ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

                }

                double porcentaje = ((i + 1) * 100) / (dataGrid.Rows.Count);

                if (mostrarProgresoConversion != null)
                    mostrarProgresoConversion(porcentaje);

            }
            xlWorkSheet.Columns.AutoFit();
            try
            {
                xlWorkBook.SaveAs(rutaGuardado, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            catch { }
            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            if (terminoConversion != null)
                terminoConversion(rutaGuardado);
        }

        Color dtColorEncabezado;
        Color dtColorEncabezadoTexto;
        Color dtColorAlternado1;
        Color dtColorAlternado2;

        private void ConvertirHiloDataTable()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Columns.AutoFit();
            xlWorkBook.CheckCompatibility = false;

            for (int k = 0; k < dataTable.Columns.Count; k++)
            {
                xlWorkSheet.Cells[1, k + 1] = dataTable.Columns[k].Caption;

                ((Excel.Range)xlWorkSheet.Cells[1, k + 1]).Interior.Color = ColorTranslator.ToOle(dtColorEncabezado);
                ((Excel.Range)xlWorkSheet.Cells[1, k + 1]).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);
                ((Excel.Range)xlWorkSheet.Cells[1, k + 1]).Font.Color = ColorTranslator.ToOle(dtColorEncabezadoTexto);
                ((Excel.Range)xlWorkSheet.Cells[1, k + 1]).Font.Bold = true;
            }

            Color colorAlternado = dtColorAlternado1;
            Boolean intercambiado = false;
            //buscando columna agrupadora
            //int nivel = -1;

            //List<ExcelGrupoRows> gruposBase = new List<ExcelGrupoRows>();
            //ExcelGrupoRows grupoPivote = new ExcelGrupoRows();
            //grupoPivote.Nivel = 0;
            for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                if (intercambiado)
                    colorAlternado = dtColorAlternado2;
                else
                    colorAlternado = dtColorAlternado1;
                //try
                //{
                //    nivel = Convert.ToInt32(dataTable.Rows[i]["_NivelGrupo"].ToString());
                //}
                //catch
                //{
                //}

                //if (nivel != -1)
                //{
                //    if (nivel > grupoPivote.Nivel)
                //    {
                //        ExcelGrupoRows grupoNuevo = new ExcelGrupoRows();
                //        grupoNuevo.RowInicio = i + 3;
                //        grupoNuevo.RowFin = i + 3;
                //        grupoNuevo.Nivel = nivel;
                //        grupoNuevo.GrupoPadre = grupoPivote;
                //        if (grupoPivote.GruposInternos == null) grupoPivote.GruposInternos = new List<ExcelGrupoRows>();
                //        grupoPivote.GruposInternos.Add(grupoNuevo);
                //        grupoPivote.RowFin = i + 2;
                //        if (grupoPivote.GrupoPadre != null)
                //            grupoPivote.GrupoPadre.RowFin = i + 2;
                //        grupoPivote = grupoNuevo;

                //        if (grupoPivote.Nivel == 1)
                //            gruposBase.Add(grupoPivote);
                //    }
                //    else if (nivel < grupoPivote.Nivel)
                //    {
                //        int diferencia = grupoPivote.Nivel - nivel + 1;
                //        //se crea el grupo nuevo que subio de nivel
                //        ExcelGrupoRows grupoNuevo = new ExcelGrupoRows();
                //        grupoNuevo.RowInicio = i + 3;
                //        grupoNuevo.RowFin = i + 3;
                //        grupoNuevo.Nivel = nivel;
                //        for (int d = 0; d < diferencia; d++)
                //        {
                //            grupoPivote.RowFin = i + 1;
                //            grupoPivote = grupoPivote.GrupoPadre;
                //        }
                //        //if (grupoNuevo.Nivel >= 2)
                //        //{
                //        if (grupoPivote.GruposInternos == null) grupoPivote.GruposInternos = new List<ExcelGrupoRows>();
                //        grupoPivote.GruposInternos.Add(grupoNuevo);
                //        //}
                //        if (grupoNuevo.Nivel == 1)
                //            gruposBase.Add(grupoNuevo);
                //        grupoPivote = grupoNuevo;

                //    }
                //    else if (nivel == grupoPivote.Nivel && grupoPivote.GrupoPadre != null)
                //    {
                //        //grupoPivote.RowFin = i + 2;
                //        grupoPivote.GrupoPadre.RowFin = i + 2;
                //    }
                //}

                for (int j = 0; j <= dataTable.Columns.Count - 1; j++)
                {

                    //String celda = ((char)(65 + j)) + "" + (i + 2);
                    //Excel.Range formatRange;
                    //formatRange = xlWorkSheet.get_Range(celda, celda);
                    //formatRange.NumberFormat = "@";

                    //DataGridViewCell cell = dataGrid[j, i];



                    String valor = dataTable.Rows[i][j].ToString();

                    xlWorkSheet.Cells[i + 2, j + 1] = valor;

                    #region alineando el valor
                    try
                    {
                        Convert.ToDateTime(valor);
                        ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }
                    catch { }

                    try
                    {
                        Convert.ToDouble(valor);
                        ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    }
                    catch { }

                    try
                    {
                        Convert.ToInt32(valor);
                        ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    }
                    catch { }
                    #endregion



                    ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).Interior.Color = ColorTranslator.ToOle(colorAlternado);
                    ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).Font.Color = ColorTranslator.ToOle(Color.Black);
                    ((Excel.Range)xlWorkSheet.Cells[i + 2, j + 1]).BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin);

                }
                //formato de colores de celda
                intercambiado = !intercambiado;
                double porcentaje = ((i + 1) * 100) / (dataTable.Rows.Count);

                if (mostrarProgresoConversion != null)
                    mostrarProgresoConversion(porcentaje);

            }
            //agrupando los rows de acuerdo a los grupos
            //xlWorkSheet.get_Range("A3", "A12").EntireRow.Group();
            //xlWorkSheet.get_Range("A5", "A9").EntireRow.Group();
            //xlWorkSheet.get_Range("A9", "A12").EntireRow.Group();
            //xlWorkSheet.get_Range("A13", "A15").EntireRow.Group();

            //foreach (ExcelGrupoRows grupo in gruposBase)
            //{
            //    Agrupar(xlWorkSheet, grupo);
            //}

            //xlWorkSheet.Outline.ShowLevels(1, 0);
            xlWorkSheet.Columns.AutoFit();
            try
            {
                xlWorkBook.SaveAs(rutaGuardado, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            catch { }
            xlWorkBook.Close(true, misValue, misValue);

            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            if (terminoConversion != null)
                terminoConversion(rutaGuardado);
        }
        private void Agrupar(Excel.Worksheet xlWorkSheet, ExcelGrupoRows grupo)
        {
            if (grupo.RowInicio != grupo.RowFin)
            {
                String rang = "A" + grupo.RowInicio + " - A" + grupo.RowFin;
                xlWorkSheet.get_Range("A" + grupo.RowInicio, "A" + grupo.RowFin).EntireRow.Group();
            }
            if (grupo.GruposInternos != null)
            {
                foreach (ExcelGrupoRows grupoInterno in grupo.GruposInternos)
                {
                    Agrupar(xlWorkSheet, grupoInterno);
                }
            }
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw new Exception(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        public static ExcelArchivo ObtenerDataDeArchivoExcel(String ruta)
        {
            //data
            ExcelArchivo archivo = new ExcelArchivo();
            archivo.Hojas = new List<ExcelHoja>();
            object misValue = System.Reflection.Missing.Value;
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(ruta,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                 Type.Missing, Type.Missing);

            foreach (Excel.Worksheet sheet in wb.Sheets)
            {
                ExcelHoja hoja = new ExcelHoja();
                hoja.NombreHoja = sheet.Name;
                hoja.NombresColumnas = new List<string>();
                hoja.ExcelFilasDatos = new List<ExcelFila>();

                int filas = sheet.UsedRange.Rows.Count;
                int columnas = sheet.UsedRange.Columns.Count;


                for (int j = 1; j <= columnas; j++)
                {
                    if (sheet.Cells[1, j].value == null)
                        break;
                    hoja.NombresColumnas.Add(sheet.Cells[1, j].value.ToString());
                }

                for (int i = 2; i <= filas; i++)
                {
                    ExcelFila fila = new ExcelFila();
                    fila.Datos = new List<string>();
                    for (int j = 1; j <= hoja.NombresColumnas.Count; j++)
                    {
                        String valor = "";
                        if (sheet.Cells[i, j].value != null)
                        {
                            valor = sheet.Cells[i, j].value.ToString();
                        }
                        fila.Datos.Add(valor);
                    }
                    hoja.ExcelFilasDatos.Add(fila);
                }
                archivo.Hojas.Add(hoja);
                releaseObject(sheet);
            }
            wb.Close(true, misValue, misValue);

            app.Quit();

            releaseObject(wb);
            releaseObject(app);
            return archivo;
        }



    }

}
