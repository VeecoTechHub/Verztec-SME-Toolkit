using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ABSDTO;
using System.Globalization;
using System.Threading;


public partial class Public_faq : System.Web.UI.Page
{
    UserMgmt objUserMgmt = new UserMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");

        }
        if (!IsPostBack)
        {

            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
            ViewState["IndustryId"] = objLoginDTO.IndustryID;

            //Added by Mahesh to Insert ModuleTrack Records
            //Added on 05/03/2012
            objUserMgmt.UserID = ViewState["UserID"].ToString();
            objUserMgmt.AccessBy = Session["USER_ID"].ToString();
            objUserMgmt.CategoryId = 6;
            objUserMgmt.PageView = "Y";
            objUserMgmt.AccessDescription = "Access faq page";
            objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                objUserMgmt.Culture = 2;
            else
                objUserMgmt.Culture = 1;
            objUserMgmt.InsertModuleTrack(objUserMgmt);
        }

        lblLink.Text = Convert.ToString(GetLocalResourceObject("lblLinkResource1.Text"));
        lblQuote.Text = Convert.ToString(GetLocalResourceObject("lblQuoteResource1.Text"));
        lblQuote1.Text = Convert.ToString(GetLocalResourceObject("lblQuote1Resource1.Text"));
        lblLink2.Text = Convert.ToString(GetLocalResourceObject("lblLink2Resource1.Text"));
        lblLink3.Text = Convert.ToString(GetLocalResourceObject("lblLink3Resource1.Text"));
    }

    protected override void InitializeCulture()
    {
        string culture = string.Empty;
        culture = Convert.ToString(Session["Culture"]);
        if (culture != "Auto")
        {
            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            //Get Browser Language

            //string browserLanguage = Request.UserLanguages[0];
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(browserLanguage);
            //string s=Thread.CurrentThread.CurrentCulture.DisplayName;
        }

    }
}
