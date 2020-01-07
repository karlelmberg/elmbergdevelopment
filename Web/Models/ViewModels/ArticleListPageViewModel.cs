using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Business.Vue;

namespace Web.Models.ViewModels
{
    public class ArticleListPageViewModel
    {
        [VueData("Heading")]
        public virtual string Heading { get; set; }

        [VueData("Ingress")]
        public virtual string Ingress { get; set; }


        //public virtual ImageProperty Image { get; set; }

        //public List<ArticlePage> ArticlePageList { get; set; }

        // in a real app, this would be placed in the base view model class
        public Dictionary<string, object> VueData { get; set; } = new Dictionary<string, object>();
    }
}