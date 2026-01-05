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
using System.Data.SqlClient;
using System.Configuration;

public partial class Administration_Admin_NextSteps : System.Web.UI.Page
{
    private CourseDetails obj_CDetails = new CourseDetails();
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    public string strparm;
    public string strtags = "";
    DataSet tagds = new DataSet();
    int index = 0;
    int count = 1;
    DataSet ds_Search = new DataSet();
    public static string token;
    protected void Page_Load(object sender, EventArgs e)
    {
      
      
        DG_NextStep.Visible = true;
        if (!IsPostBack)
        {

            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_url1"] = "../Administration/CourseRegistration_Report.aspx";
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
            token = Request.Form["token"];

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {
                Bind_Data("", "all");
            }
        }
    }

    void Bind_Data(string ptitle, string ptopic)
    {
        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        DG_NextStep.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        ddlCategory.DataSource = obj_CDetails.Get_CourseMaster();
        ddlCategory.DataTextField = "CourseName";
        ddlCategory.DataValueField = "CourseID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, "ALL");
        obj_CDetails.Title = ptitle;
        obj_CDetails.Topic = ptopic;
        DG_NextStep.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        try
        {
            Bind_dataGrid();
        }
        catch (Exception err)
        {
            try
            {
                DG_NextStep.CurrentPageIndex = System.Convert.ToInt32(ViewState["page_no"]) - 1;
                Bind_dataGrid();
            }
            catch
            {
                lblError.Visible = true;
                DG_NextStep.Visible = false;
                Lbl_Pageinfo.Visible = false;
            }
        }
    }



    protected void Button_New_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Administration/Admin_AddNextSteps.aspx");
    }


    private void Bind_dataGrid()
    {
        Page.Validate();
        if (Page.IsValid)
        {
            obj_CDetails.SortOn = "";
            obj_CDetails.SortDirection = "";
            if (ViewState["Sort_On"] != null)
            {
                obj_CDetails.SortOn = ViewState["Sort_On"].ToString();
                obj_CDetails.SortDirection = ViewState["Sort_By"].ToString();
            }
            lblError.Visible = false;
            obj_CDetails.Admin = "admin";
            obj_CDetails.Title = txtCourseTitle.Text.Trim().ToString();
            obj_CDetails.Topic = ddlCategory.SelectedValue;
            ds_Search = obj_CDetails.Get_CourseDetails(obj_CDetails);

            if (ds_Search.Tables[0].Rows.Count > 0)
            {
               // Button_New.Visible = true;
                lblError.Visible = false;
                id_btn_Delete.Visible = true;
            }
            else
            {
                DG_NextStep.DataBind();
                lblError.Visible = true;
                lblError.Text = "No Data Available";
               //Button_New.Visible = true;
                id_btn_Delete.Visible = false;
                DG_NextStep.DataBind();
            }

            if (this.Txt_Page_Size.Text != "")
            {
                if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                {
                    this.DG_NextStep.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                }
            }
            else
            {
                this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
                this.DG_NextStep.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
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
                        DG_NextStep.CurrentPageIndex = intPageNo - 1;
                    }
                }
                ViewState["dsData"] = ds_Search;
                DG_NextStep.DataSource = ds_Search;
                DG_NextStep.DataBind();
                Int16 intTo;
                Int16 intFrom;
                if (DG_NextStep.PageSize * (DG_NextStep.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                {
                    intTo = System.Convert.ToInt16(DG_NextStep.PageSize * (DG_NextStep.CurrentPageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                }
                intFrom = System.Convert.ToInt16((DG_NextStep.PageSize * DG_NextStep.CurrentPageIndex) + 1);
                this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
                this.Lbl_Pageinfo.Visible = true;
            }
        }

    }

    protected void DG_NextStep_ItemCreated(object sender, DataGridItemEventArgs e)
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
                        // h.Attributes.Add("OnClick", "return pageNavigate('Page');");
                        if (i == 0)
                            h.Text = "Page(s) " + h.Text;
                    }
                }
            }
        }
        catch
        { }

    }
    protected void DG_NextStep_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        obj_CDetails.SortOn = e.SortExpression;

        ViewState["Sort_On"] = obj_CDetails.SortOn;
        if (ViewState["Sort_By"] == null)
            ViewState["Sort_By"] = "Asc";
        if (ViewState["Sort_By"].ToString() == "Asc")
        {
            ViewState["Sort_By"] = "Desc";
        }
        else
        {
            ViewState["Sort_By"] = "Asc";
        }

        Bind_dataGrid();
        ViewState["page_no"] = DG_NextStep.CurrentPageIndex;
    }
    protected void DG_NextStep_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            obj_CDetails.SortOn = ViewState["Sort_On"].ToString();
        DG_NextStep.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        Bind_dataGrid();
        ViewState["page_no"] = DG_NextStep.CurrentPageIndex;
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
            obj_CDetails.Delete_Record_CourseDetails(_users);

            //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            ////string response = "<script type='text/javascript'>alert('Record(s) has been successfully deleted');parent.mainframe.location.href='" + navurl + "';</script>";
            //string response = "<script type='text/javascript'>alert('Record(s) has been successfully deleted');</script>";
            //Response.Write(response);

            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");

            Bind_dataGrid();
        }

    }


    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        DG_NextStep.CurrentPageIndex = 0;
        Bind_dataGrid();

    }
    protected void DG_NextStep_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            HiddenField hf = (HiddenField)e.Item.FindControl("HiddenField1");
            Label h = (Label)e.Item.FindControl("lbl_Topic");
            int id_RLID = Convert.ToInt32(hf.Value);

            obj_CDetails.CID = id_RLID;

            tagds = obj_CDetails.CDetails_GetSelTags(obj_CDetails);





            for (int m = 0; m < tagds.Tables[0].Rows.Count; m++)
            {

                if (strtags.ToString().Equals(""))
                    strtags += tagds.Tables[0].Rows[m]["CourseName"].ToString();
                else
                    strtags += ", " + tagds.Tables[0].Rows[m]["CourseName"].ToString();

                strparm = strtags;
                h.Text = strparm;
            }
            strtags = "";
        }

    }
    //protected string getEditProfilePage()
    //{
    //    //return "/administration/User_Update.aspx?userid=" + ViewState["USER_ID"].ToString() + "";
    //    string str = string.Empty;
    //    // str = "User_Update.aspx?userid=" + CommonFunctions.EncryptText( ds_Search.Tables[0].Rows[index]["USER_ID"].ToString()).ToString() + "";
    //    DataSet ds = new DataSet();
    //    ds = (DataSet)ViewState["dsData"];
    //    if (index < ds.Tables[0].Rows.Count)
    //    {
    //        str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["CID"].ToString()).ToString();
    //        str = Server.UrlEncode(str);

    //    }
    //    index = index + 1;
    //    return str;


    //}
    protected string getEditProfilePage()
    {

        string str = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["CID"].ToString()).ToString();
            str = Server.UrlEncode(str);

        }
        if (count == 2)
        {
            index = index + 1;
            count = 1;
        }
        else
            count = count + 1;

        return str;

    }


}