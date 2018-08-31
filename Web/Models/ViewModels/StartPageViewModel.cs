using System.Collections.Generic;
using KalikoCMS.Core;
using Web.Models.Pages;

namespace Web.Models.ViewModels
{
    public class StartPageViewModel : IPageViewModel<StartPage>
    {
        public StartPageViewModel(StartPage currentPage)
        {
            CurrentPage = currentPage;
        }

        public StartPage CurrentPage { get; private set; }
        public IEnumerable<CmsPage> TopMenu { get; set; }
        //public IEnumerable<CmsPage> LatestNews { get; set; }
    }
}