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

public partial class Public_ResourceLibrary : BasePage
{
    UserMgmt objUserMgmt = new UserMgmt();
    ResourceLibraryDetails obj_RLDetails = new ResourceLibraryDetails();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoginDTO"] == null)
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");

        }
        id_btn_Add.Visible = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            BindResourceLibraryDetails("", "all");
        }

      
    }

    /// <summary>
    /// DEC 20.2011
    /// This method populates the data from tabel with name tbl_ResourceLibrary in DB to DataList.
    /// </summary>
    public void BindResourceLibraryDetails(string ptitle, string ptopic)
    {
        id_ddl_Topic.DataSource = obj_RLDetails.Get_Tags(obj_RLDetails);
        id_ddl_Topic.DataTextField = "TopicName";
        id_ddl_Topic.DataValueField = "TopicID";
        id_ddl_Topic.DataBind();
        if (ptopic.ToUpper().ToString() != "ALL")
            id_ddl_Topic.Items.FindByValue(ptopic).Selected = true;
        id_ddl_Topic.Items.Insert(0, "ALL");
        obj_RLDetails.Title = ptitle; obj_RLDetails.Topic = ptopic;
        ds = obj_RLDetails.Get_ResourceLibraryDetails(obj_RLDetails);
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
           // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('There is no such record exists.');</script>");
           // BindResourceLibraryDetails("", "all");
        }
    }

    protected void id_datalist_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.ToString().ToLower().Equals("favourite"))
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
            int resval = obj_RLDetails.Insert_AddFavourite(obj_RLDetails);
            if (resval != -1)
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Added to your favourites successfully');</script>");
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Already this article is added to your favourites.');</script>");
        }
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
               // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('File does not exist');</script>");

        }
    }

    public DataSet Get_TagSel_By_RL_ID(int id)
    {
        obj_RLDetails.RL_ID = id;
        return obj_RLDetails.Get_TagSel_By_RL_ID(obj_RLDetails);
    }

   

    /// <summary>
    /// DEC 22.2011
    /// This method populates the DataList based on the user Title selection
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void id_btn_Search_Click(object sender, EventArgs e)
    {
        if (id_ddl_Topic.SelectedItem.Text.ToString() == "ALL" && id_txt_Title.Text == "")
        {
            BindResourceLibraryDetails("", "all");
        }

        else if (id_ddl_Topic.SelectedItem.Text.ToString() == "ALL" && id_txt_Title.Text != "")
        {
            string Title = id_txt_Title.Text.ToString();
            BindResourceLibraryDetails(Title, "all");
        }

        else
        {
            string TagID = id_ddl_Topic.SelectedValue.ToString();
            string Title = id_txt_Title.Text.ToString();
            BindResourceLibraryDetails(Title, TagID);
        }
    }

    protected void id_btn_Add_Click(object sender, EventArgs e)
    {
        // id_tbl_Add.Style["display"] = "block";
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

    protected void id_ddl_Topic_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void id_datalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("HiddenField1");
            int id_RLID = Convert.ToInt32(hf.Value);
            int dlcount = ds.Tables[0].Rows.Count;
            obj_RLDetails.RL_ID = id_RLID;
            ds1 = obj_RLDetails.Get_TagSelName(obj_RLDetails);
            DataList dtTopics = (DataList)e.Item.FindControl("dtTopics");
            dtTopics.DataSource = ds1;
            dtTopics.DataBind();
        }
    }

    private void BindGrid(GridView mygrid, int n)
    {
        if (mygrid != null)
        {
            int id_RLID = int.Parse(ds.Tables[0].Rows[n]["RL_ID"].ToString());
            obj_RLDetails.RL_ID = id_RLID;
            ds1 = obj_RLDetails.Get_TagSelName(obj_RLDetails);
            mygrid.DataSource = ds1;
            mygrid.DataBind();
        }
    }

}