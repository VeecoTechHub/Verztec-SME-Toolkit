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

public partial class RadarGraph : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    Report_BLL bll = new Report_BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
                ViewState["PreviousPage"] = Request.UrlReferrer;
            }
            Session["IsFinancialStmtAvailable"] = 0;

            bindChart();
            bindChart_health();
        }

    }
    private void bindChart()
    {
        try
        {
            DataSet ds = bll.getReport_health(Convert.ToString(ViewState["UserID"]));

            //   DataTable dtTemp = createTable();

            // double[] yValues = { 1, 1, 3, 9 };
            double[] yValues = { Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString()), Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString()), Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString()), Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString()) };

            //  double[] yValues = { Convert.ToString(ds.Tables[0].Rows[0][0]) == "" ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0][0]),Convert.ToString(ds.Tables[0].Rows[0][1]) == ""? 0 : Convert.ToInt32(ds.Tables[0].Rows[0][1]), Convert.ToString(ds.Tables[0].Rows[0][2]) == "" ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0][2]),Convert.ToString(ds.Tables[0].Rows[0][3]) == "" ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0][3]) };

            // double[] yValues2 = { 76.45, 23.78, 86.45, 30.76, 23.79, 35.67, 89.56, 67.45, 38.98 };
            //  string[] xValues = { "asdsa dsadA", "Bsadas sa sadd ", "C sad as", "D asdasdasd" };
            string[] xValues = { "Growing & Glowing", "Growing Pain ", "Rejuvenation needed", "Survival at risk" };
            Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region health

    private void formatSeries_health(SeriesChartType chartType, string strSeriesName, MarkerStyle seriesMarkerStyle)
    {
        try
        {

            FinancialChart.Series[strSeriesName].ChartType = chartType;

            if (chartType == SeriesChartType.Line)
            {
                FinancialChart.Series[strSeriesName].MarkerStyle = seriesMarkerStyle;
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable createTable_health()
    {
        DataSet ds = bll.getReport_GetQuestionPercentange(Convert.ToString(ViewState["UserID"]));
        DataTable dtTemp = new DataTable();
        try
        {

            DataColumn dcXaxis = new DataColumn("X Axis");
            DataColumn dcYours = new DataColumn("Yours");
            DataColumn dcHigh = new DataColumn("High");


            dtTemp.Columns.Add(dcXaxis);
            dtTemp.Columns.Add(dcYours);
            dtTemp.Columns.Add(dcHigh);


            DataRow dr1 = dtTemp.NewRow();
            dr1["X Axis"] = "Your rating of the external environment";
            if (ds.Tables.Count > 0)
            {
                dr1["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()).ToString("0000.00");

                //dr1["High"] = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                double a = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                dr1["High"] = Convert.ToDecimal(a).ToString("0000.00");


                dtTemp.Rows.Add(dr1);

                DataRow dr2 = dtTemp.NewRow();
                dr2["X Axis"] = "Your competitive edge rating";
                dr2["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][1].ToString()).ToString("0000.00");
                double b = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                dr2["High"] = Convert.ToDecimal(b).ToString("0000.00");


                dtTemp.Rows.Add(dr2);

                DataRow dr3 = dtTemp.NewRow();
                dr3["X Axis"] = "Your profitability rating";
                dr3["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString()).ToString("0000.00");
                double c = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString());
                dr3["High"] = Convert.ToDecimal(c).ToString("0000.00");

                dtTemp.Rows.Add(dr3);

                DataRow dr4 = dtTemp.NewRow();
                dr4["X Axis"] = "Your cash flow liquidity rating";
                dr4["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString()).ToString("0000.00");
                double d = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                dr4["High"] = Convert.ToDecimal(d).ToString("0000.00");

                dtTemp.Rows.Add(dr4);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtTemp;
    }


    private void bindChart_health()
    {
        try
        {
            DataSet ds = bll.getReport_health(Convert.ToString(ViewState["UserID"]));

            DataTable dtTemp = createTable_health();

            FinancialChart.DataSource = dtTemp;
            DataView firstView = new DataView(dtTemp);
            FinancialChart.Series["Yours"].Points.DataBindXY(firstView, "X Axis", firstView, "Yours");
            FinancialChart.Series["High"].Points.DataBindXY(firstView, "X Axis", firstView, "High");

            formatSeries_health(SeriesChartType.StackedBar, "Yours", MarkerStyle.Circle);
            formatSeries_health(SeriesChartType.StackedBar, "High", MarkerStyle.Circle);


            FinancialChart.Series["Yours"]["StackedGroupName"] = "Group2";
            FinancialChart.Series["High"]["StackedGroupName"] = "Group2";


            FinancialChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            FinancialChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion health
    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["PreviousPage"] != null)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
}