using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

/// <summary>
/// Summary description for HTMLParser
/// </summary>
public class HTMLParser
{
    

    public string getBody(string Type,Dictionary<string,string> collectValue,string path)
    {
        StringBuilder template = new StringBuilder();
        switch (Type)
        {
            case "ACK":
                StreamReader SR = new StreamReader(path);
               
                template.Append(SR.ReadToEnd());
                SR.Close();
                foreach(KeyValuePair<string,string> KVP in collectValue)
                {
                    template.Replace(KVP.Key, KVP.Value);
                }
              
            break;
        }

        return template.ToString();
    }
}
