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

public partial class FinancialModeling_Optional : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
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
                if (Request.QueryString["Id"] != "" && Request.QueryString["Id"] != null)
                {
                    ViewState["Id"] = Request.QueryString["Id"].ToString();
                }

                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                bindCompanyInfo();
                bindData();
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "highlightmenu", "HighlightMenu();", true);
            }
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
            DataSet ds = objFinModelingMgmt.getDataBySection(6);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drAssets = getFsMappingValue(dtFsMapping, 62);
                //txtManufacturingSale.Text = drManufacturingSale["FsMappingName"].ToString();              
                txtAssetsEst.Text = CommonBindings.TextToBind(drAssets["C_Value"].ToString());
                lblAssetsP1.Text = CommonBindings.TextToBind(drAssets["P1_Value"].ToString());
                lblAssetsP2.Text = CommonBindings.TextToBind(drAssets["P2_Value"].ToString());
                //lblOtherLiabilitiesP3.Text = drAssets["P3_Value"].ToString();

                DataRow drDepreciation = getFsMappingValue(dtFsMapping, 63);
                //txtManufacturingSale.Text = drManufacturingSale["FsMappingName"].ToString();              
                //lblOtherIncomeEst.Text = drOtherIncome["C_Value"].ToString();
                txtDepreciationP1.Text = CommonBindings.TextToBind(drDepreciation["P1_Value"].ToString());
                txtDepreciationP2.Text = CommonBindings.TextToBind(drDepreciation["P2_Value"].ToString());
                txtDepreciationP3.Text = CommonBindings.TextToBind(drDepreciation["P3_Value"].ToString());
            }


            DataSet ds1 = objFinModelingMgmt.getDataBySection(7);
            DataTable dtFsMapping1 = ds1.Tables[0];
            DataTable dtInputValue1 = ds1.Tables[1];

            if (dtInputValue1.Rows.Count > 0)
            {
                //lblIncometax.Text = getInputValue(dtInputValue, 62);
                txtIncometax.Text = getInputValue(dtInputValue1, 73);

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
            dr1["FsMappingId"] = "62";
            if (txtAssetsEst.Text.Trim().Length > 0)
                dr1["C_Value"] = txtAssetsEst.Text.Trim();
            else
                dr1["C_Value"] = DBNull.Value;

            if (lblAssetsP1.Text.Trim().Length > 0)
                dr1["P1_Value"] = lblAssetsP1.Text.Trim();
            else
                dr1["P1_Value"] = DBNull.Value;

            if (lblAssetsP2.Text.Trim().Length > 0)
                dr1["P2_Value"] = lblAssetsP2.Text.Trim();
            else
                dr1["P2_Value"] = DBNull.Value;
            dr1["P3_Value"] = "";
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "63";
            if (txtDepreciationP1.Text.Trim().Length > 0)
                dr2["P1_Value"] = txtDepreciationP1.Text.Trim();
            else
                dr2["P1_Value"] = DBNull.Value;

            if (txtDepreciationP2.Text.Trim().Length > 0)
                dr2["P2_Value"] = txtDepreciationP2.Text.Trim();
            else
                dr2["P2_Value"] = DBNull.Value;

            if (txtDepreciationP3.Text.Trim().Length > 0)
                dr2["P3_Value"] = txtDepreciationP3.Text.Trim();
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

            //IncomeTax

            //DataRow dr1 = dt.NewRow();
            //dr1["MasterInputId"] = "62";
            //dr1["Input_Value"] = lblIncometax.Text.Trim();
            //dt.Rows.Add(dr1);

            DataRow dr1 = dt.NewRow();
            dr1["MasterInputId"] = "73";
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
        try
        {
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
            if (i == 1)
            {
                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Report.aspx?Id=" + ViewState["Id"] + "";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Data Saved Successfully.'); location='" + _redirectPath + "';</Script>");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FinancialModeling/Other_Assets.aspx?Id=" + ViewState["Id"].ToString());
    }
    public void SaveData(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string strUrl = lb.CommandArgument;

        string strHidden = hfValue.Value;
        if (strHidden == "1")
        {
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
        }
        string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + strUrl;
        Response.Redirect(_redirectPath);
    }   
}