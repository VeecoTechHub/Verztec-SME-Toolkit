using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.Win32;
using DBLinks;

using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;

using System.Net.Mail;

/// <summary>
/// Summary description for CommonFunctions
/// </summary>
public class CommonFunctions
{
    //private DatabaseConnector dbConnection;

    public string ConnectionString;
    DAL dal;
    /// <summary>
    /// Obtaining the database Connectivity
    /// </summary>
    public CommonFunctions()
    {
        /**this.ConnectionString = NusDataAccessLayer.GetConnectionString();//GetConnectionString();// ConfigurationManager.AppSettings["OledbConnStr"];**/
        dal = new DAL();

    }

    /// <summary>
    /// Encrypting function
    /// </summary>
    /// <param name="strTextToEncrypt">Text to Encrypt</param>
    /// <returns>After Encrypt</returns>
    #region Method To EnCrypt the Text
    public string EncryptText(string strTextToEncrypt)
    {
        int i;
        int c=0;
        string strResult;
        object strCryptoKey = ConfigurationManager.AppSettings["CryptoKey"];
        strResult = "";
      
        if (strTextToEncrypt != "")
        {
            if ((strTextToEncrypt.Length) > 0)
            {
                for (i = 0; i < (strTextToEncrypt.Length); i++)
                {
                    c = ascii_fun(strTextToEncrypt.ToString().Substring(i, 1)) + (ascii_fun(strCryptoKey.ToString().Substring(i, 1)) % 31);
                    strResult = strResult + c;
                }
            }
        }
        return strResult;
    }
    #endregion

    #region Method to DeCrypt Text
    public string DecryptText(string strTextToDecrypt)
    {
        int i;
        int c;
        string strResult;
        object strCryptoKey = ConfigurationManager.AppSettings["CryptoKey"];
        strResult = "";
        if (((strTextToDecrypt)) != null)
        {
            if (strTextToDecrypt.Length > 0)
            {
                for (i = 0; i <= strTextToDecrypt.Length - 1; i++)
                {
                    c = ascii_fun(strTextToDecrypt.Substring(i, 1)) - (ascii_fun(strCryptoKey.ToString().Substring(i, 1)) % 31);
                    strResult = strResult + System.Convert.ToChar(c);

                }
            }
        }
        return strResult;
    }
    #endregion

    #region   Check Encrypt and Decrypt

    const string DESKey = "AQWSEDRF";
    const string DESIV = "HGFEDCBA";

    public string Decrypt(string stringToDecrypt)//Decrypt the content
    {
        byte[] key;
        byte[] IV;
        byte[] inputByteArray;
        
        try
        {
            if (string.IsNullOrEmpty(stringToDecrypt))
            {
                throw new ArgumentException("Input string to decrypt cannot be null or empty");
            }

            key = Convert2ByteArray(DESKey);
            IV = Convert2ByteArray(DESIV);

            int len = stringToDecrypt.Length;
            
            try
            {
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
            }
            catch (FormatException ex)
            {
                System.Diagnostics.Debug.WriteLine("Base64 Decode Error. Input length: " + stringToDecrypt.Length + ", Input: " + stringToDecrypt);
                throw new FormatException("Invalid Base64 format. Ensure the input string is properly URL-decoded. Input length: " + stringToDecrypt.Length, ex);
            }

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            Encoding encoding = Encoding.UTF8;
            string result = encoding.GetString(ms.ToArray());
            
            ms.Close();
            cs.Close();
            
            return result;
        }
        catch (System.Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Decrypt Error: " + ex.Message);
            throw;
        }
    }

    public string Encrypt(string stringToEncrypt)// Encrypt the content
                {

        byte[] key;
        byte[] IV;

        byte[] inputByteArray;
        try
        {

            key = Convert2ByteArray(DESKey);

            IV = Convert2ByteArray(DESIV);

            inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);

            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        catch (System.Exception ex)
        {

            throw ex;
        }

    }

    static byte[] Convert2ByteArray(string strInput)
    {

        int intCounter; char[] arrChar;
        arrChar = strInput.ToCharArray();

        byte[] arrByte = new byte[arrChar.Length];

        for (intCounter = 0; intCounter <= arrByte.Length - 1;intCounter++)
            arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

        return arrByte;
    }

    #endregion


    #region   checkaccess

    /**
    public string CheckAccess(string Str_Func_ID, string Str_User_Id, string Str_Group_Id)
    {
        string Str_Links;
        string strPath;
        string strSQLMFun;
        DataSet dsTempFunction1 = new DataSet();
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_CHKFUNCACCESS", ConnectionString);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters.Add("var_grp_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_func_id"].Value = Str_Func_ID;
        OledbDa.SelectCommand.Parameters["var_grp_id"].Value = Str_Group_Id;
        OledbDa.Fill(dsTempFunction1);

        if (System.Convert.ToInt32(dsTempFunction1.Tables[0].Rows[0][0]) == 0)
        {
            strPath = ConfigurationSettings.AppSettings["InternalUrl"];
            //dbConnection.Close_Conn();
            return strPath + "Adminfintool/Main.aspx";
        }
        else
        {
            DataSet dsTempFunction = new DataSet();
            OleDbDataAdapter OledbDa1 = new OleDbDataAdapter("AWC_USP_GETFUNCLINKS", ConnectionString);
            OledbDa1.SelectCommand.CommandType = CommandType.StoredProcedure;
            OledbDa1.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
            OledbDa1.SelectCommand.Parameters["var_func_id"].Value = Str_Func_ID;
            OledbDa1.Fill(dsTempFunction);

            DataSet dsTempFunction2 = new DataSet();
            OleDbDataAdapter OledbDa2 = new OleDbDataAdapter("AWC_USP_GETFUNCLINKS", ConnectionString);
            OledbDa2.SelectCommand.CommandText = "AWC_USP_GET_STSDESC_FROM_STS";
            OledbDa2.SelectCommand.CommandType = CommandType.StoredProcedure;
            OledbDa2.SelectCommand.Parameters.Add("var_sts", OleDbType.VarChar).Direction = ParameterDirection.Input;
            OledbDa2.SelectCommand.Parameters["var_sts"].Value = dsTempFunction.Tables[0].Rows[0][3].ToString();
            OledbDa2.Fill(dsTempFunction2);


            Str_Links = dsTempFunction.Tables[0].Rows[0][0] + "|" + dsTempFunction.Tables[0].Rows[0][1] + "|" + dsTempFunction.Tables[0].Rows[0][2] + "|" + dsTempFunction2.Tables[0].Rows[0][0] + "|" + dsTempFunction.Tables[0].Rows[0][4] + "<script>if((document.location + '').indexOf('_')>0)document.write(' (' + (document.location + '').substr((document.location + '').lastIndexOf('_')+1,((document.location + '').indexOf('.aspx')-((document.location + '').lastIndexOf('_')+1))) + ')');//if((document.location + '').indexOf('Add')>0)document.write(' (Add)');if((document.location + '').indexOf('Update')>0)document.write(' (Edit)');</script>";
            //dbConnection.Close_Conn();
            return Str_Links;
        }
    }

    **/

    public string CheckAccess(string Str_Func_ID, string Str_User_Id, string Str_Group_Id)
    {
        string Str_Links;
        string strPath;
        string strSQLMFun;
        DataSet dsTempFunction1 = new DataSet();



        SqlParameter[] parameter = new SqlParameter[3];
        parameter[0] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Func_ID);
        parameter[1] = CommonFunctions.MakeParam("@pGroupID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Group_Id);
        parameter[2] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetGroupPriviligesCount");
        //////dsTempFunction1= DAL.GetListWithParam("[AWC_SP_CHKFUNCACCESS]", parameter);
        dsTempFunction1 = DAL.GetListWithParam("[Usp_CommonFunctions]", parameter);




        /**
        OleDbDataAdapter OledbDa = new OleDbDataAdapter("AWC_SP_CHKFUNCACCESS", ConnectionString);
        OledbDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        OledbDa.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters.Add("var_grp_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
        OledbDa.SelectCommand.Parameters["var_func_id"].Value = Str_Func_ID;
        OledbDa.SelectCommand.Parameters["var_grp_id"].Value = Str_Group_Id;
        OledbDa.Fill(dsTempFunction1);
        **/

        if (System.Convert.ToInt32(dsTempFunction1.Tables[0].Rows[0][0]) == 0)
        {
            strPath = ConfigurationSettings.AppSettings["InternalUrl"];
            //dbConnection.Close_Conn();
            return strPath + "Adminfintool/Main.aspx";
        }
        else
        {
            DataSet dsTempFunction = new DataSet();
            SqlParameter[] parameter2 = new SqlParameter[2];
            parameter2[0] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Func_ID);
            parameter2[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetFunctionLinks");
            //////dsTempFunction = DAL.GetListWithParam("[AWC_USP_GETFUNCLINKS]", parameter);
            dsTempFunction = DAL.GetListWithParam("[Usp_CommonFunctions]", parameter2);


            /**
            OleDbDataAdapter OledbDa1 = new OleDbDataAdapter("AWC_USP_GETFUNCLINKS", ConnectionString);
            OledbDa1.SelectCommand.CommandType = CommandType.StoredProcedure;
            OledbDa1.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
            OledbDa1.SelectCommand.Parameters["var_func_id"].Value = Str_Func_ID;
            OledbDa1.Fill(dsTempFunction);
            **/


            DataSet dsTempFunction2 = new DataSet();
            SqlParameter[] parameter1 = new SqlParameter[2];
            parameter1[0] = CommonFunctions.MakeParam("@pStatus", SqlDbType.VarChar, 50, ParameterDirection.Input, dsTempFunction.Tables[0].Rows[0][3].ToString());
            parameter1[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetStatusDescFromStatus");
            //////dsTempFunction2 = DAL.GetListWithParam("[AWC_USP_GET_STSDESC_FROM_STS]", parameter);
            dsTempFunction2 = DAL.GetListWithParam("[Usp_CommonFunctions]", parameter1);


            /**
            DataSet dsTempFunction2 = new DataSet();
            OleDbDataAdapter OledbDa2 = new OleDbDataAdapter("AWC_USP_GETFUNCLINKS", ConnectionString);
            OledbDa2.SelectCommand.CommandText = "AWC_USP_GET_STSDESC_FROM_STS";
            OledbDa2.SelectCommand.CommandType = CommandType.StoredProcedure;
            OledbDa2.SelectCommand.Parameters.Add("var_sts", OleDbType.VarChar).Direction = ParameterDirection.Input;
            OledbDa2.SelectCommand.Parameters["var_sts"].Value = dsTempFunction.Tables[0].Rows[0][3].ToString();
            OledbDa2.Fill(dsTempFunction2);
            **/


            Str_Links = dsTempFunction.Tables[0].Rows[0][0] + "|" + dsTempFunction.Tables[0].Rows[0][1] + "|" + dsTempFunction.Tables[0].Rows[0][2] + "|" + dsTempFunction2.Tables[0].Rows[0][0] + "|" + dsTempFunction.Tables[0].Rows[0][4] + "<script>if((document.location + '').indexOf('_')>0)document.write(' (' + (document.location + '').substr((document.location + '').lastIndexOf('_')+1,((document.location + '').indexOf('.aspx')-((document.location + '').lastIndexOf('_')+1))) + ')');//if((document.location + '').indexOf('Add')>0)document.write(' (Add)');if((document.location + '').indexOf('Update')>0)document.write(' (Edit)');</script>";
            //dbConnection.Close_Conn();
            return Str_Links;
        }
    }
    #endregion


    #region   getpagesize
    public Int16 Get_Page_Size(string Str_Function)
    {
        //DatabaseConnector dbConnection = new DatabaseConnector();
        try
        {

            /**
            DataSet dsTempFunction3 = new DataSet();
            OleDbDataAdapter OledbDa3 = new OleDbDataAdapter("AWC_USP_GETPAGESIZE", ConnectionString);
            OledbDa3.SelectCommand.CommandType = CommandType.StoredProcedure;
            OledbDa3.SelectCommand.Parameters.Add("var_func_id", OleDbType.VarChar).Direction = ParameterDirection.Input;
            OledbDa3.SelectCommand.Parameters["var_func_id"].Value = Str_Function;
            OledbDa3.Fill(dsTempFunction3);
            **/

            DataSet dsTempFunction3 = new DataSet();
            SqlParameter[] parameter = new SqlParameter[2];
            parameter[0] = CommonFunctions.MakeParam("@pFunctionID", SqlDbType.VarChar, 50, ParameterDirection.Input, Str_Function);
            parameter[1] = CommonFunctions.MakeParam("@pOperation", SqlDbType.VarChar, 50, ParameterDirection.Input, "GetPageSize");
            //////dsTempFunction3 = DAL.GetListWithParam("[AWC_USP_GETPAGESIZE]", parameter);
            dsTempFunction3 = DAL.GetListWithParam("[Usp_CommonFunctions]", parameter);

            return System.Convert.ToInt16(dsTempFunction3.Tables[0].Rows[0][0]);
        }
        catch
        {
            return 10;
        }
    }

    #endregion

    public static string delQuote(string str)
    {
        if (str != null)
        {
            if (str != "")
            {
                return str.Replace("'", "''");
            }
            else
            {
                return "";
            }
        }
        else
        {
            return "";
        }
    }

    public static long delQuoteint(long id)
    {
        if (id != 0)
        {
            return id;
        }
        else
        {
            return 0;
        }
    }


    public int ascii_fun(string str1)
    {
        char a;
        a = Convert.ToChar(str1);
        int asc = a; // First way
        return asc;
    }
    public static string getContent(string Content)
    {
        string NewContent = Content;
        if (NewContent.Contains("<"))
        {
            NewContent = NewContent.Replace("<", "&lt;");
        }
        if (NewContent.Contains(">"))
        {
            NewContent = NewContent.Replace(">", "&gt;");
        }
        //if (NewContent.Contains("("))
        //{
        //    NewContent = NewContent.Replace("(", "&#40");
        //}
        //if (NewContent.Contains(")"))
        //{
        //    NewContent = NewContent.Replace(")", " &#41");
        //}
        return NewContent;
    }

    public bool Send_email(string mailto, string mailFrom, string strSubject, string ccList, string strBody)
    {
        try
        {

            MailMessage MyMail = new MailMessage();
            SmtpClient SmtpMail = new SmtpClient();

            MailAddress ReplyTo = new MailAddress(mailFrom.ToString().Trim());
            MyMail.To.Add(mailto.ToString().Trim());
            if (!ccList.ToString().Equals(""))
                MyMail.Bcc.Add(ccList);
            SmtpMail.Host = System.Configuration.ConfigurationManager.AppSettings["mail_smtpserver"].ToString();
            SmtpMail.UseDefaultCredentials = true;
            SmtpMail.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            SmtpMail.Port = 25;
            MailAddress FromAdd = new MailAddress(mailFrom.ToString().Trim());
            MyMail.From = FromAdd;
            MyMail.Subject = strSubject;
            MyMail.IsBodyHtml = true;
            MyMail.Body = strBody;
            SmtpMail.Send(MyMail);
            //lblStatus.Text = "Mail Sent Successfully...";
            // lblStatus.Visible = true;

            //CDONTS.NewMail msg = new CDONTS.NewMail();
            //MailMessage msg = new MailMessage();
            //msg.To = mailto;
            //msg.Cc = ccList;
            //msg.From = mailFrom;
            //msg.Subject = strSubject;


            ////msg.Body = strbody;

            ////msg.BodyFormat = 0;
            ////msg.MailFormat = 0;
            ////msg.Send(mailFrom, mailto, strSubject, strbody, 1);
            ////strbody = "";

            //msg.BodyFormat = MailFormat.Html;
            //msg.Body = strBody;

            //SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["mail_smtpserver"];
            //SmtpMail.Send(msg);
            //strBody = "";
            //msg = null;

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #region Making parameters to pass it to the StoredProcedure
    public static SqlParameter MakeParam(string ParamName, SqlDbType DataType, Int32 Size,
        ParameterDirection Direction, object Value)
    {
        SqlParameter myParameter = new SqlParameter(ParamName, DataType);

        //myParameter.ParameterName= ParamName;
        //myParameter.DbType=DataType;

        if (Size > 0)
        {
            myParameter.Size = Size;
        }
        myParameter.Direction = Direction;
        if (!(Direction == ParameterDirection.Output && Value == null))
        {

            myParameter.Value = Value;
        }
        //myParameter.IsNullable = true;

        return myParameter;
    }

    #endregion

}
