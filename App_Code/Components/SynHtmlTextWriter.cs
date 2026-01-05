using System;
using System.Collections;
using System.IO;
using System.Web.UI;


    public class SynHtmlTextWriter : HtmlTextWriter
    {
        private string formAction;
        private const string actionAttribute = "action";

        public SynHtmlTextWriter(TextWriter writer)
            : base(writer)
        {}

        public SynHtmlTextWriter(TextWriter writer, string action) : base(writer)
		{
			formAction = action;
		}

		public override void RenderBeginTag(string tagName)
		{
			base.RenderBeginTag(tagName);
		}

		public override void WriteAttribute(string name, string value, bool fEncode)
		{
          
            if (string.Equals(name, actionAttribute))
            {
                base.WriteAttribute(name, formAction, fEncode);
            }
            else
            {
                base.WriteAttribute(name, value, fEncode);
            }
		}

    }

