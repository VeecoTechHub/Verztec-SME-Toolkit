using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using Microsoft.Win32;
////using NusDAL;

/// <summary>
/// Summary description for DatabaseConnector
/// </summary>
public class DatabaseConnector
{
    #region Variable Declration
        private OleDbConnection dbConnection;
        //private OleDbDataAdapter dbAdapter;
        private OleDbCommand cmd = new OleDbCommand(); 
    #endregion 
		
		

		public DatabaseConnector()
		{

            //this.dbConnection = new OleDbConnection(NusDataAccessLayer.GetConnectionString()); 
            //    if (dbConnection.State == ConnectionState.Closed) 
            //    { 
            //        dbConnection.Open();
            //    } 
            //    if (dbConnection.State == ConnectionState.Broken) 
            //    { 
            //        dbConnection.Close(); 
            //        dbConnection.Open(); 
            //    } 
            //    cmd = new OleDbCommand(); 
			
		}
        
}
