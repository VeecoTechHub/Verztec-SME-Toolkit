using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.Common;
using System.Text;
using System.IO;
using System.Web.Mail;
using System.Net;
using System.Security.Cryptography;


namespace Global
{
    /// <summary>
    /// Summary description for Global
    /// </summary>
    public class Globals
    {
        private System.Data.SqlClient.SqlConnection dbConnection;
        private System.Data.SqlClient.SqlDataAdapter dbAdapter;
        private System.Data.SqlClient.SqlCommand dbCommand;
        private System.Data.OleDb.OleDbDataAdapter oleDataAdapter;

        public Globals()
        {

            try
            {
                //this.dbConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                this.dbConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                if (dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection.Open();
                }
                if (dbConnection.State == ConnectionState.Broken)
                {
                    dbConnection.Close();
                    dbConnection.Open();
                }
            }
            catch (Exception ex)
            {
                string strerror;
                strerror = ex.Message;
                dbConnection.Close();
            }

        }

        public static string GetTime()
        {
            string TimeInString = "";
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

            TimeInString = (hour < 10) ? "0" + hour.ToString() : hour.ToString();
            TimeInString += ":" + ((min < 10) ? "0" + min.ToString() : min.ToString());
            TimeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
            return TimeInString;
        }

        public static string ReplaceQuote(string strFileName)
        {
            strFileName = strFileName.Replace("'", "");
            strFileName = strFileName.Replace("%20", "");
            strFileName = strFileName.Replace("&", "");
            return strFileName;
        }

        /// <summary>
        /// Convert string to Date String
        /// </summary>
        /// <param name="YYYYMMDD"></param>
        /// <returns>dd-MMM-yyyy</returns>
        public static string DDMMMYYYY(string YYYYMMDD)
        {
            string Fyear;
            string FMonth;
            String FDay;
            String FDate;
            Fyear = YYYYMMDD.Substring(0, 4);
            FDay = YYYYMMDD.Substring(6, 2);
            FMonth = YYYYMMDD.Substring(4, 2);
            FDate = String.Format("{0:dd-MMM-yyyy}", DateTime.Parse(FMonth + "/" + FDay + "/" + Fyear));
            return FDate;
        }
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="ddMMyyyy">dd/mm/yyyy</param>
        /// <returns></returns>
        public static string yyyyddMM(string ddMMyyyy)
        {
      
            string Fyear;
            string FMonth;
            String FDay;
            String FDate;
            FDay = ddMMyyyy.Substring(0, 2);
            FMonth = ddMMyyyy.Substring(3, 2);
            Fyear = ddMMyyyy.Substring(6, 4);
            FDate = Fyear+FMonth+FDay;
            return FDate;
        }

        public string Encrypt(string pwd)
        {
            //MD5CryptoServiceProvider md5Hasher=new MD5CryptoServiceProvider();
            SHA1CryptoServiceProvider md5Hasher = new SHA1CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(pwd));
            return Convert.ToBase64String(hashedBytes);
        }

        #region To send Email to the desired reciepents.
        //public static string SendMail(string[] strTo, string strFrom, string strBody, string strSubject, string[] strCc)
        //{
        //    strBody = "<font face='Arial'>" + strBody + "</font>";
        //    MailMessage MyMail = new MailMessage();
        //    SmtpClient SmtpMail = new SmtpClient();
        //    string strToAdd = "";
        //    for (int intI = 0; intI < strTo.Length; intI++)
        //    {
        //        if (strTo[intI] != null && strTo[intI] != "")
        //        {
        //            strToAdd += strTo[intI] + ",";
        //        }
        //    }
        //    strToAdd = strToAdd.Substring(0, strToAdd.Length - 1);
        //    MyMail.To.Add(strToAdd);
        //    SmtpMail.Host = ConfigurationManager.AppSettings["mail_smtpserver"].ToString();//"localhost";//"pop.synergies.com.sg";
        //    SmtpMail.Port = 25;
        //    MailAddress FromAdd = new MailAddress(strFrom);
        //    MyMail.From = FromAdd;
        //    MyMail.Bcc.Add("rajendra_parise@yahoo.co.in");
        //    MyMail.Subject = strSubject;
        //    MyMail.IsBodyHtml = true;
        //    MyMail.Body = strBody;
        //    try
        //    {
        //        SmtpMail.Send(MyMail);
        //        return "success";
        //    }
        //    catch (Exception Ex)
        //    {
        //        string strError = Ex.Message;
        //        throw Ex;
        //        return "";
        //    }
        //}
        #endregion

        //#region JobApplication Mail
        //public static string SendJobApplicationMail(string[] strTo, string strFrom, string strBody, string strSubject, string[] strCc, string file1)
        //{
        //    strBody = "<font face='Arial'>" + strBody + "</font>";
        //    MailMessage MyMail = new MailMessage();
        //    SmtpClient SmtpMail = new SmtpClient();
        //    string strToAdd = "";
        //    for (int intI = 0; intI < strTo.Length; intI++)
        //    {
        //        strToAdd += strTo[intI] + ",";
        //    }
        //    strToAdd = strToAdd.Substring(0, strToAdd.Length - 1);
        //    MyMail.To.Add(strToAdd);
        //    if (strCc.Length > 0)
        //    {
        //        string strToCCAdd = "";
        //        for (int intI = 0; intI < strCc.Length; intI++)
        //        {
        //            strToCCAdd += strCc[intI] + ",";
        //        }

        //        MyMail.CC.Add(strToCCAdd);
        //    }
        //    //MyMail.Bcc.Add("sudheer@synergies.com.sg");
        //    SmtpMail.Host = ConfigurationManager.AppSettings["mail_smtpserver"].ToString();//"localhost";//"pop.synergies.com.sg";
        //    SmtpMail.Port = 25;
        //    MailAddress FromAdd = new MailAddress(strFrom);
        //    MyMail.From = FromAdd;
        //    MyMail.Subject = strSubject;
        //    MyMail.IsBodyHtml = true;
        //    MyMail.Body = strBody;
        //    if (file1 != "")
        //        MyMail.Attachments.Add(new Attachment(file1));         

        //    try
        //    {
        //        SmtpMail.Send(MyMail);
        //        return "success";
        //    }
        //    catch (Exception Ex)
        //    {
        //        string strError = Ex.Message;
        //        return "";
        //    }
        //}
        //#endregion


        #region Error Handling to display page

        public static string Generate()
        {
            int minlenght = 3;
            int maxlenght = 5;
            int y;
            int lenght = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PasswordLenght"]);
            Random Rnd = new Random();

            string Password = string.Empty;
            if (lenght == 0)
            {
                lenght = (maxlenght * Convert.ToInt32(Rnd.NextDouble()) + minlenght);
            }

            for (int count = 0; count < lenght; count++)
            {
                y = Convert.ToInt32((3 * Rnd.NextDouble()) + 1);

                switch (y)
                {
                    case 1:
                        //Numeric character Randomize
                        Password += Convert.ToChar(Convert.ToInt32((9 * Rnd.NextDouble()) + 48));
                        break;

                    case 2:
                        //Uppercase character Randomize
                        Password += Convert.ToChar(Convert.ToInt32((25 * Rnd.NextDouble()) + 65));
                        break;

                    case 3:
                        //Lowercase character Randomize
                        Password += Convert.ToChar(Convert.ToInt32((25 * Rnd.NextDouble()) + 97));
                        break;
                    default:
                        Password += Convert.ToChar(Convert.ToInt32((9 * Rnd.NextDouble()) + 48));
                        break;

                }

            }
            return Password;

        }


        public static void send_email(string str_to, string str_from, string str_cc, string subject, string body)
        {
            try
            {
                System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient();


                smtpClient.Host = ConfigurationManager.AppSettings.Get("SMTPHost").ToString();
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Port").ToString());
                //myMail.Sender = new MailAddress(ConfigurationManager.AppSettings.Get("Sender_mail_address").ToString());
                //myMail.ReplyTo = new MailAddress(ConfigurationManager.AppSettings.Get("ReplyTo_mail_address").ToString());

                smtpClient.UseDefaultCredentials = true;
                //smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings.Get("usercredential_userid").ToString(), ConfigurationSettings.AppSettings.Get("usercredential_pwd").ToString());

                if (str_to != "")
                {

                    if (ConfigurationManager.AppSettings.Get("AdminMail").ToString() == "Y")
                        myMail.To.Add(ConfigurationManager.AppSettings.Get("AdminMail").ToString());
                    else
                        myMail.To.Add(str_to);

                    if (ConfigurationManager.AppSettings.Get("AdminMail").ToString() == "N")
                    {
                        if (str_cc != "" && str_cc != ",")
                        {
                            str_cc.Replace(",,", ",");
                            myMail.CC.Add(str_cc);
                        }
                    }

                    //myMail.From = new MailAddress(str_from);

                    myMail.From = new MailAddress(ConfigurationManager.AppSettings.Get("MailFrom").ToString());

                    myMail.Subject = subject;
                    myMail.IsBodyHtml = true;
                    myMail.Body = body;
                    //smtpClient.Send(myMail);                    
                }
            }
            catch (Exception ex)
            { }
        }


        public static void send_emailAttachment(string str_to, string str_from, string str_cc, string subject, string body)
        {
            try
            {
                string strLogFolderpath = System.Configuration.ConfigurationManager.AppSettings.Get("logpath");
                string strLogFileName = "ABS_ErrorLog_" + string.Format("{0:dd-MMM-yyyy}", System.DateTime.Now) + ".txt";

                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                string FromAddress = System.Configuration.ConfigurationManager.AppSettings["AdminMail"].ToString();
                string ccMail = System.Configuration.ConfigurationManager.AppSettings["ErrorccMail"].ToString();
                string ToAddress = str_to;
                message.From = new MailAddress(FromAddress,"ABS");
                message.To.Add(ToAddress);
                message.CC.Add(ccMail);
                StringBuilder strSubject = new StringBuilder();
                strSubject.Append("Error Log File");

                Attachment attachLogFile = new Attachment(HttpContext.Current.Server.MapPath(strLogFolderpath + strLogFileName));
                message.Attachments.Add(attachLogFile);


                StringBuilder strBody = new StringBuilder();
                strBody.Append("Error Log File");
                message.Subject = strSubject.ToString();
                message.Body = strBody.ToString();
                message.IsBodyHtml = true;
                message.Priority = System.Net.Mail.MailPriority.High;
                SmtpClient client = new SmtpClient();
                client.Host = System.Configuration.ConfigurationSettings.AppSettings["SMTPHost"].ToString();
                client.Port = 25;
                client.Send(message);
                strBody = null;
                attachLogFile.Dispose();
            }
            catch (Exception ex)
            { }

        }

        //Import the Data from Excel

        public static DataTable ImportFromExcelToTable(string filepath, string SheetName)
        {
            DataTable dt;
            dt = null;
            // string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + filepath + "; Extended Properties=Excel 8.0;";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filepath + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
            // Establish a connection to the data source.
            using (OleDbConnection Connection = new OleDbConnection(connectionString))
            {
                Connection.Open();
                //reading data from excel to Data Table
                using (OleDbCommand command = new OleDbCommand())
                {
                    command.Connection = Connection;
                    command.CommandText = "SELECT * FROM " + "$" + SheetName;
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        adapter.SelectCommand = command;
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }

        }

        
        public string Write_XML_TblData(DataTable tbl_Data)
        {
            System.IO.MemoryStream memStream = new System.IO.MemoryStream();
            string xmlData = null;

            tbl_Data.WriteXml(memStream);

            memStream.Seek(0, System.IO.SeekOrigin.Begin);

            System.IO.StreamReader streamRdr = new System.IO.StreamReader(memStream);
            xmlData = streamRdr.ReadToEnd();
            streamRdr.Close();
            streamRdr.Dispose();

            return xmlData;
        }



        //Added by ranganath 25March2010
        public DataSet uploadExcelData(string str_FileName)
        {
            string excelConnectionString;
            // excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + str_FileName + "'" + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";

            excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + str_FileName + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";

            using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
            {
                connection.Open();
                DataSet dsTemp = new DataSet();
                DataSet ds_ExcelSheets = new DataSet();
                System.Data.OleDb.OleDbSchemaGuid obj = new OleDbSchemaGuid();
                DataTable dtSheetNames = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                dsTemp.Tables.Add(dtSheetNames);
                for (int i = 0; i < dtSheetNames.Rows.Count; i++)
                {
                    OleDbCommand command = new OleDbCommand("select * from [" + dtSheetNames.Rows[i]["TABLE_NAME"].ToString() + "]", connection);
                    oleDataAdapter = new OleDbDataAdapter();
                    oleDataAdapter.SelectCommand = command;
                    oleDataAdapter.Fill(dsTemp, dtSheetNames.Rows[i]["TABLE_NAME"].ToString());
                }
                return dsTemp;

                //  Create DbDataReader to Data Worksheet
                //using (DbDataReader dr = command.ExecuteReader())
                //{

                //    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(dbConnection))
                //    {
                //        bulkCopy.DestinationTableName = TableName;
                //        bulkCopy.WriteToServer(dr);
                //    }

                //}
            }
        }

        public static void RiseError(Exception exception)
        {
            string UserDetails = string.Empty;
            User_Logic objSession = new User_Logic();

            if (User_Logic.sessionU_ID != null)
                UserDetails = UserDetails + "\n\n User ID: " + User_Logic.sessionU_ID + "\n  ";

            //if (User_Logic.sessionUserId != null)
            //    UserDetails = UserDetails + "USER ID: " + User_Logic.sessionUserId + "\n";

            //if (User_Logic.sessionGROUPID != null)
            //    UserDetails = UserDetails + "Group ID: " + User_Logic.sessionGROUPID + "\n";

            if (User_Logic.sessionUSERName != null)
                UserDetails = UserDetails + "User Name: " + User_Logic.sessionUSERName + "\n  ";

            //Create object
            error_handler EH = new error_handler();
            //Set MessageType
            EH.MsgType = MessageType.TextFile;

            HttpContext ctx = HttpContext.Current;
            //Exception exception = ctx.Server.GetLastError();

            string InnerException = string.Empty;

            if (exception.InnerException != null)
                InnerException = "Inner exception: " + exception.InnerException.ToString();

            string errorInfo =
           "\n\n Offending URL: " + ctx.Request.Url.ToString() +
           "\n Source: " + exception.Source +
           "\n Message: " + exception.Message +
           "\n " + InnerException +
           "\n Stack trace: " + exception.StackTrace;

            EH.RaiseError(UserDetails + errorInfo);

        }

        #region ReadTextFile
        public static string GetMailMessage(string fileNm)
        {

            StringBuilder sb = new StringBuilder();
            try
            {
                string fPath = System.AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + fileNm;
                if (File.Exists(fPath))
                {
                    using (StreamReader sr = new StreamReader(fPath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            sb.Append(line);
                        }
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return sb.ToString();
            }
        }
        #endregion

        #endregion




    }
}


