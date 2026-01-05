using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using ABSDTO;
using ABSCommon;
using System.Configuration;
using System.Globalization;
using System.Threading;
public partial class Public_ForgotPassword : System.Web.UI.Page
{
    ForgotPassword obj_FGPwd = new ForgotPassword();
    

    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strMsg = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text"));
        string strMsg1 = Convert.ToString(GetLocalResourceObject("lblDes2Resource1.Text"));
        string strMsg2 = Convert.ToString(GetLocalResourceObject("lblDes3Resource1.Text"));
        lblEmailMsg.Text = string.Empty;
        try
        {
            obj_FGPwd.EmailID = txtEmail.Text.ToString();
            DataSet ds_regs = obj_FGPwd.GetUserStatus(obj_FGPwd.EmailID);
            if (ds_regs.Tables[0].Rows.Count > 0)
            {
                obj_FGPwd.Status = ds_regs.Tables[0].Rows[0]["Status"].ToString();
                if (obj_FGPwd.Status == "Completed")
                {
                    obj_FGPwd.UserID = ds_regs.Tables[0].Rows[0]["UserID"].ToString();
                    obj_FGPwd.ActivationID = Guid.NewGuid().ToString();
                    obj_FGPwd.ExpiryDate = DateTime.Now;

                    // insert activation ID into forgotpassword table
                    int Id = obj_FGPwd.InsertForgotPWdDetails(obj_FGPwd);
                    Sendmail();
                   // ABSCommon.Common.ShowMessage(this, "Password reset link sent to " + obj_FGPwd.EmailID);
                    ABSCommon.Common.ShowMessage(this, strMsg);
                   

                }
                else
                {
                    //ABSCommon.Common.ShowMessage(this, "Your account was not activated or deleted");
                    lblEmailMsg.Text = strMsg1;
                }
            }
            else
            {
                //ABSCommon.Common.ShowMessage(this, "Please provide previously registered email id");
                lblEmailMsg.Text = strMsg2;
            }
            txtEmail.Text = "";
           

        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

    public void Sendmail()
    {
        try
        {
            string strActID = obj_FGPwd.ActivationID.ToString();
            if (CommonBindings.IsGuid(strActID))
            {
               
                        string str = Request.Url.ToString();                        
                        string sub = str.Replace("ForgotPassword.aspx", "ResetPassword.aspx");

                        Dictionary<string, string> tempValue = new Dictionary<string, string>();

                        string strMapPath = string.Empty;
                        if (Convert.ToString(Session["Culture"]) == "zh-SG")
                            strMapPath = ConfigurationManager.AppSettings["ForgotPasswordMailHtmlzhSG"];
                        else
                            strMapPath = ConfigurationManager.AppSettings["ForgotPasswordMailHtml"];

                        string strToMail = obj_FGPwd.EmailID ;//dsUser.Tables[0].Rows[0]["EmailID"].ToString();
                        //string strGivenName = dsUser.Tables[0].Rows[0]["Name"].ToString();
                        //tempValue["<!--GivenName-->"] = strGivenName;

                        tempValue["<!--URLPart-->"] = "<a href='" + sub + "'>" + sub + "</a> ";
                        tempValue["<!--ActCode-->"] = strActID;

                        string path = Server.MapPath(strMapPath);
                        HTMLParser htmlParser = new HTMLParser();
                        string strBody = htmlParser.getBody("ACK", tempValue, path);

                        // Code to send Forgot Password Mail

                        string subject = Convert.ToString(GetLocalResourceObject("lblDes4Resource1.Text"));
                        MailManager objMailManager = new MailManager();
                        objMailManager.sendForgotPasswordMail(strToMail, strBody,subject);
                        // End Code                     
                                   
                
            }
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        txtEmail.Text = "";

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