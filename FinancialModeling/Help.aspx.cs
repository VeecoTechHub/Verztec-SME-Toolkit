using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSCommon;
using System.Configuration;
using ABSDTO;
using System.Globalization;
using System.Threading;

public partial class FinancialModeling_Help : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////
        //// ateeq 20sept when logout.....
        Common objCommon = new Common();
        if (Session["LoginDTO"] != null)
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            if (objCommon.CheckFeedback(objLoginDTO.UserID))
            {
                string strReferURL = Request.UrlReferrer.ToString();
                string strReferPath = Request.Path.ToString();

                string subpath = strReferURL.Substring(strReferURL.Length - 12);

                if (subpath.ToLower().Equals("reports.aspx"))
                {
                    Session["isRedirect"] = "YES";
                    Session["RedirectURL"] = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "/FinancialModeling/Help.aspx";
                    Session["RedirectLogout"] = "NO";
                    Response.Redirect("~/Public/FMFeedback.aspx", false);
                    return;
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
