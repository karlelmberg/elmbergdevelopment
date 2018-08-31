using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KalikoCMS.Mvc.Framework;
using Web.Models.Pages;

namespace Web.Controllers.Pages
{ 
        public class ArticlePageController : PageController<ArticlePage>
        {
            public override ActionResult Index(ArticlePage currentPage)
            {
                return View(currentPage);
            }
        }  
}