Imports System.Windows.Forms
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.IO
Imports System.Text.RegularExpressions

Namespace Comunes.Comun.DBF

#Region "Database"
    Public Class Databases
        Public Sub New()
        End Sub

        ' <summary>
        ' Exporta una expresión Sql a formato Dbf (dBase III)
        ' </summary>
        ' <param name="cadenaConexion">Cadena de conexión con el servidor SQL</param>
        ' <param name="sql">Secuencia Select SQL para exportar</param>
        ' <param name="ficheroSalida">Nombre completo del fichero que se creará</param>
        ' <returns>true si la exportación es correcta</returns>
        Public Function Sql2Dbf(ByVal cadenaConexion As String, ByVal sql As String, ByVal ficheroSalida As String) As Boolean
            Dim factoria As DbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient")
            Return Databases.Db2Dbf(factoria, cadenaConexion, sql, ficheroSalida)
        End Function

        ' <summary>
        ' Exporta una expresión Sql a formato Dbf (dBase III)
        ' </summary>
        ' <param name="factoria">Factoría de System.Data.Common en el que se encuentra el formato de origen</param>
        ' <param name="cadenaConexion">Cadena de conexión con la base de datos de origen</param>
        ' <param name="sql">Secuencia Select SQL para exportar</param>
        ' <param name="ficheroSalida">Nombre completo del fichero que se creará</param>
        ' <returns>true si la exportación es correcta</returns>
        Public Shared Function Db2Dbf(ByVal factoria As DbProviderFactory, ByVal cadenaConexion As String, ByVal sql As String, ByVal ficheroSalida As String) As Boolean
            Dim retval As Boolean
            Dim export As New DatabaseToDbf(factoria, cadenaConexion, sql, ficheroSalida)
            retval = export.Exporta()
            Return retval
        End Function

    End Class

#End Region

#Region "DatabaseToDBF"

    Friend Class DatabaseToDbf

        Private factoria As DbProviderFactory
        Private cadenaConexion As String
        Private sql As String
        Private pathSalida As String
        Private ficheroSalida As String
        Private nombreTabla As String

        Private campos As New List(Of String)()
        Private parametros As New List(Of String)()
        Private nombreCampos As New List(Of String)()

        Private strConnDbf As String

        ' <summary>
        ' Constructor de la clase
        ' </summary>
        ' <param name="factoria">Factoría del origen de los datos</param>
        ' <param name="cadenaConexion">Cadena de conexión a la base de datos de origen</param>
        ' <param name="sql">Instrucción Select SQL para exportar a dbf</param>
        ' <param name="ficheroSalida">Nombre completo del fichero de salida</param>
        Public Sub New(ByVal factoria As DbProviderFactory, ByVal cadenaConexion As String, ByVal sql As String, ByVal ficheroSalida As String)
            Me.factoria = factoria
            Me.cadenaConexion = cadenaConexion
            Me.sql = sql

            ' En base al fichero, se desglosa la información para usarla más tarde.
            Dim f As New FileInfo(ficheroSalida)
            pathSalida = f.DirectoryName
            Me.ficheroSalida = f.FullName
            nombreTabla = New Regex(f.Extension & "$").Replace(f.Name, "")

            ' Creación de la cadena de conexión al fichero .dbf
            strConnDbf = ("Provider = Microsoft.Jet.OLEDB.4.0" & ";Data Source = ") + pathSalida & ";Extended Properties = dBASE IV" & ";User ID=Admin;Password=;"
        End Sub

        ' <summary>
        ' Realiza la exportación de la base de datos de origen a un fichero con formato .dbf.
        ' </summary>
        ' <returns>True si el traspaso ha sido correcto</returns>
        Public Function Exporta() As Boolean
            Dim retVal As Boolean = False
            Try
                LeeEstructura()
                CreaTabla()
                InsertaDatos()

                ' Se ha llegado hasta aquí, se supone que está todo bien
                retVal = True
            Catch
                retVal = False
            End Try
            Return retVal
        End Function

        ' <summary>
        ' Lectura de la estructura de la tabla de origen
        ' </summary>
        Private Sub LeeEstructura()
            Using cn As DbConnection = factoria.CreateConnection()
                cn.ConnectionString = cadenaConexion
                Using cmd As DbCommand = cn.CreateCommand()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    Dim da As DbDataAdapter = factoria.CreateDataAdapter()
                    da.SelectCommand = cmd

                    Dim dt As New DataTable()
                    da.FillSchema(dt, SchemaType.Mapped)

                    For Each columna As DataColumn In dt.Columns
                        Dim c As New Campo(columna)
                        ' Se crea la lista de parámetros
                        campos.Add(c.Tabla())
                        parametros.Add(c.Parametro())
                        nombreCampos.Add(c.Nombre())

                        c = Nothing
                    Next
                End Using
            End Using
        End Sub

        ' <summary>
        ' Creación del fichero DBF.
        ' </summary>
        Private Sub CreaTabla()
            ' Se borra el fichero en el caso de que exista
            File.Delete(ficheroSalida)

            Using cn As New OleDbConnection(strConnDbf)
                Using cmd As New OleDbCommand()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = GetSql_Create()

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                End Using
            End Using
        End Sub

        ' <summary>
        ' Realiza el traspaso de datos de la base de datos de origen al fichero dbf.
        ' </summary>
        Private Sub InsertaDatos()
            ' Preparación del comando de inserción
            Dim cnDestino As New OleDbConnection(strConnDbf)

            Dim cmdInserta As New OleDbCommand()
            cmdInserta.CommandType = CommandType.Text
            cmdInserta.CommandText = GetSql_Insert()
            cmdInserta.Connection = cnDestino

            ' Parámetros 
            For i As Integer = 0 To parametros.Count - 1
                ' Añado los parámetros con un valor nulo. Luego se cambiará. 
                cmdInserta.Parameters.Add(New OleDbParameter(parametros(i), DBNull.Value))
            Next

            ' Se hace un recorrido por los datos de origen
            Using cnOrigen As DbConnection = factoria.CreateConnection()
                cnOrigen.ConnectionString = cadenaConexion
                Using cmd As DbCommand = cnOrigen.CreateCommand()
                    cmd.Connection = cnOrigen
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = sql

                    cnOrigen.Open()
                    Dim dr As DbDataReader = cmd.ExecuteReader()
                    cnDestino.Open()

                    While dr.Read()
                        For i As Integer = 0 To nombreCampos.Count - 1
                            ' Se establece el valor del parámetro
                            cmdInserta.Parameters(i).Value = dr(i)
                        Next

                        ' Ejecución de la inserción en dbf
                        cmdInserta.ExecuteNonQuery()
                    End While
                    dr.Close()
                    cnDestino.Close()
                    cnOrigen.Close()
                End Using
            End Using
        End Sub

        ' <summary>
        ' Devuelve la instrucción SQL que permitirá la inserción de los datos
        ' </summary>
        Private Function GetSql_Insert() As String
            Return (("INSERT INTO " & nombreTabla) + String.Concat("(", String.Join(",", nombreCampos.ToArray()), ")") & " VALUES ") + String.Concat("(", String.Join(",", parametros.ToArray()), ")")
        End Function

        ' <summary>
        ' Obtiene la instrucción SQL que permitirá la creación de la tabla
        ' </summary>
        Private Function GetSql_Create() As String

            Return ("CREATE TABLE " & nombreTabla) + String.Concat("(", String.Join(", ", campos.ToArray()), ")")
        End Function

    End Class

#End Region

#Region "Campo"
    ' <summary>
    ' Clase que representa un campo de la tabla de origen.
    ' </summary>
    ' <remarks>
    ' Como la estructura de la tabla de destino tendrá la misma estructura que la sentencia
    ' de entrada, es importante obtener todos los datos posibles de dicha estructura.
    ' </remarks>
    Friend Class Campo

        ' <summary>
        ' Tipos de datos que puede tener la tabla de origen. 
        ' </summary>
        ' <remarks>Como que la lectura de la base de datos de origen se hace mediante clases genéricas
        ' de acceso a datos, pueden surgir tipos no conocidos aquí</remarks>
        Private Enum TiposCampoEnum
            Varchar
            Int
            [Double]
            Bit
            DateTime
        End Enum

        Private atrnombre As String
        Private atrtipo As TiposCampoEnum
        Private atrtamano As Integer

        ' <summary>
        ' Constructor. 
        ' </summary>
        Public Sub New(ByVal columna As System.Data.DataColumn)

            atrnombre = columna.ColumnName
            atrtipo = TipoCampo(columna)
            atrtamano = columna.MaxLength
            ' Se omiten intencionadamente los campos Memo
            If atrtamano > 254 Then
                atrtamano = 254
            End If
        End Sub

        ' <summary>
        ' Adaptación del tipo de campo de origen a un formato simple dbf
        ' </summary>
        ' <remarks>Es posible que si se usan otras bases de datos haya que modificar este
        ' procedimiento</remarks>
        Private Function TipoCampo(ByVal columna As DataColumn) As TiposCampoEnum
            Dim s As TiposCampoEnum = TiposCampoEnum.Varchar

            Select Case columna.DataType.FullName
                Case "System.String"
                    s = TiposCampoEnum.Varchar
                    Exit Select

                Case "System.Int", "System.Int16", "System.Int32", "System.Int64"
                    s = TiposCampoEnum.Int
                    Exit Select

                Case "System.Double", "System.Decimal"
                    s = TiposCampoEnum.[Double]
                    Exit Select

                Case "System.Boolean"
                    s = TiposCampoEnum.Bit
                    Exit Select

                Case "System.DateTime"
                    s = TiposCampoEnum.DateTime
                    Exit Select
                Case Else

                    Throw New ArgumentOutOfRangeException("El tipo " & columna.DataType.FullName & " no está contemplado en el procedimiento Campo.TipoCampo")
            End Select
            Return s
        End Function

        ' <summary>
        ' Obtiene el campo en formato de parámetro
        ' </summary>
        ' <returns></returns>
        Public ReadOnly Property Parametro() As String
            Get
                Return "@" & Nombre
            End Get
        End Property

        ' <summary>
        ' Obtiene el nombre del campo
        ' </summary>
        ' <returns></returns>
        Public ReadOnly Property Nombre() As String
            Get
                Return atrnombre
            End Get
        End Property

        ' <summary>
        ' Obtiene la estructura necesaria que se empleará en la creación de la tabla.
        ' </summary>
        ' <returns></returns>
        Public ReadOnly Property Tabla() As String
            Get
                Return ("[" & Nombre & "]" & " ") + atrtipo.ToString + (If(atrtipo <> TiposCampoEnum.Varchar, "", "(" & atrtamano & ")"))
            End Get
        End Property

    End Class
#End Region

End Namespace