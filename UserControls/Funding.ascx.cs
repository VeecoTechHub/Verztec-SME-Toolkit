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

public partial class UserControls_Funding : System.Web.UI.UserControl
{
    FinancialModelingMgmt objFinModelingMgmt = new FinancialModelingMgmt();
    public static string strLblClientIds = string.Empty;

    public string lblFYLoclResText = string.Empty;
    public string lblNilLoclResText = string.Empty;

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
        lblNilLoclResText = Convert.ToString(GetLocalResourceObject("lblNilResource1.Text"));
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

                this.gvReport.Columns[0].HeaderText = "";
                this.gvReport.Columns[1].HeaderText = lblFYLoclResText + ViewState["ProjYear1"].ToString();
                this.gvReport.Columns[2].HeaderText = lblFYLoclResText + ViewState["ProjYear2"].ToString();
                this.gvReport.Columns[3].HeaderText = lblFYLoclResText + ViewState["ProjYear3"].ToString();
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
            dsData = objFinModelingMgmt.Get_FinTool_Funding_Report(objFinModelingMgmt);

            ViewState["Funding"] = dsData.Tables[0];
            gvReport.DataSource = dsData.Tables[0];
            gvReport.DataBind();
        }
    }
    protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblfsMappingName = (Label)e.Row.FindControl("lblFsMappingName");
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            if (e.Row.RowIndex != 6)
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
            if (e.Row.RowIndex == 2)
            {
                lblp1.Text = calValues((DataTable)ViewState["Funding"], "259,260", "P1_Value", "1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["Funding"], "259,260", "P2_Value", "1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["Funding"], "259,260", "P3_Value", "1,1").ToString();
            }
            if (e.Row.RowIndex == 5)
            {
                lblp1.Text = calValues((DataTable)ViewState["Funding"], "262,263", "P1_Value", "1,1").ToString();
                lblp2.Text = calValues((DataTable)ViewState["Funding"], "262,263", "P2_Value", "1,1").ToString();
                lblp3.Text = calValues((DataTable)ViewState["Funding"], "262,263", "P3_Value", "1,1").ToString();
            }

            if (e.Row.RowIndex == 4)
            {
                lblfsMappingName.Text = lblfsMappingName.Text + "<br/>" + Convert.ToString(GetLocalResourceObject("lblFakeAddResource1.Text")); ;
            }

          
        }
        if (e.Row.RowIndex == 2)
        {
            e.Row.Font.Bold = true;
            e.Row.Cells[1].CssClass = "tdtop";
            e.Row.Cells[2].CssClass = "tdtop";
            e.Row.Cells[3].CssClass = "tdtop";
         
        }
        if (e.Row.RowIndex == 5)
        {
            e.Row.Font.Bold = true;
            e.Row.Cells[1].CssClass = "tdtop";
            e.Row.Cells[2].CssClass = "tdtop";
            e.Row.Cells[3].CssClass = "tdtop";
            
        }
        if (e.Row.RowIndex == 6)
        {
            Label lblp1 = (Label)e.Row.FindControl("lbl_P1_Value");
            Label lblp2 = (Label)e.Row.FindControl("lbl_P2_Value");
            Label lblp3 = (Label)e.Row.FindControl("lbl_P3_Value");
            e.Row.Font.Bold = true;
            e.Row.ForeColor = System.Drawing.Color.Blue;

            if (lblp1.Text == "")
            {
                lblp1.Text = lblNilLoclResText;
            }
            if (lblp2.Text == "")
            {
                lblp2.Text = lblNilLoclResText;
            }
            if (lblp3.Text == "")
            {
                lblp3.Text = lblNilLoclResText;
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