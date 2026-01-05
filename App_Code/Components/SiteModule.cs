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
/// Summary description for SiteModule
/// </summary>

namespace Syner
{
    public class SiteModule : System.Web.UI.UserControl
    {

        private int _ModuleId;

        public int ModuleId
        {
            get { return _ModuleId; }
            set { _ModuleId = value; }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }


        private string  _FeatureName;

        public string  FeatureName
        {
            get { return _FeatureName; }
            set { _FeatureName = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<Div class='module'>");
            writer.Write("<Div class='moduleheader'><span class='moduletitle'>" + Title + "</span></Div>");
            base.Render(writer);
            writer.Write("</Div>");
        }
        
        public SiteModule()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}