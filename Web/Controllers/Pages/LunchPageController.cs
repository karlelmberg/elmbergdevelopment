using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KalikoCMS.Mvc.Framework;
using Web.Business.ViewModelBuilders;
using Web.Models.Pages;
using Web.Models.ViewModels;
using HtmlAgilityPack;
using Microsoft.Ajax.Utilities;
using Web.Business.Services;

namespace Web.Controllers.Pages
{
    public class LunchPageController : PageController<LunchPage>
    {
        private PageViewModel<LunchPage> _model;
        private string _externalUrl;
        private HtmlNode _externalDocument;
        private LunchPageViewModel _lunchPageViewModel;
        private ResultViewModel _resultViewModel;
        private HtmlNode _node;
        private HtmlDocument _htmlDoc;
        private List<HtmlNode> _dishes;

        public override ActionResult Index(LunchPage currentPage)
        {
            _model = PageViewModelBuilder.Create(currentPage);

            return View(_model);
        }

        [HttpGet]
        public JsonResult GetLunch()
        {
            try
            {
                _lunchPageViewModel = new LunchPageViewModel();

                //TwoValveAndKitchenHtmlTable
                _externalUrl = "https://restaurang2valv.gastrogate.com/lunch/";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//table[@class='table lunch_menu animation']").First();
                _lunchPageViewModel.TwoValveAndKitchenHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);

                //PercysHtmlTable
                _externalUrl = "https://percysrestaurang.gastrogate.com/lunch/";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//table[@class='table lunch_menu animation']").First();
                _lunchPageViewModel.PercysHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);

                //NilssonsHtmlTable
                _externalUrl = "https://nilssonsrestaurang.gastrogate.com/lunch/";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//table[@class='table lunch_menu animation']").First();
                _lunchPageViewModel.NilssonsHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);

                //NilssonsHtmlTable
                _externalUrl = "https://frilaget.gastrogate.com/lunch/";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//table[@class='table lunch_menu animation']").First();
                _lunchPageViewModel.FrilagetHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);

                return Json(_lunchPageViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult GetOneDayLunch()
        {      
            try
            {
                _lunchPageViewModel = new LunchPageViewModel();
                _lunchPageViewModel.ListOfRestaurants = new List<RestaurantViewModel>();
                
                //TwoValveAndKitchen
                _externalUrl = "https://restaurang2valv.gastrogate.com/lunch/";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//tbody[@class='lunch-day-content']").First();

                _dishes = _node.SelectNodes("//td[@class='td_title']").ToList();
                var twoValveAndKitchen = new RestaurantViewModel();
                twoValveAndKitchen.LunchHeader = "2 Valv och kök";
                GetDish(twoValveAndKitchen);

                _lunchPageViewModel.ListOfRestaurants.Add(twoValveAndKitchen);

                //Percys
                _externalUrl = "https://percysrestaurang.gastrogate.com/lunch/";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//tbody[@class='lunch-day-content']").First();
                _dishes = _node.SelectNodes("//td[@class='td_title']").ToList();

                var percys = new RestaurantViewModel();
                percys.LunchHeader = "Percys";

                GetDish(percys);
                      
                _lunchPageViewModel.ListOfRestaurants.Add(percys);

                return Json(_lunchPageViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetHtmlDataFromExternalUrl()
        {
            HttpWebRequest request = HttpWebRequest.Create(_externalUrl) as HttpWebRequest;
            request.Method = "GET";

            /* Sart browser signature */
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
            /* Sart browser signature */

            WebResponse response = request.GetResponse();
            _htmlDoc = new HtmlAgilityPack.HtmlDocument();
            _htmlDoc.OptionFixNestedTags = true;

            _htmlDoc.Load(response.GetResponseStream(), true);
        }

        public RestaurantViewModel GetDish(RestaurantViewModel restaurant)
        {
            if (restaurant.LunchHeader == "2 Valv och kök")
            {
                if (_dishes.Count >= 1)
                {
                    restaurant.FirstDish = HttpUtility.HtmlDecode(_dishes[0].OuterHtml);
                }
                if (_dishes.Count >= 2)
                {
                    restaurant.SecondDish = HttpUtility.HtmlDecode(_dishes[1].OuterHtml);
                }
                if (_dishes.Count >= 3)
                {
                    restaurant.VegitarianDish = HttpUtility.HtmlDecode(_dishes[2].OuterHtml);
                }
            }

            if (restaurant.LunchHeader == "Percys")
            {
                if (_dishes.Count >= 1)
                {
                    restaurant.FirstDish = HttpUtility.HtmlDecode(_dishes[0].OuterHtml);
                }
                if (_dishes.Count >= 2)
                {
                    restaurant.SecondDish = HttpUtility.HtmlDecode(_dishes[_dishes.Count -2].OuterHtml);
                }
                if (_dishes.Count >= 3)
                {
                    restaurant.VegitarianDish = HttpUtility.HtmlDecode(_dishes[_dishes.Count - 3].OuterHtml);
                }
            }

            return restaurant;
        }
    }
}
