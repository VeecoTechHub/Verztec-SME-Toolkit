using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


namespace DBLinks
{
    /// <summary>
    /// Summary description for DAL
    /// </summary>
    public class DAL
    {
        //public DAL()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}
        public static SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        public static DataSet ds = new DataSet();

        #region To Get the Data in a Dataset without using parameters

        public static DataSet GetList(string strCommandText)
        {
            try
            {
                Open();
                SqlDataAdapter adpt = new SqlDataAdapter();
                SqlCommand cmdList = new SqlCommand(strCommandText, Con);

                adpt.SelectCommand = cmdList;

                cmdList.CommandType = CommandType.StoredProcedure;
                cmdList.CommandTimeout = 60;

                DataSet dsList = new DataSet();
                adpt.Fill(dsList);
                return dsList;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                return null;
            }
        }
        #endregion

        #region To Get the Data from a Dataset by Passing Parameters
        public static DataSet GetListWithParam(string txtCmd, SqlParameter[] inParams)
        {
            try
            {
                if (Con.State != ConnectionState.Closed)
                    Con.Close();
                Con.Open();

                SqlDataAdapter adpt = new SqlDataAdapter();
                SqlCommand cmdList = new SqlCommand(txtCmd, Con);

                adpt.SelectCommand = cmdList;

                cmdList.CommandType = CommandType.StoredProcedure;
                cmdList.CommandTimeout = 60;
                cmdList.Parameters.Clear();

                if (inParams != null)
                {
                    foreach (SqlParameter parameter in inParams)
                    {
                        cmdList.Parameters.Add(parameter);
                    }
                }

                DataSet dsListParam = new DataSet();
                //if (dsListParam != null)
                //	dsListParam =null;

                adpt.Fill(dsListParam);
                return dsListParam;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                return null;
            }
        }
        #endregion

        #region To Insert , Update and Delete

        public static bool DBExecNonQuery(string txtCmd, SqlParameter[] inParams)
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                //SqlParameter[] objsqlArray; 
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(txtCmd, Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                cmd.Parameters.Clear();
                if (inParams != null)
                {
                    foreach (SqlParameter parameter in inParams)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                object obj = cmd.ExecuteScalar();
                return true;
            }
            catch (System.Exception ex)
            {
                string str;
                str = ex.Message;
                return false;
            }
        }
        #endregion
        
        #region To fetch the records thru Datareader with out parameters

        public static SqlDataReader GetDataReaderRecsWithOutParams(string txtcmd)
        {
            SqlDataReader dr;

            try
            {
                if (Con.State != ConnectionState.Closed)
                    Con.Close();
                Con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(txtcmd, Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                dr = null;
                return dr;
                //Throw New Exception(Err_Code, exception)
            }
            ////			finally
            ////			{  
            ////				dr=null;
            ////				
            ////			}
        }

        #endregion


        #region To Insert Master and Detail
        #endregion


        #region To get the scalar output
        public object DBAccessScalarWithParam(string qry, SqlParameter[] inParams)
        {
            SqlCommand cmd = new SqlCommand();
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd = new SqlCommand(qry, Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            if (inParams != null)
            {
                foreach (SqlParameter parameter in inParams)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            object obj = cmd.ExecuteScalar();
            return obj;
        }
        #endregion
        #region To get the scalar output with param
        public object DBAccessScalar(string qry)
        {
            SqlCommand cmd = new SqlCommand();
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd = new SqlCommand(qry, Con);
            object obj = cmd.ExecuteScalar();
            return obj;
        }
        #endregion

        #region To get the Data thru DataReader by passing parameters
        public static SqlDataReader DBReader(string txtCmd, SqlParameter[] inParams)
        {
            SqlDataReader dr;

            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                SqlCommand cmd = new SqlCommand(txtCmd, Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Clear();
                if (inParams != null)
                {
                    foreach (SqlParameter parameter in inParams)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }

                dr = cmd.ExecuteReader();
                // Capturing the return value from the stored procedure
                // returncode = (int) (inParams[2].Value);
                return dr;
            }
            catch (Exception ex)
            {
                string str;
                str = ex.Message;
                dr = null;
                //Throw New Exception("E101", str);
                return dr;

            }
        }
        #endregion


        #region To open Connection
        static void Open()
        {
            // open connection
            if (Con.State != ConnectionState.Closed)
            { Con.Close(); }
            Con.Open();
            //Con = new SqlConnection(ConfigurationSettings.AppSettings["ConString"]);
            //Con.Open();
        }

        #endregion


        #region To Close the SQL Database Connection
        public void Close()
        {
            if (Con != null)
                Con.Close();
        }
        #endregion


        #region To Insert , Update and Delete with Transaction commit N rollback

        public static bool DBExecNonQuery1(string txtCmd, SqlParameter[] inParams)
        {
            try
            {
                SqlTransaction sqlTran;
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                //SqlParameter[] objsqlArray; 
                sqlTran = Con.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand(txtCmd, Con);
                cmd.Transaction = sqlTran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;

                cmd.Parameters.Clear();
                if (inParams != null)
                {
                    foreach (SqlParameter parameter in inParams)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                }
                try
                {
                    object obj = cmd.ExecuteScalar();
                    sqlTran.Commit();
                    return true;
                }
                catch (SqlException sqlEx)
                {
                    string strEx;
                    strEx = sqlEx.Message;
                    sqlTran.Rollback();
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                string str;
                str = ex.Message;
                return false;
            }
        }
        #endregion

        #region BatchTransaction
        public static bool BatchDBExecNonQueryText(string[] strSqlCmdText)//working fine
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            SqlTransaction sqlTran;
            SqlCommand dbCommand = new SqlCommand();
            sqlTran = Con.BeginTransaction();
            dbCommand.Connection = Con;
            dbCommand.Transaction = sqlTran;
            try
            {
                for (int i = 0; i < strSqlCmdText.Length; i++)
                {
                    if (strSqlCmdText[i] == null)
                    {
                        continue;
                    }
                    dbCommand.CommandText = strSqlCmdText[i].ToString();
                    dbCommand.ExecuteNonQuery();
                }
                //Commit Transactions 
                sqlTran.Commit();
                sqlTran = null;
                dbCommand.Dispose();
                dbCommand = null;
                Con = null;
                return true;
            }
            catch (Exception ex)
            {
                //Rollback Transactions
                sqlTran.Rollback();
                sqlTran = null;
                string str = ex.Message;
                dbCommand.Dispose();
                dbCommand = null;
                Con = null;
                return false;
            }
        }

        public static bool BatchDBExecNonQuerySP(string[] strSqlCmdProc)
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            SqlTransaction sqlTran;
            SqlCommand dbCommand = new SqlCommand();
            sqlTran = Con.BeginTransaction();
            dbCommand.Connection = Con;
            dbCommand.Transaction = sqlTran;
            try
            {
                for (int i = 0; i < strSqlCmdProc.Length; i++)
                {
                    if (strSqlCmdProc[i] == null)
                    {
                        continue;
                    }
                    dbCommand.CommandText = strSqlCmdProc[i].ToString();
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.ExecuteNonQuery();
                }
                //Commit Transactions 
                sqlTran.Commit();
                sqlTran = null;
                dbCommand.Dispose();
                dbCommand = null;
                Con = null;
                return true;
            }
            catch (Exception ex)
            {
                //Rollback Transactions
                sqlTran.Rollback();
                sqlTran = null;
                string str = ex.Message;
                dbCommand.Dispose();
                dbCommand = null;
                Con = null;
                return false;
            }
        }

        public static bool BatchDBExecNonQuerySPWithParams(SqlCommand[] sqlCmd)
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                SqlTransaction sqlTran = Con.BeginTransaction();
                try
                {
                    for (int i = 0; i < sqlCmd.Length; i++)
                    {
                        sqlCmd[i].Transaction = sqlTran;
                        sqlCmd[i].Connection = Con;
                        sqlCmd[i].ExecuteNonQuery();
                    }
                    sqlTran.Commit();
                    return true;
                }
                catch (SqlException sqlEx)
                {
                    sqlTran.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
        #region Test Region

        public SqlCommand ConstructSqlCmd(string sqlCmdText, SqlParameter[] inParams)
        {
            SqlCommand sqlCmd = new SqlCommand(sqlCmdText);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandTimeout = 60;
            sqlCmd.Parameters.Clear();
            if (inParams != null)
            {
                foreach (SqlParameter parameter in inParams)
                {
                    sqlCmd.Parameters.Add(parameter);
                }
            }
            return sqlCmd;
        }

        
        #endregion




    }
}
