using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSCommon;
using System.Web.Security;
using ABSDTO;
using ABSBLL;
using System.Data;
using System.Configuration;
using ABSSecurity;


using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Globalization;
using System.Threading;
public partial class _Default : System.Web.UI.Page
{
    public string BannerImages = string.Empty;
    public string navigation = string.Empty;
    public string AdBanners = string.Empty;
    public string Adnavigation = string.Empty;


    public string FooterBanner = string.Empty;
    public string RHSBanner = string.Empty;

    string imgsrc = string.Empty;
    string Adimgsrc = string.Empty;

    BannerDetails objGet = new BannerDetails();
    string TopBanner = string.Empty;
    string Banner2 = string.Empty;
    string Banner3 = string.Empty;
    string Banner4 = string.Empty;
    string Banner5 = string.Empty;

    string RHSBanner7 = string.Empty;
    string AddBanner = string.Empty;
    string TopBannerURl = string.Empty;
    string BannerURL2 = string.Empty;
    string BannerURL3 = string.Empty;
    string BannerURL4 = string.Empty;
    string BannerURL5 = string.Empty;

    string RHSBannerURL7 = string.Empty;
    string AddBannerURL = string.Empty;



    string AdBanner1 = string.Empty;
    string AdBannerURL1 = string.Empty;
    string AdBanner2 = string.Empty;
    string AdBannerURL2 = string.Empty;
    string AdBanner3 = string.Empty;
    string AdBannerURL3 = string.Empty;
    string AdBanner4 = string.Empty;
    string AdBannerURL4 = string.Empty;



    string _imagelink = "<li id=\"{0}\"><a href={1} ><img border=0 src=\"{2}\" alt=\"\" /></a></li>";

    string _Adimagelink = "<a href=\"{0}\" class=\"show\" target=\"{1}\"><img src=\"{2}\" width=\"580\" height=\"120\" title=\"\" alt=\"\" rel=\"\"/></a>";
    string __Adimagelink_All = "<a href=\"{0}\" class=\"\" target=\"{1}\"><img src=\"{2}\" width=\"580\" height=\"120\" title=\"\" alt=\"\" rel=\"\"/></a>";
    // string _strFormat_First = "<a href=\"{0}\" class=\"show\"><img src=\"{1}\" width=\"580\" height=\"120\" title=\"\" alt=\"\" rel=\"\"/></a>";
    // string _strFormat_All = "<a href=\"{0}\" class=\"\"><img src=\"{1}\" width=\"580\" height=\"120\" title=\"\" alt=\"\" rel=\"\"/></a>";


    // string _Adimagelink = "<li id=\"{0}\"><a href={1} ><img border=0 src=\"{2}\" alt=\"\" /></a></li>";
    string _RHSBannerimagelink = "<li id=\"{0}\" ><a href={1} ><img border=0 src=\"{2}\" alt=\"\" width=\"251px\" height=\"144px\"  /></a></li>";
    Security objSecurity = new Security();

    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            Session.Remove("LoginDTO");
            if (!IsPostBack)
            {
                HideCaptcha.Visible = false;
                // Clears all sessions through out the application
                //Session.Abandon();
                //  
                //if (Session["LoginDTO"] != null)
                //{
                //    string redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + "Public/DashBoard.aspx";
                //    Response.Redirect(redirectPath);
                //}
                FormsAuthentication.SignOut();
                clearCookies(this);
                txtUsername.Focus();
                Getdata();

            }
            else
                Getdata();

            string strURL = Convert.ToString(GetLocalResourceObject("lblFakeResource1.Text"));

            string URL = ConfigurationManager.AppSettings["InternalUrl"] + "TermsConditions.aspx";

            if (Convert.ToString(Session["Culture"]) != "zh-SG")
                lblParaWithLink.Text = "This tool is provided free-of-charge but one-time registration with a valid email address is required. Please read the <a href=\"#\" class=\"more\" onclick=\"mypopup('TermsConditions.aspx')\">Terms of Use and Privacy Notice</a>  should you wish to use this Toolkit.";
            else
                lblParaWithLink.Text = "此工具供您免费使用，但需要进行一次性注册并且附上有效的电邮地址。如果您想要使用本工具箱，请阅读 <a href=\"#\" class=\"more\" onclick=\"mypopup('TermsConditions.aspx')\">《使用条款》与《隐私声明》</a>。";



            // lblParaWithLink.Text = Convert.ToString(GetLocalResourceObject("lblParaWithLinkResource1.Text"));
            //lblParaWithLink.Text = "This tool is provided free-of-charge but one-time registration with a valid email address is required. Please read the <a href=\"#\" class='footer_link' Title='Terms of Use and Privacy Notice' onclick=\"return javascript:mypopup('TermsConditions.aspx'); return false;\">Terms of Use and Privacy Notice</a>  should you wish to use this Toolkit.";
            //lblParaWithLink.Text = "<a href=\"#\" class='footer_link' Title='Terms of Use and Privacy Notice' onclick=\"return javascript:<script type='text/javascript'>mypopup()</script>; return false;\">Terms of Use and Privacy Notice</a>";
            //lblParaWithLink.Text = "<a href=\"#\" onclick=\"window.open('TermsConditions.aspx', 'newwindow', 'width=830,height=420'); return false;\">Open new window.</a>";

            //lblParaWithLink.Text = "you are indicating that you have read and agree to the Law Society <a href=\"#\" class=\"more\" onclick=\"mypopup('TermsConditions.aspx')\">Terms of Use and Privacy Notice</a>";


            imgRegister.Src = strURL;

        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }
    }
    /// <summary>
    /// Method to clear Cookies
    /// </summary>
    /// <param name="pageObj"></param>
    public void clearCookies(Page pageObj)
    {
        pageObj.Response.Cache.SetAllowResponseInBrowserHistory(false);
        pageObj.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        pageObj.Response.Cache.SetAllowResponseInBrowserHistory(false);
        pageObj.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        pageObj.Response.Cache.SetExpires(DateTime.Now - new TimeSpan(1, 0, 0));//Parse("6:00:00PM"));
        pageObj.Response.Cache.SetLastModified(DateTime.Now);
        pageObj.Response.Cache.SetAllowResponseInBrowserHistory(false);
        pageObj.Response.Expires = -1000;
        pageObj.Response.Cache.SetNoServerCaching();
        pageObj.Response.Cache.SetNoStore();
        pageObj.Response.Cache.SetMaxAge(TimeSpan.Zero);
        pageObj.Response.AppendHeader("Pragma", "no-cache");
        pageObj.Response.CacheControl = "";
        pageObj.Response.Buffer = true;
    }

    /// <summary>
    /// Event which allows user to login with valid credentials
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLogin_Click(object sender, EventArgs e)
    {
       //string DecryptPassword = objSecurity.Decrypt(txtUsername.Text);
        try
        {
            if (Session["LoginsessionID"] == null)
            {
                Guid LoginsessionID;
                LoginsessionID = Guid.NewGuid();
                Session["LoginsessionID"] = LoginsessionID;
            }
            if (ViewState["CheckCaptcha"] != null)
                if (ViewState["CheckCaptcha"].ToString().Equals("YES"))
                {
                    ccCorporateCaptcha.ValidateCaptcha(txtCaptcha.Text.Trim());
                    if (!ccCorporateCaptcha.UserValidated)
                    {
                        string strAlert = Convert.ToString(GetLocalResourceObject("lblDes1Resource1.Text"));
                        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('" + strAlert + "');  </Script>");
                        txtCaptcha.Text = string.Empty;
                        return;
                    }
                }
            RegistrationDTO objDTOLogin = new RegistrationDTO();
            objDTOLogin.EmailID = txtUsername.Text;
            objDTOLogin.Password = objSecurity.Encrypt(txtPassword.Text);
            objDTOLogin.LoginsessionID = Session["LoginsessionID"].ToString();
            ABSBLL.Registration objRegs = new ABSBLL.Registration();
            LoginDTO objDTO = new LoginDTO();
            objDTO = objRegs.CheckUser(objDTOLogin);

            DataSet DS = new DataSet();

            if (objDTO.EmailID != null)
            {
                Session["UserName"] = objDTO.Name;
                if (objDTO.Status.ToLower() == "pending")
                {
                    string redirectPath = ConfigurationManager.AppSettings["InternalUrl"];
                    Response.Redirect(redirectPath + "Public/RegistrationAccess.aspx?UID=" + objDTO.UserID + "", false);
                }
                else if (objDTO.Status.ToLower() == "disagree")
                {
                    string redirectPath = ConfigurationManager.AppSettings["InternalUrl"];
                    Response.Redirect(redirectPath + "Public/RegistrationAccess.aspx?UID=" + objDTO.UserID + "", false);
                }
                else if (objDTO.Status.ToLower() == "completed")
                {
                    // LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                    Session["EmailID"] = txtUsername.Text;
                    FormsAuthentication.Initialize();
                    FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1,
                        txtUsername.Text, DateTime.Now,
                        DateTime.Now.AddMinutes(15), false,
                        FormsAuthentication.FormsCookiePath);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(fat)));

                    objDTO.Flag = "Insert";
                    Session["LoginDTO"] = objDTO;
                    MaintainUserLogDetails(objDTO);
                    Session["USER_ID"] = objDTO.Name;
                    Session["USER_GUID"] = objDTO.UserID;
                    //  Session["Culture"] = "zh-SG";

                    //Response.Redirect("Public/Main.aspx");

                    string redirectPath = ConfigurationManager.AppSettings["InternalUrl"];
                    Response.Redirect(redirectPath + "Public/Dashboard.aspx", false);
                }
            }
            else
            {
                string strMsg = Convert.ToString(GetLocalResourceObject("lblDes3Resource1.Text"));
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
                Common.ShowMessage(this, strMsg);

                if (objDTO.Wrongstatus == "1")
                {
                    ViewState["CheckCaptcha"] = "YES";
                    HideCaptcha.Visible = true;
                }
                else
                {
                    ViewState["CheckCaptcha"] = "NO";
                }

            }
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }
    }

    /// <summary>
    /// Method to maintain User Log Details in [tbl_UserLogs]
    /// </summary>
    /// <param name="objDTO"></param>
    private void MaintainUserLogDetails(LoginDTO objDTO)
    {
        try
        {
            ABSBLL.Registration objRegs = new ABSBLL.Registration();
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                objDTO.Culture = 2;
            else
                objDTO.Culture = 1;
            int LogId = objRegs.InsertUserLogs(objDTO);
            Session["LogId"] = LogId;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Getdata()
    {
        int count = 0;
        if (Convert.ToString(Session["Culture"]) == "")
            objGet.Culture = "en-us";
        else
            objGet.Culture = Convert.ToString(Session["Culture"]);

        DataSet dsBanner = objGet.GetBannerDetails_Culture(objGet);

        if (dsBanner.Tables[0].Rows.Count > 0)
        {
            TopBanner = dsBanner.Tables[0].Rows[0][1].ToString();
            TopBannerURl = dsBanner.Tables[0].Rows[0][2].ToString();
            Banner2 = dsBanner.Tables[0].Rows[0][3].ToString();
            BannerURL2 = dsBanner.Tables[0].Rows[0][4].ToString();
            Banner3 = dsBanner.Tables[0].Rows[0][5].ToString();
            BannerURL3 = dsBanner.Tables[0].Rows[0][6].ToString();
            Banner4 = dsBanner.Tables[0].Rows[0][7].ToString();
            BannerURL4 = dsBanner.Tables[0].Rows[0][8].ToString();
            Banner5 = dsBanner.Tables[0].Rows[0][9].ToString();
            BannerURL5 = dsBanner.Tables[0].Rows[0][10].ToString();
            RHSBanner7 = dsBanner.Tables[0].Rows[0][11].ToString();
            RHSBannerURL7 = dsBanner.Tables[0].Rows[0][12].ToString();


            AdBanner1 = dsBanner.Tables[0].Rows[0][21].ToString();
            AdBannerURL1 = (dsBanner.Tables[0].Rows[0][22].ToString() == "") ? "#" : dsBanner.Tables[0].Rows[0][22].ToString();
            AdBanner2 = dsBanner.Tables[0].Rows[0][23].ToString();
            AdBannerURL2 = (dsBanner.Tables[0].Rows[0][24].ToString() == "") ? "#" : dsBanner.Tables[0].Rows[0][24].ToString();
            //AdBanner3 = dsBanner.Tables[0].Rows[0][25].ToString();
            //AdBannerURL3 = (dsBanner.Tables[0].Rows[0][26].ToString() == "") ? "#" : dsBanner.Tables[0].Rows[0][26].ToString();
            AdBanner4 = dsBanner.Tables[0].Rows[0][27].ToString();
            AdBannerURL4 = (dsBanner.Tables[0].Rows[0][28].ToString() == "") ? "#" : dsBanner.Tables[0].Rows[0][28].ToString();
        }

        if (TopBanner != "")
        {
            imgsrc = string.Format(_imagelink, "content", TopBannerURl, "BannerImages/" + TopBanner);
            BannerImages += imgsrc;
            navigation += "<li onclick=\"slideshow.pos(0)\"></li>";
        }
        if (Banner2 != "")
        {
            imgsrc = string.Format(_imagelink, "content", BannerURL2, "BannerImages/" + Banner2);
            BannerImages += imgsrc;
            navigation += "<li onclick=\"slideshow.pos(1)\"></li>";
        }
        if (Banner3 != "")
        {
            imgsrc = string.Format(_imagelink, "content", BannerURL3, "BannerImages/" + Banner3);
            BannerImages += imgsrc;
            navigation += "<li onclick=\"slideshow.pos(2)\"></li>";
        }
        if (Banner4 != "")
        {
            imgsrc = string.Format(_imagelink, "content", BannerURL4, "BannerImages/" + Banner4);
            BannerImages += imgsrc;
            navigation += "<li onclick=\"slideshow.pos(3)\"></li>";
        }
        if (Banner5 != "")
        {
            imgsrc = string.Format(_imagelink, "content", BannerURL5, "BannerImages/" + Banner5);
            BannerImages += imgsrc;
            navigation += "<li onclick=\"slideshow.pos(4)\"></li>";
        }
        if (RHSBanner7 != "")
        {
            hypRHS.NavigateUrl = RHSBannerURL7;
            imgRHS.ImageUrl = "~/BannerImages/" + RHSBanner7;
        }

        if (AdBanner1 != "")
        {
            count = count + 1;
            if (AdBannerURL1 == "#")
                Adimgsrc = string.Format(_Adimagelink, AdBannerURL1, "_self", "BannerImages/" + AdBanner1);
            else
                Adimgsrc = string.Format(_Adimagelink, AdBannerURL1, "_blank", "BannerImages/" + AdBanner1);
            AdBanners += Adimgsrc;
        }
        if (AdBanner2 != "")
        {
            count = count + 1;
            if (AdBannerURL2 == "#")
                Adimgsrc = string.Format(__Adimagelink_All, AdBannerURL2, "_self", "BannerImages/" + AdBanner2);
            else
                Adimgsrc = string.Format(__Adimagelink_All, AdBannerURL2, "_blank", "BannerImages/" + AdBanner2);
            AdBanners += Adimgsrc;
        }
        if (AdBanner3 != "")
        {
            count = count + 1;
            if (AdBannerURL3 == "#")
                Adimgsrc = string.Format(__Adimagelink_All, AdBannerURL3, "_self", "BannerImages/" + AdBanner3);
            else
                Adimgsrc = string.Format(__Adimagelink_All, AdBannerURL3, "_blank", "BannerImages/" + AdBanner3);

            AdBanners += Adimgsrc;
        }
        if (AdBanner4 != "")
        {
            count = count + 1;
            if (AdBannerURL4 == "#")
                Adimgsrc = string.Format(__Adimagelink_All, AdBannerURL4, "_self", "BannerImages/" + AdBanner4);
            else
                Adimgsrc = string.Format(__Adimagelink_All, AdBannerURL4, "_blank", "BannerImages/" + AdBanner4);
            AdBanners += Adimgsrc;
        }
        if (count == 1)
        {
            if (AdBannerURL1 == "#")
                Adimgsrc = string.Format(_Adimagelink, AdBannerURL1, "_self", "BannerImages/" + AdBanner1);
            else
                Adimgsrc = string.Format(_Adimagelink, AdBannerURL1, "_blank", "BannerImages/" + AdBanner1);
            AdBanners += Adimgsrc;
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