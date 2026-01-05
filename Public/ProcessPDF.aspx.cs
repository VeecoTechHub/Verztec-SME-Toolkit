using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSCommon;
using ABSDTO;
using System.Data;
using System.Configuration;
using System.IO;
using ABSDAL;
using System.Web.UI.HtmlControls;
using Winnovative.WnvHtmlConvert;
using System.Drawing;
using System.Web.Security;

public partial class Public_ProcessPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
        ViewState["UserID"] = objLoginDTO.UserID;
        generatePdf();
    }
    public void generatePdf()
    {
        try
        {
            string MyURL = string.Empty;
            string PDFConverterLicence = string.Empty;
            if (Convert.ToString(ViewState["UserID"]) != null && Convert.ToString(ViewState["UserID"]) != "")
            {
                MyURL = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "FinancialModeling/Reports_All.aspx?UserId=" + Convert.ToString(ViewState["UserID"]);
                PDFConverterLicence = ConfigurationManager.AppSettings["PDFConverterLicence"].ToString();

                PdfConverter pdfConverter = new PdfConverter();
                pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
                pdfConverter.PdfHeaderOptions.HeaderHeight = 80;
                pdfConverter.PdfHeaderOptions.HeaderImageLocation = new PointF(0, 0);
                pdfConverter.PageWidth = 0;
                pdfConverter.PdfDocumentOptions.FitWidth = true;
                pdfConverter.PdfDocumentOptions.LeftMargin = 20;
                pdfConverter.PdfDocumentOptions.RightMargin = 20;
                pdfConverter.PdfDocumentOptions.TopMargin = 20;
                pdfConverter.PdfDocumentOptions.BottomMargin = 20;
                pdfConverter.PdfDocumentOptions.GenerateSelectablePdf = false;
                pdfConverter.PdfDocumentOptions.LiveUrlsEnabled = false;
                pdfConverter.RightToLeftEnabled = true;
                pdfConverter.LicenseKey = PDFConverterLicence;
                byte[] downloadBytes = pdfConverter.GetPdfFromUrlBytes(MyURL);

                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.AddHeader("Content-Type", "binary/octet-stream");
                response.AddHeader("Content-Disposition", "attachment; filename=" + "FintoolRpt.pdf" + "; size=" + downloadBytes.Length.ToString());
                response.BinaryWrite(downloadBytes);
                response.Flush();
                response.End();


            }


        }
        catch (Exception err)
        {
            // HideTr.Visible = true;
            throw err;
        }
        finally
        {
            // HideTr.Visible = true;
            Dispose();
        }

    }
}
