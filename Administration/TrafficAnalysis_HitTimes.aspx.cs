using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administration_TrafficAnalysis_HitTimes : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    public static string token;
    Check_Access chkAccess = new Check_Access();

    int total1 = 0;
    int total2 = 0;
    int total3 = 0;
    int total4 = 0;
    int total5 = 0;
    int total6 = 0;
    int total7 = 0;
    int total8 = 0;

    int dlbl1 = 0;
    int dlbl2 = 0;
    int dlbl3 = 0;
    int dlbl4 = 0;
    int dlbl5 = 0;
    int dlbl6 = 0;
    int dlbl7 = 0;
    int dlbl8 = 0;

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
                FillDropDowns();

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
            DataSet ds_Search = trafficAnalysis.GET_TrafficAnalysis_Login_HitTimes(trafficAnalysis);

         

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
                gvTrafficAnalysisHitTimes.DataBind();

            }

            if (ds_Search.Tables[0].Rows.Count != 0)
            {
                int Count = 0;
                for (int index = 0; index < ds_Search.Tables[0].Rows.Count; index++)
                {
                    int flag = 1;
                    int totalcount = 0;
                    for (int cindex = 2; cindex <= ds_Search.Tables[0].Columns.Count - 1; cindex++)
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
                        Count = Count + 1;

                    }
                    else
                    {
                        //ds_Search.Tables[0].Rows[index]["SUBTOTAL"] = totalcount.ToString();
                    }
                }
                if (ds_Search.Tables[0].Rows.Count == Count)
                {
                    lblError.Visible = true;
                    lblError.Text = "  No Data Available";
                    btnExptoExcel.Visible = false;
                    tdSelect.Visible = false;
                    gvTrafficAnalysisHitTimes.DataBind();
                }
                else
                {
                    btnExptoExcel.Visible = true; ;

                    gvTrafficAnalysisHitTimes.DataSource = ds_Search;
                    gvTrafficAnalysisHitTimes.DataBind();
                }
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

        Response.AddHeader("content-disposition", "attachment;filename=TrafficAnalysis_Login_HitTimesReport.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvTrafficAnalysisHitTimes.RenderControl(htmlWrite);     //throwing error 

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

    protected void gvTrafficAnalysisHitTimes_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl1 = (Label)e.Row.FindControl("lbl_Resourcelibrary");
            Label lbl2 = (Label)e.Row.FindControl("lbl_BusinessProfiling");
            Label lbl3 = (Label)e.Row.FindControl("lbl_CapabilitiesProfiling");
            Label lbl4 = (Label)e.Row.FindControl("lbl_FinancialModeling");
            Label lbl8 = (Label)e.Row.FindControl("lbl_Financial_Modeling");
            Label lbl5 = (Label)e.Row.FindControl("lbl_LearnMore");
            Label lbl6 = (Label)e.Row.FindControl("lbl_Faqs");
            Label lbl7 = (Label)e.Row.FindControl("lbl_Total");

            total7 = 0;

            if (lbl1.Text != "" && lbl1.Text != null)
                dlbl1 = Convert.ToInt32(lbl1.Text);
            else
                dlbl1 = 0;

            if (lbl2.Text != "" && lbl2.Text != null)
                dlbl2 = Convert.ToInt32(lbl2.Text);
            else
                dlbl2 = 0;

            if (lbl3.Text != "" && lbl3.Text != null)
                dlbl3 = Convert.ToInt32(lbl3.Text);
            else
                dlbl3 = 0;

            if (lbl4.Text != "" && lbl4.Text != null)
                dlbl4 = Convert.ToInt32(lbl4.Text);
            else
                dlbl4 = 0;

            if (lbl5.Text != "" && lbl5.Text != null)
                dlbl5 = Convert.ToInt32(lbl5.Text);
            else
                dlbl5 = 0;

            if (lbl6.Text != "" && lbl6.Text != null)
                dlbl6 = Convert.ToInt32(lbl6.Text);
            else
                dlbl6 = 0;
            if (lbl8.Text != "" && lbl8.Text != null)
                dlbl8 = Convert.ToInt32(lbl8.Text);
            else
                dlbl8 = 0;

            total1 += dlbl1;
            total2 += dlbl2;
            total3 += dlbl3;
            total4 += dlbl4;
            total5 += dlbl5;
            total6 += dlbl6;
            total8 += dlbl8;

            total7 += dlbl1 + dlbl2 + dlbl3 + dlbl4 + dlbl5 + dlbl6 + dlbl8;

            lbl7.Text = total7.ToString();



        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            Label lbl1 = (Label)e.Row.FindControl("lblTotalR");
            Label lbl2 = (Label)e.Row.FindControl("lblTotalBP");
            Label lbl3 = (Label)e.Row.FindControl("lblTotalCP");
            Label lbl4 = (Label)e.Row.FindControl("lblTotalFM");
            Label lbl8 = (Label)e.Row.FindControl("lblTotal_FM");
            Label lbl5 = (Label)e.Row.FindControl("lblTotalLM");
            Label lbl6 = (Label)e.Row.FindControl("lblTotalFaq");
            Label lbl7 = (Label)e.Row.FindControl("lblTotalFooter");

            lbl1.Text = total1.ToString();
            lbl2.Text = total2.ToString();
            lbl3.Text = total3.ToString();
            lbl4.Text = total4.ToString();
            lbl5.Text = total5.ToString();
            lbl6.Text = total6.ToString();
            lbl8.Text = total8.ToString();

            lbl7.Text = (total1 + total2 + total3 + total4 + total5 + total6 + total8).ToString();


        }
    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
}
