using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Herramientas.Forms.ExcelElements;

namespace Herramientas.SQL
{
    public interface iSQL
    {
        void ConfigurarConexion(String cadenaConexion);
	    void ConfigurarConexion(String servidor,String baseDatos,String usuario,String contrasena);
        void ConfigurarConexion(String archivoDB, Boolean EsNuevo);
        String ObtenerCadenaConexion();
        iSQL ObtenerNuevaInstancia(String cadenaConexion);
        void AbrirConexion();
        void CerrarConexion();
        DataTable EjecutarConsulta(String consulta);
        DataTable EjecutarConsulta(String consulta, List<Object> valores);
        void IniciarTransaccion();
        void TerminarTransaccion();
        void DeshacerTransaccion();
        Boolean Reconectar();
        String ObtenerBD();
        void AsignarBD(String bd);
        void CrearEInsertarArchivoDataExcel(ExcelArchivo dataExcel);
        //metodos para que funcione el generador de codigo
        String ObtenerTipoEspecifico(Type tipo);
        Boolean ExisteColumnaDeTabla(String tabla, String columna);
        Boolean ExisteTabla(String tabla);
        DataTable ObtenerListadoTablas();
        DataTable ObtenerListadoColumnasDeTabla(String tabla);
        String ObtenerCodigoCrearBD(String nombreBD);
        String ObtenerPalabraClaveParaIdentity();
        String ObtenerPalabraClaveParaCamposNull();
        String ObtenerExpresionParaAgregarIndiceClusteredAPK(String tabla);
        String ObtenerPalabraClaveParaGO();
        String ObtenerExpresionParaAgregarColumnaDeObjetoRelacionado(String columna, Type tipoColumna, String tablaAAgregar, String nombreTablaReferencia, String nombreCampoReferencia);
        String ObtenerExpresionParaAgregarLlaveForanea(String nombreLlaveForanea, String columna, String tablaAAgregar, String nombreTablaReferencia, String nombreCampoReferencia);
        String ObtenerExpresionParaAgregarIndiceNonClustered(String nombreIndice, String Tabla, String campo);
        String ObtenerExpresionParaAgregarIndiceClustered(String nombreIndice, String Tabla, String campo);
        Boolean ImplementaLlaveForaneaConstraint();
        //metodos para que funcione el framework
        DateTime QueryParaObtenerLaHoraDelServer();
        String QueryParaObtenerElUltimoIDInsertado(String tabla);
    }
}
