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

public partial class Administration_FAQ_Update : System.Web.UI.Page
{
    private FaqMgmt objFaq = new FaqMgmt();


    string strFaqId = string.Empty;
    private CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!(Page.IsPostBack))
        {
          
            if (Request.QueryString["FaqId"] != null)
            {
                strFaqId = CommonFunctions.Decrypt(Request.QueryString["FaqId"].ToString());
            }
            ViewState["Links"] = chkAccess.initSystem();
            if (Session["USER_ID"] != null)
            {
                ViewState["USER_ID"] = Convert.ToString(Session["USER_ID"]);
            }
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            bindCategory();
            bindData();

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
    private void bindData()
    {
        try
        {
            objFaq.FaqId = Convert.ToString(strFaqId);
            DataSet ds = objFaq.getFaqById();
            ddlCategory.Items.FindByValue(ds.Tables[0].Rows[0]["CategoryId"].ToString()).Selected = true;
            txtQuestion.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["FaqQuestion"].ToString());
            txtAnswer.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["FaqAnswer"].ToString());
            lblError.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Visible = true;
            lblError.Text = ex.Message;
        }
    }


    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {

        Page.Validate();
        if (Page.IsValid)
        {
            objFaq.FaqId = Convert.ToString(strFaqId);
            objFaq.CategoryId = ddlCategory.SelectedValue;
            objFaq.FaqQuestion = CommonFunctions.delQuote(txtQuestion.Text);
            objFaq.FaqAnswer = CommonFunctions.delQuote(txtAnswer.Text);
            objFaq.updateFaq(Convert.ToString(ViewState["USER_ID"]));
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveSript", "SuccessRegister();", true);
            //string navurl = ViewState["Links"].ToString().Split('|')[0].ToString().Split('/')[1] + "?showList=Y";
            //string response = "<script type='text/javascript'>alert('Faq has been successfully updated');parent.mainframe.location.href='" + navurl + "';</script>";
            //Response.Write(response);
        }
    }


  
    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FAQ_Search.aspx");
    }
    protected void btnReset_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FAQ_Update.aspx?FaqId="+Convert.ToString(strFaqId)+"");
    }
}

