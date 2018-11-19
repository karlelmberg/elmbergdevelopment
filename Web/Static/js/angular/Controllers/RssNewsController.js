app.controller("RssNewsController", ["$scope", function ($scope) {
    $scope.rawNewsList = [];
    $scope.newsItemList = [];
    $scope.newsItem = {};

    $scope.init = function (rssItemList, sourceSupplier) {
        $scope.rssItemList = rssItemList;
        $scope.manipulaterssItemList(rssItemList, sourceSupplier);
        //$scope.setPager(rssItemList);
    }

    $scope.manipulaterssItemList = function (rssItemList, sourceSupplier) {
        if (sourceSupplier.Value === "idg") {
            $.each(rssItemList,
                function (key, value) {
                    var d = value.Description;
                    var i = d.split('<br>');
                    var im = i[0];
                    var ima = im.replace('<img src="', '');
                    var imag = ima.replace('" border="0">', '');
                    var image = imag.trim();
                    var description = i[1];
                    var link = value.Link;
                    var pDate = value.PublicationDate.replace(/\//g, "-");
                    var pubdate = new Date(pDate);
                    var publicationDate = pubdate.toISOString().slice(0, 10).replace(/-/g, "");
                    var title = value.Title;

                    $scope.newsItem = {
                        image: image,
                        link: link,
                        publicationDate: publicationDate,
                        title: title,
                        description: description
                    };
                    $scope.newsItemList.push($scope.newsItem);
                });
            $scope.newsItemList.sort(function (a, b) { return b.publicationDate - a.publicationDate });

            //$.each($scope.newsItemList,
            //    function (key, value) {
            //        var pub = new Date(value.publicationDate, "YYYY-MM-DD");
            //        value.publicationDate = pub;
            //});
        }

        if (sourceSupplier.Value === "epi") {          
                $.each(rssItemList,
                    function (key, value) {
                        //var d = value.Description;
                        //var i = d.split('<br>');
                        var d = value.Description.substr(0, 300);
                        var description = d += "...";
                        //var description = i[1];
                        var link = value.Link;
                        var pDate = value.PublicationDate.replace(/\//g, "-");
                        var pubdate = new Date(pDate);
                        var publicationDate = pubdate.toISOString().slice(0, 10).replace(/-/g, "");
                        var title = value.Title;
                        $scope.newsItem = {                          
                            link: link,
                            publicationDate: publicationDate,
                            title: title,
                            description: description
                        };
                        $scope.newsItemList.push($scope.newsItem);
                    });
                $scope.newsItemList.sort(function (a, b) { return b.publicationDate - a.publicationDate });
        }     
    }

    //$(document).ready(function () {
    //    $(".news-item").hover(function () {        
    //        $(".news-item-read-more-underline").css('background-color', 'white');
    //        $(".news-item-read-more-underline").animate({ width: ("60px") }, 200);               
    //    }, function () {
    //            $(".news-item-read-more-underline").animate({ width: ("0px") }, 200);
    //        }
    //    );
    //});

    //$(document).ready(function () {
    //    $(".news-item").hover(function () {
    //        $(".news-item-read-more").addClass("news-item-hovered");               
    //        }, function () {
    //            $(".news-item-read-more").removeClass("news-item-hovered");     
    //        }
    //    );
    //});

    $scope.animateReadMore = function (newsItem) {
        newsItem.selectedItem = true;
    }

    $scope.removeAnimateReadMore = function (newsItem) {
        newsItem.selectedItem = false;
    }

    function matchHeight() {
        $('.news-item-text-container').matchHeight({
            byRow: true,
            property: 'height',
            target: null,
            remove: false
        });
    }

    $scope.setHeight = function () {
        matchHeight();
    }

    //$scope.setPager = function (rssItemList) {
    //    var vm = this;

    //    vm.dummyItems = rssItemList; // dummy array of items to be paged
    //    vm.pager = {};
    //    vm.setPage = setPage;

    //    initController();

    //    function initController() {
    //        // initialize to page 1
    //        vm.setPage(1);
    //    }

    //    $scope.setListPage = function (page) {
    //        setPage(page);
    //    }

    //    function setPage(page) {
    //        if (page < 1 || page > vm.pager.totalPages) {
    //            return;
    //        }

    //        // get pager object from service
    //        vm.pager = pagerService.GetPager(vm.dummyItems.length, page, 20);
    //        $scope.pager = vm.pager;

    //        // get current page of items
    //        vm.items = vm.dummyItems.slice(vm.pager.startIndex, vm.pager.endIndex + 1);
    //        //$scope.firstItemsNewsList = vm.items.slice(0, 2);
    //        //vm.items.shift();
    //        //vm.items.shift();
    //        //$scope.followingItemsNewsList = vm.items;
    //        $scope.rssItemList = vm.items;

    //        window.scrollTo(0, 0);
    //    }
    //}

}]);