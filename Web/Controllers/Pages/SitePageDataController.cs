using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KalikoCMS.Mvc.Framework;
using Web.Models.Pages;

namespace Web.Controllers.Pages
{
    public class SitePageDataController : PageController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentPage)
        {
            return View(currentPage);
        }
    }
}