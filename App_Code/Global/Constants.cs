using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Constants
/// </summary>
public class Constants
{
    public static string BaseUrl {

        get {


           return ConfigurationManager.AppSettings["internalurl"].ToString();
        }
    
    
    }

    

    public static string  DateFormat
    {
        get {


            return "dd-MMM-yyyy";      
            
             }
        
    }
	


	public Constants()
	{
		//
		// TODO: Add constructor logic here
		//

        
	}
}
