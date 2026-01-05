using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using ABSDAL;
using ABSBLL;
using ABSDTO;
using System.Configuration;


public partial class UserControls_CashFlow : System.Web.UI.UserControl
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    Report_BLL bll = new Report_BLL();
    public static string strLblClientIds = string.Empty;

    public string lblFYLoclResText = string.Empty;
    public string lblPLoclResText = string.Empty;

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
        strLblClientIds = string.Empty;
        lblFYLoclResText = Convert.ToString(GetLocalResourceObject("lblfyResource1.Text"));
        lblPLoclResText = Convert.ToString(GetLocalResourceObject("lblpResource1.Text"));
        bindCompanyInfo();
        Binddata();
        BindClientIds();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "FormatCells", "formatCellsWithComma('" + strLblClientIds + "');", true);
     
       
    }

    public void Binddata()
    {
        DataSet dsData = new DataSet();
        if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            dsData = objFinModelingMgmt.Get_FinTool_CashFlowReport_Report(objFinModelingMgmt);

            DataTable dtData = new DataTable();
            dtData = dsData.Tables[0];
            ViewState["dtData1"] = dsData.Tables[0];

            lblOperatingActivitiesP1.Text = dtData.Rows[9][2].ToString();
            lblOperatingActivitiesP2.Text = dtData.Rows[9][3].ToString();
            lblOperatingActivitiesP3.Text = dtData.Rows[9][4].ToString();

            lblplannedP1.Text = dtData.Rows[0][2].ToString();
            lblplannedP2.Text = dtData.Rows[0][3].ToString();
            lblplannedP3.Text = dtData.Rows[0][4].ToString();

            lblOfWhichP1.Text = dtData.Rows[1][2].ToString();
            lblOfWhichP2.Text = dtData.Rows[1][3].ToString();
            lblOfWhichP3.Text = dtData.Rows[1][4].ToString();

            //lblBalanceP1.Text = dtData1.Rows[2][2].ToString();
            //lblBalanceP2.Text = dtData1.Rows[2][3].ToString();
            //lblBalanceP3.Text = dtData1.Rows[2][4].ToString();

            lblBalanceP1.Text = calValues((DataTable)ViewState["dtData1"], "245,246", "P1_Value", "1,1").ToString();
            lblBalanceP2.Text = calValues((DataTable)ViewState["dtData1"], "245,246", "P2_Value", "1,1").ToString();
            lblBalanceP3.Text = calValues((DataTable)ViewState["dtData1"], "245,246", "P3_Value", "1,1").ToString();

            lblExistingP1.Text = dtData.Rows[3][2].ToString();
            lblExistingP2.Text = dtData.Rows[3][3].ToString();
            lblExistingP3.Text = dtData.Rows[3][4].ToString();

            lblNewP1.Text = dtData.Rows[4][2].ToString();
            lblNewP2.Text = dtData.Rows[4][3].ToString();
            lblNewP3.Text = dtData.Rows[4][4].ToString();

            lblInterestsP1.Text = dtData.Rows[5][2].ToString();
            lblInterestsP2.Text = dtData.Rows[5][3].ToString();
            lblInterestsP3.Text = dtData.Rows[5][4].ToString();

            //lblTotalloanP1.Text = dtData1.Rows[6][2].ToString();
            //lblTotalloanP2.Text = dtData1.Rows[6][3].ToString();
            //lblTotalloanP3.Text = dtData1.Rows[6][4].ToString();
            lblTotalloanP1.Text = calValues((DataTable)ViewState["dtData1"], "248,249,250", "P1_Value", "1,1,1").ToString();
            lblTotalloanP2.Text = calValues((DataTable)ViewState["dtData1"], "248,249,250", "P2_Value", "1,1,1").ToString();
            lblTotalloanP3.Text = calValues((DataTable)ViewState["dtData1"], "248,249,250", "P3_Value", "1,1,1").ToString();

            lblRaiseNewP1.Text = dtData.Rows[7][2].ToString();
            lblRaiseNewP2.Text = dtData.Rows[7][3].ToString();
            lblRaiseNewP3.Text = dtData.Rows[7][4].ToString();

            //lblTotalcashP1.Text = dtData1.Rows[8][2].ToString();
            //lblTotalcashP2.Text = dtData1.Rows[8][3].ToString();
            //lblTotalcashP3.Text = dtData1.Rows[8][4].ToString();
            lblTotalcashP1.Text = calValues((DataTable)ViewState["dtData1"], "245,246,248,249,250,252", "P1_Value", "1,1,1,1,1,1").ToString();
            lblTotalcashP2.Text = calValues((DataTable)ViewState["dtData1"], "245,246,248,249,250,252", "P2_Value", "1,1,1,1,1,1").ToString();
            lblTotalcashP3.Text = calValues((DataTable)ViewState["dtData1"], "245,246,248,249,250,252", "P3_Value", "1,1,1,1,1,1").ToString();

            lblInvestingActivitiesP1.Text = lblTotalcashP1.Text;
            lblInvestingActivitiesP2.Text = lblTotalcashP2.Text;
            lblInvestingActivitiesP3.Text = lblTotalcashP3.Text;

            //lblNetCashP1.Text = dtData.Rows[3][2].ToString();
            //lblNetCashP2.Text = dtData.Rows[3][3].ToString();
            //lblNetCashP3.Text = dtData.Rows[3][4].ToString();
            lblNetCashP1.Text = calValues((DataTable)ViewState["dtData1"], "274,245,246,248,249,250,252", "P1_Value", "1,1,1,1,1,1,1").ToString();
            lblNetCashP2.Text = calValues((DataTable)ViewState["dtData1"], "274,245,246,248,249,250,252", "P2_Value", "1,1,1,1,1,1,1").ToString();
            lblNetCashP3.Text = calValues((DataTable)ViewState["dtData1"], "274,245,246,248,249,250,252", "P3_Value", "1,1,1,1,1,1,1").ToString();



            lblCashBalP1.Text = dtData.Rows[11][2].ToString();
            lblCashBalP2.Text = dtData.Rows[11][3].ToString();
            lblCashBalP3.Text = dtData.Rows[11][4].ToString();

            lblTotelNetCashP1.Text = dtData.Rows[12][2].ToString();
            lblTotelNetCashP2.Text = dtData.Rows[12][3].ToString();
            lblTotelNetCashP3.Text = dtData.Rows[12][4].ToString();

            //lblCashBal1P1.Text = dtData.Rows[14][2].ToString();
            //lblCashBal1P2.Text = dtData.Rows[14][3].ToString();
            //lblCashBal1P3.Text = dtData.Rows[14][4].ToString();
            lblCashBal1P1.Text = calValues((DataTable)ViewState["dtData1"], "276,277", "P1_Value", "1,1").ToString();
            lblCashBal1P2.Text = calValues((DataTable)ViewState["dtData1"], "276,277", "P2_Value", "1,1").ToString();
            lblCashBal1P3.Text = calValues((DataTable)ViewState["dtData1"], "276,277", "P3_Value", "1,1").ToString();

            lblCashBalanceP1.Text = lblCashBal1P1.Text;
            lblCashBalanceP2.Text = lblCashBal1P2.Text;
            lblCashBalanceP3.Text = lblCashBal1P3.Text;


            lblCashBalance1P1.Text = dtData.Rows[14][2].ToString();
            lblCashBalance1P2.Text = dtData.Rows[14][3].ToString();
            lblCashBalance1P3.Text = dtData.Rows[14][4].ToString();

            lblUnutilisedP1.Text = dtData.Rows[15][2].ToString();
            lblUnutilisedP2.Text = dtData.Rows[15][3].ToString();
            lblUnutilisedP3.Text = dtData.Rows[15][4].ToString();

            lblRestrictedP1.Text = dtData.Rows[16][2].ToString();
            lblRestrictedP2.Text = dtData.Rows[16][3].ToString();
            lblRestrictedP3.Text = dtData.Rows[16][4].ToString();

            //lblHeadroomP1.Text = dtData.Rows[17][2].ToString();
            //lblHeadroomP2.Text = dtData.Rows[17][3].ToString();
            //lblHeadroomP3.Text = dtData.Rows[17][4].ToString();
            lblHeadroomP1.Text = calValues((DataTable)ViewState["dtData1"], "279,280,281", "P1_Value", "1,1,1").ToString();
            lblHeadroomP2.Text = calValues((DataTable)ViewState["dtData1"], "279,280,281", "P2_Value", "1,1,1").ToString();
            lblHeadroomP3.Text = calValues((DataTable)ViewState["dtData1"], "279,280,281", "P3_Value", "1,1,1").ToString();


            lblHeadroomSurplusP1.Text = lblHeadroomP1.Text;
            lblHeadroomSurplusP2.Text = lblHeadroomP2.Text;
            lblHeadroomSurplusP3.Text = lblHeadroomP3.Text;
        }
    
      
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

                lblYearP1.Text = "<span align='right'>" + lblFYLoclResText + drCompanyInfo["P1_Year"].ToString() + "</span><br/><span align='center'>" + lblPLoclResText + "</span>";
                lblYearP2.Text = "<span align='right'>" + lblFYLoclResText + drCompanyInfo["P2_Year"].ToString() + "</span><br/><span align='center'>" + lblPLoclResText + "</span>";
                lblYearP3.Text = "<span align='right'>" + lblFYLoclResText + drCompanyInfo["P3_Year"].ToString() + "</span><br/><span align='center'>" + lblPLoclResText + "</span>";
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void BindClientIds()
    {
        strLblClientIds = lblOperatingActivitiesP1.ClientID + "," + lblOperatingActivitiesP2.ClientID + "," + lblOperatingActivitiesP3.ClientID + "," + lblInvestingActivitiesP1.ClientID + "," + lblInvestingActivitiesP2.ClientID + "," + lblInvestingActivitiesP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblplannedP1.ClientID + "," + lblplannedP2.ClientID + "," + lblplannedP3.ClientID + "," + lblOfWhichP1.ClientID + "," + lblOfWhichP2.ClientID + "," + lblOfWhichP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblBalanceP1.ClientID + "," + lblBalanceP2.ClientID + "," + lblBalanceP3.ClientID + "," + lblExistingP1.ClientID + "," + lblExistingP2.ClientID + "," + lblExistingP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblNewP1.ClientID + "," + lblNewP2.ClientID + "," + lblNewP3.ClientID + "," + lblInterestsP1.ClientID + "," + lblInterestsP2.ClientID + "," + lblInterestsP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotalloanP1.ClientID + "," + lblTotalloanP2.ClientID + "," + lblTotalloanP3.ClientID + "," + lblRaiseNewP1.ClientID + "," + lblRaiseNewP2.ClientID + "," + lblRaiseNewP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotalcashP1.ClientID + "," + lblTotalcashP2.ClientID + "," + lblTotalcashP3.ClientID + "," + lblNetCashP1.ClientID + "," + lblNetCashP2.ClientID + "," + lblNetCashP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblCashBalanceP1.ClientID + "," + lblCashBalanceP2.ClientID + "," + lblCashBalanceP3.ClientID + "," + lblCashBalP1.ClientID + "," + lblCashBalP2.ClientID + "," + lblCashBalP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblTotelNetCashP1.ClientID + "," + lblTotelNetCashP2.ClientID + "," + lblTotelNetCashP3.ClientID + "," + lblCashBal1P1.ClientID + "," + lblCashBal1P2.ClientID + "," + lblCashBal1P3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblHeadroomSurplusP1.ClientID + "," + lblHeadroomSurplusP2.ClientID + "," + lblHeadroomSurplusP3.ClientID + "," + lblCashBalance1P1.ClientID + "," + lblCashBalance1P2.ClientID + "," + lblCashBalance1P3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblUnutilisedP1.ClientID + "," + lblUnutilisedP2.ClientID + "," + lblUnutilisedP3.ClientID + "," + lblRestrictedP1.ClientID + "," + lblRestrictedP2.ClientID + "," + lblRestrictedP3.ClientID;
        strLblClientIds = strLblClientIds + "," + lblHeadroomP1.ClientID + "," + lblHeadroomP2.ClientID + "," + lblHeadroomP3.ClientID;

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