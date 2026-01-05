using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using ABSCommon;
using ABSDTO;
using ABSSecurity;
using System.Configuration;


public partial class Administration_PublicUsersList_Update : System.Web.UI.Page
{
    private Registration obj_Regs = new Registration();
    CommonFunctions commonfunction = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();

    Security objSecurity = new Security();
    public static string token;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    Check_Access chkAccess = new Check_Access();
        //    ViewState["Links"] = chkAccess.initSystem();
        //    ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];

   
    

        if (!IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            token = Request.Form["token"];
            ViewState["t_url"] = "PublicUsersList_Search.aspx";
            if (token == null)
            {
                Response.Redirect("default.aspx");
            }

            else
            {

                FillDropDowns();
                if (Request["IDforEdit"] != null)
                {
                    string str = commonfunction.Decrypt(Request["IDforEdit"]);
                    ViewState["UserID"] = str;
                    BindData();
                }
            }
        }
    }
    /// <summary>
    /// Method to bind the drop downs (Year, Nature of Business, Industry)
    /// </summary>
    private void FillDropDowns()
    {
        try
        {
            // Code to bind Business Started Year
            ddlYear.DataSource = GetYears();
            ddlYear.DataTextField = "strText";
            ddlYear.DataValueField = "strpassword";
            ddlYear.DataBind();
            ListItem li = new ListItem();
            li.Text = "Year";
            li.Value = "0";
            ddlYear.Items.Insert(0, li);

            //ddlYear.ClearSelection();
            //ddlYear.Items.FindByText(DateTime.Now.Year.ToString()).Selected = true;
            // End Code

            // Code to bind Business Started Month
            ABSBLL.Registration objRegs = new ABSBLL.Registration();
            ddlMonth.DataSource = objRegs.GetAllMonths();
            ddlMonth.DataTextField = "MonthNm";
            ddlMonth.DataValueField = "MonthID";
            ddlMonth.DataBind();
            // End Code

            string Culture = Convert.ToString(Session["Culture"]);
            // Code to bind Nature of Business and Industry
            DataSet dsItems = objRegs.GetItemsDetails(Culture);
            if (dsItems != null && dsItems.Tables.Count > 0)
            {
                //ddlNatureofBuss.DataSource = dsItems.Tables[0];
                //ddlNatureofBuss.DataTextField = "ItemText";
                //ddlNatureofBuss.DataValueField = "ID";
                //ddlNatureofBuss.DataBind();
                ddlIndustry.DataSource = dsItems.Tables[0];
                ddlIndustry.DataTextField = "IndustryNames";
                ddlIndustry.DataValueField = "ID";
                ddlIndustry.DataBind();
            }
            // End Code
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Method to generate the years.
    /// </summary>
    /// <returns></returns>
    private IList<BusinessYears> GetYears()
    {
        int year = DateTime.Now.Year;
        IList<BusinessYears> BYears = new List<BusinessYears>();
        for (int i = year; i > 1899; i--)
        {
            BusinessYears objYears = new BusinessYears(i.ToString(), i.ToString());
            BYears.Add(objYears);
        }
        return BYears;
    }



    public void BindData()
    {
        try
        {
            string UserID = ViewState["UserID"].ToString();
            DataSet ds_UserDtls = obj_Regs.GetUserDetailsbyUserID(UserID);
            if (ds_UserDtls != null)
            {
                if (ds_UserDtls.Tables[0].Rows.Count > 0)
                {
                    txtEmail.Text = ds_UserDtls.Tables[0].Rows[0]["EmailID"].ToString();
                    if (ds_UserDtls.Tables[0].Rows[0]["Title"].ToString() != "" && ds_UserDtls.Tables[0].Rows[0]["Title"].ToString() != null)
                    {
                        ddlTitle.Items.FindByValue(ds_UserDtls.Tables[0].Rows[0]["Title"].ToString()).Selected = true;
                    }
                    txtName.Text = ds_UserDtls.Tables[0].Rows[0]["Name"].ToString();
                    txtCompanyNm.Text = ds_UserDtls.Tables[0].Rows[0]["CompanyNm"].ToString();
                    if (ds_UserDtls.Tables[0].Rows[0]["IndustryID"].ToString() != "" && ds_UserDtls.Tables[0].Rows[0]["IndustryID"].ToString() != null)
                    {
                        ddlIndustry.Items.FindByValue(ds_UserDtls.Tables[0].Rows[0]["IndustryID"].ToString()).Selected = true;
                    }
                    if (ds_UserDtls.Tables[0].Rows[0]["BussStartedMonth"].ToString() != "" && ds_UserDtls.Tables[0].Rows[0]["BussStartedMonth"].ToString() != null)
                    {
                        ddlMonth.Items.FindByValue(ds_UserDtls.Tables[0].Rows[0]["BussStartedMonth"].ToString()).Selected = true;
                    }
                    if (ds_UserDtls.Tables[0].Rows[0]["BussStartedYear"].ToString() != "" && ds_UserDtls.Tables[0].Rows[0]["BussStartedYear"].ToString() != null)
                    {
                        ddlYear.Items.FindByValue(ds_UserDtls.Tables[0].Rows[0]["BussStartedYear"].ToString()).Selected = true;
                    }
                    txtNoofEmps.Text = ds_UserDtls.Tables[0].Rows[0]["NoofEmployees"].ToString();
                    txtTotalCapital.Text = ds_UserDtls.Tables[0].Rows[0]["TotalCapital"].ToString();
                    txtAnnualRev.Text = ds_UserDtls.Tables[0].Rows[0]["AnnualRevenue"].ToString();

                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void Button_Update_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    // Assign values to Registration DTO
                    RegistrationDTO objDTO = new RegistrationDTO();
                    objDTO.UserID = ViewState["UserID"].ToString();
                    objDTO.EmailID = txtEmail.Text.Trim();
                    objDTO.Password = objSecurity.Encrypt(txtPassword.Text.Trim());
                    objDTO.Title = ddlTitle.SelectedValue;
                    objDTO.Name = txtName.Text.Trim();
                    objDTO.CompanyNm = txtCompanyNm.Text.Trim();
                    objDTO.BussStartedMonth = int.Parse(ddlMonth.SelectedValue);
                    objDTO.BussStartedYear = int.Parse(ddlYear.SelectedValue);
                    objDTO.NoofEmployees = int.Parse(txtNoofEmps.Text.Trim());
                    objDTO.TotalCapital = Convert.ToDouble(txtTotalCapital.Text.Trim());
                    objDTO.AnnualRevenue = Convert.ToDouble(txtAnnualRev.Text.Trim());
                   // objDTO.BusinessID = Convert.ToInt32(ddlNatureofBuss.SelectedValue);
                    objDTO.IndustryID = Convert.ToInt32(ddlIndustry.SelectedValue);
                    ABSBLL.Registration objRegs = new ABSBLL.Registration();
                    int UserID = objRegs.UpdateUserDetails(objDTO);

                    if (UserID == 1)
                    {
                        //changes this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "javascript:alert('Registration details updated Successfully..',window.location('PublicUsersList_Search.aspx'))", true);
                        
                        string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");

                    }


                }
                else
                {
                    // Assign values to Registration DTO
                    RegistrationDTO objDTO = new RegistrationDTO();
                    objDTO.UserID = ViewState["UserID"].ToString();
                    objDTO.EmailID = txtEmail.Text.Trim();
                    //objDTO.Password = txtPassword.Text.Trim();
                    objDTO.Title = ddlTitle.SelectedValue;
                    objDTO.Name = txtName.Text.Trim();
                    objDTO.CompanyNm = txtCompanyNm.Text.Trim();
                    objDTO.BussStartedMonth = int.Parse(ddlMonth.SelectedValue);
                    objDTO.BussStartedYear = int.Parse(ddlYear.SelectedValue);
                    objDTO.NoofEmployees = int.Parse(txtNoofEmps.Text.Trim());
                    objDTO.TotalCapital = Convert.ToDouble(txtTotalCapital.Text.Trim());
                    objDTO.AnnualRevenue = Convert.ToDouble(txtAnnualRev.Text.Trim());
                  //  objDTO.BusinessID = Convert.ToInt32(ddlNatureofBuss.SelectedValue);
                    objDTO.IndustryID = Convert.ToInt32(ddlIndustry.SelectedValue);
                    ABSBLL.Registration objRegs = new ABSBLL.Registration();
                    int UserID = objRegs.UpdateUserDetailsWithoutPwd(objDTO);

                    if (UserID == 1)
                    {
                        //changes this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "javascript:alert('Registration details updated Successfully..',window.location('PublicUsersList_Search.aspx'))", true);
                        string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");

                    }
                }



                // Save Code              
                //else if (UserID == 0)
                //    Common.ShowMessage(this, "Email ID already exists");
                // End Save Code
            }
            else
            {
                //lblRError.Visible = true;
                //lblRError.Text = "Please enter valid captcha text";
                //Common.ShowMessage(this, "Please enter valid captcha text");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button_Back_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Administration/PublicUsersList_Search.aspx");
    }
    protected void Button_Resend_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
           // Button BtnResend = (Button)sender;
            ImageButton BtnResend = (ImageButton)sender;
            if (BtnResend != null)
            {
                string strUID = ViewState["UserID"].ToString();//BtnResend.CommandArgument.ToString();
                ABSBLL.Registration objRegs = new ABSBLL.Registration();
                DataSet dsUser = objRegs.GetUserDetails(strUID, "", "userid");
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        string str = Request.Url.ToString();
                        //int startindex = str.ToLower().IndexOf("ABS");
                        //string sub = str.Substring(0, startindex);
                        string sub = str.Replace("Administration/PublicUsersList_RegistrationUpdate.aspx", "RegsAccessActivation.aspx?UID=" + strUID);

                        Dictionary<string, string> tempValue = new Dictionary<string, string>();
                        string strMapPath = ConfigurationManager.AppSettings["AdminNotificationMailHtml"];
                        string strToMail = dsUser.Tables[0].Rows[0]["EmailID"].ToString();
                        string strGivenName = dsUser.Tables[0].Rows[0]["Name"].ToString();
                        tempValue["<!--GivenName-->"] = strGivenName;
                        tempValue["<!--URLPart-->"] = "<a href='" + sub + "'>" + sub + "</a> ";
                        tempValue["<!--ActCode-->"] = dsUser.Tables[0].Rows[0]["ActivationKey"].ToString();

                        string path = Server.MapPath(strMapPath);
                        HTMLParser htmlParser = new HTMLParser();
                        string strBody = htmlParser.getBody("ACK", tempValue, path);

                        // Code to send Notification Mail
                        string subject = "Welcome to ABS";
                        MailManager objMailManager = new MailManager();
                        objMailManager.sendNotificationMail(strToMail, strGivenName, strBody, subject);
                        // End Code

                        ABSCommon.Common.ShowMessage(this, "Mail sent successfully");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }
    }
}