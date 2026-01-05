using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Administration_TrafficAnalysis_DetailedReport : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    Check_Access chkAccess = new Check_Access();
    public static string token;
    DataTable dtData = new DataTable();
    DataSet ds_Search;

 
    int count = 0;

    int dlbl1 = 0;
    int dlbl2 = 0;
    int dlbl3 = 0;
    int dlbl4 = 0;
    int dlbl5 = 0;
    int dlbl6 = 0;


    int total1 = 0;
    int total2 = 0;
    int total3 = 0;
    int total4 = 0;
    int total5 = 0;
    int total6 = 0;
    int total7 = 0;


    int MainTotal1 = 0;
    int MainTotal2 = 0;
    int MainTotal3 = 0;
    int MainTotal4 = 0;
    int MainTotal5 = 0;
    int MainTotal6 = 0;



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
                BindGrid();
                FillDropDowns();

            }

        }
    }


    public void BindGrid()
    {

        try
        {
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

            trafficAnalysis.Culture = Convert.ToInt32(ddlCulture.SelectedItem.Value);
            ds_Search = trafficAnalysis.Get_TrafficAnalysis(trafficAnalysis);

            if (ds_Search.Tables[0].Rows.Count > 0)
            {
                dtData.Columns.Add(new DataColumn("Id", typeof(string)));
                dtData.Columns.Add(new DataColumn("Industry", typeof(string)));
                dtData.Columns.Add(new DataColumn("Name", typeof(string)));
                dtData.Columns.Add(new DataColumn("Company Name", typeof(string)));
                dtData.Columns.Add(new DataColumn("Business started in", typeof(string)));
                dtData.Columns.Add(new DataColumn("No Of Employees", typeof(string)));
                dtData.Columns.Add(new DataColumn("Email", typeof(string)));
                dtData.Columns.Add(new DataColumn("Resource Library", typeof(int)));
                dtData.Columns.Add(new DataColumn("Business Profiling", typeof(int)));
                dtData.Columns.Add(new DataColumn("Capabilities Profiling", typeof(int)));
                dtData.Columns.Add(new DataColumn("Financial Modeling", typeof(int)));
                dtData.Columns.Add(new DataColumn("Learn More", typeof(int)));
                dtData.Columns.Add(new DataColumn("Faqs OnlineHelp", typeof(int)));
                dtData.Columns.Add(new DataColumn("FLAG", typeof(string)));
               // dtData.Columns.Add(new DataColumn("SubTotal", typeof(string)));

                DataRow dr;
                for (int index = 0; index < ds_Search.Tables[0].Rows.Count; index++)
                {


                    if (index == 0)
                    {
                        ViewState["Id"] = "Nothing";
                    }

                    if (ViewState["Id"].ToString().Equals(ds_Search.Tables[0].Rows[index]["Id"].ToString()) || index == 0)
                    {
                        ViewState["Id"] = ds_Search.Tables[0].Rows[index]["Id"].ToString();
                        dr = dtData.NewRow();
                        dr["Id"] = ds_Search.Tables[0].Rows[index]["Id"].ToString();
                        dr["NAME"] = ds_Search.Tables[0].Rows[index]["NAME"].ToString();
                        dr["Industry"] = ds_Search.Tables[0].Rows[index]["INDUSTRYNAME"].ToString();
                        dr["Company Name"] = ds_Search.Tables[0].Rows[index]["COMPANYNM"].ToString();
                        dr["Business started in"] = ds_Search.Tables[0].Rows[index]["BUSSSTARTEDYEAR"].ToString();
                        dr["No Of Employees"] = ds_Search.Tables[0].Rows[index]["NOOFEMPLOYEES"].ToString();
                        dr["Email"] = ds_Search.Tables[0].Rows[index]["EMAILID"].ToString();
                        dr["Resource Library"] = ds_Search.Tables[0].Rows[index]["RESOURCELIBRARY"].ToString();
                        dr["Business Profiling"] = ds_Search.Tables[0].Rows[index]["BUSINESSPROFILING"].ToString();
                        dr["Capabilities Profiling"] = ds_Search.Tables[0].Rows[index]["CAPABILITIESPROFILING"].ToString();
                        dr["Financial Modeling"] = ds_Search.Tables[0].Rows[index]["FINANCIALMODELING"].ToString();
                        dr["Learn More"] = ds_Search.Tables[0].Rows[index]["LEARNMORE"].ToString();
                        dr["Faqs OnlineHelp"] = ds_Search.Tables[0].Rows[index]["FAQSONLINEHELP"].ToString();
                        dr["FLAG"] = "0";
                        //if (ds_Search.Tables[0].Rows[index]["RESOURCELIBRARY"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["BUSINESSPROFILING"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["CAPABILITIESPROFILING"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["FINANCIALMODELING"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["LEARNMORE"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["FAQsONLINEHELP"].ToString() == "0")
                        //{
                        //    dr["SubTotal"] = "0";
                        //}
                        //else
                        //{
                        //    dr["SubTotal"] = "1";
                        //}
                        dtData.Rows.Add(dr);
                    }
                    else
                    {

                        ViewState["Id"] = ds_Search.Tables[0].Rows[index]["Id"].ToString();
                        dr = dtData.NewRow();
                        dr["Id"] = "";
                        dr["NAME"] = "";
                        dr["Industry"] = "";
                        dr["Company Name"] = "";
                        dr["Business started in"] = "";
                        dr["No Of Employees"] = "";
                        dr["Email"] = "SubTotal";

                        dr["Resource Library"] = ds_Search.Tables[0].Compute("SUM(RESOURCELIBRARY)", "Id ='" + ds_Search.Tables[0].Rows[index - 1]["Id"].ToString() + "'");
                        //ViewState["RESOURCELIBRARY"] = ds_Search.Tables[0].Compute("SUM(RESOURCELIBRARY)", "Id ='" + ds_Search.Tables[0].Rows[index - 1]["Id"].ToString() + "'");
                        dr["Business Profiling"] = ds_Search.Tables[0].Compute("SUM(BUSINESSPROFILING)", "Id ='" + ds_Search.Tables[0].Rows[index - 1]["Id"].ToString() + "'");
                        dr["Capabilities Profiling"] = ds_Search.Tables[0].Compute("SUM(CAPABILITIESPROFILING)", "Id ='" + ds_Search.Tables[0].Rows[index - 1]["Id"].ToString() + "'");
                        dr["Financial Modeling"] = ds_Search.Tables[0].Compute("SUM(FINANCIALMODELING)", "Id ='" + ds_Search.Tables[0].Rows[index - 1]["Id"].ToString() + "'");
                        dr["Learn More"] = ds_Search.Tables[0].Compute("SUM(LEARNMORE)", "Id ='" + ds_Search.Tables[0].Rows[index - 1]["Id"].ToString() + "'");
                        dr["Faqs OnlineHelp"] = ds_Search.Tables[0].Compute("SUM(FAQSONLINEHELP)", "Id ='" + ds_Search.Tables[0].Rows[index - 1]["Id"].ToString() + "'");
                        dr["FLAG"] = "1";

                        //if (ds_Search.Tables[0].Rows[index - 1]["RESOURCELIBRARY"].ToString() == "0" && ds_Search.Tables[0].Rows[index - 1]["BUSINESSPROFILING"].ToString() == "0" && ds_Search.Tables[0].Rows[index - 1]["CAPABILITIESPROFILING"].ToString() == "0" && ds_Search.Tables[0].Rows[index - 1]["FINANCIALMODELING"].ToString() == "0" && ds_Search.Tables[0].Rows[index - 1]["LEARNMORE"].ToString() == "0" && ds_Search.Tables[0].Rows[index - 1]["FAQsONLINEHELP"].ToString() == "0")
                        //{
                        //    dr["SubTotal"] = "0";
                        //}
                        //else
                        //{
                        //    dr["SubTotal"] = "1";
                        //}



                        dtData.Rows.Add(dr);

                        dr = dtData.NewRow();
                        dr["Id"] = ds_Search.Tables[0].Rows[index]["Id"].ToString();
                        dr["NAME"] = ds_Search.Tables[0].Rows[index]["NAME"].ToString();
                        dr["Industry"] = ds_Search.Tables[0].Rows[index]["INDUSTRYNAME"].ToString();
                        dr["Company Name"] = ds_Search.Tables[0].Rows[index]["COMPANYNM"].ToString();
                        dr["Business started in"] = ds_Search.Tables[0].Rows[index]["BUSSSTARTEDYEAR"].ToString();
                        dr["No Of Employees"] = ds_Search.Tables[0].Rows[index]["NOOFEMPLOYEES"].ToString();
                        dr["Email"] = ds_Search.Tables[0].Rows[index]["EMAILID"].ToString();
                        dr["Resource Library"] = ds_Search.Tables[0].Rows[index]["RESOURCELIBRARY"].ToString();
                        dr["Business Profiling"] = ds_Search.Tables[0].Rows[index]["BUSINESSPROFILING"].ToString();
                        dr["Capabilities Profiling"] = ds_Search.Tables[0].Rows[index]["CAPABILITIESPROFILING"].ToString();
                        dr["Financial Modeling"] = ds_Search.Tables[0].Rows[index]["FINANCIALMODELING"].ToString();
                        dr["Learn More"] = ds_Search.Tables[0].Rows[index]["LEARNMORE"].ToString();
                        dr["Faqs OnlineHelp"] = ds_Search.Tables[0].Rows[index]["FAQSONLINEHELP"].ToString();
                        dr["FLAG"] = "0";

                        //if (ds_Search.Tables[0].Rows[index]["RESOURCELIBRARY"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["BUSINESSPROFILING"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["CAPABILITIESPROFILING"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["FINANCIALMODELING"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["LEARNMORE"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["FAQsONLINEHELP"].ToString() == "0")
                        //{
                        //    dr["SubTotal"] = "0";
                        //}
                        //else
                        //{
                        //    dr["SubTotal"] = "1";
                        //}


                        dtData.Rows.Add(dr);
                    }

                }
                dr = dtData.NewRow();
                dr["Id"] = "";
                dr["NAME"] = "";
                dr["Industry"] = "";
                dr["Company Name"] = "";
                dr["Business started in"] = "";
                dr["No Of Employees"] = "";
                dr["Email"] = "SubTotal";

                dr["Resource Library"] = ds_Search.Tables[0].Compute("SUM(RESOURCELIBRARY)", "Id ='" + ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["Id"].ToString() + "'");
                dr["Business Profiling"] = ds_Search.Tables[0].Compute("SUM(BUSINESSPROFILING)", "Id ='" + ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["Id"].ToString() + "'");
                dr["Capabilities Profiling"] = ds_Search.Tables[0].Compute("SUM(CAPABILITIESPROFILING)", "Id ='" + ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["Id"].ToString() + "'");
                dr["Financial Modeling"] = ds_Search.Tables[0].Compute("SUM(FINANCIALMODELING)", "Id ='" + ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["Id"].ToString() + "'");
                dr["Learn More"] = ds_Search.Tables[0].Compute("SUM(LEARNMORE)", "Id ='" + ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["Id"].ToString() + "'");
                dr["Faqs OnlineHelp"] = ds_Search.Tables[0].Compute("SUM(FAQSONLINEHELP)", "Id ='" + ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["Id"].ToString() + "'");
                dr["FLAG"] = "1";
                //if (ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["RESOURCELIBRARY"].ToString() == "0" && ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["BUSINESSPROFILING"].ToString() == "0" && ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["CAPABILITIESPROFILING"].ToString() == "0" && ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["FINANCIALMODELING"].ToString() == "0" && ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["LEARNMORE"].ToString() == "0" && ds_Search.Tables[0].Rows[(ds_Search.Tables[0].Rows.Count) - 1]["FAQsONLINEHELP"].ToString() == "0")
                //{
                //    dr["SubTotal"] = "0";
                //}
                //else
                //{
                //    dr["SubTotal"] = "1";
                //}
                dtData.Rows.Add(dr);


                lblError.Visible = false;
                btnExptoExcel.Visible = true;
                tdSelect.Visible = true;


                gvTrafficAnalysis.DataSource = dtData;
                gvTrafficAnalysis.DataBind();


            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "  No Data Available";
                btnExptoExcel.Visible = false;
                tdSelect.Visible = false;
                gvTrafficAnalysis.DataBind();

                ViewState["dsData"] = ds_Search;

                gvTrafficAnalysis.DataSource = dtData;
                gvTrafficAnalysis.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvTrafficAnalysis_RowDataBound(object sender, GridViewRowEventArgs e)
    {

      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             total1 = 0;
             total2 = 0;
             total3 = 0;
             total4 = 0;
             total5 = 0;
             total6 = 0;
             total7 = 0;

         
        
          
            Label lbl_Email = (Label)e.Row.FindControl("lbl_Email");
            Label lbl_Resourcelibrary = (Label)e.Row.FindControl("lbl_Resourcelibrary");
            Label lbl_BusinessProfiling = (Label)e.Row.FindControl("lbl_BusinessProfiling");
            Label lbl_CapabilitiesProfiling = (Label)e.Row.FindControl("lbl_CapabilitiesProfiling");
            Label lbl_FinancialModeling = (Label)e.Row.FindControl("lbl_FinancialModeling");
            Label lbl_LearnMore = (Label)e.Row.FindControl("lbl_LearnMore");
            Label lbl_Faqs = (Label)e.Row.FindControl("lbl_Faqs");
            Label lbl_ROWTOTAL = (Label)e.Row.FindControl("lbl_ROWTOTAL");


            if (lbl_Resourcelibrary.Text != "" && lbl_Resourcelibrary.Text != null)
                dlbl1 = Convert.ToInt32(lbl_Resourcelibrary.Text);
            else
                dlbl1 = 0;

            if (lbl_BusinessProfiling.Text != "" && lbl_BusinessProfiling.Text != null)
                dlbl2 = Convert.ToInt32(lbl_BusinessProfiling.Text);
            else
                dlbl2 = 0;

            if (lbl_CapabilitiesProfiling.Text != "" && lbl_CapabilitiesProfiling.Text != null)
                dlbl3 = Convert.ToInt32(lbl_CapabilitiesProfiling.Text);
            else
                dlbl3 = 0;

            if (lbl_FinancialModeling.Text != "" && lbl_FinancialModeling.Text != null)
                dlbl4 = Convert.ToInt32(lbl_FinancialModeling.Text);
            else
                dlbl4 = 0;

            if (lbl_LearnMore.Text != "" && lbl_LearnMore.Text != null)
                dlbl5 = Convert.ToInt32(lbl_LearnMore.Text);
            else
                dlbl5 = 0;

            if (lbl_Faqs.Text != "" && lbl_Faqs.Text != null)
                dlbl6 = Convert.ToInt32(lbl_Faqs.Text);
            else
                dlbl6 = 0;

         
           

            total1 += dlbl1;
            total2 += dlbl2;
            total3 += dlbl3;
            total4 += dlbl4;
            total5 += dlbl5;
            total6 += dlbl6;
         
            total7 += dlbl1 + dlbl2 + dlbl3 + dlbl4 + dlbl5 + dlbl6;

            lbl_ROWTOTAL.Text = total7.ToString();

          


            Label lbl_FLAG = (Label)e.Row.FindControl("lbl_FLAG");
            // Label lbl_SubTotal = (Label)e.Row.FindControl("lbl_SubTotal");

            if (lbl_FLAG.Text == "1")
            {
                count = 0;
                e.Row.BackColor = Color.FromName("#BEBEBE");
                e.Row.Cells[0].BorderStyle = BorderStyle.None;
                e.Row.Cells[0].BackColor = Color.White;
                e.Row.Font.Bold = true;

                MainTotal1 += total1;
                MainTotal2 += total2;
                MainTotal3 += total3;
                MainTotal4 += total4;
                MainTotal5 += total5;
                MainTotal6 += total6;
             

            }

            if (lbl_FLAG.Text == "0")
            {
                count = count + 1;
            }
            if (count > 1)
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[0].BorderStyle = BorderStyle.None;

            }
          

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalR = (Label)e.Row.FindControl("lblTotalR");
            Label lblTotalBP = (Label)e.Row.FindControl("lblTotalBP");
            Label lblTotalCP = (Label)e.Row.FindControl("lblTotalCP");
            Label lblTotalFM = (Label)e.Row.FindControl("lblTotalFM");
            Label lblTotalLM = (Label)e.Row.FindControl("lblTotalLM");
            Label lblTotalFaq = (Label)e.Row.FindControl("lblTotalFaq");
            Label lblTotalFooter = (Label)e.Row.FindControl("lblTotalFooter");

            lblTotalR.Text = MainTotal1.ToString();
            lblTotalBP.Text = MainTotal2.ToString();
            lblTotalCP.Text = MainTotal3.ToString();
            lblTotalFM.Text = MainTotal4.ToString();
            lblTotalLM.Text = MainTotal5.ToString();
            lblTotalFaq.Text = MainTotal6.ToString();


            lblTotalFooter.Text = (MainTotal1 + MainTotal2 + MainTotal3 + MainTotal4 + MainTotal5 + MainTotal6).ToString();


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

    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=TrafficAnalysisLoginReport1.xls");

        Response.Charset = "";

        Response.ContentType = "application/vnd.xls";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

       // gvTrafficAnalysis.Columns[13].Visible = false;
       // gvTrafficAnalysis.DataBind();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvTrafficAnalysis.RenderControl(htmlWrite);     //throwing error 

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
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        //if (DatePicker_StartDate.DateString == "" && DatePicker_EndDate.DateString != "")
        //{
        //    ABSCommon.Common.ShowMessage(this, "Please select Startdate");
        //    gvTrafficAnalysis.Visible = false;
        //    btnExptoExcel.Visible = false;
        //}
        //else
        //{
        //    gvTrafficAnalysis.Visible = true;
        //    btnExptoExcel.Visible = true; ;
            BindGrid();
        //}
       
    }

   
}
