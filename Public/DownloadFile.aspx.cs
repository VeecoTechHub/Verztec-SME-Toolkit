using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net;
using System.Configuration;


public partial class Public_DownloadFile : System.Web.UI.Page
{
    string strFileName = string.Empty;
   // string virtualPath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        if (Request.QueryString["fileName"] != null)
        {
            strFileName = Request.QueryString["fileName"].ToString();
            //string serverName = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + ":" + System.Web.HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            //virtualPath = "http://" + serverName + "/" + "ABS/UploadedFiles" + "/" + strFileName;
            DownloadFile(strFileName);
        }
        
            
    }
    protected void DownloadFile(string Filename)
    {
        try
        {
            string filePath = Server.MapPath("~/UploadedFiles");
            string _DownloadableProductFileName = Filename;
            System.IO.FileInfo FileName = new System.IO.FileInfo(filePath + "\\" +
                _DownloadableProductFileName);
            FileStream myFile = new FileStream(filePath + "\\" +
                _DownloadableProductFileName, FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite);
            BinaryReader _BinaryReader = new BinaryReader(myFile);
            long startBytes = 0;
            string lastUpdateTiemStamp = File.GetLastWriteTimeUtc(filePath).ToString("r");
            string _EncodedData = HttpUtility.UrlEncode
                (_DownloadableProductFileName, Encoding.UTF8) + lastUpdateTiemStamp;
            Response.Clear();
            Response.Buffer = false;
            Response.AddHeader("Accept-Ranges", "bytes");
            Response.AppendHeader("ETag", "\"" + _EncodedData + "\"");
            Response.AppendHeader("Last-Modified", lastUpdateTiemStamp);
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName.Name);
            Response.AddHeader("Content-Length", (FileName.Length - startBytes).ToString());
            Response.AddHeader("Connection", "Keep-Alive");
            Response.ContentEncoding = Encoding.UTF8;
            _BinaryReader.BaseStream.Seek(startBytes, SeekOrigin.Begin);
            int maxCount = (int)Math.Ceiling((FileName.Length - startBytes + 0.0) / 1024);
            int i;
            for (i = 0; i < maxCount && Response.IsClientConnected; i++)
            {
                Response.BinaryWrite(_BinaryReader.ReadBytes(1024));
                Response.Flush();
            }
            _BinaryReader.Close();
            myFile.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    
}