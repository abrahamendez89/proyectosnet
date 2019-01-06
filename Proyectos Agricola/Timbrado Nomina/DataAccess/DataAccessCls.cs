// Type: Sistema.DataAccessCls
// Assembly: DataAccess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C415D2F-B423-4DB8-8067-FB9CD8A174EC
// Assembly location: C:\Users\abrahamm\Documents\Visual Studio 2012\Projects2\Facturacion\Timbrado Nomina\TimbradoNomina\bin\Debug\DataAccess.dll

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using Ini;

namespace Sistema
{
  public class DataAccessCls
  {
    private string passwordSA = "";
    private string servidorAlterno_Nombre = "";
    private string servidorAlterno_BaseDeDatos = "";
    private string servidorAlterno_Usuario = "";
    private string servidorAlterno_Password = "";
    private bool UsuarioSql_Activado = true;
    private string UsuarioSql_Login = "";
    private string UsuarioSql_PassWord = "";
    private string ultimoMensajeEnviado = "";
    private bool enviarMensajesAPantalla = true;
    private string currentSqlStatement = "";
    private static DataAccessCls AccessData;
    private bool agenteEspecial_Activado;
    private bool servidorAlterno_Activado;
    private IniFileController UsuarioSql_ArchivoIni;
    private string UsuarioSql_RutaDeArchivoIni;
    private IniFileController archivoIni;
    private string miRutaDeArchivoIni;
    private bool UsuarioSql_bConexionDirecta;
    private string nombreServidor;
    private string nombreBaseDeDatos;
    private string loginUsuario;
    private string passwordUsuario;
    private int tiempoDeEspera;
    private string passwordEncriptado;
    private bool usuarioValidado;
    private SqlConnection conexionGlobal;
    private SqlTransaction transaccionGlobal;
    public bool conexionGlobalAbierta;
    private bool transaccionAbierta;
    private bool funcionalidadTouchScreenActivada;
    private object parametrosGenerales;
    private object parametrosSucursal;
    private object parametrosTerminal;

    public object ParametrosGenerales
    {
      get
      {
        return this.parametrosGenerales;
      }
      set
      {
        this.parametrosGenerales = value;
      }
    }

    public object ParametrosSucursal
    {
      get
      {
        return this.parametrosSucursal;
      }
      set
      {
        this.parametrosSucursal = value;
      }
    }

    public object ParametrosTerminal
    {
      get
      {
        return this.parametrosTerminal;
      }
      set
      {
        this.parametrosTerminal = value;
      }
    }

    public string UltimoMensajeEnviado
    {
      get
      {
        return this.ultimoMensajeEnviado;
      }
      set
      {
        this.ultimoMensajeEnviado = value;
      }
    }

    public bool EnviarMensajesAPantalla
    {
      get
      {
        return this.enviarMensajesAPantalla;
      }
      set
      {
        this.enviarMensajesAPantalla = value;
      }
    }

    public bool ServidoAlternoActivado
    {
      get
      {
        return this.servidorAlterno_Activado;
      }
    }

    public int TiempoDeEspera_Segundos
    {
      get
      {
        return this.tiempoDeEspera;
      }
      set
      {
        this.tiempoDeEspera = value;
      }
    }

    public static DataAccessCls DevuelveInstancia(bool TouchScreenActivada)
    {
      if (DataAccessCls.AccessData == null)
      {
        DataAccessCls.AccessData = new DataAccessCls();
        DataAccessCls.AccessData.AccesoDeUsuario();
        if (DataAccessCls.AccessData.loginUsuario.ToUpper() == "SA" && !DataAccessCls.AccessData.CreaArquitectura())
        {
          int num = (int) MessageBox.Show("Se presentó un error en la creación de los objetos Access. Verifique con el administrador del sistema", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        DataAccessCls.AccessData.tiempoDeEspera = 300;
        DataAccessCls.AccessData.passwordEncriptado = DataAccessCls.AccessData.ParametroAdministradoObtener("Access", "Agente Especial");
        DataAccessCls.AccessData.passwordSA = "";
      }
      return DataAccessCls.AccessData;
    }

    public static DataAccessCls DevuelveInstancia()
    {
      if (DataAccessCls.AccessData == null)
      {
        DataAccessCls.AccessData = new DataAccessCls();
        DataAccessCls.AccessData.tiempoDeEspera = 0;
        if (DataAccessCls.AccessData.AccesoDeUsuario())
        {
          if (DataAccessCls.AccessData.loginUsuario.ToUpper() == "SA" && !DataAccessCls.AccessData.CreaArquitectura())
          {
            int num = (int) MessageBox.Show("Se presentó un error en la creación de los objetos Access. Verifique con el administrador del sistema", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          }
          DataAccessCls.AccessData.passwordEncriptado = "";
          DataAccessCls.AccessData.passwordSA = "";
        }
        else
        {
          Application.Exit();
          DataAccessCls.AccessData = (DataAccessCls) null;
        }
      }
      return DataAccessCls.AccessData;
    }

    public void DestruyeInstancia()
    {
      DataAccessCls.AccessData = (DataAccessCls) null;
    }

    public static DataAccessCls DevuelveInstancia(string datosDeConexion)
    {
      if (DataAccessCls.AccessData == null)
      {
        string servidor = "";
        string baseDeDatos = "";
        string usuario = "";
        string password = "";
        DataAccessCls.AccessData = new DataAccessCls();
        if (datosDeConexion == "ASADM")
        {
          DataAccessCls.AccessData.UsuarioSql_bConexionDirecta = true;
          DataAccessCls.AccessData.EnviarMensajesAPantalla = false;
        }
        else
        {
          char[] separator = ":".ToCharArray();
          string[] strArray = datosDeConexion.Split(separator, 4);
          int num = 0;
          foreach (string str in strArray)
          {
            ++num;
            switch (num)
            {
              case 1:
                servidor = str;
                break;
              case 2:
                baseDeDatos = str;
                break;
              case 3:
                usuario = str;
                break;
              case 4:
                password = str;
                break;
            }
          }
        }
        DataAccessCls.AccessData.AccesoDeUsuario(servidor, baseDeDatos, usuario, password);
        if (DataAccessCls.AccessData.loginUsuario.ToUpper() == "SA" && !DataAccessCls.AccessData.CreaArquitectura())
          DataAccessCls.AccessData.DespliegaErrores("Se presentó un error en la creación de los objetos Access. Verifique con el administrador del sistema");
      }
      return DataAccessCls.AccessData;
    }

    private bool CreaArquitectura()
    {
      if (!this.usuarioValidado || this.loginUsuario.ToUpper() != "SA")
        return false;
      return this.ExistenDatosEnConsultaSQL("Select name from sysusers where name='Access' and status=0") || this.EjecutaComandoSQL("Execute Sp_AddRole 'Access'") && this.ADU_GrantAll();
    }

    public bool EjecutaComandoSQL(string comandoSQL)
    {
      return this.EjecutaComandoSQL(comandoSQL, this.tiempoDeEspera);
    }

    public bool EjecutaComandoSQL(string comandoSQL, int tiempoDeEspera_Segundos)
    {
      if (!this.AbreConexion())
        return false;
      try
      {
        SqlCommand sqlCommand = new SqlCommand(comandoSQL, this.conexionGlobal);
        if (this.transaccionAbierta)
          sqlCommand.Transaction = this.transaccionGlobal;
        sqlCommand.CommandTimeout = tiempoDeEspera_Segundos;
        try
        {
          sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          this.conexionGlobalAbierta = false;
          this.EjecutaComandoSQL(comandoSQL, tiempoDeEspera_Segundos);
        }
        if (!this.transaccionAbierta)
          this.CierraConexion();
        return true;
      }
      catch (SqlException ex)
      {
        if (ex.Number == 17 | ex.Number == 11)
          return false;
        this.currentSqlStatement = comandoSQL;
        this.DespliegaErrores(ex);
        return false;
      }
    }

    public DateTime FechaJuliana(int numeroJuliano)
    {
      DateTime dateTime = new DateTime(1900, 1, 1);
      dateTime.AddDays((double) (numeroJuliano - 2415021));
      return dateTime;
    }

    public long NumeroJuliano(DateTime fecha)
    {
      return DateAndTime.DateDiff(DateInterval.Day, new DateTime(1900, 1, 1), fecha, FirstDayOfWeek.Monday, FirstWeekOfYear.System) + 2415021L;
    }

    private SqlDataReader CreaDataReader(string consultaSql, CommandBehavior comportamiento)
    {
      try
      {
        this.UsuarioUsuarioSql_Impersonalizar();
        SqlConnection connection = new SqlConnection(this.StringDeConexion());
        connection.Open();
        SqlCommand sqlCommand = new SqlCommand(consultaSql, connection);
        sqlCommand.CommandTimeout = this.tiempoDeEspera;
        SqlDataReader sqlDataReader;
        try
        {
          sqlDataReader = sqlCommand.ExecuteReader(comportamiento);
        }
        catch (Exception ex)
        {
          this.conexionGlobalAbierta = false;
          if (connection.State == ConnectionState.Closed)
            connection.Open();
          sqlDataReader = sqlCommand.ExecuteReader(comportamiento);
        }
        this.UsuarioUsuarioSql_DesImpersonalizar();
        return sqlDataReader;
      }
      catch (SqlException ex)
      {
        if (ex.Number == 17 | ex.Number == 11)
          return (SqlDataReader) null;
        this.currentSqlStatement = consultaSql;
        this.DespliegaErrores(ex);
        return (SqlDataReader) null;
      }
    }

    public bool RegresaConsultaSQL(string consultaSQL, ref SqlDataReader miDataReader)
    {
      miDataReader = this.CreaDataReader(consultaSQL, CommandBehavior.CloseConnection);
      return miDataReader != null;
    }

    public bool RegresaConsultaSQL(string consultaSQL, ref DataSet miDataSet, string nombreDeTabla)
    {
      DataTable miDataTable = new DataTable(nombreDeTabla);
      this.RegresaConsultaSQL(consultaSQL, ref miDataTable);
      miDataSet.Tables.Add(miDataTable);
      return true;
    }

    private void CargaParametros(SqlCommand miComando, object[] args)
    {
      int count = miComando.Parameters.Count;
      for (int index = 1; index < count; ++index)
      {
        SqlParameter sqlParameter = miComando.Parameters[index];
        if (index <= args.Length)
          sqlParameter.Value = args[index - 1];
        else
          sqlParameter.Value = (object) null;
      }
    }

    public bool RegresaConsultaSQL(string procedimientoAlmacenado, ref DataSet miDataSet)
    {
      return this.RegresaConsultaSQL(procedimientoAlmacenado, ref miDataSet, new object[1]
      {
        (object) DBNull.Value
      });
    }

    public bool RegresaConsultaSQL(string procedimientoAlmacenado, ref DataSet miDataSet, params object[] args)
    {
      try
      {
        this.UsuarioUsuarioSql_Impersonalizar();
        SqlConnection connection;
        if (this.TieneTransaccionAbierta())
        {
          connection = new SqlConnection(this.StringDeConexion());
          connection.Open();
        }
        else
        {
          if (!this.AbreConexion())
            return false;
          connection = this.conexionGlobal;
        }
        SqlCommand sqlCommand = new SqlCommand(procedimientoAlmacenado, connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandTimeout = this.tiempoDeEspera;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        try
        {
          SqlCommandBuilder.DeriveParameters(sqlCommand);
        }
        catch (Exception ex)
        {
          if (connection.State == ConnectionState.Closed)
            connection.Open();
          SqlCommandBuilder.DeriveParameters(sqlCommand);
        }
        if (!this.AbreConexion())
          return false;
        sqlCommand.Connection = this.conexionGlobal;
        if (this.TieneTransaccionAbierta())
        {
          sqlCommand.Transaction = this.transaccionGlobal;
          if (connection.State == ConnectionState.Open)
            connection.Close();
          connection.Dispose();
        }
        this.CargaParametros(sqlCommand, args);
        try
        {
          ((DataAdapter) sqlDataAdapter).Fill(miDataSet);
        }
        catch (Exception ex)
        {
          this.conexionGlobalAbierta = false;
          ((DataAdapter) sqlDataAdapter).Fill(miDataSet);
        }
        this.UsuarioUsuarioSql_DesImpersonalizar();
        return true;
      }
      catch (SqlException ex)
      {
        this.currentSqlStatement = procedimientoAlmacenado;
        this.DespliegaErrores(ex);
        return false;
      }
    }

    public bool RegresaConsultaSQL(string consultaSQL, ref DataTable miDataTable)
    {
      try
      {
        miDataTable.Clear();
        this.UsuarioUsuarioSql_Impersonalizar();
        if (!this.AbreConexion())
          return false;
        SqlConnection connection = this.conexionGlobal;
        SqlCommand selectCommand = new SqlCommand(consultaSQL, connection);
        if (this.TieneTransaccionAbierta())
          selectCommand.Transaction = this.transaccionGlobal;
        consultaSQL = consultaSQL.ToUpper();
        consultaSQL = consultaSQL.Trim();
        selectCommand.CommandTimeout = this.tiempoDeEspera;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
        try
        {
          sqlDataAdapter.Fill(miDataTable);
        }
        catch (Exception ex)
        {
          this.conexionGlobalAbierta = false;
          sqlDataAdapter.Fill(miDataTable);
        }
        this.UsuarioUsuarioSql_DesImpersonalizar();
        return true;
      }
      catch (SqlException ex)
      {
        this.currentSqlStatement = consultaSQL;
        this.DespliegaErrores(ex);
        return false;
      }
    }

    public bool RegresaConsultaSQL(string consultaSQL, ListView miListView)
    {
      SqlDataReader sqlDataReader = this.CreaDataReader(consultaSQL, CommandBehavior.CloseConnection);
      if (sqlDataReader == null)
        return false;
      miListView.View = View.Details;
      miListView.Items.Clear();
      miListView.Columns.Clear();
      miListView.LabelEdit = false;
      miListView.GridLines = true;
      miListView.FullRowSelect = true;
      string text1 = "";
      string str = "";
      DataTable schemaTable = sqlDataReader.GetSchemaTable();
      foreach (DataRow dataRow in (InternalDataCollectionBase) schemaTable.Rows)
      {
        foreach (DataColumn index in (InternalDataCollectionBase) schemaTable.Columns)
        {
          switch (index.ColumnName)
          {
            case "ColumnName":
              text1 = dataRow[index].ToString();
              continue;
            case "ColumnSize":
              dataRow[index].ToString();
              continue;
            case "NumericPrecision":
              dataRow[index].ToString();
              continue;
            case "NumericScale":
              dataRow[index].ToString();
              continue;
            case "DataType":
              str = dataRow[index].ToString();
              continue;
            default:
              continue;
          }
        }
        switch (str)
        {
          case "System.Decimal":
            miListView.Columns.Add(text1, -2, HorizontalAlignment.Right);
            continue;
          case "System.DateTime":
            miListView.Columns.Add(text1, -2, HorizontalAlignment.Center);
            continue;
          default:
            miListView.Columns.Add(text1, -2, HorizontalAlignment.Left);
            continue;
        }
      }
      int index1 = 0;
      while (sqlDataReader.Read())
      {
        for (int ordinal = 0; ordinal < sqlDataReader.FieldCount; ++ordinal)
        {
          string text2;
          switch (sqlDataReader.GetDataTypeName(ordinal))
          {
            case "datetime":
            case "smalldatetime":
              text2 = sqlDataReader.IsDBNull(ordinal) ? "1900/01/01" : sqlDataReader.GetDateTime(ordinal).ToShortDateString();
              break;
            case "tinyint":
            case "bigint":
            case "int":
            case "smallint":
            case "money":
            case "bit":
            case "decimal":
              text2 = sqlDataReader.IsDBNull(ordinal) ? "0" : sqlDataReader.GetValue(ordinal).ToString();
              break;
            case "char":
            case "nvarchar":
            case "ntext":
            case "varchar":
              text2 = sqlDataReader.IsDBNull(ordinal) ? "" : sqlDataReader.GetString(ordinal);
              break;
            default:
              text2 = sqlDataReader.GetDataTypeName(ordinal) + " No Considerado****";
              break;
          }
          if (ordinal == 0)
            miListView.Items.Add(text2);
          else
            miListView.Items[index1].SubItems.Add(text2);
        }
        ++index1;
      }
      sqlDataReader.Close();
      for (int index2 = 0; index2 < miListView.Columns.Count; ++index2)
        miListView.Columns[index2].Width = -2;
      return true;
    }

    public bool RegresaConsultaSQL(string consultaSQL, CheckedListBox miCheckedListBox, string seleccionesActuales, string separador)
    {
      this.RegresaConsultaSQL(consultaSQL, (ListControl) miCheckedListBox);
      foreach (string str in seleccionesActuales.Split(separador.ToCharArray()))
      {
        for (int index = 0; index <= miCheckedListBox.Items.Count - 1; ++index)
        {
          miCheckedListBox.SetSelected(index, true);
          if (miCheckedListBox.SelectedValue.ToString() == str)
            miCheckedListBox.SetItemCheckState(index, CheckState.Checked);
        }
      }
      if (miCheckedListBox.Items.Count > 0)
        miCheckedListBox.SetSelected(0, true);
      return true;
    }

    public bool RegresaConsultaSQL(string consultaSQL, ListControl miListControl)
    {
      DataTable miDataTable = new DataTable();
      this.RegresaConsultaSQL(consultaSQL, ref miDataTable);
      try
      {
        miListControl.DataSource = (object) miDataTable;
        miListControl.DisplayMember = miDataTable.Columns[0].ColumnName;
        miListControl.ValueMember = miDataTable.Columns[miDataTable.Columns.Count - 1].ColumnName;
        return true;
      }
      catch (SqlException ex)
      {
        this.DespliegaErrores(ex);
        return false;
      }
      catch (Exception ex)
      {
        this.DespliegaErrores(ex.Message);
        return false;
      }
    }

    public bool RegresaConsultaSQL(string consultaSQL, ComboBox miComboBox, DataAccessCls.TipoElementoAdicionalDeLista elementoAdicional)
    {
      try
      {
        DataTable miDataTable = new DataTable();
        this.RegresaConsultaSQL(consultaSQL, ref miDataTable);
        DataTable dataTable1 = new DataTable();
        DataTable dataTable2 = miDataTable.Clone();
        DataRow row1 = dataTable2.NewRow();
        row1[0] = elementoAdicional != DataAccessCls.TipoElementoAdicionalDeLista.Todos ? (object) "<<SELECCIONE>>" : (object) "<<TODOS>>";
        row1[miDataTable.Columns.Count - 1] = (object) 0;
        dataTable2.Rows.Add(row1);
        foreach (DataRow dataRow in (InternalDataCollectionBase) miDataTable.Rows)
        {
          DataRow row2 = dataTable2.NewRow();
          row2[0] = dataRow[0];
          row2[dataTable2.Columns.Count - 1] = dataRow[miDataTable.Columns.Count - 1];
          dataTable2.Rows.Add(row2);
        }
        miComboBox.DataSource = (object) dataTable2;
        miComboBox.DisplayMember = dataTable2.Columns[0].ColumnName;
        miComboBox.ValueMember = dataTable2.Columns[miDataTable.Columns.Count - 1].ColumnName;
        return true;
      }
      catch (SqlException ex)
      {
        this.DespliegaErrores(ex);
        return false;
      }
      catch (Exception ex)
      {
        this.DespliegaErrores(ex.Message);
        return false;
      }
    }

    public bool RegresaEsquemaDeDatos(string consultaSQL, ref DataSet miDataSet, string nombreDeTabla)
    {
      DataTable miDataTable = new DataTable(nombreDeTabla);
      this.RegresaEsquemaDeDatos(consultaSQL, ref miDataTable);
      miDataSet.Tables.Add(miDataTable);
      return true;
    }

    public bool RegresaEsquemaDeDatos(string consultaSQL, ref DataTable miDataTable)
    {
      try
      {
        miDataTable.Clear();
        if (!this.conexionGlobalAbierta)
        {
          this.UsuarioUsuarioSql_Impersonalizar();
          SqlConnection connection = new SqlConnection(this.StringDeConexion());
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(consultaSQL, connection));
          connection.Open();
          try
          {
            sqlDataAdapter.FillSchema(miDataTable, SchemaType.Mapped);
          }
          catch (Exception ex)
          {
            this.conexionGlobalAbierta = false;
            sqlDataAdapter.FillSchema(miDataTable, SchemaType.Mapped);
          }
          connection.Close();
          this.UsuarioUsuarioSql_DesImpersonalizar();
        }
        else
        {
          SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(!this.transaccionAbierta ? new SqlCommand(consultaSQL, this.conexionGlobal) : new SqlCommand(consultaSQL, this.conexionGlobal, this.transaccionGlobal));
          try
          {
            sqlDataAdapter.FillSchema(miDataTable, SchemaType.Mapped);
          }
          catch (Exception ex)
          {
            this.conexionGlobalAbierta = false;
            sqlDataAdapter.FillSchema(miDataTable, SchemaType.Mapped);
          }
        }
        return true;
      }
      catch (SqlException ex)
      {
        this.DespliegaErrores(ex);
        return false;
      }
    }

    public bool EsConsultaValida(string consultaSQL)
    {
      try
      {
        this.UsuarioUsuarioSql_Impersonalizar();
        SqlConnection connection = new SqlConnection(this.StringDeConexion());
        SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
        connection.Open();
        try
        {
          sqlCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
          this.conexionGlobalAbierta = false;
          if (connection.State == ConnectionState.Closed)
            connection.Open();
          sqlCommand.ExecuteScalar();
        }
        connection.Close();
        this.UsuarioUsuarioSql_DesImpersonalizar();
        return true;
      }
      catch (SqlException ex)
      {
        return false;
      }
    }

    public object RegresaDatoSQL(string consultaSQL)
    {
      SqlDataReader sqlDataReader = this.CreaDataReader(consultaSQL, CommandBehavior.CloseConnection);
      try
      {
        if (sqlDataReader == null)
        {
          sqlDataReader.Close();
          return (object) null;
        }
        else if (sqlDataReader.Read())
        {
          object obj = sqlDataReader.GetValue(0);
          sqlDataReader.Close();
          return obj;
        }
        else
        {
          sqlDataReader.Close();
          return (object) null;
        }
      }
      catch (Exception ex)
      {
        this.DespliegaErrores(ex.Message);
        return (object) null;
      }
    }

    public string RegresaEleccionDeUsuarioSobreConsultaSQL(string consultaSQL)
    {
      FrmVisorDeListas frmVisorDeListas = new FrmVisorDeListas();
      this.RegresaConsultaSQL(consultaSQL, frmVisorDeListas.miListView);
      SendKeys.Send("{DOWN}");
      SendKeys.Send("{LEFT}");
      SendKeys.Send("{UP}");
      string str = frmVisorDeListas.ShowDialog() != DialogResult.OK ? "*" : frmVisorDeListas.eleccionDeUsuario;
      frmVisorDeListas.Dispose();
      return str;
    }

    public string RegresaEleccionDeUsuarioSobreConsultaSQL(string consultaSQL, bool requiereFiltroObligatoriamente, string columnaDefault, string nombresFisicosDeColumnas, string consultaSQLComplementaria, string camposRelacionados)
    {
      string str = "*";
      FrmVisorDeListasAvanzado deListasAvanzado = new FrmVisorDeListasAvanzado();
      deListasAvanzado.consultaSQL = consultaSQL;
      deListasAvanzado.requiereFiltroObligatoriamente = requiereFiltroObligatoriamente;
      deListasAvanzado.columnaDefault = columnaDefault;
      deListasAvanzado.nombresFisicoDeColumnas = nombresFisicosDeColumnas;
      deListasAvanzado.consultaSQLComplementaria = consultaSQLComplementaria;
      deListasAvanzado.camposRelacionados = camposRelacionados;
      if (deListasAvanzado.ShowDialog() == DialogResult.OK)
        str = deListasAvanzado.eleccionDeUsuario;
      return str;
    }

    public string RegresaEleccionDeUsuarioSobreDataTable(DataTable tablaDeDatos)
    {
      FrmVisorDeListas frmVisorDeListas = new FrmVisorDeListas();
      ListView listView = frmVisorDeListas.miListView;
      listView.View = View.Details;
      listView.Items.Clear();
      listView.Columns.Clear();
      listView.LabelEdit = false;
      listView.GridLines = true;
      listView.FullRowSelect = true;
      foreach (DataColumn dataColumn in (InternalDataCollectionBase) tablaDeDatos.Columns)
      {
        switch (dataColumn.DataType.ToString())
        {
          case "System.Decimal":
            listView.Columns.Add(dataColumn.Caption, -2, HorizontalAlignment.Right);
            continue;
          case "System.DateTime":
            listView.Columns.Add(dataColumn.Caption, -2, HorizontalAlignment.Center);
            continue;
          default:
            listView.Columns.Add(dataColumn.Caption, -2, HorizontalAlignment.Left);
            continue;
        }
      }
      int index1 = 0;
      foreach (DataRow dataRow in (InternalDataCollectionBase) tablaDeDatos.Rows)
      {
        for (int index2 = 0; index2 < tablaDeDatos.Columns.Count; ++index2)
        {
          string text;
          switch (tablaDeDatos.Columns[index2].DataType.ToString().ToLower())
          {
            case "system.datetime":
            case "system.date":
              text = dataRow[index2] == DBNull.Value ? "1900/01/01" : Convert.ToDateTime(dataRow[index2]).ToShortDateString();
              break;
            case "system.boolean":
            case "system.short":
            case "system.long":
            case "system.integer":
            case "system.int16":
            case "system.int32":
            case "system.int64":
            case "system.double":
            case "system.float":
            case "system.single":
            case "decimal":
              text = dataRow[index2] == DBNull.Value ? "0" : dataRow[index2].ToString();
              break;
            case "system.string":
              text = dataRow[index2] == DBNull.Value ? "" : dataRow[index2].ToString();
              break;
            default:
              text = dataRow[index2].ToString() + " No Considerado****";
              break;
          }
          if (index2 == 0)
            listView.Items.Add(text);
          else
            listView.Items[index1].SubItems.Add(text);
        }
        ++index1;
      }
      SendKeys.Send("{DOWN}");
      SendKeys.Send("{LEFT}");
      SendKeys.Send("{UP}");
      string str = frmVisorDeListas.ShowDialog() != DialogResult.OK ? "*" : frmVisorDeListas.eleccionDeUsuario;
      frmVisorDeListas.Dispose();
      return str;
    }

    public void MuestraEleccionesDeUsuario(string consultaSQL, string seleccionesActuales, string separador)
    {
      FrmSeleccionadorMultiple seleccionadorMultiple = new FrmSeleccionadorMultiple();
      this.RegresaConsultaSQL(consultaSQL, seleccionadorMultiple.ChkListBox, seleccionesActuales, separador);
      seleccionadorMultiple.separador = separador;
      seleccionadorMultiple.seleccionesActuales = seleccionesActuales;
      seleccionadorMultiple.ChkListBox.Enabled = false;
      if (seleccionadorMultiple.ShowDialog() == DialogResult.OK)
      {
        string str = seleccionadorMultiple.eleccionDeUsuario;
      }
      seleccionadorMultiple.Dispose();
    }

    public string RegresaEleccionesDeUsuario(string consultaSQL, string seleccionesActuales, string separador)
    {
      return this.RegresaEleccionesDeUsuario(consultaSQL, seleccionesActuales, separador, true);
    }

    public string RegresaEleccionesDeUsuario(string consultaSQL, string seleccionesActuales, string separador, bool regresaAsteriscoAnteEleccionCompleta)
    {
      return this.RegresaEleccionesDeUsuario(consultaSQL, seleccionesActuales, separador, regresaAsteriscoAnteEleccionCompleta, false, false, "", "", "", "");
    }

    public string RegresaEleccionesDeUsuario(string consultaSQL, string seleccionesActuales, string separador, bool regresaAsteriscoAnteEleccionCompleta, ref bool seAbortoSeleccion)
    {
      return this.RegresaEleccionesDeUsuario(consultaSQL, seleccionesActuales, separador, regresaAsteriscoAnteEleccionCompleta, false, false, "", "", "", "", ref seAbortoSeleccion);
    }

    public string RegresaEleccionesDeUsuario(string consultaSQL, string seleccionesActuales, string separador, bool regresaAsteriscoAnteEleccionCompleta, bool indicarAsteristoAlPrincipioEnSeleccionCompleta, string columnaDefault)
    {
      return this.RegresaEleccionesDeUsuario(consultaSQL, seleccionesActuales, separador, regresaAsteriscoAnteEleccionCompleta, indicarAsteristoAlPrincipioEnSeleccionCompleta, false, columnaDefault, "", "", "");
    }

    public string RegresaEleccionesDeUsuario(string consultaSQL, string seleccionesActuales, string separador, bool regresaAsteriscoAnteEleccionCompleta, bool indicarAsteristoAlPrincipioEnSeleccionCompleta, string columnaDefault, ref bool seAbortoSeleccion)
    {
      return this.RegresaEleccionesDeUsuario(consultaSQL, seleccionesActuales, separador, regresaAsteriscoAnteEleccionCompleta, indicarAsteristoAlPrincipioEnSeleccionCompleta, false, columnaDefault, "", "", "", ref seAbortoSeleccion);
    }

    public string RegresaEleccionesDeUsuario(string consultaSQL, string seleccionesActuales, string separador, bool regresaAsteriscoAnteEleccionCompleta, bool indicarAsteristoAlPrincipioEnSeleccionCompleta, bool requiereFiltroObligatoriamente, string columnaDefault, string nombresFisicosDeColumnas, string consultaSQLComplementaria, string camposRelacionados)
    {
      bool seAbortoSeleccion = false;
      return this.RegresaEleccionesDeUsuario(consultaSQL, seleccionesActuales, separador, regresaAsteriscoAnteEleccionCompleta, indicarAsteristoAlPrincipioEnSeleccionCompleta, requiereFiltroObligatoriamente, columnaDefault, nombresFisicosDeColumnas, consultaSQLComplementaria, camposRelacionados, ref seAbortoSeleccion);
    }

    public string RegresaEleccionesDeUsuario(string consultaSQL, string seleccionesActuales, string separador, bool regresaAsteriscoAnteEleccionCompleta, bool indicarAsteristoAlPrincipioEnSeleccionCompleta, bool requiereFiltroObligatoriamente, string columnaDefault, string nombresFisicosDeColumnas, string consultaSQLComplementaria, string camposRelacionados, ref bool seAbortoSeleccion)
    {
      FrmVisorDeListasAvanzado deListasAvanzado = new FrmVisorDeListasAvanzado();
      deListasAvanzado.consultaSQL = consultaSQL;
      deListasAvanzado.separador = separador;
      deListasAvanzado.seleccionesActuales = seleccionesActuales;
      deListasAvanzado.regresaAsteriscoAnteSeleccionCompleta = regresaAsteriscoAnteEleccionCompleta;
      deListasAvanzado.indicarAsteristoAlPrincipioEnSeleccionCompleta = indicarAsteristoAlPrincipioEnSeleccionCompleta;
      deListasAvanzado.requiereFiltroObligatoriamente = requiereFiltroObligatoriamente;
      deListasAvanzado.nombresFisicoDeColumnas = nombresFisicosDeColumnas;
      deListasAvanzado.consultaSQLComplementaria = consultaSQLComplementaria;
      deListasAvanzado.camposRelacionados = camposRelacionados;
      deListasAvanzado.columnaDefault = columnaDefault;
      deListasAvanzado.multiseleccionActivada = true;
      string str;
      if (deListasAvanzado.ShowDialog() == DialogResult.OK)
      {
        seAbortoSeleccion = deListasAvanzado.seAbortoSeleccion;
        str = deListasAvanzado.eleccionDeUsuario;
      }
      else
      {
        seAbortoSeleccion = deListasAvanzado.seAbortoSeleccion;
        str = seleccionesActuales;
      }
      deListasAvanzado.Dispose();
      return str;
    }

    public string RegresaEleccionesDeUsuario(ref CheckedListBox miChekedListBox, DataAccessCls.TipoDeValorDeUnListControl tipoDeResultado, string separador)
    {
      return this.RegresaEleccionesDeUsuario(ref miChekedListBox, tipoDeResultado, separador, true);
    }

    public string RegresaEleccionesDeUsuario(ref CheckedListBox miChekedListBox, DataAccessCls.TipoDeValorDeUnListControl tipoDeResultado, string separador, bool regresaAsteriscoAnteSeleccionCompleta)
    {
      string str1 = "";
      string str2 = "";
      if (miChekedListBox.CheckedItems.Count == 0)
        return "";
      if (miChekedListBox.CheckedItems.Count == miChekedListBox.Items.Count && regresaAsteriscoAnteSeleccionCompleta)
        return "*";
      foreach (int index in miChekedListBox.CheckedIndices)
      {
        miChekedListBox.SetSelected(index, true);
        str1 = tipoDeResultado != DataAccessCls.TipoDeValorDeUnListControl.ValueMember ? str1 + str2 + miChekedListBox.Text : str1 + str2 + miChekedListBox.SelectedValue.ToString();
        str2 = separador;
      }
      return str1;
    }

    public string RegresaEleccionesDeUsuario(ref ListView miListView, DataAccessCls.TipoDeValorDeUnListControl tipoDeResultado, string separador, bool regresaAsteriscoAnteSeleccionCompleta, int CantidadOpciones)
    {
      string str1 = "";
      string str2 = "";
      if (miListView.CheckedItems.Count == 0)
        return "";
      if (miListView.CheckedItems.Count == CantidadOpciones && regresaAsteriscoAnteSeleccionCompleta)
        return "*";
      for (int index = 0; index < miListView.Items.Count; ++index)
      {
        if (miListView.Items[index].Checked)
        {
          str1 = tipoDeResultado != DataAccessCls.TipoDeValorDeUnListControl.ValueMember ? (miListView.Items[index].SubItems.Count <= 1 ? str1 + str2 + miListView.Items[index].Text.Trim() : str1 + str2 + miListView.Items[index].SubItems[1].Text.Trim()) : str1 + str2 + miListView.Items[index].Text.Trim();
          str2 = separador;
        }
      }
      return str1;
    }

    public DateTime RegresaFechaDelSistema()
    {
      return (DateTime) this.RegresaDatoSQL("Select GetDate()");
    }

    public bool ExistenDatosEnConsultaSQL(string consultaSql)
    {
      try
      {
        SqlDataReader sqlDataReader = this.CreaDataReader(consultaSql, CommandBehavior.CloseConnection);
        if (sqlDataReader == null)
          return false;
        if (sqlDataReader.HasRows)
        {
          sqlDataReader.Close();
          return true;
        }
        else
        {
          sqlDataReader.Close();
          return false;
        }
      }
      catch (SqlException ex)
      {
        this.DespliegaErrores(ex);
        return false;
      }
    }

    internal void DespliegaErrores(string mensajeDeError)
    {
      this.UltimoMensajeEnviado = mensajeDeError;
      if (!this.EnviarMensajesAPantalla)
        return;
      int num = (int) MessageBox.Show(this.UltimoMensajeEnviado, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    private void DespliegaErrores(SqlException misErrores)
    {
      if (this.transaccionAbierta)
        this.DeshaceTransaccion();
      string str = "";
      for (int index = 0; index < misErrores.Errors.Count; ++index)
        str = str + (object) "Error: [" + misErrores.Errors[index].Number.ToString() + "] Proc:[" + misErrores.Errors[index].Procedure + "] Linea:[" + (string) (object) misErrores.Errors[index].LineNumber.ToString() + "] " + misErrores.Errors[index].Message;
      if (this.currentSqlStatement != "")
        str = str + "              " + this.currentSqlStatement;
      this.UltimoMensajeEnviado = str;
      if (this.EnviarMensajesAPantalla)
      {
        int num = (int) MessageBox.Show(this.UltimoMensajeEnviado, "Error De Sql...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      this.currentSqlStatement = "";
    }

    public bool TieneTransaccionAbierta()
    {
      return this.transaccionAbierta;
    }

    public string GetNombreServidor()
    {
      return this.nombreServidor;
    }

    public string GetRutaArchivoIni()
    {
      return this.miRutaDeArchivoIni;
    }

    public bool GetAgenteEspecialActivado()
    {
      return this.agenteEspecial_Activado;
    }

    public string GetNombreBaseDeDatos()
    {
      return this.nombreBaseDeDatos;
    }

    public string GetLoginUsuario()
    {
      return this.loginUsuario;
    }

    public string GetPassUsuario()
    {
      return this.passwordUsuario;
    }

    private string GetPasswordUsuario()
    {
      return this.passwordUsuario;
    }

    public string GetNombreDeEmpresa()
    {
      return this.RegresaDatoSQL("Select cNombreDeEmpresa from DATOSEMPRESA").ToString();
    }

    public bool AgenteEspecial_Activar()
    {
      this.agenteEspecial_Activado = true;
      return true;
    }

    public bool AgenteEspecial_Desactivar()
    {
      this.agenteEspecial_Activado = false;
      return true;
    }
    public void SetNombreBaseDeDatos(String baseDatos)
    {
        this.nombreBaseDeDatos = baseDatos;
        this.conexionGlobalAbierta = false;
        AbreConexion();
    }
    private string StringDeConexion()
    {
      string str;
      if (this.loginUsuario.ToUpper() == "SA")
        str = "Integrated Security=false; Database=" + this.nombreBaseDeDatos + " ;server=" + this.nombreServidor + ";User ID=" + this.loginUsuario + "; Pwd=" + this.passwordUsuario + " ; Connect Timeout=0";
      else
        str = "Integrated Security=false; Database=" + this.nombreBaseDeDatos + " ;server=" + this.nombreServidor + ";User ID=" + this.loginUsuario + "; Pwd=" + this.passwordUsuario + " ; Connect Timeout=0";
      return str;
    }

    private string StringDeConexion(string nombreBaseDeDatos, string nombreServidor, string loginUsuario, string passwordUsuario)
    {
      this.passwordEncriptado = passwordUsuario;
      if (loginUsuario.ToUpper() != "SA")
        this.passwordEncriptado = passwordUsuario;
      return "Integrated Security=false; Database=" + nombreBaseDeDatos + " ;server=" + nombreServidor + ";User ID=" + loginUsuario + "; Pwd=" + this.passwordEncriptado + " ;";
    }

    public string DatosDeConexion()
    {
      String cadena = this.nombreServidor + ":" + this.nombreBaseDeDatos + ":" + this.loginUsuario + ":" + this.passwordUsuario;
      return cadena;
    }

    public bool AbreConexion()
    {
      try
      {
        if (this.conexionGlobalAbierta)
          return true;
        this.UsuarioUsuarioSql_Impersonalizar();
        this.conexionGlobal = new SqlConnection(this.StringDeConexion());
        this.conexionGlobal.Open();
        SqlCommand sqlCommand = new SqlCommand("Set DateFormat ymd", this.conexionGlobal);
        sqlCommand.CommandTimeout = 0;
        try
        {
          sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          this.conexionGlobalAbierta = false;
          if (this.conexionGlobal.State == ConnectionState.Closed)
            this.conexionGlobal.Open();
          sqlCommand.ExecuteNonQuery();
        }
        this.conexionGlobalAbierta = true;
        return true;
      }
      catch (SqlException ex)
      {
        this.DespliegaErrores(ex);
        return false;
      }
    }

    private bool CierraConexion()
    {
      if (!this.conexionGlobalAbierta)
        return true;
      this.conexionGlobal.Close();
      this.conexionGlobalAbierta = false;
      this.AgenteEspecial_Desactivar();
      this.UsuarioUsuarioSql_DesImpersonalizar();
      return true;
    }

    public bool GetConexionUtilizandoActiveDirectory()
    {
      return this.UsuarioSql_Activado;
    }

    public bool ValidaUsuarioYPassword(string usuario, string password)
    {
      try
      {
        SqlConnection sqlConnection = new SqlConnection(this.StringDeConexion(this.nombreBaseDeDatos, this.nombreServidor, usuario, password));
        sqlConnection.Open();
        sqlConnection.Close();
        sqlConnection.Dispose();
        return true;
      }
      catch (SqlException ex)
      {
        if (ex.Number == 17 | ex.Number == 11)
        {
          this.DespliegaErrores("Servidor No Disponible...");
          Application.Exit();
          return false;
        }
        else
        {
          if (ex.Number == 18456)
            this.DespliegaErrores("Password Incorrecto..");
          else
            this.DespliegaErrores(ex);
          return false;
        }
      }
    }

    private string ObtenDominio()
    {
      ArrayList arrayList = new ArrayList((ICollection) ((object) WindowsIdentity.GetCurrent().Name).ToString().Split(new char[1]
      {
        '\\'
      }));
      string str = "";
      for (int index = 0; index <= arrayList.Count - 2; ++index)
        str = index != 0 ? str + (object) "\\" + (string) arrayList[index] : str + arrayList[index];
      return str;
    }

    public bool ServidorAlterno_Activar()
    {
      this.servidorAlterno_Activado = true;
      this.DeterminaRutaDeArchivoIni();
      this.archivoIni.OpenINIFile(this.miRutaDeArchivoIni);
      this.archivoIni.SetEntry("SERVIDORALTERNO_ACTIVADO", "1");
      this.archivoIni.CloseINIFile();
      int num = (int) MessageBox.Show("Se ha perdido la conexión con el servidor central. En este momento se saldrá del sistema y la próxima vez que entre, Se conectará al servidor alterno", "Aviso Importante...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      Application.Exit();
      return true;
    }

    public bool ServidorAlterno_Desactivar()
    {
      this.servidorAlterno_Activado = false;
      this.DeterminaRutaDeArchivoIni();
      this.archivoIni.OpenINIFile(this.miRutaDeArchivoIni);
      this.archivoIni.SetEntry("SERVIDORALTERNO_ACTIVADO", "0");
      this.archivoIni.CloseINIFile();
      Application.Exit();
      return true;
    }

    public bool AccesoDeUsuarioActual()
    {
      FrmAccesoDeUsuario frmAccesoDeUsuario = new FrmAccesoDeUsuario();
      frmAccesoDeUsuario.miPassWord = "";
      frmAccesoDeUsuario.miUsuarioLogin = this.GetLoginUsuario();
      frmAccesoDeUsuario.miNombreServidor = this.GetNombreServidor();
      frmAccesoDeUsuario.miNombreBaseDeDatos = this.GetNombreBaseDeDatos();
      frmAccesoDeUsuario.miFuncionalidadTouchScreenActivada = this.funcionalidadTouchScreenActivada;
      frmAccesoDeUsuario.miRutaArchivoIni = this.miRutaDeArchivoIni;
      frmAccesoDeUsuario.miSevidorAlternoActivado = this.servidorAlterno_Activado;
      frmAccesoDeUsuario.miMostrarUltimoUsuario = false;
      frmAccesoDeUsuario.mostrarSoloUsuarioProporcionado = true;
      bool flag = frmAccesoDeUsuario.ShowDialog() == DialogResult.OK;
      frmAccesoDeUsuario.Dispose();
      return flag;
    }

    public bool AccesoDeUsuario()
    {
      string str1 = "C:\\CROP\\ASADM.Ini";
      this.UsuarioSql_RutaDeArchivoIni = "C:\\CROP\\ASADM.Ini";
      bool flag1 = false;
      bool flag2 = true;
      this.archivoIni = new IniFileController();
      IniFileController iniFileController = new IniFileController();
      string str2 = Application.StartupPath + "\\ASADM.Ini";
      if (!File.Exists(str2))
      {
        iniFileController.CreateINIFile(str2);
        this.UsuarioSql_RutaDeArchivoIni = "C:\\CROP\\ASADM.Ini";
      }
      iniFileController.CloseINIFile();
      this.miRutaDeArchivoIni = str1;
      if (!File.Exists(str1))
        this.archivoIni.CreateINIFile(str1);
      this.archivoIni.OpenINIFile(str1);
      this.archivoIni.AddEntry("SERVIDOREMPRESAS", "");
      this.archivoIni.AddEntry("BaseDatos", "");
      this.archivoIni.AddEntry("UltimoLogin", "");
      this.nombreServidor = this.archivoIni.GetEntry("SERVIDOREMPRESAS");
      this.nombreBaseDeDatos = this.archivoIni.GetEntry("BaseDatos");
      this.loginUsuario = this.archivoIni.GetEntry("UltimoLogin");
      this.passwordUsuario = "";
      FrmAccesoDeUsuario frmAccesoDeUsuario = new FrmAccesoDeUsuario();
      frmAccesoDeUsuario.miPassWord = this.passwordUsuario;
      frmAccesoDeUsuario.miUsuarioLogin = this.loginUsuario;
      frmAccesoDeUsuario.miNombreServidor = this.nombreServidor;
      frmAccesoDeUsuario.miNombreBaseDeDatos = this.nombreBaseDeDatos;
      frmAccesoDeUsuario.miFuncionalidadTouchScreenActivada = this.funcionalidadTouchScreenActivada;
      frmAccesoDeUsuario.miRutaArchivoIni = this.miRutaDeArchivoIni;
      frmAccesoDeUsuario.miSevidorAlternoActivado = this.servidorAlterno_Activado;
      frmAccesoDeUsuario.miMostrarUsuarioEncriptado = flag1;
      frmAccesoDeUsuario.miMostrarUltimoUsuario = flag2;
      if (frmAccesoDeUsuario.ShowDialog() == DialogResult.OK)
      {
        this.loginUsuario = frmAccesoDeUsuario.TxtUsuario.Text.Trim();
        this.passwordUsuario = frmAccesoDeUsuario.TxtPassWord.Text.Trim();
        this.servidorAlterno_Activado = frmAccesoDeUsuario.miSevidorAlternoActivado;
        if (this.servidorAlterno_Activado)
          this.ServidorAlterno_Activar();
        this.archivoIni.SetEntry("UltimoLogin", this.loginUsuario);
        this.archivoIni.CloseINIFile();
        this.usuarioValidado = true;
      }
      else
        this.usuarioValidado = false;
      frmAccesoDeUsuario.Dispose();
      return this.usuarioValidado;
    }

    public bool AccesoDeUsuario(string servidor, string baseDeDatos, string usuario, string password)
    {
      string str1 = "C:\\CROP\\ASADM.Ini";
      this.UsuarioSql_RutaDeArchivoIni = "C:\\CROP\\ASADM.Ini";
      this.archivoIni = new IniFileController();
      IniFileController iniFileController = new IniFileController();
      string str2 = "C:\\CROP\\ASADM.Ini";
      if (!File.Exists(str2))
      {
        iniFileController.CreateINIFile(str2);
        this.archivoIni.AddEntry("SERVIDOREMPRESAS", "");
        this.archivoIni.AddEntry("BaseDatos", "");
        this.archivoIni.AddEntry("UltimoLogin", "");
        this.UsuarioSql_RutaDeArchivoIni = "C:\\CROP\\ASADM.Ini";
      }
      else
      {
        iniFileController.OpenINIFile(str2);
        this.UsuarioSql_RutaDeArchivoIni = "C:\\CROP\\ASADM.Ini";
      }
      iniFileController.CloseINIFile();
      this.miRutaDeArchivoIni = str1;
      if (!File.Exists(str1))
        this.archivoIni.CreateINIFile(str1);
      else
        this.archivoIni.OpenINIFile(str1);
      this.archivoIni.AddEntry("SERVIDOREMPRESAS", "");
      this.archivoIni.AddEntry("BaseDatos", "");
      this.archivoIni.AddEntry("UltimoLogin", "");
      this.nombreServidor = servidor;
      this.nombreBaseDeDatos = baseDeDatos;
      this.loginUsuario = usuario;
      this.passwordUsuario = password;
      this.usuarioValidado = this.ValidaUsuarioYPassword(usuario, this.passwordUsuario);
      return this.usuarioValidado;
    }

    private bool DeterminaRutaDeArchivoIni()
    {
      string newValue = "C:\\Access\\ASADM.Ini";
      this.archivoIni = new IniFileController();
      IniFileController iniFileController = new IniFileController();
      string str = Application.StartupPath + "\\ASADM.Ini";
      if (!File.Exists(str))
      {
        iniFileController.CreateINIFile(str);
        iniFileController.AddEntry("RUTA_INI", newValue);
      }
      else
      {
        iniFileController.OpenINIFile(str);
        newValue = iniFileController.GetEntry("RUTA_INI");
      }
      iniFileController.CloseINIFile();
      this.miRutaDeArchivoIni = newValue;
      return true;
    }

    private bool UsuarioUsuarioSql_Impersonalizar()
    {
      return true;
    }

    private bool UsuarioUsuarioSql_DesImpersonalizar()
    {
      return true;
    }

    public bool AbreTransaccion()
    {
      if (!this.transaccionAbierta)
      {
        if (!this.AbreConexion())
          return false;
        try
        {
          this.transaccionGlobal = this.conexionGlobal.BeginTransaction();
          this.transaccionAbierta = true;
          return true;
        }
        catch (SqlException ex)
        {
          this.DespliegaErrores(ex);
          return false;
        }
      }
      else
      {
        this.DespliegaErrores("No Se Puede Abrir Mas De Una Transacción..");
        return false;
      }
    }

    public bool CierraTransaccion()
    {
      if (!this.transaccionAbierta)
      {
        this.DespliegaErrores("No Existe Una Transacción Abierta Que Se Pueda Cerrar..");
        return false;
      }
      else
      {
        this.transaccionGlobal.Commit();
        this.transaccionAbierta = false;
        this.CierraConexion();
        return true;
      }
    }

    public bool DeshaceTransaccion()
    {
      if (!this.transaccionAbierta)
      {
        this.DespliegaErrores("No Existe Una Transacción Abierta Que Se Pueda Deshacer..");
        return false;
      }
      else
      {
        try
        {
          ((DbTransaction) this.transaccionGlobal).Rollback();
          this.CierraConexion();
          this.transaccionAbierta = false;
          return true;
        }
        catch (InvalidOperationException ex)
        {
          this.transaccionAbierta = false;
          this.conexionGlobalAbierta = false;
          return true;
        }
      }
    }

    public Decimal FolioAdministradoSiguiente(string folioId)
    {
      if (!this.transaccionAbierta)
      {
        int num = (int) MessageBox.Show("Este Método Requiere Ser Ejecutado Dentro De Una Transacción..", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return new Decimal(0);
      }
      else
      {
        Decimal num1 = new Decimal(0);
        Decimal d = this.FolioAdministradoActual(folioId);
        if (d == new Decimal(-1))
        {
          this.DespliegaErrores("La transacción se ha deshecho..");
          return new Decimal(0);
        }
        else
        {
          Decimal num2 = d++;
          this.EjecutaComandoSQL("Update FoliosAdministrados Set nConsecutivo=" + num2.ToString() + " Where cFolioAdministrado='" + folioId + "'");
          return num2;
        }
      }
    }

    public bool FolioAdministradoAgregar(string folioId, string descripcion)
    {
      if (this.ExistenDatosEnConsultaSQL("Select * from FoliosAdministrados(NoLock) Where cFolioAdministrado='" + folioId + "'"))
        return true;
      return this.EjecutaComandoSQL("Insert FoliosAdministrados (cFolioAdministrado, nConsecutivo,cDescripcion, bAlterablePorAdministrador )" + " Values ('" + folioId + "',0,'" + descripcion + "',0)");
    }

    public Decimal FolioAdministradoActual(string folioId)
    {
      Decimal num = new Decimal(0);
      if (!this.ExistenDatosEnConsultaSQL("Select * from FoliosAdministrados(NoLock) Where cFolioAdministrado='" + folioId + "'"))
      {
        if (this.transaccionAbierta)
          this.DeshaceTransaccion();
        this.DespliegaErrores("No Existe Este Folio Administrado [" + folioId + "]..");
        this.FolioAdministradoAgregar(folioId, "XXXXX");
        return new Decimal(-1);
      }
      else
      {
        SqlDataReader sqlDataReader = this.CreaDataReader("Select nConsecutivo From FoliosAdministrados(NoLock) Where cFolioAdministrado='" + folioId + "'", CommandBehavior.CloseConnection);
        if (sqlDataReader == null)
          return new Decimal(0);
        sqlDataReader.Read();
        Decimal @decimal = sqlDataReader.GetDecimal(0);
        sqlDataReader.Close();
        return @decimal;
      }
    }

    public virtual void FolioAdministradoInterfaseDeModificacion(string folioId)
    {
    }

    private void FolioAdministradoModificar(string folioId, long consecutivoNuevo)
    {
    }

    public bool OperacionSupervisadaTemporalUtilizar(string supervisor, string password, string opcionDondeSeUtiliza, string observacion)
    {
      int num = -1;
      string consultaSQL = string.Format("SELECT nPasswordTemporal ,cPassword FROM OperacionesSupervisadas_Temporales(NOLOCK) WHERE bAplicado = 0 AND cUsuario_Registro = '{0}'", (object) supervisor);
      DataTable miDataTable = new DataTable();
      if (!this.RegresaConsultaSQL(consultaSQL, ref miDataTable))
        return false;
      foreach (DataRow dataRow in (InternalDataCollectionBase) miDataTable.Rows)
      {
        string strB = dataRow["cPassword"].ToString();
        if (password.CompareTo(strB) == 0)
        {
          num = int.Parse(dataRow["nPasswordTemporal"].ToString());
          break;
        }
      }
      if (num == -1)
      {
        this.DespliegaErrores("Password temporal incorrecto");
        return false;
      }
      else
        return this.EjecutaComandoSQL(string.Format("UPDATE OperacionesSupervisadas_Temporales SET bAplicado = 1 ,cOpcionAplicacion = LEFT('{1}' ,100) ,cObservacion = LEFT('{2}' ,1000) ,cUsuario_Aplicacion = LEFT('{3}' ,50) ,dFecha_Aplicacion = GETDATE() ,cMaquina_Aplicacion = HOST_NAME() WHERE nPasswordTemporal = {0}", (object) num, (object) opcionDondeSeUtiliza, (object) observacion, (object) this.GetLoginUsuario()));
    }

    public void OperacionSupervisadaTemporalAgregar()
    {
      FrmAgregarOperacionSupervisadaTemporal supervisadaTemporal = new FrmAgregarOperacionSupervisadaTemporal();
      int num = (int) supervisadaTemporal.ShowDialog();
      supervisadaTemporal.Dispose();
    }

    public bool OperacionSupervisadaAgregar(string operacionSupervisada, string descripcion)
    {
      return this.OperacionSupervisadaAgregar(operacionSupervisada, descripcion, false);
    }

    public bool OperacionSupervisadaAgregar(string operacionSupervisada, string descripcion, bool autorizacionRequeridaSiempre)
    {
      if (this.ExistenDatosEnConsultaSQL("Select * from OperacionesSupervisadas(NoLock) Where cOperacionSupervisada='" + operacionSupervisada + "'"))
        return true;
      string str = "Insert OperacionesSupervisadas  (cOperacionSupervisada, cDescripcion, bAutorizacionRequeridaSiempre, bOperacionSupervisadaActiva )";
      string comandoSQL;
      if (autorizacionRequeridaSiempre)
        comandoSQL = str + " Values ('" + operacionSupervisada + "','" + descripcion + "',1,1)";
      else
        comandoSQL = str + " Values ('" + operacionSupervisada + "','" + descripcion + "',0,1)";
      return this.EjecutaComandoSQL(comandoSQL);
    }

    public virtual bool OperacionSupervisadaAprobacion(string operacionSupervisada, string observacion, ref string supervisor)
    {
      if (this.transaccionAbierta)
      {
        int num = (int) MessageBox.Show("Este Método No Puede Ser Ejecutado Dentro De Una Transacción..", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
      else if (!this.ExistenDatosEnConsultaSQL("Select * from OperacionesSupervisadas(NoLock) Where cOperacionSupervisada='" + operacionSupervisada + "'"))
      {
        this.DespliegaErrores("No Existe Esta Operación Supervisada [" + operacionSupervisada + "]..");
        this.OperacionSupervisadaAgregar(operacionSupervisada, "XXXXX");
        return false;
      }
      else
      {
        if (this.ExistenDatosEnConsultaSQL("select 1 from operacionessupervisadas as OS(NoLock)" + " Join OperacionesSupervisadas_Supervisores as OSS(NoLock)" + " On (OS.cOperacionSupervisada=OSS.cOperacionSupervisada)" + "\tWhere OS.cOperacionSupervisada='" + operacionSupervisada + "'" + " And OS.bAutorizacionRequeridaSiempre=0 And OSS.cSupervisor='" + this.loginUsuario + "'"))
          return true;
        FrmAutorizacionLocalDeOperacionSupervisada operacionSupervisada1 = new FrmAutorizacionLocalDeOperacionSupervisada();
        operacionSupervisada1.operacionSupervisada = operacionSupervisada;
        operacionSupervisada1.observacion = observacion;
        bool flag;
        if (operacionSupervisada1.ShowDialog() == DialogResult.OK)
        {
          supervisor = !this.GetConexionUtilizandoActiveDirectory() ? operacionSupervisada1.CboSupervisor.SelectedValue.ToString() : operacionSupervisada1.CboSupervisor.Text;
          flag = true;
        }
        else
        {
          supervisor = "";
          flag = false;
        }
        operacionSupervisada1.Dispose();
        return flag;
      }
    }

    public virtual bool OperacionSupervisadaAprobacion(string operacionSupervisada, string observacion)
    {
      string supervisor = "";
      return this.OperacionSupervisadaAprobacion(operacionSupervisada, observacion, ref supervisor);
    }

    public virtual bool OperacionSupervisadaCorporativaSolicitaAprobacion(string operacionSupervisada, string observacion, DataSet datos)
    {
      return true;
    }

    public long OperacionSupervisadaSolicitaAprobacionRemota(string operacionSupervisada, string supervisor, string observacion)
    {
      long num = 0L;
      if (this.EjecutaComandoSQL("Insert OperacionesSupervisadas_Remotas (cOperacionSupervisada, Solicitud_cObservacion, Autorizacion_cLogin, Solicitud_cLogin)" + "values ('" + operacionSupervisada + "','" + observacion + "','" + supervisor + "','" + this.GetLoginUsuario() + "')"))
        num = (long) this.RegresaDatoSQL("Select Max(nOperacionSupervisadaRemota) From OperacionesSupervisadas_Remotas");
      return num;
    }

    public bool OperacionSupervisadaCancelaSolicitudRemota(long operacionSupervisadaRemota)
    {
      string consultaSql = "Select 1 from OperacionesSupervisadas_Remotas Where nOperacionSupervisadaRemota=" + operacionSupervisadaRemota.ToString();
      if (!this.ExistenDatosEnConsultaSQL(consultaSql))
      {
        this.DespliegaErrores("Este Folio de Solicitud Remota No Existe!");
        return false;
      }
      else
      {
        if (this.ExistenDatosEnConsultaSQL(!(this.loginUsuario.ToUpper() == "SA") ? consultaSql + " And Solicitud_cLogin='" + this.loginUsuario + "'" : consultaSql + " And Solicitud_cLogin='dbo'"))
          return this.EjecutaComandoSQL("Update OperacionesSupervisadas_Remotas Set bOperacionSupervisadaRemotaActiva=0 Where nOperacionSupervisadaRemota=" + operacionSupervisadaRemota.ToString());
        this.DespliegaErrores("Operación Invalida: Este Folio de Solicitud Remota Pertenece A Otro Usuario!");
        return false;
      }
    }

    public virtual void OperacionSupervisadaAprobacionRemota()
    {
      int num = (int) new FrmAutorizacionRemotaDeOperacionSupervisada().ShowDialog();
    }

    public bool ParametroAdministradoAgregar(string contexto, string parametro, DataAccessCls.TipoDeParametroAdministrado tipo, string descripcion, object valorPredeterminado)
    {
      if (this.ExistenDatosEnConsultaSQL("Select * from ParametrosAdministrados(NoLock) Where cParametroAdministrado='" + parametro + "'"))
        return true;
      string comandoSQL = "Insert ParametrosAdministrados  (cContexto, cParametroAdministrado, nTipo, cDescripcion, cValor )" + (object) " Values ('" + contexto + "','" + parametro + "'," + (string) (object) tipo + ",'" + descripcion + "',";
      switch (tipo)
      {
        case DataAccessCls.TipoDeParametroAdministrado.Caracter:
          comandoSQL = string.Concat(new object[4]
          {
            (object) comandoSQL,
            (object) "'",
            valorPredeterminado,
            (object) "')"
          });
          break;
        case DataAccessCls.TipoDeParametroAdministrado.Numero:
          comandoSQL = comandoSQL + valorPredeterminado + ")";
          break;
      }
      return this.EjecutaComandoSQL(comandoSQL);
    }

    public string ParametroAdministradoObtener(string contexto, string parametro)
    {
      string str = "Select cValor From ParametrosAdministrados(NoLock) Where cContexto='" + contexto + "' And cParametroAdministrado='" + parametro + "'";
      if (this.ExistenDatosEnConsultaSQL(str))
        return this.RegresaDatoSQL(str).ToString();
      string mensajeDeError = "No Esta Registrado Este Parametro [" + contexto + " " + parametro + "], Verifique";
      this.ParametroAdministradoAgregar(contexto, parametro, DataAccessCls.TipoDeParametroAdministrado.Caracter, "XXXXX", (object) ".");
      this.DespliegaErrores(mensajeDeError);
      return "";
    }

    private bool ParametroAdministradoConfigurar(string contexto, string parametro, object valor)
    {
      if (!this.ExistenDatosEnConsultaSQL("Select cValor From ParametrosAdministrados(NoLock) Where cContexto='" + contexto + "' And cParametroAdministrado='" + parametro + "'"))
      {
        string mensajeDeError = "No Esta Registrado Este Parametro [" + contexto + " " + parametro + "], Verifique";
        this.ParametroAdministradoAgregar(contexto, parametro, DataAccessCls.TipoDeParametroAdministrado.Caracter, "XXXXX", (object) ".");
        this.DespliegaErrores(mensajeDeError);
        return false;
      }
      else
        return this.EjecutaComandoSQL("Update ParametrosAdministrados Set cValor='" + valor.ToString() + "' Where cContexto='" + contexto + "' And cParametroAdministrado='" + parametro + "'");
    }

    public bool LlenaTablaDeDatos(string consultaSQL, ref SqlDataAdapter miDataAdapter, ref DataTable miDataTable)
    {
      if (!this.conexionGlobalAbierta)
      {
        this.DespliegaErrores("Este Método Requiere De Una Conexión Abierta. Ejecutar Método DAO.AbreConexion...");
        return false;
      }
      else
      {
        miDataAdapter = this.CreaDataAdapter(consultaSQL);
        try
        {
          try
          {
            miDataAdapter.Fill(miDataTable);
          }
          catch (Exception ex)
          {
            this.conexionGlobalAbierta = false;
            miDataAdapter.Fill(miDataTable);
          }
          return true;
        }
        catch (SqlException ex)
        {
          this.DespliegaErrores(ex);
          return false;
        }
      }
    }

    public bool InsertaDatosDeTablaSql(ref SqlDataAdapter miDataAdapter, ref DataTable miDataTable)
    {
      try
      {
        DataTable changes = miDataTable.GetChanges(DataRowState.Added);
        if (changes == null || changes.Rows.Count != miDataTable.Rows.Count)
        {
          this.DespliegaErrores("Existen Renglones No Agregados, utiliza el método DAO.ActualizaDatosDeTabla, ó DAO.EliminaDatosDeTabla");
          return false;
        }
        else
        {
          SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(miDataAdapter);
          miDataAdapter.UpdateCommand = (SqlCommand) null;
          miDataAdapter.DeleteCommand = (SqlCommand) null;
          miDataAdapter.InsertCommand = sqlCommandBuilder.GetInsertCommand();
          if (this.transaccionAbierta)
            miDataAdapter.InsertCommand.Transaction = this.transaccionGlobal;
          try
          {
            miDataAdapter.Update(miDataTable);
          }
          catch (Exception ex)
          {
            this.conexionGlobalAbierta = false;
            miDataAdapter.Update(miDataTable);
          }
          return true;
        }
      }
      catch (SqlException ex)
      {
        this.DespliegaErrores(ex);
        return false;
      }
    }

    public bool ActualizaDatosDeTablaSql(ref SqlDataAdapter miDataAdapter, ref DataTable miDataTable)
    {
      try
      {
        DataTable changes = miDataTable.GetChanges(DataRowState.Modified);
        if (changes == null || changes.Rows.Count != miDataTable.Rows.Count)
        {
          this.DespliegaErrores("Existen Renglones Agregados ó Eliminados, utiliza el método DAO.InsertaDatosDeTabla, ó DAO.EliminaDatosDeTabla");
          return false;
        }
        else
        {
          SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(miDataAdapter);
          miDataAdapter.DeleteCommand = (SqlCommand) null;
          miDataAdapter.InsertCommand = (SqlCommand) null;
          miDataAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();
          if (this.transaccionAbierta)
            miDataAdapter.UpdateCommand.Transaction = this.transaccionGlobal;
          try
          {
            miDataAdapter.Update(miDataTable);
          }
          catch (Exception ex)
          {
            this.conexionGlobalAbierta = false;
            miDataAdapter.Update(miDataTable);
          }
          return true;
        }
      }
      catch (SqlException ex)
      {
        this.DespliegaErrores(ex);
        return false;
      }
    }

    public bool EliminaDatosDeTablaSql(ref SqlDataAdapter miDataAdapter, ref DataTable miDataTable)
    {
      try
      {
        DataTable changes = miDataTable.GetChanges(DataRowState.Deleted);
        if (changes == null || changes.Rows.Count != miDataTable.Rows.Count)
        {
          this.DespliegaErrores("Existen Renglones No Agregados ó Actualizados, utiliza el método DAO.ActualizaDatosDeTabla, ó DAO.InsertaDatosDeTabla");
          return false;
        }
        else
        {
          SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(miDataAdapter);
          miDataAdapter.UpdateCommand = (SqlCommand) null;
          miDataAdapter.InsertCommand = (SqlCommand) null;
          miDataAdapter.DeleteCommand = sqlCommandBuilder.GetDeleteCommand();
          if (this.transaccionAbierta)
            miDataAdapter.DeleteCommand.Transaction = this.transaccionGlobal;
          try
          {
            miDataAdapter.Update(miDataTable);
          }
          catch (Exception ex)
          {
            this.conexionGlobalAbierta = false;
            miDataAdapter.Update(miDataTable);
          }
          return true;
        }
      }
      catch (SqlException ex)
      {
        this.DespliegaErrores(ex);
        return false;
      }
    }

    private SqlDataAdapter CreaDataAdapter(string consultaSQL)
    {
      if (consultaSQL.IndexOf("*") > 0)
      {
        this.DespliegaErrores("Se requiere la declaración explicita de todos los campos que formarán la tabla (no usar SELECT * FROM)");
        return (SqlDataAdapter) null;
      }
      else
      {
        if (!this.AbreConexion())
          return (SqlDataAdapter) null;
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaSQL, this.conexionGlobal);
        if (this.transaccionAbierta)
          sqlDataAdapter.SelectCommand.Transaction = this.transaccionGlobal;
        return sqlDataAdapter;
      }
    }

    private bool ReporteCrystal_ConfiguraConexion(ref ReportDocument reporteCrystal, DataSet miDataSet)
    {
      if (reporteCrystal.DataSourceConnections.Count > 0)
        reporteCrystal.SetDataSource(miDataSet);
      for (int index = 0; index <= reporteCrystal.Subreports.Count - 1; ++index)
      {
        ReportDocument reportDocument = reporteCrystal.Subreports[index];
        if (reportDocument.DataSourceConnections.Count > 0)
          reportDocument.SetDataSource(miDataSet);
      }
      return true;
    }

    private bool ReporteCrystal_ConfiguraConexion(ref ReportDocument reporteCrystal)
    {
      TableLogOnInfos tableLogOnInfos = new TableLogOnInfos();
      TableLogOnInfo logonInfo = new TableLogOnInfo();
      ConnectionInfo connectionInfo = new ConnectionInfo();
      logonInfo.ConnectionInfo.ServerName = this.GetNombreServidor();
      logonInfo.ConnectionInfo.DatabaseName = this.GetNombreBaseDeDatos();
      logonInfo.ConnectionInfo.UserID = this.UsuarioSql_Login;
      logonInfo.ConnectionInfo.Password = this.UsuarioSql_PassWord;
      for (int index = 0; index < reporteCrystal.DataSourceConnections.Count; ++index)
      {
        reporteCrystal.DataSourceConnections[index].SetConnection(logonInfo.ConnectionInfo.ServerName, logonInfo.ConnectionInfo.DatabaseName, logonInfo.ConnectionInfo.UserID, logonInfo.ConnectionInfo.Password);
        reporteCrystal.DataSourceConnections[index].SetLogon(logonInfo.ConnectionInfo.UserID, logonInfo.ConnectionInfo.Password);
      }
      for (int index = 0; index < reporteCrystal.Database.Tables.Count; ++index)
      {
        reporteCrystal.Database.Tables[index].ApplyLogOnInfo(logonInfo);
        reporteCrystal.Database.Tables[index].Location = logonInfo.ConnectionInfo.DatabaseName + ".dbo." + reporteCrystal.Database.Tables[index].Name;
      }
      if (reporteCrystal.IsSubreport)
        return true;
      for (int index = 0; index < reporteCrystal.Subreports.Count; ++index)
      {
        ReportDocument reporteCrystal1 = reporteCrystal.Subreports[index];
        this.ReporteCrystal_ConfiguraConexion(ref reporteCrystal1);
      }
      return true;
    }

    private ParameterFields ReporteCrystal_ConfiguraParametros(ReportDocument reporteCrystal, string nombresDeParametros, string valoresDeParametros)
    {
      ParameterFields parameterFields = new ParameterFields();
      string[] strArray1 = nombresDeParametros.Split(new char[1]
      {
        ';'
      });
      string[] strArray2 = valoresDeParametros.Split(new char[1]
      {
        ';'
      });
      for (int index1 = 0; index1 <= strArray1.GetUpperBound(0); ++index1)
      {
        ParameterField parameterField = new ParameterField();
        parameterField.ParameterFieldName = strArray1[index1];
        strArray2[index1] = strArray2[index1].Replace("{", "");
        strArray2[index1] = strArray2[index1].Replace("}", "");
        string[] strArray3 = strArray2[index1].Split(new char[1]
        {
          ','
        });
        for (int index2 = 0; index2 <= strArray3.GetUpperBound(0); ++index2)
        {
          if (strArray3[index2].IndexOf("|") == -1)
          {
            parameterField.CurrentValues.Add((ParameterValue) new ParameterDiscreteValue()
            {
              Value = (object) strArray3[index2]
            });
            parameterFields.Add(parameterField);
          }
          else
          {
            string[] strArray4 = strArray3[index2].Split(new char[1]
            {
              ':'
            });
            parameterField.CurrentValues.Add((ParameterValue) new ParameterRangeValue()
            {
              StartValue = (object) strArray4[0],
              EndValue = (object) strArray4[1]
            });
          }
        }
      }
      return parameterFields;
    }

    public void ReporteCrystal_MuestraEnPantalla(ReportDocument reporteCrystal, string nombresDeParametros, string valoresDeParametros)
    {
      FrmVisorCrystalReport visorCrystalReport = new FrmVisorCrystalReport();
      visorCrystalReport.reporteCrystal = reporteCrystal;
      if (nombresDeParametros != "")
        visorCrystalReport.crystalReportViewer1.ParameterFieldInfo = this.ReporteCrystal_ConfiguraParametros(reporteCrystal, nombresDeParametros, valoresDeParametros);
      ((Control) visorCrystalReport).Show();
    }

    public void ReporteCrystal_ImprimeDirecto(ReportDocument reporteCrystal, string nombresDeParametros, string valoresDeParametros)
    {
      FrmVisorCrystalReport visorCrystalReport = new FrmVisorCrystalReport();
      visorCrystalReport.reporteCrystal = reporteCrystal;
      if (nombresDeParametros != "")
        visorCrystalReport.crystalReportViewer1.ParameterFieldInfo = this.ReporteCrystal_ConfiguraParametros(reporteCrystal, nombresDeParametros, valoresDeParametros);
      visorCrystalReport.reporteCrystal.PrintToPrinter(1, true, 1, 10000);
    }

    public bool ReporteCrystal_ImprimeReporte(ReportDocument reporteCrystal, DataSet miDataSet, string nombresDeParametros, string valoresDeParametros)
    {
      this.ReporteCrystal_ConfiguraConexion(ref reporteCrystal, miDataSet);
      this.ReporteCrystal_ImprimeDirecto(reporteCrystal, nombresDeParametros, valoresDeParametros);
      return true;
    }

    public bool ReporteCrystal_ImprimeReporte(ReportDocument reporteCrystal, string nombresDeParametros, string valoresDeParametros)
    {
      this.ReporteCrystal_ConfiguraConexion(ref reporteCrystal);
      this.ReporteCrystal_ImprimeDirecto(reporteCrystal, nombresDeParametros, valoresDeParametros);
      return true;
    }

    public bool ReporteCrystal_MuestraReporte(ReportDocument reporteCrystal, DataSet miDataSet, string nombresDeParametros, string valoresDeParametros)
    {
      this.ReporteCrystal_ConfiguraConexion(ref reporteCrystal, miDataSet);
      this.ReporteCrystal_MuestraEnPantalla(reporteCrystal, nombresDeParametros, valoresDeParametros);
      return true;
    }

    public bool ReporteCrystal_MuestraReporte(ReportDocument reporteCrystal, string nombresDeParametros, string valoresDeParametros)
    {
      this.ReporteCrystal_ConfiguraConexion(ref reporteCrystal);
      this.ReporteCrystal_MuestraEnPantalla(reporteCrystal, nombresDeParametros, valoresDeParametros);
      return true;
    }

    public bool DAO_CambiaPassword()
    {
      FrmCambioDePassword cambioDePassword = new FrmCambioDePassword();
      bool flag;
      if (cambioDePassword.ShowDialog() == DialogResult.OK)
      {
        int num = (int) MessageBox.Show("El Password Se Ha Cambiado Correctamente", "Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        flag = true;
      }
      else
        flag = false;
      cambioDePassword.Dispose();
      return flag;
    }

    public bool DAO_CambiaPassword(string usuario, string passwordActual, string passwordNuevo)
    {
      string str = passwordNuevo;
      bool flag = false;
      if (usuario.ToUpper() == "SA")
      {
        this.DespliegaErrores("Este Método No Se Puede Utilizar Para Con El Login SA");
        return false;
      }
      else
      {
        if (usuario.ToUpper() != "SA")
        {
          str = passwordNuevo;
          flag = this.EjecutaComandoSQL("update Usuarios Set cPassword='" + passwordNuevo + "' Where cLogin='" + usuario + "'");
        }
        return flag;
      }
    }

    public bool ADU_AgregaUsuarioSQL(string usuario, string password)
    {
      if (this.loginUsuario.ToUpper() != "SA")
      {
        this.DespliegaErrores("Este Método Es De Uso Exclusivo Del Login SA");
        return false;
      }
      else
      {
        if (usuario.ToUpper() != "SA")
          this.EjecutaComandoSQL("update Usuarios Set cPassword\t='" + password + "' Where cLogin='" + usuario + "'");
        return true;
      }
    }

    public bool ADU_EliminaUsuarioSQL(string usuario)
    {
      if (this.loginUsuario.ToUpper() != "SA")
      {
        this.DespliegaErrores("Este Método Es De Uso Exclusivo Del Login 'SA'");
        return false;
      }
      else
      {
        this.EjecutaComandoSQL("Delete OperacionesSupervisadas_Supervisores Where cSupervisor='" + usuario + "' ");
        this.EjecutaComandoSQL("Delete Usuarios_X_Perfil Where cLogin='" + usuario + "' ");
        this.EjecutaComandoSQL("Delete Usuarios Where cLogin='" + usuario + "' ");
        int num = (int) MessageBox.Show("Usuario Eliminado Correctamente", "Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return true;
      }
    }

    public bool ADU_GrantAll()
    {
      if (this.loginUsuario.ToUpper() != "SA")
      {
        this.DespliegaErrores("Este Método Es De Uso Exclusivo Del Login 'SA'");
        return false;
      }
      else
      {
        DataTable miDataTable = new DataTable();
        this.RegresaConsultaSQL("Select name from Sysobjects where xtype in ('fn','u','v','p')", ref miDataTable);
        Cursor.Current = Cursors.WaitCursor;
        foreach (DataRow dataRow in (InternalDataCollectionBase) miDataTable.Rows)
          this.EjecutaComandoSQL("Grant All on " + dataRow["name"] + " to Access");
        Cursor.Current = Cursors.Default;
        int num = (int) MessageBox.Show("Derechos Otorgados Correctamente..", "Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return true;
      }
    }

    public enum TipoElementoAdicionalDeLista
    {
      Todos,
      Seleccione,
    }

    public enum TipoDeValorDeUnListControl
    {
      ValueMember,
      DisplayMember,
    }

    public enum TipoDeParametroAdministrado
    {
      Caracter,
      Numero,
    }
  }
}
