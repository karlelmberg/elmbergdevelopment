using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KalikoCMS.Mvc.Framework;
using Web.Models.Pages;

namespace Web.Controllers.Pages
{
    public class RssListNewsPageController : PageController<RssListNewsPage>
    {
        public override ActionResult Index(RssListNewsPage currentPage)
        {
            return View(currentPage);
        }
    }

}
