using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSCommon;
using System.Configuration;
using ABSBLL;
using System.Data;
using ABSDTO;

public partial class Administration_PublicUsersList_Search : System.Web.UI.Page
{

    private DataSet ds_Search;
    int index = 0;
    CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();
    RegistrationDTO objDTO = new RegistrationDTO();
    ABSBLL.Registration objRegs = new ABSBLL.Registration();
    public static string token;

    protected void Page_Load(object sender, EventArgs e)
    {
   
      
        if (!IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
            DG_ResourcesLibrary.Visible = true;

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
                FillDropDowns();
                Bind_Data();
            }
        }

    }

    private void FillDropDowns()
    {
        try
        {
            TrafficAnalysis trafficAnalysis = new TrafficAnalysis();
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

    private void Bind_Data()
    {
        this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
        Bind_DataGrid();
        try
        {
            DG_ResourcesLibrary.CurrentPageIndex = System.Convert.ToInt32(Session["pageno"]);
        }
        catch
        {
        }
        try
        {
            ViewState["Sort_On"] = Session["sort_on"];
        }
        catch
        {
        }
        try
        {
            Bind_DataGrid();
        }
        catch
        {
            try
            {
                DG_ResourcesLibrary.CurrentPageIndex = System.Convert.ToInt32(Session["pageno"]) - 1;
                Bind_DataGrid();
            }
            catch
            {
                Lblnorecords.Text = "No records found.";
                this.Lblnorecords.Visible = true;
                DG_ResourcesLibrary.Visible = false;
                Lbl_Pageinfo.Visible = false;
                //this.pnluser.Visible = false;
            }
        }
    }
    private void Bind_DataGrid()
    {


        Page.Validate();
        if (Page.IsValid)
        {

            objDTO.Sort_On = "";
            objDTO.Sort_Direction = "";
            if (ViewState["Sort_On"] != null)
            {
                objDTO.Sort_On = ViewState["Sort_On"].ToString() + " " + ViewState["Sort_By"].ToString();
                //objRegs.Sort_Direction = ViewState["Sort_By"].ToString();
            }
            Lblnorecords.Visible = false;
            objDTO.Name = txtName.Text.ToString();
            objDTO.EmailID = txtEmailAddress.Text.ToString();
            objDTO.CompanyNm = txtCompanyName.Text.ToString();
            objDTO.Status = ddlStatus.SelectedItem.Text.ToString();
            objDTO.IndustryID = Convert.ToInt32(ddlIndustry.SelectedItem.Value);
            ds_Search = objRegs.GetAllUsers(objDTO);
            ViewState["dsData"] = ds_Search;
            if (ds_Search.Tables[0].Rows.Count > 0)
            {

                DG_ResourcesLibrary.Visible = true;
               // id_btn_Delete.Visible = true;
                // Button_New.Visible = true;
                Lblnorecords.Visible = false;
                //ChkAll.Visible = true ;
                spSelect.Visible = true;
                ExporttoExcel.Visible = true;

            }
            else
            {
                DG_ResourcesLibrary.Visible = false;
                //id_btn_Delete.Visible = false;
                Lblnorecords.Visible = true;
                Lblnorecords.Text = "No data available.";
                //ChkAll.Visible = false;
                spSelect.Visible = false;
                ExporttoExcel.Visible = false;
                

                // Button_New.Visible = true;
                //pnluser.Visible = false;
            }
            if (this.Txt_Page_Size.Text != "")
            {
                if (System.Convert.ToInt32(this.Txt_Page_Size.Text) > 0)
                {
                    this.DG_ResourcesLibrary.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
                }
            }
            else
            {
                this.Txt_Page_Size.Text = CommonFunctions.Get_Page_Size(Session["fid"].ToString()).ToString();
                this.DG_ResourcesLibrary.PageSize = System.Convert.ToInt32(this.Txt_Page_Size.Text);
            }

            DG_ResourcesLibrary.DataSource = ds_Search;
            DG_ResourcesLibrary.DataBind();
            DG_Export.DataSource = ds_Search;
            DG_Export.DataBind();
            if (ds_Search.Tables[0].Rows.Count == 0)
            {
                this.Lbl_Pageinfo.Visible = false;
            }
            else
            {
                Int16 intTo;
                Int16 intFrom;
                if (DG_ResourcesLibrary.PageSize * (DG_ResourcesLibrary.CurrentPageIndex + 1) < ds_Search.Tables[0].Rows.Count)
                {
                    intTo = System.Convert.ToInt16(DG_ResourcesLibrary.PageSize * (DG_ResourcesLibrary.CurrentPageIndex + 1));
                }
                else
                {
                    intTo = System.Convert.ToInt16(ds_Search.Tables[0].Rows.Count);
                }
                intFrom = System.Convert.ToInt16((DG_ResourcesLibrary.PageSize * DG_ResourcesLibrary.CurrentPageIndex) + 1);
                this.Lbl_Pageinfo.Text = "Record(s) " + intFrom + " to " + intTo + " of " + ds_Search.Tables[0].Rows.Count;
                this.Lbl_Pageinfo.Visible = true;
            }
            index = System.Convert.ToInt16((DG_ResourcesLibrary.PageSize * DG_ResourcesLibrary.CurrentPageIndex));
        }
        //ds_Search = null;

    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            this.DG_ResourcesLibrary.CurrentPageIndex = 0;
            Bind_DataGrid();
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }
    }

    protected void DG_ResourcesLibrary_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        if (ViewState["Sort_On"] != null)
            //obj_RLDetails.SortOn = ViewState["Sort_On"].ToString();
        DG_ResourcesLibrary.CurrentPageIndex = e.NewPageIndex;
        ViewState["currentPagNo"] = e.NewPageIndex;
        Bind_Data();
        ViewState["page_no"] = DG_ResourcesLibrary.CurrentPageIndex;
    }

    protected void DG_ResourcesLibrary_ItemCreated(object sender, DataGridItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Pager)
            {
                TableCell pager = (TableCell)e.Item.Controls[0];
                int i;
                Label l;
                LinkButton h;
                for (i = 0; i < pager.Controls.Count; i += 2)
                {
                    try
                    {
                        l = (Label)pager.Controls[i];
                        if (i == 0)
                            l.Text = "Page(s) " + l.Text;
                    }
                    catch
                    {
                        h = (LinkButton)pager.Controls[i];
                        if (i == 0)
                            h.Text = "Page(s) " + h.Text;
                    }
                }
            }
        }
        catch
        { }
    }

  

    protected void id_btn_Delete_Click(object sender, ImageClickEventArgs e)
     {
         if (Request["Cbx_uid"] == null)
         {
             this.Lblnorecords.Text = "Please select at least one record to delete.";
             this.Lblnorecords.Visible = true;
         }
         else
         {
             string[] _UsersArr = Request["Cbx_uid"].Split(',');
             string _users = "";
             for (int i = 0; i < _UsersArr.Length; i++)
             {
                 _users = _users + ",'" + _UsersArr[i].ToString() + "'";
             }
             if (_users != "")
                 _users = _users.Remove(0, 1);
             objRegs.Delete_Record_UserDetails(_users);

             string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
             this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) has been deleted Successfully.'); location='" + _redirectPath + "';</Script>");
             Bind_DataGrid();
         }

    }

    protected void BtnResend_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton BtnResend = (ImageButton)sender;
            if (BtnResend != null)
            {
                string strUID = BtnResend.CommandArgument.ToString();
                ABSBLL.Registration objRegs = new ABSBLL.Registration();
                DataSet dsUser = objRegs.GetUserDetails(strUID, "", "userid");
                if (dsUser != null && dsUser.Tables.Count > 0)
                {
                    if (dsUser.Tables[0].Rows.Count > 0)
                    {
                        string str = Request.Url.ToString();
                        //int startindex = str.ToLower().IndexOf("ABS");
                        //string sub = str.Substring(0, startindex);
                        string sub = str.Replace("Administration/PublicUsersList_Search.aspx", "Public/RegsAccessActivation.aspx?UID=" + strUID);

                        Dictionary<string, string> tempValue = new Dictionary<string, string>();
                        string strMapPath = ConfigurationManager.AppSettings["AdminNotificationMailHtml"];
                        string strToMail = dsUser.Tables[0].Rows[0]["EmailID"].ToString();
                        string strGivenName = dsUser.Tables[0].Rows[0]["Name"].ToString();
                        tempValue["<!--GivenName-->"] = strGivenName;
                        tempValue["<!--URLPart-->"] = "<a href='" + sub + "'>" + sub + "</a> ";
                        tempValue["<!--ActCode-->"] = dsUser.Tables[0].Rows[0]["ActivationKey"].ToString();

                        string path = Server.MapPath(strMapPath);
                        HTMLParser htmlParser = new HTMLParser();
                        string strBody = htmlParser.getBody("ACK", tempValue, path);

                        // Code to send Notification Mail
                        string subject = "Welcome to ABS";
                        MailManager objMailManager = new MailManager();
                        objMailManager.sendNotificationMail(strToMail, strGivenName, strBody, subject);
                        // End Code

                        ABSCommon.Common.ShowMessage(this, "Mail sent successfully");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }
    }


    

    protected void ExportToExcel()
    {

        Response.Clear();

        Response.AddHeader("content-disposition", "attachment;filename=MemberListDetails.xls");

        Response.Charset = "";

        // If you want the option to open the Excel file without saving than

        // comment out the line below

        // Response.Cache.SetCacheability(HttpCacheability.NoCache);

        Response.ContentType = "application/vnd.xlsx";
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

       DG_Export.RenderControl(htmlWrite);     //throwing error

        Response.Write(stringWrite.ToString());

        Response.End();
    }

    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
        //for exporttoexcel to work....we have to put define this method.
        // Confirms that an HtmlForm control is rendered for the
        // specified ASP.NET server control at run time.


    }

    protected string getEditProfilePage()
    {

        string str = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["UserID"].ToString());
            str = Server.UrlEncode(str);

        }
        index = index + 1;
        return str;

    }
    protected void ExporttoExcel_Click(object sender, ImageClickEventArgs e)
    {
        if (DG_Export.Items.Count > 0)
            ExportToExcel();
    }

    public void ChangeDGPAGE(object objSender, DataGridPageChangedEventArgs objArgs)
    {
        if (ViewState["Sort_On"] != null)
            objDTO.Sort_On = ViewState["Sort_On"].ToString();


        DG_ResourcesLibrary.CurrentPageIndex = objArgs.NewPageIndex;
        Bind_DataGrid();
        Session["pageno"] = DG_ResourcesLibrary.CurrentPageIndex;
    }
    protected void DG_ResourcesLibrary_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
        objDTO.Sort_On = e.SortExpression;

        ViewState["Sort_On"] = objDTO.Sort_On;
        if (ViewState["Sort_By"] == null)
            ViewState["Sort_By"] = "Asc";
        if (ViewState["Sort_By"].ToString() == "Asc")
        {
            ViewState["Sort_By"] = "Desc";
        }
        else
        {
            ViewState["Sort_By"] = "Asc";
        }

        Bind_DataGrid();
        Session["page_no"] = DG_ResourcesLibrary.CurrentPageIndex;
    }
}