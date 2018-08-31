using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KalikoCMS.Mvc.Framework;
using Web.Models.Pages;
using Web.Business.ViewModelBuilders;

namespace Web.Controllers.Pages
{
    public class StartPageController : PageController<StartPage>
    {
        public override ActionResult Index(StartPage currentPage)
        {
            var model = StartPageViewModelBuilder.Create(currentPage);

            return View(model);
        }
    }
}