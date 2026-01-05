using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSDTO;
using ABSSecurity;
using System.Configuration;
using System.Globalization;
using System.Threading;

public partial class Public_ChangePassword : System.Web.UI.Page
{
    Security objSecurity = new Security();
    LoginDTO objLoginDTO;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objLoginDTO = (LoginDTO)Session["LoginDTO"];
            if (objLoginDTO == null)
                Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtEmail.Text = string.Empty;
        txtExistingPassword.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtRePassword.Text = string.Empty;
        lblEmailWrong.Visible = false;
        lblErrorMessage.Visible = false;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        lblEmailWrong.Visible = false;
        LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
        if (objLoginDTO != null)
        {
            if (objLoginDTO.EmailID != null)
            {
                if (!objLoginDTO.EmailID.Equals(txtEmail.Text))
                {
                    lblEmailWrong.Visible = true;
                    lblEmailWrong.Text = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text"));
                }
                else
                {
                    try
                    {
                        ChangePassword objCP = new ChangePassword();
                        objCP.StrEmailID = txtEmail.Text.Trim();
                        objCP.StrExistingPassword = objSecurity.Encrypt(txtExistingPassword.Text.Trim());
                        objCP.strNewPassword = objSecurity.Encrypt(txtPassword.Text.Trim());
                        int intresult = objCP.UpdatePassword(objCP);
                        if (intresult == 1)
                        {
                            lblErrorMessage.Text = Convert.ToString(GetLocalResourceObject("lblDes2Resource1.Text"));
                            lblErrorMessage.Visible = true;
                        }
                        else
                        {
                            lblErrorMessage.Visible = true;
                            lblErrorMessage.Text = Convert.ToString(GetLocalResourceObject("lblDes3Resource1.Text"));
                        }
                    }
                    catch (Exception err)
                    {
                        lblErrorMessage.Text = err.Message.ToString();
                    }

                }
            }

        }
    }

    protected override void InitializeCulture()
    {
        string culture = string.Empty;
        //culture = Request.Form["ddlLang"];
        // if (string.IsNullOrEmpty(culture)) culture = "Auto";
        //   UICulture = "zh-SG";
        //  Page.Culture = "zh-SG";
        culture = Convert.ToString(Session["Culture"]);
        if (culture != "Auto")
        {
            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

        }

    }
}
