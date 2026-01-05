using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using ABSDAL;
using ABSBLL;
using ABSDTO;
using System.Configuration;

public partial class FinancialModeling_DownloadReport : System.Web.UI.Page
{

    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    Report_BLL bll = new Report_BLL();
    TradeCycle_Bll obj = new TradeCycle_Bll();
    UserMgmt objUserMgmt = new UserMgmt();
    public static string strLblClientIds = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {

            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
            ViewState["C_Year"] = dtCompanyInfo.Rows[0]["LatestFinancialYear"];
            ViewState["P1_Year"] = dtCompanyInfo.Rows[0]["P1_Year"];
            ViewState["P2_Year"] = dtCompanyInfo.Rows[0]["P2_Year"];
            ViewState["P3_Year"] = dtCompanyInfo.Rows[0]["P3_Year"];
            ViewState["RoundDollarType"] = dtCompanyInfo.Rows[0]["RoundDollarType"];
            DataTable dtCompanyInfo1 = objFinModelingMgmt.bindCompanyInformationByUserID();

            lblCompanyName.Text = Convert.ToString(dtCompanyInfo1.Rows[0]["CompanyName"]);
            lblFinancialYr.Text = Convert.ToDateTime(dtCompanyInfo1.Rows[0]["FinYearEndDate"]).AddYears(3).ToString("dd MMM yyyy");// DateTime.Now.AddYears(3).ToShortDateString();
            lblTodayDate.Text = DateTime.Now.ToString("dd MMM yyyy");
        }
        bindFinancialHighlightsChart();
        bindChartSegmentAnalysis();
        if (ViewState["C_Year"] != null && Convert.ToString(ViewState["C_Year"]) != "")
        {
            CashConversion1_Chart.Visible = true;
            bindChart_CC1();
        }
        bindChart_CC2();
        bindCompanyInfo();
        Binddata();

      
        BindClientIds();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "FormatCells", "formatCellsWithComma('" + strLblClientIds + "');", true);
        string inputStatus = objFinModelingMgmt.getInputStatus("74", Convert.ToString(ViewState["UserID"]));
        if (inputStatus == "0")
        {
            trTradeCycle.Visible = false;
        }
        else if (inputStatus == "1")
        {
            trTradeCycle.Visible = true;

            DataSet ds = obj.getTradeCycleDate(ViewState["UserID"].ToString());
            int x2, x3, x4, x5, x6, x7;
            x2 = Convert.ToString(ds.Tables[0].Rows[0][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[0][0]) : 0;
            x3 = Convert.ToString(ds.Tables[0].Rows[1][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[1][0]) : 0;
            x4 = Convert.ToString(ds.Tables[0].Rows[2][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[2][0]) : 0;
            x5 = Convert.ToString(ds.Tables[0].Rows[3][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[3][0]) : 0;
            x6 = Convert.ToString(ds.Tables[0].Rows[4][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[4][0]) : 0;
            x7 = Convert.ToString(ds.Tables[0].Rows[5][0]) != "" ? Convert.ToInt32(ds.Tables[0].Rows[5][0]) : 0;


            lblDay2.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
            lblDay3.Text = Convert.ToString(ds.Tables[0].Rows[1][0]);
            lblDay4.Text = Convert.ToString(ds.Tables[0].Rows[2][0]);
            lblDay5.Text = Convert.ToString(ds.Tables[0].Rows[3][0]);
            lblDay6.Text = Convert.ToString(ds.Tables[0].Rows[4][0]);
            lblCDay7.Text = Convert.ToString(ds.Tables[0].Rows[5][0]);


            lblDay1.Text = "0";
            lblCDay1.Text = lblDay1.Text;
            // lblCDay1.Text = lblDay1.Text;

            lblCDay2.Text = Convert.ToString(x2 + Convert.ToInt32(lblDay1.Text));
            lblCDay3.Text = Convert.ToString(x3 + Convert.ToInt32(lblCDay2.Text));
            lblCDay4.Text = Convert.ToString(x4 + Convert.ToInt32(lblCDay3.Text));
            lblCDay5.Text = Convert.ToString(x5 + Convert.ToInt32(lblCDay4.Text));
            lblCDay6.Text = Convert.ToString(x6 + Convert.ToInt32(lblCDay5.Text));
            lblCDay8.Text = Convert.ToString(Convert.ToInt32(lblDay3.Text) + Convert.ToInt32(lblDay4.Text) + +Convert.ToInt32(lblDay5.Text) + Convert.ToInt32(lblDay6.Text));

        }
    

        //}
    }

    private void bindCompanyInfo()
    {
        try
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
            ViewState["C_Year"] = dtCompanyInfo.Rows[0]["LatestFinancialYear"];
            ViewState["P1_Year"] = dtCompanyInfo.Rows[0]["P1_Year"];
            ViewState["P2_Year"] = dtCompanyInfo.Rows[0]["P2_Year"];
            ViewState["P3_Year"] = dtCompanyInfo.Rows[0]["P3_Year"];
            ViewState["RoundDollarType"] = dtCompanyInfo.Rows[0]["RoundDollarType"];
            ViewState["IsFinancialStmtAvailable"] = dtCompanyInfo.Rows[0]["IsFinancialStmtAvailable"];

            lblYearC.Text = dtCompanyInfo.Rows[0]["LatestFinancialYear"].ToString();
            lblYearP1.Text = dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            lblYearP2.Text = dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            lblYearP3.Text = dtCompanyInfo.Rows[0]["P3_Year"].ToString();

            lblYear1P1.Text = dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            lblYear1P2.Text = dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            lblYear1P3.Text = dtCompanyInfo.Rows[0]["P3_Year"].ToString();

        

            this.gvGrossProfit.Columns[1].HeaderText = "FY" + dtCompanyInfo.Rows[0]["LatestFinancialYear"] + "A";
            this.gvGrossProfit.Columns[2].HeaderText = "FY" + dtCompanyInfo.Rows[0]["P1_Year"] + "P";
            this.gvGrossProfit.Columns[3].HeaderText = "FY" + dtCompanyInfo.Rows[0]["P2_Year"] + "P";
            this.gvGrossProfit.Columns[4].HeaderText = "FY" + dtCompanyInfo.Rows[0]["P3_Year"] + "P";

            this.gvSalesProfitAnalysis.Columns[1].HeaderText = "Sales";
            this.gvSalesProfitAnalysis.Columns[2].HeaderText = "%";
            this.gvSalesProfitAnalysis.Columns[3].HeaderText = "Sales";
            this.gvSalesProfitAnalysis.Columns[4].HeaderText = "%";
            this.gvSalesProfitAnalysis.Columns[5].HeaderText = "Sales";
            this.gvSalesProfitAnalysis.Columns[6].HeaderText = "%";

            this.gvGPAnalysis.Columns[1].HeaderText = "Gross Profit";
            this.gvGPAnalysis.Columns[2].HeaderText = "GP%";
            this.gvGPAnalysis.Columns[3].HeaderText = "Gross Profit";
            this.gvGPAnalysis.Columns[4].HeaderText = "GP%";
            this.gvGPAnalysis.Columns[5].HeaderText = "Gross Profit";
            this.gvGPAnalysis.Columns[6].HeaderText = "GP%";

            //breakeven
            Label1.Text = dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            Label2.Text = dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            Label3.Text = dtCompanyInfo.Rows[0]["P3_Year"].ToString();

            //working capital
            Label4.Text = dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            Label5.Text = dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            Label6.Text = dtCompanyInfo.Rows[0]["P3_Year"].ToString();

            //cash flow 
            Label7.Text = dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            Label8.Text = dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            Label9.Text = dtCompanyInfo.Rows[0]["P3_Year"].ToString();

            //funding
            this.gvReport.Columns[0].HeaderText = "";
            this.gvReport.Columns[1].HeaderText = "FY" + dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            this.gvReport.Columns[2].HeaderText = "FY" + dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            this.gvReport.Columns[3].HeaderText = "FY" + dtCompanyInfo.Rows[0]["P3_Year"].ToString();

            //Trade cycle
            this.gvIncomeReport.Columns[1].HeaderText = "Actual <br />FY" + dtCompanyInfo.Rows[0]["LatestFinancialYear"].ToString();
            this.gvIncomeReport.Columns[3].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            this.gvIncomeReport.Columns[5].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            this.gvIncomeReport.Columns[7].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P3_Year"].ToString();

            this.gvBalanceReport.Columns[1].HeaderText = "Actual <br />FY" + dtCompanyInfo.Rows[0]["LatestFinancialYear"].ToString();
            this.gvBalanceReport.Columns[2].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            this.gvBalanceReport.Columns[3].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            this.gvBalanceReport.Columns[4].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P3_Year"].ToString();

            this.gvCashFlowAnalysisReport.Columns[1].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P1_Year"].ToString();
            this.gvCashFlowAnalysisReport.Columns[2].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P2_Year"].ToString();
            this.gvCashFlowAnalysisReport.Columns[3].HeaderText = "Estimates <br />FY" + dtCompanyInfo.Rows[0]["P3_Year"].ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private void bindFinancialHighlightsChart()
    {
        try
        {
            DataSet ds = bll.getFinancialPerfomance(Convert.ToString(ViewState["UserID"]));

            DataTable dtTemp = createTable(ds);

            FinancialChart.DataSource = dtTemp;
            DataView firstView = new DataView(dtTemp);
            FinancialChart.Series["EBITDA"].Points.DataBindXY(firstView, "Years", firstView, "EBITDA");
            FinancialChart.Series["GrossProfit"].Points.DataBindXY(firstView, "Years", firstView, "GrossProfit");
            FinancialChart.Series["Sales"].Points.DataBindXY(firstView, "Years", firstView, "Sales");


            formatSeries(FinancialChart, SeriesChartType.Column, "EBITDA", MarkerStyle.Circle);
            formatSeries(FinancialChart, SeriesChartType.Column, "GrossProfit", MarkerStyle.Circle);
            formatSeries(FinancialChart, SeriesChartType.Column, "Sales", MarkerStyle.Cross);


            if (Convert.ToString(ViewState["RoundDollarType"]) == "Dollars")
            {
                FinancialChart.ChartAreas[0].AxisY.Title = "Dollars";
            }
            else
            {
                FinancialChart.ChartAreas[0].AxisY.Title = "Thousands";
            }

            FinancialChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            FinancialChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    private void bindChartSegmentAnalysis()
    {
        try
        {
            DataSet ds = bll.getFinancialPerfomance(Convert.ToString(ViewState["UserID"]));

            DataTable dtTemp = createTable(ds);

            chartSegmentAnalysis.DataSource = dtTemp;
            DataView firstView = new DataView(dtTemp);
            chartSegmentAnalysis.Series["GrossProfit Margin (%)"].Points.DataBindXY(firstView, "Years", firstView, "GrossProfit Margin (%)");
            chartSegmentAnalysis.Series["EBITDA Margin (%)"].Points.DataBindXY(firstView, "Years", firstView, "EBITDA Margin (%)");


            formatSeries(chartSegmentAnalysis, SeriesChartType.Column, "EBITDA Margin (%)", MarkerStyle.Circle);
            formatSeries(chartSegmentAnalysis, SeriesChartType.Column, "GrossProfit Margin (%)", MarkerStyle.Circle);


            if (Convert.ToString(ViewState["RoundDollarType"]) == "Dollars")
            {
                chartSegmentAnalysis.ChartAreas[0].AxisY.Title = "Dollars";
            }
            else
            {
                chartSegmentAnalysis.ChartAreas[0].AxisY.Title = "Thousands";
            }
            chartSegmentAnalysis.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chartSegmentAnalysis.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void formatSeries(Chart finChart, SeriesChartType chartType, string strSeriesName, MarkerStyle seriesMarkerStyle)
    {
        try
        {

            finChart.Series[strSeriesName].ChartType = chartType;
            // FinancialChart.Series[strSeriesName].Color = seriesColor;

            if (chartType == SeriesChartType.Line)
            {
                //  FinancialChart.Series[strSeriesName].MarkerColor = seriesColor;
                finChart.Series[strSeriesName].MarkerStyle = seriesMarkerStyle;
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable createTable(DataSet ds)
    {
        DataTable dtTemp = new DataTable();
        try
        {

            DataColumn dcYears = new DataColumn("Years");
            DataColumn dcEBITDA = new DataColumn("EBITDA");
            DataColumn dcEBITDA_P = new DataColumn("EBITDA Margin (%)");
            DataColumn dcGrossProfit = new DataColumn("GrossProfit");
            DataColumn dcGrossProfit_P = new DataColumn("GrossProfit Margin (%)");
            DataColumn dcSales = new DataColumn("Sales");


            dtTemp.Columns.Add(dcYears);
            dtTemp.Columns.Add(dcEBITDA);
            dtTemp.Columns.Add(dcEBITDA_P);
            dtTemp.Columns.Add(dcGrossProfit);
            dtTemp.Columns.Add(dcGrossProfit_P);
            dtTemp.Columns.Add(dcSales);

            int i = 0;
            if (Convert.ToString(ViewState["IsFinancialStmtAvailable"]) == "0")
            {
                i = 1;
            }
            DataRow drMain = ds.Tables[0].Rows[0];
            if (i == 0)
            {
                DataRow dr1 = dtTemp.NewRow();
                dr1["Years"] = "FY" + Convert.ToString(ViewState["C_Year"]) + "A";
                dr1["EBITDA"] = drMain["C_Value"];
                dtTemp.Rows.Add(dr1);
            }

            DataRow dr2 = dtTemp.NewRow();
            dr2["Years"] = "FY" + Convert.ToString(ViewState["P1_Year"]) + "P";
            dr2["EBITDA"] = drMain["P1_Value"];
            dtTemp.Rows.Add(dr2);

            DataRow dr3 = dtTemp.NewRow();
            dr3["Years"] = "FY" + Convert.ToString(ViewState["P2_Year"]) + "P";
            dr3["EBITDA"] = drMain["P2_Value"];
            dtTemp.Rows.Add(dr3);

            DataRow dr4 = dtTemp.NewRow();
            dr4["Years"] = "FY" + Convert.ToString(ViewState["P3_Year"]) + "P";
            dr4["EBITDA"] = drMain["P3_Value"];
            dtTemp.Rows.Add(dr4);

            //Updating Gross Profit Margin
            DataRow drEBITDA_P = ds.Tables[0].Rows[1];

            dtTemp.Rows[1 - i]["EBITDA Margin (%)"] = drEBITDA_P["P1_Value"];
            dtTemp.Rows[2 - i]["EBITDA Margin (%)"] = drEBITDA_P["P2_Value"];
            dtTemp.Rows[3 - i]["EBITDA Margin (%)"] = drEBITDA_P["P3_Value"];

            //Updating NetProfitMargin
            DataRow drGrossProfit = ds.Tables[0].Rows[2];


            dtTemp.Rows[1 - i]["GrossProfit"] = drGrossProfit["P1_Value"];
            dtTemp.Rows[2 - i]["GrossProfit"] = drGrossProfit["P2_Value"];
            dtTemp.Rows[3 - i]["GrossProfit"] = drGrossProfit["P3_Value"];

            DataRow drGrossProfit_P = ds.Tables[0].Rows[3];

            dtTemp.Rows[1 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P1_Value"];
            dtTemp.Rows[2 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P2_Value"];
            dtTemp.Rows[3 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P3_Value"];


            DataRow drSales = ds.Tables[0].Rows[4];


            dtTemp.Rows[1 - i]["Sales"] = drSales["P1_Value"];
            dtTemp.Rows[2 - i]["Sales"] = drSales["P2_Value"];
            dtTemp.Rows[3 - i]["Sales"] = drSales["P3_Value"];
            if (i == 0)
            {
                dtTemp.Rows[0]["EBITDA Margin (%)"] = drEBITDA_P["C_Value"];
                dtTemp.Rows[0]["GrossProfit"] = drGrossProfit["C_Value"];
                dtTemp.Rows[0]["GrossProfit Margin (%)"] = drGrossProfit_P["C_Value"];
                dtTemp.Rows[0]["Sales"] = drSales["C_Value"];
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtTemp;
    }

    public void Binddata()
    {
        DataSet dsData = new DataSet();
        objFinModelingMgmt.UserID = ViewState["UserID"].ToString();

        objFinModelingMgmt.RoundDollar = Convert.ToInt32(Session["RoundDollar"]);
        dsData = objFinModelingMgmt.Get_FinTool_Report(objFinModelingMgmt);


        //Highlets values
        DataTable dtReportData = new DataTable();
        dtReportData = dsData.Tables[0];

        lblEBITDA.Text = dtReportData.Rows[2][0].ToString();
        lblEBITDAC.Text = dtReportData.Rows[2][5].ToString();
        lblEBITDAP1.Text = dtReportData.Rows[2][6].ToString();
        lblEBITDAP2.Text = dtReportData.Rows[2][7].ToString();
        lblEBITDAP3.Text = dtReportData.Rows[2][8].ToString();

        lblEBITDAPercentage.Text = dtReportData.Rows[1][0].ToString();
        lblEBITDAPercentageC.Text = dtReportData.Rows[1][5].ToString();
        lblEBITDAPercentageP1.Text = dtReportData.Rows[1][6].ToString();
        lblEBITDAPercentageP2.Text = dtReportData.Rows[1][7].ToString();
        lblEBITDAPercentageP3.Text = dtReportData.Rows[1][8].ToString();

        lblGrossProfit.Text = dtReportData.Rows[2][0].ToString();
        lblGrossProfitC.Text = dtReportData.Rows[2][1].ToString();
        lblGrossProfitP1.Text = dtReportData.Rows[2][2].ToString();
        lblGrossProfitP2.Text = dtReportData.Rows[2][3].ToString();
        lblGrossProfitP3.Text = dtReportData.Rows[2][4].ToString();

        lblGrossProfitPercentage.Text = dtReportData.Rows[1][0].ToString();
        lblGrossProfitPercentageC.Text = dtReportData.Rows[1][1].ToString();
        lblGrossProfitPercentageP1.Text = dtReportData.Rows[1][2].ToString();
        lblGrossProfitPercentageP2.Text = dtReportData.Rows[1][3].ToString();
        lblGrossProfitPercentageP3.Text = dtReportData.Rows[1][4].ToString();

        lblSales.Text = dtReportData.Rows[0][0].ToString();
        lblSalesC.Text = dtReportData.Rows[0][1].ToString();
        lblSalesP1.Text = dtReportData.Rows[0][2].ToString();
        lblSalesP2.Text = dtReportData.Rows[0][3].ToString();
        lblSalesP3.Text = dtReportData.Rows[0][4].ToString();

        DataTable dtGVData = new DataTable();
        dtGVData = dsData.Tables[1];

        gvGrossProfit.DataSource = dtGVData;
        gvGrossProfit.DataBind();

        if (Session["pastValue"] != null && Session["pastValue"] != "")
        {
            int pastValue = Convert.ToInt32(Session["pastValue"]);
            if (pastValue == 0)
            {
                gvGrossProfit.Columns[1].Visible = false;
            }
        }

        lblSales1Name.Text = dtReportData.Rows[0][0].ToString();
        lblSales1P1.Text = dtReportData.Rows[0][2].ToString();
        lblSales1P2.Text = dtReportData.Rows[0][3].ToString();
        lblSales1P3.Text = dtReportData.Rows[0][4].ToString();

        lblgp.Text = dtReportData.Rows[1][0].ToString();
        lblgpP1.Text = dtReportData.Rows[1][2].ToString();
        lblgpP2.Text = dtReportData.Rows[1][3].ToString();
        lblgpP3.Text = dtReportData.Rows[1][4].ToString();

        DataTable dtGVSalesProfitAnalysis = new DataTable();
        dtGVSalesProfitAnalysis = dsData.Tables[2];

        gvSalesProfitAnalysis.DataSource = dtGVSalesProfitAnalysis;
        gvSalesProfitAnalysis.DataBind();

        DataTable dtGVGPAnalysis = new DataTable();
        dtGVGPAnalysis = dsData.Tables[3];

        gvGPAnalysis.DataSource = dtGVGPAnalysis;
        gvGPAnalysis.DataBind();

        //Breakeven values
        DataTable dtData = new DataTable();
        dtData = dsData.Tables[4];
        lblCoverFixedExpensesP1.Text = dtData.Rows[0][2].ToString();
        lblCoverFixedExpensesP2.Text = dtData.Rows[0][3].ToString();
        lblCoverFixedExpensesP3.Text = dtData.Rows[0][4].ToString();

        lblCoverInterestsP1.Text = dtData.Rows[1][2].ToString();
        lblCoverInterestsP2.Text = dtData.Rows[1][3].ToString();
        lblCoverInterestsP3.Text = dtData.Rows[1][4].ToString();

        lblPrincipalPaymentsP1.Text = dtData.Rows[2][2].ToString();
        lblPrincipalPaymentsP2.Text = dtData.Rows[2][3].ToString();
        lblPrincipalPaymentsP3.Text = dtData.Rows[2][4].ToString();

        lblSaleSurplusP1.Text = dtData.Rows[3][2].ToString();
        lblSaleSurplusP2.Text = dtData.Rows[3][3].ToString();
        lblSaleSurplusP3.Text = dtData.Rows[3][4].ToString();

        lblTotalSalesP1.Text = dtData.Rows[4][2].ToString();
        lblTotalSalesP2.Text = dtData.Rows[4][3].ToString();
        lblTotalSalesP3.Text = dtData.Rows[4][4].ToString();

        lblbreakevenP1.Text = dtData.Rows[5][2].ToString();
        lblbreakevenP2.Text = dtData.Rows[5][2].ToString();
        lblbreakevenP3.Text = dtData.Rows[5][2].ToString();

        //working capital values
        DataTable dtDataWorking = new DataTable();
        dtDataWorking = dsData.Tables[5];
        lblAvgPaymentDaysP1.Text = dtDataWorking.Rows[0][1].ToString();

        lblWorkingCapitalDaysP1.Text = dtDataWorking.Rows[1][1].ToString();

        lblAvgStockHoldingDaysP2.Text = dtDataWorking.Rows[2][1].ToString();

        lblAvgCollectionDaysP2.Text = dtDataWorking.Rows[3][1].ToString();



        lblAvgPaymentDays1P1.Text = dtDataWorking.Rows[0][2].ToString();

        lblWorkingCapitalDays1P1.Text = dtDataWorking.Rows[1][2].ToString();

        lblAvgStockHoldingDays1P2.Text = dtDataWorking.Rows[2][2].ToString();

        lblAvgCollectionDays1P2.Text = dtDataWorking.Rows[3][2].ToString();

        DataTable dtDataWorking1 = new DataTable();
        dtDataWorking1 = dsData.Tables[6];

        lblFundingP1.Text = dtDataWorking1.Rows[0][2].ToString();
        lblFundingP2.Text = dtDataWorking1.Rows[0][3].ToString();
        lblFundingP3.Text = dtDataWorking1.Rows[0][4].ToString();

        lblResourcesStocksP1.Text = dtDataWorking1.Rows[1][2].ToString();
        lblResourcesStocksP2.Text = dtDataWorking1.Rows[1][3].ToString();
        lblResourcesStocksP3.Text = dtDataWorking1.Rows[1][4].ToString();

        lblResourcesReceivablesP1.Text = dtDataWorking1.Rows[2][2].ToString();
        lblResourcesReceivablesP2.Text = dtDataWorking1.Rows[2][3].ToString();
        lblResourcesReceivablesP3.Text = dtDataWorking1.Rows[2][4].ToString();

        lblWorkingCapitalP1.Text = dtDataWorking1.Rows[3][2].ToString();
        lblWorkingCapitalP2.Text = dtDataWorking1.Rows[3][3].ToString();
        lblWorkingCapitalP3.Text = dtDataWorking1.Rows[3][4].ToString();

        DataTable dtDataWorking2 = new DataTable();
        dtDataWorking2 = dsData.Tables[7];

        lblCapital1Days.Text = dtDataWorking2.Rows[0][0].ToString();
        lblCapital2Days.Text = dtDataWorking2.Rows[1][0].ToString();
        lblAverage1.Text = dtDataWorking2.Rows[2][0].ToString();
        lblAverage2.Text = dtDataWorking2.Rows[3][0].ToString();
        decimal decimallblAverage3 = (-Convert.ToDecimal(dtDataWorking2.Rows[4][0].ToString()));
        lblAverage3.Text = decimallblAverage3.ToString();

        decimal decimala = (-Convert.ToDecimal(dtDataWorking2.Rows[2][0].ToString()));
        lbla.Text = decimala.ToString();
        decimal decimalb = (-Convert.ToDecimal(dtDataWorking2.Rows[3][0].ToString()));
        lblb.Text = decimalb.ToString();
        decimal decimalc = (-Convert.ToDecimal(dtDataWorking2.Rows[4][0].ToString()));
        lblc.Text = decimalc.ToString();

        lblABCTotal.Text = (decimala + decimalb + decimalc).ToString();

       //cash flow values
        DataTable dtData1 = new DataTable();
        dtData1 = dsData.Tables[8];

        DataTable dtData2 = new DataTable();
        dtData2 = dsData.Tables[9];

        lblOperatingActivitiesP1.Text = dtData2.Rows[0][1].ToString();
        lblOperatingActivitiesP2.Text = dtData2.Rows[0][2].ToString();
        lblOperatingActivitiesP3.Text = dtData2.Rows[0][3].ToString();

        lblInvestingActivitiesP1.Text = dtData1.Rows[8][1].ToString();
        lblInvestingActivitiesP2.Text = dtData1.Rows[8][2].ToString();
        lblInvestingActivitiesP3.Text = dtData1.Rows[8][3].ToString();

        lblplannedP1.Text = dtData1.Rows[0][1].ToString();
        lblplannedP2.Text = dtData1.Rows[0][2].ToString();
        lblplannedP3.Text = dtData1.Rows[0][3].ToString();

        lblOfWhichP1.Text = dtData1.Rows[1][1].ToString();
        lblOfWhichP2.Text = dtData1.Rows[1][2].ToString();
        lblOfWhichP3.Text = dtData1.Rows[1][3].ToString();

        lblBalanceP1.Text = dtData1.Rows[2][1].ToString();
        lblBalanceP2.Text = dtData1.Rows[2][2].ToString();
        lblBalanceP3.Text = dtData1.Rows[2][3].ToString();

        lblExistingP1.Text = dtData1.Rows[3][1].ToString();
        lblExistingP2.Text = dtData1.Rows[3][2].ToString();
        lblExistingP3.Text = dtData1.Rows[3][3].ToString();

        lblNewP1.Text = dtData1.Rows[4][1].ToString();
        lblNewP2.Text = dtData1.Rows[4][2].ToString();
        lblNewP3.Text = dtData1.Rows[4][3].ToString();

        lblInterestsP1.Text = dtData1.Rows[5][1].ToString();
        lblInterestsP2.Text = dtData1.Rows[5][2].ToString();
        lblInterestsP3.Text = dtData1.Rows[5][3].ToString();

        lblTotalloanP1.Text = dtData1.Rows[6][1].ToString();
        lblTotalloanP2.Text = dtData1.Rows[6][2].ToString();
        lblTotalloanP3.Text = dtData1.Rows[6][3].ToString();

        lblRaiseNewP1.Text = dtData1.Rows[7][1].ToString();
        lblRaiseNewP2.Text = dtData1.Rows[7][2].ToString();
        lblRaiseNewP3.Text = dtData1.Rows[7][3].ToString();

        lblTotalcashP1.Text = dtData1.Rows[8][1].ToString();
        lblTotalcashP2.Text = dtData1.Rows[8][2].ToString();
        lblTotalcashP3.Text = dtData1.Rows[8][3].ToString();

        lblNetCashP1.Text = dtData2.Rows[3][1].ToString();
        lblNetCashP2.Text = dtData2.Rows[3][2].ToString();
        lblNetCashP3.Text = dtData2.Rows[3][3].ToString();

        lblCashBalanceP1.Text = dtData2.Rows[6][1].ToString();
        lblCashBalanceP2.Text = dtData2.Rows[6][2].ToString();
        lblCashBalanceP3.Text = dtData2.Rows[6][3].ToString();

        lblCashBalP1.Text = dtData2.Rows[4][1].ToString();
        lblCashBalP2.Text = dtData2.Rows[4][2].ToString();
        lblCashBalP3.Text = dtData2.Rows[4][3].ToString();

        lblTotelNetCashP1.Text = dtData2.Rows[5][1].ToString();
        lblTotelNetCashP2.Text = dtData2.Rows[5][2].ToString();
        lblTotelNetCashP3.Text = dtData2.Rows[5][3].ToString();

        lblCashBal1P1.Text = dtData2.Rows[7][1].ToString();
        lblCashBal1P2.Text = dtData2.Rows[7][2].ToString();
        lblCashBal1P3.Text = dtData2.Rows[7][3].ToString();

        lblHeadroomSurplusP1.Text = dtData2.Rows[2][1].ToString();
        lblHeadroomSurplusP2.Text = dtData2.Rows[2][2].ToString();
        lblHeadroomSurplusP3.Text = dtData2.Rows[2][3].ToString();

        lblCashBalance1P1.Text = dtData2.Rows[7][1].ToString();
        lblCashBalance1P2.Text = dtData2.Rows[7][2].ToString();
        lblCashBalance1P3.Text = dtData2.Rows[7][3].ToString();

        lblUnutilisedP1.Text = dtData2.Rows[8][1].ToString();
        lblUnutilisedP2.Text = dtData2.Rows[8][2].ToString();
        lblUnutilisedP3.Text = dtData2.Rows[8][3].ToString();

        lblRestrictedP1.Text = dtData2.Rows[1][1].ToString();
        lblRestrictedP2.Text = dtData2.Rows[1][2].ToString();
        lblRestrictedP3.Text = dtData2.Rows[1][3].ToString();

        lblHeadroomP1.Text = dtData2.Rows[2][1].ToString();
        lblHeadroomP2.Text = dtData2.Rows[2][2].ToString();
        lblHeadroomP3.Text = dtData2.Rows[2][3].ToString();

        //funding
        gvReport.DataSource = dsData.Tables[10];
        gvReport.DataBind();

        //Trade cycle
        gvIncomeReport.DataSource = dsData.Tables[11];
        gvIncomeReport.DataBind();
        gvBalanceReport.DataSource = dsData.Tables[12];
        gvBalanceReport.DataBind();
        gvCashFlowAnalysisReport.DataSource = dsData.Tables[13];
        gvCashFlowAnalysisReport.DataBind();
    }

    public void BindClientIds()
    {
        strLblClientIds = strLblClientIds + "," + lblGrossProfitC.ClientID + "," + lblGrossProfitP1.ClientID + "," + lblGrossProfitP2.ClientID + "," + lblGrossProfitP3.ClientID + "," + lblGrossProfitPercentageC.ClientID + "," + lblGrossProfitPercentageP1.ClientID + "," + lblGrossProfitPercentageP2.ClientID + "," + lblGrossProfitPercentageP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblSalesC.ClientID + "," + lblSalesP1.ClientID + "," + lblSalesP2.ClientID + "," + lblSalesP3.ClientID + "," + lblSales1P1.ClientID + "," + lblSales1P2.ClientID + "," + lblSales1P3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblgpP1.ClientID + "," + lblgpP2.ClientID + "," + lblgpP3.ClientID;
       //breakeven
        strLblClientIds = strLblClientIds + "," + lblPrincipalPaymentsP1.ClientID + "," + lblPrincipalPaymentsP2.ClientID + "," + lblPrincipalPaymentsP3.ClientID + "," + lblSaleSurplusP1.ClientID + "," + lblSaleSurplusP2.ClientID + "," + lblSaleSurplusP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotalSalesP1.ClientID + "," + lblTotalSalesP2.ClientID + "," + lblTotalSalesP3.ClientID + "," + lblbreakevenP1.ClientID + "," + lblbreakevenP2.ClientID + "," + lblbreakevenP3.ClientID;
       //working capital 
        strLblClientIds = strLblClientIds + "," + lblFundingP1.ClientID + "," + lblFundingP2.ClientID + "," + lblFundingP3.ClientID + "," + lblResourcesStocksP1.ClientID + "," + lblResourcesStocksP2.ClientID + "," + lblResourcesStocksP3.ClientID + "," + lbla.ClientID + "," + lblb.ClientID + "," + lblc.ClientID + "," + lblABCTotal.ClientID;
        strLblClientIds = strLblClientIds + "," + lblResourcesReceivablesP1.ClientID + "," + lblResourcesReceivablesP2.ClientID + "," + lblResourcesReceivablesP3.ClientID + "," + lblWorkingCapitalP1.ClientID + "," + lblWorkingCapitalP2.ClientID + "," + lblWorkingCapitalP3.ClientID;
        //cash flow
        strLblClientIds = strLblClientIds + "," + lblOperatingActivitiesP1.ClientID + "," + lblOperatingActivitiesP2.ClientID + "," + lblOperatingActivitiesP3.ClientID + "," + lblInvestingActivitiesP1.ClientID + "," + lblInvestingActivitiesP2.ClientID + "," + lblInvestingActivitiesP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblplannedP1.ClientID + "," + lblplannedP2.ClientID + "," + lblplannedP3.ClientID + "," + lblOfWhichP1.ClientID + "," + lblOfWhichP2.ClientID + "," + lblOfWhichP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblBalanceP1.ClientID + "," + lblBalanceP2.ClientID + "," + lblBalanceP3.ClientID + "," + lblExistingP1.ClientID + "," + lblExistingP2.ClientID + "," + lblExistingP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblNewP1.ClientID + "," + lblNewP2.ClientID + "," + lblNewP3.ClientID + "," + lblInterestsP1.ClientID + "," + lblInterestsP2.ClientID + "," + lblInterestsP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotalloanP1.ClientID + "," + lblTotalloanP2.ClientID + "," + lblTotalloanP3.ClientID + "," + lblRaiseNewP1.ClientID + "," + lblRaiseNewP2.ClientID + "," + lblRaiseNewP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotalcashP1.ClientID + "," + lblTotalcashP2.ClientID + "," + lblTotalcashP3.ClientID + "," + lblNetCashP1.ClientID + "," + lblNetCashP2.ClientID + "," + lblNetCashP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblCashBalanceP1.ClientID + "," + lblCashBalanceP2.ClientID + "," + lblCashBalanceP3.ClientID + "," + lblCashBalP1.ClientID + "," + lblCashBalP2.ClientID + "," + lblCashBalP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotelNetCashP1.ClientID + "," + lblTotelNetCashP2.ClientID + "," + lblTotelNetCashP3.ClientID + "," + lblCashBal1P1.ClientID + "," + lblCashBal1P2.ClientID + "," + lblCashBal1P3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblHeadroomSurplusP1.ClientID + "," + lblHeadroomSurplusP2.ClientID + "," + lblHeadroomSurplusP3.ClientID + "," + lblCashBalance1P1.ClientID + "," + lblCashBalance1P2.ClientID + "," + lblCashBalance1P3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblUnutilisedP1.ClientID + "," + lblUnutilisedP2.ClientID + "," + lblUnutilisedP3.ClientID + "," + lblRestrictedP1.ClientID + "," + lblRestrictedP2.ClientID + "," + lblRestrictedP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblHeadroomP1.ClientID + "," + lblHeadroomP2.ClientID + "," + lblHeadroomP3.ClientID;

    }
    #region cc1
    private void bindChart_CC1()
    {
        try
        {

            string fsmappingids = "73,74,75,76";// "73,74,75,76";
            string userid = Convert.ToString(ViewState["UserID"]);
            DataSet ds = bll.getReport_workingcapital(fsmappingids, userid);

            DataTable dtTemp = createTable_CC1(ds);

            CashConversion1_Chart.DataSource = dtTemp;
            DataView firstView = new DataView(dtTemp);
            CashConversion1_Chart.Series["Avg Payment Days"].Points.DataBindXY(firstView, "CycleName", firstView, "Col3");
            CashConversion1_Chart.Series["Working Capital Days"].Points.DataBindXY(firstView, "CycleName", firstView, "Col4");
            CashConversion1_Chart.Series["Avg Stock Holdings Days"].Points.DataBindXY(firstView, "CycleName", firstView, "Col1");
            CashConversion1_Chart.Series["Avg Collection Days"].Points.DataBindXY(firstView, "CycleName", firstView, "Col2");

            formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, "Avg Payment Days", MarkerStyle.Circle);
            formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, "Working Capital Days", MarkerStyle.Circle);

            formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, "Avg Stock Holdings Days", MarkerStyle.Circle);
            formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, "Avg Collection Days", MarkerStyle.Circle);


            //This helps in making 2 series merged inot single column. For this column type need be StackedColumn
            CashConversion1_Chart.Series["Avg Stock Holdings Days"]["StackedGroupName"] = "Group1";
            CashConversion1_Chart.Series["Avg Collection Days"]["StackedGroupName"] = "Group1";
            CashConversion1_Chart.Series["Avg Payment Days"]["StackedGroupName"] = "Group2";
            CashConversion1_Chart.Series["Working Capital Days"]["StackedGroupName"] = "Group2";


            CashConversion1_Chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            CashConversion1_Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            //BindLabels();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void formatSeries_CC1(Chart CashConversion1_Chart, SeriesChartType chartType, string strSeriesName, MarkerStyle seriesMarkerStyle)
    {
        try
        {

            CashConversion1_Chart.Series[strSeriesName].ChartType = chartType;
            // CashConversion1_Chart.Series[strSeriesName].Color = seriesColor;

            if (chartType == SeriesChartType.Line)
            {
                // CashConversion1_Chart.Series[strSeriesName].MarkerColor = seriesColor;
                CashConversion1_Chart.Series[strSeriesName].MarkerStyle = seriesMarkerStyle;
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable createTable_CC1(DataSet ds)
    {
        DataTable dtTemp = new DataTable();
        try
        {

            DataColumn dcCycleName = new DataColumn("CycleName");
            DataColumn dcCol1 = new DataColumn("Col1");
            DataColumn dcCol2 = new DataColumn("Col2");
            DataColumn dcCol3 = new DataColumn("Col3");
            DataColumn dcCol4 = new DataColumn("Col4");
            DataRow drMain;
            dtTemp.Columns.Add(dcCycleName);
            dtTemp.Columns.Add(dcCol1);
            dtTemp.Columns.Add(dcCol2);
            dtTemp.Columns.Add(dcCol3);
            dtTemp.Columns.Add(dcCol4);

            DataRow dr2 = dtTemp.NewRow();
            drMain = ds.Tables[0].Rows[0];
            dr2["CycleName"] = "Period of financing";
            dr2["Col3"] = drMain["C_Value"];
            drMain = ds.Tables[0].Rows[1];
            dr2["Col4"] = drMain["C_Value"];
            dtTemp.Rows.Add(dr2);

            drMain = ds.Tables[0].Rows[2];

            DataRow dr1 = dtTemp.NewRow();
            dr1["CycleName"] = "Your Resources tied in";
            dr1["Col1"] = drMain["C_Value"];
            drMain = ds.Tables[0].Rows[3];
            dr1["Col2"] = drMain["C_Value"];
            dtTemp.Rows.Add(dr1);



        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtTemp;
    }


    private void BindLabels()
    {
        int intTemp = 0;
        foreach (DataPoint ptRevenue in CashConversion1_Chart.Series["Your Resources tied in"].Points)
        {

            intTemp++;
            if (intTemp == 2)
            {
                //ptRevenue.Color = Color.Transparent;

                ptRevenue.Label = "test1</br>35";

            }
            if (intTemp == 4)
            {
                ptRevenue.Color = Color.Transparent;
                ptRevenue.Label = "test2";
            }

        }
    }

    #endregion cc1
    #region cc2
    private void bindChart_CC2()
    {
        try
        {
            string fsmappingids = "73,74,75,76";// "73,74,75,76";
            string userid = Convert.ToString(ViewState["UserID"]);
            DataSet ds = bll.getReport(fsmappingids, userid);

            DataTable dtTemp = createTable_CC2(ds);

            CashConversion2_Chart.DataSource = dtTemp;

            DataView firstView = new DataView(dtTemp);
            CashConversion2_Chart.Series["Avg Payment Days"].Points.DataBindXY(firstView, "CycleName", firstView, "Col3");
            CashConversion2_Chart.Series["Working Capital Days"].Points.DataBindXY(firstView, "CycleName", firstView, "Col4");
            CashConversion2_Chart.Series["Avg Stock Holdings Days"].Points.DataBindXY(firstView, "CycleName", firstView, "Col1");
            CashConversion2_Chart.Series["Avg Collection Days"].Points.DataBindXY(firstView, "CycleName", firstView, "Col2");



            formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, "Avg Payment Days", MarkerStyle.Circle);
            formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, "Working Capital Days", MarkerStyle.Circle);

            formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, "Avg Stock Holdings Days", MarkerStyle.Circle);
            formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, "Avg Collection Days", MarkerStyle.Circle);


            //This helps in making 2 series merged inot single column. For this column type need be StackedColumn
            CashConversion2_Chart.Series["Avg Payment Days"]["StackedGroupName"] = "Group2";
            CashConversion2_Chart.Series["Working Capital Days"]["StackedGroupName"] = "Group2";
            CashConversion2_Chart.Series["Avg Stock Holdings Days"]["StackedGroupName"] = "Group1";
            CashConversion2_Chart.Series["Avg Collection Days"]["StackedGroupName"] = "Group1";


            CashConversion2_Chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            CashConversion2_Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void formatSeries_CC2(Chart CashConversion2_Chart, SeriesChartType chartType, string strSeriesName, MarkerStyle seriesMarkerStyle)
    {
        try
        {

            CashConversion2_Chart.Series[strSeriesName].ChartType = chartType;
            // CashConversion2_Chart.Series[strSeriesName].Color = seriesColor;

            if (chartType == SeriesChartType.Line)
            {
                //  CashConversion2_Chart.Series[strSeriesName].MarkerColor = seriesColor;
                CashConversion2_Chart.Series[strSeriesName].MarkerStyle = seriesMarkerStyle;
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable createTable_CC2(DataSet ds)
    {
        DataTable dtTemp = new DataTable();
        try
        {


            DataColumn dcCycleName = new DataColumn("CycleName");
            DataColumn dcCol1 = new DataColumn("Col1");
            DataColumn dcCol2 = new DataColumn("Col2");
            DataColumn dcCol3 = new DataColumn("Col3");
            DataColumn dcCol4 = new DataColumn("Col4");
            DataRow drMain;
            dtTemp.Columns.Add(dcCycleName);
            dtTemp.Columns.Add(dcCol1);
            dtTemp.Columns.Add(dcCol2);
            dtTemp.Columns.Add(dcCol3);
            dtTemp.Columns.Add(dcCol4);



            DataRow dr2 = dtTemp.NewRow();
            drMain = ds.Tables[0].Rows[0];
            dr2["CycleName"] = "Period of financing";
            dr2["Col3"] = drMain["P1_Value"];
            drMain = ds.Tables[0].Rows[1];
            dr2["Col4"] = drMain["P1_Value"];
            dtTemp.Rows.Add(dr2);

            drMain = ds.Tables[0].Rows[2];

            DataRow dr1 = dtTemp.NewRow();
            dr1["CycleName"] = "Your Resources tied in";
            dr1["Col1"] = drMain["P1_Value"];
            drMain = ds.Tables[0].Rows[3];
            dr1["Col2"] = drMain["P1_Value"];
            dtTemp.Rows.Add(dr1);



        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtTemp;
    }


    #endregion cc2
    protected void gvGPAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            if (strLblClientIds == "")
            {
                strLblClientIds = lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            else
            {
                strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }

            if (e.Row.RowIndex == 4)
            {
                e.Row.Cells[1].ForeColor = Color.Red;
                e.Row.Cells[3].ForeColor = Color.Red;
                e.Row.Cells[5].ForeColor = Color.Red;


            }
            if (e.Row.RowIndex == 5)
            {
                e.Row.BackColor = Color.FromName("#ccecff");
                e.Row.Font.Bold = true;

            }
        }
    }
    protected void gvSalesProfitAnalysis_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow =
            new GridViewRow(0, 0, DataControlRowType.Header,
            DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 1;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "FY" + ViewState["P1_Year"].ToString() + "P";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.Font.Bold = true;
            HeaderCell.Attributes.Add("align", "right");
            HeaderGridRow.Cells.Add(HeaderCell);



            HeaderCell = new TableCell();
            HeaderCell.Text = "FY" + ViewState["P2_Year"].ToString() + "P";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.Font.Bold = true;
            HeaderCell.Attributes.Add("align", "right");
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "FY" + ViewState["P3_Year"].ToString() + "P";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.Font.Bold = true;
            HeaderCell.Attributes.Add("align", "right");
            HeaderGridRow.Cells.Add(HeaderCell);

            gvSalesProfitAnalysis.Controls[0].Controls.AddAt
            (0, HeaderGridRow);
        }

    }
    protected void gvSalesProfitAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            if (strLblClientIds == "")
            {
                strLblClientIds = lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            else
            {
                strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }

            if (e.Row.RowIndex == 3)
            {
                e.Row.BackColor = Color.FromName("#ccecff");
                e.Row.Font.Bold = true;
                e.Row.Cells[0].Text = "";
            }

        }
    }
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            if (strLblClientIds == "")
            {
                strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            else
            {
                strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }

        }
        if (e.Row.RowIndex == 2)
        {
            e.Row.Font.Bold = true;
            e.Row.Cells[1].CssClass = "tdtop";
            e.Row.Cells[2].CssClass = "tdtop";
            e.Row.Cells[3].CssClass = "tdtop";

        }
        if (e.Row.RowIndex == 5)
        {
            e.Row.Font.Bold = true;
            e.Row.Cells[1].CssClass = "tdtop";
            e.Row.Cells[2].CssClass = "tdtop";
            e.Row.Cells[3].CssClass = "tdtop";

        }
        if (e.Row.RowIndex == 6)
        {
            if (e.Row.Cells[3].Text == "")
            {
                e.Row.Cells[3].Text = "Nil";
                e.Row.Font.Bold = true;
                e.Row.ForeColor = System.Drawing.Color.Blue;
                strLblClientIds = strLblClientIds.Substring(0, strLblClientIds.Length - 28);
            }


        }

    }
    protected void gvIncomeReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblc = (Label)e.Row.FindControl("lbl_C_Value");
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            if (strLblClientIds == "")
            {
                strLblClientIds = strLblClientIds + "," + lblc.ClientID + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            else
            {
                strLblClientIds = strLblClientIds + "," + lblc.ClientID + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
        }

    }
    protected void gvBalanceReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblc = (Label)e.Row.FindControl("lbl_C_Value");
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            if (strLblClientIds == "")
            {
                strLblClientIds = strLblClientIds + "," + lblc.ClientID + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            else
            {
                strLblClientIds = strLblClientIds + "," + lblc.ClientID + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
        }
    }
    protected void gvCashFlowAnalysisReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            if (strLblClientIds == "")
            {
                strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            else
            {
                strLblClientIds = strLblClientIds + "," +  lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
        }
    }
  
}
