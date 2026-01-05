using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Winnovative.WnvHtmlConvert;
using System.Drawing;
using System.Web.Security;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        generatePdf();
    }
    public void generatePdf()
    {
        //System.Security.Principal.WindowsImpersonationContext impersonationContext;
        //impersonationContext = ((System.Security.Principal.WindowsIdentity)User.Identity).Impersonate();

       
            string MyURL = string.Empty;
            string PDFConverterLicence = string.Empty;
            Response.Write(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["myurl"].ToString()));
            // MyURL = "http://http://203.92.95.88/fintool/PDFtest.aspx";
            MyURL = @"http://www.google.com";
            PDFConverterLicence = ConfigurationManager.AppSettings["PDFConverterLicence"].ToString();

            PdfConverter pdfConverter = new PdfConverter();
            pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
            pdfConverter.PdfHeaderOptions.HeaderHeight = 80;
            // pdfConverter.PdfHeaderOptions.HeaderImage = System.Drawing.Image.FromFile(Server.MapPath("~/images/ABSLOGO_1.jpg"));
            pdfConverter.PdfHeaderOptions.HeaderImageLocation = new PointF(0, 0);
            pdfConverter.PageWidth = 0;
            pdfConverter.PdfDocumentOptions.FitWidth = true;
            pdfConverter.PdfDocumentOptions.LeftMargin = 20;
            pdfConverter.PdfDocumentOptions.RightMargin = 20;
            pdfConverter.PdfDocumentOptions.TopMargin = 20;
            pdfConverter.PdfDocumentOptions.BottomMargin = 20;
            pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = true;
            pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = true;
        

            //if (Context.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            //    pdfConverter.HttpRequestHeaders = String.Format("Cookie : {0}={1}",
            //            FormsAuthentication.FormsCookieName, Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            pdfConverter.RightToLeftEnabled = true;

            pdfConverter.LicenseKey = PDFConverterLicence;

          byte[] downloadBytes = pdfConverter.GetPdfBytesFromUrl("http://www.google.com");
          // byte[] downloadBytes = pdfConverter.GetPdfFromUrlBytes("http://smetoolkit.abs.org.sg/PDFtest.aspx");
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "binary/octet-stream");
            response.AddHeader("Content-Disposition", "attachment; filename=" + "FintoolRpt.pdf" + "; size=" + downloadBytes.Length.ToString());
            response.Flush();
            response.BinaryWrite(downloadBytes);
            response.Flush();
            response.End();

            //Insert your code that runs under the security context of the authenticating user here.

           // impersonationContext.Undo();
      

    }
}
