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


public partial class Administration_User_Search : System.Web.UI.Page
{
    private User_Logic ObjUser = new User_Logic();
    Check_Access chkAccess = new Check_Access();

    private CommonFunctions CommonFunctions = new CommonFunctions();

    int index=0;
    DataSet Ds_Group = new DataSet();
    DataSet ds_Search = new DataSet();
    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
        DG_User_List.Visible = true;
        if (!(Page.IsPostBack))
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_urladd"] = "../" + ViewState["Links"].ToString().Split('|')[1];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            token = Request.Form["token"];


            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {

                Bind_Data();
            }

        }
        //Button_Delete.Attributes.Add("onClick", "return confirm('Are you sure to delete the selected items? Once deleted you will not be able to view it again. Click OK to delete. Otherwise, click Cancel.');");
        Button_Delete.Attributes.Add("onClick", "return confirm('Are you sure to delete the selected user(s)?');");
    }

    public void BindiID(string id)
    {

        //foreach (DataGridItem row in DG_User_List.Items)
        //{
            Label lbluserid = (Label)DG_User_List.FindControl("lbluserid");
            lbluserid.Text = CommonFunctions.EncryptText(lbluserid.Text);
            ViewState["id"] = null;
        ViewState["id"] = lbluserid.Text;




      // }


    }
  
    void Bind_Data()
    {

        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        //DataSet Ds_Group;
        Lst_Group.Items.Clear();
        Ds_Group = ObjUser.GetAllGroups(Session["group_id"].ToString());
        Lst_Group.DataSource = Ds_Group;
        Lst_Group.DataTextField = "GROUP_DESCR";
        Lst_Group.DataValueField = "GROUP_ID";

        Lst_Group.DataBind();
        Lst_Group.Items.Insert(0, "ALL");
        Ds_Group = null;
        
        //DataSet Ds_Dept;
        //Ds_Dept = ObjUser.GetAllDepartments();
        //Lst_Dept.DataSource = Ds_Dept;
        //Lst_Dept.DataTextField = "Description";
        //Lst_Dept.DataValueField = "DeptID";
        //Lst_Dept.DataBind();
        //Lst_Dept.Items.Insert(0, "ALL");
        //Ds_Dept = null;
        /**************************************************************/


        //			if (Request["showList"] == "Y") 
        //			{ 
        //				try 
        //				{ 
        //					this.Lst_Group.Items.FindByValue(Session["group"].ToString()); 
        //				} 
        //				catch 
        //				{ 
        //				} 
        //				this.Txt_Userid.Text = Session["userid"].ToString(); 
        //				this.Txt_Name.Text = Session["nam"].ToString(); 
        //				this.Txt_Page_Size.Text = Session["page_size"].ToString(); 
        DG_User_List.CurrentPageIndex = System.Convert.ToInt16(Session["page_no"]);
        ViewState["Sort_On"] = Session["sort_on"];
        try
        {
            Bind_dataGrid();
        }
        catch (Exception err)
        {
            try
            {
                DG_User_List.CurrentPageIndex = System.Convert.ToInt32(Session["page_no"]) - 1;
                Bind_dataGrid();
            }
            catch
            {
                lblError.Visible = true;
                //pnluser.Visible = false;
                DG_User_List.Visible = false;
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
            ObjUser.USER_NM = CommonFunctions.delQuote(Txt_Name.Text);
            ObjUser.USER_ID = CommonFunctions.delQuote(Txt_Userid.Text);
            ObjUser.GROUP_ID = CommonFunctions.delQuote(Lst_Group.SelectedItem.Value);
            //ObjUser.DeptID = CommonFunctions.delQuote(Lst_Dept.SelectedItem.Value);
            ObjUser.Sort_On = "";
            ObjUser.Sort_Direction = "";
            if (ViewState["Sort_On"] != null)
            {
                ObjUser.Sort_On = ViewState["Sort_On"].ToString();
                ObjUser.Sort_Direction = ViewState["Sort_By"].ToString();
            }
            lblError.Visible = false;
            ds_Search = ObjUser.GetUsersAll(Session["group_id"].ToString());
            ViewState["dsData"] = ds_Search;
            if (ds_Search.Tables[0].Rows.Count > 0)
            {

                DG_User_List.Visible = true;
                Button_Delete.Visible = true;
               // Button_New.Visible = true;
                lblError.Visible = false;
                //ChkAll.Visible = true ;
                spselect.Visible = true;

            }
            else
            {
                DG_User_List.Visible = false;
                Button_Delete.Visible = false;
                lblError.Visible = true;
                lblError.Text = "User information not available";
                //ChkAll.Visible = false;
                spselect.Visible = false;
               
               // Button_New.Visible = true;
                //pnluser.Visible = false;
            }
            if (this.Txt_Page_Size.Text != "")
            {
                if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                {
                    this.DG_User_List.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                }
            }
            else
            {
                this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
                this.DG_User_List.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
            }

            DG_User_List.DataSource = ds_Search;
            DG_User_List.DataBind();
            if (ds_Search.Tables[0].Rows.Count == 0)
            {
                this.Lbl_Pageinfo.Visible = false;
            }
            else
            {
                Int16 intTo;
                Int16 intFrom;
                if (DG_User_List.PageSize * (DG_User_List.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                {
                    intTo = System.Convert.ToInt16(DG_User_List.PageSize * (DG_User_List.CurrentPageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                }
                intFrom = System.Convert.ToInt16((DG_User_List.PageSize * DG_User_List.CurrentPageIndex) + 1);
                this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
                this.Lbl_Pageinfo.Visible = true;
            }
        }
        //ds_Search = null;

    }

    public void ChangeDGPAGE(object objSender, DataGridPageChangedEventArgs objArgs)
    {
        if (ViewState["Sort_On"] != null)
            ObjUser.Sort_On = ViewState["Sort_On"].ToString();
        DG_User_List.CurrentPageIndex = objArgs.NewPageIndex;
        Bind_dataGrid();
        Session["page_no"] = DG_User_List.CurrentPageIndex;
    }

    protected void DG_User_List_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        ObjUser.Sort_On = e.SortExpression;

        ViewState["Sort_On"] = ObjUser.Sort_On;
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
        Session["page_no"] = DG_User_List.CurrentPageIndex;
    }


    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        DG_User_List.CurrentPageIndex = 0;
        //ObjUser.Sort_On = ViewState["Sort_On"].ToString(); 
        Bind_dataGrid();
    }

    protected void Button_Delete_Click(object sender, ImageClickEventArgs e)
    {
        if (Request["Cbx_uid"] == null)
        {
            this.lblError.Text = "Please select at least one user to delete.";
            this.lblError.Visible = true;
        }
        else
        {
            string[] _faqsArr = Request["Cbx_uid"].Split(',');
            string _faqs = "";
            for (int i = 0; i < _faqsArr.Length; i++)
            {
                _faqs = _faqs + ",'" + _faqsArr[i].ToString() + "'";
            }
            if (_faqs != "")
                _faqs = _faqs.Remove(0, 1);
            ObjUser.Delete_Users(_faqs);
            //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            //string response = "<script type='text/javascript'>alert('User(s) has been successfully deleted');parent.mainframe.location.href='" + navurl + "';</script>";
            //Response.Write(response);

            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");



            // Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0] + "?showList=Y");
        }
    }

    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AddTLD.aspx");
    }
    protected void DG_User_List_ItemCreated(object sender, DataGridItemEventArgs e)
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

    //protected string getEditProfilePage()
    //{


    //   //return "/administration/User_Update.aspx?userid=" + Session ["userId"].ToString() + "";
    //   // return "/administration/User_Update.aspx?userid=" + CommonFunctions.EncryptText(ViewState["USER_ID"].ToString()) + "";
    //    return ViewState["t_url"] +"?userid="+ CommonFunctions.EncryptText(Session["USER_ID"].ToString()) + "";
    //    //return ViewState["t_url"] +"/?userid=" + CommonFunctions.EncryptText(ViewState ["USER_ID"].ToString()) + "";
    //}

    protected string   getEditProfilePage()
    {
        //return "/administration/User_Update.aspx?userid=" + ViewState["USER_ID"].ToString() + "";
        string str = string.Empty;
       // str = "User_Update.aspx?userid=" + CommonFunctions.EncryptText( ds_Search.Tables[0].Rows[index]["USER_ID"].ToString()).ToString() + "";
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt (ds.Tables[0].Rows[index]["USER_ID"].ToString()).ToString();
            str = Server.UrlEncode(str);
        }
        index = index + 1;
        return str;
       

    }
    protected void DG_User_List_ItemDataBound2(object sender, DataGridItemEventArgs e)
    {
        foreach (DataGridItem row in DG_User_List.Items)
        {
            Label lbluserid = (Label)row.FindControl("lbluserid");
            //lbluserid.Text = CommonFunctions.EncryptText(lbluserid.Text);
            string name = lbluserid.Text;
            lbluserid.Text = CommonFunctions.Encrypt (lbluserid.Text);



        }
    }
   
}
