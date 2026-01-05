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
/// Summary description for Status_Logic
/// </summary>
public class Status_Logic
{
    /**private  NusDAL.NusDataAccessLayer NusDal = new NusDAL.NusDataAccessLayer();**/
    private string S_ID;
    private int STATUS_ID;
    private string STATUS_DESCRIPTION;
    public string Sort_On;
    private CommonFunctions CommonFunctions = new CommonFunctions();
  
    public int pro_STATUS_ID
    {
        get
        {
            return STATUS_ID;
        }
        set
        {
            if (value.ToString() == "")
            {
                STATUS_ID = 0;
            }
            else
            {
                STATUS_ID = value;
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

    public string pro_S_ID
    {
        get
        {
            return S_ID;
        }
        set
        {
            if (value.ToString() == "")
            {
                S_ID = "";
            }
            else
            {
                S_ID = value;
            }
        }
    }

    public DataSet GetStatusAll()
    {

        /**
        string STRSQL = "SELECT *  from AWC_NAV_STS ";


        if (STATUS_DESCRIPTION != "")
        {
            STRSQL = STRSQL + " where STS_DESC like '%" + STATUS_DESCRIPTION + "%'";
        }


        if (Sort_On != "")
        {
            STRSQL = STRSQL + " ORDER BY " + Sort_On;
        }
        else
        {
            STRSQL = STRSQL + " ORDER BY STS_ID";
        }
        DataSet dsTemp;
        dsTemp = NusDal.getDataSet(STRSQL);
        return dsTemp;

        **/

        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[4];
        parameter[0] = CommonFunctions.MakeParam("@pStatusDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, STATUS_DESCRIPTION);
        parameter[1] = CommonFunctions.MakeParam("@pSort_On", SqlDbType.VarChar, 50, ParameterDirection.Input, Sort_On);
        parameter[2] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetAllStatus");
        parameter[3] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, 2);
        dsTemp = DAL.GetListWithParam("[Usp_StatusMgmt]", parameter);
        return dsTemp;
    }

    public void addStatus()
    {
        /**
        string strSQL;
        strSQL = "INSERT INTO AWC_NAV_STS(S_ID,STS_ID,STS_DESC)";
        strSQL = strSQL + " VALUES ('"+System.Guid.NewGuid()+"',";
        strSQL = strSQL + "'" + delQuoteint(STATUS_ID) + "',";
        strSQL = strSQL + "'" + delQuote(STATUS_DESCRIPTION) + "')";

        NusDal.runSql(strSQL);

        **/

        SqlParameter[] parameter = new SqlParameter[5];
        parameter[0] = CommonFunctions.MakeParam("@pSId", SqlDbType.VarChar, 50, ParameterDirection.Input, System.Guid.NewGuid().ToString());
        parameter[1] = CommonFunctions.MakeParam("@pStatusId", SqlDbType.VarChar, 50, ParameterDirection.Input, STATUS_ID);
        parameter[2] = CommonFunctions.MakeParam("@pStatusDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, STATUS_DESCRIPTION);
        parameter[3] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "AddStatus");
        parameter[4] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, 2);
        DAL.DBExecNonQuery("[Usp_StatusMgmt]", parameter);
    }

    public void Update_Status()
    {
        /**
        string strSQL;
        strSQL = "Update AWC_NAV_STS set STS_ID='" + CommonFunctions.delQuoteint(STATUS_ID) + "',";
        strSQL = strSQL + " STS_DESC='" + CommonFunctions.delQuote(STATUS_DESCRIPTION) + "' ";
        strSQL = strSQL + " where S_ID='" + CommonFunctions.delQuote(S_ID) + "'";
        NusDal.runSql(strSQL);
        **/

        SqlParameter[] parameter = new SqlParameter[5];
        parameter[0] = CommonFunctions.MakeParam("@pSId", SqlDbType.VarChar, 50, ParameterDirection.Input, S_ID);
        parameter[1] = CommonFunctions.MakeParam("@pStatusId", SqlDbType.VarChar, 50, ParameterDirection.Input, STATUS_ID);
        parameter[2] = CommonFunctions.MakeParam("@pStatusDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, STATUS_DESCRIPTION);
        parameter[3] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "UpdateStatus");
        parameter[4] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, 2);
        DAL.DBExecNonQuery("[Usp_StatusMgmt]", parameter);
    }
    public void Delete_Status(string SID)
    {
        /**NusDal.runSql("DELETE FROM AWC_NAV_STS WHERE S_ID ='" + CommonFunctions.delQuote(SID) + "'");**/
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pSId", SqlDbType.VarChar, 50, ParameterDirection.Input, SID);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "DeleteStatus");
        parameter[2] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, 2);
        DAL.DBExecNonQuery("[Usp_StatusMgmt]", parameter);
    }
    private string delQuote(string str)
    {
        return ((str.Trim()).Replace("'", "''"));
    }
    private int delQuoteint(int id)
    {
        return id;
    }
}
