(function () {

    var app = angular.module("gHackChildCare");

    var searchAndFilterService = function ($http, $q) {

        var getChildCareCentersBySuburb = function (suburb) {
            var baseUrl = "Search/GetAllChildCareBySuburb";
            return $http({
                method: "GET",
                url: baseUrl,
                params: { suburb: suburb }
            }).then(function (response) {
                    return response.data;
            }).catch(function (response) {
                console.log(response);
            });
        }

        var getAllSuburbs = function() {
            var baseUrl = "Home/GetAllSuburbs";
            return $http({
                method: "GET",
                url: baseUrl
            }).then(function (response) {
                return response.data;
            }).catch(function (response) {
                console.log(response);
            });
        }
        return {
            getChildCareCentersBySuburb: getChildCareCentersBySuburb,
            getAllSuburbs: getAllSuburbs
        }
    }

    app.factory("searchAndFilterService", searchAndFilterService);
}());