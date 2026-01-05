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

public partial class FinancialModeling_OtherIncome : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    public static string strTxtClientIds = "";
    public static string strLblClientIds = "";
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

                ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState                                            

                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                bindCompanyInfo();
                bindData();
                bindClientIds();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
            }
        }

    }
    private void bindClientIds()
    {
        if (ViewState["Id"].ToString() == "1")
        {
            strTxtClientIds = txtRecurrEst.ClientID + "," + txtRecurrP1.ClientID + "," + txtNonRecurrEst.ClientID + "," + txtNonRecurrP1.ClientID;
            strLblClientIds = lblRecurrP2.ClientID + "," + lblRecurrP3.ClientID + "," + lblNonRecurrP2.ClientID + "," + lblNonRecurrP3.ClientID;
            strLblClientIds = strLblClientIds + "," + lblIncomeEstTotal.ClientID + "," + lblIncomeP1Total.ClientID + "," + lblIncomeP2Total.ClientID + "," + lblIncomeP3Total.ClientID;
        }
        else
        {
            strTxtClientIds = txtRecurrP1.ClientID + "," + txtNonRecurrP1.ClientID;
            strLblClientIds = lblRecurrP2.ClientID + "," + lblRecurrP3.ClientID + "," + lblNonRecurrP2.ClientID + "," + lblNonRecurrP3.ClientID;
            strLblClientIds = strLblClientIds + "," + lblIncomeP1Total.ClientID + "," + lblIncomeP2Total.ClientID + "," + lblIncomeP3Total.ClientID;
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

            lblEstmate1.Text = ViewState["CurrentYear"].ToString();
            lblProYear1.Text = ViewState["ProjYear1"].ToString();
            lblProYear2.Text = ViewState["ProjYear2"].ToString();
            lblProYear3.Text = ViewState["ProjYear3"].ToString();

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


                DataRow drOtherIncome = getFsMappingValue(dtFsMapping, 40);
                txtRecurrIncome.Text = drOtherIncome["FsMappingName"].ToString();
                txtRecurrEst.Text = drOtherIncome["C_Value"].ToString();
                txtRecurrP1.Text = drOtherIncome["P1_Value"].ToString();
                lblRecurrP2.Text = drOtherIncome["P2_Value"].ToString();
                lblRecurrP3.Text = drOtherIncome["P3_Value"].ToString();
                //txtRecurrEstPer.Text = drOtherIncome["C_Percent"].ToString();
                txtRecurrP1Per.Text = drOtherIncome["P1_Percent"].ToString();
                txtRecurrP2Per.Text = drOtherIncome["P2_Percent"].ToString();

                DataRow drNonRecurrIncome = getFsMappingValue(dtFsMapping, 88);
                txtNonRecurrIncome.Text = drNonRecurrIncome["FsMappingName"].ToString();
                txtNonRecurrEst.Text = drNonRecurrIncome["C_Value"].ToString();
                txtNonRecurrP1.Text = drNonRecurrIncome["P1_Value"].ToString();
                lblNonRecurrP2.Text = drNonRecurrIncome["P2_Value"].ToString();
                lblNonRecurrP3.Text = drNonRecurrIncome["P3_Value"].ToString();
                //txtNonRecurrEstPer.Text = drOtherIncome["C_Percent"].ToString();
                txtNonRecurrP1Per.Text = drNonRecurrIncome["P1_Percent"].ToString();
                txtNonRecurrP2Per.Text = drNonRecurrIncome["P2_Percent"].ToString();


                DataRow drTotalIncome = getFsMappingValue(dtFsMapping, 89);
                lblIncomeEstTotal.Text = drTotalIncome["C_Value"].ToString();
                lblIncomeP1Total.Text = drTotalIncome["P1_Value"].ToString();
                lblIncomeP2Total.Text = drTotalIncome["P2_Value"].ToString();
                lblIncomeP3Total.Text = drTotalIncome["P3_Value"].ToString();

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
            dr2["FsMappingId"] = "40";
            if (txtRecurrEst.Text.Trim().Length > 0)
                dr2["C_Value"] = txtRecurrEst.Text.Trim();
            else
                dr2["C_Value"] = DBNull.Value;

            if (txtRecurrP1.Text.Trim().Length > 0)
                dr2["P1_Value"] = txtRecurrP1.Text.Trim();
            else
                dr2["P1_Value"] = DBNull.Value;

            //if (lblRecurrP2.Text.Trim().Length > 0)
            //    dr2["P2_Value"] = lblRecurrP2.Text.Trim();
            //else
            //    dr2["P2_Value"] = DBNull.Value;

            //if (lblRecurrP3.Text.Trim().Length > 0)
            //    dr2["P3_Value"] = lblRecurrP3.Text.Trim();
            //else
            //    dr2["P3_Value"] = DBNull.Value;

            if (txtRecurrEstPer.Text.Trim().Length > 0)
                dr2["C_Percent"] = txtRecurrEstPer.Text.Trim();
            else
                dr2["C_Percent"] = DBNull.Value;

            if (txtRecurrP1Per.Text.Trim().Length > 0)
                dr2["P1_Percent"] = txtRecurrP1Per.Text.Trim();
            else
                dr2["P1_Percent"] = DBNull.Value;
            if (txtRecurrP2Per.Text.Trim().Length > 0)
                dr2["P2_Percent"] = txtRecurrP2Per.Text.Trim();
            else
                dr2["P2_Percent"] = DBNull.Value;

            if (txtRecurrIncome.Text.Trim().Length > 0)
                dr2["FsMappingName"] = txtRecurrIncome.Text.Trim();
            else
                dr2["FsMappingName"] = DBNull.Value;   

            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["FsMappingId"] = "88";
            if (txtNonRecurrEst.Text.Trim().Length > 0)
                dr3["C_Value"] = txtNonRecurrEst.Text.Trim();
            else
                dr3["C_Value"] = DBNull.Value;

            if (txtNonRecurrP1.Text.Trim().Length > 0)
                dr3["P1_Value"] = txtNonRecurrP1.Text.Trim();
            else
                dr3["P1_Value"] = DBNull.Value;

            //if (lblNonRecurrP2.Text.Trim().Length > 0)
            //    dr3["P2_Value"] = lblNonRecurrP2.Text.Trim();
            //else
            //    dr3["P2_Value"] = DBNull.Value;

            //if (lblNonRecurrP3.Text.Trim().Length > 0)
            //    dr3["P3_Value"] = lblNonRecurrP3.Text.Trim();
            //else
            //    dr3["P3_Value"] = DBNull.Value;

            if (txtNonRecurrEstPer.Text.Trim().Length > 0)
                dr3["C_Percent"] = txtNonRecurrEstPer.Text.Trim();
            else
                dr3["C_Percent"] = DBNull.Value;

            if (txtNonRecurrP1Per.Text.Trim().Length > 0)
                dr3["P1_Percent"] = txtNonRecurrP1Per.Text.Trim();
            else
                dr3["P1_Percent"] = DBNull.Value;
            if (txtNonRecurrP2Per.Text.Trim().Length > 0)
                dr3["P2_Percent"] = txtNonRecurrP2Per.Text.Trim();
            else
                dr3["P2_Percent"] = DBNull.Value;

            if (txtNonRecurrIncome.Text.Trim().Length > 0)
                dr3["FsMappingName"] = txtNonRecurrIncome.Text.Trim();
            else
                dr3["FsMappingName"] = DBNull.Value;  

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
            int i=objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
            if (i == 1)
            {
                objFinModelingMgmt.Update_FinTool_Totals();
                string _redirectPath ="FundingMain.aspx?Id=" + ViewState["Id"] + "";
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
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }

        //Response.Redirect("~/FinancialModeling/OperatingExpenses.aspx?Id=" + ViewState["Id"].ToString());
    }
    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("FinancialModelingHome.aspx?Id=" + ViewState["Id"].ToString());
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        bindCompanyInfo();
        bindData();
        bindClientIds();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
    }
}