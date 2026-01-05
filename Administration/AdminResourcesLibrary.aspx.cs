using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using System.Data.SqlClient;
using ABSCommon;
using ABSDTO;
using System.Text;
using System.Configuration;
using System.IO;

public partial class Administration_AdminResourcesLibrary : System.Web.UI.Page
{
    ResourceLibraryDetails obj_RLDetails = new ResourceLibraryDetails();
    CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
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

            if (!(Page.IsPostBack))
            {
                ViewState["Links"] = chkAccess.initSystem();
                ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
                ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

                token = Request.Form["token"];

                if (token == null)
                    Response.Redirect("~/Administration/Default.aspx");
                else
                    DG_ResourcesLibrary.Visible = true;
                Bind_Data("", "all");
            }

        }

        catch (Exception ex)
        { throw ex; }
      
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
        ddlCategory.DataSource = obj_RLDetails.Get_Tags(obj_RLDetails);
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
                ds_Search = obj_RLDetails.Get_ResourceLibraryDetails(obj_RLDetails);
                if (ds_Search.Tables[0].Rows.Count > 0)
                {
                    //Button_New.Visible = true;
                    lblError.Visible = false;
                }
                else
                {
                    DG_ResourcesLibrary.DataBind();
                    lblError.Visible = true;
                    lblError.Text = "No Data Available";
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
                        if (Convert.ToInt32(ViewState["currentPagNo"]) >= ds_Search.Tables[0].Rows.Count - 1)
                        {
                            int intPageNo = (ds_Search.Tables[0].Rows.Count) / Convert.ToInt32(Txt_Page_Size.Text);
                            int intPageNo1 = (ds_Search.Tables[0].Rows.Count) % Convert.ToInt32(Txt_Page_Size.Text);
                            if (intPageNo1 > 0)
                            {
                                intPageNo = intPageNo + 1;
                            }
                            DG_ResourcesLibrary.CurrentPageIndex = intPageNo - 1;
                        }
                    }
                    ViewState["dsData"] = ds_Search;
                    DG_ResourcesLibrary.DataSource = ds_Search;
                    DG_ResourcesLibrary.DataBind();
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
        if (ViewState["Sort_On"] != null)
            obj_RLDetails.SortOn = ViewState["Sort_On"].ToString();
        DG_ResourcesLibrary.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        Bind_dataGrid();
        ViewState["page_no"] = DG_ResourcesLibrary.CurrentPageIndex;
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
                _users = _users + ",'" + _UsersArr[i].ToString() + "'";
            }
            if (_users != "")
                _users = _users.Remove(0, 1);

            //File delete from folder
            DataSet ds = (DataSet)ViewState["dsData"];
            string Filename = ds.Tables[0].Rows[0][4].ToString();
            string TargetDir = Server.MapPath("~/UploadedFiles/").ToString() + Filename;
            if (File.Exists(TargetDir))
                File.Delete(TargetDir);

            //File delete from Databse
            obj_RLDetails.Delete_Record_ResourceLibrary_By_RLID(_users);

   

            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) has been successfully deleted.'); location='" + _redirectPath + "';</Script>");

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
            tagds = obj_RLDetails.Get_TagSelName(obj_RLDetails);
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
