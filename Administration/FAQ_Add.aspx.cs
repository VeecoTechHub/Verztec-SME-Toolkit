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

public partial class Administration_FAQ_Add : System.Web.UI.Page
{
    private FaqMgmt objFaq = new FaqMgmt();


    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!(Page.IsPostBack))
        {

            ViewState["Links"] = chkAccess.initSystem();
            if (Session["USER_ID"] != null)
            {

                ViewState["USER_ID"] = Convert.ToString(Session["USER_ID"]);
            }
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            bindCategory();


        }
        Response.Write("<script language=javascript>var flg; flg=false</script>");

    }


    private void bindCategory()
    {
        try
        {
            ddlCategory.DataSource = objFaq.getDataForCategory();
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataBind();
            ListItem liCategory = new ListItem("select Category", "0");
            ddlCategory.Items.Insert(0, liCategory);
            lblError.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }


    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {

        Page.Validate();
        if (Page.IsValid)
        {
            objFaq.CategoryId = ddlCategory.SelectedValue;
            objFaq.FaqQuestion = CommonFunctions.delQuote(txtQuestion.Text);
            objFaq.FaqAnswer = CommonFunctions.delQuote(txtAnswer.Text);
            objFaq.insetFaq(Convert.ToString(ViewState["USER_ID"]));
            //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            string navurl = "FAQ_Search.aspx";
            string response = "<script type='text/javascript'>alert('Faq added successfully');location.href='" + navurl + "';</script>";
            Response.Write(response);
        }
    }


    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FAQ_Add.aspx");
    }


    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FAQ_Search.aspx");
    }
}
