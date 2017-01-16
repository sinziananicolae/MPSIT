(function () {
    "use strict";

    angular.module("app").controller("ApiaryController",
			["$scope", "$routeParams", "ApiaryService", apiaryController]);

    function apiaryController($scope, $routeParams, ApiaryService) {
        $scope.apiaryId = $routeParams.id;

        ApiaryService.get(function (response) {
            $scope.data = response.data;
        });

        $scope.getClass = function (type, values) {
            switch (type) {
                case 'h':
                    if (values.Humidity < 30 || values.Humidity > 70)
                        return 'warning-out-of-range';
                    break;
                case 't':
                    if (values.Temperature > 30)
                        return 'warning-out-of-range';
                    else if (values.Temperature < 5)
                        return 'warning-cold';
                    break;
                case 'w':
                    if (values.Weight > 25)
                        return 'hive-ready';
                    break;
            }
        }

    }
}());