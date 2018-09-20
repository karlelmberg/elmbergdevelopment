$(document).ready(function () {
    var show = false;
    $(".header .main-header .container .log-in-search .search").click(function () {
        if (!show) {          
            $(".header .search-panel").slideDown(400);
            $(" .header .main-header .container .log-in-search .search .search-down").css("display", "inline");
            $(" .header .main-header .container .log-in-search .search .search-up").css("display", "none");
            $(".greyed-search").css("display", "block");
            show = true;
        }
        else {          
            $(".header .search-panel").slideUp(400);
            $(" .header .main-header .container .log-in-search .search .search-down").css("display", "none");
            $(" .header .main-header .container .log-in-search .search .search-up").css("display", "inline");
            $(".greyed-search").css("display", "none");
            show = false;
        }
    });

    $(".news-list-item").matchHeight({
        byRow: true,
        property: 'height',
        target: null,
        remove: false
    });
});