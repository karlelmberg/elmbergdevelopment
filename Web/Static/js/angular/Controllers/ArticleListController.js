app.controller("ArticleListController", ["$scope", function ($scope) {
    $scope.articleItemList = [];
 
    $scope.init = function (articleItemList) {
        $scope.articleItemList = articleItemList;
        //$scope.manipulateItemList(articleItemList);
        //$scope.setPager(rssItemList);
    }


    //$(document).ready(function () {
    //    $(".news-item").hover(function () {
    //        $(".news-item-read-more-underline").css('background-color', 'white');
    //        $(".news-item-read-more-underline").animate({ width: ("60px") }, 200);
    //    }, function () {
    //        $(".news-item-read-more-underline").animate({ width: ("0px") }, 200);
    //    }
    //    );
    //});

    //function matchHeight() {
    //    $(".news-item").matchHeight({
    //        byRow: true,
    //        property: 'height',
    //        target: null,
    //        remove: false
    //    });
    //}

    //$scope.setHeight = function () {
    //    matchHeight();
    //}

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