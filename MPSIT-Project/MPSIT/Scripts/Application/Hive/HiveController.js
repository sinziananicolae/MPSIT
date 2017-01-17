(function () {
    "use strict";

    angular.module("app").controller("HiveController",
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
        var interval;
       

        $scope.getHiveData = function () {
            HiveService.get({ param: $scope.selectedHive }, function (response) {
                $scope.hiveData = response;
                $scope.sensorsDataAsc = response.SensorsData.reverse();

                $scope.labels = [];
                var dataTemp = [];
                var dataHum = [];
                var dataWeight = [];
                var dataLight = [];

                _.each($scope.sensorsDataAsc, function (sensorData) {
                    $scope.labels.push(moment(sensorData.Timestamp).format("MM/DD/YYYY HH:mm:ss"));
                    dataTemp.push(sensorData.Temperature);
                    dataHum.push(sensorData.Humidity);
                    dataWeight.push(sensorData.Weight);
                    dataLight.push(sensorData.Light*100/255);
                });
                $scope.dataTemp = [dataTemp];
                $scope.dataHum = [dataHum];
                $scope.dataWeight = [dataWeight];
                $scope.dataLight = [dataLight];
            });

            if(!interval)
                interval = setInterval(function () {

                    $scope.getHiveData();
                }, 10000);
        };

        $scope.$on('$destroy', function () {
            clearInterval(interval);
        });

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