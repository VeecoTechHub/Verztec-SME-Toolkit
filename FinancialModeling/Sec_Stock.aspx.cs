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


public partial class FinancialModeling_Sec_Stock : System.Web.UI.Page
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
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
            DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

            ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
            ViewState["ProjYear1"] = drCompanyInfo["P1_Year"].ToString();
            ViewState["ProjYear2"] = drCompanyInfo["P2_Year"].ToString();
            ViewState["ProjYear3"] = drCompanyInfo["P3_Year"].ToString();

            ViewState["Currency"] = drCompanyInfo["Currency"].ToString();           
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
            

            //section data
            DataSet ds = objFinModelingMgmt.getDataBySection(2);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];

            
            if (dtInputValue.Rows.Count > 0)
            {                   

                txtOnTheAverageDays1.Text = getInputValue(dtInputValue, 40);
                txtOnTheAverageDays2.Text = getInputValue(dtInputValue, 41);
                txtOnTheAverageDays3.Text = getInputValue(dtInputValue, 42);
                txtOnTheAverageDays4.Text = getInputValue(dtInputValue, 43);
                lblAvgDaysTotal.Text = getInputValue(dtInputValue, 81);
                lblAvgStockPeriod.Text = getInputValue(dtInputValue, 81);

                lblAvgNumOfDays.Text = bindAvgNumofDays().ToString();
                txtAvgStockDays.Text = getInputValue(dtInputValue, 49);    

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
                string _redirectPath = "OperatingExpenses.aspx?Id=" + ViewState["Id"] + "";
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
           

            DataRow dr14 = dt.NewRow();
            dr14["MasterInputId"] = "40";
            if (txtOnTheAverageDays1.Text.Trim().Length > 0)
            dr14["Input_Value"] = txtOnTheAverageDays1.Text.Trim();
            else
                dr14["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr14);

            DataRow dr15 = dt.NewRow();
            dr15["MasterInputId"] = "41";
            if (txtOnTheAverageDays2.Text.Trim().Length > 0)
            dr15["Input_Value"] = txtOnTheAverageDays2.Text.Trim();
            else
                dr15["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr15);

            DataRow dr16 = dt.NewRow();
            dr16["MasterInputId"] = "42";
            if (txtOnTheAverageDays3.Text.Trim().Length > 0)
            dr16["Input_Value"] = txtOnTheAverageDays3.Text.Trim();
            else
                dr16["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr16);

            DataRow dr17 = dt.NewRow();
            dr17["MasterInputId"] = "43";
            if (txtOnTheAverageDays4.Text.Trim().Length > 0)
            dr17["Input_Value"] = txtOnTheAverageDays4.Text.Trim();
            else
                dr17["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr17); 
            

            DataRow dr22 = dt.NewRow();
            dr22["MasterInputId"] = "49";
            if (txtAvgStockDays.Text.Trim().Length > 0)
            dr22["Input_Value"] = txtAvgStockDays.Text.Trim().ToString();
            else
                dr22["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr22);
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
    
    public double bindAvgNumofDays()
    {
        try
        {
            double total = double.NaN;
            string FsMapIDs = "2,14";
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
        Response.Redirect("FinancialModelingHome.aspx?Id=" + ViewState["Id"].ToString());
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        bindCompanyInfo();
        bindData();
    }
}