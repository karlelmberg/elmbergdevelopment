$(document).ready(function () {

    /* menu */
    $("#show-device-menu").on("click", function (e) {
        e.preventDefault();
        var $this = $(this);
        if ($this.hasClass("open")) {
            $("#main").show();
            $this.removeClass("open");
            $(".device-header-menu").removeClass("open");
        } else {
            $("#main").hide();
            $this.addClass("open");
            $(".device-header-menu").addClass("open");
        }
    });

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

    checkBrowser();
});

//Check if browser is Internet explorer

function checkBrowser() {
    var isIE = false || !!document.documentMode;
    if (isIE) {
        var ieCookieSet = readCookie('iECookieSet');
        if (ieCookieSet != "true") {
            $('#check-browser-modal').modal('show');
        }
    }
}

$('#close-check-browser-modal').click(function () {
    document.cookie = "iECookieSet=true";
});

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}