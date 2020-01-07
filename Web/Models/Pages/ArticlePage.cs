using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [ImageProperty("Image")]
        public virtual ImageProperty Image { get; set; }

        [Property("Main body")]
        public virtual HtmlProperty MainBody { get; set; }

        [Property("Cod1Heading")]
        public virtual StringProperty Code1Heading { get; set; }

        [Property("Cod1")]
        public virtual TextProperty Code1 { get; set; }

        /*https://prismjs.com/#features-full*/
        [Property("Cod1Decode")]     
        public virtual StringProperty Code1Decode { get; set; }

        [Property("Cod2Heading")]
        public virtual StringProperty Code2Heading { get; set; }

        [Property("Cod2")]
        public virtual TextProperty Code2 { get; set; }

        [Property("Cod2Decode")]
        public virtual StringProperty Code2Decode { get; set; }

        [Property("Cod3Heading")]
        public virtual StringProperty Code3Heading { get; set; }

        [Property("Cod3")]
        public virtual TextProperty Code3 { get; set; }

        [Property("Cod3Decode")]
        public virtual StringProperty Code3Decode { get; set; }
    }
}