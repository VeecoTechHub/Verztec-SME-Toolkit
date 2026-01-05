using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using ABSDTO;
using System.Data;
using ABSBLL;
using ABSCommon;
using System.Globalization;
using System.Threading;

public partial class FinancialModeling_OperatingExpenses : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    UserMgmt objUserMgmt = new UserMgmt();
    public static string strTxtClientIds = "";
    public static string strLblClientIds = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
             
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                bindCompanyInfo();
                bindData();
                bindClientIds();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);


            }
            txtTotalSalesPer.Focus();
        }

    }
    private void bindClientIds()
    {

        strTxtClientIds = txtOperatingExpenseP1.ClientID + "," + txtRecurrP1.ClientID + "," + txtNonRecurrP1.ClientID + "," + txtNonRecurrP2.ClientID + "," + txtNonRecurrP3.ClientID;
        strLblClientIds = lblOperatingExpenseP2.ClientID + "," + lblOperatingExpenseP3.ClientID + "," + lblRecurrP2.ClientID + "," + lblRecurrP3.ClientID ;
        strLblClientIds = strLblClientIds + "," + lblIncomeP1Total.ClientID + "," + lblIncomeP2Total.ClientID + "," + lblIncomeP3Total.ClientID;
    }
    private void bindCompanyInfo()
    {

        try
        {
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
                DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

                ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
                ViewState["ProjYear1"] = drCompanyInfo["P1_Year"].ToString();
                ViewState["ProjYear2"] = drCompanyInfo["P2_Year"].ToString();
                ViewState["ProjYear3"] = drCompanyInfo["P3_Year"].ToString();

                ViewState["Currency"] = drCompanyInfo["Currency"].ToString();

                lblProjYear1.Text = ViewState["ProjYear1"].ToString();
                lblProjYear2.Text = ViewState["ProjYear2"].ToString();
                lblProjYear3.Text = ViewState["ProjYear3"].ToString();

                lblProYear1.Text = ViewState["ProjYear1"].ToString();
                lblProYear2.Text = ViewState["ProjYear2"].ToString();
                lblProYear3.Text = ViewState["ProjYear3"].ToString();
            }

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
            DataSet ds = objFinModelingMgmt.getDataBySection(3);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drOperatingExpense = getFsMappingValue(dtFsMapping, 39);

               
                txtOperatingExpenseP1.Text = CommonBindings.TextToBind(drOperatingExpense["P1_Value"].ToString());
                lblOperatingExpenseP2.Text = CommonBindings.TextToBind(drOperatingExpense["P2_Value"].ToString());
                lblOperatingExpenseP3.Text = CommonBindings.TextToBind(drOperatingExpense["P3_Value"].ToString());                
                txtOperatingExpenseP1Per.Text = CommonBindings.TextToBind(drOperatingExpense["P1_Percent"].ToString());
                txtOperatingExpenseP2Per.Text = CommonBindings.TextToBind(drOperatingExpense["P2_Percent"].ToString());




                DataRow drOtherIncome = getFsMappingValue(dtFsMapping, 40);
              //  txtRecurrIncome.Text = drOtherIncome["FsMappingName"].ToString();               
                txtRecurrP1.Text = CommonBindings.TextToBind(drOtherIncome["P1_Value"].ToString());
                lblRecurrP2.Text = CommonBindings.TextToBind(drOtherIncome["P2_Value"].ToString());
                lblRecurrP3.Text = CommonBindings.TextToBind(drOtherIncome["P3_Value"].ToString());                
                txtRecurrP1Per.Text = CommonBindings.TextToBind(drOtherIncome["P1_Percent"].ToString());
                txtRecurrP2Per.Text = CommonBindings.TextToBind(drOtherIncome["P2_Percent"].ToString());

                DataRow drNonRecurrIncome = getFsMappingValue(dtFsMapping, 88);
              //  lblNonRecurrIncome.Text = drNonRecurrIncome["FsMappingName"].ToString();
                txtNonRecurrP1.Text = CommonBindings.TextToBind(drNonRecurrIncome["P1_Value"].ToString());
                txtNonRecurrP2.Text = CommonBindings.TextToBind(drNonRecurrIncome["P2_Value"].ToString());
                txtNonRecurrP3.Text = CommonBindings.TextToBind(drNonRecurrIncome["P3_Value"].ToString());                
                //txtNonRecurrP1Per.Text = drNonRecurrIncome["P1_Percent"].ToString();
                //txtNonRecurrP2Per.Text = drNonRecurrIncome["P2_Percent"].ToString();

                DataRow drTotalIncome = getFsMappingValue(dtFsMapping, 89);                
                lblIncomeP1Total.Text = CommonBindings.TextToBind(drTotalIncome["P1_Value"].ToString());
                lblIncomeP2Total.Text = CommonBindings.TextToBind(drTotalIncome["P2_Value"].ToString());
                lblIncomeP3Total.Text = CommonBindings.TextToBind(drTotalIncome["P3_Value"].ToString());

            }

            if (dtInputValue.Rows.Count > 0)
            {  
                txtTotalSalesPer.Text = getInputValue(dtInputValue, 82);
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
            dr1["FsMappingId"] = "39";            

            if (txtOperatingExpenseP1.Text.Trim().Length > 0)
                dr1["P1_Value"] = txtOperatingExpenseP1.Text.Trim();
            else
                dr1["P1_Value"] = DBNull.Value; 

            if (txtOperatingExpenseP1Per.Text.Trim().Length > 0)
                dr1["P1_Percent"] = txtOperatingExpenseP1Per.Text.Trim();
            else
                dr1["P1_Percent"] = DBNull.Value;
            if (txtOperatingExpenseP2Per.Text.Trim().Length > 0)
                dr1["P2_Percent"] = txtOperatingExpenseP2Per.Text.Trim();
            else
                dr1["P2_Percent"] = DBNull.Value;        

            dt.Rows.Add(dr1);


            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "40";           

            if (txtRecurrP1.Text.Trim().Length > 0)
                dr2["P1_Value"] = txtRecurrP1.Text.Trim();
            else
                dr2["P1_Value"] = DBNull.Value;           

            if (txtRecurrP1Per.Text.Trim().Length > 0)
                dr2["P1_Percent"] = txtRecurrP1Per.Text.Trim();
            else
                dr2["P1_Percent"] = DBNull.Value;
            if (txtRecurrP2Per.Text.Trim().Length > 0)
                dr2["P2_Percent"] = txtRecurrP2Per.Text.Trim();
            else
                dr2["P2_Percent"] = DBNull.Value;

            //if (txtRecurrIncome.Text.Trim().Length > 0)
            //    dr2["FsMappingName"] = txtRecurrIncome.Text.Trim();
            //else
            //    dr2["FsMappingName"] = DBNull.Value;

            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["FsMappingId"] = "88";           

            if (txtNonRecurrP1.Text.Trim().Length > 0)
                dr3["P1_Value"] = txtNonRecurrP1.Text.Trim();
            else
                dr3["P1_Value"] = DBNull.Value;           

            if (txtNonRecurrP2.Text.Trim().Length > 0)
                dr3["P2_Value"] = txtNonRecurrP2.Text.Trim();
            else
                dr3["P2_Value"] = DBNull.Value;
            if (txtNonRecurrP3.Text.Trim().Length > 0)
                dr3["P3_Value"] = txtNonRecurrP3.Text.Trim();
            else
                dr3["P3_Value"] = DBNull.Value;

            //if (lblNonRecurrIncome.Text.Trim().Length > 0)
            //    dr3["FsMappingName"] = lblNonRecurrIncome.Text.Trim();
            //else
            //    dr3["FsMappingName"] = DBNull.Value;

            dt.Rows.Add(dr3);


           
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

            DataRow dr1 = dt.NewRow();
            dr1["MasterInputId"] = "82";
            if (txtTotalSalesPer.Text.Trim().Length > 0)
                dr1["Input_Value"] = txtTotalSalesPer.Text.Trim();
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
    protected void btnSaveNext_Click(object sender, EventArgs e)
    {
        try
        {
            string redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_OtherOperating_Expenses(ViewState["UserID"].ToString());

                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/FundingMain.aspx";
                    Response.Redirect(redirectPath);
                }
                else
                {
                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/OperatingExpenses.aspx";
                    Response.Redirect(redirectPath);
                }
            }

            
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string strHidden = hfValue.Value;
        if (strHidden == "1")
        {
            string _redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_OtherOperating_Expenses(ViewState["UserID"].ToString());
                }
            }
        }

        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Sec_CostOfSales.aspx";
        Response.Redirect(redirectPath);
       
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        bindCompanyInfo();
        bindData();
        bindClientIds();
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "FormatCells", "formatCellsWithComma();", true);
    }
    protected void imgBtnGenerateReport_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;

        //If User want to save changes below code execute
        if (strHidden == "1")
        {
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_OtherOperating_Expenses(ViewState["UserID"].ToString());
                }
            }
        }

        //Do not save changes and generate reports
        if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            objFinModelingMgmt.Update_FinTool_Totals();
        }

        Response.Redirect("Reports.aspx");
    }
    protected void imgbtnStatements_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            string _redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_OtherOperating_Expenses(ViewState["UserID"].ToString());
                }
            }
        }
        Response.Redirect("SciStatement.aspx");
    }
    protected void imgbtnHome_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            string _redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_OtherOperating_Expenses(ViewState["UserID"].ToString());
                }
            }
        }
        Response.Redirect("FinancialModelingHome.aspx");
    }

    protected void imgBtnHelp_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            string _redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_OtherOperating_Expenses(ViewState["UserID"].ToString());
                }
            }
        }
        Response.Redirect("Help.aspx");
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