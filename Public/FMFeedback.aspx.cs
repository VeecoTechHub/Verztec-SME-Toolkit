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
using System.Text;
using System.Globalization;
using System.Threading;


public partial class Public_FMFeedback : System.Web.UI.Page
{
    FeedBack obj_Feedback = new FeedBack();
    UserMgmt objUserMgmt = new UserMgmt();
    static bool flag = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["LoginDTO"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
            }
            else
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                ViewState["UserName"] = objLoginDTO.Name;
                ViewState["MailId"] = objLoginDTO.EmailID;
                ViewState["IndustryId"] = objLoginDTO.IndustryID;

            }
        }
        if (Session["isRedirect"] != null && Session["isRedirect"].ToString().Equals("YES"))
            btnSave.Text = Convert.ToString(GetLocalResourceObject("lblFakeResource1.Text"));
        if (Session["IsSkip"] != null && Session["IsSkip"].ToString().Equals("YES"))
            btnSkip.Visible = true;
        else
            btnSkip.Visible = false;
    }


    public void BindGrid()
    {
        try
        {
            string Culture = Convert.ToString(Session["Culture"]);
            DataSet ds = obj_Feedback.Get_FeedbackQuestions(Culture);
            if (ds.Tables[0].Rows.Count > 0)
            {
                id_GV_FeedBack.DataSource = ds.Tables[0];
                id_GV_FeedBack.DataBind();
            }

        }
        catch (Exception ex)
        {
            // throw ex;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            int Result = 0;
            try
            {
                flag = false;

                obj_Feedback.PostedId = Guid.NewGuid().ToString();
                for (int i = 0; i < id_GV_FeedBack.Rows.Count; i++)
                {

                    HiddenField hfqid = (HiddenField)id_GV_FeedBack.Rows[i].FindControl("hfQid");
                    obj_Feedback.QID = Convert.ToInt32(hfqid.Value);
                    RadioButtonList rbtCheck = (RadioButtonList)id_GV_FeedBack.Rows[i].FindControl("radio");
                    int count = 1;

                    foreach (ListItem li in rbtCheck.Items)
                    {

                        if (li.Selected == true)
                        {
                            obj_Feedback.Answer = Convert.ToInt32(li.Value);
                        }
                        count = count + 1;
                    }

                    obj_Feedback.UserID = ViewState["UserID"].ToString();
                    obj_Feedback.PostedBy = ViewState["UserName"].ToString();
                    obj_Feedback.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                    Result = obj_Feedback.Insert_FeedbackAnswers(obj_Feedback);


                }

                foreach (ListItem li in rbtlist.Items)
                {
                    if (li.Selected == true)
                    {
                        obj_Feedback.Recommend = li.Value;
                        flag = true;
                    }
                }

                obj_Feedback.UserID = ViewState["UserID"].ToString();
                obj_Feedback.EmailIds = txtEmailids.Text.ToString();
                // obj_Feedback.Comments = txtComments.Text.ToString();
                //  obj_Feedback.BugsComments = txtInformBugs.Text.ToString();

                obj_Feedback.UserID = ViewState["UserID"].ToString();
                DataSet dsexport = obj_Feedback.Get_FeedbackAnswers_ByUserId(obj_Feedback);
                if (dsexport.Tables[0].Rows.Count > 0)
                { 
                    //gv_excel.DataSource = dsexport.Tables[0];
                    //gv_excel.DataBind();
                    //if (flag == true)
                    //{
                    //    sendRecommendSitemail(obj_Feedback.EmailIds);
                    //}
                    //Public_FMFeedback.ExportToFile(Server.MapPath("~/Public/Feedback.xls"), this.gv_excel);
                    //sendmail("Feedback.xls");
                    // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Feedback saved successfully...')</script>");

                }
                //int output = obj_Feedback.Insert_FeedbackComments(obj_Feedback);
                //if (output > 0)
                //{

                //}



                // DeleteFile();

                if (Session["isRedirect"] != null && Session["isRedirect"].ToString().Equals("YES"))
                {
                    if (Session["RedirectURL"] != null)
                    {
                        if (Session["RedirectLogout"] != null & Session["RedirectLogout"].ToString().Equals("YES"))
                        {
                            if (Session["LoginDTO"] != null && Session["LoginDTO"] != "")
                            {
                                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                                objLoginDTO.UserID = objLoginDTO.UserID;
                                objLoginDTO.Flag = "Update";

                                if (Session["LogId"] != "" && Session["LogId"] != null)
                                {
                                    objLoginDTO.LogId = Convert.ToInt32(Session["LogId"]);
                                }

                                MaintainUserLogDetails(objLoginDTO);

                                Session.Abandon();
                                //Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
                            }
                            else
                            {
                                Session.Abandon();
                                //Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
                            }
                        }
                        Response.Redirect(Session["RedirectURL"].ToString(), false);
                    }
                    else
                        Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
                }
                else
                {
                    objUserMgmt.UserID = ViewState["UserID"].ToString();
                    objUserMgmt.AccessBy = Session["USER_ID"].ToString();
                    objUserMgmt.CategoryId = 4;
                    objUserMgmt.Downloading = "Y";
                    objUserMgmt.AccessDescription = "DownLoaded Report";
                    objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                    if (Convert.ToString(Session["Culture"]) == "zh-SG")
                        objUserMgmt.Culture = 2;
                    else
                        objUserMgmt.Culture = 1;
                    objUserMgmt.InsertModuleTrack(objUserMgmt);

                    generatePdf();
                }



            }

            catch (Exception ex)
            {
                HideTr.Visible = true;
                //throw ex;
            }
        }
    }

    private void MaintainUserLogDetails(LoginDTO objDTO)
    {
        try
        {
            ABSBLL.Registration objRegs = new ABSBLL.Registration();
            objRegs.InsertUserLogs(objDTO);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void DeleteFile()
    {
        String strPath = Server.MapPath("~/Public/Feedback.xls");
        System.IO.File.Delete(strPath);
    }

    public static void ExportToFile(string fileName, GridView gv)
    {
        using (StreamWriter streamWriter = new StreamWriter(fileName))
        {
            using (StringWriter sw = new StringWriter())
            {
                Export(sw, gv);
                streamWriter.Write(sw.ToString());
            }
        }
    }

    public static void Export(StringWriter sw, GridView gv)
    {
        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
        {
            //  Create a table to contain the grid
            Table table = new Table();

            //  include the gridline settings
            table.GridLines = gv.GridLines;

            //  add the header row to the table
            if (gv.HeaderRow != null)
            {
                Public_FMFeedback.PrepareControlForExport(gv.HeaderRow);
                table.Rows.Add(gv.HeaderRow);
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in gv.Rows)
            {
                Public_FMFeedback.PrepareControlForExport(row);
                table.Rows.Add(row);
            }

            //  add the footer row to the table
            if (gv.FooterRow != null)
            {
                Public_FMFeedback.PrepareControlForExport(gv.FooterRow);
                table.Rows.Add(gv.FooterRow);
            }

            //  render the table into the htmlwriter
            table.RenderControl(htw);
        }
    }
    private static void PrepareControlForExport(Control control)
    {
        // code unchanged
    }



    public void sendmail(string filename)
    {
        string str = Request.Url.ToString();
        Dictionary<string, string> tempValue = new Dictionary<string, string>();
        string strMapPath = ConfigurationManager.AppSettings["FMTFeedbackMailHtml"];
        string strToMail = ConfigurationManager.AppSettings["ToMail"];
        string strUserName = ViewState["UserName"].ToString();
        tempValue["<!--Name-->"] = strUserName;
        string path = Server.MapPath(strMapPath);
        HTMLParser htmlParser = new HTMLParser();
        string strBody = htmlParser.getBody("ACK", tempValue, path);
        MailManager objMailManager = new MailManager();
        objMailManager.sendFeedbackMail(strToMail, strBody, filename, strUserName);
        // End Code

    }

    public void sendRecommendSitemail(string EmailIds)
    {
        string str = Request.Url.ToString();
        Dictionary<string, string> tempValue = new Dictionary<string, string>();
        string strMapPath = ConfigurationManager.AppSettings["RecommendSiteMailHtml"];
        string strToMail = EmailIds;
        string strFromMail = ViewState["MailId"].ToString();
        string strUserName = ViewState["UserName"].ToString();
        tempValue["<!--Name-->"] = strUserName;
        string path = Server.MapPath(strMapPath);
        HTMLParser htmlParser = new HTMLParser();
        string strBody = htmlParser.getBody("ACK", tempValue, path);
        MailManager objMailManager = new MailManager();
        objMailManager.sendRecommendSiteMail(strToMail, strFromMail, strBody);
        // End Code

    }

    public void generatePdf()
    {
        //string StrFileName = string.Empty;
        try
        {
			
            string MyURL = string.Empty;
            string PDFConverterLicence = string.Empty;
            if (Convert.ToString(ViewState["UserID"]) != null && Convert.ToString(ViewState["UserID"]) != "")
            {
				//Response.Write("Hi");
                MyURL = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "FinancialModeling/Reports_All.aspx?UserId=" + Convert.ToString(ViewState["UserID"]) + "&Culture=" + Convert.ToString(Session["Culture"]);
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
				//MyURL="http://www.winnovative-software.com";
				//MyURL="https://smetoolkit.abs.org.sg/FinancialModeling/Reports.aspx";
				//MyURL="https://sips.abs.org.sg/";
				//Response.Write(MyURL);
				//Response.Write(PDFConverterLicence);
                byte[] downloadBytes = pdfConverter.GetPdfFromUrlBytes(MyURL);
				
                System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.AddHeader("Content-Type", "binary/octet-stream");
                response.AddHeader("Content-Disposition", "attachment; filename=" + "FintoolRpt.pdf" + "; size=" + downloadBytes.Length.ToString());
                response.BinaryWrite(downloadBytes);
                response.Flush();
                response.End();

                //string StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + "FintoolRpt.pdf";
                //System.IO.FileStream file = System.IO.File.Create(HttpContext.Current.Server.MapPath("~/Downloads/" + StrFileName));
                //file.Write(downloadBytes, 0, downloadBytes.Length);
                //file.Close();


            }


        }
        catch (Exception err)
        {

            //throw err;
        }
        finally
        {

            Dispose();
        }

    }

    protected override void OnPreRender(EventArgs e)
    {
        if (ViewState["UserID"] != null)
        {
            //Check Given User Feedback crossed 90 days or not
            obj_Feedback.UserID = ViewState["UserID"].ToString();
            DataSet dsexport = obj_Feedback.Get_FeedbackAnswers_ByUserId(obj_Feedback);
            if (dsexport.Tables[0].Rows.Count > 0)
            {
                if (dsexport.Tables[0].Rows[0]["Postedon"].ToString() != string.Empty)
                {
                    DateTime nowTime = DateTime.Now;
                    DateTime CompareTime = (DateTime)dsexport.Tables[0].Rows[0]["Postedon"];

                    TimeSpan span = nowTime.Subtract(CompareTime);


                    if (span.Days > 90)
                    {
                       // Crossed
                        HideTr.Visible = false;
                        BindGrid();


                    }
                    else
                    {
                       // Not Crossed
                        HideTr.Visible = true;
                        HideTable.Visible = false;
                        btnSave.Visible = false;
                        gv_excel.Visible = false;


                        objUserMgmt.UserID = ViewState["UserID"].ToString();
                        objUserMgmt.AccessBy = Session["USER_ID"].ToString();
                        objUserMgmt.CategoryId = 4;
                        objUserMgmt.Downloading = "Y";
                        objUserMgmt.AccessDescription = "DownLoaded Report";
                        objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                        if (Convert.ToString(Session["Culture"]) == "zh-SG")
                            objUserMgmt.Culture = 2;
                        else
                            objUserMgmt.Culture = 1;
                        objUserMgmt.InsertModuleTrack(objUserMgmt);


                        generatePdf();

                    }
              }

            }
            else
            {
                HideTr.Visible = false;
                BindGrid();
            }
        }
        else
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
    }

    protected void btnSkip_Click(object sender, EventArgs e)
    {
        if (Session["RedirectURL"] != null)
        {
            if (Session["RedirectLogout"] != null & Session["RedirectLogout"].ToString().Equals("YES"))
            {
                if (Session["LoginDTO"] != null && Convert.ToString(Session["LoginDTO"]) != "")
                {
                    LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                    objLoginDTO.UserID = objLoginDTO.UserID;
                    objLoginDTO.Flag = "Update";

                    if (Convert.ToString(Session["LogId"]) != "" && Session["LogId"] != null)
                    {
                        objLoginDTO.LogId = Convert.ToInt32(Session["LogId"]);
                    }

                    MaintainUserLogDetails(objLoginDTO);

                    Session.Abandon();
                    //Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
                }
                else
                {
                    Session.Abandon();
                    //Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
                }
            }
            Response.Redirect(Session["RedirectURL"].ToString(), false);
        }
        else
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
    }

    protected override void InitializeCulture()
    {
        string culture = string.Empty;
        //culture = Request.Form["ddlLang"];
        // if (string.IsNullOrEmpty(culture)) culture = "Auto";
        //   UICulture = "zh-SG";
        //  Page.Culture = "zh-SG";
        culture = Convert.ToString(Session["Culture"]);
        if (culture != "Auto")
        {
            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

        }

    }
}


