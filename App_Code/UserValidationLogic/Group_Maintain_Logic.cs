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
/// Summary description for Group_Maintain_Logic
/// </summary>
public class Group_Maintain_Logic
{

    #region MEMBER VARIABLES
    private DAL dal;
    private CommonFunctions CommonFunctions = new CommonFunctions();
    //private string Connectionstring;
    //private string Str_Sql;
    private DataSet DS_Temp;
    public string Sort_On;
    public string Sort_On_Fun;
    public string GROUP_ID;
    public string GROUP_DESCR;
    public string DISC_PERCENT;
    public string EXTRA_FREE_PACKS;
    public string IS_ADMIN;
    public string CREAT_BY;
    public string CREAT_DT;
    public string MAINT_BY;
    public string MAINT_DT;
    public string Sort_Direction;
    private DataRow DR_Temp;
    /**private OleDbConnection dbConnectionNew;

    //private OleDbCommand dbCommand = new OleDbCommand();
    private OleDbTransaction T;**/
    #endregion

    #region Constructor
    public Group_Maintain_Logic()
    {
        //
        // TODO: Add constructor logic here
        //
        dal = new DAL();
    }
    #endregion

    #region GETTING FUNCTION LIST(THIS IS CALLED WHEN CLICK THE ADD BUTTON OF GROUP)
    public DataSet Get_Function_List(string curGroup)
    {
        #region CODE WITH SQL STMTS
        //Str_Sql = "SELECT DISTINCT f.FUNC_ID, f.SHRT_DESCR, DESCR, PARENT_MENU FROM AWC_ADM_FUNCTIONS f,AWC_ADM_GRP_FUNCTIONS gfp";

        //if (CommonFunctions.delQuote(GROUP_ID) != "")
        //{
        //    Str_Sql = Str_Sql + "GROUP_ID='%" + CommonFunctions.delQuote(GROUP_ID) + "%' AND ";
        //}
        //if (CommonFunctions.delQuote(GROUP_DESCR) != "")
        //{
        //    Str_Sql = Str_Sql + "GROUP_DESCR LIKE '%" + CommonFunctions.delQuote(GROUP_DESCR) + "%' AND ";
        //}

        //if (curGroup != "Tech Team")
        //{
        //    Str_Sql = Str_Sql + " WHERE  f.FUNC_ID = gfp.FUNC_ID(+) AND PARENT_MENU!='Administration' ";
        //}
        //else
        //{
        //    Str_Sql = Str_Sql + " WHERE  f.FUNC_ID = gfp.FUNC_ID(+)";
        //}


        //if (CommonFunctions.delQuote(GROUP_ID) != "" | CommonFunctions.delQuote(GROUP_DESCR) != "")
        //{
        //    Str_Sql = Str_Sql.Substring(1, (Str_Sql.Length) - 4);
        //}

        //Str_Sql = Str_Sql + " order by UPPER(parent_menu)"; 
        
        /**
            OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_GRP_FUNC_ALL", Connectionstring);
            OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            OledbDa.SelectCommand.Parameters.Add("var_grp_id", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_ID);
            OledbDa.SelectCommand.Parameters.Add("var_grp_descr", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_DESCR);
            OledbDa.SelectCommand.Parameters.Add("var_curGroup", OleDbType.VarChar).Value = curGroup; 
            DataSet DS_Temp = new DataSet();
            OledbDa.Fill(DS_Temp);
            return DS_Temp;

            **/


        DataSet DS_Temp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[4];
        parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_ID));
        parameter[1] = CommonFunctions.MakeParam("@pGroupDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_DESCR));
        parameter[2] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetFuntionList");
        parameter[3] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        DS_Temp = DAL.GetListWithParam("[Usp_GroupMgmt]", parameter);
        return DS_Temp;

        #endregion

    }
    #endregion

    #region Checking for duplicate groups
    public bool Check_duplicate(string str_val)
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_CHK_DUPLICATE_GROUPS", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_grp_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_grp_id"].Value = CommonFunctions.delQuote(str_val).ToString();
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        **/

        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_ID));
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "CheckDuplicateGroup");
        parameter[2] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        dsTemp = DAL.GetListWithParam("[Usp_GroupMgmt]", parameter);


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

    #region ADDING GROUP
    public void Add_Group(string Str_Fids)
    {
        //try
        //{
        /**
        OleDbConnection OLECON = new OleDbConnection(Connectionstring);
        OleDbCommand OLECMD = new OleDbCommand("AWC_SP_GROUPS_INSERT", OLECON);
        OLECMD.CommandType = CommandType.StoredProcedure;
        OLECMD.Parameters.Add("var_grp_id", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_ID);
        OLECMD.Parameters.Add("var_grp_descr", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_DESCR);
        OLECMD.Parameters.Add("var_is_admin", OleDbType.Char).Value = CommonFunctions.delQuote(IS_ADMIN);

        OLECMD.Parameters.Add("var_disc_percent", OleDbType.Integer).Value = (CommonFunctions.delQuote(DISC_PERCENT) == "" ? 0 : Convert.ToInt32(CommonFunctions.delQuote(DISC_PERCENT)));
        OLECMD.Parameters.Add("var_extra_free_packs", OleDbType.Integer).Value = (CommonFunctions.delQuote(EXTRA_FREE_PACKS) == "" ? 0 : Convert.ToInt32(CommonFunctions.delQuote(EXTRA_FREE_PACKS)));
        OLECMD.Parameters.Add("var_create_by", OleDbType.VarChar).Value = CREAT_BY;
        OLECMD.Parameters.Add("var_maintby", OleDbType.VarChar).Value = CREAT_BY;
        OLECON.Open();
        OLECMD.ExecuteNonQuery();
        OLECON.Close();



        //Str_Sql = "INSERT INTO AWC_ADM_GROUPS(GROUP_ID,GROUP_DESCR,IS_ADMIN,DISC_PERCENT,EXTRA_FREE_PACKS,CREAT_BY,CREAT_DT,MAINT_BY)";

        //Str_Sql = Str_Sql + "VALUES(";
        //Str_Sql = Str_Sql + "'" + CommonFunctions.delQuote(GROUP_ID) + "',";
        //Str_Sql = Str_Sql + "'" + CommonFunctions.delQuote(GROUP_DESCR) + "',";
        //Str_Sql = Str_Sql + "'" + CommonFunctions.delQuote(IS_ADMIN) + "',";
        //Str_Sql = Str_Sql + "'" + CommonFunctions.delQuote(DISC_PERCENT) + "',";
        //Str_Sql = Str_Sql + "'" + CommonFunctions.delQuote(EXTRA_FREE_PACKS) + "',";
        //Str_Sql = Str_Sql + "'" + CREAT_BY + "',";
        //Str_Sql = Str_Sql + "'" + System.DateTime.Now + "',";
        //Str_Sql = Str_Sql + "'" + CREAT_BY + "')";

        //dbConnection.runSQL(Str_Sql);
        **/



        SqlParameter[] parameter = new SqlParameter[9];
        parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_ID));
        parameter[1] = CommonFunctions.MakeParam("@pGroupDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_DESCR));
        parameter[2] = CommonFunctions.MakeParam("@pIsAdmin", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(IS_ADMIN));
        parameter[3] = CommonFunctions.MakeParam("@pDiscPercent", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(DISC_PERCENT));
        parameter[4] = CommonFunctions.MakeParam("@pExtraFreePacks", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(EXTRA_FREE_PACKS));
        parameter[5] = CommonFunctions.MakeParam("@pCreated_by", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(CREAT_BY));
        parameter[6] = CommonFunctions.MakeParam("@pMaint_by", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(CREAT_BY));
        parameter[7] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "AddGroup");
        parameter[8] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        DAL.DBExecNonQuery("[Usp_GroupMgmt]", parameter);


        /**

        OleDbConnection OLECON2 = new OleDbConnection(Connectionstring);

        OLECON2.Open();
        **/
        foreach (object i in (Str_Fids.Split(',')))
        {
            /**
            OleDbCommand OLECMD2 = new OleDbCommand("AWC_SP_GRP_FUNCTIONS_INSERT", OLECON2);
            OLECMD2.CommandType = CommandType.StoredProcedure;
            OLECMD2.Parameters.Add("var_grp_id", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_ID);
            OLECMD2.Parameters.Add("var_func_id", OleDbType.VarChar).Value = i;
            OLECMD2.Parameters.Add("var_create_by", OleDbType.VarChar).Value = CREAT_BY;
            OLECMD2.ExecuteNonQuery();

            //Str_Sql = "INSERT INTO AWC_ADM_GRP_FUNCTIONS VALUES(" + "'" + CommonFunctions.delQuote(GROUP_ID) + "'," + "'" + i + "'," + "'" + CREAT_BY + "'," + "'" + System.DateTime.Now + "'," + "''," + "'')";
            //dbConnection.runSQL(Str_Sql);
            **/

            SqlParameter[] parameter1 = new SqlParameter[5];
            parameter1[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_ID));
            parameter1[1] = CommonFunctions.MakeParam("@pFunctionId", SqlDbType.VarChar, 50, ParameterDirection.Input, i.ToString());
            parameter1[2] = CommonFunctions.MakeParam("@pCreated_by", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(CREAT_BY));
            parameter1[3] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "AddGroupFunctions");
            parameter1[4] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
            DAL.DBExecNonQuery("[Usp_GroupMgmt]", parameter1);
        }
        //OLECON2.Close();
        // }
        //catch
        //{
        //}
    }
    #endregion

    #region GETTING GROUP LIST
    public DataSet Get_Group_List(string curgroup)
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_GROUPS_LIST", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_grp_id", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_ID);
        OledbDa.SelectCommand.Parameters.Add("var_grp_descr", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_DESCR);
        OledbDa.SelectCommand.Parameters.Add("var_curGroup", OleDbType.VarChar).Value =curgroup;
        OledbDa.SelectCommand.Parameters.Add("var_Sort_On", OleDbType.VarChar).Value = Sort_On;
        OledbDa.SelectCommand.Parameters.Add("var_Sort_Direction", OleDbType.VarChar).Value = Sort_Direction;
                
        DataSet DS_Temp = new DataSet();
        OledbDa.Fill(DS_Temp);
        return DS_Temp;

        **/


        DataSet DS_Temp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[5];
        parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_ID));
        parameter[1] = CommonFunctions.MakeParam("@pGroupDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_DESCR));
        parameter[2] = CommonFunctions.MakeParam("@pCurrentGroup", SqlDbType.VarChar, 50, ParameterDirection.Input, curgroup);
        parameter[3] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "SearchGroups");
        parameter[4] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        DS_Temp = DAL.GetListWithParam("[Usp_GroupMgmt]", parameter);
        return DS_Temp;

    }


    #endregion

    #region deleting groups
    public void Delete_Groups(string Str_Group_Ids)
    {
        #region this is done by bhaskar but it is not working

        /**
                 OleDbConnection OLECON = new OleDbConnection(Connectionstring);
                 OleDbCommand OLECMD = new OleDbCommand("AWC_SP_GROUPS_DELETE", OLECON);
                 OLECMD.CommandType = CommandType.StoredProcedure;
                 OLECMD.Parameters.Add("var_Str_Group_Ids", OleDbType.VarChar).Value = "'" + Str_Group_Ids.Replace(",", "','") + "'";
                 OLECMD.Parameters["var_Str_Group_Ids"].Direction = ParameterDirection.Input;
                 OLECON.Open();
                 OLECMD.ExecuteNonQuery();
                 OLECON.Close();
                //dbConnection.runSQL("DELETE FROM AWC_ADM_GROUPSFUNCPRIV WHERE GROUP_ID IN (SELECT GROUP_ID FROM AWC_ADM_GROUPS WHERE GROUP_ID IN ('" + (Str_Group_Ids.Replace(",", "', '") + "'))"));
               // dbConnection.runSQL("DELETE FROM AWC_ADM_GROUPS WHERE GROUP_ID IN ('" + (Str_Group_Ids.Replace(",", "', '") + "')")); 
                #endregion
                      
               // string strsql="";
               // strsql= "DELETE FROM AWC_ADM_GRP_FUNCTIONS WHERE GROUP_ID IN (SELECT GROUP_ID FROM AWC_ADM_GROUPS WHERE GROUP_ID IN('"+Str_Group_Ids.Replace(",", "', '")+"'))";
               // OleDbConnection OLECON = new OleDbConnection(Connectionstring);
               // OleDbCommand OLECMD = new OleDbCommand(strsql, OLECON);
               // OLECMD.CommandType = CommandType.Text;
               // OLECON.Open();
               // OLECMD.ExecuteNonQuery();
               // OLECON.Close();

               //strsql="DELETE FROM AWC_ADM_GROUPS WHERE GROUP_ID IN('" + Str_Group_Ids.Replace(",", "', '") + "')";
               //OLECMD.CommandText = strsql;
               //OLECMD.CommandType = CommandType.Text;
               //OLECON.Open();
               //OLECMD.ExecuteNonQuery();
               //OLECON.Close();

                **/

        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pGroupIds", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Group_Ids);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "DeleteGroups");
        parameter[2] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        DAL.DBExecNonQuery("[Usp_GroupMgmt]", parameter);

        #endregion

    }

    #endregion


    #region CHECKING CONTRAINT
    public bool Check_Constraint(string Str_Group_Ids)
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_CHK_CONSTRAINT", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_Str_Group_Ids", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_Str_Group_Ids"].Value = Str_Group_Ids.ToString().Replace(",", "','");
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        **/

        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pGroupIds", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Group_Ids);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "CheckConstraint");
        parameter[2] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        dsTemp = DAL.GetListWithParam("[Usp_GroupMgmt]", parameter);

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

    #region Getting Group values(THIS IS CALLED WHEN UPDATING A PARTICULAR GROUP)
    public void Get_Group_Vlues()
    {
        /**
        //Str_Sql = "SELECT * FROM AWC_ADM_GROUPS WHERE GROUP_ID='" + GROUP_ID + "'";
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GROUPS_SELECT", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_grp_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_grp_id"].Value = GROUP_ID;
        DataSet DS_Temp = new DataSet();
        OledbDa.Fill(DS_Temp);
                
        //DS_Temp = dbConnection.getDataSet(Str_Sql);
        **/

        DataSet DS_Temp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, GROUP_ID);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetGroupDtls");
        parameter[2] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        DS_Temp = DAL.GetListWithParam("[Usp_GroupMgmt]", parameter);



        if (DS_Temp.Tables[0].Rows.Count == 1)
        {
            DR_Temp = DS_Temp.Tables[0].Rows[0];
            GROUP_ID = DR_Temp["GROUP_ID"].ToString();
            GROUP_DESCR = DR_Temp["GROUP_DESCR"].ToString();
            IS_ADMIN = DR_Temp["IS_ADMIN"].ToString();
            CREAT_BY = DR_Temp["CREAT_BY"].ToString();

            if (DR_Temp["DISC_PERCENT"].ToString() != "")
            {
                DISC_PERCENT = DR_Temp["DISC_PERCENT"].ToString();
            }
            else
            {
                DISC_PERCENT = "";
            }
            if (DR_Temp["EXTRA_FREE_PACKS"].ToString() != "")
            {
                EXTRA_FREE_PACKS = DR_Temp["EXTRA_FREE_PACKS"].ToString();
            }
            else
            {
                EXTRA_FREE_PACKS = "";
            }
        }
    }
    #endregion

    #region GETTING UPDTING  FUNCTION LIST
    public DataSet Get_Fun_Update_List(String GROUP_ID)
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_FUNC_UPDATE_LIST", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_grp_id", OleDbType.VarChar).Value = GROUP_ID;
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        return dsTemp;
        **/

        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, GROUP_ID);
        parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetFuncUpdateList");
        parameter[2] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        dsTemp = DAL.GetListWithParam("[Usp_GroupMgmt]", parameter);
        return dsTemp;
    }
    #endregion

    #region UPDATING GROUP
    public void Update_Group(string Str_Fids)
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_CREATEINFO_GRP", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_grp_id ", OleDbType.VarChar).Value = GROUP_ID;
        DataSet DS_Temp = new DataSet();
        OledbDa.Fill(DS_Temp);
        **/

        DataSet DS_Temp = new DataSet();
        SqlParameter[] parameter1 = new SqlParameter[3];
        parameter1[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, GROUP_ID);
        parameter1[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetGroupDtls");
        parameter1[2] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        DS_Temp = DAL.GetListWithParam("[Usp_GroupMgmt]", parameter1);

        CREAT_BY = DS_Temp.Tables[0].Rows[0]["CREAT_BY"].ToString();
        CREAT_DT = DS_Temp.Tables[0].Rows[0]["CREAT_DT"].ToString();
        /**
        this.dbConnectionNew = new OleDbConnection(Connectionstring);
        dbConnectionNew.Open();
        T = dbConnectionNew.BeginTransaction();
        **/
        try
        {
            /**
            OleDbCommand dbCommand_delete = new OleDbCommand();
            dbCommand_delete.Transaction = T;
            dbCommand_delete.Connection = dbConnectionNew;
            dbCommand_delete.CommandType = CommandType.StoredProcedure;
            dbCommand_delete.CommandText = "AWC_SP_GRPFUNC_DELETE_BY_GRPID";
            dbCommand_delete.Parameters.Add("var_grp_id", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_ID);
            dbCommand_delete.ExecuteNonQuery();
            **/

            SqlParameter[] parameter = new SqlParameter[11];
            parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_ID));
            parameter[1] = CommonFunctions.MakeParam("@pGroupDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(GROUP_DESCR));
            parameter[2] = CommonFunctions.MakeParam("@pIsAdmin", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(IS_ADMIN));
            parameter[3] = CommonFunctions.MakeParam("@pDiscPercent", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(DISC_PERCENT));
            parameter[4] = CommonFunctions.MakeParam("@pExtraFreePacks", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(EXTRA_FREE_PACKS));
            parameter[5] = CommonFunctions.MakeParam("@pCreated_by", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(CREAT_BY));
            parameter[6] = CommonFunctions.MakeParam("@pCreated_Dt", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(CREAT_DT));

            parameter[7] = CommonFunctions.MakeParam("@pMaint_by", SqlDbType.VarChar, 50, ParameterDirection.Input, CommonFunctions.delQuote(MAINT_BY));
            parameter[8] = CommonFunctions.MakeParam("@pFunctionIds", SqlDbType.VarChar, 3000, ParameterDirection.Input, Str_Fids);
            parameter[9] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "UpdateGroup");
            parameter[10] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
            DAL.DBExecNonQuery("[Usp_GroupMgmt]", parameter);

            /**
            OleDbCommand dbCommand_update = new OleDbCommand();
            dbCommand_update.Connection = dbConnectionNew;
            dbCommand_update.Transaction = T;
            dbCommand_update.CommandType = CommandType.StoredProcedure;
            dbCommand_update.CommandText = "AWC_SP_GROUPS_UPDATE";
            dbCommand_update.Parameters.Add("var_grp_descr", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_DESCR);
            dbCommand_update.Parameters.Add("var_is_admin", OleDbType.Char).Value = IS_ADMIN;
            dbCommand_update.Parameters.Add("var_disc_percent", OleDbType.Integer).Value = int.Parse(DISC_PERCENT);
            dbCommand_update.Parameters.Add("var_extra_free_packs", OleDbType.VarChar).Value = int.Parse(EXTRA_FREE_PACKS);
            dbCommand_update.Parameters.Add("MAINT_BY", OleDbType.VarChar).Value = MAINT_BY;
            dbCommand_update.Parameters.Add("var_grp_id", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_ID);

            dbCommand_update.ExecuteNonQuery();
                    

            if (Str_Fids != null)
            {
                foreach (string i in Str_Fids.ToString().Split(','))
                {
                    OleDbCommand dbCommand_insert = new OleDbCommand();
                    dbCommand_insert.Connection = dbConnectionNew;
                    dbCommand_insert.Transaction = T;
                    dbCommand_insert.CommandType = CommandType.StoredProcedure;
                    dbCommand_insert.CommandText = "AWC_SP_GRP_FUNC_INSERT";
                    dbCommand_insert.Parameters.Add("var_grp_id", OleDbType.VarChar).Value = CommonFunctions.delQuote(GROUP_ID);
                    dbCommand_insert.Parameters.Add("var_func_id", OleDbType.VarChar).Value = i;
                    dbCommand_insert.Parameters.Add("var_create_by", OleDbType.VarChar).Value = CREAT_BY;
                    dbCommand_insert.Parameters.Add("var_create_dt", OleDbType.VarChar).Value = CREAT_DT;
                    dbCommand_insert.Parameters.Add("var_maint_by", OleDbType.VarChar).Value = MAINT_BY;

                    dbCommand_insert.ExecuteNonQuery();
                }
            }
            T.Commit();**/
        }
        catch (Exception ex)
        {
            /**T.Rollback();**/
            throw ex;
        }
        //dbConnectionNew.Close();
    }
    #endregion

    #region WHETHER THE GIVEN FUNCTION IS EXISTING OR NOT

    public bool Is_Function_Exist(string Str_FID)
    {

        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_IS_FUNC_EXIST", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_grp_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_grp_id"].Value = CommonFunctions.delQuote(GROUP_ID);
        OledbDa.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_func_id"].Value = CommonFunctions.delQuote(Str_FID);
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        **/


        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[4];
        parameter[0] = CommonFunctions.MakeParam("@pGroupId", SqlDbType.VarChar, 50, ParameterDirection.Input, GROUP_ID);
        parameter[1] = CommonFunctions.MakeParam("@pFunctionId", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_FID);
        parameter[2] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "IsFunctionExists");
        parameter[3] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        dsTemp = DAL.GetListWithParam("[Usp_GroupMgmt]", parameter);

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
}
