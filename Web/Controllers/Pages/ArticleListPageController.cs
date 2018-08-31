using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using KalikoCMS.Mvc.Framework;
using Web.Models.Pages;
using Web.Models.ViewModels;

namespace Web.Controllers.Pages
{
    public class ArticleListPageController : PageController<ArticleListPage>
    {
        
        public override ActionResult Index(ArticleListPage currentPage)
        {        
         
            return View(currentPage);
        }
    }    
}