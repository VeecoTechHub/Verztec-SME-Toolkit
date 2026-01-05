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

public partial class Administration_Group_Add : System.Web.UI.Page
{
    private DataSet DS_Temp;
    private Function_Maintain_Logic my_Function_Maintain_Logic = new Function_Maintain_Logic();
    private Group_Maintain_Logic my_Group_Maintain_Logic = new Group_Maintain_Logic();
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
	private string StrCheckAccess;
        public static string token;
        protected void Page_Load(object sender, EventArgs e)
        {
            
       

            if (!(Page.IsPostBack))
            {
                ViewState["Links"] = chkAccess.initSystem();
                ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
                ViewState["t_urlback"] = "../" + (ViewState["Links"].ToString().Split('|')[0]);
                token = Request.Form["token"];

                if (token == null)
                    Response.Redirect("~/Administration/Default.aspx");
                else
                {
                    {


                        if (Session["USER_ID"] != null)
                        {
                            ViewState["USER_ID"] = Convert.ToString(Session["USER_ID"]);
                        }
                        ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
                        // Button_Save.Attributes.Add("onClick", "return confirm('Do you want to add this group? Click OK to Add. Otherwise, click Cancel.');");
                        Bind_DataGrid();
                    }
                }
            }
        }



    private void Bind_DataGrid()
    {
        my_Group_Maintain_Logic.GROUP_ID = CommonBindings.TextToBind(this.Txt_Group_Id.Text);
        my_Group_Maintain_Logic.GROUP_DESCR = CommonBindings.TextToBind(this.Txt_Description.Text);
        DS_Temp = my_Group_Maintain_Logic.Get_Function_List(Session["group_id"].ToString());
        if (DS_Temp.Tables[0].Rows.Count == 0)
        {
            this.Lblnorecords.Visible = true;
        }
        this.DG_Function_List.DataSource = DS_Temp;
        this.DG_Function_List.DataBind();
    }

    //protected string Is_Default(string Str_FID)
    //{
    //    string str1;
    //    str1 = my_Group_Maintain_Logic.Is_Default(Str_FID).ToString();
    //    if (str1 == "")
    //    {
    //        if (instr_fun(Request["Cbx_Fid"], Str_FID) > 0)
    //        {
    //            str1 = " Checked";
    //        }
    //    }
    //    return str1;
    //}

    protected string rplc(string str)
    {
        return (str.Replace("'", "\\'"));
    }
    public int instr_fun(string str1, string str2)
    {
        string SearchString;
        SearchString = str1;
        int myPos = SearchString.IndexOf(str2);
        return myPos;
    }

    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {
        {
            Page.Validate();

            if (!(Page.IsValid))
            {

                ////Commented by Dinakar on 4-12-2007 changed the message so that user can understand it clearly
                ////lblError.Text = "Please enter the mandatory fields (coloured).";
                ////lblError.Text = "Please enter all '*' marked fields.";
                //lblError.Text = "Fields marked '*' are compulsory.";
                //lblError.Visible = true;
            }
            else if (my_Group_Maintain_Logic.Check_duplicate(this.Txt_Group_Id.Text))
            {
                lblError.Text = "A group already exists with this ID. Please try with a new Group ID.";
                lblError.Visible = true;
            }
            else
            {
                if (Request["Cbx_Fid"] == null)
                {
                    this.lblError.Text = "Please select at least one Function id";
                    this.lblError.Visible = true;
                }
                else
                {

                    my_Group_Maintain_Logic.GROUP_ID = CommonBindings.TextToBind(this.Txt_Group_Id.Text);
                    my_Group_Maintain_Logic.GROUP_DESCR = CommonBindings.TextToBind(this.Txt_Description.Text);
                    my_Group_Maintain_Logic.DISC_PERCENT = "";
                    my_Group_Maintain_Logic.EXTRA_FREE_PACKS = "";
                    my_Group_Maintain_Logic.CREAT_BY = Convert.ToString(ViewState["USER_ID"]);
                    my_Group_Maintain_Logic.CREAT_DT = string.Format("('{0:yyyy-MM-dd}", Convert.ToDateTime(DateTime.Today)) + "')";
                    my_Group_Maintain_Logic.IS_ADMIN = "Y";
                    my_Group_Maintain_Logic.Add_Group(Request["Cbx_Fid"]);

                    //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
                    //string response = "<script type='text/javascript'>alert('New Group has successfully created');parent.mainframe.location.href='" + navurl + "';</script>";
                    //Response.Write(response);


                    string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");


                    //Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[0]));
                }
            }
        }
    }

    protected void Button_Back_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../" + (ViewState["Links"].ToString().Split('|')[0]));
    }
}
