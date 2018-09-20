using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataTransferObjects.Dtos;
using KalikoCMS.Attributes;
using KalikoCMS.Core;
using KalikoCMS.PropertyType;

namespace Web.Models.Pages
{
    [PageType("RssNewsPage", "Rss News Page", "TODO")]
    public class RssNewsPage : CmsPage
    {
        [Property("Heading")]
        public virtual StringProperty Heading { get; set; }

        [Property("Ingress")]
        public virtual HtmlProperty Ingress { get; set; }

        [Property("RssUrl")]
        public virtual StringProperty RssUrl { get; set; }

        [ImageProperty("Image")]
        public virtual ImageProperty Image { get; set; }

        [Property("SourceSupplier")]
        public virtual StringProperty SourceSupplier { get; set; }

        public List<RssItemDto> RssItemList { get; set; }      
    }
}