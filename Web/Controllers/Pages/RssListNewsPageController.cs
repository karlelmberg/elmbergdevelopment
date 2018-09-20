using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KalikoCMS;
using KalikoCMS.Core;
using KalikoCMS.Mvc.Framework;
using Web.Business.ViewModelBuilders;
using Web.Models.Pages;
using Web.Models.ViewModels;
using WebGrease.Css.Extensions;

namespace Web.Controllers.Pages
{
    public class RssListNewsPageController : PageController<RssListNewsPage>
    {
        private PageViewModel<RssListNewsPage> _model;
        public override ActionResult Index(RssListNewsPage currentPage)
        {
            //Get the children of RssListNewsPage. Still of type CmsPage
            var pageCollection = PageFactory.GetChildrenForPageOfPageType(currentPage.PageId, typeof(RssNewsPage), PublishState.Published);

            //Creates list with pages of type RssNewsPage
            currentPage.NewsPageList = new List<RssNewsPage>();

            //Iterates through pageCollection, converts cmsPages to RssNewsPages and adds them in NewsPageList 
            pageCollection.ForEach(x => currentPage.NewsPageList.Add(x.ConvertToTypedPage<RssNewsPage>()));

            _model = PageViewModelBuilder.Create(currentPage);

            return View(_model);
        }
    }
}


;