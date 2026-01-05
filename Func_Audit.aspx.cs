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

public partial class Func_Audit : System.Web.UI.Page
{
    public string token;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["fid"] = Request["fid"];
		
        if (Session["USER_ID"] != null)
        {

            token = Guid.NewGuid().ToString() + "-" + Session.SessionID;
            Session["token"] = token;
			/*Response.Write (token); */
            string fid = Convert.ToString(Request["fid"]);
            string link = Convert.ToString(Request["link"]);
            Session["fidlink"] = "Func_Audit.aspx?link=" + Request["Link"].ToString() + "&fid=" + Request["fid"].ToString();
			Page.ClientScript.RegisterStartupScript(this.GetType(), "fidscript", "postForEditMenu1('" + Request["link"].ToString() + "','" + Request["fid"].ToString() + "','" + token + "');", true);
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Administration/Default.aspx");
        }


    }
}
