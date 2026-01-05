using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSDTO;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;


public partial class FinancialModeling_FinancialModelingHome : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
              
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                bindData();

            }

        }
    }
    private void bindData()
    {
        try
        {
            //section zero data
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
                lblCompanyName.Text = dtCompanyInfo.Rows[0]["CompanyName"].ToString();

                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataSet dsSectionZero = objFinModelingMgmt.getDataBySection(0);
                DataTable dtFsMapping_0 = dsSectionZero.Tables[0];
                DataTable dtInputValue_0 = dsSectionZero.Tables[1];

                imgStocks.Src = Convert.ToString(GetLocalResourceObject("lblImgURL1Resource1.Text"));
                imgtwo.Src = Convert.ToString(GetLocalResourceObject("lblImgURL2Resource1.Text"));
                imgthree.Src = Convert.ToString(GetLocalResourceObject("lblImgURL3Resource1.Text"));
                imgCapital.Src = Convert.ToString(GetLocalResourceObject("lblImgURL4Resource1.Text"));
                imgLoan.Src = Convert.ToString(GetLocalResourceObject("lblImgURL5Resource1.Text"));
                if (dtInputValue_0.Rows.Count > 0)
                {

                    string strStock = getInputValue(dtInputValue_0, 74);
                    if (strStock == "0")
                    {
                      //  imgStocks.Src = "../images/stocks_1.jpg";
                        imgStocks.Src = Convert.ToString(GetLocalResourceObject("lblImgURL6Resource1.Text"));
                    }

                    string strCapital = getInputValue(dtInputValue_0, 76);
                    if (strCapital == "0")
                    {
                     //   imgCapital.Src = "../images/Capital_1.jpg";
                        imgCapital.Src = Convert.ToString(GetLocalResourceObject("lblImgURL7Resource1.Text"));
                    }

                    string strLoan = getInputValue(dtInputValue_0, 77);
                    if (strLoan == "0")
                    {
                       // imgLoan.Src = "../images/Loan_1.jpg";
                        imgLoan.Src = Convert.ToString(GetLocalResourceObject("lblImgURL8Resource1.Text"));
                    }
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    private string getInputValue(DataTable dt, int MasterId)
    {
        try
        {
            DataRow[] dr = dt.Select("MasterInputId=" + MasterId);
            return dr[0]["Input_Value"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }      
   
   

    protected void imgBtnGenerateReport_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            objFinModelingMgmt.Update_FinTool_Totals();
        }
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
