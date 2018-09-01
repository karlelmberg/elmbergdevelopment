app.controller("RssNewsController", ["$scope", function ($scope) {
    $scope.rawNewsList = [];
    $scope.newsItemList = [];
    $scope.newsItem = {};

    $scope.init = function (rssItemList) {
        $scope.rssItemList = rssItemList;
        $scope.manipulaterssItemList(rssItemList);
        //$scope.setPager(rssItemList);

    }
  
    $scope.manipulaterssItemList = function (rssItemList) {
        $.each(rssItemList,
            function (key, value) {
                var d = value.Description;
                var i = d.split('<br>');
                var image = i[0];
                var description = i[1];
                var link = value.Link;
                var publicationDate = value.PublicationDate.replace(/\//g, "-");               
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
       
        //var description = rssItemList.title.description;
        //var parts = myString.split("Half");
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

    //function matchHeight() {
    //    $('.news-page-item-wrapper').matchHeight({
    //        byRow: true,
    //        property: 'height',
    //        target: null,
    //        remove: false
    //    });
    //}


}]);