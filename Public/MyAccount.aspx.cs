using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSDTO;
using System.Data;
using ABSBLL;
using ABSCommon;
using System.Configuration;
using System.Globalization;
using System.Threading;

public partial class Public_MyAccount : BasePage
{
    UserMgmt objUserMgmt = new UserMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }

        try
        {
            if (!IsPostBack)
            {
                FillDropDowns();
                if (Session["LoginDTO"] != null)
                {
                    LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];


                    ////
                    //// ateeq 20sept when logout.....
                    Common objCommon = new Common();
                   

                    if (objCommon.CheckFeedback(objLoginDTO.UserID))
                    {
                        string strReferURL = Request.UrlReferrer.ToString();
                        string strReferPath = Request.Path.ToString();

                        string subpath = strReferURL.Substring(strReferURL.Length - 12);

                        if (subpath.ToLower().Equals("reports.aspx"))
                        {
                            Session["isRedirect"] = "YES";
                            Session["IsSkip"] = "NO";
                            Session["RedirectURL"] = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "/Public/MyAccount.aspx";
                            Session["RedirectLogout"] = "NO";
                            Response.Redirect("~/Public/FMFeedback.aspx", false);
                            return;
                        }

                    }


                    if (objLoginDTO.EmailID != null)
                    {
                        ViewState["CurrentUserIS"] = objLoginDTO.UserID;
                        txtEmail.Text = objLoginDTO.EmailID;
                        ViewState["CurrentUserPassword"] = objLoginDTO.Password;
                        BindData(objLoginDTO);
                    }
                }

             
            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }
    }

    /// <summary>
    /// Method to bind the data in controls.
    /// </summary>
    /// <param name="objLoginDTO"></param>
    private void BindData(LoginDTO objLoginDTO)
    {
        try
        {
            txtName.Text = CommonBindings.TextToBind(objLoginDTO.Name);
            txtCompanyNm.Text = CommonBindings.TextToBind(objLoginDTO.CompanyNm);
            txtNoofEmps.Text = CommonBindings.TextToBind(objLoginDTO.NoofEmployees.ToString());
          //  txtTotalCapital.Text = CommonBindings.TextToBind(objLoginDTO.TotalCapital.ToString());
          //  txtAnnualRev.Text = CommonBindings.TextToBind(objLoginDTO.AnnualRevenue.ToString());

            //ddlTitle.Items.FindByText(objLoginDTO.Title).Selected = true;
            //ddlNatureofBuss.ClearSelection();
            //ddlNatureofBuss.Items.FindByValue(objLoginDTO.BusinessID.ToString()).Selected = true;
            ddlIndustry.Items.FindByValue(objLoginDTO.IndustryID.ToString()).Selected = true;
           // ddlMonth.Items.FindByValue(objLoginDTO.BussStartedMonth.ToString()).Selected = true;

            ListItem liYear = new ListItem();
            liYear.Text = objLoginDTO.BussStartedYear.ToString();
            if (ddlYear.Items.Contains(liYear))
                ddlYear.Items.FindByText(objLoginDTO.BussStartedYear.ToString()).Selected = true;

         
         
        }
        catch (Exception ex)
        {
            throw ex;
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
            // End Code

            // Code to bind Business Started Month
            ABSBLL.Registration objRegs = new ABSBLL.Registration();
            //ddlMonth.DataSource = objRegs.GetAllMonths();
            //ddlMonth.DataTextField = "MonthNm";
            //ddlMonth.DataValueField = "MonthID";
            //ddlMonth.DataBind();
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

    /// <summary>
    /// Event to update the user details in [tbl_Registration]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                // Assign values to Registration DTO
                RegistrationDTO objDTO = new RegistrationDTO();
                objDTO.UserID = ViewState["CurrentUserIS"].ToString();
                objDTO.EmailID = txtEmail.Text.Trim();
                if (chbPwd.Checked == true)
                    objDTO.Password = txtPassword.Text.Trim();
                else
                {
                    if (ViewState["CurrentUserPassword"] != null)
                        objDTO.Password = ViewState["CurrentUserPassword"].ToString();
                }
                objDTO.Title = "";// ddlTitle.SelectedValue;
                objDTO.Name = txtName.Text;
                objDTO.CompanyNm = txtCompanyNm.Text.Trim();
               // objDTO.BussStartedMonth = int.Parse(ddlMonth.SelectedValue);
                objDTO.BussStartedYear = int.Parse(ddlYear.SelectedValue);
                objDTO.NoofEmployees = Int64.Parse(txtNoofEmps.Text.Trim());
               // objDTO.TotalCapital = Convert.ToDouble(txtTotalCapital.Text.Trim());
                //objDTO.AnnualRevenue = Convert.ToDouble(txtAnnualRev.Text.Trim());
               // objDTO.BusinessID = Convert.ToInt32(ddlNatureofBuss.SelectedValue);
                objDTO.IndustryID = Convert.ToInt32(ddlIndustry.SelectedValue);
                // End Assigning

                // Update Code
                ABSBLL.Registration objRegs = new ABSBLL.Registration();
                int objStatus = objRegs.UpdateUserDetails(objDTO);

                if (objStatus == 1)
                {
                    string strAlert = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text"));
                    Common.ShowMessage(this, strAlert, true);
                }
                else if (objStatus == 0)
                {
                    string strAlert1 = Convert.ToString(GetLocalResourceObject("lblDes2Resource1.Text"));
                    Common.ShowMessage(this, strAlert1, true);
                }
                // End Save Code

                // Code to preserve the Logged In Status of User.
                if (Session["LoginDTO"] != null)
                {
                    LoginDTO objLDTO = (LoginDTO)Session["LoginDTO"];
                    if (objLDTO.EmailID != null)
                    {
                        ViewState["LastLoginLoggedInAt"] = objLDTO.LoggedInAt.ToString();
                    }
                }
                // End Code

                // Code to Rebind the data

                LoginDTO objLoginDTO = new LoginDTO();
                objLoginDTO = objRegs.GetUserDetailsAfterUpdate(objDTO.EmailID, ViewState["LastLoginLoggedInAt"].ToString());
                if (objLoginDTO.EmailID != null)
                {
                    BindData(objLoginDTO);
                    Session["LoginDTO"] = objLoginDTO;
                }

                // End Code
            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }
    }

    /// <summary>
    /// Event to enable and disable change password
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chbPwd_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if(chbPwd.Checked==true)
            {
                trPwd.Visible = true;
            }
            else 
            {
                trPwd.Visible = false;
                txtPassword.Text = string.Empty;
                txtRePassword.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("DashBoard.aspx");
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