using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KalikoCMS.Attributes;
using KalikoCMS.Core;

namespace Web.Models.Pages
{
    [PageType(
       "WeatherPage",
       "Weather Page",
       "Page for displaying temperature, wind and weather from https://www.sydsvenskan.se/vader/")
    ]
    public class WeatherPage : CmsPage
    {
        
    }
}