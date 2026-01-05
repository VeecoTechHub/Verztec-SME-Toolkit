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
public partial class tiny_mce_gallery_ImageManager : System.Web.UI.Page
{
    string strPath = string.Empty;

    DataTable dt;
    ArrayList a = new ArrayList();
    ArrayList b = new ArrayList();
    PagedDataSource pg = new PagedDataSource();

    public int CurrentPage1
    {
        get
        {
            // look for current page in ViewState
            object o = this.ViewState["_CurrentPage1"];
            if (o == null)
                return 0; // default page index of 0
            else
                return (int)o;
        }

        set
        {
            this.ViewState["_CurrentPage1"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ViewState["Url"] = Convert.ToString(ConfigurationManager.AppSettings["InternalUrl"]);
        if (!IsPostBack)
        {
            //Session["Selected"] = "Kiran/Sub-Folder1/Test1/Test23";
            ImageOpen.Visible = true;
            imgClose.Visible = false;
            if (Session["Dir"] != null && Session["Path"] != null && Session["Location"] != null)
            {
                ViewState["CurDirectory"] = Session["Dir"];
                ViewState["CurrentPath"] = Session["Path"];
                ViewState["CLocation"] = Session["Location"];
            }
            else
            {
                ViewState["CurDirectory"] = ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString();
                ViewState["CurrentPath"] = ConfigurationManager.AppSettings["CMSCtrlRootPath"].ToString();
                ViewState["CLocation"] = "/files";
                Session["Dir"] = string.Empty;
                Session["Path"] = string.Empty;
            }
            getDirectories();
            getFiles();
            Bind_PagingList();
        }
    }

    private void getFiles()
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(Convert.ToString(ViewState["CurDirectory"])));
            if (dirInfo.Exists)
            {
                FileInfo[] filesList = dirInfo.GetFiles();

                if (filesList.Length.Equals(1))
                {
                    foreach (FileInfo f in filesList)
                    {
                        if (f.Extension.Equals(".db"))
                        {
                            dlImages.Visible = false;
                            dlPaging.Visible = false;
                            tblheight.Visible = true;
                            return;
                        }
                    }
                }


                if (filesList.Length > 0)
                {
                    DataTable dtFiles = new DataTable();
                    dtFiles.Columns.Add("ImageName");
                    dtFiles.Columns.Add("ImageNameTrim");
                    dtFiles.Columns.Add("ImagePath");
                    foreach (FileInfo file in filesList)
                    {
                        string fileExtension = file.Name.Remove(0, file.Name.LastIndexOf('.')).ToLower();
                        if (fileExtension.Equals(".jpg") || fileExtension.Equals(".bmp") || fileExtension.Equals(".gif") || fileExtension.Equals(".jpeg") || fileExtension.Equals(".png"))
                        {
                            DataRow drowfile = dtFiles.NewRow();
                            drowfile["ImageName"] = file.Name.Remove(file.Name.LastIndexOf('.'));
                            if (file.Name.Remove(file.Name.LastIndexOf('.')).Length > 17)
                            {
                                drowfile["ImageNameTrim"] = file.Name.Remove(file.Name.LastIndexOf('.')).Substring(0, 17);
                            }
                            else
                            {
                                drowfile["ImageNameTrim"] = file.Name.Remove(file.Name.LastIndexOf('.'));
                            }
                           // drowfile["ImagePath"] = ConfigurationManager.AppSettings["InternalUrl"].ToString() + Convert.ToString(ViewState["CurrentPath"]) + file.Name;
                            drowfile["ImagePath"] = ConfigurationManager.AppSettings["InternalUrl"].ToString()+ Convert.ToString(ViewState["CurrentPath"]) + file.Name;
                            dtFiles.Rows.Add(drowfile);
                        }

                    }

                    pg.AllowPaging = true;
                    pg.PageSize = 15;
                    pg.DataSource = dtFiles.DefaultView;

                    try
                    {
                        pg.CurrentPageIndex = int.Parse(ViewState["page"].ToString());
                    }
                    catch
                    {
                        pg.CurrentPageIndex = 0;
                    }

                    if (dtFiles.Rows.Count <= pg.PageSize)
                    {
                        ViewState["pagecount"] = pg.PageCount;
                        ViewState["pagecount1"] = pg.Count;
                        dlImages.DataSource = dtFiles;
                        dlImages.DataBind();
                    }
                    else
                    {
                        ViewState["pagecount"] = pg.PageCount;
                        ViewState["pagecount1"] = pg.Count;
                        dlImages.DataSource = pg;
                        dlImages.DataBind();
                    }

                    //dlImages.DataSource = dtFiles;
                    //dlImages.DataBind();
                    dlImages.Visible = true;
                    dlPaging.Visible = true;
                    tblheight.Visible = false;
                }
                else
                {
                    dlImages.Visible = false;
                    dlPaging.Visible = false;
                    tblheight.Visible = true;
                }
            }
        }
        catch (Exception err)
        {
            throw err;
        }
    }

    private void getDirectories()
    {
        tvFolders.Nodes.Clear();
        DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath(Convert.ToString(ConfigurationManager.AppSettings["CMSEditorImagePath"])));
        DirectoryInfo[] dirList = dirInfo.GetDirectories();
        if (dirList.Length > 0)
        {
            foreach (DirectoryInfo dir in dirList)
            {
                TreeNode tNode = new TreeNode();
                tNode.Text = dir.Name;
                //tNode.Value = dir.Name + "/";

                DirectoryInfo dirInfoChildMain = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString() + tNode.ValuePath));
                DirectoryInfo[] dirListChildMain = dirInfoChildMain.GetDirectories();
                if (dirListChildMain.Length > 0)
                {
                    tNode.PopulateOnDemand = true;
                }
                else
                {
                    tNode.PopulateOnDemand = false;
                }
                tvFolders.Nodes.Add(tNode);

                #region Commented
                //DirectoryInfo dirInfoChild = new DirectoryInfo(Server.MapPath(Convert.ToString(ViewState["CurDirectory"]) + dir.Name));
                //DirectoryInfo[] dirListChild = dirInfoChild.GetDirectories();
                //if (dirListChild.Length > 0)
                //{
                //    foreach (DirectoryInfo dirChilds in dirListChild)
                //    {
                //        TreeNode tChildNode = new TreeNode();
                //        tChildNode.Text = dirChilds.Name;
                //        tChildNode.Value = dir.Name + "/" + dirChilds.Name + "/";
                //        tNode.ChildNodes.Add(tChildNode);
                //    }
                //} 
                #endregion
            }
        }
        if (Session["Selected"] != null)
        {
            strPath = Convert.ToString(Session["Selected"]);
            if (strPath.Contains("/"))
            {
                strPath = strPath.Substring(0, Convert.ToString(Session["Selected"]).IndexOf("/"));
                ViewState["SPath"] = Convert.ToString(Session["Selected"]).Remove(0, Convert.ToString(Session["Selected"]).IndexOf("/") + 1);
                //tvFolders.FindNode(strPath).Expand();
            }

            tvFolders.FindNode(strPath).Expand();
        }
    }

    protected void tvFolders_SelectedNodeChanged(object sender, EventArgs e)
    {
        ImageOpen.Visible = false;
        imgClose.Visible = true;

        string s = tvFolders.SelectedNode.ValuePath;
        ViewState["CurrentPath"] = ConfigurationManager.AppSettings["CMSCtrlRootPath"].ToString() + s + "/";
        ViewState["CurDirectory"] = ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString() + s;

        Session["Dir"] = ViewState["CurDirectory"];
        Session["Path"] = ViewState["CurrentPath"];

        string strPath = string.Empty;
        strPath = tvFolders.SelectedNode.ValuePath;
        Session["Selected"] = tvFolders.SelectedNode.ValuePath;

        ViewState["CLocation"] = "/files/" + strPath;
        Session["Location"] = ViewState["CLocation"];

        ViewState["page"] = 0;
        getFiles();
        Bind_PagingList();
    }

    /// <summary>
    /// Creates the Paging List Depending upon on products.
    /// </summary>
    void Bind_PagingList()
    {
        dt = new DataTable();
        dt.Columns.Add("PageNo");
        DataRow dr;
        if (pg != null)
        {
            if (ViewState["page"] == null)
            {
                ViewState["page"] = "0";
                Session["ProductPage"] = "0";
            }
            int nowpage = (Convert.ToInt32(ViewState["page"].ToString()) + 1);

            for (int pageC = 1; pageC <= pg.PageCount; pageC++)
            {
                dr = dt.NewRow();
                dr["PageNo"] = pageC;
                dt.Rows.Add(dr);
            }

            dlPaging.DataSource = dt;
            dlPaging.DataBind();

        }
    }

    protected void dlPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        ViewState["page"] = Convert.ToString(Convert.ToDouble(e.CommandName.ToString()) - 1);
        Session["ProductPage"] = Convert.ToString(Convert.ToDouble(e.CommandName.ToString()) - 1);
        getFiles();
        Bind_PagingList();
    }

    protected void dlPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ViewState["currentindex_Up"] = pg.CurrentPageIndex;
            LinkButton lbtnpage = (LinkButton)e.Item.FindControl("lbtnpaging_Up");
            if (Convert.ToInt64(lbtnpage.CommandName) - 1 == pg.CurrentPageIndex)
                lbtnpage.Enabled = false;
            else
                lbtnpage.Enabled = true;
        }
    }

    protected void lnkRefresh_Click(object sender, EventArgs e)
    {
        string strTemp = Convert.ToString(ViewState["CurDirectory"]);
        //ViewState["CurDirectory"] = ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString();
        //ViewState["CurrentPath"] = ConfigurationManager.AppSettings["CMSCtrlRootPath"].ToString();
        //ViewState["CLocation"] = "/files";
        //getDirectories();
        getFiles();
        Bind_PagingList();
    }

    protected void lnkFiles_Click(object sender, EventArgs e)
    {
        ImageOpen.Visible = true;
        imgClose.Visible = false;
        ViewState["CurDirectory"] = ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString();
        ViewState["CurrentPath"] = ConfigurationManager.AppSettings["CMSCtrlRootPath"].ToString();
        ViewState["CLocation"] = "/files";
        getDirectories();
        getFiles();
        Bind_PagingList();
        tvFolders.CollapseAll();
    }

    protected void tvFolders_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        DirectoryInfo dirInfoChild = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString() + e.Node.ValuePath));
        DirectoryInfo[] dirListChild = dirInfoChild.GetDirectories();
        if (dirListChild.Length > 0)
        {
            foreach (DirectoryInfo dirChilds in dirListChild)
            {
                TreeNode tChildNode = new TreeNode();
                tChildNode.Text = dirChilds.Name;
                //tChildNode.Value = e.Node.Value + "/" + dirChilds.Name + "/";
                DirectoryInfo dirInfoChild1 = new DirectoryInfo(Server.MapPath(ConfigurationManager.AppSettings["CMSEditorImagePath"].ToString() + tChildNode.ValuePath));
                DirectoryInfo[] dirListChild1 = dirInfoChild1.GetDirectories();
                if (dirListChild1.Length > 0)
                {
                    tChildNode.PopulateOnDemand = true;
                }
                else
                {
                    tChildNode.PopulateOnDemand = false;
                }
                e.Node.ChildNodes.Add(tChildNode);
            }

            if (ViewState["SPath"] != null)
            {
                string strPath1 = Convert.ToString(ViewState["SPath"]);
                if (!string.IsNullOrEmpty(strPath1))
                {
                    if (strPath1.Contains("/"))
                    {
                        strPath1 = strPath1.Substring(0, Convert.ToString(ViewState["SPath"]).IndexOf("/"));
                        ViewState["SPath"] = Convert.ToString(ViewState["SPath"]).Remove(0, Convert.ToString(ViewState["SPath"]).IndexOf("/") + 1);
                        strPath = strPath + "/" + strPath1;
                        tvFolders.FindNode(strPath).Expand();
                    }
                    else
                    {
                        ViewState["SPath"] = string.Empty;
                    }

                }
            }
        }
    }
}
