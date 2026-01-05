using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using ABSBLL;
using ABSDAL;
using ABSDTO;
using System.Configuration;

public partial class UserControls_ReportsHome : System.Web.UI.UserControl
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();

    Report_BLL bll = new Report_BLL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["UserId"] != null)
        {

            ViewState["UserID"] = Convert.ToString(Request.QueryString["UserId"]);
        }

        else if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
           
           
        }
        objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
        DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();

        lblCompanyName.Text = Convert.ToString(dtCompanyInfo.Rows[0]["CompanyName"]);
        lblFinancialYr.Text = Convert.ToDateTime(dtCompanyInfo.Rows[0]["FinYearEndDate"]).AddYears(2).ToString("dd/MM/yyyy");// DateTime.Now.AddYears(3).ToShortDateString();
        lblTodayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
      
          
       
    }
   
}