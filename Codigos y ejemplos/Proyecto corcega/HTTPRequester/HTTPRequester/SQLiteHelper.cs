using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace HTTPRequester
{
    public class SQLiteHelper
    {
        public static void VerificarExistenciaBD()
        {
            if (!File.Exists("history.sqlite"))
            {
                try
                {
                    SQLiteConnection.CreateFile("history.sqlite");
                    SQLiteConnection m_dbConnection;
                    m_dbConnection = new SQLiteConnection("Data Source=history.sqlite;Version=3;");
                    m_dbConnection.Open();
                    //creando tablas
                    string sql = "CREATE TABLE history (id integer PRIMARY KEY AUTOINCREMENT, url VARCHAR(300), method varchar(20), headers varchar(300), body varchar(500), dt datetime DEFAULT (datetime('now','localtime')))";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    m_dbConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error trying create history database.", ex);
                }

            }
        }

        public static void InsertarHistorialPorURL(HistoryRow row)
        {
            if (File.Exists("history.sqlite") && row.isChanged)
            {
                try
                {
                    row.isChanged = false;
                    SQLiteConnection m_dbConnection;
                    m_dbConnection = new SQLiteConnection("Data Source=history.sqlite;Version=3;");
                    m_dbConnection.Open();
                    //creando tablas
                    string sql = "";


                    String headers = "";
                    if (row.Headers != null)
                    {
                        sql = "insert into history (url, method, headers, body) values ('@url', '@method', '@headers', '@body')";
                        foreach (Header header in row.Headers)
                        {
                            headers += header.Key + "," + header.Value + "|";
                        }
                        headers = headers.Substring(0, headers.Length - 1);
                        sql = sql.Replace("@headers", headers);
                    }
                    else
                    {
                        sql = "insert into history (url, method, body) values ('@url', '@method', '@body')";
                    }

                    sql = sql.Replace("@url", row.URL);
                    sql = sql.Replace("@method", row.Method);
                    sql = sql.Replace("@body", row.Body);
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    m_dbConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error trying create history database.", ex);
                }

            }
            else
            {
                ActualizarHistorialPorURL(row);
            }
        }
        public static void ActualizarHistorialPorURL(HistoryRow row)
        {
            if (File.Exists("history.sqlite") )
            {
                try
                {
                    row.isChanged = false;
                    SQLiteConnection m_dbConnection;
                    m_dbConnection = new SQLiteConnection("Data Source=history.sqlite;Version=3;");
                    m_dbConnection.Open();
                    //creando tablas
                    string sql = "update history set dt = datetime('now','localtime') where id = "+row.ID;
                      
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    m_dbConnection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error trying create history database.", ex);
                }

            }
        }
        public static List<HistoryRow> ObtenerHistorial()
        {
            List<HistoryRow> rows = new List<HistoryRow>();
            if (File.Exists("history.sqlite"))
            {
                try
                {
                    SQLiteConnection m_dbConnection;
                    m_dbConnection = new SQLiteConnection("Data Source=history.sqlite;Version=3;");
                    m_dbConnection.Open();
                    //creando tablas
                    string sql = "select * from history ORDER BY datetime(dt) desc limit 20";
                    
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                    SQLiteDataReader reader = command.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        HistoryRow row = new HistoryRow();
                        row.ID = Convert.ToInt32(reader["id"]);
                        row.URL = reader["url"].ToString();
                        row.Method = reader["method"].ToString();
                        row.Body = reader["body"].ToString();

                        try
                        {
                            String headers = reader["readers"].ToString();

                            foreach (String header in headers.Split('|'))
                            {
                                Header head = new Header();
                                head.Key = header.Split(',')[0];
                                head.Value = header.Split(',')[1];
                                row.Headers.Add(head);
                            }
                        }
                        catch { }
                        row.isChanged = false;
                        row.ActivarEventos = true;
                        rows.Add(row);

                    }

                    m_dbConnection.Close();
                   
                }
                catch (Exception ex)
                {
                    throw new Exception("Error trying get history.", ex);
                }

            }
            return rows;
        }
    }
}
