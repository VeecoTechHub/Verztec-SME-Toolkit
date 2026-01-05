using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Administration_FAQ_Search : System.Web.UI.Page
{
    private FaqMgmt ObjFaq = new FaqMgmt();

    Check_Access chkAccess = new Check_Access();
    private CommonFunctions CommonFunctions = new CommonFunctions();

    DataSet ds_Search = new DataSet();
    int index;
    protected void Page_Load(object sender, EventArgs e)
    {


       
      
        DG_Faq.Visible = true;
        if (!(Page.IsPostBack))
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            Bind_Data();
        }
        //Button_Delete.Attributes.Add("onClick", "return confirm('Are you sure to delete the selected items? Once deleted you will not be able to view it again. Click OK to delete. Otherwise, click Cancel.');");
        Button_Delete.Attributes.Add("onClick", "return confirm('Are you sure to delete the selected faq(s)?');");
    }



    void Bind_Data()
    {

        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        DataSet dsCategory;
        ddlCategory.Items.Clear();
        dsCategory = ObjFaq.getDataForCategory();
        ddlCategory.DataSource = dsCategory;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CategoryId";
        ddlCategory.DataBind();
        ListItem liCategory = new ListItem("ALL", "0");
        ddlCategory.Items.Insert(0, liCategory);
        dsCategory = null;



        DG_Faq.CurrentPageIndex = System.Convert.ToInt16(ViewState["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        try
        {
            Bind_dataGrid();
        }
        catch (Exception err)
        {
            try
            {
                DG_Faq.CurrentPageIndex = System.Convert.ToInt32(ViewState["page_no"]) - 1;
                Bind_dataGrid();
            }
            catch
            {
                lblError.Visible = true;
                //pnluser.Visible = false;
                DG_Faq.Visible = false;
                Lbl_Pageinfo.Visible = false;
            }
        }

    }
    protected void Button_New_Click(object sender, EventArgs e)
    {
        Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[1]));
    }

    private void Bind_dataGrid()
    {
       

        Page.Validate();
        if (Page.IsValid)
        {
            if (ddlCategory.SelectedValue != "0")
            {
                ObjFaq.CategoryId = CommonFunctions.delQuote(ddlCategory.SelectedValue);
            }

            //ObjFaq.DeptID = CommonFunctions.delQuote(Lst_Dept.SelectedItem.Value);
            ObjFaq.Sort_On = "";
            ObjFaq.Sort_Direction = "";
            if (ViewState["Sort_On"] != null)
            {
                ObjFaq.Sort_On = ViewState["Sort_On"].ToString();
                ObjFaq.Sort_Direction = ViewState["Sort_By"].ToString();
            }
            lblError.Visible = false;
            ds_Search = ObjFaq.getAllFaq();

            if (ds_Search.Tables[0].Rows.Count > 0)
            {
                spSelect.Visible = true;
                DG_Faq.Visible = true;
                Button_Delete.Visible = true;
                Button_New.Visible = true;
                lblError.Visible = false;
            }
            else
            {
                spSelect.Visible = false;
                DG_Faq.Visible = false;
                Button_Delete.Visible = false;
                lblError.Visible = true;
                lblError.Text = "No Data Available";
                Button_New.Visible = true;
                //pnluser.Visible = false;
            }
            if (this.Txt_Page_Size.Text != "")
            {
                if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                {
                    this.DG_Faq.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                }
            }
            else
            {
                this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
                this.DG_Faq.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
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
                        DG_Faq.CurrentPageIndex = intPageNo-1;
                    }
                }
                DG_Faq.DataSource = ds_Search;
                DG_Faq.DataBind();
                Int16 intTo;
                Int16 intFrom;
                if (DG_Faq.PageSize * (DG_Faq.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                {
                    intTo = System.Convert.ToInt16(DG_Faq.PageSize * (DG_Faq.CurrentPageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                }
                intFrom = System.Convert.ToInt16((DG_Faq.PageSize * DG_Faq.CurrentPageIndex) + 1);
                this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
                this.Lbl_Pageinfo.Visible = true;
            }
        }
        //ds_Search = null;

    }


    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        DG_Faq.CurrentPageIndex = 0;
        //ObjFaq.Sort_On = ViewState["Sort_On"].ToString(); 
        Bind_dataGrid();
    }

    protected void Button_Delete_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["Cbx_uid"] == null)
        {
            this.lblError.Text = "Please select at least one faq to delete.";
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
            ObjFaq.deleteFaq(_users);
            string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            string response = "<script type='text/javascript'>alert('faq has been successfully deleted');parent.mainframe.location.href='" + navurl + "';</script>";
            Response.Write(response);

            // Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0] + "?showList=Y");
        }
    }

    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddTLD.aspx");
    }


    protected void DG_Faq_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            ObjFaq.Sort_On = ViewState["Sort_On"].ToString();
        DG_Faq.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        Bind_dataGrid();
        ViewState["page_no"] = DG_Faq.CurrentPageIndex;
    }
    protected void DG_Faq_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        ObjFaq.Sort_On = e.SortExpression;

        ViewState["Sort_On"] = ObjFaq.Sort_On;
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
        ViewState["page_no"] = DG_Faq.CurrentPageIndex;
    }
    protected void DG_Faq_ItemCreated(object sender, DataGridItemEventArgs e)
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
    protected void Button_New_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[1]));
        Response.Redirect("FAQ_Add.aspx");
    }

    protected string getEditProfilePage()
    {
        string str = string.Empty;
        if (index < ds_Search.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds_Search.Tables[0].Rows[index]["FaqId"].ToString());
            Server.UrlEncode(str);
        }
        index = index + 1;
        return str;
    }
}