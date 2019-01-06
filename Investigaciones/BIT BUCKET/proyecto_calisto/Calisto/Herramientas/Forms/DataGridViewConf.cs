using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Herramientas.Forms
{
    public class DataGridViewConf
    {
        public static void DesactivarOrdenamientoTodasColumnasDataGridView(DataGridView dgv)
        {
            try
            {
                for (int i = 0; i < dgv.ColumnCount; i++) { dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ActivarOrdenamientoTodasColumnasDataGridView(DataGridView dgv)
        {
            try
            {
                for (int i = 0; i < dgv.ColumnCount; i++) { dgv.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ActivarODesactivarOrdenamientoDeColumnaDataGridView(DataGridView dgv, int indiceColumna, Boolean ordenar)
        {
            try
            {
                if (ordenar)
                    dgv.Columns[indiceColumna].SortMode = DataGridViewColumnSortMode.Automatic;
                else
                    dgv.Columns[indiceColumna].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CambiarWidhtDeColumnaDataGridView(ref DataGridView dgv, int indiceColumna, int width)
        {
            try
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgv.Columns[indiceColumna].Width = width;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CambiarWidhtDeColumnaDataGridView(DataGridView dgv, String nombreColumna, int width)
        {
            try
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgv.Columns[nombreColumna].Width = width;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static String ObtenerValorCelda(DataGridView dgv, int indiceFila, int indiceColumna)
        {
            try
            {
                return dgv.Rows[indiceFila].Cells[indiceColumna].FormattedValue.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static String ObtenerValorCelda(DataGridView dgv, int indiceFila, String nombreColumna)
        {
            try
            {
                return dgv.Rows[indiceFila].Cells[nombreColumna].FormattedValue.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static System.Drawing.Color ObtenerColorFondoCelda(DataGridView dgv, int indiceFila, int indiceColumna)
        {
            try
            {
                return dgv.Rows[indiceFila].Cells[indiceColumna].Style.BackColor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static System.Drawing.Color ObtenerColorFondoCelda(DataGridView dgv, int indiceFila, String nombreColumna)
        {
            try
            {
                return dgv.Rows[indiceFila].Cells[nombreColumna].Style.BackColor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AsignarValorCelda(DataGridView dgv, int indiceFila, String nombreColumna, String valor)
        {
            try
            {
                dgv.Rows[indiceFila].Cells[nombreColumna].Value = (object)valor;
                dgv.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AgregarColumna(DataGridView dgv, String nombreColumna, int width)
        {
            try
            {
                dgv.Columns.Add(new DataGridViewColumn() { HeaderText = nombreColumna, Name = nombreColumna, Width = width, ReadOnly = true, ToolTipText = nombreColumna, SortMode = DataGridViewColumnSortMode.NotSortable, CellTemplate = new DataGridViewTextBoxCell() });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CambiarColorCelda(DataGridView dgv, System.Drawing.Color colorCelda, System.Drawing.Color colorTexto, int fila, int columna)
        {
            dgv.Rows[fila].Cells[columna].Style.BackColor = colorCelda;
            dgv.Rows[fila].Cells[columna].Style.ForeColor = colorTexto;
        }
        public static void CambiarColorCelda(DataGridView dgv, System.Drawing.Color colorCelda, System.Drawing.Color colorTexto, int fila, string columna)
        {
            dgv.Rows[fila].Cells[columna].Style.BackColor = colorCelda;
            dgv.Rows[fila].Cells[columna].Style.ForeColor = colorTexto;
        }
        public static void EliminarColumnas(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
        }
    }
}
