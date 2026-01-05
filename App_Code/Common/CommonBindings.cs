using System;
using System.Collections.Generic;

using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for CommonBindings
/// </summary>

namespace ABSCommon
{
    public class CommonBindings
    {
        public CommonBindings()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string Strip(string text)
        {
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }
        public static string LineBreak(string text)
        {
            if (text.Contains("\r\n"))
            {
                return text.Replace("\r\n", "<br/>");
            }
            else if (text.Contains("\n"))
            {
                return text.Replace("\n", "<br/>");
            }
            return text;
        }
        public static string UrlRegularExpression()
        {
            return @"^(((h|H)(t|T))(t|T)(p|P)((s|S)?)\:\/\/)?((w{3}|W{3})+\.)+(([0-9]{1,3}){3}[0-9]{1,3}\.|([\w!~*'()-]+\.)*([\w^-][\w-]{0,61})?[\w]\.[a-z]{2,6})(:[0-9]{1,4})?((\/*)|(\/+[\w!~*'().;?:@&=+$,%#-]+)+\/*)$|^(((h|H)(t|T))(t|T)(p|P)((s|S)?)\:\/\/)(([a-zA-Z0-9])+\.)+(([0-9]{1,3}){3}[0-9]{1,3}\.|([\w!~*'()-]+\.)*([\w^-][\w-]{0,61})?[\w]\.[a-z]{2,6})(:[0-9]{1,4})?((\/*)|(\/+[\w!~*'().;?:@&=+$,%#-]+)+\/*)$";
        }
        public static string TextForSearch(string text)
        {

            if (!string.IsNullOrEmpty(text))
            {
                text = HttpUtility.HtmlEncode(text.Replace("'", "''").Replace("%", "\\%"));
            }

            return text;
        }
        public static string TextToBind(string text)
        {

            if ((!string.IsNullOrEmpty(text)) && (text.Contains(">") || text.Contains("<")))
            {
                text = HttpUtility.HtmlEncode(text);
            }

            return text;
        }
        public static bool IsGuid(string strGuid)
        {
            try
            {
                bool isValid = true;
                if (strGuid != null && strGuid != "")
                {
                    if (Regex.IsMatch(strGuid, @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                return isValid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool IsInt(string strInt)
        {
            try
            {
                bool isValid = true;
                if (strInt != null && strInt != "")
                {

                    if (Regex.IsMatch(strInt, @"^-[0-9]+$|^[0-9]+$"))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                return isValid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string StripUnwantedHtml(string strHtml)
        {
            try
            {
                if (strHtml != null)
                {
                    string strReturn = strHtml;
                    strReturn = Regex.Replace(strReturn, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "<iframe[^>]+>", "", RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "</iframe[^>]+>", "", RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "<applet[^>]+>", "", RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "</applet[^>]+>", "", RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "javascript:", "", RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "java&#010", "", RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "java&#X0A", "", RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "TYPE=\"text/javascript\"", "", RegexOptions.IgnoreCase);
                    strReturn = Regex.Replace(strReturn, "TYPE='text/javascript'", "", RegexOptions.IgnoreCase);

                    return strReturn;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to Check the Eval value for NULL
        /// </summary>
        /// <param name="objGrid"></param>
        /// <returns></returns>
        public static string CheckNull(object objGrid)
        {
            if (object.ReferenceEquals(objGrid, DBNull.Value))
            {
                return string.Empty;
            }
            else
            {
                return objGrid.ToString();
            }
        }

    }
}