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

public partial class tiny_mce_gallery_UploadImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Path"] = Request["IDE"];
        ViewState["Dir"] = Request["IDE1"];
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        if (!fupUpload.HasFile)
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
                    lblError.Text = "Image with same name already exists.";
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
        if (strType.Equals("image/jpeg") || strType.Equals("image/gif") || strType.Equals("image/jpg") || strType.Equals("image/bmp") || strType.Equals("image/pjpg") || strType.Equals("image/pjpeg") || strType.Equals("image/x-png"))
        {

            fupUpload.SaveAs(Server.MapPath("~/" + ConfigurationManager.AppSettings["CMSCtrlRootPath"]) + strPath + "/" + fupUpload.FileName);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveScript", "SaveSuccess();", true);
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Please upload only Images of type jpeg,gif,bmp and png";
            return;
        }
    }
}
