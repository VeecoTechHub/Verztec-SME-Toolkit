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
using System.Data.SqlClient;

public partial class Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
           // if (Session["USER_ID"] != null)
           // {
                BuildMENU();
           // }

        // Added by Mahesh on 23/01/2012
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
    }
    public DataSet getPARENTMENU()
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        //////SqlDataAdapter adPARENT = new SqlDataAdapter("select distinct status, status_descr from Tb_CodeMaster s, tb_function f,Tb_GroupFuncPriv gfp where upper(f.func_id)=upper(gfp.func_id) and upper(f.parent_menu)=upper(s.status) AND upper(status_type)='parentmenu' and upper(gfp.group_id)= '" + Session["GROUP_ID"].ToString() + "'  order by status", myConnection);
        SqlDataAdapter adPARENT = new SqlDataAdapter("select distinct status, status_descr from Tb_CodeMaster s, tb_function f,Tb_GroupFuncPriv gfp where upper(f.func_id)=upper(gfp.func_id) and upper(f.parent_menu)=upper(s.status) AND upper(status_type)='parentmenu' and upper(gfp.group_id)= '" + Session["GROUP_ID"].ToString() + "'  order by status", myConnection);
        DataSet dsTEMP = new DataSet();
        adPARENT.Fill(dsTEMP, "tablePARENT");
        return dsTEMP;
    }
    public DataSet getCHILDMENU(string mainMENUTITLE)
    {
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlDataAdapter adCHILD = new SqlDataAdapter("select distinct shrt_descr,f.parent_menu, case when def_link='s' then search_link else new_link end def_link,menu_sort_seq, f.func_id from tb_function f,Tb_GroupFuncPriv gfp where upper(f.func_id)=upper(gfp.func_id) and upper(f.parent_menu)='" + mainMENUTITLE + "'  and upper(gfp.group_id)='" + Session["GROUP_ID"].ToString() + "'  order by menu_sort_seq", myConnection);
        DataSet dsTEMP = new DataSet();
        adCHILD.Fill(dsTEMP, "tableCHILD");
        return dsTEMP;
    }
    public void BuildMENU()
    {
        DataSet dsMAINMENU = getPARENTMENU();
        Accordion1.DataSource = dsMAINMENU.Tables[0].DefaultView;
        Accordion1.DataBind();

        //if(Request.Params["mn"]!=null)
        //{
        //    Accordion1.SelectedIndex = Convert.ToInt32(Request.Params["mn"].ToString());

        //}
    }
    protected void Accordion1_ItemDataBound(object sender, AjaxControlToolkit.AccordionItemEventArgs e)
    {
        string sMainMenu = Convert.ToString(DataBinder.Eval(e.AccordionItem.DataItem, "status_descr"));

        if (Session["mn"] != null && Session["mn"].ToString().Trim() == sMainMenu.Trim())
        {
            Accordion1.SelectedIndex = e.AccordionItem.DataItemIndex;

        }
        
        if (e.ItemType == AjaxControlToolkit.AccordionItemType.Header)
        {
            Label lbl = (Label)e.AccordionItem.FindControl("lbl");
        }
        if (e.ItemType == AjaxControlToolkit.AccordionItemType.Content)
        {
            
            Repeater rpt = (Repeater)e.AccordionItem.FindControl("rptSubMenus");
            //if (lbl != null && lbl.Text != "")
            //{
                DataSet dsSUBMENU = getCHILDMENU(sMainMenu);
                if (dsSUBMENU != null)
                {
                    rpt.ItemDataBound += new RepeaterItemEventHandler(rpt_ItemDataBound);
                    rpt.DataSource = dsSUBMENU.Tables[0].DefaultView;
                    rpt.DataBind();


                    
                }
            //}
        }
    }

    void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblDefLnk = (Label)e.Item.FindControl("lblDefLnk");
                Label lblFuncId = (Label)e.Item.FindControl("lblFuncId");
                Label lblShrtDesc = (Label)e.Item.FindControl("lblShrtDesc");
                Label lblLnk = (Label)e.Item.FindControl("lblLnk");

                string parentmenu = DataBinder.Eval(e.Item.DataItem, "parent_menu").ToString();
                
                if (lblShrtDesc != null && lblShrtDesc.Text != "")
                {
                    string sUrl = ConfigurationManager.AppSettings["InternalUrl"].ToString() + "Func_Audit.aspx?link=" + lblDefLnk.Text + "&fid=" + lblFuncId.Text + "&mn=" + parentmenu;
                    lblLnk.Text = "<a  href='" + sUrl + "'>" + lblShrtDesc.Text + "</a>";
                }
            }
            //throw new Exception("The method or operation is not implemented.");
        }
        catch
        {
            throw;
        }
    }
}
