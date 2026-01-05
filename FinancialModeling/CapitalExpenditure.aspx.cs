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
using ABSCommon;
using System.Globalization;
using System.Threading;

public partial class FinancialModeling_CapitalExpenditure : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    UserMgmt objUserMgmt = new UserMgmt();

    public static string strTxtClientIds = "";
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
                bindCompanyInfo();
                bindData();
              //  ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState                 
                bindClientIds();
                bindJSFunction();

            }
            txtOtherAssetsP1.Focus();
        }
    }
    private void bindJSFunction()
    {
        if (ViewState["CapexHide"].ToString() == "yes")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "HideCapex('yes');", true);
        }
        else
        {
            if (ViewState["FinanceHide"].ToString() == "yes")
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "Combine('yes');", true);
            else
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FormatCells", "Combine('no');", true);
        }
    }

    private void bindClientIds()
    {

        strTxtClientIds = txtCapex1P1.ClientID + "," + txtCapex1P2.ClientID + "," + txtCapex1P3.ClientID + "," + txtCapex2P1.ClientID + "," + txtCapex2P2.ClientID + "," + txtCapex2P3.ClientID;
        strTxtClientIds = strTxtClientIds + "," + txtCapex3P1.ClientID + "," + txtCapex3P2.ClientID + "," + txtCapex3P3.ClientID;
        strTxtClientIds = strTxtClientIds + "," + txtOtherAssetsP1.ClientID + "," + txtOtherAssetsP2.ClientID + "," + txtOtherAssetsP3.ClientID;
        strTxtClientIds = strTxtClientIds + "," + txtOtherLiabilitiesP1.ClientID + "," + txtOtherLiabilitiesP2.ClientID + "," + txtOtherLiabilitiesP3.ClientID;

    }

    private void bindCompanyInfo()
    {

        try
        {
            if (ViewState["UserID"] != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
                DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

                ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
                ViewState["ProjYear1"] = drCompanyInfo["P1_Year"].ToString();
                ViewState["ProjYear2"] = drCompanyInfo["P2_Year"].ToString();
                ViewState["ProjYear3"] = drCompanyInfo["P3_Year"].ToString();

                ViewState["Currency"] = drCompanyInfo["Currency"].ToString();

                lblCapex1ProjYear1.Text = ViewState["ProjYear1"].ToString();
                lblCapex1ProjYear2.Text = ViewState["ProjYear2"].ToString();
                lblCapex1ProjYear3.Text = ViewState["ProjYear3"].ToString();

                lblCapex2ProjYear1.Text = ViewState["ProjYear1"].ToString();
                lblCapex2ProjYear2.Text = ViewState["ProjYear2"].ToString();
                lblCapex2ProjYear3.Text = ViewState["ProjYear3"].ToString();

                lblCapex3ProjYear1.Text = ViewState["ProjYear1"].ToString();
                lblCapex3ProjYear2.Text = ViewState["ProjYear2"].ToString();
                lblCapex3ProjYear3.Text = ViewState["ProjYear3"].ToString();

                lblProjYear1.Text = ViewState["ProjYear1"].ToString();
                lblProjYear2.Text = ViewState["ProjYear2"].ToString();
                lblProjYear3.Text = ViewState["ProjYear3"].ToString();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void bindData()
    {
        try
        {
            //section zero data
            DataSet dsSectionZero = objFinModelingMgmt.getDataBySection(0);
            DataTable dtFsMapping_0 = dsSectionZero.Tables[0];
            DataTable dtInputValue_0 = dsSectionZero.Tables[1];
            ViewState["CapexHide"] = "no";
            ViewState["FinanceHide"] = "no";
            if (dtInputValue_0.Rows.Count > 0)
            {
                ViewState["CapexStatus"] = getInputValue(dtInputValue_0, 78);               
                ViewState["FinanceStatus"] = getInputValue(dtInputValue_0, 79);                
                if (ViewState["CapexStatus"].ToString() == "0")
                {
                    ViewState["CapexHide"] = "yes";
                }
                if (ViewState["FinanceStatus"].ToString() == "0")
                {
                    ViewState["FinanceHide"] = "yes";
                }               

            }

            DataSet ds = objFinModelingMgmt.getDataBySection(5);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drCapex1= getFsMappingValue(dtFsMapping, 44);
                txtExpenditure1.Text = CommonBindings.TextToBind(drCapex1["FsMappingName"].ToString());
                txtCapex1P1.Text = CommonBindings.TextToBind(drCapex1["P1_Value"].ToString());
                txtCapex1P2.Text = CommonBindings.TextToBind(drCapex1["P2_Value"].ToString());
                txtCapex1P3.Text = CommonBindings.TextToBind(drCapex1["P3_Value"].ToString());

                DataRow drCapex1Quantum = getFsMappingValue(dtFsMapping, 45);
                txtCapex1QuantumP1.Text = CommonBindings.TextToBind(drCapex1Quantum["P1_Percent"].ToString());
                txtCapex1QuantumP2.Text = CommonBindings.TextToBind(drCapex1Quantum["P2_Percent"].ToString());
                txtCapex1QuantumP3.Text = CommonBindings.TextToBind(drCapex1Quantum["P3_Percent"].ToString());

                DataRow drCapex1Tenure = getFsMappingValue(dtFsMapping, 46);
                txtCapex1TenureP1.Text = CommonBindings.TextToBind(drCapex1Tenure["P1_Value"].ToString());
                txtCapex1TenureP2.Text = CommonBindings.TextToBind(drCapex1Tenure["P2_Value"].ToString());
                txtCapex1TenureP3.Text = CommonBindings.TextToBind(drCapex1Tenure["P3_Value"].ToString());

                DataRow drCapex1Months = getFsMappingValue(dtFsMapping, 47);
                txtCapex1MonthsP1.Text = CommonBindings.TextToBind(drCapex1Months["P1_Value"].ToString());
                txtCapex1MonthsP2.Text = CommonBindings.TextToBind(drCapex1Months["P2_Value"].ToString());
                txtCapex1MonthsP3.Text = CommonBindings.TextToBind(drCapex1Months["P3_Value"].ToString());


                DataRow drCapex2 = getFsMappingValue(dtFsMapping, 49);
                txtExpenditure2.Text = CommonBindings.TextToBind(drCapex2["FsMappingName"].ToString());
                txtCapex2P1.Text = CommonBindings.TextToBind(drCapex2["P1_Value"].ToString());
                txtCapex2P2.Text = CommonBindings.TextToBind(drCapex2["P2_Value"].ToString());
                txtCapex2P3.Text = CommonBindings.TextToBind(drCapex2["P3_Value"].ToString());

                DataRow drCapex2Quantum = getFsMappingValue(dtFsMapping, 50);
                txtCapex2QuantumP1.Text = CommonBindings.TextToBind(drCapex2Quantum["P1_Percent"].ToString());
                txtCapex2QuantumP2.Text = CommonBindings.TextToBind(drCapex2Quantum["P2_Percent"].ToString());
                txtCapex2QuantumP3.Text = CommonBindings.TextToBind(drCapex2Quantum["P3_Percent"].ToString());

                DataRow drCapex2Tenure = getFsMappingValue(dtFsMapping, 51);
                txtCapex2TenureP1.Text = CommonBindings.TextToBind(drCapex2Tenure["P1_Value"].ToString());
                txtCapex2TenureP2.Text = CommonBindings.TextToBind(drCapex2Tenure["P2_Value"].ToString());
                txtCapex2TenureP3.Text = CommonBindings.TextToBind(drCapex2Tenure["P3_Value"].ToString());

                DataRow drCapex2Months = getFsMappingValue(dtFsMapping, 52);
                txtCapex2MonthsP1.Text = CommonBindings.TextToBind(drCapex2Months["P1_Value"].ToString());
                txtCapex2MonthsP2.Text = CommonBindings.TextToBind(drCapex2Months["P2_Value"].ToString());
                txtCapex2MonthsP3.Text = CommonBindings.TextToBind(drCapex2Months["P3_Value"].ToString());



                DataRow drCapex3 = getFsMappingValue(dtFsMapping, 54);
                txtExpenditure3.Text = drCapex3["FsMappingName"].ToString();
                txtCapex3P1.Text = CommonBindings.TextToBind(drCapex3["P1_Value"].ToString());
                txtCapex3P2.Text = CommonBindings.TextToBind(drCapex3["P2_Value"].ToString());
                txtCapex3P3.Text = CommonBindings.TextToBind(drCapex3["P3_Value"].ToString());

                DataRow drCapex3Quantum = getFsMappingValue(dtFsMapping, 55);
                txtCapex3QuantumP1.Text = CommonBindings.TextToBind(drCapex3Quantum["P1_Percent"].ToString());
                txtCapex3QuantumP2.Text = CommonBindings.TextToBind(drCapex3Quantum["P2_Percent"].ToString());
                txtCapex3QuantumP3.Text = CommonBindings.TextToBind(drCapex3Quantum["P3_Percent"].ToString());

                DataRow drCapex3Tenure = getFsMappingValue(dtFsMapping, 56);
                txtCapex3TenureP1.Text = CommonBindings.TextToBind(drCapex3Tenure["P1_Value"].ToString());
                txtCapex3TenureP2.Text = CommonBindings.TextToBind(drCapex3Tenure["P2_Value"].ToString());
                txtCapex3TenureP3.Text = CommonBindings.TextToBind(drCapex3Tenure["P3_Value"].ToString());

                DataRow drCapex3Months = getFsMappingValue(dtFsMapping, 57);
                txtCapex3MonthsP1.Text = CommonBindings.TextToBind(drCapex3Months["P1_Value"].ToString());
                txtCapex3MonthsP2.Text = CommonBindings.TextToBind(drCapex3Months["P2_Value"].ToString());
                txtCapex3MonthsP3.Text = CommonBindings.TextToBind(drCapex3Months["P3_Value"].ToString());



                DataRow drOtherAssets = getFsMappingValue(dtFsMapping, 58);
              //  txtOtherAssets.Text = drOtherAssets["FsMappingName"].ToString();                
                txtOtherAssetsP1.Text = CommonBindings.TextToBind(drOtherAssets["P1_Value"].ToString());
                txtOtherAssetsP2.Text = CommonBindings.TextToBind(drOtherAssets["P2_Value"].ToString());
                txtOtherAssetsP3.Text = CommonBindings.TextToBind(drOtherAssets["P3_Value"].ToString());

                DataRow drOtherLiabilities = getFsMappingValue(dtFsMapping, 59);
               // txtOtherLiabilities.Text = drOtherLiabilities["FsMappingName"].ToString();              
                txtOtherLiabilitiesP1.Text = CommonBindings.TextToBind(drOtherLiabilities["P1_Value"].ToString());
                txtOtherLiabilitiesP2.Text = CommonBindings.TextToBind(drOtherLiabilities["P2_Value"].ToString());
                txtOtherLiabilitiesP3.Text = CommonBindings.TextToBind(drOtherLiabilities["P3_Value"].ToString());

                

            }
            if (dtInputValue.Rows.Count > 0)
            {
                txtCapex1Years.Text = getInputValue(dtInputValue, 83);
                txtCapex1InterestRate.Text = getInputValue(dtInputValue, 84);

                txtCapex2Years.Text = getInputValue(dtInputValue, 85);
                txtCapex2InterestRate.Text = getInputValue(dtInputValue, 86);

                txtCapex3Years.Text = getInputValue(dtInputValue, 87);
                txtCapex3InterestRate.Text = getInputValue(dtInputValue, 88);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private DataRow getFsMappingValue(DataTable dt, int FsMappingId)
    {
        try
        {
            DataRow[] dr = dt.Select("FsMappingId=" + FsMappingId);
            return dr[0];
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

    protected void btnSaveNext_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string redirectPath = string.Empty;
            try
            {
                DataTable dtFsMapping = generateFsMapping();
                DataTable dtInputValues = generateInputValues();
                if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
                {
                    objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                    int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                    if (i == 1)
                    {
                        objFinModelingMgmt.Update_FinTool_Assets(ViewState["UserID"].ToString());

                        redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Taxation.aspx";
                        Response.Redirect(redirectPath);

                    }
                    else
                    {
                        redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/CapitalExpenditure.aspx";
                        Response.Redirect(redirectPath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    private DataTable generateFsMapping()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FsMappingId");
            dt.Columns.Add("C_Value");
            dt.Columns.Add("P1_Value");
            dt.Columns.Add("P2_Value");
            dt.Columns.Add("P3_Value");
            dt.Columns.Add("C_Percent");
            dt.Columns.Add("P1_Percent");
            dt.Columns.Add("P2_Percent");
            dt.Columns.Add("P3_Percent");
            dt.Columns.Add("FsMappingName");


            DataRow dr1 = dt.NewRow();
            dr1["FsMappingId"] = "44";
            if (ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtExpenditure1.Text.Trim().Length > 0)
                    dr1["FsMappingName"] = txtExpenditure1.Text.Trim();
                else
                    dr1["FsMappingName"] = DBNull.Value;

                if (txtCapex1P1.Text.Trim().Length > 0)
                    dr1["P1_Value"] = txtCapex1P1.Text.Trim();
                else
                    dr1["P1_Value"] = DBNull.Value;

                if (txtCapex1P2.Text.Trim().Length > 0)
                    dr1["P2_Value"] = txtCapex1P2.Text.Trim();
                else
                    dr1["P2_Value"] = DBNull.Value;

                if (txtCapex1P3.Text.Trim().Length > 0)
                    dr1["P3_Value"] = txtCapex1P3.Text.Trim();
                else
                    dr1["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr1["FsMappingName"] = DBNull.Value;
                dr1["P1_Value"] = DBNull.Value;
                dr1["P2_Value"] = DBNull.Value; 
                dr1["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "45";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex1QuantumP1.Text.Trim().Length > 0)
                    dr2["P1_Percent"] = txtCapex1QuantumP1.Text.Trim();
                else
                    dr2["P1_Percent"] = DBNull.Value;

                if (txtCapex1QuantumP2.Text.Trim().Length > 0)
                    dr2["P2_Percent"] = txtCapex1QuantumP2.Text.Trim();
                else
                    dr2["P2_Percent"] = DBNull.Value;

                if (txtCapex1QuantumP3.Text.Trim().Length > 0)
                    dr2["P3_Percent"] = txtCapex1QuantumP3.Text.Trim();
                else
                    dr2["P3_Percent"] = DBNull.Value;
            }
            else
            {
                dr2["P1_Percent"] = DBNull.Value;
                dr2["P2_Percent"] = DBNull.Value;
                dr2["P3_Percent"] = DBNull.Value;
            } 
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["FsMappingId"] = "46";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex1TenureP1.Text.Trim().Length > 0)
                    dr3["P1_Value"] = txtCapex1TenureP1.Text.Trim();
                else
                    dr3["P1_Value"] = DBNull.Value;

                if (txtCapex1TenureP2.Text.Trim().Length > 0)
                    dr3["P2_Value"] = txtCapex1TenureP2.Text.Trim();
                else
                    dr3["P2_Value"] = DBNull.Value;

                if (txtCapex1TenureP3.Text.Trim().Length > 0)
                    dr3["P3_Value"] = txtCapex1TenureP3.Text.Trim();
                else
                    dr3["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr3["P1_Value"] = DBNull.Value;
                dr3["P2_Value"] = DBNull.Value;
                dr3["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["FsMappingId"] = "47";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex1MonthsP1.Text.Trim().Length > 0)
                    dr4["P1_Value"] = txtCapex1MonthsP1.Text.Trim();
                else
                    dr4["P1_Value"] = DBNull.Value;

                if (txtCapex1MonthsP2.Text.Trim().Length > 0)
                    dr4["P2_Value"] = txtCapex1MonthsP2.Text.Trim();
                else
                    dr4["P2_Value"] = DBNull.Value;

                if (txtCapex1MonthsP3.Text.Trim().Length > 0)
                    dr4["P3_Value"] = txtCapex1MonthsP3.Text.Trim();
                else
                    dr4["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr4["P1_Value"] = DBNull.Value;
                dr4["P2_Value"] = DBNull.Value;
                dr4["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr4);

            //capex2

            DataRow dr5 = dt.NewRow();
            dr5["FsMappingId"] = "49";
            if (ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtExpenditure2.Text.Trim().Length > 0)
                    dr5["FsMappingName"] = txtExpenditure2.Text.Trim();
                else
                    dr5["FsMappingName"] = DBNull.Value;

                if (txtCapex2P1.Text.Trim().Length > 0)
                    dr5["P1_Value"] = txtCapex2P1.Text.Trim();
                else
                    dr5["P1_Value"] = DBNull.Value;

                if (txtCapex2P2.Text.Trim().Length > 0)
                    dr5["P2_Value"] = txtCapex2P2.Text.Trim();
                else
                    dr5["P2_Value"] = DBNull.Value;

                if (txtCapex2P3.Text.Trim().Length > 0)
                    dr5["P3_Value"] = txtCapex2P3.Text.Trim();
                else
                    dr5["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr5["FsMappingName"] = DBNull.Value;
                dr5["P1_Value"] = DBNull.Value;
                dr5["P2_Value"] = DBNull.Value;
                dr5["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["FsMappingId"] = "50";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex2QuantumP1.Text.Trim().Length > 0)
                    dr6["P1_Percent"] = txtCapex2QuantumP1.Text.Trim();
                else
                    dr6["P1_Percent"] = DBNull.Value;

                if (txtCapex2QuantumP2.Text.Trim().Length > 0)
                    dr6["P2_Percent"] = txtCapex2QuantumP2.Text.Trim();
                else
                    dr6["P2_Percent"] = DBNull.Value;

                if (txtCapex2QuantumP3.Text.Trim().Length > 0)
                    dr6["P3_Percent"] = txtCapex2QuantumP3.Text.Trim();
                else
                    dr6["P3_Percent"] = DBNull.Value;
            }
            else
            {
                dr6["P1_Percent"] = DBNull.Value;
                dr6["P2_Percent"] = DBNull.Value;
                dr6["P3_Percent"] = DBNull.Value;
            }
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["FsMappingId"] = "51";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex2TenureP1.Text.Trim().Length > 0)
                    dr7["P1_Value"] = txtCapex2TenureP1.Text.Trim();
                else
                    dr7["P1_Value"] = DBNull.Value;

                if (txtCapex2TenureP2.Text.Trim().Length > 0)
                    dr7["P2_Value"] = txtCapex2TenureP2.Text.Trim();
                else
                    dr7["P2_Value"] = DBNull.Value;

                if (txtCapex2TenureP3.Text.Trim().Length > 0)
                    dr7["P3_Value"] = txtCapex2TenureP3.Text.Trim();
                else
                    dr7["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr7["P1_Value"] = DBNull.Value;
                dr7["P2_Value"] = DBNull.Value;
                dr7["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["FsMappingId"] = "52";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex2MonthsP1.Text.Trim().Length > 0)
                    dr8["P1_Value"] = txtCapex2MonthsP1.Text.Trim();
                else
                    dr8["P1_Value"] = DBNull.Value;

                if (txtCapex2MonthsP2.Text.Trim().Length > 0)
                    dr8["P2_Value"] = txtCapex2MonthsP2.Text.Trim();
                else
                    dr8["P2_Value"] = DBNull.Value;

                if (txtCapex2MonthsP3.Text.Trim().Length > 0)
                    dr8["P3_Value"] = txtCapex2MonthsP3.Text.Trim();
                else
                    dr8["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr8["P1_Value"] = DBNull.Value;
                dr8["P2_Value"] = DBNull.Value;
                dr8["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr8);


            //capex3

            DataRow dr9 = dt.NewRow();
            dr9["FsMappingId"] = "54";
            if (ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtExpenditure3.Text.Trim().Length > 0)
                    dr9["FsMappingName"] = txtExpenditure3.Text.Trim();
                else
                    dr9["FsMappingName"] = DBNull.Value;

                if (txtCapex3P1.Text.Trim().Length > 0)
                    dr9["P1_Value"] = txtCapex3P1.Text.Trim();
                else
                    dr9["P1_Value"] = DBNull.Value;

                if (txtCapex3P2.Text.Trim().Length > 0)
                    dr9["P2_Value"] = txtCapex3P2.Text.Trim();
                else
                    dr9["P2_Value"] = DBNull.Value;

                if (txtCapex3P3.Text.Trim().Length > 0)
                    dr9["P3_Value"] = txtCapex3P3.Text.Trim();
                else
                    dr9["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr9["FsMappingName"] = DBNull.Value;
                dr9["P1_Value"] = DBNull.Value;
                dr9["P2_Value"] = DBNull.Value;
                dr9["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr9);

            DataRow dr10 = dt.NewRow();
            dr10["FsMappingId"] = "55";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex3QuantumP1.Text.Trim().Length > 0)
                    dr10["P1_Percent"] = txtCapex3QuantumP1.Text.Trim();
                else
                    dr10["P1_Percent"] = DBNull.Value;

                if (txtCapex3QuantumP2.Text.Trim().Length > 0)
                    dr10["P2_Percent"] = txtCapex3QuantumP2.Text.Trim();
                else
                    dr10["P2_Percent"] = DBNull.Value;

                if (txtCapex3QuantumP3.Text.Trim().Length > 0)
                    dr10["P3_Percent"] = txtCapex3QuantumP3.Text.Trim();
                else
                    dr10["P3_Percent"] = DBNull.Value;
            }
            else
            {
                dr10["P1_Percent"] = DBNull.Value;
                dr10["P2_Percent"] = DBNull.Value;
                dr10["P3_Percent"] = DBNull.Value;
            }
            dt.Rows.Add(dr10);

            DataRow dr11 = dt.NewRow();
            dr11["FsMappingId"] = "56";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex3TenureP1.Text.Trim().Length > 0)
                    dr11["P1_Value"] = txtCapex3TenureP1.Text.Trim();
                else
                    dr11["P1_Value"] = DBNull.Value;

                if (txtCapex3TenureP2.Text.Trim().Length > 0)
                    dr11["P2_Value"] = txtCapex3TenureP2.Text.Trim();
                else
                    dr11["P2_Value"] = DBNull.Value;

                if (txtCapex3TenureP3.Text.Trim().Length > 0)
                    dr11["P3_Value"] = txtCapex3TenureP3.Text.Trim();
                else
                    dr11["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr11["P1_Value"] = DBNull.Value;
                dr11["P2_Value"] = DBNull.Value;
                dr11["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr11);

            DataRow dr12 = dt.NewRow();
            dr12["FsMappingId"] = "57";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex3MonthsP1.Text.Trim().Length > 0)
                    dr12["P1_Value"] = txtCapex3MonthsP1.Text.Trim();
                else
                    dr12["P1_Value"] = DBNull.Value;

                if (txtCapex3MonthsP2.Text.Trim().Length > 0)
                    dr12["P2_Value"] = txtCapex3MonthsP2.Text.Trim();
                else
                    dr12["P2_Value"] = DBNull.Value;

                if (txtCapex3MonthsP3.Text.Trim().Length > 0)
                    dr12["P3_Value"] = txtCapex3MonthsP3.Text.Trim();
                else
                    dr12["P3_Value"] = DBNull.Value;
            }
            else
            {
                dr12["P1_Value"] = DBNull.Value;
                dr12["P2_Value"] = DBNull.Value;
                dr12["P3_Value"] = DBNull.Value;
            }
            dt.Rows.Add(dr12);



            DataRow dr13 = dt.NewRow();

            dr13["FsMappingId"] = "58";

            //if (txtOtherAssets.Text.Trim().Length > 0)
            //    dr13["FsMappingName"] = txtOtherAssets.Text.Trim();
            //else
            //    dr13["FsMappingName"] = DBNull.Value;            

            if (txtOtherAssetsP1.Text.Trim().Length > 0)
                dr13["P1_Value"] = txtOtherAssetsP1.Text.Trim();
            else
                dr13["P1_Value"] = DBNull.Value;

            if (txtOtherAssetsP2.Text.Trim().Length > 0)
                dr13["P2_Value"] = txtOtherAssetsP2.Text.Trim();
            else
                dr13["P2_Value"] = DBNull.Value;

            if (txtOtherAssetsP3.Text.Trim().Length > 0)
                dr13["P3_Value"] = txtOtherAssetsP3.Text.Trim();
            else
                dr13["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr13);


            DataRow dr14 = dt.NewRow();
            dr14["FsMappingId"] = "59";
            //if (txtOtherLiabilities.Text.Trim().Length > 0)
            //    dr14["FsMappingName"] = txtOtherLiabilities.Text.Trim();
            //else
            //    dr14["FsMappingName"] = DBNull.Value;            

            if (txtOtherLiabilitiesP1.Text.Trim().Length > 0)
                dr14["P1_Value"] = txtOtherLiabilitiesP1.Text.Trim();
            else
                dr14["P1_Value"] = DBNull.Value;

            if (txtOtherLiabilitiesP2.Text.Trim().Length > 0)
                dr14["P2_Value"] = txtOtherLiabilitiesP2.Text.Trim();
            else
                dr14["P2_Value"] = DBNull.Value;

            if (txtOtherLiabilitiesP3.Text.Trim().Length > 0)
                dr14["P3_Value"] = txtOtherLiabilitiesP3.Text.Trim();
            else
                dr14["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr14);
            return dt;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable generateInputValues()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MasterInputId");
            dt.Columns.Add("Input_Value");


            DataRow dr1 = dt.NewRow();
            dr1["MasterInputId"] = "83";
            if (ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex1Years.Text.Trim().Length > 0)
                    dr1["Input_Value"] = txtCapex1Years.Text.Trim();
                else
                    dr1["Input_Value"] = DBNull.Value;
            }
            else
                dr1["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["MasterInputId"] = "84";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex1InterestRate.Text.Trim().Length > 0)
                    dr2["Input_Value"] = txtCapex1InterestRate.Text.Trim();
                else
                    dr2["Input_Value"] = DBNull.Value;
            }
            else
                dr2["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["MasterInputId"] = "85";
            if (ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex2Years.Text.Trim().Length > 0)
                    dr3["Input_Value"] = txtCapex2Years.Text.Trim();
                else
                    dr3["Input_Value"] = DBNull.Value;
            }
            else
                dr3["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "86";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
            if (txtCapex2InterestRate.Text.Trim().Length > 0)
                dr4["Input_Value"] = txtCapex2InterestRate.Text.Trim();
            else
                dr4["Input_Value"] = DBNull.Value;
            }
            else
                dr4["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["MasterInputId"] = "87";
            if (ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex3Years.Text.Trim().Length > 0)
                    dr5["Input_Value"] = txtCapex3Years.Text.Trim();
                else
                    dr5["Input_Value"] = DBNull.Value;
            }
            else
                dr5["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["MasterInputId"] = "88";
            if (ViewState["FinanceStatus"].ToString() == "1" || ViewState["CapexStatus"].ToString() == "1")
            {
                if (txtCapex3InterestRate.Text.Trim().Length > 0)
                    dr6["Input_Value"] = txtCapex3InterestRate.Text.Trim();
                else
                    dr6["Input_Value"] = DBNull.Value;
            }
            else
                dr6["Input_Value"] = DBNull.Value;

            dt.Rows.Add(dr6);   

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string strHidden = hfValue.Value;
        if (strHidden == "1")
        {
            string _redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {

                    objFinModelingMgmt.Update_FinTool_Assets(ViewState["UserID"].ToString());

                }
            }
        }
        string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/FundingMain.aspx";
        Response.Redirect(redirectPath);
      
    }
  
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            bindCompanyInfo();
            bindData();            
            bindClientIds();
            bindJSFunction();
            ScriptManager.RegisterClientScriptBlock(this, Page.GetType(), "FormatCells", "formatCellsWithComma();", true);

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void imgBtnGenerateReport_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;

        //If User want to save changes below code execute
        if (strHidden == "1")
        {
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {
                    objFinModelingMgmt.Update_FinTool_Assets(ViewState["UserID"].ToString());
                }
            }
        }

        //Do not save changes and generate reports
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
            string _redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {

                    objFinModelingMgmt.Update_FinTool_Assets(ViewState["UserID"].ToString());

                }
            }
        }
        Response.Redirect("SciStatement.aspx");
    }
    protected void imgbtnHome_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            string _redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {

                    objFinModelingMgmt.Update_FinTool_Assets(ViewState["UserID"].ToString());

                }
            }
        }
        Response.Redirect("FinancialModelingHome.aspx");
    }



    protected void imgBtnHelp_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue1.Value;
        if (strHidden == "1")
        {
            string _redirectPath = string.Empty;
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
                if (i == 1)
                {

                    objFinModelingMgmt.Update_FinTool_Assets(ViewState["UserID"].ToString());

                }
            }
        }
        Response.Redirect("Help.aspx");
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