using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Data;

namespace Sistema
{
	public class SelectedElement_DriverXtraGridArgs : SelectedElementArgs
	{
		private DriverXtraGrid atrGrid;

		private int atrRowIndex;

		private GridColumn atrColumn;

		private bool atrEsValido;

		private string atrDescripcionElementoInvalido;

		private ColumnView atrView;

		private bool atrSaliendoDelGrid;

		internal static string atrDescripcionInvalidoDefault;

		public GridColumn Column
		{
			get
			{
				return this.atrColumn;
			}
		}

		public override string Descripcion
		{
			get
			{
				if (base.Row != null)
				{
					return base.Descripcion;
				}
				return this.atrGrid.Cells[this.atrRowIndex, this.atrColumn].Value.ToString();
			}
		}

		public string DescripcionElementoInvalido
		{
			get
			{
				return this.atrDescripcionElementoInvalido;
			}
			set
			{
				this.atrDescripcionElementoInvalido = value;
			}
		}

		public bool EsValido
		{
			get
			{
				return this.atrEsValido;
			}
			set
			{
				this.atrEsValido = value;
			}
		}

		public DriverXtraGrid Grid
		{
			get
			{
				return this.atrGrid;
			}
		}

		public int RowIndex
		{
			get
			{
				return this.atrRowIndex;
			}
		}

		public bool SaliendoDelGrid
		{
			get
			{
				return this.atrSaliendoDelGrid;
			}
		}

		public override object Valor
		{
			get
			{
				if (base.Row != null)
				{
					return base.Valor;
				}
				return this.atrGrid.Cells[this.atrRowIndex, this.atrColumn].Value;
			}
		}

		public ColumnView View
		{
			get
			{
				return this.atrView;
			}
		}

		static SelectedElement_DriverXtraGridArgs()
		{
			SelectedElement_DriverXtraGridArgs.atrDescripcionInvalidoDefault = "Código inválido";
		}

		public SelectedElement_DriverXtraGridArgs(DriverXtraGrid prmGrid, DataRow renglon, Catalogo catalogo, int rowIndex, GridColumn Column, bool esValido, ColumnView view, bool saliendoDelGrid) : base(renglon, catalogo)
		{
			this.atrGrid = prmGrid;
			this.atrRowIndex = rowIndex;
			this.atrColumn = Column;
			this.atrEsValido = esValido;
			this.atrView = view;
			this.atrSaliendoDelGrid = saliendoDelGrid;
			if (!esValido)
			{
				this.atrDescripcionElementoInvalido = SelectedElement_DriverXtraGridArgs.atrDescripcionInvalidoDefault;
			}
		}
	}
}