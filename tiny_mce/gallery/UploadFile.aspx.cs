using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class tiny_mce_gallery_UploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Path"] = Request["IDE"];
        if (Convert.ToString(ViewState["Path"]).ToUpper() == "/IMAGEREPOSITORY")
        {
            // ViewState["Path"] = "/files" + ViewState["Path"].ToString();
            ViewState["Path"] = "/files";
        }
        ViewState["Dir"] = Request["IDE1"];
        Session["Dir1"] = Session["CurDir"];
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {

        if (fupUpload.HasFile == false)
        {
            lblError.Visible = true;
            lblError.Text = "Please select a file and upload.";
            return;
        }
        else
        {
            lblError.Text = "";
        }
        DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(Convert.ToString(ViewState["Dir"])));
        if (dirInfo.Exists)
        {
            FileInfo[] fileEntries = dirInfo.GetFiles();
            foreach (FileInfo fileTemp in fileEntries)
            {
                if (fileTemp.Name == fupUpload.FileName.ToString())
                {
                    lblError.Visible = true;
                    lblError.Text = "File with same name already exists.";
                    return;
                }
                else
                {
                    lblError.Text = "";
                }
            }
        }

        string strType = string.Empty;
        string strPath = string.Empty;


        strType = fupUpload.PostedFile.ContentType;
        strPath = Convert.ToString(ViewState["Path"]).Remove(0, 6);
        //if (fupUpload.PostedFile.ContentLength < 10485760)-- For 10MB
        if (fupUpload.PostedFile.ContentLength < 31457280)
        {
            //if (!strType.Equals(".db") && !strType.Equals(".exe"))
            //{
            //    if (strType.Equals("image/jpeg") || strType.Equals("image/gif") || strType.Equals("image/jpg") || strType.Equals("image/bmp") || strType.Equals("image/pjpg") || strType.Equals("image/pjpeg") || strType.Equals("image/x-png") || strType.Equals("application/msword") || strType.Equals("application/pdf") || strType.Equals("text/plain") || strType.Equals("application/x-shockwave-flash"))
            //    {
          
                fupUpload.SaveAs(Server.MapPath("~/" + ConfigurationManager.AppSettings["CMSCtrlRootPath"]) + strPath + "/" + fupUpload.FileName);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveScript", "SaveSuccess();", true);
                
          

               
           
                //    }
            //}
            lblError.Text = "";
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Max file can be uploaded is 30MB";
        }

    }
}
