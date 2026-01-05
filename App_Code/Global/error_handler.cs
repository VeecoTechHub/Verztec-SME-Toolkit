using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mail;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading;
/// <summary>
/// Summary description for error_handler
/// </summary>
/// 
public enum MessageType
{
    EventLog, //Only log in EventLog
    SendMail, //Only send email
    MailAndEventLog, //Both EventLog and email
    MailAndEventLogAndTextFile,
    TextFile
}
public class error_handler
{
    public MessageType MT = new MessageType();
    public string EmailReciever = "";
    public string FromMailID = "";
    public string LogName = "";
    public string MailServer = "";
    public string MailSubject = "Auto generated ABS error message";
    public string LastMessage = "";
    private string EventLogName = "ABS System";

    // In case of setting the strings in web.config
    public error_handler()
    {
        this.MailServer = System.Configuration.ConfigurationManager.AppSettings.Get("SMTPHost");
        this.EmailReciever = System.Configuration.ConfigurationManager.AppSettings.Get("AdminMail");
        this.FromMailID = System.Configuration.ConfigurationManager.AppSettings.Get("MailFrom");
        this.LogName = "ABS System";
    }
    // In case of setting params upon object creation
    public error_handler(string _mailserver, string _mailreciever, string _logname)
    {
        this.MailServer = _mailserver;
        this.EmailReciever = _mailreciever;
        this.LogName = _logname;
    }
    public void RaiseError(string _message)
    {
        this.LastMessage = _message;
        switch (this.MT)
        {
            case MessageType.EventLog:
                SaveToEventLog(_message);
                break;
            case MessageType.SendMail:
                SendMail(_message);
                break;
            case MessageType.MailAndEventLog:
                SaveToEventLog(_message);
                SendMail(_message);
                break;
            case MessageType.MailAndEventLogAndTextFile:
                SaveToEventLog(_message);
                SendMail(_message);
                LogResult(_message);
                break;
            case MessageType.TextFile:
                LogResult(_message);
                SendMailAttachment(_message);
                break;
            default:
                break;
        }
    }

    private void SendMailAttachment(string _message)
    {
        string body = "Error message:\n" + _message + "\n\n" + GetUserData();

        Global.Globals.send_emailAttachment(this.EmailReciever, this.FromMailID, "", this.MailSubject, body);
    }
    public string ShowAlert(string myMessage, bool useHtml, bool goBack)
    {
        string message = "alert('" + myMessage + "');";
        string back = "";
        if (goBack)
        {
            back = "window.history.go(-1);";
        }
        string output = "<script>";
        output += message;
        output += back;
        output += "</script>";
        if (useHtml)
        {
            output = "<html><head></head><body>" + output + "</body></html>";
        }
        return output;

    }
    public MessageType MsgType
    {
        get
        {
            return this.MT;
        }
        set
        {
            this.MT = value;
        }

    }
    private void SaveToEventLog(string _message)
    {
        //Here is an issue. ASP.NET does not have privilages by default to write to the event log
        //so, what we do is to try, if fail, we send us a mail to say so.
        //The solutions are many. One is to:
        //To do so, open regedt32 (not the standard, regedit) and navigate to HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\EventLog and click on "Security-->Permissions..." in the menu.  Add the ASPNET account for the local machine and place a check next to "Full Control"

        try
        {
            //Create our own log if it not already exists

            if (!EventLog.SourceExists(this.EventLogName))
                EventLog.CreateEventSource(this.EventLogName, this.EventLogName);

            EventLog MyLog = new EventLog();
            MyLog.Source = this.EventLogName;
            MyLog.WriteEntry(_message + GetUserData(), EventLogEntryType.Warning);

        }
        catch (Exception e)
        {
            //send us a email and tell that there is a permission problem
            SendMail(e.Message);
        }
    }
    private static string GetUserData()
    {
        System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
        string s = "Browser Capabilities\n"
            + "IP Address = " + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString() + "\n"
            + "Type = " + browser.Type + "\n"
            + "Name = " + browser.Browser + "\n"
            + "Version = " + browser.Version + "\n"
            + "Major Version = " + browser.MajorVersion + "\n"
            + "Minor Version = " + browser.MinorVersion + "\n"
            + "Platform = " + browser.Platform + "\n"
            + "Is Beta = " + browser.Beta + "\n"
            + "Is Crawler = " + browser.Crawler + "\n"
            + "Is AOL = " + browser.AOL + "\n"
            + "Is Win16 = " + browser.Win16 + "\n"
            + "Is Win32 = " + browser.Win32 + "\n"
            + "Supports Frames = " + browser.Frames + "\n"
            + "Supports Tables = " + browser.Tables + "\n"
            + "Supports Cookies = " + browser.Cookies + "\n"
            + "Supports VBScript = " + browser.VBScript + "\n"
            + "Supports JavaScript = " + browser.JavaScript + "\n"
            + "Supports Java Applets = " + browser.JavaApplets + "\n"
            + "Supports BackgroundSounds = " + browser.BackgroundSounds + "\n"
            + "Supports ActiveX Controls = " + browser.ActiveXControls + "\n"
            + "Browser = " + browser.Browser + "\n"
            + "CDF = " + browser.CDF + "\n"
            + "CLR Version = " + browser.ClrVersion + "\n"
            + "ECMA Script version = " + browser.EcmaScriptVersion + "\n"
            + "MSDOM version = " + browser.MSDomVersion + "\n"
            + "Supports tables = " + browser.Tables + "\n"
            + "W3C DOM version = " + browser.W3CDomVersion + "\n";
        return s;

    }

    public void SendMail(string _message)
    {
        string body = "Error message:\n" + _message + "\n\n" + GetUserData();

        Global.Globals.send_email(this.EmailReciever, this.FromMailID, "", this.MailSubject, body);
    }

    public void LogResult(string strDesc)
    {
         
            StreamWriter sw = null;
            string strLogFolderpath = System.Configuration.ConfigurationManager.AppSettings.Get("logpath");
            string strLogFileName = "ABS_ErrorLog_" + string.Format("{0:dd-MMM-yyyy}", System.DateTime.Now) + ".txt";
            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(strLogFolderpath)))
            {
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(strLogFolderpath));
            }

            if (!File.Exists(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName)))
            {
                sw = File.CreateText(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName));


                //System.Diagnostics.Process procNotePad;
                //procNotePad = System.Diagnostics.Process.Start("notepad.exe", HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName));
                //if (procNotePad != null && !procNotePad.HasExited)
                //{
                //    Thread.Sleep(1000);
                //    procNotePad.Kill();
                //    procNotePad.WaitForExit();
                //}
                //bool value = IsProcessOpen("notepad");
            }
            else
            {

                sw = File.AppendText(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName));
                //StreamWriter sw1 = new StreamWriter(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName), true);
                //sw1.WriteLine("Logged On: " + DateTime.Now.ToString());
                //sw1.WriteLine(Environment.NewLine);
                //sw1.WriteLine("Error Description: " + strDesc + GetUserData());
                //sw1.WriteLine(Environment.NewLine);
                //sw1.WriteLine("----------------------------");

                ////sw1.Flush();
                //sw1.Close(); 

                //System.Diagnostics.Process procNotePad;
                //procNotePad = System.Diagnostics.Process.Start("notepad.exe", HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName));
                //Process[] processes = Process.GetProcessesByName("notepad.exe");
                //if (procNotePad != null && !procNotePad.HasExited)
                //{
                //    foreach (Process process in processes)
                //    {
                //        process.Kill(); 
                //    }
                //    Thread.Sleep(1000);
                //    procNotePad.Kill();
                //    procNotePad.WaitForExit();
                //}
                //bool value = IsProcessOpen("notepad");

                //sw = File.AppendText(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName));

                //using (var fileStream = new FileStream(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName).ToString(), FileMode.Create, FileAccess.Write, FileShare.None))
                //using (var streamWriter = new StreamWriter(fileStream))
                //{
                //    streamWriter.WriteLine("Logged On: " + DateTime.Now.ToString());
                //    streamWriter.WriteLine(Environment.NewLine);
                //    streamWriter.WriteLine("Error Description: " + strDesc + GetUserData());
                //    streamWriter.WriteLine(Environment.NewLine);
                //    streamWriter.WriteLine("----------------------------");

                //    streamWriter.Flush();
                //    streamWriter.Close(); 
                //}


                //using (StreamWriter sw1 = File.AppendText(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName).ToString()))
                //{
                //    sw1.WriteLine("Logged On: " + DateTime.Now.ToString());
                //    sw1.WriteLine(Environment.NewLine);
                //    sw1.WriteLine("Error Description: " + strDesc + GetUserData());
                //    sw1.WriteLine(Environment.NewLine);
                //    sw1.WriteLine("----------------------------");

                //    sw1.Flush();
                //    sw1.Close(); 
                //}	

                //using (StreamWriter sw1 = new StreamWriter(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName).ToString(), true))
                //{

                //    sw1.WriteLine("Logged On: " + DateTime.Now.ToString());
                //    sw1.WriteLine(Environment.NewLine);
                //    sw1.WriteLine("Error Description: " + strDesc + GetUserData());
                //    sw1.WriteLine(Environment.NewLine);
                //    sw1.WriteLine("----------------------------");

                //    sw1.Flush();
                //    sw1.Close();

                //    //Process process = Process.Start("notepad.exe", HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName).ToString());
                //    //process.Exited += EventHandler;
                //}

            }
            string ReadString = System.DateTime.Now.ToString();

            sw.WriteLine("Logged On: " + DateTime.Now.ToString());
            sw.WriteLine(Environment.NewLine);
            sw.WriteLine("Error Description: " + strDesc + GetUserData());
            sw.WriteLine(Environment.NewLine);
            sw.WriteLine("----------------------------");
            sw.AutoFlush = true;

            sw.Flush();
            sw.Dispose();
            sw.Close(); 

      
    }


    public bool IsProcessOpen(string name)
    {
        //here we're going to get a list of all <strong class="highlight">running</strong> processes on
        //the computer
        foreach (Process clsProcess in Process.GetProcesses())
        {

            if (clsProcess.ProcessName.Contains(name))
            {
                //if <strong class="highlight">the</strong> <strong class="highlight">process</strong> <strong class="highlight">is</strong> found to be <strong class="highlight">running</strong> then we
                //return a true



                return true;
            }
        }


        //otherwise we return a false
        return false;
    }

}
