using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSCommon;
using ABSDTO;
using System.Data;
using System.Globalization;
using System.Threading;

public partial class Public_RegsAccessActivation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["UID"] != null)
                {
                    tbActive.Visible = false;
                    tbError.Visible = false;
                    if (CommonBindings.IsGuid(Request.QueryString["UID"].ToString()))
                    {
                        ABSBLL.Registration objRegs = new ABSBLL.Registration();
                        string strUserStatus = objRegs.GetUserStatusbyUserID(Request.QueryString["UID"].ToString());
                        if (!string.IsNullOrEmpty(strUserStatus))
                        {
                            string strAlert = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text")); 
                            if (strUserStatus.ToLower() == "completed")
                                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "javascript:alert('" + strAlert + "',window.location('../Default.aspx'))", true);
                        }
                        else
                        {
                            tbActiveCode.Visible = false;
                            tbError.Visible = true;
                        }
                    }
                    else
                        Response.Redirect("~/Error_Page.aspx");
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this, ex);
            }
        }
    }
    protected void btnActivation_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["UID"] != null)
            {
                string strUID = Request.QueryString["UID"].ToString();
                if (CommonBindings.IsGuid(strUID) && CommonBindings.IsGuid(txtActivationCode.Text.Trim()))
                {
                    ABSBLL.Registration objRegs = new ABSBLL.Registration();
                    DataSet dsUser = objRegs.GetUserDetails(strUID, txtActivationCode.Text.Trim(), "activationkey");
                    if (dsUser != null && dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows.Count > 0)
                    {
                        if (txtActivationCode.Text.Trim() == dsUser.Tables[0].Rows[0]["ActivationKey"].ToString())
                        {
                            RegistrationDTO objDTO = new RegistrationDTO();
                            objDTO.ActivationKey = txtActivationCode.Text;
                            objDTO.Status = "Completed";
                            objDTO.Action = "Activation";
                            // Updating the user status as 'Completed' so that user can log in to the system
                            objRegs.UpdateUserStatus(objDTO);
                            txtActivationCode.Text = string.Empty;
                            tbActive.Visible = true;
                            tbActiveCode.Visible = false;
                            Response.Redirect("~/Default.aspx");
                        }
                    }
                    else
                    {
                        string strMsg = Convert.ToString(GetLocalResourceObject("lbllblDes2Resource1.Text"));
                        txtActivationCode.Text = string.Empty;
                        Common.ShowMessage(this, strMsg);
                    }
                }
                else
                    Response.Redirect("~/Error_Page.aspx");
            }
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }
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