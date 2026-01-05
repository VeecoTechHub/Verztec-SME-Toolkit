using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ABSBLL;
using ABSDTO;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;

public partial class FinancialModeling_MainSection : System.Web.UI.Page
{
    UserMgmt objUserMgmt = new UserMgmt();
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
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

                DataTable dtCompanyFinDetails = objFinModelingMgmt.Get_CompanyFinDetails(ViewState["UserID"].ToString());
                ViewState["Id"] = dtCompanyFinDetails.Rows[0][0].ToString();

                rblQ1.SelectedValue = "1";
                rblQ2.SelectedValue = "1";
                rblQ3.SelectedValue = "1";
                rblQ4.SelectedValue = "1";
                rblQ5.SelectedValue = "1";
                rblQ6.SelectedValue = "1";
                    
                bindData();
                
            }

        }

    }

    private void bindData()
    {
        try
        {
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                DataSet ds = objFinModelingMgmt.getDataBySection(0);
                DataTable dtFsMapping = ds.Tables[0];
                DataTable dtInputValue = ds.Tables[1];

                if (dtInputValue.Rows.Count > 0)
                {
                    rblQ1.SelectedValue = getInputValue(dtInputValue, 74);
                    rblQ2.SelectedValue = getInputValue(dtInputValue, 75);
                    rblQ3.SelectedValue = getInputValue(dtInputValue, 76);
                    rblQ4.SelectedValue = getInputValue(dtInputValue, 77);
                    rblQ5.SelectedValue = getInputValue(dtInputValue, 78);
                    rblQ6.SelectedValue = getInputValue(dtInputValue, 79);

                    ViewState["74"] = getInputValue(dtInputValue, 74);
                    ViewState["75"] = getInputValue(dtInputValue, 75);
                    ViewState["76"] = getInputValue(dtInputValue, 76);
                    ViewState["77"] = getInputValue(dtInputValue, 77);
                    ViewState["78"] = getInputValue(dtInputValue, 78);
                    ViewState["79"] = getInputValue(dtInputValue, 79);
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
    protected void btnSaveNext_Click(object sender, EventArgs e)
    {
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
                    if (ViewState["74"].ToString() != rblQ1.SelectedValue || ViewState["75"].ToString() != rblQ2.SelectedValue || ViewState["76"].ToString() != rblQ3.SelectedValue || ViewState["77"].ToString() != rblQ4.SelectedValue || ViewState["78"].ToString() != rblQ5.SelectedValue || ViewState["79"].ToString() != rblQ6.SelectedValue)
                    {
                        objFinModelingMgmt.Update_FinTool_Totals();

                    }
                }

                string _redirectPath = string.Empty; ;
                if (ViewState["Id"].ToString() == "0")
                {
                    _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/FinancialModelingHome.aspx";
                }
                else
                {
                    _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "FinancialModeling/SciStatement.aspx";
                }
                Response.Redirect(_redirectPath);
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

            if (rblQ2.SelectedValue == "0")
            {
                DataRow dr1 = dt.NewRow();
                dr1["FsMappingId"] = "38";
                dr1["C_Value"] = DBNull.Value;
                dr1["P1_Value"] = DBNull.Value;
                dr1["P2_Value"] = DBNull.Value;
                dr1["P3_Value"] = DBNull.Value;
                dr1["C_Percent"] = DBNull.Value;
                dr1["P1_Percent"] = DBNull.Value;
                dr1["P2_Percent"] = DBNull.Value;
                dt.Rows.Add(dr1);
            }

            if (rblQ4.SelectedValue == "0")
            {
                DataRow dr2 = dt.NewRow();
                dr2["FsMappingId"] = "42";
                dr2["C_Value"] = DBNull.Value;
                dr2["P1_Value"] = DBNull.Value;
                dr2["P2_Value"] = DBNull.Value;
                dr2["P3_Value"] = DBNull.Value;
                dr2["C_Percent"] = DBNull.Value;
                dr2["P1_Percent"] = DBNull.Value;
                dr2["P2_Percent"] = DBNull.Value;
                dt.Rows.Add(dr2);
            }
            if (rblQ5.SelectedValue == "0")
            {
                //Capex1
                DataRow dr3 = dt.NewRow();
                dr3["FsMappingId"] = "44";
                dr3["FsMappingName"] = DBNull.Value;
                dr3["C_Value"] = DBNull.Value;
                dr3["P1_Value"] = DBNull.Value;
                dr3["P2_Value"] = DBNull.Value;
                dr3["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr3);             


                //Capex2
                DataRow dr7 = dt.NewRow();
                dr7["FsMappingId"] = "49";
                dr7["FsMappingName"] = DBNull.Value;
                dr7["C_Value"] = DBNull.Value;
                dr7["P1_Value"] = DBNull.Value;
                dr7["P2_Value"] = DBNull.Value;
                dr7["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr7);             


                //Capex3
                DataRow dr11 = dt.NewRow();
                dr11["FsMappingId"] = "54";
                dr11["FsMappingName"] = DBNull.Value;
                dr11["C_Value"] = DBNull.Value;
                dr11["P1_Value"] = DBNull.Value;
                dr11["P2_Value"] = DBNull.Value;
                dr11["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr11);
                
            }

            if (rblQ5.SelectedValue == "0" || rblQ6.SelectedValue == "0")
            {
                //Capex1
                DataRow dr4 = dt.NewRow();
                dr4["FsMappingId"] = "45";
                dr4["P1_Percent"] = DBNull.Value;
                dr4["P2_Percent"] = DBNull.Value;
                dr4["P3_Percent"] = DBNull.Value;
                dt.Rows.Add(dr4);

                DataRow dr5 = dt.NewRow();
                dr5["FsMappingId"] = "46";
                dr5["P1_Value"] = DBNull.Value;
                dr5["P2_Value"] = DBNull.Value;
                dr5["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr5);

                DataRow dr6 = dt.NewRow();
                dr6["FsMappingId"] = "47";
                dr6["P1_Value"] = DBNull.Value;
                dr6["P2_Value"] = DBNull.Value;
                dr6["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr6);

                //Capex2
                DataRow dr8 = dt.NewRow();
                dr8["FsMappingId"] = "50";
                dr8["P1_Percent"] = DBNull.Value;
                dr8["P2_Percent"] = DBNull.Value;
                dr8["P3_Percent"] = DBNull.Value;
                dt.Rows.Add(dr8);

                DataRow dr9 = dt.NewRow();
                dr9["FsMappingId"] = "51";
                dr9["P1_Value"] = DBNull.Value;
                dr9["P2_Value"] = DBNull.Value;
                dr9["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr9);

                DataRow dr10 = dt.NewRow();
                dr10["FsMappingId"] = "52";
                dr10["P1_Value"] = DBNull.Value;
                dr10["P2_Value"] = DBNull.Value;
                dr10["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr10);

                //Capex3
                DataRow dr12 = dt.NewRow();
                dr12["FsMappingId"] = "55";
                dr12["P1_Percent"] = DBNull.Value;
                dr12["P2_Percent"] = DBNull.Value;
                dr12["P3_Percent"] = DBNull.Value;
                dt.Rows.Add(dr12);

                DataRow dr13 = dt.NewRow();
                dr13["FsMappingId"] = "56";
                dr13["P1_Value"] = DBNull.Value;
                dr13["P2_Value"] = DBNull.Value;
                dr13["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr13);

                DataRow dr14 = dt.NewRow();
                dr14["FsMappingId"] = "57";
                dr14["P1_Value"] = DBNull.Value;
                dr14["P2_Value"] = DBNull.Value;
                dr14["P3_Value"] = DBNull.Value;
                dt.Rows.Add(dr14);
            }
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
            dr1["MasterInputId"] = "74";
            dr1["Input_Value"] = rblQ1.SelectedValue;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["MasterInputId"] = "75";
            dr2["Input_Value"] = rblQ2.SelectedValue;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["MasterInputId"] = "76";
            dr3["Input_Value"] = rblQ3.SelectedValue;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["MasterInputId"] = "77";
            dr4["Input_Value"] = rblQ4.SelectedValue;
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["MasterInputId"] = "78";
            dr5["Input_Value"] = rblQ5.SelectedValue;
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["MasterInputId"] = "79";
            dr6["Input_Value"] = rblQ6.SelectedValue;
            dt.Rows.Add(dr6);

            if (rblQ1.SelectedValue == "0")
            {
                DataRow dr7 = dt.NewRow();
                dr7["MasterInputId"] = "40";
                dr7["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr7);

                DataRow dr8 = dt.NewRow();
                dr8["MasterInputId"] = "41";
                dr8["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr8);

                DataRow dr9 = dt.NewRow();
                dr9["MasterInputId"] = "42";
                dr9["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr9);

                DataRow dr10 = dt.NewRow();
                dr10["MasterInputId"] = "43";
                dr10["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr10);

                DataRow dr11 = dt.NewRow();
                dr11["MasterInputId"] = "49";
                dr11["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr11);

                DataRow dr12 = dt.NewRow();
                dr12["MasterInputId"] = "81";
                dr12["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr12);
            }
            if (rblQ3.SelectedValue == "0")
            {
                DataRow dr13 = dt.NewRow();
                dr13["MasterInputId"] = "50";
                dr13["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr13);

                DataRow dr14 = dt.NewRow();
                dr14["MasterInputId"] = "51";
                dr14["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr14);

                DataRow dr15 = dt.NewRow();
                dr15["MasterInputId"] = "52";
                dr15["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr15);

                DataRow dr16 = dt.NewRow();
                dr16["MasterInputId"] = "53";
                dr16["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr16);

                DataRow dr17 = dt.NewRow();
                dr17["MasterInputId"] = "54";
                dr17["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr17);

            }
            if (rblQ4.SelectedValue == "0")
            {
                DataRow dr18 = dt.NewRow();
                dr18["MasterInputId"] = "55";
                dr18["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr18);
            }
            if (rblQ5.SelectedValue == "0")
            {
                DataRow dr19 = dt.NewRow();
                dr19["MasterInputId"] = "83";
                dr19["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr19);

                DataRow dr21 = dt.NewRow();
                dr21["MasterInputId"] = "85";
                dr21["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr21);

                DataRow dr23 = dt.NewRow();
                dr23["MasterInputId"] = "87";
                dr23["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr23);

            }
            if (rblQ5.SelectedValue == "0" || rblQ6.SelectedValue == "0")
            {
                DataRow dr20 = dt.NewRow();
                dr20["MasterInputId"] = "84";
                dr20["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr20);

                DataRow dr22 = dt.NewRow();
                dr22["MasterInputId"] = "86";
                dr22["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr22);

                DataRow dr24 = dt.NewRow();
                dr24["MasterInputId"] = "88";
                dr24["Input_Value"] = DBNull.Value;
                dt.Rows.Add(dr24);
            }

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
            DataTable dtFsMapping = generateFsMapping();
            DataTable dtInputValues = generateInputValues();
            if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
            {
                objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
                int i = objFinModelingMgmt.UpdateFsMappings(dtFsMapping, dtInputValues);

                if (i == 1)
                {
                    if (ViewState["74"].ToString() != rblQ1.SelectedValue || ViewState["75"].ToString() != rblQ2.SelectedValue || ViewState["76"].ToString() != rblQ3.SelectedValue || ViewState["77"].ToString() != rblQ4.SelectedValue || ViewState["78"].ToString() != rblQ5.SelectedValue || ViewState["79"].ToString() != rblQ6.SelectedValue)
                    {
                        objFinModelingMgmt.Update_FinTool_Totals();

                    }
                }
            }
        }
        Response.Redirect("CompanyInformation.aspx");
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        bindData();
    }
    protected void imgBtnGenerateReport_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue.Value;
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
                    if (ViewState["74"].ToString() != rblQ1.SelectedValue || ViewState["75"].ToString() != rblQ2.SelectedValue || ViewState["76"].ToString() != rblQ3.SelectedValue || ViewState["77"].ToString() != rblQ4.SelectedValue || ViewState["78"].ToString() != rblQ5.SelectedValue || ViewState["79"].ToString() != rblQ6.SelectedValue)
                    {
                        objFinModelingMgmt.Update_FinTool_Totals();

                    }
                }
            }
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
        string strHidden = hfValue.Value;
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
                    if (ViewState["74"].ToString() != rblQ1.SelectedValue || ViewState["75"].ToString() != rblQ2.SelectedValue || ViewState["76"].ToString() != rblQ3.SelectedValue || ViewState["77"].ToString() != rblQ4.SelectedValue || ViewState["78"].ToString() != rblQ5.SelectedValue || ViewState["79"].ToString() != rblQ6.SelectedValue)
                    {
                        objFinModelingMgmt.Update_FinTool_Totals();

                    }
                }
            }
        }
        Response.Redirect("SciStatement.aspx");
    }
    protected void imgbtnHome_Click(object sender, ImageClickEventArgs e)
    {
        string strHidden = hfValue.Value;
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
                    if (ViewState["74"].ToString() != rblQ1.SelectedValue || ViewState["75"].ToString() != rblQ2.SelectedValue || ViewState["76"].ToString() != rblQ3.SelectedValue || ViewState["77"].ToString() != rblQ4.SelectedValue || ViewState["78"].ToString() != rblQ5.SelectedValue || ViewState["79"].ToString() != rblQ6.SelectedValue)
                    {
                        objFinModelingMgmt.Update_FinTool_Totals();

                    }
                }
            }
        }
        Response.Redirect("FinancialModelingHome.aspx");
    }

    protected void imgBtnHelp_Click(object sender, ImageClickEventArgs e)
    {
         string strHidden = hfValue.Value;
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
                     if (ViewState["74"].ToString() != rblQ1.SelectedValue || ViewState["75"].ToString() != rblQ2.SelectedValue || ViewState["76"].ToString() != rblQ3.SelectedValue || ViewState["77"].ToString() != rblQ4.SelectedValue || ViewState["78"].ToString() != rblQ5.SelectedValue || ViewState["79"].ToString() != rblQ6.SelectedValue)
                     {
                         objFinModelingMgmt.Update_FinTool_Totals();

                     }
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