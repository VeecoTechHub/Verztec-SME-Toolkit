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


public partial class FinancialModeling_Other_Assets : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
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
                //ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState                      

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
            DataSet ds = objFinModelingMgmt.getDataBySection(5);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drlblOtherAssets = getFsMappingValue(dtFsMapping, 58);
                lblOtherAssetsEst.Text = drlblOtherAssets["C_Value"].ToString();
                lblOtherAssetsP1.Text = drlblOtherAssets["P1_Value"].ToString();
                lblOtherAssetsP2.Text = drlblOtherAssets["P2_Value"].ToString();
                lblOtherAssetsP3.Text = drlblOtherAssets["P3_Value"].ToString();

                DataRow drOtherAssets = getFsMappingValue(dtFsMapping, 59);
                //lblOperatingExpenseEst.Text = drOperatingExpense["C_Value"].ToString();
                txtOtherAssetsP1.Text = drOtherAssets["P1_Value"].ToString();
                txtOtherAssetsP2.Text = drOtherAssets["P2_Value"].ToString();
                txtOtherAssetsP3.Text = drOtherAssets["P3_Value"].ToString();

                DataRow drlblOtherLiabilities = getFsMappingValue(dtFsMapping, 60);
                //txtManufacturingSale.Text = drManufacturingSale["FsMappingName"].ToString();              
                lblOtherLiabilitiesEst.Text = drlblOtherLiabilities["C_Value"].ToString();
                lblOtherLiabilitiesP1.Text = drlblOtherLiabilities["P1_Value"].ToString();
                lblOtherLiabilitiesP2.Text = drlblOtherLiabilities["P2_Value"].ToString();
                lblOtherLiabilitiesP3.Text = drlblOtherLiabilities["P3_Value"].ToString();

                DataRow drOtherLiabilities = getFsMappingValue(dtFsMapping, 61);
                //txtManufacturingSale.Text = drManufacturingSale["FsMappingName"].ToString();              
                //lblOtherIncomeEst.Text = drOtherIncome["C_Value"].ToString();
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
    //private string getInputValue(DataTable dt, int MasterId)
    //{
    //    try
    //    {
    //        DataRow[] dr = dt.Select("MasterInputId=" + MasterId);
    //        return dr[0]["Input_Value"].ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
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

            if (lblOtherAssetsEst.Text.Trim().Length > 0)
                dr1["C_Value"] = lblOtherAssetsEst.Text.Trim();
            else
                dr1["C_Value"] = DBNull.Value;

            if (lblOtherAssetsP1.Text.Trim().Length > 0)
                dr1["P1_Value"] = lblOtherAssetsP1.Text.Trim();
            else
                dr1["P1_Value"] = DBNull.Value;

            if (lblOtherAssetsP2.Text.Trim().Length > 0)
                dr1["P2_Value"] = lblOtherAssetsP2.Text.Trim();
            else
                dr1["P2_Value"] = DBNull.Value;

            if (lblOtherAssetsP3.Text.Trim().Length > 0)
                dr1["P3_Value"] = lblOtherAssetsP3.Text.Trim();
            else
                dr1["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "59";

            if (txtOtherAssetsP1.Text.Trim().Length > 0)
                dr2["P1_Value"] = txtOtherAssetsP1.Text.Trim();
            else
                dr2["P1_Value"] = DBNull.Value;

            if (txtOtherAssetsP2.Text.Trim().Length > 0)
                dr2["P2_Value"] = txtOtherAssetsP2.Text.Trim();
            else
                dr2["P2_Value"] = DBNull.Value;

            if (txtOtherAssetsP3.Text.Trim().Length > 0)
                dr2["P3_Value"] = txtOtherAssetsP3.Text.Trim();
            else
                dr2["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["FsMappingId"] = "60";
            if (lblOtherLiabilitiesEst.Text.Trim().Length > 0)
                dr3["C_Value"] = lblOtherLiabilitiesEst.Text.Trim();
            else
                dr3["C_Value"] = DBNull.Value;

            if (lblOtherLiabilitiesP1.Text.Trim().Length > 0)
                dr3["P1_Value"] = lblOtherLiabilitiesP1.Text.Trim();
            else
                dr3["P1_Value"] = DBNull.Value;

            if (lblOtherLiabilitiesP2.Text.Trim().Length > 0)
                dr3["P2_Value"] = lblOtherLiabilitiesP2.Text.Trim();
            else
                dr3["P2_Value"] = DBNull.Value;

            if (lblOtherLiabilitiesP3.Text.Trim().Length > 0)
                dr3["P3_Value"] = lblOtherLiabilitiesP3.Text.Trim();
            else
                dr3["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["FsMappingId"] = "61";

            if (txtOtherLiabilitiesP1.Text.Trim().Length > 0)
                dr4["P1_Value"] = txtOtherLiabilitiesP1.Text.Trim();
            else
                dr4["P1_Value"] = DBNull.Value;

            if (txtOtherLiabilitiesP2.Text.Trim().Length > 0)
                dr4["P2_Value"] = txtOtherLiabilitiesP2.Text.Trim();
            else
                dr4["P2_Value"] = DBNull.Value;

            if (txtOtherLiabilitiesP3.Text.Trim().Length > 0)
                dr4["P3_Value"] = txtOtherLiabilitiesP3.Text.Trim();
            else
                dr4["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);
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

            //DataRow dr1 = dt.NewRow();
            //dr1["MasterInputId"] = "1";
            //dr1["Input_Value"] = "";
            //dt.Rows.Add(dr1);          

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
                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Optional.aspx?Id=" + ViewState["Id"] + "";
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
        //if (ViewState["PreviousPage"] != null)        
        //{
        //    Response.Redirect(ViewState["PreviousPage"].ToString());

        //}
        Response.Redirect("~/FinancialModeling/funding_structure.aspx?Id=" + ViewState["Id"].ToString());

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