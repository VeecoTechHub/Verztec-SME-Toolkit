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

public partial class UserControls_Hightlights : System.Web.UI.UserControl
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    Report_BLL bll = new Report_BLL();
    public static string strLblClientIds = string.Empty;
    public int count = 0;

    public string resChartTitle = string.Empty;
    public string resChartTitle1 = string.Empty;
    public string resSales = string.Empty;
    public string resGrossProfit = string.Empty;
    public string resEBITDA = string.Empty;
    public string resSales1 = string.Empty;
    public string resGrossProfit1 = string.Empty;

    public string lblFYLoclResText = string.Empty;
    public string lblPLoclResText = string.Empty;
    public string lblALoclResText = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["UserId"] != null)
        {
            ViewState["UserID"] = Convert.ToString(Request.QueryString["UserId"]);
        }

        else if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
        }

        lblFYLoclResText = Convert.ToString(GetLocalResourceObject("lblfyResource1.Text"));
        lblPLoclResText = Convert.ToString(GetLocalResourceObject("lblpResource1.Text"));
        lblALoclResText = Convert.ToString(GetLocalResourceObject("lblAResource1.Text"));


        strLblClientIds = string.Empty;
        bindCompanyInfo();
        Binddata();
        bindFinancialHighlightsChart();
        bindChartSegmentAnalysis();
        if (count > 1)
        {
            BindClientIds();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "FormatCells", "formatCellsWithComma('" + strLblClientIds + "');", true);
        }

    }

    private void bindCompanyInfo()
    {
        try
        {
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
                ViewState["C_Year"] = dtCompanyInfo.Rows[0]["LatestFinancialYear"];
                ViewState["P1_Year"] = dtCompanyInfo.Rows[0]["P1_Year"];
                ViewState["P2_Year"] = dtCompanyInfo.Rows[0]["P2_Year"];
                ViewState["P3_Year"] = dtCompanyInfo.Rows[0]["P3_Year"];
                ViewState["RoundDollar"] = dtCompanyInfo.Rows[0]["RoundDollar"];
                ViewState["IsFinancialStmtAvailable"] = dtCompanyInfo.Rows[0]["IsFinancialStmtAvailable"];

                lblYearC.Text = dtCompanyInfo.Rows[0]["LatestFinancialYear"].ToString();
                lblYearP1.Text = dtCompanyInfo.Rows[0]["P1_Year"].ToString();
                lblYearP2.Text = dtCompanyInfo.Rows[0]["P2_Year"].ToString();
                lblYearP3.Text = dtCompanyInfo.Rows[0]["P3_Year"].ToString();

                lblYear1P1.Text = dtCompanyInfo.Rows[0]["P1_Year"].ToString();
                lblYear1P2.Text = dtCompanyInfo.Rows[0]["P2_Year"].ToString();
                lblYear1P3.Text = dtCompanyInfo.Rows[0]["P3_Year"].ToString();

                if (ViewState["IsFinancialStmtAvailable"].ToString() != null && ViewState["IsFinancialStmtAvailable"].ToString() != "")
                {
                    int pastValue = Convert.ToInt32(ViewState["IsFinancialStmtAvailable"]);
                    if (pastValue == 0)
                        this.gvGrossProfit.Columns[1].HeaderText = "";
                    else
                        this.gvGrossProfit.Columns[1].HeaderText = "<span align='right'>" + lblFYLoclResText + dtCompanyInfo.Rows[0]["LatestFinancialYear"] + "</span><br/><span align='center'>" + lblALoclResText + "</span>";
                }

                this.gvGrossProfit.Columns[2].HeaderText = "<span align='right'>" + lblFYLoclResText + dtCompanyInfo.Rows[0]["P1_Year"] + "</span><br/><span align='center'>" + lblPLoclResText + "</span>";
                this.gvGrossProfit.Columns[3].HeaderText = "<span align='right'>" + lblFYLoclResText + dtCompanyInfo.Rows[0]["P2_Year"] + "</span><br/><span align='center'>" + lblPLoclResText + "</span>";
                this.gvGrossProfit.Columns[4].HeaderText = "<span align='right'>" + lblFYLoclResText + dtCompanyInfo.Rows[0]["P3_Year"] + "</span><br/><span align='center'>" + lblPLoclResText + "</span>";

                //this.gvSalesProfitAnalysis.Columns[1].HeaderText = "Sales";
                //this.gvSalesProfitAnalysis.Columns[2].HeaderText = "%";
                //this.gvSalesProfitAnalysis.Columns[3].HeaderText = "Sales";
                //this.gvSalesProfitAnalysis.Columns[4].HeaderText = "%";
                //this.gvSalesProfitAnalysis.Columns[5].HeaderText = "Sales";
                //this.gvSalesProfitAnalysis.Columns[6].HeaderText = "%";

                //this.gvGPAnalysis.Columns[1].HeaderText = "Gross Profit";
                //this.gvGPAnalysis.Columns[2].HeaderText = "GP%";
                //this.gvGPAnalysis.Columns[3].HeaderText = "Gross Profit";
                //this.gvGPAnalysis.Columns[4].HeaderText = "GP%";
                //this.gvGPAnalysis.Columns[5].HeaderText = "Gross Profit";
                //this.gvGPAnalysis.Columns[6].HeaderText = "GP%";
            }

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
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {

                resChartTitle = Convert.ToString(GetLocalResourceObject("lblChartTitleResource1.Text"));
                resSales = Convert.ToString(GetLocalResourceObject("lblColumn1Resource1.Text"));
                resGrossProfit = Convert.ToString(GetLocalResourceObject("lblColumn2Resource1.Text"));
                resEBITDA = Convert.ToString(GetLocalResourceObject("lblColumn3Resource1.Text"));

                DataSet ds = bll.getFinancialPerfomance(Convert.ToString(ViewState["UserID"]));

                DataTable dtTemp = createTable(ds);

                FinancialChart.DataSource = dtTemp;
                DataView firstView = new DataView(dtTemp);

                FinancialChart.Titles[0].Text = resChartTitle;

                FinancialChart.Series[0].Name = resSales;
                FinancialChart.Series[1].Name = resGrossProfit;
                FinancialChart.Series[2].Name = resEBITDA;

                FinancialChart.Series[resEBITDA].Points.DataBindXY(firstView, "Years", firstView, resEBITDA);
                FinancialChart.Series[resGrossProfit].Points.DataBindXY(firstView, "Years", firstView, resGrossProfit);
                FinancialChart.Series[resSales].Points.DataBindXY(firstView, "Years", firstView, resSales);


                formatSeries(FinancialChart, SeriesChartType.Column, resEBITDA, MarkerStyle.Circle);
                formatSeries(FinancialChart, SeriesChartType.Column, resGrossProfit, MarkerStyle.Circle);
                formatSeries(FinancialChart, SeriesChartType.Column, resSales, MarkerStyle.Cross);


                if (Convert.ToString(ViewState["RoundDollar"]) == "1")
                {
                    FinancialChart.ChartAreas[0].AxisY.Title = Convert.ToString(GetLocalResourceObject("lblAxisTitle1Resource1.Text"));
                }
                else
                {
                    FinancialChart.ChartAreas[0].AxisY.Title = Convert.ToString(GetLocalResourceObject("lblAxisTitle2Resource1.Text"));
                }

                //FinancialChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
                //FinancialChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;



                DataSet dsSegment = objFinModelingMgmt.getDataBySection(1);
                DataTable dtFsMapping = dsSegment.Tables[0];
                if (dtFsMapping.Rows.Count > 0)
                {
                    string[] pvalue = new string[3];
                    //int count = 0;
                    DataRow drTradingGoods = getFsMappingValue(dtFsMapping, 33);
                    pvalue[0] = drTradingGoods["P1_Value"].ToString();
                    DataRow drManufacturingSale = getFsMappingValue(dtFsMapping, 34);
                    pvalue[1] = drManufacturingSale["P1_Value"].ToString();
                    DataRow drServices = getFsMappingValue(dtFsMapping, 35);
                    pvalue[2] = drServices["P1_Value"].ToString();
                    for (int i = 0; i < pvalue.Length; i++)
                    {
                        if (pvalue[i] != string.Empty)
                            count = count + 1;
                    }
                    if (count < 2)
                    {

                        trSegmentAnalysis.Visible = false;
                        trfollowinggraph.Visible = false;
                        trSpace.Visible = false;
                        idSegment.Visible = false;
                    }

                }
                FinancialChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                FinancialChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
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


    private void bindChartSegmentAnalysis()
    {
        try
        {
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                resChartTitle1 = Convert.ToString(GetLocalResourceObject("lblChartTitle1Resource1.Text"));
                resSales1 = Convert.ToString(GetLocalResourceObject("lblColumn4Resource1.Text"));
                resGrossProfit1 = Convert.ToString(GetLocalResourceObject("lblColumn5Resource1.Text"));

                DataSet ds = bll.getFinancialPerfomance(Convert.ToString(ViewState["UserID"]));

                DataTable dtTemp = createTableSegmentAnalysis(ds);

                chartSegmentAnalysis.DataSource = dtTemp;
                DataView firstView = new DataView(dtTemp);

              

                chartSegmentAnalysis.Titles[0].Text = resChartTitle1;
                //chartSegmentAnalysis.Series["EBITDA"].Points.DataBindXY(firstView, "Years", firstView, "EBITDA");

                chartSegmentAnalysis.Series[0].Name = resSales1;
                chartSegmentAnalysis.Series[1].Name = resGrossProfit1;

                chartSegmentAnalysis.Series[resGrossProfit1].Points.DataBindXY(firstView, "Years", firstView, resGrossProfit1);
                chartSegmentAnalysis.Series[resSales1].Points.DataBindXY(firstView, "Years", firstView, resSales1);


                //  formatSeries(chartSegmentAnalysis, SeriesChartType.Column, "EBITDA", MarkerStyle.Circle);
                formatSeries(chartSegmentAnalysis, SeriesChartType.Column, resGrossProfit1, MarkerStyle.Circle);
                formatSeries(chartSegmentAnalysis, SeriesChartType.Column, resSales1, MarkerStyle.Cross);


                if (Convert.ToString(ViewState["RoundDollar"]) == "1")
                {
                    chartSegmentAnalysis.ChartAreas[0].AxisY.Title = Convert.ToString(GetLocalResourceObject("lblAxisTitle1Resource1.Text"));
                }
                else
                {
                    chartSegmentAnalysis.ChartAreas[0].AxisY.Title = Convert.ToString(GetLocalResourceObject("lblAxisTitle2Resource1.Text"));
                }

                //FinancialChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
                //FinancialChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartSegmentAnalysis.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chartSegmentAnalysis.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            }

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
            foreach (DataPoint ptChart in finChart.Series[strSeriesName].Points)
            {
                ptChart.LabelFormat = "{0,0}";
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
            DataColumn dcEBITDA = new DataColumn(resEBITDA);
            DataColumn dcEBITDA_P = new DataColumn("EBITDA Margin (%)");
            DataColumn dcGrossProfit = new DataColumn(resGrossProfit);
            DataColumn dcGrossProfit_P = new DataColumn("GrossProfit Margin (%)");
            DataColumn dcSales = new DataColumn(resSales);


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
                dr1["Years"] = lblFYLoclResText + Convert.ToString(ViewState["C_Year"]) + lblALoclResText;
                dr1[resEBITDA] = drMain["C_Value"];
                dtTemp.Rows.Add(dr1);
            }

            DataRow dr2 = dtTemp.NewRow();
            dr2["Years"] = lblFYLoclResText + Convert.ToString(ViewState["P1_Year"]) + lblPLoclResText;
            dr2[resEBITDA] = drMain["P1_Value"];
            dtTemp.Rows.Add(dr2);

            DataRow dr3 = dtTemp.NewRow();
            dr3["Years"] = lblFYLoclResText + Convert.ToString(ViewState["P2_Year"]) + lblPLoclResText;
            dr3[resEBITDA] = drMain["P2_Value"];
            dtTemp.Rows.Add(dr3);

            DataRow dr4 = dtTemp.NewRow();
            dr4["Years"] = lblFYLoclResText + Convert.ToString(ViewState["P3_Year"]) + lblPLoclResText;
            dr4[resEBITDA] = drMain["P3_Value"];
            dtTemp.Rows.Add(dr4);

            //Updating Gross Profit Margin
            DataRow drEBITDA_P = ds.Tables[0].Rows[1];

            dtTemp.Rows[1 - i]["EBITDA Margin (%)"] = drEBITDA_P["P1_Value"];
            dtTemp.Rows[2 - i]["EBITDA Margin (%)"] = drEBITDA_P["P2_Value"];
            dtTemp.Rows[3 - i]["EBITDA Margin (%)"] = drEBITDA_P["P3_Value"];

            //Updating NetProfitMargin
            DataRow drGrossProfit = ds.Tables[0].Rows[2];


            dtTemp.Rows[1 - i][resGrossProfit] = drGrossProfit["P1_Value"];
            dtTemp.Rows[2 - i][resGrossProfit] = drGrossProfit["P2_Value"];
            dtTemp.Rows[3 - i][resGrossProfit] = drGrossProfit["P3_Value"];

            DataRow drGrossProfit_P = ds.Tables[0].Rows[3];

            dtTemp.Rows[1 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P1_Value"];
            dtTemp.Rows[2 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P2_Value"];
            dtTemp.Rows[3 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P3_Value"];


            DataRow drSales = ds.Tables[0].Rows[4];


            dtTemp.Rows[1 - i][resSales] = drSales["P1_Value"];
            dtTemp.Rows[2 - i][resSales] = drSales["P2_Value"];
            dtTemp.Rows[3 - i][resSales] = drSales["P3_Value"];
            if (i == 0)
            {
                dtTemp.Rows[0]["EBITDA Margin (%)"] = drEBITDA_P["C_Value"];
                dtTemp.Rows[0][resGrossProfit] = drGrossProfit["C_Value"];
                dtTemp.Rows[0]["GrossProfit Margin (%)"] = drGrossProfit_P["C_Value"];
                dtTemp.Rows[0][resSales] = drSales["C_Value"];
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtTemp;
    }

    private DataTable createTableSegmentAnalysis(DataSet ds)
    {
        DataTable dtTemp = new DataTable();
        try
        {

            DataColumn dcYears = new DataColumn("Years");
            DataColumn dcEBITDA = new DataColumn("EBITDA");
            DataColumn dcEBITDA_P = new DataColumn("EBITDA Margin (%)");
            DataColumn dcGrossProfit = new DataColumn(resGrossProfit1);
            DataColumn dcGrossProfit_P = new DataColumn("GrossProfit Margin (%)");
            DataColumn dcSales = new DataColumn(resSales1);


            dtTemp.Columns.Add(dcYears);
            dtTemp.Columns.Add(dcEBITDA);
            dtTemp.Columns.Add(dcEBITDA_P);
            dtTemp.Columns.Add(dcGrossProfit);
            dtTemp.Columns.Add(dcGrossProfit_P);
            dtTemp.Columns.Add(dcSales);

            int i = 1;
            //if (Convert.ToString(ViewState["IsFinancialStmtAvailable"]) == "0")
            //{
            //    i = 1;
            //}
            DataRow drMain = ds.Tables[0].Rows[0];
            if (i == 0)
            {
                DataRow dr1 = dtTemp.NewRow();
                dr1["Years"] = lblFYLoclResText + Convert.ToString(ViewState["C_Year"]) + lblALoclResText;
                dr1["EBITDA"] = drMain["C_Value"];
                dtTemp.Rows.Add(dr1);
            }

            DataRow dr2 = dtTemp.NewRow();
            dr2["Years"] = lblFYLoclResText + Convert.ToString(ViewState["P1_Year"]) + lblPLoclResText;
            dr2["EBITDA"] = drMain["P1_Value"];
            dtTemp.Rows.Add(dr2);

            DataRow dr3 = dtTemp.NewRow();
            dr3["Years"] = lblFYLoclResText + Convert.ToString(ViewState["P2_Year"]) + lblPLoclResText;
            dr3["EBITDA"] = drMain["P2_Value"];
            dtTemp.Rows.Add(dr3);

            DataRow dr4 = dtTemp.NewRow();
            dr4["Years"] = lblFYLoclResText + Convert.ToString(ViewState["P3_Year"]) + lblPLoclResText;
            dr4["EBITDA"] = drMain["P3_Value"];
            dtTemp.Rows.Add(dr4);

            //Updating Gross Profit Margin
            DataRow drEBITDA_P = ds.Tables[0].Rows[1];

            dtTemp.Rows[1 - i]["EBITDA Margin (%)"] = drEBITDA_P["P1_Value"];
            dtTemp.Rows[2 - i]["EBITDA Margin (%)"] = drEBITDA_P["P2_Value"];
            dtTemp.Rows[3 - i]["EBITDA Margin (%)"] = drEBITDA_P["P3_Value"];

            //Updating NetProfitMargin
            DataRow drGrossProfit = ds.Tables[0].Rows[2];


            dtTemp.Rows[1 - i][resGrossProfit1] = drGrossProfit["P1_Value"];
            dtTemp.Rows[2 - i][resGrossProfit1] = drGrossProfit["P2_Value"];
            dtTemp.Rows[3 - i][resGrossProfit1] = drGrossProfit["P3_Value"];

            DataRow drGrossProfit_P = ds.Tables[0].Rows[3];

            dtTemp.Rows[1 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P1_Value"];
            dtTemp.Rows[2 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P2_Value"];
            dtTemp.Rows[3 - i]["GrossProfit Margin (%)"] = drGrossProfit_P["P3_Value"];


            DataRow drSales = ds.Tables[0].Rows[4];


            dtTemp.Rows[1 - i][resSales1] = drSales["P1_Value"];
            dtTemp.Rows[2 - i][resSales1] = drSales["P2_Value"];
            dtTemp.Rows[3 - i][resSales1] = drSales["P3_Value"];
            if (i == 0)
            {
                dtTemp.Rows[0]["EBITDA Margin (%)"] = drEBITDA_P["C_Value"];
                dtTemp.Rows[0][resGrossProfit1] = drGrossProfit["C_Value"];
                dtTemp.Rows[0]["GrossProfit Margin (%)"] = drGrossProfit_P["C_Value"];
                dtTemp.Rows[0][resSales1] = drSales["C_Value"];
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
        if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            objFinModelingMgmt.Culture = Convert.ToString(Session["Culture"]);
            dsData = objFinModelingMgmt.Get_FinTool_Highlights_Report(objFinModelingMgmt);

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

            if (ViewState["IsFinancialStmtAvailable"].ToString() != null && ViewState["IsFinancialStmtAvailable"].ToString() != "")
            {
                int pastValue = Convert.ToInt32(ViewState["IsFinancialStmtAvailable"]);
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

            ViewState["SalesProfitAnalysis"] = dsData.Tables[2];
            gvSalesProfitAnalysis.DataSource = dtGVSalesProfitAnalysis;
            gvSalesProfitAnalysis.DataBind();


            DataTable dtGVGPAnalysis = new DataTable();
            dtGVGPAnalysis = dsData.Tables[3];

            ViewState["GVGPAnalysis"] = dsData.Tables[3];
            gvGPAnalysis.DataSource = dtGVGPAnalysis;
            gvGPAnalysis.DataBind();
        }
    }


    protected void gvSalesProfitAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            Label lblpercent1 = (Label)e.Row.FindControl("lbl_P1_Percent");
            Label lblpercent2 = (Label)e.Row.FindControl("lbl_P2_Percent");
            Label lblpercent3 = (Label)e.Row.FindControl("lbl_P3_Percent");
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
            if (e.Row.RowIndex == 0 || e.Row.RowIndex == 1 || e.Row.RowIndex == 2 || e.Row.RowIndex == 3)
            {
                if (lblpercent1.Text.ToString() != "" && lblpercent2.Text.ToString() != "" && lblpercent3.Text.ToString() != "")
                {
                    lblpercent1.Text = lblpercent1.Text + "%";
                    lblpercent2.Text = lblpercent2.Text + "%";
                    lblpercent3.Text = lblpercent3.Text + "%";
                }
            }

            if (e.Row.RowIndex == 3)
            {
                lblp1.Text = calValues((DataTable)ViewState["SalesProfitAnalysis"], "266,267,268", "P1_Value", "1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["SalesProfitAnalysis"], "266,267,268", "P2_Value", "1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["SalesProfitAnalysis"], "266,267,268", "P3_Value", "1,1,1").ToString();
                //lblpercent1.Text = calValues((DataTable)ViewState["SalesProfitAnalysis"], "266,267,268", "P1_PERCENT", "1,1,1").ToString() + "%";
                //lblpercent2.Text = calValues((DataTable)ViewState["SalesProfitAnalysis"], "266,267,268", "P2_PERCENT", "1,1,1").ToString() + "%";
                //lblpercent3.Text = calValues((DataTable)ViewState["SalesProfitAnalysis"], "266,267,268", "P3_PERCENT", "1,1,1").ToString() + "%";
            }

        }
    }
    protected void gvGPAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            Label lblpercent1 = (Label)e.Row.FindControl("lbl_P1_Percent");
            Label lblpercent2 = (Label)e.Row.FindControl("lbl_P2_Percent");
            Label lblpercent3 = (Label)e.Row.FindControl("lbl_P3_Percent");
            Label lblFsMappingName = (Label)e.Row.FindControl("lblFsMappingName");

            // if (e.Row.RowIndex != 4)
            // {
            if (strLblClientIds == "")
            {
                strLblClientIds = lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            else
            {
                strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            //  }

            if (e.Row.RowIndex == 3)//lblFsMappingName.Text == "Total")
            {
                lblFsMappingName.Visible = false;
                e.Row.Style.Value = "display:none";
                e.Row.Style.Value = "font-weight:bold";
            }
            if (e.Row.RowIndex == 4)
            {
                e.Row.Cells[1].ForeColor = Color.Red;
                e.Row.Cells[3].ForeColor = Color.Red;
                e.Row.Cells[5].ForeColor = Color.Red;
                lblFsMappingName.Text = Convert.ToString(GetLocalResourceObject("lblFake1Resource1.Text"));


            }
            if (e.Row.RowIndex == 5)
            {
                e.Row.BackColor = Color.FromName("#ccecff");
                e.Row.Font.Bold = true;
                lblFsMappingName.Text = Convert.ToString(GetLocalResourceObject("lblFake2Resource1.Text"));

            }
            if (e.Row.RowIndex == 0 || e.Row.RowIndex == 1 || e.Row.RowIndex == 2 || e.Row.RowIndex == 3 || e.Row.RowIndex == 4 || e.Row.RowIndex == 5)
            {
                if (lblpercent1.Text.ToString() != "" && lblpercent2.Text.ToString() != "" && lblpercent3.Text.ToString() != "")
                {
                    lblpercent1.Text = lblpercent1.Text + "%";
                    lblpercent2.Text = lblpercent2.Text + "%";
                    lblpercent3.Text = lblpercent3.Text + "%";
                }
            }

            if (e.Row.RowIndex == 3)
            {
                lblp1.Text = calValues((DataTable)ViewState["GVGPAnalysis"], "220,221,222", "P1_Value", "1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["GVGPAnalysis"], "220,221,222", "P2_Value", "1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["GVGPAnalysis"], "220,221,222", "P3_Value", "1,1,1").ToString();
            }
            //if (e.Row.RowIndex == 3)
            //{
            //    lblp1.Text = calValues((DataTable)ViewState["GVGPAnalysis"], "270,271", "P1_Value", "1,1").ToString();
            //    lblp2.Text = calValues((DataTable)ViewState["GVGPAnalysis"], "270,271", "P2_Value", "1,1").ToString();
            //    lblp3.Text = calValues((DataTable)ViewState["GVGPAnalysis"], "270,271", "P3_Value", "1,1").ToString();
            //}

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
            HeaderCell.Text = lblFYLoclResText + ViewState["P1_Year"].ToString() + lblPLoclResText;
            HeaderCell.ColumnSpan = 2;
            HeaderCell.Font.Bold = true;
            HeaderCell.Attributes.Add("align", "center");
            HeaderGridRow.Cells.Add(HeaderCell);



            HeaderCell = new TableCell();
            HeaderCell.Text = lblFYLoclResText + ViewState["P2_Year"].ToString() + lblPLoclResText;
            HeaderCell.ColumnSpan = 2;
            HeaderCell.Font.Bold = true;
            HeaderCell.Attributes.Add("align", "center");
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = lblFYLoclResText + ViewState["P3_Year"].ToString() + lblPLoclResText;
            HeaderCell.ColumnSpan = 2;
            HeaderCell.Font.Bold = true;
            HeaderCell.Attributes.Add("align", "center");
            HeaderGridRow.Cells.Add(HeaderCell);

            gvSalesProfitAnalysis.Controls[0].Controls.AddAt
            (0, HeaderGridRow);
        }


    }
    public void BindClientIds()
    {
        strLblClientIds = strLblClientIds + "," + lblGrossProfitC.ClientID + "," + lblGrossProfitP1.ClientID + "," + lblGrossProfitP2.ClientID + "," + lblGrossProfitP3.ClientID + "," + lblGrossProfitPercentageC.ClientID + "," + lblGrossProfitPercentageP1.ClientID + "," + lblGrossProfitPercentageP2.ClientID + "," + lblGrossProfitPercentageP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblSalesC.ClientID + "," + lblSalesP1.ClientID + "," + lblSalesP2.ClientID + "," + lblSalesP3.ClientID + "," + lblSales1P1.ClientID + "," + lblSales1P2.ClientID + "," + lblSales1P3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblgpP1.ClientID + "," + lblgpP2.ClientID + "," + lblgpP3.ClientID;


    }
    protected void gvGrossProfit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblFsMappingName = (Label)e.Row.FindControl("lblFsMappingName");
            if (e.Row.RowIndex == 0)
            {
                
              //  lblFsMappingName.Text = lblFsMappingName.Text + " Margin";
                lblFsMappingName.Text = Convert.ToString(GetLocalResourceObject("lblFakeMarginResource.Text"));
            }

        }
    }
    private int calValues(DataTable dt, string FsMappingIds, string strFieldName, string signs)
    {
        try
        {
            int intOutPutValue = 0;
            string[] strSplitIds = FsMappingIds.Split(',');
            string[] strSplitSign = signs.Split(',');
            for (int i = 0; i < strSplitIds.Length; i++)
            {
                DataRow[] dr = dt.Select("FSMAPPINGID=" + strSplitIds[i].ToString());
                if (dr[0][strFieldName] != null && Convert.ToString(dr[0][strFieldName]) != "")
                {
                    intOutPutValue = intOutPutValue + (Convert.ToInt32(dr[0][strFieldName]) * Convert.ToInt32(strSplitSign[i]));
                }
            }
            return intOutPutValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}