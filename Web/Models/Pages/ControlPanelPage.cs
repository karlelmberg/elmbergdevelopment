using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KalikoCMS;
using KalikoCMS.Attributes;
using KalikoCMS.Core;
using KalikoCMS.Core.Collections;
using KalikoCMS.PropertyType;
using Web.Business.Extensions;

namespace Web.Models.Pages
{
    [PageType("ControlPanelPage", "Control Panel Page", "TODO")]
    public class ControlPanelPage : CmsPage
    {
        [Property("Heading")]
        public virtual StringProperty Heading { get; set; }

        [Property("Ingress")]
        public virtual HtmlProperty Ingress { get; set; }

        [ImageProperty("Image", Width = 960, Height = 280)]
        public virtual ImageProperty Image { get; set; }

        [Property("Main body")]
        public virtual HtmlProperty MainBody { get; set; }

        public List<ControlPanelLinkPage> ControlPanelLinkPageList { get; set; }

        //Med GetChildrenForPageOfPageType metod och CastToPageList extension
        //public List<RssNewsPage> NewsPageList2 => PageFactory.GetChildrenForPageOfPageType(PageId, typeof(RssNewsPage), PublishState.Published)
        //    .CastToPageList<RssNewsPage>().ToList();
        //Med metoden children och CastToPageList extension
        //public List<RssNewsPage> NewsPageList3 => Children.CastToPageList<RssNewsPage>().ToList();
    }
}