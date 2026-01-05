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

public partial class Administration_HealthProfiling : System.Web.UI.Page
{


    HealthProfiling obj_HPDetails = new HealthProfiling();

    ResourceLibDetails obj_RLDetails = new ResourceLibDetails();

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
                    DG_HealthProfile.Visible = true;
               
               
                Bind_Data("", "all");
               // Bind_QueCategory();
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


    }
    protected void Button_New_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Administration/AdminAddResource.aspx?RL_ID=00");
    }
    void Bind_Data(string ptitle, string ptopic)
    {
        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        DG_HealthProfile.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];

        DG_HealthProfile.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        try
        {
            Bind_dataGrid();
        }
        catch (Exception err)
        {
            try
            {
                DG_HealthProfile.CurrentPageIndex = System.Convert.ToInt32(ViewState["page_no"]) - 1;
                Bind_dataGrid();
            }
            catch
            {
                lblError.Visible = true;
                DG_HealthProfile.Visible = false;
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
                obj_HPDetails.Type = "all";
                obj_HPDetails.Qid = 0;
                obj_HPDetails.Qdescription = txt_Description.Text;
                obj_HPDetails.Category = "Cat";




                ds_Search = obj_HPDetails.Get_HealthProfileDetails(obj_HPDetails);
                if (ds_Search.Tables[0].Rows.Count > 0)
                {
                    //Button_New.Visible = true;
                    lblError.Visible = false;
                    spSelect.Visible = true;
                    id_btn_Delete.Visible = true;
                }
                else
                {
                    DG_HealthProfile.DataBind();
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
                        this.DG_HealthProfile.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);

                    }
                }
                else
                {
                    this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
                    this.DG_HealthProfile.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
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
                            DG_HealthProfile.CurrentPageIndex = intPageNo - 1;
                        }
                    }
                    ViewState["dsData"] = ds_Search;
                    DG_HealthProfile.DataSource = ds_Search;
                    DG_HealthProfile.DataBind();
                    Int16 intTo;
                    Int16 intFrom;
                    if (DG_HealthProfile.PageSize * (DG_HealthProfile.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                    {
                        intTo = System.Convert.ToInt16(DG_HealthProfile.PageSize * (DG_HealthProfile.CurrentPageIndex + 1));
                    }
                    else
                    {
                        intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                    }
                    intFrom = System.Convert.ToInt16((DG_HealthProfile.PageSize * DG_HealthProfile.CurrentPageIndex) + 1);
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
    protected void DG_HealthProfile_ItemCreated(object sender, DataGridItemEventArgs e)
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
    protected void DG_HealthProfile_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            obj_RLDetails.SortOn = ViewState["Sort_On"].ToString();
        DG_HealthProfile.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        Bind_dataGrid();
        ViewState["page_no"] = DG_HealthProfile.CurrentPageIndex;
    }
    protected void DG_HealthProfile_SortCommand(object source, DataGridSortCommandEventArgs e)
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
        ViewState["page_no"] = DG_HealthProfile.CurrentPageIndex;
    }
    protected void id_btn_Delete_Click(object sender, ImageClickEventArgs e)
    {

        // if (Request["Cbx_uid"] == null)

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

                _users = _UsersArr[i].ToString();
                //changes 
                obj_HPDetails.Qid = Convert.ToInt32(_UsersArr[i].ToString());

                obj_HPDetails.Type = "delete";

                obj_HPDetails.Update_HealthProfileDetails(obj_HPDetails);



                //}
                if (_users != "")
                    _users = _users.Remove(0, 1);

                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) has been successfully deleted.'); location='" + _redirectPath + "';</Script>");


            }
        }
    }




    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        DG_HealthProfile.CurrentPageIndex = 0;
        Bind_dataGrid();
    }
    //public void Bind_QueCategory()
    //{
    //    DataSet dscat = new DataSet();
    //    dscat = obj_HPDetails.Get_QueCategory();
    //    ddlCategory.DataSource = dscat;
    //  //  ddlCategory.DataMember = "Category";
    //    ddlCategory.DataTextField = "Category";
    //    ddlCategory.DataBind();
    //    //ddlCategory.Items.Insert(0, "Select");
    //}
    protected void DG_HealthProfile_ItemDataBound(object sender, DataGridItemEventArgs e)
    {

    }
    protected string getEditProfilePage()
    {
        string str = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["QId"].ToString()).ToString();
            str = Server.UrlEncode(str);
        }
        index = index + 1;
        return str;


    }


    protected void Button_New_Click1(object sender, ImageClickEventArgs e)
    {
        string _redirectPath = Convert.ToString(ViewState["t_url"]);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> location='" + _redirectPath + "';</Script>");
    }

}
