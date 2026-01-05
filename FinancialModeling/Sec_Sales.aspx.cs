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

public partial class FinancialModeling_Sec_Sales : System.Web.UI.Page
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
                DataTable dtCompanyFinDetails = objFinModelingMgmt.Get_CompanyFinDetails(ViewState["UserID"].ToString());
                ViewState["Id"] = dtCompanyFinDetails.Rows[0][0].ToString();

                if (ViewState["Id"].ToString() == "0")
                {
                    tr_Days.Visible = false;
                }
                else
                {
                    tr_Days.Visible = true;
                }



                bindCompanyInfo();
                bindData();
                bindClientIds();
                if (ViewState["CashTermHide"].ToString() == "yes")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "Combine('yes');", true);
                }
                else
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "Combine('no');", true);

            
            }
            txtTradingOfGoodsP1.Focus();

        }
    }

    private void bindClientIds()
    {

        strTxtClientIds = txtTradingOfGoodsP1.ClientID + "," + txtManufacturingSaleP1.ClientID + "," + txtServicesP1.ClientID;
        strLblClientIds = lblTradingOfGoodsP2.ClientID + "," + lblTradingOfGoodsP3.ClientID + "," + lblManufacturingSaleP2.ClientID + "," + lblManufacturingSaleP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblServicesP2.ClientID + "," + lblServicesP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotalP2.ClientID + "," + lblTotalP3.ClientID + "," + lblTotalP4.ClientID;

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
                //lblEstimate.Text = ViewState["CurrentYear"].ToString();
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
            DataSet ds = objFinModelingMgmt.getDataBySection(1);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drTradingGoods = getFsMappingValue(dtFsMapping, 33);
                txtTradingOfGoods.Text =  CommonBindings.TextToBind(drTradingGoods["FsMappingName"].ToString());
                txtTradingOfGoodsP1.Text =  CommonBindings.TextToBind(drTradingGoods["P1_Value"].ToString());
                lblTradingOfGoodsP2.Text =  CommonBindings.TextToBind(drTradingGoods["P2_Value"].ToString());
                lblTradingOfGoodsP3.Text =  CommonBindings.TextToBind(drTradingGoods["P3_Value"].ToString());
                txtTradingOfGoodsP1Per.Text =  CommonBindings.TextToBind(drTradingGoods["P1_Percent"].ToString());
                txtTradingOfGoodsP2Per.Text =  CommonBindings.TextToBind(drTradingGoods["P2_Percent"].ToString());


                DataRow drManufacturingSale = getFsMappingValue(dtFsMapping, 34);
                txtManufacturingSale.Text =  CommonBindings.TextToBind(drManufacturingSale["FsMappingName"].ToString());
                txtManufacturingSaleP1.Text =  CommonBindings.TextToBind(drManufacturingSale["P1_Value"].ToString());
                lblManufacturingSaleP2.Text =  CommonBindings.TextToBind(drManufacturingSale["P2_Value"].ToString());
                lblManufacturingSaleP3.Text =  CommonBindings.TextToBind(drManufacturingSale["P3_Value"].ToString());
                txtManufacturingSaleP1Per.Text =  CommonBindings.TextToBind(drManufacturingSale["P1_Percent"].ToString());
                txtManufacturingSaleP2Per.Text =  CommonBindings.TextToBind(drManufacturingSale["P2_Percent"].ToString());


                DataRow drServices = getFsMappingValue(dtFsMapping, 35);
                txtServices.Text =  CommonBindings.TextToBind(drServices["FsMappingName"].ToString());
                txtServicesP1.Text =  CommonBindings.TextToBind(drServices["P1_Value"].ToString());
                lblServicesP2.Text =  CommonBindings.TextToBind(drServices["P2_Value"].ToString());
                lblServicesP3.Text =  CommonBindings.TextToBind(drServices["P3_Value"].ToString());
                txtServicesP1Per.Text =  CommonBindings.TextToBind(drServices["P1_Percent"].ToString());
                txtServicesP2Per.Text =  CommonBindings.TextToBind(drServices["P2_Percent"].ToString());

                DataRow drTotals = getFsMappingValue(dtFsMapping, 36);
                lblTotalP2.Text =  CommonBindings.TextToBind(drTotals["P1_Value"].ToString());
                lblTotalP3.Text =  CommonBindings.TextToBind(drTotals["P2_Value"].ToString());
                lblTotalP4.Text =  CommonBindings.TextToBind(drTotals["P3_Value"].ToString());

            }
            if (dtInputValue.Rows.Count > 0)
            {
                string rblQ2Status = getInputValue(dtInputValue, 89);
                if (rblQ2Status == string.Empty)
                {
                    rbl_Q2.SelectedValue = "0";
                }
                else
                {
                    rbl_Q2.SelectedValue = rblQ2Status;
                }

                ViewState["CashTermHide"] = "no";
                if (rbl_Q2.SelectedValue.ToString() == "1")
                {
                    ViewState["CashTermHide"] = "yes";
                }
                txtSales1.Text = getInputValue(dtInputValue, 1);
                txtSales2.Text = getInputValue(dtInputValue, 2);
                txtSales3.Text = getInputValue(dtInputValue, 3);
                txtSales4.Text = getInputValue(dtInputValue, 4);

                txtDays1.Text = getInputValue(dtInputValue, 7);
                txtDays2.Text = getInputValue(dtInputValue, 8);
                txtDays3.Text = getInputValue(dtInputValue, 9);
                txtDays4.Text = getInputValue(dtInputValue, 10);
                //lblDays5.Text = getInputValue(dtInputValue, 11);


                int total = getInputValue(dtInputValue, 6) == "" ? 0 : Convert.ToInt32(getInputValue(dtInputValue, 6));
                if (total > 100)
                {
                    lblTotal.Attributes.Add("style", "background-color:#DC7171;");
                }
                lblTotal.Text = total + " %";

                lblAvgNumberofDays.Text = getInputValue(dtInputValue, 12);

                lblAvgDays.Text = getInputValue(dtInputValue, 12);

                txtDays.Text = getInputValue(dtInputValue, 63);

                if (bindAvgDays().ToString() == "NaN")
                {
                    lblCollectionDays.Text = " ";
                }
                else
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
            return dr[0]["Input_Value"].ToString().Trim();
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
                    objFinModelingMgmt.Update_FinTool_Sales(ViewState["UserID"].ToString());

                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Sec_CostOfSales.aspx";
                    Response.Redirect(redirectPath);
                }
                else
                {
                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Sec_Sales.aspx";
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
            dr1["FsMappingId"] = "33";
            if (txtTradingOfGoods.Text.Trim().Length > 0)
                dr1["FsMappingName"] = txtTradingOfGoods.Text.Trim();
            else
                dr1["FsMappingName"] = DBNull.Value;


            if (txtTradingOfGoodsP1.Text.Trim().Length > 0)
                dr1["P1_Value"] = txtTradingOfGoodsP1.Text.Trim();
            else
                dr1["P1_Value"] = DBNull.Value;

            if (lblTradingOfGoodsP2.Text.Trim().Length > 0)
                dr1["P2_Value"] = lblTradingOfGoodsP2.Text.Trim();
            else
                dr1["P2_Value"] = DBNull.Value;

            if (lblTradingOfGoodsP3.Text.Trim().Length > 0)
                dr1["P3_Value"] = lblTradingOfGoodsP3.Text.Trim();
            else
                dr1["P3_Value"] = DBNull.Value;

            if (txtTradingOfGoodsP1Per.Text.Trim().Length > 0)
                dr1["P1_Percent"] = txtTradingOfGoodsP1Per.Text.Trim();
            else
                dr1["P1_Percent"] = DBNull.Value;

            if (txtTradingOfGoodsP2Per.Text.Trim().Length > 0)
                dr1["P2_Percent"] = txtTradingOfGoodsP2Per.Text.Trim();
            else
                dr1["P2_Percent"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "34";

            if (txtManufacturingSale.Text.Trim().Length > 0)
                dr2["FsMappingName"] = txtManufacturingSale.Text.Trim();
            else
                dr2["FsMappingName"] = DBNull.Value;

            if (txtManufacturingSaleP1.Text.Trim().Length > 0)
                dr2["P1_Value"] = txtManufacturingSaleP1.Text.Trim();
            else
                dr2["P1_Value"] = DBNull.Value;

            if (lblManufacturingSaleP2.Text.Trim().Length > 0)
                dr2["P2_Value"] = lblManufacturingSaleP2.Text.Trim();
            else
                dr2["P2_Value"] = DBNull.Value;

            if (lblManufacturingSaleP3.Text.Trim().Length > 0)
                dr2["P3_Value"] = lblManufacturingSaleP3.Text.Trim();
            else
                dr2["P3_Value"] = DBNull.Value;

            if (txtManufacturingSaleP1Per.Text.Trim().Length > 0)
                dr2["P1_Percent"] = txtManufacturingSaleP1Per.Text.Trim();
            else
                dr2["P1_Percent"] = DBNull.Value;

            if (txtManufacturingSaleP2Per.Text.Trim().Length > 0)
                dr2["P2_Percent"] = txtManufacturingSaleP2Per.Text.Trim();
            else
                dr2["P2_Percent"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["FsMappingId"] = "35";
            if (txtServices.Text.Trim().Length > 0)
                dr3["FsMappingName"] = txtServices.Text.Trim();
            else
                dr3["FsMappingName"] = DBNull.Value;

            if (txtServicesP1.Text.Trim().Length > 0)
                dr3["P1_Value"] = txtServicesP1.Text.Trim();
            else
                dr3["P1_Value"] = DBNull.Value;

            if (lblServicesP2.Text.Trim().Length > 0)
                dr3["P2_Value"] = lblServicesP2.Text.Trim();
            else
                dr3["P2_Value"] = DBNull.Value;

            if (lblServicesP3.Text.Trim().Length > 0)
                dr3["P3_Value"] = lblServicesP3.Text.Trim();
            else
                dr3["P3_Value"] = DBNull.Value;

            if (txtServicesP1Per.Text.Trim().Length > 0)
                dr3["P1_Percent"] = txtServicesP1Per.Text.Trim();
            else
                dr3["P1_Percent"] = DBNull.Value;

            if (txtServicesP2Per.Text.Trim().Length > 0)
                dr3["P2_Percent"] = txtServicesP2Per.Text.Trim();
            else
                dr3["P2_Percent"] = DBNull.Value;

            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["FsMappingId"] = "220";
            if (txtTradingOfGoods.Text.Trim().Length > 0)
                dr4["FsMappingName"] = txtTradingOfGoods.Text.Trim();
            else
                dr4["FsMappingName"] = DBNull.Value;

            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["FsMappingId"] = "221";
            if (txtTradingOfGoods.Text.Trim().Length > 0)
                dr5["FsMappingName"] = txtManufacturingSale.Text.Trim();
            else
                dr5["FsMappingName"] = DBNull.Value;

            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["FsMappingId"] = "222";
            if (txtTradingOfGoods.Text.Trim().Length > 0)
                dr6["FsMappingName"] = txtServices.Text.Trim();
            else
                dr6["FsMappingName"] = DBNull.Value;

            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["FsMappingId"] = "266";
            if (txtTradingOfGoods.Text.Trim().Length > 0)
                dr7["FsMappingName"] = txtTradingOfGoods.Text.Trim();
            else
                dr7["FsMappingName"] = DBNull.Value;

            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["FsMappingId"] = "267";
            if (txtTradingOfGoods.Text.Trim().Length > 0)
                dr8["FsMappingName"] = txtManufacturingSale.Text.Trim();
            else
                dr8["FsMappingName"] = DBNull.Value;

            dt.Rows.Add(dr8);

            DataRow dr9 = dt.NewRow();
            dr9["FsMappingId"] = "268";
            if (txtTradingOfGoods.Text.Trim().Length > 0)
                dr9["FsMappingName"] = txtServices.Text.Trim();
            else
                dr9["FsMappingName"] = DBNull.Value;

            dt.Rows.Add(dr9);

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

            DataRow dr14 = dt.NewRow();
            dr14["MasterInputId"] = "89";
            dr14["Input_Value"] = rbl_Q2.SelectedValue;
            dt.Rows.Add(dr14);


            DataRow dr1 = dt.NewRow();
            dr1["MasterInputId"] = "1";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtSales1.Text.Trim().Length > 0)
                    dr1["Input_Value"] = txtSales1.Text.Trim();
                else
                    dr1["Input_Value"] = DBNull.Value;
            }
            else
                dr1["Input_Value"] = DBNull.Value;

            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["MasterInputId"] = "2";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtSales2.Text.Trim().Length > 0)
                    dr2["Input_Value"] = txtSales2.Text.Trim();
                else
                    dr2["Input_Value"] = DBNull.Value;
            }
            else
                dr2["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["MasterInputId"] = "3";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtSales3.Text.Trim().Length > 0)
                    dr3["Input_Value"] = txtSales3.Text.Trim();
                else
                    dr3["Input_Value"] = DBNull.Value;
            }
            else
                dr3["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "4";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtSales4.Text.Trim().Length > 0)
                    dr4["Input_Value"] = txtSales4.Text.Trim();
                else
                    dr4["Input_Value"] = DBNull.Value;
            }
            else
                dr4["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);

            DataRow dr6 = dt.NewRow();
            dr6["MasterInputId"] = "7";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtDays1.Text.Trim().Length > 0)
                    dr6["Input_Value"] = txtDays1.Text.Trim();
                else
                    dr6["Input_Value"] = DBNull.Value;
            }
            else
                dr6["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["MasterInputId"] = "8";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtDays2.Text.Trim().Length > 0)
                    dr7["Input_Value"] = txtDays2.Text.Trim();
                else
                    dr7["Input_Value"] = DBNull.Value;
            }
            else
                dr7["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["MasterInputId"] = "9";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtDays3.Text.Trim().Length > 0)
                    dr8["Input_Value"] = txtDays3.Text.Trim();
                else
                    dr8["Input_Value"] = DBNull.Value;
            }
            else
                dr8["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr8);

            DataRow dr9 = dt.NewRow();
            dr9["MasterInputId"] = "10";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtDays4.Text.Trim().Length > 0)
                    dr9["Input_Value"] = txtDays4.Text.Trim();
                else
                    dr9["Input_Value"] = DBNull.Value;
            }
            else
                dr9["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr9);

            DataRow dr10 = dt.NewRow();
            dr10["MasterInputId"] = "11";
            if (rbl_Q2.SelectedValue == "0")
            {
                //if (lblDays5.Text.Trim().Length > 0)
                //    dr10["Input_Value"] = lblDays5.Text.Trim();
                //else
                //    dr10["Input_Value"] = DBNull.Value;

            }
            else
                dr10["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr10);

            DataRow dr13 = dt.NewRow();
            dr13["MasterInputId"] = "63";
            if (rbl_Q2.SelectedValue == "0")
            {

                if (txtDays.Text.Trim().Length > 0)
                    dr13["Input_Value"] = txtDays.Text.Trim();
                else
                    dr13["Input_Value"] = DBNull.Value;
            }
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

                    objFinModelingMgmt.Update_FinTool_Sales(ViewState["UserID"].ToString());

                }
            }
        }
        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/FinancialModelingHome.aspx";
        Response.Redirect(redirectPath);
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        bindCompanyInfo();
        bindData();
        bindClientIds();
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "FormatCells", "formatCellsWithComma();", true);
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
                     objFinModelingMgmt.Update_FinTool_Sales(ViewState["UserID"].ToString());
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
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_Sales(ViewState["UserID"].ToString());

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
           
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                DataTable dtFsMapping = generateFsMapping();
                DataTable dtInputValues = generateInputValues();
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_Sales(ViewState["UserID"].ToString());

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
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_Sales(ViewState["UserID"].ToString());

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