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

public partial class Administration_Group_Search : System.Web.UI.Page
{
    private DataSet DS_Temp;
    private Group_Maintain_Logic my_Group_Maintain_Logic = new Group_Maintain_Logic();
    private string StrCheckAccess;
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    int index = 0;
    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
        Lblnorecords.Text = "";


     
        //Button_delete.Attributes.Add("onClick", "return confirm('Are you sure you want to delete the selected items? Once deleted you will not be able to view it again. Click OK to delete. Otherwise, click Cancel.');");

        if (!(Page.IsPostBack))
        {

            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_urladd"] = "../" + ViewState["Links"].ToString().Split('|')[1];
            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[0];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
            token = Request.Form["token"];


            if (token == null)
            {
                Response.Redirect("~/Administration/Default.aspx");
            }
            else
            {
                this.DG_Group_List.CurrentPageIndex = 0;
                Bind_Data();
            }
        }
    }

    private void Bind_Data()
    {
        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        //			if (Request["showList"] == "Y") 
        //			{ 
        //				this.Txt_Group_Id.Text = Session["groupid"].ToString(); 
        //				this.Txt_Description.Text = Session["description"].ToString(); 
        //				this.Txt_Page_Size.Text = Session["page_size"].ToString(); 
        Bind_DataGrid();
        DG_Group_List.CurrentPageIndex = System.Convert.ToInt32(Session["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        try
        {
            Bind_DataGrid();
        }
        catch
        {
            try
            {
                DG_Group_List.CurrentPageIndex = System.Convert.ToInt32(Session["page_no"]) - 1;
                Bind_DataGrid();
            }
            catch
            {
                Lblnorecords.Text = "Group information not available.";
                this.Lblnorecords.Visible = true;

                //this.pnluser.Visible = false;
                this.DG_Group_List.Visible = false;

            }
        }
        //			} 
        //			else 
        //			{ 
        //				Session["groupid"] = ""; 
        //				Session["description"] = ""; 
        //				Session["page_size"] = ""; 
        //				Session["page_no"] = ""; 
        //				Session["sort_on"] = ""; 
        //			} 
    }

    public void ChangeDGPAGE(object objSender, DataGridPageChangedEventArgs objArgs)
    {
        if (ViewState["Sort_On"] != null & ViewState["Sort_BY"] != null)
        {
            my_Group_Maintain_Logic.Sort_On = ViewState["Sort_On"].ToString();
            my_Group_Maintain_Logic.Sort_Direction = ViewState["Sort_By"].ToString();
        }


        DG_Group_List.CurrentPageIndex = objArgs.NewPageIndex;
        Bind_DataGrid();
        Session["page_no"] = DG_Group_List.CurrentPageIndex;
    }
    private void Bind_DataGrid()
    {
        my_Group_Maintain_Logic.GROUP_DESCR = this.Txt_Description.Text;
        my_Group_Maintain_Logic.GROUP_ID = this.Txt_Group_Id.Text;

        my_Group_Maintain_Logic.Sort_On = "";
        my_Group_Maintain_Logic.Sort_Direction = "";
        if (ViewState["Sort_On"] != null & ViewState["Sort_By"] != null)
        {
            my_Group_Maintain_Logic.Sort_On = ViewState["Sort_On"].ToString();
            my_Group_Maintain_Logic.Sort_Direction = ViewState["Sort_By"].ToString();
        }
        DS_Temp = my_Group_Maintain_Logic.Get_Group_List(Session["GROUP_ID"].ToString());
        if (DS_Temp.Tables[0].Rows.Count == 0)
        {
            Lblnorecords.Text = "Group information not available.";
            this.Lblnorecords.Visible = true;
            //Button_Add.Visible = true;
            Button_delete.Visible = false;
            //this.pnluser.Visible = false;
            this.DG_Group_List.Visible = false;
        }
        else
        {
            this.Lblnorecords.Visible = false;
            //this.pnluser.Visible = true;
            this.DG_Group_List.Visible = true;
        }
        if (this.Txt_Page_Size.Text != "")
        {
            if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
            {
                this.DG_Group_List.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
            }
        }
        else
        {
            this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
            this.DG_Group_List.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
        }
        ViewState["dsData"] = DS_Temp;
        this.DG_Group_List.DataSource = DS_Temp;
        this.DG_Group_List.DataBind();
        if (DS_Temp.Tables[0].Rows.Count == 0)
        {
            this.Lbl_Pageinfo.Visible = false;
        }
        else
        {
            Int16 intTo;
            Int16 intFrom;
            if (DG_Group_List.PageSize * (DG_Group_List.CurrentPageIndex + 1) < DS_Temp.Tables[0].Rows.Count)
            {
                intTo = System.Convert.ToInt16(DG_Group_List.PageSize * (DG_Group_List.CurrentPageIndex + 1));
            }
            else
            {
                intTo = System.Convert.ToInt16(DS_Temp.Tables[0].Rows.Count);
            }
            intFrom = System.Convert.ToInt16((DG_Group_List.PageSize * DG_Group_List.CurrentPageIndex) + 1);
            this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + DS_Temp.Tables[0].Rows.Count;
            this.Lbl_Pageinfo.Visible = true;
        }
    }



    protected void DG_Group_List_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        my_Group_Maintain_Logic.Sort_On = e.SortExpression;
        ViewState["Sort_On"] = my_Group_Maintain_Logic.Sort_On;
        if (ViewState["Sort_By"] == null)
        {
            ViewState["Sort_By"] = "Asc";
        }

        if (ViewState["Sort_By"].ToString() == "Asc")
        {
            ViewState["Sort_By"] = "Desc";
        }
        else
        {
            ViewState["Sort_By"] = "Asc";
        }
        my_Group_Maintain_Logic.Sort_Direction = ViewState["Sort_By"].ToString();
        this.DG_Group_List.CurrentPageIndex = 0;
        Bind_DataGrid();
        Session["page_no"] = DG_Group_List.CurrentPageIndex;
    }
    //		private void Page_Unload(object sender, System.EventArgs e) 
    //		{ 
    //			Session["groupid"] = this.Txt_Group_Id.Text; 
    //			Session["description"] = this.Txt_Description.Text; 
    //			Session["page_size"] = this.Txt_Page_Size.Text; 
    //			Session["page_no"] = DG_Group_List.CurrentPageIndex; 
    //			Session["sort_on"] = ViewState["Sort_On"]; 
    //		}
    public int instr_fun(string str1, string str2)
    {
        string SearchString;
        SearchString = str1;
        int myPos = SearchString.IndexOf(str2);
        return myPos;
    }

    protected void Button_go_Click(object sender, ImageClickEventArgs e)
    {
        this.DG_Group_List.CurrentPageIndex = 0;
        Bind_DataGrid();

    }

    protected void Button_Add_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[1]));
    }

    protected void Button_delete_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["Cbx_uid"] == null)
        {
            this.Lblnorecords.Text = "Please select at least one group to delete.";
            this.Lblnorecords.Visible = true;
            return;
        }
        if (my_Group_Maintain_Logic.Check_Constraint(Request["Cbx_uid"]))
        {
            this.Lblnorecords.Text = "User record exists for the selected group(s). Deletion failled.";
            this.Lblnorecords.Visible = true;
        }
        else
        {
            my_Group_Maintain_Logic.Delete_Groups(Request["Cbx_uid"]);
            //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            //string response = "<script type='text/javascript'>alert('Group has successfully deleted');parent.mainframe.location.href='" + navurl + "';</script>";
            //Response.Write(response); 
            
            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");
            
            //Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[0]) + "?showList=Y");
        }
    }
    protected void DG_Group_List_ItemCreated(object sender, DataGridItemEventArgs e)
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
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["GROUP_ID"].ToString()).ToString();
            str = Server.UrlEncode(str);

        }
        index = index + 1;
        return str;


    }
}
