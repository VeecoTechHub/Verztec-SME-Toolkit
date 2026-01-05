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
/// Summary description for Function_Maintain_Logic
/// </summary>
public class Function_Maintain_Logic
{

    //private DatabaseConnector dbConnection;
    DAL dal;
    private string Connectionstring;
    private string Str_Sql;
    private DataSet DS_Temp;
    private DataRow DR_Temp;

    public string Str_Function_Id;
    public string Str_Short_Desc;
    public string Str_Description;
    public string Str_Parent_Menu;
    public string Int_Page_Size;
    public string Int_Sort_Seq;
    public string Str_Search_URL;
    public string Str_New_URL;
    public string Str_Edit_URL;
    public string Str_Delete_URL;
    public string Str_Query_URL;
    public char Def_To_Groups;
    public char Def_Link;
    public string Str_Created_By;
    public string Str_Created_On;
    public string Str_Maintained_By;
    public string Str_Maintained_On;
    public string Str_Sort_On;

    public Function_Maintain_Logic()
    {
        /**this.Connectionstring = NusDataAccessLayer.GetConnectionString();//GetConnectionString();// ConfigurationManager.AppSettings["OledbConnStr"];**/
        dal = new DAL();
    }

    #region Getting Parent Menu
    public DataSet Get_Parent_Menu()
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_PARENT_MENU", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        DataSet DS_Temp = new DataSet();
        OledbDa.Fill(DS_Temp);
        //DS_Temp = dbConnection.getDataSet("SELECT STATUS, STATUS_DESCR FROM AWC_ADM_CODEMASTER WHERE STATUS_TYPE='PARENTMENU' order by SORT_order");
        return DS_Temp;
        **/

        DataSet DS_Temp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[2];
        parameter[0] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetParentMenus");
        parameter[1] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        //DAL.DBExecNonQuery("[AWC_SP_GET_PARENT_MENU]", parameter);
        DS_Temp = DAL.GetListWithParam("[Usp_CodeMasterMgmt]", parameter);
        return DS_Temp;
    }
    #endregion

    #region checking for duplicate Functions
    public bool Check_Duplicate(string Str_Val)
    {
        
        
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_CHK_DUPLICATE_FUNCTIONS", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_func_id"].Value = Str_Val;
        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);
        **/

        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Val);
        parameter[1] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        parameter[2] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "CheckDuplicateFunction");

        //////dsTempFunction = DAL.GetListWithParam("[AWC_SP_CHK_DUPLICATE_FUNCTIONS]", parameter);
        dsTemp = DAL.GetListWithParam("[Usp_FunctionMgmt]", parameter);



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

    #region Checking Duplicate Sort Sequence
    public bool Check_Dup_Sort_Seq()
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_CHK_DUP_SORT_SEQ", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_Parent_Menu", OleDbType.VarChar).Value = Str_Parent_Menu;
        OledbDa.SelectCommand.Parameters.Add("var_Int_Sort_Seq", OleDbType.Integer).Value = Convert.ToInt32(Int_Sort_Seq);
        OledbDa.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Value = Str_Function_Id;

        DataSet dsTemp = new DataSet();
        OledbDa.Fill(dsTemp);

        **/

        DataSet dsTemp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[5];
        parameter[0] = CommonFunctions.MakeParam("@pParentMenuID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Parent_Menu);
        parameter[1] = CommonFunctions.MakeParam("@pSortSequence", SqlDbType.VarChar, 50, ParameterDirection.Input, Int_Sort_Seq);
        parameter[2] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Function_Id);
        parameter[3] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        parameter[4] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "CheckDuplicateSortSequence");
        //////dsTempFunction = DAL.GetListWithParam("[AWC_SP_CHK_DUP_SORT_SEQ]", parameter);
        dsTemp = DAL.GetListWithParam("[Usp_FunctionMgmt]", parameter);


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

    //#region CHECKING DUP SORT SEQ
    //public bool Check_Dup_Sort_Seq()
    //{
    //    if (Convert.ToInt32(dbConnection.getDataSet("SELECT COUNT(*) FROM AWC_ADM_FUNCTIONS WHERE PARENT_MENU='" + Str_Parent_Menu + "' AND MENU_SORT_SEQ='" + Int_Sort_Seq + "' AND NOT FUNC_ID='" + Str_Function_Id + "'").Tables[0].Rows[0][0]) > 0)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //} 
    //#endregion

    #region ADDING FUNCTIONz
    public void Add_Function()
    {
        /**
        OleDbConnection OLECON = new OleDbConnection(Connectionstring);
        OleDbCommand OLECMD = new OleDbCommand("AWC_SP_FUNCTIONS_INSERT", OLECON);
        OLECMD.Parameters.Add("var_Function_Id", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Function_Id);
        OLECMD.Parameters.Add("var_Short_Desc", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Short_Desc);
        OLECMD.Parameters.Add("var_Description", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Description);
        OLECMD.Parameters.Add("var_Parent_Menu", OleDbType.VarChar).Value = this.Str_Parent_Menu;
        OLECMD.Parameters.Add("var_Page_Size", OleDbType.Integer).Value = Convert.ToInt32(this.Int_Page_Size);
        OLECMD.Parameters.Add("var_Sort_Seq", OleDbType.Integer).Value = Convert.ToInt32(this.Int_Sort_Seq);
        OLECMD.Parameters.Add("var_Edit_URL", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Edit_URL);
        OLECMD.Parameters.Add("var_Search_URL", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Search_URL);
        OLECMD.Parameters.Add("var_New_URL", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_New_URL);
        OLECMD.Parameters.Add("var_Created_By", OleDbType.VarChar).Value = this.Str_Created_By;
        OLECMD.Parameters.Add("var_Def_Link", OleDbType.VarChar).Value = this.Def_Link;
        OLECMD.CommandType = CommandType.StoredProcedure;
        OLECON.Open();
        OLECMD.ExecuteNonQuery();
        OLECON.Close();

        **/


        SqlParameter[] parameter = new SqlParameter[14];
        parameter[0] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Function_Id);
        parameter[1] = CommonFunctions.MakeParam("@pShortDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Short_Desc);
        parameter[2] = CommonFunctions.MakeParam("@pDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Description);
        parameter[3] = CommonFunctions.MakeParam("@pParentMenuID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Parent_Menu);
        parameter[4] = CommonFunctions.MakeParam("@pPageSize", SqlDbType.VarChar, 50, ParameterDirection.Input, Int_Page_Size);
        parameter[5] = CommonFunctions.MakeParam("@pSortSequence", SqlDbType.VarChar, 50, ParameterDirection.Input, Int_Sort_Seq);
        parameter[6] = CommonFunctions.MakeParam("@pEditURL", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Edit_URL);
        parameter[7] = CommonFunctions.MakeParam("@pDelLINK", SqlDbType.VarChar, 50, ParameterDirection.Input, "");
        parameter[8] = CommonFunctions.MakeParam("@pSearchURL", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Search_URL);
        parameter[9] = CommonFunctions.MakeParam("@pNewURL", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_New_URL);
        parameter[10] = CommonFunctions.MakeParam("@pCreatedBy", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Created_By);
        parameter[11] = CommonFunctions.MakeParam("@pDefLINK", SqlDbType.VarChar, 50, ParameterDirection.Input, Def_Link);
        parameter[12] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        parameter[13] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "AddFunction");
        //DAL.DBExecNonQuery("[AWC_SP_FUNCTIONS_INSERT]", parameter);
        DAL.DBExecNonQuery("[Usp_FunctionMgmt]", parameter);




    }
    #endregion


    #region getting function list
    public DataSet Get_Function_List(string Str_Parent_Menu_Id, string Str_Function_Id, string Str_Short_Desc, string Str_Description)
    {
        //Str_Sql = "SELECT FUNC_ID,DESCR,PARENT_MENU FROM AWC_ADM_FUNCTIONS ";
        //if (CommonFunctions.delQuote(Str_Function_Id) != "" | CommonFunctions.delQuote(Str_Parent_Menu_Id) != "0" | CommonFunctions.delQuote(Str_Short_Desc) != "" | CommonFunctions.delQuote(Str_Description) != "")
        //{
        //    Str_Sql = Str_Sql + "WHERE ";
        //}
        //if (CommonFunctions.delQuote(Str_Parent_Menu_Id) != "0")
        //{
        //    Str_Sql = Str_Sql + "UPPER(PARENT_MENU) LIKE UPPER('" + CommonFunctions.delQuote(Str_Parent_Menu_Id) + "') AND ";
        //}
        //if (CommonFunctions.delQuote(Str_Function_Id) != "")
        //{
        //    Str_Sql = Str_Sql + "UPPER(FUNC_ID) LIKE UPPER('" + CommonFunctions.delQuote(Str_Function_Id) + "') AND ";
        //}
        //if (CommonFunctions.delQuote(Str_Short_Desc) != "")
        //{
        //    Str_Sql = Str_Sql + "UPPER(SHRT_DESCR) LIKE UPPER('" + CommonFunctions.delQuote(Str_Short_Desc) + "') AND ";
        //}
        //if (CommonFunctions.delQuote(Str_Description) != "")
        //{
        //    Str_Sql = Str_Sql + "UPPER(DESCR) LIKE UPPER('" + CommonFunctions.delQuote(Str_Description) + "') AND ";
        //}
        //if (CommonFunctions.delQuote(Str_Function_Id) != "" | CommonFunctions.delQuote(Str_Parent_Menu_Id) != "0" | CommonFunctions.delQuote(Str_Short_Desc) != "" | CommonFunctions.delQuote(Str_Description) != "")
        //{
        //    Str_Sql = Substring(Str_Sql,0, (Str_Sql.Length) - 4);
        //}
        //if (Str_Sort_On != "")
        //{
        //    Str_Sql = Str_Sql + " ORDER BY " + Str_Sort_On + "";
        //}
        //else
        //{
        //    Str_Sql = Str_Sql + " ORDER BY UPPER(FUNC_ID)";
        //}
        ////DS_Temp = dbConnection.getDataSet(Str_Sql);

        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_GET_FUNCTIONS_ALL", Connectionstring);
        DataSet dsTemp = new DataSet();
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_Function_Id", OleDbType.VarChar).Value = CommonFunctions.delQuote(Str_Function_Id);
        OledbDa.SelectCommand.Parameters.Add("var_Parent_Menu_Id", OleDbType.VarChar).Value = CommonFunctions.delQuote(Str_Parent_Menu_Id);
        OledbDa.SelectCommand.Parameters.Add("var_Short_Desc", OleDbType.VarChar).Value = CommonFunctions.delQuote(Str_Short_Desc);
        OledbDa.SelectCommand.Parameters.Add("var_Description", OleDbType.VarChar).Value = CommonFunctions.delQuote(Str_Description);
        OledbDa.SelectCommand.Parameters.Add("var_sort_On", OleDbType.VarChar).Value = Str_Sort_On;
        OledbDa.Fill(dsTemp);
        return dsTemp;

        **/


        DataSet dsTemp = new DataSet();

        SqlParameter[] parameter = new SqlParameter[7];
        parameter[0] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Function_Id);
        parameter[1] = CommonFunctions.MakeParam("@pParentMenuID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Parent_Menu_Id);
        parameter[2] = CommonFunctions.MakeParam("@pShortDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Short_Desc);
        parameter[3] = CommonFunctions.MakeParam("@pDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Description);
        parameter[4] = CommonFunctions.MakeParam("@pSortOn", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Sort_On);
        parameter[5] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        parameter[6] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "SearchFunction");
        //DAL.DBExecNonQuery("[AWC_SP_FUNCTIONS_DELETE]", parameter);
        dsTemp=DAL.GetListWithParam("[Usp_FunctionMgmt]", parameter);
        return dsTemp;
      
    }
    #endregion

    #region Deleting Functions
    public void Delete_Functions(string Str_Func_Ids)
    {
        /**
        OleDbConnection OLECON = new OleDbConnection(Connectionstring);
        OleDbCommand OLECMD = new OleDbCommand("AWC_SP_FUNCTIONS_DELETE", OLECON);
        OLECMD.CommandType = CommandType.StoredProcedure;
        OLECMD.Parameters.Add("var_Str_Func_Ids", OleDbType.VarChar).Value = "'" + Str_Func_Ids.Replace(",", "','") + "'";
        OLECMD.Parameters["var_Str_Func_Ids"].Direction = ParameterDirection.Input;
        OLECON.Open();
        OLECMD.ExecuteNonQuery();
        OLECON.Close();


        //string strsql = "";
        //strsql = "DELETE FROM AWC_ADM_GRP_FUNCTIONS WHERE FUNC_ID IN ('" + Str_Func_Ids.Replace(",", "','") + "')";
        //OleDbConnection OLECON = new OleDbConnection(Connectionstring);
        //OleDbCommand OLECMD = new OleDbCommand(strsql, OLECON);
        //OLECMD.CommandType = CommandType.Text;
        //OLECON.Open();
        //OLECMD.ExecuteNonQuery();
        //OLECON.Close();

        //strsql = "DELETE FROM AWC_ADM_FUNCTIONS WHERE FUNC_ID IN ('" + Str_Func_Ids.Replace(",", "','") + "')";
        //OLECMD.CommandText = strsql;
        //OLECMD.CommandType = CommandType.Text;
        //OLECON.Open();
        //OLECMD.ExecuteNonQuery();
        //OLECON.Close();
        //dbConnection.runSQL("DELETE FROM AWC_ADM_GRP_FUNCTIONS WHERE FUNC_ID IN ('" + (Str_Func_Ids.Replace(",", "','") + "')"));
        //dbConnection.runSQL("DELETE FROM AWC_ADM_FUNCTIONS WHERE FUNC_ID IN ('" + (Str_Func_Ids.Replace(",", "','") + "')"));


        **/


        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pFunctionIDs", SqlDbType.VarChar, 2000, ParameterDirection.Input,"'"+ Str_Func_Ids.Replace(",", "','")+"'");
        parameter[1] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        parameter[2] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "DeleteFunctions");
        //DAL.DBExecNonQuery("[AWC_SP_FUNCTIONS_DELETE]", parameter);
 bool i=    DAL.DBExecNonQuery("[Usp_FunctionMgmt]", parameter);





    }
    public void Get_Values(string Str_FUNC_ID)
    {
        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_FUNCTIONS_SELECT", Connectionstring);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_func_id"].Value = (Str_FUNC_ID == null) ? "" : Str_FUNC_ID;
        DataSet DS_Temp = new DataSet();
        OledbDa.Fill(DS_Temp);

        



        // DS_Temp = dbConnection.getDataSet("SELECT * FROM AWC_ADM_FUNCTIONS WHERE FUNC_ID='" + Str_FUNC_ID + "'");
        **/
        DataSet DS_Temp = new DataSet();
        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_FUNC_ID);
        parameter[1] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        parameter[2] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetFunctionDtls");
        //DAL.DBExecNonQuery("[AWC_SP_FUNCTIONS_INSERT]", parameter);
        DS_Temp=DAL.GetListWithParam("[Usp_FunctionMgmt]", parameter);


        if (DS_Temp.Tables[0].Rows.Count > 0)
        {
            DR_Temp = DS_Temp.Tables[0].Rows[0];
            this.Str_Function_Id = DR_Temp["FUNC_ID"].ToString();
            this.Str_Short_Desc = DR_Temp["SHRT_DESCR"].ToString();
            this.Str_Description = DR_Temp["DESCR"].ToString();
            this.Str_Parent_Menu = DR_Temp["PARENT_MENU"].ToString();
            this.Int_Page_Size = DR_Temp["SEARCH_LIST_SIZE"].ToString();
            this.Int_Sort_Seq = DR_Temp["MENU_SORT_SEQ"].ToString();
            //if (DR_Temp["QRY_LINK"].ToString()!="") 
            //{ 
            //    this.Str_Query_URL = DR_Temp["QRY_LINK"].ToString(); 
            //} 
            //else 
            //{ 
            //    this.Str_Query_URL = ""; 
            //} 
            if (DR_Temp["EDIT_LINK"].ToString() != "")
            {
                this.Str_Edit_URL = DR_Temp["EDIT_LINK"].ToString();
            }
            else
            {
                this.Str_Edit_URL = "";
            }
            this.Def_Link = Convert.ToChar(DR_Temp["DEF_LINK"]);
            if (DR_Temp["SEARCH_LINK"].ToString() != "")
            {
                this.Str_Search_URL = DR_Temp["SEARCH_LINK"].ToString();
            }
            else
            {
                this.Str_Search_URL = "";
            }
            if (DR_Temp["NEW_LINK"].ToString() != "")
            {
                this.Str_New_URL = DR_Temp["NEW_LINK"].ToString();
            }
            else
            {
                this.Str_New_URL = "";
            }
            //if (DR_Temp["DEF_TO_GROUPS"].ToString()!="") 
            //{ 
            //    this.Def_To_Groups = Convert.ToChar(DR_Temp["DEF_TO_GROUPS"]); 
            //} 
            //else 
            //{ 
            //    this.Def_To_Groups = Convert.ToChar(""); 
            //} 
            this.Str_Created_By = DR_Temp["CREAT_BY"].ToString();
            this.Str_Created_On = DR_Temp["CREAT_DT"].ToString();
        }
    }
    #endregion

    #region UPADATING FUNCTION
    public void Update_Function()
    {

        /**
        OleDbConnection olecon = new OleDbConnection(Connectionstring);
        OleDbCommand oledbcmd = new OleDbCommand("AWC_SP_UPDATE_FUNCTION", olecon);
        oledbcmd.CommandType = CommandType.StoredProcedure;
        oledbcmd.Parameters.Add("var_Short_Desc", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Short_Desc);
        oledbcmd.Parameters.Add("var_Description", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Description);
        oledbcmd.Parameters.Add("var_Parent_Menu", OleDbType.VarChar).Value = this.Str_Parent_Menu;
        oledbcmd.Parameters.Add("var_Int_Page_Size", OleDbType.Integer).Value = Convert.ToInt32(this.Int_Page_Size);
        oledbcmd.Parameters.Add("var_Sort_Seq", OleDbType.Integer).Value = Convert.ToInt32(this.Int_Sort_Seq);
        oledbcmd.Parameters.Add("var_Edit_URL", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Edit_URL);
        oledbcmd.Parameters.Add("var_Search_URL", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_Search_URL);
        oledbcmd.Parameters.Add("var_New_URL", OleDbType.VarChar).Value = CommonFunctions.delQuote(this.Str_New_URL);
        oledbcmd.Parameters.Add("var_Created_By", OleDbType.VarChar).Value = this.Str_Created_By;
        oledbcmd.Parameters.Add("var_Def_Link", OleDbType.VarChar).Value = this.Def_Link;
        oledbcmd.Parameters.Add("var_Func_Id", OleDbType.VarChar).Value = this.Str_Function_Id;
        olecon.Open();
        oledbcmd.ExecuteNonQuery();
        olecon.Close();

        //str_sql = "update AWC_ADM_FUNCTIONS set " + "shrt_descr='" + CommonFunctions.delQuote(this.str_short_desc) + "', " + "descr='" + CommonFunctions.delQuote(this.str_description) + "', " + "parent_menu='" + this.str_parent_menu + "', " + "search_list_size=" + this.int_page_size + ", " + "menu_sort_seq=" + this.int_sort_seq + ", " + "edit_link='" + CommonFunctions.delQuote(this.str_edit_url) + "', " + "del_link='', " + "search_link='" + CommonFunctions.delQuote(this.str_search_url) + "', " + "new_link='" + CommonFunctions.delQuote(this.str_new_url) + "', " + "maint_by='" + this.str_created_by + "', " + "maint_dt='" + system.datetime.now + "'," + "def_link='" + this.def_link + "'" + " where func_id='" + this.str_function_id + "'";
        //dbconnection.runsql(str_sql);

        **/


        SqlParameter[] parameter = new SqlParameter[14];
        parameter[0] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Function_Id);
        parameter[1] = CommonFunctions.MakeParam("@pShortDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Short_Desc);
        parameter[2] = CommonFunctions.MakeParam("@pDescription", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Description);
        parameter[3] = CommonFunctions.MakeParam("@pParentMenuID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Parent_Menu);
        parameter[4] = CommonFunctions.MakeParam("@pPageSize", SqlDbType.VarChar, 50, ParameterDirection.Input, Int_Page_Size);
        parameter[5] = CommonFunctions.MakeParam("@pSortSequence", SqlDbType.VarChar, 50, ParameterDirection.Input, Int_Sort_Seq);
        parameter[6] = CommonFunctions.MakeParam("@pEditURL", SqlDbType.VarChar, 250, ParameterDirection.Input, Str_Edit_URL);
        parameter[7] = CommonFunctions.MakeParam("@pDelLINK", SqlDbType.VarChar, 250, ParameterDirection.Input, "");
        parameter[8] = CommonFunctions.MakeParam("@pSearchURL", SqlDbType.VarChar, 250, ParameterDirection.Input, Str_Search_URL);
        parameter[9] = CommonFunctions.MakeParam("@pNewURL", SqlDbType.VarChar, 250, ParameterDirection.Input, Str_New_URL);
        parameter[10] = CommonFunctions.MakeParam("@pCreatedBy", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Maintained_By);
        parameter[11] = CommonFunctions.MakeParam("@pDefLINK", SqlDbType.VarChar, 50, ParameterDirection.Input, Def_Link);
        parameter[12] = CommonFunctions.MakeParam("@pOPStatus", SqlDbType.Int, 2, ParameterDirection.Output, 2);
        parameter[13] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "UpdateFunction");
        //DAL.DBExecNonQuery("[AWC_SP_FUNCTIONS_INSERT]", parameter);
        DAL.DBExecNonQuery("[Usp_FunctionMgmt]", parameter);

    }
    #endregion

}
