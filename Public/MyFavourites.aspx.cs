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

public partial class Public_MyFavourites : BasePage
{
    ResourceLibraryDetails obj_RLDetails = new ResourceLibraryDetails();
    UserMgmt objUserMgmt = new UserMgmt();
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
                ViewState["UserID"] = objLoginDTO.UserID;
                ViewState["IndustryId"] = objLoginDTO.IndustryID;

                if (objLoginDTO.EmailID != null)
                {
                    BindMyFavouritesDetails(objLoginDTO.UserID,"all","");

                    //To Insert ModuleTrack Records

                    //objUserMgmt.UserID = ViewState["UserID"].ToString();
                    //objUserMgmt.AccessBy = Session["USER_ID"].ToString();
                    //objUserMgmt.CategoryId = 1;
                    //objUserMgmt.PageView = "Y";
                    //objUserMgmt.AccessDescription = "Access Resource Library page";
                    //objUserMgmt.IndustryId = Convert.ToInt32(ViewState["IndustryId"]);
                    //objUserMgmt.InsertModuleTrack(objUserMgmt);
                }
            }
            else 
            {
                Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
            }

        
        }
    }
    /// <summary>
    /// DEC 20.2011
    /// This method populates the data from tabel with name tbl_ResourceLibrary in DB to DataList.
    /// </summary>
    public void BindMyFavouritesDetails(string parsessionusername, string ptopic, string ptitle)
    {
        obj_RLDetails.Created_By = parsessionusername;
        obj_RLDetails.Title = ptitle;
        obj_RLDetails.Topic = ptopic;
        ds = obj_RLDetails.Get_MyFavouritesDetails(obj_RLDetails);

        //ds = obj_RLDetails.Get_MyFavouritesDetails(obj_RLDetails);// obj_RLDetails.Get_RL_ID_By_Title_Favourites(obj_RLDetails);
        if (ds.Tables[0].Rows.Count > 0)
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
            //string uname = Convert.ToString(Session["LoginDTO"]);
            //BindMyFavouritesDetails(uname, "all", "");

        }

        id_ddl_Topic.DataSource = obj_RLDetails.Get_Tags(obj_RLDetails);
        id_ddl_Topic.DataTextField = "TopicName";
        id_ddl_Topic.DataValueField = "TopicID";
        id_ddl_Topic.DataBind();

        if (ptopic.ToUpper().ToString() != "ALL")
            id_ddl_Topic.Items.FindByValue(ptopic).Selected = true;
        id_ddl_Topic.Items.Insert(0, "ALL");


    }
    protected void id_datalist_ItemCommand(object source, DataListCommandEventArgs e)
    {

        if (e.CommandName.ToString().ToLower().Equals("delete"))
        {
            obj_RLDetails.RL_ID = Convert.ToInt32(e.CommandArgument);
            obj_RLDetails.Delete_Record_ResourceLibrary(obj_RLDetails);
        }

        if (e.CommandName.ToString().ToLower().Equals("download"))
        {
            int rl_id = int.Parse(e.CommandArgument.ToString());
            obj_RLDetails.RL_ID = rl_id;
            string Filename = obj_RLDetails.Get_FileName_ByID(obj_RLDetails);

            string TargetDir = Server.MapPath("~/UploadedFiles/").ToString() + Filename;
            if (File.Exists(TargetDir))
                Response.Redirect("~/public/DownloadFile.aspx?fileName=" + Filename + "");
            else
                throw new FileNotFoundException();
        }




    }

    /// <summary>
    /// DEC 22.2011
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
                    BindMyFavouritesDetails(objLoginDTO.UserID,"all","");
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



    protected void id_datalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("HiddenField1");
            int id_RLID = Convert.ToInt32(hf.Value);
            //int dlcount = ds.Tables[0].Rows.Count;
            obj_RLDetails.RL_ID = id_RLID;
            ds1 = obj_RLDetails.Get_TagSelName(obj_RLDetails);
            DataList dtTopics = (DataList)e.Item.FindControl("dtTopics");
            dtTopics.DataSource = ds1;
            dtTopics.DataBind();
        }
    }

}