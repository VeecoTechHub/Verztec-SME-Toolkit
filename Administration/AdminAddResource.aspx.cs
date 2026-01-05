using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using ABSBLL;
using ABSCommon;
using System.IO;


public partial class Administration_AdminAddResource : System.Web.UI.Page
{
   // string displayfilename = string.Empty;
    int result;
    ResourceLibraryDetails obj_RLDetails = new ResourceLibraryDetails();
    Check_Access chkAccess = new Check_Access();
    string StrFileName = string.Empty;
    int rl_id;
    //int strtagsi;
    DataSet ds = new DataSet();
    CommonFunctions commonfunction = new CommonFunctions();
    public static string token;
    protected void Page_Load(object sender, EventArgs e)
    {

      
        if (!IsPostBack)
        {

            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            token = Request.Form["token"];
            ViewState["t_url"] = "AdminResourcesLibrary.aspx?RL_ID=00";
            if (token == null)
            {
                Response.Redirect("default.aspx");
            }

            else
            {
                BindCheckList();
                string v = Request["IDforEdit"].ToString();
                if (Request["IDforEdit"] != null)
                {
                        if (Request["IDforEdit"] != "")
                        {
                            string str = commonfunction.Decrypt(Request["IDforEdit"]);
                            rl_id = Convert.ToInt32(str);
                            ViewState["rl_id"] = rl_id;
                            BindCheckListWithSel(rl_id);
                            Button_Save.CausesValidation = false;
                            Bind_Data_toTable(rl_id);

                        }
                }
                else
                    btnClear.Visible = true;
            }
        }
    }

    public void BindCheckList()
    {
        ds = obj_RLDetails.GetTagValues();
        id_cklist.DataSource = ds;
        id_cklist.DataTextField = "TopicName";
        id_cklist.DataValueField = "TopicID";
        id_cklist.DataBind();
      
    }    

    public void BindCheckListWithSel(int strtagsi_rlid)
    {
        obj_RLDetails.RL_ID = strtagsi_rlid;
        ds = obj_RLDetails.GetSelTags(obj_RLDetails);
        string[] j = new string[5];
        int count = ds.Tables[0].Rows.Count;
        for (int p = 0; p < count; p++)
        {
            string kj = ds.Tables[0].Rows[p][0].ToString();
            id_cklist.Items.FindByValue(ds.Tables[0].Rows[p][0].ToString()).Selected = true;
        }
    }

    public void Bind_Data_toTable(int rl_id)
    {
       
        string filename = string.Empty;
        obj_RLDetails.RL_ID = rl_id;
        ds = obj_RLDetails.Get_ResourceLibraryDetails_ByID(obj_RLDetails);
        ViewState["ds"] = ds;
        id_txt_AddTitle.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["ArticleTitle"].ToString());
        id_txt_AddAuthor.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["Author_Name"].ToString());
        id_txt_AddDescription.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["ArticleDescription"].ToString());
        id_ddl_Rating.SelectedValue = ds.Tables[0].Rows[0]["Rating"].ToString();
        id_lbl_sessfilename.Text = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["RL_FileName"].ToString());
        DatePicker_PublishedOn.DateString = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["publishedon"].ToString());
        if (ds.Tables[0].Rows[0]["RL_FileName"].ToString() == "")
        {
            lnkBtn.Visible = false;
            //lnkBtn.Visible = true;
            //filename = CommonBindings.TextToBind(ds.Tables[0].Rows[0]["RL_FileName"].ToString());
            //hlViewFile.Target = "_blank";
            //hlViewFile.NavigateUrl = "~/ViewFile.aspx?fileName=" + filename + "";

        }
        else
            lnkBtn.Visible = true;
    }


    //protected void btnClear_Click(object sender, ImageClickEventArgs e)
    //{
    //    //ClearText();
    //}

  

    public int UpLoad()
    {
        try
        {
            if (!string.IsNullOrEmpty(FileUpload1.PostedFile.FileName))
            {
                string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
                if (ext.ToLower() == ".pdf")
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(FileUpload1, Server.MapPath("~/UploadedFiles"), StrFileName);
                    obj_RLDetails.Upload_File_Path = StrFileName;
                    return 1;
                }
                else
                {
                    id_lbl_error.Visible = true;
                    return 0;
                }
            }
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return 0;
    }

    public void ClearText()
    {
        id_txt_AddAuthor.Text = " ";
        id_txt_AddDescription.Text = " ";
        id_txt_AddTitle.Text = " ";
        id_cklist.ClearSelection();
    }

    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(id_lbl_sessfilename.Text))//indicates the admin is in edit mode for a particular title.
            {
                obj_RLDetails.Title = id_txt_AddTitle.Text;
                obj_RLDetails.Description = id_txt_AddDescription.Text;
                obj_RLDetails.Author = id_txt_AddAuthor.Text;
                obj_RLDetails.Updated_On = DateTime.Now;
                obj_RLDetails.Updated_By = Session["USER_NM"].ToString();
                //changes 
                obj_RLDetails.Published_On = Convert.ToDateTime(DatePicker_PublishedOn.DateString);
                obj_RLDetails.Rating = int.Parse(id_ddl_Rating.SelectedValue.ToString());
                //changes 0ne obj_RLDetails.Published_On=
                string[] kk = new string[5];
                int ii = 0;
                obj_RLDetails.RL_ID = Convert.ToInt32(ViewState["rl_id"]);
                obj_RLDetails.DeleteTagRow_ByID(obj_RLDetails);
                foreach (ListItem listItems in id_cklist.Items)
                {
                    if (listItems.Selected)
                    {
                        obj_RLDetails.tags[ii] = Convert.ToInt32(listItems.Value.ToString());
                        kk[ii] = obj_RLDetails.tags[ii].ToString();
                        obj_RLDetails.tagno = int.Parse(kk[ii]);
                        obj_RLDetails.Insert_TagDetails(obj_RLDetails);
                    }
                    else
                    { //do something else }
                    }
                    ii++;
                }
                if (FileUpload1.FileName == "")
                {
                    obj_RLDetails.Upload_File_Path = id_lbl_sessfilename.Text.Trim();
                }
                else
                {
                    ABSCommon.Common.DeleteFile(Server.MapPath("~/UploadedFiles/"), id_lbl_sessfilename.Text.Trim());

                    int resfile = UpLoad();
                    if (resfile == 1)
                        obj_RLDetails.RL_ID = Convert.ToInt32(ViewState["rl_id"]);
                    else
                    {
                        id_lbl_error.Visible = true;
                        return;
                    }
                }
                int result = obj_RLDetails.Update_ResouceLibraryDetails(obj_RLDetails);
                if (result > 0)
                {
                    string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");

                }
               // ClearText();
            }
            //the below code indicated the admin is adding a new title
            else
            {
                obj_RLDetails.Title = CommonBindings.TextToBind(id_txt_AddTitle.Text);
                obj_RLDetails.Description = CommonBindings.TextToBind(id_txt_AddDescription.Text);
                obj_RLDetails.Author = CommonBindings.TextToBind(id_txt_AddAuthor.Text);
                obj_RLDetails.Created_On = DateTime.Now;
                obj_RLDetails.Created_By = Session["USER_NM"].ToString();
              
                obj_RLDetails.Rating = int.Parse(id_ddl_Rating.SelectedValue);
                obj_RLDetails.Published_On = Convert.ToDateTime(DatePicker_PublishedOn.DateString);
                string[] k = new string[5];
                int i = 0;
                if (FileUpload1.FileName != string.Empty)
                {
                    int fileres = UpLoad();

                    if (fileres == 1)
                    {
                        result = obj_RLDetails.Insert_tbl_ResourceLibrary(obj_RLDetails);
                        if (result > 0)
                        {
                           // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Record Added Successfully.');</script>");
                            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
                            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('User Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");

                        }
                    }
                    else
                        return;

                }
                foreach (ListItem listItem in id_cklist.Items)
                {
                    if (listItem.Selected)
                    {
                        obj_RLDetails.tags[i] = Convert.ToInt32(listItem.Value.ToString());
                        k[i] = obj_RLDetails.tags[i].ToString();
                        obj_RLDetails.RL_ID = result;
                        obj_RLDetails.tagno = int.Parse(k[i]);
                        obj_RLDetails.Insert_TagDetails(obj_RLDetails);
                    }
                    else
                    { //do something else }
                    }
                    i++;
                }
                ClearText();
                id_lbl_error.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ABSCommon.Common.ErrorMessage(this, ex);
        }

    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        ClearText();
    }
    protected void lnkBtn_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)ViewState["ds"];

        int rl_id = int.Parse(ViewState["rl_id"].ToString());
        obj_RLDetails.RL_ID = rl_id;
        string Filename = obj_RLDetails.Get_FileName_ByID(obj_RLDetails);

        string TargetDir = Server.MapPath("~/UploadedFiles/").ToString() + Filename;
        if (File.Exists(TargetDir))
            Response.Redirect("~/public/DownloadFile.aspx?fileName=" + Filename + "");
        else
            throw new FileNotFoundException();
    }
}
