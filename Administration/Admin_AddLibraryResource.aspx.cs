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
using System.IO;

//using ABSBLL;
//using ABSCommon;
//using System.Data;

//New Version of AdminAddResource.aspx
public partial class Administration_AdminAddLibraryResources : System.Web.UI.Page
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
    string StrFileName = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        //ViewState["type"] = "insert";
        if (!Page.IsPostBack)
        {
            ViewState["Links"] = chkAccess.initSystem();
            ViewState["t_url"] = "../" + ViewState["Links"].ToString().Split('|')[2];
            ViewState["t_urlback"] = "../" + ViewState["Links"].ToString().Split('|')[1];
            ViewState["fidlink"] = Convert.ToString(Session["fidlink"]);

            // string v = Request["IDforEdit"].ToString();
            if (Request.Form["token"] != null && Request.Form["token"]!="")
            {
                token = Request.Form["token"];
                ViewState["ViewToken"] = Request.Form["token"];
                ViewState["ViewTokenFlag"] = "Yes";
            }
            lbloperation.Text = "insert";
            //if (ViewState["ViewTokenFlag"] != "")
            //{
                BindCategory();
                if (Request["IDforEdit"] != "")
                {

                    string str = CommonFunctions.Decrypt(Request["IDforEdit"]);
                    nid = Convert.ToInt32(str);
                    ViewState["nid"] = nid;
                    BindCheckListWithSel(nid);
                    //ViewState["type"] = "update";
                    lbloperation.Text = "update";
                    Get_NewsDetails_ById(nid);
                }
            //}
            //else
            //{
            //    Response.Redirect("default.aspx");
            //}
        }
    }
    public void Get_NewsDetails_ById(int id)
    {
        obj_RsDetails.RL_ID = id;

        //DataSet dsbyid = obj_RsDetails.Get_NewsDetails_ByID(obj_RsDetails);
        DataSet dsbyid = obj_RsDetails.Get_ResourceLibDetails_ByID (obj_RsDetails);
        if (dsbyid.Tables[0].Rows.Count > 0)
        {
            id_txt_AddTitle.Text = dsbyid.Tables[0].Rows[0]["Title"].ToString();
            id_txt_AddChTitle.Text = dsbyid.Tables[0].Rows[0]["C_Title"].ToString();
            //id_txt_AddAuthor.Text = dsbyid.Tables[0].Rows[0]["Author_Name"].ToString();
            txtDescription.Text = dsbyid.Tables[0].Rows[0]["Description"].ToString();
            txtChDescription.Text = dsbyid.Tables[0].Rows[0]["C_Description"].ToString();
            id_txt_AddDetails.Text = dsbyid.Tables[0].Rows[0]["RL_Details"].ToString();
            id_txt_ChineseAddDetails.Text = dsbyid.Tables[0].Rows[0]["C_RL_Details"].ToString();
            //id_ddl_Rating.SelectedValue = dsbyid.Tables[0].Rows[0]["Rating"].ToString();
            ddlImage.ClearSelection();
            ddlImage.Items.FindByValue(dsbyid.Tables[0].Rows[0]["CreateImage"].ToString()).Selected = true;
            txtLevel.Text = dsbyid.Tables[0].Rows[0]["Level"].ToString();
            //DatePicker_PublishedOn.DateString = CommonBindings.TextToBind(dsbyid.Tables[0].Rows[0]["publishedon"].ToString());
            if (!string.IsNullOrEmpty(dsbyid.Tables[0].Rows[0]["RL_FileName"].ToString()))
            {
                ViewState["ViewRL_FileName"] = dsbyid.Tables[0].Rows[0]["RL_FileName"].ToString();
                lbtnViewFile.Visible = true;
            }
            if (!string.IsNullOrEmpty(dsbyid.Tables[0].Rows[0]["C_RL_FileName"].ToString()))
            {
                ViewState["ViewC_RL_FileName"] = dsbyid.Tables[0].Rows[0]["C_RL_FileName"].ToString();
                lbtnChineseViewFile.Visible = true;
            }
            if (!string.IsNullOrEmpty(dsbyid.Tables[0].Rows[0]["DocSelection"].ToString()))
            {
                lbArticles.ClearSelection();
                string strDocSelection = dsbyid.Tables[0].Rows[0]["DocSelection"].ToString();
                if (strDocSelection.Length == 1)
                    strDocSelection = strDocSelection + ",";
                string[] strArrDocSelection = strDocSelection.Split(',');
                for (int i = 0; i < strArrDocSelection.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strArrDocSelection[i]))
                    {
                        for (int j = 0; j < lbArticles.Items.Count; j++)
                        {
                            if (lbArticles.Items[j].Value == strArrDocSelection[i])
                                lbArticles.Items[j].Selected = true;
                        }
                    }
                }
            }
            rbtnStatus.ClearSelection();
            rbtnStatus.Items.FindByValue(dsbyid.Tables[0].Rows[0]["RL_Status"].ToString()).Selected = true;
        }


    }
    public void BindCheckListWithSel(int nid)
    {
        DataSet dsselcat = new System.Data.DataSet();
        obj_RsDetails.RL_ID = nid;
        obj_RsDetails.Type = "RL";
        dsselcat = obj_RsDetails.GetSelResourceLibCategory(obj_RsDetails);
        if (dsselcat != null && dsselcat.Tables.Count > 0 && dsselcat.Tables[0].Rows.Count > 0)
        {
            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue(dsselcat.Tables[0].Rows[0]["TopicID"].ToString()).Selected = true;
        }
    }
    public void BindCategory()
    {
        DataSet ds = new DataSet();
        obj_RsDetails.Type = "RL";
        ds = obj_RsDetails.Get_ResourceLibCategory (obj_RsDetails);
        ddlCategory.DataSource = ds;
        ddlCategory.DataTextField = "TopicName";
        ddlCategory.DataValueField = "TopicID";
        ddlCategory.DataBind();
        ListItem li = new ListItem();
        li.Text = "Select";
        li.Value = "0";
        ddlCategory.Items.Insert(0, li);

        obj_RsDetails = new ResourceLibDetails();
        obj_RsDetails.Admin = "list";
        DataSet dsRS = new DataSet();
        dsRS = obj_RsDetails.Get_ResourceLibDetails(obj_RsDetails);
        lbArticles.DataSource = dsRS;
        lbArticles.DataTextField = "Title";
        lbArticles.DataValueField = "RL_ID";
        lbArticles.DataBind();
        ListItem li1 = new ListItem();
        li1.Text = "None";
        li1.Value = "0";
        lbArticles.Items.Insert(0, li1);
    }

    //public void bingcategory()
    //{



    //}

    public void Insert_Category()
    {
        obj_RsDetails.RL_ID= Convert.ToInt32(ViewState["nid"].ToString());
        obj_RsDetails.tagno = int.Parse(ddlCategory.SelectedValue);
        obj_RsDetails.Insert_ResourceLibCategoryDetails(obj_RsDetails);
    }
    int id;
    protected void Button_Save_Click(object sender, ImageClickEventArgs e)
    {
        if (!string.IsNullOrEmpty(FURLFileUpload.PostedFile.FileName))
        {
            if (!lblDeleteFlag.Visible)
            {
                string fileExtension = Path.GetExtension(FURLFileUpload.PostedFile.FileName);
                if (fileExtension.ToLower() == ".doc" || fileExtension.ToLower() == ".docx" || fileExtension.ToLower() == ".pdf" || fileExtension.ToLower() == ".ppt" || fileExtension.ToLower() == ".pptx" || fileExtension.ToLower() == ".xls" || fileExtension.ToLower() == ".xlsx")
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(FURLFileUpload.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(FURLFileUpload, Server.MapPath("~/UploadedFiles"), StrFileName);
                    obj_RsDetails.RL_FileName = StrFileName;
                }
                else
                {
                    Common.ShowMessage(this, "Please select only supported files");
                    return;
                }
            }
            else
                obj_RsDetails.RL_FileName = DBNull.Value.ToString();
        }
        else if (ViewState["ViewRL_FileName"] != null && Convert.ToString(ViewState["ViewRL_FileName"]) != "")
            obj_RsDetails.RL_FileName = Convert.ToString(ViewState["ViewRL_FileName"]);
        else
            obj_RsDetails.RL_FileName = DBNull.Value.ToString();

        if (!string.IsNullOrEmpty(ChineseFURLFileUpload.PostedFile.FileName))
        {
            if (!lblDeleteChineseFlag.Visible)
            {
                string fileExtension = Path.GetExtension(ChineseFURLFileUpload.PostedFile.FileName);
                if (fileExtension.ToLower() == ".doc" || fileExtension.ToLower() == ".docx" || fileExtension.ToLower() == ".pdf" || fileExtension.ToLower() == ".ppt" || fileExtension.ToLower() == ".pptx" || fileExtension.ToLower() == ".xls" || fileExtension.ToLower() == ".xlsx")
                {
                    StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(ChineseFURLFileUpload.PostedFile.FileName);
                    ABSCommon.Common.UploadFile(ChineseFURLFileUpload, Server.MapPath("~/UploadedFiles"), StrFileName);
                    obj_RsDetails.C_RL_FileName = StrFileName;
                }
                else
                {
                    Common.ShowMessage(this, "Please select only supported files");
                    return;
                }
            }
            else
                obj_RsDetails.C_RL_FileName = DBNull.Value.ToString();
        }

        else if (ViewState["ViewC_RL_FileName"] != null && Convert.ToString(ViewState["ViewC_RL_FileName"]) != "")
            obj_RsDetails.C_RL_FileName = Convert.ToString(ViewState["ViewC_RL_FileName"]);

        else
            obj_RsDetails.C_RL_FileName = DBNull.Value.ToString();
        
        obj_RsDetails.RLStatus = rbtnStatus.SelectedValue;

        if (lbloperation.Text == "insert")
        {
            obj_RsDetails.Type = "insert";
            

            obj_RsDetails.Title = id_txt_AddTitle.Text;
            obj_RsDetails.C_Title = id_txt_AddChTitle.Text;
            obj_RsDetails.Description = txtDescription.Text;
            obj_RsDetails.C_Description = txtChDescription.Text;
            //id_txt_AddDescription.Text;
            //obj_RsDetails.Author = id_txt_AddAuthor.Text;
            obj_RsDetails.Published_On = DateTime.Now;
            obj_RsDetails.Created_On = DateTime.Now.Date;
            obj_RsDetails.Created_By = Session["USER_ID"].ToString();
            obj_RsDetails.Updated_On = DateTime.Now.Date;
            obj_RsDetails.Updated_By = Session["USER_ID"].ToString();
            //obj_RsDetails.Rating = Convert.ToInt32(id_ddl_Rating.SelectedItem.Value);
            obj_RsDetails.NewsDetails = id_txt_AddDetails.Text;
            obj_RsDetails.CNewdetails = id_txt_ChineseAddDetails.Text;
            obj_RsDetails.ImageType = ddlImage.SelectedValue;
            obj_RsDetails.Level = txtLevel.Text;
            
            
            // Recommended Articles code
            for (int i = 0; i < lbArticles.Items.Count; i++)
            {
                if (i != 0)
                {
                    if (lbArticles.Items[i].Selected)
                    {
                        if (string.IsNullOrEmpty(obj_RsDetails.DocSelection))
                            obj_RsDetails.DocSelection = lbArticles.Items[i].Value;
                        else
                            obj_RsDetails.DocSelection = "," + lbArticles.Items[i].Value;
                    }
                }
            }
            // End Code

            id = obj_RsDetails.Update_ResourceLibDetails (obj_RsDetails);
            ViewState["nid"] = id;
            obj_RsDetails.RL_ID = Convert.ToInt32(ViewState["nid"].ToString());
            
            Insert_Category();
        }
        else
        {
            obj_RsDetails.RL_ID = Convert.ToInt32(ViewState["nid"].ToString());
            obj_RsDetails.Delete_ResourceLibCategoryDetails(obj_RsDetails);
            Insert_Category();

            obj_RsDetails.Type = "update";
            obj_RsDetails.Title = id_txt_AddTitle.Text;
            obj_RsDetails.C_Title = id_txt_AddChTitle.Text;
            obj_RsDetails.Description = txtDescription.Text;
            obj_RsDetails.C_Description = txtChDescription.Text;
            // id_txt_AddDescription.Text;
            //obj_RsDetails.Author = id_txt_AddAuthor.Text;
            obj_RsDetails.Published_On = DateTime.Now;
            obj_RsDetails.Created_On = DateTime.Now.Date;
            obj_RsDetails.Created_By = Session["USER_ID"].ToString();
            obj_RsDetails.Updated_On = DateTime.Now.Date;
            obj_RsDetails.Updated_By = Session["USER_ID"].ToString();
            //obj_RsDetails.Rating = Convert.ToInt32(id_ddl_Rating.SelectedItem.Value);
            obj_RsDetails.NewsDetails = id_txt_AddDetails.Text;
            obj_RsDetails.CNewdetails = id_txt_ChineseAddDetails.Text;
            obj_RsDetails.ImageType = ddlImage.SelectedValue;
            obj_RsDetails.Level = txtLevel.Text;
            obj_RsDetails.RL_ID = Convert.ToInt32(ViewState["nid"].ToString());

            if (!string.IsNullOrEmpty(FURLFileUpload.PostedFile.FileName))
            {
                StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(FURLFileUpload.PostedFile.FileName);
                ABSCommon.Common.UploadFile(FURLFileUpload, Server.MapPath("~/UploadedFiles"), StrFileName);
                obj_RsDetails.RL_FileName = StrFileName;
            }

            if (!string.IsNullOrEmpty(FURLFileUpload.PostedFile.FileName))
            {
                StrFileName = DateTime.Now.ToFileTime().ToString().Replace("/", "") + System.IO.Path.GetFileName(FURLFileUpload.PostedFile.FileName);
                ABSCommon.Common.UploadFile(FURLFileUpload, Server.MapPath("~/UploadedFiles"), StrFileName);
                obj_RsDetails.C_RL_FileName = StrFileName;
            }

            // Recommended Articles code
            for (int i = 0; i < lbArticles.Items.Count; i++)
            {
                if (i != 0)
                {
                    if (lbArticles.Items[i].Selected)
                    {
                        if (string.IsNullOrEmpty(obj_RsDetails.DocSelection))
                            obj_RsDetails.DocSelection = lbArticles.Items[i].Value;
                        else
                            obj_RsDetails.DocSelection += "," + lbArticles.Items[i].Value;
                    }
                }
            }
            // End Code

            id = obj_RsDetails.Update_ResourceLibDetails(obj_RsDetails);
        }
        if (id > 0)
        {
            string _redirectPath = ConfigurationManager.AppSettings["InternalUrl"] + Convert.ToString(ViewState["fidlink"]);
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Resource Library Details Saved Successfully.'); location='" + _redirectPath + "';</Script>");
        }
    }
    public void Delete_Category(int nid)
    {
        obj_RsDetails.RL_ID  = nid;
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void lbtnViewFile_Click(object sender, EventArgs e)
    {
        if (ViewState["ViewRL_FileName"] != null && Convert.ToString(ViewState["ViewRL_FileName"]) != "")
        {
            ABSCommon.Common.DownloadFile(Convert.ToString(ViewState["ViewRL_FileName"]), true);
            //ABSCommon.Common.DownloadFile(Server.MapPath("~/UploadedFiles/" + Convert.ToString(ViewState["ViewRL_FileName"])), true);
        }
    }
    protected void lbtnChineseViewFile_Click(object sender, EventArgs e)
    {
        if (ViewState["ViewC_RL_FileName"] != null && Convert.ToString(ViewState["ViewC_RL_FileName"]) != "")
        {
            ABSCommon.Common.DownloadFile(Convert.ToString(ViewState["ViewC_RL_FileName"]), true);
            //ABSCommon.Common.DownloadFile(Server.MapPath("~/UploadedFiles/" + Convert.ToString(ViewState["ViewRL_FileName"])), true);
        }

    }
    protected void ibtnDeleteFile_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(FURLFileUpload.PostedFile.FileName) || (ViewState["ViewRL_FileName"] != null && Convert.ToString(ViewState["ViewRL_FileName"]) != ""))
            {
                ViewState["ViewRL_FileName"] = string.Empty;
                lblDeleteFlag.Visible = true;
                if (Request["IDforEdit"] != "")
                    lbtnViewFile.Visible = false;
                Common.ShowMessage(this, "Download File Removed");
            }
            else
                Common.ShowMessage(this, "File not Exists!");
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }
    }
    protected void ibtnDeleteChineseFile_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!string.IsNullOrEmpty(FURLFileUpload.PostedFile.FileName) || (ViewState["ViewC_RL_FileName"] != null && Convert.ToString(ViewState["ViewC_RL_FileName"]) != ""))
            {
                ViewState["ViewC_RL_FileName"] = string.Empty;
                lblDeleteChineseFlag.Visible = true;
                if (Request["IDforEdit"] != "")
                    lbtnChineseViewFile.Visible = false;
                Common.ShowMessage(this, "Download File Removed");
            }
            else
                Common.ShowMessage(this, "File not Exists!");
        }
        catch (Exception ex)
        {
            Common.ErrorMessage(this, ex);
        }

    }
}
