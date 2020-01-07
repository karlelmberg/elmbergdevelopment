using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KalikoCMS.Core;

namespace Web.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : CmsPage
    {
        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
            MainMenu = new List<CmsPage>();         
        }

        public T CurrentPage { get; private set; }
        public IEnumerable<CmsPage> MainMenu { get; set; }     
    }
}