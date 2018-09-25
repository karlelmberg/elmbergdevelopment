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
            //Get the children of RssListNewsPage. Still of type CmsPage
            var pageCollection = PageFactory.GetChildrenForPageOfPageType(currentPage.PageId, typeof(RssNewsPage), PublishState.Published);

            //Creates list with pages of type RssNewsPage
            currentPage.ArticlePageList = new List<ArticlePage>();

            //Iterates through pageCollection, converts cmsPages to RssNewsPages and adds them in NewsPageList 
            pageCollection.ForEach(x => currentPage.ArticlePageList.Add(x.ConvertToTypedPage<ArticlePage>()));

            _model = PageViewModelBuilder.Create(currentPage);

            return View(_model);            
        }
    }    
}