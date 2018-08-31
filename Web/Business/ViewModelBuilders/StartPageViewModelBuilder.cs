using System.Collections.Generic;
using System.Linq;
using KalikoCMS;
using KalikoCMS.Core;
using KalikoCMS.Core.Collections;
using Web.Models.Pages;
using Web.Models.ViewModels;
namespace Web.Business.ViewModelBuilders
{
    public class StartPageViewModelBuilder
    {
        public static StartPageViewModel Create(StartPage currentPage)
        {
            var model = new StartPageViewModel(currentPage);
            PageViewModelBuilder.SetBaseProperties(model);
            //model.LatestNews = GetLatestNews();
            return model;
        }

    }
}