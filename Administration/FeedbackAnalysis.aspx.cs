using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Administration_FeedbackAnalysis : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    Check_Access chkAccess = new Check_Access();
    public static string token;
    DataTable dtData = new DataTable();

    int intCount = 0;
    int tempExc = 0;
    int tempaboveEvr = 0;
    int tempAverage = 0;
    int tempGood = 0;
    int tempPoor = 0;
    int tempExc_Total = 0;
    int tempaboveEvr_Total = 0;
    int tempAverage_Total = 0;
    int tempGood_Total = 0;
    int tempPoor_Total = 0;

    int Row_Total = 0;


    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {

            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            token = Request.Form["token"];
            //ViewState["t_url"] = "Admin_NextSteps.aspx";
            if (token == null)
            {
                Response.Redirect("default.aspx");
            }

            else
            {
                DateTime maxDate = DateTime.Today;
                DatePicker_StartDate.MaxDate = maxDate;
                DatePicker_EndDate.MaxDate = maxDate;
                FillDropDowns();
                BindGrid();

            }

        }
    }
    private void FillDropDowns()
    {
        try
        {
            string Culture = Convert.ToString(Session["Culture"]);
            // Code to bind Nature of Business and Industry
            DataSet dsItems = trafficAnalysis.GetItemsDetails(Culture);
            if (dsItems != null && dsItems.Tables.Count > 0)
            {
                ddlIndustry.DataSource = dsItems.Tables[0];
                ddlIndustry.DataTextField = "IndustryNames";
                ddlIndustry.DataValueField = "ID";
                ddlIndustry.DataBind();
            }
            // End Code
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void BindGrid()
    {
        //try
        //{
        //trafficAnalysis.PostedBy = txtName.Text.ToString();
        trafficAnalysis.IndustryID = Convert.ToInt32(ddlIndustry.SelectedValue);
        if (DatePicker_StartDate.DateString == "")
        {
            trafficAnalysis.StartDate = null;
        }
        else
        {
            trafficAnalysis.StartDate = Convert.ToString(DatePicker_StartDate.Date);
        }
        if (DatePicker_EndDate.DateString == "")
        {
            trafficAnalysis.EndDate = null;
        }
        else
        {
            trafficAnalysis.EndDate = Convert.ToString(DatePicker_EndDate.Date);
        }
        DataSet ds_Search = trafficAnalysis.Get_FeedbackAnalysis(trafficAnalysis);
        if (ds_Search.Tables[0].Rows.Count > 0)
        {
            lblError.Visible = false;
            btnExptoExcel.Visible = true;
            tdSelect.Visible = true;
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "  No Data Available";
            btnExptoExcel.Visible = false;
            tdSelect.Visible = false;
            gvTrafficAnalysisLogin.DataBind();

        }
        if (ds_Search.Tables[0].Rows.Count != 0)
        {

            ///creating data table...
            ///
            dtData.Columns.Add(new DataColumn("IndustryName", typeof(string)));
            dtData.Columns.Add(new DataColumn("QuestionName", typeof(string)));
            dtData.Columns.Add(new DataColumn("Excellent", typeof(string)));
            dtData.Columns.Add(new DataColumn("AboveAverage", typeof(string)));
            dtData.Columns.Add(new DataColumn("Average", typeof(string)));
            dtData.Columns.Add(new DataColumn("Good", typeof(string)));
            dtData.Columns.Add(new DataColumn("Poor", typeof(string)));
            dtData.Columns.Add(new DataColumn("subtotal", typeof(string)));
            dtData.Columns.Add(new DataColumn("isTotal", typeof(string)));


            DataRow dr;
            int count = 0;
            string subTotal_Strong = string.Empty;
            string subTotal_AboveAverage = string.Empty;
            string subTotal_Average = string.Empty;
            string subTotal_Good = string.Empty;
            string subTotal_Poor = string.Empty;

            for (int index = 0; index < ds_Search.Tables[0].Rows.Count; index++)
            {
                if (index == ds_Search.Tables[0].Rows.Count - 1)
                {
                    subTotal_Strong = ds_Search.Tables[0].Compute("SUM(Excellent)", "IndustryName ='" + ds_Search.Tables[0].Rows[index]["IndustryName"].ToString() + "'").ToString();
                    subTotal_AboveAverage = ds_Search.Tables[0].Compute("SUM([Above Average])", "IndustryName ='" + ds_Search.Tables[0].Rows[index]["IndustryName"].ToString() + "'").ToString();
                    subTotal_Average = ds_Search.Tables[0].Compute("SUM(Average)", "IndustryName ='" + ds_Search.Tables[0].Rows[index]["IndustryName"].ToString() + "'").ToString();
                    subTotal_Good = ds_Search.Tables[0].Compute("SUM(Good)", "IndustryName ='" + ds_Search.Tables[0].Rows[index]["IndustryName"].ToString() + "'").ToString();
                    subTotal_Poor = ds_Search.Tables[0].Compute("SUM(Poor)", "IndustryName ='" + ds_Search.Tables[0].Rows[index]["IndustryName"].ToString() + "'").ToString();
                }
                if (index == 0)
                {
                    ViewState["IndustryName"] = "Nothing";

                    //dr = dtData.NewRow();
                    //count = count + 1;
                    //dr["IndustryName"] = ds_Search.Tables[0].Rows[index]["IndustryName"].ToString();
                    //dr["QuestionName"] = ds_Search.Tables[0].Rows[index]["QuestionName"].ToString();
                    //dr["Excellent"] = ds_Search.Tables[0].Rows[index]["Excellent"].ToString();
                    //dr["AboveAverage"] = ds_Search.Tables[0].Rows[index]["Above Average"].ToString();
                    //dr["Average"] = ds_Search.Tables[0].Rows[index]["Average"].ToString();
                    //dr["Good"] = ds_Search.Tables[0].Rows[index]["Good"].ToString();
                    //dr["Poor"] = ds_Search.Tables[0].Rows[index]["Poor"].ToString();
                    //dr["subtotal"] = ds_Search.Tables[0].Rows[index]["QuestionName"].ToString();
                    //dtData.Rows.Add(dr);
                }
                //Self Evaluation - Financial Management Discipline 
                if (ViewState["IndustryName"].ToString().Equals(ds_Search.Tables[0].Rows[index]["IndustryName"].ToString()) || index == 0)
                {
                    ViewState["IndustryName"] = ds_Search.Tables[0].Rows[index]["IndustryName"].ToString();
                    dr = dtData.NewRow();
                    dr["IndustryName"] = ds_Search.Tables[0].Rows[index]["IndustryName"].ToString();
                    dr["QuestionName"] = ds_Search.Tables[0].Rows[index]["QuestionName"].ToString();
                    dr["Excellent"] = ds_Search.Tables[0].Rows[index]["Excellent"].ToString();
                    dr["AboveAverage"] = ds_Search.Tables[0].Rows[index]["Above Average"].ToString();
                    dr["Average"] = ds_Search.Tables[0].Rows[index]["Average"].ToString();
                    dr["Good"] = ds_Search.Tables[0].Rows[index]["Good"].ToString();
                    dr["Poor"] = ds_Search.Tables[0].Rows[index]["Poor"].ToString();
                    dr["subtotal"] = "";
                    dr["isTotal"] = "NO";
                    dtData.Rows.Add(dr);
                }
                else
                {
                    ViewState["IndustryName"] = ds_Search.Tables[0].Rows[index]["IndustryName"].ToString();
                    dr = dtData.NewRow();
                    count = count + 1;
                    dr["IndustryName"] = "";
                    dr["QuestionName"] = "Total";
                    dr["Excellent"] = ds_Search.Tables[0].Compute("SUM(Excellent)", "IndustryName ='" + ds_Search.Tables[0].Rows[index - 1]["IndustryName"].ToString() + "'").ToString();
                    dr["AboveAverage"] = ds_Search.Tables[0].Compute("SUM([Above Average])", "IndustryName ='" + ds_Search.Tables[0].Rows[index - 1]["IndustryName"].ToString() + "'").ToString();
                    dr["Average"] = ds_Search.Tables[0].Compute("SUM(Average)", "IndustryName ='" + ds_Search.Tables[0].Rows[index - 1]["IndustryName"].ToString() + "'").ToString();
                    dr["Good"] = ds_Search.Tables[0].Compute("SUM(Good)", "IndustryName ='" + ds_Search.Tables[0].Rows[index - 1]["IndustryName"].ToString() + "'").ToString();
                    dr["Poor"] = ds_Search.Tables[0].Compute("SUM(Poor)", "IndustryName ='" + ds_Search.Tables[0].Rows[index - 1]["IndustryName"].ToString() + "'").ToString();
                    dr["subtotal"] = "";
                    dr["isTotal"] = "YES";
                    dtData.Rows.Add(dr);


                    dr = dtData.NewRow();
                    count = count + 1;
                    dr["IndustryName"] = "";
                    dr["QuestionName"] = "Average";
                    dr["Excellent"] = "avg";
                    dr["AboveAverage"] = "avg";
                    dr["Average"] = "avg";
                    dr["Good"] = "avg";
                    dr["Poor"] = "avg";
                    dr["subtotal"] = "";
                    dr["isTotal"] = "YES_AVG";
                    dtData.Rows.Add(dr);


                    dr = dtData.NewRow();
                    count = count + 1;
                    dr["IndustryName"] = ds_Search.Tables[0].Rows[index]["IndustryName"].ToString();
                    dr["QuestionName"] = ds_Search.Tables[0].Rows[index]["QuestionName"].ToString();
                    dr["Excellent"] = ds_Search.Tables[0].Rows[index]["Excellent"].ToString();
                    dr["AboveAverage"] = ds_Search.Tables[0].Rows[index]["Above Average"].ToString();
                    dr["Average"] = ds_Search.Tables[0].Rows[index]["Average"].ToString();
                    dr["Good"] = ds_Search.Tables[0].Rows[index]["Good"].ToString();
                    dr["Poor"] = ds_Search.Tables[0].Rows[index]["Poor"].ToString();
                    dr["subtotal"] = "";
                    dr["isTotal"] = "NO";
                    dtData.Rows.Add(dr);


                }
            }

            dr = dtData.NewRow();
            count = count + 1;
            dr["IndustryName"] = "";
            dr["QuestionName"] = "Total";
            dr["Excellent"] = subTotal_Strong.ToString();
            dr["AboveAverage"] = subTotal_AboveAverage;
            dr["Average"] = subTotal_Average;
            dr["Good"] = subTotal_Good;
            dr["Poor"] = subTotal_Poor;
            dr["subtotal"] = "subtotal";
            dr["isTotal"] = "YES";
            dtData.Rows.Add(dr);


            dr = dtData.NewRow();
            count = count + 1;
            dr["IndustryName"] = "";
            dr["QuestionName"] = "Average";
            dr["Excellent"] = "avg";
            dr["AboveAverage"] = "avg";
            dr["Average"] = "avg";
            dr["Good"] = "avg";
            dr["Poor"] = "avg";
            dr["subtotal"] = "";
            dr["isTotal"] = "YES_AVG";
            dtData.Rows.Add(dr);

            gvTrafficAnalysisLogin.DataSource = dtData;
            gvTrafficAnalysisLogin.DataBind();

        }





    }


    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=FeedbackAnalysis.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvTrafficAnalysisLogin.RenderControl(htmlWrite);     //throwing error 

        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {

        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.

    }

    protected void btnExptoExcel_Click(object sender, ImageClickEventArgs e)
    {
        ExportToExcel();
    }

    protected void gvTrafficAnalysisLogin_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            tempExc = 0;
            tempaboveEvr = 0;
            //tempExc_Total = 0;
            Label lbl_isTotal = (Label)e.Row.FindControl("lbl_isTotal");
            if (lbl_isTotal.Text.Equals("NO"))
            {
                Label lbl_Excellent = (Label)e.Row.FindControl("lbl_Excellent");
                Label lbl_AboveAverage = (Label)e.Row.FindControl("lbl_AboveAverage");
                Label lbl_Average = (Label)e.Row.FindControl("lbl_Average");
                Label lbl_Good = (Label)e.Row.FindControl("lbl_Good");
                Label lbl_poor = (Label)e.Row.FindControl("lbl_poor");
                Label lbl_SubTotal = (Label)e.Row.FindControl("lbl_SubTotal");

                if (lbl_Excellent.Text != "" && lbl_Excellent.Text != null)
                    tempExc = Convert.ToInt32(lbl_Excellent.Text);
                else
                    tempExc = 0;

                if (lbl_AboveAverage.Text != "" && lbl_AboveAverage.Text != null)
                    tempaboveEvr = Convert.ToInt32(lbl_AboveAverage.Text);
                else
                    tempaboveEvr = 0;

                if (lbl_Average.Text != "" && lbl_Average.Text != null)
                    tempAverage = Convert.ToInt32(lbl_Average.Text);
                else
                    tempAverage = 0;

                if (lbl_Good.Text != "" && lbl_Good.Text != null)
                    tempGood = Convert.ToInt32(lbl_Good.Text);
                else
                    tempGood = 0;

                if (lbl_poor.Text != "" && lbl_poor.Text != null)
                    tempPoor = Convert.ToInt32(lbl_poor.Text);
                else
                    tempPoor = 0;


                tempExc_Total += tempExc;
                tempaboveEvr_Total += tempaboveEvr;
                tempAverage_Total += tempAverage;
                tempGood_Total += tempGood;
                tempPoor_Total += tempPoor;

                int subtotal_right = tempExc + tempaboveEvr + tempAverage + tempGood + tempPoor;
                Row_Total = tempExc_Total + tempaboveEvr_Total + tempAverage_Total + tempGood_Total + tempPoor_Total;
                lbl_SubTotal.Text = subtotal_right.ToString();


            }
            else if (lbl_isTotal.Text.Equals("YES"))
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[0].BorderStyle = BorderStyle.None;
                e.Row.BackColor = Color.FromName("#BEBEBE");
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

                Label lbl_SubTotal = (Label)e.Row.FindControl("lbl_SubTotal");
                lbl_SubTotal.Text = Row_Total.ToString();


            }
            else if (lbl_isTotal.Text.Equals("YES_AVG"))
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[0].BorderStyle = BorderStyle.None;
                e.Row.BackColor = Color.FromName("#BEBEBE");
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;

                Label lbl_Excellent = (Label)e.Row.FindControl("lbl_Excellent");
                Label lbl_AboveAverage = (Label)e.Row.FindControl("lbl_AboveAverage");
                Label lbl_Average = (Label)e.Row.FindControl("lbl_Average");
                Label lbl_Good = (Label)e.Row.FindControl("lbl_Good");
                Label lbl_poor = (Label)e.Row.FindControl("lbl_poor");
                // Response.Write(tempExc_Total.ToString());
                decimal tempavg = tempExc_Total * 100;
                decimal avg = 0;
                if (Row_Total > 0)
                {
                    avg = tempavg / Row_Total;
                }
                lbl_Excellent.Text = Math.Round(avg, 2) + "%";

                tempavg = tempaboveEvr_Total * 100;

                if (Row_Total > 0)
                avg = tempavg / Row_Total;

                lbl_AboveAverage.Text = Math.Round(avg, 2) + "%";


                tempavg = tempAverage_Total * 100;

                if (Row_Total > 0)
                avg = tempavg / Row_Total;

                lbl_Average.Text = Math.Round(avg, 2) + "%";


                tempavg = tempGood_Total * 100;

                if (Row_Total > 0)
                avg = tempavg / Row_Total;
                lbl_Good.Text = Math.Round(avg, 2) + "%";

                tempavg = tempPoor_Total * 100;

                if (Row_Total > 0)
                avg = tempavg / Row_Total;
                lbl_poor.Text = Math.Round(avg, 2) + "%";


                tempExc_Total = 0;
                tempaboveEvr = 0;
                Row_Total = 0;
                tempGood_Total = 0;
                tempaboveEvr_Total = 0;
                tempAverage_Total = 0;
                tempAverage = 0;
            }

            if (intCount == 1 || intCount == 2)
            {
                //e.Row.Cells[0].Text = "";
                // e.Row.Cells[0].BorderStyle = BorderStyle.None;

                if (intCount == 2)
                {
                    intCount = -1;
                }

            }
            intCount = intCount + 1; ;
        }


    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
}
