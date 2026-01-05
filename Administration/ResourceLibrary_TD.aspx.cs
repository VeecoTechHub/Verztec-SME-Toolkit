using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Administration_ResourceLibrary_TD : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    Check_Access chkAccess = new Check_Access();
    public static string token;
    DataSet ds_Search = null;
    int total1 = 0;
    int total2 = 0;
    int total3 = 0;
    int total4 = 0;
    int total5 = 0;
    int total6 = 0;
    int total7 = 0;
    int total8 = 0;
    int total9 = 0;
    int total10 = 0;
    int total11 = 0;
    int total12 = 0;

    int dlbl1 = 0;
    int dlbl2 = 0;
    int dlbl3 = 0;
    int dlbl4 = 0;
    int dlbl5 = 0;
    int dlbl6 = 0;
    int dlbl7 = 0;
    int dlbl8 = 0;
    int dlbl9 = 0;
    int dlbl10 = 0;
    int dlbl11 = 0;
    int dlbl12 = 0;


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
                if (Session["GROUP_ID"] == null || Session["GROUP_ID"].ToString().ToUpper() != "ADMIN")
                {
                    Response.Redirect("~/Administration/Default.aspx");
                    return;
                }
                DateTime maxDate = DateTime.Today;
                DatePicker_StartDate.MaxDate = maxDate;
                DatePicker_EndDate.MaxDate = maxDate;
                BindGrid();

            }

        }
    }

    public void BindGrid()
    {
        try
        {
            trafficAnalysis.PostedBy = txtName.Text.ToString();

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
            //DataSet ds_Search = trafficAnalysis.GET_TrafficAnalysis_Login();
            ds_Search = trafficAnalysis.Get_ResLib_TemplateDownloaded(trafficAnalysis);
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

                for (int index = 0; index < ds_Search.Tables[0].Rows.Count; index++)
                {
                    int flag = 1;
                    int totalcount = 0;
                    for (int cindex = 3; cindex <= ds_Search.Tables[0].Columns.Count - 1; cindex++)
                    {
                        if (ds_Search.Tables[0].Rows[index][cindex].ToString() != "0")
                        {
                            flag = 0;
                            totalcount += Convert.ToInt32(ds_Search.Tables[0].Rows[index][cindex].ToString());
                        }
                    }
                    if (flag == 1)
                    {
                        ds_Search.Tables[0].Rows[index].Delete();
                        //ds_Search.Tables.Add(new DataTable());
                        // ds_Search.Tables[0].Columns.Add("SubTotal", typeof(string));
                        //ds_Search.Tables[0].Rows[index]["SubTotal"] = "abc";


                    }
                    else
                    {
                        ds_Search.Tables[0].Rows[index]["SUBTOTAL"] = totalcount.ToString();
                    }
                }



                ViewState["dsData"] = ds_Search;
                gvTrafficAnalysisLogin.DataSource = ds_Search;
                gvTrafficAnalysisLogin.DataBind();

                //gvExport.DataSource = ds_Search;
                // gvExport.DataBind();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=ResourceLibrary_TemplateDownload.xls");

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
            //Label lbl1 = (Label)e.Row.FindControl("lbl_BPT"); // total : lblTotalBPT
            //Label lbl2 = (Label)e.Row.FindControl("lbl_BSPL"); // lblTotalBSPL
            //Label lbl3 = (Label)e.Row.FindControl("lbl_ProfitandLoss");//lblTotalProfitandLoss
            //Label lbl4 = (Label)e.Row.FindControl("lbl_Cashflowforecast"); //lblTotalCashflowforecast
            //Label lbl5 = (Label)e.Row.FindControl("lbl_Flashreports"); //lblTotalFlashreports
            //Label lbl6 = (Label)e.Row.FindControl("lbl_Financialratios"); //lblTotalFinancialratios
            //Label lbl7 = (Label)e.Row.FindControl("lbl_TradeCycleCalculator");//lblTotalTradeCycleCalculator
            //Label lbl8 = (Label)e.Row.FindControl("lbl_LoanCalculator"); //lblTotalLoanCalculator
            //Label lbl9 = (Label)e.Row.FindControl("lbl_Stockbalancerecord");//lblTotalStockbalancerecord
            //Label lbl10 = (Label)e.Row.FindControl("lbl_Fixedassetssummary"); //lblTotalFixedassetssummary
            //Label lbl11 = (Label)e.Row.FindControl("lbl_Fixedassetsregister"); //lblTotalFixedassetsregister
            //Label lbl12 = (Label)e.Row.FindControl("lbl_ChartofAccounts"); //lblTotalChartofAccounts


            ////for (int i = 0; i < 11; i++)
            ////{
            ////    int count= i+1;
            ////    string strval="lbl" + count.ToString();

            ////}

            //if (lbl1.Text != "" && lbl1.Text != null)
            //    dlbl1 = Convert.ToInt32(lbl1.Text);
            //else
            //    dlbl1 = 0;

            //if (lbl2.Text != "" && lbl2.Text != null)
            //    dlbl2 = Convert.ToInt32(lbl2.Text);
            //else
            //    dlbl2 = 0;

            //if (lbl3.Text != "" && lbl3.Text != null)
            //    dlbl3 = Convert.ToInt32(lbl3.Text);
            //else
            //    dlbl3 = 0;

            //if (lbl3.Text != "" && lbl3.Text != null)
            //    dlbl3 = Convert.ToInt32(lbl3.Text);
            //else
            //    dlbl3 = 0;


            //total1 += dlbl1;
            //total2 += dlbl2;
            //total3 += dlbl3;

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            Label lbl1 = (Label)e.Row.FindControl("lblTotalBPT");
            Label lbl2 = (Label)e.Row.FindControl("lblTotalBSPL");
            Label lbl3 = (Label)e.Row.FindControl("lblTotalProfitandLoss");
            Label lbl4 = (Label)e.Row.FindControl("lblTotalCashflowforecast");
            Label lbl5 = (Label)e.Row.FindControl("lblTotalFlashreports");
            Label lbl6 = (Label)e.Row.FindControl("lblTotalFinancialratios");
            Label lbl7 = (Label)e.Row.FindControl("lblTotalTradeCycleCalculator");
            Label lbl8 = (Label)e.Row.FindControl("lblTotalLoanCalculator");
            Label lbl9 = (Label)e.Row.FindControl("lblTotalStockbalancerecord");
            Label lbl10 = (Label)e.Row.FindControl("lblTotalFixedassetssummary");
            Label lbl11 = (Label)e.Row.FindControl("lblTotalFixedassetsregister");
            Label lbl12 = (Label)e.Row.FindControl("lblTotalChartofAccounts");

            lbl1.Text = ds_Search.Tables[0].Compute("SUM(BusinessPlanTemplate)", string.Empty).ToString();
            lbl2.Text = ds_Search.Tables[0].Compute("SUM(BSPL)", string.Empty).ToString();
            lbl3.Text = ds_Search.Tables[0].Compute("SUM(ProfitLoss)", string.Empty).ToString();
            lbl4.Text = ds_Search.Tables[0].Compute("SUM(Cashflowforecast)", string.Empty).ToString();
            lbl5.Text = ds_Search.Tables[0].Compute("SUM(Flashreports)", string.Empty).ToString();
            lbl6.Text = ds_Search.Tables[0].Compute("SUM(Financialratios)", string.Empty).ToString();
            lbl7.Text = ds_Search.Tables[0].Compute("SUM(TradeCycleCalculator)", string.Empty).ToString();
            lbl8.Text = ds_Search.Tables[0].Compute("SUM(LoanCalculato)", string.Empty).ToString();
            lbl9.Text = ds_Search.Tables[0].Compute("SUM(Stockbalancerecord)", string.Empty).ToString();
            lbl10.Text = ds_Search.Tables[0].Compute("SUM(Fixedassetssummary)", string.Empty).ToString();
            lbl11.Text = ds_Search.Tables[0].Compute("SUM(Fixedassetsregister)", string.Empty).ToString();
            lbl12.Text = ds_Search.Tables[0].Compute("SUM(ChartofAccounts)", string.Empty).ToString();


            //RIGHT SIDE FOOTER TOTOAL...
            Label lblTotalFooter = (Label)e.Row.FindControl("lblTotalFooter");
            lblTotalFooter.Text = ds_Search.Tables[0].Compute("SUM(SUBTOTAL)", string.Empty).ToString();
        }
    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
}
