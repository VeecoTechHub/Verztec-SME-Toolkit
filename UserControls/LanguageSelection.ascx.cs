using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_LanguageSelection : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["Culture"]) == "en-US" || Convert.ToString(Session["Culture"]) == "")
            {
                lnkEnglish.Enabled = false;
            }
            else
            {
                lnkChinese.Enabled = false;
            }
        }
    }
    protected void lnkEnglish_Click(object sender, EventArgs e)
    {
        //store requested language as new culture in the session
        Session["Culture"] = "en-US";
     
        //reload last requested page with new culture
        Server.Transfer(Request.Path);
    }
    protected void lnkChinese_Click(object sender, EventArgs e)
    {
        //store requested language as new culture in the session
        Session["Culture"] = "zh-SG";
    
        //reload last requested page with new culture
        Server.Transfer(Request.Path);
    }
  
   
}
