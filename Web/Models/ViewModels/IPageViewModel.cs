using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KalikoCMS.Core;

namespace Web.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : CmsPage
    {
        T CurrentPage { get; }
        IEnumerable<CmsPage> TopMenu { get; set; }
    }
}