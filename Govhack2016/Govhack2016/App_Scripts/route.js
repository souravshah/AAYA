(function () {
    var app = angular.module("gHackChildCare");

    app.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/");
        if (WURFL.form_factor !== "Smartphone") {
            $stateProvider
                .state("home",
                {
                    url: "/",
                    controller: "homeController",
                    controllerAs: "vm",
                    templateUrl: "/Templates/home.html"
                })
                .state("searchResults",
                {
                    url: "/search/:id",
                    controller: "resultsController",
                    controllerAs: "vm",
                    templateUrl: "/Templates/searchResults.html"
                }
            );
        } else {
            $stateProvider
                .state("home",
                {
                    url: "/",
                    controller: "homeController",
                    controllerAs: "vm",
                    templateUrl: "/Templates/mobileHome.html",
                    resolve: {
                        allSuburbs: function (searchAndFilterService) {
                            return searchAndFilterService.getAllSuburbs();
                        }
                    }
                })
                .state("searchResults",
                {
                    url: "/search/:suburb",
                    controller: "resultsController",
                    controllerAs:"vm",
                    templateUrl: "/Templates/mobileSearchResults.html",
                    resolve: {
                        allChildCares: function (searchAndFilterService, $stateParams) {
                            return searchAndFilterService.getChildCareCentersBySuburb($stateParams.suburb);
                        }
                    }
                }
            );
        }
    }]);
}());