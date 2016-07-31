(function () {
    var app = angular.module("gHackChildCare");
    app.filter('propsFilter', function () {
        return function (items, props) {
            var out = [];

            if (angular.isArray(items)) {
                var keys = Object.keys(props);

                items.forEach(function (item) {
                    var itemMatches = false;

                    for (var i = 0; i < keys.length; i++) {
                        var prop = keys[i];
                        var text = props[prop].toLowerCase();
                        if (item[prop].toString().toLowerCase().indexOf(text) !== -1) {
                            itemMatches = true;
                            break;
                        }
                    }

                    if (itemMatches) {
                        out.push(item);
                    }
                });
            } else {
                // Let the output be the input untouched
                out = items;
            }

            return out;
        };
    });
    var homeController = function ($scope, $state, allSuburbs) {
        var vm = this;
        $scope.suburb = {};
        vm.selected = undefined;
        vm.allSuburbs = allSuburbs;
        vm.getAllChildCareCentersForSelectedSuburb = function () {
            if (vm.selected !== undefined) {
                $state.go("searchResults", { suburb: vm.selected });
            }
        }
    }
    app.controller("homeController", ["$scope", "$state", "allSuburbs", homeController]);
}());