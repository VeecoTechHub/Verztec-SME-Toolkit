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
using ABSCommon;
using System.Globalization;
using System.Threading;

public partial class FinancialModeling_FundingMain : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    UserMgmt objUserMgmt = new UserMgmt();

    public static string strTxtClientIds = "";
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
                //if (Request.QueryString["Id"] != "" && Request.QueryString["Id"] != null)
                //{
                //    ViewState["Id"] = Request.QueryString["Id"].ToString();
                //}

                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                bindCompanyInfo();
                bindData();
                //bindClientIds();
                CallJScriptMethod();

            }
            txtCapitalP1.Focus();
        }
    }
    private void CallJScriptMethod()
    {        
        string strHideWCL = "no", strHideTL = "no";
        if (ViewState["HideWCL"].ToString() == "yes")
        {
            strHideWCL = "yes";
        }
        if (ViewState["HideTL"].ToString() == "yes")
        {
            strHideTL = "yes";
        }
        bindClientIds(strHideWCL, strHideTL);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "Combine('" + strHideWCL + "','" + strHideTL + "');", true);
       
    }
    private void bindClientIds(string strWCL, string strTL)
    {


        if (strWCL == "no" && strTL == "no")
        {
            strTxtClientIds = txtCapitalP1.ClientID + "," + txtCapitalP2.ClientID + "," + txtCapitalP3.ClientID;
            strTxtClientIds = strTxtClientIds + "," + txtloansP1.ClientID + "," + txtloansP2.ClientID + "," + txtloansP3.ClientID;
            strTxtClientIds = strTxtClientIds + "," + txtCapitalLoan1.ClientID + "," + txtCapitalLoan2.ClientID + "," + txtCapitalLoan4.ClientID;
            if (ViewState["IsFinancialStmtAvailable"].ToString() != "0")
            {
                strTxtClientIds = strTxtClientIds + "," + txtTermLoanP1.ClientID + "," + txtTermLoanP2.ClientID + "," + txtTermLoanP3.ClientID;
            }
        }
        else if (strWCL == "yes" && strTL == "yes")
        {
            strTxtClientIds = txtCapitalP1.ClientID + "," + txtCapitalP2.ClientID + "," + txtCapitalP3.ClientID;
            strTxtClientIds = strTxtClientIds + "," + txtloansP1.ClientID + "," + txtloansP2.ClientID + "," + txtloansP3.ClientID;
        }
        else if (strWCL == "yes" && strTL == "no")
        {
            strTxtClientIds = txtCapitalP1.ClientID + "," + txtCapitalP2.ClientID + "," + txtCapitalP3.ClientID;
            strTxtClientIds = strTxtClientIds + "," + txtloansP1.ClientID + "," + txtloansP2.ClientID + "," + txtloansP3.ClientID;
            if (ViewState["IsFinancialStmtAvailable"].ToString() != "0")
            {
                strTxtClientIds = strTxtClientIds + "," + txtTermLoanP1.ClientID + "," + txtTermLoanP2.ClientID + "," + txtTermLoanP3.ClientID;
            }
        }
        else if (strWCL == "no" && strTL == "yes")
        {
            strTxtClientIds = txtCapitalP1.ClientID + "," + txtCapitalP2.ClientID + "," + txtCapitalP3.ClientID;
            strTxtClientIds = strTxtClientIds + "," + txtloansP1.ClientID + "," + txtloansP2.ClientID + "," + txtloansP3.ClientID;
            strTxtClientIds = strTxtClientIds + "," + txtCapitalLoan1.ClientID + "," + txtCapitalLoan2.ClientID + "," + txtCapitalLoan4.ClientID;
        }


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
                ViewState["IsFinancialStmtAvailable"] = dtCompanyInfo.Rows[0]["IsFinancialStmtAvailable"];
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
            //section zero data
            DataSet dsSectionZero = objFinModelingMgmt.getDataBySection(0);
            DataTable dtFsMapping_0 = dsSectionZero.Tables[0];
            DataTable dtInputValue_0 = dsSectionZero.Tables[1];
            ViewState["HideWCL"] = "no";
            ViewState["HideTL"] = "no";

            if (ViewState["IsFinancialStmtAvailable"].ToString() == "0")
            {
                hfPastValues.Value = "0";
            }
            else
                hfPastValues.Value = "1";

            if (dtInputValue_0.Rows.Count > 0)
            {
                ViewState["CapitalLoanStatus"] = getInputValue(dtInputValue_0, 76);
                if (ViewState["CapitalLoanStatus"].ToString() == "0")
                {
                    ViewState["HideWCL"] = "yes";
                }
                ViewState["TermLoanStatus"] = getInputValue(dtInputValue_0, 77);
                if (ViewState["TermLoanStatus"].ToString() == "0")
                {
                    ViewState["HideTL"] = "yes";
                }
            }


            //section 4 data
            DataSet ds = objFinModelingMgmt.getDataBySection(4);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drCapital = getFsMappingValue(dtFsMapping, 41);               
                txtCapitalP1.Text = CommonBindings.TextToBind(drCapital["P1_Value"].ToString());
                txtCapitalP2.Text = CommonBindings.TextToBind(drCapital["P2_Value"].ToString());
                txtCapitalP3.Text = CommonBindings.TextToBind(drCapital["P3_Value"].ToString());

                DataRow drLoans = getFsMappingValue(dtFsMapping, 90);               
                txtloansP1.Text = CommonBindings.TextToBind(drLoans["P1_Value"].ToString());
                txtloansP2.Text = CommonBindings.TextToBind(drLoans["P2_Value"].ToString());
                txtloansP3.Text = CommonBindings.TextToBind(drLoans["P3_Value"].ToString());


                DataRow drTermLoan = getFsMappingValue(dtFsMapping, 42);              
                txtTermLoanP1.Text = CommonBindings.TextToBind(drTermLoan["P1_Value"].ToString());
                txtTermLoanP2.Text = CommonBindings.TextToBind(drTermLoan["P2_Value"].ToString());
                txtTermLoanP3.Text = CommonBindings.TextToBind(drTermLoan["P3_Value"].ToString());
            }

            if (dtInputValue.Rows.Count > 0)
            {
                txtCapitalLoan1.Text = getInputValue(dtInputValue, 50);
                txtCapitalLoan2.Text = getInputValue(dtInputValue, 51);
               // txtCapitalLoan3.Text = getInputValue(dtInputValue, 52);
                txtCapitalLoan4.Text = getInputValue(dtInputValue, 53);
                txtCapitalLoanPer.Text = getInputValue(dtInputValue, 54);

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
            string redirectPath = string.Empty;

            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_Funding(ViewState["UserID"].ToString());

                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/CapitalExpenditure.aspx";
                    Response.Redirect(redirectPath);
                }
                else
                {
                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/FundingMain.aspx";
                    Response.Redirect(redirectPath);
                }
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

            dr1["FsMappingId"] = "41";           

            if (txtCapitalP1.Text.Trim().Length > 0)
                dr1["P1_Value"] = txtCapitalP1.Text.Trim();
            else
                dr1["P1_Value"] = DBNull.Value;

            if (txtCapitalP2.Text.Trim().Length > 0)
                dr1["P2_Value"] = txtCapitalP2.Text.Trim();
            else
                dr1["P2_Value"] = DBNull.Value;

            if (txtCapitalP3.Text.Trim().Length > 0)
                dr1["P3_Value"] = txtCapitalP3.Text.Trim();
            else
                dr1["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "90";
            
            if (txtloansP1.Text.Trim().Length > 0)
                dr2["P1_Value"] = txtloansP1.Text.Trim();
            else
                dr2["P1_Value"] = DBNull.Value;

            if (txtloansP2.Text.Trim().Length > 0)
                dr2["P2_Value"] = txtloansP2.Text.Trim();
            else
                dr2["P2_Value"] = DBNull.Value;

            if (txtloansP3.Text.Trim().Length > 0)
                dr2["P3_Value"] = txtloansP3.Text.Trim();
            else
                dr2["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);


            DataRow dr3 = dt.NewRow();

            dr3["FsMappingId"] = "42";
            if (ViewState["TermLoanStatus"].ToString() == "1" && ViewState["IsFinancialStmtAvailable"].ToString() != "0")
            {                

                if (txtTermLoanP1.Text.Trim().Length > 0)
                    dr3["P1_Value"] = txtTermLoanP1.Text.Trim();
                else
                    dr3["P1_Value"] = DBNull.Value;

                if (txtTermLoanP2.Text.Trim().Length > 0)
                    dr3["P2_Value"] = txtTermLoanP2.Text.Trim();
                else
                    dr3["P2_Value"] = DBNull.Value;

                if (txtTermLoanP3.Text.Trim().Length > 0)
                    dr3["P3_Value"] = txtTermLoanP3.Text.Trim();
                else
                    dr3["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr3["C_Value"] = DBNull.Value;
                dr3["P1_Value"] = DBNull.Value;
                dr3["P2_Value"] = DBNull.Value;
                dr3["P3_Value"] = DBNull.Value;
            }
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
            dr1["MasterInputId"] = "50";
            if (ViewState["CapitalLoanStatus"].ToString() == "1")
            {
                if (txtCapitalLoan1.Text.Trim().Length > 0)
                    dr1["Input_Value"] = txtCapitalLoan1.Text.Trim();
                else
                    dr1["Input_Value"] = DBNull.Value;
            }
            else
                dr1["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["MasterInputId"] = "51";
            if (ViewState["CapitalLoanStatus"].ToString() == "1")
            {
                if (txtCapitalLoan2.Text.Trim().Length > 0)
                    dr2["Input_Value"] = txtCapitalLoan2.Text.Trim();
                else
                    dr2["Input_Value"] = DBNull.Value;
            }
            else
                dr2["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            //DataRow dr3 = dt.NewRow();
            //dr3["MasterInputId"] = "52";
            //if (ViewState["CapitalLoanStatus"].ToString() == "1")
            //{
            //    if (txtCapitalLoan3.Text.Trim().Length > 0)
            //        dr3["Input_Value"] = txtCapitalLoan3.Text.Trim();
            //    else
            //        dr3["Input_Value"] = DBNull.Value;
            //}
            //else
            //    dr3["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr3);

            DataRow dr3 = dt.NewRow();
            dr3["MasterInputId"] = "53";
            if (ViewState["CapitalLoanStatus"].ToString() == "1")
            {
                if (txtCapitalLoan4.Text.Trim().Length > 0)
                    dr3["Input_Value"] = txtCapitalLoan4.Text.Trim();
                else
                    dr3["Input_Value"] = DBNull.Value;
            }
            else
                dr3["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "54";
            if (ViewState["CapitalLoanStatus"].ToString() == "1")
            {
                if (txtCapitalLoanPer.Text.Trim().Length > 0)
                    dr4["Input_Value"] = txtCapitalLoanPer.Text.Trim();
                else
                    dr4["Input_Value"] = DBNull.Value;
            }
            else
                dr4["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);


            DataRow dr5 = dt.NewRow();
            dr5["MasterInputId"] = "55";
            if (ViewState["TermLoanStatus"].ToString() == "1")
            {
                if (txtTermLoanPer.Text.Trim().Length > 0)
                    dr5["Input_Value"] = txtTermLoanPer.Text.Trim();
                else
                    dr5["Input_Value"] = DBNull.Value;
            }
            else
                dr5["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr5);

            return dt;
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

                    objFinModelingMgmt.Update_FinTool_Funding(ViewState["UserID"].ToString());

                }
            }

        }
        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/OperatingExpenses.aspx";
        Response.Redirect(redirectPath);
    }
  

    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            bindCompanyInfo();
            bindData();
            CallJScriptMethod();
            ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "FormatCells", "formatCellsWithComma();", true);

        }
        catch (Exception ex)
        {
            throw ex;
        }
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
                    objFinModelingMgmt.Update_FinTool_Funding(ViewState["UserID"].ToString());
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

                    objFinModelingMgmt.Update_FinTool_Funding(ViewState["UserID"].ToString());

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

                    objFinModelingMgmt.Update_FinTool_Funding(ViewState["UserID"].ToString());

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

                    objFinModelingMgmt.Update_FinTool_Funding(ViewState["UserID"].ToString());

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