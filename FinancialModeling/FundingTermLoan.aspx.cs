using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSDTO;
using System.Data;
using System.Configuration;
public partial class FinancialModeling_FundingTermLoan : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    public static string strTxtClientIds = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id"] != "" && Request.QueryString["Id"] != null)
                {
                    ViewState["Id"] = Request.QueryString["Id"].ToString();
                }

                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                bindCompanyInfo();
                bindData();
                bindClientIds();                          
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState 
            }
        }
    }
    private void bindClientIds()
    {
        if (ViewState["Id"].ToString() == "1")
        {
            strTxtClientIds = txtTermLoanEst.ClientID + "," + txtTermLoanP1.ClientID + "," + txtTermLoanP2.ClientID + "," + txtTermLoanP3.ClientID;     
        }
        else
        {
            strTxtClientIds =txtTermLoanP1.ClientID + "," + txtTermLoanP2.ClientID + "," + txtTermLoanP3.ClientID;     
        }
    }

    private void bindCompanyInfo()
    {

        try
        {

            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
            DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

            ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
            ViewState["ProjYear1"] = drCompanyInfo["P1_Year"].ToString();
            ViewState["ProjYear2"] = drCompanyInfo["P2_Year"].ToString();
            ViewState["ProjYear3"] = drCompanyInfo["P3_Year"].ToString();

            ViewState["Currency"] = drCompanyInfo["Currency"].ToString();
            lblEstimate.Text = ViewState["CurrentYear"].ToString();
            lblProjYear1.Text = ViewState["ProjYear1"].ToString();
            lblProjYear2.Text = ViewState["ProjYear2"].ToString();
            lblProjYear3.Text = ViewState["ProjYear3"].ToString();

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
            //section zero data
            DataSet dsSectionZero = objFinModelingMgmt.getDataBySection(0);
            DataTable dtFsMapping_0 = dsSectionZero.Tables[0];
            DataTable dtInputValue_0 = dsSectionZero.Tables[1];
            if (dtInputValue_0.Rows.Count > 0)
            {
                ViewState["CapitalLoanStatus"] = getInputValue(dtInputValue_0, 76);
                ViewState["CapitalExpenditureStatus"] = getInputValue(dtInputValue_0, 78);
            }

            DataSet ds = objFinModelingMgmt.getDataBySection(4);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];

            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drCapital = getFsMappingValue(dtFsMapping, 42);
                txtTermLoanEst.Text = drCapital["C_Value"].ToString();
                txtTermLoanP1.Text = drCapital["P1_Value"].ToString();
                txtTermLoanP2.Text = drCapital["P2_Value"].ToString();
                txtTermLoanP3.Text = drCapital["P3_Value"].ToString();
            }
            if (dtInputValue.Rows.Count > 0)
            {
                txtTermLoanPer.Text = getInputValue(dtInputValue, 55);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

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
    private string getInputValue(DataTable dt, int MasterId)
    {
        try
        {
            DataRow[] dr = dt.Select("MasterInputId=" + MasterId);
            return dr[0]["Input_Value"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSaveNext_Click(object sender, EventArgs e)
    {
        try
        {
            string _redirectPath = string.Empty;

            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
            if (i == 1)
            {
                objFinModelingMgmt.Update_FinTool_Totals();
                if (ViewState["CapitalExpenditureStatus"].ToString() == "1")
                {
                    _redirectPath = "CapitalExpenditure.aspx?Id=" + ViewState["Id"] + "";                    
                }
                else
                {
                    _redirectPath = "OtherAssets.aspx?Id=" + ViewState["Id"] + "";                   
                }
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Data Saved Successfully.'); location='" + _redirectPath + "';</Script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Updation failed.'); </Script>");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable generateFsMapping()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FsMappingId");
            dt.Columns.Add("C_Value");
            dt.Columns.Add("P1_Value");
            dt.Columns.Add("P2_Value");
            dt.Columns.Add("P3_Value");
            dt.Columns.Add("C_Percent");
            dt.Columns.Add("P1_Percent");
            dt.Columns.Add("P2_Percent");
            dt.Columns.Add("P3_Percent");
            dt.Columns.Add("FsMappingName");

            DataRow dr1 = dt.NewRow();

            dr1["FsMappingId"] = "42";
            if (txtTermLoanEst.Text.Trim().Length > 0)
                dr1["C_Value"] = txtTermLoanEst.Text.Trim();
            else
                dr1["C_Value"] = DBNull.Value;

            if (txtTermLoanP1.Text.Trim().Length > 0)
                dr1["P1_Value"] = txtTermLoanP1.Text.Trim();
            else
                dr1["P1_Value"] = DBNull.Value;

            if (txtTermLoanP2.Text.Trim().Length > 0)
                dr1["P2_Value"] = txtTermLoanP2.Text.Trim();
            else
                dr1["P2_Value"] = DBNull.Value;

            if (txtTermLoanP3.Text.Trim().Length > 0)
                dr1["P3_Value"] = txtTermLoanP3.Text.Trim();
            else
                dr1["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            return dt;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable generateInputValues()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MasterInputId");
            dt.Columns.Add("Input_Value");


            //Sales

            DataRow dr1 = dt.NewRow();
            dr1["MasterInputId"] = "55";
            if (txtTermLoanPer.Text.Trim().Length > 0)
                dr1["Input_Value"] = txtTermLoanPer.Text.Trim();
            else
                dr1["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //if (ViewState["CapitalLoanStatus"].ToString() == "0")
        //{
        //    Response.Redirect("~/FinancialModeling/FundingMain.aspx?Id=" + ViewState["Id"].ToString());
        //}
        //else if (ViewState["CapitalLoanStatus"].ToString() == "1")
        //{
        //    Response.Redirect("~/FinancialModeling/FundingCapitalLoan.aspx?Id=" + ViewState["Id"].ToString());
        //}
        if (ViewState["PreviousPage"] != null)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("FinancialModelingHome.aspx?Id=" + ViewState["Id"].ToString());
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            bindCompanyInfo();
            bindData();
            bindClientIds();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}