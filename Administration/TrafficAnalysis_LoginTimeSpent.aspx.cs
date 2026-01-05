using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Administration_TrafficAnalysis_LoginTimeSpent : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
    Check_Access chkAccess = new Check_Access();
    public static string token;

    decimal total1 = 0;
    decimal total2 = 0;
    decimal total3 = 0;
    decimal total4 = 0;

    decimal dlbl1 = 0;
    decimal dlbl2 = 0;
    decimal dlbl3 = 0;
    decimal dlbl4 = 0;

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
                DateTime maxDate = DateTime.Today;
                DatePicker_StartDate.MaxDate = maxDate;
                DatePicker_EndDate.MaxDate = maxDate;
                BindGrid();
                FillDropDowns();

            }

        }
    }
    private void FillDropDowns()
    {
        try
        {
            string Culture = Convert.ToString(Session["Culture"]);
            // Code to bind Nature of Business and Industry
            DataSet dsItems = trafficAnalysis.GetItemsDetails(Culture);
            if (dsItems != null && dsItems.Tables.Count > 0)
            {
                ddlIndustry.DataSource = dsItems.Tables[0];
                ddlIndustry.DataTextField = "IndustryNames";
                ddlIndustry.DataValueField = "ID";
                ddlIndustry.DataBind();
            }
            // End Code
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void BindGrid()
    {
        try
        {
            trafficAnalysis.IndustryID = Convert.ToInt32(ddlIndustry.SelectedValue);

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
            DataSet ds_Search = trafficAnalysis.GET_TrafficAnalysis_Login_SpentTime(trafficAnalysis);

          

            if (ds_Search.Tables[0].Rows.Count > 0)
            {
                int Count = 0;
                for (int index = 0; index < ds_Search.Tables[0].Rows.Count; index++)
                {
                    int flag = 1;
                    for (int cindex = 2; cindex <= ds_Search.Tables[0].Columns.Count - 1; cindex++)
                    {
                        if (ds_Search.Tables[0].Rows[index][cindex].ToString() != "0")
                        {
                            flag = 0;
                        }

                    }
                    if (flag == 1)
                    {
                        ds_Search.Tables[0].Rows[index].Delete();
                        Count = Count + 1;

                    }
                }
                if (ds_Search.Tables[0].Rows.Count == Count)
                {
                    lblError.Visible = true;
                    lblError.Text = "  No Data Available";
                    btnExptoExcel.Visible = false;
                    gvTrafficAnalysisLoginTimeSpent.DataBind();
                }
                else
                {
                    btnExptoExcel.Visible = true;

                    gvTrafficAnalysisLoginTimeSpent.DataSource = ds_Search;
                    gvTrafficAnalysisLoginTimeSpent.DataBind();
                }
                //btnExptoExcel.Visible = true;
                //gvTrafficAnalysisLoginTimeSpent.DataSource = ds_Search;
                //gvTrafficAnalysisLoginTimeSpent.DataBind();
                

            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "  No Data Available";
                btnExptoExcel.Visible = false;
                gvTrafficAnalysisLoginTimeSpent.DataBind();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
 

    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=TrafficAnalysisLogin_TimeSpentReport.xls");

        Response.Charset = "";

        Response.ContentType = "application/vnd.xls";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvTrafficAnalysisLoginTimeSpent.RenderControl(htmlWrite);     //throwing error 

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

    protected void gvTrafficAnalysisLoginTimeSpent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl_NewUsersLoginInTime = (Label)e.Row.FindControl("lbl_NewUsersLoginInTime");
            Label lbl_NewUsersAvgLoginInTime = (Label)e.Row.FindControl("lbl_NewUsersAvgLoginInTime");
            Label lbl_TotalUsersLoginInTime = (Label)e.Row.FindControl("lbl_TotalUsersLoginInTime");
            Label lbl_TotalUsersAvgLoginInTime = (Label)e.Row.FindControl("lbl_TotalUsersAvgLoginInTime");
            Label lbl_TotalUsers = (Label)e.Row.FindControl("lbl_TotalUsers");
            Label lbl_NewUsers = (Label)e.Row.FindControl("lbl_NewUsers");

            string MainValue = string.Empty;
            decimal subValue = 0;
            decimal Testvalue = 0;

            if (lbl_NewUsersLoginInTime.Text != "" && lbl_NewUsersLoginInTime.Text != null)
            {
                dlbl1 = Convert.ToDecimal(lbl_NewUsersLoginInTime.Text);
                if (dlbl1 >= 60)
                {
                    decimal value = dlbl1 / Convert.ToDecimal(60.00);
                    Array strArray;
                    strArray = value.ToString().Split('.');
                    //if (Convert.ToDouble(strArray.GetValue(1)) >= 60)
                    //{
                        Testvalue = Convert.ToDecimal(strArray.GetValue(0)) * Convert.ToDecimal(60);
                        subValue = dlbl1 - Testvalue;

                        string value1 = subValue.ToString();
                        int intCount = value1.Length;
                        if (intCount == 1)
                        {
                            value1 = "0" + subValue.ToString();
                        }
                        else
                        {
                            value1 = subValue.ToString(); 
                        }

                        MainValue = strArray.GetValue(0) + "." + value1;
                        dlbl1 = Convert.ToDecimal(MainValue);
                   // }
                }
                else
                {
                    string value = dlbl1.ToString();
                    int intCount = value.Length;
                    if (intCount == 1)
                    {
                        MainValue = "0.0" + value;
                    }
                    else
                    {
                        MainValue = "0." + value;
                    }
                    dlbl1 = Convert.ToDecimal(MainValue);

                }
            }
            else
                dlbl1 = 0;

            if (dlbl1 != 0 && lbl_NewUsers.Text != null && lbl_NewUsers.Text != "")
            {
                if (dlbl1 > 0 && dlbl1 < 1 || dlbl1 > 1)
                {
                    subValue = 0;
                    Testvalue = 0;
                    MainValue = string.Empty;

                    dlbl2 = Math.Round((dlbl1 / Convert.ToDecimal(lbl_NewUsers.Text)), 2);

                    string value = string.Empty;
                    value = dlbl2.ToString();
                    Array strArray;
                    strArray = value.ToString().Split('.');
                    if (Convert.ToDouble(strArray.GetValue(1)) >= 60)
                    {
                        subValue = Convert.ToDecimal(strArray.GetValue(1)) - 60;

                        string value1 = subValue.ToString();

                        int intCount = value1.Length;

                        if (intCount == 1)
                        {
                            value1 = "0" + subValue.ToString();
                        }
                        else
                        {
                            value1 = subValue.ToString();
                        }

                        MainValue = strArray.GetValue(0) + "." + value1;
                        dlbl2 = Convert.ToDecimal(MainValue);
                    }
                }
                else
                {
                    dlbl2 = (dlbl1 / Convert.ToDecimal(lbl_NewUsers.Text));
                }
            }
            else
                dlbl2 = 0;


            if (lbl_TotalUsersLoginInTime.Text != "" && lbl_TotalUsersLoginInTime.Text != null)
            {
                subValue = 0;
                Testvalue = 0;
                MainValue = string.Empty;
                dlbl3 = Convert.ToDecimal(lbl_TotalUsersLoginInTime.Text);

              
                if (dlbl3 >= 60)
                {
                    decimal value = dlbl3 / Convert.ToDecimal(60.00);

                    //string text = value.ToString();
                    //decimal valueTemp;
                    //if (decimal.TryParse(text, out valueTemp))
                    //{
                    //    valueTemp = Math.Round(valueTemp);
                    //    text = valueTemp.ToString();
                    //    // Do something with the new text value
                    //}


                    Array strArray;
                    strArray = value.ToString().Split('.');
                    //if (Convert.ToDouble(strArray.GetValue(1)) >= 60)
                    //{
                        Testvalue = Convert.ToDecimal(strArray.GetValue(0)) * Convert.ToDecimal(60);
                        subValue = dlbl3 - Testvalue;

                        string value1 = subValue.ToString();
                        int intCount = value1.Length;
                        if (intCount == 1)
                        {
                            value1 = "0" + subValue.ToString();
                        }
                        else
                        {
                            value1 = subValue.ToString();
                        }

                        MainValue = strArray.GetValue(0) + "." + value1;
                        dlbl3 = Convert.ToDecimal(MainValue);
                    //}
                }
                else
                {
                    string value = dlbl3.ToString();
                    int intCount = value.Length;
                    if (intCount == 1)
                    {
                        MainValue = "0.0" + value;
                    }
                    else
                    {
                        MainValue = "0." + value;
                    }
                    dlbl3 = Convert.ToDecimal(MainValue);

                }
            }
            else
                dlbl3 = 0;

            if (dlbl3 != 0 && lbl_TotalUsers.Text !=null && lbl_TotalUsers.Text != "")
            {
                if (dlbl3 > 0 && dlbl3 < 1 || dlbl3 > 1)
                {
                    subValue = 0;
                    Testvalue = 0;
                    MainValue = string.Empty;
                    dlbl4 = Math.Round((dlbl3 / Convert.ToDecimal(lbl_TotalUsers.Text)), 2);

                    string value = string.Empty;
                    value = dlbl4.ToString();
                    Array strArray;
                    strArray = value.ToString().Split('.');
                    if (Convert.ToDouble(strArray.GetValue(1)) >= 60)
                    {
                        subValue = Convert.ToDecimal(strArray.GetValue(1)) - 60;

                        string value1 = subValue.ToString();

                        int intCount = value1.Length;

                        if (intCount == 1)
                        {
                            value1 = "0" + subValue.ToString();
                        }
                        else
                        {
                            value1 = subValue.ToString();
                        }

                        MainValue = strArray.GetValue(0) + "." + value1;
                        dlbl4 = Convert.ToDecimal(MainValue);
                    }
                }
                else
                {
                    dlbl4 = (dlbl3 / Convert.ToDecimal(lbl_TotalUsers.Text));
                }
            }
              
            else
                dlbl4 = 0;


            lbl_NewUsersLoginInTime.Text = Convert.ToString(dlbl1);
            total1 += dlbl1;

            lbl_NewUsersAvgLoginInTime.Text = Convert.ToString(dlbl2);
            total2 += dlbl2;

            lbl_TotalUsersLoginInTime.Text = Convert.ToString(dlbl3);
            total3 += dlbl3;

            lbl_TotalUsersAvgLoginInTime.Text = Convert.ToString(dlbl4);
            total4 += dlbl4;

         

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            Label lbl1 = (Label)e.Row.FindControl("NewUsersLoginInTime");
            Label lbl2 = (Label)e.Row.FindControl("NewUsers_AvgLoginInTime");
            Label lbl3 = (Label)e.Row.FindControl("lblTotalUsersLoginInTime");
            Label lbl4 = (Label)e.Row.FindControl("lblTotalUsersAvgLoginInTime");

            if (total1 != 0)
            {
                Array strArray;
                strArray = total1.ToString().Split('.');
                string Mainvalue = string.Empty;
                if (Convert.ToDecimal(strArray.GetValue(1)) >= 60)
                {
                    decimal subValue = Convert.ToDecimal(strArray.GetValue(0)) + 1;
                    decimal subValue1 = Convert.ToDecimal(strArray.GetValue(1)) - 60;
                    string strValue = subValue1.ToString();
                    int intCount = strValue.Length;
                    if (intCount == 1)
                    {
                        Mainvalue = subValue + ".0" + strValue;
                    }
                    else
                    {
                        Mainvalue = subValue + "." + strValue;
                    }
                   // Mainvalue = subValue + "." + subValue1;
                    lbl1.Text = Convert.ToString(Mainvalue);
                }
                else
                {
                    lbl1.Text = total1.ToString();
                }
            }
            else
            {
                lbl1.Text = total1.ToString();
            }

            if (total2 != 0)
            {
                Array strArray1;
                strArray1 = total2.ToString().Split('.');
                string Mainvalue2 = string.Empty;
                if (Convert.ToDecimal(strArray1.GetValue(1)) >= 60)
                {
                    decimal subValue = Convert.ToDecimal(strArray1.GetValue(0)) + 1;
                    decimal subValue1 = Convert.ToDecimal(strArray1.GetValue(1)) - 60;
                    string strValue = subValue1.ToString();
                    int intCount = strValue.Length;
                    if (intCount == 1)
                    {
                        Mainvalue2 = subValue + ".0" + strValue;
                    }
                    else
                    {
                        Mainvalue2 = subValue + "." + strValue;
                    }
                  //  Mainvalue2 = subValue + "." + subValue1;
                    lbl2.Text = Convert.ToString(Mainvalue2);
                }
                else
                {
                    lbl2.Text = total2.ToString();
                }
            }
            else
            {
                lbl2.Text = total2.ToString();
            }

            if (total3 != 0)
            {
                Array strArray3;
                strArray3 = total3.ToString().Split('.');
                string Mainvalue3 = string.Empty;
                if (Convert.ToDecimal(strArray3.GetValue(1)) >= 60)
                {
                    decimal subValue = Convert.ToDecimal(strArray3.GetValue(0)) + 1;
                    decimal subValue1 = Convert.ToDecimal(strArray3.GetValue(1)) - 60;
                    string strValue = subValue1.ToString();
                    int intCount = strValue.Length;
                    if (intCount == 1)
                    {
                        Mainvalue3 = subValue + ".0" + strValue;
                    }
                    else
                    {
                        Mainvalue3 = subValue + "." + strValue;
                    }
                   // Mainvalue3 = subValue + "." + subValue1;
                    lbl3.Text = Convert.ToString(Mainvalue3);
                }
                else
                {
                    lbl3.Text = total3.ToString();
                }
            }
            else
            {
                lbl3.Text = total3.ToString();
            }

            if (total4 != 0)
            {
                Array strArray4;
                strArray4 = total4.ToString().Split('.');
                string Mainvalue4 = string.Empty;
                if (Convert.ToDecimal(strArray4.GetValue(1)) >= 60)
                {
                    decimal subValue = Convert.ToDecimal(strArray4.GetValue(0)) + 1;
                    decimal subValue1 = Convert.ToDecimal(strArray4.GetValue(1)) - 60;

                    string strValue = subValue1.ToString();
                    int intCount = strValue.Length;
                    if (intCount == 1)
                    {
                        Mainvalue4 = subValue + ".0" + strValue;
                    }
                    else
                    {
                        Mainvalue4 = subValue + "." + strValue;
                    }

                    lbl4.Text = Convert.ToString(Mainvalue4);
                }
                else
                {
                    lbl4.Text = total4.ToString();
                }
            }
            else
            {
                lbl4.Text = total4.ToString();
            }

        }
    }
    protected void Button_Go_Click(object sender, ImageClickEventArgs e)
    {
        BindGrid();
    }
}
