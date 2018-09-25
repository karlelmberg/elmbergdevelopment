using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KalikoCMS.Mvc.Framework;
using Web.Business.ViewModelBuilders;
using Web.Models.Pages;
using Web.Models.ViewModels;

namespace Web.Controllers.Pages
{
    public class ArticlePageController : PageController<ArticlePage>
    {
        private PageViewModel<ArticlePage> _model;
        public override ActionResult Index(ArticlePage currentPage)
        {
            _model = PageViewModelBuilder.Create(currentPage);
            return View(_model);
        }
    }
}