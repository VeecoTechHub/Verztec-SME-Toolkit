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

public partial class UserControls_TradeCycle : System.Web.UI.UserControl
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
  
    public static string strLblClientIds =string.Empty;
    public int count = 0;

    public string lblFYLoclResText = string.Empty;
    public string lblActualLoclResText = string.Empty;
    public string lblEstimatesLoclResText = string.Empty;

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
        lblActualLoclResText = Convert.ToString(GetLocalResourceObject("lblActualResource1.Text"));
        lblEstimatesLoclResText = Convert.ToString(GetLocalResourceObject("lblEstimatesResource1.Text"));

        objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
        DataTable dtCompanyInfo = objFinModelingMgmt.bindCompanyInformationByUserID();
        ViewState["IsFinancialStmtAvailable"] = dtCompanyInfo.Rows[0]["IsFinancialStmtAvailable"];
        bindCompanyInfo();
        Binddata();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "FormatCells", "formatCellsWithComma('" + strLblClientIds + "');", true);          

      
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

                this.gvIncomeReport.Columns[1].HeaderText = "<span align='center'>" + lblFYLoclResText + "</span><br/><span align='center'>" + ViewState["CurrentYear"].ToString() + "</span><br/><span align='center'>" + lblActualLoclResText + "</span>";
                this.gvIncomeReport.Columns[3].HeaderText = "<span align='center'>" + lblFYLoclResText + "</span><br/><span align='center'>" + ViewState["ProjYear1"].ToString() + "</span><br/><span align='center'>" + lblEstimatesLoclResText + "</span>";
                this.gvIncomeReport.Columns[5].HeaderText = "<span align='center'>" + lblFYLoclResText + "</span><br/><span align='center'>" + ViewState["ProjYear2"].ToString() + "</span><br/><span align='center'>" + lblEstimatesLoclResText + "</span>";
                this.gvIncomeReport.Columns[7].HeaderText = "<span align='center'>" + lblFYLoclResText + "</span><br/><span align='center'>" + ViewState["ProjYear3"].ToString() + "</span><br/><span align='center'>" + lblEstimatesLoclResText + "</span>";

                //this.gvBalanceReport.Columns[1].HeaderText = "Actual <br />FY" + ViewState["CurrentYear"].ToString();
                //this.gvBalanceReport.Columns[2].HeaderText = "Estimates <br />FY" + ViewState["ProjYear1"].ToString();
                //this.gvBalanceReport.Columns[3].HeaderText = "Estimates <br />FY" + ViewState["ProjYear2"].ToString();
                //this.gvBalanceReport.Columns[4].HeaderText = "Estimates <br />FY" + ViewState["ProjYear3"].ToString();

                this.gvCashFlowAnalysisReport.Columns[1].HeaderText =  "<span align='right'>" + lblFYLoclResText + ViewState["ProjYear1"].ToString() + "</span><br/><span align='center'>" + lblEstimatesLoclResText + "</span>";
                this.gvCashFlowAnalysisReport.Columns[2].HeaderText = "<span align='right'>" + lblFYLoclResText + ViewState["ProjYear2"].ToString() + "</span><br/><span align='center'>" + lblEstimatesLoclResText + "</span>";
                this.gvCashFlowAnalysisReport.Columns[3].HeaderText = "<span align='right'>" + lblFYLoclResText + ViewState["ProjYear3"].ToString() + "</span><br/><span align='center'>" + lblEstimatesLoclResText + "</span>";

            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void Binddata()
    {
        DataSet dsData = new DataSet();
        if (ViewState["UserID"].ToString() != "" && ViewState["UserID"] != null)
        {
            objFinModelingMgmt.UserID = ViewState["UserID"].ToString();
            objFinModelingMgmt.Culture = Convert.ToString(Session["Culture"]);
            dsData = objFinModelingMgmt.Get_FinTool_Appa_Financials_Report(objFinModelingMgmt);

            ViewState["IncomeStatement"] = dsData.Tables[0];
            gvIncomeReport.DataSource = dsData.Tables[0];
            gvIncomeReport.DataBind();
            //gvBalanceReport.DataSource = dsData.Tables[12];
            //gvBalanceReport.DataBind();
            ViewState["CashFlow"] = dsData.Tables[1];
            gvCashFlowAnalysisReport.DataSource = dsData.Tables[1];
            gvCashFlowAnalysisReport.DataBind();

            if (ViewState["IsFinancialStmtAvailable"].ToString() == "0")
            {
                gvIncomeReport.Columns[1].Visible = false;
                gvIncomeReport.Columns[2].Visible = false;
                // gvBalanceReport.Columns[1].Visible = false;

            }


            String strURLPath = Request.Url.AbsolutePath.ToString();
            Array strArray;
            strArray = strURLPath.ToString().Split('/');
            int length = strArray.Length;
            string path = string.Empty;
            if (strArray.GetValue(length - 1).ToString().ToLower().Contains("reports.aspx"))
            {
                HideTR1.Visible = false;
                HideTR2.Visible = false;
            }
        }
    }




    protected void gvIncomeReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int intValue = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            Label lblc = (Label)e.Row.FindControl("lbl_C_Value");
            Label lblcPercent = (Label)e.Row.FindControl("lbl_C_Percent");

            if (ViewState["IsFinancialStmtAvailable"].ToString() == "0")
            {
                
                if (strLblClientIds == "")
                {
                    strLblClientIds = lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
                }
                else
                {
                    strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
                }
            }
            else
            {
              
                if (strLblClientIds == "")
                {
                    strLblClientIds = lblc.ClientID + "," +  lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
                }
                else
                {
                    strLblClientIds = strLblClientIds + "," + lblc.ClientID + "," +  lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
                }


                if (e.Row.RowIndex == 1 || e.Row.RowIndex == 3 || e.Row.RowIndex == 6 || e.Row.RowIndex == 7 || e.Row.RowIndex == 9)
                {
                    if (lblc.Text.ToString() != null && lblc.Text.ToString() != "")
                    {
                        intValue = Convert.ToInt32(lblc.Text);
                        lblc.Text = (-intValue).ToString();
                    }
                    //if (e.Row.RowIndex == 9 && lblcPercent.Text.ToString() != null && lblcPercent.Text.ToString() != "")
                    //{
                    //    intValue1 = Convert.ToInt32(lblcPercent.Text);
                    //    lblcPercent.Text = (-intValue1).ToString();
                    //}


                }
            }
            if (e.Row.RowIndex == 2 || e.Row.RowIndex == 5 || e.Row.RowIndex == 8 || e.Row.RowIndex == 10)
            {
                e.Row.Style.Value = "font-weight:bold";
            }
            if (e.Row.RowIndex == 2)
            {
                lblc.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2", "C_Value", "1,-1").ToString();
                lblp1.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2", "P1_Value", "1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2", "P2_Value", "1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2", "P3_Value", "1,1").ToString();
            }
            if (e.Row.RowIndex == 5)
            {
                lblc.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5", "C_Value", "1,-1,-1,1").ToString();
                lblp1.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5", "P1_Value", "1,1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5", "P2_Value", "1,1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5", "P3_Value", "1,1,1,1").ToString();
            }
            if (e.Row.RowIndex == 8)
            {
                lblc.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5,7,8", "C_Value", "1,-1,-1,1,-1,-1").ToString();
                lblp1.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5,7,8", "P1_Value", "1,1,1,1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5,7,8", "P2_Value", "1,1,1,1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5,7,8", "P3_Value", "1,1,1,1,1,1").ToString();
            }
            if (e.Row.RowIndex == 10)
            {
                lblc.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5,7,8,10", "C_Value", "1,-1,-1,1,-1,-1,-1").ToString();
                lblp1.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5,7,8,10", "P1_Value", "1,1,1,1,1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5,7,8,10", "P2_Value", "1,1,1,1,1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["IncomeStatement"], "1,2,4,5,7,8,10", "P3_Value", "1,1,1,1,1,1,1").ToString();
            }
          


        }
     

       // lbl.Text = strLblClientIds.ToString();
    }
    //protected void gvBalanceReport_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
            
    //        Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
    //        Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
    //        Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
    //        if (ViewState["IsFinancialStmtAvailable"].ToString() == "0")
    //        {
    //            if (strLblClientIds == "")
    //            {
    //                strLblClientIds = lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
    //            }
    //            else
    //            {
    //                strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
    //            }
    //        }
    //        else
    //        {
    //            Label lblc = (Label)e.Row.FindControl("lbl_C_Value");
    //            if (strLblClientIds == "")
    //            {
    //                strLblClientIds = lblc.ClientID + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
    //            }
    //            else
    //            {
    //                strLblClientIds = strLblClientIds + "," + lblc.ClientID + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
    //            }
    //        }
            
    //        if (e.Row.RowIndex == 5 || e.Row.RowIndex == 7 || e.Row.RowIndex == 8 || e.Row.RowIndex == 15 || e.Row.RowIndex == 19 || e.Row.RowIndex == 20)
    //        {
    //            e.Row.Style.Value = "font-weight:bold";
    //        }
    //    }

    //    lbl.Text = strLblClientIds.ToString();
    //}
    protected void gvCashFlowAnalysisReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblc = (Label)e.Row.FindControl("lbl_C_Value");
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            if (strLblClientIds == "")
            {
                strLblClientIds = lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }
            else
            {
                strLblClientIds = strLblClientIds + "," + lblp1.ClientID + "," + lblp2.ClientID + "," + lblp3.ClientID;
            }

            if (e.Row.RowIndex == 2 || e.Row.RowIndex == 6 || e.Row.RowIndex == 7 || e.Row.RowIndex == 12 || e.Row.RowIndex == 16 || e.Row.RowIndex == 18 || e.Row.RowIndex == 21)
            {
                e.Row.Style.Value = "font-weight:bold";
            }
            if (e.Row.RowIndex == 19)
            {
                string strForReferenceOnly = Convert.ToString(GetLocalResourceObject("lblFake1Resource1.Text"));
                string strHeadroom = Convert.ToString(GetLocalResourceObject("lblFake2Resource1.Text"));

                e.Row.Cells[0].Text = "<b><u><I>" + strForReferenceOnly + "</I></u></b><br/>" + strHeadroom + "";
            }
            if (e.Row.RowIndex == 2)
            {
                lblp1.Text = calValues((DataTable)ViewState["CashFlow"], "179,180", "P1_Value", "1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["CashFlow"], "179,180", "P2_Value", "1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["CashFlow"], "179,180", "P3_Value", "1,1").ToString();
            }
            if (e.Row.RowIndex == 6)
            {
                lblp1.Text = calValues((DataTable)ViewState["CashFlow"], "182,183,184", "P1_Value", "1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["CashFlow"], "182,183,184", "P2_Value", "1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["CashFlow"], "182,183,184", "P3_Value", "1,1,1").ToString();
            }
            if (e.Row.RowIndex == 7)
            {
                lblp1.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184", "P1_Value", "1,1,1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184", "P2_Value", "1,1,1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184", "P3_Value", "1,1,1,1,1").ToString();
            }
            if (e.Row.RowIndex == 12)
            {
                lblp1.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190", "P1_Value", "1,1,1,1,1,1,1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190", "P2_Value", "1,1,1,1,1,1,1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190", "P3_Value", "1,1,1,1,1,1,1,1,1").ToString();
            }
            if (e.Row.RowIndex == 16)
            {
                lblp1.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194", "P1_Value", "1,1,1,1,1,1,1,1,1,1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194", "P2_Value", "1,1,1,1,1,1,1,1,1,1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194", "P3_Value", "1,1,1,1,1,1,1,1,1,1,1,1").ToString();
            }
            if (e.Row.RowIndex == 18)
            {
                lblp1.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194,196", "P1_Value", "1,1,1,1,1,1,1,1,1,1,1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194,196", "P2_Value", "1,1,1,1,1,1,1,1,1,1,1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194,196", "P3_Value", "1,1,1,1,1,1,1,1,1,1,1,1,1").ToString();
            }
            if (e.Row.RowIndex == 21)
            {
                lblp1.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194,196,198,199", "P1_Value", "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194,196,198,199", "P2_Value", "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["CashFlow"], "179,180,182,183,184,187,188,189,190,192,193,194,196,198,199", "P3_Value", "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1").ToString();
            }
        }

    
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
                if (dr[0][strFieldName] != null && Convert.ToString(dr[0][strFieldName] ) != "" )
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

}
