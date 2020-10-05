using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModels
{
    public class WeatherPageViewModel
    {
        public string Time { get; set; }
        public string WeatherIcon { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
    }
}