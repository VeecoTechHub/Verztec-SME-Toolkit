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
using System.Configuration;

public partial class Administration_Admin_AddNextSteps : System.Web.UI.Page
{
    CourseDetails obj_CDetails = new CourseDetails();
    Check_Access chkAccess = new Check_Access();
    string StrFileName = string.Empty;
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    int CID;
    CommonFunctions commonfunction = new CommonFunctions();
    public static string token;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);
      
            token = Request.Form["token"];
            ViewState["t_url"] = "Admin_NextSteps.aspx";
            if (token == null)
            {
                Response.Redirect("default.aspx");
            }

            else
            {

                Session["CID"] = "";
                BindCheckList();

                if (Request["IDforEdit"] != null && Request["IDforEdit"] !="" )
                {
                    CID = Convert.ToInt32(commonfunction.Decrypt(Request["IDforEdit"]));
                    Session["CID"] = CID;
                    Bind_Data_toTable(CID);
                    BindCheckListWithSel(CID);
                }
            }

        }
    }

    public void BindCheckList()
    {
        ds = obj_CDetails.CDetails_GetTagValues();
        id_cklist.DataSource = ds;
        id_cklist.DataTextField = "CourseName";
        id_cklist.DataValueField = "CourseID";
        id_cklist.DataBind();
    }

    public void Bind_Data_toTable(int CID)
    {
        obj_CDetails.CID = CID;
        ds1 = obj_CDetails.Get_CourseDetails_By_Id(CID);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            id_txt_AddTitle.Text = CommonBindings.TextToBind(ds1.Tables[0].Rows[0]["Category_Title"].ToString());
            id_txt_Faculty.Text = CommonBindings.TextToBind(ds1.Tables[0].Rows[0]["Faculty"].ToString());
            id_txt_AddDescription.Text = CommonBindings.TextToBind(ds1.Tables[0].Rows[0]["Description"].ToString());
            DatePicker_DurationFrom.DateString = CommonBindings.TextToBind(ds1.Tables[0].Rows[0]["Duration_From"].ToString());
            DatePicker_DurationTo.DateString = CommonBindings.TextToBind(ds1.Tables[0].Rows[0]["Duration_To"].ToString());
        }
    }


    public void BindCheckListWithSel(int CID)
    {
        obj_CDetails.CID = CID;
        ds = obj_CDetails.Get_Course_ById(CID);
        string[] strId = new string[5];
        int count = ds.Tables[0].Rows.Count;
        for (int Index = 0; Index < count; Index++)
        {
            string Id = ds.Tables[0].Rows[Index][0].ToString();
            id_cklist.Items.FindByValue(ds.Tables[0].Rows[Index][0].ToString()).Selected = true;
        }
    }
    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {
        int intCID;
        DateTime DurationFromDate = DateTime.Parse(DatePicker_DurationFrom.DateString);
        DateTime DurationToDate = DateTime.Parse(DatePicker_DurationTo.DateString);
        if (DateTime.Compare(DurationFromDate, DurationToDate) < 0)
        {
            if (Page.IsValid)
            {
                try
                {
                    obj_CDetails.Title = CommonBindings.TextToBind(id_txt_AddTitle.Text.ToString());
                    obj_CDetails.TitleID = Guid.NewGuid();
                    obj_CDetails.Faculty = CommonBindings.TextToBind(id_txt_Faculty.Text.ToString());
                    obj_CDetails.Description = CommonBindings.TextToBind(id_txt_AddDescription.Text.ToString());
                    obj_CDetails.Duration_From = Convert.ToDateTime(DatePicker_DurationFrom.DateString);
                    obj_CDetails.Duration_To = Convert.ToDateTime(DatePicker_DurationTo.DateString);
                    obj_CDetails.Created_By = Session["USER_NM"].ToString();
                    obj_CDetails.Created_On = DateTime.Now;
                    obj_CDetails.Updated_By = Session["USER_NM"].ToString();
                    obj_CDetails.Updated_On = DateTime.Now;
                    string strCID = Session["CID"].ToString();
                    if (strCID != "")
                        intCID = Convert.ToInt32(strCID);
                    else
                        intCID = 0;
                    if (intCID == 0)
                    {
                        obj_CDetails.CID = 0;
                        int ReturnId = obj_CDetails.Insert_CourseDetails(obj_CDetails);
                        obj_CDetails.ReturnId = ReturnId;
                        if (ReturnId > 0)
                        {
                            string[] strItems = new string[5];
                            int Index = 0;
                            foreach (ListItem listItems in id_cklist.Items)
                            {
                                if (listItems.Selected)
                                {

                                    obj_CDetails.tags[Index] = Convert.ToInt32(listItems.Value.ToString());
                                    strItems[Index] = obj_CDetails.tags[Index].ToString();
                                    obj_CDetails.CID = ReturnId;
                                    obj_CDetails.tagno = int.Parse(strItems[Index]);
                                    obj_CDetails.CDetails_Insert_TagDetails(obj_CDetails);
                                }
                                Index++;
                            }
                            //changes
                            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Record Saved Successfully.');</script>");
                            //ClearText();
                            string navurl = "Admin_NextSteps.aspx";
                            //string response = "<script type='text/javascript'>alert('Record added successfully');location.href='" + navurl + "';</script>";
                            //Response.Write(response);
                            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");

                        }
                        else
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Record Insert Failed.');</script>");
                    }
                    else
                    {
                        obj_CDetails.CID = intCID;
                        int ReturnId = obj_CDetails.Insert_CourseDetails(obj_CDetails);
                        if (ReturnId > 0)
                        {
                            obj_CDetails.CID = ReturnId;
                            obj_CDetails.CDetails_DeleteTagRow_ByID(obj_CDetails);
                            string[] strItems = new string[5];
                            int Index = 0;
                            foreach (ListItem listItems in id_cklist.Items)
                            {
                                if (listItems.Selected)
                                {
                                    obj_CDetails.tags[Index] = Convert.ToInt32(listItems.Value.ToString());
                                    strItems[Index] = obj_CDetails.tags[Index].ToString();
                                    obj_CDetails.CID = ReturnId;
                                    obj_CDetails.tagno = int.Parse(strItems[Index]);
                                    obj_CDetails.CDetails_Insert_TagDetails(obj_CDetails);
                                }
                                Index++;
                            }
                            //changes Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveSript", "SuccessRegister();", true);
                            //string navurl = "Admin_NextSteps.aspx";
                            //string response = "<script type='text/javascript'>alert('Record added successfully');location.href='" + navurl + "';</script>";
                            //Response.Write(response);
                            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");

                        }
                    }
                }
                catch (Exception ex)
                {
                    ABSCommon.Common.ErrorMessage(this, ex);
                }
            }
        }
        else
        {
            DatePicker_DurationTo.Reset();
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('DurationFrom Date cannot be greater than DurationTo Date.');</script>");
        }
    }
    public void ClearText()
    {
        id_txt_AddTitle.Text = "";
        id_txt_Faculty.Text = "";
        id_cklist.ClearSelection();
        id_txt_AddDescription.Text = "";
        DatePicker_DurationFrom.Reset();
        DatePicker_DurationTo.Reset();
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        ClearText();
    }
    protected void btnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Administration/Admin_NextSteps.aspx");
    }

}