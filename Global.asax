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
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        //Save logout time when a session End
        ABSDTO.LoginDTO objLoginDTO = (ABSDTO.LoginDTO)Session["LoginDTO"];
        objLoginDTO.UserID = objLoginDTO.UserID;
        objLoginDTO.Flag = "Update";
        if (Session["LogId"] != "" && Session["LogId"] != null)
        {
            objLoginDTO.LogId = Convert.ToInt32(Session["LogId"]);
        }

        ABSBLL.Registration objRegs = new ABSBLL.Registration();
        objRegs.InsertUserLogs(objLoginDTO);



    }
       
</script>
