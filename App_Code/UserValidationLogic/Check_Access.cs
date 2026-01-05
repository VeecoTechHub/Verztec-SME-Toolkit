using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
	
/// <summary>
/// Summary description for Check_Access.
/// </summary>
public class Check_Access : System.Web.UI.Page
{
	private string StrCheckAccess; 
	
	private User_Logic ObjUser; 
	private CommonFunctions CommonFunctions;

    public Check_Access()
    {
       
        ObjUser = new User_Logic();
        CommonFunctions = new CommonFunctions();
    }

    public Object initSystem()
    {
        if (Session["USER_ID"] == null)
        {
            Session["TimeOut"] = true;

            Server.Transfer("~/Administration/Default.aspx");
        }
        if (!(Page.IsPostBack))
        {
            if (Session["USER_ID"] != null && Session["fid"] != null && Session["USER_ID"] != null)
            {
                StrCheckAccess = CommonFunctions.CheckAccess(Session["fid"].ToString(), Session["USER_ID"].ToString(), Session["GROUP_ID"].ToString());
                if (instr_fun(StrCheckAccess, "Administration/Main.aspx") > 0)
                {
                    Server.Transfer(StrCheckAccess);



                }
                ViewState.Add("Links", StrCheckAccess);
            }
            else
                Server.Transfer("~/Administration/Default.aspx");


           
        }

        return ViewState["Links"];
    }

	
	public int instr_fun(string str1,string str2)
	{
		string SearchString;
		SearchString =str1;
		int myPos=SearchString.IndexOf(str2);
		return myPos;
	}

   

}

