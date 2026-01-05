using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

using ABSCommon;
using ABSBLL;
using System.Configuration;
using ABSDTO;
using System.Globalization;
using System.Threading;

public partial class Public_ClinicalSession : System.Web.UI.Page
{
    Registration objReg = new Registration();
    UserMgmt objUserMgmt = new UserMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        Bindata();
    }


    public void Bindata()
    {
        if (Session["LoginDTO"] != null)
        {
            DataSet dsData = new DataSet();

            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
            ViewState["IndustryId"] = objLoginDTO.IndustryID;
            objReg.UserID = Convert.ToString(ViewState["UserID"]);
            dsData = objReg.Get_RegDetails_ClinicalSession(objReg);

            if (dsData.Tables[0].Rows.Count > 0)
            {
                txtName.Text = (dsData.Tables[0].Rows[0][2].ToString() == "") ? "#" : dsData.Tables[0].Rows[0][2].ToString();
                txtCompany.Text = (dsData.Tables[0].Rows[0][3].ToString() == "") ? "#" : dsData.Tables[0].Rows[0][3].ToString();
                txtEmail.Text = (dsData.Tables[0].Rows[0][4].ToString() == "") ? "#" : dsData.Tables[0].Rows[0][4].ToString();
            }
            //Added by Mahesh to Insert ModuleTrack Records
            //Added on 06/06/2012
            objUserMgmt.UserID = ViewState["UserID"].ToString();
            objUserMgmt.AccessBy = Session["USER_ID"].ToString();
            objUserMgmt.CategoryId = 5;
            objUserMgmt.PageView = "Y";
            objUserMgmt.AccessDescription = "Access ClinicalSession page";
            objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                objUserMgmt.Culture = 2;
            else
                objUserMgmt.Culture = 1;
            objUserMgmt.InsertModuleTrack(objUserMgmt);
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                string strAlert = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text"));
                string strAlert1 = Convert.ToString(GetLocalResourceObject("lblDes2Resource1.Text"));
                string strAlert2 = Convert.ToString(GetLocalResourceObject("lblDes3Resource1.Text"));

                objReg.UserID = Guid.NewGuid().ToString();

                ccCorporateCaptcha.ValidateCaptcha(txtCaptcha.Text.Trim());
                if (!ccCorporateCaptcha.UserValidated)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strAlert + "');  </Script>");
                    txtCaptcha.Text = string.Empty;
                    return;
                }
                string strHtmlAlert = "HTML entry is not allowed. Please make sure that your entries do not contain any angle brackets like < or >.";
                if (txtName.Text.Trim().Contains("<") || txtName.Text.Trim().Contains(">"))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strHtmlAlert + "');  </Script>");
                    return;
                }
                if (txtDesignation.Text.Trim().Contains("<") || txtDesignation.Text.Trim().Contains(">"))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strHtmlAlert + "');  </Script>");
                    return;
                }
                if (txtCompany.Text.Trim().Contains("<") || txtCompany.Text.Trim().Contains(">"))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strHtmlAlert + "');  </Script>");
                    return;
                }
                if (txtTelephone.Text.Trim().Contains("<") || txtTelephone.Text.Trim().Contains(">"))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strHtmlAlert + "');  </Script>");
                    return;
                }
                if (txtPreferredDates.Text.Trim().Contains("<") || txtPreferredDates.Text.Trim().Contains(">"))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strHtmlAlert + "');  </Script>");
                    return;
                }
                if (txtTopics.Text.Trim().Contains("<") || txtTopics.Text.Trim().Contains(">"))
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strHtmlAlert + "');  </Script>");
                    return;
                }




                objReg.Title = ddlTitle.SelectedItem.Text.ToString();
                objReg.Name = txtName.Text.Trim();
                objReg.Designation = txtDesignation.Text;
                objReg.Company = txtCompany.Text.Trim();
                objReg.Telephone = txtTelephone.Text;
                objReg.Email = txtEmail.Text;
                objReg.PreferredDates = txtPreferredDates.Text;
                objReg.Topics = txtTopics.Text;
                int Status = objReg.Insert_ClinicalSession(objReg);

                if (Status == 1)
                {
                    Dictionary<string, string> tempValue = new Dictionary<string, string>();

                    string strMapPath = string.Empty;
                    if (Convert.ToString(Session["Culture"]) == "zh-SG")
                        strMapPath = ConfigurationManager.AppSettings["ClinicalSessionMailzhSG"];
                    else
                        strMapPath = ConfigurationManager.AppSettings["ClinicalSessionMail"];

                    string Title = ddlTitle.SelectedItem.Text.ToString();
                    string Name = txtName.Text.ToString();
                    string Designation = txtDesignation.Text.ToString();
                    string Company = txtCompany.Text.ToString();
                    string Telephone = txtTelephone.Text.ToString();
                    string Email = txtEmail.Text.ToString();

                    string PreferredDates = string.Empty;
                    PreferredDates = (txtPreferredDates.Text == "") ? "-" : txtPreferredDates.Text.ToString();
                    string Topics = string.Empty;
                    Topics = (txtTopics.Text == "") ? "-" : txtTopics.Text.ToString(); ;

                    tempValue["<!--Title-->"] = Title;
                    tempValue["<!--Name-->"] = Name;
                    tempValue["<!--Designation-->"] = Designation;
                    tempValue["<!--Company-->"] = Company;
                    tempValue["<!--Telephone-->"] = Telephone;
                    tempValue["<!--Email-->"] = Email;
                    tempValue["<!--PreferredDates-->"] = PreferredDates;
                    tempValue["<!--Topics-->"] = Topics;

                    string path = Server.MapPath(strMapPath);
                    HTMLParser htmlParser = new HTMLParser();
                    string strBody = htmlParser.getBody("ACK", tempValue, path);

                    // Code to send Notification Mail

                    string strSubject = Convert.ToString(GetLocalResourceObject("lblDes4Resource1.Text"));
                    MailManager objMailManager = new MailManager();
                    objMailManager.sendClinicalSession(Email, Name, strBody,strSubject);

                    string redirectPath = string.Empty;
                    if (Session["LoginDTO"] == null)
                    {
                        redirectPath = ConfigurationManager.AppSettings["InternalUrl"].ToString();
                    }
                    else
                    {
                        redirectPath = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Public/Dashboard.aspx";
                    }
                  
                    Common.ShowUpdateMessage(this, strAlert1, redirectPath);
                   
                }
                else
                    Common.ShowMessage(this, strAlert2);

               
            }
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ResetAll();
    }

    public void ResetAll()
    {
        txtName.Text = "";
        txtDesignation.Text = "";
        txtCompany.Text = "";
        txtTelephone.Text = "";
        txtEmail.Text = "";
        txtPreferredDates.Text = "";
        txtTopics.Text = "";
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
