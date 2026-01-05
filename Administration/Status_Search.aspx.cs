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


public partial class Masters_Status_Search : System.Web.UI.Page
{
    private Status_Logic ObjStatus = new Status_Logic();
    
    private CommonFunctions CommonFunctions = new CommonFunctions();
    private string StrCheckAccess;
    bool isEditing = false;
   
    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        if (Session["USER_ID"] == null)
        {
            Session["TimeOut"] = true;
            Response.Redirect("Default.aspx");
        }
        if (!(Page.IsPostBack))
        {
            StrCheckAccess = CommonFunctions.CheckAccess(Session["fid"].ToString(), Session["USER_ID"].ToString(), Session["GROUP_ID"].ToString());
            if (instr_fun(StrCheckAccess, "common/Restricted_admin.aspx") > 0)
            {
                Response.Redirect(StrCheckAccess);
            }
            ViewState.Add("Links", StrCheckAccess);

            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
           
        }
        if (!(Page.IsPostBack))
        {
            Bind_Data();
        }
        Label1.Visible = true;
    }

    public int instr_fun(string str1, string str2)
    {
        string SearchString;
        SearchString = str1;
        int myPos = SearchString.IndexOf(str2);
        return myPos;
    }

    void Bind_Data()
    {
        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();

        DG_Status_List.CurrentPageIndex = System.Convert.ToInt16(Session["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        try
        {
            Bind_dataGrid();
        }
        catch
        {
            try
            {
                if (Session["page_no"] != null)
                {
                    DG_Status_List.CurrentPageIndex = System.Convert.ToInt32(Session["page_no"]) - 1;
                }
                else
                {
                    DG_Status_List.CurrentPageIndex = 0;
                    Bind_dataGrid();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                DG_Status_List.Visible = false;
                Lbl_Pageinfo.Visible = false;


            }
        }
    }
    public void ChangeDGPAGE(object objSender, DataGridPageChangedEventArgs objArgs)
    {
        if (ViewState["Sort_On"] != null)
        {
            ObjStatus.Sort_On = ViewState["Sort_On"].ToString();
        }
        else
        {
            ObjStatus.Sort_On = "";
        }

        if (!isEditing)
        {
            DG_Status_List.CurrentPageIndex = objArgs.NewPageIndex;
            Bind_dataGrid();
            Session["page_no"] = DG_Status_List.CurrentPageIndex;
        }



    }

    private void Bind_dataGrid()
    {
        DataSet ds_Search;


        ObjStatus.pro_STATUS_DESCRIPTION = CommonFunctions.delQuote(Txt_StatusDescription.Text);
        ObjStatus.Sort_On = "";
        if (ViewState["Sort_On"] != null)
            ObjStatus.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
        lblError.Visible = false;
        ds_Search = ObjStatus.GetStatusAll();
        if (ds_Search.Tables[0].Rows.Count > 0)
        {

            DG_Status_List.Visible = true;
            lblError.Visible = false;
        }
        else
        {
            Label1.Visible = false;
            DG_Status_List.Visible = false;
            lblError.Visible = true;
        }
        if (this.Txt_Page_Size.Text != "")
        {
            if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
            {
                this.DG_Status_List.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
            }
        }

        DG_Status_List.DataSource = ds_Search;
        DG_Status_List.DataBind();
        if (ds_Search.Tables[0].Rows.Count == 0)
        {
            this.Lbl_Pageinfo.Visible = false;
        }
        else
        {
            Int16 intTo;
            Int16 intFrom;
            if (DG_Status_List.PageSize * (DG_Status_List.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
            {
                intTo = System.Convert.ToInt16(DG_Status_List.PageSize * (DG_Status_List.CurrentPageIndex + 1));
            }
            else
            {
                intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
            }
            intFrom = System.Convert.ToInt16((DG_Status_List.PageSize * DG_Status_List.CurrentPageIndex) + 1);
            this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
            this.Lbl_Pageinfo.Visible = true;
        }


        ds_Search = null;

    }

    protected void DG_Status_List_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        ObjStatus.Sort_On = e.SortExpression;

        ViewState["Sort_On"] = ObjStatus.Sort_On;
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
        Session["page_no"] = DG_Status_List.CurrentPageIndex;
    }

    
  



    protected void DG_Status_List_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        if (!isEditing)
        {
            DG_Status_List.EditItemIndex = e.Item.ItemIndex;
            Bind_dataGrid();
        }

    }

    protected void DG_Status_List_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {

        DG_Status_List.EditItemIndex = -1;
        Bind_dataGrid();

        AddingNew = false;

    }

    protected void DG_Status_List_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        CheckIsEditing(e.CommandName);
        if (e.CommandName == "Delete")
        {

            if (!isEditing)
            {

                string sid = e.Item.Cells[4].Text;

                ObjStatus.Delete_Status(sid);
                DG_Status_List.CurrentPageIndex = 0;
                DG_Status_List.EditItemIndex = -1;
                Bind_dataGrid();
            }

        }


    }

    void CheckIsEditing(string commandName)
    {

        if (DG_Status_List.EditItemIndex != -1)
        {

            // we are currently editing a row
            if (commandName != "Cancel" && commandName != "Update")
            {

                // user's edit changes (if any) will not be committed
                lblError.Text = "Your changes have not been saved yet.  Please press update to save your changes, or cancel to discard your changes, before selecting another item.";
                lblError.Visible = true;
                isEditing = true;
            }
        }
    }

    protected void DG_Status_List_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {

        Page.Validate();

        if (Page.IsValid)
        {


            int stid = Convert.ToInt32(((TextBox)e.Item.Cells[2].FindControl("txt_edit")).Text);
            string sdesc = ((TextBox)e.Item.Cells[3].FindControl("txt_edit1")).Text;
            string id = e.Item.Cells[4].Text;
            ObjStatus.pro_S_ID = id;
            ObjStatus.pro_STATUS_ID = stid;
            ObjStatus.pro_STATUS_DESCRIPTION = sdesc;

            if (AddingNew)
            {
                ObjStatus.addStatus();
            }
            else
            {
                ObjStatus.pro_S_ID = id;
                ObjStatus.Update_Status();
            }
            if (AddingNew)
            {

                DG_Status_List.CurrentPageIndex = 0;
                AddingNew = false;
            }

            // rebind the grid
            DG_Status_List.EditItemIndex = -1;
            Bind_dataGrid();
        }
    }


    protected void DG_Status_List_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType ==  ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            ((LinkButton)e.Item.FindControl("lbtn_delete")).Attributes.Add("onClick", "return confirm('Are you sure to delete the selected items? Once deleted you will not be able to view it again. Click OK to delete. Otherwise, click Cancel.');");
        }
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
                        //h.Attributes.Add("OnClick", "return pageNavigate('Page');");
                        if (i == 0)
                            h.Text = "Page(s) " + h.Text;
                    }
                }
            }
        }
        catch
        { }


    }


    protected bool AddingNew
    {

        get
        {
            object o = ViewState["AddingNew"];
            return (o == null) ? false : (bool)o;
        }
        set
        {
            ViewState["AddingNew"] = value;
        }
    }

    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        DG_Status_List.EditItemIndex = -1;
        DG_Status_List.CurrentPageIndex = 0;
        if (ViewState["Sort_On"] != null)
            ObjStatus.Sort_On = ViewState["Sort_On"].ToString();
        Bind_dataGrid();

    }

    protected void Button_New_Click(object sender, ImageClickEventArgs e)
    {
        if (!isEditing)
        {

            // set the flag so we know to do an insert at Update time
            AddingNew = true;

            // add new row to the end of the dataset after binding

            // first get the data
            ObjStatus.pro_STATUS_DESCRIPTION = CommonFunctions.delQuote(Txt_StatusDescription.Text);
            ObjStatus.Sort_On = "";
            if (ViewState["Sort_On"] != null)
                ObjStatus.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
            lblError.Visible = false;

            DataSet ds = ObjStatus.GetStatusAll();



            // add a new blank row to the end of the data
            object[] rowValues = { Guid.NewGuid(), 0, "" };
            ds.Tables[0].Rows.Add(rowValues);

            // figure out the EditItemIndex, last record on last page
            int recordCount = ds.Tables[0].Rows.Count;
            if (recordCount > 1)
                recordCount--;
            DG_Status_List.CurrentPageIndex = recordCount / DG_Status_List.PageSize;
            DG_Status_List.EditItemIndex = recordCount % DG_Status_List.PageSize;

            // databind
            DG_Status_List.DataSource = ds;
            DG_Status_List.DataBind();

        }

    }
}