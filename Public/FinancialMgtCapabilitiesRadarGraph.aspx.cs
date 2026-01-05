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

public partial class FinancialMgtCapabilitiesRadarGraph : System.Web.UI.Page
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
           
                ViewState["PreviousPage"] = Request.UrlReferrer;

            }

            //bindChart();
            bindChart_health();
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
            dr1["X Axis"] = "How well do you manage your suppliers & purchases?";
          
            if (ds.Tables.Count > 0)
            {
                dr1["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()).ToString("0000.00");

                
                double a = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                dr1["High"] = Convert.ToDecimal(a).ToString("0000.00");


                dtTemp.Rows.Add(dr1);

                DataRow dr2 = dtTemp.NewRow();
                dr2["X Axis"] = "How well do you manage your credit exposures & collections?";
              

                dr2["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][1].ToString()).ToString("0000.00");
                double b = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
                dr2["High"] = Convert.ToDecimal(b).ToString("0000.00");


                dtTemp.Rows.Add(dr2);

                DataRow dr3 = dtTemp.NewRow();
                dr3["X Axis"] = "How well do you manage your Inventories?";
                              dr3["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][2].ToString()).ToString("0000.00");
                double c = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString());
                dr3["High"] = Convert.ToDecimal(c).ToString("0000.00");

                dtTemp.Rows.Add(dr3);

                DataRow dr4 = dtTemp.NewRow();
                dr4["X Axis"] = "How much do you utilise management report to help you in decision making?";
                               dr4["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][3].ToString()).ToString("0000.00");
                double d = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][3].ToString());
                dr4["High"] = Convert.ToDecimal(d).ToString("0000.00");

                dtTemp.Rows.Add(dr4);


                DataRow dr5 = dtTemp.NewRow();
                dr5["X Axis"] = "How serious do you take your  Business Plan & Budget?";
                               dr5["Yours"] = Convert.ToDecimal(ds.Tables[0].Rows[0][4].ToString()).ToString("0000.00");
                double e = 100 - Convert.ToDouble(ds.Tables[0].Rows[0][4].ToString());
                dr5["High"] = Convert.ToDecimal(e).ToString("0000.00");

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
           // Response.Redirect("~/Public/PublicHealthProfiling.aspx");
        }
    }
}