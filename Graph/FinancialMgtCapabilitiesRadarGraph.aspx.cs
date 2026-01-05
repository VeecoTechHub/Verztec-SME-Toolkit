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
using System.Globalization;
using System.Threading;

public partial class FinancialMgtCapabilitiesRadarGraph : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    Report_BLL bll = new Report_BLL();
    UserMgmt objUserMgmt = new UserMgmt();

    string strYourScore = string.Empty;
    string strlblHowSerious = string.Empty;
    string strlblHowMuch = string.Empty;
    string strlblHow1 = string.Empty;
    string strlblHow2 = string.Empty;
    string strlblHow3 = string.Empty;
    string strlblImpro = string.Empty;
    string strlblAvg = string.Empty;
    string strlblExcellent = string.Empty;

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
                ViewState["IndustryId"] = objLoginDTO.IndustryID;
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();

               // ViewState["PreviousPage"] = Request.UrlReferrer;

            }

            //bindChart();
            bindChart_health();

            //Added by Mahesh to Insert ModuleTrack Records
            //Added on 06/06/2012
            objUserMgmt.UserID = ViewState["UserID"].ToString();
            objUserMgmt.AccessBy = Session["USER_ID"].ToString();
            objUserMgmt.CategoryId = 3;
            objUserMgmt.PageView = "Y";
            objUserMgmt.AccessDescription = "Access FinancialMgtCapabilitiesRadarGraph page";
            objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                objUserMgmt.Culture = 2;
            else
                objUserMgmt.Culture = 1;
            objUserMgmt.InsertModuleTrack(objUserMgmt);
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

    //private DataTable createTable_health()
    //{

    //    DataSet ds = bll.getReport_GetFinancialMgtRatingPercentage(Convert.ToString(ViewState["UserID"]));
    //    DataTable dtTemp = new DataTable();
    //    try
    //    {

    //        DataColumn dcXaxis = new DataColumn("X Axis");
    //        DataColumn dcYours = new DataColumn("Yours");
    //        DataColumn dcHigh = new DataColumn("High");


    //        dtTemp.Columns.Add(dcXaxis);
    //        dtTemp.Columns.Add(dcYours);
    //        dtTemp.Columns.Add(dcHigh);




    //        DataRow dr1 = dtTemp.NewRow();
    //        dr1["X Axis"] = "How well do you manage your suppliers & purchases?";

    //        if (ds.Tables.Count > 0)
    //        {
    //            dr1["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()).ToString("0000.0");


    //            double a = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
    //            dr1["High"] = Convert.ToDecimal(a).ToString("0000.0");


    //            dtTemp.Rows.Add(dr1);

    //            DataRow dr2 = dtTemp.NewRow();
    //            dr2["X Axis"] = "How well do you manage your credit exposures & collections?";


    //            dr2["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][1].ToString()).ToString("0000.0");
    //            double b = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
    //            dr2["High"] = Convert.ToDecimal(b).ToString("0000.0");


    //            dtTemp.Rows.Add(dr2);

    //            DataRow dr3 = dtTemp.NewRow();
    //            dr3["X Axis"] = "How well do you manage your Inventories?";
    //            dr3["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString()).ToString("0000.0");
    //            double c = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString());
    //            dr3["High"] = Convert.ToDecimal(c).ToString("0000.0");

    //            dtTemp.Rows.Add(dr3);

    //            DataRow dr4 = dtTemp.NewRow();
    //            dr4["X Axis"] = "How much do you utilise management report to help you in decision making?";
    //            dr4["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString()).ToString("0000.0");
    //            double d = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
    //            dr4["High"] = Convert.ToDecimal(d).ToString("0000.0");

    //            dtTemp.Rows.Add(dr4);


    //            DataRow dr5 = dtTemp.NewRow();
    //            dr5["X Axis"] = "How serious \n do you take your  Business Plan & Budget?";
    //            dr5["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString()).ToString("0000.0");
    //            double e = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
    //            dr5["High"] = Convert.ToDecimal(e).ToString("0000.0");

    //            dtTemp.Rows.Add(dr5);


    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return dtTemp;
    //}

    private DataTable createTable_health()
    {
        // Chart Titles
        strYourScore = Convert.ToString(GetLocalResourceObject("lblYourScoreResource1.Text"));

        // Business Profiling Chart data
        strlblHowSerious = Convert.ToString(GetLocalResourceObject("lblHowSeriousResource1.Text"));
        strlblHowMuch = Convert.ToString(GetLocalResourceObject("lblHowMuchResource1.Text"));
        strlblHow1 = Convert.ToString(GetLocalResourceObject("lblHow1Resource1.Text"));
        strlblHow2 = Convert.ToString(GetLocalResourceObject("lblHow2Resource1.Text"));
        strlblHow3 = Convert.ToString(GetLocalResourceObject("lblHow3Resource1.Text"));
        strlblImpro = Convert.ToString(GetLocalResourceObject("lblImproResource1.Text"));
        strlblAvg = Convert.ToString(GetLocalResourceObject("lblAvgResource1.Text"));
        strlblExcellent = Convert.ToString(GetLocalResourceObject("lblExcellentResource1.Text"));


        FinancialChart.Titles[0].Text = strYourScore;

        CustomLabel lblImpro = new CustomLabel();
        CustomLabel lblAvarage = new CustomLabel();
        CustomLabel lblExcellent = new CustomLabel();

        lblImpro.Text = strlblImpro;
        lblImpro.FromPosition = -50;
        lblImpro.ToPosition = 50;

        lblAvarage.Text = strlblAvg;
        lblAvarage.FromPosition = 100;

        lblExcellent.Text = strlblExcellent;
        lblExcellent.FromPosition = 200;

        FinancialChart.ChartAreas[0].AxisY.CustomLabels.Add(lblImpro);
        FinancialChart.ChartAreas[0].AxisY.CustomLabels.Add(lblAvarage);
        FinancialChart.ChartAreas[0].AxisY.CustomLabels.Add(lblExcellent);

        DataSet ds = bll.getReport_GetFinancialMgtRatingPercentage(Convert.ToString(ViewState["UserID"]));
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
          //  dr1["X Axis"] = "How well do you manage \n  your suppliers \n & purchases?";
            dr1["X Axis"] = strlblHow3;

            if (ds.Tables.Count > 0)
            {
                dr1["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()).ToString("0000.0");


                double a = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                dr1["High"] = Convert.ToDecimal(a).ToString("0000.0");


                dtTemp.Rows.Add(dr1);

                DataRow dr2 = dtTemp.NewRow();
               // dr2["X Axis"] = "How well do you manage \n your credit exposures \n & collections?";
                dr2["X Axis"] = strlblHow2;


                dr2["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][1].ToString()).ToString("0000.0");
                double b = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                dr2["High"] = Convert.ToDecimal(b).ToString("0000.0");


                dtTemp.Rows.Add(dr2);

                DataRow dr3 = dtTemp.NewRow();
               // dr3["X Axis"] = "How well do you manage \n your Inventories?";
                dr3["X Axis"] = strlblHow1;
                dr3["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString()).ToString("0000.0");
                double c = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString());
                dr3["High"] = Convert.ToDecimal(c).ToString("0000.0");

              

                dtTemp.Rows.Add(dr3);

                DataRow dr4 = dtTemp.NewRow();
              //  dr4["X Axis"] = "How much do you utilise \n management report to  help \n you in decision making?";
                dr4["X Axis"] = strlblHowMuch;
                dr4["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString()).ToString("0000.0");
                double d = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                dr4["High"] = Convert.ToDecimal(d).ToString("0000.0");

            

                dtTemp.Rows.Add(dr4);


                DataRow dr5 = dtTemp.NewRow();
              //  dr5["X Axis"] = "How serious do you take \n your  Business Plan \n & Budget?";
                dr5["X Axis"] = strlblHowSerious;
                dr5["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString()).ToString("0000.0");
                double e = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
                dr5["High"] = Convert.ToDecimal(e).ToString("0000.0");


                dtTemp.Rows.Add(dr5);
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

            /// at present to using.. means not binding the graph as like health profling....
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
            //FinancialChart.Font.Name = "Microsoft Sans Serif";

            FinancialChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            FinancialChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            FinancialChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            FinancialChart.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9f);
            FinancialChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9f);

            //FinancialChart.Legends["Legend1"].Position = System.Drawing.StringAlignment.Near;


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion health
    //protected void btnBack_Click(object sender, ImageClickEventArgs e)
    //{
    //    //if (ViewState["PreviousPage"] != null)
    //    //{
    //       // Response.Redirect(ViewState["PreviousPage"].ToString());
           
    //    //}
    //    Response.Redirect("~/Public/FinancialMgtCapabilities.aspx");
    //}
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Public/FinancialMgtCapabilities.aspx");
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