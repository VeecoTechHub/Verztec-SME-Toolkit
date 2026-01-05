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
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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

    private bool ValidateFile(byte[] bytes, string extension)
    {
        if (extension == ".pdf")
        {
            if (bytes.Length < 4 || Encoding.ASCII.GetString(bytes, 0, 4) != "%PDF")
                return false;
        }
        else if (extension == ".doc")
        {
            if (bytes.Length < 8 || BitConverter.ToUInt64(bytes, 0) != 0xE011CFD0A1B11AE1UL)
                return false;
        }
        else if (extension == ".docx")
        {
            if (bytes.Length < 2 || bytes[0] != 0x50 || bytes[1] != 0x4B)
                return false;
        }
        else // images
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(ms))
                    {
                        // valid image
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        return true;
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

        string fileName = fupUpload.FileName;
        string extension = Path.GetExtension(fileName).ToLowerInvariant();
        List<string> allowedExtensions = new List<string> { ".pdf", ".doc", ".docx", ".jpg", ".jpeg", ".png", ".gif" };
        if (!allowedExtensions.Contains(extension))
        {
            lblError.Text = "Invalid file type. Only PDF, DOC, DOCX, JPG, JPEG, PNG, GIF are allowed.";
            return;
        }

        // Check for double extensions or suspicious
        if (fileName.Contains("..") || fileName.Split('.').Length > 2)
        {
            lblError.Text = "Invalid file name.";
            return;
        }

        string contentType = fupUpload.PostedFile.ContentType;
        Dictionary<string, string> allowedContentTypes = new Dictionary<string, string>
        {
            {".pdf", "application/pdf"},
            {".doc", "application/msword"},
            {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
            {".jpg", "image/jpeg"},
            {".jpeg", "image/jpeg"},
            {".png", "image/png"},
            {".gif", "image/gif"}
        };
        if (!allowedContentTypes.ContainsKey(extension) || contentType != allowedContentTypes[extension])
        {
            lblError.Text = "Invalid content type.";
            return;
        }

        // Read file bytes
        byte[] fileBytes = new byte[fupUpload.PostedFile.ContentLength];
        fupUpload.PostedFile.InputStream.Read(fileBytes, 0, fileBytes.Length);

        // Validate file content
        if (!ValidateFile(fileBytes, extension))
        {
            lblError.Text = "File validation failed. The file may be corrupted or not of the expected type.";
            return;
        }

        string strType = string.Empty;
        string strPath = string.Empty;


        strType = fupUpload.PostedFile.ContentType;
        strPath = Convert.ToString(ViewState["Path"]).Remove(0, 6);
        //if (fupUpload.PostedFile.ContentLength < 10485760)-- For 10MB
        if (fupUpload.PostedFile.ContentLength < 31457280)
        {
            // Save file
            string fullPath = Server.MapPath("~/" + ConfigurationManager.AppSettings["CMSCtrlRootPath"]) + strPath + "/" + fupUpload.FileName;
            File.WriteAllBytes(fullPath, fileBytes);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveScript", "SaveSuccess();", true);
                
            lblError.Text = "";
        }
        else
        {
            lblError.Visible = true;
            lblError.Text = "Max file can be uploaded is 30MB";
        }

    }
}
