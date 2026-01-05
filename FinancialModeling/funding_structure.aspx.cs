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

public partial class FinancialModeling_funding_structure : System.Web.UI.Page
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id"] != "" && Request.QueryString["Id"] != null)
                {
                    ViewState["Id"] = Request.QueryString["Id"].ToString();
                }

                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                ViewState["UserID"] = objLoginDTO.UserID;
                bindCompanyInfo();
                bindData();
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "highlightmenu", "HighlightMenu();", true);
            }
        }
    }

    private void bindCompanyInfo()
    {

        try
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
            DataRow drCompanyInfo = dtCompanyInfo.Rows[0];

            ViewState["CurrentYear"] = drCompanyInfo["LatestFinancialYear"].ToString();
            ViewState["ProjYear1"] = drCompanyInfo["P1_Year"].ToString();
            ViewState["ProjYear2"] = drCompanyInfo["P2_Year"].ToString();
            ViewState["ProjYear3"] = drCompanyInfo["P3_Year"].ToString();

            ViewState["Currency"] = drCompanyInfo["Currency"].ToString();
            lblEstimate.Text = ViewState["CurrentYear"].ToString();
            lblProjYear1.Text = ViewState["ProjYear1"].ToString();
            lblProjYear2.Text = ViewState["ProjYear2"].ToString();
            lblProjYear3.Text = ViewState["ProjYear3"].ToString();

            lblEstimate1.Text = ViewState["CurrentYear"].ToString();
            lblPro1.Text = ViewState["ProjYear1"].ToString();
            lblPro2.Text = ViewState["ProjYear2"].ToString();
            lblPro3.Text = ViewState["ProjYear3"].ToString();

            lblProjection1.Text = ViewState["ProjYear1"].ToString();
            lblProjection2.Text = ViewState["ProjYear2"].ToString();
            lblProjection3.Text = ViewState["ProjYear3"].ToString();

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
            DataSet ds = objFinModelingMgmt.getDataBySection(4);
            DataTable dtFsMapping = ds.Tables[0];
            DataTable dtInputValue = ds.Tables[1];
            if (dtFsMapping.Rows.Count > 0)
            {
                DataRow drTradingGoods = getFsMappingValue(dtFsMapping, 41);
                txtQuestion1P1.Text = drTradingGoods["P1_Value"].ToString();
                txtQuestion1P2.Text = drTradingGoods["P2_Value"].ToString();
                txtQuestion1P3.Text = drTradingGoods["P3_Value"].ToString();

                DataRow drManufacturingSale = getFsMappingValue(dtFsMapping, 42);
                txtQuestion3P1.Text = drManufacturingSale["P1_Value"].ToString();
                txtQuestion3P2.Text = drManufacturingSale["P2_Value"].ToString();
                txtQuestion3P3.Text = drManufacturingSale["P3_Value"].ToString();

                DataRow drServices = getFsMappingValue(dtFsMapping, 43);
                txtQuestion5Main1.Text = drServices["FsMappingName"].ToString();
                txtQuestion5P1.Text = drServices["P1_Value"].ToString();
                txtQuestion5P2.Text = drServices["P2_Value"].ToString();
                txtQuestion5P3.Text = drServices["P3_Value"].ToString();



                DataRow drMain1Years = getFsMappingValue(dtFsMapping, 44);
                txtQuestion5YearsP1.Text = drMain1Years["P1_Value"].ToString();
                txtQuestion5YearsP2.Text = drMain1Years["P2_Value"].ToString();
                txtQuestion5YearsP3.Text = drMain1Years["P3_Value"].ToString();

                DataRow drQuestion5Quantum = getFsMappingValue(dtFsMapping, 45);
                txtQuantumP1.Text = drQuestion5Quantum["P1_Value"].ToString();
                txtQuantumP2.Text = drQuestion5Quantum["P2_Value"].ToString();
                txtQuantumP3.Text = drQuestion5Quantum["P3_Value"].ToString();

                DataRow drQuestion5Tenure = getFsMappingValue(dtFsMapping, 46);
                txtTenureP1.Text = drQuestion5Tenure["P1_Value"].ToString();
                txtTenureP2.Text = drQuestion5Tenure["P2_Value"].ToString();
                txtTenureP3.Text = drQuestion5Tenure["P3_Value"].ToString();

                DataRow drQuestion5Months = getFsMappingValue(dtFsMapping, 47);
                txtMonthsP1.Text = drQuestion5Months["P1_Value"].ToString();
                txtMonthsP2.Text = drQuestion5Months["P2_Value"].ToString();
                txtMonthsP3.Text = drQuestion5Months["P3_Value"].ToString();

                DataRow drQuestion5Main1 = getFsMappingValue(dtFsMapping, 48);
                txtQuestion5Main2.Text = drQuestion5Main1["FsMappingName"].ToString();
                txtQuestion5Main2P1.Text = drQuestion5Main1["P1_Value"].ToString();
                txtQuestion5Main2P2.Text = drQuestion5Main1["P2_Value"].ToString();
                txtQuestion5Main2P3.Text = drQuestion5Main1["P3_Value"].ToString();



                DataRow drMain2Years = getFsMappingValue(dtFsMapping, 49);
                txtQuestion5Main2YearsP1.Text = drMain2Years["P1_Value"].ToString();
                txtQuestion5Main2YearsP2.Text = drMain2Years["P2_Value"].ToString();
                txtQuestion5Main2YearsP3.Text = drMain2Years["P3_Value"].ToString();

                DataRow drQuestion5Main2Quantum = getFsMappingValue(dtFsMapping, 50);
                txtQuestion5Main2QuantumP1.Text = drQuestion5Main2Quantum["P1_Value"].ToString();
                txtQuestion5Main2QuantumP2.Text = drQuestion5Main2Quantum["P2_Value"].ToString();
                txtQuestion5Main2QuantumP3.Text = drQuestion5Main2Quantum["P3_Value"].ToString();

                DataRow drTenureMain2 = getFsMappingValue(dtFsMapping, 51);
                txtTenureMain2P1.Text = drTenureMain2["P1_Value"].ToString();
                txtTenureMain2P2.Text = drTenureMain2["P2_Value"].ToString();
                txtTenureMain2P3.Text = drTenureMain2["P3_Value"].ToString();

                DataRow drMain2Months = getFsMappingValue(dtFsMapping, 52);
                txtMain2MonthsP1.Text = drMain2Months["P1_Value"].ToString();
                txtMain2MonthsP2.Text = drMain2Months["P2_Value"].ToString();
                txtMain2MonthsP3.Text = drMain2Months["P3_Value"].ToString();

                DataRow drQuestion5Main3 = getFsMappingValue(dtFsMapping, 53);
                txtQuestion5Main3.Text = drQuestion5Main3["FsMappingName"].ToString();
                txtQuestion5Main3P1.Text = drQuestion5Main3["P1_Value"].ToString();
                txtQuestion5Main3P2.Text = drQuestion5Main3["P2_Value"].ToString();
                txtQuestion5Main3P3.Text = drQuestion5Main3["P3_Value"].ToString();



                DataRow drMain3Years = getFsMappingValue(dtFsMapping, 54);
                txtQuestion5Main3YearsP1.Text = drMain3Years["P1_Value"].ToString();
                txtQuestion5Main3YearsP2.Text = drMain3Years["P2_Value"].ToString();
                txtQuestion5Main3YearsP3.Text = drMain3Years["P3_Value"].ToString();

                DataRow drQuestion5Main3Quantum = getFsMappingValue(dtFsMapping, 55);
                txtQuestion5Main3QuantumP1.Text = drQuestion5Main3Quantum["P1_Value"].ToString();
                txtQuestion5Main3QuantumP2.Text = drQuestion5Main3Quantum["P2_Value"].ToString();
                txtQuestion5Main3QuantumP3.Text = drQuestion5Main3Quantum["P3_Value"].ToString();

                DataRow drQuestion5TenureMain3 = getFsMappingValue(dtFsMapping, 56);
                txtTenureMain3P1.Text = drQuestion5TenureMain3["P1_Value"].ToString();
                txtTenureMain3P2.Text = drQuestion5TenureMain3["P2_Value"].ToString();
                txtTenureMain3P3.Text = drQuestion5TenureMain3["P3_Value"].ToString();

                DataRow drQuestion5Main3Months = getFsMappingValue(dtFsMapping, 57);
                txtMain3MonthsP1.Text = drQuestion5Main3Months["P1_Value"].ToString();
                txtMain3MonthsP2.Text = drQuestion5Main3Months["P2_Value"].ToString();
                txtMain3MonthsP3.Text = drQuestion5Main3Months["P3_Value"].ToString();


            }
            if (dtInputValue.Rows.Count > 0)
            {
                txtQuestion2.Text = getInputValue(dtInputValue, 50);
                txtQuestion3.Text = getInputValue(dtInputValue, 53);
                txtQuestion4P1.Text = getInputValue(dtInputValue, 52);
                txtQuestion4P2.Text = getInputValue(dtInputValue, 68);
                txtQuestion4EstimatePercent.Text = getInputValue(dtInputValue, 54);

                txtQuestion4EstimateValue.Text = getInputValue(dtInputValue, 55);
                txtInterestRate.Text = getInputValue(dtInputValue, 70);
                txtMain2InterestRate2.Text = getInputValue(dtInputValue, 59);
                txtMain3InterestRate3.Text = getInputValue(dtInputValue, 61);

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
        try
        {
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
            if (i == 1)
            {
                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/Other_Assets.aspx?Id=" + ViewState["Id"] + "";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Data Saved Successfully.'); location='" + _redirectPath + "';</Script>");
            }
        }
        catch (Exception ex)
        {
            throw ex;
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

            dr1["FsMappingId"] = "41";
            if (txtQuestion1P1.Text.Trim().Length > 0)
                dr1["P1_Value"] = txtQuestion1P1.Text.Trim();
            else
                dr1["P1_Value"] = DBNull.Value;

            if (txtQuestion1P2.Text.Trim().Length > 0)
                dr1["P2_Value"] = txtQuestion1P2.Text.Trim();
            else
                dr1["P2_Value"] = DBNull.Value;

            if (txtQuestion1P3.Text.Trim().Length > 0)
                dr1["P3_Value"] = txtQuestion1P3.Text.Trim();
            else
                dr1["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["FsMappingId"] = "42";

            if (txtQuestion3P1.Text.Trim().Length > 0)
                dr2["P1_Value"] = txtQuestion3P1.Text.Trim();
            else
                dr2["P1_Value"] = DBNull.Value;

            if (txtQuestion3P2.Text.Trim().Length > 0)
                dr2["P2_Value"] = txtQuestion3P2.Text.Trim();
            else
                dr2["P2_Value"] = DBNull.Value;

            if (txtQuestion3P3.Text.Trim().Length > 0)
                dr2["P3_Value"] = txtQuestion3P3.Text.Trim();
            else
                dr2["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            if (txtQuestion5Main1.Text.Trim().Length > 0)
                dr3["FsMappingName"] = txtQuestion5Main1.Text.Trim();
            else
                dr3["FsMappingName"] = DBNull.Value;

            dr3["FsMappingId"] = "43";
            if (txtQuestion5P1.Text.Trim().Length > 0)
                dr3["P1_Value"] = txtQuestion5P1.Text.Trim();
            else
                dr3["P1_Value"] = DBNull.Value;

            if (txtQuestion5P2.Text.Trim().Length > 0)
                dr3["P2_Value"] = txtQuestion5P2.Text.Trim();
            else
                dr3["P2_Value"] = DBNull.Value;

            if (txtQuestion5P3.Text.Trim().Length > 0)
                dr3["P3_Value"] = txtQuestion5P3.Text.Trim();
            else
                dr3["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["FsMappingId"] = "44";

            if (txtQuestion5YearsP1.Text.Trim().Length > 0)
                dr4["P1_Value"] = txtQuestion5YearsP1.Text.Trim();
            else
                dr4["P1_Value"] = DBNull.Value;

            if (txtQuestion5YearsP2.Text.Trim().Length > 0)
                dr4["P2_Value"] = txtQuestion5YearsP2.Text.Trim();
            else
                dr4["P2_Value"] = DBNull.Value;

            if (txtQuestion5YearsP3.Text.Trim().Length > 0)
                dr4["P3_Value"] = txtQuestion5YearsP3.Text.Trim();
            else
                dr4["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["FsMappingId"] = "45";
            if (txtQuantumP1.Text.Trim().Length > 0)
                dr5["P1_Value"] = txtQuantumP1.Text.Trim();
            else
                dr5["P1_Value"] = DBNull.Value;

            if (txtQuantumP2.Text.Trim().Length > 0)
                dr5["P2_Value"] = txtQuantumP2.Text.Trim();
            else
                dr5["P2_Value"] = DBNull.Value;

            if (txtQuantumP3.Text.Trim().Length > 0)
                dr5["P3_Value"] = txtQuantumP3.Text.Trim();
            else
                dr5["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["FsMappingId"] = "46";
            if (txtTenureP1.Text.Trim().Length > 0)
                dr6["P1_Value"] = txtTenureP1.Text.Trim();
            else
                dr6["P1_Value"] = DBNull.Value;

            if (txtTenureP2.Text.Trim().Length > 0)
                dr6["P2_Value"] = txtTenureP2.Text.Trim();
            else
                dr6["P2_Value"] = DBNull.Value;

            if (txtTenureP3.Text.Trim().Length > 0)
                dr6["P3_Value"] = txtTenureP3.Text.Trim();
            else
                dr6["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["FsMappingId"] = "47";

            if (txtMonthsP1.Text.Trim().Length > 0)
                dr7["P1_Value"] = txtMonthsP1.Text.Trim();
            else
                dr7["P1_Value"] = DBNull.Value;

            if (txtMonthsP2.Text.Trim().Length > 0)
                dr7["P2_Value"] = txtMonthsP2.Text.Trim();
            else
                dr7["P2_Value"] = DBNull.Value;

            if (txtMonthsP3.Text.Trim().Length > 0)
                dr7["P3_Value"] = txtMonthsP3.Text.Trim();
            else
                dr7["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["FsMappingId"] = "48";
            if (txtQuestion5Main2.Text.Trim().Length > 0)
                dr8["FsMappingName"] = txtQuestion5Main2.Text.Trim();
            else
                dr8["FsMappingName"] = DBNull.Value;

            if (txtQuestion5Main2P1.Text.Trim().Length > 0)
                dr8["P1_Value"] = txtQuestion5Main2P1.Text.Trim();
            else
                dr8["P1_Value"] = DBNull.Value;

            if (txtQuestion5Main2P2.Text.Trim().Length > 0)
                dr8["P2_Value"] = txtQuestion5Main2P2.Text.Trim();
            else
                dr8["P2_Value"] = DBNull.Value;

            if (txtQuestion5Main2P3.Text.Trim().Length > 0)
                dr8["P3_Value"] = txtQuestion5Main2P3.Text.Trim();
            else
                dr8["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr8);

            DataRow dr9 = dt.NewRow();
            dr9["FsMappingId"] = "49";
            if (txtQuestion5Main2YearsP1.Text.Trim().Length > 0)
                dr9["P1_Value"] = txtQuestion5Main2YearsP1.Text.Trim();
            else
                dr9["P1_Value"] = DBNull.Value;

            if (txtQuestion5Main2YearsP2.Text.Trim().Length > 0)
                dr9["P2_Value"] = txtQuestion5Main2YearsP2.Text.Trim();
            else
                dr9["P2_Value"] = DBNull.Value;

            if (txtQuestion5Main2YearsP3.Text.Trim().Length > 0)
                dr9["P3_Value"] = txtQuestion5Main2YearsP3.Text.Trim();
            else
                dr9["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr9);

            DataRow dr10 = dt.NewRow();
            dr10["FsMappingId"] = "50";

            if (txtQuestion5Main2QuantumP1.Text.Trim().Length > 0)
                dr10["P1_Value"] = txtQuestion5Main2QuantumP1.Text.Trim();
            else
                dr10["P1_Value"] = DBNull.Value;

            if (txtQuestion5Main2QuantumP2.Text.Trim().Length > 0)
                dr10["P2_Value"] = txtQuestion5Main2QuantumP2.Text.Trim();
            else
                dr10["P2_Value"] = DBNull.Value;

            if (txtQuestion5Main2QuantumP3.Text.Trim().Length > 0)
                dr10["P3_Value"] = txtQuestion5Main2QuantumP3.Text.Trim();
            else
                dr10["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr10);

            DataRow dr11 = dt.NewRow();
            dr11["FsMappingId"] = "51";
            if (txtTenureMain2P1.Text.Trim().Length > 0)
                dr11["P1_Value"] = txtTenureMain2P1.Text.Trim();
            else
                dr11["P1_Value"] = DBNull.Value;

            if (txtTenureMain2P2.Text.Trim().Length > 0)
                dr11["P2_Value"] = txtTenureMain2P2.Text.Trim();
            else
                dr11["P2_Value"] = DBNull.Value;

            if (txtTenureMain2P3.Text.Trim().Length > 0)
                dr11["P3_Value"] = txtTenureMain2P3.Text.Trim();
            else
                dr11["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr11);

            DataRow dr12 = dt.NewRow();
            dr12["FsMappingId"] = "52";

            if (txtMain2MonthsP1.Text.Trim().Length > 0)
                dr12["P1_Value"] = txtMain2MonthsP1.Text.Trim();
            else
                dr12["P1_Value"] = DBNull.Value;

            if (txtMain2MonthsP2.Text.Trim().Length > 0)
                dr12["P2_Value"] = txtMain2MonthsP2.Text.Trim();
            else
                dr12["P2_Value"] = DBNull.Value;

            if (txtMain2MonthsP3.Text.Trim().Length > 0)
                dr12["P3_Value"] = txtMain2MonthsP3.Text.Trim();
            else
                dr12["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr12);

            DataRow dr13 = dt.NewRow();
            dr13["FsMappingId"] = "53";
            if (txtQuestion5Main3.Text.Trim().Length > 0)
                dr13["FsMappingName"] = txtQuestion5Main3.Text.Trim();
            else
                dr13["FsMappingName"] = DBNull.Value;

            if (txtQuestion5Main3P1.Text.Trim().Length > 0)
                dr13["P1_Value"] = txtQuestion5Main3P1.Text.Trim();
            else
                dr13["P1_Value"] = DBNull.Value;

            if (txtQuestion5Main3P2.Text.Trim().Length > 0)
                dr13["P2_Value"] = txtQuestion5Main3P2.Text.Trim();
            else
                dr13["P2_Value"] = DBNull.Value;

            if (txtQuestion5Main3P3.Text.Trim().Length > 0)
                dr13["P3_Value"] = txtQuestion5Main3P3.Text.Trim();
            else
                dr13["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr13);

            DataRow dr14 = dt.NewRow();
            dr14["FsMappingId"] = "54";
            if (txtQuestion5Main3YearsP1.Text.Trim().Length > 0)
                dr14["P1_Value"] = txtQuestion5Main3YearsP1.Text.Trim();
            else
                dr14["P1_Value"] = DBNull.Value;

            if (txtQuestion5Main3YearsP2.Text.Trim().Length > 0)
                dr14["P2_Value"] = txtQuestion5Main3YearsP2.Text.Trim();
            else
                dr14["P2_Value"] = DBNull.Value;

            if (txtQuestion5Main3YearsP3.Text.Trim().Length > 0)
                dr14["P3_Value"] = txtQuestion5Main3YearsP3.Text.Trim();
            else
                dr14["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr14);

            DataRow dr15 = dt.NewRow();

            dr15["FsMappingId"] = "55";
            if (txtQuestion5Main3QuantumP1.Text.Trim().Length > 0)
                dr15["P1_Value"] = txtQuestion5Main3QuantumP1.Text.Trim();
            else
                dr15["P1_Value"] = DBNull.Value;

            if (txtQuestion5Main3QuantumP2.Text.Trim().Length > 0)
                dr15["P2_Value"] = txtQuestion5Main3QuantumP2.Text.Trim();
            else
                dr15["P2_Value"] = DBNull.Value;

            if (txtQuestion5Main3QuantumP3.Text.Trim().Length > 0)
                dr15["P3_Value"] = txtQuestion5Main3QuantumP3.Text.Trim();
            else
                dr15["P3_Value"] = DBNull.Value;

            dt.Rows.Add(dr15);

            DataRow dr16 = dt.NewRow();
            dr16["FsMappingId"] = "56";
            if (txtTenureMain3P1.Text.Trim().Length > 0)
                dr16["P1_Value"] = txtTenureMain3P1.Text.Trim();
            else
                dr16["P1_Value"] = DBNull.Value;

            if (txtTenureMain3P2.Text.Trim().Length > 0)
                dr16["P2_Value"] = txtTenureMain3P2.Text.Trim();
            else
                dr16["P2_Value"] = DBNull.Value;

            if (txtTenureMain3P3.Text.Trim().Length > 0)
                dr16["P3_Value"] = txtTenureMain3P3.Text.Trim();
            else
                dr16["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr16);

            DataRow dr17 = dt.NewRow();
            dr17["FsMappingId"] = "57";
            if (txtMain3MonthsP1.Text.Trim().Length > 0)
                dr17["P1_Value"] = txtMain3MonthsP1.Text.Trim();
            else
                dr17["P1_Value"] = DBNull.Value;

            if (txtMain3MonthsP2.Text.Trim().Length > 0)
                dr17["P2_Value"] = txtMain3MonthsP2.Text.Trim();
            else
                dr17["P2_Value"] = DBNull.Value;

            if (txtMain3MonthsP3.Text.Trim().Length > 0)
                dr17["P3_Value"] = txtMain3MonthsP3.Text.Trim();
            else
                dr17["P3_Value"] = DBNull.Value;
            dt.Rows.Add(dr17);


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


            //Sales

            DataRow dr1 = dt.NewRow();
            dr1["MasterInputId"] = "50";
            if (txtQuestion2.Text.Trim().Length > 0)
                dr1["Input_Value"] = txtQuestion2.Text.Trim();
            else
                dr1["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["MasterInputId"] = "53";
            if (txtQuestion3.Text.Trim().Length > 0)
                dr2["Input_Value"] = txtQuestion3.Text.Trim();
            else
                dr2["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["MasterInputId"] = "52";

            if (txtQuestion4P1.Text.Trim().Length > 0)
                dr3["Input_Value"] = txtQuestion4P1.Text.Trim();
            else
                dr3["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "68";
            if (txtQuestion4P2.Text.Trim().Length > 0)
                dr4["Input_Value"] = txtQuestion4P2.Text.Trim();
            else
                dr4["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["MasterInputId"] = "54";
            if (txtQuestion4EstimatePercent.Text.Trim().Length > 0)
                dr5["Input_Value"] = txtQuestion4EstimatePercent.Text.Trim();
            else
                dr5["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr5);


            DataRow dr6 = dt.NewRow();
            dr6["MasterInputId"] = "55";
            if (txtQuestion4EstimateValue.Text.Trim().Length > 0)
                dr6["Input_Value"] = txtQuestion4EstimateValue.Text.Trim();
            else
                dr6["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["MasterInputId"] = "70";
            if (txtInterestRate.Text.Trim().Length > 0)
                dr7["Input_Value"] = txtInterestRate.Text.Trim();
            else
                dr7["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["MasterInputId"] = "59";
            if (txtMain2InterestRate2.Text.Trim().Length > 0)
                dr8["Input_Value"] = txtMain2InterestRate2.Text.Trim();
            else
                dr8["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr8);

            DataRow dr9 = dt.NewRow();
            dr9["MasterInputId"] = "61";
            if (txtMain3InterestRate3.Text.Trim().Length > 0)
                dr9["Input_Value"] = txtMain3InterestRate3.Text.Trim();
            else
                dr9["Input_Value"] = DBNull.Value;
            dt.Rows.Add(dr9);



            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FinancialModeling/OperatingCost.aspx?Id=" + ViewState["Id"].ToString());
    }

    public void SaveData(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        string strUrl = lb.CommandArgument;

        string strHidden = hfValue.Value;
        if (strHidden == "1")
        {
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);
        }
        string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + strUrl;
        Response.Redirect(_redirectPath);
    }
}