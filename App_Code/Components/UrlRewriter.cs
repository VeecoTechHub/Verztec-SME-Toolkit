using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Configuration;


namespace syn.Web
{
	
	public class UrlRewriter : IHttpModule
	{
       


		public void Init(HttpApplication app)
		{
			app.BeginRequest += new EventHandler(this.UrlRewriter_BeginRequest);
            app.AuthenticateRequest += new EventHandler(app_AuthenticateRequest);
		}

        void app_AuthenticateRequest(object sender, EventArgs e)
        {
           

        }

		public void Dispose() {}

		protected  void UrlRewriter_BeginRequest(object sender, EventArgs e)
		{
            if (sender == null) return;

            HttpApplication app = (HttpApplication)sender;
            
            if (
                (app.Request.Path.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase))
                    || (app.Request.Path.EndsWith(".js", StringComparison.InvariantCultureIgnoreCase))
                    || (app.Request.Path.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                    || (app.Request.Path.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase))
                    || (app.Request.Path.EndsWith(".css", StringComparison.InvariantCultureIgnoreCase))
                    || (app.Request.Path.EndsWith(".axd", StringComparison.InvariantCultureIgnoreCase))
                    || (app.Request.Path.EndsWith("thumbnailservice.ashx", StringComparison.InvariantCultureIgnoreCase))
                    )
            {
                return;

            }

          
                    RewriteUrl(app);
             
           
		}

        private static void RewriteUrl(HttpApplication app)
        {


            // we will check the condition here


           



          string  InternalUrl = ConfigurationManager.AppSettings["internalurl"].ToString();

          HttpContext.Current.Items["InternalURl"] = InternalUrl;
            
           string PageUrl =HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Replace(InternalUrl.ToLower(), "");




           if (PageUrl.ToLower().StartsWith("site"))
               app.Context.RewritePath("~/default.aspx?PageUrl=" + PageUrl.ToLower().Replace("site/",""));
           else
               return;
            

            
        }


        



       
		
	}
}
