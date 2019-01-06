using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace Sistema
{
	public class DriverXtraGrid_Celda : CellValueChangedEventArgs
	{
		private object atrTag;

		public BaseEdit ActiveEditor
		{
			get
			{
				return base.Column.View.ActiveEditor;
			}
		}

		public object Tag
		{
			get
			{
				return this.atrTag;
			}
			set
			{
				this.atrTag = value;
			}
		}

		public new object Value
		{
			get
			{
				return base.Column.View.GetDataRow(base.RowHandle)[base.Column.FieldName];
			}
			set
			{
				DataRow dataRow = base.Column.View.GetDataRow(base.RowHandle);
				dataRow.Table.BeginLoadData();
				dataRow[base.Column.FieldName] = this.CastToColumnType(value);
				dataRow.Table.EndLoadData();
				base.Column.View.GridControl.Refresh();
			}
		}

		public DriverXtraGrid_Celda(int prmRow, GridColumn prmColumn, object prmValue) : base(prmRow, prmColumn, prmValue)
		{
			this.atrTag = null;
		}

		public object CastToColumnType(object Value)
		{
			object str;
			if (Value == null || Value == DBNull.Value)
			{
				return DBNull.Value;
			}
			bool flag = this.EsNumerico(Value);
			if (this.EsNumerico(Value, base.Column.ColumnType) && !flag)
			{
				return DBNull.Value;
			}
			try
			{
				string upper = base.Column.ColumnType.Name.ToUpper();
				string str1 = upper;
				if (upper != null)
				{
					switch (str1)
					{
						case "BYTE":
						{
							str = byte.Parse(Value.ToString());
							return str;
						}
						case "CHAR":
						{
							str = char.Parse(Value.ToString());
							return str;
						}
						case "DATETIME":
						{
							str = DateTime.Parse(Value.ToString());
							return str;
						}
						case "DECIMAL":
						{
							str = decimal.Parse(Value.ToString());
							return str;
						}
						case "DOUBLE":
						{
							str = double.Parse(Value.ToString());
							return str;
						}
						case "INT16":
						{
							str = short.Parse(Value.ToString());
							return str;
						}
						case "INT32":
						{
							str = int.Parse(Value.ToString());
							return str;
						}
						case "INT64":
						{
							str = long.Parse(Value.ToString());
							return str;
						}
						case "INT":
						{
							str = int.Parse(Value.ToString());
							return str;
						}
						case "SBYTE":
						{
							str = sbyte.Parse(Value.ToString());
							return str;
						}
						case "FLOAT":
						{
							str = float.Parse(Value.ToString());
							return str;
						}
						case "STRING":
						{
							str = Value.ToString();
							return str;
						}
						case "UINT16":
						{
							str = ushort.Parse(Value.ToString());
							return str;
						}
						case "UINT32":
						{
							str = uint.Parse(Value.ToString());
							return str;
						}
						case "UINT64":
						{
							str = ulong.Parse(Value.ToString());
							return str;
						}
					}
				}
				return Value;
			}
			catch (Exception exception)
			{
				return Value;
			}
			return str;
		}

		private bool EsNumerico(object Value)
		{
			return this.EsNumerico(Value, Value.GetType());
		}

		private bool EsNumerico(object Value, Type tipo)
		{
			string upper = tipo.Name.ToUpper();
			string str = upper;
			if (upper != null)
			{
				switch (str)
				{
					case "BYTE":
					case "DECIMAL":
					case "DOUBLE":
					case "INT16":
					case "INT32":
					case "INT64":
					case "INT":
					case "SBYTE":
					case "FLOAT":
					case "UINT16":
					case "UINT32":
					case "UINT64":
					{
						return true;
					}
				}
			}
			string upper1 = Value.ToString().Trim().ToUpper();
			if (upper1 == "")
			{
				return false;
			}
			char[] charArray = upper1.ToCharArray();
			for (int i = 0; i < (int)charArray.Length; i++)
			{
				if ("ABCDEFGHIJKLMNÑOPQRSTUVWXYZ/!#$%&/()='?¡¿*-+".IndexOf(charArray[i]) >= 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}