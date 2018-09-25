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
    [PageType("ControlPanelLinkPage", "Control Panel Link Page", "TODO")]
    public class ControlPanelLinkPage : CmsPage
    {
        [Property("Heading")]
        public virtual StringProperty Heading { get; set; }

        [Property("Ingress")]
        public virtual HtmlProperty Ingress { get; set; }

        [ImageProperty("Image")]
        public virtual ImageProperty Image { get; set; }

        [Property("External Url")]
        public virtual StringProperty ExternalUrl { get; set; }

        [Property("Type")]
        public virtual StringProperty Type { get; set; }
    }
}