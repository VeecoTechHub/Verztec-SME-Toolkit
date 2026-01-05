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


public partial class Public_CourseRegistration : System.Web.UI.Page
{
    string NS_ID = string.Empty;
    string CID1 = string.Empty;
    private CourseRegistration obj_CourseRegs = new CourseRegistration();
    CommonFunctions commonFunctions = new CommonFunctions();
    UserMgmt objUserMgmt = new UserMgmt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["NS_ID"] != null && Request.QueryString["CID"] != null)
            {
                NS_ID = commonFunctions.Decrypt(Request.QueryString["NS_ID"]);
                CID1 = commonFunctions.Decrypt(Request.QueryString["CID"]);
                BindData(NS_ID);
                ViewState["NS_ID"] = NS_ID;
                ViewState["CID"] = CID1;

            
            }
            if (Session["LoginDTO"] == null)
            {
                Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
            }
            else
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                txtEmail.Text = objLoginDTO.EmailID;
            }
        }

    }
    public void BindData(string cid)
    {
        try
        {
            DataSet ds = obj_CourseRegs.Get_CourseDetailsById(cid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCourseTitle.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["Category_Title"].ToString());
                lbl_DurationFrom.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["Duration_From"].ToString());
                lbl_DurationTo.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["Duration_To"].ToString());
            }
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                string cint = ViewState["NS_ID"].ToString();
                int identcid = obj_CourseRegs.getCid(cint);
                obj_CourseRegs.UserID = Guid.NewGuid().ToString();
                obj_CourseRegs.Name = txtName.Text.ToString();
                obj_CourseRegs.NRIC_ID_Number = txtNRICNo.Text.ToString();
                obj_CourseRegs.Contact_Number = txtContactNumber.Text.Trim();
                obj_CourseRegs.EmailID = txtEmail.Text.Trim();
                obj_CourseRegs.CreatedOn = DateTime.Now;
                obj_CourseRegs.ActivationKey = Guid.NewGuid().ToString();
                obj_CourseRegs.CID = identcid;
                int UserID = obj_CourseRegs.InsertCourseRegistration(obj_CourseRegs);
                if (UserID == 1)
                {
                    DataSet dsUser = obj_CourseRegs.GetCourseRegistrationDetails(obj_CourseRegs.UserID);
                    if (dsUser != null && dsUser.Tables.Count > 0)
                    {
                        if (dsUser.Tables[0].Rows.Count > 0)
                        {
                            string str = Request.Url.ToString();
                            Dictionary<string, string> tempValue = new Dictionary<string, string>();
                            string strMapPath = ConfigurationManager.AppSettings["CourseRegistrationMailHtml"];
                            string strToMail = dsUser.Tables[0].Rows[0]["EmailID"].ToString();
                            string strGivenName = dsUser.Tables[0].Rows[0]["Name"].ToString();
                            string strTitle = dsUser.Tables[0].Rows[0]["Category_Title"].ToString();
                            string strDuarFrom = dsUser.Tables[0].Rows[0]["Duration_From"].ToString();
                            string strDuaTo = dsUser.Tables[0].Rows[0]["Duration_To"].ToString();
                            //DateTime dtpDurFrom = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["Duration_From"]);
                            //string strDuarFrom = dtpDurFrom.Day + "/" + dtpDurFrom.Month + "/" + dtpDurFrom.Year;
                            //DateTime dtpDurTo = Convert.ToDateTime(dsUser.Tables[0].Rows[0]["Duration_To"]);
                            //string strDuaTo = dtpDurTo.Day + "/" + dtpDurTo.Month + "/" + dtpDurTo.Year;
                            tempValue["<!--GivenName-->"] = strGivenName;
                            tempValue["<!--Title-->"] = strTitle;
                            tempValue["<!--DurationFrom-->"] = strDuarFrom;
                            tempValue["<!--DurationTo-->"] = strDuaTo;
                            tempValue["<!--ActCode-->"] = dsUser.Tables[0].Rows[0]["ActivationKey"].ToString();
                            string path = Server.MapPath(strMapPath);
                            HTMLParser htmlParser = new HTMLParser();
                            string strBody = htmlParser.getBody("ACK", tempValue, path);
                            // Code to send Course Registration Mail
                            MailManager objMailManager = new MailManager();
                            objMailManager.sendCourseRegistrationMail(strToMail, strGivenName, strBody);
                            // End Code
                            ClearData();

                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Registered Successfully...')</script>");
                        }
                    }
                }
                else if (UserID == 0)
                    Common.ShowMessage(this, " Registration Not Completed:");
            }
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Public/NextStep.aspx");
    }
    private void ClearData()
    {
        txtName.Text = "";
        txtNRICNo.Text = "";
        txtContactNumber.Text = "";
        txtEmail.Text = "";
    }

}