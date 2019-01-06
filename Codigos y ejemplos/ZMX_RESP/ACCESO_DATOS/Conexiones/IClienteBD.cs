using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESO_DATOS.Conexiones
{
    public interface IClienteBD
    {
        void AbrirConexion();
        void CerrarConexion();
        void AsignarCadenaConexion(String cadenaConexion);
        String ObtenerCadenaConexion();
        void IniciarTransaccion();
        void TerminarTransaccion();
        void DeshacerTransaccion();
        DataTable EjecutarSelect(String selectQuery);
        DataTable EjecutarSelect(String selectQuery, Dictionary<String, Object> parametros);
        int EjecutarInsert(String insertQuery);
        int EjecutarInsert(String insertQuery, Dictionary<String, Object> parametros);
        int EjecutarUpdate(String updateQuery);
        int EjecutarUpdate(String updateQuery, Dictionary<String, Object> parametros);
        int EjecutarDelete(String deleteQuery);
        int EjecutarDelete(String deleteQuery, Dictionary<String, Object> parametros);
        bool EstaActivaConexion();
        bool EstaActivaTransaccion();
        int EjecutaInsertUpdate(String insertUpdate);
    }
}
