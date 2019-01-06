using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Utilerias.SQL
{
    public interface ISQLManager
    {
        void ConfigurarConexion(String cadenaConexion);
        void AbrirConexion();
        void CerrarConexion();
        DataTable EjecutarConsulta(String consulta);
        void IniciarTransaccion();
        void TerminarTransaccion();
        void DeshacerTransaccion();
        int Reconectar();
    }
}
