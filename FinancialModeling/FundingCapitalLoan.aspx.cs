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

public partial class FinancialModeling_FundingCapitalLoan : System.Web.UI.Page
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
                strTxtClientIds = txtCapitalLoan1.ClientID + "," + txtCapitalLoan2.ClientID + "," + txtCapitalLoan3.ClientID + "," + txtCapitalLoan4.ClientID;               
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState 
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
            //section zero data
            DataSet dsSectionZero = objFinModelingMgmt.getDataBySection(0);
            DataTable dtFsMapping_0 = dsSectionZero.Tables[0];
            DataTable dtInputValue_0 = dsSectionZero.Tables[1];
            if (dtInputValue_0.Rows.Count > 0)
            {              
                ViewState["TermLoanStatus"] = getInputValue(dtInputValue_0, 77);
                ViewState["CapitalExpenditureStatus"] = getInputValue(dtInputValue_0, 78);
            }

            DataSet ds = objFinModelingMgmt.getDataBySection(4);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];            
            if (dtInputValue.Rows.Count > 0)
            {
                txtCapitalLoan1.Text = getInputValue(dtInputValue, 50);
                txtCapitalLoan2.Text = getInputValue(dtInputValue, 51);
                txtCapitalLoan3.Text = getInputValue(dtInputValue, 52);
                txtCapitalLoan4.Text = getInputValue(dtInputValue, 53);
                txtCapitalLoanPer.Text = getInputValue(dtInputValue, 54);

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

                if (ViewState["TermLoanStatus"].ToString() == "0" || ViewState["Id"].ToString() == "0")
                {
                    if (ViewState["CapitalExpenditureStatus"].ToString() == "1")
                    {
                        _redirectPath = "CapitalExpenditure.aspx?Id=" + ViewState["Id"] + "";                        
                    }
                    else
                    {
                        _redirectPath = "OtherAssets.aspx?Id=" + ViewState["Id"] + "";                        
                    }
                }
                else
                {
                    _redirectPath = "FundingTermLoan.aspx?Id=" + ViewState["Id"] + "";                    
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
            dr1["MasterInputId"] = "50";
            if (txtCapitalLoan1.Text.Trim().Length > 0)
                dr1["Input_Value"] = txtCapitalLoan1.Text.Trim();
            else
                dr1["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["MasterInputId"] = "51";
            if (txtCapitalLoan2.Text.Trim().Length > 0)
                dr2["Input_Value"] = txtCapitalLoan2.Text.Trim();
            else
                dr2["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["MasterInputId"] = "52";

            if (txtCapitalLoan3.Text.Trim().Length > 0)
                dr3["Input_Value"] = txtCapitalLoan3.Text.Trim();
            else
                dr3["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "53";
            if (txtCapitalLoan4.Text.Trim().Length > 0)
                dr4["Input_Value"] = txtCapitalLoan4.Text.Trim();
            else
                dr4["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["MasterInputId"] = "54";
            if (txtCapitalLoanPer.Text.Trim().Length > 0)
                dr5["Input_Value"] = txtCapitalLoanPer.Text.Trim();
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
        if (ViewState["PreviousPage"] != null)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
        //Response.Redirect("~/FinancialModeling/FundingMain.aspx?Id=" + ViewState["Id"].ToString());
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
            strTxtClientIds = txtCapitalLoan1.ClientID + "," + txtCapitalLoan2.ClientID + "," + txtCapitalLoan3.ClientID + "," + txtCapitalLoan4.ClientID;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}