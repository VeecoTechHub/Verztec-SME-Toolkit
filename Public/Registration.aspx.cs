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
using ABSSecurity;
using System.Globalization;
using System.Threading;
using System.Configuration;

public partial class Public_Registration : System.Web.UI.Page
{
    Security objSecurity = new Security();
    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            if (!IsPostBack)
                FillDropDowns();

            string URL = ConfigurationManager.AppSettings["InternalUrl"] + "TermsConditions.aspx";
            if (Convert.ToString(Session["Culture"]) != "zh-SG")
                lblLink.Text = "Registration is required to access the online resources and tools in this website. All information provided will be kept confidential and will not be used to beyond the scope of this website. Please refer to the <a href=\"#\" class=\"more\" onclick=\"mypopup('"+URL+"')\">Terms of Use and Privacy Notice</a>  for further information.";
            else
                lblLink.Text = "浏览本网站的在线资源和工具需要先行注册。您提供的所有信息将得到保密，且不会被用于本网站以外的用途。<br />请参阅 <a href=\"#\" class=\"more\" onclick=\"mypopup('" + URL + "')\">《使用条款》与《隐私声明》</a>，以获取更多信息。";

        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }
    }

    /// <summary>
    /// Method to bind the drop downs (Year, Nature of Business, Industry)
    /// </summary>
    private void FillDropDowns()
    {

        try
        {
            string strText = Convert.ToString(GetLocalResourceObject("lblDes4Resource1.Text"));
            // Code to bind Business Started Year
            ddlYear.DataSource = GetYears();
            ddlYear.DataTextField = "strText";
            ddlYear.DataValueField = "strpassword";
            ddlYear.DataBind();
            ListItem li = new ListItem();
            li.Text = strText;
            li.Value = "0";
            ddlYear.Items.Insert(0, li);

            //ddlYear.ClearSelection();
            //ddlYear.Items.FindByText(DateTime.Now.Year.ToString()).Selected = true;
            // End Code

            //// Code to bind Business Started Month
            ABSBLL.Registration objRegs = new ABSBLL.Registration();
            //ddlMonth.DataSource = objRegs.GetAllMonths();
            //ddlMonth.DataTextField = "MonthNm";
            //ddlMonth.DataValueField = "MonthID";
            //ddlMonth.DataBind();
            //// End Code

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
    /// Event to save the user details in [tbl_Registration]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                // Assign values to Registration DTO
                RegistrationDTO objDTO = new RegistrationDTO();
                objDTO.UserID = Guid.NewGuid().ToString();

                ccCorporateCaptcha.ValidateCaptcha(txtCaptcha.Text.Trim());
                if (!ccCorporateCaptcha.UserValidated)
                {
                    string strAlert = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text"));
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strAlert + "');  </Script>");
                    txtCaptcha.Text = string.Empty;
                    return;
                }

                objDTO.EmailID = txtEmail.Text.Trim();
                objDTO.Password =
                objDTO.Password = objSecurity.Encrypt(txtPassword.Text.Trim());
                objDTO.Title = "";// ddlTitle.SelectedValue;
                objDTO.Name = txtName.Text.Trim();
                objDTO.CompanyNm = txtCompanyNm.Text.Trim();
                objDTO.BussStartedMonth = 0;// int.Parse(ddlMonth.SelectedValue);
                objDTO.BussStartedYear = int.Parse(ddlYear.SelectedValue);
                objDTO.NoofEmployees = int.Parse(txtNoofEmps.Text.Trim());
                objDTO.TotalCapital = 0.00;//Convert.ToDouble(txtTotalCapital.Text.Trim());
                objDTO.AnnualRevenue = 0.00;// Convert.ToDouble(txtAnnualRev.Text.Trim());
                objDTO.BusinessID = 0;// Convert.ToInt32(ddlNatureofBuss.SelectedValue);
                objDTO.IndustryID = Convert.ToInt32(ddlIndustry.SelectedValue);
                // Status will be pending at time of registration, and completed when link is clicked in notification mail.
                objDTO.Status = "Pending";
                objDTO.CreatedOn = DateTime.Now;
                objDTO.ActivationKey = Guid.NewGuid().ToString();
                // End Assigning

                // Save Code
                ABSBLL.Registration objRegs = new ABSBLL.Registration();
                int UserID = objRegs.InsertRegistration(objDTO);

                if (UserID == 1)
                {
                    Session["UserName"] = Convert.ToString(txtName.Text.Trim());
                    //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "javascript:alert('Volunteer Registered Successfully.',window.location('RegistrationAccess.aspx'))", true);
                    Response.Redirect("RegistrationAccess.aspx?UID=" + objDTO.UserID + "");
                }
                else if (UserID == 0)
                    //Common.ShowMessage(this, "Email ID already exists");
                    lblErrorMessage.Text = Convert.ToString(GetLocalResourceObject("lblDes2Resource1.Text"));
                // End Save Code
            }
            else
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = Convert.ToString(GetLocalResourceObject("lblDes3Resource1.Text"));
                // Common.ShowMessage(this, "Please enter valid captcha text");

            }
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCompanyNm.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtName.Text = string.Empty;
        txtNoofEmps.Text = string.Empty;
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