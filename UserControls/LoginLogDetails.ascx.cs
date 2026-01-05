using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSDTO;

public partial class UserControls_LoginLogDetails : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] != null)
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            if (objLoginDTO.EmailID != null)
            {
                lblCurrentUser.Text = System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(objLoginDTO.Name);
                if (objLoginDTO.LoggedInAt != null)
                {

                    DateTime dtLoggedIn = objLoginDTO.LoggedInAt.Value;
                    lblDate.Text = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text")) + " " + dtLoggedIn.Date.ToString("dd/MM/yyyy") + "&nbsp;&nbsp;";
                    //lblTime.Text = dtLoggedIn.TimeOfDay.ToString();
                    lblTime.Text = String.Format("{0:hh:mm tt}", dtLoggedIn);
                    lblCompanyName.Text = objLoginDTO.CompanyNm;
                }
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