using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using ABSDTO;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Globalization;
using System.Threading;
public partial class Public_ResourceLibDtls : System.Web.UI.Page
{
    CommonFunctions commonfunction = new CommonFunctions();
    ResourceLibDetails obj_RLDetails = new ResourceLibDetails();
    UserMgmt objUserMgmt = new UserMgmt();
    int index = 0;
    int count = 0, count1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }

        if (!IsPostBack)
        {
            //BindHyperLinks();
            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
            ViewState["IndustryId"] = objLoginDTO.IndustryID;

            ViewState["docs"] = string.Empty;
            if (Request.QueryString["RL_ID"] != null)
            {
                ViewState["RL_ID"] = commonfunction.Decrypt(Request.QueryString["RL_ID"].ToString());
                BindData();

            }
        }

    }
    public void BindData()
    {
        //try
        //{
        obj_RLDetails.UserId = ViewState["UserID"].ToString();
        obj_RLDetails.Author = Session["USER_ID"].ToString();
        obj_RLDetails.RL_ID = Convert.ToInt32(ViewState["RL_ID"]);

        if (Convert.ToString(Session["Culture"]) == "zh-SG")
            obj_RLDetails.intCulture = 2;
        else
            obj_RLDetails.intCulture = 1;
        DataSet ds_search = obj_RLDetails.Get_ResourceLibDetails_ByID_Public(obj_RLDetails);
        if (ds_search != null)
        {
            if (ds_search.Tables[0].Rows.Count > 0)
            {
                id_datalist.DataSource = ds_search;
                id_datalist.DataBind();
            }

            else
            {
                id_datalist.DataSource = ds_search;
                id_datalist.DataBind();
            }

        }

        //}
        //catch (Exception ex)
        //{
        //    throw ex;

        //}
    }
    public string GetImg(object ImageName)
    {
        string rstring = string.Empty;
        string rint = (string)ImageName;
        if (rint == "New.jpg")
        {
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                rstring = "../images/new_zh.gif";
            else
                rstring = "../images/new.gif";

        }

        else if (rint == "Recomended.jpg")
        {
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                rstring = "../images/Recommended_zh.gif";
            else
                rstring = "../images/Recommended.gif";
        }
        else
        {
            rstring = "../images/none.gif";
        }

        return rstring;
    }

    protected void id_datalist_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.ToString().ToLower().Equals("favourite"))
        {
            obj_RLDetails.RL_ID = Convert.ToInt32(e.CommandArgument);
            obj_RLDetails.Created_On = DateTime.Now;
            obj_RLDetails.typedownloadoraddfav = 0; //fav
            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                {
                    obj_RLDetails.Created_By = objLoginDTO.UserID;
                }
            }
            int resval = obj_RLDetails.Insert_AddRLFavourite(obj_RLDetails);
            if (resval != -1)
            {

                HtmlImage imgFavourite = (HtmlImage)e.Item.FindControl("imgFavourite");
                imgFavourite.Src = "../images/favourites_new.png";
                BindData();
                string strMsg1 = Convert.ToString(GetLocalResourceObject("lblMsg1Resource1.Text"));
                // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Added to your favourites successfully');</script>");
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + strMsg1 + "');</script>");
            }
            else
            {
                string strMsg2 = Convert.ToString(GetLocalResourceObject("lblMsg2Resource1.Text"));

                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Already this article is added to your favourites.');</script>");
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + strMsg2 + "');</script>");
            }
        }
        else if (e.CommandName.ToString().ToLower().Equals("favouritedelete"))
        {
            obj_RLDetails.RL_ID = Convert.ToInt32(e.CommandArgument);
            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                {
                    obj_RLDetails.Created_By = objLoginDTO.UserID;
                }
            }
            int resval = obj_RLDetails.Delete_AddRLFavourite(obj_RLDetails);
            if (resval != -1)
            {
                BindData();
                string strMsg3 = Convert.ToString(GetLocalResourceObject("lblMsg3Resource1.Text"));

              //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Removed from your favourites successfully');</script>");
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + strMsg3 + "');</script>");
            }
        }
        else if (e.CommandName.ToString().ToLower().Equals("download"))
        {
            obj_RLDetails.RL_ID = Convert.ToInt32(e.CommandArgument);
            obj_RLDetails.Created_On = DateTime.Now;
            obj_RLDetails.typedownloadoraddfav = 1; //download
            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                {
                    obj_RLDetails.Created_By = objLoginDTO.UserID;
                }
            }
            HiddenField hydTitle = (HiddenField)e.Item.FindControl("hydTitle");

            objUserMgmt.UserID = ViewState["UserID"].ToString();
            objUserMgmt.AccessBy = Session["USER_ID"].ToString();
            objUserMgmt.CategoryId = obj_RLDetails.RL_ID;
            objUserMgmt.Downloading = "Y";
            if (hydTitle != null)
                objUserMgmt.AccessDescription = hydTitle.Value;
            else
                objUserMgmt.AccessDescription = "";
            objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                objUserMgmt.Culture = 2;
            else
                objUserMgmt.Culture = 1;
            objUserMgmt.InsertModuleTrack_ResLib(objUserMgmt);
            //int resval = obj_RLDetails.Insert_AddRLFavourite(obj_RLDetails);
            //if (resval != -1)
            //{

            //    //HtmlImage imgFavourite = (HtmlImage)e.Item.FindControl("imgFavourite");
            //    //imgFavourite.Src = "../images/favourites_new.png";

            //    //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Added to your favourites successfully');</script>");
            //}

            // downloaded method here...
            HiddenField RL_FileName = (HiddenField)e.Item.FindControl("hyddownload");
            if (RL_FileName != null)
                DownloadFile(RL_FileName.Value, true);
            //else
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Already this article is added to your favourites.');</script>");
        }



    }

    public static void DownloadFile(string filename, bool forceDownload)
    {
        string path = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + filename);
        string name = System.IO.Path.GetFileName(path);
        string ext = System.IO.Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".xls":
                case ".csv":
                    type = "text/Delimited";
                    break;
            }
        }
        if (forceDownload)
        {
            HttpContext.Current.Response.AppendHeader("content-disposition",
                "attachment; filename=\"" + name + "\"");
        }
        if (type != "")
            HttpContext.Current.Response.ContentType = type;
        HttpContext.Current.Response.WriteFile(path);
        HttpContext.Current.Response.End();
    }


    public string DateFormat(DateTime date)
    {
        //date = Convert.ToDateTime(date.Day + "/" + date.Month + "/" + date.Year);
        return date != null ? ((DateTime)date).ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"].ToString()) : "";
    }
    protected void id_datalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        HtmlImage imgFavourite = (HtmlImage)e.Item.FindControl("imgFavourite");
        LinkButton linkFavourite = (LinkButton)e.Item.FindControl("linkFavourite");
        LinkButton linkFavouriteDelete = (LinkButton)e.Item.FindControl("linkFavouriteDelete");
        int STATUS = obj_RLDetails.GET_STATUS_FAVOURITE(obj_RLDetails);
        if (STATUS == 1)
        {
            imgFavourite.Src = "../images/favourites_new.png";
            linkFavouriteDelete.Visible = true;
            linkFavourite.Visible = false;
        }
        else
        {
            imgFavourite.Src = "../images/favourites1.png";
            linkFavouriteDelete.Visible = false;
            linkFavourite.Visible = true;
        }

        HiddenField hyddownload = (HiddenField)e.Item.FindControl("hyddownload");

        LinkButton lnkbtnDownload = (LinkButton)e.Item.FindControl("lnkbtnDownload");

        //if (!string.IsNullOrEmpty(hyddownload.Value))
        if (hyddownload.Value != "" && hyddownload.Value != null)
        {
            if (ABSCommon.Common.IsFileExists(Server.MapPath("~/UploadedFiles/" + hyddownload.Value)))
                lnkbtnDownload.Visible = true;
            else
                lnkbtnDownload.Visible = false;
        }
        else
            lnkbtnDownload.Visible = false;

        HiddenField docSelection = (HiddenField)e.Item.FindControl("docSelection");

        if (!string.IsNullOrEmpty(docSelection.Value))
        {
            ViewState["docs"] = docSelection.Value;
            DataList dlHypLink = (DataList)e.Item.FindControl("dlHypLink");
            Label lblRecCaptoin = (Label)e.Item.FindControl("lblRecCaptoin");
            obj_RLDetails.Docs = ViewState["docs"].ToString();
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                obj_RLDetails.intCulture = 2;
            else
                obj_RLDetails.intCulture = 1;
            DataSet ds = obj_RLDetails.GET_RelatedArticals(obj_RLDetails);
            if (ds != null)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlHypLink.DataSource = ds;
                    dlHypLink.DataBind();
                }
                else
                {
                    dlHypLink.DataSource = ds;
                    dlHypLink.DataBind();
                    lblRecCaptoin.Visible = false;
                }
            }
            ViewState["dsData" + count] = ds;
            count = count + 1;
        }
        else
        {
            //Label lblNoArticles = (Label)e.Item.FindControl("lblNoArticles");
            //lblNoArticles.Visible = true;
            Label lblRecCaptoin = (Label)e.Item.FindControl("lblRecCaptoin");
            lblRecCaptoin.Visible = false;
        }
    }


    protected string getEditProfilePage()
    {

        string str = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData" + count1];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = commonfunction.Encrypt(ds.Tables[0].Rows[index]["RL_ID"].ToString());
            str = Server.UrlEncode(str);
            index = index + 1;
            if (index == ds.Tables[0].Rows.Count)
            {
                index = 0;
                if (count1 <= count)
                {
                    count1 = count1 + 1;
                }
            }
        }
        return "ResourceLibDtls.aspx?RL_ID=" + str;
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