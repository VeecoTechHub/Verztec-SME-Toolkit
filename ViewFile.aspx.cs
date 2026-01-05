using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class ViewFile : System.Web.UI.Page
{
    CommonFunctions cmnobj = new CommonFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            string fileName = Request.QueryString["fileName"].ToString();
            string pdfPath = Server.MapPath("~/UploadedFiles/" + fileName + " ");
            WebClient client = new WebClient();
            Byte[] buffer = client.DownloadData(pdfPath);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", buffer.Length.ToString());
            Response.BinaryWrite(buffer);
        }
    }
}