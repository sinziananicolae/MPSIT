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

                _.each($scope.data, function (apiary) {
                    var hives = _.filter(apiary.Hives, function (hive) { return hive.HiveFile });
                    apiary.groupedHiveFiles = _.groupBy(hives, function (item) { return item.HiveFile.Status });
                    console.log(apiary.groupedHiveFiles);
                });
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

        $scope.getStatusClass = function (key) {
            var classStyle = "";
            switch (key) {
                case 'Strong': classStyle = 'label label-success label-form'; break;
                case 'Medium': classStyle = 'label label-warning label-form'; break;
                case 'Weak': classStyle = 'label label-primary label-form'; break;
                case 'Sick': classStyle = 'label label-danger label-form'; break;
            }

            return classStyle;
        };

        $scope.getProgressClass = function (key) {
            var classStyle = "";
            switch (key) {
                case 'Strong': classStyle = 'progress-bar progress-bar-success'; break;
                case 'Medium': classStyle = 'progress-bar progress-bar-warning'; break;
                case 'Weak': classStyle = 'progress-bar progress-bar-primary'; break;
                case 'Sick': classStyle = 'progress-bar progress-bar-danger'; break;
            }

            return classStyle;
        };

        $scope.getStatusPercent = function (no, apiary, style) {
            var percent = no * 100 / apiary.Hives.length;
            if (style) {
                return { "width": +percent + "%" };

            }
            else return percent;

        };

    }
}());