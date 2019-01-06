using System;

namespace Sistema.Mantenimiento
{
	/// <summary>
	/// Desarrollado Por : Lic. Alejandro Cons Gastélum Arámburo
	/// Fecha V1.1		 : Septiembre 2004
	/// Clase			 : ClsMetaCatalogosManager
	/// Descripcion      : Clase para la Creacion de MetaCatálogos
	/// Que Hace		 : Esta Clase Apoya en el Creado de MetaCatálogos 
	///					   Proporcionando el Codigo en Transac-SQL para generarlos
	///					   
	///****************** NO TERMINADA *************************
	///****************** NO TERMINADA *************************
	///****************** NO TERMINADA *************************
	///					   
	/// </summary>
	public class ClsMetaCatalogosManager
	{
		
		public static string	GenerarSqlScriptCrearMetaCatalogo(string prmMetaCatalogo, string prmSqlCatalogo, string prmSqlBusquedaRapida, string prmSqlScriptCatalogo, string prmSqlScriptBusquedaRapida, string prmCampoPrimario, string prmCampoDescripcion, string prmCampoBusqueda, int prmCerosAJustificar, int prmTipoCriterio, bool prmCriterioObligatorio)
		{
			string sqlScript;
			sqlScript  = "--***********************************\r\n";
			sqlScript += "-- MetaCatalogo : " + prmMetaCatalogo + "\r\n";
			sqlScript += "--***********************************\r\n";
			
			sqlScript += GeneraSqlScriptCrearVista(prmSqlCatalogo, prmSqlScriptCatalogo) + "\r\n";
			sqlScript += GeneraSqlScriptCrearVista(prmSqlBusquedaRapida, prmSqlScriptBusquedaRapida) + "\r\n";
			sqlScript += "EXEC spGuardarMetaCatalogo ";
			sqlScript += prmMetaCatalogo + ", ";			
			sqlScript += prmCampoPrimario + ", ";
			sqlScript += prmCampoDescripcion + ", ";
			sqlScript += prmCampoBusqueda + ", ";			
			sqlScript += prmSqlCatalogo + ", ";
			sqlScript += prmSqlBusquedaRapida + ", ";
			sqlScript += prmCerosAJustificar + ", ";
			sqlScript += prmTipoCriterio.ToString() + ", ";						
			if (prmCriterioObligatorio)
				sqlScript += "1 \r\n " ;
			else
				sqlScript += "0 \r\n " ;
			sqlScript += "GO \r\n" ;
			sqlScript += "EXEC spCrearMetaCampos " + prmMetaCatalogo + "\r\n GO";
			return sqlScript;
		}
		public static string	ObtenSqlSelectVista(string prmVista)
		{			
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			if (DAO.ExistenDatosEnConsultaSQL("SELECT 1 FROM sysObjects WHERE name = '"+ prmVista +"' "))
			{
				System.Data.SqlClient.SqlDataReader drScriptVista = null ;
				DAO.RegresaConsultaSQL("sp_helptext " + prmVista, ref drScriptVista);
				while (drScriptVista.Read() && !drScriptVista.GetString(0).Trim().ToUpper().StartsWith("SELECT"));
				string sqlScript = drScriptVista.GetString(0);
				while (drScriptVista.Read())
					sqlScript += drScriptVista.GetString(0);
				drScriptVista.Close();
				return sqlScript;
			}
			else
			{				
				return "";
			}


		}
		public static string	GeneraSqlScriptCrearVista(string prmVista, string prmSqlScript)
		{
			string sqlScript = "";			
			if (prmSqlScript == null)
			{			
				System.Data.SqlClient.SqlDataReader drScriptVista = null ;
				DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
				DAO.RegresaConsultaSQL("sp_helptext " + prmVista, ref drScriptVista);
			
				while (drScriptVista.Read())
					sqlScript += drScriptVista.GetString(0);
				
				drScriptVista.Close();
			}
			else
			{
				sqlScript = "CREATE VIEW " + prmVista + " AS \r\n" ;
				sqlScript += prmSqlScript + "\r\n";
			}

			sqlScript += "GO";
			
			return sqlScript;
		}
		public static bool		GuardaMetaCatalogo (string prmMetaCatalogo, string prmSqlCatalogo, string prmSqlBusquedaRapida, string prmSqlScriptCatalogo, string prmSqlScriptBusquedaRapida, string prmCampoPrimario, string prmCampoDescripcion, string prmCampoBusqueda, int prmCerosAJustificar, int prmTipoCriterio, bool prmCriterioObligatorio)
		{			
			if (!ExisteObjetoSQL(prmSqlCatalogo) || !ExisteObjetoSQL(prmSqlBusquedaRapida))
				return false;
			string sqlQuery = GenerarSqlScriptCrearMetaCatalogo(prmMetaCatalogo, prmSqlCatalogo, prmSqlBusquedaRapida, prmSqlScriptCatalogo, prmSqlScriptBusquedaRapida, prmCampoPrimario, prmCampoDescripcion, prmCampoBusqueda, prmCerosAJustificar, prmTipoCriterio, prmCriterioObligatorio);
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			DAO.EjecutaComandoSQL(sqlQuery);
			return true;
			
		}
		public static bool		BorraMetaCatalogo(string prmMetaCatalogo)
		{ 			
			string sqlQuery = "spBorraMetaCatalogo " + prmMetaCatalogo;
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			DAO.EjecutaComandoSQL(sqlQuery);
			return true;
		}

		public static bool		ExisteObjetoSQL(string prmTabla )
		{
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			return DAO.ExistenDatosEnConsultaSQL("SELECT 1 AS nExiste FROM sysobjects WHERE name = " + prmTabla);
		}

		public static System.Data.DataTable ObtenTablaCampos( string prmTabla )
		{									
			string sqlQuery = "SELECT C.name as [Campos] FROM sysColumns C WHERE C.id = Object_Id('" + prmTabla + "')";
			System.Data.DataTable dttCampos = new System.Data.DataTable();
			DataAccessCls DAO = DataAccessCls.DevuelveInstancia();
			DAO.RegresaConsultaSQL(sqlQuery, ref dttCampos);
			return dttCampos;
		}
		
	}

}
