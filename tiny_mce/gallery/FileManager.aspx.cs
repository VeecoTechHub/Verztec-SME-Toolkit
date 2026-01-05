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
using System.Reflection;

public partial class FileManager : System.Web.UI.Page
{
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public static string strImg1 = "";
    public static string strImg2 = "";
    public static object obj1;
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Url"] = Convert.ToString(ConfigurationManager.AppSettings["InternalUrl"]);
        ViewState["imgName"] = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Picture-Not-Available.gif";
        if (!Page.IsPostBack)
        {
            if (Session["Dir1"] != null)
            {
                Session["CurDir"] = Session["Dir1"];
                Session["Dir1"] = null;
            }
            else
            {
                Session["CurDir"] = null;
            }
            ViewState["CLocation"] = "/ImageRepository";
            ViewState["CurDirectory"] = ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString();
            ViewState["CurrentPath"] = ConfigurationManager.AppSettings["CMSCtrlRootPath"].ToString();
            BindFiles("FileType", " Desc");
        }
        btnDelete.Attributes.Add("onClick", "return confirm('Are you sure you want to delete the selected record? Once deleted you will not be able to view it again. Click OK to delete. Otherwise, click Cancel.');");
    }

    private void BindFiles(string sortExpression, string direction)
    {
        try
        {
            ViewState["sortExp"] = sortExpression;
            ViewState["Direction"] = direction;
            string strPath = string.Empty;
            if (Session["CurDir"] != null)
            {
                strPath = Convert.ToString(Session["CurDir"]);
            }
            else
            {
                strPath = Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["CMSEditorImagePath"]));
                Session["CurDir"] = strPath;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(strPath);
            if (dirInfo.Exists)
            {
                DirectoryInfo[] dirList = dirInfo.GetDirectories();
                FileInfo[] filList = dirInfo.GetFiles();

                //if (dirList.Length > 0 || filList.Length > 0)
                //{ }
                DataTable dtFiles = new DataTable();
                dtFiles = CreateTable();

                if (!strPath.Equals(Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["CMSEditorImagePath"]))))
                {
                    DataRow drow = dtFiles.NewRow();
                    drow["FolderName"] = "11Back";
                    drow["FilePath"] = strPath;
                    dtFiles.Rows.Add(drow);
                }

                foreach (DirectoryInfo dir in dirList)
                {
                    DataRow drow = dtFiles.NewRow();
                    drow["FolderName"] = dir.Name;
                    drow["FileSize"] = string.Empty;
                    drow["FileType"] = "Folder";
                    drow["FileModifyDate"] = Convert.ToDateTime(dir.LastWriteTime);
                    drow["FilePath"] = dir.FullName;
                    dtFiles.Rows.Add(drow);
                }

                foreach (FileInfo file in filList)
                {
                    if (!file.Extension.ToLower().Equals(".db"))
                    {
                        DataRow drow = dtFiles.NewRow();
                        drow["FolderName"] = file.Name;
                        drow["FileSize"] = file.Length;
                        drow["FileType"] = file.Extension;
                        drow["FileModifyDate"] = Convert.ToDateTime(file.LastWriteTime);
                        //drow["FilePath"] = Convert.ToString(ViewState["CurrentPath"]) + "\\" + file.Name;
                        drow["FilePath"] = file.Name;
                        dtFiles.Rows.Add(drow);
                    }
                }

                DataView dv = new DataView(dtFiles);
                dv.Sort = sortExpression + direction;
                gvFolder.DataSource = dv;
                gvFolder.DataBind();



                //if (!Convert.ToString(ViewState["imgName"]).Equals(ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Picture-Not-Available.gif"))
                //{
                //    trViewImg.Visible = true;
                //    trNOImg.Visible = false;
                //    img.Visible = true;
                //    lblViewImage.Enabled = true;
                //}
                //else
                //{
                //    trViewImg.Visible = false;
                //    trNOImg.Visible = true;
                //    lblNOImg.Enabled = false;
                //    img.Visible = true;
                //    img.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Picture-Not-Available.gif";
                //}

                if (string.IsNullOrEmpty(lblImageHeading.Text))
                {
                    trViewImg.Visible = false;
                    trNOImg.Visible = true;
                    lblNOImg.Enabled = false;
                    img.Visible = true;
                    img.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Picture-Not-Available.gif";
                }
                else
                {
                    trViewImg.Visible = true;
                    trNOImg.Visible = false;
                    img.Visible = true;
                    lblViewImage.Enabled = true;
                    string strExtension = Path.GetExtension(lblImageHeading.Text);
                    if (strExtension.Equals(".pdf") || strExtension.Equals("application/msword") || strExtension.Equals(".doc") || strExtension.Equals(".txt"))
                    {
                        lblViewImage.Text = "View File";
                    }
                    else
                    {
                        lblViewImage.Text = "View Image";
                    }
                }
            }
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    protected void gvFolder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["imgName"] = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Picture-Not-Available.gif";
        lblImageHeading.Text = string.Empty;
        if (e.CommandName.ToString() == "getRDetails")
        {
            if (Session["CurDir"] != null && !Convert.ToString(Session["CurDir"]).Equals(Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["CMSEditorImagePath"]))))
            {
                if (e.CommandArgument.ToString().Contains("."))
                {
                    ViewState["CurrentPath"] = buildPath(Session["CurDir"].ToString());
                    FindFileType(e.CommandArgument.ToString());
                    lblImageHeading.Text = e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().LastIndexOf("/") + 1);
                }
                else if (e.CommandArgument.ToString().ToLower().Equals("11back"))
                {
                    if (Convert.ToString(Session["CurDir"]).EndsWith("\\"))
                    {
                        Session["CurDir"] = Convert.ToString(Session["CurDir"]).Remove(Convert.ToString(Session["CurDir"]).LastIndexOf("\\"));
                    }
                    Session["CurDir"] = Convert.ToString(Session["CurDir"]).Remove(Convert.ToString(Session["CurDir"]).LastIndexOf("\\") + 1);
                    ViewState["CurrentPath"] = buildPath(Session["CurDir"].ToString()) + "/";
                    img.Width = Unit.Pixel(170);
                    img.Height = Unit.Pixel(180);
                }
                else
                {
                    Session["CurDir"] = Convert.ToString(e.CommandArgument.ToString());
                    ViewState["CurrentPath"] = buildPath(Session["CurDir"].ToString()) + "/";
                    img.Width = Unit.Pixel(170);
                    img.Height = Unit.Pixel(180);
                }
            }
            else
            {
                if (e.CommandArgument.ToString().Contains("."))
                {
                    ViewState["CurrentPath"] = buildPath(Session["CurDir"].ToString());
                    FindFileType(e.CommandArgument.ToString());
                    lblImageHeading.Text = e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().LastIndexOf("\\") + 1);
                }
                else
                {
                    Session["CurDir"] = Convert.ToString(e.CommandArgument.ToString());
                    ViewState["CurrentPath"] = buildPath(Session["CurDir"].ToString()) + "/";
                    img.Width = Unit.Pixel(170);
                    img.Height = Unit.Pixel(180);
                }
            }
            img.ImageUrl = Convert.ToString(ViewState["imgName"]);
            BindFiles("FileSize", " ASC");
        }
    }

    protected void gvFolder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LinkButton lbRootName = (LinkButton)e.Row.FindControl("lbRootName");
        ImageButton imgFolder = (ImageButton)e.Row.FindControl("imgFolder");
        Label lblRootName = (Label)e.Row.FindControl("lblRootName");

        //HtmlInputCheckBox chkId = (HtmlInputCheckBox)e.Row.FindControl("chkId");
        CheckBox chkId = (CheckBox)e.Row.FindControl("chkId");

        if (lbRootName != null && imgFolder != null && lblRootName != null && chkId != null)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(lblRootName.Text.Trim());
            string strExtention = dirInfo.Extension.ToString();

            if (lblRootName.Text == "11Back")
            {
                chkId.Visible = false;
                imgFolder.Visible = true;
                lbRootName.Visible = false;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "backImg.jpg";
            }
            else if (strExtention == "")
            {
                imgFolder.Visible = true;
                lbRootName.Visible = true;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "folder-icon.gif";
            }
            else if (strExtention == ".pdf")
            {
                imgFolder.Visible = true;
                lbRootName.Visible = true;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "pdfImg.png";
            }
            else if (strExtention == ".doc" || strExtention == "application/msword")
            {
                imgFolder.Visible = true;
                lbRootName.Visible = true;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "wordImg.png";
            }
            else if (strExtention == ".txt")
            {
                //Microsoft Office Excel 2007.png
                //Microsoft Office Word 2007.png
                //Microsoft Office Access 2007.png
                //Microsoft Office PowerPoint 2007.png
                //Microsoft Office Outlook 2007.png
                imgFolder.Visible = true;
                lbRootName.Visible = true;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "text.jpg";
            }


            else if (strExtention == ".docx" || strExtention == "application/msword")
            {
                imgFolder.Visible = true;
                lbRootName.Visible = true;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Microsoft Office Word 2007.png";
                imgFolder.Height = 20;
                imgFolder.Width = 20;
            }
            else if (strExtention == ".xlsx" || strExtention == ".xls" || strExtention == "application/msexcel")
            {
                imgFolder.Visible = true;
                lbRootName.Visible = true;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Microsoft Office Excel 2007.png";
                imgFolder.Height = 20;
                imgFolder.Width =20;
            }
            else if (strExtention == ".pptx" || strExtention == ".ppt" || strExtention == "application/mspowerpoint")
            {
                imgFolder.Visible = true;
                lbRootName.Visible = true;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Microsoft Office PowerPoint 2007.png";
                imgFolder.Height = 20;
                imgFolder.Width = 20;
            }
            else
            {
                imgFolder.Visible = true;
                imgFolder.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "logoImg.gif";
                lbRootName.Visible = true;
            }
        }
    }

    protected void gvFolder_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;

        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            BindFiles(sortExpression, DESCENDING);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            BindFiles(sortExpression, ASCENDING);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        object o = p.GetValue(null, null);
        FieldInfo f = o.GetType().GetField("_dirMonSubdirs", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
        object monitor = f.GetValue(o);
        MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
        m.Invoke(monitor, new object[] { });

        string strChkId = "";
        foreach (GridViewRow gvRow in gvFolder.Rows)
        {
            CheckBox chkId = (CheckBox)gvRow.Cells[0].FindControl("chkId");
            Label lblChk = (Label)gvRow.Cells[0].FindControl("lblChk");
            if (chkId != null)
            {
                if (chkId.Checked == true)
                {
                    if (strChkId != "")
                    {
                        strChkId = strChkId + "," + lblChk.Text.Trim();
                    }
                    else
                    {
                        strChkId = lblChk.Text.Trim();
                    }
                }
            }

        }

        if (strChkId == "")
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Please select atleast one record(s) to Delete.');</Script>");
        }
        else
        {
            //string list = Convert.ToString(Request["chkId"]);
            string list = strChkId;
            string[] id = list.Split(',');
            int len = int.Parse(id.Length.ToString());
            for (int i = 0; i < len; i++)
            {
                string strId = id[i].ToString();
                ViewState["imgName"] = "";

                if (File.Exists(Convert.ToString(Session["CurDir"] + "/" + strId)))
                {
                    File.Delete(Convert.ToString(Session["CurDir"] + "/" + strId));
                }
                DirectoryInfo dirlocal = new DirectoryInfo(strId);
                if (dirlocal.Exists)
                {
                    dirlocal.Delete(true);
                }
            }
            BindFiles("FileSize", " asc");
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alertscript", "<Script language='javascript'> alert('Record(s) deleted successfully.');</Script>");
        }
    }

    protected void lbDownload_Click(object sender, EventArgs e)
    {
        string _file = Convert.ToString(Session["CurDir"]) + "\\" + lblImageHeading.Text;
        if (File.Exists(_file))
        {
            FileInfo objFileInfo = new FileInfo(_file);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + objFileInfo.Name);
            HttpContext.Current.Response.WriteFile(objFileInfo.FullName);
            HttpContext.Current.Response.End();
        }
    }

    protected void lnkRefresh_Click(object sender, EventArgs e)
    {
        BindFiles("FileSize", " asc");
    }

    protected void gvFolder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFolder.PageIndex = e.NewPageIndex;
        BindFiles(ViewState["sortExp"].ToString(), ViewState["Direction"].ToString());
    }

    private DataTable CreateTable()
    {
        DataTable dtTemp = new DataTable();
        dtTemp.Columns.Add("FolderName");
        dtTemp.Columns.Add("FileSize");
        dtTemp.Columns.Add("FileType");
        dtTemp.Columns.Add("FileModifyDate", typeof(DateTime));
        dtTemp.Columns.Add("FilePath");
        return dtTemp;
    }

    private string buildPath(string strPath)
    {
        string strReturn = string.Empty;
        bool bStatus = false;
        if (!string.IsNullOrEmpty(strPath) && strPath.Contains("\\"))
        {
            string[] strSplit = strPath.Split('\\');
            for (int i = strSplit.Length - 1; i > 0; i--)
            {
                if (strSplit[i].Equals("ImageRepository"))
                {
                    bStatus = true;
                }
                if (string.IsNullOrEmpty(strReturn))
                {
                    strReturn = strSplit[i].ToString();
                    if (!bStatus)
                    {
                        ViewState["CLocation"] = "/" + strSplit[i].ToString();
                        ViewState["CurDirectory"] = "/" + strSplit[i].ToString();
                    }
                }
                else
                {
                    strReturn = strSplit[i].ToString() + "/" + strReturn;
                    if (!bStatus)
                    {
                        ViewState["CLocation"] = "/" + strSplit[i].ToString() + Convert.ToString(ViewState["CLocation"]);
                        ViewState["CurDirectory"] = "/" + strSplit[i].ToString() + Convert.ToString(ViewState["CurDirectory"]);
                    }
                }
                if (bStatus)
                {
                    ViewState["CLocation"] = "/files" + ViewState["CLocation"].ToString();
                    ViewState["CurDirectory"] = "../../ImageRepository" + ViewState["CurDirectory"].ToString();
                    return strReturn;
                }
            }
        }
        ViewState["CLocation"] = "/files" + ViewState["CLocation"].ToString();
        ViewState["CurDirectory"] = "../../ImageRepository" + ViewState["CurDirectory"].ToString();
        return strReturn;
    }

    private void FindFileType(string strFile)
    {
        string strReturn = string.Empty;
        string strExtn = Path.GetExtension(strFile);
        if (strExtn.Equals(".jpg") || strExtn.Equals(".jpeg") || strExtn.Equals(".gif") || strExtn.Equals(".pjpg") || strExtn.Equals(".pjpeg") || strExtn.Equals(".x-png") || strExtn.Equals(".bmp") || strExtn.Equals(".png"))
        {
            ViewState["imgName"] = Convert.ToString(ViewState["Url"]) + Convert.ToString(ViewState["CurrentPath"]) + "/" + strFile;
            ViewState["img"] = Convert.ToString(ViewState["Url"]) + Convert.ToString(ViewState["CurrentPath"]) + "/" + strFile;

            System.Drawing.Image imgSize;
            GC.Collect();
            imgSize = System.Drawing.Image.FromFile(Convert.ToString(Session["CurDir"] + "/" + strFile));
            
            img.Width = imgSize.Width;
            img.Height = imgSize.Height;
        }
        else
        {
            ViewState["img"] = Convert.ToString(ViewState["Url"]) + Convert.ToString(ViewState["CurrentPath"]) + "/" + strFile;
            img.Width = Unit.Pixel(170);
            img.Height = Unit.Pixel(180);
        }
    }

    #region Commented
    //private void bindData(string sortExpression, string direction)
    //{
    //    PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
    //    object o = p.GetValue(null, null);
    //    FieldInfo f = o.GetType().GetField("_dirMonSubdirs", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
    //    object monitor = f.GetValue(o);
    //    MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
    //    m.Invoke(monitor, new object[] { });

    //    ViewState["sortExp"] = sortExpression;
    //    ViewState["Direction"] = direction;
    //    DataTable dt = new DataTable();
    //    DataColumn dcMainFName = new DataColumn("FolderName");
    //    DataColumn dcFileSize = new DataColumn("FileSize");
    //    DataColumn dcFileType = new DataColumn("FileType");
    //    DataColumn dcFileModifyDate = new DataColumn("FileModifyDate", typeof(DateTime));
    //    DataColumn dcFilePath = new DataColumn("FilePath");
    //    dt.Columns.Add(dcMainFName);
    //    dt.Columns.Add(dcFileSize);
    //    dt.Columns.Add(dcFileType);
    //    dt.Columns.Add(dcFileModifyDate);
    //    dt.Columns.Add(dcFilePath);
    //    string strVirtualPath = ConfigurationManager.AppSettings["CMSCtrlRootPath"].ToString();
    //    string strVirtualPath1 = ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString();
    //    string strPhysicalpath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "ImageRepository";

    //    string strPathDisplay = string.Empty;
    //    if (Session["CurDir"] != null)
    //    {
    //        ViewState["rootName"] = Session["CurDir"];
    //    }
    //    if (ViewState["rootName"] != null)
    //    {

    //        if (Convert.ToString(ViewState["rootName"]) != "")
    //        {
    //            DataRow dr = dt.NewRow();
    //            dr["FolderName"] = "11Back";
    //            gvFolder.Columns[0].Visible = false;
    //            gvFolder.Columns[2].Visible = false;
    //            gvFolder.Columns[3].Visible = false;
    //            gvFolder.Columns[4].Visible = false;
    //            gvFolder.ShowHeader = false;
    //            dt.Rows.Add(dr);
    //            string[] strSplitComma = Convert.ToString(ViewState["rootName"]).Split(',');

    //            foreach (string str in strSplitComma)
    //            {
    //                if (str != "")
    //                {
    //                    if (strPathDisplay != "")
    //                    {
    //                        strPathDisplay = strPathDisplay + "/" + str;
    //                    }
    //                    else
    //                    {
    //                        strPathDisplay = "/" + str;
    //                    }

    //                    strVirtualPath = strVirtualPath + "/" + str;
    //                    strVirtualPath1 = strVirtualPath1 + "/" + str;
    //                    strPhysicalpath = strPhysicalpath + "/" + str;
    //                }
    //            }
    //            ViewState["CurDirectory"] = strVirtualPath1;
    //            //Session["CurDir"] = Convert.ToString(ViewState["CurDirectory"]);
    //            ViewState["CLocation"] = "/files" + strPathDisplay;
    //            lblPath.Text = strPathDisplay;
    //        }
    //        else
    //        {
    //            ViewState["CurDirectory"] = strVirtualPath1;
    //            //Session["CurDir"] = Convert.ToString(ViewState["CurDirectory"]);
    //            ViewState["CLocation"] = "/files";
    //            strPathDisplay = "";
    //            lblPath.Text = "";
    //        }
    //    }
    //    else
    //    {
    //        ViewState["CurDirectory"] = strVirtualPath1;
    //        //Session["CurDir"] = Convert.ToString(ViewState["CurDirectory"]);
    //        ViewState["CLocation"] = "/files";
    //        strPathDisplay = "";
    //        lblPath.Text = "";
    //    }


    //    string strPath1 = Server.MapPath(strVirtualPath);
    //    string strPath2 = Server.MapPath(strVirtualPath1);
    //    ViewState["localHostPath"] = ConfigurationManager.AppSettings["EditorUrl"].ToString() + "/" + "ImageRepository";
    //    string strCheckPath = Convert.ToString(ViewState["localHostPath"]);
    //    ViewState["FilePath"] = strCheckPath;
    //    if (Directory.Exists(strPath1))
    //    {

    //        img.Visible = false;

    //        DirectoryInfo dirInfo = new DirectoryInfo(strPhysicalpath);
    //        DirectoryInfo[] dirFolInf = dirInfo.GetDirectories();
    //        FileInfo[] fileEntries = dirInfo.GetFiles();

    //        string strFile = "";

    //        foreach (FileInfo fileinform in fileEntries)
    //        {
    //            gvFolder.Columns[0].Visible = true;
    //            gvFolder.Columns[2].Visible = true;
    //            gvFolder.Columns[3].Visible = true;
    //            gvFolder.Columns[4].Visible = false;
    //            gvFolder.ShowHeader = true;
    //            string strFileType = fileinform.Extension.ToString();
    //            string strFileSize = fileinform.Length.ToString();
    //            string[] strSplitFileName = fileinform.FullName.Split('\\');
    //            strFile = strSplitFileName[strSplitFileName.Length - 1].ToString();
    //            if (strFileType != ".db")
    //            {
    //                DataRow dr = dt.NewRow();
    //                dr["FileSize"] = strFileSize;
    //                dr["FileType"] = strFileType;
    //                dr["FolderName"] = strFile;
    //                dr["FileModifyDate"] = fileinform.CreationTime;
    //                dr["FilePath"] = fileinform.FullName;
    //                dt.Rows.Add(dr);
    //            }
    //        }

    //        foreach (DirectoryInfo dirInfo1 in dirFolInf)
    //        {
    //            gvFolder.Columns[0].Visible = true;
    //            gvFolder.Columns[2].Visible = true;
    //            gvFolder.Columns[3].Visible = true;
    //            gvFolder.Columns[4].Visible = true;
    //            gvFolder.ShowHeader = true;
    //            string strFileType = "Folder";
    //            string strFileSize = "";
    //            string[] strSplitFileName = dirInfo1.FullName.Split('\\');
    //            strFile = strSplitFileName[strSplitFileName.Length - 1].ToString();

    //            DataRow dr = dt.NewRow();
    //            dr["FileSize"] = strFileSize;
    //            dr["FileType"] = strFileType;
    //            dr["FolderName"] = strFile;
    //            dr["FileModifyDate"] = dirInfo1.CreationTime;
    //            dr["FilePath"] = dirInfo1.FullName;
    //            dt.Rows.Add(dr);
    //        }
    //    }
    //    if (ViewState["imgName"] != null && Convert.ToString(ViewState["imgName"]) != "")
    //    {

    //        trViewImg.Visible = true;
    //        trNOImg.Visible = false;
    //        img.Visible = true;
    //        lblViewImage.Enabled = true;
    //        img.ImageUrl = strVirtualPath + "/" + Convert.ToString(ViewState["imgName"]);
    //        strImg1 = strVirtualPath1 + "/" + Convert.ToString(ViewState["imgName"]);
    //        strImg2 = ConfigurationManager.AppSettings["EditorUrl"].ToString() + strVirtualPath1.Remove(0, 6) + Convert.ToString(ViewState["imgName"]);
    //        ViewState["strVirtualPath1"] = strVirtualPath1;
    //        lblImageHeading.Text = Convert.ToString(ViewState["imgName"]);
    //        FileInfo fileTemp = new FileInfo(strImg1);
    //        if (fileTemp.Extension == ".pdf" || fileTemp.Extension == "application/msword" || fileTemp.Extension == ".doc")
    //        {
    //            img.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Picture-Not-Available.gif";
    //            lblViewImage.Text = "View File";
    //        }
    //        else
    //        {
    //            lblViewImage.Text = "View Image";
    //        }
    //    }
    //    else
    //    {
    //        trViewImg.Visible = false;
    //        trNOImg.Visible = true;
    //        lblNOImg.Enabled = false;
    //        img.Visible = true;
    //        img.ImageUrl = ConfigurationManager.AppSettings["galleryImgPath"].ToString() + "/" + "Picture-Not-Available.gif";
    //        lblImageHeading.Text = "";
    //    }

    //    //if (intFlag == 0)
    //    //{  }
    //    DataView dv = new DataView(dt);
    //    dv.Sort = sortExpression + direction;
    //    gvFolder.DataSource = dv;
    //    gvFolder.DataBind();

    //} 
    #endregion
}
