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

public partial class Administration_User_Add : System.Web.UI.Page
{
    private User_Logic ObjnewUser = new User_Logic();
    Check_Access chkAccess = new Check_Access();
    Security objSecurity = new Security();
    private string StrCheckAccess;

    private CommonFunctions CommonFunctions = new CommonFunctions();
    //SystemParamvalues SystemParams = new SystemParamvalues();

    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!(Page.IsPostBack))
        {
        
            ViewState["Links"] = chkAccess.initSystem();
            //ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[1];
            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[0];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            token = Request.Form["token"];

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {
                Bind_Data();

            }

        }
        Response.Write("<script language=javascript>var flg; flg=false</script>");
        //Button_Save.Attributes.Add("onClick", "return confirm('Do you want to add this user? Click OK to Add. Otherwise, click Cancel.');");
        //Button_Save.Attributes.Add("onClick", "return confirm('Are you sure to add this user?');");
    }

    void Bind_Data()
    {

        DataSet Ds_Group;
        Ds_Group = ObjnewUser.GetAllGroups(Session["group_id"].ToString());
        Lst_Group.DataSource = Ds_Group;
        Lst_Group.DataTextField = "GROUP_DESCR";
        Lst_Group.DataValueField = "GROUP_ID";
        Lst_Group.DataBind();
        Ds_Group = null;
        if (Session["GROUP_ID"].ToString() == "ADUST01")
            Lst_Group.Enabled = false;

        //DataSet Ds_Dept;
        //Ds_Dept = ObjnewUser.GetAllDepartments();
        //Lst_Dept.DataSource = Ds_Dept;
        //Lst_Dept.DataTextField = "Description";
        //Lst_Dept.DataValueField = "DeptID";
        //Lst_Dept.DataBind();
        //Ds_Dept = null;
    }



    private bool customValid()
    {
        string strError = "";
        bool valid = true;
        //if (Txt_Name.Text.Trim() == "" | Txt_Userid.Text.Trim() == "" | Lst_Group.SelectedItem.Value == "" | txt_Email.Text == "" | txt_Password.Text == "" | txt_ConPassword.Text == "")
        //{
        //    //strError = "Please enter the data for all fields.<br>"; 
        //    strError = "Fields marked '*' are compulsory.";
        //    valid = false;
        //}
        //if (txt_Password.Text.Length < 8 | txt_ConPassword.Text.Length < 8) 
        //{ 
        //    //strError = strError + "Password or Confirm Password should have minimum 8 characters. No special characters are allowed. <br>"; 
        //    strError = strError + "Password or Confirm Password should be atleast 8 characters and accepts only alphanumerics. ";
        //    valid = false; 
        //}

        foreach (char a in txt_Password.Text)
        {
            if (!(((ascii_fun(a) >= 48 & ascii_fun(a) <= 57) | (ascii_fun(a) > 64 & ascii_fun(a) < 91) | (ascii_fun(a) > 96 & ascii_fun(a) < 123))))
            {
                strError = strError + "No special characters are allowed for Passwords.";
                valid = false;
                goto exitForStatement0;
            }
        }
    exitForStatement0: ;
        foreach (char a in Txt_Userid.Text)
        {
            if (!(((ascii_fun(a) >= 48 & ascii_fun(a) <= 57) | (ascii_fun(a) > 64 & ascii_fun(a) < 91) | (ascii_fun(a) > 96 & ascii_fun(a) < 123))))
            {
                strError = strError + "No special characters are allowed for UserID. ";
                valid = false;
                goto exitForStatement1;
            }
        }
    exitForStatement1: ;
        if (txt_Password.Text.Trim() != txt_ConPassword.Text.Trim())
        {
            //strError = strError + "Password and Confirm Password must be the same.<br>"; 
            strError = strError + "Password and Confirm Password must be same.";
            valid = false;
        }
        if (strError != "")
        {
            lblError.Text = strError;
            lblError.Visible = true;
        }
        else
        {
            lblError.Visible = false;
        }
        if (this.txt_Email.Text != "")
        {
            if (this.txt_Email.Text.IndexOf(".") == -1 | this.txt_Email.Text.IndexOf("@") == -1)
            {
                lblError.Text = "Please enter a valid email address.";
                valid = false;
            }
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
    public int instr_fun(string str1, string str2)
    {
        string SearchString;
        SearchString = str1;
        int myPos = SearchString.IndexOf(str2);
        return myPos;
    }

    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {
        if (customValid())
        {
            Page.Validate();
            if (Page.IsValid)
            {
                //int password_minLength;
                //password_minLength = Convert.ToInt32(SystemParams.getSystemParam("Password_Min_Length"));
                //if (txt_Password.Text.Length < password_minLength)
                //{
                //    lblError.Text = "Passwords should contain at least " + password_minLength + " alphanumeric characters.";
                //    //lblError.Text = "Password should be minimum of " + password_minLength + " characters";
                //    lblError.Visible = true;
                //    return; 
                //}

                if (ObjnewUser.Check_Duplicate(this.Txt_Userid.Text))
                {
                    lblError.Text = "A user already exists with this ID, Please try with a new user ID";
                    lblError.Visible = true;
                    return;
                }
                ObjnewUser.UserID = CommonBindings.TextToBind(Txt_Userid.Text.Trim());

                ObjnewUser.CompanyCode = "";
                ObjnewUser.GroupID = Lst_Group.SelectedItem.Value;
                ObjnewUser.Telephone = CommonBindings.TextToBind(txt_Tel.Text.Trim());
                ObjnewUser.UserName = CommonBindings.TextToBind(Txt_Name.Text.Trim());
                ObjnewUser.Desg = CommonBindings.TextToBind(txtDesg.Text);

                ObjnewUser.UserPassword = objSecurity.Encrypt(CommonBindings.TextToBind(txt_Password.Text.Trim()));
                ObjnewUser.UserEmail = CommonBindings.TextToBind(txt_Email.Text.Trim());
                ObjnewUser.UserActive = "Y";
                ObjnewUser.Creatby = Session["USER_ID"].ToString();
                ObjnewUser.MAINT_BY = Session["USER_ID"].ToString();
                //ObjnewUser.RoleID = Lst_Role.SelectedItem.Value;
                ObjnewUser.DeptID = "";//Lst_Dept.SelectedItem.Value;
                //#Multiple Logins: To select multiple logins OR Restricted no of logins

                ObjnewUser.NumLogins = 1;

                ObjnewUser.addUsers();

                //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
                //string response = "<script type='text/javascript'>alert('User has been successfully added');parent.mainframe.location.href='" + navurl + "';</script>";
                //Response.Write(response);

                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");


                Txt_Userid.Text = "";
                Txt_Name.Text = "";
                txt_Email.Text = "";
                txt_Tel.Text = "";
                //Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0] + "?showList=Y"); 
            }
        }
    }

    //protected void Bttn_clear_Click(object sender, System.EventArgs e)
    //{
    //Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[1])); 
    //}

    protected void Bttn_Search_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[0]));
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Txt_Userid.Text = "";
        Txt_Name.Text = "";
        txt_Email.Text = "";
        txt_Tel.Text = "";
        txtDesg.Text = "";
        Lst_Group.SelectedIndex = 0;
    }


}
