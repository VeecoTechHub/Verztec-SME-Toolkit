using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSCommon;
using ABSDTO;
using System.Data;
using System.Configuration;

public partial class Administration_Admin_Feedback : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    public static string token;
    FeedBack obj_Feedback = new FeedBack();

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
                obj_Feedback.StartDate=null;

            }
            if (DatePicker_EndDate.DateString == "")
            {
                // DatePicker_EndDate.DateString = DateTime.Now.Date.ToString();
                obj_Feedback.EndDate =null;

            }
            else
            {
                obj_Feedback.StartDate = Convert.ToString(DatePicker_StartDate.Date);
                obj_Feedback.EndDate = Convert.ToString(DatePicker_EndDate.Date);
            }

            DataSet ds_Search = obj_Feedback.Get_FeedbackAnswers(obj_Feedback);
            if (ds_Search.Tables[0].Rows.Count > 0)
            {

                lblError.Visible = false;
                btnExptoExcel.Visible = true;
                //id_btn_Delete.Visible = true;
                tdSelect.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "  No Data Available";
                btnExptoExcel.Visible = false;
                //id_btn_Delete.Visible = false;
                tdSelect.Visible = false;
                DG_Feedback.DataBind();

            }

            if (this.Txt_Page_Size.Text != "")
            {
                if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                {
                    this.DG_Feedback.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                }
            }
            else
            {
                this.Txt_Page_Size.Text = commonfunction.Get_Page_Size(Session["fid"].ToString()).ToString();
                this.DG_Feedback.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
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
                        DG_Feedback.CurrentPageIndex = intPageNo - 1;
                    }
                }
                ViewState["dsData"] = ds_Search;
                DG_Feedback.DataSource = ds_Search;
                DG_Feedback.DataBind();

                gvExport.DataSource = ds_Search;
                gvExport.DataBind();


                Int16 intTo;
                Int16 intFrom;
                if (DG_Feedback.PageSize * (DG_Feedback.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                {
                    intTo = System.Convert.ToInt16(DG_Feedback.PageSize * (DG_Feedback.CurrentPageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                }
                intFrom = System.Convert.ToInt16((DG_Feedback.PageSize * DG_Feedback.CurrentPageIndex) + 1);
                this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
                this.Lbl_Pageinfo.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    protected void DG_Feedback_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Pager)
            {
                TableCell pager = (TableCell)e.Item.Controls[0];
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
    protected void DG_Feedback_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        //if (ViewState["Sort_On"] != null)
        //obj_CourseRegs.SortOn = ViewState["Sort_On"].ToString();
        DG_Feedback.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        BindGrid();
        ViewState["page_no"] = DG_Feedback.CurrentPageIndex;
    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        //ViewState["CID"] = "";
        //DG_Feedback.CurrentPageIndex = 0;
        BindGrid();
    }

    protected void btnExptoExcel_Click(object sender, ImageClickEventArgs e)
    {
        if (gvExport.Rows.Count > 0)
        {
            ExportToExcel();
       
        }
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

        gvExport.RenderControl(htmlWrite);     //throwing error

        Response.Write(stringWrite.ToString());

        Response.End();
    }

}