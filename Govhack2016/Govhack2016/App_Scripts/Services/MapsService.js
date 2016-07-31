(function () {

    var app = angular.module("gHackChildCare");

    var mapsService = function ($http, $q) {

        var getLocationBoundaries = function (suburb) {
            var baseUrl =
                "http://data.gov.au/geoserver/nsw-suburb-locality-boundaries-psma-administrative-boundaries/wfs?request=GetFeature&typeName=91e70237_d9d1_4719_a82f_e71b811154c6&outputFormat=json&";
            baseUrl = baseUrl + "&CQL_FILTER=nsw_loca_2=%27" + suburb + "%27%20AND%20nsw_loca_7=%271%27&service=WFS";
            var deferred = $q.defer();
            $http({
                method: "GET",
                url: baseUrl
            })
                .success(deferred.resolve)
                .error(deferred.reject);

            return deferred.promise;
        }

        return {
            getLocationBoundaries: getLocationBoundaries
        }
    }

    app.factory("mapsService", mapsService);
}());