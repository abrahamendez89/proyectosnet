using DevExpress.XtraGrid.Views.Base;
using System;
using System.ComponentModel;

namespace Sistema
{
	public class EliminacionRenglonDriverXtraGridArgs : CancelEventArgs
	{
		private DriverXtraGrid atrGrid;

		private int atrRowIndex;

		private ColumnView atrView;

		private bool atrMostrarMensajeConfirmacion;

		public DriverXtraGrid Grid
		{
			get
			{
				return this.atrGrid;
			}
		}

		public bool MostrarMensajeConfirmacion
		{
			get
			{
				return this.atrMostrarMensajeConfirmacion;
			}
		}

		public int RowIndex
		{
			get
			{
				return this.atrRowIndex;
			}
		}

		public ColumnView View
		{
			get
			{
				return this.atrView;
			}
		}

		public EliminacionRenglonDriverXtraGridArgs(DriverXtraGrid grid, int rowIndex, ColumnView view) : base(false)
		{
			this.atrGrid = grid;
			this.atrRowIndex = rowIndex;
			this.atrView = view;
			this.atrMostrarMensajeConfirmacion = true;
		}
	}
}