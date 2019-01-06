using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Sistema
{
	public class DriverXtraGrid
	{
		private const int Const_Renglon_Invalido = -2;

		private const int Const_NumeroMaximoColumnasCatalogoGrid = 100;

		private const int Const_AnchoPorCaracter = 9;

		public const string MensajeGroupPanel = "Arrastre aquí las columnas que desea agrupar";

		private GridControl atrGrid;

		private DriverXtraGrid.Estilos atrEstilo;

		private bool atrEsGridCaptura;

		private int atrRenglon;

		private int atrColumna;

		private Control atrControlAnterior;

		private Control atrControlSiguiente;

		private AccessForm atrFormaPadre;

		private bool atrPrimerENTERActivado;

		private DataAccessCls DAO;

		private bool atrAutoAjustarAnchoAlValorMaximo;

		private bool atrEventoKeyDownRemovido;

		private DriverXtraGrid_Cells atrCeldas;

		private Hashtable atrCatalogosBaseDeVistas;

		private Hashtable atrColumnasDestinoDescripcionDeVistas;

		private Hashtable atrControlesDestinoDeColumnasDeVistas;

		public static string TituloMessageBox;

		private int atrColumnaSeleccionadoraDeRenglon;

		private bool atrAgregarRenglonAutomatico;

		private bool atrEliminacionDeRenglonesActivada;

		private bool atrPermitirAvanceCeldaInvalida;

		private object atrValorAnterior;

		private string atrUltimaDescripcionDeErrorDesplegada;

		private string atrUltimaDescripcionRenglonInvalido;

		private bool atrLanzarCambioElementoSiempre;

		private bool atrBlancoEsValorInvalido;

		private bool atrCancelacionPorBlancoRaised;

		private string atrNombreUltimaVistaConFoco;

		private bool atrCambiElementoRaisedByLeave;

		private bool atrNoLanzarErrorEnCasoDeError;

		private bool atrEventosActivados;

		private bool atrRaisedValidateRow;

		private bool atrBeforeValidaRenglonRaised;

		[Category("Funcionamiento")]
		[Description("Obtiene o establece si al solicitar un nuevo renglon este se agregara automaticamente sin validarse.")]
		public bool AgregarRenglonAutomatico
		{
			get
			{
				return this.atrAgregarRenglonAutomatico;
			}
			set
			{
				this.atrAgregarRenglonAutomatico = value;
			}
		}

		public bool AutoAjustarAnchoAlValorMaximo
		{
			get
			{
				return this.atrAutoAjustarAnchoAlValorMaximo;
			}
			set
			{
				this.atrAutoAjustarAnchoAlValorMaximo = value;
			}
		}

		public bool AutoAjustarAnchoDeColumnas
		{
			get
			{
				if (this.atrGrid.MainView == null)
				{
					return false;
				}
				return this.MainView.OptionsView.ColumnAutoWidth;
			}
			set
			{
				if (this.atrGrid.MainView != null)
				{
					this.MainView.OptionsView.ColumnAutoWidth = value;
				}
			}
		}

		public bool BlancoEsValorInvalido
		{
			get
			{
				return this.atrBlancoEsValorInvalido;
			}
			set
			{
				this.atrBlancoEsValorInvalido = value;
			}
		}

		[Category("Recursos")]
		[Description("Obtiene o establece el arreglo de catalogos para el grid.")]
		public Catalogo[] CatalogosBase
		{
			get
			{
				return (Catalogo[])this.atrCatalogosBaseDeVistas[this.atrGrid.MainView];
			}
			set
			{
				if (this.atrGrid.MainView != null)
				{
					this.atrCatalogosBaseDeVistas[this.atrGrid.MainView] = value;
				}
			}
		}

		public DriverXtraGrid_Celda CeldaActual
		{
			get
			{
				return this.Cells[this.MainView.FocusedRowHandle, this.MainView.FocusedColumn];
			}
		}

		public DriverXtraGrid_Cells Cells
		{
			get
			{
				return this.atrCeldas;
			}
		}

		[Category("Recursos")]
		[Description("Obtiene o establece el arreglo de indices de columnas en las cuales se desplegara la ayuda.")]
		public int[] ColumnasDestinoDescripcion
		{
			get
			{
				return (int[])this.atrColumnasDestinoDescripcionDeVistas[this.atrGrid.MainView];
			}
			set
			{
				if (this.atrGrid.MainView != null)
				{
					this.atrColumnasDestinoDescripcionDeVistas[this.atrGrid.MainView] = value;
				}
			}
		}

		public int ColumnaSeleccionadoraDeRenglon
		{
			get
			{
				return this.atrColumnaSeleccionadoraDeRenglon;
			}
			set
			{
				if (value >= -1)
				{
					this.atrColumnaSeleccionadoraDeRenglon = value;
					return;
				}
				this.atrColumnaSeleccionadoraDeRenglon = -1;
			}
		}

		[Category("Funcionamiento")]
		[Description("Obtiene o establece el control que obtendra el foco al regresar de la primera columna capturable.")]
		public Control ControlAnterior
		{
			get
			{
				return this.atrControlAnterior;
			}
			set
			{
				this.atrControlAnterior = value;
			}
		}

		public Control[] ControlesDestinoDeColumnas
		{
			get
			{
				return (Control[])this.atrControlesDestinoDeColumnasDeVistas[this.atrGrid.MainView];
			}
			set
			{
				if (this.atrGrid.MainView != null)
				{
					this.atrControlesDestinoDeColumnasDeVistas[this.atrGrid.MainView] = value;
				}
			}
		}

		[Category("Funcionamiento")]
		[Description("Obtiene o establece el control que obtendra el foco al salir de la primera ultima capturable.")]
		public Control ControlSiguiente
		{
			get
			{
				return this.atrControlSiguiente;
			}
			set
			{
				this.atrControlSiguiente = value;
			}
		}

		[Category("Funcionamiento")]
		[Description("Obtiene o establece si esta permitido eliminar renglones en el grid.")]
		public bool EliminacionDeRenglonesActivada
		{
			get
			{
				return this.atrEliminacionDeRenglonesActivada;
			}
			set
			{
				this.atrEliminacionDeRenglonesActivada = value;
			}
		}

		public DriverXtraGrid.Estilos Estilo
		{
			get
			{
				return this.atrEstilo;
			}
			set
			{
				this.atrEstilo = value;
				this.atrEsGridCaptura = value == DriverXtraGrid.Estilos.Captura;
				this.setEstilo(value);
			}
		}

		public bool EsUltimaColumna
		{
			get
			{
				if (this.MainView.FocusedColumn == null)
				{
					return false;
				}
				return this.EsUltimaColumnaCapturable(this.MainView.FocusedColumn);
			}
		}

		public GridControl Grid
		{
			get
			{
				return this.atrGrid;
			}
		}

		public bool LanzarCambioElementoSiempre
		{
			get
			{
				return this.atrLanzarCambioElementoSiempre;
			}
			set
			{
				this.atrLanzarCambioElementoSiempre = value;
			}
		}

		public GridView MainView
		{
			get
			{
				if (this.atrGrid.MainView == null)
				{
					return null;
				}
				return (GridView)this.atrGrid.MainView;
			}
			set
			{
				this.atrGrid.MainView = value;
			}
		}

		public bool MostrarGroupPanel
		{
			get
			{
				if (this.atrGrid.MainView == null)
				{
					return false;
				}
				return ((GridView)this.atrGrid.MainView).OptionsView.ShowGroupPanel;
			}
			set
			{
				if (this.atrGrid.MainView != null)
				{
					((GridView)this.atrGrid.MainView).OptionsView.ShowGroupPanel = value;
				}
			}
		}

		public bool NoLanzarErrorEnCasoDeError
		{
			get
			{
				return this.atrNoLanzarErrorEnCasoDeError;
			}
			set
			{
				this.atrNoLanzarErrorEnCasoDeError = value;
			}
		}

		[Category("Funcionamiento")]
		[Description("Obtiene o establece si al presentarse una celda invalida se le permitira abandonar esta.")]
		public bool PermitirAvanceCeldaInvalida
		{
			get
			{
				return this.atrPermitirAvanceCeldaInvalida;
			}
			set
			{
				this.atrPermitirAvanceCeldaInvalida = value;
			}
		}

		public int RowCount
		{
			get
			{
				return this.MainView.RowCount;
			}
			set
			{
				int num = value - this.MainView.RowCount;
				DataView dataSource = (DataView)this.MainView.DataSource;
				dataSource.Table.BeginLoadData();
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						dataSource.Table.Rows.Add(dataSource.Table.NewRow());
					}
				}
				if (num < 0)
				{
					num = num * -1;
					for (int j = 0; j < num; j++)
					{
						int count = dataSource.Table.Rows.Count - 1;
						if (count < 0)
						{
							break;
						}
						dataSource.Table.Rows.Remove(dataSource.Table.Rows[count]);
					}
				}
				dataSource.Table.EndLoadData();
				this.atrGrid.Refresh();
			}
		}

		static DriverXtraGrid()
		{
			DriverXtraGrid.TituloMessageBox = "Sistema Estratégico de Nómina";
		}

		public DriverXtraGrid(GridControl grid)
		{
			this.atrGrid = grid;
			this.atrRenglon = 0;
			this.atrColumna = 0;
			this.atrEsGridCaptura = false;
			this.atrPrimerENTERActivado = false;
			this.atrEstilo = DriverXtraGrid.Estilos.Seleccion;
			this.atrColumnaSeleccionadoraDeRenglon = -1;
			this.atrAutoAjustarAnchoAlValorMaximo = false;
			this.atrEventosActivados = true;
			this.atrUltimaDescripcionRenglonInvalido = "Renglon invalido";
			this.atrCatalogosBaseDeVistas = new Hashtable();
			this.atrColumnasDestinoDescripcionDeVistas = new Hashtable();
			this.atrControlesDestinoDeColumnasDeVistas = new Hashtable();
			this.atrRaisedValidateRow = true;
			this.atrLanzarCambioElementoSiempre = false;
			this.atrCancelacionPorBlancoRaised = false;
			this.atrBeforeValidaRenglonRaised = false;
			this.atrNombreUltimaVistaConFoco = "";
			this.atrNoLanzarErrorEnCasoDeError = false;
			this.atrEventoKeyDownRemovido = false;
			this.atrGrid.Leave += new EventHandler(this.ADSUMXTRA_GRID_Leave);
			this.atrGrid.Enter += new EventHandler(this.ADSUMXTRA_GRID_Enter);
			this.atrGrid.ProcessGridKey += new KeyEventHandler(this.DriverXtraGrid_ProcessGridKey);
			this.atrGrid.DataSourceChanged += new EventHandler(this.ADSUMXTRA_GRID_DataSourceChanged);
			this.atrCeldas = new DriverXtraGrid_Cells(this);
			this.atrUltimaDescripcionDeErrorDesplegada = SelectedElement_DriverXtraGridArgs.atrDescripcionInvalidoDefault;
			this.MainView.OptionsBehavior.EditorShowMode = EditorShowMode.Click;
		}

		public bool _SetCellValue(DriverXtraGrid_Celda prmCeldaActual, object prmValor)
		{
			int num = this.ObtenIndiceColumnaActual(prmCeldaActual.Column);
			int rowHandle = prmCeldaActual.RowHandle;
			Tool.IfNull(prmCeldaActual.Value, "").ToString();
			Tool.IfNull(prmValor, "").ToString();
			this.atrValorAnterior = prmValor;
			if (!this.tieneCatalogo(prmCeldaActual))
			{
				prmCeldaActual.Value = prmValor;
				this.RefrescarControlesExternos(prmCeldaActual.Column.View);
				return true;
			}
			this.LimpiarColumnasDependientes(prmCeldaActual);
			bool flag = this.CatalogosBase[num].ObtenElementoRow(Tool.IfNull(prmValor, "").ToString()) != null;
			string str = "";
			if (flag)
			{
				prmCeldaActual.Value = prmCeldaActual.CastToColumnType(prmValor);
				str = this.ValidayObtenDescripcion(prmCeldaActual, prmValor.ToString());
				this.SetMiValorEnColumnasDependientes(prmCeldaActual);
			}
			if (this.ColumnasDestinoDescripcion[num] != -1)
			{
				DriverXtraGrid_Celda item = this.Cells[rowHandle, this.ColumnasDestinoDescripcion[num]];
				if (!flag)
				{
					item.Value = DBNull.Value;
				}
				else
				{
					item.Value = item.CastToColumnType(str);
				}
			}
			this.RefrescarControlesExternos(prmCeldaActual.Column.View);
			return true;
		}

		public void ActivaSiguienteColumnaCapturable(DriverXtraGrid_Celda prmCeldaActual)
		{
			DriverXtraGrid_Celda siguienteCeldaActiva = this.getSiguienteCeldaActiva(prmCeldaActual);
			prmCeldaActual.Column.View.FocusedRowHandle = siguienteCeldaActiva.RowHandle;
			prmCeldaActual.Column.View.FocusedColumn = siguienteCeldaActiva.Column;
			if (siguienteCeldaActiva.ActiveEditor == null)
			{
				SendKeys.Send("{ENTER}");
			}
		}

		private void ADSUMXTRA_GRID_DataSourceChanged(object sender, EventArgs e)
		{
			this.Estilo = this.atrEstilo;
			this.ConfiguraCatalogos();
		}

		private void ADSUMXTRA_GRID_Enter(object sender, EventArgs e)
		{
			if (this.atrGrid.TopLevelControl != null)
			{
				this.atrFormaPadre = this.ObtenAccessForm();
				if (this.atrFormaPadre != null && !this.atrEventoKeyDownRemovido)
				{
					this.atrFormaPadre.KeyDown -= new KeyEventHandler(this.atrFormaPadre.AccessForm_KeyDown);
					this.atrEventoKeyDownRemovido = true;
				}
			}
			if (this.atrEsGridCaptura)
			{
				GridView focusedView = (GridView)this.atrGrid.FocusedView;
				focusedView.Appearance.FocusedCell.BackColor = Color.Yellow;
				focusedView.Appearance.FocusedCell.BackColor2 = Color.Yellow;
				if (this.MainView.Name == this.atrGrid.FocusedView.Name)
				{
					if (focusedView.IsValidRowHandle(this.atrRenglon))
					{
						focusedView.FocusedRowHandle = this.atrRenglon;
					}
					if (this.atrColumna >= 0 && this.atrColumna < focusedView.Columns.Count && focusedView.FocusedColumn == null)
					{
						focusedView.FocusedColumn = focusedView.VisibleColumns[this.atrColumna];
					}
				}
				if (!this.MainView.IsEditing && this.MainView.ActiveEditor == null)
				{
					SendKeys.Send("{ENTER}");
				}
			}
		}

		private void ADSUMXTRA_GRID_Leave(object sender, EventArgs e)
		{
			GridView focusedView = (GridView)this.atrGrid.FocusedView;
			this.atrNombreUltimaVistaConFoco = focusedView.Name;
			if (this.atrLanzarCambioElementoSiempre && this.atrGrid.FocusedView != null && this.atrGrid.FocusedView.IsEditing && this.atrGrid.FocusedView.ActiveEditor != null)
			{
				this.atrRenglon = focusedView.FocusedRowHandle;
				this.atrColumna = focusedView.Columns.IndexOf(this.MainView.FocusedColumn);
				this.atrBeforeValidaRenglonRaised = this.MainView.EditingValueModified;
				this.atrCambiElementoRaisedByLeave = true;
				try
				{
					if (!this.atrGrid.FocusedView.ValidateEditor())
					{
						this.atrCancelacionPorBlancoRaised = true;
						this.atrCambiElementoRaisedByLeave = false;
						return;
					}
				}
				catch (Exception exception)
				{
					this.atrCancelacionPorBlancoRaised = true;
					this.atrCambiElementoRaisedByLeave = false;
					return;
				}
			}
			this.atrCambiElementoRaisedByLeave = false;
			this.atrRenglon = this.MainView.FocusedRowHandle;
			this.atrColumna = this.MainView.Columns.IndexOf(this.MainView.FocusedColumn);
			focusedView.Appearance.FocusedCell.BackColor = Color.Empty;
			focusedView.Appearance.FocusedCell.BackColor2 = Color.Empty;
			if (this.atrFormaPadre != null && this.atrEventoKeyDownRemovido)
			{
				this.atrFormaPadre.KeyDown += new KeyEventHandler(this.atrFormaPadre.AccessForm_KeyDown);
				this.atrEventoKeyDownRemovido = false;
			}
		}

		public void AgregaRenglon(DataRow row)
		{
			((DataView)this.MainView.DataSource).Table.Rows.Add(row);
		}

		private static void AsignaEventosPintado(GridControl grid)
		{
			grid.Enter -= new EventHandler(DriverXtraGrid.grid_Enter);
			grid.Leave -= new EventHandler(DriverXtraGrid.grid_Leave);
			grid.FocusedViewChanged -= new ViewFocusEventHandler(DriverXtraGrid.grid_FocusedViewChanged);
			grid.Enter += new EventHandler(DriverXtraGrid.grid_Enter);
			grid.Leave += new EventHandler(DriverXtraGrid.grid_Leave);
			grid.FocusedViewChanged += new ViewFocusEventHandler(DriverXtraGrid.grid_FocusedViewChanged);
		}

		private void AutoAjustaAnchoColumnas(DataTable prmTabla)
		{
			for (int i = 0; i < prmTabla.Columns.Count; i++)
			{
				this.MainView.Columns[i].Width = this.getMaxWith(prmTabla, i);
			}
		}

		private void cambioDeRenglon(DriverXtraGrid_Celda cell)
		{
			if (!this.atrEsGridCaptura)
			{
				return;
			}
			for (int i = 0; i < (int)this.CatalogosBase.Length; i++)
			{
				if (this.CatalogosBase[i] != null)
				{
					this.CatalogosBase[i].LimpiarValoresDependencias();
					this.obtenValoresDependenciasExistentes(cell);
				}
			}
			this.RefrescarControlesExternos(cell.Column.View);
		}

		public bool CeldaEsValida(DriverXtraGrid_Celda prmCeldaActual)
		{
			this.ValidayObtenDescripcion(prmCeldaActual);
			return (bool)prmCeldaActual.Tag;
		}

		private void ConfiguraCatalogos()
		{
			if (!this.atrEsGridCaptura)
			{
				DataTable dataSource = null;
				if (this.atrGrid.DataSource.GetType().Equals(typeof(DataTable)))
				{
					dataSource = (DataTable)this.atrGrid.DataSource;
				}
				else if (this.atrGrid.DataSource.GetType().Equals(typeof(DataSet)))
				{
					dataSource = ((DataSet)this.atrGrid.DataSource).Tables[this.atrGrid.DataMember];
				}
				if (this.atrColumnaSeleccionadoraDeRenglon != -1 && dataSource.Columns.Count >= this.atrColumnaSeleccionadoraDeRenglon && dataSource.Columns[this.atrColumnaSeleccionadoraDeRenglon].DataType.Name.ToUpper() == "BOOLEAN" && this.atrGrid.MainView != null)
				{
					this.MainView.OptionsBehavior.Editable = true;
					foreach (GridColumn column in this.MainView.Columns)
					{
						column.OptionsColumn.AllowEdit = false;
					}
					this.MainView.Columns[this.atrColumnaSeleccionadoraDeRenglon].OptionsColumn.AllowEdit = true;
				}
				return;
			}
			if (this.CatalogosBase == null)
			{
				if (this.atrGrid.MainView == null)
				{
					return;
				}
				this.CatalogosBase = new Catalogo[this.MainView.Columns.Count];
				this.ControlesDestinoDeColumnas = new Control[this.MainView.Columns.Count];
				this.ColumnasDestinoDescripcion = new int[this.MainView.Columns.Count];
			}
			if (this.MainView.Columns.Count != (int)this.CatalogosBase.Length)
			{
				int count = this.MainView.Columns.Count;
				Catalogo[] catalogosBase = new Catalogo[count];
				int[] columnasDestinoDescripcion = new int[count];
				Control[] controlesDestinoDeColumnas = new Control[count];
				for (int i = 0; i < (int)columnasDestinoDescripcion.Length; i++)
				{
					columnasDestinoDescripcion[i] = -1;
				}
				for (int j = 0; j < count; j++)
				{
					if (j < (int)this.CatalogosBase.Length)
					{
						catalogosBase[j] = this.CatalogosBase[j];
					}
					if (j < (int)this.ControlesDestinoDeColumnas.Length)
					{
						controlesDestinoDeColumnas[j] = this.ControlesDestinoDeColumnas[j];
					}
					if (j >= (int)this.ColumnasDestinoDescripcion.Length)
					{
						columnasDestinoDescripcion[j] = -1;
					}
					else
					{
						columnasDestinoDescripcion[j] = this.ColumnasDestinoDescripcion[j];
					}
				}
				this.atrCatalogosBaseDeVistas[this.atrGrid.MainView] = catalogosBase;
				this.atrControlesDestinoDeColumnasDeVistas[this.atrGrid.MainView] = controlesDestinoDeColumnas;
				this.atrColumnasDestinoDescripcionDeVistas[this.atrGrid.MainView] = columnasDestinoDescripcion;
			}
		}

		public void ConfiguraCeldaDeCaptura(int Index, bool Activar)
		{
			GridColumn item = this.MainView.Columns[Index];
			item.OptionsColumn.AllowEdit = Activar;
			item.OptionsColumn.AllowFocus = Activar;
		}

		private void DriverXtraGrid_ProcessGridKey(object sender, KeyEventArgs e)
		{
			if (e.Control && this.atrFormaPadre != null && (e.KeyCode == Keys.G || e.KeyCode == Keys.U || e.KeyCode == Keys.B || e.KeyCode == Keys.E || e.KeyCode == Keys.I))
			{
				this.atrFormaPadre.AccessForm_KeyDown(this.atrFormaPadre, e);
			}
			if (!this.atrEsGridCaptura)
			{
				if (e.KeyCode == Keys.Escape && this.atrGrid.MainView != null)
				{
					int focusedRowHandle = this.MainView.FocusedRowHandle;
					if (this.atrControlAnterior != null && e.KeyCode == Keys.Escape)
					{
						Application.DoEvents();
						this.atrControlAnterior.Focus();
						e.Handled = true;
					}
				}
				if ((e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab) && this.atrGrid.MainView != null)
				{
					int num = this.MainView.FocusedRowHandle;
					if (this.atrControlSiguiente != null && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Tab))
					{
						Application.DoEvents();
						this.atrControlSiguiente.Focus();
						e.Handled = true;
					}
				}
				return;
			}
			if (this.atrEsGridCaptura)
			{
				DriverXtraGrid_Celda celdaActual = null;
				if (this.atrGrid.MainView != null && this.MainView.FocusedRowHandle >= 0 && this.MainView.FocusedColumn != null && this.MainView.FocusedRowHandle < this.MainView.RowCount)
				{
					celdaActual = this.CeldaActual;
				}
				if (e.KeyCode == Keys.Escape)
				{
					if (this.atrGrid.MainView != null && celdaActual != null)
					{
						GridColumn focusedColumn = this.MainView.FocusedColumn;
						int focusedRowHandle1 = this.MainView.FocusedRowHandle;
						if (this.atrControlAnterior == null || !this.EsPrimeraColumnaCapturable(focusedColumn) || !this.EsPrimerRenglonCapturable(focusedRowHandle1))
						{
							SendKeys.Send("{LEFT}");
						}
						else
						{
							this.atrControlAnterior.Focus();
						}
					}
					e.Handled = true;
				}
				if (this.MainView.FocusedRowHandle >= 0 && this.atrEsGridCaptura && celdaActual != null && this.tieneCatalogo(celdaActual) && e.KeyCode == Keys.F1)
				{
					string str = "";
					if (celdaActual.ActiveEditor != null && celdaActual.ActiveEditor.EditValue != null)
					{
						str = celdaActual.ActiveEditor.EditValue.ToString();
					}
					string str1 = this.RegresaEleccionDeUsuario(celdaActual, str);
					if (str1 != "*")
					{
						BaseContainerValidateEditorEventArgs baseContainerValidateEditorEventArg = new BaseContainerValidateEditorEventArgs(celdaActual.CastToColumnType(str1));
						this.MainView_ValidatingEditor(this.MainView, baseContainerValidateEditorEventArg);
						if (baseContainerValidateEditorEventArg.Valid)
						{
							this.atrRaisedValidateRow = false;
							this.MainView.UpdateCurrentRow();
							this.atrRaisedValidateRow = true;
							SendKeys.Send("{ENTER}");
						}
					}
				}
				if (e.KeyCode == Keys.Delete && celdaActual != null)
				{
					if (this.atrEliminacionDeRenglonesActivada)
					{
						this.EliminarRenglon(celdaActual.Column.View, celdaActual.RowHandle);
					}
					return;
				}
				if (e.KeyCode == Keys.Return && celdaActual != null && this.atrGrid.FocusedView.IsEditing && this.atrGrid.MainView != null)
				{
					GridColumn gridColumn = this.MainView.FocusedColumn;
					int rowHandle = celdaActual.RowHandle;
					bool enterMoveNextColumn = false;
					if (!this.atrPrimerENTERActivado && this.EsUltimaColumnaCapturable(gridColumn) && this.EsUltimoRenglonCapturable(this.MainView.FocusedRowHandle))
					{
						enterMoveNextColumn = this.MainView.OptionsNavigation.EnterMoveNextColumn;
						this.atrBeforeValidaRenglonRaised = this.MainView.EditingValueModified;
						if (this.MainView.ValidateEditor())
						{
							DriverXtraGridValidateRowEventArgs driverXtraGridValidateRowEventArg = new DriverXtraGridValidateRowEventArgs(new ValidateRowEventArgs(rowHandle, this.MainView.GetDataRow(rowHandle)), this.atrAgregarRenglonAutomatico, true);
							this.OnValidaRenglon(driverXtraGridValidateRowEventArg);
							if (!driverXtraGridValidateRowEventArg.AgregarNuevoRenglon)
							{
								if (driverXtraGridValidateRowEventArg.Valid && this.atrControlSiguiente != null)
								{
									this.atrControlSiguiente.Focus();
								}
							}
							else if (driverXtraGridValidateRowEventArg.Valid)
							{
								return;
							}
							this.MainView.OptionsNavigation.EnterMoveNextColumn = enterMoveNextColumn;
							e.Handled = true;
						}
					}
					this.atrPrimerENTERActivado = false;
				}
			}
		}

		public bool EliminarRenglon(ColumnView Vista, int Index)
		{
			if (Index < 0 || Index >= Vista.RowCount)
			{
				throw new Exception("El Indice se encuentra fuera del intervalo");
			}
			EliminacionRenglonDriverXtraGridArgs eliminacionRenglonDriverXtraGridArg = new EliminacionRenglonDriverXtraGridArgs(this, Index, Vista);
			this.OnBeforeEliminacionRenglon(eliminacionRenglonDriverXtraGridArg);
			if (eliminacionRenglonDriverXtraGridArg.Cancel)
			{
				return false;
			}
			if (eliminacionRenglonDriverXtraGridArg.MostrarMensajeConfirmacion && MessageBox.Show("¿Seguro de eliminar el renglón?", DriverXtraGrid.TituloMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return false;
			}
			if (Vista.RowCount != 1)
			{
				this.atrRaisedValidateRow = false;
				Vista.DeleteRow(Index);
				this.atrRaisedValidateRow = true;
			}
			else
			{
				foreach (GridColumn column in Vista.Columns)
				{
					this.Cells[Index, column].Value = DBNull.Value;
				}
			}
			this.OnAfterEliminacionRenglon(eliminacionRenglonDriverXtraGridArg);
			if (!Vista.IsEditing)
			{
				SendKeys.Send("{ENTER}");
			}
			return true;
		}

		public bool EliminarRenglon(int Index)
		{
			return this.EliminarRenglon((ColumnView)this.atrGrid.FocusedView, Index);
		}

		private bool EsPrimeraColumnaCapturable(GridColumn prmColumn)
		{
			bool flag;
			IEnumerator enumerator = this.MainView.Columns.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					GridColumn current = (GridColumn)enumerator.Current;
					if (!current.OptionsColumn.AllowEdit || !current.Visible)
					{
						continue;
					}
					flag = prmColumn.Equals(current);
					return flag;
				}
				return false;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return flag;
		}

		private bool EsPrimerRenglonCapturable(int prmRow)
		{
			if (prmRow != 0)
			{
				return false;
			}
			return this.MainView.GetVisibleRowHandle(prmRow) == prmRow;
		}

		private bool EsUltimaColumnaCapturable(GridColumn prmColumn)
		{
			for (int i = this.MainView.Columns.Count - 1; i >= 0; i--)
			{
				GridColumn item = this.MainView.Columns[i];
				if (item.OptionsColumn.AllowEdit && item.Visible)
				{
					return prmColumn.Equals(item);
				}
			}
			return false;
		}

		private bool EsUltimoRenglonCapturable(int prmRow)
		{
			if (prmRow != this.atrGrid.MainView.RowCount - 1)
			{
				return false;
			}
			return this.MainView.GetVisibleRowHandle(prmRow) == prmRow;
		}

		private bool EsVistaConCatalogos(ColumnView miVista)
		{
			return this.MainView.Name == miVista.Name;
		}

		private int getMaxWith(DataTable prmTabla, int prmIndexColumnTable)
		{
			string columnName = prmTabla.Columns[prmIndexColumnTable].ColumnName;
			foreach (DataRow row in prmTabla.Rows)
			{
				if (row[prmIndexColumnTable].ToString().Length <= columnName.Length)
				{
					continue;
				}
				columnName = row[prmIndexColumnTable].ToString();
			}
			return columnName.Length * 9;
		}

		private DriverXtraGrid_Celda getSiguienteCeldaActiva(DriverXtraGrid_Celda prmCeldaActual)
		{
			if (this.atrGrid.MainView == null)
			{
				return prmCeldaActual;
			}
			if (this.atrGrid.MainView.RowCount == 0)
			{
				return prmCeldaActual;
			}
			int rowHandle = prmCeldaActual.RowHandle;
			int num = this.ObtenIndiceColumnaActual(prmCeldaActual.Column);
			bool flag = false;
			int num1 = 0;
			int num2 = 0;
			int num3 = rowHandle;
			while (num3 < this.atrGrid.MainView.RowCount)
			{
				int num4 = num;
				while (num4 < this.MainView.Columns.Count)
				{
					if (!this.MainView.Columns[num4].OptionsColumn.AllowEdit)
					{
						num4++;
					}
					else
					{
						num1 = num4;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					num = this.MainView.Columns.IndexOf(this.MainView.GetVisibleColumn(0));
					num3++;
				}
				else
				{
					num2 = num3;
					break;
				}
			}
			return this.Cells[num2, num1];
		}

		private bool getValoresDependencias(DriverXtraGrid_Celda prmCell, bool prmPedirValores)
		{
			int num = this.ObtenIndiceColumnaActual(prmCell.Column);
			int rowHandle = prmCell.RowHandle;
			if (!prmCell.Column.Visible)
			{
				return true;
			}
			if (this.CatalogosBase[num] == null || this.CatalogosBase[num].Vacio)
			{
				return true;
			}
			bool flag = true;
			ValorDependencia[] valoresDeDependencias = this.CatalogosBase[num].ValoresDeDependencias;
			for (int i = 0; i < (int)valoresDeDependencias.Length; i++)
			{
				ValorDependencia valorDependencium = valoresDeDependencias[i];
				GridColumn gridColumn = this.ObtenColumnaConMetacatalogo(valorDependencium.MetaCatalogoDependencia.NombreMetaCatalogo);
				if (gridColumn != null)
				{
					this.ObtenIndiceColumnaActual(gridColumn);
					DriverXtraGrid_Celda driverXtraGridCelda = new DriverXtraGrid_Celda(rowHandle, gridColumn, prmCell.Column.View.GetRowCellValue(rowHandle, gridColumn));
					bool flag1 = this.CeldaEsValida(driverXtraGridCelda);
                    if (!prmPedirValores || flag1 && !valorDependencium.DependenciaObligatoria || flag1 && valorDependencium.DependenciaObligatoria && Tool.IfNull(driverXtraGridCelda.Value, "").ToString().Trim() != "")
					{
						valorDependencium.Valor = Tool.IfNull(driverXtraGridCelda.Value, "").ToString();
					}
					else if (!prmPedirValores || !(valorDependencium.Valor == ""))
					{
						flag = true;
					}
					else
					{
						string str = this.RegresaEleccionDeUsuario(driverXtraGridCelda, "");
						if (str != "*")
						{
							this._SetCellValue(driverXtraGridCelda, str);
						}
						else
						{
							flag = false;
							break;
						}
					}
				}
			}
			this.RefrescarControlesExternos(prmCell.Column.View);
			return flag;
		}

		private static void grid_Enter(object sender, EventArgs e)
		{
			GridView focusedView = (GridView)((GridControl)sender).FocusedView;
			focusedView.Appearance.FocusedCell.BackColor = Color.Yellow;
			focusedView.Appearance.FocusedCell.BackColor2 = Color.Yellow;
		}

		private static void grid_FocusedViewChanged(object sender, ViewFocusEventArgs e)
		{
			if (e.PreviousView != null)
			{
				GridView previousView = (GridView)e.PreviousView;
				previousView.Appearance.FocusedCell.BackColor = Color.Empty;
				previousView.Appearance.FocusedCell.BackColor2 = Color.Empty;
			}
			if (e.View != null)
			{
				GridView view = (GridView)e.View;
				view.Appearance.FocusedCell.BackColor = Color.Yellow;
				view.Appearance.FocusedCell.BackColor2 = Color.Yellow;
			}
		}

		private static void grid_Leave(object sender, EventArgs e)
		{
			GridView focusedView = (GridView)((GridControl)sender).FocusedView;
			focusedView.Appearance.FocusedCell.BackColor = Color.Empty;
			focusedView.Appearance.FocusedCell.BackColor2 = Color.Empty;
		}

		private void Inicializa_Arreglos(GridView View)
		{
			this.CatalogosBase = new Catalogo[View.Columns.Count];
			this.ColumnasDestinoDescripcion = new int[View.Columns.Count];
			for (int i = 0; i < (int)this.ColumnasDestinoDescripcion.Length; i++)
			{
				this.ColumnasDestinoDescripcion[i] = -1;
			}
			this.ControlesDestinoDeColumnas = new Control[View.Columns.Count];
		}

		public void LimpiarColumnasDependientes(DriverXtraGrid_Celda prmCeldaActual)
		{
			this.ObtenIndiceColumnaActual(prmCeldaActual.Column);
			int rowHandle = prmCeldaActual.RowHandle;
			DriverXtraGrid_Celda[] driverXtraGridCeldaArray = this.ObtenCeldasDependientes(prmCeldaActual);
			if (driverXtraGridCeldaArray != null)
			{
				DriverXtraGrid_Celda[] driverXtraGridCeldaArray1 = driverXtraGridCeldaArray;
				for (int i = 0; i < (int)driverXtraGridCeldaArray1.Length; i++)
				{
					this.LimpiarValorCelda(driverXtraGridCeldaArray1[i]);
				}
			}
			this.RefrescarControlesExternos(prmCeldaActual.Column.View);
		}

		public void LimpiarValorCelda(DriverXtraGrid_Celda prmCeldaActual)
		{
			int num = this.ObtenIndiceColumnaActual(prmCeldaActual.Column);
			int rowHandle = prmCeldaActual.RowHandle;
			prmCeldaActual.Value = DBNull.Value;
			prmCeldaActual.Tag = null;
			if (this.ColumnasDestinoDescripcion[num] != -1)
			{
				DriverXtraGrid_Celda item = this.Cells[rowHandle, this.ColumnasDestinoDescripcion[num]];
				item.Value = DBNull.Value;
			}
			if (this.tieneCatalogo(prmCeldaActual))
			{
				this.LimpiarColumnasDependientes(prmCeldaActual);
			}
			this.RefrescarControlesExternos(prmCeldaActual.Column.View);
		}

		public bool LLenaGrid(string prmSqlText)
		{
			this.DAO = DataAccessCls.DevuelveInstancia();
			return this.LLenaGrid(prmSqlText, this.DAO.TiempoDeEspera_Segundos);
		}

		public bool LLenaGrid(string prmSqlText, int TIEMPO_ESPERA)
		{
			this.DAO = DataAccessCls.DevuelveInstancia();
			DataTable dataTable = new DataTable();
			int tiempoDeEsperaSegundos = this.DAO.TiempoDeEspera_Segundos;
			bool flag = false;
			this.DAO.TiempoDeEspera_Segundos = TIEMPO_ESPERA;
			if (this.DAO.RegresaConsultaSQL(prmSqlText, ref dataTable))
			{
				this.atrGrid.DataSource = dataTable;
				if (this.atrAutoAjustarAnchoAlValorMaximo)
				{
					this.AutoAjustaAnchoColumnas(dataTable);
				}
				flag = true;
			}
			return flag;
		}

		private void MainView_DragObjectDrop(object sender, DragObjectDropEventArgs e)
		{
			if (e.DragObject.Equals(typeof(GridColumn)))
			{
				((GridColumn)e.DragObject).Visible = false;
			}
		}

		private void MainView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
		{
			if (!this.atrEventosActivados)
			{
				return;
			}
			ColumnView columnView = (ColumnView)sender;
			if (columnView.FocusedColumn != null && e.FocusedRowHandle >= 0 && e.FocusedRowHandle < columnView.RowCount)
			{
				this.cambioDeRenglon(this.Cells[e.FocusedRowHandle, columnView.FocusedColumn]);
			}
			this.OnCambioRenglonActivo(new DriverXtraGrid_CambioRenglonActivoEventArgs((GridView)sender, e));
		}

		private void MainView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
		{
			if (!this.atrEventosActivados)
			{
				return;
			}
			e.ExceptionMode = ExceptionMode.NoAction;
		}

		private void MainView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
		{
			if (!this.atrEventosActivados)
			{
				return;
			}
			e.ExceptionMode = ExceptionMode.NoAction;
		}

		private void MainView_ValidateRow(object sender, ValidateRowEventArgs e)
		{
			if (!this.atrEventosActivados || !this.atrRaisedValidateRow)
			{
				e.Valid = false;
				return;
			}
			DriverXtraGridValidateRowEventArgs driverXtraGridValidateRowEventArg = new DriverXtraGridValidateRowEventArgs(e, this.atrAgregarRenglonAutomatico);
			this.OnValidaRenglon(driverXtraGridValidateRowEventArg);
			if (!driverXtraGridValidateRowEventArg.Valid)
			{
				this.atrUltimaDescripcionRenglonInvalido = driverXtraGridValidateRowEventArg.ErrorText;
			}
			e.Valid = driverXtraGridValidateRowEventArg.Valid;
		}

		private void MainView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
		{
			SelectedElement_DriverXtraGridArgs selectedElementDriverXtraGridArg;
			if (!this.atrEventosActivados)
			{
				return;
			}
			if (this.atrCancelacionPorBlancoRaised)
			{
				this.atrCancelacionPorBlancoRaised = false;
				this.atrBeforeValidaRenglonRaised = false;
				e.Value = DBNull.Value;
				e.Valid = false;
				return;
			}
			ColumnView columnView = (ColumnView)sender;
			int focusedRowHandle = columnView.FocusedRowHandle;
			if (focusedRowHandle < 0 || focusedRowHandle >= columnView.RowCount)
			{
				return;
			}
			DriverXtraGrid_Celda item = this.Cells[focusedRowHandle, columnView.FocusedColumn];
			if (item != null)
			{
				object value = item.Value;
				object columnType = item.CastToColumnType(e.Value);
				this.getValoresDependencias(item, false);
				bool flag = this._SetCellValue(item, columnType);
				bool str = item.CastToColumnType(e.Value).ToString() == columnType.ToString();
				item.Value = columnType;
				e.Value = columnType;
				int num = this.ObtenIndiceColumnaActual(item.Column);
				selectedElementDriverXtraGridArg = (!this.tieneCatalogo(item) ? new SelectedElement_DriverXtraGridArgs(this, null, null, item.RowHandle, item.Column, (!this.CeldaEsValida(item) ? false : str), columnView, this.atrCambiElementoRaisedByLeave) : new SelectedElement_DriverXtraGridArgs(this, this.CatalogosBase[num].ObtenElementoRow(item.Value.ToString()), this.CatalogosBase[num], item.RowHandle, item.Column, (!this.CeldaEsValida(item) ? false : str), columnView, this.atrCambiElementoRaisedByLeave));
				if (flag || selectedElementDriverXtraGridArg.CatalogoBase != null && !str)
				{
					this.OnCambioElemento(this, selectedElementDriverXtraGridArg);
				}
				e.Valid = selectedElementDriverXtraGridArg.EsValido;
				if (!selectedElementDriverXtraGridArg.EsValido)
				{
					item.Value = DBNull.Value;
					e.Value = DBNull.Value;
					e.ErrorText = selectedElementDriverXtraGridArg.DescripcionElementoInvalido;
					this.atrUltimaDescripcionDeErrorDesplegada = e.ErrorText;
					if (columnView.ActiveEditor != null)
					{
						columnView.ActiveEditor.SelectAll();
					}
				}
				this.atrCancelacionPorBlancoRaised = (!this.atrBlancoEsValorInvalido ? false : !selectedElementDriverXtraGridArg.EsValido);
				if (!this.atrCancelacionPorBlancoRaised)
				{
					this.atrRaisedValidateRow = false;
					this.atrGrid.FocusedView.UpdateCurrentRow();
					this.atrRaisedValidateRow = true;
				}
				this.atrCancelacionPorBlancoRaised = (!this.atrCancelacionPorBlancoRaised ? false : this.atrBeforeValidaRenglonRaised);
			}
		}

		private AccessForm ObtenAccessForm()
		{
			for (Control i = this.atrGrid.Parent; i != null; i = i.Parent)
			{
				if (i.GetType().IsSubclassOf(typeof(AccessForm)))
				{
					return (AccessForm)i;
				}
			}
			return null;
		}

		public DriverXtraGrid_Celda[] ObtenCeldasDependientes(DriverXtraGrid_Celda prmCeldaActual)
		{
			int num = this.ObtenIndiceColumnaActual(prmCeldaActual.Column);
			int rowHandle = prmCeldaActual.RowHandle;
			if (!this.tieneCatalogo(prmCeldaActual))
			{
				return null;
			}
			DriverXtraGrid_Celda[] driverXtraGridCeldaArray = new DriverXtraGrid_Celda[0];
			for (int i = 0; i < (int)this.CatalogosBase.Length; i++)
			{
				if (this.CatalogosBase[i] != null && !this.CatalogosBase[i].Vacio && i != num && this.CatalogosBase[i].DependoDe(this.CatalogosBase[num]))
				{
					DriverXtraGrid_Celda[] driverXtraGridCelda = new DriverXtraGrid_Celda[(int)driverXtraGridCeldaArray.Length + 1];
					driverXtraGridCeldaArray.CopyTo(driverXtraGridCelda, 0);
					driverXtraGridCelda[(int)driverXtraGridCelda.Length - 1] = new DriverXtraGrid_Celda(rowHandle, prmCeldaActual.Column.View.Columns[i], prmCeldaActual.Column.View.GetRowCellValue(rowHandle, prmCeldaActual.Column.View.Columns[i]));
					driverXtraGridCeldaArray = driverXtraGridCelda;
				}
			}
			if ((int)driverXtraGridCeldaArray.Length > 0)
			{
				return driverXtraGridCeldaArray;
			}
			return null;
		}

		public GridColumn ObtenColumnaConMetacatalogo(string prmMetaCatalogo)
		{
			for (int i = 0; i < (int)this.CatalogosBase.Length; i++)
			{
				if (this.CatalogosBase[i] != null && this.CatalogosBase[i].MetaCatalogoBase.NombreMetaCatalogo == prmMetaCatalogo)
				{
					return this.MainView.Columns[i];
				}
			}
			return null;
		}

		public int ObtenIndiceColumnaActual(GridColumn prmColumn)
		{
			return prmColumn.VisibleIndex;
		}

		public int ObtenIndiceColumnaActual()
		{
			return this.MainView.FocusedColumn.VisibleIndex;
		}

		public DataRow ObtenNuevoRenglon()
		{
			return ((DataView)this.MainView.DataSource).Table.NewRow();
		}

		private bool obtenValoresDependenciasExistentes(DriverXtraGrid_Celda cell)
		{
			return this.getValoresDependencias(cell, false);
		}

		protected virtual void OnAfterEliminacionRenglon(EliminacionRenglonDriverXtraGridArgs e)
		{
			if (this.AfterEliminacionRenglon != null)
			{
				this.AfterEliminacionRenglon(this, e);
			}
		}

		protected virtual void OnBeforeEliminacionRenglon(EliminacionRenglonDriverXtraGridArgs e)
		{
			if (this.BeforeEliminacionRenglon != null)
			{
				this.BeforeEliminacionRenglon(this, e);
			}
		}

		protected void OnCambioElemento(object sender, SelectedElement_DriverXtraGridArgs e)
		{
			if (this.CambioElemento != null)
			{
				this.CambioElemento(sender, e);
			}
			if (!this.atrNoLanzarErrorEnCasoDeError && !e.EsValido)
			{
				MessageBox.Show(e.DescripcionElementoInvalido, DriverXtraGrid.TituloMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		protected void OnCambioRenglonActivo(DriverXtraGrid_CambioRenglonActivoEventArgs e)
		{
			if (this.CambioRenglonActivo != null)
			{
				this.CambioRenglonActivo(this, e);
			}
		}

		protected void OnValidaRenglon(DriverXtraGridValidateRowEventArgs e)
		{
			if (this.ValidaRenglon != null)
			{
				this.ValidaRenglon(this, e);
			}
			if (e.Valid)
			{
				if (e.SolicitaNuevoRenglon && this.EsUltimoRenglonCapturable(e.RowHandle) && e.AgregarNuevoRenglon)
				{
					this.atrEventosActivados = false;
					DataRow dataRow = this.ObtenNuevoRenglon();
					if (e.ItemArray != null)
					{
						int num = 0;
						object[] itemArray = e.ItemArray;
						for (int i = 0; i < (int)itemArray.Length; i++)
						{
							object obj = itemArray[i];
							dataRow[this.MainView.Columns[num].FieldName] = obj;
							num++;
						}
					}
					this.AgregaRenglon(dataRow);
					this.atrEventosActivados = true;
					return;
				}
			}
			else if (!this.atrNoLanzarErrorEnCasoDeError)
			{
				MessageBox.Show(e.ErrorText, DriverXtraGrid.TituloMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private bool pedirValoresDependenciasObligatorias(DriverXtraGrid_Celda prmCell)
		{
			return this.getValoresDependencias(prmCell, true);
		}

		public static void Pintar(GridControl grid, DriverXtraGrid.Estilos estilo)
		{
			foreach (GridView viewCollection in grid.ViewCollection)
			{
				if (estilo == DriverXtraGrid.Estilos.Captura)
				{
					DriverXtraGrid.setAparienciaCaptura(viewCollection);
				}
				if (estilo != DriverXtraGrid.Estilos.Seleccion)
				{
					continue;
				}
				DriverXtraGrid.setAparienciaSeleccion(viewCollection);
			}
			if (estilo == DriverXtraGrid.Estilos.Captura)
			{
				DriverXtraGrid.AsignaEventosPintado(grid);
			}
		}

		public void RefrescarControlesExternos(ColumnView miVista)
		{
			if (!this.EsVistaConCatalogos(miVista))
			{
				return;
			}
			for (int i = 0; i < miVista.Columns.Count; i++)
			{
				if (this.ControlesDestinoDeColumnas[i] != null)
				{
					if (miVista.RowCount == 0)
					{
						this.ControlesDestinoDeColumnas[i].Text = "";
					}
					else
					{
						if (this.ControlesDestinoDeColumnas[i].GetType() == (new AccTextBox()).GetType() && miVista.GetRowCellValue(miVista.FocusedRowHandle, miVista.Columns[i]).ToString() != this.ControlesDestinoDeColumnas[i].Text)
						{
							((AccTextBox)this.ControlesDestinoDeColumnas[i]).SetTextBoxValue(miVista.GetRowCellValue(miVista.FocusedRowHandle, miVista.Columns[i]).ToString());
						}
						this.ControlesDestinoDeColumnas[i].Text = miVista.GetRowCellValue(miVista.FocusedRowHandle, miVista.Columns[i]).ToString();
					}
				}
			}
		}

		public string RegresaEleccionDeUsuario(DriverXtraGrid_Celda prmCell, string prmCriterio)
		{
			int num = this.ObtenIndiceColumnaActual(prmCell.Column);
			int rowHandle = prmCell.RowHandle;
			if (!this.tieneCatalogo(num))
			{
				return "*";
			}
			if (!this.pedirValoresDependenciasObligatorias(prmCell))
			{
				return "*";
			}
			return this.CatalogosBase[num].RegresaEleccionDeUsuario(prmCriterio);
		}

		private static void setAparienciaCaptura(GridView prmView)
		{
			prmView.Appearance.BeginUpdate();
			prmView.PaintStyleName = "MixedXP";
			prmView.Appearance.Empty.BackColor = Color.Empty;
			prmView.Appearance.Empty.BackColor2 = Color.Empty;
			prmView.Appearance.Empty.Options.UseBackColor = true;
			prmView.Appearance.FocusedRow.BackColor = Color.LightGray;
			prmView.Appearance.FocusedRow.BackColor2 = Color.LightGray;
			prmView.Appearance.FocusedRow.ForeColor = Color.Black;
			prmView.Appearance.FocusedRow.Options.UseBackColor = true;
			prmView.Appearance.FocusedRow.Options.UseForeColor = true;
			prmView.Appearance.FocusedCell.BackColor = Color.Empty;
			prmView.Appearance.FocusedCell.BackColor2 = Color.Empty;
			prmView.Appearance.FocusedCell.ForeColor = Color.Black;
			prmView.Appearance.FocusedCell.Options.UseBackColor = true;
			prmView.Appearance.FocusedCell.Options.UseForeColor = true;
			prmView.Appearance.HideSelectionRow.BackColor = Color.Empty;
			prmView.Appearance.HideSelectionRow.BackColor2 = Color.Empty;
			prmView.Appearance.HideSelectionRow.ForeColor = Color.Black;
			prmView.Appearance.HideSelectionRow.Options.UseBackColor = true;
			prmView.Appearance.HideSelectionRow.Options.UseForeColor = true;
			prmView.Appearance.Row.BackColor = Color.OldLace;
			prmView.Appearance.Row.BackColor2 = Color.OldLace;
			prmView.Appearance.Row.ForeColor = Color.Black;
			prmView.Appearance.Row.Options.UseBackColor = true;
			prmView.Appearance.Row.Options.UseForeColor = true;
			prmView.Appearance.HeaderPanel.BackColor = Color.Navy;
			prmView.Appearance.HeaderPanel.BackColor2 = Color.Navy;
			prmView.Appearance.HeaderPanel.ForeColor = Color.White;
			prmView.Appearance.HeaderPanel.Options.UseBackColor = true;
			prmView.Appearance.HeaderPanel.Options.UseForeColor = true;
			prmView.Appearance.HeaderPanel.BorderColor = Color.Navy;
			prmView.Appearance.HorzLine.BackColor = Color.Silver;
			prmView.Appearance.HorzLine.BackColor2 = Color.Silver;
			prmView.Appearance.HorzLine.Options.UseBackColor = true;
			prmView.Appearance.VertLine.BackColor = Color.Silver;
			prmView.Appearance.VertLine.BackColor2 = Color.Silver;
			prmView.Appearance.VertLine.Options.UseBackColor = true;
			prmView.Appearance.EvenRow.BackColor = Color.White;
			prmView.Appearance.EvenRow.BackColor2 = Color.White;
			prmView.Appearance.EvenRow.ForeColor = Color.Black;
			prmView.Appearance.EvenRow.Options.UseBackColor = true;
			prmView.Appearance.EvenRow.Options.UseForeColor = true;
			prmView.Appearance.OddRow.BackColor = Color.White;
			prmView.Appearance.OddRow.BackColor2 = Color.White;
			prmView.Appearance.OddRow.ForeColor = Color.Black;
			prmView.Appearance.OddRow.Options.UseBackColor = true;
			prmView.Appearance.OddRow.Options.UseForeColor = true;
			prmView.Appearance.GroupPanel.BackColor = prmView.Appearance.GroupRow.BackColor;
			prmView.Appearance.GroupPanel.Options.UseBackColor = true;
			prmView.OptionsBehavior.Editable = true;
			prmView.OptionsBehavior.AutoPopulateColumns = true;
			prmView.OptionsSelection.EnableAppearanceFocusedCell = true;
			prmView.OptionsSelection.EnableAppearanceFocusedRow = true;
			prmView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
			prmView.OptionsCustomization.AllowRowSizing = true;
			prmView.OptionsNavigation.EnterMoveNextColumn = true;
			prmView.OptionsView.ShowGroupPanel = false;
			prmView.OptionsView.EnableAppearanceEvenRow = true;
			prmView.OptionsView.EnableAppearanceOddRow = true;
			if (prmView.GetType() == typeof(BandedGridView))
			{
				foreach (GridBand band in ((BandedGridView)prmView).Bands)
				{
					band.AppearanceHeader.BackColor = Color.Navy;
					band.AppearanceHeader.BackColor2 = Color.Navy;
					band.AppearanceHeader.BorderColor = Color.Navy;
					band.AppearanceHeader.ForeColor = Color.White;
					band.AppearanceHeader.Options.UseBackColor = true;
					band.AppearanceHeader.Options.UseForeColor = true;
					band.OptionsBand.AllowMove = false;
				}
			}
			prmView.Appearance.EndUpdate();
		}

		private static void setAparienciaSeleccion(GridView prmView)
		{
			prmView.Appearance.BeginUpdate();
			prmView.PaintStyleName = "MixedXP";
			prmView.Appearance.Empty.BackColor = Color.Empty;
			prmView.Appearance.Empty.BackColor2 = Color.Empty;
			prmView.Appearance.Empty.Options.UseBackColor = true;
			prmView.Appearance.EvenRow.BackColor = Color.White;
			prmView.Appearance.EvenRow.BackColor2 = Color.White;
			prmView.Appearance.EvenRow.ForeColor = Color.Black;
			prmView.Appearance.EvenRow.Options.UseBackColor = true;
			prmView.Appearance.EvenRow.Options.UseForeColor = true;
			prmView.Appearance.FocusedRow.Reset();
			prmView.Appearance.FocusedCell.BackColor = Color.Empty;
			prmView.Appearance.FocusedCell.BackColor2 = Color.Empty;
			prmView.Appearance.FocusedCell.Options.UseBackColor = true;
			prmView.Appearance.HideSelectionRow.BackColor = Color.Empty;
			prmView.Appearance.HideSelectionRow.BackColor2 = Color.Empty;
			prmView.Appearance.HideSelectionRow.ForeColor = Color.Black;
			prmView.Appearance.HideSelectionRow.Options.UseBackColor = true;
			prmView.Appearance.HideSelectionRow.Options.UseForeColor = true;
			prmView.Appearance.HeaderPanel.BackColor = Color.FromArgb(52, 98, 135);
			prmView.Appearance.HeaderPanel.BackColor2 = Color.FromArgb(52, 98, 135);
			prmView.Appearance.HeaderPanel.BorderColor = Color.FromArgb(52, 98, 135);
			prmView.Appearance.HeaderPanel.ForeColor = Color.White;
			prmView.Appearance.HeaderPanel.Options.UseBackColor = true;
			prmView.Appearance.HeaderPanel.Options.UseForeColor = true;
			prmView.Appearance.OddRow.BackColor = Color.FromArgb(208, 213, 232);
			prmView.Appearance.OddRow.BackColor2 = Color.FromArgb(208, 213, 232);
			prmView.Appearance.OddRow.ForeColor = Color.Black;
			prmView.Appearance.OddRow.Options.UseBackColor = true;
			prmView.Appearance.OddRow.Options.UseForeColor = true;
			prmView.Appearance.Row.BackColor = Color.White;
			prmView.Appearance.Row.BackColor2 = Color.White;
			prmView.Appearance.Row.ForeColor = Color.Black;
			prmView.Appearance.Row.Options.UseBackColor = true;
			prmView.Appearance.Row.Options.UseForeColor = true;
			prmView.OptionsSelection.EnableAppearanceFocusedCell = false;
			prmView.OptionsSelection.EnableAppearanceFocusedRow = true;
			prmView.Appearance.HorzLine.BackColor = Color.Silver;
			prmView.Appearance.HorzLine.BackColor2 = Color.Silver;
			prmView.Appearance.HorzLine.Options.UseBackColor = true;
			prmView.Appearance.VertLine.BackColor = Color.Silver;
			prmView.Appearance.VertLine.BackColor2 = Color.Silver;
			prmView.Appearance.VertLine.Options.UseBackColor = true;
			prmView.Appearance.GroupPanel.BackColor = prmView.Appearance.GroupRow.BackColor;
			prmView.Appearance.GroupPanel.Options.UseBackColor = true;
			prmView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Default;
			prmView.OptionsView.EnableAppearanceEvenRow = true;
			prmView.OptionsView.EnableAppearanceOddRow = true;
			if (prmView.GetType() == typeof(BandedGridView))
			{
				foreach (GridBand band in ((BandedGridView)prmView).Bands)
				{
					band.AppearanceHeader.BackColor = Color.FromArgb(52, 98, 135);
					band.AppearanceHeader.BackColor2 = Color.FromArgb(52, 98, 135);
					band.AppearanceHeader.BorderColor = Color.FromArgb(52, 98, 135);
					band.AppearanceHeader.ForeColor = Color.White;
					band.AppearanceHeader.Options.UseBackColor = true;
					band.AppearanceHeader.Options.UseForeColor = true;
					band.OptionsBand.AllowMove = false;
				}
			}
			prmView.Appearance.EndUpdate();
		}

		private void setEstilo(DriverXtraGrid.Estilos prmEstilo)
		{
			if (this.atrGrid.Views == null)
			{
				return;
			}
			switch (prmEstilo)
			{
				case DriverXtraGrid.Estilos.Seleccion:
				{
					this.setEstiloSeleccion();
					return;
				}
				case DriverXtraGrid.Estilos.Captura:
				{
					this.setEstiloCaptura();
					return;
				}
				default:
				{
					return;
				}
			}
		}

		private void setEstiloCaptura()
		{
			this.atrGrid.FocusedViewChanged -= new ViewFocusEventHandler(DriverXtraGrid.grid_FocusedViewChanged);
			this.atrGrid.FocusedViewChanged += new ViewFocusEventHandler(DriverXtraGrid.grid_FocusedViewChanged);
			foreach (GridView viewCollection in this.atrGrid.ViewCollection)
			{
				this.setEstiloCaptura(viewCollection);
				DriverXtraGrid.setAparienciaCaptura(viewCollection);
			}
			this.ConfiguraCatalogos();
		}

		private void setEstiloCaptura(GridView prmView)
		{
			prmView.GroupPanelText = "Arrastre aquí las columnas que desea agrupar";
			this.MostrarGroupPanel = false;
			prmView.OptionsBehavior.Editable = true;
			prmView.OptionsBehavior.AutoPopulateColumns = true;
			prmView.OptionsSelection.EnableAppearanceFocusedCell = true;
			prmView.OptionsSelection.EnableAppearanceFocusedRow = true;
			prmView.OptionsView.EnableAppearanceEvenRow = false;
			prmView.OptionsView.EnableAppearanceOddRow = false;
			prmView.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
			prmView.OptionsView.ShowIndicator = false;
			prmView.OptionsCustomization.AllowRowSizing = false;
			prmView.OptionsNavigation.EnterMoveNextColumn = true;
			foreach (GridColumn column in prmView.Columns)
			{
				column.OptionsColumn.AllowGroup = DefaultBoolean.False;
				column.OptionsColumn.AllowMove = false;
			}
			prmView.InvalidRowException -= new InvalidRowExceptionEventHandler(this.MainView_InvalidRowException);
			prmView.InvalidValueException -= new InvalidValueExceptionEventHandler(this.MainView_InvalidValueException);
			prmView.ValidatingEditor -= new BaseContainerValidateEditorEventHandler(this.MainView_ValidatingEditor);
			prmView.FocusedRowChanged -= new FocusedRowChangedEventHandler(this.MainView_FocusedRowChanged);
			prmView.ValidateRow -= new ValidateRowEventHandler(this.MainView_ValidateRow);
			prmView.InvalidRowException += new InvalidRowExceptionEventHandler(this.MainView_InvalidRowException);
			prmView.InvalidValueException += new InvalidValueExceptionEventHandler(this.MainView_InvalidValueException);
			prmView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(this.MainView_ValidatingEditor);
			prmView.FocusedRowChanged += new FocusedRowChangedEventHandler(this.MainView_FocusedRowChanged);
			prmView.ValidateRow += new ValidateRowEventHandler(this.MainView_ValidateRow);
			prmView.DragObjectDrop -= new DragObjectDropEventHandler(this.MainView_DragObjectDrop);
			prmView.DragObjectDrop += new DragObjectDropEventHandler(this.MainView_DragObjectDrop);
			this.Inicializa_Arreglos(prmView);
		}

		private void setEstiloSeleccion()
		{
			foreach (GridView viewCollection in this.atrGrid.ViewCollection)
			{
				this.setEstiloSeleccion(viewCollection);
				DriverXtraGrid.setAparienciaSeleccion(viewCollection);
			}
		}

		private void setEstiloSeleccion(GridView prmView)
		{
			prmView.GroupPanelText = "Arrastre aquí las columnas que desea agrupar";
			this.MostrarGroupPanel = false;
			prmView.OptionsBehavior.Editable = false;
			prmView.OptionsSelection.EnableAppearanceFocusedCell = false;
			prmView.OptionsView.EnableAppearanceEvenRow = true;
			prmView.OptionsView.EnableAppearanceOddRow = true;
			prmView.OptionsView.ShowIndicator = false;
			prmView.OptionsBehavior.AutoPopulateColumns = true;
			prmView.OptionsCustomization.AllowRowSizing = false;
			foreach (GridColumn column in prmView.Columns)
			{
				column.OptionsColumn.AllowEdit = false;
				column.OptionsColumn.AllowFocus = false;
				column.OptionsColumn.AllowGroup = DefaultBoolean.False;
				column.OptionsColumn.AllowMove = false;
			}
			prmView.DragObjectDrop -= new DragObjectDropEventHandler(this.MainView_DragObjectDrop);
			prmView.DragObjectDrop += new DragObjectDropEventHandler(this.MainView_DragObjectDrop);
		}

		public void SetMiValorEnColumnasDependientes(DriverXtraGrid_Celda prmCeldaActual)
		{
			int num = this.ObtenIndiceColumnaActual(prmCeldaActual.Column);
			int rowHandle = prmCeldaActual.RowHandle;
			DriverXtraGrid_Celda[] driverXtraGridCeldaArray = this.ObtenCeldasDependientes(prmCeldaActual);
			if (driverXtraGridCeldaArray == null)
			{
				return;
			}
			DriverXtraGrid_Celda[] driverXtraGridCeldaArray1 = driverXtraGridCeldaArray;
			for (int i = 0; i < (int)driverXtraGridCeldaArray1.Length; i++)
			{
				int num1 = this.ObtenIndiceColumnaActual(driverXtraGridCeldaArray1[i].Column);
				if (this.CatalogosBase[num1] != null)
				{
					this.CatalogosBase[num1].SetValorDeDependecia(this.CatalogosBase[num].MetaCatalogoBase.NombreMetaCatalogo, Tool.IfNull(prmCeldaActual.Value, "").ToString());
				}
			}
		}

		private bool tieneCatalogo()
		{
			return this.tieneCatalogo(this.ObtenIndiceColumnaActual());
		}

		private bool tieneCatalogo(int prmColumnIndex)
		{
			if (this.CatalogosBase == null || prmColumnIndex == -1 || prmColumnIndex >= (int)this.CatalogosBase.Length || this.CatalogosBase[prmColumnIndex] == null)
			{
				return false;
			}
			return !this.CatalogosBase[prmColumnIndex].Vacio;
		}

		private bool tieneCatalogo(DriverXtraGrid_Celda prmCeldaActual)
		{
			if (prmCeldaActual == null || prmCeldaActual.Column == null)
			{
				return false;
			}
			return this.tieneCatalogo(this.ObtenIndiceColumnaActual(prmCeldaActual.Column));
		}

		public string ValidayObtenDescripcion(DriverXtraGrid_Celda prmCeldaActual)
		{
			string str = "";
			if (prmCeldaActual.Value != null)
			{
				str = prmCeldaActual.Value.ToString();
			}
			return this.ValidayObtenDescripcion(prmCeldaActual, str);
		}

		public string ValidayObtenDescripcion(DriverXtraGrid_Celda prmCeldaActual, string valor)
		{
			int num = this.ObtenIndiceColumnaActual(prmCeldaActual.Column);
			int rowHandle = prmCeldaActual.RowHandle;
			if (!this.tieneCatalogo(prmCeldaActual))
			{
				prmCeldaActual.Tag = (this.atrPermitirAvanceCeldaInvalida || !this.atrBlancoEsValorInvalido ? true : !(valor == ""));
				return prmCeldaActual.Value.ToString();
			}
			if (valor == "" && this.atrPermitirAvanceCeldaInvalida)
			{
				prmCeldaActual.Tag = true;
				return "";
			}
			DataRow dataRow = this.CatalogosBase[num].ObtenElementoRow(valor);
			if (dataRow == null)
			{
				prmCeldaActual.Tag = false;
				return this.CatalogosBase[num].CadenaDescripcionNoValida;
			}
			prmCeldaActual.Tag = true;
			return dataRow[this.CatalogosBase[num].MetaCatalogoBase.CampoDescripcion].ToString();
		}

		public event DriverXtraGrid.DriverXtraGridEliminacionRenglonEventHandler AfterEliminacionRenglon;

		public event DriverXtraGrid.DriverXtraGridEliminacionRenglonEventHandler BeforeEliminacionRenglon;

		public event DriverXtraGrid.DriverXtraGrid_CambioElemento_Delegate CambioElemento;

		public event DriverXtraGrid.CambioRenglonActivoEventHandler CambioRenglonActivo;

		public event DriverXtraGrid.DriverXtraGridValidateRowEventHandler ValidaRenglon;

		public delegate void ADSUMXTRA_GRID_Cambio_Celda_Delegate(object sender, CambioCeldaGridArgs e);

		public delegate void CambioRenglonActivoEventHandler(object sender, DriverXtraGrid_CambioRenglonActivoEventArgs e);

		public delegate void DriverXtraGrid_CambioElemento_Delegate(object sender, SelectedElement_DriverXtraGridArgs e);

		public delegate void DriverXtraGridEliminacionRenglonEventHandler(object sender, EliminacionRenglonDriverXtraGridArgs e);

		public delegate void DriverXtraGridValidateRowEventHandler(object sender, DriverXtraGridValidateRowEventArgs e);

		public enum Estilos
		{
			Seleccion,
			Captura
		}
	}
}