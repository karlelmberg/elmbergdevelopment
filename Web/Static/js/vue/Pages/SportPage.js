


var sport = new Vue({
    el: '#vueApp',
    data: {
        //Menus
        sportMenu: true,
        footballLeagueMenu: false,
        premierFootballLeagueTypeMenu: false,
        allsvenskanFootballLeagueTypeMenu: false,
        bundesLigaFootballLeagueTypeMenu: false,
        laLigaFootballLeagueTypeMenu: false,

        //Panels
        premierLeaguePanel: {},
        allsvenskanPanel: false,
        laLigaPanel: false,
        bundesLigaPanel: false,
        footballNewsPanel: false,

        //Tables
        premierLeagueTable: {},
        premierLeagueBestGoalScorersTable: {},
        allsvenskanTable: {},
        allsvenskanBestGoalScorersTable: {},
        laLigaTable: {},
        laLigaBestGoalScorersTable: {},
        bundesLigaTable: {},
        bundesLigaBestGoalScorersTable: {},

        //News
        footballNews: {},

        //Buttons
        footballBtn: false,
        bandyBtn: false,

        leagueNewsBtn: false,
        leagueTableBtn: false,
        leagueMatchesBtn: false,

        premierLeagueBtn: false,
        allsvenskanBtn: false,
        laLigaBtn: false,
        bundesLigaBtn: false

    },
    methods: {
        getStandings: function () {
            $('.spinner-background').show();
            $('.edspinner').show();
            var self = this;
            axios.get('/SportPage/GetStandings')
                .then(function (response) {
                    console.log(response.data);
                    console.log(response.status);
                    if (response.data !== "") {
                        self.premierLeagueTable = response.data.PremierLeagueHtmlTable;
                        self.premierLeagueBestGoalScorersTable = response.data.PremierLeagueBestGoalScorersHtmlTable;
                        self.allsvenskanTable = response.data.AllsvenskanHtmlTable;
                        self.allsvenskanBestGoalScorersTable = response.data.AllsvenskanBestGoalScorersHtmlTable;
                        self.laLigaTable = response.data.LaLigaHtmlTable;
                        self.laLigaBestGoalScorersTable = response.data.LaLigaBestGoalScorersHtmlTable;
                        self.bundesLigaTable = response.data.BundesLigaHtmlTable;
                        self.bundesLigaBestGoalScorersTable = response.data.BundesLigaBestGoalScorersHtmlTable;
                        $('.spinner-background').hide();
                        $('.edspinner').hide();
                        $('.hide-vue').show();
                    } else {
                        $('.spinner-background').hide();
                        $('.edspinner').hide();
                        $('.hide-vue').show();
                        alert("Data kunde inte hämtas");
                    }
                })
                .catch(error => {
                    console.log(error);
                    this.error = true;
                    alert("Något gick fel");
                });
        },

        getNews: function () {
            $('.spinner-background').show();
            $('.edspinner').show();
            var self = this;
            axios.get('/SportPage/GetNews')
                .then(function (response) {
                    console.log(response.data);
                    console.log(response.status);
                    self.footballNews = response.data.FootballNews;
                    $('.spinner-background').hide();
                    $('.edspinner').hide();
                    $('.hide-vue').show();
                })
                .catch(error => {
                    console.log(error);
                    this.error = true;
                    alert("error");
                });
        },

        initSportMenu: function () {
            this.initPanelsButtonsAndMenus();
            this.sportMenu = true;
        },

        chooseSport: function (sport) {
            this.initPanelsButtonsAndMenus();
            switch (sport) {
                case "football":
                    this.footballLeagueMenu = true;
                    this.footballBtn = true;
                    this.getNews();
                    this.footballNewsPanel = true;
                    break;
                case "bandy":
                    this.bandyBtn = true;
                    break;
            }
        },

        chooseLeague: function (league) {
            this.initPanelsButtonsAndMenus();
            switch (league) {
                case "premierLeague":
                    this.premierLeagueBtn = true;
                    this.premierFootballLeagueTypeMenu = true;
                    break;
                case "allsvenskan":
                    this.allsvenskanBtn = true;
                    this.allsvenskanFootballLeagueTypeMenu = true;
                    break;
                case "laLiga":
                    this.laLigaBtn = true;
                    this.laLigaFootballLeagueTypeMenu = true;
                    break;
                case "bundesLiga":
                    this.bundesLigaBtn = true;
                    this.bundesLigaFootballLeagueTypeMenu = true;
                    break;
            }
        },

        chooseLeagueType: function (leagueType, league) {
            this.initPanelsButtonsAndMenus();
            if (league == 'premierLeague') {
                this.premierFootballLeagueTypeMenu = true;
                switch (leagueType) {
                    case "news":
                        this.leagueNewsBtn = true;
                        break;
                    case "table":
                        this.premierLeaguePanel = true;
                        this.leagueTableBtn = true;
                        this.getStandings();
                        break;
                    case "matches":
                        this.laLigaPanel = true;
                        this.leagueMatchesBtn = true;
                        break;
                }
            }
            if (league == 'allsvenskan') {
                this.allsvenskanFootballLeagueTypeMenu = true;
                switch (leagueType) {
                    case "news":
                        this.leagueNewsBtn = true;
                        break;
                    case "table":
                        this.allsvenskanPanel = true;
                        this.leagueTableBtn = true;
                        this.getStandings();
                        break;
                    case "matches":
                        this.laLigaPanel = true;
                        this.leagueMatchesBtn = true;
                        break;
                }
            }
            if (league == 'bundesLiga') {
                this.bundesLigaFootballLeagueTypeMenu = true;
                switch (leagueType) {
                    case "news":
                        this.leagueNewsBtn = true;
                        break;
                    case "table":
                        this.bundesLigaPanel = true;
                        this.leagueTableBtn = true;
                        this.getStandings();
                        break;
                    case "matches":
                        this.laLigaPanel = true;
                        this.leagueMatchesBtn = true;
                        break;
                }
            }
            if (league == 'laLiga') {
                this.laLigaFootballLeagueTypeMenu = true;
                switch (leagueType) {
                    case "news":
                        this.leagueNewsBtn = true;
                        break;
                    case "table":
                        this.laLigaPanel = true;
                        this.leagueTableBtn = true;
                        this.getStandings();
                        break;
                    case "matches":
                        this.laLigaPanel = true;
                        this.leagueMatchesBtn = true;
                        break;
                }
            }

        },

        initPanelsButtonsAndMenus: function () {
            //Menus
            this.sportMenu = false,
                this.footballLeagueMenu = false,
                this.premierFootballLeagueTypeMenu = false,
                this.allsvenskanFootballLeagueTypeMenu = false,
                this.bundesLigaFootballLeagueTypeMenu = false,
                this.laLigaFootballLeagueTypeMenu = false,

                //Panels
                this.allsvenskanPanel = false;
            this.premierLeaguePanel = false;
            this.laLigaPanel = false;
            this.bundesLigaPanel = false;
            this.footballNewsPanel = false,

                //Buttons
                this.leagueNewsBtn = false;
            this.leagueTableBtn = false;
            this.leagueMatchesBtn = false;
            this.footballBtn = false;
            this.bandyBtn = false;
            this.premierLeagueBtn = false;
            this.allsvenskanBtn = false;
            this.laLigaBtn = false;
            this.bundesLigaBtn = false;

        },

    },
    mounted() {
        $('.hide-sport').show();
    }
});


