using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ABSSecurity;

public partial class Administration_Default : System.Web.UI.Page
{
    User_Logic ObjUser = new User_Logic();
    Security objSecurity = new Security();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack))
        {

            if (System.Convert.ToBoolean(Session["TimeOut"]))
                Response.Write("<script>document.status='TimeOut';</script>");
            // Session.Clear();
            this.txtUserId.Text = "";
            // this.txtUserId.Attributes.Add("onBlur", "document.form1['" + txtPwd.ClientID + "'].focus();");
            if (txtUserId.Text == "")
                txtUserId.Focus();
        }
        else
        {
            if (txtUserId.Text == "")
                txtUserId.Focus();

        }
    }

    private void IsAdmin(DataTable DT_Temp)
    {
        Session["U_ID"] = DT_Temp.Rows[0]["UID"].ToString();
        Session["USER_GUID"]=DT_Temp.Rows[0]["UID"].ToString();
        Session["USER_ID"] = DT_Temp.Rows[0]["USER_ID"].ToString();
        Session["GROUP_ID"] = DT_Temp.Rows[0]["GROUP_ID"].ToString();
        Session["USER_NM"] = DT_Temp.Rows[0]["USER_NM"].ToString();
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
         if (txtUserId.Text.Trim() == "")
            {
                Lblerror.Text = "Please enter User name.";
                Lblerror.Visible = true;
                return;
            }
            else if (txtPwd.Text == "")
            {
                Lblerror.Text = "Please enter Password.";
                Lblerror.Visible = true;
                return;
            }
            else
            {
                Lblerror.Visible = true;
            }
            UserMgmt userMgmt = new UserMgmt();
            userMgmt.UserID = this.txtUserId.Text.Trim();
            userMgmt.Password = objSecurity.Encrypt(this.txtPwd.Text.Trim());

            DataSet dsLogins = userMgmt.CheckUserLog();

            if (dsLogins != null && dsLogins.Tables[0].Rows != null && dsLogins.Tables[0].Rows.Count > 0)
            {
                if (dsLogins.Tables[0].Rows[0][0].ToString() == "1")
                {
                    IsAdmin(dsLogins.Tables[0]);
                    //Response.Redirect("Main_administration.aspx");
                    Response.Redirect("Main.aspx");
                }
                //else if (dsLogins.Tables[0].Rows[0][0].ToString() == "2")
                //{
                //    Lblerror.Text = "Invalid Password. Please try again.";
                //    Lblerror.Visible = true;
                //}
                else
                {
                    //Lblerror.Text = "Invalid User name. Please try again.";
					Lblerror.Text = "The username or password you entered is incorrect.";
                    Lblerror.Visible = true;
                }
            }
     }
    
}
