using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using ABSDTO;
using ABSCommon;
using System.Configuration;
using ABSSecurity;
using System.Globalization;
using System.Threading;

public partial class Public_ResetPassword : System.Web.UI.Page
{
    ForgotPassword obj_FGPwd = new ForgotPassword();
    Security objSecurity = new Security();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnActivation_Click(object sender, EventArgs e)
    {
        try
        {

            string strActID = txtActivationCode.Text.ToString();
            if (CommonBindings.IsGuid(strActID))
            {
                obj_FGPwd.ActivationID = txtActivationCode.Text;
                DataSet ds_GetActKey = obj_FGPwd.GetForgotPwdDtlsbyAcctKey(obj_FGPwd);
                if (ds_GetActKey.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds_GetActKey.Tables[0].Rows[0]["ErrCode"]) == 0)
                    {
                        if (txtActivationCode.Text.ToString() == ds_GetActKey.Tables[0].Rows[0]["ActivationId"].ToString())
                        {
                            tbActive.Visible = true;
                            tbError.Visible = false;
                            tbExpire.Visible = false;
                            tbActiveCode.Visible = false;
                            ViewState["UserID"] = ds_GetActKey.Tables[0].Rows[0]["UserID"].ToString();
                        }
                        else
                        {
                            txtActivationCode.Text = "";
                            tbError.Visible = true;
                        }

                      
                    }
                    else
                    {
                        tbExpire.Visible = true;
                        tbActive.Visible = false;
                        tbActiveCode.Visible = true;
                        txtActivationCode.Text = "";
                    }
                  


                        //ViewState["UserID"] = ds_GetActKey.Tables[0].Rows[0]["UserID"].ToString();
                        //if (obj_FGPwd.ExpiryDate >= DateTime.Now.Date)
                        //{
                        //    if (txtActivationCode.Text.ToString() == ds_GetActKey.Tables[0].Rows[0]["ActivationId"].ToString())
                        //    {
                        //        tbActive.Visible = true;
                        //        tbError.Visible = false;
                        //        tbExpire.Visible = false;
                        //        tbActiveCode.Visible = false;
                        //    }
                        //    else
                        //    {
                        //        txtActivationCode.Text = "";
                        //        tbError.Visible = true;
                        //    }
                          
                        //}
                        //else
                        //{
                        //    tbExpire.Visible = true;
                        //    tbActive.Visible = false;
                        //    tbActiveCode.Visible = true;
                        //    txtActivationCode.Text = "";
                        //}
                    
                }
                else
                {
                    txtActivationCode.Text = "";
                    tbError.Visible = true;
                }


            }
            else
            {
                txtActivationCode.Text = "";
                tbError.Visible = true;
                tbActive.Visible = false;
                tbActiveCode.Visible = true;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            string strMsg = Convert.ToString(GetLocalResourceObject("lblMsgResource1.Text"));
            obj_FGPwd.UserID = ViewState["UserID"].ToString();
            obj_FGPwd.Password = objSecurity.Encrypt(txtPassword.Text.ToString());
            int output = obj_FGPwd.UpdateUserPwdbyUserID(obj_FGPwd);
            if (output == 1)
            {
                string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "Default.aspx";
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strMsg + "'); location='" + _redirectPath + "';</Script>");
               
            }           
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected override void InitializeCulture()
    {
        string culture = string.Empty;
        culture = Convert.ToString(Session["Culture"]);
        if (culture != "Auto")
        {
            CultureInfo ci = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            //Get Browser Language

            //string browserLanguage = Request.UserLanguages[0];
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(browserLanguage);
            //string s=Thread.CurrentThread.CurrentCulture.DisplayName;
        }

    }
}