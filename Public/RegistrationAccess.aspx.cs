using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSCommon;
using System.Configuration;
using ABSBLL;
using System.Data;
using ABSDTO;
using System.Globalization;
using System.Threading;


public partial class Public_RegistrationAccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAgree_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["UID"] != null)
            {
                string strUID = Request.QueryString["UID"].ToString();
                if (CommonBindings.IsGuid(strUID))
                {
                    ABSBLL.Registration objRegs = new ABSBLL.Registration();
                    DataSet dsUser = objRegs.GetUserDetails(strUID, "", "userid");
                    if (dsUser != null && dsUser.Tables.Count > 0)
                    {
                        if (dsUser.Tables[0].Rows.Count > 0)
                        {
                          //  string str = Request.Url.ToString();
                            //int startindex = str.ToLower().IndexOf("ABS");
                            //string sub = str.Substring(0, startindex);
                            //string sub = str.Replace("RegistrationAccess.aspx", "RegsAccessActivation.aspx");

                            //Dictionary<string, string> tempValue = new Dictionary<string, string>();

                            //string strMapPath = string.Empty;
                            //if (Convert.ToString(Session["Culture"]) == "zh-SG")
                            //{
                            //    strMapPath = ConfigurationManager.AppSettings["AdminNotificationMailHtmlzhSG"];
                            //}
                            //else
                            //    strMapPath = ConfigurationManager.AppSettings["AdminNotificationMailHtml"];

                            //string strToMail = dsUser.Tables[0].Rows[0]["EmailID"].ToString();
                            //string strGivenName = dsUser.Tables[0].Rows[0]["Name"].ToString();
                            //Session["UserName"] = strGivenName;
                            //Session["EmailID"] = strToMail;
                            //tempValue["<!--GivenName-->"] = strGivenName;
                            //tempValue["<!--URLPart-->"] = "<a href='" + sub + "'>" + sub + "</a> ";
                            //tempValue["<!--ActCode-->"] = dsUser.Tables[0].Rows[0]["ActivationKey"].ToString();

                            //string path = Server.MapPath(strMapPath);
                            //HTMLParser htmlParser = new HTMLParser();
                            //string strBody = htmlParser.getBody("ACK", tempValue, path);

                            //// Code to send Notification Mail
                            //string subject = Convert.ToString(GetLocalResourceObject("lblMsgResource1.Text"));
                            //MailManager objMailManager = new MailManager();
                            //objMailManager.sendNotificationMail(strToMail, strGivenName, strBody, subject);
                            // End Code

                            RegistrationDTO objDTO = new RegistrationDTO();
                            objDTO.UserID = strUID;
                            objDTO.Status = "Completed";
                            objDTO.Action = "Activation";

                            // Updating the user status as 'Completed' so that user can log in to the system
                            objRegs.UpdateUserStatus(objDTO);

                            Response.Redirect("RegistrationSuccess.aspx");

                        }
                    }
                }
                else
                    Response.Redirect("~/Error_Page.aspx");
            }
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string strUID = Request.QueryString["UID"].ToString();
        ABSBLL.Registration objRegs = new ABSBLL.Registration();
        RegistrationDTO objDTO = new RegistrationDTO();
        objDTO.UserID = strUID;
        objDTO.Status = "disagree";
        objDTO.Action = "Activation";

        // Updating the user status as 'Completed' so that user can log in to the system
        objRegs.UpdateUserStatus(objDTO);

        Response.Redirect("~/Default.aspx");
    }
}