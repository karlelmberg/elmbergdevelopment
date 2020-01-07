using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace Web.Models.ViewModels
{
    public class LunchPageViewModel
    {
        public string TwoValveAndKitchenHtmlTable { get; set; }
        public string PercysHtmlTable { get; set; }
        public string NilssonsHtmlTable { get; set; }     
        public string QualityViewHtmlTable { get; set; }
        public string FrilagetHtmlTable { get; set; }
        public List<RestaurantViewModel> ListOfRestaurants { get; set; }
    }
}