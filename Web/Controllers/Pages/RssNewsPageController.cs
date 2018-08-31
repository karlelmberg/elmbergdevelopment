using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using KalikoCMS.Mvc.Framework;
using Web.Models.Pages;
using Web.Models.ViewModels;
using DataTransferObjects.Dtos;
using Web.Business.ViewModelBuilders;

namespace Web.Controllers.Pages
{
    public class RssNewsPageController : PageController<RssNewsPage>
    {
        private XmlTextReader _xmlReader;
        private XmlDocument _xmlDoc;
        private XmlElement _xmlRoot;
        private XmlNode _xmlNode;
        private XmlNode _xmlChildNode;
        private XmlNode _xmlDataNode;
        private List<RssItemDto> _rssItemList;
        private RssItemDto _rssItem;
        private string _rssSource;
        private PageViewModel<RssNewsPage> _model;

        public override ActionResult Index(RssNewsPage currentPage)
        {
            _model = PageViewModelBuilder.Create(currentPage);         
            //Initiate Data
            InitiateData();
            //Gets xml file from Rss source           
            GetXml();
            //Modify Xml Data
            ModifyXmlData();
            //Add Rss List to model
            currentPage.RssItemList = _rssItemList;

            return View(_model);
        }

        public void InitiateData()
        {
            if (_model.CurrentPage.RssUrl!= null)
                _rssSource = _model.CurrentPage.RssUrl.ToString();
        //    if (model.CurrentPage.RssFromDate.ToString("yyyy/MM/dd") != "")
        //        _rssSource += "&from_date=" + model.CurrentPage.RssFromDate.ToString("yyyy/MM/dd");
        //    if (model.CurrentPage.RssToDate.ToString("yyyy/MM/dd") != "")
        //        _rssSource += "&to_date=" + model.CurrentPage.RssToDate.ToString("yyyy/MM/dd");
        //    if (model.CurrentPage.RssItemCount.ToString() != "")
        //        _rssSource += "&count=" + model.CurrentPage.RssItemCount.ToString();

        //    //else
        //    //_rssSource = "http://accesstwo.observer.se/feed/default.aspx/st7075.std/rss20";
        }


        public void GetXml()
        {
            if (_rssSource != null)
            {
                try
                {
                    _rssItemList = new List<RssItemDto>();
                    _xmlReader = new XmlTextReader(_rssSource);
                    _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(_xmlReader);
                    _xmlRoot = _xmlDoc.DocumentElement;

                    //rss källa
                    if (_xmlRoot.Name == "rss")
                    {
                        //har version attribut
                        if (_xmlRoot.HasAttribute("version") == true)
                        {
                            //är version 2.0
                            if (_xmlRoot.Attributes["version"].Value == "2.0")
                            {
                                _xmlNode = _xmlRoot.FirstChild;
                                if (_xmlNode.Name == "channel")
                                {
                                    if (_xmlNode.HasChildNodes)
                                    {
                                        _xmlChildNode = _xmlNode.FirstChild;
                                        while (_xmlChildNode != null)
                                        {
                                            if (_xmlChildNode.Name == "item")
                                            {
                                                _rssItem = new RssItemDto();
                                                if (_xmlChildNode.HasChildNodes)
                                                {
                                                    _xmlDataNode = _xmlChildNode.FirstChild;
                                                    while (_xmlDataNode != null)
                                                    {
                                                        switch (_xmlDataNode.Name)
                                                        {
                                                            case "title":
                                                                _rssItem.Title = _xmlDataNode.InnerText;
                                                                break;
                                                            case "link":
                                                                _rssItem.Link = _xmlDataNode.InnerText;
                                                                break;

                                                            case "description":
                                                                _rssItem.Description = _xmlDataNode.InnerText;
                                                                break;
                                                            case "source":
                                                                _rssItem.Source = _xmlDataNode.InnerText;
                                                                break;
                                                            case "pubDate":
                                                                _rssItem.PublicationDate = _xmlDataNode.InnerText;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                        _xmlDataNode = _xmlDataNode.NextSibling;
                                                    }
                                                }
                                                _rssItemList.Add(_rssItem);
                                            }
                                            _xmlChildNode = _xmlChildNode.NextSibling;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //lblError.Text = "RSS-källa är inte av version 2.0, kontakta webbplatsens redaktör.";
                                //lblError.Visible = true;
                            }
                        }
                        else
                        {
                            //lblError.Text = "RSS-källa saknar versions nummer, kontakta webbplatsens redaktör.";
                            //lblError.Visible = true;
                        }
                    }
                    else
                    {
                        //lblError.Text = "Felaktig RSS-källa, kontakta webbplatsens redaktör.";
                        //lblError.Visible = true;
                    }

                    //rptNews.DataSource = alItem;
                    //rptNews.DataBind();

                    //gridArtiklar.DataSource = alItem;
                    //gridArtiklar.DataBind();
                }
                catch (Exception)
                {
                    //lblError.Text = "Ett fel inträffade vid läsning från RSS-källa, kontakta webbplatsens redaktör.";
                    //lblError.Visible = true;
                }
            }
            else
            {
                //lblError.Text = "RSS-källa saknas, kontakta webbplatsens redaktör.";
                //lblError.Visible = true;
            }
        }

        public void ModifyXmlData()
        {
            foreach (var rssItem in _rssItemList)
            {
                //Modify Date
                string r = rssItem.PublicationDate;
                DateTime dt = Convert.ToDateTime(r);
                string s = dt.ToString("yyyy/MM/dd");
                rssItem.PublicationDate = s.Substring(0, 10);

                //Modify Title
                string source = rssItem.Source;
                string title = rssItem.Title;
                rssItem.Title = title.Replace(source + ": ", "");

                //Modify Description 
                rssItem.Description = rssItem.Description.Replace("\r\n\t\t\t\t\t\t\t", "");
                //string description = rssItem.Description;
                //rssItem.Description = description.Substring(1);
            }
        }
    }
}