using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using ABSCommon;
using ABSDTO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Administration_SurveyReport : System.Web.UI.Page
{

    private HealthProfiling obj_Hpetails = new HealthProfiling();
    Check_Access chkAccess = new Check_Access();
    private CommonFunctions CommonFunctions = new CommonFunctions();
    public string strparm;
    public string strtags = "";
    DataSet tagds = new DataSet();
    DataSet DsReport = new DataSet();
    int index = 0;
    int count = 1;
    DataSet ds_Search = new DataSet();
    public static string token;
    protected void Page_Load(object sender, EventArgs e)
    {
        
     

        DG_NextStep.Visible = true;

        if (!IsPostBack)
        {

            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_url1"] = "../Administration/CourseRegistration_Report.aspx";
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            DatePicker_StartDate.MaxDate = DateTime.Now.Date;
            DatePicker_EndDate.MaxDate = DateTime.Now.Date;

            obj_Hpetails.StartDate = null;
            obj_Hpetails.EndDate = null;

            Bind_Data();

            token = Request.Form["token"];

            if (token == null)
                Response.Redirect("~/Administration/Default.aspx");
            else
            {

               // Bind_QueCategory();
            }
        }
    }
    //public void Bind_QueCategory()
    //{
    //    DataSet dscat = new DataSet();
    //    dscat = obj_Hpetails.Get_QueCategory();
    //    ddlCategory.DataSource = dscat;

    //    ddlCategory.DataTextField = "Category";
    //    ddlCategory.DataBind();
    //    ddlCategory.Items.Insert(0, "All");


    //}

    void Bind_Data()
    {
        //if (ddlCategory.SelectedIndex > 0)
        //{ obj_Hpetails.Category = ddlCategory.SelectedItem.Text; }
        //else
        //{
        //    obj_Hpetails.Category = "all";
        //}


        DsReport.Tables.Clear();
        DsReport = obj_Hpetails.Get_ReportHealthProfile(obj_Hpetails);
        
        DG_NextStep.DataSource = null;

        
        if (DsReport.Tables[0].Rows.Count > 0)
        {
            DG_NextStep.Visible = true;
            DG_NextStep.DataSource = DsReport;
            DG_NextStep.DataBind();
            lblError.Visible = false;
            gvExport.DataSource = DsReport;
            gvExport.DataBind();
            btnExptoExcel.Visible = true ;

        }

        else
        {

            btnExptoExcel.Visible = false;

            DG_NextStep.Visible = false;
            lblError.Text = "No Record Found";
            lblError.Visible = true;


        }


    }



    protected void Button_New_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Administration/Admin_AddNextSteps.aspx");
    }




    protected void DG_NextStep_ItemCreated(object sender, DataGridItemEventArgs e)
    {


    }
    protected void DG_NextStep_SortCommand(object source, DataGridSortCommandEventArgs e)
    {

    }
    protected void DG_NextStep_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {

    }



    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        //DatePicker_EndDate.DateString = DateTime.Now.Date.ToString();
        if (DatePicker_StartDate.DateString == "")
        {
            obj_Hpetails.StartDate = null;

        }
        if (DatePicker_EndDate.DateString == "")
        {
           // DatePicker_EndDate.DateString = DateTime.Now.Date.ToString();
            obj_Hpetails.EndDate = DateTime.Now.Date.ToString();

        }
        else
        {
            obj_Hpetails.StartDate = Convert.ToString(DatePicker_StartDate.Date);
            obj_Hpetails.EndDate = Convert.ToString(DatePicker_EndDate.Date);
        }
        Bind_Data();


    }
    protected void DG_NextStep_ItemDataBound(object sender, DataGridItemEventArgs e)
    {


    }



    protected void DatePicker_StartDate_Load(object sender, EventArgs e)
    {
       
    }
    protected void DatePicker_StartDate_PreRender(object sender, EventArgs e)
    {
       
    }
    protected void btnExptoExcel_Click(object sender, ImageClickEventArgs e)
    {
      
      // if (gvExport.Rows.Count>0)
       
            ExportToExcel();
       
    }
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //for exporttoexcel to work....we have to put define this method. 
        // Confirms that an HtmlForm control is rendered for the 
        // specified ASP.NET server control at run time. 


    }


    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=SurveyReport.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xlsx";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        gvExport.RenderControl(htmlWrite);     //throwing error

        Response.Write(stringWrite.ToString());

        Response.End();
    }
}