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

public partial class FinancialModeling_Sec_SalesCollection : System.Web.UI.Page
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
            DataSet ds = objFinModelingMgmt.getDataBySection(1);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];            
            if (dtInputValue.Rows.Count > 0)
            {
                txtSales1.Text = getInputValue(dtInputValue, 1);
                txtSales2.Text = getInputValue(dtInputValue, 2);
                txtSales3.Text = getInputValue(dtInputValue, 3);
                txtSales4.Text = getInputValue(dtInputValue, 4);
                lblSales5.Text = getInputValue(dtInputValue, 5);

                txtDays1.Text = getInputValue(dtInputValue, 7);
                txtDays2.Text = getInputValue(dtInputValue, 8);
                txtDays3.Text = getInputValue(dtInputValue, 9);
                txtDays4.Text = getInputValue(dtInputValue, 10);
                //lblDays5.Text = getInputValue(dtInputValue, 11);
               

                int total = Convert.ToInt32(getInputValue(dtInputValue, 6));
                if (total > 100)
                {
                    lblTotal.Attributes.Add("style", "background-color:#DC7171;");                    
                }
                lblTotal.Text = total + " %";

                lblAvgNumberofDays.Text = getInputValue(dtInputValue, 12);

                lblAvgDays.Text = getInputValue(dtInputValue, 12);

                txtDays.Text = getInputValue(dtInputValue, 63);

                lblCollectionDays.Text = bindAvgDays().ToString(); 

                
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
                string _redirectPath = "Sec_CostOfSales.aspx?Id=" + ViewState["Id"] + "";
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


            //Sales

            DataRow dr1 = dt.NewRow();
            dr1["MasterInputId"] = "1";
            if (txtSales1.Text.Trim().Length > 0)
                dr1["Input_Value"] = txtSales1.Text.Trim();
            else
                dr1["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["MasterInputId"] = "2";
            if (txtSales2.Text.Trim().Length > 0)
                dr2["Input_Value"] = txtSales2.Text.Trim();
            else
                dr2["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["MasterInputId"] = "3";
            if (txtSales3.Text.Trim().Length > 0)
                dr3["Input_Value"] = txtSales3.Text.Trim();
            else
                dr3["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "4";
            if (txtSales4.Text.Trim().Length > 0)
                dr4["Input_Value"] = txtSales4.Text.Trim();
            else
                dr4["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);

            //DataRow dr5 = dt.NewRow();
            //dr5["MasterInputId"] = "5";
            //if (txtSales5.Text.Trim().Length > 0)
            //    dr5["Input_Value"] = txtSales5.Text.Trim();
            //else
            //    dr5["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr5);

            //No. Of days.

            DataRow dr6 = dt.NewRow();
            dr6["MasterInputId"] = "7";
            if (txtDays1.Text.Trim().Length > 0)
                dr6["Input_Value"] = txtDays1.Text.Trim();
            else
                dr6["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["MasterInputId"] = "8";
            if (txtDays2.Text.Trim().Length > 0)
                dr7["Input_Value"] = txtDays2.Text.Trim();
            else
                dr7["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["MasterInputId"] = "9";
            if (txtDays3.Text.Trim().Length > 0)
                dr8["Input_Value"] = txtDays3.Text.Trim();
            else
                dr8["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr8);

            DataRow dr9 = dt.NewRow();
            dr9["MasterInputId"] = "10";
            if (txtDays4.Text.Trim().Length > 0)
                dr9["Input_Value"] = txtDays4.Text.Trim();
            else
                dr9["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr9);

            //DataRow dr10 = dt.NewRow();
            //dr10["MasterInputId"] = "11";
            //if (txtDays5.Text.Trim().Length > 0)
            //    dr10["Input_Value"] = txtDays5.Text.Trim();
            //else
            //    dr10["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr10);


            //DataRow dr11 = dt.NewRow();
            //dr11["MasterInputId"] = "6";
            //string strDaysTotal = lblTotal.Text.Substring(0, lblTotal.Text.Length - 1);
            //if (Convert.ToInt32(strDaysTotal) > 0)
            //    dr11["Input_Value"] = strDaysTotal;
            //else
            //    dr11["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr11);

            //DataRow dr12 = dt.NewRow();
            //dr12["MasterInputId"] = "12";
            //if (lblAvgNumberofDays.Text.Trim().Length > 0)
            //    dr12["Input_Value"] = lblAvgNumberofDays.Text.Trim();
            //else
            //    dr12["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr12);

            DataRow dr13 = dt.NewRow();
            dr13["MasterInputId"] = "63";
            if (txtDays.Text.Trim().Length > 0)
                dr13["Input_Value"] = txtDays.Text.Trim();
            else
                dr13["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr13);          

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public double bindAvgDays()
    {
        try
        {
            double total = double.NaN;
            string FsMapIDs = "1,13";
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

    protected void btnBack_Click(object sender, EventArgs e)    {

        //Response.Redirect("~/FinancialModeling/Sec_Sales.aspx?Id="+ViewState["Id"].ToString());
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
        bindCompanyInfo();
        bindData();
    }
}