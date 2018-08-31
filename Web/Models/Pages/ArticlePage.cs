using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KalikoCMS.Attributes;
using KalikoCMS.Core;
using KalikoCMS.PropertyType;

namespace Web.Models.Pages
{
    [PageType("ArticlePage", "Article page", "TODO")]
    public class ArticlePage : CmsPage
    {
        [Property("Heading")]
        public virtual StringProperty Heading { get; set; }

        [Property("Ingress")]
        public virtual HtmlProperty Ingress { get; set; }

        [ImageProperty("Image", Width = 960, Height = 280)]
        public virtual ImageProperty Image { get; set; }

        //[Property("Preamble")]
        //public virtual TextProperty Preamble { get; set; }

        [Property("Main body")]
        public virtual HtmlProperty MainBody { get; set; }

    }
}