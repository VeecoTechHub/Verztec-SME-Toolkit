using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using ABSDTO;
using System.Configuration;
using ABSCommon;
using System.Globalization;
using System.Threading;


public partial class Public_MyRLFavourites : System.Web.UI.Page
{

    int index = 0;
    UserMgmt objUserMgmt = new UserMgmt();
    CommonFunctions commonfunction = new CommonFunctions();
    string str = string.Empty;

    ResourceLibDetails obj_RLDetails = new ResourceLibDetails();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            if (Session["LoginDTO"] != null)
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
                        Session["RedirectURL"] = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "/Public/MyRLFavourites.aspx";
                        Session["RedirectLogout"] = "NO";
                        Response.Redirect("~/Public/FMFeedback.aspx", false);
                        return;
                    }

                }


                if (objLoginDTO.EmailID != null)
                {
                    BindMyFavouritesDetails(objLoginDTO.UserID, "all", "");
                }
            }
            else
            {
                Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
            }


        }
    }

    /// <summary>
    /// FEB 07.2012
    /// This method populates the data from tabel with name tbl_NewsDetails in DB to DataList.
    /// </summary>
    public void BindMyFavouritesDetails(string parsessionusername, string ptopic, string ptitle)
    {
        obj_RLDetails.Created_By = parsessionusername;
        obj_RLDetails.Title = ptitle;
        obj_RLDetails.Topic = ptopic;
        ds = obj_RLDetails.Get_MyRLFavouritesDetails(obj_RLDetails);        
        if (ds.Tables[0].Rows.Count > 0)
        {
            id_datalist.DataSource = ds;
            id_datalist.DataBind();
            ViewState["dsData"] = ds;
            tbdatalist.Visible = true;
        }
        else
        {
            id_datalist.DataSource = ds;
            id_datalist.DataBind();
            lblMsg.Text = Convert.ToString(GetLocalResourceObject("lblMsgResource1.Text"));
            tbdatalist.Visible = false;
     
        }
        obj_RLDetails.Type = "RL";
        obj_RLDetails.Culture=Convert.ToString(Session["Culture"]);
        id_ddl_Topic.DataSource = obj_RLDetails.Get_ResourceLibCategory(obj_RLDetails);
        id_ddl_Topic.DataTextField = "TopicName";
        id_ddl_Topic.DataValueField = "TopicID";
        id_ddl_Topic.DataBind();


        if (ptopic.ToUpper().ToString() != "ALL")
            id_ddl_Topic.Items.FindByValue(ptopic).Selected = true;
        id_ddl_Topic.Items.Insert(0, Convert.ToString(GetLocalResourceObject("lblFake1Resource1.Text")));


    }


    protected void id_datalist_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
        if (e.CommandName.ToString().ToLower().Equals("delete"))
        {
            
            obj_RLDetails.RL_ID = Convert.ToInt32(e.CommandArgument);
            //obj_RLDetails.Created_On = DateTime.Now;
            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                {
                    obj_RLDetails.Created_By = objLoginDTO.UserID;
                }
            }
            int resval = obj_RLDetails.Delete_AddRLFavourite(obj_RLDetails);
            string strAlert1 = Convert.ToString(GetLocalResourceObject("lblAlert1Resource1.Text"));
            string strAlert2 = Convert.ToString(GetLocalResourceObject("lblAlert2Resource1.Text"));
            if (resval != -1)
            {
                    string strURL = Convert.ToString(GetLocalResourceObject("lblFakeResource1.Text"));

                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + strAlert1 + "');</script>");
            }
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('" + strAlert2 + "');</script>");

           
        }
        if (id_ddl_Topic.SelectedItem.Text.ToString() == "ALL" && id_txt_Title.Text == "")
        {
            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                    BindMyFavouritesDetails(objLoginDTO.UserID, "all", "");
            }

            // return;
        }

        else if (id_ddl_Topic.SelectedItem.Text.ToString() == "ALL" && id_txt_Title.Text != "")
        {
            string Title = id_txt_Title.Text.ToString();
            obj_RLDetails.Title = Title;
            obj_RLDetails.Topic = "all";// id_ddl_Topic.SelectedItem.Text.ToString();

            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                    BindMyFavouritesDetails(objLoginDTO.UserID, "all", Title);
            }

            //return;
        }
        else
        {

            string Title = id_txt_Title.Text.ToString();
            string lptopic = id_ddl_Topic.SelectedValue.ToString();

            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                    BindMyFavouritesDetails(objLoginDTO.UserID, lptopic, Title);
            }
            
        }

       



    }

    /// <summary>
    /// FEB 07.2012
    /// This method populates the DataList based on the user Title selection
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void id_btn_Search_Click(object sender, EventArgs e)
    {
        //LoginDTO objLoginDTO= new LoginDTO();

        if (id_ddl_Topic.SelectedItem.Text.ToString() == "ALL" && id_txt_Title.Text == "")
        {
            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                    BindMyFavouritesDetails(objLoginDTO.UserID, "all", "");
            }
            // return;
        }

        else if (id_ddl_Topic.SelectedItem.Text.ToString() == "ALL" && id_txt_Title.Text != "")
        {
            string Title = id_txt_Title.Text.ToString();
            obj_RLDetails.Title = Title;
            obj_RLDetails.Topic = "all";// id_ddl_Topic.SelectedItem.Text.ToString();

            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                    BindMyFavouritesDetails(objLoginDTO.UserID, "all", Title);
            }

            //return;
        }
        else
        {

            string Title = id_txt_Title.Text.ToString();
            string lptopic = id_ddl_Topic.SelectedValue.ToString();

            if (Session["LoginDTO"] != null)
            {
                LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
                if (objLoginDTO.EmailID != null)
                    BindMyFavouritesDetails(objLoginDTO.UserID, lptopic, Title);
            }
            //string unamee = Convert.ToString(Session["LoginDTO"]);

        }


    

        // id_txt_Title.Text = "";
    }
    protected void id_btn_Add_Click(object sender, EventArgs e)
    {
        //id_tbl_Add.Style["display"] = "block";
    }



    //protected void id_datalist_ItemDataBound(object sender, DataListItemEventArgs e)
    //{
    //    if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
    //    {
    //        HiddenField hf = (HiddenField)e.Item.FindControl("HiddenField1");
    //        int id_RLID = Convert.ToInt32(hf.Value);
    //        //int dlcount = ds.Tables[0].Rows.Count;
    //        obj_RLDetails.RL_ID = id_RLID;
    //        obj_RLDetails.Type = "RL";
    //        ds1 = obj_RLDetails.GetSelResourceLibCategory(obj_RLDetails);
    //        DataList dtTopics = (DataList)e.Item.FindControl("dtTopics");
    //        dtTopics.DataSource = ds1;
    //        dtTopics.DataBind();
    //    }
    //}

    public string DateFormat(DateTime date)
    {
        //date = Convert.ToDateTime(date.Day + "/" + date.Month + "/" + date.Year);
        return date != null ? ((DateTime)date).ToString(System.Configuration.ConfigurationManager.AppSettings["DateFormat"].ToString()) : "";
    }

    public string GetImg(object RID)
    {
        string rstring = string.Empty;
        int rint = (int)RID;
        if (rint == 1)
        {
            rstring = "../images/img_rating1.png";
        }

        else if (rint == 2)
        {
            rstring = "../images/img_rating2.png";
        }
        else if (rint == 3)
        {
            rstring = "../images/img_rating3.png";
        }
        else if (rint == 4)
        {
            rstring = "../images/img_rating4.png";
        }
        else if (rint == 5)
        {
            rstring = "../images/img_rating5.png";
        }

        return rstring;
    }

    protected string getEditProfilePage()
    {
        string str = string.Empty;
        DataSet ds = new DataSet();
        ds = (DataSet)ViewState["dsData"];
        if (index < ds.Tables[0].Rows.Count)
        {
            str = commonfunction.Encrypt(ds.Tables[0].Rows[index]["RL_ID"].ToString());
            str = Server.UrlEncode(str);
        }
        index = index + 1;
        return "MyRLFavouritesDtls.aspx?RL_ID=" + str;
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