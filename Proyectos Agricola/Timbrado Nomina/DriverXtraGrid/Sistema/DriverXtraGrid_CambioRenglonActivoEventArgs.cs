using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;

namespace Sistema
{
	public class DriverXtraGrid_CambioRenglonActivoEventArgs
	{
		private DataRow atrRow;

		private GridView atrView;

		private int atrRenglonActivo;

		private int atrRenglonActivoAnterior;

		public int RenglonActivo
		{
			get
			{
				return this.atrRenglonActivo;
			}
		}

		public int RenglonActivoAnterior
		{
			get
			{
				return this.atrRenglonActivoAnterior;
			}
		}

		public DataRow Row
		{
			get
			{
				return this.atrRow;
			}
		}

		public GridView View
		{
			get
			{
				return this.atrView;
			}
		}

		public DriverXtraGrid_CambioRenglonActivoEventArgs(GridView prmView, FocusedRowChangedEventArgs e)
		{
			this.atrView = prmView;
			this.atrRenglonActivo = e.FocusedRowHandle;
			this.atrRenglonActivoAnterior = e.PrevFocusedRowHandle;
			this.atrRow = this.atrView.GetDataRow(this.atrRenglonActivo);
		}
	}
}