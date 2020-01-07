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
using DataTransferObjects.Dtos;

namespace Web.Controllers.Pages
{
    public class SportPageController : PageController<SportPage>
    {
        private PageViewModel<SportPage> _model;
        private string _externalUrl;
        private HtmlNode _externalDocument;
        private SportPageViewModel _sportPageViewModel;
        private HtmlNode _node;
        private HtmlDocument _htmlDoc;

        public override ActionResult Index(SportPage currentPage)
        {
            _model = PageViewModelBuilder.Create(currentPage);
     
            return View(_model);
        }

        [HttpGet]
        public JsonResult GetStandings()
        {
            try
            {
                _sportPageViewModel = new SportPageViewModel();

                //PremierLeagueTable
                _externalUrl = "https://www.fotbollskanalen.se/premier-league/?tab=tables";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@class='league-tables']").First();
                //var a = _node.SelectNodes(".//a");
                if (_node != null && _node.OuterHtml != null)
                {
                    _sportPageViewModel.PremierLeagueHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);
                }

                //PremierLeagueBestGoalScorersHtmlTable              
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@id='top-scorer']")?.First();
                if (_node != null && _node.OuterHtml != null)
                {
                    _sportPageViewModel.PremierLeagueBestGoalScorersHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);
                }                             

                //AllsvenskanLeagueTable
                _externalUrl = "https://www.fotbollskanalen.se/allsvenskan/?tab=tables";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@class='league-tables']")?.First();
                if (_node != null && _node.OuterHtml != null)
                {
                    _sportPageViewModel.AllsvenskanHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);
                }

                //AllsvenskanBestGoalScorersHtmlTable
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@id='top-scorer']")?.First();
                if (_node != null && _node.OuterHtml != null)
                {
                    _sportPageViewModel.AllsvenskanBestGoalScorersHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);
                }

                //LaLigaTable
                _externalUrl = "https://www.fotbollskanalen.se/la-liga/?tab=tables";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@class='league-tables']")?.First();
                if (_node != null && _node.OuterHtml != null)
                {
                    _sportPageViewModel.LaLigaHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);
                }

                //LaLigaBestGoalScorersHtmlTable
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@id='top-scorer']")?.First();
                if (_node != null && _node.OuterHtml != null)
                {
                    _sportPageViewModel.LaLigaBestGoalScorersHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);
                }

                //BundesLigaTable
                _externalUrl = "https://www.fotbollskanalen.se/bundesliga/?tab=tables";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@class='league-tables']")?.First();
                if (_node != null && _node.OuterHtml != null)
                {
                    _sportPageViewModel.BundesLigaHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);
                }

                //LaLigaBestGoalScorersHtmlTable
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@id='top-scorer']")?.First();
                if (_node != null && _node.OuterHtml != null)
                {
                    _sportPageViewModel.BundesLigaBestGoalScorersHtmlTable = HttpUtility.HtmlDecode(_node.OuterHtml);
                }

                return Json(_sportPageViewModel, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
                //throw ex;              
            }          
        }

        [HttpGet]
        public JsonResult GetNews()
        {
            try
            {
                _sportPageViewModel = new SportPageViewModel();

                //Football news
                _externalUrl = "https://www.fotbollskanalen.se/senaste/";
                GetHtmlDataFromExternalUrl();
                _node = _htmlDoc.DocumentNode.SelectNodes("//div[@class='main-content']").First();              
                _sportPageViewModel.FootballNews = HttpUtility.HtmlDecode(_node.OuterHtml);              

                return Json(_sportPageViewModel, JsonRequestBehavior.AllowGet);
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

        public JsonResult TestVue()
        {
            return Json("Fungerar att hämta JsonResult", JsonRequestBehavior.AllowGet);
        }
    }
}