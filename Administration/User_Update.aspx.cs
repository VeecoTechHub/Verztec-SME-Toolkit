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
        try
        {
            if (!(Page.IsPostBack))
            {
                ViewState["Links"] = chkAccess.initSystem();
                ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[0];
                ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
                token = Request["token"];

                if (token == null)
                {
                    Response.Redirect("~/Administration/Default.aspx");
                }
                else
                {
                    if (Request["IDforEdit"] == null || Request["IDforEdit"].ToString() == "")
                    {
                        Uid = "";
                    }
                    else
                    {
                        try
                        {
                            string encryptedId = HttpUtility.UrlDecode(Request["IDforEdit"].ToString());
                            Uid = CommonFunctions.Decrypt(encryptedId);
                            
                            // Validate that Uid is not empty before binding data
                            if (!string.IsNullOrEmpty(Uid))
                            {
                                Bind_Data();
                            }
                            else
                            {
                                throw new Exception("Decrypted USER_ID is empty");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("Error in Page_Load: " + ex.Message);
                            System.Diagnostics.Debug.WriteLine("Stack Trace: " + ex.StackTrace);
                            Response.Redirect("~/Administration/Default.aspx");
                            return;
                        }
                    }
                    ViewState["IDforEdit"] = Uid;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Outer Page_Load Error: " + ex.Message);
            System.Diagnostics.Debug.WriteLine("Stack Trace: " + ex.StackTrace);
            Response.Redirect("~/Administration/Default.aspx");
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
        try
        {
            if (Uid != "")
            {
                ObjUser.GetUsers(Uid);
                
                // Check if user data was actually loaded
                if (string.IsNullOrEmpty(ObjUser.UserName))
                {
                    throw new Exception("User data not found for ID: " + Uid);
                }
            }

            DataSet groupsDS = ObjUser.GetAllGroups(Session["GROUP_ID"].ToString());
            if (groupsDS != null && groupsDS.Tables.Count > 0 && groupsDS.Tables[0].Rows.Count > 0)
            {
                ddlGroupName.DataSource = groupsDS;
                ddlGroupName.DataTextField = "GROUP_DESCR";
                ddlGroupName.DataValueField = "GROUP_ID";
                ddlGroupName.DataBind();
                
                if (!string.IsNullOrEmpty(ObjUser.GroupID) && ddlGroupName.Items.FindByValue(ObjUser.GroupID) != null)
                    ddlGroupName.Items.FindByValue(ObjUser.GroupID).Selected = true;
            }
            
            if (Session["GROUP_ID"] != null && Session["GROUP_ID"].ToString() == "ADUST01")
                ddlGroupName.Enabled = false;

            Txt_Userid.Text = CommonBindings.TextToBind(ObjUser.USER_ID);
            txtDesg.Text = CommonBindings.TextToBind(ObjUser.Desg);
            txt_Tel.Text = CommonBindings.TextToBind(ObjUser.Telephone);
            txt_Password.Text = CommonBindings.TextToBind(ObjUser.UserPassword);
            txt_ConPassword.Text = CommonBindings.TextToBind(ObjUser.UserPassword);
            txt_Email.Text = CommonBindings.TextToBind(ObjUser.UserEmail);
            Txt_Name.Text = CommonBindings.TextToBind(ObjUser.UserName);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Bind_Data Error: " + ex.Message);
            System.Diagnostics.Debug.WriteLine("Stack Trace: " + ex.StackTrace);
            throw;
        }
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