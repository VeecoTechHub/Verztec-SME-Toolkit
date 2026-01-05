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

public partial class UserControls_Public_MenuControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["parentid"] != null)
            {
                ViewState["Ilocal"] = Convert.ToString(Request["parentid"]);               
            }
            if (Request["link"] != null)
            {
                ViewState["link"] = Convert.ToString(Request["link"]);
            }

        }
    }
    public void mainMenu()
    {
        string strMenu = "";
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        //Bind All ModelNumbers
        //string strPros = string.Empty;
        //string strProIds = string.Empty;
        //SqlDataAdapter adPro = new SqlDataAdapter("select * from  tbl_Product where IsDeleted=1", myConnection);
        //DataSet dsPro = new DataSet();
        //adPro.Fill(dsPro, "tablePro");

        //foreach (DataRow dr in dsPro.Tables[0].Rows)
        //{
        //    if (strPros != "")
        //    {
        //        strPros = strPros + "," + dr["ModelNumber"].ToString();
        //    }
        //    else
        //    {
        //        strPros = dr["ModelNumber"].ToString();
        //    }
        //    if (strProIds != "")
        //    {
        //        strProIds = strProIds + "," + dr["ProductId"].ToString();
        //    }
        //    else
        //    {
        //        strProIds = dr["ProductId"].ToString();
        //    }
        //}
        //end of Bindning Model Numbers
        SqlDataAdapter adPARENT = new SqlDataAdapter("select * from Tb_PublicMainMenu order by SortOrder", myConnection);
        DataSet dsMenu = new DataSet();
        adPARENT.Fill(dsMenu, "tablePARENT");

        strMenu = strMenu + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
        strMenu = strMenu + "<tr>";
        strMenu = strMenu + "<td width=\"100%\">";
        strMenu = strMenu + "<table width=\"100%\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
        strMenu = strMenu + "<tr>";
        strMenu = strMenu + "<td>";
        strMenu = strMenu + "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr>";
        int ilocal = 0;
        foreach (DataRow drMenu in dsMenu.Tables[0].Rows)
        {
            string strSubMenu = string.Empty;
            string submenuItem = drMenu["MainMenuId"].ToString();
            string submenulandingpageurl = "", submenuurl = "";
            SqlConnection myConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlDataAdapter adCHILD = new SqlDataAdapter("select * from Tb_PublicSubMenu where MainMenuId='" + submenuItem + "' order by SortOrder", myConnection1);
            DataSet dsMenusub = new DataSet();
            adCHILD.Fill(dsMenusub, "tableCHILD");
            strSubMenu = strSubMenu + "<script language=\"JavaScript1.2\">";
            strSubMenu = strSubMenu + "submenu[" + ilocal.ToString() + "]='";
            if (dsMenusub.Tables[0].Rows.Count > 0)
            {
            }            
            strSubMenu = strSubMenu + "<div ***SetAlignTag*** id=\"divSubMenu_" + ilocal.ToString() + "\">";
            int isubmenu = 0;
            foreach (DataRow drMenusub in dsMenusub.Tables[0].Rows)
            {
                isubmenu = isubmenu + 1;                
                string tUrl = ConfigurationManager.AppSettings["InternalURL"].ToString() + drMenusub["NavigationUrl"].ToString() + "?link=" + drMenusub["SubMenuID"].ToString() + "&parentid=" + ilocal;//drMenu["MainMenuId"].ToString();//
                strSubMenu = strSubMenu + "<a id=\"sMenu" + drMenusub["SubMenuID"].ToString() + "\" href=" + tUrl + " class=\"dropstyInner\">" + drMenusub["SubMenuName"].ToString() + "</a>";
                if (isubmenu < dsMenusub.Tables[0].Rows.Count)
                    strSubMenu = strSubMenu + "&nbsp;|&nbsp;";                
               }

            strSubMenu = strSubMenu + "</div>";

            strSubMenu = strSubMenu + "';</script>";

            if (drMenu["MenuName"].ToString().ToLower().Trim() == "contact us")
                strSubMenu = strSubMenu.Replace("***SetAlignTag***", "align=\"right\" style=\"width:440px;border-weight:1;\"");
            else
                strSubMenu = strSubMenu.Replace("***SetAlignTag***", "align=\"left\"");
             Response.Write(strSubMenu);           
            string strMainUrl = ConfigurationManager.AppSettings["InternalURL"].ToString() + drMenu["NavigateUrl"].ToString() + "?MenuID=" + drMenu["MainMenuId"].ToString();
            if (drMenu["NavigateUrl"].ToString() == "#")
            {
                strMainUrl = "#";
            }
            strMenu = strMenu + "<td align=\"left\" valign=\"top\"> ";
            strMenu = strMenu + "<a id=\"amenu" + drMenu["MenuName"].ToString() + "\"" + " href=" + strMainUrl + " onclick=showit(" + ilocal.ToString() + ") onmouseover=\"showit(" + ilocal.ToString() + "); \" class=\"mainMenuInner\">" + drMenu["MenuName"].ToString() + "</a>";
            strMenu = strMenu + "</td>";
            ilocal = ilocal + 1;
        }


        strMenu = strMenu.Substring(0, strMenu.Length - 5);

        
        strMenu = strMenu + "<td width=25px;></td>";
        // To Create Search Button

      

        strMenu = strMenu + " <td width=32% align=left valign=top class=search>";
        strMenu = strMenu + " <table width=157 border=0 cellspacing=0 cellpadding=0> ";
        strMenu = strMenu + " <tr> ";
        strMenu = strMenu + " <td width=131 align=left> ";
        strMenu = strMenu + " <input name=textfield type=text onClick=removeText('textfield') onkeypress=goSearch('textfield') onkeydown=changeFocus() class=textbox_search id=textfield style=background: none;";
        //strMenu = strMenu + " <input name=textfield type=text onClick=removeText('textfield') onkeydown=\"javascript: if((event.which == 13) || (event.keyCode == 13)){ this.window.location.href='TopSearch.aspx?SearchText=a';} \" class=textbox_search id=textfield style=background: none;";
        strMenu = strMenu + " value=Search border=none /></td> ";
        strMenu = strMenu + "   <td width=26 align=left valign=top> ";
        strMenu = strMenu + " <a href=# id='aSearch' onclick=\"NavigateSearch('textfield')\" onmouseout=MM_swapImgRestore() onmouseover=MM_swapImage('Image13','','images/search_over.gif',1)> ";
        //strMenu = strMenu + " <asp:ImageButton ID=Image13 runat=server ImageUrl='images/' Width='26' Height='21' OnClick=Image13_Click /> </td>";
        strMenu = strMenu + " <img class=search_1 src='images/spacer.gif' alt='Search' name='Image13' width='26' height='21' border=0 id=Image13 />";
        strMenu = strMenu + " </a></td>";
        strMenu = strMenu + "  </tr> ";
        strMenu = strMenu + "  </table>";
        strMenu = strMenu + " </td>";
        //end of Search Button

        strMenu = strMenu + "</tr></table>";
        strMenu = strMenu + "</td>";
        strMenu = strMenu + "</tr>";
        strMenu = strMenu + "<tr>";
        strMenu = strMenu + "<td valign=top>";
        strMenu = strMenu + "<div id=\"describe\" style=\"height: 16px;width:698px;vertical-align: top;\" onmouseover=\"clear_delayhide()\" >";
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


}
