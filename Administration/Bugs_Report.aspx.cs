using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administration_Bugs_Report : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    FeedBack obj_Feedback = new FeedBack();
    Check_Access chkAccess = new Check_Access();
    public static string token;
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
            obj_Feedback.IndustryId = Convert.ToInt32(ddlIndustry.SelectedValue);

            if (DatePicker_StartDate.DateString == "")
            {
                obj_Feedback.StartDate = null;
            }
            else
            {
                obj_Feedback.StartDate = Convert.ToString(DatePicker_StartDate.Date);
            }
            if (DatePicker_EndDate.DateString == "")
            {
                obj_Feedback.EndDate = null;
            }
            else
            {
                obj_Feedback.EndDate = Convert.ToString(DatePicker_EndDate.Date);
            }
            DataSet ds_Search = obj_Feedback.Get_Bugs_Comments(obj_Feedback);

            if (ds_Search.Tables[0].Rows.Count > 0)
            {
                lblError.Visible = false;
                btnExptoExcel.Visible = true;
                tdSelect.Visible = true;
                btnExptoExcel.Visible = true;

                gvBugs.DataSource = ds_Search;
                gvBugs.DataBind();
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "  No Data Available";
                btnExptoExcel.Visible = false;
                tdSelect.Visible = false;
                gvBugs.DataBind();

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

        Response.AddHeader("content-disposition", "attachment;filename=TrafficAnalysis_LoginReport.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvBugs.RenderControl(htmlWrite);     //throwing error 

        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {

        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.

    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
    protected void btnExptoExcel_Click(object sender, ImageClickEventArgs e)
    {
        ExportToExcel();
    }
}
