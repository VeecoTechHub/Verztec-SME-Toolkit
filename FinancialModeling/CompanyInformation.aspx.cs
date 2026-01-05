using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ABSDAL;
using ABSDTO;
using ABSBLL;
using System.Configuration;
using ABSCommon;
using System.Globalization;
using System.Threading;

public partial class FinancialModeling_CompanyInformation : System.Web.UI.Page
{
    UserMgmt objUserMgmt = new UserMgmt();
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["LoginDTO"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
            }
            else
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];

                

                ViewState["UserID"] = objLoginDTO.UserID;
                ViewState["IndustryId"] = objLoginDTO.IndustryID;
                bindData();

            }
        }
        txtCompanyName.Focus();
        lblMsg.Text = string.Empty;

    }

    private void bindData()
    {
        try
        {
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataTable dt = objFinModelingMgmt.bindCompanyInformationByUserID();
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    txtCompanyName.Text = CommonBindings.TextToBind(dr["CompanyName"].ToString());
                  

                  //  ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText(dr["Currency"].ToString()));
                    txtFinEndDate.Text = CommonBindings.TextToBind(string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dr["FinYearEndDate"])));
                    ViewState["IsFinancialStmtAvailable"] = dr["IsFinancialStmtAvailable"].ToString();
                    rblFinStatement.Items.FindByValue(ViewState["IsFinancialStmtAvailable"].ToString()).Selected = true;
                    hfFsCheck.Value = ViewState["IsFinancialStmtAvailable"].ToString();
                    Session["CompanyId"] = dr["CompanyId"].ToString();
                    ViewState["CompanyId"] = dr["CompanyId"].ToString();
                    ViewState["UpdateFlag"] = 1;
                    TR2.Visible = false;


                    ViewState["CompanyName"] = dr["CompanyName"].ToString();
                    ViewState["Currency"] = dr["Currency"].ToString();
                    ViewState["FinYearEndDate"] = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dr["FinYearEndDate"]));
                    ViewState["IsFinancialStmtAvailable"] = dr["IsFinancialStmtAvailable"].ToString();


                    //Manually Handle  to bind ddd currency year for chinese language
                    if (Convert.ToString(Session["Culture"]) == "zh-SG")
                    {
                        if (Convert.ToString(ViewState["Currency"]) == "SGD" || Convert.ToString(ViewState["Currency"]) == "新元")
                        {
                            ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText("新元"));
                        }
                        else
                        {
                            ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText("美元"));
                        }
                    }
                    else
                    {
                        if (Convert.ToString(ViewState["Currency"]) == "SGD" || Convert.ToString(ViewState["Currency"]) == "新元")
                        {
                            ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText("SGD"));
                        }
                        else
                        {
                            ddlCurrency.SelectedIndex = ddlCurrency.Items.IndexOf(ddlCurrency.Items.FindByText("USD"));
                        }
                    }

                }
                else
                {
                    hfFsCheck.Value = "0";
                    ViewState["UpdateFlag"] = 0;
                    TR1.Visible = false;
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        string _redirectPath = string.Empty;
        if (Page.IsValid)
        {
            try
            {
                if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
                {
                    objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                    objFinModelingMgmt.CompanyName = txtCompanyName.Text.Trim();
                    objFinModelingMgmt.Currency = ddlCurrency.SelectedValue;
                    //Generate Date
                    string[] strSplitDate = txtFinEndDate.Text.Trim().Split('/');

                    //  if (strSplitDate[0].Length == 2 && strSplitDate[1].Length == 2 && strSplitDate[2].Length == 4 || strSplitDate[0].Length == 1 && strSplitDate[1].Length == 1)
                    //    {
                    if (Convert.ToInt32(strSplitDate[0]) > 0 && Convert.ToInt32(strSplitDate[0]) < 32)
                    {
                        if (Convert.ToInt32(strSplitDate[1]) > 0 && Convert.ToInt32(strSplitDate[1]) < 13)
                        {
                            if (Convert.ToInt32(strSplitDate[1]) != 02 || Convert.ToInt32(strSplitDate[1]) != 2)
                            {
                                if (Convert.ToInt32(strSplitDate[1]) == 4 || Convert.ToInt32(strSplitDate[1]) == 6 || Convert.ToInt32(strSplitDate[1]) == 9 || Convert.ToInt32(strSplitDate[1]) == 11 || Convert.ToInt32(strSplitDate[1]) == 04 || Convert.ToInt32(strSplitDate[1]) == 06 || Convert.ToInt32(strSplitDate[1]) == 09)
                                {
                                    if (Convert.ToInt32(strSplitDate[1]) != 31)
                                    {
                                        objFinModelingMgmt.FinYearEndDate = strSplitDate[2].ToString() + "-" + strSplitDate[1].ToString() + "-" + strSplitDate[0].ToString(); //Passing in yyyy-MM-dd
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Month " + strSplitDate[2] + " doesn't have 31 days!";
                                        return;
                                    }
                                }
                                else
                                {
                                    objFinModelingMgmt.FinYearEndDate = strSplitDate[2].ToString() + "-" + strSplitDate[1].ToString() + "-" + strSplitDate[0].ToString(); //Passing in yyyy-MM-dd
                                }
                            }
                            else
                            {
                                if (IsLeapYear(Convert.ToInt32(strSplitDate[2])))
                                {
                                    if (Convert.ToInt32(strSplitDate[0]) < 30)
                                    {
                                        objFinModelingMgmt.FinYearEndDate = strSplitDate[2].ToString() + "-" + strSplitDate[1].ToString() + "-" + strSplitDate[0].ToString(); //Passing in yyyy-MM-dd
                                    }
                                }
                                else
                                {
                                    if (Convert.ToInt32(strSplitDate[0]) < 29)
                                    {
                                        objFinModelingMgmt.FinYearEndDate = strSplitDate[2].ToString() + "-" + strSplitDate[1].ToString() + "-" + strSplitDate[0].ToString(); //Passing in yyyy-MM-dd
                                    }
                                    else
                                    {
                                        lblMsg.Text = "February " + strSplitDate[2] + " doesn't have " + strSplitDate[0] + " days!";
                                        return;
                                    }
                                }
                            }

                        }
                        else
                        {
                            lblMsg.Text = "Months should be in between 1 - 12";
                            return;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Days should be in between 1 - 31";
                        return;
                    }


                    objFinModelingMgmt.IsFinancialStmtAvailable = rblFinStatement.SelectedValue;
                    int intOut = 0;
                    if (Convert.ToInt32(ViewState["UpdateFlag"]) == 0)
                    {
                        intOut = objFinModelingMgmt.insertCompanyInformation();

                    }
                    else
                    {
                        if (ViewState["CompanyId"].ToString() != null && ViewState["CompanyId"] != "")
                        {
                            objFinModelingMgmt.CompanyId = ViewState["CompanyId"].ToString();

                            //If the statement selection is changed then delete all the previous records.
                            int intDelFlag = 0;
                            if (ViewState["IsFinancialStmtAvailable"].ToString() != rblFinStatement.SelectedValue)
                            {
                                intDelFlag = 1;
                            }
                            if (ViewState["CompanyName"].ToString() != txtCompanyName.Text.Trim().ToString() || ViewState["Currency"].ToString() != ddlCurrency.SelectedItem.Text.ToString() || ViewState["FinYearEndDate"].ToString() != txtFinEndDate.Text.Trim().ToString() || ViewState["IsFinancialStmtAvailable"].ToString() != rblFinStatement.SelectedValue.ToString())
                            {
                                intOut = objFinModelingMgmt.updateCompanyInformation(intDelFlag);

                            }
                        }
                        
                    }
                    if (intOut == 1)
                    {
                        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/MainSection.aspx";
                        Response.Redirect(redirectPath);

                    }
                    else if (intOut == 0)
                    {
                        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/MainSection.aspx";
                        Response.Redirect(redirectPath);

                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Insertion Failed.";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    private void validateForm()
    {
        try
        {
            if (ViewState["IsFinancialStmtAvailable"].ToString() != rblFinStatement.SelectedValue)
            { 
            
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Public/Dashboard.aspx");
    }

    protected void imgBtnGenerateReport_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Reports.aspx");
    }
    protected void imgbtnStatements_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SciStatement.aspx");
    }
    protected void imgbtnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FinancialModelingHome.aspx");
    }

     public bool IsLeapYear(int year) 
    { 
        if (year % 4 != 0) 
        { 
            return false; 
        } 
        if (year % 100 == 0) 
        { 
            return (year % 400 == 0); 
       } 
       return true; 
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