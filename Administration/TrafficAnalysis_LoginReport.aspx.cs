using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administration_TrafficAnalysis_LoginReport : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    Check_Access chkAccess = new Check_Access();
    public static string token;

    int total1 = 0;
    int total2 = 0;

    int dlbl1 = 0;
    int dlbl2 = 0;

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
            DataSet ds_Search = trafficAnalysis.GET_TrafficAnalysis_Login(trafficAnalysis);

            if (ds_Search.Tables[0].Rows.Count > 0)
            {
                lblError.Visible = false;
                btnExptoExcel.Visible = true;
                tdSelect.Visible = true;

                ViewState["dsData"] = ds_Search;

                //for (int index = 0; index < ds_Search.Tables[0].Rows.Count; index++)
                //{
                //    if (ds_Search.Tables[0].Rows[index]["TotalUsers"].ToString() == "0" && ds_Search.Tables[0].Rows[index]["NewUsers"].ToString() == "0")
                //    {
                //        ds_Search.Tables[0].Rows[index].Delete();
                //    }
                //}

                int Count = 0;
                for (int index = 0; index < ds_Search.Tables[0].Rows.Count; index++)
                {
                    int flag = 1;
                    for (int cindex = 1; cindex <= ds_Search.Tables[0].Columns.Count - 1; cindex++)
                    {
                        if (ds_Search.Tables[0].Rows[index][cindex].ToString() != "0")
                        {
                            flag = 0;
                        }
                    }
                    if (flag == 1)
                    {
                        ds_Search.Tables[0].Rows[index].Delete();
                        Count = Count + 1;

                    }
                }
                if (ds_Search.Tables[0].Rows.Count == Count)
                {
                    lblError.Visible = true;
                    lblError.Text = "  No Data Available";
                    btnExptoExcel.Visible = false;
                    tdSelect.Visible = false;
                    gvTrafficAnalysisLogin.DataBind();
                }
                else
                {
                    btnExptoExcel.Visible = true;

                    gvTrafficAnalysisLogin.DataSource = ds_Search;
                    gvTrafficAnalysisLogin.DataBind();
                }

                //btnExptoExcel.Visible = true;

                //gvTrafficAnalysisLogin.DataSource = ds_Search;
                //gvTrafficAnalysisLogin.DataBind();
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "  No Data Available";
                btnExptoExcel.Visible = false;
                tdSelect.Visible = false;
                gvTrafficAnalysisLogin.DataBind();

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
            Label lbl1 = (Label)e.Row.FindControl("lbl_NewUsers");
            Label lbl2 = (Label)e.Row.FindControl("lbl_TotalUsers");


            if (lbl1.Text != "" && lbl1.Text != null)
                dlbl1 = Convert.ToInt32(lbl1.Text);
            else
                dlbl1 = 0;

            if (lbl2.Text != "" && lbl2.Text != null)
                dlbl2 = Convert.ToInt32(lbl2.Text);
            else
                dlbl2 = 0;


            total1 += dlbl1;
            total2 += dlbl2;

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            Label lbl1 = (Label)e.Row.FindControl("lblNewUsers");
            Label lbl2 = (Label)e.Row.FindControl("lblTotalUsers");

            lbl1.Text = total1.ToString();
            lbl2.Text = total2.ToString();

        }
    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
}
