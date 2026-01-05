using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ABSDAL;
using ABSDTO;
using System.Configuration;
using System.Web.UI.HtmlControls;
using ABSBLL;
using System.Globalization;
using System.Threading;

public partial class FinancialModeling_SfpStatement : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    UserMgmt objUserMgmt = new UserMgmt();
    public static string strTxtClientIds = "";
    int tabIndex = 0;
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
                bindCompanyInfo();
                bindData();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "formatCellsWithComma();", true);
            }

         
        }

    }
    private void bindData()
    {
        try
        {
            if (ViewState["UserID"] != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                objFinModelingMgmt.Culture = Convert.ToString(Session["Culture"]);
                DataSet dsStatements = objFinModelingMgmt.getStatementByType("SFP");
                dlSFP.DataSource = dsStatements.Tables[0];
                dlSFP.DataBind();
            }

            btnSaveNext.TabIndex = Convert.ToInt16(tabIndex);
            btnSaveNext.Attributes.Add("onFocus", "focus('" + btnSaveNext.ClientID + "')");
            tabIndex = tabIndex + 1;
            btnClear.TabIndex = Convert.ToInt16(tabIndex);
            btnClear.Attributes.Add("onFocus", "focus('" + btnClear.ClientID + "')");
            tabIndex = tabIndex + 1;
            btnBack.TabIndex = Convert.ToInt16(tabIndex);
            btnBack.Attributes.Add("onFocus", "focus('" + btnBack.ClientID + "')");

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    private void bindCompanyInfo()
    {

        try
        {
            if (Convert.ToString(ViewState["UserID"]) != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
                DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

                ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
                ViewState["Currency"] = drCompanyInfo["Currency"].ToString();
                lblHeaderCurrentYear.Text = ViewState["CurrentYear"].ToString();


                //Manually Handle  to bind label currency year for chinese language
                if (Convert.ToString(Session["Culture"]) == "zh-SG")
                {
                    if (Convert.ToString(ViewState["Currency"]) == "SGD" || Convert.ToString(ViewState["Currency"]) == "新元")
                    {
                        lblCurrency.Text = "新元";
                    }
                    else
                    {
                        lblCurrency.Text = "美元";
                    }
                }
                else
                {
                    if (Convert.ToString(ViewState["Currency"]) == "SGD" || Convert.ToString(ViewState["Currency"]) == "新元")
                    {
                        lblCurrency.Text = "SGD";
                    }
                    else
                    {
                        lblCurrency.Text = "USD";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void btnSaveNext_Click(object sender, EventArgs e)
    {
        string _redirectPath = string.Empty;
        int intOut = SaveData();

    


        if (intOut == 1)
        {
            string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/FinancialModelingHome.aspx";
            Response.Redirect(redirectPath);
           // _redirectPath = "FinancialModelingHome.aspx";
          //  ABSCommon.Common.ShowUpdateMessage(this, "Data Saved Successfully", _redirectPath);

          //  Response.Redirect("FinancialModelingHome.aspx");
        }
        else if (intOut == 2)
        {
            lblError.Visible = true;
            lblError.Text = "Both Balance sheet and CashFlow are not tally  ";
        }
        else if (intOut == 3)
        {
            lblError.Visible = true;
            lblError.Text = "Balance sheet not tally";
        }
        else if (intOut == 4)
        {
            lblError.Visible = true;
            lblError.Text = "Cash Flow not tally";
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Updation failed.";
        }
    }


    protected void dlSFP_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HiddenField hfIsFormula = (HiddenField)e.Item.FindControl("hfIsFormula");
            TextBox txtCurrentYear = (TextBox)e.Item.FindControl("txtCurrentYear");
            Label lblFsMappingName = (Label)e.Item.FindControl("lblFsMappingName");

            tabIndex = tabIndex + 1;
            if (strTxtClientIds == "")
            {
                strTxtClientIds = txtCurrentYear.ClientID;
            }
            else
            {
                strTxtClientIds = strTxtClientIds + "," + txtCurrentYear.ClientID;
            }
            if (hfIsFormula != null)
            {
                if (hfIsFormula.Value == "1")
                {
                    /*Highlighting formula*/

                    //txtCurrentYear.CssClass = "StmtTextBox_Formula";
                    //txtCurrentYear.Attributes.Add("readonly", "readonly");

                    //HtmlTableRow trSCI = (HtmlTableRow)e.Item.FindControl("trSCI");
                    //if (trSCI != null)
                    //{
                    //    trSCI.BgColor = "#EEEEEE";
                    //}
                    txtCurrentYear.CssClass = "StmtTextBox_Formula";
                    txtCurrentYear.Attributes.Add("readonly", "readonly");
                    lblFsMappingName.CssClass = "lblBold";
                }
                else
                {
                    txtCurrentYear.TabIndex = Convert.ToInt16(tabIndex);
                    txtCurrentYear.Attributes.Add("onblur", "changeCurentYear('" + txtCurrentYear.ClientID + "')");
                    txtCurrentYear.Attributes.Add("onFocus", "highlightBg('" + txtCurrentYear.ClientID + "')");

                }
            }
        }
    }

 
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("SfpStatement.aspx");
    }
    public int SaveData()
    {
        try
        {
            DataTable dtStmt = new DataTable();

            DataColumn dcStmtRecordId = new DataColumn("StmtRecordId");
            DataColumn dcCurrentYearValue = new DataColumn("C_Value");
            dtStmt.Columns.Add(dcStmtRecordId);
            dtStmt.Columns.Add(dcCurrentYearValue);


            foreach (DataListItem dlItems in dlSFP.Items)
            {
                HiddenField hfStmtRecordId = (HiddenField)dlItems.FindControl("hfStmtRecordId");
                TextBox txtCurrentYear = (TextBox)dlItems.FindControl("txtCurrentYear");
                DataRow dr = dtStmt.NewRow();
                if (hfStmtRecordId != null)
                {
                    dr["StmtRecordId"] = hfStmtRecordId.Value;
                    dr["C_Value"] = txtCurrentYear.Text.Trim();
                    dtStmt.Rows.Add(dr);


                }

            }
           
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
           
            int intOut = objFinModelingMgmt.UpdateStatements(dtStmt, "SFP");

            return intOut;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void imgBtnGenerateReport_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            SaveData();

        }

        if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            objFinModelingMgmt.Update_FinTool_Totals();
        }

    

        Response.Redirect("Reports.aspx");
    }
    protected void imgbtnStatements_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            SaveData();
        }
        Response.Redirect("SciStatement.aspx");
    }
    protected void imgbtnHome_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            SaveData();
        }
        Response.Redirect("FinancialModelingHome.aspx");
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        string strHidden = hfValue.Value;
        if (strHidden == "1")
        {
            SaveData();

        }
        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/SciStatement.aspx";
        Response.Redirect(redirectPath);
    }

    protected void imgBtnHelp_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            SaveData();
        }
        Response.Redirect("Help.aspx");
    }
    protected void imgbtnIncomeSheet_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            SaveData();
        }
        Response.Redirect("SciStatement.aspx");
    }
    protected void lnkBalanceSheet_Click(object sender, EventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            SaveData();
        }
        Response.Redirect("SciStatement.aspx");
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