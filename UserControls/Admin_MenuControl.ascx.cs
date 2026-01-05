using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControls_Admin_MenuControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["parentid"] != null)
            {
                ViewState["Ilocal"] = Convert.ToString(Request["parentid"]);

                ViewState["GROUP_ID"] = Session["GROUP_ID"].ToString();
            }
            if (Request["fid"] != null)
            {
                ViewState["link"] = Convert.ToString(Request["fid"]);
            }


        }
    }
    public void mainMenu()
    {
        if (Session["GROUP_ID"] != "" && Session["GROUP_ID"] != null)
        {
            string strMenu = "";

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlDataAdapter adPARENT = new SqlDataAdapter("select distinct status, status_descr,Sort_Order from Tb_CodeMaster s, tb_function f where upper(f.parent_menu)=upper(s.status) AND upper(status_type)='parentmenu' order by Sort_Order", myConnection);
            //SqlDataAdapter adPARENT = new SqlDataAdapter("select distinct status, status_descr,Sort_Order from Tb_CodeMaster s, tb_function f where upper(f.parent_menu)=upper(s.status) AND upper(status_type)='parentmenu' and s.PublicAdminStatus=1 order by Sort_Order", myConnection);
            DataSet dsMenu = new DataSet();
            adPARENT.Fill(dsMenu, "tablePARENT");

            strMenu = strMenu + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            strMenu = strMenu + "<tr>";
            //strMenu = strMenu + "<td width=\"205\" valign=\"top\" class=\"buttonmenubg\">";

            //strMenu = strMenu + "</td>";
            strMenu = strMenu + "<td width=\"100%\" class=\"buttonmenubg\">";
            strMenu = strMenu + "<table width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
            strMenu = strMenu + "<tr>";

            strMenu = strMenu + "<td>";
            strMenu = strMenu + "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr>";
            //strMenu = strMenu + "<td height=\"29\" align=\"left\" valign=\"top\">";
            int ilocal = 0;
            //dsMenu.Tables[0].Rows.RemoveAt(0);

            //strSubMenu = strSubMenu + 


            foreach (DataRow drMenu in dsMenu.Tables[0].Rows)
            {
                string strSubMenu = string.Empty;
                string submenuItem = drMenu["status"].ToString();
                string submenulandingpageurl = "", submenuurl = "";
                SqlConnection myConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlDataAdapter adCHILD = new SqlDataAdapter("select distinct shrt_descr, case when def_link='s' then search_link else new_link end def_link,menu_sort_seq, f.func_id from tb_function f,Tb_GroupFuncPriv gfp where upper(f.func_id)=upper(gfp.func_id) and upper(f.parent_menu)='" + drMenu["status"].ToString() + "'  and upper(gfp.group_id)='" + Session["GROUP_ID"].ToString() + "'  order by menu_sort_seq", myConnection1);
                //SqlDataAdapter adCHILD = new SqlDataAdapter("select distinct shrt_descr, case when def_link='s' then search_link else new_link end def_link,menu_sort_seq, f.func_id from tb_function f,Tb_GroupFuncPriv gfp where upper(f.func_id)=upper(gfp.func_id) and upper(f.parent_menu)='" + drMenu["status"].ToString() + "'  and upper(gfp.group_id)='Admin' and f.PublicAdminStatus=2  order by menu_sort_seq", myConnection1);
                DataSet dsMenusub = new DataSet();
                adCHILD.Fill(dsMenusub, "tableCHILD");

                strSubMenu = strSubMenu + "<script language=\"JavaScript1.2\">";
                strSubMenu = strSubMenu + "submenu[" + ilocal.ToString() + "]='";


                // Page.ClientScript.RegisterClientScriptBlock(Page.GetType, "var delay_hide=500",true);
                if (dsMenusub.Tables[0].Rows.Count > 0)
                {
                    //submenulandingpageurl = dsMenusub.Tables[0].Rows[0]["IsExternalLink"].ToString() == "Y" ? dsMenusub.Tables[0].Rows[0]["ExternalLink"].ToString() : "Content.aspx";
                    //submenulandingpageurl = submenulandingpageurl + "?parentid=" + ilocal.ToString() + "&menuid=" + "smenu" + dsMenusub.Tables[0].Rows[0]["Title"].ToString() + "&mid=" + dsMenusub.Tables[0].Rows[0]["MenuId"].ToString();
                }

                strSubMenu = strSubMenu + "<div class=\"buttonmenubg\" style=\"height:29px;vertical-align:middle;padding-top:5px;\" id=\"divSubMenu_" + ilocal.ToString() + "\">";

                int isubmenu = 0;
                foreach (DataRow drMenusub in dsMenusub.Tables[0].Rows)
                {
                    isubmenu = isubmenu + 1;

                    string tUrl = "../Func_Audit.aspx?link=" + drMenusub["def_link"].ToString() + "&parentid=" + ilocal + "&fid=" + drMenusub["func_id"].ToString();

                    strSubMenu = strSubMenu + "<a id=\"smenu" + drMenusub["func_id"].ToString() + "\"" + " href=" + tUrl + " class=\"sub_headderbuttonactive1\">" + drMenusub["shrt_descr"].ToString() + "</a>";

                    if (isubmenu < dsMenusub.Tables[0].Rows.Count)
                        //strSubMenu = strSubMenu + "&nbsp;&nbsp;|&nbsp;&nbsp;";
                        strSubMenu = strSubMenu + "<img src=\"../images/buttonside.jpg\" alt=\"\" width=\"2\" height=\"15\" hspace=\"5\"  style=\"vertical-align:middle;\"/>";

                }
                strSubMenu = strSubMenu + "</div>";

                strSubMenu = strSubMenu + "';</script>";
                Response.Write(strSubMenu);

                strMenu = strMenu + "<td height=\"29\" align=\"left\" valign=\"top\" class=\"sub_headderbuttonactive1\"> ";
                strMenu = strMenu + "<a id=\"amenu" + drMenu["status"].ToString() + "\"" + " href='#' onclick=showit(" + ilocal.ToString() + ") onmouseover=\"showit(" + ilocal.ToString() + "); \" class=\"headerMenuText\">" + drMenu["status"].ToString() + "</a>";
                strMenu = strMenu + "</td>";
                strMenu = strMenu + "<td height=\"29\" align=\"left\" valign=\"top\"><img src=\"../images/buttonside.jpg\" alt=\"\" width=\"1\" height=\"29\" hspace=\"1\" /></td>";

                ilocal = ilocal + 1;
            }


            strMenu = strMenu.Substring(0, strMenu.Length - 5);

            strMenu = strMenu + "<td height=\"29\" align=\"left\" valign=\"top\" class=\"sub_headderbuttonactive1\"><a href=../Administration/Logout.aspx class=headerMenuText>Logout</a></td>";
            strMenu = strMenu + "</tr></table>";

            strMenu = strMenu + "</td>";
            strMenu = strMenu + "</tr>";
            strMenu = strMenu + "<tr>";

            //////strMenu = strMenu + "<td height=\"3px\">";
            //////strMenu = strMenu + "</td>";
            strMenu = strMenu + "<td height=\"0px\">";
            strMenu = strMenu + "</td>";
            strMenu = strMenu + "</tr>";
            strMenu = strMenu + "<tr>";
            strMenu = strMenu + "<td>";
            strMenu = strMenu + "<div id=\"describe\" style=\"height: 29px; vertical-align: middle;\">";
            strMenu = strMenu + "</div>";
            strMenu = strMenu + "</td>";
            strMenu = strMenu + "</tr>";
            strMenu = strMenu + "</table>";
            strMenu = strMenu + "</td>";
            strMenu = strMenu + "</tr>";
            strMenu = strMenu + "</table>";


            Response.Write(strMenu);
            string strScript = string.Empty;

            if (Convert.ToString(ViewState["Ilocal"]) != "")
            {
                if (Convert.ToString(ViewState["link"]) != "")
                {
                    strScript = "var menuobj=document.getElementById? document.getElementById(\"describe\") : document.all? document.all.describe : document.layers? document.dep1.document.dep2 : \"\";showit(" + Convert.ToString(ViewState["Ilocal"]) + ");assignCss('smenu" + Convert.ToString(ViewState["link"]) + "');";

                }
                else
                {
                    strScript = "var menuobj=document.getElementById? document.getElementById(\"describe\") : document.all? document.all.describe : document.layers? document.dep1.document.dep2 : \"\";showit(" + Convert.ToString(ViewState["Ilocal"]) + ");";

                }
            }
            else
            {
                strScript = "var menuobj=document.getElementById? document.getElementById(\"describe\") : document.all? document.all.describe : document.layers? document.dep1.document.dep2 : \"\";";
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", strScript, true);
        }
        else
        {
            Response.Redirect(ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Default.aspx");
        }
    }
    


}
