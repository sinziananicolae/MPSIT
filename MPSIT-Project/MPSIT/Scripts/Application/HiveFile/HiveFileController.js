(function () {
    "use strict";

    angular.module("app").controller("HiveFileController",
			["$scope", "$routeParams", "ApiaryService", "HiveService", hiveFileController]);

    function hiveFileController($scope, $routeParams, ApiaryService, HiveService) {
        ApiaryService.get({ param: "allIds" }, function (response) {
            $scope.data = response.data;
            
            if ($routeParams.id) {
                var hive;
                var apiary = _.find($scope.data, function (apiary) {
                    hive = _.find(apiary.Hives, function (hive) {
                        return hive.Id == $routeParams.id;
                    });
                    if (hive) return true;
                });
                $scope.selectedApiary = apiary.Id;
                $scope.hives = apiary.Hives;
                $scope.selectedHive = hive.Id;
                $scope.getHiveData();
            } else {
                $scope.selectedApiary = $scope.data[0].Id;
                $scope.setHivesForApiary($scope.data[0]);
            }
        });

        $scope.setHivesForApiary = function (apiary) {
            $scope.hives = apiary.Hives;
            $scope.selectedHive = $scope.hives[0].Id;
        };

        setInterval(function () { $scope.getHiveData(); }, 10000);

        $scope.getHiveData = function () {
            HiveService.get({ param: $scope.selectedHive }, function (response) {
                $scope.hiveData = response;
                $scope.sensorsDataAsc = response.SensorsData.reverse();

                createTempChart();
                createHumChart();
            });
        };

        function createTempChart() {
            
            $scope.labelsTemp = [];
            var data = [];

            _.each($scope.sensorsDataAsc, function (sensorData) {
                $scope.labelsTemp.push(moment(sensorData.Timestamp).format("MM/DD/YYYY HH:mm:ss"));
                data.push(sensorData.Temperature);
            });
            $scope.dataTemp = [data];

        }

        function createHumChart() {

            $scope.labelsHum = [];
            var data = [];

            _.each($scope.sensorsDataAsc, function (sensorData) {
                $scope.labelsHum.push(moment(sensorData.Timestamp).format("MM/DD/YYYY HH:mm:ss"));
                data.push(sensorData.Humidity);
            });
            $scope.dataHum = [data];

        }

        $scope.getClass = function (type, values) {
            switch (type) {
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