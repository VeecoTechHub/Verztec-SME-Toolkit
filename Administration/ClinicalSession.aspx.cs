using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using ABSBLL;
using System.Configuration;
using System.Globalization;
using System.Threading;

public partial class Administration_ClinicalSession : System.Web.UI.Page
{
    CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    ABSBLL.Registration objRegs = new ABSBLL.Registration();
    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            token = Request.Form["token"];

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {
                if (Session["GROUP_ID"] == null || Session["GROUP_ID"].ToString().ToUpper() != "ADMIN")
                {
                    Response.Redirect("~/Administration/Default.aspx");
                    return;
                }
                //DateTime maxDate = DateTime.Today;
                //DatePicker_StartDate.MaxDate = maxDate;
                //DatePicker_EndDate.MaxDate = maxDate;
              
                BindGrid();
            }
        }
    }

    public void BindGrid()
    {
        try
        {
            if(txtCompanyName.Text.Trim().Length > 0)
              objRegs.Company = txtCompanyName.Text;
            else
                objRegs.Company = DBNull.Value.ToString();

            if (txtEmail.Text.Trim().Length > 0)
                 objRegs.Email = txtEmail.Text;
            else
                objRegs.Email = DBNull.Value.ToString();


            if (DatePicker_StartDate.DateString == "")
            {
                objRegs.StartDate = null;
            }
            else
            {
                objRegs.StartDate = Convert.ToString(DatePicker_StartDate.Date);
            }
            if (DatePicker_EndDate.DateString == "")
            {
                objRegs.EndDate = null;
            }
            else
            {
                objRegs.EndDate = Convert.ToString(DatePicker_EndDate.Date);
            }
            DataSet ds_Search = objRegs.Get_ClinicalSession(objRegs);



            if (ds_Search.Tables[0].Rows.Count > 0)
            {
                lblError.Visible = false;
                btnExptoExcel.Visible = true;
                tdSelect.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "  No Data Available";
                btnExptoExcel.Visible = false;
                tdSelect.Visible = false;
                gvClinicalSession.DataBind();

            }

            if (ds_Search.Tables[0].Rows.Count <= 0)
            {
                 lblError.Visible = true;
                    lblError.Text = "  No Data Available";
                    btnExptoExcel.Visible = false;
                    tdSelect.Visible = false;
                    gvClinicalSession.DataBind();
               
            }
            else
            {
                btnExptoExcel.Visible = true; ;

                gvExcel.DataSource = ds_Search;
                gvExcel.DataBind();

                gvClinicalSession.DataSource = ds_Search;
                gvClinicalSession.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnExptoExcel_Click(object sender, ImageClickEventArgs e)
    {
        ExportToExcel();
    }
    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=ClinicalSession.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
      
        Response.ContentType = "application/vnd.xls";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvExcel.Visible = true;
        gvExcel.RenderControl(htmlWrite);     //throwing error 

        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {

        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.

    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }


    protected void gvClinicalSession_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Save"))
        {
            string strUserId = e.CommandArgument.ToString();

            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            TextBox AdminPreferredDate = (TextBox)row.Cells[0].FindControl("txt_AdminPreferredDate");


            objRegs.UserID = strUserId;
            objRegs.Admin_PreferredDate = AdminPreferredDate.Text;

            int Result = objRegs.Update_ClinicalSession(objRegs);

            if (Result == 1)
            {
                BindGrid();
                ABSCommon.Common.ShowMessage(this, "Saved successfully");
            }
            else
                ABSCommon.Common.ShowMessage(this, "Save failed");
        }
    }

 


}
