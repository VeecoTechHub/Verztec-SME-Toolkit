using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSCommon;
using System.Data;
using System.Configuration;
public partial class Administration_AdminLibraryResources : System.Web.UI.Page
{
    //New version of AdminResourcesLibrary.aspx

    ResourceLibDetails obj_RLDetails = new ResourceLibDetails();
    Check_Access chkAccess = new Check_Access();
    CommonFunctions CommonFunctions = new CommonFunctions();
    public string strparm;
    public string strtags = "";
    DataSet tagds = new DataSet();
    DataSet ds_Search;
    int index = 0;
    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            if (!(Page.IsPostBack))
            {
                token = Request.Form["token"];
                ViewState["ViewToken"] = Request.Form["token"];

                if (ViewState["ViewToken"] == null)
                    Response.Redirect("~/Administration/Default.aspx");
                else
                {
                    if (Session["GROUP_ID"] == null || Session["GROUP_ID"].ToString().ToUpper() != "ADMIN")
                    {
                        Response.Redirect("~/Administration/Default.aspx");
                        return;
                    }
                    DG_ResourcesLibrary.Visible = true;
                }
                bindcategory();

                Bind_Data("", "all");

            }

        }

        catch (Exception ex)
        { throw ex; }

    }
    public void bindcategory()
    {
        DataSet dscat = new DataSet();
        //dscat = obj_RsDetails.Get_Category(obj_RsDetails );
        obj_RLDetails.Type = "RL";

        dscat = obj_RLDetails.Get_ResourceLibCategory(obj_RLDetails);

        ddlCategory.DataSource = dscat;
        ddlCategory.DataTextField = "Topicname";
        ddlCategory.DataValueField = "TopicID";

        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, "ALL");

    }
    protected void Button_New_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Administration/AdminAddResource.aspx?RL_ID=00");
    }
    void Bind_Data(string ptitle, string ptopic)
    {
        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        DG_ResourcesLibrary.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        ddlCategory.DataSource = obj_RLDetails.Get_ResourceLibCategory(obj_RLDetails);
        ddlCategory.DataTextField = "TopicName";
        ddlCategory.DataValueField = "TopicID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, "ALL");
        obj_RLDetails.Title = ptitle;
        obj_RLDetails.Topic = ptopic;
        DG_ResourcesLibrary.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        try
        {
            Bind_dataGrid();
        }
        catch (Exception err)
        {
            try
            {
                DG_ResourcesLibrary.CurrentPageIndex = System.Convert.ToInt32(ViewState["page_no"]) - 1;
                Bind_dataGrid();
            }
            catch
            {
                lblError.Visible = true;
                DG_ResourcesLibrary.Visible = false;
                Lbl_Pageinfo.Visible = false;
            }
        }
    }
    private void Bind_dataGrid()
    {
        try
        {

            Page.Validate();
            if (Page.IsValid)
            {
                obj_RLDetails.SortOn = "";
                obj_RLDetails.SortDirection = "";
                if (ViewState["Sort_On"] != null)
                {
                    obj_RLDetails.SortOn = ViewState["Sort_On"].ToString();
                    obj_RLDetails.SortDirection = ViewState["Sort_By"].ToString();
                }
                lblError.Visible = false;
                obj_RLDetails.Admin = "admin";
                obj_RLDetails.Title = txtCourseTitle.Text.Trim().ToString();
                obj_RLDetails.Topic = ddlCategory.SelectedValue;
                ds_Search = obj_RLDetails.Get_ResourceLibDetails(obj_RLDetails);
                if (ds_Search.Tables[0].Rows.Count > 0)
                {
                    //Button_New.Visible = true;
                    lblError.Visible = false;
                    spSelect.Visible = false;
                    id_btn_Delete.Visible = true ;
                }
                else
                {
                    DG_ResourcesLibrary.DataBind();
                    lblError.Visible = true;
                    lblError.Text = "No Data Available";
                    spSelect.Visible = false;
                    id_btn_Delete.Visible = false;
                    // Button_New.Visible = true;
                }

                if (this.Txt_Page_Size.Text != "")
                {
                    if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                    {
                        this.DG_ResourcesLibrary.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                    }
                }
                else
                {
                    this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
                    this.DG_ResourcesLibrary.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
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
                            //int intPageNo = (ds_Search.Tables[0].Rows.Count) / Convert.ToInt32(Txt_Page_Size.Text);
                            int intPageNo1 = (ds_Search.Tables[0].Rows.Count) % Convert.ToInt32(Txt_Page_Size.Text);
                            if (intPageNo1 > 0)
                            {
                                intPageNo = intPageNo + 1;
                            }
                            DG_ResourcesLibrary.CurrentPageIndex = intPageNo - 1;
                        }
                    }
                    ViewState["dsData"] = ds_Search;
                    if (ViewState["ViewToken"] != null)
                        token = ViewState["ViewToken"].ToString();
                    DG_ResourcesLibrary.DataSource = ds_Search;
                    DG_ResourcesLibrary.DataBind();

                    for (int i = 0; i < DG_ResourcesLibrary.Items.Count; i++)
                    {
                        Label lblStatus = (Label)DG_ResourcesLibrary.Items[i].FindControl("lblStatus");
                        HiddenField hdfldStatus = (HiddenField)DG_ResourcesLibrary.Items[i].FindControl("hdfldStatus");
                        if (hdfldStatus.Value == "0")
                            lblStatus.Text = "Active";
                        else
                            lblStatus.Text = "Inactive";
                    }

                    Int16 intTo;
                    Int16 intFrom;
                    if (DG_ResourcesLibrary.PageSize * (DG_ResourcesLibrary.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                    {
                        intTo = System.Convert.ToInt16(DG_ResourcesLibrary.PageSize * (DG_ResourcesLibrary.CurrentPageIndex + 1));
                    }
                    else
                    {
                        intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                    }
                    intFrom = System.Convert.ToInt16((DG_ResourcesLibrary.PageSize * DG_ResourcesLibrary.CurrentPageIndex) + 1);
                    this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
                    this.Lbl_Pageinfo.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }

    }
    protected void DG_ResourcesLibrary_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        try
        {

            if (e.Item.ItemType == ListItemType.Pager)
            {
                TableCell pager = (TableCell)e.Item.Controls[0];
                int i;
                Label l;
                // LinkButton l;
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
    protected void DG_ResourcesLibrary_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        //if (ViewState["ViewToken"] != null)
        //    token = ViewState["ViewToken"].ToString();
        if (ViewState["Sort_On"] != null)
            obj_RLDetails.SortOn = ViewState["Sort_On"].ToString();
        DG_ResourcesLibrary.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        Bind_dataGrid();
        ViewState["page_no"] = DG_ResourcesLibrary.CurrentPageIndex;
        index = System.Convert.ToInt16((DG_ResourcesLibrary.PageSize * DG_ResourcesLibrary.CurrentPageIndex));
    }
    protected void DG_ResourcesLibrary_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        obj_RLDetails.SortOn = e.SortExpression;
        ViewState["Sort_On"] = obj_RLDetails.SortOn;
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
        ViewState["page_no"] = DG_ResourcesLibrary.CurrentPageIndex;
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
                // _users = _users + "'" + _UsersArr[i].ToString() + "'";


                _users = _UsersArr[i].ToString();
                //changes 
                obj_RLDetails.RL_ID = Convert.ToInt32(_UsersArr[i].ToString());

                // obj_RsDetails.Delete_CategoryDetails(obj_NsDetails);

                // obj_RLDetails.Delete_ResourceLibCategoryDetails(obj_RLDetails);
                obj_RLDetails.Type = "delete";
                //obj_RsDetails.N_ID = Convert.ToInt32(ViewState["nid"].ToString());

                //obj_RsDetails.Delete_CategoryDetails(obj_RsDetails);
                // Insert_Category();

                obj_RLDetails.Title = "";
                obj_RLDetails.Description = "";//id_txt_AddDescription.Text;
                obj_RLDetails.Author = "";
                obj_RLDetails.Published_On = DateTime.Now.Date;
                obj_RLDetails.Created_On = DateTime.Now.Date;
                obj_RLDetails.Created_By = Session["USER_ID"].ToString();
                obj_RLDetails.Updated_On = DateTime.Now.Date;
                obj_RLDetails.Updated_By = Session["USER_ID"].ToString();
                obj_RLDetails.Rating = 0;
                obj_RLDetails.NewsDetails = "";




                obj_RLDetails.Update_ResourceLibDetails(obj_RLDetails);

                //obj_RLDetails(_users);
            }
            if (_users != "")
                _users = _users.Remove(0, 1);

            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) has been successfully deleted.'); location='" + _redirectPath + "';</Script>");

            //Bind_dataGrid();
            //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            //string response = "<script type='text/javascript'>alert('Record(s) has been successfully deleted');parent.mainframe.location.href='" + navurl + "';</script>";
            //Response.Write(response);
        }
    }



    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        DG_ResourcesLibrary.CurrentPageIndex = 0;
        Bind_dataGrid();
    }
    protected void DG_ResourcesLibrary_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("HiddenField1");
            Label h = (Label)e.Item.FindControl("lbl_Topic");
            int id_RLID = Convert.ToInt32(hf.Value);
            obj_RLDetails.RL_ID = id_RLID;
            obj_RLDetails.Type = "RL";
            tagds = obj_RLDetails.GetSelResourceLibCategory(obj_RLDetails);
            for (int m = 0; m < tagds.Tables[0].Rows.Count; m++)
            {
                if (strtags.ToString().Equals(""))
                    strtags += tagds.Tables[0].Rows[m]["TopicName"].ToString();
                else
                    strtags += ", " + tagds.Tables[0].Rows[m]["TopicName"].ToString();
                strparm = strtags;
                h.Text = strparm;
            }
            strtags = "";
        }
    }
    protected string getEditProfilePage()
    {
        string str = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["RL_ID"].ToString()).ToString();
            str = Server.UrlEncode(str);
        }
        index = index + 1;
        return str;
    }

    //protected void Button_New_Click2(object sender, ImageClickEventArgs e)
    //{
    //    string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> location='" + _redirectPath + "';</Script>");
    //}
    protected void Button_New_Click1(object sender, ImageClickEventArgs e)
    {
        string _redirectPath = Convert.ToString(ViewState["t_url"]);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> location='" + _redirectPath + "';</Script>");
    }
}
