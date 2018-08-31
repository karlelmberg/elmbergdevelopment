using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KalikoCMS.Mvc.Framework;
using Web.Models.Pages;

namespace Web.Controllers.Pages
{
    public class StandardPageController : PageController<StandardPage>
    {
        public override ActionResult Index(StandardPage currentPage)
        {
            return View(currentPage);
        }
    }
}