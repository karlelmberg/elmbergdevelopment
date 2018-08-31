using KalikoCMS;
using KalikoCMS.Configuration;
using KalikoCMS.Core;
using Web.Models.ViewModels;

namespace Web.Business.ViewModelBuilders
{
    public class PageViewModelBuilder
    {
        public static PageViewModel<T> Create<T>(T currentPage) where T : CmsPage
        {
            var model = new PageViewModel<T>(currentPage);

            SetBaseProperties(model);

            return model;
        }

        public static void SetBaseProperties(IPageViewModel<CmsPage> model)
        {
            model.TopMenu = PageFactory.GetChildrenForPage(SiteSettings.RootPage, x => x.VisibleInMenu);
        }

    }
}