using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ABSBLL;
using ABSCommon;
using ABSDTO;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


public partial class Administration_CourseRegistration_Report : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    CourseRegistration obj_CourseRegs = new CourseRegistration();
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

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {
                if (Request["IDforEdit"] != null)
                {
                    string str = commonfunction.Decrypt(Request["IDforEdit"]);
                    ViewState["CID"] = str;
                    BindGrid();
                }
                else
                {
                    ViewState["CID"] = "";
                    BindGrid();
                }

            }
        }
    }


    public void BindGrid()
    {
        try
        {
            DataSet ds_Search;

            if (!string.IsNullOrEmpty(ViewState["CID"].ToString()))
            {
                int cid = Convert.ToInt32(ViewState["CID"].ToString());
                ds_Search = obj_CourseRegs.Get_CourseRegs_DetailsById(cid);
            }
            else
            {
                string strTitle = txtTitle.Text.ToString();
                ds_Search = obj_CourseRegs.Get_CourseRegs_DetailsAll(strTitle);
            }


            if (ds_Search.Tables[0].Rows.Count > 0)
            {

                lblError.Visible = false;
                btnExptoExcel.Visible = true;
                id_btn_Delete.Visible = true;
                tdSelect.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "  No Data Available";
                btnExptoExcel.Visible = false;
                id_btn_Delete.Visible = false;
                tdSelect.Visible = false;
                DG_CourseRegs.DataBind();

            }

            if (this.Txt_Page_Size.Text != "")
            {
                if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                {
                    this.DG_CourseRegs.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                }
            }
            else
            {
                this.Txt_Page_Size.Text = commonfunction.Get_Page_Size(Session["fid"].ToString()).ToString();
                this.DG_CourseRegs.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
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
                        DG_CourseRegs.CurrentPageIndex = intPageNo - 1;
                    }
                }
                ViewState["dsData"] = ds_Search;
                DG_CourseRegs.DataSource = ds_Search;
                DG_CourseRegs.DataBind();

                gvExport.DataSource = ds_Search;
                gvExport.DataBind();


                Int16 intTo;
                Int16 intFrom;
                if (DG_CourseRegs.PageSize * (DG_CourseRegs.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                {
                    intTo = System.Convert.ToInt16(DG_CourseRegs.PageSize * (DG_CourseRegs.CurrentPageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                }
                intFrom = System.Convert.ToInt16((DG_CourseRegs.PageSize * DG_CourseRegs.CurrentPageIndex) + 1);
                this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
                this.Lbl_Pageinfo.Visible = true;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void DG_CourseRegs_ItemCreated(object sender, DataGridItemEventArgs e)
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

    protected void DG_CourseRegs_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        //if (ViewState["Sort_On"] != null)
        //obj_CourseRegs.SortOn = ViewState["Sort_On"].ToString();
        DG_CourseRegs.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        BindGrid();
        ViewState["page_no"] = DG_CourseRegs.CurrentPageIndex;
    }


    protected void id_btn_Delete_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["Cbx_uid"] == null)
        {
            this.lblError.Text = "Please select at least one record to delete.";
            this.lblError.Visible = true;
        }
        else
        {
            string[] _UsersArr = Request["Cbx_uid"].Split(',');
            string _users = "";
            for (int i = 0; i < _UsersArr.Length; i++)
            {
                _users = _users + ",'" + _UsersArr[i].ToString() + "'";
            }
            if (_users != "")
                _users = _users.Remove(0, 1);

            //obj_CDetails.Delete_Record_CourseDetails(_users);

            obj_CourseRegs.DeleteCourseRegistration(_users);

            string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            //string response = "<script type='text/javascript'>alert('Record(s) has been successfully deleted');parent.mainframe.location.href='" + navurl + "';</script>";
            //changes 
            //string response = "<script type='text/javascript'>alert('Record(s) has been successfully deleted');</script>";
            //Response.Write(response);

            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) has been successfully deleted.'); location='" + _redirectPath + "';</Script>");


            BindGrid();
        }

    }

    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["CID"] = "";
        DG_CourseRegs.CurrentPageIndex = 0;
        BindGrid();
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {

        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.


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

        Response.AddHeader("content-disposition", "attachment;filename=CourseRegsDtls.xls");

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