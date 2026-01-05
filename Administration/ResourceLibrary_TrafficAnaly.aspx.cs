using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class Administration_ResourceLibrary_TrafficAnaly : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    Check_Access chkAccess = new Check_Access();
    public static string token;
    DataTable dtData = new DataTable();
    decimal total1 = 0M;
    decimal total2 = 0M;
    int int_d_total = 0;

    decimal dlbl1 = 0;
    decimal dlbl2 = 0;
    int int_d_temp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       

     
        if (!IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            token = Request.Form["token"];
            //ViewState["t_url"] = "Admin_NextSteps.aspx";
            if (token == null)
            {
                Response.Redirect("default.aspx");
            }

            else
            {
                if (Session["GROUP_ID"] == null || Session["GROUP_ID"].ToString().ToUpper() != "ADMIN")
                {
                    Response.Redirect("~/Administration/Default.aspx");
                    return;
                }
                DateTime maxDate = DateTime.Today;
                DatePicker_StartDate.MaxDate = maxDate;
                DatePicker_EndDate.MaxDate = maxDate;
                BindGrid();

            }

        }
    }

    public void BindGrid()
    {
        //try
        //{
        //trafficAnalysis.PostedBy = txtName.Text.ToString();

        if (DatePicker_StartDate.DateString == "")
        {
            trafficAnalysis.StartDate = null;
        }
        else
        {
            trafficAnalysis.StartDate = Convert.ToString(DatePicker_StartDate.Date);
        }
        if (DatePicker_EndDate.DateString == "")
        {
            trafficAnalysis.EndDate = null;
        }
        else
        {
            trafficAnalysis.EndDate = Convert.ToString(DatePicker_EndDate.Date);
        }
        trafficAnalysis.Culture = Convert.ToInt32(ddlCulture.SelectedItem.Value);
        DataSet ds_Search = trafficAnalysis.Get_ResLib_TrafficAnalysis(trafficAnalysis);
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
            gvTrafficAnalysisLogin.DataBind();

        }

        if (ds_Search.Tables[0].Rows.Count != 0)
        {

            if (ds_Search.Tables[0].Rows.Count > 0)
            {

                dtData.Columns.Add(new DataColumn("Id", typeof(string)));
                dtData.Columns.Add(new DataColumn("Title", typeof(string)));
                dtData.Columns.Add(new DataColumn("Hits", typeof(string)));
                dtData.Columns.Add(new DataColumn("Fav", typeof(string)));
                dtData.Columns.Add(new DataColumn("flag", typeof(string)));
                dtData.Columns.Add(new DataColumn("na", typeof(string)));
                dtData.Columns.Add(new DataColumn("level", typeof(string)));
                dtData.Columns.Add(new DataColumn("downloadhits", typeof(string)));



                DataRow dr;
                int count = 0;
                for (int index = 0; index < ds_Search.Tables[0].Rows.Count; index++)
                {


                    if (index == 0)
                    {
                        ViewState["TopicID"] = "Nothing";

                        dr = dtData.NewRow();
                        count = count + 1;
                        dr["Id"] = ds_Search.Tables[0].Rows[index]["TopicID"].ToString();
                        dr["Title"] = count.ToString() + ") " + ds_Search.Tables[0].Rows[index]["TopicName"].ToString();
                        dr["Hits"] = "";
                        dr["Fav"] = "";
                        dr["flag"] = "1";
                        dr["na"] = "0";
                        dr["level"] = "1";
                        dr["downloadhits"] = "";
                        dtData.Rows.Add(dr);
                    }
                    //Self Evaluation - Financial Management Discipline 
                    if (ViewState["TopicID"].ToString().Equals(ds_Search.Tables[0].Rows[index]["TopicID"].ToString()) || index == 0)
                    {
                        ViewState["TopicID"] = ds_Search.Tables[0].Rows[index]["TopicID"].ToString();
                        dr = dtData.NewRow();

                        string level = string.Empty;
                        if (ds_Search.Tables[0].Rows[index]["level"].ToString().Length == 3)
                            level = "2";
                        else if (ds_Search.Tables[0].Rows[index]["level"].ToString().Length >= 5)
                            level = "3";
                        else
                            level = "0";

                        dr["Id"] = ds_Search.Tables[0].Rows[index]["TopicID"].ToString();
                        if (level == "3")
                            dr["Title"] = ds_Search.Tables[0].Rows[index]["Title"].ToString();
                        else
                            dr["Title"] = ds_Search.Tables[0].Rows[index]["level"].ToString() + " " + ds_Search.Tables[0].Rows[index]["Title"].ToString();

                        dr["Hits"] = ds_Search.Tables[0].Rows[index]["hits"].ToString();
                        dr["Fav"] = ds_Search.Tables[0].Rows[index]["favourite"].ToString();
                        dr["flag"] = "0";
                        dr["level"] = level;
                        dr["downloadhits"] = ds_Search.Tables[0].Rows[index]["downloadhits"].ToString();

                        dtData.Rows.Add(dr);
                    }
                    else
                    {

                        dr = dtData.NewRow();
                        count = count + 1;
                        dr["Id"] = ds_Search.Tables[0].Rows[index]["TopicID"].ToString();
                        dr["Title"] = count.ToString() + ") " + ds_Search.Tables[0].Rows[index]["TopicName"].ToString();
                        dr["Hits"] = "";
                        dr["Fav"] = "";
                        dr["flag"] = "1";
                        dr["na"] = "0";
                        dr["level"] = "1";
                        dr["downloadhits"] = "";
                        dtData.Rows.Add(dr);

                        string level = string.Empty;
                        if (ds_Search.Tables[0].Rows[index]["level"].ToString().Length == 3)
                            level = "2";
                        else if (ds_Search.Tables[0].Rows[index]["level"].ToString().Length >= 5)
                            level = "3";
                        else
                            level = "0";

                        ViewState["TopicID"] = ds_Search.Tables[0].Rows[index]["TopicID"].ToString();
                        dr = dtData.NewRow();
                        dr["Id"] = ds_Search.Tables[0].Rows[index]["TopicID"].ToString();
                        if (level == "3")
                            dr["Title"] = ds_Search.Tables[0].Rows[index]["Title"].ToString();
                        else
                            dr["Title"] = ds_Search.Tables[0].Rows[index]["level"].ToString() + " " + ds_Search.Tables[0].Rows[index]["Title"].ToString();

                        dr["Hits"] = ds_Search.Tables[0].Rows[index]["hits"].ToString();
                        dr["Fav"] = ds_Search.Tables[0].Rows[index]["favourite"].ToString();
                        dr["flag"] = "0";
                        dr["na"] = "0";
                        dr["level"] = level;
                        dr["downloadhits"] = ds_Search.Tables[0].Rows[index]["downloadhits"].ToString();

                        dtData.Rows.Add(dr);
                    }
                }

            }
            ViewState["dsData"] = ds_Search;
            gvTrafficAnalysisLogin.DataSource = dtData;
            gvTrafficAnalysisLogin.DataBind();


        }

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }


    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=ResourceLibrary_TrafficAnaly.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xls";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvTrafficAnalysisLogin.RenderControl(htmlWrite);     //throwing error 

        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {

        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.

    }

    protected void btnExptoExcel_Click(object sender, ImageClickEventArgs e)
    {
        ExportToExcel();
    }

    protected void gvTrafficAnalysisLogin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl1 = (Label)e.Row.FindControl("lbl_NewUsers");
            Label lbl2 = (Label)e.Row.FindControl("lbl_TotalUsers");
            Label lbl_download = (Label)e.Row.FindControl("lbl_download");

            Label lblflag = (Label)e.Row.FindControl("lblflag");
            Label lblna = (Label)e.Row.FindControl("lblna");

            Label lblna1 = (Label)e.Row.FindControl("lblna1");
            

            if (lblflag.Text == "1")
            {
                e.Row.BackColor = Color.FromName("#BEBEBE");
                e.Row.Font.Bold = true;
            }



            if (lbl1.Text != "" && lbl1.Text != null)
                dlbl1 = Convert.ToDecimal(lbl1.Text);
            else
                dlbl1 = 0;

            if (lbl2.Text != "" && lbl2.Text != null)
                dlbl2 = Convert.ToDecimal(lbl2.Text);
            else
                dlbl2 = 0;

            if (lbl_download.Text != "" && lbl_download.Text != null)
                int_d_temp = Convert.ToInt32(lbl_download.Text);
            else
                int_d_temp = 0;


            

            total1 += dlbl1;
            total2 += dlbl2;
            int_d_total += int_d_temp;

            if (lblna.Text == "1")
            {
                //lbl_NewUsers
                Label lbl_NewUsers = (Label)e.Row.FindControl("lbl_NewUsers");
                Label lbl_TotalUsers = (Label)e.Row.FindControl("lbl_TotalUsers");
               
                lbl_NewUsers.Text = "NA";
                lbl_TotalUsers.Text = "NA";
                //e.Row.BackColor = Color.FromName("#BEBEBE");
                // e.Row.Font.Bold = true;
            }

            if (lblna1.Text == "3")
            {
                //e.Row.BackColor = Color.FromName("#BEBEBE");
                e.Row.Cells[0].Style.Add("padding-left","30");
                //e.Row.Font.Bold = true;
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            Label lbl1 = (Label)e.Row.FindControl("lblNewUsers");
            Label lbl2 = (Label)e.Row.FindControl("lblTotalUsers");
            Label lbl_downloadhits = (Label)e.Row.FindControl("lbl_downloadhits");

            lbl1.Text = total1.ToString();
            lbl2.Text = total2.ToString();
            lbl_downloadhits.Text = int_d_total.ToString();

        }
    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
}
