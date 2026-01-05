using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using ABSDTO;

public partial class Public_NextStep : BasePage
{
    UserMgmt objUserMgmt = new UserMgmt();
    CourseDetails obj_CDetails = new CourseDetails();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    int index = 0;

    CommonFunctions CommonFunctions = new CommonFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");

        }
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            BindNextStepDetails("", "ALL");

            LoginDTO objLoginDTO = (LoginDTO)Session["LoginDTO"];
            ViewState["UserID"] = objLoginDTO.UserID;
            ViewState["IndustryId"] = objLoginDTO.IndustryID;

            //Added by Mahesh to Insert ModuleTrack Records
            //Added on 05/03/2012
            objUserMgmt.UserID = ViewState["UserID"].ToString();
            objUserMgmt.AccessBy = Session["USER_ID"].ToString();
            objUserMgmt.CategoryId = 5;
            objUserMgmt.PageView = "Y";
            objUserMgmt.AccessDescription = "Access LearnMore page";
            objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
            if (Convert.ToString(Session["Culture"]) == "zh-SG")
                objUserMgmt.Culture = 2;
            else
                objUserMgmt.Culture = 1;
            objUserMgmt.InsertModuleTrack(objUserMgmt);
        }
    }

    public void BindNextStepDetails(string ptitle, string ptopic)//starthere....................
    {
        id_ddl_Topic.DataSource = obj_CDetails.Get_CourseMaster();

        id_ddl_Topic.DataTextField = "CourseName";
        id_ddl_Topic.DataValueField = "CourseID";
        id_ddl_Topic.DataBind();
        if (ptopic.ToUpper().ToString() != "ALL")
            id_ddl_Topic.Items.FindByValue(ptopic).Selected = true;
        id_ddl_Topic.Items.Insert(0, "ALL");

        obj_CDetails.Title = ptitle;
        obj_CDetails.Topic = ptopic;

        //int tno = int.Parse(ptopic);
        //obj_CDetails.tagno = tno;

        ds = obj_CDetails.Get_CourseDetails(obj_CDetails);

        if (ds.Tables[0].Rows.Count != 0)
        {
            id_datalist.DataSource = ds;
            id_datalist.DataBind();
        }
        else
        {
            id_datalist.DataSource = ds;
            id_datalist.DataBind();
            lblMsg.Text = " <br />Records Not Found";
            //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('There is no such record exists with this Title.');</script>");
            //BindNextStepDetails("", "all");
        }
    }
    protected void id_datalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            HiddenField hf = (HiddenField)e.Item.FindControl("HiddenField1");
            int CID = Convert.ToInt32(hf.Value);
            int dlcount = ds.Tables[0].Rows.Count;

            obj_CDetails.CID = CID;
            ds1 = obj_CDetails.CDetails_GetSelTags(obj_CDetails);

            DataList dtCategory = (DataList)e.Item.FindControl("dtCategory");
            dtCategory.DataSource = ds1;
            dtCategory.DataBind();
        }

    }
    protected void id_btn_Search_Click(object sender, EventArgs e)
    {
        if (id_ddl_Topic.SelectedItem.Text.ToString() == "ALL" && id_txt_CategoryTitle.Text == "")
        {
            BindNextStepDetails("", "ALL");
        }

        else if (id_ddl_Topic.SelectedItem.Text.ToString() == "ALL" && id_txt_CategoryTitle.Text != "")
        {
            string Title = id_txt_CategoryTitle.Text.ToString();
            BindNextStepDetails(Title, "ALL");
        }

        else
        {
            string TagID = id_ddl_Topic.SelectedValue.ToString();
            string Title = id_txt_CategoryTitle.Text.ToString();
            BindNextStepDetails(Title, TagID);

        }

      
    }

    protected string getEditProfilePage()
    {
        string str = string.Empty;
        string str1 = string.Empty;
        if (index < ds.Tables[0].Rows.Count)
        {
            str = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["NS_ID"].ToString());
            str1 = CommonFunctions.Encrypt(ds.Tables[0].Rows[index]["CID"].ToString());
            str = Server.UrlEncode(str);
        }
        index = index + 1;
        return "CourseRegistration.aspx?NS_ID=" + str + "&CID="+ str1 +"" ;
    }


    protected void id_datalist_DataBinding(object sender, EventArgs e)
    {


        //foreach (DataListItem item in id_datalist .Items )
        //{
        //      HyperLink hpr = (HyperLink)item.FindControl ("Register");

        //      hpr.NavigateUrl = "CourseRegistration.aspx?cid="+ getEditProfilePage();
        //}
    }


    protected void dtCategory_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "searchtopic")
        {
            string topicid = e.CommandArgument.ToString();



            obj_CDetails.Title = "";
            obj_CDetails.Topic = topicid.ToString();

            ds = obj_CDetails.Get_CourseDetails(obj_CDetails);

            if (ds.Tables[0].Rows.Count != 0)
            {
                id_datalist.DataSource = ds;

                id_datalist.DataBind();
            }

        }
    }


  
}