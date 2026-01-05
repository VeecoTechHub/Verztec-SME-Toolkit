using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSCommon;
using ABSDTO;
using System.Data;
using System.Configuration;
using System.IO;

public partial class Administration_FeedbackReport : System.Web.UI.Page
{


    int intCount = 0;
    CommonFunctions commonfunction = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    public static string token;
    FeedBack obj_Feedback = new FeedBack();

    protected void Page_Load(object sender, EventArgs e)
    {

        gvExcel.Visible = false;
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

            }

        }
    }
    public void BindGrid()
    {
        try
        {
            obj_Feedback.PostedBy = txtName.Text.ToString();

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
            DataSet ds_Search = obj_Feedback.Get_FeedbackAnswers(obj_Feedback);
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
                DG_Feedback.DataBind();

            }

            if (this.Txt_Page_Size.Text != "")
            {
                if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                {
                    this.DG_Feedback.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text) * 3;
                }
            }
            else
            {
                this.Txt_Page_Size.Text = commonfunction.Get_Page_Size(Session["fid"].ToString()).ToString();
                this.DG_Feedback.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text) * 3;
            }

            if (ds_Search.Tables[0].Rows.Count == 0)
            {
                this.Lbl_Pageinfo.Visible = false;
            }
            else
            {
                if (ViewState["currentPagNo"] != null)
                {
                    int intPageNo = (ds_Search.Tables[0].Rows.Count) / Convert.ToInt32(Txt_Page_Size.Text);
                    if (Convert.ToInt32(ViewState["currentPagNo"]) >= intPageNo)
                    {
                        //ds_Search.Tables[0].Rows.Count - 1
                        //int intPageNo = (ds_Search.Tables[0].Rows.Count) / Convert.ToInt32(Txt_Page_Size.Text);
                        int intPageNo1 = (ds_Search.Tables[0].Rows.Count) % Convert.ToInt32(Txt_Page_Size.Text);
                        if (intPageNo1 > 0)
                        {
                            intPageNo = intPageNo + 1;
                        }
                        DG_Feedback.PageIndex = intPageNo - 1;

                    }
                }
                ViewState["dsData"] = ds_Search;
                DG_Feedback.DataSource = ds_Search;
                DG_Feedback.DataBind();

                gvExcel.DataSource = ds_Search;
                gvExcel.DataBind();


                Int16 intTo;
                Int16 intFrom;
                if (DG_Feedback.PageSize * (DG_Feedback.PageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                {
                    intTo = System.Convert.ToInt16(DG_Feedback.PageSize * (DG_Feedback.PageIndex + 1));
                    intTo = Convert.ToInt16(intTo / 3);
                }
                else
                {
                    intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                    intTo = Convert.ToInt16(intTo / 3);
                }
                intFrom = System.Convert.ToInt16((DG_Feedback.PageSize * DG_Feedback.PageIndex) + 1);
                intFrom = Convert.ToInt16((intFrom / 3) + 1);
                this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + (ds_Search.Tables[0].Rows.Count / 3);
                this.Lbl_Pageinfo.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        //DG_Feedback.CurrentPageIndex = 0;
        BindGrid();
    }
    protected void DG_Feedback_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DG_Feedback.PageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        BindGrid();
        ViewState["page_no"] = DG_Feedback.PageIndex;
    }
    protected void DG_Feedback_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell pager = (TableCell)e.Row.Controls[0];
                int i;
                Label l;
                LinkButton h;
                for (i = 0; i < pager.Controls.Count; i += 2)
                {
                    try
                    {
                        l = (Label)pager.Controls[i];
                        if (i == 0)
                            l.Text = "Page(s) " + l.Text;
                    }
                    catch
                    {
                        h = (LinkButton)pager.Controls[i];
                        if (i == 0)
                            h.Text = "Page(s) " + h.Text;
                    }
                }
            }
        }
        catch
        { }
    }

    protected void gvExcel_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell pager = (TableCell)e.Row.Controls[0];
                int i;
                Label l;
                LinkButton h;
                for (i = 0; i < pager.Controls.Count; i += 2)
                {
                    try
                    {
                        l = (Label)pager.Controls[i];
                        if (i == 0)
                            l.Text = "Page(s) " + l.Text;
                    }
                    catch
                    {
                        h = (LinkButton)pager.Controls[i];
                        if (i == 0)
                            h.Text = "Page(s) " + h.Text;
                    }
                }
            }
        }
        catch
        { }
    }


    protected void btnExptoExcel_Click(object sender, ImageClickEventArgs e)
    {
        gvExcel.Visible = true;
        ExportToExcel();
        gvExcel.Visible = false;
    }


    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=Feedback.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvExcel.RenderControl(htmlWrite);     //throwing error 

        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {

        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.

    }
    protected void DG_Feedback_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (intCount == 1 || intCount == 2)
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[0].BorderStyle = BorderStyle.None;

                e.Row.Cells[1].Text = "";
                e.Row.Cells[1].BorderStyle = BorderStyle.None;

                if (intCount == 2)
                {
                    intCount = -1;
                }

            }
            intCount = intCount + 1; ;
        }


    }
    protected void gvExcel_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (intCount == 1 || intCount == 2)
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[0].BorderStyle = BorderStyle.None;

                e.Row.Cells[1].Text = "";
                e.Row.Cells[1].BorderStyle = BorderStyle.None;

                if (intCount == 2)
                {
                    intCount = -1;
                }

            }
            intCount = intCount + 1; ;
        }


    }




}