using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Globalization;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : Page
{
    public BasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// This is the page from which all pages inherits, if user session is null then it redirects to login page
    /// </summary>
    /// <param name="e"></param>
    protected override void OnLoad(EventArgs e)
    {
        if (Session["LoginDTO"] != null && Context.User.Identity.IsAuthenticated == true) LTDO = (ABSDTO.LoginDTO)Session["LoginDTO"];
        else Response.Redirect("~/Default.aspx");
        base.OnLoad(e);
    }
    public ABSDTO.LoginDTO LTDO { get; set; }

    protected override void InitializeCulture()
    {
        /*
         * Get the culture from the Sessions
         */
        string currentCulture = Convert.ToString(Session["Culture"]);

        /*
         * Check if there's in a
         * culture in the Sessions
         * Otherwise, set the Default Culture
         */
        CultureInfo ci = new CultureInfo(currentCulture);
        if (!string.IsNullOrEmpty(currentCulture))
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
       
        base.InitializeCulture();
    }
}