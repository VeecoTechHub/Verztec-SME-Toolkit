using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administration_ViewImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string BannerURL = string.Empty;
        if (Page.Request.QueryString.Count > 0)
        {
            BannerURL = Request.QueryString["Banner"].ToString();
            ImgBanner.ImageUrl = "~/BannerImages/" + BannerURL;
        }
       // btnClose.Attributes.Add("onclick","closepopup()");
    }
}