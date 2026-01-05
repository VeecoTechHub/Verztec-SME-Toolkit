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

public partial class RadarGraph : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    Report_BLL bll = new Report_BLL();
    UserMgmt objUserMgmt = new UserMgmt();

    string strlblBusinessProfi = string.Empty;
    string strlblGroandGlo = string.Empty;
    string strlblSurvival = string.Empty;
    string strlblRej = string.Empty;
    string strlblGrowingPlan = string.Empty;
    string strlblYourScore = string.Empty;
    string strlblYourCashFLow = string.Empty;
    string strlblProfi = string.Empty;
    string strlblYourComp = string.Empty;
    string strlblYourRating = string.Empty;
    string strlblWeak = string.Empty;
    string strlblAvarage = string.Empty;
    string strlblStrong = string.Empty;

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
                //ViewState["PreviousPage"] = Request.UrlReferrer;

                //Added by Mahesh to Insert ModuleTrack Records
                //Added on 06/06/2012
                objUserMgmt.UserID = ViewState["UserID"].ToString();
                objUserMgmt.AccessBy = Session["USER_ID"].ToString();
                objUserMgmt.CategoryId = 2;
                objUserMgmt.PageView = "Y";
                objUserMgmt.AccessDescription = "Access Radar Graph page";
                objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                if (Convert.ToString(Session["Culture"]) == "zh-SG")
                    objUserMgmt.Culture = 2;
                else
                    objUserMgmt.Culture = 1;
                objUserMgmt.InsertModuleTrack(objUserMgmt);
            }

          //  bindChart();
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

            Chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9f);
            Chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9f);
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
        // Chart Titles
        strlblBusinessProfi = Convert.ToString(GetLocalResourceObject("lblBusinessProfiResource1.Text"));
        strlblYourScore = Convert.ToString(GetLocalResourceObject("lblYourScoreResource1.Text"));

        // Business Profiling Chart data
        strlblGroandGlo = Convert.ToString(GetLocalResourceObject("lblGroandGloResource1.Text"));
        strlblSurvival = Convert.ToString(GetLocalResourceObject("lblSurvivalResource1.Text"));
        strlblRej = Convert.ToString(GetLocalResourceObject("lblRejResource1.Text"));
        strlblGrowingPlan = Convert.ToString(GetLocalResourceObject("lblGrowingPlanResource1.Text"));

        // Your Score Chart data
        strlblYourCashFLow = Convert.ToString(GetLocalResourceObject("lblYourCashFLowResource1.Text"));
        strlblProfi = Convert.ToString(GetLocalResourceObject("lblProfiResource1.Text"));
        strlblYourComp = Convert.ToString(GetLocalResourceObject("lblYourCompResource1.Text"));
        strlblYourRating = Convert.ToString(GetLocalResourceObject("lblYourRatingResource1.Text"));
        strlblWeak = Convert.ToString(GetLocalResourceObject("lblWeakResource1.Text"));
        strlblAvarage = Convert.ToString(GetLocalResourceObject("lblAvarageResource1.Text"));
        strlblStrong = Convert.ToString(GetLocalResourceObject("lblStrongResource1.Text"));


        Chart1.Titles[0].Text = strlblBusinessProfi;
        FinancialChart.Titles[0].Text = strlblYourScore;

        CustomLabel lblWeek = new CustomLabel();
        CustomLabel lblAvarage = new CustomLabel();
        CustomLabel lblStrong = new CustomLabel();

        lblWeek.Text = strlblWeak;
        lblWeek.FromPosition = -20;
        lblWeek.ToPosition = 20;

        lblAvarage.Text = strlblAvarage;
        lblAvarage.FromPosition = 100;

        lblStrong.Text = strlblStrong;
        lblStrong.FromPosition = 200;

        FinancialChart.ChartAreas[0].AxisY.CustomLabels.Add(lblWeek);
        FinancialChart.ChartAreas[0].AxisY.CustomLabels.Add(lblAvarage);
        FinancialChart.ChartAreas[0].AxisY.CustomLabels.Add(lblStrong);
    
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
           // dr1["X Axis"] = "Your rating of the external \n environment";
            dr1["X Axis"] = strlblYourRating;
            if (ds.Tables.Count > 0)
            {
                dr1["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()).ToString("0000.0");

                //dr1["High"] = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                double a = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                dr1["High"] = Convert.ToDecimal(a).ToString("0000.0");


                dtTemp.Rows.Add(dr1);

                DataRow dr2 = dtTemp.NewRow();
            //    dr2["X Axis"] = "Your competitive edge \n rating";
                dr2["X Axis"] = strlblYourComp;
                dr2["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][1].ToString()).ToString("0000.0");
                double b = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                dr2["High"] = Convert.ToDecimal(b).ToString("0000.0");


                dtTemp.Rows.Add(dr2);

                DataRow dr3 = dtTemp.NewRow();
              //  dr3["X Axis"] = "Your profitability rating";
                dr3["X Axis"] = strlblProfi;
                dr3["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString()).ToString("0000.0");
                double c = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString());
                dr3["High"] = Convert.ToDecimal(c).ToString("0000.0");

                dtTemp.Rows.Add(dr3);

                DataRow dr4 = dtTemp.NewRow();
              //  dr4["X Axis"] = "Your cash flow liquidity \n rating";
                dr4["X Axis"] = strlblYourCashFLow;
                dr4["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString()).ToString("0000.0");
                double d = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                dr4["High"] = Convert.ToDecimal(d).ToString("0000.0");

                dtTemp.Rows.Add(dr4);

                string strCode=string.Empty;
                if (ds.Tables[0].Rows[0][0].ToString() != null && ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 50)
                    {
                        strCode = "H";
                    }
                    else
                    {
                        strCode = "L";
                    }
                }
                if (ds.Tables[0].Rows[0][1].ToString() != null && ds.Tables[0].Rows[0][1].ToString() != "")
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][1]) > 50)
                    {
                        strCode = strCode + "H";
                    }
                    else
                    {
                        strCode = strCode + "L";
                    }
                }
                if (ds.Tables[0].Rows[0][2].ToString() != null && ds.Tables[0].Rows[0][2].ToString() != "")
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][2]) > 50)
                    {
                        strCode = strCode + "H";
                    }
                    else
                    {
                        strCode = strCode + "L";
                    }
                }
                if (ds.Tables[0].Rows[0][3].ToString() != null && ds.Tables[0].Rows[0][3].ToString() != "")
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][3]) > 50)
                    {
                        strCode = strCode + "H";
                    }
                    else
                    {
                        strCode = strCode + "L";
                    }
                }
                for (int index = 0; index <= ds.Tables[1].Rows.Count - 1; index++)
                {
                    if (strCode == ds.Tables[1].Rows[index][1].ToString())
                    {
                        double[] yValues = { 1 + Convert.ToDouble(ds.Tables[1].Rows[index][2].ToString()), 1 + Convert.ToDouble(ds.Tables[1].Rows[index][3].ToString()), 1 + Convert.ToDouble(ds.Tables[1].Rows[index][4].ToString()), 1 + Convert.ToDouble(ds.Tables[1].Rows[index][5].ToString()) };

                      //  string[] xValues = { "Growing & Glowing", "Growing Pain ", "Rejuvenation needed", "Survival at risk" };
                        string[] xValues = { strlblGroandGlo, strlblGrowingPlan, strlblRej, strlblSurvival };
                        Chart1.Series["Series1"].Points.DataBindXY(xValues, yValues);

                        Chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9f);
                        Chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9f);

                    }
                }

           


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
            //FinancialChart.Series["Yours"].Font.Name = System.Drawing.Font("Microsoft Sans Serif ", "Microsoft Sans Serif ");
            //FinancialChart.Series["Yours"].Font.Name. = "Microsoft Sans Serif ";
            FinancialChart.Series["High"].Points.DataBindXY(firstView, "X Axis", firstView, "High");

            formatSeries_health(SeriesChartType.StackedBar, "Yours", MarkerStyle.Circle);
            formatSeries_health(SeriesChartType.StackedBar, "High", MarkerStyle.Circle);


            FinancialChart.Series["Yours"]["StackedGroupName"] = "Group2";
            FinancialChart.Series["High"]["StackedGroupName"] = "Group2";

            
           // FontInfo Font1 ;
            
           // FontInfo ff = new FontInfo();
            //Font1.Name = "Microsoft Sans Serif ";
            FinancialChart.Font.Name = "Arial";
            //FinancialChart.Font.Bold = true;
            //FinancialChart.Font.Italic = true;


            FinancialChart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            FinancialChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            FinancialChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            FinancialChart.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 9f);
            FinancialChart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 9f);


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
    //    //    Response.Redirect(ViewState["PreviousPage"].ToString());
    //    //}
    //}

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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Public/PublicHealthProfiling.aspx");

    }

  
}