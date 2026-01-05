using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ABSBLL;
using ABSDTO;
using System.Configuration;
using ABSCommon;
using System.Globalization;
using System.Threading;
public partial class Public_Dashboard : BasePage
{
    FeedBack obj_Feedback = new FeedBack();
    ABSBLL.Registration objRegs = new ABSBLL.Registration();
    RegistrationDTO objDTO = new RegistrationDTO();
    UserMgmt objUserMgmt = new UserMgmt();
    BannerDetails objGet = new BannerDetails();

    static bool flag = false;

    public string FooterBanners = string.Empty;
    public string Footernavigation = string.Empty;

    string Footerimgsrc = string.Empty;


    string FooterBanner1 = string.Empty;
    string FooterBannerURL1 = string.Empty;
    string FooterBanner2 = string.Empty;
    string FooterBannerURL2 = string.Empty;
    string FooterBanner3 = string.Empty;
    string FooterBannerURL3 = string.Empty;
    string FooterBanner4 = string.Empty;
    string FooterBannerURL4 = string.Empty;

    string _Footerimagelink = "<a href=\"{0}\" class=\"show\" target=\"{1}\"><img src=\"{2}\" width=\"829\" height=\"125\" title=\"\" alt=\"\" rel=\"\"/></a>";
    string __Footerimage_All = "<a href=\"{0}\" class=\"\" target=\"{1}\"><img src=\"{2}\" width=\"829\" height=\"125\" title=\"\" alt=\"\" rel=\"\"/></a>";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
        else
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];


            ////
            //// ateeq 20sept when logout.....
            Common objCommon = new Common();

            if (objCommon.CheckFeedback(objLoginDTO.UserID))
            {
                string strReferURL = Request.UrlReferrer.ToString();
                string strReferPath = Request.Path.ToString();

                string subpath = strReferURL.Substring(strReferURL.Length - 12);

                if (subpath.ToLower().Equals("reports.aspx"))
                {
                    Session["isRedirect"] = "YES";
                    Session["IsSkip"] = "NO";
                    Session["RedirectURL"] = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "/Public/Dashboard.aspx";
                    Session["RedirectLogout"] = "NO";
                    Response.Redirect("~/Public/FMFeedback.aspx", false);
                    return;
                }

            }



            objDTO.EmailID = objLoginDTO.EmailID;
            ViewState["UserID"] = objLoginDTO.UserID;
            ViewState["UserName"] = objLoginDTO.Name;
            ViewState["MailId"] = objLoginDTO.EmailID;
            ViewState["IndustryId"] = objLoginDTO.IndustryID;
        }
        //objDTO.EmailID = Session["EmailID"].ToString();

        if (!IsPostBack)
        {

            int i = objRegs.Get_VisitStatus(objDTO);
            if (i == 1)
            {
                Session["show"] = "no";
            }
            else
            {
                if (Session["isClosed"] == null)
                {
                    Session["show"] = "yes";
                }
                else
                {
                    Session["show"] = "no";
                }
            }
         

            Getdata();
            hideImages();
        }

        string strURL1 = Convert.ToString(GetLocalResourceObject("lblFintoolResource1.Text"));
        string strURL2 = Convert.ToString(GetLocalResourceObject("lblBusinessResource1.Text"));
        string strURL3 = Convert.ToString(GetLocalResourceObject("lblCapabilitiesResource1.Text"));
        string strURL4 = Convert.ToString(GetLocalResourceObject("lblResLibraryResource1.Text"));
        string strURL5 = Convert.ToString(GetLocalResourceObject("lblLearnMoreResource1.Text"));
        string strURL6 = Convert.ToString(GetLocalResourceObject("lblFaqsResource1.Text"));

        Img2.ImageUrl = strURL1;
        Img3.ImageUrl = strURL2;
        Img5.ImageUrl = strURL3;
        img1.ImageUrl = strURL4;
        Img4.ImageUrl = strURL5;
        Img6.ImageUrl = strURL6;


    }
    private void hideImages()
    {
        try
        {
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            TimeSpan time = new TimeSpan(6, 0, 0);

            if (System.DateTime.Now < Convert.ToDateTime("15-Aug-2012").Add(time))
            {
                if (objLoginDTO.CreatedOn <= Convert.ToDateTime("21-Jun-2012"))
                {
                   // imgshadow.Visible = false;
                    box2_hide.Visible = false;
                    box2.Visible = true;
                    box3_hide.Visible = false;
                    box3.Visible = true;
                    box4_hide.Visible = false;
                    box4.Visible = true;
                    box5_hide.Visible = false;
                    box5.Visible = true;
                    box6_hide.Visible = false;
                    box6.Visible = true;
                }
                else
                {
                   // imgshadow.Visible = true;
                    box2_hide.Visible = true;
                    box2.Visible = false;
                    box3_hide.Visible = true;
                    box3.Visible = false;
                    box4_hide.Visible = true;
                    box4.Visible = false;
                    box5_hide.Visible = true;
                    box5.Visible = false;
                    box6_hide.Visible = true;
                    box6.Visible = false;

                  
                }
            }
            else
            {
                box2_hide.Visible = false;
                box2.Visible = true;
                box3_hide.Visible = false;
                box3.Visible = true;
                box4_hide.Visible = false;
                box4.Visible = true;
                box5_hide.Visible = false;
                box5.Visible = true;
                box6_hide.Visible = false;
                box6.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (chkVisit.Checked == true)
        {
            objDTO.EmailID = Session["EmailID"].ToString();
            objRegs.UpdateVisitStatus(objDTO);
        }

        Session["show"] = "no";
        Session["isClosed"] = "yes";
        Response.Redirect("Dashboard.aspx");
        // Uncomment below code, in order to show Feedback Pop Up (Commented by Lavanya on 27th Jun 2012)
        //Session["MemberRegistrationdate"] = "yes";
        // End Code
    }

  
    protected void imgBtnCloseReg_Click(object sender, EventArgs e)
    {


    }
    protected void ibtnGeneralFbClose_Click(object sender, EventArgs e)
    {
        // Uncomment below code, in order to show Feedback Pop Up (Commented by Lavanya on 27th Jun 2012)
        //Session["MemberRegistrationdate"] = "no";
        // End Code
    }

   

  

    public void Getdata()
    {
        int count = 0;
        string strPath = ConfigurationManager.AppSettings["InternalUrl"].ToString();
        DataSet dsBanner = objGet.GetBannerDetails();

        if (dsBanner.Tables[0].Rows.Count > 0)
        {
            FooterBanner1 = dsBanner.Tables[0].Rows[0][13].ToString();
            FooterBannerURL1 = (dsBanner.Tables[0].Rows[0][14].ToString() == "") ? "#" : dsBanner.Tables[0].Rows[0][14].ToString();
            FooterBanner2 = dsBanner.Tables[0].Rows[0][15].ToString();
            FooterBannerURL2 = (dsBanner.Tables[0].Rows[0][16].ToString() == "") ? "#" : dsBanner.Tables[0].Rows[0][16].ToString();
            //FooterBanner3 = dsBanner.Tables[0].Rows[0][17].ToString();
            //FooterBannerURL3 = (dsBanner.Tables[0].Rows[0][18].ToString() == "") ? "#" : dsBanner.Tables[0].Rows[0][18].ToString();
            FooterBanner4 = dsBanner.Tables[0].Rows[0][19].ToString();
            FooterBannerURL4 = (dsBanner.Tables[0].Rows[0][20].ToString() == "") ? "#" : dsBanner.Tables[0].Rows[0][20].ToString();
        }


        if (FooterBanner1 != "")
        {
            count = count + 1;
            if(FooterBannerURL1 == "#")
                 Footerimgsrc = string.Format(_Footerimagelink, FooterBannerURL1,"_self", "" + strPath + "BannerImages/" + FooterBanner1);
            else
                 Footerimgsrc = string.Format(_Footerimagelink, FooterBannerURL1,"_blank", "" + strPath + "BannerImages/" + FooterBanner1);
            FooterBanners += Footerimgsrc;
        }
        if (FooterBanner2 != "")
        {
            count = count + 1;
            if(FooterBannerURL2 == "#")
                 Footerimgsrc = string.Format(__Footerimage_All, FooterBannerURL2,"_self", "" + strPath + "BannerImages/" + FooterBanner2);
            else
                 Footerimgsrc = string.Format(__Footerimage_All, FooterBannerURL2, "_blank","" + strPath + "BannerImages/" + FooterBanner2);
            FooterBanners += Footerimgsrc;
        }
        if (FooterBanner3 != "")
        {
            count = count + 1;
             if(FooterBannerURL3 == "#")
                  Footerimgsrc = string.Format(__Footerimage_All, FooterBannerURL3,"_self", "" + strPath + "BannerImages/" + FooterBanner3);
             else
                  Footerimgsrc = string.Format(__Footerimage_All, FooterBannerURL3,"_blank", "" + strPath + "BannerImages/" + FooterBanner3);
            FooterBanners += Footerimgsrc;
        }
        if (FooterBanner4 != "")
        {
            count = count + 1;
            if(FooterBannerURL4 == "#")
                Footerimgsrc = string.Format(__Footerimage_All, FooterBannerURL4,"_self", "" + strPath + "BannerImages/" + FooterBanner4);
            else
                Footerimgsrc = string.Format(__Footerimage_All, FooterBannerURL4,"_blank", "" + strPath + "BannerImages/" + FooterBanner4);
            FooterBanners += Footerimgsrc;
        }
        if (count == 1)
        {
            if(FooterBannerURL1 == "#")
                 Footerimgsrc = string.Format(_Footerimagelink, FooterBannerURL1,"_self", "" + strPath + "BannerImages/" + FooterBanner1);
            else
                 Footerimgsrc = string.Format(_Footerimagelink, FooterBannerURL1,"_blank", "" + strPath + "BannerImages/" + FooterBanner1);
            FooterBanners += Footerimgsrc;
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