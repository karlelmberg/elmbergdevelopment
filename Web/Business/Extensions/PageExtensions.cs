using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using KalikoCMS.Core;
using KalikoCMS.Core.Collections;

namespace Web.Business.Extensions
{
    public static class PageExtensions
    {
        public static IEnumerable<T> CastToPageList<T>(this PageCollection collection) where T : CmsPage
        {
            foreach (CmsPage page in collection)
            {
                var pageTypeId = PageType.GetPageType(typeof(T)).PageTypeId;
                if(page.PageTypeId != pageTypeId)
                    continue;

                yield return page.ConvertToTypedPage<T>();
            }
        }
    }
}