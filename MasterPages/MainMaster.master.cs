using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSDTO;
using System.Configuration;
using System.Globalization;
using System.Threading;

public partial class MasterPages_MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] != null)
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            if (objLoginDTO.EmailID != null)
            {
                Control Menu = null;
                Menu = LoadControl("../UserControls/UserMenu.ascx");
                MenuPlaceHolder.Controls.Add(Menu);

                Control MenuLog = null;
                MenuLog = LoadControl("../UserControls/LoginLogDetails.ascx");
                LogPlaceHolder.Controls.Add(MenuLog);
            }
            else
            {
                Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
            }
        }
        else
        {
            Control Menu = null;
            Menu = LoadControl("../UserControls/LanguageSelection.ascx");
            MenuPlaceHolder.Controls.Add(Menu);
        }
        //else
        //{
        //    Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        //}
       
        

        // Added by Mahesh on 23/01/2012
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
    }
   
   
}
