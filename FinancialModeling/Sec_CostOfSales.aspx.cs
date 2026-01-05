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
using ABSCommon;
using System.Globalization;
using System.Threading;

public partial class FinancialModeling_Sec_CostOfSales : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    UserMgmt objUserMgmt = new UserMgmt();

    //static string[] strValues = new string[9];
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
                    tr_Days1.Visible = false;
                }
                else
                {
                    tr_Days.Visible = true;
                    tr_Days1.Visible = true;
                }

                bindCompanyInfo();
                bindData();
                bindClientIds();
                CallJScriptMethod();

       
            }
            txtTradingOfGoodsPer.Focus();

        }

    }
    private void CallJScriptMethod()
    {
        string strCashTerm = "no", strMFHide = "no", strStockStaus = "no";
        if (ViewState["CashTermHide"].ToString() == "yes")
        {
            strCashTerm = "yes";
        }
        if (ViewState["MFHide"].ToString() == "yes")
        {
            strMFHide = "yes";
        }
        if (ViewState["StockHide"].ToString() == "yes")
        {
            strStockStaus = "yes";
        }

        Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "Combine('" + strMFHide + "','" + strCashTerm + "','" + strStockStaus + "');", true);
        
       
    }
    private void bindClientIds()
    {        
            strTxtClientIds = txtProjectionP1.ClientID;
            strLblClientIds = lblProjectionP2.ClientID + "," + lblProjectionP3.ClientID;        
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
            if (dtInputValue_0.Rows.Count > 0)
            {
                ViewState["StockStatus"] = getInputValue(dtInputValue_0, 74);
                ViewState["MFActivitiesStatus"] = getInputValue(dtInputValue_0, 75);
                ViewState["MFHide"] = "no";
                ViewState["StockHide"] = "no";
                if (ViewState["MFActivitiesStatus"].ToString() == "0")
                {
                    ViewState["MFHide"] = "yes";              
                }
                if (ViewState["StockStatus"].ToString() == "0")
                {
                    ViewState["StockHide"] = "yes";
                }
                
            }
            //section one data
            DataSet dsSection = objFinModelingMgmt.getDataBySection(1);
            DataTable dt_FsMapping = dsSection.Tables[0];
            DataTable dt_InputValue = dsSection.Tables[1];
            ViewState["dt_FsMapping"] = dt_FsMapping;
            if (dt_FsMapping.Rows.Count > 0)
            {
                DataRow drTradingGoods = getFsMappingValue(dt_FsMapping, 33);
                lblTradingOfGoods.Text = drTradingGoods["FsMappingName"].ToString();

                DataRow drManufacturingSale = getFsMappingValue(dt_FsMapping, 34);
                lblManufacturingSale.Text = drManufacturingSale["FsMappingName"].ToString();

                DataRow drServices = getFsMappingValue(dt_FsMapping, 35);
                lblServices.Text = drServices["FsMappingName"].ToString();
            }
            if (dt_InputValue.Rows.Count > 0)
            {
                ViewState["SalesStatus"] = getInputValue(dt_InputValue, 89);
            }

            //section two data
            DataSet ds = objFinModelingMgmt.getDataBySection(2);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];

            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drTradingGoods = getFsMappingValue(dtFsMapping, 38);              
                
                txtProjectionP1.Text = CommonBindings.TextToBind(drTradingGoods["P1_Value"].ToString());
                lblProjectionP2.Text = CommonBindings.TextToBind(drTradingGoods["P2_Value"].ToString());
                lblProjectionP3.Text = CommonBindings.TextToBind(drTradingGoods["P3_Value"].ToString());               
                txtProjectionP1Per.Text = CommonBindings.TextToBind(drTradingGoods["P1_Percent"].ToString());
                txtProjectionP2Per.Text = CommonBindings.TextToBind(drTradingGoods["P2_Percent"].ToString());


                DataRow drTradingGoods1 = getFsMappingValue(dtFsMapping, 166);
                lblTradingOfGoodsP1.Text = CommonBindings.TextToBind(drTradingGoods1["P1_Percent"].ToString());
                lblManufacturingSaleP1.Text = CommonBindings.TextToBind(drTradingGoods1["P2_Percent"].ToString());
                lblServicesP1.Text = CommonBindings.TextToBind(drTradingGoods1["P3_Percent"].ToString()); 
            }
            if (dtInputValue.Rows.Count > 0)
            {
                txtTradingOfGoodsPer.Text = getInputValue(dtInputValue, 15);
                txtManufacturingSalePer.Text = getInputValue(dtInputValue, 16);
                txtServicesPer.Text = getInputValue(dtInputValue, 17);

                string rblQ2Status = getInputValue(dtInputValue, 90);
                if (rblQ2Status == string.Empty)
                {
                    rbl_Q2.SelectedValue = "0";
                }
                else
                {
                    rbl_Q2.SelectedValue = rblQ2Status;
                }
                
                ViewState["CashTermHide"] = "no";
                if (rbl_Q2.SelectedValue == "1")
                {
                    ViewState["CashTermHide"] = "yes";
                }

                txtCostOfSale1.Text = getInputValue(dtInputValue, 25);
                txtCostOfSale2.Text = getInputValue(dtInputValue, 26);
                txtCostOfSale3.Text = getInputValue(dtInputValue, 27);
                txtCostOfSale4.Text = getInputValue(dtInputValue, 28);

                string strtotal = getInputValue(dtInputValue, 30);
                int intTotal=0;
                if (strtotal != null && strtotal != "")
                {
                    intTotal = Convert.ToInt32(strtotal);
                    if (intTotal > 100)
                    {
                        lblTotal.Attributes.Add("style", "background-color:#DC7171;");
                    }
                    lblTotal.Text = intTotal + " %";
                }

               

                txtNumberOfDays1.Text = getInputValue(dtInputValue, 31);
                txtNumberOfDays2.Text = getInputValue(dtInputValue, 32);
                txtNumberOfDays3.Text = getInputValue(dtInputValue, 33);
                txtNumberOfDays4.Text = getInputValue(dtInputValue, 34);
                //txtNumberOfDays5.Text = getInputValue(dtInputValue, 35);

                lblAverageDays.Text = getInputValue(dtInputValue, 80);
                lblAvgDays.Text = getInputValue(dtInputValue, 80);
                if (bindAvgPaymentDays().ToString() == "NaN")
                {
                    lblAvgPaymentDays.Text = "";
                }
                else
                lblAvgPaymentDays.Text = bindAvgPaymentDays().ToString();

                txtDays.Text = getInputValue(dtInputValue, 64);


                //stock
                txtOnTheAverageDays1.Text = getInputValue(dtInputValue, 40);
                txtOnTheAverageDays2.Text = getInputValue(dtInputValue, 41);
                txtOnTheAverageDays3.Text = getInputValue(dtInputValue, 42);
                txtOnTheAverageDays4.Text = getInputValue(dtInputValue, 43);
                lblAvgDaysTotal.Text = getInputValue(dtInputValue, 81);
                lblAvgStockPeriod.Text = getInputValue(dtInputValue, 81);
                if (bindAvgNumofDays().ToString() == "NaN")
                {
                    lblAvgNumOfDays.Text = "";
                }
                else
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
            string redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_CostOfSales(ViewState["UserID"].ToString());

                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/OperatingExpenses.aspx";
                    Response.Redirect(redirectPath);
                }
                else
                {
                    redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Sec_CostOfSales.aspx";
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
            dr1["FsMappingId"] = "38";
            if (ViewState["MFActivitiesStatus"].ToString() == "1")
            {                
                if (txtProjectionP1.Text.Trim().Length > 0)
                    dr1["P1_Value"] = txtProjectionP1.Text.Trim();
                else
                    dr1["P1_Value"] = DBNull.Value;

                if (lblProjectionP2.Text.Trim().Length > 0)
                    dr1["P2_Value"] = lblProjectionP2.Text.Trim();
                else
                    dr1["P2_Value"] = DBNull.Value;

                if (lblProjectionP3.Text.Trim().Length > 0)
                    dr1["P3_Value"] = lblProjectionP3.Text.Trim();
                else
                    dr1["P3_Value"] = DBNull.Value;              

                if (txtProjectionP1Per.Text.Trim().Length > 0)
                    dr1["P1_Percent"] = txtProjectionP1Per.Text.Trim();
                else
                    dr1["P1_Percent"] = DBNull.Value;

                if (txtProjectionP2Per.Text.Trim().Length > 0)
                    dr1["P2_Percent"] = txtProjectionP2Per.Text.Trim();
                else
                    dr1["P2_Percent"] = DBNull.Value;
            }            
            dt.Rows.Add(dr1);   

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
            dr1["MasterInputId"] = "15";
            if (txtTradingOfGoodsPer.Text.Trim().Length > 0)
                dr1["Input_Value"] = txtTradingOfGoodsPer.Text.Trim();
            else
                dr1["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["MasterInputId"] = "16";
            if (txtManufacturingSalePer.Text.Trim().Length > 0)
                dr2["Input_Value"] = txtManufacturingSalePer.Text.Trim();
            else
                dr2["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["MasterInputId"] = "17";
            if (txtServicesPer.Text.Trim().Length > 0)
                dr3["Input_Value"] = txtServicesPer.Text.Trim();
            else
                dr3["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "90";
            dr4["Input_Value"] = rbl_Q2.SelectedValue;
            dt.Rows.Add(dr4);

            
            DataRow dr5 = dt.NewRow();
            dr5["MasterInputId"] = "25";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtCostOfSale1.Text.Trim().Length > 0)
                    dr5["Input_Value"] = txtCostOfSale1.Text.Trim();
                else
                    dr5["Input_Value"] = DBNull.Value;
            }
            else
                dr5["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["MasterInputId"] = "26";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtCostOfSale2.Text.Trim().Length > 0)
                    dr6["Input_Value"] = txtCostOfSale2.Text.Trim();
                else
                    dr6["Input_Value"] = DBNull.Value;
            }
            else
                dr6["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["MasterInputId"] = "27";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtCostOfSale3.Text.Trim().Length > 0)
                    dr7["Input_Value"] = txtCostOfSale3.Text.Trim();
                else
                    dr7["Input_Value"] = DBNull.Value;
            }
            else
                dr7["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["MasterInputId"] = "28";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtCostOfSale4.Text.Trim().Length > 0)
                    dr8["Input_Value"] = txtCostOfSale4.Text.Trim();
                else
                    dr8["Input_Value"] = DBNull.Value;
            }
            else
                dr8["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr8);           

            DataRow dr9 = dt.NewRow();
            dr9["MasterInputId"] = "31";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtNumberOfDays1.Text.Trim().Length > 0)
                    dr9["Input_Value"] = txtNumberOfDays1.Text.Trim();
                else
                    dr9["Input_Value"] = DBNull.Value;
            }
            else
                dr9["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr9);

            DataRow dr10 = dt.NewRow();
            dr10["MasterInputId"] = "32";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtNumberOfDays2.Text.Trim().Length > 0)
                    dr10["Input_Value"] = txtNumberOfDays2.Text.Trim();
                else
                    dr10["Input_Value"] = DBNull.Value;
            }
            else
                dr10["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr10);

            DataRow dr11 = dt.NewRow();
            dr11["MasterInputId"] = "33";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtNumberOfDays3.Text.Trim().Length > 0)
                    dr11["Input_Value"] = txtNumberOfDays3.Text.Trim();
                else
                    dr11["Input_Value"] = DBNull.Value;
            }
            else
                dr11["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr11);

            DataRow dr12 = dt.NewRow();
            dr12["MasterInputId"] = "34";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtNumberOfDays4.Text.Trim().Length > 0)
                    dr12["Input_Value"] = txtNumberOfDays4.Text.Trim();
                else
                    dr12["Input_Value"] = DBNull.Value;
            }
            else
                dr12["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr12);

            //DataRow dr13 = dt.NewRow();
            //dr13["MasterInputId"] = "35";
            //if (rbl_Q2.SelectedValue == "0")
            //{
            //    if (lblNumberOfDays5.Text.Trim().Length > 0)
            //        dr13["Input_Value"] = lblNumberOfDays5.Text.Trim();
            //    else
            //        dr13["Input_Value"] = DBNull.Value;
            //}
            //else
            //    dr13["Input_Value"] = DBNull.Value;
            //dt.Rows.Add(dr13);


            DataRow dr14 = dt.NewRow();
            dr14["MasterInputId"] = "64";
            if (rbl_Q2.SelectedValue == "0")
            {
                if (txtDays.Text.Trim().Length > 0)
                    dr14["Input_Value"] = txtDays.Text.Trim().ToString();
                else
                    dr14["Input_Value"] = DBNull.Value;
            }
            else
                dr14["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr14);

            //stock

            DataRow dr19 = dt.NewRow();
            dr19["MasterInputId"] = "40";
            if (ViewState["StockStatus"].ToString() == "1")
            {
                if (txtOnTheAverageDays1.Text.Trim().Length > 0)
                    dr19["Input_Value"] = txtOnTheAverageDays1.Text.Trim();
                else
                    dr19["Input_Value"] = DBNull.Value;
            }
            else
                dr19["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr19);

            DataRow dr15 = dt.NewRow();
            dr15["MasterInputId"] = "41";
            if (ViewState["StockStatus"].ToString() == "1")
            {
                if (txtOnTheAverageDays2.Text.Trim().Length > 0)
                    dr15["Input_Value"] = txtOnTheAverageDays2.Text.Trim();
                else
                    dr15["Input_Value"] = DBNull.Value;
            }
            else
                dr15["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr15);

            DataRow dr16 = dt.NewRow();
            dr16["MasterInputId"] = "42";
            if (ViewState["StockStatus"].ToString() == "1")
            {
                if (txtOnTheAverageDays3.Text.Trim().Length > 0)
                    dr16["Input_Value"] = txtOnTheAverageDays3.Text.Trim();
                else
                    dr16["Input_Value"] = DBNull.Value;
            }
            else
                dr16["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr16);

            DataRow dr17 = dt.NewRow();
            dr17["MasterInputId"] = "43";
            if (ViewState["StockStatus"].ToString() == "1")
            {
                if (txtOnTheAverageDays4.Text.Trim().Length > 0)
                    dr17["Input_Value"] = txtOnTheAverageDays4.Text.Trim();
                else
                    dr17["Input_Value"] = DBNull.Value;
            }
            else
                dr17["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr17);


            DataRow dr22 = dt.NewRow();
            dr22["MasterInputId"] = "49";
            if (ViewState["StockStatus"].ToString() == "1")
            {
                if (txtAvgStockDays.Text.Trim().Length > 0)
                    dr22["Input_Value"] = txtAvgStockDays.Text.Trim().ToString();
                else
                    dr22["Input_Value"] = DBNull.Value;
            }
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

                    objFinModelingMgmt.Update_FinTool_CostOfSales(ViewState["UserID"].ToString());

                }
            }
        }
        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Sec_Sales.aspx";
        Response.Redirect(redirectPath);
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        if (ViewState["dt_FsMapping"].ToString() != "" && ViewState["dt_FsMapping"] != null)
        {
            try
            {
                DataTable dt_FsMapping = (DataTable)ViewState["dt_FsMapping"];
                if (dt_FsMapping.Rows.Count > 0)
                {
                    DataRow drTradingGoods = getFsMappingValue(dt_FsMapping, 33);
                    DataRow drManufacturingSale = getFsMappingValue(dt_FsMapping, 34);
                    DataRow drServices = getFsMappingValue(dt_FsMapping, 35);
                    DataRow drTotal = getFsMappingValue(dt_FsMapping, 36);

                    double Proj1Goods = 0;
                    double Proj1Sale = 0;
                    double Proj1Services = 0;
                    double Proj2Goods = 0;
                    double Proj2Sale = 0;
                    double Proj2Services = 0;
                    double Proj3Goods = 0;
                    double Proj3Sale = 0;
                    double Proj3Services = 0;


                    if (txtTradingOfGoodsPer.Text.Trim().Length > 0 || txtManufacturingSalePer.Text.Trim().Length > 0 || txtServicesPer.Text.Trim().Length > 0)
                    {
                        if (txtTradingOfGoodsPer.Text.Trim().Length > 0)
                            Proj1Goods = (CheckNullValue(drTradingGoods["P1_Value"].ToString()) * Convert.ToDouble(txtTradingOfGoodsPer.Text)) / 100;

                        if (txtManufacturingSalePer.Text.Trim().Length > 0)
                            Proj1Sale = (CheckNullValue(drManufacturingSale["P1_Value"].ToString()) * Convert.ToDouble(txtManufacturingSalePer.Text)) / 100;

                        if (txtServicesPer.Text.Trim().Length > 0)
                            Proj1Services = (CheckNullValue(drServices["P1_Value"].ToString()) * Convert.ToDouble(txtServicesPer.Text)) / 100;

                        if (CheckNullValue(drTotal["P1_Value"].ToString()) > 0)
                            lblTradingOfGoodsP1.Text = Convert.ToString(Math.Round(((Proj1Goods + Proj1Sale + Proj1Services) / CheckNullValue(drTotal["P1_Value"].ToString()) * 100), 1));
                        else
                            lblTradingOfGoodsP1.Text = "";



                        if (txtTradingOfGoodsPer.Text.Trim().Length > 0)
                            Proj2Goods = (CheckNullValue(drTradingGoods["P2_Value"].ToString()) * Convert.ToDouble(txtTradingOfGoodsPer.Text)) / 100;

                        if (txtManufacturingSalePer.Text.Trim().Length > 0)
                            Proj2Sale = (CheckNullValue(drManufacturingSale["P2_Value"].ToString()) * Convert.ToDouble(txtManufacturingSalePer.Text)) / 100;

                        if (txtServicesPer.Text.Trim().Length > 0)
                            Proj2Services = (CheckNullValue(drServices["P2_Value"].ToString()) * Convert.ToDouble(txtServicesPer.Text)) / 100;

                        if (CheckNullValue(drTotal["P2_Value"].ToString()) > 0)
                            lblManufacturingSaleP1.Text = Convert.ToString(Math.Round(((Proj2Goods + Proj2Sale + Proj2Services) / CheckNullValue(drTotal["P2_Value"].ToString()) * 100), 1));
                        else
                            lblManufacturingSaleP1.Text = "";



                        if (txtTradingOfGoodsPer.Text.Trim().Length > 0)
                            Proj3Goods = (CheckNullValue(drTradingGoods["P3_Value"].ToString()) * Convert.ToDouble(txtTradingOfGoodsPer.Text)) / 100;

                        if (txtManufacturingSalePer.Text.Trim().Length > 0)
                            Proj3Sale = (CheckNullValue(drManufacturingSale["P3_Value"].ToString()) * Convert.ToDouble(txtManufacturingSalePer.Text)) / 100;

                        if (txtServicesPer.Text.Trim().Length > 0)
                            Proj3Services = (CheckNullValue(drServices["P3_Value"].ToString()) * Convert.ToDouble(txtServicesPer.Text)) / 100;

                        if (CheckNullValue(drTotal["P3_Value"].ToString()) > 0)
                            lblServicesP1.Text = Convert.ToString(Math.Round(((Proj3Goods + Proj3Sale + Proj3Services) / CheckNullValue(drTotal["P3_Value"].ToString()) * 100), 1));
                        else
                            lblServicesP1.Text = "";
                    }

                }
                if (ViewState["MFActivitiesStatus"].ToString() == "0" || ViewState["StockHide"].ToString() == "yes")
                {
                    ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "hideC", "hideQ2_withCondition('" + ViewState["MFActivitiesStatus"].ToString() + "','" + ViewState["StockHide"].ToString() + "');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "Recalculate", "CalcEstimateP2Increase();", true);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    private double CheckNullValue(string strTempValue)
    {

        if (strTempValue == string.Empty)
            return 0;
        else
            return Convert.ToDouble(strTempValue);
    }
  
    protected void btnClear_Click(object sender, EventArgs e)
    {
        bindCompanyInfo();
        bindData();
        bindClientIds();
        CallJScriptMethod();
        ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "FormatCells", "formatCellsWithComma();", true);

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
                    objFinModelingMgmt.Update_FinTool_CostOfSales(ViewState["UserID"].ToString());
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

                    objFinModelingMgmt.Update_FinTool_CostOfSales(ViewState["UserID"].ToString());

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

                    objFinModelingMgmt.Update_FinTool_CostOfSales(ViewState["UserID"].ToString());

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

                    objFinModelingMgmt.Update_FinTool_CostOfSales(ViewState["UserID"].ToString());

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