using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using KalikoCMS;
using KalikoCMS.Core;
using KalikoCMS.Mvc.Framework;
using Web.Business.ViewModelBuilders;
using Web.Business.Vue;
using Web.Models.Pages;
using Web.Models.ViewModels;
using WebGrease.Css.Extensions;

namespace Web.Controllers.Pages
{
    public class ArticleListPageController : PageController<ArticleListPage>
    {
        private PageViewModel<ArticleListPage> _model;
        public override ActionResult Index(ArticleListPage currentPage)
        {
            _model = PageViewModelBuilder.Create(currentPage);

            // create our view model and parser
            var viewModel = new ArticleListPageViewModel();
            viewModel.Heading = _model.CurrentPage.Heading.ToString();
            viewModel.Ingress = _model.CurrentPage.Ingress.ToString();

            /*var parser = new VueParser();*/ // in the real app you would use DI

            // in a real app, this would be placed somewhere in the base controller
            //viewModel.VueData = parser.ParseData(viewModel);

            _model.CurrentPage.ArticleListPageViewModel = viewModel;

            return View(_model);            
        }


        //[HttpGet]
        //public JsonResult GetCurrentPage()
        //{
        //    try
        //    {
        //        ArticleListPage currentPage = new ArticleListPage();

        //        //Get the children of RssListNewsPage. Still of type CmsPage
        //        var pageCollection = PageFactory.GetChildrenForPageOfPageType(currentPage.PageId, typeof(ArticlePage), PublishState.Published);

        //        //Creates list with pages of type ArticlePage
        //        currentPage.ArticlePageList = new List<ArticlePage>();

        //        //Iterates through pageCollection, converts cmsPages to ArticleListPages and adds them in ArticlePageList 
        //        pageCollection.ForEach(x => currentPage.ArticlePageList.Add(x.ConvertToTypedPage<ArticlePage>()));

        //        _model = PageViewModelBuilder.Create(currentPage);

        //        return Json(_model, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }    
}