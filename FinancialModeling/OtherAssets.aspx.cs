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
public partial class FinancialModeling_OtherAssets : System.Web.UI.Page
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
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState 
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
            }
        }
    }

    private void bindClientIds()
    {
        if (ViewState["Id"].ToString() == "1")
        {
            strTxtClientIds = txtOtherAssetsEst.ClientID + "," + txtOtherAssetsP1.ClientID + "," + txtOtherAssetsP2.ClientID + "," + txtOtherAssetsP3.ClientID;
            strTxtClientIds = strTxtClientIds + "," + txtOtherLiabilitiesEst.ClientID + "," + txtOtherLiabilitiesP1.ClientID + "," + txtOtherLiabilitiesP2.ClientID + "," + txtOtherLiabilitiesP3.ClientID;
        }
        else
        {
            strTxtClientIds =txtOtherAssetsP1.ClientID + "," + txtOtherAssetsP2.ClientID + "," + txtOtherAssetsP3.ClientID;
            strTxtClientIds = strTxtClientIds + "," + txtOtherLiabilitiesP1.ClientID + "," + txtOtherLiabilitiesP2.ClientID + "," + txtOtherLiabilitiesP3.ClientID;
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
                ViewState["TermLoanStatus"] = getInputValue(dtInputValue_0, 77);
                ViewState["CapitalExpenditureStatus"] = getInputValue(dtInputValue_0, 78);
            }


            DataSet ds = objFinModelingMgmt.getDataBySection(5);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drOtherAssets = getFsMappingValue(dtFsMapping, 58);
                txtOtherAssets.Text = drOtherAssets["FsMappingName"].ToString();
                txtOtherAssetsEst.Text = drOtherAssets["C_Value"].ToString();
                txtOtherAssetsP1.Text = drOtherAssets["P1_Value"].ToString();
                txtOtherAssetsP2.Text = drOtherAssets["P2_Value"].ToString();
                txtOtherAssetsP3.Text = drOtherAssets["P3_Value"].ToString();

                DataRow drOtherLiabilities = getFsMappingValue(dtFsMapping, 59);
                txtOtherLiabilities.Text = drOtherLiabilities["FsMappingName"].ToString();
                txtOtherLiabilitiesEst.Text = drOtherLiabilities["C_Value"].ToString();
                txtOtherLiabilitiesP1.Text = drOtherLiabilities["P1_Value"].ToString();
                txtOtherLiabilitiesP2.Text = drOtherLiabilities["P2_Value"].ToString();
                txtOtherLiabilitiesP3.Text = drOtherLiabilities["P3_Value"].ToString();
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
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
            if (i == 1)
            {
                objFinModelingMgmt.Update_FinTool_Totals();
                string _redirectPath ="Taxation.aspx?Id=" + ViewState["Id"] + "";
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

            dr1["FsMappingId"] = "58";

            if (txtOtherAssets.Text.Trim().Length > 0)
                dr1["FsMappingName"] = txtOtherAssets.Text.Trim();
            else
                dr1["FsMappingName"] = DBNull.Value;

            if (txtOtherAssetsEst.Text.Trim().Length > 0)
                dr1["C_Value"] = txtOtherAssetsEst.Text.Trim();
            else
                dr1["C_Value"] = DBNull.Value;

            if (txtOtherAssetsP1.Text.Trim().Length > 0)
                dr1["P1_Value"] = txtOtherAssetsP1.Text.Trim();
            else
                dr1["P1_Value"] = DBNull.Value;

            if (txtOtherAssetsP2.Text.Trim().Length > 0)
                dr1["P2_Value"] = txtOtherAssetsP2.Text.Trim();
            else
                dr1["P2_Value"] = DBNull.Value;

            if (txtOtherAssetsP3.Text.Trim().Length > 0)
                dr1["P3_Value"] = txtOtherAssetsP3.Text.Trim();
            else
                dr1["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "59";
            if (txtOtherLiabilities.Text.Trim().Length > 0)
                dr2["FsMappingName"] = txtOtherLiabilities.Text.Trim();
            else
                dr2["FsMappingName"] = DBNull.Value;

            if (txtOtherLiabilitiesEst.Text.Trim().Length > 0)
                dr2["C_Value"] = txtOtherLiabilitiesEst.Text.Trim();
            else
                dr2["C_Value"] = DBNull.Value;

            if (txtOtherLiabilitiesP1.Text.Trim().Length > 0)
                dr2["P1_Value"] = txtOtherLiabilitiesP1.Text.Trim();
            else
                dr2["P1_Value"] = DBNull.Value;

            if (txtOtherLiabilitiesP2.Text.Trim().Length > 0)
                dr2["P2_Value"] = txtOtherLiabilitiesP2.Text.Trim();
            else
                dr2["P2_Value"] = DBNull.Value;

            if (txtOtherLiabilitiesP3.Text.Trim().Length > 0)
                dr2["P3_Value"] = txtOtherLiabilitiesP3.Text.Trim();
            else
                dr2["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);


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

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //if (ViewState["CapitalExpenditureStatus"].ToString() == "1")
        //{
        //    Response.Redirect("~/FinancialModeling/CapitalExpenditure.aspx?Id=" + ViewState["Id"].ToString());
        //}
        //else
        //{
        //    if (ViewState["TermLoanStatus"].ToString() == "0" || ViewState["Id"].ToString() == "0")
        //    {
        //        if (ViewState["CapitalLoanStatus"].ToString() == "0")
        //        {
        //            Response.Redirect("~/FinancialModeling/FundingMain.aspx?Id=" + ViewState["Id"].ToString());
        //        }
        //        else
        //        {
        //            Response.Redirect("~/FinancialModeling/FundingCapitalLoan.aspx?Id=" + ViewState["Id"].ToString());
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect("~/FinancialModeling/FundingTermLoan.aspx?Id=" + ViewState["Id"].ToString());

        //    }
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