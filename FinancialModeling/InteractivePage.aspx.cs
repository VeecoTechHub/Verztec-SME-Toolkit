using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ABSDAL;
using ABSDTO;
using System.Configuration;
using System.Web.UI.HtmlControls;
using ABSBLL;

public partial class FinancialModeling_InteractivePage : BasePage
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
            bindCompanyInfo();
            bindYears();
            bindData();
        }
        //ViewState["UserID"] = "E036E515-86B0-4674-940B-79DFA8E3E1F1";
        //bindCompanyInfo();
        //bindData();
    }

    private void bindCompanyInfo()
    {

        try
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
            DataRow drCompanyInfo = dtCompanyInfo.Rows[0];
            ViewState["PreviousPreviousYear"] = drCompanyInfo["PreviousPreviousYear"].ToString();
            ViewState["PreviousYear"] = drCompanyInfo["PreviousYear"].ToString();
            ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
            ViewState["Currency"] = drCompanyInfo["Currency"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void bindYears()
    {

        try
        {
            lblPreviousPreviousYear.Text = Convert.ToString(Convert.ToInt32(ViewState["CurrentYear"]) + 1);
            lblPreviousYear.Text = Convert.ToString(Convert.ToInt32(ViewState["CurrentYear"]) + 2);
            lblCurrentYear.Text = Convert.ToString(Convert.ToInt32(ViewState["CurrentYear"]) + 3);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void bindData()
    {
        try
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            DataSet ds = objFinModelingMgmt.getInteractiveData();
            if(ds.Tables[0].Rows.Count>0)
            {
                txtDebtRepaymentperiod.Text = ds.Tables[0].Rows[0]["DebtRepaymentPeriod"].ToString();
                txtEffectiveInterest.Text = ds.Tables[0].Rows[0]["EffectiveInterestOnDebt"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                DataRow drRevenueGrowth = ds.Tables[1].Rows[0];
                txtPreviousPreviousYearRevenue.Text = drRevenueGrowth["PreviousPreviousYearValue"].ToString();
                txtPreviousYearRevenue.Text = drRevenueGrowth["PreviousYearValue"].ToString();
                txtCurrentYearRevenue.Text = drRevenueGrowth["CurrentYearValue"].ToString();

                DataRow drTaxRate = ds.Tables[1].Rows[1];
                txtPreviousPreviousTaxRate.Text = drTaxRate["PreviousPreviousYearValue"].ToString();
                txtPreviousTaxRate.Text = drTaxRate["PreviousYearValue"].ToString();
                txtCurrentTaxRate.Text = drTaxRate["CurrentYearValue"].ToString();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            int intOut = objFinModelingMgmt.updateInteractiveData(txtPreviousPreviousYearRevenue.Text.Trim(),txtPreviousYearRevenue.Text.Trim(),txtCurrentYearRevenue.Text.Trim()
                ,txtPreviousPreviousTaxRate.Text.Trim(),txtPreviousTaxRate.Text.Trim(),txtCurrentTaxRate.Text.Trim(),txtDebtRepaymentperiod.Text.Trim(),txtEffectiveInterest.Text.Trim(),ViewState["UserID"].ToString());
            if (intOut == 1)
            {
                Response.Redirect("Report.aspx");
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Updation Failed.";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("SfpStatement.aspx");
    }
   
}