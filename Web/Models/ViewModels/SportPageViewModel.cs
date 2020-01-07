using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModels
{
    public class SportPageViewModel
    {
        //Standings
        public string PremierLeagueHtmlTable { get; set; }
        public string PremierLeagueBestGoalScorersHtmlTable { get; set; }
        public string LaLigaHtmlTable { get; set; }
        public string LaLigaBestGoalScorersHtmlTable { get; set; }
        public string BundesLigaHtmlTable { get; set; }
        public string BundesLigaBestGoalScorersHtmlTable { get; set; }
        public string AllsvenskanHtmlTable { get; set; }
        public string AllsvenskanBestGoalScorersHtmlTable { get; set; }
        public string Division5SodraHtmlTable { get; set; }

        //News
        public string FootballNews { get; set; }

    }
}