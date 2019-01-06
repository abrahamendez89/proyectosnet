Option Strict On

Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Data.SqlClient



Public Class SQLHelper


    ' Public Shared ReadOnly strConnectionString As String = ConfigurationSettings.AppSettings("ConnectionString")
    ' Dim objcommonDAL As Common.Common
    ':::::::::::::::::::::::::::::::::::::'
    'Public Shared strConnectionString As String = "Server=developer-15; Database=4BERP; uid=sa; pwd=sa;"
    'Public Shared gblDBServer, gblDBName, gblDBUser, gblDBPassword As String
    'Public Shared gblBranchID As Integer
    'Public Shared LoggedInUserID As Integer = 0
    'Public Shared Sub setConnectionString(ByVal serverName As String, ByVal userId As String, ByVal password As String)
    '    gblDBServer = serverName
    '    gblDBName = "wsons"
    '    gblDBUser = userId
    '    gblDBPassword = password

    '    strConnectionString = "Initial Catalog=4BERP; Data Source=" & serverName & "; User Id=" & userId & "; Password=" & password  ''& " '' DAL.Common.Common.strConnectionString"
    '    '   strConnectionString1 = "Initial Catalog=ws-lhr05; Data Source=" & serverName & "; User Id=" & userId & "; Password=" & password  ''& " '' DAL.Common.Common.strConnectionString"

    'End Sub
    'Public Shared ReadOnly Property getConnectionString() As String
    '    Get
    '        Return strConnectionString
    '    End Get
    'End Property
    'Public Shared ReadOnly Property getBusinessCode() As String
    '    Get
    '        Return "AGR"
    '    End Get
    'End Property
    'Public Shared ReadOnly Property getGetBusnessID() As Integer
    '    Get
    '        Return 1
    '    End Get
    'End Property
    'Public Shared ReadOnly Property GetTransactionStartDate() As Date
    '    Get
    '        Return CDate("1/1/2006")
    '    End Get
    'End Property
    'Public Shared ReadOnly Property GetTransactionEndDate() As Date
    '    Get
    '        Return CDate("12/31/2006")
    '    End Get
    'End Property
    ':::::::::::::::::::::::::::::::::::::'
    'Public Shared SeverName As String
    'Public Shared UserId As String
    'Public Shared Password As String


    'Public Shared ReadOnly strConnectionString As String = "Initial Catalog=wsons; Data Source=" & SeverName & "; User Id=" & UserId & "; Password=" & Password ''& " '' DAL.Common.Common.strConnectionString"
    'Database connection strings
    'Public Shared ReadOnly CONN_STRING As String = ConfigurationSettings.AppSettings("MySQLConnString1")

    '// Hashtable to store cached parameters
    'Private parmCache As Hashtable = Hashtable.Synchronized(New Hashtable)

    '/// <summary>
    '/// Execute a OleDbCommand (that returns no resultset) against the database specified in the connection string 
    '/// using the provided parameters.
    '/// </summary>
    '/// <remarks>
    '/// e.g.:  
    '///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
    '/// </remarks>
    '/// <param name="connectionString">a valid connection string for a OleDbConnection</param>
    '/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    '/// <param name="commandText">the stored procedure name or T-SQL command</param>
    '/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    '/// <returns>an int representing the number of rows affected by the command</returns>


    ''Executa la cadena de conexion del sistema
    Public Shared Function ExecuteNonQuery(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As SqlParameter()) As Integer

        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        'Dim trans As SqlTransaction = conn.BeginTransaction("BuilderTransaction")
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim val As Integer = cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException
            Throw New Exception("SQL Exception1 " & ex.Message)
        Catch exx As Exception
            Throw New Exception("ExecuteNonQuery Function", exx)
        Finally                'Add this for finally closing the connection and destroying the command
            conn.Close()
            cmd = Nothing
            cmdParms = Nothing
        End Try
    End Function

    '/// <summary>
    '/// Execute a OleDbCommand (that returns no resultset) against an existing database connection 
    '/// using the provided parameters.
    '/// </summary>
    '/// <remarks>
    '/// e.g.:  
    '///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
    '/// </remarks>
    '/// <param name="conn">an existing database connection</param>
    '/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    '/// <param name="commandText">the stored procedure name or T-SQL command</param>
    '/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    '/// <returns>an int representing the number of rows affected by the command</returns>

    Public Shared Function ExecuteNonQuery(ByRef conn As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As SqlParameter()) As Integer
        Dim cmd As SqlCommand = New SqlCommand
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            'For Each parm In cmdParms
            '    cmd.Parameters.Add(parm)
            'Next
            Dim val As Integer = cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteNonQuery", exx)
        Finally
            cmd = Nothing
        End Try
    End Function

    '	/// <summary>
    '/// Execute a OleDbCommand that returns a resultset against the database specified in the connection string 
    '/// using the provided parameters.
    '/// </summary>
    '/// <remarks>
    ''/// e.g.:  
    '///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
    '/// </remarks>
    '/// <param name="connectionString">a valid connection string for a OleDbConnection</param>
    '/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    '/// <param name="commandText">the stored procedure name or T-SQL command</param>
    '/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    '/// <returns>A SqlDataReader containing the results</returns>

    Public Shared Function ExecuteReader(ByRef conn As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand
        'Dim conn As OleDbConnection = New OleDbConnection(connString)
        ' we use a try/catch here because if the method throws an exception we want to 
        ' close the connection throw ex code, because no datareader will exist, hence the 
        ' commandBehaviour.CloseConnection will not work
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim rdr As SqlDataReader = cmd.ExecuteReader()
            'cmd.Parameters.Clear()
            Return rdr
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteReader", exx)
        Finally
            cmd = Nothing
        End Try
    End Function

    Public Shared Function ExecuteTable(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataTable

        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        Dim oDataAdapter As New SqlDataAdapter
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            'cmd.Parameters = cmdParms
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            Return oDataTable
        Catch ex As SqlException

            Throw New Exception("SQL Exception : " & ex.Message, ex)
        Catch exx As Exception
            Throw New Exception("ExecuteTable Exception :", exx)
        Finally
            conn.Close()
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    Public Shared Function ExecuteTable(ByRef oConnection As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataTable

        Dim cmd As SqlCommand = New SqlCommand
        Dim oDataAdapter As New SqlDataAdapter
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, oConnection, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            Return oDataTable
        Catch ex As Exception
            Throw New Exception("ExecuteTable", ex)
        Finally
            cmd.Connection.Close()
            cmd.Dispose()
            oDataAdapter.Dispose()
            oDataTable.Dispose()
        End Try
    End Function

    ''Public Shared Function ExecuteDataSet(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataSet
    Public Shared Function ExecuteDataSet(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataSet

        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)

        Dim oDataAdapter As New SqlDataAdapter
        Dim oDataSet As New DataSet
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            'cmd.Connection = conn
            ''Llena el dataset''
            oDataAdapter.Fill(oDataSet)
            cmd.Parameters.Clear()
            Return oDataSet
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteDataSet", exx)
        Finally
            conn.Close()
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    Public Shared Function ExecuteRow(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataRow
        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        Dim oDataAdapter As New SqlDataAdapter
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            If oDataTable.Rows.Count = 0 Then
                Return Nothing
            Else
                Dim oRow As DataRow = oDataTable.Rows(0)
                Return oRow
            End If
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExecuteRow", exx)
        Finally
            conn.Close()
            oDataTable = Nothing
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function


    Public Shared Function ExecuteRow(ByRef oConnection As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, Optional ByVal cmdParms As SqlParameter() = Nothing) As DataRow
        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = oConnection
        Dim oDataAdapter As New SqlDataAdapter
        Dim oDataTable As New DataTable
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            oDataAdapter.SelectCommand = cmd
            oDataAdapter.Fill(oDataTable)
            cmd.Parameters.Clear()
            If oDataTable.Rows.Count = 0 Then
                Return Nothing
            Else
                Dim oRow As DataRow = oDataTable.Rows(0)
                Return oRow
            End If
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateScalar", exx)
        Finally
            oDataTable = Nothing
            cmd.Connection.Close()
            cmd = Nothing
            oDataAdapter = Nothing
        End Try
    End Function

    '/// <summary>
    '/// Execute a OleDbCommand that returns the first column of the first record against the database specified in the connection string 
    '/// using the provided parameters.
    '/// </summary>
    '/// <remarks>
    '/// e.g.:  
    '///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
    '/// </remarks>
    '/// <param name="connectionString">a valid connection string for a OleDbConnection</param>
    '/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    '/// <param name="commandText">the stored procedure name or T-SQL command</param>
    '/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    '/// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>

    Public Shared Function ExecuteScalar(ByVal connString As String, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As SqlParameter()) As Object
        Dim cmd As SqlCommand = New SqlCommand
        Dim conn As SqlConnection = New SqlConnection(connString)
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim val As Object = cmd.ExecuteScalar()

            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException

            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateScalar", exx)
        Finally
            conn.Close()
            conn = Nothing
            cmd = Nothing
        End Try
    End Function


    '/// <summary>
    '/// Execute a OleDbCommand that returns the first column of the first record against an existing database connection 
    '/// using the provided parameters.
    '/// </summary>
    '/// <remarks>
    '/// e.g.:  
    '///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OleDbParameter("@prodid", 24));
    '/// </remarks>
    '/// <param name="conn">an existing database connection</param>
    '/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
    '/// <param name="commandText">the stored procedure name or T-SQL command</param>
    '/// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
    '/// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>

    Public Shared Function ExecuteScalar(ByRef conn As SqlConnection, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms As SqlParameter()) As Object

        Dim cmd As SqlCommand = New SqlCommand
        Try
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParms)
            Dim val As Object = cmd.ExecuteScalar()
            cmd.Parameters.Clear()
            Return val
        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateScalar", exx)
        Finally
            cmd.Connection.Close()
            cmd = Nothing
        End Try
    End Function

    '/// <summary>
    '/// add parameter array to the cache
    '/// </summary>
    '/// <param name="cacheKey">Key to the parameter cache</param>
    '/// <param name="cmdParms">an array of SqlParamters to be cached</param>

    'Public Function CacheParameters(ByVal cacheKey As String, ByVal cmdParms As OleDbParameter())
    '    parmCache(cacheKey) = cmdParms
    'End Function

    '/// <summary>
    '/// Retrieve cached parameters
    '/// </summary>
    '/// <param name="cacheKey">key used to lookup parameters</param>
    '/// <returns>Cached SqlParamters array</returns>

    'Public Function GetCachedParameters(ByVal cacheKey As String) As OleDbParameter()
    '    Dim cachedParms As OleDbParameter() = parmCache(cacheKey)
    '    If IsNothing(cachedParms) Then
    '        Return Nothing
    '    End If

    '    Dim clonedParms() As OleDbParameter = New OleDbParameter("abc", cachedParms.Length)
    '    Dim i As Integer
    '    Dim j As Integer = cachedParms.Length
    '    For i = 0 To j < 1
    '		clonedParms(i) = (OleDbParameter)((ICloneable)cachedParms(i)).Clone();
    '        Return clonedParms
    '    Next


    '/// <summary>
    '/// Prepare a command for execution
    '/// </summary>
    '/// <param name="cmd">OleDbCommand object</param>
    '/// <param name="conn">OleDbConnection object</param>
    '/// <param name="trans">SqlTransaction object</param>
    '/// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
    '/// <param name="cmdText">Command text, e.g. Select * from Products</param>
    '/// <param name="cmdParms">OleDbParameters to use in the command</param>

    Public Shared Function PrepareCommand(ByRef cmd As SqlCommand, ByRef conn As SqlConnection, ByRef cmdType As CommandType, ByRef cmdText As String, ByRef cmdParms As SqlParameter()) As Boolean
        If Not conn.State = ConnectionState.Open Then
            'MsgBox("Connection open")
            conn.Open()
        End If
        Try
            cmd.Connection = conn
            cmd.CommandText = cmdText
            cmd.Parameters.Clear()
            '  cmd.ParameterCheck = True
            cmd.CommandType = cmdType
            ''Si no se paso como parametro algo entra al IF
            If Not (IsNothing(cmdParms)) Then
                Dim parm As SqlParameter
                For Each parm In cmdParms
                    cmd.Parameters.Add(parm)
                Next
            End If
        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("PrepareCommand : ", exx)
        End Try
    End Function


    Public Shared Function ExcuteAdapter(ByVal connString As String, ByVal oTable As DataTable, ByVal cmdText As String, Optional ByRef lngMaxID As Long = 0) As Boolean

        Dim conn As SqlConnection
        Dim oDataAdapter As New SqlDataAdapter
        Dim oSqlCmd As New SqlCommand
        Dim oCmdBuilder As SqlCommandBuilder
        Try
            conn = New SqlConnection(connString)
            If Not conn.State = ConnectionState.Open Then
                conn.Open()
            End If

            oSqlCmd.Connection = conn
            oSqlCmd.CommandText = cmdText
            oSqlCmd.CommandType = CommandType.Text
            oDataAdapter.SelectCommand = oSqlCmd
            oCmdBuilder = New SqlCommandBuilder(oDataAdapter)
            oCmdBuilder.GetUpdateCommand()
            oCmdBuilder.GetInsertCommand()
            oCmdBuilder.GetDeleteCommand()
            oDataAdapter.Update(oTable)
            oDataAdapter.SelectCommand = New SqlCommand("SELECT @@IDENTITY", conn)
            lngMaxID = CType(oDataAdapter.SelectCommand.ExecuteScalar(), Long)

        Catch ex As SqlException
            Throw New Exception("SQL Exception ", ex)
        Catch exx As Exception
            Throw New Exception("ExeculateAdapter", exx)
        Finally
            ' cmd.Connection.Close()
            If conn.State = ConnectionState.Open Then conn.Close()
            oSqlCmd = Nothing
            oDataAdapter = Nothing
            oCmdBuilder = Nothing

        End Try

    End Function

    ' <summary>
    ' return table Schema 
    ' </summary>
    ' <param name="connString"></param>
    ' <param name="cmdText"></param>
    ' <param name="strTableName"></param>
    ' <returns></returns>
    'Public Shared Function FillSchema(ByVal connString As String, ByVal cmdText As String, ByVal strTableName As String
End Class