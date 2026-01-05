using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ABSSecurity;


public partial class Administration_ChangePassword : System.Web.UI.Page
{
    private User_Logic ObjUser = new User_Logic();
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Security objSecurity = new Security();
    string StrCheckAccess;

    int pwdminlen;
    public static string token;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Put user code to initialize the page here
        if (Session["USER_ID"] == null)
        {
            Session["TimeOut"] = true;
            Response.Redirect("Default.aspx");
        }
        else
        {
            ViewState["USER_ID"] = Convert.ToString(Session["USER_ID"]);
        }
        if (!(Page.IsPostBack))
        {

            token = Request.Form["token"];


            token = Request.Form["token"];
            if (token == null)
            {
                Response.Redirect("~/Administration/Default.aspx");
            }
            else
            {
                StrCheckAccess = CommonFunctions.CheckAccess("ASMM01", Session["USER_ID"].ToString(), Session["GROUP_ID"].ToString());
                if (instr_fun(StrCheckAccess, "Administration/Main.aspx") > 0)
                {
                    Response.Redirect(StrCheckAccess);
                }
                ViewState.Add("Links", StrCheckAccess);
            }
        }
        txt_oldpassword.Focus();
    }

    public int instr_fun(string str1, string str2)
    {
        string SearchString;
        SearchString = str1;
        int myPos = SearchString.IndexOf(str2);
        return myPos;
    }



    protected void Button_Back_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("Main.aspx");
    }

    protected void Btn_Save_Click(object sender, ImageClickEventArgs e)
    {
        ObjUser.UserID = Convert.ToString(ViewState["USER_ID"]);
        ObjUser.UserPassword = objSecurity.Encrypt(txt_oldpassword.Text.Trim());
        ObjUser.newPassword = objSecurity.Encrypt(txt_Password.Text.Trim());
        if (ObjUser.CheckUserID() == "NOTEXIST")
        {
            lblError.Text = "Sorry, your old password is invalid. Please try again.";
            lblError.Visible = true;
            return;
        }
        else
        {
            lblError.Visible = false;
        }
        ObjUser.Update_User();
        Response.Write("<script>javascript:alert('Password has been changed successfully');</script>");

    }
}