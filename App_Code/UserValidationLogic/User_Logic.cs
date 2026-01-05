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
/// Summary description for User_Logic
/// </summary>
public class User_Logic
{
    #region Variable Declaration
    private DAL dal;
    private String ConnectionString;
    private DatabaseConnector dbConnection;
    public string COMPANY_ID;
    public string USER_ID;
    public string USER_NM;
    public string OUTLET_CD;
    public string GROUP_ID;
    public string EMAIL_ID;
    public string TEL_NO;
    public string PSWD;
    public string NPSWD;
    public string ACTIVE_IND;
    public string CREAT_BY;
    public System.DateTime CREAT_DT;
    public string MAINT_BY;
    public System.DateTime MAINT_DT;
    public string Sort_On;
    public string Sort_Direction;
    private int User_Num_Logins;
    private string User_Logins_Update;
    private string desg;
    private string roleid;
    private string deptid;

    private CommonFunctions CommonFunctions = new CommonFunctions();
    #endregion

    #region Constructor
    public User_Logic()
    {
        // this.dbConnection = new DatabaseConnector();
        //this.ConnectionString = NusDataAccessLayer.GetConnectionString();// ConfigurationManager.AppSettings["OledbConnStr"];
        dal = new DAL();
    }
    #endregion

    #region Properties
    public string Creatby
    {
        get
        {
            return CREAT_BY;
        }
        set
        {
            if (value.ToString() == "")
            {
                CREAT_BY = "1";
            }
            else
            {
                CREAT_BY = value;
            }
        }
    }
    public string maintby
    {
        get
        {
            return MAINT_BY;
        }
        set
        {
            if (value.ToString() == "")
            {
                MAINT_BY = "";
            }
            else
            {
                MAINT_BY = value;
            }
        }
    }

    public string Desg
    {
        get
        {
            return desg;
        }
        set
        {
            desg = value;

        }
    }

    public string UserID
    {
        get
        {
            return USER_ID;
        }
        set
        {
            if (value.ToString() == "")
            {
                USER_ID = "";
            }
            else
            {
                USER_ID = value;
            }
        }
    }
    public string COMPANYID
    {
        get
        {
            return COMPANY_ID;
        }
        set
        {
            if (value.ToString() == "")
            {
                COMPANY_ID = "";
            }
            else
            {
                COMPANY_ID = value;
            }
        }
    }
    public string UserName
    {
        get
        {
            return USER_NM;
        }
        set
        {
            if (value.ToString() == "")
            {
                USER_NM = "";
            }
            else
            {
                USER_NM = value;
            }
        }
    }
    public string CompanyCode
    {
        get
        {
            return OUTLET_CD;
        }
        set
        {
            if (value.ToString() == "")
            {
                OUTLET_CD = "";
            }
            else
            {
                OUTLET_CD = value;
            }
        }
    }
    public string GroupID
    {
        get
        {
            return GROUP_ID;
        }
        set
        {
            if (value.ToString() == "")
            {
                GROUP_ID = "";
            }
            else
            {
                GROUP_ID = value;
            }
        }
    }
    public string UserEmail
    {
        get
        {
            return EMAIL_ID;
        }
        set
        {
            if (value.ToString() == "")
            {
                EMAIL_ID = "";
            }
            else
            {
                EMAIL_ID = value;
            }
        }
    }
    public string Telephone
    {
        get
        {
            return TEL_NO;
        }
        set
        {
            if (value.ToString() == "")
            {
                TEL_NO = "";
            }
            else
            {
                TEL_NO = value;
            }
        }
    }
    public string UserPassword
    {
        get
        {
            return PSWD;
        }
        set
        {
            if (value.ToString() == "")
            {
                PSWD = "";
            }
            else
            {
                PSWD = value;
            }
        }
    }
    public string newPassword
    {
        get
        {
            return NPSWD;
        }
        set
        {
            if (value.ToString() == "")
            {
                NPSWD = "";
            }
            else
            {
                NPSWD = value;
            }
        }
    }
    public string UserActive
    {
        get
        {
            return ACTIVE_IND;
        }
        set
        {
            if (value.ToString() == "")
            {
                ACTIVE_IND = "";
            }
            else
            {
                ACTIVE_IND = value;
            }
        }
    }

    public string DeptID
    {
        get
        {
            return deptid;
        }
        set
        {
            if (value.ToString() == "")
            {
                deptid = "";
            }
            else
            {
                deptid = value;
            }
        }
    }

    public int NumLogins
    {
        get
        {
            return User_Num_Logins;
        }
        set
        {

            User_Num_Logins = value;

        }
    }

    //Present user LoginUpdation
    public string LoginsUpdate
    {
        get { return User_Logins_Update; }
        set
        {
            if (value.ToString() == null) { User_Logins_Update = ""; }
            else { User_Logins_Update = value; }
        }
    }

    #endregion

    #region get all groups
    public DataSet GetAllGroups(string curgroup)
    {
       

        DataSet DS_Temp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pCurrentGroup", SqlDbType.VarChar, 50, ParameterDirection.Input, curgroup);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetAllGroups");
        parameter[2] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");
        DS_Temp = DAL.GetListWithParam("[Usp_UserMgmt]", parameter);
        return DS_Temp;


      
    }

    #endregion

    #region delete users
    public void Delete_Users(string USER_IDs)
    {
        
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pUserIds", SqlDbType.VarChar, 1000, ParameterDirection.Input, USER_IDs);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "DeleteUsers");
        parameter[2] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");
        DAL.DBExecNonQuery("[Usp_UserMgmt]", parameter);


    }
    #endregion

    #region GETUSER
    public void GetUsers(string USER_ID)
    {

        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pUserId", SqlDbType.VarChar, 50, ParameterDirection.Input, USER_ID);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetUsers");
        parameter[2] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");
        dsTemp = DAL.GetListWithParam("[Usp_UserMgmt]", parameter);


        DataRow drTemp;
        if (dsTemp.Tables[0].Rows.Count > 0)
        {
            drTemp = dsTemp.Tables[0].Rows[0];
            UserName = drTemp["USER_NM"].ToString();
            UserID = USER_ID;
            Telephone = drTemp["tel_no"].ToString();
            CompanyCode = drTemp["OUTLET_CD"].ToString();
            Desg = drTemp["Desg"].ToString();
            GroupID = drTemp["GROUP_ID"].ToString();
            UserEmail = drTemp["EMAIL_ID"].ToString();
            UserPassword = CommonFunctions.EncryptText(drTemp["PSWD"].ToString());
            UserActive = drTemp["ACTIVE_IND"].ToString();
        }
    }
    #endregion

    #region getting_all_users
    public DataSet GetUsersAll(string curgroup)
    {
        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[7];
        parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, GROUP_ID);
        parameter[1] = CommonFunctions.MakeParam("@pUserId", SqlDbType.VarChar, 50, ParameterDirection.Input, USER_ID);
        parameter[2] = CommonFunctions.MakeParam("@pUserName", SqlDbType.VarChar, 50, ParameterDirection.Input, USER_NM);
        parameter[3] = CommonFunctions.MakeParam("@pCurrentGroup", SqlDbType.VarChar, 50, ParameterDirection.Input, curgroup);
        parameter[4] = CommonFunctions.MakeParam("@pSort_On", SqlDbType.VarChar, 50, ParameterDirection.Input, Sort_On);
        parameter[5] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetAllUsers");
        parameter[6] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");
        dsTemp = DAL.GetListWithParam("[Usp_UserMgmt]", parameter);
        return dsTemp;

    }
    #endregion

    #region checking_duplicate_users

    public bool Check_Duplicate(string Str_Val)
    {

        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pUserId", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Val);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "CheckDuplicateUsers");
        parameter[2] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");


        dsTemp = DAL.GetListWithParam("[Usp_UserMgmt]", parameter);

        if (Convert.ToInt32(dsTemp.Tables[0].Rows[0][0]) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    #endregion

    #region removing quotations
    private string delQuote(string str)
    {
        return ((str.Trim()).Replace("'", "''"));
    }
    #endregion

    #region adding new staff
    public void addUsers()
    {
        SqlParameter[] parameter = new SqlParameter[12];
        parameter[0] = CommonFunctions.MakeParam("@pUserId", SqlDbType.VarChar, 50, ParameterDirection.Input, UserID);
        parameter[1] = CommonFunctions.MakeParam("@pUserName", SqlDbType.VarChar, 50, ParameterDirection.Input, UserName);
        parameter[2] = CommonFunctions.MakeParam("@pDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, Desg);
        parameter[3] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, GroupID);
        parameter[4] = CommonFunctions.MakeParam("@pEmailId", SqlDbType.VarChar, 50, ParameterDirection.Input, UserEmail);
        parameter[5] = CommonFunctions.MakeParam("@pTelephoneNo", SqlDbType.VarChar, 50, ParameterDirection.Input, Telephone);
        parameter[6] = CommonFunctions.MakeParam("@pPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.EncryptText(delQuote(UserPassword)));
        parameter[7] = CommonFunctions.MakeParam("@pIsActive", SqlDbType.VarChar, 50, ParameterDirection.Input, UserActive);
        parameter[8] = CommonFunctions.MakeParam("@pCreated_by", SqlDbType.VarChar, 50, ParameterDirection.Input, CREAT_BY);
        parameter[9] = CommonFunctions.MakeParam("@pMaint_by", SqlDbType.VarChar, 50, ParameterDirection.Input, MAINT_BY);
        parameter[10] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "AddUser");
        parameter[11] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");
        DAL.DBExecNonQuery("[Usp_UserMgmt]", parameter);
        
    }
    #endregion

    #region UPDATE STAFF
    public void Update_Users()
    {
        SqlParameter[] parameter = new SqlParameter[11];
        parameter[0] = CommonFunctions.MakeParam("@pUserId", SqlDbType.VarChar, 50, ParameterDirection.Input, UserID);
        parameter[1] = CommonFunctions.MakeParam("@pUserName", SqlDbType.VarChar, 50, ParameterDirection.Input, UserName);
        parameter[2] = CommonFunctions.MakeParam("@pDesignation", SqlDbType.VarChar, 50, ParameterDirection.Input, Desg);
        parameter[3] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, GroupID);
        parameter[4] = CommonFunctions.MakeParam("@pEmailId", SqlDbType.VarChar, 50, ParameterDirection.Input, UserEmail);
        parameter[5] = CommonFunctions.MakeParam("@pTelephoneNo", SqlDbType.VarChar, 50, ParameterDirection.Input, Telephone);
        parameter[6] = CommonFunctions.MakeParam("@pPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, UserPassword);
        parameter[7] = CommonFunctions.MakeParam("@pIsActive", SqlDbType.VarChar, 50, ParameterDirection.Input, UserActive);
        parameter[8] = CommonFunctions.MakeParam("@pMaint_by", SqlDbType.VarChar, 50, ParameterDirection.Input, MAINT_BY);
        parameter[9] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "UpdateUser");
        parameter[10] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");
        DAL.DBExecNonQuery("[Usp_UserMgmt]", parameter);

    }
    #endregion

    #region Checking user id
    public string CheckUserID()
    {
        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[4];
        parameter[0] = CommonFunctions.MakeParam("@pUserId", SqlDbType.VarChar, 50, ParameterDirection.Input, UserID);
        parameter[1] = CommonFunctions.MakeParam("@pPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, UserPassword);
        parameter[2] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "CheckUserID");
        parameter[3] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");
        dsTemp=DAL.GetListWithParam("[Usp_UserMgmt]", parameter);

        int drTemp;
        try
        {
            drTemp = dsTemp.Tables[0].Rows.Count;
            if (drTemp > 0)
            {
                return "EXIST";
            }
            else
            {
                return "NOTEXIST";
            }
        }
        catch (Exception)
        {
            string strResult = "NORECORD";
            return strResult;
        }
    }
    #endregion

    #region UPDATING STAFF LOG IN CREDENTIALS
    public void Update_User()
    {
        SqlParameter[] parameter = new SqlParameter[5];
        parameter[0] = CommonFunctions.MakeParam("@pUserId", SqlDbType.VarChar, 50, ParameterDirection.Input, UserID);
        parameter[1] = CommonFunctions.MakeParam("@pPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, UserPassword);
        parameter[2] = CommonFunctions.MakeParam("@pNewPassword", SqlDbType.VarChar, 50, ParameterDirection.Input, newPassword);
        parameter[3] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "ChangePassword");
        parameter[4] = CommonFunctions.MakeParam("@pOpStatus", SqlDbType.Int, 50, ParameterDirection.Output, "");
        DAL.DBExecNonQuery("[Usp_UserMgmt]", parameter);
    }
    #endregion

    public DataSet GetUserDetailsByGroup(string Group)
    {
        /**
        string STRSQL = "SELECT USER_ID, USER_NM,EMAIL_ID, u.GROUP_ID as GROUPID,g.GROUP_DESCR as GROUPDESC FROM AWC_ADM_STAFF u, AWC_ADM_GROUPS g WHERE U.GROUP_ID=g.GROUP_ID and U.GROUP_ID='" + Group + "'";

        OleDbDataAdapter OledbDa = new OleDbDataAdapter(STRSQL, ConnectionString);
        OledbDa.SelectCommand.CommandType = CommandType.Text;
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        return dsTemp;
        **/
        return null;
    }


    /// <summary>
    ///for httpcontext.current.session values
    /// </summary>
    public static string sessionU_ID
    {
        get { return HttpContext.Current.Session["USER_GUID"] == null ? string.Empty : HttpContext.Current.Session["USER_GUID"].ToString().ToUpper(); }
        set { HttpContext.Current.Session["USER_GUID"] = value; }
    }

    //public static string sessionUserId
    //{
    //    get { return HttpContext.Current.Session["UserId"] == null ? string.Empty : HttpContext.Current.Session["USER_ID"].ToString().ToUpper(); }
    //    set { HttpContext.Current.Session["UserId"] = value; }
    //}

    //public static string sessionGROUPID
    //{
    //    get { return HttpContext.Current.Session["GROUP_ID"] == null ? string.Empty : HttpContext.Current.Session["GROUP_ID"].ToString().ToUpper(); }
    //    set { HttpContext.Current.Session["GROUP_ID"] = value; }
    //}

    public static string sessionUSERName
    {
        get { return HttpContext.Current.Session["USER_ID"] == null ? string.Empty : HttpContext.Current.Session["USER_ID"].ToString().ToUpper(); }
        set { HttpContext.Current.Session["USER_ID"] = value; }
    }

}
