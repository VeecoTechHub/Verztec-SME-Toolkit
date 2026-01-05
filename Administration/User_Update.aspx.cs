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
using ABSCommon;
using ABSSecurity;

public partial class Administration_User_Update : System.Web.UI.Page
{
    private User_Logic ObjUser = new User_Logic();
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    Security objSecurity = new Security();
    private string Uid;
    public static string token;


    protected void Page_Load(object sender, EventArgs e)
    {

        
           

        if (!(Page.IsPostBack))
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[0];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
             token = Request.Form["token"];
           // ViewState["t_url"] = "AdminResourcesLibrary.aspx?RL_ID=00";

             // ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[0];
            if (token == null)
            {
                Response.Redirect("default.aspx");
            }

            else
            {
               //changes ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
                if (Request["IDforEdit"].ToString() == ""  )
                { Uid = Request["IDforEdit"].ToString();
                //ddlGroupName.DataSource = ObjUser.GetAllGroups(Session["group_id"].ToString());
                //ddlGroupName.DataTextField = "GROUP_DESCR";
                //ddlGroupName.DataValueField = "GROUP_ID";
                //ddlGroupName.DataBind();
                }
                else
                {
                    Uid = CommonFunctions.Decrypt(Request["IDforEdit"].ToString());
                    Bind_Data();
                }
                ViewState["IDforEdit"] = Uid;
               
            }
        }
    }

    public int instr_fun(string str1, string str2)
    {
        string SearchString;
        SearchString = str1;
        int myPos = SearchString.IndexOf(str2);
        return myPos;
    }

    private void Bind_Data()
    {

        if (Uid != "")
        {
           ObjUser.GetUsers( Uid);
           // ObjUser.GetUsers(CommonFunctions.Decrypt (CommonFunctions.Encrypt ( Uid)));



        }

        ddlGroupName.DataSource = ObjUser.GetAllGroups(Session["group_id"].ToString());
        ddlGroupName.DataTextField = "GROUP_DESCR";
        ddlGroupName.DataValueField = "GROUP_ID";
        ddlGroupName.DataBind();
        ddlGroupName.Items.FindByValue(ObjUser.GroupID).Selected = true;
        if (Session["GROUP_ID"].ToString() == "ADUST01")
            ddlGroupName.Enabled = false;
        /****************************************************/

        //ddlDept.DataSource = ObjUser.GetAllDepartments();
        //ddlDept.DataTextField = "Description";
        //ddlDept.DataValueField = "DeptID";
        //ddlDept.DataBind();
        //if (ddlDept.Items.FindByValue(ObjUser.DeptID) != null)
        //ddlDept.Items.FindByValue(ObjUser.DeptID).Selected = true;
        /****************************************************/


        Txt_Userid.Text = CommonBindings.TextToBind(ObjUser.USER_ID);
        txtDesg.Text = CommonBindings.TextToBind(ObjUser.Desg);
        txt_Tel.Text = CommonBindings.TextToBind(ObjUser.Telephone);
        txt_Password.Text = CommonBindings.TextToBind(ObjUser.UserPassword);
        txt_ConPassword.Text = CommonBindings.TextToBind(ObjUser.UserPassword);
        txt_Email.Text = CommonBindings.TextToBind(ObjUser.UserEmail);
        Txt_Name.Text = CommonBindings.TextToBind(ObjUser.UserName);

    }



    private bool customValid()
    {
        string strError = "";
        bool valid = true;
        if (Txt_Name.Text.Trim() == "" | txt_Email.Text == "" | (txt_ConPassword.Text != "" & txt_Password.Text == "") | (txt_ConPassword.Text == "" & txt_Password.Text != ""))
        {
            strError = "Please enter all '*' marked fields.<br>";
            valid = false;
        }
        if ((txt_ConPassword.Text != "" & txt_Password.Text != ""))
        {



            foreach (char a in txt_Password.Text)
            {
                if (!(((ascii_fun(a) >= 48 & ascii_fun(a) <= 57) | (ascii_fun(a) > 64 & ascii_fun(a) < 91) | (ascii_fun(a) > 96 & ascii_fun(a) < 123))))
                {
                    strError = strError + "No special characters are allowed for Passwords. <br>";
                    valid = false;
                    goto exitForStatement0;
                }
            }
        exitForStatement0: ;
            if (txt_Password.Text.Trim() != txt_ConPassword.Text.Trim())
            {
                strError = strError + "Password and Confirm Password must be same.<br>";
                valid = false;
            }
        }
        if (strError != "")
        {
            lblError.Text = strError;
            lblError.Visible = true;
            valid = false;
        }
        else
        {
            lblError.Visible = false;
            valid = true;
        }
        if (txt_Email.Text != "")
        {
            if (this.txt_Email.Text.IndexOf(".") == -1 | this.txt_Email.Text.IndexOf("@") == -1)
            {
                //lblError.Text = "You did not enter a valid email address."; 
                lblError.Text = "Please enter a valid email address.";
                lblError.Visible = true;
                valid = false;
            }
        }
        else
        {
        }
        return valid;
    }
    public int ascii_fun(char str1)
    {
        char a;
        a = str1;
        int asc = a; // First way
        return asc;
    }

    protected void Bttn_Save_Click(object sender, ImageClickEventArgs e)
    {
        if (customValid())
        {
            Page.Validate();
            if (Page.IsValid)
            {
                ObjUser.USER_ID = Txt_Userid.Text;
                ObjUser.GroupID = ddlGroupName.SelectedItem.Value;
                ObjUser.Telephone = txt_Tel.Text.Trim();
                ObjUser.UserName = Txt_Name.Text.Trim();
                ObjUser.Desg = txtDesg.Text.Trim();
                ObjUser.UserPassword = objSecurity.Encrypt(txt_Password.Text.Trim());
                ObjUser.UserEmail = txt_Email.Text.Trim();
                ObjUser.UserActive = "Y";
                ObjUser.maintby = Session["USER_ID"].ToString();
                /**************************************************/
                ObjUser.DeptID = "";//ddlDept.SelectedValue;
                ObjUser.Update_Users();
                //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
                //string response = "<script type='text/javascript'>alert('User has been successfully saved');parent.mainframe.location.href='" + navurl + "';</script>";
                //Response.Write(response);

                //Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0] + "?showList=Y"); 
                //changes

                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");



            }
        }
    }
    protected void Bttn_Back_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0]);
    }
    protected void btnReset_Click(object sender, ImageClickEventArgs e)
    {

        Uid = Convert.ToString(ViewState["IDforEdit"]);
        Bind_Data();

    }
}