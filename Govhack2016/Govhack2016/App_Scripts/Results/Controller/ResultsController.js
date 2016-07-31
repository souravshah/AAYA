(function () {
    var app = angular.module("gHackChildCare");

    var resultsController = function (allChildCares, $scope, $state) {
        var vm = this;
        vm.allChildCares = allChildCares;

        vm.showFilter = function() {
            $scope.$broadcast("showFilter","SETFILTERS");
        }
    }
    app.controller("resultsController", ["allChildCares", "$scope", "$state", resultsController]);
}());