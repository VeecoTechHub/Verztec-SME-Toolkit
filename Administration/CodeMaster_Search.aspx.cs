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
using System.Threading;

public partial class Administration_CodeMaster_Search : System.Web.UI.Page
{
    private CodeMaster_Logic ObjCodeMaster = new CodeMaster_Logic();
    //UserLogin_Logic myDBConnection = new UserLogin_Logic();
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    private string StrCheckAccess;
    bool isEditing = false;
    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;

      
      

        if (!(Page.IsPostBack))
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];

            token = Request.Form["token"];


            token = Request.Form["token"];
            if (token == null)
            {
                Response.Redirect("~/Administration/Default.aspx");
            }
            else
            {
                if (Session["GROUP_ID"] == null || Session["GROUP_ID"].ToString().ToUpper() != "ADMIN")
                {
                    Response.Redirect("~/Administration/Default.aspx");
                    return;
                }


                if (Session["USER_ID"] != null)
                {
                    ViewState["USER_ID"] = Convert.ToString(Session["USER_ID"]);
                }
               
                bindDropDown();
                Bind_Data();


            }
        }
        //if (!(Page.IsPostBack))
        //{
        //    bindDropDown();
        //    Bind_Data();

        //}
    }

    private void bindDropDown()
    {
        ddlStatusType.DataSource = ObjCodeMaster.getCODESTATUSMASTER();
        ddlStatusType.DataTextField = "STATUS_TYPE";
        ddlStatusType.DataValueField = "STATUS_TYPE";
        ddlStatusType.DataBind();
        ddlStatusType.Items.Insert(0, "ALL");
        ddlStatusType.Items[0].Value = "0";




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

        DG_CodeMaster_List.CurrentPageIndex = System.Convert.ToInt16(Session["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];

        if (Convert.ToBoolean(Session["IsAdmin"]))
            DG_CodeMaster_List.Columns[1].Visible = true;
        else
            DG_CodeMaster_List.Columns[1].Visible = false;

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
                    DG_CodeMaster_List.CurrentPageIndex = System.Convert.ToInt32(Session["page_no"]) - 1;
                }
                else
                {
                    DG_CodeMaster_List.CurrentPageIndex = 0;
                    Bind_dataGrid();
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
                DG_CodeMaster_List.Visible = false;
                Lbl_Pageinfo.Visible = false;


            }
        }
    }

    public void ChangeDGPAGE(object objSender, DataGridPageChangedEventArgs objArgs)
    {
        if (ViewState["Sort_On"] != null)
        {
            ObjCodeMaster.Sort_On = ViewState["Sort_On"].ToString();
        }
        else
        {
            ObjCodeMaster.Sort_On = "";
        }

        if (!isEditing)
        {
            DG_CodeMaster_List.CurrentPageIndex = objArgs.NewPageIndex;
            Bind_dataGrid();
            Session["page_no"] = DG_CodeMaster_List.CurrentPageIndex;
        }

    }

    protected void Bind_dataGrid()
    {
        DataSet ds_Search;
        CodeMaster_Logic ObjCodeMaster = new CodeMaster_Logic();
        if (!ddlStatusType.SelectedValue.Equals("0"))
        {
            ObjCodeMaster.pro_STATUS_TYPE = CommonFunctions.delQuote(ddlStatusType.SelectedItem.Value);
        }

        ObjCodeMaster.pro_STATUS = CommonFunctions.delQuote(Txt_Status.Text);
        ObjCodeMaster.Sort_On = "";
        if (ViewState["Sort_On"] != null)

            //WHILE SORTING ORACLE TREAT UPPERCASE AS HI PRIORITY SO IF WE CONVERT ALL COLMN DATA TO UPPER AS FOLLOWING  IN THE SORT EXPRESSION.SO WE GET EXACT RESULT

            ObjCodeMaster.Sort_On = "UPPER(" + ViewState["Sort_On"].ToString() + ")" + " " + ViewState["Sort_By"].ToString();
        lblError.Visible = false;
        ds_Search = ObjCodeMaster.GetCodeMasterAll();
        Button_New.Visible = true;
        if (ds_Search.Tables[0].Rows.Count > 0)
        {
            lblError.Visible = false;
            DG_CodeMaster_List.Visible = true;
        }
        else
        {
            DG_CodeMaster_List.Visible = false;
            Button_New.Visible = true;
            lblError.Visible = true;
            lblError.Text = "No Data Available";
        }

        if (this.Txt_Page_Size.Text != "")
        {
            if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
            {
                this.DG_CodeMaster_List.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);

            }
        }
        else
        {
            this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
            this.DG_CodeMaster_List.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);

        }

        DG_CodeMaster_List.DataSource = ds_Search;
        DG_CodeMaster_List.DataBind();

        if (ds_Search.Tables[0].Rows.Count == 0)
        {
            this.Lbl_Pageinfo.Visible = false;
        }
        else
        {
            Int16 intTo;
            Int16 intFrom;
            if (DG_CodeMaster_List.PageSize * (DG_CodeMaster_List.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
            {
                intTo = System.Convert.ToInt16(DG_CodeMaster_List.PageSize * (DG_CodeMaster_List.CurrentPageIndex + 1));
            }
            else
            {
                intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
            }
            intFrom = System.Convert.ToInt16((DG_CodeMaster_List.PageSize * DG_CodeMaster_List.CurrentPageIndex) + 1);
            this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
            this.Lbl_Pageinfo.Visible = true;
        }


        ds_Search = null;

    }

    protected void DG_CodeMaster_List_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        ObjCodeMaster.Sort_On = e.SortExpression;

        ViewState["Sort_On"] = ObjCodeMaster.Sort_On;
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
        Session["page_no"] = DG_CodeMaster_List.CurrentPageIndex;
    }

    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        DG_CodeMaster_List.EditItemIndex = -1;
        DG_CodeMaster_List.CurrentPageIndex = 0;
        if (ViewState["Sort_On"] != null)
            ObjCodeMaster.Sort_On = ViewState["Sort_On"].ToString();
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
            if (!ddlStatusType.SelectedValue.Equals("0"))
                ObjCodeMaster.pro_STATUS_TYPE = CommonFunctions.delQuote(ddlStatusType.SelectedItem.Text);
            ObjCodeMaster.pro_STATUS = CommonFunctions.delQuote(Txt_Status.Text);
            ObjCodeMaster.Sort_On = "";
            if (ViewState["Sort_On"] != null)
                ObjCodeMaster.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
            lblError.Visible = false;

            DataSet ds = ObjCodeMaster.GetCodeMasterAll();



            // add a new blank row to the end of the data
            object[] rowValues = { System.Guid.NewGuid(), "", "", "", 0, 0 };
            ds.Tables[0].Rows.Add(rowValues);

            // figure out the EditItemIndex, last record on last page
            int recordCount = ds.Tables[0].Rows.Count;
            if (recordCount > 1)
                recordCount--;
            DG_CodeMaster_List.CurrentPageIndex = recordCount / DG_CodeMaster_List.PageSize;
            DG_CodeMaster_List.EditItemIndex = recordCount % DG_CodeMaster_List.PageSize;

            // databind
            DG_CodeMaster_List.DataSource = ds;
            DG_CodeMaster_List.DataBind();
        }
    }

    protected void DG_CodeMaster_List_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        if (!isEditing)
        {
            DG_CodeMaster_List.EditItemIndex = e.Item.ItemIndex;
            Bind_dataGrid();
        }

        //DropDownList ddlStatus = ((DropDownList)e.Item.Cells[8].FindControl("ddlStatus"));
        //ddlStatus.DataSource = ObjCodeMaster.getStatus();
        //ddlStatus.DataValueField = "StatusId";
        //ddlStatus.DataTextField = "StatusDescription";
        //ddlStatus.DataBind();
    }

    protected void DG_CodeMaster_List_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {

        DG_CodeMaster_List.EditItemIndex = -1;
        Bind_dataGrid();

        AddingNew = false;

    }

    protected void DG_CodeMaster_List_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        CheckIsEditing(e.CommandName);
        if (e.CommandName == "Delete")
        {

            if (!isEditing)
            {

                string sid = e.Item.Cells[6].Text;//Code Id

                ObjCodeMaster.Delete_CodeMaster(sid);
                DG_CodeMaster_List.CurrentPageIndex = 0;
                DG_CodeMaster_List.EditItemIndex = -1;
                bindDropDown();
                Bind_dataGrid();
            }

        }


    }

    void CheckIsEditing(string commandName)
    {

        if (DG_CodeMaster_List.EditItemIndex != -1)
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

    protected void DG_CodeMaster_List_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {

            string stype = ((TextBox)e.Item.Cells[2].FindControl("txt_edit")).Text;//Status Type
            string status = ((TextBox)e.Item.Cells[3].FindControl("txt_edit1")).Text;// Status
            string sdesc = ((TextBox)e.Item.Cells[4].FindControl("txt_edit2")).Text;// Status Description
            string value2 = ((TextBox)e.Item.Cells[7].FindControl("txtValue2")).Text;
            int CStatus = int.Parse(((DropDownList)e.Item.Cells[8].FindControl("ddlStatus")).SelectedItem.Value);// Code_Status

            int sort, value;//Sort Order
            if (((TextBox)e.Item.Cells[5].FindControl("txt_edit3")).Text == "")
            {
                sort = 0;
            }
            else
            {
                sort = Convert.ToInt32(((TextBox)e.Item.Cells[5].FindControl("txt_edit3")).Text);
            }

            if (((TextBox)e.Item.Cells[5].FindControl("txt_edit4")).Text == "")
            {
                value = 0;
            }
            else
            {
                value = Convert.ToInt32(((TextBox)e.Item.Cells[5].FindControl("txt_edit4")).Text);
            }

            string id = e.Item.Cells[6].Text;// Code Id
            ObjCodeMaster.pro_CODE_ID = id;
            ObjCodeMaster.pro_STATUS_TYPE = stype;
            ObjCodeMaster.pro_STATUS = status;
            ObjCodeMaster.pro_STATUS_DESCRIPTION = sdesc;
            ObjCodeMaster.pro_SORT_ORDER = sort;
            ObjCodeMaster.Value = value;
            ObjCodeMaster.Value2 = value2;
            ObjCodeMaster.CStatus = CStatus;
            ObjCodeMaster.CREAT_BY = Convert.ToString(ViewState["USER_ID"]);
            ObjCodeMaster.MAINT_BY = Convert.ToString(ViewState["USER_ID"]);


            if (AddingNew)
            {
                ObjCodeMaster.addCodeMaster();
            }
            else
            {
                ObjCodeMaster.pro_CODE_ID = id;
                ObjCodeMaster.Update_CodeMaster();
            }
            if (AddingNew)
            {

                DG_CodeMaster_List.CurrentPageIndex = 0;
                AddingNew = false;
            }

            // rebind the grid
            DG_CodeMaster_List.EditItemIndex = -1;
            Bind_dataGrid();

            bindDropDown();
        }

    }

    protected void DG_CodeMaster_List_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            ((LinkButton)e.Item.FindControl("lbtn_delete")).Attributes.Add("onClick", "return confirm('Are you sure to delete the selected items? Once deleted you will not be able to view it again. Click OK to delete. Otherwise, click Cancel.');");

        }

        if (e.Item.ItemType == ListItemType.EditItem)
        {
            DropDownList ddlStatus = ((DropDownList)e.Item.Cells[8].FindControl("ddlStatus"));
            ddlStatus.Items.Add("ACTIVE");
            ddlStatus.Items[0].Value = "1";
            ddlStatus.Items.Add("IN ACTIVE");
            ddlStatus.Items[1].Value = "0";
            ddlStatus.ClearSelection();
            string value = ObjCodeMaster.GetCode_Status(DG_CodeMaster_List.DataKeys[e.Item.ItemIndex].ToString());
            if (!value.Equals("null"))
                ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(value));
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

    protected void ODSCodeMaster_Selected(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }

    //public string getCode_Status(string code)
    //{
    //    return ObjCodeMaster.getStatusCodeValue(code);
    //}
}

