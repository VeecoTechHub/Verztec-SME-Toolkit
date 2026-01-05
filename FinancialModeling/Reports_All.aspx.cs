using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using ABSDAL;
using ABSBLL;
using ABSDTO;
using System.Configuration;
using System.Globalization;
using System.Threading;

public partial class Reports_All : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    public int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["UserId"] != null)
        {
            ViewState["UserID"] = Convert.ToString(Request.QueryString["UserId"]);
        }

        else if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
        }
        string userID = ViewState["UserID"].ToString();
        objFinModelingMgmt.UserID = userID;
        DataSet dsSegment = objFinModelingMgmt.getDataBySection(1);
        DataTable dtFsMapping = dsSegment.Tables[0];
        if (dtFsMapping.Rows.Count > 0)
        {
            string[] pvalue = new string[3];
            //int count = 0;
            DataRow drTradingGoods = getFsMappingValue(dtFsMapping, 33);
            pvalue[0] = drTradingGoods["P1_Value"].ToString();
            DataRow drManufacturingSale = getFsMappingValue(dtFsMapping, 34);
            pvalue[1] = drManufacturingSale["P1_Value"].ToString();
            DataRow drServices = getFsMappingValue(dtFsMapping, 35);
            pvalue[2] = drServices["P1_Value"].ToString();
            for (int i = 0; i < pvalue.Length; i++)
            {
                if (pvalue[i] != string.Empty)
                    count = count + 1;
            }
            if (count < 2)
            {
               // trCss.Style.Add("Height", "700px");
                trCss.Attributes.Add("class", "HideTR1");
            }
            else
            {
                trCss.Attributes.Add("class", "HideTR2");
                //trCss.Style.Add("Height", "2100px");
            }

        }

        imgBtnHightlight.ImageUrl = Convert.ToString(GetLocalResourceObject("lblHighResource1.Text"));
        imgBtnBreakeven.ImageUrl = Convert.ToString(GetLocalResourceObject("lblBreakevenResource1.Text"));
        imgBtnWorkingCapital.ImageUrl = Convert.ToString(GetLocalResourceObject("lblWorkingCapitalResource1.Text"));
        imgBtnCashFlow.ImageUrl = Convert.ToString(GetLocalResourceObject("lblCashFlowResource1.Text"));
        imgBtnFunding.ImageUrl = Convert.ToString(GetLocalResourceObject("lblFundingResource1.Text"));
        imgBtnAppendix1.ImageUrl = Convert.ToString(GetLocalResourceObject("lblApp1Resource1.Text"));
        imgBtnAppendix2.ImageUrl = Convert.ToString(GetLocalResourceObject("lblApp2Resource1.Text"));

        ImageButton1.ImageUrl = Convert.ToString(GetLocalResourceObject("lblHigh1Resource1.Text"));
        ImageButton2.ImageUrl = Convert.ToString(GetLocalResourceObject("lblBreakeven1Resource1.Text"));
        ImageButton3.ImageUrl = Convert.ToString(GetLocalResourceObject("lblWorkingCapital1Resource1.Text"));
        ImageButton4.ImageUrl = Convert.ToString(GetLocalResourceObject("lblCashFlow1Resource1.Text"));
        ImageButton5.ImageUrl = Convert.ToString(GetLocalResourceObject("lblFunding1Resource1.Text"));
        ImageButton6.ImageUrl = Convert.ToString(GetLocalResourceObject("lblAppA1Resource1.Text"));
        Image1.ImageUrl = Convert.ToString(GetLocalResourceObject("lblAppA2Resource1.Text"));


    }
   
    private DataRow getFsMappingValue(DataTable dt, int FsMappingId)
    {
        try
        {
            DataRow[] dr = dt.Select("FsMappingId=" + FsMappingId);
            return dr[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected override void InitializeCulture()
    {
        string culture = string.Empty;
        culture = Convert.ToString(Request.QueryString["Culture"]);
      
        Session["Culture"] = Convert.ToString(Request.QueryString["Culture"]);
        culture = Convert.ToString(Session["Culture"]);
        if (culture != "Auto")
        {
            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

        }

    }

}