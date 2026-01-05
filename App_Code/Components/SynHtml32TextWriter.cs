using System;
using System.IO;
using System.Web.UI;

    class SynHtml32TextWriter : Html32TextWriter
    {
        private string formAction;
        private const string actionAttribute = "action";

        public SynHtml32TextWriter(TextWriter writer)
            : base(writer)
        {
            
        }

        public SynHtml32TextWriter(TextWriter writer, string action) : base(writer)
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

