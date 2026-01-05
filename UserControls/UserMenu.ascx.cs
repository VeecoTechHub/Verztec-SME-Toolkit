using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ABSDTO;
using ABSCommon;

public partial class UserControls_UserMenu : System.Web.UI.UserControl
{
    UserMgmt objUserMgmt = new UserMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
    }

    protected void lBtnLogout_Click(object sender, EventArgs e)
    {
       
        if (Session["LoginDTO"] != null && Session["LoginDTO"] != "")
        {



            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            objLoginDTO.UserID = objLoginDTO.UserID;
            objLoginDTO.Flag = "Update";


            ////
            //// ateeq 20sept when logout.....
            Common objCommon = new Common();

            if (objCommon.CheckFeedback(objLoginDTO.UserID))
            {
                string strReferURL = Request.UrlReferrer.ToString();
                string strReferPath = Request.Path.ToString();

                string subpath = strReferURL.Substring(strReferURL.Length - 12);

                if (subpath.ToLower().Equals("reports.aspx"))
                {
                    Session["isRedirect"] = "YES";
                    Session["RedirectURL"] = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx";
                    Session["RedirectLogout"] = "YES";
                    Response.Redirect("~/Public/FMFeedback.aspx", false);
                    return;
                }

            }

            if (Session["LogId"] != "" && Session["LogId"] != null)
            {
                objLoginDTO.LogId = Convert.ToInt32(Session["LogId"]);
            }

            MaintainUserLogDetails(objLoginDTO);

            Session.Abandon();
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {
            Session.Abandon();
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
    }

    private void MaintainUserLogDetails(LoginDTO objDTO)
    {
        try
        {
            ABSBLL.Registration objRegs = new ABSBLL.Registration();

            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                objDTO.Culture = 2;
            else
                objDTO.Culture = 1;

            objRegs.InsertUserLogs(objDTO);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}