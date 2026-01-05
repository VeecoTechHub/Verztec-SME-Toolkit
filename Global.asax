<%@ Application Language="C#" %>
<%@ Import Namespace="System.Configuration" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Mail" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web.SessionState" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        try
        {
            // Code that runs when an unhandled error occurs
            Global.Globals.RiseError(Server.GetLastError());
            Server.ClearError();
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Error_Page.aspx");
        }
        catch (Exception ex)
        {
            Server.ClearError();
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Error_Page.aspx");
        }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        ABSDTO.LoginDTO objLoginDTO = (ABSDTO.LoginDTO)Session["LoginDTO"];
        
        if (objLoginDTO == null)
            return; // No logged-in user to track
        
        objLoginDTO.Flag = "Update";
        if (Session["LogId"] != null && Session["LogId"] != "")
        {
            objLoginDTO.LogId = Convert.ToInt32(Session["LogId"]);
        }

        ABSBLL.Registration objRegs = new ABSBLL.Registration();
        objRegs.InsertUserLogs(objLoginDTO);
    }
       
</script>
