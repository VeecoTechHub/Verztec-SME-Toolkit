using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ABSBLL;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using ABSDTO;
using System.Configuration;
using System.Globalization;
using System.Threading;

public partial class Public_ResourceLib : System.Web.UI.Page
{
    int index = 0;
    int count = 0, count1 = 0;
    CommonFunctions commonfunction = new CommonFunctions();
    UserMgmt objUserMgmt = new UserMgmt();
    string str = string.Empty;

    ResourceLibDetails obj_RLDetails = new ResourceLibDetails();

    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }

        lblMsg.Text = "";
        if (!IsPostBack)
        {


            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];

            //  objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
            ViewState["IndustryId"] = objLoginDTO.IndustryID;

            BindRLDetails();


        }

    }

    /// <summary>
    /// FEB 8.2012
    /// This method populates the data from tabel with name tbl_resourceLibDetails in DB to DataList.
    /// </summary>
    public void BindRLDetails()
    {
        if (Convert.ToString(Session["Culture"]) != "")
            obj_RLDetails.Culture = Convert.ToString(Session["Culture"]);
        else
            obj_RLDetails.Culture = "en-US";


        ds = obj_RLDetails.GET_RESOURCELIBRARY_CATEGORYDTLS(obj_RLDetails);
        if (ds.Tables[0].Rows.Count > 0)
        {
            id_datalist.DataSource = ds;
            id_datalist.DataBind();
            //ViewState["dsData"] = ds;           
        }
        else
        {
            id_datalist.DataSource = ds;
            id_datalist.DataBind();
            lblMsg.Text = " <br />Records Not Found";

        }
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

    public string GetTitle(object ImageName)
    {
        string rstring = string.Empty;
        string rint = (string)ImageName;
        if (rint == "New.jpg")
        {
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                rstring = "新添";
            else
                rstring = "New";

        }

        else if (rint == "Recomended.jpg")
        {
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                rstring = "推荐";
            else
                rstring = "Recommended";
        }

        return rstring;
    }
    protected void id_innerdatalist_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName.ToString().ToLower().Equals("favourite"))
        {
            ImageButton btnFavouriteNew = (ImageButton)e.Item.FindControl("btnFavourite");
            if (btnFavouriteNew.ImageUrl != "../images/favourites_new.png")
            {
                obj_RLDetails.RL_ID = Convert.ToInt32(e.CommandArgument);
                obj_RLDetails.Created_On = DateTime.Now;
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

                    ImageButton btnFavourite = (ImageButton)e.Item.FindControl("btnFavourite");
                    btnFavourite.ImageUrl = "../images/favourites_new.png";
                    btnFavourite.Enabled = false;
                    string strAlert = Convert.ToString(GetLocalResourceObject("lblFakeResource1.Text"));
                    //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Added to your favourites successfully');</script>");
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + strAlert + "');</script>");
                }
                //else
                //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Already this article is added to your favourites.');</script>");
            }
        }

    }


    //public string DateFormat(DateTime date)
    //{

    //    //date = Convert.ToDateTime(date.Day + "/" + date.Month + "/" + date.Year);
    //    return date != null ? ((DateTime)date).ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"].ToString()) : "";
    //}  

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

    protected void id_datalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        HiddenField hdnTopicID = (HiddenField)e.Item.FindControl("hdnTopicID");
        obj_RLDetails.TopicID = Convert.ToInt32(hdnTopicID.Value);
        if (Convert.ToString(Session["Culture"]) != "zh-SG")
            obj_RLDetails.Culture = "1";
        else
            obj_RLDetails.Culture = "2";


        ds1 = obj_RLDetails.GET_RESOURCELIBRARY_DETAILS_ByTopicID(obj_RLDetails);

        AjaxControlToolkit.AccordionPane pn;
        pn = new AjaxControlToolkit.AccordionPane();

        // AjaxControlToolkit.AccordionPane AccordionPane2 = (AjaxControlToolkit.AccordionPane)e.Item.FindControl("AccordionPane2");
        //  DataList id_innerdatalist = (DataList)AccordionPane2.ContentContainer.FindControl("id_innerdatalist");
        //  Label lblTopicName = (Label)AccordionPane2.HeaderContainer.FindControl("lblTopicName");
        //if (lblTopicName != null)
        //{
        //    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
        //        lblTopicName.Text = ds1.Tables[0].Rows[0]["TopicName"].ToString();
        //}

        DataList id_innerdatalist = (DataList)e.Item.FindControl("id_innerdatalist");
        Label lblTopicName = (Label)e.Item.FindControl("lblTopicName");
        Label lblTopicDesc = (Label)e.Item.FindControl("lblTopicDesc");
        if (id_innerdatalist != null)
        {
            if (ds1 != null && ds1.Tables[0] != null && ds1.Tables[0].Rows.Count > 0)
            {
                lblTopicName.Text = ds1.Tables[0].Rows[0]["TopicName"].ToString();
                lblTopicDesc.Text = ds1.Tables[0].Rows[0]["TopicDesc"].ToString();
                id_innerdatalist.DataSource = ds1;
                id_innerdatalist.DataBind();

                ViewState["dsData" + count] = ds1;
                count = count + 1;
            }
        }

        //ViewState["dsData" + count] = ds1;
        //count = count + 1;
    }

    protected void id_innerdatalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            HiddenField hdnLevel = (HiddenField)e.Item.FindControl("hdnLevel");
            HiddenField hdnRLID = (HiddenField)e.Item.FindControl("hdnRLID");
            ImageButton btnFavourite = (ImageButton)e.Item.FindControl("btnFavourite");
            HtmlAnchor A_level = (HtmlAnchor)e.Item.FindControl("A_level");
            HtmlTableCell td1 = (HtmlTableCell)e.Item.FindControl("td1");
            HtmlTableCell td2 = (HtmlTableCell)e.Item.FindControl("td2");

            obj_RLDetails.RL_ID = Convert.ToInt32(hdnRLID.Value);
            //HyperLink hypTitle = (HyperLink)e.Item.FindControl("hypTitle");
            string strLevel = hdnLevel.Value;
            if (strLevel.Length == 3)
            {

                td1.Attributes.Add("class", "levelTwo");
                td2.Attributes.Add("class", "levelTwo");
                //hypTitle.CssClass = "levelTwo";
            }
            else if (strLevel.Length == 5 || strLevel.Length == 6)
            {
                td1.Attributes.Add("class", "levelThree");
                td2.Attributes.Add("class", "levelThree");
                //hypTitle.CssClass = "levelThree";
            }

            obj_RLDetails.UserId = Convert.ToString(ViewState["UserID"]);
            int STATUS = obj_RLDetails.GET_STATUS_FAVOURITE(obj_RLDetails);
            if (STATUS == 1)
            {
                btnFavourite.ImageUrl = "../images/favourites_new.png";
                btnFavourite.Enabled = false;
            }
            else
            {
                btnFavourite.ImageUrl = "../images/favourites1.png";
                btnFavourite.Enabled = true;
            }


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