using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ABSBLL;
using ABSDTO;
using System.Data;
using System.Configuration;


public partial class FinancialModeling_Sec_Payments : System.Web.UI.Page
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
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                bindCompanyInfo();
                bindData();
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState 
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "highlightmenu", "HighlightMenu();", true);
            }

        }

    }

    private void bindCompanyInfo()
    {

        try
        {
            if (ViewState["UserID"] != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
                DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

                ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
                ViewState["ProjYear1"] = drCompanyInfo["P1_Year"].ToString();
                ViewState["ProjYear2"] = drCompanyInfo["P2_Year"].ToString();
                ViewState["ProjYear3"] = drCompanyInfo["P3_Year"].ToString();

                ViewState["Currency"] = drCompanyInfo["Currency"].ToString();
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
            DataSet ds = objFinModelingMgmt.getDataBySection(2);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];


            if (dtInputValue.Rows.Count > 0)
            {

                txtCostOfSale1.Text = getInputValue(dtInputValue, 25);
                txtCostOfSale2.Text = getInputValue(dtInputValue, 26);
                txtCostOfSale3.Text = getInputValue(dtInputValue, 27);
                txtCostOfSale4.Text = getInputValue(dtInputValue, 28);
                lblCostOfSale5.Text = getInputValue(dtInputValue, 29);

                int total = Convert.ToInt32(getInputValue(dtInputValue, 30));
                if (total > 100)
                {
                    lblTotal.Attributes.Add("style", "background-color:#DC7171;");
                }
                lblTotal.Text = total + " %";               

                txtNumberOfDays1.Text = getInputValue(dtInputValue, 31);
                txtNumberOfDays2.Text = getInputValue(dtInputValue, 32);
                txtNumberOfDays3.Text = getInputValue(dtInputValue, 33);
                txtNumberOfDays4.Text = getInputValue(dtInputValue, 34);
                //txtNumberOfDays5.Text = getInputValue(dtInputValue, 35);

                lblAverageDays.Text = getInputValue(dtInputValue, 80);
                lblAvgDays.Text = getInputValue(dtInputValue, 80);
                lblAvgPaymentDays.Text = bindAvgPaymentDays().ToString();
                txtDays.Text = getInputValue(dtInputValue, 64);
                
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
            if (ViewState["UserID"] != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_Totals();
                    string _redirectPath = "OperatingExpenses.aspx?Id=" + ViewState["Id"] + "";
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Data Saved Successfully.'); location='" + _redirectPath + "';</Script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Updation failed.'); </Script>");
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



            //No. Of days.
            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "25";
            if (txtCostOfSale1.Text.Trim().Length > 0)
                dr4["Input_Value"] = txtCostOfSale1.Text.Trim();
            else
                dr4["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["MasterInputId"] = "26";
            if (txtCostOfSale2.Text.Trim().Length > 0)
                dr5["Input_Value"] = txtCostOfSale2.Text.Trim();
            else
                dr5["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["MasterInputId"] = "27";
            if (txtCostOfSale3.Text.Trim().Length > 0)
                dr6["Input_Value"] = txtCostOfSale3.Text.Trim();
            else
                dr6["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["MasterInputId"] = "28";
            if (txtCostOfSale4.Text.Trim().Length > 0)
                dr7["Input_Value"] = txtCostOfSale4.Text.Trim();
            else
                dr7["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr7);

            //DataRow dr8 = dt.NewRow();
            //dr8["MasterInputId"] = "29";
            //if (txtCostOfSale5.Text.Trim().Length > 0)
            //    dr8["Input_Value"] = txtCostOfSale5.Text.Trim();
            //else
            //    dr8["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr8);

            DataRow dr9 = dt.NewRow();
            dr9["MasterInputId"] = "31";
            if (txtNumberOfDays1.Text.Trim().Length > 0)
                dr9["Input_Value"] = txtNumberOfDays1.Text.Trim();
            else
                dr9["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr9);

            DataRow dr10 = dt.NewRow();
            dr10["MasterInputId"] = "32";
            if (txtNumberOfDays2.Text.Trim().Length > 0)
                dr10["Input_Value"] = txtNumberOfDays2.Text.Trim();
            else
                dr10["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr10);

            DataRow dr11 = dt.NewRow();
            dr11["MasterInputId"] = "33";
            if (txtNumberOfDays3.Text.Trim().Length > 0)
                dr11["Input_Value"] = txtNumberOfDays3.Text.Trim();
            else
                dr11["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr11);

            DataRow dr12 = dt.NewRow();
            dr12["MasterInputId"] = "34";
            if (txtNumberOfDays4.Text.Trim().Length > 0)
                dr12["Input_Value"] = txtNumberOfDays4.Text.Trim();
            else
                dr12["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr12);

            //DataRow dr13 = dt.NewRow();
            //dr13["MasterInputId"] = "35";
            //if (txtNumberOfDays5.Text.Trim().Length > 0)
            //    dr13["Input_Value"] = txtNumberOfDays5.Text.Trim();
            //else
            //    dr13["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr13);


            DataRow dr18 = dt.NewRow();
            dr18["MasterInputId"] = "64";
            if (txtDays.Text.Trim().Length > 0)
                dr18["Input_Value"] = txtDays.Text.Trim().ToString();
            else
                dr18["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr18);

            //DataRow dr19 = dt.NewRow();
            //dr19["MasterInputId"] = "30";
            //if (lblTotal.Text.Trim().Length > 0)
            //dr19["Input_Value"] = lblTotal.Text.Trim().ToString();
            //else
            //    dr19["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr19);

            //DataRow dr20 = dt.NewRow();
            //dr20["MasterInputId"] = "81";
            //if (lblAverageDays.Text.Trim().Length > 0)
            //dr20["Input_Value"] = lblAverageDays.Text.Trim().ToString();
            //else
            //    dr20["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr20);


            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/FinancialModeling/Sec_CostOfSales.aspx?Id=" + ViewState["Id"].ToString());
        if (ViewState["PreviousPage"] != null)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }


    public double bindAvgPaymentDays()
    {
        try
        {
            double total = double.NaN;
            string FsMapIDs = "2,23";
            DataSet ds = objFinModelingMgmt.getStatementByMapID(FsMapIDs);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][1] != DBNull.Value && ds.Tables[0].Rows[1][1] != DBNull.Value)
                {
                    double sales = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                    double TradeReceivables = Convert.ToDouble(ds.Tables[0].Rows[1][1].ToString());
                    total = Math.Round(TradeReceivables / sales * 365);
                }

            }
            return total;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnHome_Click(object sender, EventArgs e)
    {
        if (ViewState["Id"] != "" && ViewState["Id"] != null)
        {
            Response.Redirect("FinancialModelingHome.aspx?Id=" + ViewState["Id"].ToString());
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        bindCompanyInfo();
        bindData();
    }
}