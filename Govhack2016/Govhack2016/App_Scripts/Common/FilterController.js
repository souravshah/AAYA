(function () {
    var app = angular.module("gHackChildCare");
    var filterController = function ($scope) {
        var vm = this;
        vm.isDesktop = !WURFL.is_mobile;
        vm.showFilter = false;

        $scope.$on("showFilter",
            function (event, args) {
                if (args === "SETFILTERS") {
                    vm.showFilter = true;
                }
            });

        vm.cancelFilter = function() {
            vm.showFilter = false;
        }

        vm.applyFilter = function () {
            $scope.$emit("applyFilter");
            vm.showFilter = false;
        }
    }
    app.controller("filterController", filterController);
}());