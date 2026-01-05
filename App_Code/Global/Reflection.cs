using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;

/// <summary>
/// Summary description for Reflection
/// </summary>
public class MyReflection
{
    
    public static string getProperty(object obj,string property ) 
    {
        Type type = obj.GetType();

        
       return type.InvokeMember(property, BindingFlags.GetProperty, null, obj, null).ToString();
    
    }

    public static void setProperty(object obj, string property,string value)
    {
        Type type = obj.GetType();

        type.GetProperty(property).SetValue(obj, value, null);
        //return type.InvokeMember(property, BindingFlags.SetProperty, value, obj, null).ToString();

    }

    public static bool addEvent(object obj,string eventname, Delegate del)
    {
        Type type = obj.GetType();

        

        System.Reflection.EventInfo eventinfo = type.GetEvent(eventname);

        if (eventinfo == null)
            return false;
        else 
        {
            try
            {
                eventinfo.AddEventHandler(obj, del);
                return true;
            }
            catch(Exception ex)
            {
                string mess = ex.Message;
                return false;
            
            }       
        
        }

    }
}
