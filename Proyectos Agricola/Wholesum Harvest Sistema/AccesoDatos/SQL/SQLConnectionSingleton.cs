using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AccesoDatos.SQL
{
    public class SQLConnectionSingleton
    {
        private static Dictionary<String, SqlConnection> conexiones = new Dictionary<string,SqlConnection>();
        public static SqlConnection ObtenInstancia(String cadenaConexion)
        {
            SqlConnection conexion;
            if (!conexiones.ContainsKey(cadenaConexion))
            {
                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;
                conexiones.Add(cadenaConexion, conexion);
                conexion.Open(); //abriendo conexion
            }
            else
                conexion = conexiones[cadenaConexion];
            return conexion;
        }
    }
}
