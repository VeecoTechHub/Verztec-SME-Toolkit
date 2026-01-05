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
using Microsoft.Win32;
using DBLinks;


/// <summary>
/// Summary description for CodeMaster_Logic.
/// </summary>
public class CodeMaster_Logic
{
    #region MEMBER VARIABLES
    /** //private String ConnectionString;**/
    private DAL dal;
    private DatabaseConnector dbConnection;
    private string CODE_ID;
    private string STATUS_TYPE;
    private string STATUS;
    private string STATUS_DESCRIPTION;
    private int SORT_ORDER;
    public string CREAT_BY;
    public System.DateTime CREAT_DT;
    public string MAINT_BY;
    public System.DateTime MAINT_DT;
    public string Sort_On;
    public int _value;
    public string _value2;
    public int _cstatus;
    private CommonFunctions CommonFunctions = new CommonFunctions();
    #endregion

    #region CONSTRUCTOR
    public CodeMaster_Logic()
    {
       /**this.ConnectionString = NusDataAccessLayer.GetConnectionString();//ConfigurationManager.AppSettings["OledbConnStr"];**/
        dal = new DAL();
    }
    #endregion

    #region PROPERTYS

    public int pro_SORT_ORDER
    {
        get
        {
            return SORT_ORDER;
        }
        set
        {
            if (value.ToString() == "")
            {
                SORT_ORDER = 0;
            }
            else
            {
                SORT_ORDER = value;
            }
        }
    }
    public string pro_STATUS_TYPE
    {
        get
        {
            return STATUS_TYPE;
        }
        set
        {
            if (value.ToString() == "")
            {
                STATUS_TYPE = "";
            }
            else
            {
                STATUS_TYPE = value;
            }
        }
    }


    public string pro_STATUS
    {
        get
        {
            return STATUS;
        }
        set
        {
            if (value.ToString() == "")
            {
                STATUS = "";
            }
            else
            {
                STATUS = value;
            }
        }
    }
    public string pro_STATUS_DESCRIPTION
    {
        get
        {
            return STATUS_DESCRIPTION;
        }
        set
        {
            if (value.ToString() == "")
            {
                STATUS_DESCRIPTION = "";
            }
            else
            {
                STATUS_DESCRIPTION = value;
            }
        }
    }
    public string pro_CODE_ID
    {
        get
        {
            return CODE_ID;
        }
        set
        {
            if (value.ToString() == "")
            {
                CODE_ID = "";
            }
            else
            {
                CODE_ID = value;
            }
        }
    }

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value.ToString() == "")
            {
                _value = 0;
            }
            else
            {
                _value = value;
            }
        }
    }

    public string Value2
    {
        get
        {
            return _value2;
        }
        set
        {
            _value2 = value;
        }
    }

    public int CStatus
    {
        get
        {
            return _cstatus;
        }
        set
        {
            if (value.ToString() == "")
            {
                _cstatus = 0;
            }
            else
            {
                _cstatus = value;
            }
        }
    }

    #endregion

    #region GETTING CODEMASTER DATA
    public DataSet GetCodeMasterAll()
    {
        //string STRSQL = "SELECT code_id,STS_TYPE,STS,STS_DESCR,Sort_Order,val,Val2,Code_Sts  from AWC_ADM_CODEMASTER ";


        //if (!String.IsNullOrEmpty(STATUS_TYPE) && (!String.IsNullOrEmpty(STATUS)))
        //{
        //    STRSQL = STRSQL + " where STS_TYPE like '" + STATUS_TYPE + "' and STS like '%" + STATUS + "%'";
        //}
        //else if ((STATUS_TYPE != "" && STATUS_TYPE != null))
        //{
        //    STRSQL = STRSQL + " where code_sts in (1,2) and STS_TYPE like '" + STATUS_TYPE + "'";
        //}
        //else if (!String.IsNullOrEmpty(STATUS))
        //{
        //    STRSQL = STRSQL + " where  STS like '%" + STATUS + "%'";
        //}
        //if (HttpContext.Current.Session["Role"] != null)
        //{
        //    if (HttpContext.Current.Session["Role"].ToString().ToLower() != "res")
        //    {
        //        STRSQL = STRSQL + " And  Value2 not like '%" + "T" + "%'";
        //    }
        //}
        //if (!String.IsNullOrEmpty(Sort_On))
        //{
        //    STRSQL = STRSQL + " ORDER BY " + Sort_On;
        //}
        //else
        //{
        //    STRSQL = STRSQL + " ORDER BY STS_TYPE,Sort_Order";
        //}



        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_CODEMASTER_All", ConnectionString);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_sts_type", OleDbType.VarChar).Value = (STATUS_TYPE == null) ? "" : STATUS_TYPE;
        OledbDa.SelectCommand.Parameters.Add("var_sts", OleDbType.VarChar).Value = (STATUS == null) ? "" : STATUS;
        OledbDa.SelectCommand.Parameters.Add("var_session_role", OleDbType.VarChar).Value = (HttpContext.Current.Session["Role"] != null) ? HttpContext.Current.Session["Role"].ToString() : "NULL";
        OledbDa.SelectCommand.Parameters.Add("var_Sort_On", OleDbType.VarChar).Value = (Sort_On == null) ? "" : Sort_On;
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        return dsTemp;
        **/

        SqlParameter[] parameter = new SqlParameter[6];
        parameter[0] = CommonFunctions.MakeParam("@pvar_sts_type", SqlDbType.VarChar, 50, ParameterDirection.Input, (STATUS_TYPE == null) ? "" : STATUS_TYPE);
        parameter[1] = CommonFunctions.MakeParam("@pvar_sts", SqlDbType.VarChar, 50, ParameterDirection.Input, (STATUS == null) ? "" : STATUS);
        parameter[2] = CommonFunctions.MakeParam("@pvar_session_role", SqlDbType.VarChar, 50, ParameterDirection.Input, (HttpContext.Current.Session["Role"] != null) ? HttpContext.Current.Session["Role"].ToString() : "NULL");
        parameter[3] = CommonFunctions.MakeParam("@pvar_Sort_On", SqlDbType.VarChar, 50, ParameterDirection.Input, (Sort_On == null) ? "" : Sort_On);
        parameter[4] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "SearchCodes");
        parameter[5] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        //////return DAL.GetListWithParam("[AWC_SP_GET_CODEMASTER_All]", parameter);
        return DAL.GetListWithParam("[Usp_CodeMasterMgmt]", parameter);





    }
    #endregion

    //public DataSet getStatus()
    //{
    //    string STRSQL = "select StatusId,StatusDescription from TB_Status where statusID in (1,2)";

    //    DataSet dsTemp;
    //    dsTemp = dbConnection.getDataSet(STRSQL);
    //    return dsTemp;
    //}

    #region GETTING STATUS FROM THE CODEMASTER
    public DataSet getCODESTATUSMASTER()
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_CODEMASTER_STS", ConnectionString);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        return dsTemp;
        **/
        //////return DAL.GetList("[AWC_SP_GET_CODEMASTER_STS]");
        SqlParameter[] parameter = new SqlParameter[2];
        parameter[0] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetStatusCodes");
        parameter[1] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        return DAL.GetListWithParam("[Usp_CodeMasterMgmt]",parameter);
    }
    #endregion

    //public string getStatusCodeValue(String Code)
    //{

    //    //return dsTemp;
    //    //string STRSQL = "select StatusDescription from Tb_Status where statusID =" + Code;

    //    //DataSet dsTemp;
    //    //dsTemp = dbConnection.getDataSet(STRSQL);
    //    return dsTemp.Tables[0].Rows[0][0].ToString();
    //}

    #region GETIING CODE STATUS BY CODE ID
    public string GetCode_Status(string codeID)
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_CODESTS_BY_CODEID", ConnectionString);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_code_id", OleDbType.VarChar).Value = codeID;
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        if (dsTemp.Tables[0].Rows.Count.Equals(1))
            return dsTemp.Tables[0].Rows[0][0].ToString();
        else return "null";
        **/

        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pvar_code_id", SqlDbType.VarChar, 50, ParameterDirection.Input, codeID);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetCodeDetails");
        parameter[2] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        DataSet dsTemp = new DataSet();
        //////dsTemp = DAL.GetListWithParam("[AWC_SP_GET_CODESTS_BY_CODEID]", parameter);
        dsTemp = DAL.GetListWithParam("[Usp_CodeMasterMgmt]", parameter);
        if (dsTemp.Tables[0].Rows.Count.Equals(1))
            return dsTemp.Tables[0].Rows[0][0].ToString();
        else return "null";


    }
    #endregion

    #region ADDING CODE MASTER
    public void addCodeMaster()
    {

        //string strSQL;
        //strSQL = "INSERT INTO AWC_ADM_CODEMASTER(code_id,STS_TYPE,STS,STS_DESCR,Code_Sts,Sort_Order,CREAT_BY,CREAT_DT,VALUE,Value2)"; 
        //strSQL = strSQL + " VALUES (";
        //strSQL = strSQL + "'" + CODE_ID + "',";
        //strSQL = strSQL + "'" + delQuote(STATUS_TYPE) + "',";
        //strSQL = strSQL + "'" + delQuote(STATUS) + "',";
        //strSQL = strSQL + "'" + delQuote(STATUS_DESCRIPTION) + "',";
        //strSQL = strSQL + "'" + CStatus + "',";
        //strSQL = strSQL + "'" + SORT_ORDER + "',";
        //strSQL = strSQL + "'" + delQuote(CREAT_BY) + "',";
        //strSQL = strSQL + "'" + System.DateTime.Now + "',";
        //strSQL = strSQL + "'" + Value + "',";
        //strSQL = strSQL + "'" + Value2 + "')";

        /**
        OleDbConnection OLECON = new OleDbConnection(ConnectionString);
        OleDbCommand OLECMD = new OleDbCommand("AWC_SP_GET_CODEMASTER_INSERT", OLECON);
        OLECMD.CommandType = CommandType.StoredProcedure;
        OLECMD.Parameters.Add("var_code_id", OleDbType.VarChar).Value = CODE_ID;
        OLECMD.Parameters.Add("var_sts_type", OleDbType.VarChar).Value = delQuote(STATUS_TYPE);
        OLECMD.Parameters.Add("var_sts", OleDbType.VarChar).Value = delQuote(STATUS);
        OLECMD.Parameters.Add("var_sts_descr", OleDbType.VarChar).Value = delQuote(STATUS_DESCRIPTION);
        OLECMD.Parameters.Add("var_code_sts", OleDbType.Integer).Value = CStatus;
        OLECMD.Parameters.Add("var_sort_order", OleDbType.Integer).Value = SORT_ORDER;
        OLECMD.Parameters.Add("var_created_by", OleDbType.VarChar).Value = delQuote(CREAT_BY);
        OLECMD.Parameters.Add("var_value", OleDbType.Integer).Value = Value;
        OLECMD.Parameters.Add("var_value2", OleDbType.VarChar).Value = Value2;
        OLECON.Open();
        OLECMD.ExecuteNonQuery();
        OLECON.Close();
        **/
        //dbConnection.runSQL(strSQL); 



        SqlParameter[] parameter = new SqlParameter[11];
        parameter[0] = CommonFunctions.MakeParam("@pvar_code_id", SqlDbType.VarChar, 50, ParameterDirection.Input, CODE_ID);
        parameter[1] = CommonFunctions.MakeParam("@pvar_sts_type", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(STATUS_TYPE));
        parameter[2] = CommonFunctions.MakeParam("@pvar_sts", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(STATUS));
        parameter[3] = CommonFunctions.MakeParam("@pvar_sts_descr", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(STATUS_DESCRIPTION));
        parameter[4] = CommonFunctions.MakeParam("@pvar_code_sts", SqlDbType.Int, 50, ParameterDirection.Input, CStatus);
        parameter[5] = CommonFunctions.MakeParam("@pvar_sort_order", SqlDbType.Int, 50, ParameterDirection.Input, SORT_ORDER);
        parameter[6] = CommonFunctions.MakeParam("@pvar_created_by", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(CREAT_BY));
        parameter[7] = CommonFunctions.MakeParam("@pvar_value", SqlDbType.Int, 50, ParameterDirection.Input, Value);
        parameter[8] = CommonFunctions.MakeParam("@pvar_value2", SqlDbType.VarChar, 50, ParameterDirection.Input, Value2.ToString());
        parameter[9] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "AddCodeMaster");
        parameter[10] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        //////return DAL.DBExecNonQuery("[AWC_SP_GET_CODEMASTER_INSERT]", parameter);
        DAL.DBExecNonQuery("[Usp_CodeMasterMgmt]", parameter);


    }
    #endregion

    private object CheckDBNULL(int parVal)
    {
        if (parVal.Equals(0))
            return DBNull.Value;
        else
            return parVal;

    }

    #region UPDATING CODE MASTER
    public void Update_CodeMaster()
    {
        //string strSQL;
        //strSQL = "Update AWC_ADM_CODEMASTER set STS_TYPE='" + CommonFunctions.delQuote(STATUS_TYPE) + "',";
        //strSQL = strSQL + " STS='" + CommonFunctions.delQuote(STATUS) + "', "; 
        //strSQL = strSQL + " STS_DESCR='" + CommonFunctions.delQuote(STATUS_DESCRIPTION) + "' ,";
        //strSQL = strSQL + "Code_Sts = '" + CheckDBNULL(CStatus) + "',";
        //strSQL = strSQL + " Sort_Order='" + SORT_ORDER + "' ,"; 
        //strSQL = strSQL + " MAINT_BY='" + CommonFunctions.delQuote(MAINT_BY) + "', ";
        //strSQL = strSQL + " MAINT_DT='" + System.DateTime.Now + "', "; 
        //strSQL = strSQL + " VAL='" +  Value + "' ,";
        //strSQL = strSQL + " VAL2='" + Value2 + "' ";
        //strSQL = strSQL + " where code_id='" + CommonFunctions.delQuote(CODE_ID)+ "'"; 
        //dbConnection.runSQL(strSQL);


        /**
        OleDbConnection OLECON = new OleDbConnection(ConnectionString);
        OleDbCommand OLECMD = new OleDbCommand("AWC_SP_CODEMASTER_UPDATE", OLECON);
        OLECMD.CommandType = CommandType.StoredProcedure;
        OLECMD.Parameters.Add("var_code_id", OleDbType.VarChar).Value = CODE_ID;
        OLECMD.Parameters.Add("var_sts_type", OleDbType.VarChar).Value = CommonFunctions.delQuote(STATUS_TYPE);
        OLECMD.Parameters.Add("var_sts", OleDbType.VarChar).Value = CommonFunctions.delQuote(STATUS);
        OLECMD.Parameters.Add("var_sts_descr", OleDbType.VarChar).Value = CommonFunctions.delQuote(STATUS_DESCRIPTION);
        OLECMD.Parameters.Add("var_code_sts", OleDbType.Integer).Value = CStatus;
        OLECMD.Parameters.Add("var_sort_order", OleDbType.Integer).Value = SORT_ORDER;
        OLECMD.Parameters.Add("var_maint_by", OleDbType.VarChar).Value = CommonFunctions.delQuote(MAINT_BY);
        OLECMD.Parameters.Add("var_value", OleDbType.Integer).Value = Value;
        OLECMD.Parameters.Add("var_value2", OleDbType.VarChar).Value = Value2;
        OLECON.Open();
        OLECMD.ExecuteNonQuery();
        OLECON.Close();
        **/


        SqlParameter[] parameter = new SqlParameter[11];
        parameter[0] = CommonFunctions.MakeParam("@pvar_code_id", SqlDbType.VarChar, 50, ParameterDirection.Input, CODE_ID);
        parameter[1] = CommonFunctions.MakeParam("@pvar_sts_type", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(STATUS_TYPE));
        parameter[2] = CommonFunctions.MakeParam("@pvar_sts", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(STATUS));
        parameter[3] = CommonFunctions.MakeParam("@pvar_sts_descr", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(STATUS_DESCRIPTION));
        parameter[4] = CommonFunctions.MakeParam("@pvar_code_sts", SqlDbType.Int, 50, ParameterDirection.Input, CStatus);
        parameter[5] = CommonFunctions.MakeParam("@pvar_sort_order", SqlDbType.Int, 50, ParameterDirection.Input, SORT_ORDER);
        parameter[6] = CommonFunctions.MakeParam("@pvar_maint_by", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(MAINT_BY));
        parameter[7] = CommonFunctions.MakeParam("@pvar_value", SqlDbType.Int, 50, ParameterDirection.Input, Value);
        //parameter[8] = CommonFunctions.MakeParam("@pvar_value2", SqlDbType.Int, 50, ParameterDirection.Input, Value2);
        parameter[8] = CommonFunctions.MakeParam("@pvar_value2", SqlDbType.VarChar, 50, ParameterDirection.Input, Value2.ToString());
        parameter[9] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "UpdateCodeMaster");
        parameter[10] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        //////return DAL.DBExecNonQuery("[AWC_SP_CODEMASTER_UPDATE]", parameter);
       DAL.DBExecNonQuery("[Usp_CodeMasterMgmt]", parameter);



    }
    #endregion

    #region DELETING CODEMASTER
    public void Delete_CodeMaster(string SID)
    {
        /**
        OleDbConnection OLECON = new OleDbConnection(ConnectionString);
        OleDbCommand OLECMD = new OleDbCommand("AWC_SP_GET_CODEMASTER_DELETE", OLECON);
        OLECMD.CommandType = CommandType.StoredProcedure;
        OLECMD.Parameters.Add("var_code_id", OleDbType.VarChar).Value = CommonFunctions.delQuote(SID);
        OLECON.Open();
        OLECMD.ExecuteNonQuery();
        OLECON.Close();
        //dbConnection.runSQL("DELETE FROM AWC_ADM_CODEMASTER WHERE code_id ='" + CommonFunctions.delQuote(SID) + "'"); 
        **/



        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pvar_code_id", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(SID));
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "DeleteCode");
        parameter[2] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);

        //////DAL.DBExecNonQuery("[AWC_SP_GET_CODEMASTER_DELETE]", parameter);
        DAL.DBExecNonQuery("[Usp_CodeMasterMgmt]", parameter);
    }
    #endregion

    private string delQuote(string str)
    {
        return ((str.Trim()).Replace("'", "''"));
    }

    private int delQuoteint(int id)
    {
        return id;
    }

}


