using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class FinancialModeling_Report : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.Header.DataBind();
            bindUserControl("FinancialPerformance.ascx");
            bindNumberImages(imgOne, "one");
        }
    }
    //protected override void OnLoad(EventArgs e)
    //{
    //    base.OnLoad(e);
    //    bindUserControl("BreakEvenPoints.ascx");
    //    bindNumberImages(imgSeven, "seven");
    //} 


    protected void lBtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
    }
    private void bindUserControl(string strUcName)
    {
        try
        {
            trKeyRpt.Visible = false;
            string strUcPath = "~/UserControls/FinancialModeling_UserControls/";
            trFinGraphs.Visible = true;
            Control fsGraph = null;
            fsGraph = LoadControl(strUcPath + strUcName);
            //phFinancialGraphs.ViewStateMode = System.Web.UI.ViewStateMode.Disabled;
            phFinancialGraphs.Controls.Add(fsGraph);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

  
    private void bindNumberImages(Image imgOn, string strOnImageName)
    {
        try
        {
            string strInternalUrl = ConfigurationManager.AppSettings["InternalUrl"].ToString();
            imgOne.ImageUrl = strInternalUrl + "images/one.jpg";
            imgTwo.ImageUrl = strInternalUrl + "images/two.jpg";
            imgThree.ImageUrl = strInternalUrl + "images/three.jpg";
            imgFour.ImageUrl = strInternalUrl + "images/four.jpg";
            imgFive.ImageUrl = strInternalUrl + "images/five.jpg";
            imgSix.ImageUrl = strInternalUrl + "images/six.jpg";
            imgSeven.ImageUrl = strInternalUrl + "images/seven.jpg";
            imgEight.ImageUrl = strInternalUrl + "images/eight.jpg";
            imgNine.ImageUrl = strInternalUrl + "images/nine.jpg";
            imgTen.ImageUrl = strInternalUrl + "images/ten.jpg";
            imgEleven.ImageUrl = strInternalUrl + "images/eleven.jpg";
            imgTwelve.ImageUrl = strInternalUrl + "images/twelve.jpg";
            imgOn.ImageUrl = strInternalUrl + "images/" + strOnImageName + "On.jpg";


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lbFinPerfo_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("FinancialPerformance.ascx");
            bindNumberImages(imgOne, "one");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbFinPosition_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("FinancialPosition.ascx");
            bindNumberImages(imgTwo, "two");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void lbCashFlowAnalysis_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("CashFlowAnalysis.ascx");
            bindNumberImages(imgThree, "three");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbWorkingCapitalCycle_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("WorkingCapitalCycle.ascx");
            bindNumberImages(imgFour, "four");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbFundinSalesGrowth_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("FundingForSalesGrowth.ascx");
            bindNumberImages(imgFive, "five");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbDebtRepaymentSchedule_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("DebtRepaymentSchedule.ascx");
            bindNumberImages(imgSix, "six");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbBreakEvenPoints_Click(object sender, EventArgs e)
    {
        try
        {
            trBreakEven.Visible = true;
           // bindUserControl("BreakEvenPoints.ascx");
            trFinGraphs.Visible = false;
            trKeyRpt.Visible = false;
            bindNumberImages(imgSeven, "seven");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lbKpiProfitablility1_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("KpiProfitability1.ascx");
            bindNumberImages(imgEight, "eight");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbKpiProfitablility2_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("KpiProfitability2.ascx");
            bindNumberImages(imgNine, "nine");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbKpiLiquidity_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("Liquidity.ascx");
            bindNumberImages(imgTen, "ten");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbKpiLeverage_Click(object sender, EventArgs e)
    {
        try
        {
            bindUserControl("Leverage.ascx");
            bindNumberImages(imgEleven, "eleven");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lbKeySensitivityReport_Click(object sender, EventArgs e)
    {
        try
        {
          
            trFinGraphs.Visible = false;
            trBreakEven.Visible = false;
            trKeyRpt.Visible = true;
            bindNumberImages(imgTwelve, "twelve");
            

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}