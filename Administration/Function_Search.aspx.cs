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
public partial class Administration_Function_Search : System.Web.UI.Page
{
    private DataSet DS_Temp;
    private Function_Maintain_Logic my_Function_Maintain_Logic = new Function_Maintain_Logic();
    int index = 0;
    private string StrCheckAccess;
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
        Lblnorecords.Text = "";
   

        this.DG_Function_List.CurrentPageIndex = 0;


        if (!(Page.IsPostBack))
        {

            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_urladd"] = "../" + ViewState["Links"].ToString().Split('|')[1];
            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[0];

            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
            token = Request.Form["token"];

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {
                Bind_Data();
            }
            //           Button_delete.Attributes.Add("onClick", "return confirm('Are you sure you want to delete the selected items? Once deleted you will not be able to view it again. Click OK to delete. Otherwise, click Cancel.');");


        }
    }

    public void ChangeDGPAGE(object objSender, DataGridPageChangedEventArgs objArgs)
    {
        if (ViewState["Sort_On"] != null)
            my_Function_Maintain_Logic.Str_Sort_On = ViewState["Sort_On"].ToString();


        DG_Function_List.CurrentPageIndex = objArgs.NewPageIndex;
        Bind_DataGrid();
        Session["page_no"] = DG_Function_List.CurrentPageIndex;
    }


    private void Bind_Data()
    {
        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        DS_Temp = my_Function_Maintain_Logic.Get_Parent_Menu();
        Lst_Parent_Menu.DataSource = DS_Temp;
        Lst_Parent_Menu.DataTextField = "STATUS";
        Lst_Parent_Menu.DataValueField = "STATUS";
        Lst_Parent_Menu.DataBind();
        this.Lst_Parent_Menu.Items.Insert(0, "All");
        this.Lst_Parent_Menu.Items[0].Value = "0";

        Bind_DataGrid();
        try
        {
            DG_Function_List.CurrentPageIndex = System.Convert.ToInt32(Session["page_no"]);
        }
        catch
        {
        }
        try
        {
            ViewState["Sort_On"] = Session["sort_on"];
        }
        catch
        {
        }
        try
        {
            Bind_DataGrid();
        }
        catch
        {
            try
            {
                DG_Function_List.CurrentPageIndex = System.Convert.ToInt32(Session["page_no"]) - 1;
                Bind_DataGrid();
            }
            catch
            {
                Lblnorecords.Text = "No records found.";
                this.Lblnorecords.Visible = true;
                DG_Function_List.Visible = false;
                Lbl_Pageinfo.Visible = false;
                //this.pnluser.Visible = false;
            }
        }
    }

    private void Bind_DataGrid()
    {

        my_Function_Maintain_Logic.Str_Sort_On = "";

        if (ViewState["Sort_On"] != null)
            my_Function_Maintain_Logic.Str_Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();

        DS_Temp = my_Function_Maintain_Logic.Get_Function_List(this.Lst_Parent_Menu.SelectedItem.Value, this.Txt_FunctionId.Text, this.Txt_Short_Desc.Text, this.Txt_Description.Text);
        Button_delete.Visible = true;
       // Button_add.Visible = true;
        if (DS_Temp.Tables[0].Rows.Count == 0)
        {
            Lblnorecords.Text = "Records Not Found";
            this.Lblnorecords.Visible = true;
            //this.pnluser.Visible = false;
            //this.DG_Function_List.Visible = false;
            //this.Lbl_Pageinfo.Visible = false;
            DG_Function_List.Visible = false;
            Button_delete.Visible = false;
           // Button_add.Visible = true;
        }
        else
        {
            this.Lbl_Pageinfo.Text = DG_Function_List.CurrentPageIndex + " of " + DG_Function_List.PageCount;
            this.Lbl_Pageinfo.Visible = true;
            this.DG_Function_List.Visible = true;
            this.Lblnorecords.Visible = false;
            //this.pnluser.Visible = true;
        }
        if (this.Txt_Page_Size.Text.Trim() != "")
        {
            if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
            {
                this.DG_Function_List.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
            }
        }

        else
        {
            this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
            this.DG_Function_List.PageSize = Convert.ToInt32(this.Txt_Page_Size.Text);
        }
        ViewState["dsData"] = DS_Temp;
        this.DG_Function_List.DataSource = DS_Temp;
        this.DG_Function_List.DataBind();
        if (DS_Temp.Tables[0].Rows.Count == 0)
        {
            this.Lbl_Pageinfo.Visible = false;
        }
        else
        {
            Int16 intTo;
            Int16 intFrom;
            if (DG_Function_List.PageSize * (DG_Function_List.CurrentPageIndex + 1) < DS_Temp.Tables[0].Rows.Count)
            {
                intTo = System.Convert.ToInt16(DG_Function_List.PageSize * (DG_Function_List.CurrentPageIndex + 1));

            }
            else
            {
                intTo = System.Convert.ToInt16(DS_Temp.Tables[0].Rows.Count);
            }
            intFrom = System.Convert.ToInt16((DG_Function_List.PageSize * DG_Function_List.CurrentPageIndex) + 1);
            this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + DS_Temp.Tables[0].Rows.Count;
            this.Lbl_Pageinfo.Visible = true;
        }
    }

    protected void DG_Function_List_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        my_Function_Maintain_Logic.Str_Sort_On = e.SortExpression;

        ViewState["Sort_On"] = my_Function_Maintain_Logic.Str_Sort_On;
        if (ViewState["Sort_By"] == null)
            ViewState["Sort_By"] = " Asc ";

        if (ViewState["Sort_By"].ToString() == " Asc ")
        {
            ViewState["Sort_By"] = " Desc ";
        }
        else
        {
            ViewState["Sort_By"] = " Asc ";
        }


        this.DG_Function_List.CurrentPageIndex = 0;
        Bind_DataGrid();
    }
    protected int instr_fun(string str1, string str2)
    {
        string SearchString;
        SearchString = str1;
        int myPos = SearchString.IndexOf(str2);
        return myPos;
    }

    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        this.DG_Function_List.CurrentPageIndex = 0;
        Bind_DataGrid();
    }

    protected void Button_add_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[1]));
    }

    protected void Button_delete_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["Cbx_uid"] == null)
        {
            this.Lblnorecords.Text = "Please select at least one function to delete.";
            this.Lblnorecords.Visible = true;
        }
        else
        {
            my_Function_Maintain_Logic.Delete_Functions(Request["Cbx_uid"]);
            //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            //string response = "<script type='text/javascript'>alert('Function has successfully deleted');parent.mainframe.location.href='" + navurl + "';</script>";
            //Response.Write(response);

            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");




            //Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[0]) + "?showList=Y");
        }
    }
    protected void DG_Function_List_ItemCreated(object sender, DataGridItemEventArgs e)
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
    protected string getEditProfilePage()
    {
        //return "/administration/User_Update.aspx?userid=" + ViewState["USER_ID"].ToString() + "";
        string str = string.Empty;
        // str = "User_Update.aspx?userid=" + CommonFunctions.EncryptText( ds_Search.Tables[0].Rows[index]["USER_ID"].ToString()).ToString() + "";
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["FUNC_ID"].ToString()).ToString();
            str = Server.UrlEncode(str);
        }
        index = index + 1;
        return str;


    }
}