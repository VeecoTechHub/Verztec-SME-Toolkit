using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using ABSBLL;
using ABSDAL;
using ABSDTO;
using System.Configuration;
using System.Web.UI.HtmlControls;
using ABSCommon;
using System.Globalization;
using System.Threading;

public partial class Reports : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    UserMgmt objUserMgmt = new UserMgmt();

    Report_BLL bll = new Report_BLL();
    //public static string strLblClientIds = string.Empty;   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {

                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                ViewState["IndustryId"] = objLoginDTO.IndustryID;
                objFinModelingMgmt.UserID = objLoginDTO.UserID;
                // DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();

                //Page.Header.DataBind();
                ViewState["Graph"] = "ReportsHome";
                bindUserControl("ReportsHome.ascx");
                DataTable dtCompanyFinDetails = objFinModelingMgmt.Get_CompanyFinDetails(ViewState["UserID"].ToString());
                ddlRoundDollar.SelectedValue = dtCompanyFinDetails.Rows[0][1].ToString();
                ViewState["Id"] = dtCompanyFinDetails.Rows[0][0].ToString();
                Session["RoundDollar"] = dtCompanyFinDetails.Rows[0][1].ToString();

                //To Insert ModuleTrack Records
                objUserMgmt.UserID = ViewState["UserID"].ToString();
                objUserMgmt.AccessBy = Session["USER_ID"].ToString();
                objUserMgmt.CategoryId = 4;
                objUserMgmt.PageView = "Y";
                objUserMgmt.AccessDescription = "Access Reports";
                objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                if (Convert.ToString(Session["Culture"]) == "zh-SG")
                    objUserMgmt.Culture = 2;
                else
                    objUserMgmt.Culture = 1;

                objUserMgmt.InsertModuleTrack(objUserMgmt);

            }

            ViewState["hlkImageURL"] = Convert.ToString(GetLocalResourceObject("lblFakeHomeResource1.Text"));
            hlkHome.ImageUrl = Convert.ToString(ViewState["hlkImageURL"]);
            ViewState["imgbtnImageURL"] = Convert.ToString(GetLocalResourceObject("lblDownloadReportFakeResource1.Text"));
            imgbtnDownloadReport.ImageUrl = Convert.ToString(ViewState["imgbtnImageURL"]);

            imgBtnHightlight.ImageUrl = Convert.ToString(GetLocalResourceObject("lblHighResource1.Text"));
            imgBtnBreakeven.ImageUrl = Convert.ToString(GetLocalResourceObject("lblBreakevenResource1.Text"));
            imgBtnWorkingCapital.ImageUrl = Convert.ToString(GetLocalResourceObject("lblWorkingCapitalResource1.Text"));
            imgBtnCashFlow.ImageUrl = Convert.ToString(GetLocalResourceObject("lblCashFlowResource1.Text"));
            imgBtnFunding.ImageUrl = Convert.ToString(GetLocalResourceObject("lblFundingResource1.Text"));
            imgBtnAppendix.ImageUrl = Convert.ToString(GetLocalResourceObject("lblApp1Resource1.Text"));
            imgBtnAppendix2.ImageUrl = Convert.ToString(GetLocalResourceObject("lblApp2Resource1.Text"));


        }


    }
    private void bindUserControl(string strUcName)
    {
        try
        {
            string strUcPath = "~/UserControls/";//FinancialModeling_UserControls/";
            Control fsGraph = null;
            fsGraph = LoadControl(strUcPath + strUcName);
            phFinancialGraphs.Controls.Clear();
            phFinancialGraphs.Controls.Add(fsGraph);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void imgBtnHightlight_Click(object sender, ImageClickEventArgs e)
    {
        // imgHeader.ImageUrl = "~\\images\\highlightsbar.png";
        phFinancialGraphs.Controls.Clear();
        ViewState["Graph"] = "Hightlights";


        bindUserControl("Hightlights.ascx");





    }
    protected void imgBtnBreakeven_Click(object sender, ImageClickEventArgs e)
    {
        ///  imgHeader.ImageUrl = "~\\images\\breakeven.png";
        phFinancialGraphs.Controls.Clear();
        ViewState["Graph"] = "breakeven";


        bindUserControl("breakeven.ascx");

    }
    protected void imgBtnWorkingCapital_Click(object sender, ImageClickEventArgs e)
    {
        //  imgHeader.ImageUrl = "~\\images\\workingcaptialbar.png";
        phFinancialGraphs.Controls.Clear();
        ViewState["Graph"] = "WorkingCapital";

        bindUserControl("WorkingCapital.ascx");
    }
    protected void imgBtnCashFlow_Click(object sender, ImageClickEventArgs e)
    {
        // imgHeader.ImageUrl = "~\\images\\cashflowbar.png";
        phFinancialGraphs.Controls.Clear();
        ViewState["Graph"] = "CashFlow";

        bindUserControl("CashFlow.ascx");

    }
    protected void imgBtnFunding_Click(object sender, ImageClickEventArgs e)
    {
        // imgHeader.ImageUrl = "~\\images\\fundingbar.png";
        phFinancialGraphs.Controls.Clear();
        ViewState["Graph"] = "Funding";

        bindUserControl("Funding.ascx");

    }
    protected void imgBtnAppendix_Click(object sender, ImageClickEventArgs e)
    {
        // imgHeader.ImageUrl = "~\\images\\appendixbar.png";
        phFinancialGraphs.Controls.Clear();
        ViewState["Graph"] = "Appendix";

        bindUserControl("TradeCycle.ascx");

    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] != null && Session["LoginDTO"] != "")
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["IndustryId"] = objLoginDTO.IndustryID;

            objFinModelingMgmt.UserID = objLoginDTO.UserID;
            objFinModelingMgmt.RoundDollar = Convert.ToInt32(ddlRoundDollar.SelectedValue);

            Session["RoundDollar"] = ddlRoundDollar.SelectedValue.ToString();
            objFinModelingMgmt.Update_CompanyFinDetails(objFinModelingMgmt);

            ViewState["Graph"] = "ReportsHome";

            objUserMgmt.UserID = objLoginDTO.UserID;
            if (Session["USER_ID"] != null && Session["USER_ID"] != "")
            {
                objUserMgmt.AccessBy = Session["USER_ID"].ToString();
            }
            objUserMgmt.CategoryId = 4;
            objUserMgmt.PageView = "Y";
            objUserMgmt.AccessDescription = "Reports_ChangedRounded";
            if (ViewState["IndustryId"] != null && Convert.ToString(ViewState["IndustryId"]) != "")
            {
                objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"].ToString());
            }
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                objUserMgmt.Culture = 2;
            else
                objUserMgmt.Culture = 1;

            objUserMgmt.InsertModuleTrack(objUserMgmt);
        }


        bindUserControl("ReportsHome.ascx");
    }
    protected void imgBtnHome_Click(object sender, ImageClickEventArgs e)
    {

        ViewState["Graph"] = "ReportsHome";
        phFinancialGraphs.Controls.Clear();
        bindUserControl("ReportsHome.ascx");
    }


    protected void imgbtnDownloadReport_Click(object sender, ImageClickEventArgs e)
    {
        Session["isRedirect"] = null;
        Response.Redirect("~/Public/FMFeedback.aspx", false);
    }

    protected void imgBtnAppendix2_Click(object sender, ImageClickEventArgs e)
    {
        // imgHeader.ImageUrl = "~\\images\\appendixbar.png";
        phFinancialGraphs.Controls.Clear();


        ViewState["Graph"] = "Appendix";

        bindUserControl("Appendix.ascx");
    }

    protected void imgBtnGenerateReport_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Reports.aspx");
    }


    void GoToFeedback(string strPageName)
    {
        ////
        //// ateeq 20sept when logout.....
        Common objCommon = new Common();
        LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
        //ViewState["UserID"] = objLoginDTO.UserID;
        if (objCommon.CheckFeedback(objLoginDTO.UserID))
        {
            string strReferURL = Request.UrlReferrer.ToString();
            string strReferPath = Request.Path.ToString();

            string subpath = strReferURL.Substring(strReferURL.Length - 12);

            if (subpath.ToLower().Equals("reports.aspx"))
            {
                Session["isRedirect"] = "YES";
                Session["IsSkip"] = "YES";
                Session["RedirectURL"] = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "/FinancialModeling/" + strPageName + ".aspx";
                Session["RedirectLogout"] = "NO";
                Response.Redirect("~/Public/FMFeedback.aspx", false);
                return;
            }

        }
        else
        {
            Response.Redirect(strPageName + ".aspx");
        }
    }
    protected void imgbtnStatements_Click(object sender, ImageClickEventArgs e)
    {

        GoToFeedback("SciStatement");
        return;

    }
    protected void imgbtnHome_Click(object sender, ImageClickEventArgs e)
    {
        GoToFeedback("FinancialModelingHome");
        return;
        //Response.Redirect("FinancialModelingHome.aspx");
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