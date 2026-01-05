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

public partial class Administration_Function_Update : System.Web.UI.Page
{
    private DataSet DS_Temp;
    private Function_Maintain_Logic my_Function_Maintain_Logic = new Function_Maintain_Logic();
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();

    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Put user code to initialize the page here
      
      


        if (!(Page.IsPostBack))
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[0];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            token = Request.Form["token"];
            if (token == null)
            {
                Response.Redirect("~/Administration/Default.aspx");
            }
            else
            {

                if (Session["USER_ID"] != null)
                {
                    ViewState["USER_ID"] = Convert.ToString(Session["USER_ID"]);
                }
                //   ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
                //Bttn_Update.Attributes.Add("onClick", "return confirm('Do you want to update this Function? Click OK to update. Otherwise, click Cancel.');");
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

        my_Function_Maintain_Logic.Get_Values(CommonFunctions.Decrypt(Request["IDforEdit"]));
        this.Txt_Function_Id.Text = my_Function_Maintain_Logic.Str_Function_Id;
        this.Txt_Function_Id.ReadOnly = true;
        this.Txt_Function_Id.BorderStyle = BorderStyle.None;
        this.Txt_Short_Desc.Text = my_Function_Maintain_Logic.Str_Short_Desc;
        this.Txt_Description.Text = my_Function_Maintain_Logic.Str_Description;
        this.Lst_Parent_Menu.SelectedItem.Selected = false;
        this.Lst_Parent_Menu.Items.FindByValue(my_Function_Maintain_Logic.Str_Parent_Menu).Selected = true;
        this.txt_Page_Size.Text = my_Function_Maintain_Logic.Int_Page_Size;
        this.Txt_Sort_Seq.Text = my_Function_Maintain_Logic.Int_Sort_Seq;
        //this.Txt_Query_URL.Text = my_Function_Maintain_Logic.Str_Query_URL; 
        this.Txt_Edit_URL.Text = my_Function_Maintain_Logic.Str_Edit_URL;
        this.Txt_Search_URL.Text = my_Function_Maintain_Logic.Str_Search_URL;
        this.Txt_Search_URL.Text = my_Function_Maintain_Logic.Str_Search_URL;
        this.Txt_New_URL.Text = my_Function_Maintain_Logic.Str_New_URL;
        //if (my_Function_Maintain_Logic.Def_To_Groups ==Convert.ToChar("Y")) 
        //{ 
        //    this.Rad_Yes.Checked = true; 
        //} 
        //else 
        //{ 
        //    this.Rad_No.Checked = true; 
        //} 
        if (my_Function_Maintain_Logic.Def_Link == Convert.ToChar("S"))
        {
            this.Rad_Search.Checked = true;
        }
        else
        {
            this.Rad_New.Checked = true;
        }
    }


    protected void Bttn_Back_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0]);
    }

    protected void Bttn_Update_Click(object sender, ImageClickEventArgs e)
    {
        my_Function_Maintain_Logic.Str_Parent_Menu = this.Lst_Parent_Menu.SelectedItem.Value;
        Page.Validate();

        if (this.Rad_New.Checked & this.Txt_New_URL.Text == "")
        {
            lblError.Text = "New Link should not be blank, if you selected New as default page.";
            lblError.Visible = true;
        }
        else if (this.Rad_Search.Checked & this.Txt_Search_URL.Text == "")
        {
            lblError.Text = "Serach Link should not be blank, if you selected Search as default page.";
            lblError.Visible = true;
        }
        else
        {
            my_Function_Maintain_Logic.Str_Parent_Menu = this.Lst_Parent_Menu.SelectedItem.Value;
            my_Function_Maintain_Logic.Int_Sort_Seq = this.Txt_Sort_Seq.Text;
            my_Function_Maintain_Logic.Str_Function_Id = this.Txt_Function_Id.Text;
            if (my_Function_Maintain_Logic.Check_Dup_Sort_Seq())
            {
                lblError.Text = "There exists a same sort sequence with the selected Parent Menu, please try with another sort sequence";
                lblError.Visible = true;
            }
            else
            {
                my_Function_Maintain_Logic.Str_Function_Id = this.Txt_Function_Id.Text;
                my_Function_Maintain_Logic.Str_Short_Desc = this.Txt_Short_Desc.Text;
                my_Function_Maintain_Logic.Str_Description = this.Txt_Description.Text;
                my_Function_Maintain_Logic.Str_Parent_Menu = this.Lst_Parent_Menu.SelectedItem.Value;
                my_Function_Maintain_Logic.Int_Page_Size = this.txt_Page_Size.Text;
                my_Function_Maintain_Logic.Int_Sort_Seq = this.Txt_Sort_Seq.Text;
                //my_Function_Maintain_Logic.Str_Query_URL = this.Txt_Query_URL.Text; 
                my_Function_Maintain_Logic.Str_Edit_URL = this.Txt_Edit_URL.Text;
                my_Function_Maintain_Logic.Str_Search_URL = this.Txt_Search_URL.Text;
                my_Function_Maintain_Logic.Str_Search_URL = this.Txt_Search_URL.Text;
                my_Function_Maintain_Logic.Str_New_URL = this.Txt_New_URL.Text;
                if (this.Rad_Search.Checked)
                {
                    my_Function_Maintain_Logic.Def_Link = Convert.ToChar("S");
                }
                else
                {
                    my_Function_Maintain_Logic.Def_Link = Convert.ToChar("N");
                }
                //if (this.Rad_Yes.Checked) 
                //{ 
                //    my_Function_Maintain_Logic.Def_To_Groups = Convert.ToChar("Y");
                //} 
                //else 
                //{ 
                //    my_Function_Maintain_Logic.Def_To_Groups =Convert.ToChar("N"); 
                //} 
                my_Function_Maintain_Logic.Str_Created_By = Convert.ToString(ViewState["USER_ID"]);
                my_Function_Maintain_Logic.Str_Created_On = string.Format("('{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Today)) + "')";
                my_Function_Maintain_Logic.Update_Function();

                //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
                //string response = "<script type='text/javascript'>alert('Function has successfully updated');parent.mainframe.location.href='" + navurl + "';</script>";
                //Response.Write(response);

                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");



                //Response.Redirect("../" + ViewState["Links"].ToString().Split('|')[0] + "?showList=Y"); 
            }
        }
    }

}