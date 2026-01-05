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
using ABSDTO;
using ABSBLL;
using System.Configuration;

public partial class UserControls_WorkingCapital : System.Web.UI.UserControl
{
    public string resChartTitle = string.Empty;
    public string resAvgStockHoldingsDays = string.Empty;
    public string resAvgCollectionDays = string.Empty;
    public string resAvgFinancingDaysfromSupplliers = string.Empty;
    public string resAvgPaymentDays = string.Empty;
    public string resWorkingCapitalDays = string.Empty;

    public string resGrossProfit = string.Empty;
    Report_BLL bll = new Report_BLL();
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    public static string strLblClientIds = string.Empty;
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
        strLblClientIds = string.Empty;
        objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
        DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
        ViewState["C_Year"] = dtCompanyInfo.Rows[0]["LatestFinancialYear"];
        ViewState["P1_Year"] = dtCompanyInfo.Rows[0]["P1_Year"];
        ViewState["P2_Year"] = dtCompanyInfo.Rows[0]["P2_Year"];
        ViewState["P3_Year"] = dtCompanyInfo.Rows[0]["P3_Year"];
        ViewState["RoundDollarType"] = dtCompanyInfo.Rows[0]["RoundDollarType"];
        ViewState["IsFinancialStmtAvailable"] = dtCompanyInfo.Rows[0]["IsFinancialStmtAvailable"];


        if (ViewState["C_Year"] != null && Convert.ToString(ViewState["C_Year"]) != "")
        {
            CashConversion1_Chart.Visible = true;
            bindChart_CC1();
        }
        bindChart_CC2();
        Binddata();
        bindCompanyInfo();
        BindClientIds();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "FormatCells", "formatCellsWithComma('" + strLblClientIds + "');", true);
    }
    #region cc1
    private void bindChart_CC1()
    {
        try
        {


            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                resChartTitle = Convert.ToString(GetLocalResourceObject("lblChartTitleResource1.Text"));
                resAvgStockHoldingsDays = Convert.ToString(GetLocalResourceObject("lblAvgStockHoldingsDaysResource1.Text"));
                resAvgCollectionDays = Convert.ToString(GetLocalResourceObject("lblAvgCollectionDaysResource1.Text"));
                resAvgFinancingDaysfromSupplliers = Convert.ToString(GetLocalResourceObject("lblAvgFinancingDaysfromSupplliersResource1.Text"));
                resAvgPaymentDays = Convert.ToString(GetLocalResourceObject("lblAvgPaymentDaysResource1.Text"));
                resWorkingCapitalDays = Convert.ToString(GetLocalResourceObject("lblWorkingCapitalDaysResource1.Text"));


                string fsmappingids = "120,121,97,98,125";// "73,74,75,76";
                string userid = Convert.ToString(ViewState["UserID"]);
                DataSet ds = bll.getReport_workingcapital(fsmappingids, userid);

                DataTable dtTemp = createTable_CC1(ds);

                if (Convert.ToString(Session["Culture"]) != "zh-SG")
                    tdHide1.Attributes.Add("class", "tdimage");
                else
                    tdHide1.Attributes.Add("class", "tdimage_C");


                if (Convert.ToString(dtTemp.Rows[0][resAvgPaymentDays]) == "0" || Convert.ToString(dtTemp.Rows[0][resAvgPaymentDays]) == "" && Convert.ToString(dtTemp.Rows[1][resAvgStockHoldingsDays]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgStockHoldingsDays]) == "" && Convert.ToString(dtTemp.Rows[1][resAvgCollectionDays]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgCollectionDays]) == "")
                {
                    CashConversion1_Chart.Visible = false;
                    TrImage1.Visible = true;
                    HideTr16.Visible = false;
                }
                else
                {
                   

                    CashConversion1_Chart.Titles[0].Text = resChartTitle;
                    //chartSegmentAnalysis.Series["EBITDA"].Points.DataBindXY(firstView, "Years", firstView, "EBITDA");

                    CashConversion1_Chart.Series[0].Name = resAvgStockHoldingsDays;
                    CashConversion1_Chart.Series[1].Name = resAvgCollectionDays;
                    CashConversion1_Chart.Series[2].Name = resAvgFinancingDaysfromSupplliers;
                    CashConversion1_Chart.Series[3].Name = resAvgPaymentDays;
                    CashConversion1_Chart.Series[4].Name = resWorkingCapitalDays;

                    CashConversion1_Chart.Visible = true;
                    TrImage1.Visible = false;
                    HideTr16.Visible = true;

                    CashConversion1_Chart.DataSource = dtTemp;
                    DataView firstView = new DataView(dtTemp);

                    CashConversion1_Chart.Series[resAvgPaymentDays].Points.DataBindXY(firstView, "CycleName", firstView, resAvgPaymentDays);
                    CashConversion1_Chart.Series[resWorkingCapitalDays].Points.DataBindXY(firstView, "CycleName", firstView, resWorkingCapitalDays);
                    CashConversion1_Chart.Series[resAvgStockHoldingsDays].Points.DataBindXY(firstView, "CycleName", firstView, resAvgStockHoldingsDays);
                    CashConversion1_Chart.Series[resAvgCollectionDays].Points.DataBindXY(firstView, "CycleName", firstView, resAvgCollectionDays);
                    CashConversion1_Chart.Series[resAvgFinancingDaysfromSupplliers].Points.DataBindXY(firstView, "CycleName", firstView, resAvgFinancingDaysfromSupplliers);



                    formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, resAvgPaymentDays, MarkerStyle.Circle);
                    formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, resWorkingCapitalDays, MarkerStyle.Circle);
                    formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, resAvgFinancingDaysfromSupplliers, MarkerStyle.Circle);
                    formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, resAvgStockHoldingsDays, MarkerStyle.Circle);
                    formatSeries_CC1(CashConversion1_Chart, SeriesChartType.StackedBar, resAvgCollectionDays, MarkerStyle.Circle);


                    //This helps in making 2 series merged into single column. For this column type need be StackedColumn
                    CashConversion1_Chart.Series[resAvgStockHoldingsDays]["StackedGroupName"] = "Group1";
                    CashConversion1_Chart.Series[resAvgCollectionDays]["StackedGroupName"] = "Group1";
                    CashConversion1_Chart.Series[resAvgFinancingDaysfromSupplliers]["StackedGroupName"] = "Group1";
                    CashConversion1_Chart.Series[resAvgPaymentDays]["StackedGroupName"] = "Group2";
                    CashConversion1_Chart.Series[resWorkingCapitalDays]["StackedGroupName"] = "Group2";


                    CashConversion1_Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    CashConversion1_Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;



                    #region formating labels
                    foreach (DataPoint ptRevenue in CashConversion1_Chart.Series[resAvgPaymentDays].Points)
                    {
                        ptRevenue.Label = resAvgPaymentDays + ptRevenue.YValues[0].ToString();
                       // ptRevenue.Label = "Avg Payment \n Days " + ptRevenue.YValues[0].ToString();
                        break;
                    }
                    foreach (DataPoint ptRevenue in CashConversion1_Chart.Series[resWorkingCapitalDays].Points)
                    {
                        ptRevenue.Label = resWorkingCapitalDays + ptRevenue.YValues[0].ToString();
                       // ptRevenue.Label = "Working Capital \n Days " + ptRevenue.YValues[0].ToString();
                        break;

                    }
                    foreach (DataPoint ptRevenue in CashConversion1_Chart.Series[resAvgStockHoldingsDays].Points)
                    {

                        ptRevenue.Label = resAvgStockHoldingsDays + ptRevenue.YValues[0].ToString();
                        //ptRevenue.Label = "Avg Stock \n Holdings Days" + ptRevenue.YValues[0].ToString();

                    }
                    foreach (DataPoint ptRevenue in CashConversion1_Chart.Series[resAvgCollectionDays].Points)
                    {
                        ptRevenue.Label = resAvgCollectionDays + ptRevenue.YValues[0].ToString();
                       // ptRevenue.Label = "Avg Collection \n Days " + ptRevenue.YValues[0].ToString();

                    }
                    foreach (DataPoint ptRevenue in CashConversion1_Chart.Series[resAvgFinancingDaysfromSupplliers].Points)
                    {
                        ptRevenue.Label = resAvgFinancingDaysfromSupplliers + ptRevenue.YValues[0].ToString();
                        //ptRevenue.Label = "Avg Financing Days \n from Supplliers " + ptRevenue.YValues[0].ToString();
                    }

                    #endregion

                    #region Hiding the series if no data
                    if (Convert.ToString(dtTemp.Rows[0][resAvgPaymentDays]) == "0" || Convert.ToString(dtTemp.Rows[0][resAvgPaymentDays]) == "")
                    {
                        CashConversion1_Chart.Series.Remove(CashConversion1_Chart.Series[resAvgPaymentDays]);
                    }
                    if (Convert.ToString(dtTemp.Rows[0][resWorkingCapitalDays]) == "0" || Convert.ToString(dtTemp.Rows[0][resWorkingCapitalDays]) == "")
                    {
                        CashConversion1_Chart.Series.Remove(CashConversion1_Chart.Series[resWorkingCapitalDays]);
                    }
                    if (Convert.ToString(dtTemp.Rows[1][resAvgStockHoldingsDays]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgStockHoldingsDays]) == "")
                    {
                        CashConversion1_Chart.Series.Remove(CashConversion1_Chart.Series[resAvgStockHoldingsDays]);
                    }
                    if (Convert.ToString(dtTemp.Rows[1][resAvgCollectionDays]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgCollectionDays]) == "")
                    {
                        CashConversion1_Chart.Series.Remove(CashConversion1_Chart.Series[resAvgCollectionDays]);
                    }
                    if (Convert.ToString(dtTemp.Rows[1][resAvgFinancingDaysfromSupplliers]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgFinancingDaysfromSupplliers]) == "")
                    {
                        CashConversion1_Chart.Series.Remove(CashConversion1_Chart.Series[resAvgFinancingDaysfromSupplliers]);
                    }
                    #endregion
                }
            }

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

            DataColumn dcAvgStockHolding = new DataColumn(resAvgStockHoldingsDays);
            DataColumn dcAvgCollection = new DataColumn(resAvgCollectionDays);
            DataColumn dcAvgPayment = new DataColumn(resAvgPaymentDays);
            DataColumn dcWorkingCapital = new DataColumn(resWorkingCapitalDays);
            DataColumn dcAvgFinancing = new DataColumn(resAvgFinancingDaysfromSupplliers);



            dtTemp.Columns.Add(dcCycleName);
            dtTemp.Columns.Add(dcAvgStockHolding);
            dtTemp.Columns.Add(dcAvgCollection);
            dtTemp.Columns.Add(dcAvgPayment);
            dtTemp.Columns.Add(dcWorkingCapital);
            dtTemp.Columns.Add(dcAvgFinancing);


            DataRow dr2 = dtTemp.NewRow();

            dr2["CycleName"] = Convert.ToString(GetLocalResourceObject("lblCycleName1Resource1.Text"));

            dr2[resAvgPaymentDays] = ds.Tables[0].Rows[2]["C_Value"];
            dr2[resWorkingCapitalDays] = ds.Tables[0].Rows[3]["C_Value"];
            dtTemp.Rows.Add(dr2);



            DataRow dr1 = dtTemp.NewRow();
            dr1["CycleName"] = Convert.ToString(GetLocalResourceObject("lblCycleName2Resource1.Text"));
            dr1[resAvgStockHoldingsDays] = ds.Tables[0].Rows[0]["C_Value"];
            dr1[resAvgCollectionDays] = ds.Tables[0].Rows[1]["C_Value"];
            dr1[resAvgFinancingDaysfromSupplliers] = ds.Tables[0].Rows[4]["C_Value"];
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

            string fsmappingids = "100,101,102,103,123";
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                resChartTitle = Convert.ToString(GetLocalResourceObject("lblChartTitleResource1.Text"));
                resAvgStockHoldingsDays = Convert.ToString(GetLocalResourceObject("lblAvgStockHoldingsDaysResource1.Text"));
                resAvgCollectionDays = Convert.ToString(GetLocalResourceObject("lblAvgCollectionDaysResource1.Text"));
                resAvgFinancingDaysfromSupplliers = Convert.ToString(GetLocalResourceObject("lblAvgFinancingDaysfromSupplliersResource1.Text"));
                resAvgPaymentDays = Convert.ToString(GetLocalResourceObject("lblAvgPaymentDaysResource1.Text"));
                resWorkingCapitalDays = Convert.ToString(GetLocalResourceObject("lblWorkingCapitalDaysResource1.Text"));

                string userid = Convert.ToString(ViewState["UserID"]);
                DataSet ds = bll.getReport_workingcapital(fsmappingids, userid);

                DataTable dtTemp = createTable_CC2(ds);

                if(Convert.ToString(Session["Culture"]) != "zh-SG")
                    tdHide.Attributes.Add("class", "tdimage");
                else
                    tdHide.Attributes.Add("class", "tdimage_C");


                if (Convert.ToString(dtTemp.Rows[0][resAvgPaymentDays]) == "0" || Convert.ToString(dtTemp.Rows[0][resAvgPaymentDays]) == "" && Convert.ToString(dtTemp.Rows[1][resAvgStockHoldingsDays]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgStockHoldingsDays]) == "" && Convert.ToString(dtTemp.Rows[1][resAvgCollectionDays]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgCollectionDays]) == "")
                {
                    CashConversion2_Chart.Visible = false;
                    TrImage2.Visible = true;
                  
                }
                else
                {

                    CashConversion2_Chart.Titles[0].Text = resChartTitle;
                    //chartSegmentAnalysis.Series["EBITDA"].Points.DataBindXY(firstView, "Years", firstView, "EBITDA");

                    CashConversion2_Chart.Series[0].Name = resAvgStockHoldingsDays;
                    CashConversion2_Chart.Series[1].Name = resAvgCollectionDays;
                    CashConversion2_Chart.Series[2].Name = resAvgFinancingDaysfromSupplliers;
                    CashConversion2_Chart.Series[3].Name = resAvgPaymentDays;
                    CashConversion2_Chart.Series[4].Name = resWorkingCapitalDays;


                    CashConversion2_Chart.Visible = true;
                    TrImage2.Visible = false;

                    CashConversion2_Chart.DataSource = dtTemp;

                    DataView firstView = new DataView(dtTemp);


                    CashConversion2_Chart.Series[resAvgPaymentDays].Points.DataBindXY(firstView, "CycleName", firstView, resAvgPaymentDays);
                    CashConversion2_Chart.Series[resWorkingCapitalDays].Points.DataBindXY(firstView, "CycleName", firstView, resWorkingCapitalDays);
                    CashConversion2_Chart.Series[resAvgStockHoldingsDays].Points.DataBindXY(firstView, "CycleName", firstView, resAvgStockHoldingsDays);
                    CashConversion2_Chart.Series[resAvgCollectionDays].Points.DataBindXY(firstView, "CycleName", firstView, resAvgCollectionDays);
                    CashConversion2_Chart.Series[resAvgFinancingDaysfromSupplliers].Points.DataBindXY(firstView, "CycleName", firstView, resAvgFinancingDaysfromSupplliers);

                    formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, resAvgPaymentDays, MarkerStyle.Circle);
                    formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, resWorkingCapitalDays, MarkerStyle.Circle);
                    formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, resAvgFinancingDaysfromSupplliers, MarkerStyle.Circle);

                    formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, resAvgStockHoldingsDays, MarkerStyle.Circle);
                    formatSeries_CC2(CashConversion2_Chart, SeriesChartType.StackedBar, resAvgCollectionDays, MarkerStyle.Circle);


                    //This helps in making 2 series merged into single column. For this column type need be StackedColumn
                    CashConversion2_Chart.Series[resAvgStockHoldingsDays]["StackedGroupName"] = "Group1";
                    CashConversion2_Chart.Series[resAvgCollectionDays]["StackedGroupName"] = "Group1";
                    CashConversion2_Chart.Series[resAvgFinancingDaysfromSupplliers]["StackedGroupName"] = "Group1";
                    CashConversion2_Chart.Series[resAvgPaymentDays]["StackedGroupName"] = "Group2";
                    CashConversion2_Chart.Series[resWorkingCapitalDays]["StackedGroupName"] = "Group2";

                    CashConversion2_Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    CashConversion2_Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;





                    #region formating labels
                    foreach (DataPoint ptRevenue in CashConversion2_Chart.Series[resAvgPaymentDays].Points)
                    {
                        ptRevenue.Label = resAvgPaymentDays + ptRevenue.YValues[0].ToString();
                      //  ptRevenue.Label = "Avg Payment \n Days " + ptRevenue.YValues[0].ToString();
                        break;
                    }
                    foreach (DataPoint ptRevenue in CashConversion2_Chart.Series[resWorkingCapitalDays].Points)
                    {
                        ptRevenue.Label = resWorkingCapitalDays + ptRevenue.YValues[0].ToString();
                      //  ptRevenue.Label = "Working Capital \n Days " + ptRevenue.YValues[0].ToString();
                        break;

                    }
                    foreach (DataPoint ptRevenue in CashConversion2_Chart.Series[resAvgStockHoldingsDays].Points)
                    {

                        ptRevenue.Label = resAvgStockHoldingsDays + ptRevenue.YValues[0].ToString();
                      //  ptRevenue.Label = "Avg Stock \n Holdings Days" + ptRevenue.YValues[0].ToString();

                    }
                    foreach (DataPoint ptRevenue in CashConversion2_Chart.Series[resAvgCollectionDays].Points)
                    {
                        ptRevenue.Label = resAvgCollectionDays + ptRevenue.YValues[0].ToString();
                      //  ptRevenue.Label = "Avg Collection \n Days " + ptRevenue.YValues[0].ToString();

                    }
                    foreach (DataPoint ptRevenue in CashConversion2_Chart.Series[resAvgFinancingDaysfromSupplliers].Points)
                    {
                        ptRevenue.Label = resAvgFinancingDaysfromSupplliers + ptRevenue.YValues[0].ToString();
                       // ptRevenue.Label = "Avg Financing Days \n from Supplliers " + ptRevenue.YValues[0].ToString();
                    }

                    #endregion

                    #region Hiding the series if no data
                    if (Convert.ToString(dtTemp.Rows[0][resAvgPaymentDays]) == "0" || Convert.ToString(dtTemp.Rows[0][resAvgPaymentDays]) == "")
                    {
                        CashConversion2_Chart.Series.Remove(CashConversion2_Chart.Series[resAvgPaymentDays]);
                    }
                    if (Convert.ToString(dtTemp.Rows[0][resWorkingCapitalDays]) == "0" || Convert.ToString(dtTemp.Rows[0][resWorkingCapitalDays]) == "")
                    {
                        CashConversion2_Chart.Series.Remove(CashConversion2_Chart.Series[resWorkingCapitalDays]);
                    }
                    if (Convert.ToString(dtTemp.Rows[1][resAvgStockHoldingsDays]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgStockHoldingsDays]) == "")
                    {
                        CashConversion2_Chart.Series.Remove(CashConversion2_Chart.Series[resAvgStockHoldingsDays]);
                    }
                    if (Convert.ToString(dtTemp.Rows[1][resAvgCollectionDays]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgCollectionDays]) == "")
                    {
                        CashConversion2_Chart.Series.Remove(CashConversion2_Chart.Series[resAvgCollectionDays]);
                    }
                    if (Convert.ToString(dtTemp.Rows[1][resAvgFinancingDaysfromSupplliers]) == "0" || Convert.ToString(dtTemp.Rows[1][resAvgFinancingDaysfromSupplliers]) == "")
                    {
                        CashConversion2_Chart.Series.Remove(CashConversion2_Chart.Series[resAvgFinancingDaysfromSupplliers]);
                    }
                    #endregion
                }
            }

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

            DataColumn dcAvgStockHolding = new DataColumn(resAvgStockHoldingsDays);
            DataColumn dcAvgCollection = new DataColumn(resAvgCollectionDays);
            DataColumn dcAvgPayment = new DataColumn(resAvgPaymentDays);
            DataColumn dcWorkingCapital = new DataColumn(resWorkingCapitalDays);
            DataColumn dcAvgFinancing = new DataColumn(resAvgFinancingDaysfromSupplliers);



            dtTemp.Columns.Add(dcCycleName);
            dtTemp.Columns.Add(dcAvgStockHolding);
            dtTemp.Columns.Add(dcAvgCollection);
            dtTemp.Columns.Add(dcAvgPayment);
            dtTemp.Columns.Add(dcWorkingCapital);
            dtTemp.Columns.Add(dcAvgFinancing);


            DataRow dr2 = dtTemp.NewRow();

            dr2["CycleName"] = Convert.ToString(GetLocalResourceObject("lblCycleName1Resource1.Text"));

            dr2[resAvgPaymentDays] = ds.Tables[0].Rows[0]["C_Value"];
            dr2[resWorkingCapitalDays] = ds.Tables[0].Rows[1]["C_Value"];
            dtTemp.Rows.Add(dr2);



            DataRow dr1 = dtTemp.NewRow();
            dr1["CycleName"] = Convert.ToString(GetLocalResourceObject("lblCycleName2Resource1.Text"));
            dr1[resAvgStockHoldingsDays] = ds.Tables[0].Rows[2]["C_Value"];
            dr1[resAvgCollectionDays] = ds.Tables[0].Rows[3]["C_Value"];
            dr1[resAvgFinancingDaysfromSupplliers] = ds.Tables[0].Rows[4]["C_Value"];
            dtTemp.Rows.Add(dr1);



        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtTemp;
    }


    #endregion cc2




    public void Binddata()
    {
        DataSet dsData = new DataSet();
        if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            dsData = objFinModelingMgmt.Get_FinTool_WorkingCapital_Report(objFinModelingMgmt);

            if (Convert.ToInt32(ViewState["IsFinancialStmtAvailable"]) == 0)
            {
                HideTr1.Visible = false;
                HideTr2.Visible = false;
                HideTr3.Visible = false;
                HideTr4.Visible = false;
                HideTr5.Visible = false;
                HideTr6.Visible = false;
                HideTr7.Visible = false;
                HideTr8.Visible = false;
                HideTr10.Visible = false;
                //  HideTr11.Visible = false;
                //  HideTr12.Visible = false;
                HideTr13.Visible = false;
                HideTr14.Visible = false;
                HideTr15.Visible = false;
                HideTr16.Visible = false;
                HideTr17.Visible = false;
            }
            else
            {
                ConditionTR.Visible = false;
            }
            String strURLPath = Request.Url.AbsolutePath.ToString();
            Array strArray;
            strArray = strURLPath.ToString().Split('/');
            int length = strArray.Length;
            string path = string.Empty;
            if (strArray.GetValue(length - 1).ToString().ToLower().Contains("reports.aspx"))
            {
                ConditionTR.Visible = false;
            }
            else
            {
                ConditionTR.Visible = true;
            }



            DataTable dtData1 = new DataTable();
            dtData1 = dsData.Tables[1];

            lblFundingP1.Text = dtData1.Rows[0][3].ToString();
            lblFundingP2.Text = dtData1.Rows[0][4].ToString();
            lblFundingP3.Text = dtData1.Rows[0][5].ToString();

            lblResourcesStocksP1.Text = dtData1.Rows[1][3].ToString();
            lblResourcesStocksP2.Text = dtData1.Rows[1][4].ToString();
            lblResourcesStocksP3.Text = dtData1.Rows[1][5].ToString();

            lblResourcesReceivablesP1.Text = dtData1.Rows[2][3].ToString();
            lblResourcesReceivablesP2.Text = dtData1.Rows[2][4].ToString();
            lblResourcesReceivablesP3.Text = dtData1.Rows[2][5].ToString();

            lblWorkingCapitalP1.Text = calValues(dtData1, "241,242,243", "P1_Value", "1,1,1").ToString();
            lblWorkingCapitalP2.Text = calValues(dtData1, "241,242,243", "P2_Value", "1,1,1").ToString();
            lblWorkingCapitalP3.Text = calValues(dtData1, "241,242,243", "P3_Value", "1,1,1").ToString();

            //lblWorkingCapitalP1.Text = dtData1.Rows[3][2].ToString();
            //lblWorkingCapitalP2.Text = dtData1.Rows[3][3].ToString();
            //lblWorkingCapitalP3.Text = dtData1.Rows[3][4].ToString();

            DataTable dtData2 = new DataTable();
            dtData2 = dsData.Tables[2];

            if (dtData2.Rows[14][0].ToString() == "0")
            {
                int intCapital1Days = 0;
                if (dtData2.Rows[17][0].ToString() != "" && dtData2.Rows[17][0].ToString() != null)
                {
                    intCapital1Days = Convert.ToInt32(dtData2.Rows[17][0]);
                }
                if (intCapital1Days >= 0)
                    lblCapital1Days.Text = Convert.ToString(GetLocalResourceObject("lblDes20Resource1.Text")) + " " + dtData2.Rows[17][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                else
                    lblCapital1Days.Text = Convert.ToString(GetLocalResourceObject("lblDes19Resource1.Text"));
            }
            else
            {
                if (dtData2.Rows[14][0].ToString() != "0")
                {
                    lblCapital1Days.Text = Convert.ToString(GetLocalResourceObject("lblDes13Resource1.Text")) + " " + dtData2.Rows[0][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                }
            }


            if (dtData2.Rows[1][0].ToString() == "0")
            {
                int intCapital2Days = 0;
                if (dtData2.Rows[16][0].ToString() != "" && dtData2.Rows[16][0].ToString() != null)
                {
                    intCapital2Days = Convert.ToInt32(dtData2.Rows[16][0]);
                }
                if (intCapital2Days >= 0)
                {
                    lblCapital2Days.Text = Convert.ToString(GetLocalResourceObject("lblDes21Resource1.Text")) + " " + dtData2.Rows[16][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                }
                else
                {
                    lblCapital2Days.Text = Convert.ToString(GetLocalResourceObject("lblDes19Resource1.Text"));
                }
            }
            else
            {
                if (dtData2.Rows[1][0].ToString() != "0")
                {
                    lblCapital2Days.Text = Convert.ToString(GetLocalResourceObject("lblDes14Resource1.Text")) + " " + dtData2.Rows[1][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                }
            }

            int intCapital3Days = 0;
            if (dtData2.Rows[3][0].ToString() != "" && dtData2.Rows[3][0].ToString() != null)
            {
                intCapital3Days = Convert.ToInt32(dtData2.Rows[3][0]);
            }
            if (intCapital3Days > 0)
            {
                if (dtData2.Rows[4][0] == null)
                {
                    lblCapital3Days.Text = Convert.ToString(GetLocalResourceObject("lblDes9Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblDes22Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                }
                else
                {
                    lblCapital3Days.Text = Convert.ToString(GetLocalResourceObject("lblDes9Resource1.Text")) + " " + dtData2.Rows[4][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                }
            }
            else
            {
                if (intCapital3Days < 0)
                {
                    if (dtData2.Rows[5][0] == null)
                    {
                        lblCapital3Days.Text = Convert.ToString(GetLocalResourceObject("lblDes3Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblDes22Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                    }
                    else
                    {
                        lblCapital3Days.Text = Convert.ToString(GetLocalResourceObject("lblDes3Resource1.Text")) + " " + dtData2.Rows[5][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                    }
                }
                else
                {
                    if (intCapital3Days == 0)
                    {
                        lblCapital3Days.Text = Convert.ToString(GetLocalResourceObject("lblDes15Resource1.Text"));
                    }
                    else
                    {
                        lblCapital3Days.Text = "N.A.";
                    }

                }

            }

            int intAverage1 = 0;
            if (dtData2.Rows[6][0].ToString() != "" && dtData2.Rows[6][0].ToString() != null)
            {
                intAverage1 = Convert.ToInt32(dtData2.Rows[6][0]);
            }
            if (intAverage1 > 0)
            {
                if (dtData2.Rows[7][0] == null)
                {
                    lblAverage1.Text = Convert.ToString(GetLocalResourceObject("lblDes4Resource1.Text")) + Convert.ToString(GetLocalResourceObject("lblDes22Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblfake1Resource1.Text"));
                }
                else
                {
                    lblAverage1.Text = Convert.ToString(GetLocalResourceObject("lblDes4Resource1.Text")) + " " + dtData2.Rows[7][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblfake1Resource1.Text"));
                }
            }
            else
            {
                if (intAverage1 < 0)
                {
                    if (dtData2.Rows[8][0] == null)
                    {
                        lblAverage1.Text = Convert.ToString(GetLocalResourceObject("lblDes10Resource1.Text")) + Convert.ToString(GetLocalResourceObject("lblDes22Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblfake2Resource1.Text"));
                    }
                    else
                    {
                        if (Convert.ToString(dtData2.Rows[8][0]) != "")
                        {
                            int intAbsolute = Convert.ToInt32(dtData2.Rows[8][0]);
                            lblAverage1.Text = Convert.ToString(GetLocalResourceObject("lblDes10Resource1.Text")) + " " + Math.Abs(intAbsolute) + " " + Convert.ToString(GetLocalResourceObject("lblfake2Resource1.Text"));
                        }
                    }
                }
                else
                {
                    if (intAverage1 == 0)
                    {
                        lblAverage1.Text = Convert.ToString(GetLocalResourceObject("lblDes16Resource1.Text"));
                    }
                    else
                    {
                        lblAverage1.Text = Convert.ToString(GetLocalResourceObject("lblDes23Resource1.Text1"));
                    }
                }

            }



            int intAverage2 = 0;
            if (dtData2.Rows[9][0].ToString() != "" && dtData2.Rows[9][0].ToString() != null)
            {
                intAverage2 = Convert.ToInt32(dtData2.Rows[9][0]);
            }
            if (intAverage2 > 0)
            {
                if (dtData2.Rows[9][0] == null)
                {
                    lblAverage2.Text = Convert.ToString(GetLocalResourceObject("lblDes5Resource1.Text")) + Convert.ToString(GetLocalResourceObject("lblDes22Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                }
                else
                {
                    lblAverage2.Text = Convert.ToString(GetLocalResourceObject("lblDes5Resource1.Text")) + " " + dtData2.Rows[9][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                }

            }
            else
            {
                if (intAverage2 < 0)
                {
                    if (dtData2.Rows[10][0] == null)
                    {
                        lblAverage2.Text = Convert.ToString(GetLocalResourceObject("lblDes11Resource1.Text"))   + Convert.ToString(GetLocalResourceObject("lblDes22Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                    }
                    else
                    {
                        if (Convert.ToString(dtData2.Rows[10][0]) != "")
                        {
                            int intAbsolute = Convert.ToInt32(dtData2.Rows[10][0]);
                            lblAverage2.Text = Convert.ToString(GetLocalResourceObject("lblDes11Resource1.Text")) + " " + Math.Abs(intAbsolute) + " " + Convert.ToString(GetLocalResourceObject("lblDaysResource1.Text"));
                        }
                    }
                }
                else
                {
                    if (intAverage2 == 0)
                    {
                        lblAverage2.Text = Convert.ToString(GetLocalResourceObject("lblDes17Resource1.Text"));
                    }
                    else
                    {
                        lblAverage2.Text = Convert.ToString(GetLocalResourceObject("lblDes24Resource1.Text1"));
                    }
                }
            }


            int intAverage3 = 0;
            if (dtData2.Rows[11][0].ToString() != "" && dtData2.Rows[11][0].ToString() != null)
            {
                intAverage3 = Convert.ToInt32(dtData2.Rows[11][0]);
            }

            if (intAverage3 > 0)
            {
                if (dtData2.Rows[12][0] == null)
                {
                    lblAverage3.Text = Convert.ToString(GetLocalResourceObject("lblDes12Resource1.Text")) + Convert.ToString(GetLocalResourceObject("lblDes22Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblfake4Resource1.Text"));
                }
                else
                {
                    if (Convert.ToString(dtData2.Rows[12][0]) != "")
                    {
                        int intAbsolute = Convert.ToInt32(dtData2.Rows[12][0]);

                        lblAverage3.Text = Convert.ToString(GetLocalResourceObject("lblDes12Resource1.Text")) + " " + Math.Abs(intAbsolute) + " " + Convert.ToString(GetLocalResourceObject("lblfake4Resource1.Text"));
                    }

                }
            }
            else
            {
                if (intAverage3 < 0)
                {
                    if (dtData2.Rows[13][0] == null)
                    {
                        lblAverage3.Text = Convert.ToString(GetLocalResourceObject("lblDes6Resource1.Text")) + Convert.ToString(GetLocalResourceObject("lblDes22Resource1.Text")) + " " + Convert.ToString(GetLocalResourceObject("lblfake3Resource1.Text"));
                    }
                    else
                    {
                        lblAverage3.Text = Convert.ToString(GetLocalResourceObject("lblDes6Resource1.Text")) + " " + dtData2.Rows[13][0].ToString() + " " + Convert.ToString(GetLocalResourceObject("lblfake3Resource1.Text"));

                    }
                }
                else
                {
                    if (intAverage3 == 0)
                    {
                        lblAverage3.Text = Convert.ToString(GetLocalResourceObject("lblDes18Resource1.Text"));
                    }
                    else
                    {
                        lblAverage3.Text = Convert.ToString(GetLocalResourceObject("lblDes25Resource1.Text1"));
                    }
                }
            }

            decimal decimala = 0;
            decimal decimalb = 0;
            decimal decimalc = 0;

            if (dtData2.Rows[6][0].ToString() != "" && dtData2.Rows[6][0].ToString() != null)
            {
                decimala = (-Convert.ToDecimal(dtData2.Rows[6][0].ToString()));
                lbla.Text = decimala.ToString();
            }
            if (dtData2.Rows[9][0].ToString() != "" && dtData2.Rows[9][0].ToString() != null)
            {
                decimalb = (-Convert.ToDecimal(dtData2.Rows[9][0].ToString()));
                lblb.Text = decimalb.ToString();
            }
            if (dtData2.Rows[11][0].ToString() != "" && dtData2.Rows[11][0].ToString() != null)
            {
                decimalc = (-Convert.ToDecimal(dtData2.Rows[11][0].ToString()));
                lblc.Text = decimalc.ToString();
            }

            lblABCTotal.Text = (decimala + decimalb + decimalc).ToString();
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
                DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

                ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
                ViewState["ProjYear1"] = drCompanyInfo["P1_Year"].ToString();
                ViewState["ProjYear2"] = drCompanyInfo["P2_Year"].ToString();
                ViewState["ProjYear3"] = drCompanyInfo["P3_Year"].ToString();

                ViewState["Currency"] = drCompanyInfo["Currency"].ToString();


                lblYearP1.Text = drCompanyInfo["P1_Year"].ToString();
                lblYearP2.Text = drCompanyInfo["P2_Year"].ToString();
                lblYearP3.Text = drCompanyInfo["P3_Year"].ToString();
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void BindClientIds()
    {
        if (Convert.ToInt32(ViewState["IsFinancialStmtAvailable"]) != 0)
        {
            strLblClientIds = lbla.ClientID + "," + lblb.ClientID + "," + lblc.ClientID + "," + lblABCTotal.ClientID;
            strLblClientIds = strLblClientIds + "," + lblFundingP1.ClientID + "," + lblFundingP2.ClientID + "," + lblFundingP3.ClientID + "," + lblResourcesStocksP1.ClientID + "," + lblResourcesStocksP2.ClientID + "," + lblResourcesStocksP3.ClientID;
            strLblClientIds = strLblClientIds + "," + lblResourcesReceivablesP1.ClientID + "," + lblResourcesReceivablesP2.ClientID + "," + lblResourcesReceivablesP3.ClientID + "," + lblWorkingCapitalP1.ClientID + "," + lblWorkingCapitalP2.ClientID + "," + lblWorkingCapitalP3.ClientID;
        }
        else
        {
            strLblClientIds = lblFundingP1.ClientID + "," + lblFundingP2.ClientID + "," + lblFundingP3.ClientID + "," + lblResourcesStocksP1.ClientID + "," + lblResourcesStocksP2.ClientID + "," + lblResourcesStocksP3.ClientID;
            strLblClientIds = strLblClientIds + "," + lblResourcesReceivablesP1.ClientID + "," + lblResourcesReceivablesP2.ClientID + "," + lblResourcesReceivablesP3.ClientID + "," + lblWorkingCapitalP1.ClientID + "," + lblWorkingCapitalP2.ClientID + "," + lblWorkingCapitalP3.ClientID;
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