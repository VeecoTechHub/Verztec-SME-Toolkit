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

public partial class Administration_Admin_TopicsList : System.Web.UI.Page
{
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
                    DG_Topics.Visible = true;

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
        //this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        DG_Topics.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        obj_RLDetails.Title = ptitle;
        obj_RLDetails.Topic = ptopic;
        DG_Topics.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        try
        {
            Bind_dataGrid();
        }
        catch (Exception err)
        {
            try
            {
                DG_Topics.CurrentPageIndex = System.Convert.ToInt32(ViewState["page_no"]) - 1;
                Bind_dataGrid();
            }
            catch
            {
                lblError.Visible = true;
                DG_Topics.Visible = false;
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
                lblError.Visible = false;
                obj_RLDetails.action = "All";
                ds_Search = obj_RLDetails.GetTopicDetails(obj_RLDetails);
                if (ds_Search.Tables[0].Rows.Count > 0)
                {
                    //Button_New.Visible = true;
                    lblError.Visible = false;
                    spSelect.Visible = true;
                    //id_btn_Delete.Visible = true;
                }
                else
                {
                    DG_Topics.DataBind();
                    lblError.Visible = true;
                    lblError.Text = "No Data Available";
                    spSelect.Visible = false;
                    id_btn_Delete.Visible = false;
                    // Button_New.Visible = true;
                }

                //if (this.Txt_Page_Size.Text != "")
                //{
                //    if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                //    {
                //        this.DG_Topics.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                //    }
                //}
                //else
                //{
                //    this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
                //    this.DG_Topics.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                //}


                if (ds_Search.Tables[0].Rows.Count == 0)
                {
                    this.Lbl_Pageinfo.Visible = false;
                }
                else
                {
                    if (ViewState["currentPagNo"] != null)
                    {
                        //int intPageNo = (ds_Search.Tables[0].Rows.Count) / Convert.ToInt32(Txt_Page_Size.Text);
                        //if (Convert.ToInt32(ViewState["currentPagNo"]) >= intPageNo)
                        //{
                        //    //int intPageNo = (ds_Search.Tables[0].Rows.Count) / Convert.ToInt32(Txt_Page_Size.Text);
                        //    int intPageNo1 = (ds_Search.Tables[0].Rows.Count) % Convert.ToInt32(Txt_Page_Size.Text);
                        //    if (intPageNo1 > 0)
                        //    {
                        //        intPageNo = intPageNo + 1;
                        //    }
                        //    DG_Topics.CurrentPageIndex = intPageNo - 1;
                        //}
                    }
                    ViewState["dsData"] = ds_Search;
                    if (ViewState["ViewToken"] != null)
                        token = ViewState["ViewToken"].ToString();
                    DG_Topics.DataSource = ds_Search;
                    DG_Topics.DataBind();
                    Int16 intTo;
                    Int16 intFrom;
                    if (DG_Topics.PageSize * (DG_Topics.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                    {
                        intTo = System.Convert.ToInt16(DG_Topics.PageSize * (DG_Topics.CurrentPageIndex + 1));
                    }
                    else
                    {
                        intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                    }
                    intFrom = System.Convert.ToInt16((DG_Topics.PageSize * DG_Topics.CurrentPageIndex) + 1);
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
    protected void DG_Topics_ItemCreated(object sender, DataGridItemEventArgs e)
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
    protected void DG_Topics_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        if (ViewState["ViewToken"] != null)
            token = ViewState["ViewToken"].ToString();
        DG_Topics.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        Bind_dataGrid();
        ViewState["page_no"] = DG_Topics.CurrentPageIndex;
        index = System.Convert.ToInt16((DG_Topics.PageSize * DG_Topics.CurrentPageIndex));
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
            string strCategories = obj_RLDetails.ValidateTopicDetails(_UsersArr);
            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            if (!string.IsNullOrEmpty(strCategories))
            {
                if (_UsersArr.Length == 1)
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Can not delete the selected Category, as it contain Articles.'); location='" + _redirectPath + "';</Script>");
                else
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Can not delete some Categories, as they have Articles.'); location='" + _redirectPath + "';</Script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) has been successfully deleted.'); location='" + _redirectPath + "';</Script>");
            }

            //string _users = "";
            //for (int i = 0; i < _UsersArr.Length; i++)
            //{
            //    _users = _UsersArr[i].ToString();
            //    //changes 
            //    obj_RLDetails.TopicIDS = _UsersArr[i].ToString();
            //    obj_RLDetails.action = "D";
            //    obj_RLDetails.InsertTopicDetails(obj_RLDetails);
            //}
            //if (_users != "")
            //    _users = _users.Remove(0, 1);

            //string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) has been successfully deleted.'); location='" + _redirectPath + "';</Script>");
        }
    }
    protected string getEditProfilePage()
    {
        string str = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["TopicID"].ToString()).ToString();
            str = Server.UrlEncode(str);
        }
        index = index + 1;
        return str;


    }
}
