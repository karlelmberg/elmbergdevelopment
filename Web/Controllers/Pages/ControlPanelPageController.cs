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
    public class ControlPanelPageController : PageController<ControlPanelPage>
    {
        private PageViewModel<ControlPanelPage> _model;
        public override ActionResult Index(ControlPanelPage currentPage)
        {
            //Get the children of RssListNewsPage. Still of type CmsPage
            var pageCollection = PageFactory.GetChildrenForPageOfPageType(currentPage.PageId, typeof(ControlPanelLinkPage), PublishState.Published);

            //Creates list with pages of type RssNewsPage
            currentPage.ControlPanelLinkPageList = new List<ControlPanelLinkPage>();

            //Iterates through pageCollection, converts cmsPages to RssNewsPages and adds them in NewsPageList 
            pageCollection.ForEach(x => currentPage.ControlPanelLinkPageList.Add(x.ConvertToTypedPage<ControlPanelLinkPage>()));

            _model = PageViewModelBuilder.Create(currentPage);

            return View(_model);
        }
    }
}


;