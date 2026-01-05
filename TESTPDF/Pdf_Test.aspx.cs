using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Winnovative.WnvHtmlConvert;

public partial class Pdf_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        generatePdf();
    }
    private void generatePdf()
    {
        try
        {
            string MyURL = string.Empty;
            //MyURL = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "FinancialModeling/Reports_All.aspx?UserId=" + Convert.ToString(ViewState["UserID"]);
            MyURL = "http://smetoolkit.abs.org.sg/testpdf/hi.aspx";

            PdfConverter pdfConverter = new PdfConverter();
            pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
            //pdfConverter.PdfDocumentOptions.PdfPageOrientation = PDFPageOrientation.Portrait;
            //pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.Normal;
            pdfConverter.PageWidth = 0;
            pdfConverter.PdfDocumentOptions.FitWidth = true;
            pdfConverter.PdfDocumentOptions.LeftMargin = 20;
            pdfConverter.PdfDocumentOptions.RightMargin = 20;
            pdfConverter.PdfDocumentOptions.TopMargin = 20;
            pdfConverter.PdfDocumentOptions.BottomMargin = 20;
            pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = false;
            pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = false;

            pdfConverter.RightToLeftEnabled = true;
            //pdfConverter.ScriptsEnabled = pdfConverter.ScriptsEnabledInImage = true;
            //pdfConverter.AvoidImageBreak = true;
            //pdfConverter.LicenseKey = "Q2hzY3Jjc2N3bXNjcHJtcnFtenp6eg==";
            pdfConverter.LicenseKey = "GjEoOis6Ky4qIzoiNCo6KSs0Kyg0IyMjIw==";
            byte[] downloadBytes = pdfConverter.GetPdfFromUrlBytes(MyURL);
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "binary/octet-stream");
            response.AddHeader("Content-Disposition", "attachment; filename=" + "FintoolRpt.pdf" + "; size=" + downloadBytes.Length.ToString());
            response.Flush();
            response.BinaryWrite(downloadBytes);
            response.Flush();
            response.End();
        }
        catch (Exception err)
        {
            throw err;
        }

    }
}
