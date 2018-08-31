var app = angular.module("edApp", []).config(['$locationProvider', '$httpProvider', function ($locationProvider,
    $httpProvider) {

    $locationProvider.html5Mode({ enabled: false, requireBase: false });


}]).factory('noCacheInterceptor', function () {
    return {
        request: function (config) {
            if (config.method === 'GET') {
                var separator = config.url.indexOf('?') === -1 ? '?' : '&';
                config.url = config.url + separator + 'noCache=' + new Date().getTime();
            }
            return config;
        }
    };
});
