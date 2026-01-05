using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.UI;
using System.Configuration;

/// <summary>
/// Summary description for MailManager
/// </summary>

namespace ABSCommon
{
    public class MailManager
    {
        public void sendNotificationMail1(string FrommailID, string ToMailID, string Subject, string MailBody, string strRegards)
        {
            try
            {
                string strHtmlBody = string.Empty;
                strHtmlBody = "<HTML><BODY BGCOLOR=#FFFFFF LEFTMARGIN=0 TOPMARGIN=0 MARGINWIDTH=0 MARGINHEIGHT=0>";
                strHtmlBody = "<HTML><BODY BGCOLOR=#FFFFFF LEFTMARGIN=0 TOPMARGIN=0 MARGINWIDTH=0 MARGINHEIGHT=0>";
                strHtmlBody += "<table width=100% border=0 cellspacing=0 cellpadding=0 style='font-family:Arial Unicode MS;color:#495257;font-size:11px;font-style:normal;'>";
                strHtmlBody += "<tr><td  style=font-family: Arial Unicode MS>" + MailBody + " <br><br> </td> </tr>";
                //strHtmlBody += "<tr><td colspan=3 height=10><br></td></tr>";
                strHtmlBody += "<tr><td colspan=3 height=10><Br><br>" + strRegards + "<br></td></tr>";
                // strHtmlBody += "<tr><td colspan=3 height=10>" + System.Configuration.ConfigurationManager.AppSettings["InternalUrl"].ToString() + "</td></tr>";
                strHtmlBody += "</table></BODY></HTML>";
                MailMessage message = new MailMessage();
                string FromAddress = FrommailID.ToString();
                string ToAddress = ToMailID;
                message.From = new MailAddress(FromAddress, "ABS");
                string ReplyAddress = FrommailID.ToString();
                MailAddress ReplyTo = new MailAddress(ReplyAddress);
                message.To.Add(ToAddress);
                message.Subject = Subject.ToString();
                message.Body = strHtmlBody.ToString();
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                string from = string.Empty;
                string password = string.Empty;
                //client.UseDefaultCredentials = false;
                client.Host = System.Configuration.ConfigurationSettings.AppSettings["smtphost"].ToString();
                //client.Port = 25;
                //client.UseDefaultCredentials = true;
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            client.Port = 587;
	    client.EnableSsl = true;
                client.Send(message);
                MailBody = null;
            }
            catch (Exception e)
            {
                //DAL.CommonDAL dal = new EPiServer.DAL.CommonDAL();
                //dal.InsertExceptionLog(e);
            }
        }

        public void sendNotificationMail(string toMail, string Name, string strBody,string Subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                string FromAddress = ConfigurationManager.AppSettings["MailFrom"].ToString();
                string ToAddress = toMail;
                message.From = new MailAddress(FromAddress, "ABS");
                message.To.Add(toMail);
                message.Subject = Subject;
                message.Body = strBody.ToString();
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                string from = string.Empty;
                string password = string.Empty;
                //client.UseDefaultCredentials = false;
                client.Host = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                //client.Port = 25;
                //client.UseDefaultCredentials = true;
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            client.Port = 587;
	    client.EnableSsl = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void sendCourseRegistrationMail(string toMail, string Name, string strBody)
        {
            try
            {
                string subject = "Registration completed successfully..";
                MailMessage message = new MailMessage();
                string FromAddress = ConfigurationManager.AppSettings["MailFrom"].ToString();
                string ToAddress = toMail;
                message.From = new MailAddress(FromAddress, "ABS");
                message.To.Add(toMail);
                message.Subject = subject.ToString();
                message.Body = strBody.ToString();
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                string from = string.Empty;
                string password = string.Empty;
                //client.UseDefaultCredentials = false;
                client.Host = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                //client.Port = 25;
                //client.UseDefaultCredentials = true;
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            client.Port = 587;
	    client.EnableSsl = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void sendForgotPasswordMail(string toMail, string strBody,string Subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                string FromAddress = ConfigurationManager.AppSettings["MailFrom"].ToString();
                string ToAddress = toMail;
                message.From = new MailAddress(FromAddress,"ABS");
                message.To.Add(toMail);
                message.Subject = Subject;
                message.Body = strBody.ToString();
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                string from = string.Empty;
                string password = string.Empty;
                //client.UseDefaultCredentials = false;
                client.Host = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                //client.Port = 25;
                //client.UseDefaultCredentials = true;
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            client.Port = 587;
	    client.EnableSsl = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void sendFeedbackMail(string toMail, string strBody,string filename,string name)
        {
            try
            {
                string subject = "SME Financial Modeling Tool FeedBack from "+ name;
                MailMessage message = new MailMessage();
                string FromAddress = ConfigurationManager.AppSettings["MailFrom"].ToString();
                string ToAddress = toMail;
                message.From = new MailAddress(FromAddress, "ABS");
                message.To.Add(toMail);
                message.Subject = subject.ToString();
                message.Body = strBody.ToString();
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                string path =HttpContext.Current.Server.MapPath(".") + "\\"+filename;
                Attachment act=new Attachment(path);
                message.Attachments.Add(act);
                SmtpClient client = new SmtpClient();
                string from = string.Empty;
                string password = string.Empty;
                //client.UseDefaultCredentials = false;
                client.Host = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                //client.Port = 25;
                //client.UseDefaultCredentials = true;
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            client.Port = 587;
	    client.EnableSsl = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void sendRecommendSiteMail(string toMail, string fromMail, string strBody)
        {
            try
            {
                string subject = "SME Financial Modeling Tool Recommended Site";
                MailMessage message = new MailMessage();
                string FromAddress = fromMail;
                string ToAddress = toMail;
                message.From = new MailAddress(FromAddress,"ABS");
                message.To.Add(toMail);
                message.Subject = subject.ToString();
                message.Body = strBody.ToString();
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;               
                SmtpClient client = new SmtpClient();
                string from = string.Empty;
                string password = string.Empty;
                //client.UseDefaultCredentials = false;
                client.Host = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                //client.Port = 25;
                //client.UseDefaultCredentials = true;
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            client.Port = 587;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void sendClinicalSession(string toMail, string Name, string strBody,string Subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                string FromAddress = ConfigurationManager.AppSettings["MailFrom"].ToString();
                string ccMail = ConfigurationManager.AppSettings["ccMail"].ToString();
                string ToAddress = toMail;
                message.From = new MailAddress(FromAddress, "ABS");
                message.To.Add(toMail);
                message.CC.Add(ccMail);
                message.Subject = Subject;
                message.Body = strBody.ToString();
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient();
                string from = string.Empty;
                string password = string.Empty;
                //client.UseDefaultCredentials = false;
                client.Host = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                //client.Port = 25;
                //client.UseDefaultCredentials = true;
                //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPUserName"].ToString(), ConfigurationManager.AppSettings["SMTPPassword"].ToString());
            client.Port = 587;
	    client.EnableSsl = true;
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}