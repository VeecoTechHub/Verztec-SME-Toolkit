using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for SynBasePage
/// </summary>
public class SynBasePage : System.Web.UI.Page
{



    private Panel _LeftDiv;

    public Panel divLeft
    {
        get { return _LeftDiv; }
        set { _LeftDiv = value; }
    }



    private Panel _ContentDiv;

    public Panel divCenter
    {
        get { return _ContentDiv; }
        set { _ContentDiv = value; }
    }


    private Panel _RightDiv;

    public Panel divRight
    {
        get { return _RightDiv; }
        set { _RightDiv = value; }
    }




    private string _PageUrl;

    public string PageUrl
    {
        get { return _PageUrl; }
        set { _PageUrl = value; }
    }



    private string  _InternalUrl;

    public string  InternalUrl
    {
        get { return _InternalUrl; }
        set { _InternalUrl = value; }
    }



    public SynBasePage()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        

       



    }


    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);

        this.Theme = "Default";


        this.divLeft = (Panel)this.Master.FindControl("divLeft");
        this.divCenter = (Panel)this.Master.FindControl("divCenter");
        this.divRight = (Panel)this.Master.FindControl("divRight");

       // InternalUrl = ConfigurationManager.AppSettings["internalurl"].ToString();

   //     PageUrl = Request.Url.AbsoluteUri.ToLower().Replace(InternalUrl.ToLower(), "");

        PageUrl = Request.Params["PageUrl"] != null ? Request.Params["PageUrl"].ToString() : "";

        this.divRight.Visible = false;
        this.divLeft.Visible = false;
        this.divCenter.Visible = false;
    }


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);



      

        if ((divLeft.Visible) && (!divRight.Visible))
        {
            divLeft.CssClass = "leftside left2column";
        }

        if ((divRight.Visible) && (!divLeft.Visible))
        {
            divRight.CssClass = "rightside right2column";
        }

        divCenter.CssClass =
            divLeft.Visible
                ? (divRight.Visible ? "center-rightandleftmargins" : "center-leftmargin")
                : (divRight.Visible ? "center-rightmargin" : "center-nomargins");



        foreach (Control control in Page.Header.Controls)
        {
            HtmlLink link;

            link = control as HtmlLink;
            if ((link != null) && link.Href.StartsWith("~/"))
            {
                if (Request.ApplicationPath == "/")
                    link.Href = link.Href.Substring(1);
                else
                    link.Href = Request.ApplicationPath + "/" + link.Href.Substring("~/".Length);
            }
        }


    }





    protected override void Render(HtmlTextWriter writer)
    {
        string action = Request.RawUrl;

        if (
            (true)
            && (action.IndexOf("?") == -1)
            && (Request.QueryString.Count > 0)
            )
        {
            action += "?" + Request.QueryString.ToString();
        }

        if (writer.GetType() == typeof(HtmlTextWriter))
        {
            writer = new SynHtmlTextWriter(writer, action);
        }
        else if (writer.GetType() == typeof(Html32TextWriter))
        {
            writer = new SynHtml32TextWriter(writer, action);
        }

        base.Render(writer);

    }
}
