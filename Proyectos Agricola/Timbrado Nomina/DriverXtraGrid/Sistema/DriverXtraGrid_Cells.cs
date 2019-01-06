using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections;
using System.Reflection;

namespace Sistema
{
	public class DriverXtraGrid_Cells
	{
		private DriverXtraGrid atrGrid;

		public DriverXtraGrid_Celda this[int RowIndex, GridColumn Column]
		{
			get
			{
				if (Column == null)
				{
					throw new Exception("La columna proporcionada no es una instancia de objeto");
				}
				if (RowIndex < 0 || RowIndex >= Column.View.RowCount)
				{
					throw new Exception("El Indice del renglon esta fuera del intervalo");
				}
				return new DriverXtraGrid_Celda(RowIndex, Column, Column.View.GetRowCellValue(RowIndex, Column));
			}
		}

		public DriverXtraGrid_Celda this[int RowIndex, int Column]
		{
			get
			{
				if (Column < 0 || Column >= this.atrGrid.MainView.Columns.Count)
				{
					throw new Exception("El Inidice de la columna esta fuera del intervalo");
				}
				return this[RowIndex, this.atrGrid.MainView.Columns[Column]];
			}
		}

		public DriverXtraGrid_Cells(DriverXtraGrid Grid)
		{
			this.atrGrid = Grid;
		}
	}
}