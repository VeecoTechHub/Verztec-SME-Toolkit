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

public partial class UserControls_breakeven : System.Web.UI.UserControl
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    public static string strLblClientIds = string.Empty;
    Report_BLL bll = new Report_BLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
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
            strLblClientIds = string.Empty;
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
        }
        Binddata();
        bindCompanyInfo();
        BindClientIds();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "FormatCells", "formatCellsWithComma('" + strLblClientIds + "');", true);
        // }
    }

    public void Binddata()
    {
        DataSet dsData = new DataSet();
        if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            dsData = objFinModelingMgmt.Get_FinTool_Breakeven_Report(objFinModelingMgmt);

            DataTable dtData = new DataTable();
            dtData = dsData.Tables[0];
            lblCoverFixedExpensesP1.Text = dtData.Rows[0][3].ToString();
            lblCoverFixedExpensesP2.Text = dtData.Rows[0][4].ToString();
            lblCoverFixedExpensesP3.Text = dtData.Rows[0][5].ToString();

            lblCoverInterestsP1.Text = dtData.Rows[1][3].ToString();
            lblCoverInterestsP2.Text = dtData.Rows[1][4].ToString();
            lblCoverInterestsP3.Text = dtData.Rows[1][5].ToString();

            lblPrincipalPaymentsP1.Text = dtData.Rows[2][3].ToString();
            lblPrincipalPaymentsP2.Text = dtData.Rows[2][4].ToString();
            lblPrincipalPaymentsP3.Text = dtData.Rows[2][5].ToString();



            lblTotalSalesP1.Text = dtData.Rows[4][3].ToString();
            lblTotalSalesP2.Text = dtData.Rows[4][4].ToString();
            lblTotalSalesP3.Text = dtData.Rows[4][5].ToString();



            lblbreakevenP1.Text = calValues(dtData, "236,237,238", "P1_Value", "1,1,1").ToString();
            lblbreakevenP2.Text = calValues(dtData, "236,237,238", "P2_Value", "1,1,1").ToString();
            lblbreakevenP3.Text = calValues(dtData, "236,237,238", "P3_Value", "1,1,1").ToString();

            lblSaleSurplusP1.Text = calValues(dtData, "240,236,237,238", "P1_Value", "1,-1,-1,-1").ToString();
            lblSaleSurplusP2.Text = calValues(dtData, "240,236,237,238", "P2_Value", "1,-1,-1,-1").ToString();
            lblSaleSurplusP3.Text = calValues(dtData, "240,236,237,238", "P3_Value", "1,-1,-1,-1").ToString();
        }

        //lblbreakevenP1.Text = dtData.Rows[5][2].ToString();
        //lblbreakevenP2.Text = dtData.Rows[5][3].ToString();
        //lblbreakevenP3.Text = dtData.Rows[5][4].ToString();
    }

    private void bindCompanyInfo()
    {

        try
        {
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
                DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

                ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
                ViewState["ProjYear1"] = drCompanyInfo["P1_Year"].ToString();
                ViewState["ProjYear2"] = drCompanyInfo["P2_Year"].ToString();
                ViewState["ProjYear3"] = drCompanyInfo["P3_Year"].ToString();

                ViewState["Currency"] = drCompanyInfo["Currency"].ToString();

                lblYearP1.Text = drCompanyInfo["P1_Year"].ToString();
                lblYearP2.Text = drCompanyInfo["P2_Year"].ToString();
                lblYearP3.Text = drCompanyInfo["P3_Year"].ToString();
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void BindClientIds()
    {
        strLblClientIds = lblCoverFixedExpensesP1.ClientID + "," + lblCoverFixedExpensesP2.ClientID + "," + lblCoverFixedExpensesP3.ClientID + "," + lblCoverInterestsP1.ClientID + "," + lblCoverInterestsP2.ClientID + "," + lblCoverInterestsP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblPrincipalPaymentsP1.ClientID + "," + lblPrincipalPaymentsP2.ClientID + "," + lblPrincipalPaymentsP3.ClientID + "," + lblSaleSurplusP1.ClientID + "," + lblSaleSurplusP2.ClientID + "," + lblSaleSurplusP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotalSalesP1.ClientID + "," + lblTotalSalesP2.ClientID + "," + lblTotalSalesP3.ClientID + "," + lblbreakevenP1.ClientID + "," + lblbreakevenP2.ClientID + "," + lblbreakevenP3.ClientID;

    }

    private int calValues(DataTable dt, string FsMappingIds, string strFieldName, string signs)
    {
        try
        {
            int intOutPutValue = 0;
            string[] strSplitIds = FsMappingIds.Split(',');
            string[] strSplitSign = signs.Split(',');
            for (int i = 0; i < strSplitIds.Length; i++)
            {
                DataRow[] dr = dt.Select("FSMAPPINGID=" + strSplitIds[i].ToString());
                if (dr[0][strFieldName] != null && Convert.ToString(dr[0][strFieldName]) != "")
                {
                    intOutPutValue = intOutPutValue + (Convert.ToInt32(dr[0][strFieldName]) * Convert.ToInt32(strSplitSign[i]));
                }
            }
            return intOutPutValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}