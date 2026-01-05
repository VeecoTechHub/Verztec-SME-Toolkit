using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABSBLL;
using System.Data;
using System.Data.SqlClient;
using ABSCommon;
using ABSDTO;
using System.Text;
using System.Configuration;

public partial class Administration_Admin_ManageTopic : System.Web.UI.Page
{

    //NewsAnnouncementDetails obj_NsDetails = new NewsAnnouncementDetails();
    ResourceLibDetails obj_RsDetails = new ResourceLibDetails();

    CommonFunctions CommonFunctions = new CommonFunctions();
    Check_Access chkAccess = new Check_Access();

    public string strparm;
    public string strtags = "";
    DataSet tagds = new DataSet();
    DataSet ds_Search;
    int index = 0;
    public static string token;
    int nid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[0];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            // string v = Request["IDforEdit"].ToString();
            if (Request.Form["token"] != null && Request.Form["token"] != "")
            {
                token = Request.Form["token"];
                ViewState["ViewToken"] = Request.Form["token"];
                ViewState["ViewTokenFlag"] = "Yes";
            }
            lbloperation.Text = "insert";
            if (ViewState["ViewTokenFlag"] != "")
            {
                if (Request["IDforEdit"] != "")
                {
                    string str = CommonFunctions.Decrypt(Request["IDforEdit"]);
                    nid = Convert.ToInt32(str);
                    ViewState["nid"] = nid;
                    lbloperation.Text = "update";
                    Get_NewsDetails_ById(nid);
                }
            }
            else
            {
                Response.Redirect("default.aspx");

            }

        }

    }
    public void Get_NewsDetails_ById(int id)
    {
        obj_RsDetails.TopicID = id;
        obj_RsDetails.action = "ID";
        DataSet dsbyid = obj_RsDetails.GetTopicDetails(obj_RsDetails);
        if (dsbyid.Tables[0].Rows.Count > 0)
        {
            id_txt_AddTitle.Text = dsbyid.Tables[0].Rows[0]["TopicName"].ToString();
            id_txt_AddDetails.Text = dsbyid.Tables[0].Rows[0]["TopicDesc"].ToString();

        }


    }
    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {
        obj_RsDetails.TopicName = id_txt_AddTitle.Text;
        obj_RsDetails.TopicDesc = id_txt_AddDetails.Text;
        if (lbloperation.Text == "insert")
        {
            obj_RsDetails.action = "I";
        }
        else
        {
            if (ViewState["nid"] != null)
                obj_RsDetails.TopicID = Convert.ToInt32(ViewState["nid"].ToString());
            obj_RsDetails.action = "U";
        }

        obj_RsDetails.InsertTopicDetails(obj_RsDetails);
        string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Category Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        id_txt_AddTitle.Text = string.Empty;
        id_txt_AddDetails.Text = string.Empty;
    }
}
