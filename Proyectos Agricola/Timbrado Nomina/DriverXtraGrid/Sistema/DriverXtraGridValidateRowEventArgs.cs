using DevExpress.XtraGrid.Views.Base;
using System;

namespace Sistema
{
	public class DriverXtraGridValidateRowEventArgs : ValidateRowEventArgs
	{
		private bool atrAgregarNuevoRenglon;

		private object[] atrItemArray;

		private bool atrSolicitaNuevoRenglon;

		public bool AgregarNuevoRenglon
		{
			get
			{
				return this.atrAgregarNuevoRenglon;
			}
			set
			{
				this.atrAgregarNuevoRenglon = value;
			}
		}

		public object[] ItemArray
		{
			get
			{
				return this.atrItemArray;
			}
			set
			{
				this.atrItemArray = value;
			}
		}

		public bool SolicitaNuevoRenglon
		{
			get
			{
				return this.atrSolicitaNuevoRenglon;
			}
		}

		public DriverXtraGridValidateRowEventArgs(ValidateRowEventArgs e, bool agregarNuevoRenglon) : this(e, agregarNuevoRenglon, false)
		{
		}

		public DriverXtraGridValidateRowEventArgs(ValidateRowEventArgs e, bool agregarNuevoRenglon, bool solicitaNuevoRenglon) : base(e.RowHandle, e.Row)
		{
			this.atrAgregarNuevoRenglon = agregarNuevoRenglon;
			this.atrItemArray = null;
			this.atrSolicitaNuevoRenglon = solicitaNuevoRenglon;
		}
	}
}