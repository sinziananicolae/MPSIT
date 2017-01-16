(function () {
    "use strict";

    angular.module("app").controller("ApiaryController",
			["$scope", "$routeParams", "ApiaryService", apiaryController]);

    function apiaryController($scope, $routeParams, ApiaryService) {
        $scope.apiaryId = $routeParams.id;
        $scope.template = "hiveInfo.html";


        ApiaryService.get(function (response) {
            
            if ($scope.apiaryId) {
                var apiary = _.find(response.data, function (data) { return data.Id == $scope.apiaryId });
                $scope.data = [apiary];
            } else {
                $scope.data = response.data;
            }
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
                case 's':
                    switch (values.Status) {
                        case "Weak":
                            return 'warning-cold';
                        case "Medium":
                            return 'warning-medium';
                        case "Strong":
                            return 'hive-ready';
                        case "Sick":
                            return 'warning-out-of-range';
                    }
                    break;
            }
        }

    }
}());