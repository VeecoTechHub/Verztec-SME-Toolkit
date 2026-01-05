using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Public_SelfEvaluations_Category : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    UserMgmt objUserMgmt = new UserMgmt();
    string str = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");

        }
        if (!IsPostBack)
        {
          
        }
        
    }
    //Added for encrypt text
    public  string Encrtypt_Text(string str)
    {

        str = commonfunction.Encrypt(str);

        return "FMSelfAssessment.aspx?Category="+str;

    }
}