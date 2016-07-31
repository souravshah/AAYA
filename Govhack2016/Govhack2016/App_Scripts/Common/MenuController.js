(function () {
    var app = angular.module("gHackChildCare");
    var menuController = function ($scope) {
        $scope.isDesktop = !WURFL.is_mobile;
        $scope.removeFilter = false;
        $scope.LoginStatus = "Login";
    }
    app.controller("menuController", menuController);
}());