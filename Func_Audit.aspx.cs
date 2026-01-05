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
using System.Text.RegularExpressions;

public partial class Func_Audit : System.Web.UI.Page
{
    public string token;
    protected void Page_Load(object sender, EventArgs e)
    {
        string fid = Request["fid"];
        string link = Request["link"];
        string parentid = Request["parentid"];

        if (!IsValidFid(fid) || !IsValidParentId(parentid) || !IsValidLink(link))
        {
            Response.Redirect("~/Admin_Error.aspx");
            return;
        }

        Session["fid"] = fid;
		
        if (Session["USER_ID"] != null)
        {

            token = Guid.NewGuid().ToString() + "-" + Session.SessionID;
            Session["token"] = token;
			/*Response.Write (token); */
            Session["fidlink"] = "Func_Audit.aspx?link=" + HttpUtility.UrlEncode(Request["Link"].ToString()) + "&fid=" + HttpUtility.UrlEncode(fid);
			Page.ClientScript.RegisterStartupScript(this.GetType(), "fidscript", "postForEditMenu1('" + EscapeJsString(link) + "','" + EscapeJsString(fid) + "','" + EscapeJsString(token) + "');", true);
        }
        else
        {
            Session.Abandon();
            Response.Redirect("~/Administration/Default.aspx");
        }


    }

    private bool IsValidFid(string fid)
    {
        if (string.IsNullOrEmpty(fid)) return false;
        return Regex.IsMatch(fid, @"^[a-zA-Z0-9]+$");
    }

    private bool IsValidParentId(string parentid)
    {
        if (string.IsNullOrEmpty(parentid)) return true; // assuming optional
        int val;
        return int.TryParse(parentid, out val);
    }

    private bool IsValidLink(string link)
    {
        if (string.IsNullOrEmpty(link)) return false;
        // Allow alphanumeric, forward slashes, dots, hyphens
        return Regex.IsMatch(link, @"^[a-zA-Z0-9/\.\-]+$");
    }

    private string EscapeJsString(string s)
    {
        if (s == null) return "";
        return s.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r", "\\r").Replace("\n", "\\n");
    }
}
