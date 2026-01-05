using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSDAL;
using ABSDTO;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Data;
using Winnovative.WnvHtmlConvert;
using System.Drawing;
using ABSCommon;
using System.Timers;

public partial class FinancialModeling_Feedback : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    UserMgmt objUserMgmt = new UserMgmt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                ViewState["IndustryId"] = objLoginDTO.IndustryID;
                BindFeedback();

                //To Insert ModuleTrack Records
                objUserMgmt.AccessBy = Session["USER_ID"].ToString();
                objUserMgmt.CategoryId = 4;
                objUserMgmt.Downloading = "N";
                objUserMgmt.AccessDescription = "Access FeedBack";
                objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                objUserMgmt.InsertModuleTrack(objUserMgmt);

              
           
            }
        }
    }

    private void BindFeedback()
    {
        try
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            DataSet dsFeedback = objFinModelingMgmt.Get_Fintool_Feedback(objFinModelingMgmt);
            if (dsFeedback.Tables.Count > 0)
            {
                if (dsFeedback.Tables[0].Rows.Count > 0)
                {
                    //if (dsFeedback.Tables[0].Rows[0]["FEEDBACK_STAUS1"].ToString() != string.Empty)
                    //{
                    //    rdolistUserFriendly.Items.FindByText(dsFeedback.Tables[0].Rows[0]["FEEDBACK_STAUS1"].ToString()).Selected = true;
                    //}
                    //if (dsFeedback.Tables[0].Rows[0]["FEEDBACK_STAUS2"].ToString() != string.Empty)
                    //{
                    //    rdolistknowledge.Items.FindByText(dsFeedback.Tables[0].Rows[0]["FEEDBACK_STAUS2"].ToString()).Selected = true;
                    //}
                    //if (dsFeedback.Tables[0].Rows[0]["FEEDBACK_STAUS3"].ToString() != string.Empty)
                    //{
                    //    rdolistReport.Items.FindByText(dsFeedback.Tables[0].Rows[0]["FEEDBACK_STAUS3"].ToString()).Selected = true;
                    //}
                    //if (dsFeedback.Tables[0].Rows[0]["ISRECOMMENDED"].ToString() != string.Empty)
                    //{
                    //    rdolistRecommend.SelectedValue = dsFeedback.Tables[0].Rows[0]["ISRECOMMENDED"].ToString();
                    //}
                    //txtEmailId.Text = dsFeedback.Tables[0].Rows[0]["EMAILID"].ToString();
                    //txtComments.Text = dsFeedback.Tables[0].Rows[0]["COMMENTS"].ToString();

                    if (dsFeedback.Tables[0].Rows[0]["LastUpdated"].ToString() != string.Empty)
                    {
                        DateTime nowTime = DateTime.Now;
                        DateTime CompareTime = (DateTime)dsFeedback.Tables[0].Rows[0]["LastUpdated"];

                        TimeSpan span = nowTime.Subtract(CompareTime);

                        if (span.Days > 90)
                        {
                            table1.Visible = true;
                            HideTr.Visible = false;
                            trLast.Visible = false;
                            btnSave.Visible = true;
                         

                        }
                        else
                        {
                            objUserMgmt.AccessBy = Session["USER_ID"].ToString();
                            objUserMgmt.CategoryId = 4;
                            objUserMgmt.Downloading = "Y";
                            objUserMgmt.AccessDescription = "DownLoaded Report";
                            objUserMgmt.InsertModuleTrack(objUserMgmt);

                            table1.Visible = false;
                            trLast.Visible = true;
                            btnSave.Visible = false;
                            generatePdf();
                        }
                    }
                    else
                    {
                        HideTr.Visible = false;
                        trLast.Visible = false;
                    }
                }
                else
                {
                    HideTr.Visible = false;
                    trLast.Visible = false;
                }
            }
        }
        catch (Exception err)
        {
            throw err;
        }

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            if (rdolistUserFriendly.SelectedIndex >= 0)
                objFinModelingMgmt.feedback_Status1 = rdolistUserFriendly.SelectedItem.Text.ToString();

            if (rdolistknowledge.SelectedIndex >= 0)
                objFinModelingMgmt.feedback_Status2 = rdolistknowledge.SelectedItem.Text.ToString();

            if (rdolistReport.SelectedIndex >= 0)
                objFinModelingMgmt.feedback_Status3 = rdolistReport.SelectedItem.Text.ToString();

            if (rdolistRecommend.SelectedIndex >= 0)
                objFinModelingMgmt.isRecommended = Convert.ToInt32(rdolistRecommend.SelectedValue);

            objFinModelingMgmt.emailId = txtEmailId.Text;
            objFinModelingMgmt.comments = txtComments.Text;

            if (rdolistUserFriendly.SelectedIndex >= 0 || rdolistknowledge.SelectedIndex >= 0 || rdolistReport.SelectedIndex >= 0 || rdolistRecommend.SelectedIndex >= 0)
            {
                objFinModelingMgmt.Insert_Fintool_Feedback(objFinModelingMgmt);
            }


            if (txtEmailId.Text.ToString() != "" && txtEmailId.Text.ToString() != null)
            {
                //Send mail to Recommended user
                Dictionary<string, string> tempValue = new Dictionary<string, string>();
                string strMapPath = ConfigurationManager.AppSettings["RecommendSiteMailHtml"];
                string strGivenName = ConfigurationManager.AppSettings["MailFrom"];
                string strToMail = txtEmailId.Text;
                string path = Server.MapPath(strMapPath);
                HTMLParser htmlParser = new HTMLParser();
                string strBody = htmlParser.getBody("ACK", tempValue, path);
                MailManager objMailManager = new MailManager();
                objMailManager.sendRecommendSiteMail(strToMail, strGivenName, strBody);
            }


            objUserMgmt.AccessBy = Session["USER_ID"].ToString();
            objUserMgmt.CategoryId = 4;
            objUserMgmt.Downloading = "Y";
            objUserMgmt.AccessDescription = "DownLoaded Report";
            objUserMgmt.IndustryId = objUserMgmt.IndustryId;
            objUserMgmt.InsertModuleTrack(objUserMgmt);


            generatePdf();
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    public void generatePdf()
    {
        try
        {
            string MyURL = string.Empty;
            MyURL = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "FinancialModeling/Reports_All.aspx?UserId=" + Convert.ToString(ViewState["UserID"]);

            PdfConverter pdfConverter = new PdfConverter();
            pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
            pdfConverter.PdfHeaderOptions.HeaderHeight = 80;
            pdfConverter.PdfHeaderOptions.HeaderImage = System.Drawing.Image.FromFile(Server.MapPath("~/images/ABSLOGO_1.jpg"));
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
            //pdfConverter.LicenseKey = "Q2hzY3Jjc2N3bXNjcHJtcnFtenp6eg==";
			pdfConverter.LicenseKey ="GjEoOis6Ky4qIzoiNCo6KSs0Kyg0IyMjIw== "; 
			//-- Taken from web.config
            byte[] downloadBytes = pdfConverter.GetPdfFromUrlBytes(MyURL);
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.Clear();
            response.AddHeader("Content-Type", "binary/octet-stream");
            response.AddHeader("Content-Disposition", "attachment; filename=" + "FintoolRpt.pdf" + "; size=" + downloadBytes.Length.ToString());
            response.Flush(); 
            response.BinaryWrite(downloadBytes);
            response.Flush();
            response.End();


            table1.Visible = false;
            trLast.Visible = true;
            btnSave.Visible = false;
            HideTr.Visible = true;


        }
        catch (Exception err)
        {
            throw err;
        }
        
    }
    protected void lnkfake_Click(object sender, EventArgs e)
    {
        generatePdf();
    }
}
