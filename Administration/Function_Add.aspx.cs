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
using ABSCommon;

public partial class Administration_Function_Add : System.Web.UI.Page
{
    private DataSet DS_Temp;
    private Function_Maintain_Logic my_Function_Maintain_Logic = new Function_Maintain_Logic();
    string StrCheckAccess;
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
     
      
        ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
        if (!(Page.IsPostBack))
        {

            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_urladd"] = "../" + (ViewState["Links"].ToString().Split('|')[1]);
            ViewState["t_urlback"] = "../" + (ViewState["Links"].ToString().Split('|')[0]);

            token = Request.Form["token"];

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {

                if (Session["USER_ID"] != null)
                {
                    ViewState["USER_ID"] = Convert.ToString(Session["USER_ID"]);
                }
                ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
                // Btn_Save.Attributes.Add("onClick", "return confirm('Do you want to add this Function? Click OK to Add. Otherwise, click Cancel.');");
                Bind_Data();
            }
        }
    }

    public int instr_fun(string str1, string str2)
    {
        string SearchString;
        SearchString = str1;
        int myPos = SearchString.IndexOf(str2);
        return myPos;
    }

    private void Bind_Data()
    {
        DS_Temp = my_Function_Maintain_Logic.Get_Parent_Menu();
        Lst_Parent_Menu.DataSource = DS_Temp;
        Lst_Parent_Menu.DataTextField = "STATUS";
        Lst_Parent_Menu.DataValueField = "STATUS";
        Lst_Parent_Menu.DataBind();
        this.Lst_Parent_Menu.Items.Insert(0, "");
        this.Lst_Parent_Menu.Items[0].Value = "0";
    }

    protected void Btn_Search_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[0]));
    }

    protected void Btn_Save_Click(object sender, ImageClickEventArgs e)
    {
        Page.Validate();
        my_Function_Maintain_Logic.Str_Function_Id = CommonBindings.TextToBind(this.Txt_Function_Id.Text);
        my_Function_Maintain_Logic.Str_Short_Desc = CommonBindings.TextToBind(this.Txt_Short_Desc.Text);
        my_Function_Maintain_Logic.Str_Description = CommonBindings.TextToBind(this.Txt_Description.Text);
        my_Function_Maintain_Logic.Str_Parent_Menu = this.Lst_Parent_Menu.SelectedItem.Value;
        my_Function_Maintain_Logic.Int_Page_Size = CommonBindings.TextToBind(this.txt_Page_Size.Text);
        my_Function_Maintain_Logic.Int_Sort_Seq = CommonBindings.TextToBind(this.Txt_Sort_Seq.Text);
        // my_Function_Maintain_Logic.Str_Query_URL = this.Txt_Query_URL.Text;
        my_Function_Maintain_Logic.Str_Edit_URL = CommonBindings.TextToBind(this.Txt_Edit_URL.Text);
        my_Function_Maintain_Logic.Str_Search_URL = CommonBindings.TextToBind(this.Txt_Search_URL.Text);
        my_Function_Maintain_Logic.Str_Search_URL = CommonBindings.TextToBind(this.Txt_Search_URL.Text);
        my_Function_Maintain_Logic.Str_New_URL = CommonBindings.TextToBind(this.Txt_New_URL.Text);
        if (this.Lst_Parent_Menu.SelectedItem.Value == "0")
        {
            //this.Lbl_Parent_Req.Visible = true;
            //lblError.Text = "Fields marked '*' are compulsory.";
            lblError.Visible = true;
        }
        else if (!(Page.IsValid))
        {
            lblError.Text = "Fields marked '*' are compulsory.";
            lblError.Visible = true;
        }
        else if (this.Rad_New.Checked & this.Txt_New_URL.Text == "")
        {
            lblError.Text = "New URL should not be blank, if you have selected New as the Default Page.";
            lblError.Visible = true;
        }
        else if (this.Rad_Search.Checked & this.Txt_Search_URL.Text == "")
        {
            lblError.Text = "Search URL should not be blank, if you have selected Search as the Default Page.";
            lblError.Visible = true;
        }
        else if (my_Function_Maintain_Logic.Check_Duplicate(this.Txt_Function_Id.Text))
        {
            lblError.Text = "There is already one function with this id, please try with a new function id";
            lblError.Visible = true;
        }
        else if (my_Function_Maintain_Logic.Check_Dup_Sort_Seq())
        {
            lblError.Text = "There exists a same sort sequence with the selected Parent Menu, please try with another sort sequence";
            lblError.Visible = true;
        }
        else
        {
            if (this.Rad_Search.Checked)
            {
                my_Function_Maintain_Logic.Def_Link = 'S';
            }
            else
            {
                my_Function_Maintain_Logic.Def_Link = 'N';
            }
            //if (this.Rad_Yes.Checked)
            //{
            //    my_Function_Maintain_Logic.Def_To_Groups = 'Y';
            //}
            //else
            //{
            //    my_Function_Maintain_Logic.Def_To_Groups = 'N';
            //}
            my_Function_Maintain_Logic.Str_Created_By = Convert.ToString(ViewState["USER_ID"]);
            my_Function_Maintain_Logic.Str_Created_On = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Today)) + "')";

            my_Function_Maintain_Logic.Add_Function();
            this.Txt_Description.Text = "";
            this.Txt_Short_Desc.Text = "";
            this.Txt_Function_Id.Text = "";
            this.lblError.Visible = false;

            //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            //string response = "<script type='text/javascript'>alert('New Function has successfully added');parent.mainframe.location.href='" + navurl + "';</script>";
            //Response.Write(response); 



            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");





            // Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[0]));
        }
    }

    protected void Btn_Clear_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[1]));


        //string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");
        Txt_Function_Id.Text = "";
        Lst_Parent_Menu.ClearSelection();
        Txt_Description.Text = "";
        txt_Page_Size.Text = "";
        Txt_Search_URL.Text = "";

        Txt_New_URL.Text = "";
        Txt_Edit_URL.Text = "";
        Txt_Short_Desc.Text = "";
        Rad_New.Checked = true;
        Rad_Search.Checked = false;
        Txt_Sort_Seq.Text = "";


    }
}
