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

public partial class FinancialModeling_Taxation : System.Web.UI.Page
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

                if (ViewState["IsFinancialStmtAvailable"].ToString() != "0")
                {
                    bindClientIds();

                    if (ViewState["HideErrMsg"].ToString() == "yes")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "Combine();", true);
                    }
                    else
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
                }

             
            }
            txtIncometax.Focus();
        }

    }
    private void bindClientIds()
    {
       
        strTxtClientIds = txtDepreciationP1.ClientID + "," + txtDepreciationP2.ClientID + "," + txtDepreciationP3.ClientID;
        strLblClientIds = lblDepreciationP1.ClientID + "," + lblDepreciationTotal.ClientID;

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
            if (ViewState["IsFinancialStmtAvailable"].ToString() == "0")
            {
                TR1.Visible = false;
                TR2.Visible = false;
                TR3.Visible = false;
                TR4.Visible = false;
                TR5.Visible = false;
                TR6.Visible = false;
                TR7.Visible = false;
            }

            DataSet ds = objFinModelingMgmt.getDataBySection(6);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drDepreciation = getFsMappingValue(dtFsMapping, 63);
                txtDepreciationP1.Text = CommonBindings.TextToBind(drDepreciation["P1_Value"].ToString());
                txtDepreciationP2.Text = CommonBindings.TextToBind(drDepreciation["P2_Value"].ToString());
                txtDepreciationP3.Text = CommonBindings.TextToBind(drDepreciation["P3_Value"].ToString());
            }
            ViewState["HideErrMsg"] = "no";
            if (dtInputValue.Rows.Count > 0)
            {
                txtIncometax.Text = getInputValue(dtInputValue, 72);
                if (GetIncometaxPercentage().ToString() == "NaN")
                {
                    lblIncometax.Text = "0";                  
                }
                else
                lblIncometax.Text = GetIncometaxPercentage().ToString();


                if (GetNetBookValue().ToString() == "NaN")
                {
                    lblDepreciationP1.Text = "";
                    
                }
                else
                    lblDepreciationP1.Text = GetNetBookValue().ToString();

                lblDepreciationTotal.Text = getInputValue(dtInputValue, 73);               
                if (lblDepreciationTotal.Text.Trim() != "" && lblDepreciationP1.Text.Trim() != "")
                {
                    if (Convert.ToDouble(lblDepreciationTotal.Text) > Convert.ToDouble(lblDepreciationP1.Text))
                    {
                        ViewState["HideErrMsg"] = "yes";
                    }
                }                
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


            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "63";

            if (ViewState["IsFinancialStmtAvailable"].ToString() != "0")
            {
                if (txtDepreciationP1.Text.Trim().Length > 0)
                    dr2["P1_Value"] = txtDepreciationP1.Text.Trim();

                if (txtDepreciationP2.Text.Trim().Length > 0)
                    dr2["P2_Value"] = txtDepreciationP2.Text.Trim();

                if (txtDepreciationP3.Text.Trim().Length > 0)
                    dr2["P3_Value"] = txtDepreciationP3.Text.Trim();
            }
            else
            {
                dr2["P1_Value"] = DBNull.Value;
                dr2["P2_Value"] = DBNull.Value;
                dr2["P3_Value"] = DBNull.Value;
            }

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

            DataRow dr1 = dt.NewRow();
            dr1["MasterInputId"] = "72";
            if (txtIncometax.Text.Trim().Length > 0)
                dr1["Input_Value"] = txtIncometax.Text.Trim();
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
        string redirectPath = string.Empty;
        try
        {
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_Totals();

                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Reports.aspx";
                    Response.Redirect(redirectPath);

                }
                else
                {
                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Taxation.aspx";
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
                    objFinModelingMgmt.Update_FinTool_Totals();


                }
            }
        }
        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/CapitalExpenditure.aspx";
        Response.Redirect(redirectPath);
    }

    public double GetIncometaxPercentage()
    {
        try
        {
            double total = double.NaN;
            string FsMapIDs = "9,10";
            DataSet ds = objFinModelingMgmt.getStatementByMapID(FsMapIDs);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][1] != DBNull.Value && ds.Tables[0].Rows[1][1] != DBNull.Value)
                {
                    double sales = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                    double TradeReceivables = Convert.ToDouble(ds.Tables[0].Rows[1][1].ToString());
                    total = Math.Round((TradeReceivables / sales * 100), 1);  
                }
            }
            return total;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public double GetNetBookValue()
    {
        try
        {
            double total = double.NaN;
            string FsMapIDs = "18";
            DataSet ds = objFinModelingMgmt.getStatementByMapID(FsMapIDs);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][1] != DBNull.Value)
                {
                    total = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                }

            }
            return total;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void btnHome_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("FinancialModelingHome.aspx");
    //}
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            bindCompanyInfo();
            bindData();
            bindClientIds();
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
                    objFinModelingMgmt.Update_FinTool_Totals();
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
                    objFinModelingMgmt.Update_FinTool_Totals();


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
                    objFinModelingMgmt.Update_FinTool_Totals();


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
                    objFinModelingMgmt.Update_FinTool_Totals();


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