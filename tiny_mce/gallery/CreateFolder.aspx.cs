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
public partial class tiny_mce_gallery_CreateFolder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Path"] = Request["IDE"];
        ViewState["Dir"] = Request["IDE1"];
        Session["Dir1"] = Session["CurDir"];
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(Convert.ToString(ViewState["Dir"])));
            if (dirInfo.Exists)
            {
                DirectoryInfo[] DirEntries = dirInfo.GetDirectories();
                foreach (DirectoryInfo DirTemp in DirEntries)
                {
                    if (DirTemp.Name == txtFolderName.Text.Trim())
                    {
                        lblError.Visible = true;
                        lblError.Text = "Folder with same name already exists.";
                        return;
                    }
                    else
                    {
                        lblError.Text = "";
                    }
                }
            }
            Directory.CreateDirectory(Path.Combine(Server.MapPath(Convert.ToString(ViewState["Dir"])), Path.GetFileName(txtFolderName.Text)));
            //txtFolderName.Text = string.Empty;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "SaveScript", "SaveSuccess();", true);
        }
        catch (Exception err)
        {
            throw err;
        }
    }
}
