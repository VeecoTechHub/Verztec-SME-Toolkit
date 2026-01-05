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


public partial class Administration_Admin_NewsAnnouncement : System.Web.UI.Page
{

    NewsAnnouncementDetails obj_NsDetails = new NewsAnnouncementDetails();
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

      
        if (!Page.IsPostBack)
        {

            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
            token = Request.Form["token"];
           // ViewState["t_url"] = "AdminResourcesLibrary.aspx?RL_ID=00";
            if (token == null)
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                bindcategory();
                //Bind_Data("", "all");
                Bind_Data("", "all");

            }
        }
    }

    public void bindcategory()
    {
        DataSet dscat = new DataSet();
        dscat = obj_NsDetails.Get_Category(obj_NsDetails);
        ddlCategory.DataSource = dscat;
        ddlCategory.DataTextField = "Topicname";
        ddlCategory.DataValueField = "TopicID";

        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, "ALL");

    }

    void Bind_Data(string ptitle, string ptopic)
    {
        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        DG_NewsDetails.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);


        obj_NsDetails.Title = ptitle;
        obj_NsDetails.Topic = ptopic;
        ds_Search = obj_NsDetails.Get_NewsDetails(obj_NsDetails);
        if (ds_Search.Tables[0].Rows.Count > 0)
        {
            DG_NewsDetails.DataSource = ds_Search;
            DG_NewsDetails.DataBind();
            ViewState["dsData"] = ds_Search;
            lblError.Visible = false;
        }
        else
        {
            DG_NewsDetails.Visible = false;
            lblError.Visible = true;
        }



        //ddlCategory.DataTextField = "TopicName";
        //ddlCategory.DataValueField = "TopicID";
        //ddlCategory.DataBind();
        //ddlCategory.Items.Insert(0, "ALL");
        //obj_NsDetails.Title = ptitle;
        //obj_NsDetails.Topic = ptopic;
    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        //Bind_Data(txtNewsTitle.Text, ddlCategory.SelectedValue.ToString());
        DG_NewsDetails .CurrentPageIndex = 0;
        Bind_dataGrid();
       // Bind_Data(txtNewsTitle.Text, ddlCategory.SelectedValue.ToString());
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
                obj_NsDetails.N_ID = Convert.ToInt32(_UsersArr[i].ToString());

                obj_NsDetails.Delete_CategoryDetails(obj_NsDetails);
                deleteNews(_users);
            }
            if (_users != "")
                _users = _users.Remove(0, 1);
           
            ////File delete from folder
            //DataSet ds = (DataSet)ViewState["dsData"];
            //string Filename = ds.Tables[0].Rows[0][4].ToString();
            //string TargetDir = Server.MapPath("~/UploadedFiles/").ToString() + Filename;
            //if (File.Exists(TargetDir))
            //    File.Delete(TargetDir);

            ////File delete from Databse
           
            

            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) has been successfully deleted.'); location='" + _redirectPath + "';</Script>");

            
        }

    }
    public void deleteNews(string  nid)
    {



        obj_NsDetails.Type = "delete";
        obj_NsDetails.Title = "";
        obj_NsDetails.Description = "";
        obj_NsDetails.Author = "";
        obj_NsDetails.Published_On = DateTime.Now.Date;
        obj_NsDetails.Created_On = DateTime.Now.Date;
        obj_NsDetails.Created_By = Session["USER_ID"].ToString();
        obj_NsDetails.Updated_On = DateTime.Now.Date;
        obj_NsDetails.Updated_By = Session["USER_ID"].ToString();
        obj_NsDetails.Rating = 1;
        obj_NsDetails.NewsDetails = "";
        obj_NsDetails.N_ID = Convert.ToInt32(nid);  


        //ViewState["id"] = obj_NsDetails.N_ID;
        //obj_NsDetails.N_ID = Convert.ToInt32(ViewState["id"].ToString());

        int id = obj_NsDetails.Update_NewsDetails(obj_NsDetails);


    
    }
    protected void Button_New_Click1(object sender, ImageClickEventArgs e)
    {

    }
    protected string getEditProfilePage()
    {
        string str = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["N_ID"].ToString()).ToString();
            str = Server.UrlEncode(str);
        }
        index = index + 1;
        return str;


    }
    protected void DG_NewsDetails_ItemCommand(object source, DataGridCommandEventArgs e)
    {

    }
    protected void DG_NewsDetails_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("HiddenField1");
            Label h = (Label)e.Item.FindControl("lbl_Topic");
            int N_ID = Convert.ToInt32(hf.Value);
            obj_NsDetails.N_ID = N_ID;
            tagds = obj_NsDetails.GetSelCategory(obj_NsDetails);
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
    protected void DG_NewsDetails_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        //changes  
        //changes done

       // if (ViewState["Sort_On"] != null)
           // obj_RLDetails.SortOn = ViewState["Sort_On"].ToString();
        DG_NewsDetails.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        Bind_dataGrid();
        ViewState["page_no"] = DG_NewsDetails.CurrentPageIndex;
    }
    private void Bind_dataGrid()
    {
        try
        {

            Page.Validate();
            if (Page.IsValid)
            {
                //obj_RLDetails.SortOn = "";
                //obj_RLDetails.SortDirection = "";
                //if (ViewState["Sort_On"] != null)
                //{
                //    obj_RLDetails.SortOn = ViewState["Sort_On"].ToString();
                //    obj_RLDetails.SortDirection = ViewState["Sort_By"].ToString();
                //}
                lblError.Visible = false;
                obj_NsDetails.Admin = "admin";
                obj_NsDetails.Title = txtNewsTitle.Text.Trim().ToString();
                obj_NsDetails.Topic = ddlCategory.SelectedValue;
                //ds_Search = obj_RLDetails.Get_ResourceLibraryDetails(obj_RLDetails);
                ds_Search = obj_NsDetails.Get_NewsDetails(obj_NsDetails);

                //changes did
                DG_NewsDetails.DataSource = ds_Search;
                DG_NewsDetails.DataBind();
                if (ds_Search.Tables[0].Rows.Count > 0)
                {
                    //Button_New.Visible = true;
                    lblError.Visible = false;
                    DG_NewsDetails.Visible = true;
                    spSelect.Visible = true;
                    id_btn_Delete.Visible = true;
                }
                else
                {
                    DG_NewsDetails.Visible = false;
                    DG_NewsDetails .DataBind();
                    lblError.Visible = true;
                    lblError.Text = "No Data Available";
                    // Button_New.Visible = true;
                    spSelect.Visible = false;
                    id_btn_Delete.Visible = false;

                  //   fdss
                }

                if (this.Txt_Page_Size.Text != "")
                {
                    if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                    {
                        this.DG_NewsDetails.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                    }
                }
                else
                {
                    this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
                    this.DG_NewsDetails.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
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
                            DG_NewsDetails.CurrentPageIndex = intPageNo - 1;
                        }
                    }
                    ViewState["dsData"] = ds_Search;
                    DG_NewsDetails.DataSource = ds_Search;
                    DG_NewsDetails.DataBind();
                    Int16 intTo;
                    Int16 intFrom;
                    if (DG_NewsDetails.PageSize * (DG_NewsDetails.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                    {
                        intTo = System.Convert.ToInt16(DG_NewsDetails.PageSize * (DG_NewsDetails.CurrentPageIndex + 1));
                    }
                    else
                    {
                        intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                    }
                    intFrom = System.Convert.ToInt16((DG_NewsDetails.PageSize * DG_NewsDetails.CurrentPageIndex) + 1);
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
    protected void DG_NewsDetails_ItemCreated(object sender, DataGridItemEventArgs e)
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
}